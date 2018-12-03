namespace SB.LogoInterpreter
{
  partial class FrmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
      this.txtSource = new System.Windows.Forms.TextBox();
      this.msMain = new System.Windows.Forms.MenuStrip();
      this.msMain_tsmiRun = new System.Windows.Forms.ToolStripMenuItem();
      this.msMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtSource
      // 
      this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtSource.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtSource.Location = new System.Drawing.Point(0, 24);
      this.txtSource.Multiline = true;
      this.txtSource.Name = "txtSource";
      this.txtSource.Size = new System.Drawing.Size(607, 426);
      this.txtSource.TabIndex = 0;
      // 
      // msMain
      // 
      this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMain_tsmiRun});
      this.msMain.Location = new System.Drawing.Point(0, 0);
      this.msMain.Name = "msMain";
      this.msMain.Size = new System.Drawing.Size(607, 24);
      this.msMain.TabIndex = 1;
      this.msMain.Text = "menuStrip1";
      // 
      // msMain_tsmiRun
      // 
      this.msMain_tsmiRun.Image = global::SB.LogoInterpreter.Properties.Resources.StdImg_Run;
      this.msMain_tsmiRun.Name = "msMain_tsmiRun";
      this.msMain_tsmiRun.Size = new System.Drawing.Size(28, 20);
      this.msMain_tsmiRun.Click += new System.EventHandler(this.msMain_tsmiRun_Click);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(607, 450);
      this.Controls.Add(this.txtSource);
      this.Controls.Add(this.msMain);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.msMain;
      this.Name = "FrmMain";
      this.Text = "SB.LogoInterpreter";
      this.msMain.ResumeLayout(false);
      this.msMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSource;
    private System.Windows.Forms.MenuStrip msMain;
    private System.Windows.Forms.ToolStripMenuItem msMain_tsmiRun;
  }
}

