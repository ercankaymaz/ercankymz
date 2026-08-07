// Decompiled with JetBrains decompiler
// Type: buCameraSolutions.DigitizeSettings
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

#nullable enable
namespace buCameraSolutions;

public class DigitizeSettings : Form
{
  private string digitizePath = string.Empty;
  private string offsetPath = string.Empty;
  private CultureInfo _culture;
  private 
  #nullable disable
  IContainer components = (IContainer) null;
  private NumericUpDown numUDOffsetBottom;
  private NumericUpDown numUDOffsetRight;
  private NumericUpDown numUDOffsetLeft;
  private NumericUpDown numUDOffsetTop;
  private CheckBox cboxRotFirst;
  private Label label4;
  private Label lblK2;
  private Label label3;
  private Label lblK1;
  private Label label2;
  private Label label1;
  private Label lblRotation;
  private NumericUpDown numUDDistY;
  private NumericUpDown numUDDistX;
  private NumericUpDown numUDDistStrK2;
  private NumericUpDown numUDDistStrK1;
  private NumericUpDown numUDDelay;
  private NumericUpDown numUDRotation;
  private Label lblMarkerSize;
  private Label lblHeight;
  private Label lblWidth;
  private Panel panel1;
  private RadioButton rbuttonStretchInner;
  private RadioButton rbuttonStretchOuter;
  private Label lblStretchType;
  private RadioButton rbuttonStretchNormal;
  private NumericUpDown numUDMarkerSize;
  private NumericUpDown numUDHeight;
  private NumericUpDown numUDWidth;
  private CheckBox cboxAutoStretch;
  private CheckBox cboxAutoMirrorVertical;
  private CheckBox cboxAutoRotateRight;
  private CheckBox cboxAutoRotation;
  private CheckBox cboxAutoTopView;
  private CheckBox cboxAutoMirrorHorizontal;
  private CheckBox cboxAutoRotateLeft;
  private CheckBox cboxAutoLens;
  private Label lblOffsetTop;
  private Label lblTR;
  private Label lblBL;
  private Label lblBR;
  private Label lblDelayTime;
  private Button btnApplySettings;
  private Button btnCancel;
  private CheckBox cbAddOffset;
  private Button btnMinimize;
  private Button btnExtend;
  private Button btnClose;
  private CheckBox cbAutoContour;
  private CheckBox cbAutoCalcOffset;
  private Label lblThickness;
  private Label lblLinearMpX;
  private Label lblLinearMpY;
  private Label lbl;
  private Label lblDY;
  private TextBox tbTrans3;
  private TextBox tbLinearMpX;
  private TextBox tbLinearMpY;
  private TextBox tbStoneThickness;
  private Label label5;
  private Label label6;
  private TextBox textBox1;
  private Label label7;
  private TextBox tbOffsetCenterY;
  private TextBox tbOffsetCenterX;

  public DigitizeSettings(
  #nullable enable
  string digitPath, string offPath, CultureInfo cult)
  {
    this.InitializeComponent();
    this.digitizePath = digitPath;
    this.offsetPath = offPath;
    this._culture = cult;
  }

  private void DigitizeSettings_Load(object sender, EventArgs e)
  {
    this.ReadMenuSettings(this.digitizePath);
    this.ReadCalibOffsetStone(this.offsetPath);
  }

  private void DigitizeSettings_FormClosing(object sender, FormClosingEventArgs e)
  {
  }

