// Decompiled with JetBrains decompiler
// Type: buControls.ColorPicker.buColorPicker
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using ns7;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.ColorPicker;

public class buColorPicker : UserControl
{
  private Color color_0 = Color.Black;
  private buAdobeColors.HSL hsl_0;
  private Color color_1;
  private buAdobeColors.CMYK cmyk_0;
  private IContainer icontainer_0 = (IContainer) null;
  internal buColorVerticalSlider buColorVerticalSlider_0;
  internal buColorBox buColorBox_0;
  internal Label label_0;
  internal Label label_1;
  internal Label label_2;
  internal Label label_3;
  internal Label label_4;
  internal RadioButton radioButton_0;
  internal RadioButton radioButton_1;
  internal RadioButton radioButton_2;
  internal TextBox textBox_0;
  internal TextBox textBox_1;
  internal TextBox textBox_2;
  internal TextBox textBox_3;
  internal TextBox textBox_4;
  internal TextBox textBox_5;
  internal TextBox textBox_6;
  internal TextBox textBox_7;
  internal buColorComboBox buColorComboBox_0;
  internal TabControl tabControl_0;
  internal TabPage tabPage_0;
  internal TabPage tabPage_1;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal PictureBox pictureBox_2;
  internal PictureBox pictureBox_3;
  internal PictureBox pictureBox_4;
  internal PictureBox pictureBox_5;
  internal PictureBox pictureBox_6;
  internal PictureBox pictureBox_7;
  internal PictureBox pictureBox_8;
  internal PictureBox pictureBox_9;
  internal PictureBox pictureBox_10;
  internal PictureBox pictureBox_11;
  internal PictureBox pictureBox_12;
  internal PictureBox pictureBox_13;
  internal PictureBox pictureBox_14;
  internal PictureBox pictureBox_15;
  internal PictureBox pictureBox_16;
  internal PictureBox pictureBox_17;
  internal PictureBox pictureBox_18;
  internal PictureBox pictureBox_19;
  internal PictureBox pictureBox_20;
  internal PictureBox pictureBox_21;
  internal PictureBox pictureBox_22;
  internal PictureBox pictureBox_23;
  internal PictureBox pictureBox_24;
  internal PictureBox pictureBox_25;
  internal PictureBox pictureBox_26;
  internal PictureBox pictureBox_27;
  internal PictureBox pictureBox_28;
  internal PictureBox pictureBox_29;
  internal PictureBox pictureBox_30;
  internal PictureBox pictureBox_31;
  internal PictureBox pictureBox_32;
  internal PictureBox pictureBox_33;
  internal PictureBox pictureBox_34;
  internal PictureBox pictureBox_35;
  internal PictureBox pictureBox_36;
  internal PictureBox pictureBox_37;
  internal PictureBox pictureBox_38;
  internal PictureBox pictureBox_39;
  internal PictureBox pictureBox_40;
  internal PictureBox pictureBox_41;
  internal PictureBox pictureBox_42;
  internal PictureBox pictureBox_43;
  internal PictureBox pictureBox_44;
  internal PictureBox pictureBox_45;
  internal PictureBox pictureBox_46;
  internal PictureBox pictureBox_47;
  internal Label label_5;
  internal Label label_6;

  [Category("Appearance")]
  [DefaultValue(typeof (Color), "0, 0, 0")]
  public Color Color
  {
    get => this.color_0;
    set
    {
      this.color_0 = value;
      this.buColorComboBox_0.Color = this.color_0;
      this.method_13(this.color_0);
      this.label_5.BackColor = this.color_0;
      this.label_6.BackColor = this.color_0;
    }
  }

  public buColorPicker() => Class39.smethod_653(this);

  public event colorChangedEventHandler ColorChanged;

