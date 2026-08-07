// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.PanelCut.clsPanelCut
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buCadCamResVer5.Nesting;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms.BarCodes;
using buEyeBaseVer5.Forms.PanelCut;
using buMutliTextbox;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.PanelCut;

public class clsPanelCut
{
  public static PanelCutTempVars varTemps = new PanelCutTempVars();
  public static PanelCutSettings varPanelCutSettings = new PanelCutSettings();
  public static PanelCutRuntimeSettings varPanelCutRunSettings = new PanelCutRuntimeSettings();
  public F_PanelCutMachSim frmMachSim = (F_PanelCutMachSim) null;
  public F_PanelCutSheetList FrmNestPanelSheet = (F_PanelCutSheetList) null;
  public F_PanelCutPartList FrmNestPanelPart = (F_PanelCutPartList) null;
  public F_PanelCutMaterials FrmPanelCutMaterial = (F_PanelCutMaterials) null;
  public static Design viewportAuto = (Design) null;
  public static Design viewportAutoPanel = (Design) null;
  public static Design viewportAutoDone = (Design) null;
  public static Design viewportAutoWaiting = (Design) null;
  public Plane planeActive = Plane.XY;
  public bool isCollisionRunning = false;
  public static List<int> SimMovePartIndex = new List<int>();
  public int indexSim = -1;
  public int selectedJobIndex = -1;
  public int selectedItemIndex = -1;
  public int selectedItemSubIndex = -1;
  public int entityIndex = -1;
  public List<string> cmdExceptionID = new List<string>();
  public int JobIndex = -1;
  public int MoveIndex = 0;
  public NestingPanelJob activeJob = new NestingPanelJob();
  public NestingPanel cutPanel = new NestingPanel();
  public Timer timSim = (Timer) null;

