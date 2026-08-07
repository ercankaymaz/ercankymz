// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_LayerRouter3X
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_LayerRouter3X : Form
{
  public Button btn_lefttop;
  public Button btn_aligment;
  internal CheckBox \u0001;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<Color> ColorList;
  private IContainer \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal Label \u0003;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal Label \u0007;
  internal Label \u0008;
  internal Label \u000E;
  internal Label \u000F;
  internal Label \u0010;
  internal Label \u0011;
  internal Label \u0012;

  public F_LayerRouter3X()
  {
    ((F_Scale) this).Properties = new FormProperties();
    ((F_Scale) this).Settings = (AnalyseEntitiesSetting) new PlaneAngle();
    ((F_Scale) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_AnalyseSettings) this);
  }

  public void Init()
  {
    ((F_Scale) this).Properties.Inited = false;
    if (((F_Scale) this).Properties.Height > 10)
      this.Height = ((F_Scale) this).Properties.Height;
    if (((F_Scale) this).Properties.Width > 10)
      this.Width = ((F_Scale) this).Properties.Width;
    this.TopMost = ((F_Scale) this).Properties.TopMost;
    this.StartPosition = ((F_Scale) this).Properties.FormPosition;
    ((F_Scale) this).spn_entminlen.Value = (Decimal) ((EntitiesCopySettings) ((F_Scale) this).Settings).EntityLengthLimit;
    ((F_Scale) this).spn_gapmaxlen.Value = (Decimal) ((EntitiesCopySettings) ((F_Scale) this).Settings).SmallGapMaxDistance;
    ((F_Scale) this).spn_gapminlen.Value = (Decimal) ((EntitiesCopySettings) ((F_Scale) this).Settings).SmallGapMinDistance;
    ((F_Copy) this).spn_intersectiongap.Value = (Decimal) ((EntitiesCopySettings) ((F_Scale) this).Settings).IntersectionGap;
    ((F_Scale) this).\u0001.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).FindProblems;
    ((F_Scale) this).\u0002.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).FixProblems;
    ((F_Scale) this).\u0004.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).isSameMoreThanOneCheck;
    ((F_Scale) this).\u0003.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).isSameMoreThanOneCheck;
    ((F_Scale) this).\u0005.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).isEntityLengthSmall;
    ((F_Scale) this).\u0006.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).isClosedEntities;
    ((F_Scale) this).\u0007.Checked = ((EntitiesCopySettings) ((F_Scale) this).Settings).IntersectionEntities;
    ((F_Scale) this).Properties.Result = DialogResult.None;
    ((F_Scale) this).Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_Scale.Captions.Count >= 1)
        ;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control1 = new System.Windows.Forms.Control();
    System.Windows.Forms.Control control2 = (System.Windows.Forms.Control) obj0;
    if (control2.Name == ((F_Scale) this).btn_ok.Name)
    {
      if (!((F_Scale) this).Properties.Inited)
        return;
      if (((F_Scale) this).Properties.ReadOnly)
      {
        this.Dispose();
        return;
      }
      \u0007.\u0001.\u0001((F_AnalyseSettings) this);
      ((F_Scale) this).Properties.Result = DialogResult.OK;
      if (((F_Scale) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (((F_Scale) this).Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == ((F_Scale) this).btn_cancel.Name))
      return;
    ((F_Scale) this).Properties.Result = DialogResult.Cancel;
    if (((F_Scale) this).Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (((F_Scale) this).Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_Scale) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_Scale) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_LayerRouter3X() => F_Scale.Captions = new List<string>();

  public F_LayerRouter3X()
  {
    ((F_Copy) this).PropertiesForm = new FormProperties();
    ((F_Copy) this).Entities = new List<Entity>();
    ((F_Copy) this).Layers = new LayerKeyedCollection();
    ((F_Copy) this).viewportPort = (Design) null;
    ((F_Copy) this).\u0001 = -1;
    ((F_Copy) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_EntitiesProps) this);
  }

  public void InitViewport()
  {
    if (((F_Copy) this).viewportPort != null)
      return;
    EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
    ((DiameterDepthPoint) Properties).ShowToolBar = false;
    ((DiameterDepthPoint) Properties).ShowViewCube = false;
    ((MaterialBase5) Properties).ShowCoordinateArrow = false;
    buConversion5.CreateControlsTool(true, Properties, ref ((F_Copy) this).viewportPort);
    ((F_Copy) this).viewportPort.Dock = DockStyle.Fill;
    ((F_Copy) this).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_Copy) this).viewportPort);
  }

  public void Init()
  {
    ((F_Copy) this).PropertiesForm.Inited = false;
    if (((F_Copy) this).viewportPort == null)
    {
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref ((F_Copy) this).viewportPort);
      ((F_Copy) this).viewportPort.Dock = DockStyle.Fill;
      ((F_Copy) this).viewportPort.Layers.Clear();
      ((F_Copy) this).viewportPort.Layers = ((F_Copy) this).Layers;
      ((F_Copy) this).\u0001.Controls.Add((System.Windows.Forms.Control) ((F_Copy) this).viewportPort);
    }
    if (((F_Copy) this).PropertiesForm.Height > 10)
      this.Height = ((F_Copy) this).PropertiesForm.Height;
    if (((F_Copy) this).PropertiesForm.Width > 10)
      this.Width = ((F_Copy) this).PropertiesForm.Width;
    this.TopMost = ((F_Copy) this).PropertiesForm.TopMost;
    this.StartPosition = ((F_Copy) this).PropertiesForm.FormPosition;
    ((F_Copy) this).DGV_entitiesprops.RowHeadersVisible = false;
    ((F_Copy) this).DGV_entitiesprops.ColumnHeadersVisible = false;
    ((F_Copy) this).DGV_entitiesprops.AllowUserToAddRows = false;
    ((F_Copy) this).DGV_entitiesprops.AllowUserToResizeColumns = false;
    ((F_Copy) this).DGV_entitiesprops.AllowUserToResizeRows = false;
    ((F_Copy) this).viewportPort.Entities.Clear();
    for (int index = 0; index <= ((F_Copy) this).Entities.Count - 1; ++index)
    {
      CustomData customData = (CustomData) null;
      if (((F_Copy) this).Entities[index].EntityData != null && ((F_Copy) this).Entities[index].EntityData is CustomData)
        customData = (CustomData) new ClipperOffset((CustomData) ((F_Copy) this).Entities[index].EntityData);
      string str = (index + 1).ToString() + " - ";
      if (customData != null && ((ClipperOffset) customData).get_EntityName().Length > 0)
        str = $"{str}{((ClipperOffset) customData).get_EntityName()} - ";
      ((F_Copy) this).Entities[index].GetType();
      ((F_Copy) this).\u0001.Items.Add((object) (str + ((F_Copy) this).Entities[index].GetType().Name));
      ((F_Copy) this).viewportPort.Entities.Add(buVector5.CopyEntities(((F_Copy) this).Entities[index]));
    }
    ((F_Copy) this).viewportPort.SetView(viewType.Top);
    ((F_Copy) this).viewportPort.ZoomFit();
    ((F_Copy) this).viewportPort.ZoomOut(10);
    ((F_Copy) this).viewportPort.Invalidate();
    ((F_Copy) this).PropertiesForm.Result = DialogResult.None;
    ((F_Copy) this).PropertiesForm.Inited = true;
  }
}
