// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.Video.VideoForm
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using MvCameraControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

#nullable enable
namespace buCameraSolutions.Video;

public class VideoForm : Form
{
  private IDevice device;
  private string settingsFile;
  private bool _isInternalChange = false;
  private 
  #nullable disable
  IContainer components = (IContainer) null;
  public PictureBox pboxVideo;
  private NumericUpDown numUDGCManExp;
  private NumericUpDown numUDGain;
  private Label lblExposure;
  private Label lblGain;
  private Button btnMinimize;
  private Button btnExtend;
  private Button btnCancel;

  public VideoForm(
  #nullable enable
  IDevice camDevice, string settings)
  {
    this.InitializeComponent();
    this.device = camDevice;
    this.settingsFile = settings;
  }

  public void Setup(IDevice camDevice, string settings)
  {
    this.device = camDevice;
    this.settingsFile = settings;
    this._isInternalChange = true;
    this.numUDGCManExp.Value = Variables.gencamExpManual;
    this.numUDGain.Value = Variables.gencamGain;
    this._isInternalChange = false;
  }

  private void UpdateVariables()
  {
    if (!(Variables.camModel == "Gencam"))
      return;
    Variables.gencamExpManual = this.numUDGCManExp.Value;
    Variables.gencamGain = this.numUDGain.Value;
  }

  private void btnStart_Click(object sender, EventArgs e)
  {
  }

  private void btnStop_Click(object sender, EventArgs e)
  {
  }

  private void numUDGCManExp_ValueChanged(object sender, EventArgs e)
  {
    if (this._isInternalChange)
      return;
    Variables.gencamExpManual = this.numUDGCManExp.Value;
    if (this.device != null)
    {
      int num1 = this.device.Parameters.SetFloatValue("ExposureTime", (float) Variables.gencamExpManual);
      if (num1 != 0)
      {
        int num2 = (int) MessageBox.Show("Set Exposure Time Fail: " + num1.ToString());
      }
    }
    Variables.WriteCameraSettings(this.settingsFile);
  }

  private void numUDGain_ValueChanged(object sender, EventArgs e)
  {
    if (this._isInternalChange)
      return;
    Variables.gencamGain = this.numUDGain.Value;
    if (this.device != null)
    {
      int num1 = this.device.Parameters.SetFloatValue("Gain", (float) Variables.gencamGain);
      if (num1 != 0)
      {
        int num2 = (int) MessageBox.Show("Set Gain Fail: " + num1.ToString());
      }
    }
    Variables.WriteCameraSettings(this.settingsFile);
  }

  private void btnCancel_Click(object sender, EventArgs e) => this.Close();

  private void btnExtend_Click(object sender, EventArgs e)
  {
    if (this.WindowState == FormWindowState.Maximized)
      this.WindowState = FormWindowState.Normal;
    else
      this.WindowState = FormWindowState.Maximized;
    this.Invalidate();
  }

