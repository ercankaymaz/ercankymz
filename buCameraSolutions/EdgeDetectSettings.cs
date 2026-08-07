// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.EdgeDetectSettings
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

#nullable enable
namespace buCameraSolutions;

public class EdgeDetectSettings : Form
{
  private string edgePath = string.Empty;
  private 
  #nullable disable
  IContainer components = (IContainer) null;
  private Button btnCancel;
  private Button btnApplySettings;
  public NumericUpDown numUDHue;
  public NumericUpDown numUDSat;
  public NumericUpDown numUDVal;
  public Label lblHue;
  public Label lblSat;
  public Label lblVal;
  public TrackBar tbarMinAea;
  public TrackBar tbarContourDist;
  public TrackBar tbarSensitivy;
  public Label lblMinArea;
  public Label lblContourDist;
  public Label lblSensitivity;
  public Label lblBackColorspace;
  public ComboBox cboxBackColorspace;
  public Panel pnlPointSave;
  public RadioButton rbPointPixel;
  public RadioButton rbPointMm;
  public Panel pnlContourShowcase;
  public CheckBox cboxShowPoints;
  public CheckBox cboxShowArea;
  public RadioButton rbCurve;
  public RadioButton rbRect;
  public Panel pnlContourMethod;
  public RadioButton rbAllPoints;
  public RadioButton rbSample;
  public RadioButton rbSimplified;
  public RadioButton rbMerge;
  public Label lblPointSave;
  public Label lblContourShowcase;
  public Label lblContourMethod;
  public NumericUpDown numUDCornerTresh;
  public NumericUpDown numUDLineTresh;
  public Label lblCornerTresh;
  public Label lblLineTresh;
  private Button btnMinimize;
  private Button btnExtend;
  private Button btnClose;

  public EdgeDetectSettings(
  #nullable enable
  string path)
  {
    this.InitializeComponent();
    this.edgePath = path;
  }

  private void EdgeDetectSettings_Load(object sender, EventArgs e)
  {
    this.ReadMenuSettings(this.edgePath);
  }

