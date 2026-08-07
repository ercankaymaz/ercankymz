// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.CalibrationSettings
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Windows.Forms;

#nullable enable
namespace buCameraSolutions;

public class CalibrationSettings : Form
{
  private Image<Bgr, byte> _originalImage;
  private string _camModel;
  private string _calibDir;
  private bool _isLoading = false;
  private CultureInfo _culture;
  private 
  #nullable disable
  IContainer components = (IContainer) null;
  private Button btnMinimize;
  private Button btnExtend;
  private Button btnClose;
  private NumericUpDown numUDHeight;
  private NumericUpDown numUDWidth;
  private Label lblHeight;
  private Label lblWidth;
  private TextBox tbTrans1;
  private TextBox tbTrans2;
  private TextBox tbTrans3;
  private TextBox tbTrans4;
  private TextBox tbTrans5;
  private TextBox tbTrans6;
  private TextBox tbTrans7;
  private TextBox tbTrans8;
  private TextBox tbTrans9;
  private Label lblTransformMatrix;
  private Panel panel1;
  private RadioButton rbInner;
  private RadioButton rbOuter;
  private Label lblStretchType;
  private RadioButton rbNormal;
  private Button btnCancel;
  private Button btnApplySettings;
  private PictureBox pboxTransform;

  public CalibrationSettings()
  {
    this.InitializeComponent();
    this.tbTrans1.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans2.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans3.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans4.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans5.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans6.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans7.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans8.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.tbTrans9.TextChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.numUDWidth.ValueChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.numUDHeight.ValueChanged += new EventHandler(this.LiveUpdate_Trigger);
    this.rbOuter.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.rbInner.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.rbNormal.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.rbOuter.Checked = true;
  }

  public void Initialize(
    #nullable enable
    string camModel,
    string calibDir,
    Image<Bgr, byte> originalImage,
    CultureInfo cultureInfo)
  {
    this._camModel = camModel;
    this._calibDir = calibDir;
    this._originalImage = originalImage.Clone();
    this._culture = cultureInfo;
    this.LoadMatrixFromFile();
  }

