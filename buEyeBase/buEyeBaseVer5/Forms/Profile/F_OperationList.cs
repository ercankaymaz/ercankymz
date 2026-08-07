// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.Profile.F_OperationList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.ClassViewer;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms.Profile;

public class F_OperationList : Form
{
  public double Increment;
  public string pathString;
  internal Design \u0001;
  private System.Windows.Forms.Timer \u0001;
  internal Point3D \u0001;
  internal Point3D \u0002;
  private IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ListBox \u0001;
  internal ImageList \u0002;
  internal Panel \u0001;
  internal Button \u0003;
  internal Button \u0004;
  internal Button \u0005;
  internal Label \u0001;
  internal Panel \u0002;
  internal Button \u0006;
  internal Button \u0007;
  internal Button \u0008;
  internal Button \u000E;
  internal Button \u000F;
  internal NumericUpDown \u0001;
  internal NumericUpDown \u0002;
  internal Label \u0002;
  internal NumericUpDown \u0003;
  internal Label \u0003;
  internal NumericUpDown \u0004;
  internal Label \u0004;
  internal Button \u0010;
  internal NumericUpDown \u0005;
  internal Label \u0005;
  internal NumericUpDown \u0006;
  internal Label \u0006;
  internal Button \u0011;
  internal ImageList \u0003;
  internal Button \u0012;
  internal Button \u0013;
  internal Button \u0014;
  internal Button \u0015;
  internal Button \u0016;
  internal Button \u0017;
  internal Button \u0018;
  internal Label \u0007;
  internal Label \u0008;
  internal Label \u000E;
  internal Label \u000F;
  internal Label \u0010;
  public static byte f0017A2;
  public FormCloseModeType FormCloseMode;
  public DialogResult Result;
  public ProfileNewType SelectedType;
  public LeftRightType XDirRefType;
  public bool RightProfile;
  public List<Entity> PreviewEnts;
  public string ItemName;
  public string ItemLength;
  public double ItemWidth;
  public double ItemHeight;
  public double ItemThickness;
  public double ItemRadius;
  public double ItemDiameter;
  public int StandartProfileIndex;
  public int MaxClamper;
  private Design \u0001;
  private System.Windows.Forms.Timer \u0001;
  private bool \u0001;
  internal IContainer \u0001;
  internal Button \u0001;
  internal Button \u0002;
  internal ImageList \u0001;
  internal ListBox \u0001;
  internal Label \u0001;

  static F_OperationList() => F_ProfileCopy.Captions = new List<string>();

