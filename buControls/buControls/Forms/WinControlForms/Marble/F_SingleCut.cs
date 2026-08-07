// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Marble.F_SingleCut
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buClass.Apps;
using buControls.Controls;
using buControls.Forms.buControlForms.Marble;
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
namespace buControls.Forms.WinControlForms.Marble;

public class F_SingleCut : Form
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
  internal IContainer icontainer_0 = (IContainer) null;
  internal Panel panel_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;
  internal NumericUpDown numericUpDown_1;
  internal Label label_1;
  internal NumericUpDown numericUpDown_2;
  internal Label label_2;
  internal NumericUpDown numericUpDown_3;
  internal Label label_3;
  internal NumericUpDown numericUpDown_4;
  internal Label label_4;
  internal PictureBox pictureBox_0;
  internal PictureBox pictureBox_1;
  internal ImageList imageList_0;
  internal Label label_5;
  internal NumericUpDown numericUpDown_5;
  internal Button button_0;
  internal Button button_1;
  internal Button button_2;
  internal CheckBox checkBox_0;
  internal Panel panel_1;
  internal Button button_3;
  internal Button button_4;
  internal Button button_5;
  internal Button button_6;
  internal Label label_6;
  internal NumericUpDown numericUpDown_6;
  internal Button button_7;
  internal Panel panel_2;

  public F_SingleCut() => Class39.smethod_205(this);

  public event MarbleSetStartPositionHandler SetStartPosition;

  public event MarbleSetStartPositionHandler SetEndPosition;

  public event EventHandler ShowJogPage;

  public void Init()
  {
    try
    {
      this.bool_0 = false;
      this.bool_1 = false;
      this.button_7.BackColor = Color.Red;
      this.button_6.BackColor = Color.Red;
      this.numericUpDown_5.Value = (Decimal) this.varOperations.TargetZ;
      this.numericUpDown_6.Value = (Decimal) this.varOperations.CutLength;
      this.numericUpDown_4.Value = (Decimal) this.varOperations.AxisValues.X;
      this.numericUpDown_3.Value = (Decimal) this.varOperations.AxisValues.Y;
      this.numericUpDown_2.Value = (Decimal) this.varOperations.AxisValues.Z;
      this.numericUpDown_1.Value = (Decimal) this.varOperations.AxisValues.A;
      this.numericUpDown_0.Value = (Decimal) this.varOperations.AxisValues.C;
      this.checkBox_0.Checked = this.varOperations.ApplySurfaceReadData;
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
      if (F_SingleCut.Captions.Count <= 12)
        return;
      this.Text = F_SingleCut.Captions[0];
      this.button_7.Text = F_SingleCut.Captions[1];
      this.button_6.Text = F_SingleCut.Captions[2];
      this.label_6.Text = F_SingleCut.Captions[12];
      this.label_5.Text = F_SingleCut.Captions[11];
      this.button_4.Text = F_SingleCut.Captions[5];
      this.button_5.Text = F_SingleCut.Captions[6];
      this.button_0.Text = F_SingleCut.Captions[7];
      this.button_2.Text = F_SingleCut.Captions[8];
      this.button_3.Text = F_SingleCut.Captions[10];
      this.checkBox_0.Text = F_SingleCut.Captions[10];
      this.button_1.Text = F_SingleCut.Captions[9];
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
    if (control2.Name == this.button_2.Name)
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
    if (control2.Name == this.button_4.Name && this.eventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.eventHandler_0(sender, e);
    }
    if (control2.Name == this.button_3.Name)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.InitialDirectory = Application.StartupPath;
      openFileDialog.Filter = "Surface Data File (*.csv)|*.csv";
      openFileDialog.FilterIndex = 1;
      openFileDialog.Multiselect = false;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        List<Pnt3D> pntTeachList = new List<Pnt3D>();
        buFile.OpenSurfaceReadFile(openFileDialog.FileName, ref pntTeachList);
        if (pntTeachList.Count > 2)
        {
          buCamCalc.pntTeachGrids.Clear();
          buControlCoreClass.cVector.CreateSurfaceGridFromTeachFile(new SurfaceReadGridData()
          {
            GridDistance = new Pnt3D(1.0, 1.0)
          }, pntTeachList, ref buCamCalc.pntTeachGrids);
        }
      }
    }
    if (control2.Name == this.button_5.Name)
    {
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      Class39.smethod_741(this);
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
    if (control2.Name == this.button_7.Name)
    {
      this.button_7.BackColor = Color.Green;
      this.bool_1 = true;
      this.pnt6D_0 = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
      // ISSUE: reference to a compiler-generated field
      if (this.marbleSetStartPositionHandler_0 != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.marbleSetStartPositionHandler_0(this.pnt6D_0);
      }
    }
    if (!(control2.Name == this.button_6.Name) || !this.bool_1)
      return;
    this.button_6.BackColor = Color.Green;
    this.pnt6D_1 = new Pnt6D((double) this.numericUpDown_4.Value, (double) this.numericUpDown_3.Value, (double) this.numericUpDown_2.Value, (double) this.numericUpDown_1.Value, 0.0, (double) this.numericUpDown_0.Value);
    this.numericUpDown_6.Value = (Decimal) buControlCoreClass.cVector.Length3D(this.pnt6D_0, this.pnt6D_1);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_1(this.pnt6D_1);
  }

  internal void method_2(object sender, EventArgs e)
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