  private void LoadMatrixFromFile()
  {
    this._isLoading = true;
    string currentFilePath = this.GetCurrentFilePath();
    if (File.Exists(currentFilePath))
    {
      try
      {
        string[] strArray = File.ReadAllLines(currentFilePath);
        if (strArray.Length >= 11)
        {
          this.tbTrans1.Text = this.FormatMatrixValue(strArray[0]);
          this.tbTrans2.Text = this.FormatMatrixValue(strArray[1]);
          this.tbTrans3.Text = this.FormatMatrixValue(strArray[2]);
          this.tbTrans4.Text = this.FormatMatrixValue(strArray[3]);
          this.tbTrans5.Text = this.FormatMatrixValue(strArray[4]);
          this.tbTrans6.Text = this.FormatMatrixValue(strArray[5]);
          this.tbTrans7.Text = this.FormatMatrixValue(strArray[6]);
          this.tbTrans8.Text = this.FormatMatrixValue(strArray[7]);
          this.tbTrans9.Text = this.FormatMatrixValue(strArray[8]);
          this.numUDWidth.Value = Decimal.Parse(strArray[9], (IFormatProvider) this._culture);
          this.numUDHeight.Value = Decimal.Parse(strArray[10], (IFormatProvider) this._culture);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error reading calibration file: " + ex.Message);
      }
    }
    else
    {
      this.tbTrans1.Text = "1";
      this.tbTrans2.Text = "0";
      this.tbTrans3.Text = "0";
      this.tbTrans4.Text = "0";
      this.tbTrans5.Text = "1";
      this.tbTrans6.Text = "0";
      this.tbTrans7.Text = "0";
      this.tbTrans8.Text = "0";
      this.tbTrans9.Text = "1";
      this.numUDWidth.Value = (Decimal) this._originalImage.Width;
      this.numUDHeight.Value = (Decimal) this._originalImage.Height;
    }
    this._isLoading = false;
    this.ApplyLiveWarp();
  }

  private string FormatMatrixValue(string rawValue)
  {
    double result;
    return double.TryParse(rawValue, NumberStyles.Any, (IFormatProvider) this._culture, out result) ? result.ToString("0.##########", (IFormatProvider) this._culture) : rawValue;
  }

  private string GetCurrentFilePath()
  {
    string str = "Outer";
    if (this.rbInner.Checked)
      str = "Inner";
    if (this.rbNormal.Checked)
      str = "Normal";
    return Path.Combine(this._calibDir, $"{this._camModel.ToLower()}Transform{str}.txt");
  }

  private void LiveUpdate_Trigger(object sender, EventArgs e) => this.ApplyLiveWarp();

  private void ApplyLiveWarp()
  {
    if (this._isLoading || this._originalImage == null)
      return;
    try
    {
      Matrix<double> mapMatrix = new Matrix<double>(3, 3);
      mapMatrix[0, 0] = double.Parse(this.tbTrans1.Text, (IFormatProvider) this._culture);
      mapMatrix[0, 1] = double.Parse(this.tbTrans2.Text, (IFormatProvider) this._culture);
      mapMatrix[0, 2] = double.Parse(this.tbTrans3.Text, (IFormatProvider) this._culture);
      mapMatrix[1, 0] = double.Parse(this.tbTrans4.Text, (IFormatProvider) this._culture);
      mapMatrix[1, 1] = double.Parse(this.tbTrans5.Text, (IFormatProvider) this._culture);
      mapMatrix[1, 2] = double.Parse(this.tbTrans6.Text, (IFormatProvider) this._culture);
      mapMatrix[2, 0] = double.Parse(this.tbTrans7.Text, (IFormatProvider) this._culture);
      mapMatrix[2, 1] = double.Parse(this.tbTrans8.Text, (IFormatProvider) this._culture);
      mapMatrix[2, 2] = double.Parse(this.tbTrans9.Text, (IFormatProvider) this._culture);
      int width = (int) this.numUDWidth.Value;
      int height = (int) this.numUDHeight.Value;
      if (width <= 0 || height <= 0)
        return;
      Mat mat = new Mat();
      CvInvoke.WarpPerspective((IInputArray) this._originalImage.Mat, (IOutputArray) mat, (IInputArray) mapMatrix, new Size(width, height), Inter.Lanczos4);
      if (this._originalImage != null)
      {
        Image image = this.pboxTransform.Image;
        this.pboxTransform.Image = (Image) mat.ToBitmap();
        image?.Dispose();
      }
      mapMatrix.Dispose();
    }
    catch
    {
    }
  }

  private void btnApplySettings_Click(object sender, EventArgs e)
  {
    try
    {
      using (StreamWriter streamWriter1 = new StreamWriter(this.GetCurrentFilePath(), false))
      {
        StreamWriter streamWriter2 = streamWriter1;
        double num = double.Parse(this.tbTrans1.Text, (IFormatProvider) this._culture);
        string str1 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter2).WriteLine(str1);
        StreamWriter streamWriter3 = streamWriter1;
        num = double.Parse(this.tbTrans2.Text, (IFormatProvider) this._culture);
        string str2 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter3).WriteLine(str2);
        StreamWriter streamWriter4 = streamWriter1;
        num = double.Parse(this.tbTrans3.Text, (IFormatProvider) this._culture);
        string str3 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter4).WriteLine(str3);
        StreamWriter streamWriter5 = streamWriter1;
        num = double.Parse(this.tbTrans4.Text, (IFormatProvider) this._culture);
        string str4 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter5).WriteLine(str4);
        StreamWriter streamWriter6 = streamWriter1;
        num = double.Parse(this.tbTrans5.Text, (IFormatProvider) this._culture);
        string str5 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter6).WriteLine(str5);
        StreamWriter streamWriter7 = streamWriter1;
        num = double.Parse(this.tbTrans6.Text, (IFormatProvider) this._culture);
        string str6 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter7).WriteLine(str6);
        StreamWriter streamWriter8 = streamWriter1;
        num = double.Parse(this.tbTrans7.Text, (IFormatProvider) this._culture);
        string str7 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter8).WriteLine(str7);
        StreamWriter streamWriter9 = streamWriter1;
        num = double.Parse(this.tbTrans8.Text, (IFormatProvider) this._culture);
        string str8 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter9).WriteLine(str8);
        StreamWriter streamWriter10 = streamWriter1;
        num = double.Parse(this.tbTrans9.Text, (IFormatProvider) this._culture);
        string str9 = num.ToString((IFormatProvider) this._culture);
        ((TextWriter) streamWriter10).WriteLine(str9);
        ((TextWriter) streamWriter1).WriteLine(this.numUDWidth.Value.ToString((IFormatProvider) this._culture));
        ((TextWriter) streamWriter1).WriteLine(this.numUDHeight.Value.ToString((IFormatProvider) this._culture));
      }
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Failed to save calibration: " + ex.Message);
    }
  }

  private void RadioButton_CheckedChanged(object sender, EventArgs e)
  {
    if (!(sender is RadioButton radioButton) || !radioButton.Checked)
      return;
    this.LoadMatrixFromFile();
  }

  private void btnClose_Click(object sender, EventArgs e) => this.Close();

  protected override void OnFormClosed(FormClosedEventArgs e)
  {
    this._originalImage?.Dispose();
    base.OnFormClosed(e);
  }

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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CalibrationSettings));
    this.btnMinimize = new Button();
    this.btnExtend = new Button();
    this.btnClose = new Button();
    this.numUDHeight = new NumericUpDown();
    this.numUDWidth = new NumericUpDown();
    this.lblHeight = new Label();
    this.lblWidth = new Label();
    this.tbTrans1 = new TextBox();
    this.tbTrans2 = new TextBox();
    this.tbTrans3 = new TextBox();
    this.tbTrans4 = new TextBox();
    this.tbTrans5 = new TextBox();
    this.tbTrans6 = new TextBox();
    this.tbTrans7 = new TextBox();
    this.tbTrans8 = new TextBox();
    this.tbTrans9 = new TextBox();
    this.lblTransformMatrix = new Label();
    this.panel1 = new Panel();
    this.rbInner = new RadioButton();
    this.rbOuter = new RadioButton();
    this.lblStretchType = new Label();
    this.rbNormal = new RadioButton();
    this.btnCancel = new Button();
    this.btnApplySettings = new Button();
    this.pboxTransform = new PictureBox();
    ((ISupportInitialize) this.numUDHeight).BeginInit();
    ((ISupportInitialize) this.numUDWidth).BeginInit();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.pboxTransform).BeginInit();
    this.SuspendLayout();
    this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnMinimize.BackColor = Color.FromArgb(50, 50, 50);
    this.btnMinimize.FlatAppearance.BorderSize = 0;
    this.btnMinimize.FlatStyle = FlatStyle.Flat;
    this.btnMinimize.ForeColor = Color.White;
    this.btnMinimize.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnMinimize.Image");
    this.btnMinimize.Location = new Point(990, 12);
    this.btnMinimize.Name = "btnMinimize";
    this.btnMinimize.Size = new Size(50, 50);
    this.btnMinimize.TabIndex = 68;
    this.btnMinimize.UseVisualStyleBackColor = false;
    this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);
    this.btnExtend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnExtend.BackColor = Color.FromArgb(50, 50, 50);
    this.btnExtend.FlatAppearance.BorderSize = 0;
    this.btnExtend.FlatStyle = FlatStyle.Flat;
    this.btnExtend.ForeColor = Color.White;
    this.btnExtend.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnExtend.Image");
    this.btnExtend.Location = new Point(1047, 12);
    this.btnExtend.Name = "btnExtend";
    this.btnExtend.Size = new Size(50, 50);
    this.btnExtend.TabIndex = 69;
    this.btnExtend.UseVisualStyleBackColor = false;
    this.btnExtend.Click += new EventHandler(this.btnExtend_Click);
    this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnClose.BackColor = Color.FromArgb(50, 50, 50);
    this.btnClose.FlatAppearance.BorderSize = 0;
    this.btnClose.FlatStyle = FlatStyle.Flat;
    this.btnClose.ForeColor = Color.White;
    this.btnClose.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnClose.Image");
    this.btnClose.Location = new Point(1103, 12);
    this.btnClose.Name = "btnClose";
    this.btnClose.Size = new Size(50, 50);
    this.btnClose.TabIndex = 70;
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnClose_Click);
    this.numUDHeight.Anchor = AnchorStyles.Left;
    this.numUDHeight.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDHeight.ForeColor = Color.White;
    this.numUDHeight.Location = new Point(131, 407);
    this.numUDHeight.Margin = new Padding(4, 3, 4, 3);
    this.numUDHeight.Maximum = new Decimal(new int[4]
    {
      100000,
      0,
      0,
      0
    });
    this.numUDHeight.Name = "numUDHeight";
    this.numUDHeight.Size = new Size(120, 23);
    this.numUDHeight.TabIndex = 72;
    this.numUDWidth.Anchor = AnchorStyles.Left;
    this.numUDWidth.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDWidth.ForeColor = Color.White;
    this.numUDWidth.Location = new Point(131, 358);
    this.numUDWidth.Margin = new Padding(4, 3, 4, 3);
    this.numUDWidth.Maximum = new Decimal(new int[4]
    {
      100000,
      0,
      0,
      0
    });
    this.numUDWidth.Name = "numUDWidth";
    this.numUDWidth.Size = new Size(120, 23);
    this.numUDWidth.TabIndex = 71;
    this.lblHeight.Anchor = AnchorStyles.Left;
    this.lblHeight.AutoSize = true;
    this.lblHeight.Font = new Font("Segoe UI", 14.25f);
    this.lblHeight.ForeColor = Color.White;
    this.lblHeight.Location = new Point(27, 405);
    this.lblHeight.Margin = new Padding(4, 0, 4, 0);
    this.lblHeight.Name = "lblHeight";
    this.lblHeight.Size = new Size(68, 25);
    this.lblHeight.TabIndex = 74;
    this.lblHeight.Text = "Height";
    this.lblWidth.Anchor = AnchorStyles.Left;
    this.lblWidth.AutoSize = true;
    this.lblWidth.Font = new Font("Segoe UI", 14.25f);
    this.lblWidth.ForeColor = Color.White;
    this.lblWidth.Location = new Point(27, 356);
    this.lblWidth.Margin = new Padding(4, 0, 4, 0);
    this.lblWidth.Name = "lblWidth";
    this.lblWidth.Size = new Size(63 /*0x3F*/, 25);
    this.lblWidth.TabIndex = 73;
    this.lblWidth.Text = "Width";
    this.tbTrans1.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans1.BorderStyle = BorderStyle.None;
    this.tbTrans1.Font = new Font("Segoe UI", 12f);
    this.tbTrans1.ForeColor = Color.White;
    this.tbTrans1.Location = new Point(33, 143);
    this.tbTrans1.Name = "tbTrans1";
    this.tbTrans1.Size = new Size(165, 22);
    this.tbTrans1.TabIndex = 75;
    this.tbTrans2.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans2.BorderStyle = BorderStyle.None;
    this.tbTrans2.Font = new Font("Segoe UI", 12f);
    this.tbTrans2.ForeColor = Color.White;
    this.tbTrans2.Location = new Point(235, 143);
    this.tbTrans2.Name = "tbTrans2";
    this.tbTrans2.Size = new Size(165, 22);
    this.tbTrans2.TabIndex = 75;
    this.tbTrans3.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans3.BorderStyle = BorderStyle.None;
    this.tbTrans3.Font = new Font("Segoe UI", 12f);
    this.tbTrans3.ForeColor = Color.White;
    this.tbTrans3.Location = new Point(430, 143);
    this.tbTrans3.Name = "tbTrans3";
    this.tbTrans3.Size = new Size(165, 22);
    this.tbTrans3.TabIndex = 75;
    this.tbTrans4.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans4.BorderStyle = BorderStyle.None;
    this.tbTrans4.Font = new Font("Segoe UI", 12f);
    this.tbTrans4.ForeColor = Color.White;
    this.tbTrans4.Location = new Point(33, 198);
    this.tbTrans4.Name = "tbTrans4";
    this.tbTrans4.Size = new Size(165, 22);
    this.tbTrans4.TabIndex = 75;
    this.tbTrans5.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans5.BorderStyle = BorderStyle.None;
    this.tbTrans5.Font = new Font("Segoe UI", 12f);
    this.tbTrans5.ForeColor = Color.White;
    this.tbTrans5.Location = new Point(235, 198);
    this.tbTrans5.Name = "tbTrans5";
    this.tbTrans5.Size = new Size(165, 22);
    this.tbTrans5.TabIndex = 75;
    this.tbTrans6.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans6.BorderStyle = BorderStyle.None;
    this.tbTrans6.Font = new Font("Segoe UI", 12f);
    this.tbTrans6.ForeColor = Color.White;
    this.tbTrans6.Location = new Point(430, 198);
    this.tbTrans6.Name = "tbTrans6";
    this.tbTrans6.Size = new Size(165, 22);
    this.tbTrans6.TabIndex = 75;
    this.tbTrans7.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans7.BorderStyle = BorderStyle.None;
    this.tbTrans7.Font = new Font("Segoe UI", 12f);
    this.tbTrans7.ForeColor = Color.White;
    this.tbTrans7.Location = new Point(33, (int) byte.MaxValue);
    this.tbTrans7.Name = "tbTrans7";
    this.tbTrans7.Size = new Size(165, 22);
    this.tbTrans7.TabIndex = 75;
    this.tbTrans8.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans8.BorderStyle = BorderStyle.None;
    this.tbTrans8.Font = new Font("Segoe UI", 12f);
    this.tbTrans8.ForeColor = Color.White;
    this.tbTrans8.Location = new Point(235, (int) byte.MaxValue);
    this.tbTrans8.Name = "tbTrans8";
    this.tbTrans8.Size = new Size(165, 22);
    this.tbTrans8.TabIndex = 75;
    this.tbTrans9.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbTrans9.BorderStyle = BorderStyle.None;
    this.tbTrans9.Font = new Font("Segoe UI", 12f);
    this.tbTrans9.ForeColor = Color.White;
    this.tbTrans9.Location = new Point(430, (int) byte.MaxValue);
    this.tbTrans9.Name = "tbTrans9";
    this.tbTrans9.Size = new Size(165, 22);
    this.tbTrans9.TabIndex = 75;
    this.lblTransformMatrix.AutoSize = true;
    this.lblTransformMatrix.Font = new Font("Segoe UI", 14.25f);
    this.lblTransformMatrix.ForeColor = Color.White;
    this.lblTransformMatrix.Location = new Point(33, 71);
    this.lblTransformMatrix.Margin = new Padding(4, 0, 4, 0);
    this.lblTransformMatrix.Name = "lblTransformMatrix";
    this.lblTransformMatrix.Size = new Size(155, 25);
    this.lblTransformMatrix.TabIndex = 73;
    this.lblTransformMatrix.Text = "Transform Matrix";
    this.panel1.Anchor = AnchorStyles.Left;
    this.panel1.Controls.Add((Control) this.rbInner);
    this.panel1.Controls.Add((Control) this.rbOuter);
    this.panel1.Controls.Add((Control) this.lblStretchType);
    this.panel1.Controls.Add((Control) this.rbNormal);
    this.panel1.Location = new Point(57, 522);
    this.panel1.Margin = new Padding(4, 3, 4, 3);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(154, 162);
    this.panel1.TabIndex = 77;
    this.panel1.Visible = false;
    this.rbInner.AutoSize = true;
    this.rbInner.Font = new Font("Segoe UI", 11.25f);
    this.rbInner.ForeColor = Color.White;
    this.rbInner.Location = new Point(27, 120);
    this.rbInner.Margin = new Padding(4, 3, 4, 3);
    this.rbInner.Name = "rbInner";
    this.rbInner.Size = new Size(60, 24);
    this.rbInner.TabIndex = 0;
    this.rbInner.Text = "Inner";
    this.rbInner.UseVisualStyleBackColor = true;
    this.rbInner.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.rbOuter.AutoSize = true;
    this.rbOuter.Checked = true;
    this.rbOuter.Font = new Font("Segoe UI", 11.25f);
    this.rbOuter.ForeColor = Color.White;
    this.rbOuter.Location = new Point(27, 82);
    this.rbOuter.Margin = new Padding(4, 3, 4, 3);
    this.rbOuter.Name = "rbOuter";
    this.rbOuter.Size = new Size(64 /*0x40*/, 24);
    this.rbOuter.TabIndex = 0;
    this.rbOuter.TabStop = true;
    this.rbOuter.Text = "Outer";
    this.rbOuter.UseVisualStyleBackColor = true;
    this.rbOuter.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.lblStretchType.AutoSize = true;
    this.lblStretchType.Font = new Font("Segoe UI", 14.25f);
    this.lblStretchType.ForeColor = Color.White;
    this.lblStretchType.Location = new Point(10, 9);
    this.lblStretchType.Margin = new Padding(4, 0, 4, 0);
    this.lblStretchType.Name = "lblStretchType";
    this.lblStretchType.Size = new Size(114, 25);
    this.lblStretchType.TabIndex = 6;
    this.lblStretchType.Text = "Stretch Type";
    this.rbNormal.AutoSize = true;
    this.rbNormal.Font = new Font("Segoe UI", 11.25f);
    this.rbNormal.ForeColor = Color.White;
    this.rbNormal.Location = new Point(27, 48 /*0x30*/);
    this.rbNormal.Margin = new Padding(4, 3, 4, 3);
    this.rbNormal.Name = "rbNormal";
    this.rbNormal.Size = new Size(77, 24);
    this.rbNormal.TabIndex = 0;
    this.rbNormal.Text = "Normal";
    this.rbNormal.UseVisualStyleBackColor = true;
    this.rbNormal.CheckedChanged += new EventHandler(this.RadioButton_CheckedChanged);
    this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnCancel.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnCancel.FlatAppearance.BorderSize = 0;
    this.btnCancel.FlatStyle = FlatStyle.Flat;
    this.btnCancel.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnCancel.ForeColor = Color.White;
    this.btnCancel.Location = new Point(990, 976);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new Size(138, 46);
    this.btnCancel.TabIndex = 78;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.UseVisualStyleBackColor = false;
    this.btnCancel.Click += new EventHandler(this.btnClose_Click);
    this.btnApplySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnApplySettings.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnApplySettings.FlatAppearance.BorderSize = 0;
    this.btnApplySettings.FlatStyle = FlatStyle.Flat;
    this.btnApplySettings.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnApplySettings.ForeColor = Color.White;
    this.btnApplySettings.Location = new Point(793, 976);
    this.btnApplySettings.Name = "btnApplySettings";
    this.btnApplySettings.Size = new Size(138, 46);
    this.btnApplySettings.TabIndex = 79;
    this.btnApplySettings.Text = "Apply Settings";
    this.btnApplySettings.UseVisualStyleBackColor = false;
    this.btnApplySettings.Click += new EventHandler(this.btnApplySettings_Click);
    this.pboxTransform.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.pboxTransform.Location = new Point(344, 333);
    this.pboxTransform.Name = "pboxTransform";
    this.pboxTransform.Size = new Size(784, 575);
    this.pboxTransform.SizeMode = PictureBoxSizeMode.Zoom;
    this.pboxTransform.TabIndex = 80 /*0x50*/;
    this.pboxTransform.TabStop = false;
    this.AutoScaleDimensions = new SizeF(7f, 15f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.FromArgb(50, 50, 50);
    this.ClientSize = new Size(1165, 1062);
    this.Controls.Add((Control) this.pboxTransform);
    this.Controls.Add((Control) this.btnCancel);
    this.Controls.Add((Control) this.btnApplySettings);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.tbTrans9);
    this.Controls.Add((Control) this.tbTrans8);
    this.Controls.Add((Control) this.tbTrans6);
    this.Controls.Add((Control) this.tbTrans5);
    this.Controls.Add((Control) this.tbTrans7);
    this.Controls.Add((Control) this.tbTrans3);
    this.Controls.Add((Control) this.tbTrans4);
    this.Controls.Add((Control) this.tbTrans2);
    this.Controls.Add((Control) this.tbTrans1);
    this.Controls.Add((Control) this.lblHeight);
    this.Controls.Add((Control) this.lblTransformMatrix);
    this.Controls.Add((Control) this.lblWidth);
    this.Controls.Add((Control) this.numUDHeight);
    this.Controls.Add((Control) this.numUDWidth);
    this.Controls.Add((Control) this.btnMinimize);
    this.Controls.Add((Control) this.btnExtend);
    this.Controls.Add((Control) this.btnClose);
    this.ForeColor = SystemColors.ControlText;
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (CalibrationSettings);
    this.Text = nameof (CalibrationSettings);
    ((ISupportInitialize) this.numUDHeight).EndInit();
    ((ISupportInitialize) this.numUDWidth).EndInit();
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    ((ISupportInitialize) this.pboxTransform).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