  private void btnMinimize_Click(object sender, EventArgs e)
  {
    this.WindowState = FormWindowState.Minimized;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (VideoForm));
    this.pboxVideo = new PictureBox();
    this.numUDGCManExp = new NumericUpDown();
    this.numUDGain = new NumericUpDown();
    this.lblExposure = new Label();
    this.lblGain = new Label();
    this.btnMinimize = new Button();
    this.btnExtend = new Button();
    this.btnCancel = new Button();
    ((ISupportInitialize) this.pboxVideo).BeginInit();
    ((ISupportInitialize) this.numUDGCManExp).BeginInit();
    ((ISupportInitialize) this.numUDGain).BeginInit();
    this.SuspendLayout();
    this.pboxVideo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.pboxVideo.Location = new Point(22, 29);
    this.pboxVideo.Name = "pboxVideo";
    this.pboxVideo.Size = new Size(1229, 770);
    this.pboxVideo.SizeMode = PictureBoxSizeMode.Zoom;
    this.pboxVideo.TabIndex = 0;
    this.pboxVideo.TabStop = false;
    this.numUDGCManExp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.numUDGCManExp.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDGCManExp.ForeColor = Color.White;
    this.numUDGCManExp.Location = new Point(1288, 177);
    this.numUDGCManExp.Maximum = new Decimal(new int[4]
    {
      2000000,
      0,
      0,
      0
    });
    this.numUDGCManExp.Name = "numUDGCManExp";
    this.numUDGCManExp.Size = new Size(120, 23);
    this.numUDGCManExp.TabIndex = 10;
    this.numUDGCManExp.ValueChanged += new EventHandler(this.numUDGCManExp_ValueChanged);
    this.numUDGain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.numUDGain.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDGain.ForeColor = Color.White;
    this.numUDGain.Location = new Point(1288, 274);
    this.numUDGain.Maximum = new Decimal(new int[4]
    {
      1000000,
      0,
      0,
      0
    });
    this.numUDGain.Name = "numUDGain";
    this.numUDGain.Size = new Size(120, 23);
    this.numUDGain.TabIndex = 11;
    this.numUDGain.ValueChanged += new EventHandler(this.numUDGain_ValueChanged);
    this.lblExposure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lblExposure.AutoSize = true;
    this.lblExposure.Font = new Font("Segoe UI", 12f);
    this.lblExposure.ForeColor = Color.White;
    this.lblExposure.Location = new Point(1310, 153);
    this.lblExposure.Name = "lblExposure";
    this.lblExposure.Size = new Size(73, 21);
    this.lblExposure.TabIndex = 12;
    this.lblExposure.Text = "Exposure";
    this.lblGain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.lblGain.AutoSize = true;
    this.lblGain.Font = new Font("Segoe UI", 12f);
    this.lblGain.ForeColor = Color.White;
    this.lblGain.Location = new Point(1323, 250);
    this.lblGain.Name = "lblGain";
    this.lblGain.Size = new Size(42, 21);
    this.lblGain.TabIndex = 13;
    this.lblGain.Text = "Gain";
    this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnMinimize.BackColor = Color.FromArgb(50, 50, 50);
    this.btnMinimize.FlatAppearance.BorderSize = 0;
    this.btnMinimize.FlatStyle = FlatStyle.Flat;
    this.btnMinimize.ForeColor = Color.White;
    this.btnMinimize.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnMinimize.Image");
    this.btnMinimize.Location = new Point(1274, 2);
    this.btnMinimize.Name = "btnMinimize";
    this.btnMinimize.Size = new Size(50, 50);
    this.btnMinimize.TabIndex = 14;
    this.btnMinimize.UseVisualStyleBackColor = false;
    this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);
    this.btnExtend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnExtend.BackColor = Color.FromArgb(50, 50, 50);
    this.btnExtend.FlatAppearance.BorderSize = 0;
    this.btnExtend.FlatStyle = FlatStyle.Flat;
    this.btnExtend.ForeColor = Color.White;
    this.btnExtend.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnExtend.Image");
    this.btnExtend.Location = new Point(1331, 2);
    this.btnExtend.Name = "btnExtend";
    this.btnExtend.Size = new Size(50, 50);
    this.btnExtend.TabIndex = 15;
    this.btnExtend.UseVisualStyleBackColor = false;
    this.btnExtend.Click += new EventHandler(this.btnExtend_Click);
    this.btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnCancel.BackColor = Color.FromArgb(50, 50, 50);
    this.btnCancel.FlatAppearance.BorderSize = 0;
    this.btnCancel.FlatStyle = FlatStyle.Flat;
    this.btnCancel.ForeColor = Color.White;
    this.btnCancel.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnCancel.Image");
    this.btnCancel.Location = new Point(1387, 2);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new Size(50, 50);
    this.btnCancel.TabIndex = 16 /*0x10*/;
    this.btnCancel.UseVisualStyleBackColor = false;
    this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
    this.AutoScaleDimensions = new SizeF(7f, 15f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.FromArgb(50, 50, 50);
    this.ClientSize = new Size(1438, 828);
    this.Controls.Add((Control) this.btnMinimize);
    this.Controls.Add((Control) this.btnExtend);
    this.Controls.Add((Control) this.btnCancel);
    this.Controls.Add((Control) this.numUDGCManExp);
    this.Controls.Add((Control) this.numUDGain);
    this.Controls.Add((Control) this.lblExposure);
    this.Controls.Add((Control) this.lblGain);
    this.Controls.Add((Control) this.pboxVideo);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (VideoForm);
    this.Text = nameof (VideoForm);
    ((ISupportInitialize) this.pboxVideo).EndInit();
    ((ISupportInitialize) this.numUDGCManExp).EndInit();
    ((ISupportInitialize) this.numUDGain).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
