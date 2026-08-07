// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_TuftingImageList
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buControls.Viewer;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using dummy_ptr;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_TuftingImageList : Form
{
  internal Label \u0003;
  internal TextBox \u0001;
  internal Label \u0004;
  internal Label \u0005;
  internal Label \u0006;
  internal CheckBox \u0002;
  internal Label \u0007;
  internal TextBox \u0002;
  public Button btn_cancel;
  public Button btn_ok;
  internal ComboBox \u0002;
  internal Label \u0008;
  internal Label \u000E;

  public void AddPartFromEntities(List<eEntities> Entities)
  {
  }

  public void AddPartFromCsvFile(nestCsvPartImportType Mode, string FileName)
  {
    if (Mode == nestCsvPartImportType.Mode1_ItemNo)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      List<string> StringList = new List<string>();
      if (fileInfo.Exists)
        buVector5.OpenFromFile(FileName, ref StringList);
    }
    if (Mode == nestCsvPartImportType.Mode2_NameWidthHeightCount)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      List<string> StringList = new List<string>();
      if (fileInfo.Exists)
        buVector5.OpenFromFile(FileName, ref StringList);
    }
    if (Mode != nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount)
      return;
    FileInfo fileInfo1 = new FileInfo(FileName);
    List<string> StringList1 = new List<string>();
    if (!fileInfo1.Exists)
      return;
    buVector5.OpenFromFile(FileName, ref StringList1);
  }

  public void GetInfo()
  {
    int num1 = 0;
    int num2 = 0;
    for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index)
    {
      if (((ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Enable)
        num2 += ((ProfileOperation) ((ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity - ((ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Nested;
      num1 += ((ProfileOperation) ((ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity - ((ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Nested;
    }
    ((F_ToolList) this).lst_info.Items.Clear();
    ((F_ToolList) this).lst_info.Items.Add((object) $"{buLangTranslate.preDef.Total} {buLangTranslate.preDef.Count} : {num1.ToString()}");
    ((F_ToolList) this).lst_info.Items.Add((object) $"{buLangTranslate.preDef.Selected} {buLangTranslate.preDef.Count} : {num2.ToString()}");
  }

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
    if (((ProfileItemCalc) Sheet).EntitiesGroup.Inside != null)
    {
      for (int index1 = 0; index1 <= ((ProfileItemCalc) Sheet).EntitiesGroup.Inside.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Inside[index1]).Entities.Count - 1; ++index2)
        {
          eEntities buEntity = new eEntities();
          buString5.buEntityToEEntities(((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Inside[index1]).Entities[index2], ((CustomDataSurrogate) ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.Inside[index1]).Entities[index2]).Color, ref buEntity);
          buViewer.Entities.Add(buEntity);
        }
      }
    }
    if (((ProfileItemCalc) Sheet).EntitiesGroup.OpenEntities != null)
    {
      for (int index3 = 0; index3 <= ((ProfileItemCalc) Sheet).EntitiesGroup.OpenEntities.Count - 1; ++index3)
      {
        for (int index4 = 0; index4 <= ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.OpenEntities[index3]).Entities.Count - 1; ++index4)
        {
          eEntities buEntity = new eEntities();
          buString5.buEntityToEEntities(((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.OpenEntities[index3]).Entities[index4], ((CustomDataSurrogate) ((\u0084.\u0001) ((ProfileItemCalc) Sheet).EntitiesGroup.OpenEntities[index3]).Entities[index4]).Color, ref buEntity);
          buViewer.Entities.Add(buEntity);
        }
      }
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
    buViewer.BackColor = ((ProfileOperationEllipse) ((ProfileSupportBlock) ((F_QuiltingSettings) this).Settings).PartSettings).PartListPreviewBackColor;
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
    if ((!disposing ? 0 : (((F_RoboticSurfacePoints) this).\u0001 != null ? 1 : 0)) != 0)
      ((F_RoboticSurfacePoints) this).\u0001.Dispose();
    base.Dispose(disposing);
  }

  static F_TuftingImageList()
  {
    F_RoboticSurfacePoints.Captions = new List<string>();
    F_RoboticSurfacePoints.CaptionGrid = new List<string>();
  }

  public F_TuftingImageList()
  {
    ((F_TuftingExchange) this).PropertiesForm = new FormProperties();
    ((F_TuftingExchange) this).PostNameList = new List<FileEventArg>();
    ((F_TuftingExchange) this).ExistingPostName = "";
    ((F_TuftingExchange) this).pathPost = Application.StartupPath;
    ((F_TuftingExchange) this).\u0001 = -1;
    ((F_TuftingExchange) this).\u0001 = (IContainer) null;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001((F_PostProcessorSelect) this);
  }

  public void Init()
  {
    ((F_TuftingExchange) this).PropertiesForm.Inited = false;
    ((F_TuftingExchange) this).\u0001 = -1;
    ((F_TuftingExchange) this).\u0001.Items.Clear();
    for (int index = 0; index <= ((F_TuftingExchange) this).PostNameList.Count - 1; ++index)
    {
      if (((F_TuftingExchange) this).PostNameList[index].JustFileName.Trim() == ((F_TuftingExchange) this).ExistingPostName)
        ((F_TuftingExchange) this).\u0001 = index;
      ((F_TuftingExchange) this).\u0001.Items.Add((object) ((F_TuftingExchange) this).PostNameList[index].JustFileName);
    }
    if (((F_TuftingExchange) this).\u0001 >= 0)
      ((F_TuftingExchange) this).\u0001.SelectedIndex = ((F_TuftingExchange) this).\u0001;
    ((F_TuftingSetProps) this).LoadLanguage();
    ((F_TuftingExchange) this).PropertiesForm.Result = DialogResult.None;
    ((F_TuftingExchange) this).PropertiesForm.Inited = true;
  }
}