  public void Init()
  {
    this.FrmPanelCutMaterial = new F_PanelCutMaterials();
    clsFiles.OpenMachineConfig(AppPath.MachineSimConfig + "\\Machine.bumachdef", ref ccVars.SimMachine);
    clsInit.appNestingPanel.CalculationDone += new OkCommandWithDataEventHandler(this.doCalculationDone);
    clsItem.FrmPanelCutJob.dgv_sheets.CellClick += new DataGridViewCellEventHandler(this.SheetDone_CellClick);
    clsItem.FrmPanelCutJob.dgv_sheets.RowHeadersVisible = false;
    clsItem.FrmPanelCutJob.dgv_sheets.AllowUserToAddRows = false;
    clsItem.FrmPanelCutJob.dgv_sheets.AllowUserToResizeColumns = false;
    if (clsItem.FrmPanelCutJob.dgv_sheets.Columns.Count == 0)
    {
      DataGridViewColumn dataGridViewColumn1 = new DataGridViewColumn();
      dataGridViewColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn1.Width = 100;
      dataGridViewColumn1.HeaderText = "No";
      dataGridViewColumn1.Name = "No";
      dataGridViewColumn1.ReadOnly = true;
      dataGridViewColumn1.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn1.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn1);
      DataGridViewColumn dataGridViewColumn2 = new DataGridViewColumn();
      dataGridViewColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn2.Width = 180;
      dataGridViewColumn2.HeaderText = "Size";
      dataGridViewColumn2.Name = "Size";
      dataGridViewColumn2.ReadOnly = false;
      dataGridViewColumn2.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn2.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn2);
      DataGridViewColumn dataGridViewColumn3 = new DataGridViewColumn();
      dataGridViewColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn3.Width = 100;
      dataGridViewColumn3.HeaderText = "Count";
      dataGridViewColumn3.Name = "Count";
      dataGridViewColumn3.ReadOnly = false;
      dataGridViewColumn3.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn3.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn3);
      DataGridViewColumn dataGridViewColumn4 = new DataGridViewColumn();
      dataGridViewColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn4.Width = 120;
      dataGridViewColumn4.HeaderText = "Parts";
      dataGridViewColumn4.Name = "Parts";
      dataGridViewColumn4.ReadOnly = true;
      dataGridViewColumn4.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn4.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn4);
      DataGridViewColumn dataGridViewColumn5 = new DataGridViewColumn();
      dataGridViewColumn5.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn5.Width = 120;
      dataGridViewColumn5.HeaderText = "Waste";
      dataGridViewColumn5.Name = "Waste";
      dataGridViewColumn5.ReadOnly = false;
      dataGridViewColumn5.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn5.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn5);
      DataGridViewColumn dataGridViewColumn6 = new DataGridViewColumn();
      dataGridViewColumn6.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn6.Width = 200;
      dataGridViewColumn6.HeaderText = "Total Cut";
      dataGridViewColumn6.Name = "TotalCut";
      dataGridViewColumn6.ReadOnly = false;
      dataGridViewColumn6.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn6.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn6);
      DataGridViewColumn dataGridViewColumn7 = new DataGridViewColumn();
      dataGridViewColumn7.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn7.Width = 150;
      dataGridViewColumn7.HeaderText = "Material";
      dataGridViewColumn7.Name = "Material";
      dataGridViewColumn7.ReadOnly = false;
      dataGridViewColumn7.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn7.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn7);
      DataGridViewColumn dataGridViewColumn8 = new DataGridViewColumn();
      dataGridViewColumn8.SortMode = DataGridViewColumnSortMode.NotSortable;
      dataGridViewColumn8.Width = 400;
      dataGridViewColumn8.HeaderText = "Explanation";
      dataGridViewColumn8.Name = "Explanation";
      dataGridViewColumn8.ReadOnly = true;
      dataGridViewColumn8.DefaultCellStyle.Font = new Font("Arial", 10f, FontStyle.Bold);
      dataGridViewColumn8.CellTemplate = (DataGridViewCell) new DataGridViewTextBoxCell();
      clsItem.FrmPanelCutJob.dgv_sheets.Columns.Add(dataGridViewColumn8);
    }
    this.timSim = new Timer();
    this.timSim.Tick += new EventHandler(this.tick_Simulation);
    this.cmdExceptionID.Add("clsProfile - ID = 101-00100");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00101");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00102");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00103");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00104");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00105");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00106");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00107");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00108");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00109");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00110");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00111");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00112");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00113");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00114");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00115");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00116");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00117");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00118");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00119");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00120");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00121");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00122");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00123");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00124");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00125");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00126");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00127");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00128");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00129");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00130");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00131");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00132");
    this.cmdExceptionID.Add("clsProfile - ID = 101-00133");
  }

  public void InitViewport()
  {
    if (this.frmMachSim == null)
    {
      this.frmMachSim = new F_PanelCutMachSim();
      this.frmMachSim.ValueChanged += new ValueChangedWithDataEventHandler(this.SimValueChaned);
    }
    if (clsPanelCut.viewportAuto == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAuto, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = true,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAuto.Name = "ModelAuto";
      this.frmMachSim.pnl_viewport.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAuto);
      clsPanelCut.viewportAuto.MouseMove += new MouseEventHandler(this.method_0);
      clsPanelCut.viewportAuto.MouseDown += new MouseEventHandler(this.method_1);
      clsPanelCut.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
      for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
        {
          Entity refEnt = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[index1].Entities[index2]);
          refEnt.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.MachineParts,
            EntityName = ccVars.SimMachine.MachineParts[index1].PartName
          };
          refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsPanelCut.viewportAuto));
          string name = ((CustomData) refEnt.EntityData).EntityName;
          if (name.Length == 0)
            name = "Block" + index1.ToString();
          Block block = new Block(name);
          Entity entity = buVector5.CopyEntities(refEnt);
          entity.Color = Color.Linen;
          int alpha = (int) byte.MaxValue;
          if (ccVars.SimMachine.MachineParts[index1].Transparency >= 0 & ccVars.SimMachine.MachineParts[index1].Transparency <= (int) byte.MaxValue)
            alpha = ccVars.SimMachine.MachineParts[index1].Transparency;
          if (index1 <= ccVars.SimMachine.MachineParts.Count - 1)
            entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index1].Color);
          entity.ColorMethod = colorMethodType.byEntity;
          block.Entities.Add(entity);
          clsPanelCut.viewportAuto.Blocks.Add(block);
        }
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        for (int index4 = 0; index4 <= ccVars.SimMachine.Clampers.Count - 1; ++index4)
        {
          for (int index5 = 0; index5 <= ccVars.SimMachine.Clampers[index4].Entities.Count - 1; ++index5)
          {
            Entity refEnt = buVector5.CopyEntities(ccVars.SimMachine.Clampers[index4].Entities[index5]);
            refEnt.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.MachineParts,
              EntityName = ccVars.SimMachine.Clampers[index4].PartName
            };
            refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsPanelCut.viewportAuto));
            string name = ((CustomData) refEnt.EntityData).EntityName + index3.ToString();
            if (name.Length == 0)
              name = $"BlockClamper{index3.ToString()}{index4.ToString()}";
            Block block = new Block(name);
            Entity entity = buVector5.CopyEntities(refEnt);
            entity.Color = Color.Linen;
            int alpha = (int) byte.MaxValue;
            if (ccVars.SimMachine.Clampers[index4].Transparency >= 0 & ccVars.SimMachine.Clampers[index4].Transparency <= (int) byte.MaxValue)
              alpha = ccVars.SimMachine.Clampers[index4].Transparency;
            if (index4 <= ccVars.SimMachine.Clampers.Count - 1)
              entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.Clampers[index4].Color);
            entity.ColorMethod = colorMethodType.byEntity;
            block.Entities.Add(entity);
            clsPanelCut.viewportAuto.Blocks.Add(block);
          }
        }
      }
    }
    if (clsPanelCut.viewportAutoPanel == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoPanel, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAutoPanel.Name = "ModelAutoPanel";
      this.frmMachSim.pnl_viewportpanel.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoPanel);
      clsPanelCut.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (clsPanelCut.viewportAutoDone == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoDone, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAutoDone.Name = "ModelAutoDone";
      this.frmMachSim.pnl_viewportdone.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoDone);
      clsPanelCut.viewportAutoDone.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (clsPanelCut.viewportAutoWaiting != null)
      return;
    clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoWaiting, clsVar.UnlockKey, new CreateModelProperties()
    {
      CoordinateSystemIconVisible = false,
      OriginSymbolVisible = false,
      ViewCubeIconVisible = false,
      OrigineCaptionVisible = false,
      ToolBorVisible = false,
      BottomColor = Color.LightGray,
      MiddleColor = Color.WhiteSmoke,
      TopColor = Color.LightGray,
      PanMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
      },
      RotateMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
      },
      ZoomMouseButtons = {
        Button = mouseButtonsZPR.Middle,
        ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
      }
    });
    clsPanelCut.viewportAutoWaiting.Name = "ModelAutoWaiting";
    this.frmMachSim.pnl_viewportwaiting.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoWaiting);
    clsPanelCut.viewportAutoWaiting.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
  }

  public void cmdNestingExecute()
  {
    GC.Collect();
    clsInit.appNestingPanel.Execute();
  }

  public void cmdNestingMaterial()
  {
    try
    {
      if (this.FrmPanelCutMaterial == null)
        return;
      if (!this.FrmPanelCutMaterial.Visible)
      {
        this.FrmPanelCutMaterial.Materails.Clear();
        this.FrmPanelCutMaterial.Materails = new List<buNestingMaterials>();
        this.FrmPanelCutMaterial.Materails = buNestingMaterials.Copy(clsNesting.Materials);
        this.FrmPanelCutMaterial.Init();
        int num = (int) this.FrmPanelCutMaterial.ShowDialog();
        if (this.FrmPanelCutMaterial.PropertiesForm.Result != DialogResult.OK)
          return;
        clsNesting.Materials = buNestingMaterials.Copy(this.FrmPanelCutMaterial.Materails);
        clsInit.appNesting.SaveNestingFile();
      }
      else
        this.FrmNestPanelSheet.Visible = false;
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdShowSheetPage(bool SheetVisible)
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        if (this.FrmNestPanelSheet == null)
          this.FrmNestPanelSheet = new F_PanelCutSheetList();
        if (this.FrmNestPanelSheet == null)
          return;
        if (!this.FrmNestPanelSheet.Visible)
        {
          this.FrmNestPanelSheet.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
          this.FrmNestPanelSheet.AddPartFromFileExtenderAsCsvType = true;
          this.FrmNestPanelSheet.Sheets.Clear();
          this.FrmNestPanelSheet.Sheets = new List<buNestingSheet>();
          for (int index = 0; index <= clsNesting.Sheets.Count - 1; ++index)
          {
            buNestingSheet Copied = new buNestingSheet();
            buNestingSheet.Copy(clsNesting.Sheets[index], ref Copied);
            if (Copied.ID <= 0)
            {
              clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Copied.ID);
              clsNesting.Sheets[index].ID = Copied.ID;
            }
            this.FrmNestPanelSheet.Sheets.Add(Copied);
          }
          this.FrmNestPanelSheet.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
          if (SheetVisible)
            this.FrmNestPanelSheet.Init(0);
          else
            this.FrmNestPanelSheet.Init(1);
          int num = (int) this.FrmNestPanelSheet.ShowDialog();
          if (this.FrmNestPanelSheet.PropertiesForm.Result != DialogResult.OK)
            return;
          this.SheetUpdate();
          if (!this.FrmNestPanelSheet.SendToCad)
            return;
          clsInit.appCommand.undoBuffer();
          for (int index = 0; index <= this.FrmNestPanelSheet.SendToCadEntities.Count - 1; ++index)
          {
            ccVars.UndoDont = true;
            clsInit.appCommand.AddEntity(this.FrmNestPanelSheet.SendToCadEntities[index]);
          }
        }
        else
          this.FrmNestPanelSheet.Visible = false;
      }
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public void cmdNestingSheets()
  {
    if (this.FrmNestPanelSheet == null)
      this.FrmNestPanelSheet = new F_PanelCutSheetList();
    if (this.FrmNestPanelSheet == null)
      return;
    if (!this.FrmNestPanelSheet.Visible)
    {
      this.FrmNestPanelSheet.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
      this.FrmNestPanelSheet.AddPartFromFileExtenderAsCsvType = true;
      this.FrmNestPanelSheet.Sheets.Clear();
      this.FrmNestPanelSheet.Sheets = new List<buNestingSheet>();
      for (int index = 0; index <= clsNesting.Sheets.Count - 1; ++index)
      {
        buNestingSheet Copied = new buNestingSheet();
        buNestingSheet.Copy(clsNesting.Sheets[index], ref Copied);
        if (Copied.ID <= 0)
        {
          clsInit.cNesting.GetAvailableNestingSheetID(clsNesting.Sheets, ref Copied.ID);
          clsNesting.Sheets[index].ID = Copied.ID;
        }
        this.FrmNestPanelSheet.Sheets.Add(Copied);
      }
      this.FrmNestPanelSheet.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
      this.FrmNestPanelSheet.Init(0);
      int num = (int) this.FrmNestPanelSheet.ShowDialog();
      if (this.FrmNestPanelSheet.PropertiesForm.Result != DialogResult.OK)
        return;
      this.SheetUpdate();
      if (!this.FrmNestPanelSheet.SendToCad)
        return;
      clsInit.appCommand.undoBuffer();
      for (int index = 0; index <= this.FrmNestPanelSheet.SendToCadEntities.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(this.FrmNestPanelSheet.SendToCadEntities[index]);
      }
    }
    else
      this.FrmNestPanelSheet.Visible = false;
  }

  public void cmdNestingParts()
  {
    if (this.FrmNestPanelPart == null)
      this.FrmNestPanelPart = new F_PanelCutPartList();
    if (this.FrmNestPanelPart == null)
      return;
    if (!this.FrmNestPanelPart.Visible)
    {
      this.FrmNestPanelPart.CsvOpenTypeForAddNestingFromFile = nestCsvPartImportType.Mode3_RectanglePartWidthHeightCount;
      this.FrmNestPanelPart.AddPartFromFileExtenderAsCsvType = true;
      this.FrmNestPanelPart.Parts.Clear();
      this.FrmNestPanelPart.Parts = new List<buNestingPart>();
      for (int index = 0; index <= clsNesting.Parts.Count - 1; ++index)
      {
        buNestingPart Copied = new buNestingPart();
        buNestingPart.Copy(clsNesting.Parts[index], ref Copied);
        if (Copied.ID <= 0)
        {
          clsInit.cNesting.GetAvailableNestingPartID(clsNesting.Parts, ref Copied.ID);
          clsNesting.Sheets[index].ID = Copied.ID;
        }
        this.FrmNestPanelPart.Parts.Add(Copied);
      }
      this.FrmNestPanelPart.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
      this.FrmNestPanelPart.Init(0);
      int num = (int) this.FrmNestPanelPart.ShowDialog();
      if (this.FrmNestPanelPart.PropertiesForm.Result != DialogResult.OK)
        return;
      this.PartUpdate();
      if (!this.FrmNestPanelPart.SendToCad)
        return;
      clsInit.appCommand.undoBuffer();
      for (int index = 0; index <= this.FrmNestPanelPart.SendToCadEntities.Count - 1; ++index)
      {
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(this.FrmNestPanelPart.SendToCadEntities[index]);
      }
    }
    else
      this.FrmNestPanelPart.Visible = false;
  }

  public void cmdNestingSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.FormCaption = "Nesting";
      classViewerDialog.Value = (object) clsPanelCut.varPanelCutSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 600;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsPanelCut.varPanelCutSettings = new PanelCutSettings((PanelCutSettings) classViewerDialog.Value);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdSimilation()
  {
    if (this.frmMachSim == null)
    {
      this.frmMachSim = new F_PanelCutMachSim();
      this.frmMachSim.ValueChanged += new ValueChangedWithDataEventHandler(this.SimValueChaned);
    }
    if (clsPanelCut.viewportAuto == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAuto, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = true,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAuto.Name = "ModelAuto";
      this.frmMachSim.pnl_viewport.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAuto);
      clsPanelCut.viewportAuto.MouseMove += new MouseEventHandler(this.method_0);
      clsPanelCut.viewportAuto.MouseDown += new MouseEventHandler(this.method_1);
      clsPanelCut.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
      for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
      {
        for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
        {
          Entity refEnt = buVector5.CopyEntities(ccVars.SimMachine.MachineParts[index1].Entities[index2]);
          refEnt.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.MachineParts,
            EntityName = ccVars.SimMachine.MachineParts[index1].PartName
          };
          refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsPanelCut.viewportAuto));
          string name = ((CustomData) refEnt.EntityData).EntityName;
          if (name.Length == 0)
            name = "Block" + index1.ToString();
          Block block = new Block(name);
          Entity entity = buVector5.CopyEntities(refEnt);
          entity.Color = Color.Linen;
          int alpha = (int) byte.MaxValue;
          if (ccVars.SimMachine.MachineParts[index1].Transparency >= 0 & ccVars.SimMachine.MachineParts[index1].Transparency <= (int) byte.MaxValue)
            alpha = ccVars.SimMachine.MachineParts[index1].Transparency;
          if (index1 <= ccVars.SimMachine.MachineParts.Count - 1)
            entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.MachineParts[index1].Color);
          entity.ColorMethod = colorMethodType.byEntity;
          block.Entities.Add(entity);
          clsPanelCut.viewportAuto.Blocks.Add(block);
        }
      }
      for (int index3 = 0; index3 < 8; ++index3)
      {
        for (int index4 = 0; index4 <= ccVars.SimMachine.Clampers.Count - 1; ++index4)
        {
          for (int index5 = 0; index5 <= ccVars.SimMachine.Clampers[index4].Entities.Count - 1; ++index5)
          {
            Entity refEnt = buVector5.CopyEntities(ccVars.SimMachine.Clampers[index4].Entities[index5]);
            refEnt.EntityData = (object) new CustomData()
            {
              typeDefination = entityTypeDefination.MachineParts,
              EntityName = ccVars.SimMachine.Clampers[index4].PartName
            };
            refEnt.Regen(new RegenParams(buSystem.RegenDeviation, (IWorkspace) clsPanelCut.viewportAuto));
            string name = ((CustomData) refEnt.EntityData).EntityName + index3.ToString();
            if (name.Length == 0)
              name = $"BlockClamper{index3.ToString()}{index4.ToString()}";
            Block block = new Block(name);
            Entity entity = buVector5.CopyEntities(refEnt);
            entity.Color = Color.Linen;
            int alpha = (int) byte.MaxValue;
            if (ccVars.SimMachine.Clampers[index4].Transparency >= 0 & ccVars.SimMachine.Clampers[index4].Transparency <= (int) byte.MaxValue)
              alpha = ccVars.SimMachine.Clampers[index4].Transparency;
            if (index4 <= ccVars.SimMachine.Clampers.Count - 1)
              entity.Color = Color.FromArgb(alpha, ccVars.SimMachine.Clampers[index4].Color);
            entity.ColorMethod = colorMethodType.byEntity;
            block.Entities.Add(entity);
            clsPanelCut.viewportAuto.Blocks.Add(block);
          }
        }
      }
    }
    if (clsPanelCut.viewportAutoPanel == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoPanel, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAutoPanel.Name = "ModelAutoPanel";
      this.frmMachSim.pnl_viewportpanel.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoPanel);
      clsPanelCut.viewportAuto.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (clsPanelCut.viewportAutoDone == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoDone, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAutoDone.Name = "ModelAutoDone";
      this.frmMachSim.pnl_viewportdone.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoDone);
      clsPanelCut.viewportAutoDone.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (clsPanelCut.viewportAutoWaiting == null)
    {
      clsInit.cVector5.CreateModelControl(ref clsPanelCut.viewportAutoWaiting, clsVar.UnlockKey, new CreateModelProperties()
      {
        CoordinateSystemIconVisible = false,
        OriginSymbolVisible = false,
        ViewCubeIconVisible = false,
        OrigineCaptionVisible = false,
        ToolBorVisible = false,
        BottomColor = Color.LightGray,
        MiddleColor = Color.WhiteSmoke,
        TopColor = Color.LightGray,
        PanMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.None
        },
        RotateMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Ctrl
        },
        ZoomMouseButtons = {
          Button = mouseButtonsZPR.Middle,
          ModifierKey = devDept.Eyeshot.Control.modifierKeys.Shift
        }
      });
      clsPanelCut.viewportAutoWaiting.Name = "ModelAutoWaiting";
      this.frmMachSim.pnl_viewportwaiting.Controls.Add((System.Windows.Forms.Control) clsPanelCut.viewportAutoWaiting);
      clsPanelCut.viewportAutoWaiting.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
    }
    if (clsPanelCut.viewportAuto.Layers.Count != ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count)
    {
      clsPanelCut.viewportAuto.Layers.Clear();
      for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; ++index)
        clsPanelCut.viewportAuto.Layers.Add((Layer) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[index].Clone());
    }
    this.JobToSimulationMoves();
    this.frmMachSim.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    this.frmMachSim.txt_gcode.Text = "";
    this.frmMachSim.Init();
    this.frmMachSim.txt_gcode.Text = buString5.StringListToString(this.activeJob.SimulationCodes, true);
    this.frmMachSim.StartPosition = FormStartPosition.CenterParent;
    int num = (int) this.frmMachSim.ShowDialog();
    if (this.frmMachSim.PropertiesForm.Result == DialogResult.OK)
      ;
  }

  public void cmdStartSimulation(bool Step)
  {
    this.timSim.Interval = 20;
    clsPanelCut.varPanelCutRunSettings.StepRun = Step;
    if (!clsPanelCut.viewportAuto.IsAnimationRunning)
      clsPanelCut.viewportAuto.StartAnimation(new int?(clsPanelCut.varPanelCutSettings.simulationInterval));
    if (this.indexSim == -1)
      this.indexSim = 0;
    if (this.indexSim == 0)
    {
      clsPanelCut.viewportAutoDone.Entities.Clear();
      clsPanelCut.viewportAutoWaiting.Entities.Clear();
      clsPanelCut.viewportAutoDone.Invalidate();
      clsPanelCut.viewportAutoWaiting.Invalidate();
      this.activeJob.DoneParts.Clear();
      this.activeJob.WaitingAssembly.Clear();
    }
    this.timSim.Enabled = true;
    if (!Step)
    {
      clsPanelCut.varPanelCutRunSettings.StepRun = false;
      clsPanelCut.viewportAuto.Entities.ClearSelection();
      clsPanelCut.viewportAuto.Invalidate();
    }
    else
    {
      if (!(clsPanelCut.varPanelCutRunSettings.StepRun & Step))
        return;
      clsPanelCut.varTemps.simRelease = true;
    }
  }

  public void cmdStopSimulation()
  {
    if (this.timSim.Enabled)
    {
      this.timSim.Enabled = false;
    }
    else
    {
      this.indexSim = 0;
      this.timSim.Enabled = false;
      this.isCollisionRunning = false;
      this.SimFinished();
    }
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    string str = "";
    if (sender is System.Windows.Forms.Control)
      str = (sender as System.Windows.Forms.Control).Name;
    else if (sender is ToolStripMenuItem)
      str = (sender as ToolStripMenuItem).Name;
    if (str == clsItem.FrmPanelCutJob.btn_viewfront.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Front);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (str == clsItem.FrmPanelCutJob.btn_viewleft.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Left);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (str == clsItem.FrmPanelCutJob.btn_viewiso.Name)
    {
      clsItem.ModelMainPreview.SetView(viewType.Isometric);
      clsItem.ModelMainPreview.Invalidate();
    }
    if (!(str == clsItem.FrmPanelCutJob.btn_zoomfit.Name))
      return;
    clsItem.ModelMainPreview.ZoomFit();
    clsItem.ModelMainPreview.Invalidate();
  }

  public void cmdSetView(viewType Type)
  {
    switch (Type)
    {
      case viewType.Front:
        buEyeShotFunctions.Viewfront(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.XZ;
        break;
      case viewType.Right:
        buEyeShotFunctions.ViewRight(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.YZ;
        break;
      case viewType.Rear:
        buEyeShotFunctions.ViewBack(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.XZ;
        break;
      case viewType.Left:
        buEyeShotFunctions.ViewLeft(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.YZ;
        break;
      case viewType.Top:
        buEyeShotFunctions.ViewTop(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.XY;
        break;
      case viewType.Bottom:
        buEyeShotFunctions.ShowViewportViewBox(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.XY;
        break;
      default:
        buEyeShotFunctions.ViewIso(ref clsPanelCut.viewportAuto, false);
        clsInit.appPanelCut.planeActive = Plane.XY;
        break;
    }
  }

  public void cmdZoomFit() => buEyeShotFunctions.ZoomFit(ref clsPanelCut.viewportAuto);

  public void cmdBarCode()
  {
    F_BarCode fBarCode = new F_BarCode();
    fBarCode.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
    fBarCode.StartPosition = FormStartPosition.CenterParent;
    fBarCode.Init();
    int num = (int) fBarCode.ShowDialog();
  }

  public void cmdQRCode()
  {
  }

  public void cmdShowCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString5.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        if (this.activeJob.Panels.Count == 0)
          return;
        clsPanelCut.varTemps.OffcutCount = 0;
        ArrayList arrayList = new ArrayList();
        string Code = "";
        this.doCreateCode(ref Code);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Code);
        fNotepad.Show();
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private void method_0(object sender, MouseEventArgs e)
  {
    System.Windows.Forms.Control control = new System.Windows.Forms.Control();
    if (!(((System.Windows.Forms.Control) sender).Name == clsPanelCut.viewportAuto.Name))
      return;
    Point3D intPoint = new Point3D();
    clsPanelCut.viewportAuto.ScreenToPlane(e.Location, clsInit.appPanelCut.planeActive, out intPoint);
    if (!(intPoint != (Point3D) null))
      return;
    this.frmMachSim.lbl_x.Text = "X: " + intPoint.X.ToString("f3");
    this.frmMachSim.lbl_y.Text = "Y: " + intPoint.Y.ToString("f3");
    this.frmMachSim.lbl_z.Text = "Z: " + intPoint.Z.ToString("f3");
  }

  private void method_1(object sender, MouseEventArgs e)
  {
  }

  public void DrawEntities(bool ZoomFit)
  {
    clsPanelCut.viewportAuto.Entities.Clear();
    clsPanelCut.viewportAutoPanel.Entities.Clear();
    clsPanelCut.viewportAutoDone.Entities.Clear();
    clsPanelCut.viewportAutoWaiting.Entities.Clear();
    clsPanelCut.SimMovePartIndex.Clear();
    List<Entity> PartEntities = new List<Entity>();
    this.DrawNodesParts(this.activeJob.Panels[this.JobIndex].Nodes, this.activeJob.Panels[this.JobIndex].Depth, 0, ref PartEntities);
    if (PartEntities.Count > 0)
    {
      List<Point3D> Vertices = new List<Point3D>();
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[0].Rectangle, ref Vertices);
      Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) Vertices)).ExtrudeAsMesh(19.0, 0.1, Mesh.natureType.RichSmooth);
      mesh.Color = Color.FromArgb(150, Color.Gold);
      mesh.ColorMethod = colorMethodType.byEntity;
      mesh.Selectable = false;
      mesh.Translate(0.0, 0.0);
      for (int index = 0; index <= PartEntities.Count - 1; ++index)
      {
        PartEntities[index].Translate(0.0, 0.0);
        clsPanelCut.viewportAutoPanel.Entities.Add(PartEntities[index]);
      }
    }
    for (int index1 = 0; index1 <= ccVars.SimMachine.MachineParts.Count - 1; ++index1)
    {
      for (int index2 = 0; index2 <= ccVars.SimMachine.MachineParts[index1].Entities.Count - 1; ++index2)
      {
        buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.MachineParts[index1].PartName);
        buMachinePart.ARotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.A;
        buMachinePart.BRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.B;
        buMachinePart.CRotation = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.C;
        buMachinePart.XMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.X;
        buMachinePart.YMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Y;
        buMachinePart.ZMove = ccVars.SimMachine.MachineParts[index1].MoveAxisPermision.Z;
        buMachinePart.xRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.X;
        buMachinePart.yRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Y;
        buMachinePart.zRot = ccVars.SimMachine.MachineParts[index1].RotationCenter.Z;
        buMachinePart.Color = ccVars.SimMachine.MachineParts[index1].Color;
        buMachinePart.ColorMethod = colorMethodType.byEntity;
        double num = 0.0;
        double dx = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.X + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.X;
        double dy = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Y + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Y;
        double dz = ccVars.SimMachine.MachineParts[index1].PositionBaseOffset.Z + ccVars.SimMachine.MachineParts[index1].PositionAuxOffset.Z + num;
        buMachinePart.Translate(dx, dy, dz);
        buMachinePart.Tag = ccVars.SimMachine.MachineParts[index1].Tag;
        buMachinePart.No = ccVars.SimMachine.MachineParts[index1].No;
        buMachinePart.EntityData = (object) new CustomData()
        {
          typeDefination = entityTypeDefination.MachineBody,
          OriginalEntityIndex = clsPanelCut.viewportAuto.Entities.Count
        };
        clsPanelCut.viewportAuto.Entities.Add((Entity) buMachinePart);
        clsPanelCut.SimMovePartIndex.Add(clsPanelCut.viewportAuto.Entities.Count - 1);
      }
    }
    for (int index3 = 0; index3 < 8; ++index3)
    {
      for (int index4 = 0; index4 <= ccVars.SimMachine.Clampers.Count - 1; ++index4)
      {
        for (int index5 = 0; index5 <= ccVars.SimMachine.Clampers[index4].Entities.Count - 1; ++index5)
        {
          buMachinePart buMachinePart = new buMachinePart(ccVars.SimMachine.Clampers[index4].PartName + index3.ToString());
          buMachinePart.ARotation = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.A;
          buMachinePart.BRotation = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.B;
          buMachinePart.CRotation = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.C;
          buMachinePart.XMove = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.X;
          buMachinePart.YMove = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.Y;
          buMachinePart.ZMove = ccVars.SimMachine.Clampers[index4].MoveAxisPermision.Z;
          buMachinePart.xRot = ccVars.SimMachine.Clampers[index4].RotationCenter.X;
          buMachinePart.yRot = ccVars.SimMachine.Clampers[index4].RotationCenter.Y;
          buMachinePart.zRot = ccVars.SimMachine.Clampers[index4].RotationCenter.Z;
          buMachinePart.Color = ccVars.SimMachine.Clampers[index4].Color;
          buMachinePart.ColorMethod = colorMethodType.byEntity;
          double num1 = 0.0;
          double dx = ccVars.SimMachine.Clampers[index4].PositionBaseOffset.X + ccVars.SimMachine.Clampers[index4].PositionAuxOffset.X;
          double num2 = ccVars.SimMachine.Clampers[index4].PositionBaseOffset.Y + ccVars.SimMachine.Clampers[index4].PositionAuxOffset.Y;
          double dz = ccVars.SimMachine.Clampers[index4].PositionBaseOffset.Z + ccVars.SimMachine.Clampers[index4].PositionAuxOffset.Z + num1;
          buMachinePart.Translate(dx, num2 - (double) index3 * 500.0, dz);
          buMachinePart.Tag = ccVars.SimMachine.Clampers[index4].Tag;
          buMachinePart.No = ccVars.SimMachine.Clampers[index4].No;
          buMachinePart.EntityData = (object) new CustomData()
          {
            typeDefination = entityTypeDefination.MachineParts,
            OriginalEntityIndex = clsPanelCut.viewportAuto.Entities.Count
          };
          clsPanelCut.viewportAuto.Entities.Add((Entity) buMachinePart);
          clsPanelCut.SimMovePartIndex.Add(clsPanelCut.viewportAuto.Entities.Count - 1);
        }
      }
    }
    if (this.activeJob != null)
      ;
  }

  public void RemoveMaterial()
  {
    for (int index = clsPanelCut.viewportAuto.Entities.Count - 1; index >= 0; --index)
    {
      if (clsPanelCut.viewportAuto.Entities[index] is buMaterialMoveable)
      {
        clsPanelCut.viewportAuto.Entities[index].Selected = true;
        if (clsPanelCut.SimMovePartIndex.Count > 0 & index <= clsPanelCut.SimMovePartIndex.Count - 1)
          clsPanelCut.SimMovePartIndex.RemoveAt(index);
      }
    }
    clsPanelCut.viewportAuto.Entities.DeleteSelected();
    clsPanelCut.viewportAuto.Invalidate();
  }

  public void AddMaterial(double Width, double Height, double Depth, double XPos)
  {
    if (!(Width > 0.0 & Height > 0.0 & Depth > 0.0))
      return;
    buMaterialMoveable materialMoveable = new buMaterialMoveable("MaterialWood");
    materialMoveable.XMove = true;
    Mesh box = Mesh.CreateBox(Width, Height, Depth, Mesh.natureType.RichSmooth);
    box.ColorMethod = colorMethodType.byEntity;
    box.Color = Color.Gold;
    box.Translate(XPos, -Height);
    Block block = new Block("MaterialWood");
    block.Entities.Add((Entity) box);
    for (int index = clsPanelCut.viewportAuto.Blocks.Count - 1; index >= 0; --index)
    {
      if (clsPanelCut.viewportAuto.Blocks[index].Name == "MaterialWood")
        clsPanelCut.viewportAuto.Blocks.RemoveAt(index);
    }
    clsPanelCut.viewportAuto.Blocks.Add(block);
    materialMoveable.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Material,
      OriginalEntityIndex = clsPanelCut.viewportAuto.Entities.Count
    };
    clsPanelCut.viewportAuto.Entities.Add((Entity) materialMoveable);
    clsPanelCut.SimMovePartIndex.Add(clsPanelCut.viewportAuto.Entities.Count - 1);
    clsPanelCut.viewportAuto.Invalidate();
  }

  public void AddMaterial(
    Rectangle2D Panel,
    List<Rectangle2D> CutLines,
    double Depth,
    double XPos)
  {
    if (!(Panel.Width > 0.0 & Panel.Height > 0.0 & Depth > 0.0))
      return;
    buMaterialMoveable materialMoveable1 = new buMaterialMoveable("MaterialWood");
    materialMoveable1.XMove = true;
    Mesh box1 = Mesh.CreateBox(Panel.Width, Panel.Height, Depth, Mesh.natureType.RichSmooth);
    box1.ColorMethod = colorMethodType.byEntity;
    box1.Color = Color.FromArgb(150, Color.Gold);
    box1.Translate(XPos, -Panel.Height);
    Block block1 = new Block("MaterialWood");
    block1.Entities.Add((Entity) box1);
    for (int index = clsPanelCut.viewportAuto.Blocks.Count - 1; index >= 0; --index)
    {
      if (clsPanelCut.viewportAuto.Blocks[index].Name == "MaterialWood")
        clsPanelCut.viewportAuto.Blocks.RemoveAt(index);
    }
    clsPanelCut.viewportAuto.Blocks.Add(block1);
    materialMoveable1.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Material,
      OriginalEntityIndex = clsPanelCut.viewportAuto.Entities.Count
    };
    clsPanelCut.viewportAuto.Entities.Add((Entity) materialMoveable1);
    clsPanelCut.SimMovePartIndex.Add(clsPanelCut.viewportAuto.Entities.Count - 1);
    for (int index1 = 0; index1 <= CutLines.Count - 1; ++index1)
    {
      buMaterialMoveable materialMoveable2 = new buMaterialMoveable("MaterialWood" + index1.ToString());
      materialMoveable2.XMove = true;
      Mesh box2 = Mesh.CreateBox(CutLines[index1].Width, CutLines[index1].Height, Depth, Mesh.natureType.RichSmooth);
      box2.Translate(CutLines[index1].StartPoint.X, 0.0);
      box2.ColorMethod = colorMethodType.byEntity;
      box2.Color = Color.FromArgb((int) byte.MaxValue, Color.Red);
      box2.Translate(XPos, -Panel.Height);
      Block block2 = new Block("MaterialWood" + index1.ToString());
      block2.Entities.Add((Entity) box2);
      for (int index2 = clsPanelCut.viewportAuto.Blocks.Count - 1; index2 >= 0; --index2)
      {
        if (clsPanelCut.viewportAuto.Blocks[index2].Name == "MaterialWood" + index1.ToString())
          clsPanelCut.viewportAuto.Blocks.RemoveAt(index2);
      }
      clsPanelCut.viewportAuto.Blocks.Add(block2);
      materialMoveable2.EntityData = (object) new CustomData()
      {
        typeDefination = entityTypeDefination.Material,
        OriginalEntityIndex = clsPanelCut.viewportAuto.Entities.Count
      };
      clsPanelCut.viewportAuto.Entities.Add((Entity) materialMoveable2);
      clsPanelCut.SimMovePartIndex.Add(clsPanelCut.viewportAuto.Entities.Count - 1);
    }
    clsPanelCut.viewportAuto.Invalidate();
  }

  public void AddFinishedPart(PanelDonePart Part)
  {
    try
    {
      if (this.activeJob.DoneParts.Count == 0)
      {
        Part.Count = 1;
        this.activeJob.DoneParts.Add(Part);
      }
      else
      {
        bool flag = false;
        for (int index = 0; index <= this.activeJob.DoneParts.Count - 1; ++index)
        {
          if (this.activeJob.DoneParts[index].PartID == Part.PartID)
          {
            ++this.activeJob.DoneParts[index].Count;
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          Part.Count = 1;
          this.activeJob.DoneParts.Add(Part);
        }
      }
      double dx = 0.0;
      clsPanelCut.viewportAutoDone.Entities.Clear();
      for (int index = 0; index <= this.activeJob.DoneParts.Count - 1; ++index)
      {
        Color color = Color.LightSteelBlue;
        if (this.activeJob.DoneParts[index].PartID >= 0 & this.activeJob.DoneParts[index].PartID <= buImage5.ColorList.Count - 1)
        {
          int lower = (int) buNumeric5.RoundToLower((double) this.activeJob.DoneParts[index].PartID / 2.0);
          color = buImage5.ColorList[lower];
        }
        Mesh partEntity = (Mesh) null;
        Rectangle2D foundRect = (Rectangle2D) null;
        clsInit.cPanelCut.GetPartFromPartListWithID(this.activeJob.Parts, this.activeJob.Panels[this.JobIndex].Depth, this.activeJob.DoneParts[index].PartID, color, false, ref partEntity, ref foundRect);
        partEntity.Translate(dx, 0.0);
        clsPanelCut.viewportAutoDone.Entities.Add((Entity) partEntity);
        Point3D Center = new Point3D();
        Rectangle2D.Rectangle2DCenter(foundRect, ref Center);
        Text text = new Text(Plane.XY, new Point3D(Center.X + dx, Center.Y, this.activeJob.Panels[this.JobIndex].Depth + 2.0), this.activeJob.DoneParts[index].Count.ToString(), 40.0, Text.alignmentType.MiddleCenter);
        text.Color = Color.Black;
        text.ColorMethod = colorMethodType.byEntity;
        clsPanelCut.viewportAutoDone.Entities.Add((Entity) text);
        dx = foundRect.Width <= foundRect.Height ? dx + foundRect.Height + 30.0 : dx + foundRect.Width + 30.0;
      }
      clsPanelCut.viewportAutoDone.SetView(viewType.Top);
      clsPanelCut.viewportAutoDone.ZoomFit(10);
      clsPanelCut.viewportAutoDone.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void AddAssemblyPart(PanelWaitAssembly Assembly)
  {
    this.activeJob.WaitingAssembly.Add(Assembly);
    double dx = 0.0;
    clsPanelCut.viewportAutoWaiting.Entities.Clear();
    for (int index = 0; index <= this.activeJob.WaitingAssembly.Count - 1; ++index)
    {
      Color darkOrange = Color.DarkOrange;
      Mesh meshPanel = (Mesh) null;
      Rectangle2D rect = new Rectangle2D(this.activeJob.WaitingAssembly[index].Panel);
      clsInit.cPanelCut.RectangleToMesh(this.activeJob.WaitingAssembly[index].Panel, this.activeJob.Panels[this.JobIndex].Depth, darkOrange, 0, -1, -1, (NestingPanelNode) null, ref meshPanel);
      meshPanel.Translate(dx, 0.0);
      clsPanelCut.viewportAutoDone.Entities.Add((Entity) meshPanel);
      Point3D Center = new Point3D();
      Rectangle2D.Rectangle2DCenter(rect, ref Center);
      Text text = new Text(Plane.XY, new Point3D(Center.X + dx, Center.Y, this.activeJob.Panels[this.JobIndex].Depth + 2.0), this.activeJob.WaitingAssembly[index].Panel.Width.ToString(), 40.0, Text.alignmentType.MiddleCenter);
      text.Color = Color.Black;
      text.ColorMethod = colorMethodType.byEntity;
      clsPanelCut.viewportAutoDone.Entities.Add((Entity) text);
      dx = rect.Width <= rect.Height ? dx + rect.Height + 30.0 : dx + rect.Width + 30.0;
    }
    clsPanelCut.viewportAutoWaiting.SetView(viewType.Top);
    clsPanelCut.viewportAutoWaiting.ZoomFit(10);
    clsPanelCut.viewportAutoWaiting.Invalidate();
  }

  public void SimValueChaned(double Value, object Data)
  {
    if (Data == null || Data.ToString() == "Track")
      ;
  }

  public void tick_Simulation(object sender, EventArgs e)
  {
    if (!(!clsPanelCut.varPanelCutRunSettings.StepRun | clsPanelCut.varPanelCutRunSettings.StepRun & clsPanelCut.varTemps.simRelease))
      return;
    clsPanelCut.varTemps.simRelease = false;
    if (this.activeJob != null)
    {
      if (this.indexSim >= 0 & this.indexSim <= this.activeJob.SimulationMoves.Count - 1)
      {
        PanelCutMove simulationMove = this.activeJob.SimulationMoves[this.indexSim];
        clsPanelCut.varTemps.acliveLine = this.activeJob.SimulationMoves[this.indexSim].Index;
        if (this.activeJob.SimulationMoves[this.indexSim].Command == PanelCutMoveCommand.PartFinished)
          this.AddFinishedPart(new PanelDonePart()
          {
            PartID = simulationMove.PartID
          });
        if (this.activeJob.SimulationMoves[this.indexSim].Command == PanelCutMoveCommand.RemoveMaterial)
          this.RemoveMaterial();
        if (this.activeJob.SimulationMoves[this.indexSim].Command == PanelCutMoveCommand.AddMaterial)
        {
          this.RemoveMaterial();
          this.AddMaterial(this.activeJob.SimulationMoves[this.indexSim].Panel, this.activeJob.SimulationMoves[this.indexSim].SawCutRectangles, 18.0, this.activeJob.SimulationMoves[this.indexSim].XPosition);
        }
        if (this.activeJob.SimulationMoves[this.indexSim].Command == PanelCutMoveCommand.CutMaterial)
          ;
        if (this.indexSim >= 0 & this.indexSim <= this.activeJob.SimulationMoves.Count - 1)
        {
          this.MoveSimPart(new PanelCutMove(this.activeJob.SimulationMoves[this.indexSim]));
          if (this.frmMachSim != null)
          {
            this.frmMachSim.lbl_x.Text = "X: " + this.activeJob.SimulationMoves[this.indexSim].Position.X.ToString("f2");
            this.frmMachSim.lbl_y.Text = "Y: " + this.activeJob.SimulationMoves[this.indexSim].Position.Y.ToString("f2");
            this.frmMachSim.lbl_z.Text = "Z: " + this.activeJob.SimulationMoves[this.indexSim].Position.Z.ToString("f2");
          }
        }
        this.indexSim += clsPanelCut.varPanelCutRunSettings.SimStep;
      }
      else
      {
        this.indexSim = -1;
        this.timSim.Enabled = false;
        clsPanelCut.varTemps.acliveLine = -1;
        this.SimFinished();
      }
    }
    else
    {
      clsPanelCut.varTemps.acliveLine = -1;
      this.timSim.Enabled = false;
      this.SimFinished();
    }
    if (this.frmMachSim == null)
      return;
    if (clsPanelCut.varTemps.acliveLine > 0 & clsPanelCut.varTemps.acliveLine <= this.frmMachSim.txt_gcode.TextSource.Count - 1)
    {
      this.frmMachSim.txt_gcode.Selection.Start = new Place()
      {
        iLine = clsPanelCut.varTemps.acliveLine
      };
      Place place = new Place();
      place.iLine = clsPanelCut.varTemps.acliveLine + 1;
      this.frmMachSim.txt_gcode.Selection.End = place;
      this.frmMachSim.txt_gcode.Refresh();
      if (place.iLine <= this.frmMachSim.txt_gcode.Lines.Count - 1)
        this.frmMachSim.txt_gcode.DoSelectionVisible();
    }
    if (!(clsPanelCut.varTemps.acliveLine == -1 & this.frmMachSim.txt_gcode.TextSource.Count > 0))
      return;
    this.frmMachSim.txt_gcode.Selection.Start = new Place()
    {
      iLine = 0
    };
    Place place1 = new Place();
    place1.iLine = 1;
    this.frmMachSim.txt_gcode.Selection.End = place1;
    this.frmMachSim.txt_gcode.Refresh();
    if (place1.iLine > this.frmMachSim.txt_gcode.Lines.Count - 1)
      return;
    this.frmMachSim.txt_gcode.DoSelectionVisible();
  }

  public void SimFinished()
  {
    for (int index = 0; index <= clsPanelCut.viewportAutoPanel.Entities.Count - 1; ++index)
      clsPanelCut.viewportAutoPanel.Entities[index].Selected = false;
    clsPanelCut.viewportAutoPanel.Invalidate();
  }

  public void MoveSimPart(PanelCutMove pntMove)
  {
    for (int index = 0; index <= clsPanelCut.viewportAutoPanel.Entities.Count - 1; ++index)
    {
      clsPanelCut.viewportAutoPanel.Entities[index].Selected = false;
      if (clsPanelCut.viewportAutoPanel.Entities[index].EntityData != null && clsPanelCut.viewportAutoPanel.Entities[index].EntityData is PanelEntityData && (clsPanelCut.viewportAutoPanel.Entities[index].EntityData as PanelEntityData).NodeID == pntMove.NodeID)
        clsPanelCut.viewportAutoPanel.Entities[index].Selected = true;
    }
    if (clsPanelCut.viewportAutoPanel.Entities.Count > 0)
      clsPanelCut.viewportAutoPanel.Invalidate();
    for (int index = 0; index <= clsPanelCut.SimMovePartIndex.Count - 1; ++index)
    {
      int num1 = clsPanelCut.SimMovePartIndex[index];
      if (num1 >= 0 & num1 <= clsPanelCut.viewportAuto.Entities.Count - 1)
      {
        CustomData entityData = clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]].EntityData as CustomData;
        KinematicBase5 kinematicBase5 = new KinematicBase5()
        {
          RotateCenterOffsetOfA = {
            Z = 171.0
          },
          Type = KinemeticType.CartezianXYZ_WristA_4Axis
        };
        Pnt6D pnt6D = new Pnt6D();
        Point3D point3D = new Point3D();
        int num2 = clsPanelCut.SimMovePartIndex[index];
        if (clsPanelCut.SimMovePartIndex[index] >= 0 & clsPanelCut.SimMovePartIndex[index] <= clsPanelCut.viewportAuto.Entities.Count - 1)
        {
          if (clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]].GetType() == typeof (buTool))
          {
            buTool entity = clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]] as buTool;
            string blockName = ((BlockReference) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).BlockName;
            if (entity.Tag != null)
              ;
          }
          if (clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]].GetType() == typeof (buMaterialMoveable))
            ((buMaterialMoveable) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).xPos = pntMove.Position.X;
          if (clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]].GetType() == typeof (buMachinePart))
          {
            buMachinePart entity = clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]] as buMachinePart;
            if (entityData.typeDefination == entityTypeDefination.MachineBody | entityData.typeDefination == entityTypeDefination.MachineParts)
            {
              string blockName = ((BlockReference) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).BlockName;
              ((buMachinePart) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).xPos = pntMove.Position.X;
              ((buMachinePart) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).yPos = pntMove.Position.Y;
              ((buMachinePart) clsPanelCut.viewportAuto.Entities[clsPanelCut.SimMovePartIndex[index]]).zPos = pntMove.Position.Z;
            }
          }
        }
      }
    }
    clsPanelCut.viewportAuto.Entities.Regen();
    if (!clsPanelCut.viewportAuto.IsAnimationRunning)
      ;
  }

  public void JobToSimulationMoves()
  {
    if (this.activeJob == null)
    {
      int num = (int) MessageBox.Show("No Acitve Job");
    }
    this.activeJob.SimulationMoves.Clear();
    this.activeJob.SimulationCodes.Clear();
    this.activeJob.WaitingAssembly.Clear();
    this.activeJob.DoneParts.Clear();
    clsPanelCut.viewportAutoDone.Entities.Clear();
    clsPanelCut.viewportAutoWaiting.Entities.Clear();
    clsPanelCut.viewportAutoDone.Invalidate();
    clsPanelCut.viewportAutoWaiting.Invalidate();
    this.MoveIndex = 0;
    if (this.activeJob.Panels.Count <= 0)
      return;
    int index1 = 0;
    for (int index2 = 0; index2 <= this.activeJob.Panels[this.JobIndex].Nodes.Count - 1; ++index2)
    {
      NestingPanelNode node = this.activeJob.Panels[this.JobIndex].Nodes[index2];
      this.GetMove(node, index1);
      ++index1;
      for (int index3 = 0; index3 <= node.Node.Count - 1; ++index3)
      {
        NestingPanelNode Node1 = node.Node[index3];
        this.GetMove(Node1, index1);
        ++index1;
        for (int index4 = 0; index4 <= Node1.Node.Count - 1; ++index4)
        {
          NestingPanelNode Node2 = Node1.Node[index4];
          this.GetMove(Node2, index1);
          ++index1;
          for (int index5 = 0; index5 <= Node2.Node.Count - 1; ++index5)
          {
            NestingPanelNode Node3 = Node2.Node[index5];
            this.GetMove(Node3, index1);
            ++index1;
            for (int index6 = 0; index6 <= Node3.Node.Count - 1; ++index6)
            {
              NestingPanelNode Node4 = Node3.Node[index6];
              this.GetMove(Node4, index1);
              ++index1;
              for (int index7 = 0; index7 <= Node4.Node.Count - 1; ++index7)
              {
                this.GetMove(Node4.Node[index7], index1);
                ++index1;
              }
            }
          }
        }
      }
    }
  }

  public void GetMove(NestingPanelNode Node, int index)
  {
    double num1 = 0.0;
    double num2 = 0.0;
    double sawThickness = clsPanelCut.varPanelCutSettings.SawThickness;
    int countStep1 = 3;
    PanelCutMove panelCutMove1 = new PanelCutMove();
    int count = this.activeJob.Parts.Count;
    if (Node.NodeType == nestPanelNodeType.Assembly)
    {
      if (index == 0)
      {
        if (Node.Direction == DirectionXandY.XDirection)
        {
          PanelCutMove panelCutMove2 = new PanelCutMove();
          panelCutMove2.Position.X = 0.0;
          panelCutMove2.Position.Y = 0.0;
          panelCutMove2.XPosition = -Node.DimensionX;
          panelCutMove2.Command = PanelCutMoveCommand.AddMaterial;
          panelCutMove2.Panel = new Rectangle2D(Node.DimensionX, Node.DimensionY);
          panelCutMove2.Index = this.MoveIndex;
          panelCutMove2.NodeID = Node.NodeID;
          panelCutMove2.NodeType = Node.NodeType;
          this.activeJob.SimulationMoves.Add(panelCutMove2);
          this.activeJob.SimulationCodes.Add($"Assembly ({Node.DimensionX.ToString("f2")} , {Node.DimensionY.ToString("f2")})");
          this.CreateSimMoveXStep(this.MoveIndex, Node, 10, 0.0, 0.0, Node.DimensionX);
          ++this.MoveIndex;
        }
      }
      else if (Node.Direction == DirectionXandY.YDirection)
      {
        if (Node.BaseRectangle != null)
        {
          PanelCutMove panelCutMove3 = new PanelCutMove();
          panelCutMove3.Position.X = Node.BaseRectangle.Width;
          panelCutMove3.Position.Y = 0.0;
          panelCutMove3.XPosition = -Node.BaseRectangle.Width;
          panelCutMove3.Command = PanelCutMoveCommand.AddMaterial;
          panelCutMove3.Panel = new Rectangle2D(Node.BaseRectangle.Width, Node.BaseRectangle.Height);
          Rectangle2D rectangle2D = new Rectangle2D(new Point3D(Node.CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.CutSawDistance);
          panelCutMove3.SawCutRectangles.Add(rectangle2D);
          panelCutMove3.Index = this.MoveIndex;
          panelCutMove3.NodeID = Node.NodeID;
          panelCutMove3.NodeType = Node.NodeType;
          this.activeJob.SimulationMoves.Add(panelCutMove3);
          this.activeJob.SimulationCodes.Add($"Assembly ({Node.DimensionX.ToString("f2")} , {Node.DimensionY.ToString("f2")})");
          double x1 = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
          this.CreateSimMoveXStep(this.MoveIndex, Node, countStep1, 0.0, x1, -Node.DimensionX);
          double x2 = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
          int countStep2 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionY, clsPanelCut.varPanelCutSettings.CutSimDevideLen);
          this.CreateSimMoveYCut(this.MoveIndex, Node, countStep2, x2, 0.0, Node.DimensionY);
          PanelCutMove panelCutMove4 = new PanelCutMove();
          panelCutMove4.Position.X = x2;
          panelCutMove4.Position.Y = 0.0;
          panelCutMove4.Index = this.MoveIndex;
          panelCutMove4.NodeID = Node.NodeID;
          panelCutMove4.NodeType = Node.NodeType;
          this.activeJob.SimulationMoves.Add(panelCutMove4);
          double x3 = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
          this.CreateSimMoveXStep(this.MoveIndex, Node, countStep1, 0.0, x3, -(Node.BaseRectangle.Width - Node.DimensionX));
          ++this.MoveIndex;
        }
        else
        {
          PanelCutMove panelCutMove5 = new PanelCutMove();
          panelCutMove5.Position.X = 0.0;
          panelCutMove5.Position.Y = 0.0;
          panelCutMove5.XPosition = -Node.DimensionY;
          panelCutMove5.Command = PanelCutMoveCommand.AddMaterial;
          panelCutMove5.Panel = new Rectangle2D(Node.DimensionY, Node.DimensionX);
          panelCutMove5.Index = this.MoveIndex;
          panelCutMove5.NodeID = Node.NodeID;
          panelCutMove5.NodeType = Node.NodeType;
          this.activeJob.SimulationMoves.Add(panelCutMove5);
          this.activeJob.SimulationCodes.Add($"Assembly ({Node.DimensionX.ToString("f2")} , {Node.DimensionY.ToString("f2")})");
          this.CreateSimMoveXStep(this.MoveIndex, Node, countStep1, 0.0, 0.0, Node.DimensionY);
          ++this.MoveIndex;
        }
      }
    }
    if (Node.NodeType == nestPanelNodeType.Module)
    {
      PanelCutMove panelCutMove6 = new PanelCutMove();
      panelCutMove6.Position.X = Node.BaseRectangle.Height;
      panelCutMove6.Position.Y = 0.0;
      panelCutMove6.XPosition = -Node.BaseRectangle.Height;
      panelCutMove6.Command = PanelCutMoveCommand.AddMaterial;
      panelCutMove6.Panel = new Rectangle2D(Node.BaseRectangle.Height, Node.BaseRectangle.Width);
      panelCutMove6.NodeID = Node.NodeID;
      panelCutMove6.NodeType = Node.NodeType;
      Rectangle2D rectangle2D1 = new Rectangle2D(new Point3D(Node.CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.CutSawDistance);
      panelCutMove6.SawCutRectangles.Add(rectangle2D1);
      this.activeJob.SimulationMoves.Add(panelCutMove6);
      this.CreateSimMoveXStep(this.MoveIndex, Node, countStep1, 0.0, panelCutMove6.Position.X, -Node.DimensionY);
      double x4 = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
      int countStep3 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionX, clsPanelCut.varPanelCutSettings.CutSimDevideLen);
      this.CreateSimMoveYCut(this.MoveIndex, Node, countStep3, x4, 0.0, Node.DimensionX);
      PanelCutMove panelCutMove7 = new PanelCutMove();
      panelCutMove7.Position.X = x4;
      panelCutMove7.Position.Y = 0.0;
      panelCutMove7.Index = this.MoveIndex;
      this.activeJob.SimulationMoves.Add(panelCutMove7);
      this.activeJob.SimulationCodes.Add($"  Module ({Node.DimensionX.ToString("f2")} , {Node.DimensionY.ToString("f2")})");
      double x5 = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
      this.CreateSimMoveXStep(this.MoveIndex, Node, countStep1, 0.0, x5, -x5);
      ++this.MoveIndex;
      num1 = 0.0;
      int num3 = Node.Node.Count - 1;
      for (int index1 = 0; index1 < num3; ++index1)
      {
        double num4 = Node.Node[index1].DimensionX + sawThickness;
        double LastX = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X;
        if (index1 == 0)
        {
          panelCutMove7 = new PanelCutMove();
          panelCutMove7.Position.X = Node.DimensionX;
          panelCutMove7.Position.Y = 0.0;
          panelCutMove7.XPosition = -Node.DimensionX;
          panelCutMove7.Command = PanelCutMoveCommand.AddMaterial;
          panelCutMove7.Panel = new Rectangle2D(Node.DimensionX, Node.DimensionY);
          panelCutMove7.Index = this.MoveIndex;
          panelCutMove7.NodeID = Node.Node[index1].NodeID;
          panelCutMove7.NodeType = Node.Node[index1].NodeType;
          this.activeJob.SimulationMoves.Add(panelCutMove7);
          LastX = Node.DimensionX;
          num4 = Node.Node[index1].DimensionX + sawThickness / 2.0;
        }
        Rectangle2D rectangle2D2 = new Rectangle2D(new Point3D(Node.Node[index1].CutFeedDistance - Node.CutOffset - sawThickness / 2.0, 0.0), sawThickness, Node.Node[index1].CutSawDistance);
        panelCutMove7.SawCutRectangles.Add(rectangle2D2);
        this.CreateSimMoveXStep(this.MoveIndex, Node.Node[index1], countStep1, 0.0, LastX, -num4);
        int countStep4 = clsInit.cPanelCut.SimCountFromLength(Node.DimensionY, clsPanelCut.varPanelCutSettings.CutSimDevideLen);
        this.CreateSimMoveYCut(this.MoveIndex, Node.Node[index1], countStep4, this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X, 0.0, Node.DimensionY);
        this.activeJob.SimulationCodes.Add($"    Cut ({(Node.Node[index1].CutFeedDistance - Node.CutOffset).ToString("f2")})");
        if (Node.Node[index1].Node.Count == 0)
        {
          panelCutMove7 = new PanelCutMove();
          panelCutMove7.Position = buVector5.ToPoint3D(this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position);
          panelCutMove7.Command = PanelCutMoveCommand.PartFinished;
          panelCutMove7.Panel = new Rectangle2D(Node.Node[index1].Rectangle);
          panelCutMove7.PartID = Node.Node[index1].PartID;
          this.activeJob.SimulationMoves.Add(panelCutMove7);
        }
        ++this.MoveIndex;
      }
      double LastX1 = 0.0;
      int num5 = 1;
      for (int index2 = 0; index2 <= Node.Node.Count - 1; ++index2)
      {
        for (int index3 = 0; index3 <= Node.Node[index2].Node.Count - 1; ++index3)
        {
          NestingPanelNode node = Node.Node[index2].Node[index3];
          double num6;
          if (index3 == 0)
          {
            num2 = node.CutLine.StartPoint.Y - LastX1;
            PanelCutMove panelCutMove8 = new PanelCutMove();
            panelCutMove8.Position.X = Node.Node[index2].DimensionY;
            panelCutMove8.Position.Y = 0.0;
            panelCutMove8.XPosition = -Node.Node[index2].DimensionY;
            panelCutMove8.Command = PanelCutMoveCommand.AddMaterial;
            panelCutMove8.Panel = new Rectangle2D(Node.Node[index2].DimensionY, Node.Node[index2].DimensionX);
            for (int index4 = 0; index4 <= Node.Node[index2].Node.Count - 1; ++index4)
            {
              Rectangle2D rectangle2D3 = new Rectangle2D(new Point3D(Node.Node[index2].Node[index4].CutFeedDistance - sawThickness / 2.0, 0.0), sawThickness, Node.Node[index2].Node[index4].CutSawDistance);
              panelCutMove8.SawCutRectangles.Add(rectangle2D3);
            }
            panelCutMove8.Index = this.MoveIndex;
            panelCutMove8.NodeID = node.NodeID;
            panelCutMove8.NodeType = node.NodeType;
            this.activeJob.SimulationMoves.Add(panelCutMove8);
            LastX1 = Node.Node[index2].DimensionY;
            num6 = node.DimensionY + sawThickness / 2.0;
          }
          else
            num6 = node.DimensionY + sawThickness;
          this.CreateSimMoveXStep(this.MoveIndex, node, countStep1, 0.0, LastX1, -num6);
          LastX1 -= num6;
          if (index3 < Node.Node[index2].Node.Count - 1)
          {
            int countStep5 = clsInit.cPanelCut.SimCountFromLength(Node.Node[index2].DimensionX, clsPanelCut.varPanelCutSettings.CutSimDevideLen);
            this.CreateSimMoveYCut(this.MoveIndex, node, countStep5, this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.X, 0.0, Node.Node[index2].DimensionX);
          }
          this.activeJob.SimulationCodes.Add($"      Part = {num5.ToString()} ({this.activeJob.Parts[node.PartID].Width.ToString("f2")} X {this.activeJob.Parts[node.PartID].Height.ToString("f2")})");
          this.activeJob.SimulationMoves.Add(new PanelCutMove()
          {
            Position = buVector5.ToPoint3D(this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position),
            Command = PanelCutMoveCommand.PartFinished,
            Panel = new Rectangle2D(node.Rectangle),
            PartID = node.PartID
          });
          ++this.MoveIndex;
          ++num5;
        }
      }
    }
    if (Node.NodeType == nestPanelNodeType.CutLine)
      ;
  }

  public void CreateSimMoveXStep(
    int Index,
    NestingPanelNode node,
    int countStep,
    double YPos,
    double LastX,
    double XDistance)
  {
    double num = XDistance / (double) countStep;
    for (int index = 1; index <= countStep; ++index)
    {
      PanelCutMove panelCutMove = new PanelCutMove();
      panelCutMove.Position.X = LastX + (double) index * num;
      panelCutMove.Position.Y = YPos;
      panelCutMove.Command = PanelCutMoveCommand.AxisMove;
      panelCutMove.Index = Index;
      panelCutMove.NodeID = node.NodeID;
      panelCutMove.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove);
    }
  }

  public void CreateSimMoveYCut(
    int Index,
    NestingPanelNode node,
    int countStep,
    double XPos,
    double LastY,
    double YDistance)
  {
    double num1 = -YDistance / (double) countStep;
    PanelCutMove panelCutMove1 = new PanelCutMove();
    if (clsPanelCut.varPanelCutSettings.CutSawZMoveCount == 3)
    {
      panelCutMove1.Position.X = XPos;
      panelCutMove1.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove1.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.33;
      panelCutMove1.Index = Index;
      panelCutMove1.NodeID = node.NodeID;
      panelCutMove1.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove1);
      PanelCutMove panelCutMove2 = new PanelCutMove();
      panelCutMove2.Position.X = XPos;
      panelCutMove2.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove2.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.66;
      panelCutMove2.Index = Index;
      panelCutMove2.NodeID = node.NodeID;
      panelCutMove2.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove2);
      PanelCutMove panelCutMove3 = new PanelCutMove();
      panelCutMove3.Position.X = XPos;
      panelCutMove3.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove3.Position.Z = this.activeJob.Panels[this.JobIndex].Depth + 2.0;
      panelCutMove3.Index = Index;
      panelCutMove3.NodeID = node.NodeID;
      panelCutMove3.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove3);
    }
    else if (clsPanelCut.varPanelCutSettings.CutSawZMoveCount == 2)
    {
      PanelCutMove panelCutMove4 = new PanelCutMove();
      panelCutMove4.Position.X = XPos;
      panelCutMove4.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove4.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.5;
      panelCutMove4.Index = Index;
      panelCutMove4.NodeID = node.NodeID;
      panelCutMove4.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove4);
      PanelCutMove panelCutMove5 = new PanelCutMove();
      panelCutMove5.Position.X = XPos;
      panelCutMove5.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove5.Position.Z = this.activeJob.Panels[this.JobIndex].Depth + 2.0;
      panelCutMove5.Index = Index;
      panelCutMove5.NodeID = node.NodeID;
      panelCutMove5.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove5);
    }
    else
    {
      PanelCutMove panelCutMove6 = new PanelCutMove();
      panelCutMove6.Position.X = XPos;
      panelCutMove6.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove6.Position.Z = this.activeJob.Panels[this.JobIndex].Depth + 2.0;
      panelCutMove6.Index = Index;
      panelCutMove6.NodeID = node.NodeID;
      panelCutMove6.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove6);
    }
    for (int index = 1; index <= countStep; ++index)
    {
      PanelCutMove panelCutMove7 = new PanelCutMove();
      panelCutMove7.Position.X = XPos;
      panelCutMove7.Position.Y = (double) index * num1;
      panelCutMove7.Position.Z = this.activeJob.Panels[this.JobIndex].Depth + 2.0;
      panelCutMove7.Index = Index;
      panelCutMove7.NodeID = node.NodeID;
      panelCutMove7.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove7);
    }
    if (clsPanelCut.varPanelCutSettings.CutSawZMoveCount == 3)
    {
      PanelCutMove panelCutMove8 = new PanelCutMove();
      panelCutMove8.Position.X = XPos;
      panelCutMove8.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove8.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.66;
      panelCutMove8.Index = Index;
      panelCutMove8.NodeID = node.NodeID;
      panelCutMove8.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove8);
      PanelCutMove panelCutMove9 = new PanelCutMove();
      panelCutMove9.Position.X = XPos;
      panelCutMove9.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove9.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.33;
      panelCutMove9.Index = Index;
      panelCutMove9.NodeID = node.NodeID;
      panelCutMove9.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove9);
      PanelCutMove panelCutMove10 = new PanelCutMove();
      panelCutMove10.Position.X = XPos;
      panelCutMove10.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove10.Position.Z = 0.0;
      panelCutMove10.Index = Index;
      panelCutMove10.NodeID = node.NodeID;
      panelCutMove10.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove10);
    }
    else if (clsPanelCut.varPanelCutSettings.CutSawZMoveCount == 2)
    {
      PanelCutMove panelCutMove11 = new PanelCutMove();
      panelCutMove11.Position.X = XPos;
      panelCutMove11.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove11.Position.Z = this.activeJob.Panels[this.JobIndex].Depth * 0.5;
      panelCutMove11.Index = Index;
      panelCutMove11.NodeID = node.NodeID;
      panelCutMove11.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove11);
      PanelCutMove panelCutMove12 = new PanelCutMove();
      panelCutMove12.Position.X = XPos;
      panelCutMove12.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove12.Position.Z = 0.0;
      panelCutMove12.Index = Index;
      panelCutMove12.NodeID = node.NodeID;
      panelCutMove12.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove12);
    }
    else
    {
      PanelCutMove panelCutMove13 = new PanelCutMove();
      panelCutMove13.Position.X = XPos;
      panelCutMove13.Position.Y = this.activeJob.SimulationMoves[this.activeJob.SimulationMoves.Count - 1].Position.Y;
      panelCutMove13.Position.Z = 0.0;
      panelCutMove13.Index = Index;
      panelCutMove13.NodeID = node.NodeID;
      panelCutMove13.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove13);
    }
    double num2 = YDistance / (double) countStep;
    for (int index = 1; index <= countStep; ++index)
    {
      PanelCutMove panelCutMove14 = new PanelCutMove();
      panelCutMove14.Position.X = XPos;
      panelCutMove14.Position.Y = -YDistance + (double) index * num2;
      panelCutMove14.Index = Index;
      panelCutMove14.NodeID = node.NodeID;
      panelCutMove14.NodeType = node.NodeType;
      this.activeJob.SimulationMoves.Add(panelCutMove14);
    }
  }

  public void DrawSelectedRegion(List<Point3D> PL)
  {
    Mesh mesh = new devDept.Eyeshot.Entities.Region((ICurve) new LinearPath((ICollection<Point3D>) PL)).ExtrudeAsMesh(20.0, 0.01, Mesh.natureType.RichSmooth);
    mesh.Color = Color.FromArgb(120, Color.Tan);
    mesh.ColorMethod = colorMethodType.byEntity;
    mesh.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Temp
    };
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) mesh);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void DrawNodesParts(List<NestingPanelNode> Nodes)
  {
    for (int index = 0; index <= Nodes.Count - 1; ++index)
    {
      if (Nodes[index].NodeType == nestPanelNodeType.Module)
      {
        Rectangle2D rectangle2D = (Rectangle2D) null;
        if (Nodes[index].PartID >= 0 && Nodes[index].PartID <= this.activeJob.Parts.Count - 1)
          rectangle2D = new Rectangle2D(this.activeJob.Parts[Nodes[index].PartID].Width, this.activeJob.Parts[Nodes[index].PartID].Height);
        if (Nodes[index].XQuantity > 0 & Nodes[index].YQuantity > 0 & rectangle2D != null)
        {
          for (double num1 = 0.0; num1 <= (double) (Nodes[index].XQuantity - 1); ++num1)
          {
            for (double num2 = 0.0; num2 <= (double) (Nodes[index].YQuantity - 1); ++num2)
            {
              double num3 = num1 * (rectangle2D.Width + clsPanelCut.varPanelCutSettings.SawThickness);
              double num4 = num2 * (rectangle2D.Height + clsPanelCut.varPanelCutSettings.SawThickness);
              Rectangle2D rect = new Rectangle2D(new Point3D(Nodes[index].LowerLeft.X + num3, Nodes[index].LowerLeft.Y + num4), rectangle2D.Width, rectangle2D.Height);
              List<Point3D> Vertices = new List<Point3D>();
              Rectangle2D.Rectangle3DToVertices(rect, ref Vertices);
              LinearPath outer = new LinearPath((ICollection<Point3D>) Vertices);
              ccVars.UndoDont = true;
              Mesh Ent = new devDept.Eyeshot.Entities.Region((ICurve) outer).ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
              Ent.Color = Color.LightSteelBlue;
              if (Nodes[index].PartID >= 0 & Nodes[index].PartID <= buImage5.ColorList.Count - 1)
              {
                int lower = (int) buNumeric5.RoundToLower((double) Nodes[index].PartID / 2.0);
                Ent.Color = buImage5.ColorList[lower];
              }
              Ent.ColorMethod = colorMethodType.byEntity;
              Ent.Selectable = false;
              if (Ent != null)
                clsInit.appCommand.AddMesh(Ent);
            }
          }
        }
      }
      if (Nodes[index].NodeType == nestPanelNodeType.CutLine && Nodes[index].CutLine != null)
      {
        devDept.Eyeshot.Entities.Line Ent = new devDept.Eyeshot.Entities.Line(Nodes[index].CutLine.StartPoint, Nodes[index].CutLine.EndPoint);
        Ent.Color = Color.Black;
        Ent.ColorMethod = colorMethodType.byEntity;
        Ent.LineWeight = 3f;
        Ent.LineWeightMethod = colorMethodType.byEntity;
        Ent.Selectable = true;
        ccVars.UndoDont = true;
        clsInit.appCommand.AddLine(Ent);
      }
      if (Nodes[index].NodeType == nestPanelNodeType.OffCut)
      {
        Rectangle2D rect = new Rectangle2D(Nodes[index].Rectangle);
        List<Point3D> points = new List<Point3D>();
        if (rect.Width > 0.0 & rect.Height > 0.0)
        {
          Rectangle2D.Rectangle3DToVertices(rect, ref points);
          clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref points);
          if (points.Count >= 3)
          {
            LinearPath outer = new LinearPath((ICollection<Point3D>) points);
            ccVars.UndoDont = true;
            Mesh Ent = new devDept.Eyeshot.Entities.Region((ICurve) outer).ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
            Ent.Color = Color.Gray;
            Ent.ColorMethod = colorMethodType.byEntity;
            Ent.Selectable = false;
            if (Ent != null)
              clsInit.appCommand.AddMesh(Ent);
          }
        }
      }
      if (Nodes[index].Node.Count > 0)
        this.DrawNodesParts(Nodes[index].Node);
    }
  }

  public void DrawNodesParts(
    List<NestingPanelNode> Nodes,
    double PanelDepth,
    int Level,
    ref List<Entity> PartEntities)
  {
    for (int index = 0; index <= Nodes.Count - 1; ++index)
    {
      if (Nodes[index].NodeType == nestPanelNodeType.Assembly)
      {
        Rectangle2D rectangle = new Rectangle2D(Nodes[index].Rectangle);
        if (rectangle.Width > 0.0 & rectangle.Height > 0.0)
        {
          Mesh meshPanel = (Mesh) null;
          clsInit.cPanelCut.RectangleToMesh(rectangle, PanelDepth, Color.FromArgb(70, Color.WhiteSmoke), Level, -1, -1, Nodes[index], ref meshPanel);
          if (meshPanel != null)
            PartEntities.Add((Entity) meshPanel);
        }
      }
      if (Nodes[index].NodeType == nestPanelNodeType.Module)
      {
        Rectangle2D rectangle = new Rectangle2D(Nodes[index].Rectangle);
        if (rectangle.Width > 0.0 & rectangle.Height > 0.0)
        {
          Mesh meshPanel = (Mesh) null;
          clsInit.cPanelCut.RectangleToMesh(rectangle, PanelDepth, Color.FromArgb(100, Color.Tan), Level, -1, -1, Nodes[index], ref meshPanel);
          if (meshPanel != null)
            PartEntities.Add((Entity) meshPanel);
        }
        if (Nodes[index].PartID >= 0 && Nodes[index].PartID <= this.activeJob.Parts.Count - 1)
        {
          Rectangle2D rectangle2D = new Rectangle2D(this.activeJob.Parts[Nodes[index].PartID].Width, this.activeJob.Parts[Nodes[index].PartID].Height);
        }
      }
      if (Nodes[index].NodeType == nestPanelNodeType.CutLine)
      {
        Rectangle2D rectangle = new Rectangle2D(Nodes[index].Rectangle);
        if (rectangle.Width > 0.0 & rectangle.Height > 0.0)
        {
          Color color = Color.LightSteelBlue;
          if (Nodes[index].PartID >= 0 & Nodes[index].PartID <= buImage5.ColorList.Count - 1)
          {
            int lower = (int) buNumeric5.RoundToLower((double) Nodes[index].PartID / 2.0);
            color = buImage5.ColorList[lower];
          }
          Mesh meshPanel = (Mesh) null;
          clsInit.cPanelCut.RectangleToMesh(rectangle, PanelDepth, color, Level, -1, -1, Nodes[index], ref meshPanel);
          if (meshPanel != null)
            PartEntities.Add((Entity) meshPanel);
        }
        if (Nodes[index].CutLine != null)
        {
          devDept.Eyeshot.Entities.Line line = new devDept.Eyeshot.Entities.Line(Nodes[index].CutLine.StartPoint, Nodes[index].CutLine.EndPoint);
          line.Color = Color.Black;
          line.ColorMethod = colorMethodType.byEntity;
          line.LineWeight = 3f;
          line.LineWeightMethod = colorMethodType.byEntity;
          line.Selectable = true;
          ccVars.UndoDont = true;
        }
      }
      if (Nodes[index].NodeType == nestPanelNodeType.OffCut)
      {
        Rectangle2D rectangle = new Rectangle2D(Nodes[index].Rectangle);
        List<Point3D> point3DList = new List<Point3D>();
        if (rectangle.Width > 0.0 & rectangle.Height > 0.0)
        {
          Mesh meshPanel = (Mesh) null;
          clsInit.cPanelCut.RectangleToMesh(rectangle, PanelDepth, Color.FromArgb((int) byte.MaxValue, Color.Gray), Level, -1, -1, Nodes[index], ref meshPanel);
          if (meshPanel != null)
            PartEntities.Add((Entity) meshPanel);
        }
      }
      if (Nodes[index].Node.Count > 0)
        this.DrawNodesParts(Nodes[index].Node, PanelDepth, Level + 1, ref PartEntities);
    }
  }

  public void DeleteNodeSelection()
  {
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData != null && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData is CustomData && (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].EntityData as CustomData).typeDefination == entityTypeDefination.Temp)
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
  }

  public void GetCodeNodes(
    List<NestingPanelNode> Nodes,
    DirectionXandY PreDir,
    ref List<string> SL)
  {
    for (int index = 0; index <= Nodes.Count - 1; ++index)
    {
      if (Nodes[index].Depth > 0)
      {
        if (Nodes[index].NodeType == nestPanelNodeType.Assembly)
        {
          string str1 = "000";
          string str2 = "0";
          if (PreDir == DirectionXandY.XDirection)
            SL.Add($"KES1,{Nodes[index].Depth.ToString()},{Nodes[index].DimensionX.ToString()},{str2},{str1}");
          if (PreDir == DirectionXandY.YDirection)
            SL.Add($"KES1,{Nodes[index].Depth.ToString()},{Nodes[index].DimensionY.ToString()},{str2},{str1}");
        }
        if (Nodes[index].NodeType == nestPanelNodeType.Module)
        {
          Rectangle2D rectangle2D = (Rectangle2D) null;
          if (Nodes[index].PartID >= 0)
            ;
          if (Nodes[index].XQuantity > 0 & Nodes[index].YQuantity > 0 & rectangle2D != null)
          {
            for (double num1 = 0.0; num1 <= (double) (Nodes[index].XQuantity - 1); ++num1)
            {
              for (double num2 = 0.0; num2 <= (double) (Nodes[index].YQuantity - 1); ++num2)
              {
                double num3 = num1 * (rectangle2D.Width + clsPanelCut.varPanelCutSettings.SawThickness);
                double num4 = num2 * (rectangle2D.Height + clsPanelCut.varPanelCutSettings.SawThickness);
                Rectangle2D rect = new Rectangle2D(new Point3D(Nodes[index].LowerLeft.X + num3, Nodes[index].LowerLeft.Y + num4), rectangle2D.Width, rectangle2D.Height);
                List<Point3D> Vertices = new List<Point3D>();
                Rectangle2D.Rectangle3DToVertices(rect, ref Vertices);
                LinearPath outer = new LinearPath((ICollection<Point3D>) Vertices);
                ccVars.UndoDont = true;
                Mesh Ent = new devDept.Eyeshot.Entities.Region((ICurve) outer).ExtrudeAsMesh(18.0, 0.1, Mesh.natureType.RichSmooth);
                Ent.Color = Color.LightSteelBlue;
                if (Nodes[index].PartID >= 0 & Nodes[index].PartID <= buImage5.ColorList.Count - 1)
                {
                  int lower = (int) buNumeric5.RoundToLower((double) Nodes[index].PartID / 2.0);
                  Ent.Color = buImage5.ColorList[lower];
                }
                Ent.ColorMethod = colorMethodType.byEntity;
                Ent.Selectable = false;
                if (Ent != null)
                  clsInit.appCommand.AddMesh(Ent);
              }
            }
          }
        }
        if (Nodes[index].NodeType == nestPanelNodeType.CutLine)
        {
          string str3 = "1";
          string str4 = Nodes[index].ID.ToString("D3");
          if (Nodes[index].Direction == DirectionXandY.XDirection)
            SL.Add($"KES1,{Nodes[index].Depth.ToString()},{Nodes[index].DimensionX.ToString()},{str3},{str4}");
          if (Nodes[index].Direction == DirectionXandY.YDirection)
            SL.Add($"KES1,{Nodes[index].Depth.ToString()},{Nodes[index].DimensionY.ToString()},{str3},{str4}");
        }
        if (Nodes[index].NodeType == nestPanelNodeType.OffCut)
        {
          if (clsPanelCut.varTemps.OffcutCount == 0 & clsPanelCut.varPanelCutSettings.GeneralTrimWidth > 0.0)
          {
            string str5 = "0";
            string str6 = "000";
            if (Nodes[index].Node.Count > 0)
              str5 = "0";
            SL.Add($"KES1,{Nodes[index].Depth.ToString()},{Nodes[index].DimensionX.ToString()},{str5},{str6}");
          }
          ++clsPanelCut.varTemps.OffcutCount;
        }
      }
      if (Nodes[index].Node.Count > 0)
        this.GetCodeNodes(Nodes[index].Node, Nodes[index].Direction, ref SL);
    }
  }

  public void SavePanelCutFile()
  {
    try
    {
      string FileName = AppPath.Settings + "\\PanelCut\\PanelCut.prm";
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   Panel Cut Settings");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "<varPanelCutSettings>");
      StringList.AddRange((ICollection) clsPanelCut.varPanelCutSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varPanelCutSettings>");
      StringList.Add((object) "<varPanelCutRunSettings>");
      StringList.AddRange((ICollection) clsPanelCut.varPanelCutRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList.Add((object) "</varPanelCutRunSettings>");
      StringList.Add((object) "<NestingPartsAndSheets>");
      StringList.AddRange((ICollection) buNestingSheet.ToDef(clsNesting.Sheets, 2).ToArray());
      StringList.Add((object) " ");
      StringList.AddRange((ICollection) buNestingPart.ToDef(clsNesting.Parts, 2).ToArray());
      StringList.Add((object) " ");
      StringList.AddRange((ICollection) buNestingMaterials.ToDef(clsNesting.Materials, 2).ToArray());
      StringList.Add((object) "</NestingPartsAndSheets>");
      buFile.SaveToFile(StringList, FileName);
      buLog.addLog("PanelCut Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[17];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenPanelCutFile()
  {
    try
    {
      ArrayList StringList = new ArrayList();
      FileInfo fileInfo = new FileInfo(AppPath.Settings + "\\PanelCut\\PanelCut.prm");
      if (fileInfo.Exists)
      {
        StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<varPanelCutSettings>", "</varPanelCutSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsPanelCut.varPanelCutSettings);
            buLog.addLog("Panel Cut varPanelCutSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<varPanelCutRunSettings>", "</varPanelCutRunSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsPanelCut.varPanelCutRunSettings);
            buLog.addLog("Panel Cut varPanelCutRunSettings  Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("PanelCut Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Drill Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("PanelCut Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Drill Settings File Missing");
      }
      buLog.addLog("PanelCut Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      buNestingSheet.Decode(StringList, ref clsNesting.Sheets);
      buNestingPart.Decode(StringList, ref clsNesting.Parts);
      buNestingMaterials.Decode(StringList, ref clsNesting.Materials);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
    TreeNodeSettings selectedNode = (TreeNodeSettings) ((TreeView) sender).SelectedNode;
    this.DeleteNodeSelection();
    if (selectedNode.Level < 0)
      return;
    List<Point3D> Vertices = new List<Point3D>();
    if (selectedNode.Level == 0 && this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Rectangle != null)
    {
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Rectangle, ref Vertices);
      this.DrawSelectedRegion(Vertices);
    }
    if (selectedNode.Level == 1 && this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Rectangle != null)
    {
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Rectangle, ref Vertices);
      this.DrawSelectedRegion(Vertices);
    }
    if (selectedNode.Level == 2 && this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Rectangle != null)
    {
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Rectangle, ref Vertices);
      this.DrawSelectedRegion(Vertices);
    }
    if (selectedNode.Level == 3 && this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Rectangle != null)
    {
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Rectangle, ref Vertices);
      this.DrawSelectedRegion(Vertices);
    }
    if (selectedNode.Level == 4 && this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubIndex].Rectangle != null)
    {
      Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubIndex].Rectangle, ref Vertices);
      this.DrawSelectedRegion(Vertices);
    }
    if (selectedNode.Level != 5 || this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubSubIndex].Rectangle == null)
      return;
    Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].Nodes[selectedNode.ClassIndex].Node[selectedNode.ClassSubIndex].Node[selectedNode.ClassSubSubIndex].Node[selectedNode.ClassSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubIndex].Node[selectedNode.ClassSubSubSubSubSubIndex].Rectangle, ref Vertices);
    this.DrawSelectedRegion(Vertices);
  }

  public void SheetDone_CellClick(object sender, DataGridViewCellEventArgs e)
  {
    if (e.RowIndex > this.activeJob.Panels.Count - 1 || e.RowIndex < 0)
      return;
    clsItem.FrmPanelCutJob.dgv_sheets.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
    this.JobIndex = e.RowIndex;
    this.doDrawNestingResult();
    this.JobUpdate(true, "", new DrillItem(), -1);
    if (e.RowIndex == 0)
      return;
    clsItem.FrmPanelCutJob.dgv_sheets.Rows[0].Cells[0].Selected = false;
  }

  public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
  {
    try
    {
      if (clsItem.FrmPanelCutJob == null)
        return;
      if (ccVars.Pages.Count != clsItem.FrmPanelCutJob.tree_jobs.Nodes.Count)
        FillPages = true;
      clsItem.FrmPanelCutJob.tree_jobs.CheckBoxes = false;
      clsItem.FrmPanelCutJob.dgv_sheets.Rows.Clear();
      string str1 = AppLanguage.CadCamDynamic[114];
      string str2 = AppLanguage.CadCamDynamic[108];
      string str3 = AppLanguage.CadCamDynamic[107] + " - ";
      string str4 = AppLanguage.CadCamDynamic[106];
      string str5 = AppLanguage.CadCamDynamic[112 /*0x70*/];
      TreeNodeSettings node1 = (TreeNodeSettings) null;
      if (FillPages)
      {
        clsItem.FrmPanelCutJob.tree_jobs.Nodes.Clear();
        int int_1 = 0;
        int int_2 = 0;
        double num1 = 0.0;
        double num2 = 0.0;
        for (int index = 0; index <= this.activeJob.Panels.Count - 1; ++index)
        {
          clsItem.FrmPanelCutJob.dgv_sheets.Rows.Add(this.method_2(index + 1, $"{this.activeJob.Panels[index].Width.ToString("f2")} X {this.activeJob.Panels[index].Height.ToString("f2")}", this.activeJob.Panels[index].Count, this.activeJob.Panels[index].PartCount, this.activeJob.Panels[index].Waste, this.activeJob.Panels[index].TotalCutLength, this.activeJob.Panels[index].Material, this.activeJob.Panels[index].Explanation));
          int_1 += this.activeJob.Panels[index].Count;
          int_2 += this.activeJob.Panels[index].PartCount * this.activeJob.Panels[index].Count;
          num1 += this.activeJob.Panels[index].TotalCutLength * (double) this.activeJob.Panels[index].Count;
          num2 += this.activeJob.Panels[index].Waste * (double) this.activeJob.Panels[index].Count;
        }
        clsItem.FrmPanelCutJob.dgv_sheets.Rows.Add(this.method_2(-1, "Total Panel Count - Part Count", int_1, int_2, num2 / (double) int_1, 0.0, this.activeJob.Panels[0].Material, "Summurize"));
        for (int index1 = 0; index1 <= this.activeJob.Panels[this.JobIndex].Nodes.Count - 1; ++index1)
        {
          TreeNodeSettings treeNodeSettings1 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1]));
          treeNodeSettings1.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Direction);
          treeNodeSettings1.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Direction);
          treeNodeSettings1.Tag = (object) index1.ToString();
          treeNodeSettings1.ClassIndex = index1;
          treeNodeSettings1.ClassSubIndex = -1;
          treeNodeSettings1.ClassSubSubIndex = -1;
          treeNodeSettings1.Command = "panel";
          treeNodeSettings1.Checked = true;
          node1 = treeNodeSettings1;
          for (int index2 = 0; index2 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node.Count - 1; ++index2)
          {
            TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2]));
            treeNodeSettings2.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Direction);
            treeNodeSettings2.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Direction);
            treeNodeSettings2.Tag = (object) index2.ToString();
            treeNodeSettings2.ClassIndex = index1;
            treeNodeSettings2.ClassSubIndex = index2;
            treeNodeSettings2.ClassSubSubIndex = -1;
            treeNodeSettings2.Command = "panel";
            treeNodeSettings2.Checked = true;
            TreeNodeSettings node2 = treeNodeSettings2;
            for (int index3 = 0; index3 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node.Count - 1; ++index3)
            {
              TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3]));
              treeNodeSettings3.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Direction);
              treeNodeSettings3.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Direction);
              treeNodeSettings3.Tag = (object) index3.ToString();
              treeNodeSettings3.ClassIndex = index1;
              treeNodeSettings3.ClassSubIndex = index2;
              treeNodeSettings3.ClassSubSubIndex = index3;
              treeNodeSettings3.Command = "panel";
              treeNodeSettings3.Checked = true;
              TreeNodeSettings node3 = treeNodeSettings3;
              for (int index4 = 0; index4 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node.Count - 1; ++index4)
              {
                TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4]));
                treeNodeSettings4.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Direction);
                treeNodeSettings4.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Direction);
                treeNodeSettings4.Tag = (object) index4.ToString();
                treeNodeSettings4.ClassIndex = index1;
                treeNodeSettings4.ClassSubIndex = index2;
                treeNodeSettings4.ClassSubSubIndex = index3;
                treeNodeSettings4.ClassSubSubSubIndex = index4;
                treeNodeSettings4.Command = "panel";
                treeNodeSettings4.Checked = true;
                TreeNodeSettings node4 = treeNodeSettings4;
                for (int index5 = 0; index5 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node.Count - 1; ++index5)
                {
                  TreeNodeSettings treeNodeSettings5 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5]));
                  treeNodeSettings5.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Direction);
                  treeNodeSettings5.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Direction);
                  treeNodeSettings5.Tag = (object) index5.ToString();
                  treeNodeSettings5.ClassIndex = index1;
                  treeNodeSettings5.ClassSubIndex = index2;
                  treeNodeSettings5.ClassSubSubIndex = index3;
                  treeNodeSettings5.ClassSubSubSubIndex = index4;
                  treeNodeSettings5.ClassSubSubSubSubIndex = index5;
                  treeNodeSettings5.Command = "panel";
                  treeNodeSettings5.Checked = true;
                  TreeNodeSettings node5 = treeNodeSettings5;
                  for (int index6 = 0; index6 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node.Count - 1; ++index6)
                  {
                    TreeNodeSettings treeNodeSettings6 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6]));
                    treeNodeSettings6.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Direction);
                    treeNodeSettings6.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Direction);
                    treeNodeSettings6.Tag = (object) index6.ToString();
                    treeNodeSettings6.ClassIndex = index1;
                    treeNodeSettings6.ClassSubIndex = index2;
                    treeNodeSettings6.ClassSubSubIndex = index3;
                    treeNodeSettings6.ClassSubSubSubIndex = index4;
                    treeNodeSettings6.ClassSubSubSubSubIndex = index5;
                    treeNodeSettings6.ClassSubSubSubSubSubIndex = index6;
                    treeNodeSettings6.Command = "panel";
                    treeNodeSettings6.Checked = true;
                    TreeNodeSettings node6 = treeNodeSettings6;
                    for (int index7 = 0; index7 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node.Count - 1; ++index7)
                    {
                      TreeNodeSettings treeNodeSettings7 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7]));
                      treeNodeSettings7.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Direction);
                      treeNodeSettings7.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Direction);
                      treeNodeSettings7.Tag = (object) index6.ToString();
                      treeNodeSettings7.ClassIndex = index1;
                      treeNodeSettings7.ClassSubIndex = index2;
                      treeNodeSettings7.ClassSubSubIndex = index3;
                      treeNodeSettings7.ClassSubSubSubIndex = index4;
                      treeNodeSettings7.ClassSubSubSubSubIndex = index5;
                      treeNodeSettings7.ClassSubSubSubSubSubIndex = index6;
                      treeNodeSettings7.ClassSubSubSubSubSubSubIndex = index7;
                      treeNodeSettings7.Command = "panel";
                      treeNodeSettings7.Checked = true;
                      TreeNodeSettings node7 = treeNodeSettings7;
                      for (int index8 = 0; index8 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node.Count - 1; ++index8)
                      {
                        TreeNodeSettings treeNodeSettings8 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8]));
                        treeNodeSettings8.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Direction);
                        treeNodeSettings8.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Direction);
                        treeNodeSettings8.Tag = (object) index6.ToString();
                        treeNodeSettings8.ClassIndex = index1;
                        treeNodeSettings8.ClassSubIndex = index2;
                        treeNodeSettings8.ClassSubSubIndex = index3;
                        treeNodeSettings8.ClassSubSubSubIndex = index4;
                        treeNodeSettings8.ClassSubSubSubSubIndex = index5;
                        treeNodeSettings8.ClassSubSubSubSubSubIndex = index6;
                        treeNodeSettings8.ClassSubSubSubSubSubSubIndex = index7;
                        treeNodeSettings8.ClassSubSubSubSubSubSubSubIndex = index8;
                        treeNodeSettings8.Command = "panel";
                        treeNodeSettings8.Checked = true;
                        TreeNodeSettings node8 = treeNodeSettings8;
                        for (int index9 = 0; index9 <= this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Node.Count - 1; ++index9)
                        {
                          TreeNodeSettings treeNodeSettings9 = new TreeNodeSettings(clsInit.cPanelCut.PanelCutToString(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Node[index9]));
                          treeNodeSettings9.ImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Node[index9].Direction);
                          treeNodeSettings9.SelectedImageIndex = clsInit.cPanelCut.PanelCutDirToImageIndex(this.activeJob.Panels[this.JobIndex].Nodes[index1].Node[index2].Node[index3].Node[index4].Node[index5].Node[index6].Node[index7].Node[index8].Node[index9].Direction);
                          treeNodeSettings9.Tag = (object) index6.ToString();
                          treeNodeSettings9.ClassIndex = index1;
                          treeNodeSettings9.ClassSubIndex = index2;
                          treeNodeSettings9.ClassSubSubIndex = index3;
                          treeNodeSettings9.ClassSubSubSubIndex = index4;
                          treeNodeSettings9.ClassSubSubSubSubIndex = index5;
                          treeNodeSettings9.ClassSubSubSubSubSubIndex = index6;
                          treeNodeSettings9.ClassSubSubSubSubSubSubIndex = index7;
                          treeNodeSettings9.ClassSubSubSubSubSubSubSubIndex = index8;
                          treeNodeSettings9.ClassSubSubSubSubSubSubSubSubIndex = index9;
                          treeNodeSettings9.Command = "panel";
                          treeNodeSettings9.Checked = true;
                          TreeNodeSettings node9 = treeNodeSettings9;
                          node8.Nodes.Add((TreeNode) node9);
                        }
                        node7.Nodes.Add((TreeNode) node8);
                      }
                      node6.Nodes.Add((TreeNode) node7);
                    }
                    node5.Nodes.Add((TreeNode) node6);
                  }
                  node4.Nodes.Add((TreeNode) node5);
                }
                node3.Nodes.Add((TreeNode) node4);
              }
              node2.Nodes.Add((TreeNode) node3);
            }
            node1.Nodes.Add((TreeNode) node2);
          }
        }
        if (node1 != null)
        {
          clsItem.FrmPanelCutJob.tree_jobs.Nodes.Add((TreeNode) node1);
          clsItem.FrmPanelCutJob.tree_jobs.Nodes[0].Expand();
        }
      }
      if (this.JobIndex < 0)
        return;
      clsItem.FrmPanelCutJob.dgv_sheets.Rows[this.JobIndex].Selected = true;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  private object[] method_2(
    int int_0,
    string string_0,
    int int_1,
    int int_2,
    double double_0,
    double double_1,
    string string_1,
    string string_2)
  {
    return new object[8]
    {
      (object) int_0,
      (object) string_0,
      (object) int_1,
      (object) int_2,
      (object) ("%" + Math.Round(double_0, 3).ToString()),
      (object) (Math.Round(double_1 / 1000.0, 3).ToString() + "m"),
      (object) string_1,
      (object) string_2
    };
  }

  public void SheetUpdate()
  {
    clsNesting.Sheets.Clear();
    for (int index = 0; index <= this.FrmNestPanelSheet.Sheets.Count - 1; ++index)
      clsNesting.Sheets.Add(new buNestingSheet(this.FrmNestPanelSheet.Sheets[index]));
    clsVar.varInterface.pathNestingFiles = this.FrmNestPanelSheet.SaveFileFolder;
    this.SavePanelCutFile();
  }

  public void PartUpdate()
  {
    clsNesting.Parts.Clear();
    for (int index = 0; index <= this.FrmNestPanelPart.Parts.Count - 1; ++index)
      clsNesting.Parts.Add(new buNestingPart(this.FrmNestPanelPart.Parts[index]));
    clsVar.varInterface.pathNestingFiles = this.FrmNestPanelPart.SaveFileFolder;
    this.SavePanelCutFile();
  }

  public string OutputURN(
    int PartQuantity,
    double PartWidth,
    double PartHeight,
    int CabinetNo,
    int Sequence)
  {
    return $"{$"{$"URN1,{$"{PartQuantity.ToString(),6}"},{$"{PartQuantity.ToString(),6}"},{$"{PartWidth.ToString("f2"),6}"},{$"{PartHeight.ToString("f2"),6}"}, ,N{Environment.NewLine}"}URN2,{$"{" ",6}"},{$"{PartWidth.ToString("f2"),6}"},{$"{PartHeight.ToString("f2"),6}"}{Environment.NewLine}"}URN3,{$"{CabinetNo.ToString(),3}"},{$"{Sequence.ToString("f2"),3}"}{Environment.NewLine}";
  }

  public string OutputPRT(
    int PartQuantity,
    double PartWidth,
    double PartHeight,
    int CabinetNo,
    int Sequence,
    double Thickness)
  {
    return $"{$"{$"{$"{$"PRT1,{$"{PartQuantity.ToString(),6}"},{$"{Sequence.ToString(),6}"},{$"{PartWidth.ToString("f2"),6}"},{$"{PartHeight.ToString("f2"),6}"}, 1{$"{" ",15}"}{$"{" ",10}"},,,,{$"{" ",10}"},{Environment.NewLine}"}PRT2, 0, ,{$"{Thickness.ToString("f1"),9}"},{Environment.NewLine}"}PRT3,0000{$"{" ",9}"},,{$"{" ",9}"},{$"{" ",9}"},,{$"{" ",9}"},{$"{" ",9}"},,{$"{" ",9}"},,{Environment.NewLine}"}PRT4,,,,,0,{Environment.NewLine}"}PRT5, ,N,    ,{Environment.NewLine}";
  }

  public string OutputPNL(
    NestingPanel Panel,
    string Direction,
    int PanelCount,
    double Val1,
    double Val2,
    double Val3,
    double Val4)
  {
    string str1 = "";
    string str2 = "";
    if (Panel.Nodes[0].Direction == DirectionXandY.XDirection)
      str2 = "S";
    if (Panel.Nodes[0].Direction == DirectionXandY.YDirection)
      str2 = "L";
    string str3 = $"{$"{$"{$"{$"{$"{str1}PNL1,01,{str2},{$"{Panel.Count.ToString(),6}"},1{$"{" ",15}"}{$"{" ",10}"},,,,{$"{" ",10}"},{Environment.NewLine}"}PNL2,{$"{Panel.Waste.ToString("f1"),9}"},{$"{Val1.ToString("f3"),15}"},{$"{Val2.ToString("f3"),15}"},{$"{Val3.ToString("f3"),15}"},{$"{Val4.ToString("f3"),15}"},{Environment.NewLine}"}PNL3,{$"{" ",6}"},{$"{" ",6}"},{$"{" ",6}"},{Environment.NewLine}"}PNL4,{$"{" ",6}"},{$"{" ",6}"},{Environment.NewLine}"}PNL5,{$"{" ",6}"},{$"{" ",6}"},{$"{" ",6}"},{Environment.NewLine}"}BASLA{Environment.NewLine}";
    List<string> SL = new List<string>();
    this.GetCodeNodes(Panel.Nodes, DirectionXandY.XDirection, ref SL);
    for (int index = 0; index <= SL.Count - 1; ++index)
      str3 = str3 + SL[index] + Environment.NewLine;
    return $"{str3}BITIR{Environment.NewLine}";
  }

  public void doDrawNestingResult()
  {
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    if (this.JobIndex >= 0 & this.JobIndex <= this.activeJob.Panels.Count - 1)
    {
      for (int index = 0; index <= this.activeJob.Panels[this.JobIndex].CalculatedRectangles.Count - 1; ++index)
      {
        List<Point3D> Vertices = new List<Point3D>();
        Rectangle2D.Rectangle3DToVertices(this.activeJob.Panels[this.JobIndex].CalculatedRectangles[index], ref Vertices);
        LinearPath Ent = new LinearPath((ICollection<Point3D>) Vertices);
        Ent.ColorMethod = colorMethodType.byEntity;
        Ent.Color = Color.Red;
        clsInit.appCommand.AddPolyline(Ent);
      }
      this.DrawNodesParts(this.activeJob.Panels[this.JobIndex].Nodes);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doCalculationDone(object data)
  {
    this.JobIndex = -1;
    if (this.activeJob.Panels.Count > 0)
      this.JobIndex = 0;
    this.doDrawNestingResult();
    this.JobUpdate(true, "", (DrillItem) null, -1);
    clsInit.appCommand.cmdViewTop(false, false);
    clsInit.appCommand.cmdViewZoomFit();
    clsInit.appCommand.cmdViewZoomOut();
  }

  public void doReset() => this.DeleteNodeSelection();

  public void doNewPage()
  {
  }

  public void doOpenPage()
  {
  }

  public void doCreateCode(ref string Code)
  {
    string str1 = "FileName";
    string str2 = "2.10";
    Code = "";
    Code = $"{Code}BSL1,,{str1}{Environment.NewLine}";
    Code = $"{Code}BSL2,,{DateTime.Now.Month.ToString()},{DateTime.Now.Day.ToString()},{DateTime.Now.Year.ToString()},{DateTime.Now.ToShortTimeString()}{Environment.NewLine}";
    Code = $"{Code}BSL3,,{str2},,{Environment.NewLine}";
    Code = $"{Code}KON1,,,,,{Environment.NewLine}";
    Code = $"{Code}KON2,{clsPanelCut.varPanelCutSettings.SawThickness.ToString()}{Environment.NewLine}";
    Code = $"{Code}KON3,{Environment.NewLine}";
    Code = $"{Code}LMT1,{clsPanelCut.varPanelCutSettings.PanelThickness.ToString()},{clsPanelCut.varPanelCutSettings.PanelMaxThickness.ToString()}{Environment.NewLine}";
    for (int index = 0; index <= this.activeJob.usedParts.Count - 1; ++index)
      Code += this.OutputURN(this.activeJob.usedParts[index].PartData.Quantity, this.activeJob.usedParts[index].PartData.Width, this.activeJob.usedParts[index].PartData.Height, 1, index + 1);
    for (int index = 0; index <= this.activeJob.usedParts.Count - 1; ++index)
      Code += this.OutputPRT(this.activeJob.usedParts[index].PartData.Quantity, this.activeJob.usedParts[index].PartData.Width, this.activeJob.usedParts[index].PartData.Height, 1, index, clsPanelCut.varPanelCutSettings.PanelThickness);
    for (int index = 0; index <= this.activeJob.Panels.Count - 1; ++index)
      Code += this.OutputPNL(this.activeJob.Panels[index], "", 0, 1.0, 1.0, 1.0, 1.0);
  }
}
