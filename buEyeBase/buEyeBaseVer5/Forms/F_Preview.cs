// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_Preview
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Events;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_Preview : Form
{
  internal Label \u0011;
  internal Label \u0012;
  internal Panel \u0004;
  internal NumericUpDown \u0004;
  internal Label \u0013;
  internal Panel \u0005;
  internal Label \u0014;
  internal TextBox \u0002;

  public void SheetPointsToImage(buNestingSheet Sheet, int Width, int Height, ref Image Img)
  {
    buViewer buViewer = new buViewer();
    buViewer.Width = Width;
    buViewer.Height = Height;
    for (int index = 0; index <= ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities.Count - 1; ++index)
    {
      eEntities buEntity = new eEntities();
      buString5.buEntityToEEntities(((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities[index], ((CustomDataSurrogate) ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Outside).Entities[index]).Color, ref buEntity);
      buViewer.Entities.Add(buEntity);
    }
    buViewer.DrawEntities();
    buViewer.ZoomFit();
    buViewer.ZoomOut();
    Img = (Image) buViewer.Bmp;
  }

  public void PartPointsToImage(buNestingPart Part, int Width, int Height, ref Image Img)
  {
    buViewer buViewer = new buViewer();
    buViewer.Width = Width;
    buViewer.Height = Height;
    List<eEntities> copiedEntity = new List<eEntities>();
    buString5.buEntityGroupToEEntities(((ProfileOperationRectangle) Part).EntitiesGroup, ref copiedEntity);
    buViewer.Entities.Clear();
    buViewer.Entities.AddRange((IEnumerable<eEntities>) copiedEntity);
    buViewer.DrawEntities();
    buViewer.ZoomFit();
    buViewer.ZoomOut();
    Img = (Image) buViewer.Bmp;
  }

  public void CreatPartAsRectanlge(
    double newWidth,
    double newHeight,
    buNestingPart OldPart,
    ref buNestingPart NewPart)
  {
    NewPart = (buNestingPart) new ProfileOperationBarrel(OldPart);
    ((ProfileOperationRectangle) NewPart).Type = nestMaterialType.Rectangle;
    ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Width = newWidth;
    ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Height = newHeight;
    ((GProfileOperation) buCall.\u0001).PartRectangle(((ProfileOperation) ((ProfileOperation) NewPart).PartData).Width, ((ProfileOperation) ((ProfileOperation) NewPart).PartData).Height, ref NewPart);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (((F_LaserMaterial) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_LaserMaterial) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_Preview()
  {
    F_LaserMaterial.Captions = new List<string>();
    F_LaserMaterial.CaptionGrid = new List<string>();
  }

  public F_Preview()
  {
    ((F_LaserMaterial) this).PropertiesForm = new FormProperties();
    ((F_LaserMaterial) this).SelectedIndex = -1;
    ((F_LaserMaterial) this).DiskIndex = -1;
    ((F_LaserMaterial) this).\u0001 = new Timer();
    ((F_LaserMaterial) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u0007.\u0001.\u0001((F_BendingRotaryDisk) this);
    ((F_LaserMaterial) this).\u0001.Tick += new EventHandler(((F_Layer) this).Tick_Timer);
    ((F_LaserMaterial) this).\u0001.Interval = 10;
  }

  public void Init()
  {
    string str = nameof (Init);
    try
    {
      ((F_LaserMaterial) this).PropertiesForm.Inited = false;
      ((F_LaserMaterial) this).PropertiesForm.sClassName = "F_BendingRotaryDisk";
      if (((F_LaserMaterial) this).PropertiesForm.Height > 10)
        this.Height = ((F_LaserMaterial) this).PropertiesForm.Height;
      if (((F_LaserMaterial) this).PropertiesForm.Width > 10)
        this.Width = ((F_LaserMaterial) this).PropertiesForm.Width;
      this.TopMost = ((F_LaserMaterial) this).PropertiesForm.TopMost;
      this.StartPosition = ((F_LaserMaterial) this).PropertiesForm.FormPosition;
      if (buEyeItems.viewportDialogs == null)
      {
        CreateModelProperties Properties = (CreateModelProperties) new ShapeEdit();
        ((ViewportDrawOptions) Properties).DisplayType = displayType.Rendered;
        ((MaterialBase5) Properties).ProjetionType = projectionType.Orthographic;
        ((MaterialBase5) Properties).CoordinateSystemIconVisible = false;
        ((MaterialBase5) Properties).OriginSymbolVisible = false;
        ((MaterialBase5) Properties).ViewCubeIconVisible = false;
        ((MaterialBase5) Properties).OrigineCaptionVisible = false;
        ((MaterialBase5) Properties).ToolBorVisible = false;
        ((ViewportDrawOptions) Properties).BottomColor = Color.LightGray;
        ((ViewportDrawOptions) Properties).MiddleColor = Color.WhiteSmoke;
        ((ViewportDrawOptions) Properties).TopColor = Color.LightGray;
        ((MaterialBase5) Properties).PanMouseButtons.Button = mouseButtonsZPR.Middle;
        ((MaterialBase5) Properties).PanMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.None;
        ((MaterialBase5) Properties).RotateMouseButtons.Button = mouseButtonsZPR.Middle;
        ((MaterialBase5) Properties).RotateMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl;
        ((MaterialBase5) Properties).ZoomMouseButtons.Button = mouseButtonsZPR.Middle;
        ((MaterialBase5) Properties).ZoomMouseButtons.ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift;
        buEyeItems.viewportDialogs = ((DrawingFinisedEvent) buCall.\u0001).CreateModelControl(Properties);
        buEyeItems.viewportDialogs.ActiveViewport.DisplayMode = displayType.Rendered;
      }
      buEyeItems.viewportDialogs.ActiveViewport.CoordinateSystemIcon.Visible = true;
      buEyeItems.viewportDialogs.ActiveViewport.OriginSymbol.Visible = true;
      if (FoamCalcVars.DiskBlocks.Count > 0)
        ((F_LaserMaterial) this).SelectedIndex = 0;
      ((F_NestExecute) this).treeView_bend = ((SewingJobItem) buCall.\u0001).UpdateItems(((F_NestExecute) this).treeView_bend);
      ((F_NestExecute) this).treeView_bend.CheckBoxes = false;
      ((F_NestExecute) this).treeView_bend.ExpandAll();
      ((F_Layer) this).ControlUpdate();
      ((F_Layer) this).LoadLanguage();
      ((F_LaserMaterial) this).PropertiesForm.Result = DialogResult.None;
      ((F_LaserMaterial) this).PropertiesForm.Inited = true;
      if (FoamCalcVars.DiskBlocks.Count <= 0)
        return;
      ((F_LaserMaterial) this).\u0001.Enabled = true;
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(((F_LaserMaterial) this).PropertiesForm.sClassName, str, ex.Message, "Exception");
      buException.throwException(ex, str, true, ((F_LaserMaterial) this).PropertiesForm.sClassName);
    }
  }
}
