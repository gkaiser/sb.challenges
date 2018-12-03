using System;
using System.Linq;
using System.Windows.Forms;

namespace SB.LogoInterpreter
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();

      txtSource.Text = "fd 60 rt 120 fd 60 rt 120 fd 60 rt 120";
      txtSource.Select(txtSource.Text.Length, 0);
    }

    private void msMain_tsmiRun_Click(object sender, EventArgs e)
    {
      new FrmGfxWindow(this, txtSource.Text).Show();
    }
  }
}