  internal void method_0(object sender, EventArgs e)
  {
    this.hsl_0 = this.buColorBox_0.HSL;
    this.color_1 = buAdobeColors.HSL_to_RGB(this.hsl_0);
    this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
    this.textBox_7.Text = this.color_1.R.ToString();
    this.textBox_6.Text = this.color_1.G.ToString();
    this.textBox_5.Text = this.color_1.B.ToString();
    this.textBox_4.Text = Class39.smethod_530(this.cmyk_0.C * 100.0, this).ToString();
    this.textBox_3.Text = Class39.smethod_530(this.cmyk_0.M * 100.0, this).ToString();
    this.textBox_2.Text = Class39.smethod_530(this.cmyk_0.Y * 100.0, this).ToString();
    this.textBox_1.Text = Class39.smethod_530(this.cmyk_0.K * 100.0, this).ToString();
    this.textBox_7.Update();
    this.textBox_6.Update();
    this.textBox_5.Update();
    this.textBox_4.Update();
    this.textBox_3.Update();
    this.textBox_2.Update();
    this.textBox_1.Update();
    this.buColorVerticalSlider_0.HSL = this.hsl_0;
    this.label_5.BackColor = this.color_1;
    this.label_5.Update();
    Class39.smethod_576(this, this.color_1);
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.colorChangedEventHandler_0((object) this, this.color_1);
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.hsl_0 = this.buColorVerticalSlider_0.HSL;
    this.color_1 = buAdobeColors.HSL_to_RGB(this.hsl_0);
    this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
    this.textBox_7.Text = this.color_1.R.ToString();
    this.textBox_6.Text = this.color_1.G.ToString();
    this.textBox_5.Text = this.color_1.B.ToString();
    this.textBox_4.Text = Class39.smethod_530(this.cmyk_0.C * 100.0, this).ToString();
    this.textBox_3.Text = Class39.smethod_530(this.cmyk_0.M * 100.0, this).ToString();
    this.textBox_2.Text = Class39.smethod_530(this.cmyk_0.Y * 100.0, this).ToString();
    this.textBox_1.Text = Class39.smethod_530(this.cmyk_0.K * 100.0, this).ToString();
    this.textBox_7.Update();
    this.textBox_6.Update();
    this.textBox_5.Update();
    this.textBox_4.Update();
    this.textBox_3.Update();
    this.textBox_2.Update();
    this.textBox_1.Update();
    this.buColorBox_0.HSL = this.hsl_0;
    this.label_5.BackColor = this.color_1;
    this.label_5.Update();
    Class39.smethod_576(this, this.color_1);
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.colorChangedEventHandler_0((object) this, this.color_1);
  }

