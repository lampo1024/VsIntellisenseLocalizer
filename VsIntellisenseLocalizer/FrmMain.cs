using VsIntellisenseLocalizer.Consts;
using VsIntellisenseLocalizer.Utils;

namespace VsIntellisenseLocalizer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Text = VilResourceManager.GetResource(L.MainTitle);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}