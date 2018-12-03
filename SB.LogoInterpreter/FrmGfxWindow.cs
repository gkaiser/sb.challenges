using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace SB.LogoInterpreter
{
  public partial class FrmGfxWindow : Form
  {
    public Turtle Turtle;

    private const int FRAMES_PER_SECOND = 20;
    private Timer RedrawTimer;

    public FrmGfxWindow(FrmMain p, string src)
    {
      InitializeComponent();

      this.DoubleBuffered = true;

      this.BackColor = Color.Black;

      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(p.Location.X + p.Width + 48, p.Location.Y);

      this.Turtle = new Turtle(0, 0, src);

      this.RedrawTimer = new Timer();
      this.RedrawTimer.Interval = (int)(1m / FrmGfxWindow.FRAMES_PER_SECOND * 1000m);
      this.RedrawTimer.Tick += (s, ttea) => { this.Turtle.ProcessSource(); this.Invalidate(); };
      this.RedrawTimer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      e.Graphics.DrawImage(this.Turtle.Drawing, this.ClientRectangle);
    }

    private void FrmGfxWindow_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        this.Close();
      }
      else if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
    }

  }
}