  internal void method_2(object sender, EventArgs e)
  {
    if (!this.radioButton_2.Checked)
      return;
    this.buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Red;
    this.buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Red;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.radioButton_1.Checked)
      return;
    this.buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Green;
    this.buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Green;
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.radioButton_0.Checked)
      return;
    this.buColorVerticalSlider_0.DrawStyle = buColorVerticalSlider.eDrawStyle.Blue;
    this.buColorBox_0.DrawStyle = buColorBox.eDrawStyle.Blue;
  }

  internal void method_5(object sender, EventArgs e)
  {
    string text = this.textBox_7.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Red must be a number value between 0 and 255");
      this.method_14();
    }
    else
    {
      int red = int.Parse(text);
      if (red < 0)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.color_1 = Color.FromArgb(0, (int) this.color_1.G, (int) this.color_1.B);
      }
      else if (red > (int) byte.MaxValue)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.color_1 = Color.FromArgb((int) byte.MaxValue, (int) this.color_1.G, (int) this.color_1.B);
      }
      else
        this.color_1 = Color.FromArgb(red, (int) this.color_1.G, (int) this.color_1.B);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_6(object sender, EventArgs e)
  {
    string text = this.textBox_6.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Green must be a number value between 0 and 255");
      this.method_14();
    }
    else
    {
      int green = int.Parse(text);
      if (green < 0)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.textBox_6.Text = "0";
        this.color_1 = Color.FromArgb((int) this.color_1.R, 0, (int) this.color_1.B);
      }
      else if (green > (int) byte.MaxValue)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.textBox_6.Text = "255";
        this.color_1 = Color.FromArgb((int) this.color_1.R, (int) byte.MaxValue, (int) this.color_1.B);
      }
      else
        this.color_1 = Color.FromArgb((int) this.color_1.R, green, (int) this.color_1.B);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_7(object sender, EventArgs e)
  {
    string text = this.textBox_5.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Blue must be a number value between 0 and 255");
      this.method_14();
    }
    else
    {
      int blue = int.Parse(text);
      if (blue < 0)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.textBox_5.Text = "0";
        this.color_1 = Color.FromArgb((int) this.color_1.R, (int) this.color_1.G, 0);
      }
      else if (blue > (int) byte.MaxValue)
      {
        int num = (int) MessageBox.Show("An integer between 0 and 255 is required.\nClosest value inserted.");
        this.textBox_5.Text = "255";
        this.color_1 = Color.FromArgb((int) this.color_1.R, (int) this.color_1.G, (int) byte.MaxValue);
      }
      else
        this.color_1 = Color.FromArgb((int) this.color_1.R, (int) this.color_1.G, blue);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_8(object sender, EventArgs e)
  {
    string upper = this.textBox_0.Text.ToUpper();
    bool flag = false;
    if (upper.Length <= 0)
      flag = true;
    foreach (char c in upper)
    {
      if (!char.IsNumber(c) && (c < 'A' ? 0 : (c <= 'F' ? 1 : 0)) == 0)
      {
        flag = true;
        break;
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Hex must be a hex value between 0x000000 and 0xFFFFFF");
      Class39.smethod_576(this, this.color_1);
    }
    else
    {
      this.color_1 = Class39.smethod_561(this, upper);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_9(object sender, EventArgs e)
  {
    string text = this.textBox_4.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Cyan must be a number value between 0 and 100");
      this.method_14();
    }
    else
    {
      int num1 = int.Parse(text);
      if (num1 < 0)
      {
        int num2 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.cmyk_0.C = 0.0;
      }
      else if (num1 > 100)
      {
        int num3 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.cmyk_0.C = 1.0;
      }
      else
        this.cmyk_0.C = (double) num1 / 100.0;
      this.color_1 = buAdobeColors.CMYK_to_RGB(this.cmyk_0);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_10(object sender, EventArgs e)
  {
    string text = this.textBox_3.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Magenta must be a number value between 0 and 100");
      this.method_14();
    }
    else
    {
      int num1 = int.Parse(text);
      if (num1 < 0)
      {
        int num2 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_3.Text = "0";
        this.cmyk_0.M = 0.0;
      }
      else if (num1 > 100)
      {
        int num3 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_3.Text = "100";
        this.cmyk_0.M = 1.0;
      }
      else
        this.cmyk_0.M = (double) num1 / 100.0;
      this.color_1 = buAdobeColors.CMYK_to_RGB(this.cmyk_0);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_11(object sender, EventArgs e)
  {
    string text = this.textBox_2.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Yellow must be a number value between 0 and 100");
      this.method_14();
    }
    else
    {
      int num1 = int.Parse(text);
      if (num1 < 0)
      {
        int num2 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_2.Text = "0";
        this.cmyk_0.Y = 0.0;
      }
      else if (num1 > 100)
      {
        int num3 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_2.Text = "100";
        this.cmyk_0.Y = 1.0;
      }
      else
        this.cmyk_0.Y = (double) num1 / 100.0;
      this.color_1 = buAdobeColors.CMYK_to_RGB(this.cmyk_0);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  internal void method_12(object sender, EventArgs e)
  {
    string text = this.textBox_1.Text;
    bool flag = false;
    if (text.Length <= 0)
    {
      flag = true;
    }
    else
    {
      foreach (char c in text)
      {
        if (!char.IsNumber(c))
        {
          flag = true;
          break;
        }
      }
    }
    if (flag)
    {
      int num = (int) MessageBox.Show("Key must be a number value between 0 and 100");
      this.method_14();
    }
    else
    {
      int num1 = int.Parse(text);
      if (num1 < 0)
      {
        int num2 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_1.Text = "0";
        this.cmyk_0.K = 0.0;
      }
      else if (num1 > 100)
      {
        int num3 = (int) MessageBox.Show("An integer between 0 and 100 is required.\nClosest value inserted.");
        this.textBox_1.Text = "100";
        this.cmyk_0.K = 1.0;
      }
      else
        this.cmyk_0.K = (double) num1 / 100.0;
      this.color_1 = buAdobeColors.CMYK_to_RGB(this.cmyk_0);
      this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
      this.buColorBox_0.HSL = this.hsl_0;
      this.buColorVerticalSlider_0.HSL = this.hsl_0;
      this.label_5.BackColor = this.color_1;
      this.method_14();
    }
  }

  private void method_13(Color color_2)
  {
    this.color_1 = color_2;
    this.hsl_0 = buAdobeColors.RGB_to_HSL(this.color_1);
    this.buColorBox_0.HSL = this.hsl_0;
    this.buColorVerticalSlider_0.HSL = this.hsl_0;
    this.cmyk_0 = buAdobeColors.RGB_to_CMYK(this.color_1);
    this.textBox_7.Text = this.color_1.R.ToString();
    this.textBox_6.Text = this.color_1.G.ToString();
    this.textBox_5.Text = this.color_1.B.ToString();
    this.textBox_4.Text = Class39.smethod_530(this.cmyk_0.C * 100.0, this).ToString();
    this.textBox_3.Text = Class39.smethod_530(this.cmyk_0.M * 100.0, this).ToString();
    this.textBox_2.Text = Class39.smethod_530(this.cmyk_0.Y * 100.0, this).ToString();
    this.textBox_1.Text = Class39.smethod_530(this.cmyk_0.K * 100.0, this).ToString();
    this.textBox_7.Update();
    this.textBox_6.Update();
    this.textBox_5.Update();
    this.textBox_4.Update();
    this.textBox_3.Update();
    this.textBox_2.Update();
    this.textBox_1.Update();
  }

  private void method_14()
  {
    this.textBox_4.Text = Class39.smethod_530(this.cmyk_0.C * 100.0, this).ToString();
    this.textBox_3.Text = Class39.smethod_530(this.cmyk_0.M * 100.0, this).ToString();
    this.textBox_2.Text = Class39.smethod_530(this.cmyk_0.Y * 100.0, this).ToString();
    this.textBox_1.Text = Class39.smethod_530(this.cmyk_0.K * 100.0, this).ToString();
    this.textBox_7.Text = this.color_1.R.ToString();
    this.textBox_6.Text = this.color_1.G.ToString();
    this.textBox_5.Text = this.color_1.B.ToString();
    this.textBox_7.Update();
    this.textBox_6.Update();
    this.textBox_5.Update();
    this.textBox_4.Update();
    this.textBox_3.Update();
    this.textBox_2.Update();
    this.textBox_1.Update();
    Class39.smethod_576(this, this.color_1);
  }

  internal void method_15(object sender, EventArgs e)
  {
    this.pictureBox_47.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_46.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_45.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_44.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_43.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_42.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_28.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_29.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_30.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_31.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_32.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_41.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_33.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_34.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_21.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_22.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_23.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_40.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_24.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_25.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_26.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_27.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_14.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_39.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_38.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_15.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_37.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_36.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_35.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_16.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_17.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_18.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_19.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_20.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_7.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_8.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_9.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_10.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_11.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_12.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_13.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_0.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_1.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_2.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_3.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_4.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_5.BorderStyle = BorderStyle.FixedSingle;
    this.pictureBox_6.BorderStyle = BorderStyle.FixedSingle;
    PictureBox pictureBox1 = new PictureBox();
    PictureBox pictureBox2 = (PictureBox) sender;
    pictureBox2.BorderStyle = BorderStyle.Fixed3D;
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 == null)
      return;
    if (pictureBox2.BackColor.IsKnownColor)
      this.buColorComboBox_0.Color = pictureBox2.BackColor;
    this.label_6.BackColor = pictureBox2.BackColor;
    // ISSUE: reference to a compiler-generated field
    this.colorChangedEventHandler_0((object) this, pictureBox2.BackColor);
  }

  internal void method_16(object object_0, Color color_2)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 == null)
      return;
    this.label_6.BackColor = color_2;
    // ISSUE: reference to a compiler-generated field
    this.colorChangedEventHandler_0((object) this, color_2);
  }

  internal void method_17(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.colorChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.colorChangedEventHandler_0((object) this, this.label_5.BackColor);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
