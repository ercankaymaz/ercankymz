// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.G54.F_G54
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
namespace buControls.Forms.buControlForms.G54;

public class F_G54 : Form
{
  public List<string> Captions = new List<string>();
  public List<Pnt9D> parG54List = new List<Pnt9D>();
  public List<Pnt9D> parG54SetValue = new List<Pnt9D>();
  public int parG54Index = 0;
  public int DecimalPoint = 2;
  public double IncrementStep = 0.1;
  public bool DisableSetAllButton = false;
  public AxesEnableWithUVW parG54OffsetAxisEnable = new AxesEnableWithUVW();
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
  public bool FormTopMost = false;
  public bool ReadOnly = false;
  public bool ScreenCenter = true;
  private buSpin Offset = new buSpin();
  private buSpin buSpin_0 = new buSpin();
  private buButton buButton_0 = new buButton();
  private buButton buButton_1 = new buButton();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_2;
  internal buButton buButton_3;
  internal buPanel buPanel_0;
  internal buButton buButton_4;
  internal buSpin buSpin_1;

  public F_G54() => Class39.smethod_338(this);

  public event G54GetPosEventHandler G54GetPos;

  public event G54ChangedEventHandler G54Changed;

  public event G54GetAllPosEventHandler G54GetPosAll;

  public event PageClosedEventHandler G54PageClosed;

