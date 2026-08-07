// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Settings.F_AbsoluteHome
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Settings;

public class F_AbsoluteHome : Form
{
  public List<string> Captions = new List<string>();
  public int DecimalPoint = 2;
  public double IncrementStep = 0.1;
  public AxesEnableWithUVW parAbsoluteHomeAxisEnable = new AxesEnableWithUVW();
  public string[] parAxisString = new string[9]
  {
    "X",
    "Y",
    "Z",
    "A",
    "B",
    "C",
    "U",
    "V",
    "W"
  };
  public int[] parAxisIndex = new int[9]
  {
    0,
    1,
    2,
    3,
    4,
    4,
    -1,
    -1,
    -1
  };
  public bool FormTopMost = false;
  public bool ReadOnly = false;
  public bool ScreenCenter = true;
  private buSpin Offset = new buSpin();
  private buButton buButton_0 = new buButton();
  private IContainer icontainer_0 = (IContainer) null;
  internal buPanel buPanel_0;
  internal buGround buGround_0;
  internal buButton buButton_1;

  public F_AbsoluteHome() => Class39.smethod_641(this);

  public event AbsoluteHomeSetEventHandle AbsoluteHomeSet;

  public void Init()
  {
    try
    {
      this.TopMost = this.FormTopMost;
      int num1 = 0;
      if (this.parAbsoluteHomeAxisEnable.X)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.Y)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.Z)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.A)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.B)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.C)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.U)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.V)
        ++num1;
      if (this.parAbsoluteHomeAxisEnable.W)
        ++num1;
      if (num1 <= 0)
      {
        int num2 = (int) MessageBox.Show("No Home Value");
      }
      else
      {
        int height = Convert.ToInt32(Convert.ToDouble(this.buPanel_0.Height) / Convert.ToDouble(num1)) - 5;
        int num3 = 0;
        int num4 = 3;
        this.buPanel_0.Controls.Clear();
        for (int index = 0; index <= this.parAxisString.Length - 1; ++index)
        {
          bool flag = false;
          if (index <= this.parAxisString.Length - 1)
          {
            this.Offset = new buSpin();
            this.Offset.Name = "Offset";
            this.Offset.Font = new Font("Times New Roman", (float) height / 2f, FontStyle.Bold);
            this.Offset.Size = new Size(Convert.ToInt32((double) this.buPanel_0.Width * 0.6), height);
            this.Offset.Tag = (object) this.parAxisIndex[index];
            this.Offset.MinValue = -999999999999.0;
            this.Offset.MaxValue = 999999999999.0;
            this.Offset.DecimalPoint = this.DecimalPoint;
            this.Offset.IncrementStep = this.IncrementStep;
            this.Offset.Caption.Visible = true;
            this.Offset.Caption.Width = 50;
            this.Offset.Caption.Caption = this.parAxisString[index];
            this.Offset.Location = new Point(2, num4 + num3 * (height + 2));
            this.Offset.Enter += new EventHandler(this.Offset_Enter);
            this.buButton_0 = new buButton();
            this.buButton_0.Font = new Font("Times New Roman", (float) height / 3f, FontStyle.Bold);
            this.buButton_0.Size = new Size(this.buPanel_0.Width - this.Offset.Width - 8, height);
            this.buButton_0.Text = "Set " + this.parAxisString[index];
            this.buButton_0.Click += new EventHandler(this.buButton_0_Click);
            this.buButton_0.Tag = (object) this.parAxisIndex[index];
            this.buButton_0.Location = new Point(this.Offset.Left + this.Offset.Width + 4, num4 + num3 * (height + 2));
            if (index == 0 & this.parAbsoluteHomeAxisEnable.X)
              flag = true;
            if (index == 1 & this.parAbsoluteHomeAxisEnable.Y)
              flag = true;
            if (index == 2 & this.parAbsoluteHomeAxisEnable.Z)
              flag = true;
            if (index == 3 & this.parAbsoluteHomeAxisEnable.A)
              flag = true;
            if (index == 4 & this.parAbsoluteHomeAxisEnable.B)
              flag = true;
            if (index == 5 & this.parAbsoluteHomeAxisEnable.C)
              flag = true;
            if (index == 6 & this.parAbsoluteHomeAxisEnable.U)
              flag = true;
            if (index == 7 & this.parAbsoluteHomeAxisEnable.V)
              flag = true;
            if (index == 8 & this.parAbsoluteHomeAxisEnable.W)
              flag = true;
            if (flag)
            {
              this.buPanel_0.Controls.Add((Control) this.Offset);
              this.buPanel_0.Controls.Add((Control) this.buButton_0);
              ++num3;
            }
          }
        }
        this.LoadLanguage();
        if (!this.ScreenCenter)
          return;
        this.StartPosition = FormStartPosition.CenterScreen;
      }
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (this.Captions.Count < 7)
        return;
      this.Text = this.Captions[0];
      this.buButton_1.Text = this.Captions[6];
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  private void buButton_0_Click(object sender, EventArgs e)
  {
    try
    {
      if (!(sender.GetType() == typeof (buButton)))
        return;
      buButton buButton1 = new buButton();
      buButton buButton2 = (buButton) sender;
      for (int index = 0; index <= this.buPanel_0.Controls.Count - 1; ++index)
      {
        if (this.buPanel_0.Controls[index].GetType() == typeof (buSpin))
        {
          buSpin buSpin = new buSpin();
          buSpin control = (buSpin) this.buPanel_0.Controls[index];
          // ISSUE: reference to a compiler-generated field
          if (control.Name == "Offset" && int.Parse(control.Tag.ToString()) == int.Parse(buButton2.Tag.ToString()) && this.absoluteHomeSetEventHandle_0 != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.absoluteHomeSetEventHandle_0(int.Parse(control.Tag.ToString()), ((buSpin) this.buPanel_0.Controls[index]).Value);
          }
        }
      }
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_0(object sender, EventArgs e) => this.Visible = false;

  private void Offset_Enter(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      buSpin buSpin = new buSpin();
      buControlCommands.ShowKeyPad((Form) this, (Control) sender);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