  public F_OperationList()
  {
    ((F_ProfilePatternCopy) this).varProfileClamperSettings = (ProfileClamperSettings) new MarbleItemExtend();
    ((F_ProfilePatternCopy) this).Properties = new FormProperties();
    ((F_PlaneList) this).strPath = Application.StartupPath;
    ((F_PlaneList) this).\u0001 = 0;
    ((F_PlaneList) this).Clampers = new List<ProfileClamper>();
    ((F_PlaneList) this).Lengths = new List<ProfileLengthClamperCount>();
    ((F_PlaneList) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_Clampers) this);
  }

  public void Init()
  {
    ((F_ProfilePatternCopy) this).Properties.Inited = false;
    if (((F_ProfilePatternCopy) this).Properties.Height > 10)
      this.Height = ((F_ProfilePatternCopy) this).Properties.Height;
    if (((F_ProfilePatternCopy) this).Properties.Width > 10)
      this.Width = ((F_ProfilePatternCopy) this).Properties.Width;
    this.TopMost = ((F_ProfilePatternCopy) this).Properties.TopMost;
    this.StartPosition = ((F_ProfilePatternCopy) this).Properties.FormPosition;
    ArrayList arrayList = new ArrayList();
    ((F_SelectedPlanes) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_PlaneList) this).Clampers.Count - 1; ++index)
      ((F_SelectedPlanes) this).\u0001.Items.Add((object) $"{(index + 1).ToString()} - Min X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).MinPositionRange.ToString("f2")} - Max X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).MaxPositionRange.ToString("f2")} , W: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).Width.ToString("f1")}");
    this.Text = buLangTranslate.preDef.Clamp;
    ((F_PlaneList) this).\u0003.Text = buLangTranslate.preDef.Clamp;
    ((F_PlaneList) this).\u0002.Text = buLangTranslate.preDef.Max + " X";
    ((F_PlaneList) this).\u0001.Text = buLangTranslate.preDef.Min + " X";
    ((F_SelectedPlanes) this).btn_settings.Text = buLangTranslate.preDef.Settings;
    ((F_SelectedPlanes) this).btn_ok.Text = buLangTranslate.preDef.Ok;
    ((F_SelectedPlanes) this).btn_cancel.Text = buLangTranslate.preDef.Cancel;
    ((F_ProfilePatternCopy) this).Properties.Result = DialogResult.None;
    ((F_ProfilePatternCopy) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_ProfilePatternCopy) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_ProfilePatternCopy) this).Properties.Result = DialogResult.Cancel;
    if (((F_ProfilePatternCopy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_ProfilePatternCopy) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    try
    {
      System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
      System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
      if (control2.Name == ((F_SelectedPlanes) this).btn_ok.Name)
      {
        \u0007.\u0001.\u0001((F_Clampers) this);
        ((F_ProfilePatternCopy) this).Properties.Result = DialogResult.OK;
        if (((F_ProfilePatternCopy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ProfilePatternCopy) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_SelectedPlanes) this).btn_cancel.Name)
      {
        ((F_ProfilePatternCopy) this).Properties.Result = DialogResult.Cancel;
        if (((F_ProfilePatternCopy) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
          this.Dispose();
        if (((F_ProfilePatternCopy) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
          this.Visible = false;
      }
      if (control2.Name == ((F_SelectedPlanes) this).btn_settings.Name)
      {
        try
        {
          F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
          classViewerDialog.FormCaption = "Sheet";
          classViewerDialog.Value = (object) ((F_ProfilePatternCopy) this).varProfileClamperSettings;
          classViewerDialog.StartPosition = FormStartPosition.CenterParent;
          classViewerDialog.Width = 500;
          classViewerDialog.Height = 750;
          classViewerDialog.ValuePersentage = 35.0;
          classViewerDialog.Init();
          int num = (int) classViewerDialog.ShowDialog();
          if (classViewerDialog.Result == DialogResult.OK)
            ((F_ProfilePatternCopy) this).varProfileClamperSettings = (ProfileClamperSettings) new MarbleItemExtend((ProfileClamperSettings) classViewerDialog.Value);
        }
        catch (Exception ex)
        {
        }
      }
      if (control2.Name == ((F_SelectedPlanes) this).\u0005.Name)
      {
        ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).\u0001]).MaxPositionRange = (double) ((F_PlaneList) this).\u0002.Value;
        ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).\u0001]).MinPositionRange = (double) ((F_PlaneList) this).\u0001.Value;
        ArrayList arrayList = new ArrayList();
        ((F_SelectedPlanes) this).\u0001.Items.Clear();
        for (int index = 0; index <= ((F_PlaneList) this).Clampers.Count - 1; ++index)
          ((F_SelectedPlanes) this).\u0001.Items.Add((object) $"{(index + 1).ToString()} - Min X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).MinPositionRange.ToString("f2")} - Max X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).MaxPositionRange.ToString("f2")} , W: {((buMarbleCalc) ((F_PlaneList) this).Clampers[index]).Width.ToString("f1")}");
      }
      if (control2.Name == ((F_SelectedPlanes) this).\u0004.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_PlaneList) this).strPath;
        openFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        openFileDialog.FilterIndex = 1;
        openFileDialog.Multiselect = false;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ArrayList StringList = new ArrayList();
          buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
          try
          {
            ((F_PlaneList) this).strPath = buFile.GetPath(openFileDialog.FileName);
            ArrayList CalcList1 = new ArrayList();
            buString.ListToSpecificList("<ProfileSettings>", "</ProfileSettings>", true, StringList, ref CalcList1);
            if (CalcList1.Count > 0)
              buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) ((F_ProfilePatternCopy) this).varProfileClamperSettings);
            List<List<string>> CalcList2 = new List<List<string>>();
            buString.ListToSpecificList("<ProfileClamper>", "</ProfileClamper>", true, StringList, ref CalcList2);
            ((F_PlaneList) this).Clampers.Clear();
            for (int index = 0; index <= CalcList2.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList2[index].ToArray());
              ProfileClamper profileClamper = (ProfileClamper) new MarbleVacuumCut();
              buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) profileClamper);
              ((F_PlaneList) this).Clampers.Add(profileClamper);
            }
            List<List<string>> CalcList3 = new List<List<string>>();
            buImage5.ListToSpecificList("<ProfileLengthCountData>", "</ProfileLengthCountData>", true, StringList, ref CalcList3);
            ((F_PlaneList) this).Lengths.Clear();
            for (int index = 0; index <= CalcList3.Count - 1; ++index)
            {
              ArrayList AL = new ArrayList();
              AL.AddRange((ICollection) CalcList3[index].ToArray());
              ProfileLengthClamperCount lengthClamperCount = (ProfileLengthClamperCount) new MarbleItemExtend();
              buSerilization5.Decode(AL, "", (SerilizationMode5) 1, (object) lengthClamperCount);
              ((F_PlaneList) this).Lengths.Add(lengthClamperCount);
            }
            this.Init();
          }
          catch (Exception ex)
          {
            buLog.addLog("Profile Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
            buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Profile Settings Decoder Error");
          }
        }
      }
      if (control2.Name == ((F_SelectedPlanes) this).\u0003.Name)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_PlaneList) this).strPath;
        saveFileDialog.Filter = "buCad/Cam Profile Clamper File (*.buprofileclamper)|*.buprofileclamper";
        saveFileDialog.FilterIndex = 1;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_PlaneList) this).strPath = buFile.GetPath(saveFileDialog.FileName);
          ArrayList StringList = new ArrayList();
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Profile Settings");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "<ProfileSettings>");
          StringList.AddRange((ICollection) ((F_ProfilePatternCopy) this).varProfileClamperSettings.ToDefAll("", 2, (SerilizationMode5) 1));
          StringList.Add((object) "</ProfileSettings>");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   Clampers ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  <Clampers>");
          for (int index = 0; index <= ((F_PlaneList) this).Clampers.Count - 1; ++index)
            StringList.AddRange((ICollection) ((F_PlaneList) this).Clampers[index].ToDefAll("", 4, (SerilizationMode5) 1));
          StringList.Add((object) "  </Clampers>");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "   ProfileLengthCount ");
          StringList.Add((object) "------------------------------------------------------------------------");
          StringList.Add((object) "  <ProfileLengthCountData>");
          for (int index = 0; index <= ((F_PlaneList) this).Lengths.Count - 1; ++index)
            StringList.AddRange((ICollection) ((F_PlaneList) this).Lengths[index].ToDefAll("", 4, (SerilizationMode5) 1));
          StringList.Add((object) "  </ProfileLengthCountData>");
          buFile.SaveToFile(StringList, saveFileDialog.FileName);
        }
      }
      if (control2.Name == ((F_PlaneList) this).\u0001.Name)
      {
        ((F_PlaneList) this).Clampers.Add((ProfileClamper) new MarbleVacuumCut());
        ((F_SelectedPlanes) this).\u0001.Items.Add((object) $"{((F_PlaneList) this).Clampers.Count.ToString()} - Min X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).Clampers.Count - 1]).MinPositionRange.ToString("f2")} - Max X: {((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).Clampers.Count - 1]).MaxPositionRange.ToString("f2")} , W: {((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).Clampers.Count - 1]).Width.ToString("f1")}");
        ((F_SelectedPlanes) this).\u0001.SelectedIndex = ((F_PlaneList) this).Clampers.Count - 1;
      }
      if (!(control2.Name == ((F_PlaneList) this).\u0002.Name) || !(((F_PlaneList) this).\u0001 >= 0 & ((F_PlaneList) this).\u0001 <= ((F_PlaneList) this).Clampers.Count - 1) || buString.MessageBoxQuestion($"{buLangTranslate.preSentences.DoYouWantToDelete} {buLangTranslate.preDef.Clamp}") != DialogResult.Yes)
        return;
      ((F_PlaneList) this).Clampers.RemoveAt(((F_PlaneList) this).\u0001);
      ((F_SelectedPlanes) this).\u0001.Items.RemoveAt(((F_PlaneList) this).\u0001);
      ((F_PlaneList) this).\u0001 = ((F_PlaneList) this).\u0001 - 1;
      if (((F_PlaneList) this).\u0001 < 0)
        ((F_PlaneList) this).\u0001 = 0;
      if (((F_SelectedPlanes) this).\u0001.Items.Count <= 0)
        return;
      ((F_SelectedPlanes) this).\u0001.SelectedIndex = ((F_PlaneList) this).\u0001;
    }
    catch (Exception ex)
    {
    }
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (!((F_ProfilePatternCopy) this).Properties.Inited)
      return;
    if (control2.Name == ((F_PlaneList) this).\u0001.Name && ((F_PlaneList) this).\u0001 >= 0 & ((F_PlaneList) this).\u0001 <= ((F_PlaneList) this).Clampers.Count - 1)
      ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_SelectedPlanes) this).\u0001.SelectedIndex]).MinPositionRange = (double) ((F_PlaneList) this).\u0001.Value;
    if (!(control2.Name == ((F_PlaneList) this).\u0002.Name) || !(((F_PlaneList) this).\u0001 >= 0 & ((F_PlaneList) this).\u0001 <= ((F_PlaneList) this).Clampers.Count - 1))
      return;
    ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_SelectedPlanes) this).\u0001.SelectedIndex]).MaxPositionRange = (double) ((F_PlaneList) this).\u0002.Value;
  }

  internal void \u0003([In] object obj0, [In] EventArgs obj1)
  {
    if (!((F_ProfilePatternCopy) this).Properties.Inited || !(((F_SelectedPlanes) this).\u0001.SelectedIndex >= 0 & ((F_SelectedPlanes) this).\u0001.SelectedIndex <= ((F_PlaneList) this).Clampers.Count - 1))
      return;
    ((F_ProfilePatternCopy) this).Properties.Inited = false;
    ((F_PlaneList) this).\u0001 = ((F_SelectedPlanes) this).\u0001.SelectedIndex;
    ((F_PlaneList) this).\u0002.Value = (Decimal) ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_PlaneList) this).\u0001]).MaxPositionRange;
    ((F_PlaneList) this).\u0001.Value = (Decimal) ((buMarbleCalc) ((F_PlaneList) this).Clampers[((F_SelectedPlanes) this).\u0001.SelectedIndex]).MinPositionRange;
    ((F_ProfilePatternCopy) this).Properties.Inited = true;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_PlaneList) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_PlaneList) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_OperationList() => F_PlaneList.Captions = new List<string>();

  public F_OperationList()
  {
    ((F_SelectedPlanes) this).Properties = new FormProperties();
    ((F_SelectedPlanes) this).Plane = new WorkPlane();
    ((F_SelectedPlanes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PlaneSettings) this);
  }

  public void Init()
  {
    ((F_SelectedPlanes) this).Properties.Inited = false;
    if (((F_SelectedPlanes) this).Properties.Height > 10)
      this.Height = ((F_SelectedPlanes) this).Properties.Height;
    if (((F_SelectedPlanes) this).Properties.Width > 10)
      this.Width = ((F_SelectedPlanes) this).Properties.Width;
    if (!((F_SelectedPlanes) this).Plane.UseCenterPoint)
    {
      ((F_SelectedPlanes) this).\u0003.Value = (Decimal) ((F_SelectedPlanes) this).Plane.BasePoint.Y;
      ((F_SelectedPlanes) this).\u0004.Value = (Decimal) ((F_SelectedPlanes) this).Plane.BasePoint.Z;
    }
    else
    {
      ((F_SelectedPlanes) this).\u0003.Value = (Decimal) ((F_SelectedPlanes) this).Plane.MiddlePoint.Y;
      ((F_SelectedPlanes) this).\u0004.Value = (Decimal) ((F_SelectedPlanes) this).Plane.MiddlePoint.Z;
    }
    ((F_SelectedPlanes) this).\u0002.Value = (Decimal) ((F_SelectedPlanes) this).Plane.Angles.A;
    ((F_SelectedPlanes) this).\u0001.Value = (Decimal) ((F_SelectedPlanes) this).Plane.Lenght;
    ((F_SelectedPlanes) this).\u0001.Checked = ((F_SelectedPlanes) this).Plane.UseCenterPoint;
    ((F_SelectedPlanes) this).\u0002.Checked = ((F_SelectedPlanes) this).Plane.isCircular;
    ((F_SelectedPlanes) this).\u0005.Value = (Decimal) ((F_SelectedPlanes) this).Plane.CircularAngle;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.None;
    ((F_SelectedPlanes) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_SelectedPlanes) this).btn_ok.Name)
    {
      if (!((F_SelectedPlanes) this).Properties.Inited)
        return;
      if (((F_SelectedPlanes) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_PlaneSettings) this);
      ((F_SelectedPlanes) this).Properties.Result = DialogResult.OK;
      if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_SelectedPlanes) this).btn_cancel.Name))
      return;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.Cancel;
    if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SelectedPlanes) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SelectedPlanes) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.Cancel;
    if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SelectedPlanes) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SelectedPlanes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SelectedPlanes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  [CompilerGenerated]
  [SpecialName]
  public void add_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_SelectedPlanes) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_SelectedPlanes) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_DataChanged(OkCommandWithTwoDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithTwoDataEventHandler dataEventHandler = ((F_SelectedPlanes) this).\u0001;
    OkCommandWithTwoDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithTwoDataEventHandler>(ref ((F_SelectedPlanes) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_OperationList()
  {
    ((F_SelectedPlanes) this).Properties = new FormProperties();
    ((F_SelectedPlanes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_PlaneMoveRotate) this);
  }

  public void Init()
  {
    ((F_SelectedPlanes) this).Properties.Inited = false;
    if (((F_SelectedPlanes) this).Properties.Height > 10)
      this.Height = ((F_SelectedPlanes) this).Properties.Height;
    if (((F_SelectedPlanes) this).Properties.Width > 10)
      this.Width = ((F_SelectedPlanes) this).Properties.Width;
    this.TopMost = ((F_SelectedPlanes) this).Properties.TopMost;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.None;
    ((F_SelectedPlanes) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_SelectedPlanes) this).btn_ok.Name)
    {
      ((F_SelectedPlanes) this).Properties.Result = DialogResult.Cancel;
      if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (control2.Name == ((F_SelectedPlanes) this).\u0002.Name)
      ((F_SelectedPlanes) this).spn_value.Value = 0.1M;
    if (control2.Name == ((F_SelectedPlanes) this).\u0003.Name)
      ((F_SelectedPlanes) this).spn_value.Value = 1M;
    if (control2.Name == ((F_SelectedPlanes) this).\u0004.Name)
      ((F_SelectedPlanes) this).spn_value.Value = 5M;
    if (control2.Name == ((F_SelectedPlanes) this).\u0005.Name)
      ((F_SelectedPlanes) this).spn_value.Value = 10M;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_SelectedPlanes) this).btn_moveyplus.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) "movey", (object) (double) ((F_SelectedPlanes) this).spn_value.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_SelectedPlanes) this).btn_moveyminus.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) "movey", (object) -(double) ((F_SelectedPlanes) this).spn_value.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_SelectedPlanes) this).btn_movezplus.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) "movez", (object) (double) ((F_SelectedPlanes) this).spn_value.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_SelectedPlanes) this).btn_movezminus.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) "movez", (object) -(double) ((F_SelectedPlanes) this).spn_value.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_SelectedPlanes) this).btn_rotateminus.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) "rotate", (object) (double) ((F_SelectedPlanes) this).spn_value.Value);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((F_SelectedPlanes) this).btn_rotateplus.Name) || ((F_SelectedPlanes) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_SelectedPlanes) this).\u0001((object) "rotate", (object) -(double) ((F_SelectedPlanes) this).spn_value.Value);
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SelectedPlanes) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.Cancel;
    if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SelectedPlanes) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SelectedPlanes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SelectedPlanes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  public abstract void m000D6B();

  [CompilerGenerated]
  [SpecialName]
  public void add_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_SelectedPlanes) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_SelectedPlanes) this).\u0001, comparand + value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  [CompilerGenerated]
  [SpecialName]
  public void remove_CommandOk(OkCommandWithDataEventHandler value)
  {
    // ISSUE: reference to a compiler-generated field
    OkCommandWithDataEventHandler dataEventHandler = ((F_SelectedPlanes) this).\u0001;
    OkCommandWithDataEventHandler comparand;
    do
    {
      comparand = dataEventHandler;
      // ISSUE: reference to a compiler-generated field
      dataEventHandler = Interlocked.CompareExchange<OkCommandWithDataEventHandler>(ref ((F_SelectedPlanes) this).\u0001, comparand - value, comparand);
    }
    while (dataEventHandler != comparand);
  }

  public F_OperationList()
  {
    ((F_SelectedPlanes) this).Properties = new FormProperties();
    ((F_SelectedPlanes) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_ProfileFreeDrawCmd) this);
  }

  public void Init()
  {
    ((F_SelectedPlanes) this).Properties.FormCloseMode = FormCloseModeType.Invisible;
    ((F_SelectedPlanes) this).Properties.Inited = false;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.None;
    this.TopMost = ((F_SelectedPlanes) this).Properties.TopMost;
    this.StartPosition = ((F_SelectedPlanes) this).Properties.FormPosition;
    this.AutoScaleMode = ((F_SelectedPlanes) this).Properties.ScaleFromMode;
    if (((F_SelectedPlanes) this).Properties.Height > 10)
      this.Height = ((F_SelectedPlanes) this).Properties.Height;
    if (((F_SelectedPlanes) this).Properties.Width > 10)
      this.Width = ((F_SelectedPlanes) this).Properties.Width;
    ((F_SelectedPlanes) this).Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (((F_SelectedPlanes) this).Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    ((F_SelectedPlanes) this).Properties.Result = DialogResult.Cancel;
    if (((F_SelectedPlanes) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_SelectedPlanes) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    this.Visible = false;
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_NewProfile) this).\u0001.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) ProfileOperationTypes.FromFile);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_NewProfile) this).\u0003.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) ProfileOperationTypes.FreeDraw);
    }
    // ISSUE: reference to a compiler-generated field
    if (control2.Name == ((F_NewProfile) this).\u0002.Name && ((F_SelectedPlanes) this).\u0001 != null)
    {
      // ISSUE: reference to a compiler-generated field
      ((F_SelectedPlanes) this).\u0001((object) ProfileOperationTypes.FromFileList);
    }
    // ISSUE: reference to a compiler-generated field
    if (!(control2.Name == ((F_NewProfile) this).\u0004.Name) || ((F_SelectedPlanes) this).\u0001 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    ((F_SelectedPlanes) this).\u0001((object) ProfileOperationTypes.Library);
  }

  internal void \u0002([In] object obj0, [In] EventArgs obj1)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_SelectedPlanes) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_SelectedPlanes) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_OperationList() => F_SelectedPlanes.Captions = new List<string>();

  public event OkCommandWithThreeDataEventHandler DataOk;

  public event OkCommandWithTwoDataEventHandler CommandOk;

  public event CancelCommandEventHandler DataCancel;

  public event OkCommandWithTwoDataEventHandler PlaneEdit;
}
