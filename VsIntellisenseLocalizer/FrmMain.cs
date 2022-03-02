using Flurl.Http;

using System.IO.Compression;
using System.Security.Principal;
using VsIntellisenseLocalizer.Consts;
using VsIntellisenseLocalizer.Models;
using VsIntellisenseLocalizer.Utils;
using VsIntellisenseLocalizer.Utils.Exentsions;

namespace VsIntellisenseLocalizer
{
    public partial class frmMain : Form
    {
        private List<IntelliSenseFile> _intelliSenseFiles;
        private List<InstalledNet> _installedNets;
        private DownloadResource _selectedResource;
        private InstalledNet _selectedInstalledNet;
        private bool _isAdministrator;
        public frmMain()
        {
            InitializeComponent();
            InitLocale();
            ScanInstalledNet();
        }

        private void InitLocale()
        {
            Text = L.MainTitle.Locale();
            btnSelectDownloadFolder.Text = L.Main_Button_SelectDownloadFolder.Locale();
            btnInstallLocalizePackage.Text = L.Main_Button_InstallLocalizePackage.Locale();
            lbAvailableNetVersion.Text = L.Main_Label_AvailableNetVersion.Locale();
            lbInstalledNetVersion.Text = L.Main_Label_InstalledNetVersion.Locale();
        }

        private void ScanInstalledNet()
        {
            var selectionMode = lboxInstalledVersions.SelectionMode;
            lboxInstalledVersions.SelectionMode = SelectionMode.None;
            var folders = Directory.GetDirectories(VilConst.Folder_NETCore_App_Ref);
            _installedNets = folders
                .Select(x => new InstalledNet
                {
                    FullFolderName = x
                })
                .OrderByDescending(x => x.VersionName)
                .ToList();
            lboxInstalledVersions.DataSource = _installedNets;
            lboxInstalledVersions.ValueMember = "VersionName";
            lboxInstalledVersions.DisplayMember = "VersionName";
            lboxInstalledVersions.SelectionMode = selectionMode;
        }

        public bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            _isAdministrator = IsAdministrator();
            if (!_isAdministrator)
            {
                MessageBox.Show(L.Message_Alert_IsAdministrator);
                Application.Exit();
            }
            try
            {
                _intelliSenseFiles = await PackageDownloader.DownloadIntelliSenseFile();
                var selectionMode = lboxVersions.SelectionMode;
                lboxVersions.SelectionMode = SelectionMode.None;
                lboxVersions.DataSource = _intelliSenseFiles;
                lboxVersions.ValueMember = "Version";
                lboxVersions.DisplayMember = "Version";
                lboxVersions.SelectionMode = selectionMode;
                lboxVersions.SelectedIndex = 0;
                UpdateStatusText(L.Main_StatusLeft_Ready.Locale());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lboxVersions_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lboxVersions.SelectedIndex < 0)
            {
                return;
            }
            var item = (IntelliSenseFile)lboxVersions.SelectedItem;
            var files = _intelliSenseFiles.Where(x => x.Version == item.Version).SelectMany(x => x.Resources).ToList();
            lvIntelliSenseFiles.Items.Clear();
            foreach (var b in files)
            {
                var lvi = new ListViewItem
                {
                    Text = b.Title
                };
                lvi.SubItems.Add(b.Url);
                lvi.SubItems.Add(b.Id.ToString());
                lvi.Tag = b;
                lvIntelliSenseFiles.Items.Add(lvi);
            }
            lvIntelliSenseFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvIntelliSenseFiles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            var version = item.Version.Replace("x", "");
            var selected = _installedNets.FirstOrDefault(x => x.VersionName.StartsWith(version));
            lboxInstalledVersions.SelectedItem = selected;
            _selectedInstalledNet = selected;
            _selectedResource = null;
        }

