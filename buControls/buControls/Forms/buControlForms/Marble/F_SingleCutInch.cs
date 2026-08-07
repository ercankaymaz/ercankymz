// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Marble.F_SingleCutInch
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.Controls;
using buCore;
using buCore.AppCalc;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buControls.Forms.buControlForms.Marble;

public class F_SingleCutInch : Form
{
  public static List<string> Captions = new List<string>();
  public marbleSingleCut varSingleCut = new marbleSingleCut();
  public marbleOperation varOperations = new marbleOperation();
  public MaterialBase activeMaterial = new MaterialBase();
  public DialogResult Result = DialogResult.No;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Invisible;
  internal bool bool_0 = false;
  private bool bool_1 = false;
  private Pnt6D pnt6D_0 = new Pnt6D();
  private Pnt6D pnt6D_1 = new Pnt6D();
  private IContainer icontainer_0 = (IContainer) null;
  internal buGround buGround_0;
  internal buButton buButton_0;
  internal buButton buButton_1;
  internal buButton buButton_2;
  internal PictureBox pictureBox_0;
  internal buLabel buLabel_0;
  internal buButton buButton_3;
  internal buButton buButton_4;
  internal buButton buButton_5;
  internal buButton buButton_6;
  internal buSeparator buSeparator_0;
  internal buSeparator buSeparator_1;
  public buSpin spn_c;
  public buSpin spn_a;
  public buSpin spn_z;
  public buSpin spn_y;
  public buSpin spn_x;
  internal buButton buButton_7;
  internal TextBox textBox_0;
  internal TextBox textBox_1;

  public F_SingleCutInch()
  {
    Class39.smethod_55(this);
    this.textBox_1.Click += new EventHandler(this.textBox_0_Click);
    this.textBox_0.Click += new EventHandler(this.textBox_0_Click);
  }

  public event MarbleSetStartPositionHandler SetStartPosition;

  public event MarbleSetStartPositionHandler SetEndPosition;

  public event EventHandler ShowJogPage;

  public void Init()
  {
    try
    {
      this.bool_0 = false;
      this.bool_1 = false;
      this.buButton_6.Display.BackColor = Color.Red;
      this.buButton_5.Display.BackColor = Color.Red;
      this.textBox_1.Text = buString.InchValueToString(this.varOperations.TargetZ, 16 /*0x10*/);
      this.textBox_0.Text = buString.InchValueToString(this.varOperations.CutLength, 16 /*0x10*/);
      this.spn_x.Value = this.varOperations.AxisValues.X;
      this.spn_y.Value = this.varOperations.AxisValues.Y;
      this.spn_z.Value = this.varOperations.AxisValues.Z;
      this.spn_a.Value = this.varOperations.AxisValues.A;
      this.spn_c.Value = this.varOperations.AxisValues.C;
      this.LoadLanguage();
      this.bool_0 = true;
    }
    catch (Exception ex)
    {
      string str = "F_MultiCut";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void LoadLanguage()
  {
    try
    {
      if (F_SingleCutInch.Captions.Count <= 8)
        return;
      this.buGround_0.Text = F_SingleCutInch.Captions[0];
      this.buButton_6.Text = F_SingleCutInch.Captions[1];
      this.buButton_5.Text = F_SingleCutInch.Captions[2];
      this.buLabel_0.Text = F_SingleCutInch.Captions[4];
      this.buButton_7.Text = F_SingleCutInch.Captions[5];
      this.buButton_3.Text = F_SingleCutInch.Captions[6];
      this.buButton_4.Text = F_SingleCutInch.Captions[7];
      this.buButton_0.Text = F_SingleCutInch.Captions[8];
    }
    catch (Exception ex)
    {
    }
  }

  internal void method_0(object sender, FormClosingEventArgs e)
  {
    if (this.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    if (this.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buButton_2.Name | control2.Name == this.buButton_4.Name)
    {
      this.Result = DialogResult.Cancel;
      this.bool_1 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.buButton_1.Name))
      return;
    this.Result = DialogResult.Cancel;
    this.WindowState = FormWindowState.Minimized;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.buButton_0.Name)
    {
      F_ItemCutCamParameters cutCamParameters = new F_ItemCutCamParameters();
      cutCamParameters.Value = new marbleOperation(this.varOperations);
      cutCamParameters.Init();
      cutCamParameters.StartPosition = FormStartPosition.CenterParent;
      int num = (int) cutCamParameters.ShowDialog((IWin32Window) this);
      if (cutCamParameters.Result == DialogResult.OK)
        this.varOperations = new marbleOperation(cutCamParameters.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == this.buButton_7.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.buButton_3.Name)
    {
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      Class39.smethod_803(this);
      Pnt3D EndPnt = new Pnt3D();
      if (this.bool_1)
      {
        this.varOperations.AxisValues.X = this.pnt6D_0.X;
        this.varOperations.AxisValues.Y = this.pnt6D_0.Y;
      }
      buControlCoreClass.cVector.LineWithLengthAndAngle(new Pnt3D(this.varOperations.AxisValues.X, this.varOperations.AxisValues.Y, this.varOperations.AxisValues.Z), this.varOperations.CutLength, this.varOperations.AxisValues.C, new WorkPlane(), ref EndPnt);
      this.Result = DialogResult.OK;
      this.bool_1 = false;
      if (this.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.buButton_6.Name)
    {
      this.buButton_6.Display.BackColor = Color.Green;
      this.bool_1 = true;
      this.pnt6D_0 = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.pnt6D_0);
      }
    }
    if (!(control2.Name == this.buButton_5.Name) || !this.bool_1)
      return;
    this.buButton_5.Display.BackColor = Color.Green;
    this.pnt6D_1 = new Pnt6D(this.spn_x.Value, this.spn_y.Value, this.spn_z.Value, this.spn_a.Value, 0.0, this.spn_c.Value);
    this.textBox_0.Text = buString.InchValueToString(buControlCoreClass.cVector.Length3D(this.pnt6D_0, this.pnt6D_1), 16 /*0x10*/);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_1(this.pnt6D_1);
  }

  private void textBox_0_Click(object sender, EventArgs e)
  {
    try
    {
      if (!AppBool.TouchPad)
        return;
      if (sender.GetType() == typeof (buSpin))
      {
        buSpin buSpin = new buSpin();
        buControlCommands.ShowKeyPad((Form) this, (Control) sender);
      }
      if (!(sender.GetType() == typeof (TextBox)))
        return;
      TextBox textBox = new TextBox();
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
