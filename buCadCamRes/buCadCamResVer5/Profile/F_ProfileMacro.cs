// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Profile.F_ProfileMacro
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using ns8;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Profile;

public class F_ProfileMacro : Form
{
  public FormProperties PropertiesForm = new FormProperties();
  public Timer timInit = new Timer();
  public ProfileItem Item = new ProfileItem();
  public List<ProfileOperation> Operations = new List<ProfileOperation>();
  internal IContainer icontainer_0 = (IContainer) null;
  internal Button button_0;
  internal Button button_1;
  internal ImageList imageList_0;
  internal ImageList imageList_1;
  internal Button button_2;
  public Panel pnl_viewport;
  internal CheckedListBox checkedListBox_0;
  internal CheckBox checkBox_0;
  internal NumericUpDown numericUpDown_0;
  internal Label label_0;

  public F_ProfileMacro()
  {
    Class5.smethod_81(this);
    this.timInit.Tick += new EventHandler(this.Init_Tick);
  }

  public void Init()
  {
    this.PropertiesForm.Inited = false;
    this.TopMost = this.PropertiesForm.TopMost;
    this.StartPosition = this.PropertiesForm.FormPosition;
    this.timInit.Interval = 200;
    this.timInit.Enabled = true;
    this.checkedListBox_0.Items.Clear();
    this.PropertiesForm.Result = DialogResult.None;
    this.PropertiesForm.Inited = true;
  }

  internal void method_0(object sender, EventArgs e)
  {
  }

  public void Init_Tick(object sender, EventArgs e)
  {
    this.timInit.Enabled = false;
    clsInit.appProfile.DrawMacroEntities(this.Item);
  }