        private void lvIntelliSenseFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvIntelliSenseFiles.SelectedIndices.Count <= 0)
            {
                return;
            }
            var selectedIndex = lvIntelliSenseFiles.SelectedIndices[0];
            if (selectedIndex < 0) return;
            _selectedResource = (DownloadResource)lvIntelliSenseFiles.Items[selectedIndex].Tag;
        }

        private void btnSelectDownloadFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = L.Main_FolderBrowserDialog_Description.Locale();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDownloadFolder.Text = dialog.SelectedPath;
            }
        }

        private async void btnInstallLocalizePackage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDownloadFolder.Text))
            {
                MessageBox.Show(L.Message_Alert_SelectStorageLocation.Locale());
                return;
            }
            if (_selectedResource == null || string.IsNullOrEmpty(_selectedResource.Url))
            {
                MessageBox.Show(L.Message_Alert_SelectPackageFile.Locale());
                return;
            }

            if (lboxInstalledVersions.SelectedItem == null || lboxInstalledVersions.SelectedIndex < 0)
            {
                MessageBox.Show(L.Message_Alert_SelectNetVersion.Locale());
                return;
            }
            var sourceFile = Path.Combine(txtDownloadFolder.Text, _selectedResource.FileName);
            if (!File.Exists(sourceFile))
            {
                btnInstallLocalizePackage.Enabled = false;
                UpdateStatusText(L.Message_Alert_PackageDownloading.Locale());
                await _selectedResource.Url.DownloadFileAsync(txtDownloadFolder.Text, _selectedResource.FileName);
                btnInstallLocalizePackage.Enabled = true;
                UpdateStatusText(L.Message_Alert_PackageDownloaded.Locale());
            }

            // unzip package
            var distFolder = Path.Combine(txtDownloadFolder.Text);
            if (!Directory.Exists(Path.Combine(txtDownloadFolder.Text, _selectedResource.FileNameWithoutExt)))
            {
                ZipFile.ExtractToDirectory(sourceFile, distFolder);
            }

            // copy localized package to .NET assembly folder
            var distFolders = new List<string> { "Microsoft.NETCore.App.Ref", "Microsoft.WindowsDesktop.App.Ref" };
            foreach (var folder in distFolders)
            {
                var f = InstalledNetFolderService.GetFolder(_selectedInstalledNet.VersionName);
                var target = Path.Combine(VilConst.DotNetPacksRoot, folder, _selectedInstalledNet.VersionName);
                if (!Directory.Exists(target))
                {
                    continue;
                }
                var dist = Path.Combine(VilConst.DotNetPacksRoot, folder, _selectedInstalledNet.VersionName, "ref", f.TargetName, _selectedResource.Lang);
                if (!Directory.Exists(dist))
                {
                    Directory.CreateDirectory(dist);
                }
                var source = Path.Combine(txtDownloadFolder.Text, _selectedResource.FileNameWithoutExt, folder, _selectedResource.Lang);
                UpdateStatusText(L.Message_Alert_CopyingPackage.Locale(folder));
                FileHelper.CopyFilesRecursively(source, dist);
                UpdateStatusText(L.Message_Alert_CopyPackageSuccessful.Locale(folder));
            }

            // Copy NETStandard.Library.Ref
            UpdateStatusText(L.Message_Alert_CopyingPackage.Locale("NETStandard.Library.Ref"));
            var sourceStandard = Path.Combine(txtDownloadFolder.Text, _selectedResource.FileNameWithoutExt, "NETStandard.Library.Ref", _selectedResource.Lang);
            var distStandard = Path.Combine(VilConst.DotNetPacksRoot, "NETStandard.Library.Ref", "2.1.0", "ref", "netstandard2.1", _selectedResource.Lang);
            if (!Directory.Exists(distStandard))
            {
                Directory.CreateDirectory(distStandard);
            }
            FileHelper.CopyFilesRecursively(sourceStandard, distStandard);
            UpdateStatusText(L.Message_Alert_CopyPackageSuccessful.Locale("NETStandard.Library.Ref"));
            UpdateStatusText(L.Message_Alert_LocalizedSuccessful.Locale());
            MessageBox.Show(L.Message_Alert_LocalizedSuccessful.Locale());
        }

        private void UpdateStatusText(string message)
        {
            statusLeft.Text = message;
        }
    }
}