  public void Init()
  {
    try
    {
      this.TopMost = this.FormTopMost;
      int num1 = 0;
      if (this.parG54List.Count == 0)
      {
        this.parG54SetValue.Clear();
        this.parG54List.Add(new Pnt9D());
        this.parG54List.Add(new Pnt9D());
        this.parG54List.Add(new Pnt9D());
        this.parG54SetValue.Add(new Pnt9D());
        this.parG54SetValue.Add(new Pnt9D());
        this.parG54SetValue.Add(new Pnt9D());
      }
      this.buButton_3.Enabled = !this.DisableSetAllButton;
      if (this.parG54OffsetAxisEnable.X)
        ++num1;
      if (this.parG54OffsetAxisEnable.Y)
        ++num1;
      if (this.parG54OffsetAxisEnable.Z)
        ++num1;
      if (this.parG54OffsetAxisEnable.A)
        ++num1;
      if (this.parG54OffsetAxisEnable.B)
        ++num1;
      if (this.parG54OffsetAxisEnable.C)
        ++num1;
      if (this.parG54OffsetAxisEnable.U)
        ++num1;
      if (this.parG54OffsetAxisEnable.V)
        ++num1;
      if (this.parG54OffsetAxisEnable.W)
        ++num1;
      if (num1 <= 0)
      {
        int num2 = (int) MessageBox.Show("No Offset Value");
      }
      else
      {
        int height = Convert.ToInt32(Convert.ToDouble(this.buPanel_0.Height) / Convert.ToDouble(num1)) - 5;
        int num3 = 0;
        int num4 = 3;
        this.buPanel_0.Controls.Clear();
        for (int index = 0; index <= num1 - 1; ++index)
        {
          bool flag = false;
          if (index <= this.parAxisString.Length - 1)
          {
            this.Offset = new buSpin();
            this.Offset.Name = "Offset";
            this.Offset.Font = new Font("Times New Roman", (float) height / 2f, FontStyle.Bold);
            this.Offset.Size = new Size(Convert.ToInt32((double) this.buPanel_0.Width * 0.6), height);
            this.Offset.Tag = (object) index;
            this.Offset.MinValue = -999999999999.0;
            this.Offset.MaxValue = 999999999999.0;
            this.Offset.DecimalPoint = this.DecimalPoint;
            this.Offset.IncrementStep = this.IncrementStep;
            this.Offset.Caption.Visible = true;
            this.Offset.Caption.Width = 50;
            this.Offset.Caption.Caption = this.parAxisString[index];
            this.Offset.Location = new Point(2, num4 + num3 * (height + 2));
            this.Offset.CaptionClicked += new EventHandler(this.Offset_CaptionClicked);
            this.Offset.Enter += new EventHandler(this.Offset_Enter);
            this.buButton_0 = new buButton();
            this.buButton_0.Font = new Font("Times New Roman", (float) height / 3f, FontStyle.Bold);
            this.buButton_0.Size = new Size(this.buPanel_0.Width - this.Offset.Width - 8, height);
            this.buButton_0.Text = "Set " + this.parAxisString[index];
            this.buButton_0.Click += new EventHandler(this.buButton_0_Click);
            this.buButton_0.Tag = (object) index;
            this.buButton_0.Location = new Point(this.Offset.Left + this.Offset.Width + 4, num4 + num3 * (height + 2));
            if (index == 0 & this.parG54OffsetAxisEnable.X)
              flag = true;
            if (index == 1 & this.parG54OffsetAxisEnable.Y)
              flag = true;
            if (index == 2 & this.parG54OffsetAxisEnable.Z)
              flag = true;
            if (index == 3 & this.parG54OffsetAxisEnable.A)
              flag = true;
            if (index == 4 & this.parG54OffsetAxisEnable.B)
              flag = true;
            if (index == 5 & this.parG54OffsetAxisEnable.C)
              flag = true;
            if (index == 6 & this.parG54OffsetAxisEnable.U)
              flag = true;
            if (index == 7 & this.parG54OffsetAxisEnable.V)
              flag = true;
            if (index == 8 & this.parG54OffsetAxisEnable.W)
              flag = true;
            if (flag)
            {
              this.buPanel_0.Controls.Add((Control) this.Offset);
              this.buPanel_0.Controls.Add((Control) this.buButton_0);
              ++num3;
            }
          }
        }
        this.buSpin_1.MinValue = 0.0;
        this.buSpin_1.MaxValue = (double) (this.parG54List.Count - 1);
        this.method_0(this.parG54Index);
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
      this.buButton_2.Text = this.Captions[6];
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  public void UpdateOffsetValues(int AxisIndex, double Value)
  {
    try
    {
      Pnt9D Pnt = new Pnt9D(this.parG54List[this.parG54Index]);
      for (int index = 0; index <= this.buPanel_0.Controls.Count - 1; ++index)
      {
        if (this.buPanel_0.Controls[index].GetType() == typeof (buSpin))
        {
          buSpin buSpin = new buSpin();
          buSpin control = (buSpin) this.buPanel_0.Controls[index];
          if (control.Name == "Offset" && int.Parse(control.Tag.ToString()) == AxisIndex)
          {
            ((buSpin) this.buPanel_0.Controls[index]).Value = Value;
            if (AxisIndex == 0)
              Pnt.X = Value;
            if (AxisIndex == 1)
              Pnt.Y = Value;
            if (AxisIndex == 2)
              Pnt.Z = Value;
            if (AxisIndex == 3)
              Pnt.A = Value;
            if (AxisIndex == 4)
              Pnt.B = Value;
            if (AxisIndex == 5)
              Pnt.C = Value;
            if (AxisIndex == 6)
              Pnt.U = Value;
            if (AxisIndex == 7)
              Pnt.V = Value;
            if (AxisIndex == 8)
              Pnt.W = Value;
            this.parG54List[this.parG54Index] = new Pnt9D(Pnt);
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.g54ChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.g54ChangedEventHandler_0(this.parG54List, this.parG54SetValue);
    }
    catch (Exception ex)
    {
      string message = $"AxisIndex: {AxisIndex.ToString()} - Value: {Value.ToString()}";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), false);
    }
  }

  private void method_0(int int_0)
  {
    try
    {
      for (int index = 0; index <= this.buPanel_0.Controls.Count - 1; ++index)
      {
        if (this.buPanel_0.Controls[index].GetType() == typeof (buSpin))
        {
          buSpin buSpin = new buSpin();
          buSpin control = (buSpin) this.buPanel_0.Controls[index];
          if (control.Name == "Offset")
          {
            if (int.Parse(control.Tag.ToString()) == 0)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].X;
            if (int.Parse(control.Tag.ToString()) == 1)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].Y;
            if (int.Parse(control.Tag.ToString()) == 2)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].Z;
            if (int.Parse(control.Tag.ToString()) == 3)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].A;
            if (int.Parse(control.Tag.ToString()) == 4)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].B;
            if (int.Parse(control.Tag.ToString()) == 5)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].C;
            if (int.Parse(control.Tag.ToString()) == 6)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].U;
            if (int.Parse(control.Tag.ToString()) == 7)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].V;
            if (int.Parse(control.Tag.ToString()) == 8)
              ((buSpin) this.buPanel_0.Controls[index]).Value = this.parG54List[int_0].W;
          }
        }
      }
    }
    catch (Exception ex)
    {
      string message = "G54Index: " + int_0.ToString();
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
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
      if (!(this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1))
        return;
      Pnt9D Pnt = new Pnt9D(this.parG54List[this.parG54Index]);
      for (int index = 0; index <= this.buPanel_0.Controls.Count - 1; ++index)
      {
        if (this.buPanel_0.Controls[index].GetType() == typeof (buSpin))
        {
          buSpin buSpin = new buSpin();
          buSpin control = (buSpin) this.buPanel_0.Controls[index];
          if (control.Name == "Offset" && int.Parse(control.Tag.ToString()) == int.Parse(buButton2.Tag.ToString()))
          {
            if (int.Parse(control.Tag.ToString()) == 0)
              Pnt.X = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 1)
              Pnt.Y = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 2)
              Pnt.Z = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 3)
              Pnt.A = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 4)
              Pnt.B = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 5)
              Pnt.C = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 6)
              Pnt.U = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 7)
              Pnt.V = ((buSpin) this.buPanel_0.Controls[index]).Value;
            if (int.Parse(control.Tag.ToString()) == 8)
              Pnt.W = ((buSpin) this.buPanel_0.Controls[index]).Value;
          }
        }
      }
      this.parG54List[this.parG54Index] = new Pnt9D(Pnt);
      // ISSUE: reference to a compiler-generated field
      if (this.g54ChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.g54ChangedEventHandler_0(this.parG54List, this.parG54SetValue);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_1(object sender, EventArgs e)
  {
    try
    {
      Control control1 = new Control();
      if (!(((Control) sender).Name == this.buButton_3.Name))
        return;
      if (this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1)
      {
        Pnt9D Pnt = new Pnt9D(this.parG54List[this.parG54Index]);
        for (int index = 0; index <= this.buPanel_0.Controls.Count - 1; ++index)
        {
          if (this.buPanel_0.Controls[index].GetType() == typeof (buSpin))
          {
            buSpin buSpin = new buSpin();
            buSpin control2 = (buSpin) this.buPanel_0.Controls[index];
            if (control2.Name == "Offset")
            {
              if (int.Parse(control2.Tag.ToString()) == 0)
                Pnt.X = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 1)
                Pnt.Y = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 2)
                Pnt.Z = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 3)
                Pnt.A = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 4)
                Pnt.B = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 5)
                Pnt.C = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 6)
                Pnt.U = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 7)
                Pnt.V = ((buSpin) this.buPanel_0.Controls[index]).Value;
              if (int.Parse(control2.Tag.ToString()) == 8)
                Pnt.W = ((buSpin) this.buPanel_0.Controls[index]).Value;
            }
          }
        }
        this.parG54List[this.parG54Index] = new Pnt9D(Pnt);
      }
      // ISSUE: reference to a compiler-generated field
      if (this.g54ChangedEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.g54ChangedEventHandler_0(this.parG54List, this.parG54SetValue);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  private void Offset_CaptionClicked(object sender, EventArgs e)
  {
    try
    {
      if (!(sender.GetType() == typeof (buSpin)))
        return;
      buSpin buSpin1 = new buSpin();
      buSpin buSpin2 = (buSpin) sender;
      if (!(this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1))
        return;
      int Axis = int.Parse(buSpin2.Tag.ToString());
      // ISSUE: reference to a compiler-generated field
      if (this.g54GetPosEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.g54GetPosEventHandler_0(Axis);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_2(object sender, EventArgs e)
  {
    try
    {
      // ISSUE: reference to a compiler-generated field
      if (this.g54GetAllPosEventHandler_0 == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.g54GetAllPosEventHandler_0();
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

  internal void method_3(object sender, EventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.pageClosedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.pageClosedEventHandler_0(new PageClosedEventArg());
    }
    this.Visible = false;
  }

  internal void method_4(object object_0, double double_0)
  {
    try
    {
      this.parG54Index = (int) this.buSpin_1.Value;
      if (!(this.parG54Index >= 0 & this.parG54Index <= this.parG54List.Count - 1))
        return;
      this.method_0(this.parG54Index);
    }
    catch (Exception ex)
    {
      string message = "";
      buException.throwException(new CalculationErrorEventArg(true, MethodBase.GetCurrentMethod().Name, message, "Exception", "", "", -1, ex), true);
    }
  }

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