  public void ReadMenuSettings(string txtSettings)
  {
    try
    {
      string[] strArray = File.ReadAllLines(txtSettings);
      string str1 = strArray.Length >= 12 ? this.GetValue(strArray[0]) : throw new Exception("Menu settings file does not contain enough lines.");
      bool result1;
      if (!bool.TryParse(str1, out result1))
        throw new Exception("Invalid boolean value for Auto Correct Lens: " + str1);
      this.cboxAutoLens.Checked = result1;
      string str2 = this.GetValue(strArray[1]);
      bool result2;
      if (!bool.TryParse(str2, out result2))
        throw new Exception("Invalid boolean value for Auto Top View: " + str2);
      this.cboxAutoTopView.Checked = result2;
      string s1 = this.GetValue(strArray[2]);
      Decimal result3;
      if (!Decimal.TryParse(s1, out result3))
        throw new Exception("Invalid numeric value for Top View Width: " + s1);
      this.numUDWidth.Value = result3;
      string s2 = this.GetValue(strArray[3]);
      Decimal result4;
      if (!Decimal.TryParse(s2, out result4))
        throw new Exception("Invalid numeric value for Top View Height: " + s2);
      this.numUDHeight.Value = result4;
      string s3 = this.GetValue(strArray[4]);
      Decimal result5;
      if (!Decimal.TryParse(s3, out result5))
        throw new Exception("Invalid numeric value for Marker Size: " + s3);
      this.numUDMarkerSize.Value = result5;
      string str3 = this.GetValue(strArray[5]);
      switch (str3)
      {
        case "Normal":
          this.rbuttonStretchNormal.Checked = true;
          break;
        case "Outer":
          this.rbuttonStretchOuter.Checked = true;
          break;
        case "Inner":
          this.rbuttonStretchInner.Checked = true;
          break;
        default:
          throw new Exception("Invalid Stretch Type value: " + str3);
      }
      string str4 = this.GetValue(strArray[6]);
      bool result6;
      if (!bool.TryParse(str4, out result6))
        throw new Exception("Invalid boolean value for Auto Rotate Left: " + str4);
      this.cboxAutoRotateLeft.Checked = result6;
      string str5 = this.GetValue(strArray[7]);
      bool result7;
      if (!bool.TryParse(str5, out result7))
        throw new Exception("Invalid boolean value for Auto Rotate Right: " + str5);
      this.cboxAutoRotateRight.Checked = result7;
      string str6 = this.GetValue(strArray[8]);
      bool result8;
      if (!bool.TryParse(str6, out result8))
        throw new Exception("Invalid boolean value for Auto Mirror Horizontal: " + str6);
      this.cboxAutoMirrorHorizontal.Checked = result8;
      string str7 = this.GetValue(strArray[9]);
      bool result9;
      if (!bool.TryParse(str7, out result9))
        throw new Exception("Invalid boolean value for Auto Mirror Vertical: " + str7);
      this.cboxAutoMirrorVertical.Checked = result9;
      string s4 = this.GetValue(strArray[10]);
      Decimal result10;
      if (!Decimal.TryParse(s4, out result10))
        throw new Exception("Invalid numeric value for Rotation Value: " + s4);
      this.numUDRotation.Value = result10;
      NumericUpDown numUdDistStrK1 = this.numUDDistStrK1;
      NumericUpDown numUdDistStrK2 = this.numUDDistStrK2;
      (Decimal, Decimal) tuple1 = this.Get2Values(strArray[11]);
      Decimal num1 = tuple1.Item1;
      numUdDistStrK1.Value = num1;
      numUdDistStrK2.Value = tuple1.Item2;
      string str8 = this.GetValue(strArray[12]);
      bool result11;
      if (!bool.TryParse(str8, out result11))
        throw new Exception("Invalid numeric value for Rotation Value: " + str8);
      this.cboxRotFirst.Checked = result11;
      string str9 = this.GetValue(strArray[13]);
      bool result12;
      if (!bool.TryParse(str9, out result12))
        throw new Exception("Invalid boolean value for Auto Rotate Left: " + str9);
      this.cboxAutoRotation.Checked = result12;
      string str10 = this.GetValue(strArray[14]);
      bool result13;
      if (!bool.TryParse(str10, out result13))
        throw new Exception("Invalid boolean value for Auto Rotate Left: " + str10);
      this.cboxAutoStretch.Checked = result13;
      NumericUpDown numUdDistX = this.numUDDistX;
      NumericUpDown numUdDistY = this.numUDDistY;
      (Decimal, Decimal) tuple2 = this.Get2Values(strArray[15]);
      Decimal num2 = tuple2.Item1;
      numUdDistX.Value = num2;
      numUdDistY.Value = tuple2.Item2;
      string s5 = this.GetValue(strArray[16 /*0x10*/]);
      Decimal result14;
      if (!Decimal.TryParse(s5, out result14))
        throw new Exception("Invalid numeric value for Top View Width: " + s5);
      this.numUDDelay.Value = result14;
      string str11 = this.GetValue(strArray[17]);
      bool result15;
      if (!bool.TryParse(str11, out result15))
        throw new Exception("Invalid boolean value for Auto Rotate Left: " + str11);
      this.cbAddOffset.Checked = result15;
      string s6 = this.GetValue(strArray[18]);
      Decimal result16;
      if (!Decimal.TryParse(s6, out result16))
        throw new Exception("Invalid numeric value for Top View Width: " + s6);
      this.numUDOffsetTop.Value = result16;
      string s7 = this.GetValue(strArray[19]);
      Decimal result17;
      if (!Decimal.TryParse(s7, out result17))
        throw new Exception("Invalid numeric value for Top View Width: " + s7);
      this.numUDOffsetBottom.Value = result17;
      string s8 = this.GetValue(strArray[20]);
      Decimal result18;
      if (!Decimal.TryParse(s8, out result18))
        throw new Exception("Invalid numeric value for Top View Width: " + s8);
      this.numUDOffsetLeft.Value = result18;
      string s9 = this.GetValue(strArray[21]);
      Decimal result19;
      if (!Decimal.TryParse(s9, out result19))
        throw new Exception("Invalid numeric value for Top View Width: " + s9);
      this.numUDOffsetRight.Value = result19;
      string str12 = this.GetValue(strArray[22]);
      bool result20;
      if (!bool.TryParse(str12, out result20))
        throw new Exception("Invalid boolean value for Auto Contour: " + str12);
      this.cbAutoContour.Checked = result20;
      string str13 = this.GetValue(strArray[23]);
      bool result21;
      if (!bool.TryParse(str13, out result21))
        throw new Exception("Invalid boolean value for Auto Calculation Offset: " + str13);
      this.cbAutoCalcOffset.Checked = result21;
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
      throw new Exception($"Invalid coordinate format. Expected 2 values, found {strArray2.Length}.");
    Decimal result1;
    if (!Decimal.TryParse(strArray2[0], out result1))
      throw new Exception("Invalid X value: " + strArray2[0]);
    Decimal result2;
    if (!Decimal.TryParse(strArray2[1], out result2))
      throw new Exception("Invalid Y value: " + strArray2[1]);
    return (result1, result2);
  }

  public void WriteMenuSettings(string menuSettings)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(menuSettings))
      {
        ((TextWriter) streamWriter).WriteLine($"Auto Correct Lens: {this.cboxAutoLens.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Top View: {this.cboxAutoTopView.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Top View Width: {this.numUDWidth.Value}");
        ((TextWriter) streamWriter).WriteLine($"Top View Height: {this.numUDHeight.Value}");
        ((TextWriter) streamWriter).WriteLine($"Marker Size: {this.numUDMarkerSize.Value}");
        string str1;
        if (!this.rbuttonStretchNormal.Checked)
        {
          if (!this.rbuttonStretchOuter.Checked)
          {
            if (!this.rbuttonStretchInner.Checked)
              throw new Exception("No stretch type radio button is selected.");
            str1 = "Inner";
          }
          else
            str1 = "Outer";
        }
        else
          str1 = "Normal";
        string str2 = str1;
        ((TextWriter) streamWriter).WriteLine("Stretch Type: " + str2);
        ((TextWriter) streamWriter).WriteLine($"Auto Rotate Left: {this.cboxAutoRotateLeft.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Rotate Right: {this.cboxAutoRotateRight.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Mirror Horizontal: {this.cboxAutoMirrorHorizontal.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Mirror Vertical: {this.cboxAutoMirrorVertical.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Rotation Value: {this.numUDRotation.Value}");
        ((TextWriter) streamWriter).WriteLine($"Distortion Strength: {this.numUDDistStrK1.Value}, {this.numUDDistStrK2.Value}");
        ((TextWriter) streamWriter).WriteLine($"Rotation First: {this.cboxRotFirst.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Rotation: {this.cboxAutoRotation.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Stretch: {this.cboxAutoStretch.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Distortion XY: {this.numUDDistX.Value}, {this.numUDDistY.Value}");
        ((TextWriter) streamWriter).WriteLine($"Delay Time: {this.numUDDelay.Value}");
        ((TextWriter) streamWriter).WriteLine($"Add Offset: {this.cbAddOffset.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Offset Top: {this.numUDOffsetTop.Value}");
        ((TextWriter) streamWriter).WriteLine($"Offset Bottom: {this.numUDOffsetBottom.Value}");
        ((TextWriter) streamWriter).WriteLine($"Offset Left: {this.numUDOffsetLeft.Value}");
        ((TextWriter) streamWriter).WriteLine($"Offset Right: {this.numUDOffsetRight.Value}");
        ((TextWriter) streamWriter).WriteLine($"Auto Contour: {this.cbAutoContour.Checked}");
        ((TextWriter) streamWriter).WriteLine($"Auto Calcuation Offset: {this.cbAutoCalcOffset.Checked}");
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error writing to menu settings file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      throw;
    }
  }

  private string FormatValue(string rawValue)
  {
    double result;
    return double.TryParse(rawValue, NumberStyles.Any, (IFormatProvider) this._culture, out result) ? result.ToString("0.######", (IFormatProvider) this._culture) : rawValue;
  }

  public void ReadCalibOffsetStone(string calcOffsetPath)
  {
    try
    {
      if (!File.Exists(calcOffsetPath))
      {
        this.tbStoneThickness.Text = "0";
        this.tbLinearMpX.Text = "0";
        this.tbLinearMpY.Text = "0";
        this.tbOffsetCenterX.Text = "0";
        this.tbOffsetCenterY.Text = "0";
      }
      else
      {
        string[] strArray = File.ReadAllLines(calcOffsetPath);
        if (strArray.Length < 3)
          return;
        this.tbStoneThickness.Text = this.FormatValue(this.GetValue(strArray[0]));
        this.tbLinearMpX.Text = this.FormatValue(this.GetValue(strArray[1]));
        this.tbLinearMpY.Text = this.FormatValue(this.GetValue(strArray[2]));
        this.tbOffsetCenterX.Text = this.FormatValue(this.GetValue(strArray[3]));
        this.tbOffsetCenterY.Text = this.FormatValue(this.GetValue(strArray[4]));
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error reading stone offset settings: " + ex.Message);
    }
  }

  public void WriteCalibOffsetStone(string calcOffsetPath)
  {
    try
    {
      using (StreamWriter streamWriter = new StreamWriter(calcOffsetPath))
      {
        double num1 = double.Parse(this.tbStoneThickness.Text, (IFormatProvider) this._culture);
        double num2 = double.Parse(this.tbLinearMpX.Text, (IFormatProvider) this._culture);
        double num3 = double.Parse(this.tbLinearMpY.Text, (IFormatProvider) this._culture);
        double num4 = double.Parse(this.tbOffsetCenterX.Text, (IFormatProvider) this._culture);
        double num5 = double.Parse(this.tbOffsetCenterY.Text, (IFormatProvider) this._culture);
        ((TextWriter) streamWriter).WriteLine("Stone Thickness: " + num1.ToString((IFormatProvider) this._culture));
        ((TextWriter) streamWriter).WriteLine("Multiplier X: " + num2.ToString((IFormatProvider) this._culture));
        ((TextWriter) streamWriter).WriteLine("Multiplier Y: " + num3.ToString((IFormatProvider) this._culture));
        ((TextWriter) streamWriter).WriteLine("Offset Center X: " + num4.ToString((IFormatProvider) this._culture));
        ((TextWriter) streamWriter).WriteLine("Offset Center Y: " + num5.ToString((IFormatProvider) this._culture));
        Variables.StoneThickness = num1;
        Variables.OffsetMpX = num2;
        Variables.OffsetMpY = num3;
        Variables.OffsetCenterX = num4;
        Variables.OffsetCenterY = num5;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Failed to save stone offset calibration: " + ex.Message);
    }
  }

  private void btnApplySettings_Click(object sender, EventArgs e)
  {
    this.WriteMenuSettings(this.digitizePath);
    this.WriteCalibOffsetStone(this.offsetPath);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (DigitizeSettings));
    this.numUDOffsetBottom = new NumericUpDown();
    this.numUDOffsetRight = new NumericUpDown();
    this.numUDOffsetLeft = new NumericUpDown();
    this.numUDOffsetTop = new NumericUpDown();
    this.cboxRotFirst = new CheckBox();
    this.label4 = new Label();
    this.lblK2 = new Label();
    this.label3 = new Label();
    this.lblK1 = new Label();
    this.label2 = new Label();
    this.label1 = new Label();
    this.lblRotation = new Label();
    this.numUDDistY = new NumericUpDown();
    this.numUDDistX = new NumericUpDown();
    this.numUDDistStrK2 = new NumericUpDown();
    this.numUDDistStrK1 = new NumericUpDown();
    this.numUDDelay = new NumericUpDown();
    this.numUDRotation = new NumericUpDown();
    this.lblMarkerSize = new Label();
    this.lblHeight = new Label();
    this.lblWidth = new Label();
    this.panel1 = new Panel();
    this.rbuttonStretchInner = new RadioButton();
    this.rbuttonStretchOuter = new RadioButton();
    this.lblStretchType = new Label();
    this.rbuttonStretchNormal = new RadioButton();
    this.numUDMarkerSize = new NumericUpDown();
    this.numUDHeight = new NumericUpDown();
    this.numUDWidth = new NumericUpDown();
    this.cboxAutoStretch = new CheckBox();
    this.cboxAutoMirrorVertical = new CheckBox();
    this.cboxAutoRotateRight = new CheckBox();
    this.cboxAutoRotation = new CheckBox();
    this.cboxAutoTopView = new CheckBox();
    this.cboxAutoMirrorHorizontal = new CheckBox();
    this.cboxAutoRotateLeft = new CheckBox();
    this.cboxAutoLens = new CheckBox();
    this.lblOffsetTop = new Label();
    this.lblTR = new Label();
    this.lblBL = new Label();
    this.lblBR = new Label();
    this.lblDelayTime = new Label();
    this.btnApplySettings = new Button();
    this.btnCancel = new Button();
    this.cbAddOffset = new CheckBox();
    this.btnMinimize = new Button();
    this.btnExtend = new Button();
    this.btnClose = new Button();
    this.cbAutoContour = new CheckBox();
    this.cbAutoCalcOffset = new CheckBox();
    this.lblThickness = new Label();
    this.lblLinearMpX = new Label();
    this.lblLinearMpY = new Label();
    this.tbLinearMpY = new TextBox();
    this.tbLinearMpX = new TextBox();
    this.tbStoneThickness = new TextBox();
    this.label5 = new Label();
    this.label6 = new Label();
    this.tbOffsetCenterX = new TextBox();
    this.label7 = new Label();
    this.tbOffsetCenterY = new TextBox();
    ((ISupportInitialize) this.numUDOffsetBottom).BeginInit();
    ((ISupportInitialize) this.numUDOffsetRight).BeginInit();
    ((ISupportInitialize) this.numUDOffsetLeft).BeginInit();
    ((ISupportInitialize) this.numUDOffsetTop).BeginInit();
    ((ISupportInitialize) this.numUDDistY).BeginInit();
    ((ISupportInitialize) this.numUDDistX).BeginInit();
    ((ISupportInitialize) this.numUDDistStrK2).BeginInit();
    ((ISupportInitialize) this.numUDDistStrK1).BeginInit();
    ((ISupportInitialize) this.numUDDelay).BeginInit();
    ((ISupportInitialize) this.numUDRotation).BeginInit();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.numUDMarkerSize).BeginInit();
    ((ISupportInitialize) this.numUDHeight).BeginInit();
    ((ISupportInitialize) this.numUDWidth).BeginInit();
    this.SuspendLayout();
    this.numUDOffsetBottom.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDOffsetBottom.ForeColor = Color.White;
    this.numUDOffsetBottom.Location = new Point(697, 533);
    this.numUDOffsetBottom.Margin = new Padding(4, 3, 4, 3);
    this.numUDOffsetBottom.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDOffsetBottom.Minimum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      int.MinValue
    });
    this.numUDOffsetBottom.Name = "numUDOffsetBottom";
    this.numUDOffsetBottom.Size = new Size(63 /*0x3F*/, 23);
    this.numUDOffsetBottom.TabIndex = 56;
    this.numUDOffsetRight.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDOffsetRight.ForeColor = Color.White;
    this.numUDOffsetRight.Location = new Point(697, 620);
    this.numUDOffsetRight.Margin = new Padding(4, 3, 4, 3);
    this.numUDOffsetRight.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDOffsetRight.Minimum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      int.MinValue
    });
    this.numUDOffsetRight.Name = "numUDOffsetRight";
    this.numUDOffsetRight.Size = new Size(63 /*0x3F*/, 23);
    this.numUDOffsetRight.TabIndex = 54;
    this.numUDOffsetLeft.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDOffsetLeft.ForeColor = Color.White;
    this.numUDOffsetLeft.Location = new Point(697, 574);
    this.numUDOffsetLeft.Margin = new Padding(4, 3, 4, 3);
    this.numUDOffsetLeft.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDOffsetLeft.Minimum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      int.MinValue
    });
    this.numUDOffsetLeft.Name = "numUDOffsetLeft";
    this.numUDOffsetLeft.Size = new Size(63 /*0x3F*/, 23);
    this.numUDOffsetLeft.TabIndex = 52;
    this.numUDOffsetTop.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDOffsetTop.ForeColor = Color.White;
    this.numUDOffsetTop.Location = new Point(697, 487);
    this.numUDOffsetTop.Margin = new Padding(4, 3, 4, 3);
    this.numUDOffsetTop.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDOffsetTop.Minimum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      int.MinValue
    });
    this.numUDOffsetTop.Name = "numUDOffsetTop";
    this.numUDOffsetTop.Size = new Size(63 /*0x3F*/, 23);
    this.numUDOffsetTop.TabIndex = 51;
    this.cboxRotFirst.AutoSize = true;
    this.cboxRotFirst.Font = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.cboxRotFirst.ForeColor = Color.White;
    this.cboxRotFirst.Location = new Point(309, 448);
    this.cboxRotFirst.Margin = new Padding(4, 3, 4, 3);
    this.cboxRotFirst.Name = "cboxRotFirst";
    this.cboxRotFirst.Size = new Size(116, 24);
    this.cboxRotFirst.TabIndex = 49;
    this.cboxRotFirst.Text = "Rotation First";
    this.cboxRotFirst.UseVisualStyleBackColor = true;
    this.label4.AutoSize = true;
    this.label4.Font = new Font("Segoe UI", 12f);
    this.label4.ForeColor = Color.White;
    this.label4.Location = new Point(418, 307);
    this.label4.Margin = new Padding(4, 0, 4, 0);
    this.label4.Name = "label4";
    this.label4.Size = new Size(19, 21);
    this.label4.TabIndex = 47;
    this.label4.Text = "Y";
    this.lblK2.AutoSize = true;
    this.lblK2.Font = new Font("Segoe UI", 12f);
    this.lblK2.ForeColor = Color.White;
    this.lblK2.Location = new Point(418, 260);
    this.lblK2.Margin = new Padding(4, 0, 4, 0);
    this.lblK2.Name = "lblK2";
    this.lblK2.Size = new Size(28, 21);
    this.lblK2.TabIndex = 46;
    this.lblK2.Text = "K2";
    this.label3.AutoSize = true;
    this.label3.Font = new Font("Segoe UI", 12f);
    this.label3.ForeColor = Color.White;
    this.label3.Location = new Point(210, 306);
    this.label3.Margin = new Padding(4, 0, 4, 0);
    this.label3.Name = "label3";
    this.label3.Size = new Size(19, 21);
    this.label3.TabIndex = 45;
    this.label3.Text = "X";
    this.lblK1.AutoSize = true;
    this.lblK1.Font = new Font("Segoe UI", 12f);
    this.lblK1.ForeColor = Color.White;
    this.lblK1.Location = new Point(210, 259);
    this.lblK1.Margin = new Padding(4, 0, 4, 0);
    this.lblK1.Name = "lblK1";
    this.lblK1.Size = new Size(28, 21);
    this.lblK1.TabIndex = 44;
    this.lblK1.Text = "K1";
    this.label2.AutoSize = true;
    this.label2.Font = new Font("Segoe UI", 12f);
    this.label2.ForeColor = Color.White;
    this.label2.Location = new Point(52, 308);
    this.label2.Margin = new Padding(4, 0, 4, 0);
    this.label2.Name = "label2";
    this.label2.Size = new Size(101, 21);
    this.label2.TabIndex = 43;
    this.label2.Text = "Distortion XY";
    this.label1.AutoSize = true;
    this.label1.Font = new Font("Segoe UI", 12f);
    this.label1.ForeColor = Color.White;
    this.label1.Location = new Point(33, 260);
    this.label1.Margin = new Padding(4, 0, 4, 0);
    this.label1.Name = "label1";
    this.label1.Size = new Size(142, 21);
    this.label1.TabIndex = 48 /*0x30*/;
    this.label1.Text = "Distortion Strength";
    this.lblRotation.AutoSize = true;
    this.lblRotation.Font = new Font("Segoe UI", 12f);
    this.lblRotation.ForeColor = Color.White;
    this.lblRotation.Location = new Point(28, 448);
    this.lblRotation.Margin = new Padding(4, 0, 4, 0);
    this.lblRotation.Name = "lblRotation";
    this.lblRotation.Size = new Size(69, 21);
    this.lblRotation.TabIndex = 42;
    this.lblRotation.Text = "Rotation";
    this.numUDDistY.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDDistY.ForeColor = Color.White;
    this.numUDDistY.Location = new Point(460, 307);
    this.numUDDistY.Margin = new Padding(4, 3, 4, 3);
    this.numUDDistY.Maximum = new Decimal(new int[4]
    {
      1000,
      0,
      0,
      0
    });
    this.numUDDistY.Name = "numUDDistY";
    this.numUDDistY.Size = new Size(120, 23);
    this.numUDDistY.TabIndex = 36;
    this.numUDDistX.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDDistX.ForeColor = Color.White;
    this.numUDDistX.Location = new Point(252, 307);
    this.numUDDistX.Margin = new Padding(4, 3, 4, 3);
    this.numUDDistX.Maximum = new Decimal(new int[4]
    {
      1000,
      0,
      0,
      0
    });
    this.numUDDistX.Name = "numUDDistX";
    this.numUDDistX.Size = new Size(120, 23);
    this.numUDDistX.TabIndex = 41;
    this.numUDDistStrK2.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDDistStrK2.ForeColor = Color.White;
    this.numUDDistStrK2.Location = new Point(460, 260);
    this.numUDDistStrK2.Margin = new Padding(4, 3, 4, 3);
    this.numUDDistStrK2.Maximum = new Decimal(new int[4]
    {
      1000,
      0,
      0,
      0
    });
    this.numUDDistStrK2.Name = "numUDDistStrK2";
    this.numUDDistStrK2.Size = new Size(120, 23);
    this.numUDDistStrK2.TabIndex = 40;
    this.numUDDistStrK1.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDDistStrK1.ForeColor = Color.White;
    this.numUDDistStrK1.Location = new Point(252, 260);
    this.numUDDistStrK1.Margin = new Padding(4, 3, 4, 3);
    this.numUDDistStrK1.Maximum = new Decimal(new int[4]
    {
      1000,
      0,
      0,
      0
    });
    this.numUDDistStrK1.Name = "numUDDistStrK1";
    this.numUDDistStrK1.Size = new Size(120, 23);
    this.numUDDistStrK1.TabIndex = 39;
    this.numUDDelay.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDDelay.ForeColor = Color.White;
    this.numUDDelay.Location = new Point(946, 723);
    this.numUDDelay.Margin = new Padding(4, 3, 4, 3);
    this.numUDDelay.Maximum = new Decimal(new int[4]
    {
      36000,
      0,
      0,
      0
    });
    this.numUDDelay.Minimum = new Decimal(new int[4]
    {
      36000,
      0,
      0,
      int.MinValue
    });
    this.numUDDelay.Name = "numUDDelay";
    this.numUDDelay.Size = new Size(120, 23);
    this.numUDDelay.TabIndex = 38;
    this.numUDDelay.Value = new Decimal(new int[4]
    {
      8000,
      0,
      0,
      0
    });
    this.numUDRotation.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDRotation.ForeColor = Color.White;
    this.numUDRotation.Location = new Point(136, 448);
    this.numUDRotation.Margin = new Padding(4, 3, 4, 3);
    this.numUDRotation.Maximum = new Decimal(new int[4]
    {
      36000,
      0,
      0,
      0
    });
    this.numUDRotation.Minimum = new Decimal(new int[4]
    {
      36000,
      0,
      0,
      int.MinValue
    });
    this.numUDRotation.Name = "numUDRotation";
    this.numUDRotation.Size = new Size(120, 23);
    this.numUDRotation.TabIndex = 37;
    this.lblMarkerSize.AutoSize = true;
    this.lblMarkerSize.Font = new Font("Segoe UI", 14.25f);
    this.lblMarkerSize.ForeColor = Color.White;
    this.lblMarkerSize.Location = new Point(15, 673);
    this.lblMarkerSize.Margin = new Padding(4, 0, 4, 0);
    this.lblMarkerSize.Name = "lblMarkerSize";
    this.lblMarkerSize.Size = new Size(111, 25);
    this.lblMarkerSize.TabIndex = 35;
    this.lblMarkerSize.Text = "Marker Size";
    this.lblHeight.AutoSize = true;
    this.lblHeight.Font = new Font("Segoe UI", 14.25f);
    this.lblHeight.ForeColor = Color.White;
    this.lblHeight.Location = new Point(28, 626);
    this.lblHeight.Margin = new Padding(4, 0, 4, 0);
    this.lblHeight.Name = "lblHeight";
    this.lblHeight.Size = new Size(68, 25);
    this.lblHeight.TabIndex = 34;
    this.lblHeight.Text = "Height";
    this.lblWidth.AutoSize = true;
    this.lblWidth.Font = new Font("Segoe UI", 14.25f);
    this.lblWidth.ForeColor = Color.White;
    this.lblWidth.Location = new Point(28, 578);
    this.lblWidth.Margin = new Padding(4, 0, 4, 0);
    this.lblWidth.Name = "lblWidth";
    this.lblWidth.Size = new Size(63 /*0x3F*/, 25);
    this.lblWidth.TabIndex = 33;
    this.lblWidth.Text = "Width";
    this.panel1.Controls.Add((Control) this.rbuttonStretchInner);
    this.panel1.Controls.Add((Control) this.rbuttonStretchOuter);
    this.panel1.Controls.Add((Control) this.lblStretchType);
    this.panel1.Controls.Add((Control) this.rbuttonStretchNormal);
    this.panel1.Location = new Point(310, 568);
    this.panel1.Margin = new Padding(4, 3, 4, 3);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(154, 162);
    this.panel1.TabIndex = 32 /*0x20*/;
    this.rbuttonStretchInner.AutoSize = true;
    this.rbuttonStretchInner.Font = new Font("Segoe UI", 11.25f);
    this.rbuttonStretchInner.ForeColor = Color.White;
    this.rbuttonStretchInner.Location = new Point(27, 120);
    this.rbuttonStretchInner.Margin = new Padding(4, 3, 4, 3);
    this.rbuttonStretchInner.Name = "rbuttonStretchInner";
    this.rbuttonStretchInner.Size = new Size(60, 24);
    this.rbuttonStretchInner.TabIndex = 0;
    this.rbuttonStretchInner.Text = "Inner";
    this.rbuttonStretchInner.UseVisualStyleBackColor = true;
    this.rbuttonStretchOuter.AutoSize = true;
    this.rbuttonStretchOuter.Checked = true;
    this.rbuttonStretchOuter.Font = new Font("Segoe UI", 11.25f);
    this.rbuttonStretchOuter.ForeColor = Color.White;
    this.rbuttonStretchOuter.Location = new Point(27, 82);
    this.rbuttonStretchOuter.Margin = new Padding(4, 3, 4, 3);
    this.rbuttonStretchOuter.Name = "rbuttonStretchOuter";
    this.rbuttonStretchOuter.Size = new Size(64 /*0x40*/, 24);
    this.rbuttonStretchOuter.TabIndex = 0;
    this.rbuttonStretchOuter.TabStop = true;
    this.rbuttonStretchOuter.Text = "Outer";
    this.rbuttonStretchOuter.UseVisualStyleBackColor = true;
    this.lblStretchType.AutoSize = true;
    this.lblStretchType.Font = new Font("Segoe UI", 14.25f);
    this.lblStretchType.ForeColor = Color.White;
    this.lblStretchType.Location = new Point(10, 9);
    this.lblStretchType.Margin = new Padding(4, 0, 4, 0);
    this.lblStretchType.Name = "lblStretchType";
    this.lblStretchType.Size = new Size(114, 25);
    this.lblStretchType.TabIndex = 6;
    this.lblStretchType.Text = "Stretch Type";
    this.rbuttonStretchNormal.AutoSize = true;
    this.rbuttonStretchNormal.Font = new Font("Segoe UI", 11.25f);
    this.rbuttonStretchNormal.ForeColor = Color.White;
    this.rbuttonStretchNormal.Location = new Point(27, 48 /*0x30*/);
    this.rbuttonStretchNormal.Margin = new Padding(4, 3, 4, 3);
    this.rbuttonStretchNormal.Name = "rbuttonStretchNormal";
    this.rbuttonStretchNormal.Size = new Size(77, 24);
    this.rbuttonStretchNormal.TabIndex = 0;
    this.rbuttonStretchNormal.Text = "Normal";
    this.rbuttonStretchNormal.UseVisualStyleBackColor = true;
    this.numUDMarkerSize.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDMarkerSize.ForeColor = Color.White;
    this.numUDMarkerSize.Location = new Point(151, 673);
    this.numUDMarkerSize.Margin = new Padding(4, 3, 4, 3);
    this.numUDMarkerSize.Maximum = new Decimal(new int[4]
    {
      10000,
      0,
      0,
      0
    });
    this.numUDMarkerSize.Name = "numUDMarkerSize";
    this.numUDMarkerSize.Size = new Size(120, 23);
    this.numUDMarkerSize.TabIndex = 31 /*0x1F*/;
    this.numUDHeight.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDHeight.ForeColor = Color.White;
    this.numUDHeight.Location = new Point(151, 632);
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
    this.numUDHeight.TabIndex = 30;
    this.numUDWidth.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.numUDWidth.ForeColor = Color.White;
    this.numUDWidth.Location = new Point(151, 583);
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
    this.numUDWidth.TabIndex = 29;
    this.cboxAutoStretch.AutoSize = true;
    this.cboxAutoStretch.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoStretch.ForeColor = Color.White;
    this.cboxAutoStretch.Location = new Point(569, 142);
    this.cboxAutoStretch.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoStretch.Name = "cboxAutoStretch";
    this.cboxAutoStretch.Size = new Size(134, 29);
    this.cboxAutoStretch.TabIndex = 22;
    this.cboxAutoStretch.Text = "Auto Stretch";
    this.cboxAutoStretch.UseVisualStyleBackColor = true;
    this.cboxAutoMirrorVertical.AutoSize = true;
    this.cboxAutoMirrorVertical.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoMirrorVertical.ForeColor = Color.White;
    this.cboxAutoMirrorVertical.Location = new Point(299, 142);
    this.cboxAutoMirrorVertical.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoMirrorVertical.Name = "cboxAutoMirrorVertical";
    this.cboxAutoMirrorVertical.Size = new Size(198, 29);
    this.cboxAutoMirrorVertical.TabIndex = 23;
    this.cboxAutoMirrorVertical.Text = "Auto Mirror Vertical";
    this.cboxAutoMirrorVertical.UseVisualStyleBackColor = true;
    this.cboxAutoRotateRight.AutoSize = true;
    this.cboxAutoRotateRight.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoRotateRight.ForeColor = Color.White;
    this.cboxAutoRotateRight.Location = new Point(299, 97);
    this.cboxAutoRotateRight.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoRotateRight.Name = "cboxAutoRotateRight";
    this.cboxAutoRotateRight.Size = new Size(178, 29);
    this.cboxAutoRotateRight.TabIndex = 24;
    this.cboxAutoRotateRight.Text = "Auto Rotate Right";
    this.cboxAutoRotateRight.UseVisualStyleBackColor = true;
    this.cboxAutoRotation.AutoSize = true;
    this.cboxAutoRotation.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoRotation.ForeColor = Color.White;
    this.cboxAutoRotation.Location = new Point(568, 97);
    this.cboxAutoRotation.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoRotation.Name = "cboxAutoRotation";
    this.cboxAutoRotation.Size = new Size(146, 29);
    this.cboxAutoRotation.TabIndex = 28;
    this.cboxAutoRotation.Text = "Auto Rotation";
    this.cboxAutoRotation.UseVisualStyleBackColor = true;
    this.cboxAutoTopView.AutoSize = true;
    this.cboxAutoTopView.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoTopView.ForeColor = Color.White;
    this.cboxAutoTopView.Location = new Point(299, 56);
    this.cboxAutoTopView.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoTopView.Name = "cboxAutoTopView";
    this.cboxAutoTopView.Size = new Size(152, 29);
    this.cboxAutoTopView.TabIndex = 26;
    this.cboxAutoTopView.Text = "Auto Top View";
    this.cboxAutoTopView.UseVisualStyleBackColor = true;
    this.cboxAutoMirrorHorizontal.AutoSize = true;
    this.cboxAutoMirrorHorizontal.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoMirrorHorizontal.ForeColor = Color.White;
    this.cboxAutoMirrorHorizontal.Location = new Point(30, 142);
    this.cboxAutoMirrorHorizontal.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoMirrorHorizontal.Name = "cboxAutoMirrorHorizontal";
    this.cboxAutoMirrorHorizontal.Size = new Size(223, 29);
    this.cboxAutoMirrorHorizontal.TabIndex = 27;
    this.cboxAutoMirrorHorizontal.Text = "Auto Mirror Horizontal";
    this.cboxAutoMirrorHorizontal.UseVisualStyleBackColor = true;
    this.cboxAutoRotateLeft.AutoSize = true;
    this.cboxAutoRotateLeft.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoRotateLeft.ForeColor = Color.White;
    this.cboxAutoRotateLeft.Location = new Point(30, 97);
    this.cboxAutoRotateLeft.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoRotateLeft.Name = "cboxAutoRotateLeft";
    this.cboxAutoRotateLeft.Size = new Size(165, 29);
    this.cboxAutoRotateLeft.TabIndex = 25;
    this.cboxAutoRotateLeft.Text = "Auto Rotate Left";
    this.cboxAutoRotateLeft.UseVisualStyleBackColor = true;
    this.cboxAutoLens.AutoSize = true;
    this.cboxAutoLens.Font = new Font("Segoe UI", 14.25f);
    this.cboxAutoLens.ForeColor = Color.White;
    this.cboxAutoLens.Location = new Point(30, 56);
    this.cboxAutoLens.Margin = new Padding(4, 3, 4, 3);
    this.cboxAutoLens.Name = "cboxAutoLens";
    this.cboxAutoLens.Size = new Size(181, 29);
    this.cboxAutoLens.TabIndex = 21;
    this.cboxAutoLens.Text = "Auto Correct Lens";
    this.cboxAutoLens.UseVisualStyleBackColor = true;
    this.lblOffsetTop.AutoSize = true;
    this.lblOffsetTop.Font = new Font("Segoe UI", 12f);
    this.lblOffsetTop.ForeColor = Color.White;
    this.lblOffsetTop.Location = new Point(546, 489);
    this.lblOffsetTop.Margin = new Padding(4, 0, 4, 0);
    this.lblOffsetTop.Name = "lblOffsetTop";
    this.lblOffsetTop.Size = new Size(80 /*0x50*/, 21);
    this.lblOffsetTop.TabIndex = 63 /*0x3F*/;
    this.lblOffsetTop.Text = "Top Offset";
    this.lblTR.AutoSize = true;
    this.lblTR.Font = new Font("Segoe UI", 12f);
    this.lblTR.ForeColor = Color.White;
    this.lblTR.Location = new Point(546, 533);
    this.lblTR.Margin = new Padding(4, 0, 4, 0);
    this.lblTR.Name = "lblTR";
    this.lblTR.Size = new Size(107, 21);
    this.lblTR.TabIndex = 63 /*0x3F*/;
    this.lblTR.Text = "Bottom Offset";
    this.lblBL.AutoSize = true;
    this.lblBL.Font = new Font("Segoe UI", 12f);
    this.lblBL.ForeColor = Color.White;
    this.lblBL.Location = new Point(546, 576);
    this.lblBL.Margin = new Padding(4, 0, 4, 0);
    this.lblBL.Name = "lblBL";
    this.lblBL.Size = new Size(82, 21);
    this.lblBL.TabIndex = 63 /*0x3F*/;
    this.lblBL.Text = "Left Offset";
    this.lblBR.AutoSize = true;
    this.lblBR.Font = new Font("Segoe UI", 12f);
    this.lblBR.ForeColor = Color.White;
    this.lblBR.Location = new Point(546, 622);
    this.lblBR.Margin = new Padding(4, 0, 4, 0);
    this.lblBR.Name = "lblBR";
    this.lblBR.Size = new Size(93, 21);
    this.lblBR.TabIndex = 63 /*0x3F*/;
    this.lblBR.Text = "Right Offset";
    this.lblDelayTime.AutoSize = true;
    this.lblDelayTime.Font = new Font("Segoe UI", 12f);
    this.lblDelayTime.ForeColor = Color.White;
    this.lblDelayTime.Location = new Point(819, 723);
    this.lblDelayTime.Margin = new Padding(4, 0, 4, 0);
    this.lblDelayTime.Name = "lblDelayTime";
    this.lblDelayTime.Size = new Size(87, 21);
    this.lblDelayTime.TabIndex = 63 /*0x3F*/;
    this.lblDelayTime.Text = "Delay Time";
    this.btnApplySettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnApplySettings.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnApplySettings.FlatAppearance.BorderSize = 0;
    this.btnApplySettings.FlatStyle = FlatStyle.Flat;
    this.btnApplySettings.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnApplySettings.ForeColor = Color.White;
    this.btnApplySettings.Location = new Point(765, 816);
    this.btnApplySettings.Name = "btnApplySettings";
    this.btnApplySettings.Size = new Size(138, 46);
    this.btnApplySettings.TabIndex = 64 /*0x40*/;
    this.btnApplySettings.Text = "Apply Settings";
    this.btnApplySettings.UseVisualStyleBackColor = false;
    this.btnApplySettings.Click += new EventHandler(this.btnApplySettings_Click);
    this.btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    this.btnCancel.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.btnCancel.FlatAppearance.BorderSize = 0;
    this.btnCancel.FlatStyle = FlatStyle.Flat;
    this.btnCancel.Font = new Font("Segoe UI", 12f, FontStyle.Italic);
    this.btnCancel.ForeColor = Color.White;
    this.btnCancel.Location = new Point(962, 816);
    this.btnCancel.Name = "btnCancel";
    this.btnCancel.Size = new Size(138, 46);
    this.btnCancel.TabIndex = 64 /*0x40*/;
    this.btnCancel.Text = "Cancel";
    this.btnCancel.UseVisualStyleBackColor = false;
    this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
    this.cbAddOffset.AutoSize = true;
    this.cbAddOffset.Font = new Font("Segoe UI", 14.25f);
    this.cbAddOffset.ForeColor = Color.White;
    this.cbAddOffset.Location = new Point(593, 427);
    this.cbAddOffset.Margin = new Padding(4, 3, 4, 3);
    this.cbAddOffset.Name = "cbAddOffset";
    this.cbAddOffset.Size = new Size(120, 29);
    this.cbAddOffset.TabIndex = 22;
    this.cbAddOffset.Text = "Add Offset";
    this.cbAddOffset.UseVisualStyleBackColor = true;
    this.btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnMinimize.BackColor = Color.FromArgb(50, 50, 50);
    this.btnMinimize.FlatAppearance.BorderSize = 0;
    this.btnMinimize.FlatStyle = FlatStyle.Flat;
    this.btnMinimize.ForeColor = Color.White;
    this.btnMinimize.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnMinimize.Image");
    this.btnMinimize.Location = new Point(986, 12);
    this.btnMinimize.Name = "btnMinimize";
    this.btnMinimize.Size = new Size(50, 50);
    this.btnMinimize.TabIndex = 65;
    this.btnMinimize.UseVisualStyleBackColor = false;
    this.btnMinimize.Click += new EventHandler(this.btnMinimize_Click);
    this.btnExtend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnExtend.BackColor = Color.FromArgb(50, 50, 50);
    this.btnExtend.FlatAppearance.BorderSize = 0;
    this.btnExtend.FlatStyle = FlatStyle.Flat;
    this.btnExtend.ForeColor = Color.White;
    this.btnExtend.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnExtend.Image");
    this.btnExtend.Location = new Point(1043, 12);
    this.btnExtend.Name = "btnExtend";
    this.btnExtend.Size = new Size(50, 50);
    this.btnExtend.TabIndex = 66;
    this.btnExtend.UseVisualStyleBackColor = false;
    this.btnExtend.Click += new EventHandler(this.btnExtend_Click);
    this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.btnClose.BackColor = Color.FromArgb(50, 50, 50);
    this.btnClose.FlatAppearance.BorderSize = 0;
    this.btnClose.FlatStyle = FlatStyle.Flat;
    this.btnClose.ForeColor = Color.White;
    this.btnClose.Image = (Image) ((ResourceManager) componentResourceManager).GetObject("btnClose.Image");
    this.btnClose.Location = new Point(1099, 12);
    this.btnClose.Name = "btnClose";
    this.btnClose.Size = new Size(50, 50);
    this.btnClose.TabIndex = 67;
    this.btnClose.UseVisualStyleBackColor = false;
    this.btnClose.Click += new EventHandler(this.btnCancel_Click);
    this.cbAutoContour.AutoSize = true;
    this.cbAutoContour.Font = new Font("Segoe UI", 14.25f);
    this.cbAutoContour.ForeColor = Color.White;
    this.cbAutoContour.Location = new Point(569, 56);
    this.cbAutoContour.Margin = new Padding(4, 3, 4, 3);
    this.cbAutoContour.Name = "cbAutoContour";
    this.cbAutoContour.Size = new Size(145, 29);
    this.cbAutoContour.TabIndex = 28;
    this.cbAutoContour.Text = "Auto Contour";
    this.cbAutoContour.UseVisualStyleBackColor = true;
    this.cbAutoCalcOffset.AutoSize = true;
    this.cbAutoCalcOffset.Font = new Font("Segoe UI", 14.25f);
    this.cbAutoCalcOffset.ForeColor = Color.White;
    this.cbAutoCalcOffset.Location = new Point(878, 97);
    this.cbAutoCalcOffset.Margin = new Padding(4, 3, 4, 3);
    this.cbAutoCalcOffset.Name = "cbAutoCalcOffset";
    this.cbAutoCalcOffset.Size = new Size(226, 29);
    this.cbAutoCalcOffset.TabIndex = 22;
    this.cbAutoCalcOffset.Text = "Auto Calculation Offset";
    this.cbAutoCalcOffset.UseVisualStyleBackColor = true;
    this.lblThickness.AutoSize = true;
    this.lblThickness.Font = new Font("Segoe UI", 11.25f);
    this.lblThickness.ForeColor = Color.White;
    this.lblThickness.Location = new Point(899, 151);
    this.lblThickness.Margin = new Padding(4, 0, 4, 0);
    this.lblThickness.Name = "lblThickness";
    this.lblThickness.Size = new Size(71, 20);
    this.lblThickness.TabIndex = 63 /*0x3F*/;
    this.lblThickness.Text = "Thickness";
    this.lblLinearMpX.AutoSize = true;
    this.lblLinearMpX.Font = new Font("Segoe UI", 11.25f);
    this.lblLinearMpX.ForeColor = Color.White;
    this.lblLinearMpX.Location = new Point(885, 194);
    this.lblLinearMpX.Margin = new Padding(4, 0, 4, 0);
    this.lblLinearMpX.Name = "lblLinearMpX";
    this.lblLinearMpX.Size = new Size(86, 20);
    this.lblLinearMpX.TabIndex = 63 /*0x3F*/;
    this.lblLinearMpX.Text = "Multiplier X";
    this.lblLinearMpY.AutoSize = true;
    this.lblLinearMpY.Font = new Font("Segoe UI", 11.25f);
    this.lblLinearMpY.ForeColor = Color.White;
    this.lblLinearMpY.Location = new Point(886, 233);
    this.lblLinearMpY.Margin = new Padding(4, 0, 4, 0);
    this.lblLinearMpY.Name = "lblLinearMpY";
    this.lblLinearMpY.Size = new Size(85, 20);
    this.lblLinearMpY.TabIndex = 63 /*0x3F*/;
    this.lblLinearMpY.Text = "Multiplier Y";
    this.tbLinearMpY.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbLinearMpY.BorderStyle = BorderStyle.None;
    this.tbLinearMpY.Font = new Font("Segoe UI", 11.25f);
    this.tbLinearMpY.ForeColor = Color.White;
    this.tbLinearMpY.Location = new Point(987, 232);
    this.tbLinearMpY.Name = "tbLinearMpY";
    this.tbLinearMpY.Size = new Size(58, 20);
    this.tbLinearMpY.TabIndex = 76;
    this.tbLinearMpX.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbLinearMpX.BorderStyle = BorderStyle.None;
    this.tbLinearMpX.Font = new Font("Segoe UI", 11.25f);
    this.tbLinearMpX.ForeColor = Color.White;
    this.tbLinearMpX.Location = new Point(987, 194);
    this.tbLinearMpX.Name = "tbLinearMpX";
    this.tbLinearMpX.Size = new Size(58, 20);
    this.tbLinearMpX.TabIndex = 77;
    this.tbStoneThickness.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbStoneThickness.BorderStyle = BorderStyle.None;
    this.tbStoneThickness.Font = new Font("Segoe UI", 11.25f);
    this.tbStoneThickness.ForeColor = Color.White;
    this.tbStoneThickness.Location = new Point(987, 151);
    this.tbStoneThickness.Name = "tbStoneThickness";
    this.tbStoneThickness.Size = new Size(58, 20);
    this.tbStoneThickness.TabIndex = 78;
    this.label5.AutoSize = true;
    this.label5.Font = new Font("Segoe UI", 11.25f);
    this.label5.ForeColor = Color.White;
    this.label5.Location = new Point(899, 289);
    this.label5.Margin = new Padding(4, 0, 4, 0);
    this.label5.Name = "label5";
    this.label5.Size = new Size(167, 20);
    this.label5.TabIndex = 63 /*0x3F*/;
    this.label5.Text = "Calculation Center Point";
    this.label6.AutoSize = true;
    this.label6.Font = new Font("Segoe UI", 11.25f);
    this.label6.ForeColor = Color.White;
    this.label6.Location = new Point(819, 333);
    this.label6.Margin = new Padding(4, 0, 4, 0);
    this.label6.Name = "label6";
    this.label6.Size = new Size(65, 20);
    this.label6.TabIndex = 63 /*0x3F*/;
    this.label6.Text = "Center X";
    this.tbOffsetCenterX.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbOffsetCenterX.BorderStyle = BorderStyle.None;
    this.tbOffsetCenterX.Font = new Font("Segoe UI", 11.25f);
    this.tbOffsetCenterX.ForeColor = Color.White;
    this.tbOffsetCenterX.Location = new Point(899, 333);
    this.tbOffsetCenterX.Name = "tbOffsetCenterX";
    this.tbOffsetCenterX.Size = new Size(58, 20);
    this.tbOffsetCenterX.TabIndex = 76;
    this.label7.AutoSize = true;
    this.label7.Font = new Font("Segoe UI", 11.25f);
    this.label7.ForeColor = Color.White;
    this.label7.Location = new Point(987, 333);
    this.label7.Margin = new Padding(4, 0, 4, 0);
    this.label7.Name = "label7";
    this.label7.Size = new Size(64 /*0x40*/, 20);
    this.label7.TabIndex = 63 /*0x3F*/;
    this.label7.Text = "Center Y";
    this.tbOffsetCenterY.BackColor = Color.FromArgb(80 /*0x50*/, 80 /*0x50*/, 80 /*0x50*/);
    this.tbOffsetCenterY.BorderStyle = BorderStyle.None;
    this.tbOffsetCenterY.Font = new Font("Segoe UI", 11.25f);
    this.tbOffsetCenterY.ForeColor = Color.White;
    this.tbOffsetCenterY.Location = new Point(1058, 333);
    this.tbOffsetCenterY.Name = "tbOffsetCenterY";
    this.tbOffsetCenterY.Size = new Size(58, 20);
    this.tbOffsetCenterY.TabIndex = 76;
    this.AutoScaleDimensions = new SizeF(7f, 15f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.FromArgb(50, 50, 50);
    this.ClientSize = new Size(1161, 903);
    this.Controls.Add((Control) this.tbOffsetCenterY);
    this.Controls.Add((Control) this.tbOffsetCenterX);
    this.Controls.Add((Control) this.tbLinearMpY);
    this.Controls.Add((Control) this.tbLinearMpX);
    this.Controls.Add((Control) this.tbStoneThickness);
    this.Controls.Add((Control) this.btnMinimize);
    this.Controls.Add((Control) this.btnExtend);
    this.Controls.Add((Control) this.btnClose);
    this.Controls.Add((Control) this.btnCancel);
    this.Controls.Add((Control) this.btnApplySettings);
    this.Controls.Add((Control) this.lblDelayTime);
    this.Controls.Add((Control) this.lblBR);
    this.Controls.Add((Control) this.lblBL);
    this.Controls.Add((Control) this.label7);
    this.Controls.Add((Control) this.lblTR);
    this.Controls.Add((Control) this.label6);
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.lblLinearMpY);
    this.Controls.Add((Control) this.lblLinearMpX);
    this.Controls.Add((Control) this.lblThickness);
    this.Controls.Add((Control) this.lblOffsetTop);
    this.Controls.Add((Control) this.numUDOffsetBottom);
    this.Controls.Add((Control) this.numUDOffsetRight);
    this.Controls.Add((Control) this.numUDOffsetLeft);
    this.Controls.Add((Control) this.numUDOffsetTop);
    this.Controls.Add((Control) this.cboxRotFirst);
    this.Controls.Add((Control) this.label4);
    this.Controls.Add((Control) this.lblK2);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.lblK1);
    this.Controls.Add((Control) this.label2);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.lblRotation);
    this.Controls.Add((Control) this.numUDDistY);
    this.Controls.Add((Control) this.numUDDistX);
    this.Controls.Add((Control) this.numUDDistStrK2);
    this.Controls.Add((Control) this.numUDDistStrK1);
    this.Controls.Add((Control) this.numUDDelay);
    this.Controls.Add((Control) this.numUDRotation);
    this.Controls.Add((Control) this.lblMarkerSize);
    this.Controls.Add((Control) this.lblHeight);
    this.Controls.Add((Control) this.lblWidth);
    this.Controls.Add((Control) this.panel1);
    this.Controls.Add((Control) this.numUDMarkerSize);
    this.Controls.Add((Control) this.numUDHeight);
    this.Controls.Add((Control) this.numUDWidth);
    this.Controls.Add((Control) this.cbAddOffset);
    this.Controls.Add((Control) this.cbAutoCalcOffset);
    this.Controls.Add((Control) this.cboxAutoStretch);
    this.Controls.Add((Control) this.cboxAutoMirrorVertical);
    this.Controls.Add((Control) this.cboxAutoRotateRight);
    this.Controls.Add((Control) this.cbAutoContour);
    this.Controls.Add((Control) this.cboxAutoRotation);
    this.Controls.Add((Control) this.cboxAutoTopView);
    this.Controls.Add((Control) this.cboxAutoMirrorHorizontal);
    this.Controls.Add((Control) this.cboxAutoRotateLeft);
    this.Controls.Add((Control) this.cboxAutoLens);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Margin = new Padding(4, 3, 4, 3);
    this.Name = nameof (DigitizeSettings);
    this.Text = nameof (DigitizeSettings);
    this.FormClosing += new FormClosingEventHandler(this.DigitizeSettings_FormClosing);
    this.Load += new EventHandler(this.DigitizeSettings_Load);
    ((ISupportInitialize) this.numUDOffsetBottom).EndInit();
    ((ISupportInitialize) this.numUDOffsetRight).EndInit();
    ((ISupportInitialize) this.numUDOffsetLeft).EndInit();
    ((ISupportInitialize) this.numUDOffsetTop).EndInit();
    ((ISupportInitialize) this.numUDDistY).EndInit();
    ((ISupportInitialize) this.numUDDistX).EndInit();
    ((ISupportInitialize) this.numUDDistStrK2).EndInit();
    ((ISupportInitialize) this.numUDDistStrK1).EndInit();
    ((ISupportInitialize) this.numUDDelay).EndInit();
    ((ISupportInitialize) this.numUDRotation).EndInit();
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    ((ISupportInitialize) this.numUDMarkerSize).EndInit();
    ((ISupportInitialize) this.numUDHeight).EndInit();
    ((ISupportInitialize) this.numUDWidth).EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