  public void WriteMenuSettings(string menuSettings)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(menuSettings))
      {
        ((TextWriter) streamWriter).WriteLine($"Hue: {this.numUDHue.Value}");
        ((TextWriter) streamWriter).WriteLine($"Saturation: {this.numUDSat.Value}");
        ((TextWriter) streamWriter).WriteLine($"Value: {this.numUDVal.Value}");
        ((TextWriter) streamWriter).WriteLine($"Min Area: {this.tbarMinAea.Value}");
        ((TextWriter) streamWriter).WriteLine($"Contour Distance: {this.tbarContourDist.Value}");
        ((TextWriter) streamWriter).WriteLine($"Sensitivity: {this.tbarSensitivy.Value}");
        ((TextWriter) streamWriter).WriteLine("Background Colorspace: " + this.cboxBackColorspace.Text);
        string str1 = this.rbPointPixel.Checked ? "Pixel" : (this.rbPointMm.Checked ? "Milimeter" : "Pixel");
        ((TextWriter) streamWriter).WriteLine("Point Save Type: " + str1);
        ((TextWriter) streamWriter).WriteLine($"Show Points: {this.cboxShowPoints.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Show Area: {this.cboxShowArea.Checked}");
        string str2 = this.rbCurve.Checked ? "Curve" : (this.rbRect.Checked ? "Rect" : "Curve");
        ((TextWriter) streamWriter).WriteLine("Shape Type: " + str2);
        string str3;
        if (!this.rbAllPoints.Checked)
        {
          if (!this.rbSample.Checked)
          {
            if (!this.rbSimplified.Checked)
            {
              if (!this.rbMerge.Checked)
                throw new Exception("No contour method radio button is selected.");
              str3 = "Merge";
            }
            else
              str3 = "Simplified";
          }
          else
            str3 = "Sample";
        }
        else
          str3 = "All Points";
        string str4 = str3;
        ((TextWriter) streamWriter).WriteLine("Contour Method: " + str4);
        ((TextWriter) streamWriter).WriteLine($"Contour Corner Angle Treshold: {this.numUDCornerTresh.Value}");
        ((TextWriter) streamWriter).WriteLine($"Contour Line Fit Treshold: {this.numUDLineTresh.Value}");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing to menu settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  public void ReadMenuSettings(string txtSettings)
  {
    try
    {
      string[] strArray = File.ReadAllLines(txtSettings);
      string s1 = strArray.Length >= 12 ? this.GetValue(strArray[0]) : throw new Exception("Settings file does not contain enough lines.");
      Decimal result1;
      if (!Decimal.TryParse(s1, out result1))
        throw new Exception("Invalid numeric value for Hue: " + s1);
      this.numUDHue.Value = result1;
      string s2 = this.GetValue(strArray[1]);
      Decimal result2;
      if (!Decimal.TryParse(s2, out result2))
        throw new Exception("Invalid numeric value for Saturation: " + s2);
      this.numUDSat.Value = result2;
      string s3 = this.GetValue(strArray[2]);
      Decimal result3;
      if (!Decimal.TryParse(s3, out result3))
        throw new Exception("Invalid numeric value for Value: " + s3);
      this.numUDVal.Value = result3;
      string s4 = this.GetValue(strArray[3]);
      int result4;
      if (!int.TryParse(s4, out result4))
        throw new Exception("Invalid integer value for Min Area: " + s4);
      this.tbarMinAea.Value = result4;
      string s5 = this.GetValue(strArray[4]);
      int result5;
      if (!int.TryParse(s5, out result5))
        throw new Exception("Invalid integer value for Contour Distance: " + s5);
      this.tbarContourDist.Value = result5;
      string s6 = this.GetValue(strArray[5]);
      int result6;
      if (!int.TryParse(s6, out result6))
        throw new Exception("Invalid integer value for Sensitivity: " + s6);
      this.tbarSensitivy.Value = result6;
      this.cboxBackColorspace.Text = this.GetValue(strArray[6]);
      switch (this.GetValue(strArray[7]))
      {
        case "Pixel":
          this.rbPointPixel.Checked = true;
          break;
        case "Milimeter":
          this.rbPointMm.Checked = true;
          break;
      }
      string str1 = this.GetValue(strArray[8]);
      bool result7;
      if (!bool.TryParse(str1, out result7))
        throw new Exception("Invalid boolean value for Show Points: " + str1);
      this.cboxShowPoints.Checked = result7;
      string str2 = this.GetValue(strArray[9]);
      bool result8;
      if (!bool.TryParse(str2, out result8))
        throw new Exception("Invalid boolean value for Show Area: " + str2);
      this.cboxShowArea.Checked = result8;
      switch (this.GetValue(strArray[10]))
      {
        case "Curve":
          this.rbCurve.Checked = true;
          break;
        case "Rect":
          this.rbRect.Checked = true;
          break;
      }
      string str3 = this.GetValue(strArray[11]);
      switch (str3)
      {
        case "All Points":
          this.rbAllPoints.Checked = true;
          break;
        case "Sample":
          this.rbSample.Checked = true;
          break;
        case "Simplified":
          this.rbSimplified.Checked = true;
          break;
        case "Merge":
          this.rbMerge.Checked = true;
          break;
        default:
          throw new Exception("Invalid Contour Method: " + str3);
      }
      string s7 = this.GetValue(strArray[12]);
      Decimal result9;
      if (!Decimal.TryParse(s7, out result9))
        throw new Exception("Invalid numeric value for Value: " + s7);
      this.numUDCornerTresh.Value = result9;
      string s8 = this.GetValue(strArray[13]);
      Decimal result10;
      if (!Decimal.TryParse(s8, out result10))
        throw new Exception("Invalid numeric value for Value: " + s8);
      this.numUDLineTresh.Value = result10;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error parsing menu settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
    GC.Collect();
  }

  private string GetValue(string line)
  {
    int num = line.IndexOf(": ");
    if (num == -1 || num + 2 >= line.Length)
      throw new Exception("Invalid format in line: " + line);
    return line.Substring(num + 2).Trim();
  }

  private (Decimal, Decimal) Get2Values(string line)
  {
    string[] strArray1 = line.Split(new string[1]{ ": " }, StringSplitOptions.None);
    string[] strArray2 = strArray1.Length >= 2 ? ((IEnumerable<string>) strArray1[1].Trim().Split(new char[1]
    {
      ','
    }, StringSplitOptions.RemoveEmptyEntries)).Select<string, string>((Func<string, string>) (c => c.Trim())).ToArray<string>() : throw new Exception("Invalid line format. Missing colon separator.");
    if (strArray2.Length != 2)
      throw new Exception("Invalid coordinate format. Expected 2 values.");
    Decimal result1;
    if (!Decimal.TryParse(strArray2[0], out result1))
      throw new Exception("Invalid X value: " + strArray2[0]);
    Decimal result2;
    if (!Decimal.TryParse(strArray2[1], out result2))
      throw new Exception("Invalid Y value: " + strArray2[1]);
    return (result1, result2);
  }

  private void btnApplySettings_Click(object sender, EventArgs e)
  {
    this.WriteMenuSettings(this.edgePath);
    this.Close();
  }

  private void btnCancel_Click(object sender, EventArgs e) => this.Close();

  private void btnExtend_Click(object sender, EventArgs e)
  {
    if (this.WindowState == FormWindowState.Maximized)
      this.WindowState = FormWindowState.Normal;
    else
      this.WindowState = FormWindowState.Maximized;
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (EdgeDetectSettings));
    this.numUDHue = new NumericUpDown();
    this.numUDSat = new NumericUpDown();
    this.numUDVal = new NumericUpDown();
    this.lblHue = new Label();
    this.lblSat = new Label();
    this.lblVal = new Label();
    this.tbarMinAea = new TrackBar();
    this.tbarContourDist = new TrackBar();
    this.tbarSensitivy = new TrackBar();
    this.lblMinArea = new Label();
    this.lblContourDist = new Label();
    this.lblSensitivity = new Label();
    this.lblBackColorspace = new Label();
    this.cboxBackColorspace = new ComboBox();
    this.pnlPointSave = new Panel();
    this.lblPointSave = new Label();
    this.rbPointPixel = new RadioButton();
    this.rbPointMm = new RadioButton();
    this.pnlContourShowcase = new Panel();
    this.lblContourShowcase = new Label();
    this.cboxShowPoints = new CheckBox();
    this.cboxShowArea = new CheckBox();
    this.rbCurve = new RadioButton();
    this.rbRect = new RadioButton();
    this.pnlContourMethod = new Panel();
    this.lblContourMethod = new Label();
    this.rbAllPoints = new RadioButton();
    this.rbSample = new RadioButton();
    this.rbSimplified = new RadioButton();
    this.rbMerge = new RadioButton();
    this.btnCancel = new Button();
    this.btnApplySettings = new Button();
    this.numUDCornerTresh = new NumericUpDown();
    this.numUDLineTresh = new NumericUpDown();
    this.lblCornerTresh = new Label();
    this.lblLineTresh = new Label();
    this.btnMinimize = new Button();
    this.btnExtend = new Button();
    this.btnClose = new Button();
    ((ISupportInitialize) this.numUDHue).BeginInit();
    ((ISupportInitialize) this.numUDSat).BeginInit();
    ((ISupportInitialize) this.numUDVal).BeginInit();
    ((ISupportInitialize) this.tbarMinAea).BeginInit();
    ((ISupportInitialize) this.tbarContourDist).BeginInit();
    ((ISupportInitialize) this.tbarSensitivy).BeginInit();
    this.pnlPointSave.SuspendLayout();
    this.pnlContourShowcase.SuspendLayout();
    this.pnlContourMethod.SuspendLayout();
    ((ISupportInitialize) this.numUDCornerTresh).BeginInit();
    ((ISupportInitialize) this.numUDLineTresh).BeginInit();
    this.SuspendLayout();
    this.numUDHue.Anchor = AnchorStyles.Top;
    this.numUDHue.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDHue.ForeColor = Color.White;
    this.numUDHue.Location = new Point(50, 124);
    this.numUDHue.Maximum = new Decimal(new int[4]
    {
      (int) byte.MaxValue,
      0,
      0,
      0
    });
    this.numUDHue.Name = "numUDHue";
    this.numUDHue.Size = new Size(120, 23);
    this.numUDHue.TabIndex = 0;
    this.numUDSat.Anchor = AnchorStyles.Top;
    this.numUDSat.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDSat.ForeColor = Color.White;
    this.numUDSat.Location = new Point(253, 124);
    this.numUDSat.Maximum = new Decimal(new int[4]
    {
      (int) byte.MaxValue,
      0,
      0,
      0
    });
    this.numUDSat.Name = "numUDSat";
    this.numUDSat.Size = new Size(120, 23);
    this.numUDSat.TabIndex = 0;
    this.numUDVal.Anchor = AnchorStyles.Top;
    this.numUDVal.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDVal.ForeColor = Color.White;
    this.numUDVal.Location = new Point(459, 124);
    this.numUDVal.Maximum = new Decimal(new int[4]
    {
      (int) byte.MaxValue,
      0,
      0,
      0
    });
    this.numUDVal.Name = "numUDVal";
    this.numUDVal.Size = new Size(120, 23);
    this.numUDVal.TabIndex = 0;
    this.lblHue.Anchor = AnchorStyles.Top;
    this.lblHue.AutoSize = true;
    this.lblHue.ForeColor = Color.White;
    this.lblHue.Location = new Point(88, 86);
    this.lblHue.Name = "lblHue";
    this.lblHue.Size = new Size(29, 15);
    this.lblHue.TabIndex = 1;
    this.lblHue.Text = "Hue";
    this.lblSat.Anchor = AnchorStyles.Top;
    this.lblSat.AutoSize = true;
    this.lblSat.ForeColor = Color.White;
    this.lblSat.Location = new Point(281, 86);
    this.lblSat.Name = "lblSat";
    this.lblSat.Size = new Size(61, 15);
    this.lblSat.TabIndex = 1;
    this.lblSat.Text = "Saturation";
    this.lblVal.Anchor = AnchorStyles.Top;
    this.lblVal.AutoSize = true;
    this.lblVal.ForeColor = Color.White;
    this.lblVal.Location = new Point(501, 86);
    this.lblVal.Name = "lblVal";
    this.lblVal.Size = new Size(35, 15);
    this.lblVal.TabIndex = 1;
    this.lblVal.Text = "Value";
    this.tbarMinAea.Anchor = AnchorStyles.Left;
    this.tbarMinAea.Location = new Point(168, 211);
    this.tbarMinAea.Maximum = 100;
    this.tbarMinAea.Name = "tbarMinAea";
    this.tbarMinAea.Size = new Size(214, 45);
    this.tbarMinAea.TabIndex = 2;
    this.tbarContourDist.Anchor = AnchorStyles.Left;
    this.tbarContourDist.Location = new Point(168, 272);
    this.tbarContourDist.Maximum = 100;
    this.tbarContourDist.Name = "tbarContourDist";
    this.tbarContourDist.Size = new Size(214, 45);
    this.tbarContourDist.TabIndex = 2;
    this.tbarSensitivy.Anchor = AnchorStyles.Left;
    this.tbarSensitivy.Location = new Point(168, 340);
    this.tbarSensitivy.Maximum = 100;
    this.tbarSensitivy.Name = "tbarSensitivy";
    this.tbarSensitivy.Size = new Size(214, 45);
    this.tbarSensitivy.TabIndex = 2;
    this.lblMinArea.Anchor = AnchorStyles.Left;
    this.lblMinArea.AutoSize = true;
    this.lblMinArea.ForeColor = Color.White;
    this.lblMinArea.Location = new Point(58, 215);
    this.lblMinArea.Name = "lblMinArea";
    this.lblMinArea.Size = new Size(55, 15);
    this.lblMinArea.TabIndex = 3;
    this.lblMinArea.Text = "Min Area";
    this.lblContourDist.Anchor = AnchorStyles.Left;
    this.lblContourDist.AutoSize = true;
    this.lblContourDist.ForeColor = Color.White;
    this.lblContourDist.Location = new Point(29, 276);
    this.lblContourDist.Name = "lblContourDist";
    this.lblContourDist.Size = new Size(124, 15);
    this.lblContourDist.TabIndex = 3;
    this.lblContourDist.Text = "Contour Dist (Sample)";
    this.lblSensitivity.Anchor = AnchorStyles.Left;
    this.lblSensitivity.AutoSize = true;
    this.lblSensitivity.ForeColor = Color.White;
    this.lblSensitivity.Location = new Point(28, 344);
    this.lblSensitivity.Name = "lblSensitivity";
    this.lblSensitivity.Size = new Size(124, 15);
    this.lblSensitivity.TabIndex = 3;
    this.lblSensitivity.Text = "Sensitivity (Simplified)";
    this.lblBackColorspace.Anchor = AnchorStyles.Top;
    this.lblBackColorspace.AutoSize = true;
    this.lblBackColorspace.ForeColor = Color.White;
    this.lblBackColorspace.Location = new Point(732, 249);
    this.lblBackColorspace.Name = "lblBackColorspace";
    this.lblBackColorspace.Size = new Size(171, 15);
    this.lblBackColorspace.TabIndex = 3;
    this.lblBackColorspace.Text = "Backround Selector Colorspace";
    this.cboxBackColorspace.Anchor = AnchorStyles.Top;
    this.cboxBackColorspace.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.cboxBackColorspace.ForeColor = Color.White;
    this.cboxBackColorspace.FormattingEnabled = true;
    this.cboxBackColorspace.Items.AddRange(new object[4]
    {
      (object) "LAB",
      (object) "HSV",
      (object) "HLS",
      (object) "RGB"
    });
    this.cboxBackColorspace.Location = new Point(768 /*0x0300*/, 291);
    this.cboxBackColorspace.Name = "cboxBackColorspace";
    this.cboxBackColorspace.Size = new Size(121, 23);
    this.cboxBackColorspace.TabIndex = 4;
    this.pnlPointSave.Anchor = AnchorStyles.Left;
    this.pnlPointSave.BorderStyle = BorderStyle.FixedSingle;
    this.pnlPointSave.Controls.Add((Control) this.lblPointSave);
    this.pnlPointSave.Controls.Add((Control) this.rbPointPixel);
    this.pnlPointSave.Controls.Add((Control) this.rbPointMm);
    this.pnlPointSave.Location = new Point(29, 411);
    this.pnlPointSave.Name = "pnlPointSave";
    this.pnlPointSave.Size = new Size(353, 100);
    this.pnlPointSave.TabIndex = 5;
    this.lblPointSave.AutoSize = true;
    this.lblPointSave.ForeColor = Color.White;
    this.lblPointSave.Location = new Point(29, 41);
    this.lblPointSave.Name = "lblPointSave";
    this.lblPointSave.Size = new Size(110, 15);
    this.lblPointSave.TabIndex = 1;
    this.lblPointSave.Text = "Point Save Method:";
    this.rbPointPixel.AutoSize = true;
    this.rbPointPixel.ForeColor = Color.White;
    this.rbPointPixel.Location = new Point(286, 41);
    this.rbPointPixel.Name = "rbPointPixel";
    this.rbPointPixel.Size = new Size(49, 19);
    this.rbPointPixel.TabIndex = 0;
    this.rbPointPixel.TabStop = true;
    this.rbPointPixel.Text = "Pixel";
    this.rbPointPixel.UseVisualStyleBackColor = true;
    this.rbPointMm.AutoSize = true;
    this.rbPointMm.ForeColor = Color.White;
    this.rbPointMm.Location = new Point(186, 41);
    this.rbPointMm.Name = "rbPointMm";
    this.rbPointMm.Size = new Size(76, 19);
    this.rbPointMm.TabIndex = 0;
    this.rbPointMm.TabStop = true;
    this.rbPointMm.Text = "Milimeter";
    this.rbPointMm.UseVisualStyleBackColor = true;
    this.pnlContourShowcase.Anchor = AnchorStyles.Left;
    this.pnlContourShowcase.BorderStyle = BorderStyle.FixedSingle;
    this.pnlContourShowcase.Controls.Add((Control) this.lblContourShowcase);
    this.pnlContourShowcase.Controls.Add((Control) this.cboxShowPoints);
    this.pnlContourShowcase.Controls.Add((Control) this.cboxShowArea);
    this.pnlContourShowcase.Controls.Add((Control) this.rbCurve);
    this.pnlContourShowcase.Controls.Add((Control) this.rbRect);
    this.pnlContourShowcase.Location = new Point(28, 517);
    this.pnlContourShowcase.Name = "pnlContourShowcase";
    this.pnlContourShowcase.Size = new Size(521, 100);
    this.pnlContourShowcase.TabIndex = 5;
    this.lblContourShowcase.AutoSize = true;
    this.lblContourShowcase.ForeColor = Color.White;
    this.lblContourShowcase.Location = new Point(30, 44);
    this.lblContourShowcase.Name = "lblContourShowcase";
    this.lblContourShowcase.Size = new Size(109, 15);
    this.lblContourShowcase.TabIndex = 1;
    this.lblContourShowcase.Text = "Contour Showcase:";
    this.cboxShowPoints.AutoSize = true;
    this.cboxShowPoints.ForeColor = Color.White;
    this.cboxShowPoints.Location = new Point(247, 44);
    this.cboxShowPoints.Name = "cboxShowPoints";
    this.cboxShowPoints.Size = new Size(91, 19);
    this.cboxShowPoints.TabIndex = 1;
    this.cboxShowPoints.Text = "Show Points";
    this.cboxShowPoints.UseVisualStyleBackColor = true;
    this.cboxShowArea.AutoSize = true;
    this.cboxShowArea.ForeColor = Color.White;
    this.cboxShowArea.Location = new Point(147, 44);
    this.cboxShowArea.Name = "cboxShowArea";
    this.cboxShowArea.Size = new Size(82, 19);
    this.cboxShowArea.TabIndex = 1;
    this.cboxShowArea.Text = "Show Area";
    this.cboxShowArea.UseVisualStyleBackColor = true;
    this.rbCurve.AutoSize = true;
    this.rbCurve.ForeColor = Color.White;
    this.rbCurve.Location = new Point(453, 44);
    this.rbCurve.Name = "rbCurve";
    this.rbCurve.Size = new Size(56, 19);
    this.rbCurve.TabIndex = 0;
    this.rbCurve.TabStop = true;
    this.rbCurve.Text = "Curve";
    this.rbCurve.UseVisualStyleBackColor = true;
    this.rbRect.AutoSize = true;
    this.rbRect.ForeColor = Color.White;
    this.rbRect.Location = new Point(358, 44);
    this.rbRect.Name = "rbRect";
    this.rbRect.Size = new Size(77, 19);
    this.rbRect.TabIndex = 0;
    this.rbRect.TabStop = true;
    this.rbRect.Text = "Rectnagle";
    this.rbRect.UseVisualStyleBackColor = true;
    this.pnlContourMethod.Anchor = AnchorStyles.Left;
    this.pnlContourMethod.BorderStyle = BorderStyle.FixedSingle;
    this.pnlContourMethod.Controls.Add((Control) this.lblContourMethod);
    this.pnlContourMethod.Controls.Add((Control) this.rbAllPoints);
    this.pnlContourMethod.Controls.Add((Control) this.rbSample);
    this.pnlContourMethod.Controls.Add((Control) this.rbSimplified);
    this.pnlContourMethod.Controls.Add((Control) this.rbMerge);
    this.pnlContourMethod.Location = new Point(29, 623);
    this.pnlContourMethod.Name = "pnlContourMethod";
    this.pnlContourMethod.Size = new Size(520, 100);
    this.pnlContourMethod.TabIndex = 5;
    this.lblContourMethod.AutoSize = true;
    this.lblContourMethod.ForeColor = Color.White;
    this.lblContourMethod.Location = new Point(29, 41);
    this.lblContourMethod.Name = "lblContourMethod";
    this.lblContourMethod.Size = new Size(99, 15);
    this.lblContourMethod.TabIndex = 1;
    this.lblContourMethod.Text = "Contour Method:";
    this.rbAllPoints.AutoSize = true;
    this.rbAllPoints.ForeColor = Color.White;
    this.rbAllPoints.Location = new Point(414, 41);
    this.rbAllPoints.Name = "rbAllPoints";
    this.rbAllPoints.Size = new Size(75, 19);
    this.rbAllPoints.TabIndex = 0;
    this.rbAllPoints.TabStop = true;
    this.rbAllPoints.Text = "All Points";
    this.rbAllPoints.UseVisualStyleBackColor = true;
    this.rbSample.AutoSize = true;
    this.rbSample.ForeColor = Color.White;
    this.rbSample.Location = new Point(330, 41);
    this.rbSample.Name = "rbSample";
    this.rbSample.Size = new Size(64 /*0x40*/, 19);
    this.rbSample.TabIndex = 0;
    this.rbSample.TabStop = true;
    this.rbSample.Text = "Sample";
    this.rbSample.UseVisualStyleBackColor = true;
    this.rbSimplified.AutoSize = true;
    this.rbSimplified.ForeColor = Color.White;
    this.rbSimplified.Location = new Point(230, 41);
    this.rbSimplified.Name = "rbSimplified";
    this.rbSimplified.Size = new Size(78, 19);
    this.rbSimplified.TabIndex = 0;
    this.rbSimplified.TabStop = true;
    this.rbSimplified.Text = "Simplified";
    this.rbSimplified.UseVisualStyleBackColor = true;
    this.rbMerge.AutoSize = true;
    this.rbMerge.ForeColor = Color.White;
    this.rbMerge.Location = new Point(155, 41);
    this.rbMerge.Name = "rbMerge";
    this.rbMerge.Size = new Size(59, 19);
    this.rbMerge.TabIndex = 0;
    this.rbMerge.TabStop = true;
    this.rbMerge.Text = "Merge";
    this.rbMerge.UseVisualStyleBackColor = true;
    this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnCancel.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnCancel.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnCancel.ForeColor = Color.White;
    this.btnCancel.Location = new Point(853, 648);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new Size(138, 46);
    this.btnCancel.TabIndex = 65;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.UseVisualStyleBackColor = false;
    this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
    this.btnApplySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnApplySettings.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnApplySettings.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnApplySettings.ForeColor = Color.White;
    this.btnApplySettings.Location = new Point(656, 648);
    this.btnApplySettings.Name = "btnApplySettings";
    this.btnApplySettings.Size = new Size(138, 46);
    this.btnApplySettings.TabIndex = 66;
    this.btnApplySettings.Text = "Apply Settings";
    this.btnApplySettings.UseVisualStyleBackColor = false;
    this.btnApplySettings.Click += new EventHandler(this.btnApplySettings_Click);
    this.numUDCornerTresh.Anchor = AnchorStyles.Right;
    this.numUDCornerTresh.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDCornerTresh.ForeColor = Color.White;
    this.numUDCornerTresh.Location = new Point(827, 411);
    this.numUDCornerTresh.Maximum = new Decimal(new int[4]
    {
      360,
      0,
      0,
      0
    });
    this.numUDCornerTresh.Name = "numUDCornerTresh";
    this.numUDCornerTresh.Size = new Size(120, 23);
    this.numUDCornerTresh.TabIndex = 0;
    this.numUDLineTresh.Anchor = AnchorStyles.Right;
    this.numUDLineTresh.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDLineTresh.ForeColor = Color.White;
    this.numUDLineTresh.Location = new Point(827, 477);
    this.numUDLineTresh.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDLineTresh.Name = "numUDLineTresh";
    this.numUDLineTresh.Size = new Size(120, 23);
    this.numUDLineTresh.TabIndex = 0;
    this.lblCornerTresh.Anchor = AnchorStyles.Right;
    this.lblCornerTresh.AutoSize = true;
    this.lblCornerTresh.ForeColor = Color.White;
    this.lblCornerTresh.Location = new Point(674, 413);
    this.lblCornerTresh.Name = "lblCornerTresh";
    this.lblCornerTresh.Size = new Size(125, 15);
    this.lblCornerTresh.TabIndex = 1;
    this.lblCornerTresh.Text = "Corner Angle Treshold";
    this.lblLineTresh.Anchor = AnchorStyles.Right;
    this.lblLineTresh.AutoSize = true;
    this.lblLineTresh.ForeColor = Color.White;
    this.lblLineTresh.Location = new Point(688, 479);
    this.lblLineTresh.Name = "lblLineTresh";
    this.lblLineTresh.Size = new Size(93, 15);
    this.lblLineTresh.TabIndex = 1;
    this.lblLineTresh.Text = "Line Fit Treshold";
    this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnMinimize.BackColor = Color.FromArgb(50, 50, 50);
    this.btnMinimize.FlatAppearance.BorderSize = 0;
    this.btnMinimize.FlatStyle = FlatStyle.Flat;
    this.btnMinimize.ForeColor = Color.White;
    this.btnMinimize.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnMinimize.Image");
    this.btnMinimize.Location = new Point(910, 12);
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
    this.btnExtend.Location = new Point(967, 12);
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
    this.btnClose.Location = new Point(1023 /*0x03FF*/, 12);
    this.btnClose.Name = "btnClose";
    this.btnClose.Size = new Size(50, 50);
    this.btnClose.TabIndex = 70;
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnCancel_Click);
    this.AutoScaleDimensions = new SizeF(7f, 15f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.FromArgb(50, 50, 50);
    this.ClientSize = new Size(1085, 765);
    this.Controls.Add((Control) this.btnMinimize);
    this.Controls.Add((Control) this.btnExtend);
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.btnCancel);
    this.Controls.Add((Control) this.btnApplySettings);
    this.Controls.Add((Control) this.pnlContourMethod);
    this.Controls.Add((Control) this.pnlContourShowcase);
    this.Controls.Add((Control) this.pnlPointSave);
    this.Controls.Add((Control) this.cboxBackColorspace);
    this.Controls.Add((Control) this.lblSensitivity);
    this.Controls.Add((Control) this.lblContourDist);
    this.Controls.Add((Control) this.lblBackColorspace);
    this.Controls.Add((Control) this.lblMinArea);
    this.Controls.Add((Control) this.tbarSensitivy);
    this.Controls.Add((Control) this.tbarContourDist);
    this.Controls.Add((Control) this.tbarMinAea);
    this.Controls.Add((Control) this.lblVal);
    this.Controls.Add((Control) this.lblLineTresh);
    this.Controls.Add((Control) this.lblCornerTresh);
    this.Controls.Add((Control) this.lblSat);
    this.Controls.Add((Control) this.lblHue);
    this.Controls.Add((Control) this.numUDLineTresh);
    this.Controls.Add((Control) this.numUDVal);
    this.Controls.Add((Control) this.numUDCornerTresh);
    this.Controls.Add((Control) this.numUDSat);
    this.Controls.Add((Control) this.numUDHue);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (EdgeDetectSettings);
    this.Text = nameof (EdgeDetectSettings);
    this.Load += new EventHandler(this.EdgeDetectSettings_Load);
    ((ISupportInitialize) this.numUDHue).EndInit();
    ((ISupportInitialize) this.numUDSat).EndInit();
    ((ISupportInitialize) this.numUDVal).EndInit();
    ((ISupportInitialize) this.tbarMinAea).EndInit();
    ((ISupportInitialize) this.tbarContourDist).EndInit();
    ((ISupportInitialize) this.tbarSensitivy).EndInit();
    this.pnlPointSave.ResumeLayout(false);
    this.pnlPointSave.PerformLayout();
    this.pnlContourShowcase.ResumeLayout(false);
    this.pnlContourShowcase.PerformLayout();
    this.pnlContourMethod.ResumeLayout(false);
    this.pnlContourMethod.PerformLayout();
    ((ISupportInitialize) this.numUDCornerTresh).EndInit();
    ((ISupportInitialize) this.numUDLineTresh).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