  internal void method_1(object sender, EventArgs e)
  {
    this.PropertiesForm.Inited = false;
    this.PropertiesForm.Inited = true;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.button_0.Name)
    {
      this.PropertiesForm.Result = DialogResult.OK;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == this.button_1.Name)
    {
      this.PropertiesForm.Result = DialogResult.Cancel;
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.button_2.Name))
      return;
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = AppPath.Macro;
    openFileDialog.Filter = "Profile Macro Files (*.buOPmacro)|*.buOPmacro";
    openFileDialog.FilterIndex = 1;
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    this.Operations.Clear();
    AppPath.Macro = buFile5.GetPath(openFileDialog.FileName);
    ArrayList StringList = new ArrayList();
    buFile5.OpenFromFile(openFileDialog.FileName, ref StringList);
    List<List<string>> CalcList1 = new List<List<string>>();
    buStatics.ListToSpecificList("<PrfOperation>", "</PrfOperation>", false, StringList, ref CalcList1);
    if (CalcList1.Count == 0)
      buStatics.ListToSpecificList("<Operations>", "</Operations>", false, StringList, ref CalcList1);
    for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
    {
      new ArrayList().AddRange((ICollection) CalcList1[index1].ToArray());
      ProfileOperation OP = new ProfileOperation();
      ProfileOperation.Decode(CalcList1[index1], ref OP);
      if (OP.MinPoint.X != OP.MaxPoint.X)
      {
        OP.OperationData.CamParNotch.Notch.NotchCutType = OP.CamOPData.NotchCutType;
        if (OP.OperationData.OperationType == ProfileOperationTypes.FreeDraw)
        {
          OP.EntityMultiContour = new List<buEntity>();
          List<string> CalcList2 = new List<string>();
          buStatics.ListToSpecificList("<ContourEntitites>", "</ContourEntitites>", false, CalcList1[index1], ref CalcList2);
          if (CalcList2.Count > 0)
          {
            List<List<string>> CalcList3 = new List<List<string>>();
            buStatics.ListToSpecificList("<buEntity>", "</buEntity>", false, CalcList2, ref CalcList3);
            for (int index2 = 0; index2 <= CalcList3.Count - 1; ++index2)
            {
              buEntity buEntity = buEntity.Decode(CalcList3[index2]);
              if (buEntity != null)
                OP.EntityMultiContour.Add(buEntity);
            }
          }
        }
        this.Operations.Add(OP);
      }
    }
    this.DrawOperations();
    clsInit.appProfile.viewportCommon.SetView(viewType.vcFrontFaceTopLeft);
    clsInit.appProfile.viewportCommon.ZoomFit(10);
    this.OperationTreeFill();
  }

  internal void method_3(object sender, FormClosingEventArgs e)
  {
    if (this.PropertiesForm.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.PropertiesForm.Result = DialogResult.Cancel;
    if (this.PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.PropertiesForm.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_4(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    this.DrawOperations();
  }

  public void OperationTreeFill()
  {
    this.checkedListBox_0.Items.Clear();
    for (int index = 0; index <= this.Item.Operations.Count - 1; ++index)
      this.checkedListBox_0.Items.Add((object) buProfileCalc.OperationItemString(this.Item.Operations[index]), true);
  }

  public void DrawOperations()
  {
    this.Item.Operations.Clear();
    SizeObject Size = new SizeObject(this.Item.Length, this.Item.Width, this.Item.Height);
    if (this.Operations.Count <= 0)
      return;
    double num = 0.0;
    if (this.checkBox_0.Checked)
    {
      num = 100000.0;
      for (int index = 0; index <= this.Operations.Count - 1; ++index)
      {
        if (this.Operations[index].OperationData.Position.X < num)
          num = this.Operations[index].OperationData.Position.X;
      }
    }
    SizeObject sizeObject = new SizeObject(this.Operations[0].ProfileLength, this.Operations[0].ProfileWidth, this.Operations[0].ProfileHeight);
    for (int index1 = 0; index1 <= this.Operations.Count - 1; ++index1)
    {
      ProfileOperation profileOperation = new ProfileOperation();
      ProfileOperation.Copy(this.Operations[index1], ref profileOperation);
      if (!this.checkBox_0.Checked)
      {
        if (profileOperation.OperationData.Corner == CornerLocation.LeftBottom | profileOperation.OperationData.Corner == CornerLocation.LeftCenter | profileOperation.OperationData.Corner == CornerLocation.LeftTop)
          profileOperation.OperationData.basePosition.X += (double) this.numericUpDown_0.Value;
        if (profileOperation.OperationData.Corner == CornerLocation.RightBottom | profileOperation.OperationData.Corner == CornerLocation.RightCenter | profileOperation.OperationData.Corner == CornerLocation.RightTop)
          profileOperation.OperationData.basePosition.X -= (double) this.numericUpDown_0.Value;
      }
      else
      {
        if (profileOperation.OperationData.Corner == CornerLocation.RightBottom)
        {
          profileOperation.OperationData.Corner = CornerLocation.LeftBottom;
          profileOperation.OperationData.basePosition.X = profileOperation.OperationData.Position.X;
        }
        if (profileOperation.OperationData.Corner == CornerLocation.RightCenter)
        {
          profileOperation.OperationData.Corner = CornerLocation.LeftCenter;
          profileOperation.OperationData.basePosition.X = profileOperation.OperationData.Position.X;
        }
        if (profileOperation.OperationData.Corner == CornerLocation.RightTop)
        {
          profileOperation.OperationData.Corner = CornerLocation.LeftTop;
          profileOperation.OperationData.basePosition.X = profileOperation.OperationData.Position.X;
        }
        if (profileOperation.OperationData.Corner == CornerLocation.BottomCenter)
        {
          profileOperation.OperationData.Corner = CornerLocation.LeftBottom;
          profileOperation.OperationData.basePosition.X = profileOperation.OperationData.Position.X;
        }
        if (profileOperation.OperationData.Corner == CornerLocation.TopCenter)
        {
          profileOperation.OperationData.Corner = CornerLocation.LeftTop;
          profileOperation.OperationData.basePosition.X = profileOperation.OperationData.Position.X;
        }
        profileOperation.OperationData.basePosition.X = profileOperation.OperationData.basePosition.X + (double) this.numericUpDown_0.Value - num;
      }
      profileOperation.OperationData.DepthForced = true;
      for (int index2 = 0; index2 <= profileOperation.OperationData.DepthValues.Count - 1; ++index2)
      {
        if (profileOperation.OperationData.selectedPlaneName == planeNames.Front)
        {
          profileOperation.OperationData.DepthValues[index2].TopPosition -= Size.Height - sizeObject.Height;
          profileOperation.OperationData.DepthValues[index2].BottomPosition -= Size.Height - sizeObject.Height;
        }
        if (profileOperation.OperationData.selectedPlaneName == planeNames.Top)
        {
          profileOperation.OperationData.DepthValues[index2].TopPosition += Size.Depth - sizeObject.Depth;
          profileOperation.OperationData.DepthValues[index2].BottomPosition += Size.Depth - sizeObject.Depth;
        }
      }
      buShape buShape = (buShape) new buShapeRectangle();
      buShape.BasePoint.X = profileOperation.OperationData.basePosition.X;
      buShape.BasePoint.Y = profileOperation.OperationData.basePosition.Y;
      buShape.BasePoint.Z = profileOperation.OperationData.basePosition.Z;
      clsInit.cVector5.CoordinateFromPlaneAndCorner(Size, profileOperation.OperationData.Corner, buConversion5.PlaneNamesToPlaneBoxNames(profileOperation.OperationData.selectedPlaneName), ref buShape, ref profileOperation.OperationData.Position, SingY: -1.0);
      if (profileOperation.OperationData.selectedPlaneName == planeNames.Front | profileOperation.OperationData.selectedPlaneName == planeNames.Back)
        profileOperation.OperationData.Position.Y = profileOperation.OperationData.Position.Z;
      if (this.Item.XReferanceLocation == LeftRightType.Right)
        buShape.CornerPoint.X = this.Item.Length;
      if (!clsInit.cVector5.FindToolWithToolName(ccVars.Tools, profileOperation.OperationData.ToolName, ref ccVars.toolActive))
        clsInit.cVector5.FindToolSmallMillingDiameter(ccVars.Tools, ref ccVars.toolActive);
      clsInit.appProfile.doCreateOperation(profileOperation.Action, ccVars.toolActive, false, false, ref profileOperation);
      this.Item.Operations.Add(profileOperation);
    }
    clsInit.appProfile.DrawMacroEntities(this.Item);
  }

  internal void method_5(object sender, EventArgs e)
  {
    if (!(this.checkedListBox_0.SelectedIndex >= 0 & this.checkedListBox_0.SelectedIndex <= this.Item.Operations.Count - 1))
      return;
    if (this.checkedListBox_0.GetItemCheckState(this.checkedListBox_0.SelectedIndex) == CheckState.Checked)
      this.Item.Operations[this.checkedListBox_0.SelectedIndex].Enable = true;
    else
      this.Item.Operations[this.checkedListBox_0.SelectedIndex].Enable = false;
    clsInit.appProfile.DrawMacroEntities(this.Item);
  }

  internal void method_6(object sender, EventArgs e)
  {
    if (!this.PropertiesForm.Inited)
      return;
    this.DrawOperations();
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
