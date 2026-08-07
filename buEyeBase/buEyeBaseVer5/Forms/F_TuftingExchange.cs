// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Forms.F_TuftingExchange
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buControls.DialogBox;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using dummy_ptr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Forms;

public class F_TuftingExchange : Form
{
  internal Label \u0008;
  public static byte f000FE4;
  public FormProperties PropertiesForm;
  public static List<string> Captions;
  public List<FileEventArg> PostNameList;
  public string ExistingPostName;
  public string pathPost;
  private int \u0001;
  private IContainer \u0001;
  internal Button \u0001;
  internal ImageList \u0001;
  internal Button \u0002;
  internal ListBox \u0001;
  public Button btn_open;
  public static byte f000FF1;
  public Design viewportLayout;
  public viewType View;
  public bool ZoomFit;
  public bool ZoomAnimation;
  public string fileNameTexture;
  public List<Entity> previewEntities;
  private Timer \u0001;
  private IContainer \u0001;
  public static List<string> Captions;
  public LayerBase5 Value;
  public List<drawingPattern> Patterns;
  public List<ToolBase5> Tools;
  public DialogResult Result;
  private IContainer \u0001;
  internal ComboBox \u0001;
  internal Label \u0001;
  internal Label \u0002;
  internal NumericUpDown \u0001;
  internal CheckBox \u0001;

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    string str1 = "";
    if (obj0.GetType() == typeof (System.Windows.Forms.Control) | obj0.GetType() == typeof (Button))
      str1 = ((System.Windows.Forms.Control) obj0).Name;
    if (obj0.GetType() == typeof (ToolStripMenuItem))
      str1 = ((ToolStripItem) obj0).Name;
    if (str1 == ((F_ToolList) this).\u0014.Name && ((F_QuiltingSettings) this).SelectedRowPart >= 0 & ((F_QuiltingSettings) this).SelectedRowPart <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
    {
      ((F_QuiltingSettings) this).DrawPart = true;
      ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.OK;
      this.Visible = false;
    }
    if (str1 == ((F_SettingTreeView) this).\u0005.Name)
    {
      F_NestSheetAdd fNestSheetAdd = (F_NestSheetAdd) new F_SortingSettings();
      ((F_Layer) fNestSheetAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowSheetItemNoColumb;
      ((F_Layer) fNestSheetAdd).FormCloseMode = FormCloseModeType.Dispose;
      ((F_SortingSettings) fNestSheetAdd).Init();
      fNestSheetAdd.StartPosition = FormStartPosition.CenterParent;
      int num = (int) fNestSheetAdd.ShowDialog();
      if (((F_Layer) fNestSheetAdd).Result == DialogResult.OK)
      {
        buNestingSheet buNestingSheet = (buNestingSheet) new buEyeBaseVer5.Apps.ProfileOperation(((F_Layer) fNestSheetAdd).Sheet);
        buCall.\u0001.SetColorEntity(((ProfileOperationSortItem) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).SheetEntityColor, ref ((\u0084.\u0001) ((ProfileItemCalc) buNestingSheet).EntitiesGroup.Outside).Entities);
        ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingSheetID(((F_RoboticSurfacePoints) this).Sheets, ref ((ProfileItemCalc) buNestingSheet).ID);
        ((F_RoboticSurfacePoints) this).Sheets.Add(buNestingSheet);
        Image Img = (Image) null;
        ((F_TuftingImageList) this).SheetPointsToImage(((F_Layer) fNestSheetAdd).Sheet, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight, ref Img);
        DataGridViewRowCollection rows = ((F_RoboticSurfacePoints) this).\u0001.Rows;
        int count = ((F_RoboticSurfacePoints) this).Sheets.Count;
        bool enable = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Enable;
        string name = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Name;
        double width = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Width;
        double height = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Height;
        int quantity = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Quantity;
        int used = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Used;
        int remain = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).Remain;
        string fileName = ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).FileName;
        double thickness = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Thickness;
        string itemNo = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).ItemNo;
        string other = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Other;
        string aux = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_Layer) fNestSheetAdd).Sheet).MaterialData).Aux;
        object[] objArray = \u007B0e48b843\u002Dfb72\u002D498c\u002D834d\u002Dfc743ba0facc\u007D.\u0001(enable, quantity, Img, (F_NestSheetPartList) this, used, width, name, thickness, height, itemNo, count, other, remain, fileName, aux);
        rows.Add(objArray);
        ((F_RoboticSurfacePoints) this).\u0001.Rows[((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
        ((F_RoboticSurfacePoints) this).\u0001.Rows[((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight;
      }
    }
    if (str1 == ((F_SettingTreeView) this).\u0004.Name)
    {
      if (((F_SortingSettings) this).\u0003.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_RoboticSurfacePoints) this).Sheets.Clear();
        ((F_RoboticSurfacePoints) this).\u0001.Rows.Clear();
      }
      if (((F_SortingSettings) this).\u0002.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) == DialogResult.Yes)
      {
        ((F_RoboticSurfacePoints) this).\u0001.Rows.RemoveAt(((F_QuiltingSettings) this).\u0001);
        ((F_RoboticSurfacePoints) this).Sheets.RemoveAt(((F_QuiltingSettings) this).\u0001);
      }
      if (!((F_SortingSettings) this).\u0001.Checked || buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[33]) != DialogResult.Yes)
        return;
      for (int index = ((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1; index >= 0; --index)
      {
        if (Convert.ToBoolean(((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[1].Value))
        {
          ((F_RoboticSurfacePoints) this).\u0001.Rows.RemoveAt(index);
          ((F_RoboticSurfacePoints) this).Sheets.RemoveAt(index);
        }
      }
    }
    else
    {
      if (str1 == ((F_SettingTreeView) this).\u0003.Name && ((F_QuiltingSettings) this).\u0001 >= 0 & ((F_QuiltingSettings) this).\u0001 <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
      {
        ((F_RoboticSurfacePoints) this).\u0001.Rows[((F_QuiltingSettings) this).\u0001].Cells[7].Value = (object) 0;
        ((F_RoboticSurfacePoints) this).\u0001.Rows[((F_QuiltingSettings) this).\u0001].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).MaterialData).Quantity;
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).Used = 0;
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).MaterialData).Quantity;
        ((F_RoboticSurfacePoints) this).\u0001.Rows[((F_QuiltingSettings) this).\u0001].DefaultCellStyle.ForeColor = Color.Black;
      }
      if (str1 == ((F_SettingTreeView) this).\u0002.Name)
      {
        for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1; ++index)
        {
          ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).Used = 0;
          ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).MaterialData).Quantity;
          ((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[7].Value = (object) 0;
          ((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).MaterialData).Quantity;
          ((F_RoboticSurfacePoints) this).\u0001.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u0001.Name)
      {
        for (int index = ((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[1].Value = (object) true;
          ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).Enable = true;
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u0002.Name)
      {
        for (int index = ((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1; index >= 0; --index)
        {
          ((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[1].Value = (object) false;
          ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).Enable = false;
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u0003.Name)
      {
        DialogBoxInput dialogBoxInput = new DialogBoxInput();
        dialogBoxInput.ValueCaption = "Count";
        dialogBoxInput.FormCaption = "Set Sheet Count";
        dialogBoxInput.Value = 1.0;
        int num = (int) dialogBoxInput.ShowDialog();
        if (dialogBoxInput.Result == DialogResult.OK)
        {
          for (int index = ((F_RoboticSurfacePoints) this).\u0001.Rows.Count - 1; index >= 0; --index)
          {
            ((F_RoboticSurfacePoints) this).\u0001.Rows[index].Cells[6].Value = (object) Convert.ToInt32(dialogBoxInput.Value);
            ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index]).MaterialData).Quantity = Convert.ToInt32(dialogBoxInput.Value);
          }
        }
      }
      int num1;
      if (str1 == ((F_SortingSettings) this).\u0013.Name && ((F_RoboticSurfacePoints) this).Parts.Count > 0)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = ((F_RoboticSurfacePoints) this).SaveFileFolder;
        saveFileDialog.Filter = ((F_QuiltingSettings) this).SaveFileExtender;
        saveFileDialog.FilterIndex = ((F_RoboticSurfacePoints) this).SaveFileExtensionIndex;
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
          ((F_RoboticSurfacePoints) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
          if (fileInfo.Extension == ".dxf")
          {
            for (int index1 = 0; index1 <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1; ++index1)
            {
              if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).Enable)
              {
                string str2 = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).MaterialData).Name.Trim();
                if (str2.Length == 0)
                {
                  num1 = index1 + 1;
                  str2 = "Mat" + num1.ToString();
                }
                string[] strArray = new string[10];
                strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                strArray[1] = "\\";
                strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                strArray[3] = "_";
                num1 = index1 + 1;
                strArray[4] = num1.ToString();
                strArray[5] = "_";
                strArray[6] = str2;
                strArray[7] = "_";
                strArray[8] = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).MaterialData).Quantity.ToString();
                strArray[9] = fileInfo.Extension;
                string FileName = string.Concat(strArray);
                List<Entity> copiedEntities = new List<Entity>();
                buDiametricDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.Outside).Entities, ref copiedEntities);
                if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.Inside != null)
                {
                  for (int index2 = 0; index2 <= ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.Inside.Count - 1; ++index2)
                  {
                    for (int index3 = 0; index3 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities.Count - 1; ++index3)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.Inside[index2]).Entities[index3], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.OpenEntities != null)
                {
                  for (int index4 = 0; index4 <= ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.OpenEntities.Count - 1; ++index4)
                  {
                    for (int index5 = 0; index5 <= ((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities.Count - 1; ++index5)
                    {
                      Entity copiedEntity = (Entity) null;
                      buAngularDim.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup.OpenEntities[index4]).Entities[index5], ref copiedEntity);
                      copiedEntities.Add(copiedEntity);
                    }
                  }
                }
                if (((DimensionGroup) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup).Text != null)
                {
                  for (int index6 = 0; index6 <= ((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup).Text).Entities.Count - 1; ++index6)
                  {
                    Entity copiedEntity = (Entity) null;
                    buAngularDim.Copy(((\u0084.\u0001) ((DimensionGroup) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[index1]).EntitiesGroup).Text).Entities[index6], ref copiedEntity);
                    copiedEntities.Add(copiedEntity);
                  }
                }
                cParameter5.SaveDxfDwg(copiedEntities, FileName);
              }
            }
          }
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u000F.Name)
      {
        F_NestRectPartAdd fNestRectPartAdd = (F_NestRectPartAdd) new F_SortingSettings();
        ((F_NestSheetPartList) fNestRectPartAdd).ShowItemNo = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).ShowPartItemNoColumb;
        ((F_NestSheetPartList) fNestRectPartAdd).FormCloseMode = FormCloseModeType.Dispose;
        ((F_SortingSettings) fNestRectPartAdd).Init();
        fNestRectPartAdd.StartPosition = FormStartPosition.CenterParent;
        int num2 = (int) fNestRectPartAdd.ShowDialog();
        if (((F_NestSheetPartList) fNestRectPartAdd).Result == DialogResult.OK)
        {
          buNestingPart buNestingPart = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_NestSheetPartList) fNestRectPartAdd).Part);
          Entity entSurface = (Entity) null;
          if (((buEyeBaseVer5.Apps.ProfileClamperSettings) ((ProfileSupportBlock) ((F_QuiltingSettings) this).Settings).ProgramSettings).View3D)
            buCall.\u0001.surfaceFromOutterInner(((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup, 0.2, ref entSurface);
          if (entSurface != null)
          {
            ((DimensionGroup) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup).Solid = (buEntityList) new buArcCam();
            buEntity copiedEntity = (buEntity) null;
            buAngularDim.Copy(entSurface, ref copiedEntity);
            if (copiedEntity != null)
              ((\u0084.\u0001) ((DimensionGroup) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup).Solid).Entities.Add(copiedEntity);
          }
          buCall.\u0001.SetLayerNameEntity(((DevideEventFormVars) ((F_RoboticSurfacePoints) this).activeLayer).Name, ref ((\u0084.\u0001) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup.Outside).Entities);
          buCall.\u0001.SetColorEntity(((DevideEventFormVars) ((F_RoboticSurfacePoints) this).activeLayer).LayerColor, ref ((\u0084.\u0001) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup.Outside).Entities);
          buCall.\u0001.SetToolNameEntity(((ToolCamData5) ((ToolGeometry5) ((F_RoboticSurfacePoints) this).activeTool).Data).Name, ref ((\u0084.\u0001) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) buNestingPart).EntitiesGroup.Outside).Entities);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_RoboticSurfacePoints) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) buNestingPart).ID);
          ((F_RoboticSurfacePoints) this).Parts.Add(buNestingPart);
          Image Img = (Image) null;
          ((F_TuftingImageList) this).PartPointsToImage(((F_NestSheetPartList) fNestRectPartAdd).Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_SettingTreeView) this).\u0002.Rows;
          int count = ((F_RoboticSurfacePoints) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Rotation;
          bool mirror = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Mirror;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_NestSheetPartList) fNestRectPartAdd).Part).PartData).Aux;
          object[] objArray = \u001F.\u0001.\u0001.\u0001(height, enable, fileName, mirror, quantity, width, Img, name, nested, itemNo, aux, remain, rotation, priority, count, other, (F_NestSheetPartList) this);
          rows.Add(objArray);
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight;
          ((F_TuftingImageList) this).GetInfo();
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u0006.Name)
      {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = ((F_RoboticSurfacePoints) this).AddPartFromFileFolder;
        openFileDialog.Filter = ((F_QuiltingSettings) this).AddPartFromFileExtender;
        openFileDialog.FilterIndex = ((F_RoboticSurfacePoints) this).AddPartFromFileExtensionIndex;
        openFileDialog.Multiselect = true;
        openFileDialog.FileName = "";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          ((F_RoboticSurfacePoints) this).AddPartFromFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
          ((F_RoboticSurfacePoints) this).AddPartFromFileExtensionIndex = openFileDialog.FilterIndex;
          if (openFileDialog.FileNames.Length != 0)
          {
            for (int index = 0; index <= openFileDialog.FileNames.Length - 1; ++index)
            {
              FileInfo fileInfo = new FileInfo(openFileDialog.FileNames[index]);
              if (fileInfo.Extension == ".bucadv5")
              {
                List<eEntities> Entities = new List<eEntities>();
                buGCodeCreate.OpenBuCadCam(fileInfo.FullName, new buCadFileOpenOptions(), ref Entities);
                ((F_TuftingImageList) this).AddPartFromEntities(Entities);
              }
              if (fileInfo.Extension == ".dxf")
              {
                List<eEntities> Entities = new List<eEntities>();
                List<LayerBase> layerBaseList = new List<LayerBase>();
                ((F_TuftingImageList) this).AddPartFromEntities(Entities);
              }
              if (fileInfo.Extension == ".csv")
                ((F_TuftingImageList) this).AddPartFromCsvFile(((F_RoboticSurfacePoints) this).CsvOpenTypeForAddNestingFromFile, openFileDialog.FileName);
            }
          }
          ((F_TuftingImageList) this).GetInfo();
        }
      }
      if (str1 == ((F_SettingTreeView) this).\u000E.Name)
      {
        if (((F_SortingSettings) this).\u0006.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
        {
          ((F_RoboticSurfacePoints) this).Parts.Clear();
          ((F_SettingTreeView) this).\u0002.Rows.Clear();
        }
        if (((F_SortingSettings) this).\u0004.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes)
        {
          for (int index = ((F_SettingTreeView) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            if (Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((F_SettingTreeView) this).\u0002.Rows.RemoveAt(index);
              ((F_RoboticSurfacePoints) this).Parts.RemoveAt(index);
            }
          }
        }
        if (((F_SortingSettings) this).\u0005.Checked && buNumeric5.MessageBoxQuestion(buNesting.LangNestingMessage[7] + AppLanguage.CadCamDynamic[34]) == DialogResult.Yes && ((F_QuiltingSettings) this).SelectedRowPart >= 0 & ((F_QuiltingSettings) this).SelectedRowPart <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        {
          ((F_SettingTreeView) this).\u0002.Rows.RemoveAt(((F_QuiltingSettings) this).SelectedRowPart);
          ((F_RoboticSurfacePoints) this).Parts.RemoveAt(((F_QuiltingSettings) this).SelectedRowPart);
        }
        ((F_TuftingImageList) this).GetInfo();
      }
      else
      {
        if (str1 == ((F_SettingTreeView) this).\u0008.Name && ((F_QuiltingSettings) this).SelectedRowPart >= 0 & ((F_QuiltingSettings) this).SelectedRowPart <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        {
          ((F_SettingTreeView) this).\u0002.Rows[((F_QuiltingSettings) this).SelectedRowPart].Cells[7].Value = (object) 0;
          ((F_SettingTreeView) this).\u0002.Rows[((F_QuiltingSettings) this).SelectedRowPart].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Quantity;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).Nested = 0;
          ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Quantity;
          ((F_SettingTreeView) this).\u0002.Rows[((F_QuiltingSettings) this).SelectedRowPart].DefaultCellStyle.ForeColor = Color.Black;
        }
        if (str1 == ((F_SettingTreeView) this).\u0007.Name)
        {
          for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index)
          {
            ((F_SettingTreeView) this).\u0002.Rows[index].Cells[7].Value = (object) 0;
            ((F_SettingTreeView) this).\u0002.Rows[index].Cells[8].Value = (object) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Nested = 0;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity;
            ((F_SettingTreeView) this).\u0002.Rows[index].DefaultCellStyle.ForeColor = Color.Black;
          }
        }
        if (str1 == ((F_ToolList) this).\u0014.Name && ((F_QuiltingSettings) this).SelectedRowPart >= 0)
        {
          buNestingPart Part = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]);
          ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name + "- [Mirror]";
          Point3D MirrorPoint = new Point3D(1.0, 0.0, 0.0);
          buCall.\u0001.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref ((buEyeBaseVer5.Apps.ProfileOperationRectangle) Part).EntitiesGroup);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_RoboticSurfacePoints) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) Part).ID);
          ((F_RoboticSurfacePoints) this).Parts.Add(Part);
          Image Img = (Image) null;
          ((F_TuftingImageList) this).PartPointsToImage(Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_SettingTreeView) this).\u0002.Rows;
          int count = ((F_RoboticSurfacePoints) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Rotation;
          bool mirror = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Mirror;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Aux;
          object[] objArray = \u001F.\u0001.\u0001.\u0001(height, enable, fileName, mirror, quantity, width, Img, name, nested, itemNo, aux, remain, rotation, priority, count, other, (F_NestSheetPartList) this);
          rows.Add(objArray);
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight;
        }
        if (str1 == ((F_ToolList) this).\u0015.Name && ((F_QuiltingSettings) this).SelectedRowPart >= 0)
        {
          buNestingPart Part = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]);
          ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name + "- [Mirror]";
          Point3D MirrorPoint = new Point3D(0.0, 1.0, 0.0);
          buCall.\u0001.Mirror(new Point3D(), MirrorPoint, Plane.XY, ref ((buEyeBaseVer5.Apps.ProfileOperationRectangle) Part).EntitiesGroup);
          ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_RoboticSurfacePoints) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) Part).ID);
          ((F_RoboticSurfacePoints) this).Parts.Add(Part);
          Image Img = (Image) null;
          ((F_TuftingImageList) this).PartPointsToImage(Part, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetPreviewWidth, ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight, ref Img);
          DataGridViewRowCollection rows = ((F_SettingTreeView) this).\u0002.Rows;
          int count = ((F_RoboticSurfacePoints) this).Parts.Count;
          bool enable = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Enable;
          string name = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Name;
          double width = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Width;
          double height = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Height;
          int quantity = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Quantity;
          int nested = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Nested;
          int remain = ((buEyeBaseVer5.Apps.ProfileOperation) Part).Remain;
          int priority = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Priority;
          Enum rotation = (Enum) ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Rotation;
          bool mirror = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Mirror;
          string fileName = ((buEyeBaseVer5.Apps.ProfileOperation) Part).FileName;
          string itemNo = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).ItemNo;
          string other = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Other;
          string aux = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) Part).PartData).Aux;
          object[] objArray = \u001F.\u0001.\u0001.\u0001(height, enable, fileName, mirror, quantity, width, Img, name, nested, itemNo, aux, remain, rotation, priority, count, other, (F_NestSheetPartList) this);
          rows.Add(objArray);
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Black;
          ((F_SettingTreeView) this).\u0002.Rows[((F_SettingTreeView) this).\u0002.Rows.Count - 1].Height = ((buEyeBaseVer5.Apps.ProfileClamper) ((ProfileMultiply) ((F_QuiltingSettings) this).Settings).Draw).GridPartSheetHeight;
        }
        if (str1 == ((F_SortingSettings) this).\u0012.Name)
        {
          ((F_RoboticSurfacePoints) this).SendToCadEntities.Clear();
          double dy = 0.0;
          double dx = 0.0;
          double num3 = double.MinValue;
          int num4 = 0;
          int num5 = 0;
          for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index)
          {
            if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Enable && ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Width > num3)
              num3 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Width;
          }
          for (int index7 = 0; index7 <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index7)
          {
            if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index7]).Enable)
            {
              List<Entity> copiedEntity = new List<Entity>();
              buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_RoboticSurfacePoints) this).Parts[index7]).EntitiesGroup, ref copiedEntity);
              for (int index8 = 0; index8 <= copiedEntity.Count - 1; ++index8)
              {
                copiedEntity[index8].Translate(dx, dy);
                ((F_RoboticSurfacePoints) this).SendToCadEntities.Add(copiedEntity[index8]);
              }
              dy = dy + ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index7]).PartData).Height + 20.0;
              ++num4;
              if (num4 >= 10)
              {
                num4 = 0;
                ++num5;
                dy = 0.0;
                dx = num3 * (double) num5;
              }
            }
          }
          if (((F_RoboticSurfacePoints) this).SendToCadEntities.Count > 0)
          {
            ((F_QuiltingSettings) this).SendToCad = true;
            this.Visible = false;
            ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.OK;
          }
        }
        if (str1 == ((F_SortingSettings) this).\u000F.Name)
        {
          DialogBoxInput dialogBoxInput = new DialogBoxInput();
          dialogBoxInput.ValueCaption = "Count";
          dialogBoxInput.FormCaption = "Set Part Count";
          int num6 = (int) dialogBoxInput.ShowDialog();
          if (dialogBoxInput.Result == DialogResult.OK)
          {
            for (int index = ((F_SettingTreeView) this).\u0002.Rows.Count - 1; index >= 0; --index)
            {
              ((F_SettingTreeView) this).\u0002.Rows[index].Cells[6].Value = (object) Convert.ToInt32(dialogBoxInput.Value);
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity = Convert.ToInt32(dialogBoxInput.Value);
            }
          }
        }
        if (str1 == ((F_ToolList) this).\u0016.Name)
        {
          DialogBoxInput dialogBoxInput = new DialogBoxInput();
          dialogBoxInput.ValueCaption = "Addtional Rotation";
          dialogBoxInput.FormCaption = "Degree";
          int num7 = (int) dialogBoxInput.ShowDialog();
          if (dialogBoxInput.Result == DialogResult.OK)
          {
            for (int index = ((F_SettingTreeView) this).\u0002.Rows.Count - 1; index >= 0; --index)
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).AdditionalRotation = Convert.ToDouble(dialogBoxInput.Value);
          }
        }
        if (str1 == ((F_SettingTreeView) this).\u0004.Name)
        {
          for (int index = ((F_SettingTreeView) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            ((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value = (object) true;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Enable = true;
          }
        }
        if (str1 == ((DataTableItem) this).\u0005.Name)
        {
          for (int index = ((F_SettingTreeView) this).\u0002.Rows.Count - 1; index >= 0; --index)
          {
            ((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value = (object) false;
            ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Enable = false;
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0007.Name)
        {
          for (int index = 0; index <= ((F_SettingTreeView) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Rotation = nestPartRotateType.Fixed0;
              ((F_SettingTreeView) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Fixed0;
            }
          }
        }
        if (str1 == ((TreeNodeSettings) this).\u0006.Name)
        {
          for (int index = 0; index <= ((F_SettingTreeView) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[index].Cells[0].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Rotation = nestPartRotateType.FreeRotate;
              ((F_SettingTreeView) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.FreeRotate;
            }
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0008.Name)
        {
          for (int index = 0; index <= ((F_SettingTreeView) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Rotation = nestPartRotateType.Increment90;
              ((F_SettingTreeView) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Increment90;
            }
          }
        }
        if (str1 == ((F_SortingSettings) this).\u000E.Name)
        {
          for (int index = 0; index <= ((F_SettingTreeView) this).\u0002.Rows.Count - 1; ++index)
          {
            if (Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[index].Cells[1].Value))
            {
              ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Rotation = nestPartRotateType.Increment180;
              ((F_SettingTreeView) this).\u0002.Rows[index].Cells[10].Value = (object) nestPartRotateType.Increment180;
            }
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0011.Name)
        {
          List<buNestingPart> buNestingPartList = new List<buNestingPart>();
          for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index)
          {
            buNestingPart NewPart = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel();
            Point3D MinPoint = new Point3D();
            Point3D MaxPoint = new Point3D();
            buCall.\u0001.BoxSizeCalculate(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_RoboticSurfacePoints) this).Parts[index]).EntitiesGroup, ref MinPoint, ref MaxPoint);
            double newWidth = MaxPoint.X - MinPoint.X;
            double newHeight = MaxPoint.Y - MinPoint.Y;
            if (newWidth > 0.0 & newHeight > 0.0)
            {
              ((F_TuftingImageList) this).CreatPartAsRectanlge(newWidth, newHeight, ((F_RoboticSurfacePoints) this).Parts[index], ref NewPart);
              buNestingPart data = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(NewPart);
              ((buEyeBaseVer5.Apps.ProfileCalculatedJob) buCall.\u0001).GetAvailableNestingPartID(((F_RoboticSurfacePoints) this).Parts, ref ((buEyeBaseVer5.Apps.ProfileOperation) data).ID);
              ((F_RoboticSurfacePoints) this).Parts[index] = (buNestingPart) new buEyeBaseVer5.Apps.ProfileOperationBarrel(data);
              buNestingPartList.Add(data);
            }
          }
          ((F_ToolList) this).Init(1);
        }
        if (str1 == ((F_SortingSettings) this).\u0010.Name && ((F_RoboticSurfacePoints) this).Parts.Count > 0)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = ((F_RoboticSurfacePoints) this).SaveFileFolder;
          saveFileDialog.Filter = ((F_QuiltingSettings) this).SaveFileExtender;
          saveFileDialog.FilterIndex = ((F_RoboticSurfacePoints) this).SaveFileExtensionIndex;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
            ((F_RoboticSurfacePoints) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
            if (fileInfo.Extension == ".dxf")
            {
              for (int index = 0; index <= ((F_RoboticSurfacePoints) this).Parts.Count - 1; ++index)
              {
                if (((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).Enable)
                {
                  string str3 = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Name.Trim();
                  if (str3.Length == 0)
                  {
                    num1 = index + 1;
                    str3 = "Part" + num1.ToString();
                  }
                  string[] strArray = new string[10];
                  strArray[0] = buFile5.bunesting.GetPath(saveFileDialog.FileName);
                  strArray[1] = "\\";
                  strArray[2] = buFile5.bunesting.getFileNameWithoutExtension(saveFileDialog.FileName);
                  strArray[3] = "_";
                  num1 = index + 1;
                  strArray[4] = num1.ToString();
                  strArray[5] = "_";
                  strArray[6] = str3;
                  strArray[7] = "_";
                  strArray[8] = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[index]).PartData).Quantity.ToString();
                  strArray[9] = fileInfo.Extension;
                  string FileName = string.Concat(strArray);
                  List<Entity> copiedEntity = new List<Entity>();
                  buDiametricDim.Copy(((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_RoboticSurfacePoints) this).Parts[index]).EntitiesGroup, ref copiedEntity);
                  cParameter5.SaveDxfDwg(copiedEntity, FileName);
                }
              }
            }
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0010.Name)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = ((F_RoboticSurfacePoints) this).SaveFileFolder;
          saveFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
          saveFileDialog.FilterIndex = 1;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            ((F_RoboticSurfacePoints) this).SaveFileFolder = buFile5.bunesting.GetPath(saveFileDialog.FileName);
            new buVector5().SaveNesting(saveFileDialog.FileName, ((F_RoboticSurfacePoints) this).Parts, ((F_RoboticSurfacePoints) this).Sheets, ((F_QuiltingSettings) this).Settings);
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0011.Name)
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.InitialDirectory = ((F_RoboticSurfacePoints) this).SaveFileFolder;
          openFileDialog.Filter = "buCad/Cam Nesting Files (*.bunesting)|*.bunesting";
          openFileDialog.FilterIndex = 1;
          if (openFileDialog.ShowDialog() == DialogResult.OK)
          {
            ((F_RoboticSurfacePoints) this).SaveFileFolder = buFile5.bunesting.GetPath(openFileDialog.FileName);
            new buVector5().OpenNesting(openFileDialog.FileName, ref ((F_RoboticSurfacePoints) this).Parts, ref ((F_RoboticSurfacePoints) this).Sheets);
            ((F_ToolList) this).Init(((F_RoboticSurfacePoints) this).\u0001.SelectedIndex);
          }
        }
        if (str1 == ((F_SortingSettings) this).\u0012.Name)
        {
          this.Visible = false;
          ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.Cancel;
        }
        if (!(str1 == ((F_SortingSettings) this).\u0013.Name))
          return;
        ((buEyeBaseVer5.Apps.ProfileOperationSlot) ((ProfileSupportBlock) ((F_QuiltingSettings) this).Settings).PartSettings).Multiply = (int) ((F_ToolList) this).\u0001.Value;
        this.Visible = false;
        ((F_QuiltingSettings) this).PropertiesForm.Result = DialogResult.OK;
      }
    }
  }

  internal void \u0001([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1))
      return;
    ((F_QuiltingSettings) this).\u0001 = obj1.RowIndex;
    buCall.\u0001.DrawSheet(((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
    if (!(((F_QuiltingSettings) this).\u0001 >= 0 & ((F_QuiltingSettings) this).\u0001 <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1))
      return;
    List<Point3D> Vertices = new List<Point3D>();
    double num1 = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).MaterialData).Width / 1000.0 * (((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).MaterialData).Height / 1000.0);
    buVector5.Copy(((\u0084.\u0001) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[((F_QuiltingSettings) this).\u0001]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double num2 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    ((F_SettingTreeView) this).\u0002.Text = num1.ToString("f2");
    ((F_SettingTreeView) this).\u0001.Text = (num2 / 1000000.0).ToString("f2");
  }

  internal void \u0002([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
    {
      buNestingSheetData nestingSheetData = (buNestingSheetData) new buEyeBaseVer5.Apps.ProfileOperation(((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData);
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) nestingSheetData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData = (buNestingSheetData) new buEyeBaseVer5.Apps.ProfileOperation((buNestingSheetData) classViewerDialog.Value);
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Area = ((buEyeBaseVer5.Apps.ProfileItem) nestingSheetData).Height * ((buEyeBaseVer5.Apps.ProfileItem) nestingSheetData).Width;
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Used;
        if (((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity < 0)
          ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity;
        if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        \u0007.\u0001.\u0001((F_NestSheetPartList) this);
        buCall.\u0001.DrawSheet(((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
        ((F_RoboticSurfacePoints) this).\u0001.CurrentCell = ((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[1];
      }
    }
    \u0007.\u0001.\u0001((F_NestSheetPartList) this);
  }

  internal void \u0003([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Name = Convert.ToString(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width = Convert.ToDouble(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Area = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height = Convert.ToDouble(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Area = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height * ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width;
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Used;
        if (((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingSheet sheet = ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).SheetRectangle(((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Width, ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Height, ref sheet);
        }
        buCall.\u0001.DrawSheet(((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity = Convert.ToInt32(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Quantity - ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).Used;
      }
      if (obj1.ColumnIndex == 11 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).ItemNo = Convert.ToString(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 12 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Other = Convert.ToString(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 13 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Sheets.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileItem) ((ProfileItemCalc) ((F_RoboticSurfacePoints) this).Sheets[obj1.RowIndex]).MaterialData).Aux = Convert.ToString(((F_RoboticSurfacePoints) this).\u0001.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    \u0007.\u0001.\u0001((F_NestSheetPartList) this);
  }

  internal void \u0004([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1))
      return;
    ((F_QuiltingSettings) this).SelectedRowPart = obj1.RowIndex;
    ((F_QuiltingSettings) this).SelectedColPart = obj1.ColumnIndex;
    if (((F_QuiltingSettings) this).PartPreSelectedRow >= 0 & ((F_QuiltingSettings) this).SelectedColPart == 1 && ((F_QuiltingSettings) this).SelectedRowPart > ((F_QuiltingSettings) this).PartPreSelectedRow & ((F_QuiltingSettings) this).ShiftPressed)
    {
      bool boolean = Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      for (int partPreSelectedRow = ((F_QuiltingSettings) this).PartPreSelectedRow; partPreSelectedRow <= ((F_QuiltingSettings) this).SelectedRowPart; ++partPreSelectedRow)
      {
        ((F_SettingTreeView) this).\u0002.Rows[partPreSelectedRow].Cells[obj1.ColumnIndex].Value = (object) !boolean;
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Enable = boolean;
      }
      ((F_QuiltingSettings) this).ShiftPressed = false;
    }
    ((F_QuiltingSettings) this).PartPreSelectedRow = obj1.RowIndex;
  }

  internal void \u0005([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
    {
      buNestingPartData buNestingPartData = (buNestingPartData) new buEyeBaseVer5.Apps.ProfileOperationRoundRectangle(((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData);
      buEyeBaseVer5.Apps.ProfileOperationBarrel profileOperationBarrel = new buEyeBaseVer5.Apps.ProfileOperationBarrel();
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Width = 300;
      classViewerDialog.Value = (object) buNestingPartData;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result == DialogResult.OK)
      {
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData = (buNestingPartData) new buEyeBaseVer5.Apps.ProfileOperationRoundRectangle((buNestingPartData) classViewerDialog.Value);
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Quantity - ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Nested;
        if (((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Type == nestMaterialType.Rectangle)
        {
          buNestingPart part = ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex];
          ((GProfileOperation) buCall.\u0001).PartRectangle(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Width, ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Height, ref part);
        }
        \u0007.\u0001.\u0001((F_NestSheetPartList) this);
        buCall.\u0001.DrawPart(((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
        ((F_SettingTreeView) this).\u0002.CurrentCell = ((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[1];
      }
    }
    \u0007.\u0001.\u0001((F_NestSheetPartList) this);
  }

  internal void \u0006([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (obj1.ColumnIndex >= 0 & obj1.RowIndex >= 0)
    {
      if (obj1.ColumnIndex == 1 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Enable = Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 2 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Name = Convert.ToString(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 4 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Width = Convert.ToDouble(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Width, ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
      }
      if (obj1.ColumnIndex == 5 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Height = Convert.ToDouble(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value.ToString());
        buNestingPart part = ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex];
        ((GProfileOperation) buCall.\u0001).PartRectangle(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Width, ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) part).PartData).Height, ref part);
        buCall.\u0001.DrawPart(((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
      }
      if (obj1.ColumnIndex == 6 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
      {
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Quantity = Convert.ToInt32(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
        ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Remain = ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Quantity - ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).Nested;
      }
      if (obj1.ColumnIndex == 9 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Priority = Convert.ToInt32(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 11 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Mirror = Convert.ToBoolean(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 14 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).ItemNo = Convert.ToString(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 15 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Other = Convert.ToString(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
      if (obj1.ColumnIndex == 16 /*0x10*/ & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1)
        ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[obj1.RowIndex]).PartData).Aux = Convert.ToString(((F_SettingTreeView) this).\u0002.Rows[obj1.RowIndex].Cells[obj1.ColumnIndex].Value);
    }
    \u0007.\u0001.\u0001((F_NestSheetPartList) this);
  }

  internal void \u0007([In] object obj0, [In] DataGridViewCellEventArgs obj1)
  {
    if (!(obj1.RowIndex >= 0 & obj1.RowIndex <= ((F_RoboticSurfacePoints) this).Parts.Count - 1))
      return;
    ((F_QuiltingSettings) this).SelectedRowPart = obj1.RowIndex;
    buCall.\u0001.DrawPart(((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart], ((F_QuiltingSettings) this).Settings, ref ((F_QuiltingSettings) this).\u0001);
    if (!(((F_QuiltingSettings) this).SelectedRowPart >= 0 & ((F_QuiltingSettings) this).SelectedRowPart <= ((F_RoboticSurfacePoints) this).Parts.Count - 1))
      return;
    double num1 = 0.0;
    double num2 = 0.0;
    List<Point3D> Vertices = new List<Point3D>();
    double num3 = num1 + ((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Width / 1000.0 * (((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Height / 1000.0) * Convert.ToDouble(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Quantity);
    buVector5.Copy(((\u0084.\u0001) ((buEyeBaseVer5.Apps.ProfileOperationRectangle) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).EntitiesGroup.Outside).Points, ref Vertices);
    ((F_CutterMachineSettings) buCall.\u0001).CheckDuplicatedPointsWithPrevious(ref Vertices);
    double area = ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).Area;
    double num4 = buCall.\u0001.PolygonArea(Vertices, Plane.XY);
    double num5 = num2 + num4 / 1000000.0 * Convert.ToDouble(((buEyeBaseVer5.Apps.ProfileOperation) ((buEyeBaseVer5.Apps.ProfileOperation) ((F_RoboticSurfacePoints) this).Parts[((F_QuiltingSettings) this).SelectedRowPart]).PartData).Quantity);
    ((F_SettingTreeView) this).\u0004.Text = num3.ToString("f2");
    ((F_SettingTreeView) this).\u0003.Text = num5.ToString("f2");
  }

  internal void \u0001([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_QuiltingSettings) this).ShiftPressed = obj1.Shift;
  }

  internal void \u0002([In] object obj0, [In] KeyEventArgs obj1)
  {
    ((F_QuiltingSettings) this).ShiftPressed = false;
  }
}
