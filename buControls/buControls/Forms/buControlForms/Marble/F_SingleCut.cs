// Decompiled with JetBrains decompiler
// Type: buControls.Forms.buControlForms.Marble.F_SingleCut
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
  public buSpin spn_length;
  public buSpin spn_depth;
  public CheckBox chk_surface;
  internal buButton buButton_8;

  public F_SingleCut()
  {
    Class39.smethod_550(this);
    this.spn_depth.Click += new EventHandler(this.spn_length_Click);
    this.spn_length.Click += new EventHandler(this.spn_length_Click);
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
      this.spn_depth.Value = this.varOperations.TargetZ;
      this.spn_length.Value = this.varOperations.CutLength;
      this.spn_x.Value = this.varOperations.AxisValues.X;
      this.spn_y.Value = this.varOperations.AxisValues.Y;
      this.spn_z.Value = this.varOperations.AxisValues.Z;
      this.spn_a.Value = this.varOperations.AxisValues.A;
      this.spn_c.Value = this.varOperations.AxisValues.C;
      this.chk_surface.Checked = this.varOperations.ApplySurfaceReadData;
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
      if (F_SingleCut.Captions.Count <= 8)
        return;
      this.buGround_0.Text = F_SingleCut.Captions[0];
      this.buButton_6.Text = F_SingleCut.Captions[1];
      this.buButton_5.Text = F_SingleCut.Captions[2];
      this.spn_length.Caption.Caption = F_SingleCut.Captions[3];
      this.buLabel_0.Text = F_SingleCut.Captions[4];
      this.buButton_7.Text = F_SingleCut.Captions[5];
      this.buButton_3.Text = F_SingleCut.Captions[6];
      this.buButton_4.Text = F_SingleCut.Captions[7];
      this.buButton_0.Text = F_SingleCut.Captions[8];
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
    if (control2.Name == this.buButton_8.Name)
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
    if (control2.Name == this.buButton_3.Name)
    {
      if (this.varOperations.TargetZ >= this.varOperations.MaterialThickness)
      {
        buString.MessageBoxWarning(buMarbleCalc.LangMarbleMessage[3]);
        return;
      }
      Class39.smethod_825(this);
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
    this.spn_length.Value = buControlCoreClass.cVector.Length3D(this.pnt6D_0, this.pnt6D_1);
    // ISSUE: reference to a compiler-generated field
    if (this.marbleSetStartPositionHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.marbleSetStartPositionHandler_1(this.pnt6D_1);
  }

  internal void method_3(object sender, KeyEventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(control2.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.buGround_0.Controls, result, e.Shift);
  }

  private void spn_length_Click(object sender, EventArgs e)
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
