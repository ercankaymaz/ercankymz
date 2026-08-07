// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Cutter.clsCutter
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Errors;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Materials;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
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
namespace buCadCamResVer5.Cutter;

public class clsCutter
{
  public static CutterProgramSettings varCutterSettings = new CutterProgramSettings();
  public static CutterRuntimeSettings varCutterRuntimeSettings = new CutterRuntimeSettings();
  public List<CutterNotch> NotchList = new List<CutterNotch>();
  public RulProperties Properties = new RulProperties();
  private F_MaterialRect2D f_MaterialRect2D_0 = (F_MaterialRect2D) null;

  public void Init()
  {
    this.LoadLanguage();
    buMWCutterVars.Init();
  }

  public void cmdNewMaterial(DoorJob panel)
  {
    if (this.f_MaterialRect2D_0 == null)
    {
      this.f_MaterialRect2D_0 = new F_MaterialRect2D();
      CreateModelProperties Properties = new CreateModelProperties();
      clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
      Properties.CoordinateSystemIconVisible = false;
      Properties.ViewCubeIconVisible = false;
      Properties.OrigineCaptionVisible = false;
      Properties.ToolBorVisible = false;
      Properties.OrigineSize = 5;
      this.f_MaterialRect2D_0.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
      this.f_MaterialRect2D_0.viewportLayout.CompileUserInterfaceElements();
    }
    this.f_MaterialRect2D_0.pnl_model.Controls.Add((Control) this.f_MaterialRect2D_0.viewportLayout);
    this.f_MaterialRect2D_0.viewportLayout.Entities.Clear();
    this.f_MaterialRect2D_0.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
    ccVars.activeMaterial.Size.Width = clsCutter.varCutterRuntimeSettings.ManuelSheetWidth;
    ccVars.activeMaterial.Size.Height = clsCutter.varCutterRuntimeSettings.ManuelSheetHeight;
    this.f_MaterialRect2D_0.Material = new MaterialBase5(ccVars.activeMaterial);
    if (panel != null)
      this.f_MaterialRect2D_0.Init(panel.Material);
    else
      this.f_MaterialRect2D_0.Init((MaterialBase5) null);
    this.f_MaterialRect2D_0.StartPosition = FormStartPosition.CenterParent;
    int num = (int) this.f_MaterialRect2D_0.ShowDialog();
    if (this.f_MaterialRect2D_0.PropertiesForm.Result != DialogResult.OK)
      return;
    ccVars.activeMaterial = new MaterialBase5(this.f_MaterialRect2D_0.Material);
    clsCutter.varCutterRuntimeSettings.ManuelSheetWidth = ccVars.activeMaterial.Size.Width;
    clsCutter.varCutterRuntimeSettings.ManuelSheetHeight = ccVars.activeMaterial.Size.Height;
    CompositeCurve rectangle = CompositeCurve.CreateRectangle(ccVars.activeMaterial.Size.Width, ccVars.activeMaterial.Size.Height);
    rectangle.EntityData = (object) new CustomData()
    {
      typeDefination = entityTypeDefination.Sheet
    };
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add((Entity) rectangle);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(10);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    this.SaveCutterFile();
  }

  public void cmdNotchEdit()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.cutterNotchAdd;
      dynamicInfo.Command = AppLanguage.CadCamCommand[13];
      ccVars.selectionProcess = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doNotchRotate();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdMachineSettings()
  {
    try
    {
      F_CutterMachineSettings cutterMachineSettings = new F_CutterMachineSettings();
      cutterMachineSettings.Settings = new CutterProgramSettings(clsCutter.varCutterSettings);
      cutterMachineSettings.Init();
      int num = (int) cutterMachineSettings.ShowDialog();
      if (cutterMachineSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      clsCutter.varCutterSettings = new CutterProgramSettings(cutterMachineSettings.Settings);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdOffsetDrawing()
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      ccVars.Action = actionTypeBU.cutterOffsetEntities;
      dynamicInfo.Command = AppLanguage.CadCamCommand[13];
      ccVars.selectionProcess = true;
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        clsInit.appCommand.cmdMainFormStatusUpdate($"{AppLanguage.CadCamStatus[10]} [ {dynamicInfo.Command} ]");
      }
      else
        this.doOffsetDrawing();
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdConvertText()
  {
    string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
    List<Entity> LayerEntities = new List<Entity>();
    clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, name, ref LayerEntities);
    List<buEntity> copiedEntities = new List<buEntity>();
    buEntity.Copy(LayerEntities, ref copiedEntities);
    this.doConvertText(copiedEntities);
  }

  public void cmdShowCutterSettings()
  {
    try
    {
      if (clsVar.appModes_0.NestingMode.Mode1 == 2.0)
      {
        buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
      }
      else
      {
        F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
        classViewerDialog.Text = "Cutter";
        classViewerDialog.Value = (object) clsCutter.varCutterSettings;
        classViewerDialog.StartPosition = FormStartPosition.CenterParent;
        classViewerDialog.Width = 500;
        classViewerDialog.Height = 750;
        classViewerDialog.ValuePersentage = 35.0;
        classViewerDialog.Init();
        int num = (int) classViewerDialog.ShowDialog();
        if (classViewerDialog.Result != DialogResult.OK)
          return;
        clsCutter.varCutterSettings = new CutterProgramSettings((CutterProgramSettings) classViewerDialog.Value);
        ccVars.MaterialList.Clear();
        if (clsCutter.varCutterSettings.ShowMachineSize)
        {
          for (int index = 0; (double) index <= clsCutter.varCutterSettings.RepeatCount - 1.0; ++index)
            ccVars.MaterialList.Add(new MaterialBase5(clsCutter.varCutterSettings.MachineWidth, clsCutter.varCutterSettings.MachineHeight, 1.0)
            {
              dX = (double) index * clsCutter.varCutterSettings.MachineWidth,
              dZ = -1.1
            });
        }
        clsInit.appCommand.MaterialUpdate(true, -1);
        clsFiles.SaveParameter();
      }
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdMenuCommand(object sender, EventArgs e)
  {
    switch (sender)
    {
      case Control _:
        string name1 = (sender as Control).Name;
        break;
      case ToolStripMenuItem _:
        string name2 = (sender as ToolStripMenuItem).Name;
        break;
    }
  }

  public void Job_AfterSelect(object sender, TreeViewEventArgs e)
  {
    buCadCamResVer5.TreeNodeSettings selectedNode = (buCadCamResVer5.TreeNodeSettings) ((TreeView) sender).SelectedNode;
  }

  public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
  {
    try
    {
      if (clsItem.FrmCutterJob != null)
        ;
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadLanguage()
  {
    List<string> stringList = new List<string>();
    FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buCutter.lng") : new FileInfo(AppPath.Language + "\\buCutter.lng");
    if (fileInfo.Exists)
    {
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(fileInfo.FullName, ref StringList);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CutterProgramSettings>", "</CutterProgramSettings>", StringList), clsVar.varRuntime.Language, ref CutterProgramSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CutterMachineSettings>", "</F_CutterMachineSettings>", StringList), clsVar.varRuntime.Language, ref F_CutterMachineSettings.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NotchEdit>", "</F_NotchEdit>", StringList), clsVar.varRuntime.Language, ref F_NotchEdit.Captions);
      buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buCutter.LangCutterMessage);
      StringList.Clear();
    }
    else
    {
      buLog.addLog("Nesting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Cutter Language File Missing");
    }
  }

  public void SaveCutterFile()
  {
    string FileName1 = AppPath.Settings + "\\Nesting\\CutterSet.prm";
    ArrayList StringList1 = new ArrayList();
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "   Cuttter Settings");
    StringList1.Add((object) "------------------------------------------------------------------------");
    StringList1.Add((object) "<CutterSettings>");
    StringList1.AddRange((ICollection) clsCutter.varCutterSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
    StringList1.Add((object) "</CutterSettings>");
    buFile.SaveToFile(StringList1, FileName1);
    buMWCutterVars.varCamCutter.mwPar.Serialize(AppPath.Settings + "\\Nesting\\mwCutterCommon.bin");
    string FileName2 = AppPath.Settings + "\\Nesting\\CutterCam.bucamset";
    ArrayList StringList2 = new ArrayList();
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "   MW Cam Settings");
    StringList2.Add((object) "------------------------------------------------------------------------");
    StringList2.Add((object) "<MwCamSettings>");
    StringList2.AddRange((ICollection) buMWCutterVars.varCamCutter.buPar.ToDefAll("_varCamCutter", 2, SerilizationMode5.MultiLine));
    StringList2.Add((object) "</MwCamSettings>");
    buFile.SaveToFile(StringList2, FileName2);
    buLog.addLog("Cuttter Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
  }

  public void OpenCutterFile()
  {
    ArrayList StringList1 = new ArrayList();
    FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Nesting\\CutterSet.prm");
    if (fileInfo1.Exists)
    {
      buFile.OpenFromFile(fileInfo1.FullName, ref StringList1);
      try
      {
        ArrayList CalcList = new ArrayList();
        buString.ListToSpecificList("<CutterSettings>", "</CutterSettings>", true, StringList1, ref CalcList);
        if (CalcList.Count > 0)
        {
          buSerilization.Decode(StringList1, "", SerilizationMode.MultiLine, (object) clsCutter.varCutterSettings);
          buLog.addLog("Cutter Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
        }
        else
        {
          buLog.addLog("<CutterSettings> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buString.MessageBoxError("<CutterSettings> Line Missing");
        }
      }
      catch (Exception ex)
      {
        buLog.addLog("Cutter Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Cutter Settings Decoder Error");
      }
    }
    else if (clsVar.appModes_0.NestingMode.Enable)
    {
      buLog.addLog("Cutter Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Cutter Settings File Missing");
    }
    FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Nesting\\mwCutterCommon.bin");
    if (fileInfo2.Exists)
      buMWCutterVars.varCamCutter.mwPar.Deserialize(fileInfo2.FullName);
    string str = AppPath.Settings + "\\Nesting\\CutterCam.bucamset";
    if (new FileInfo(str).Exists)
    {
      ArrayList StringList2 = new ArrayList();
      buFile.OpenFromFile(str, ref StringList2);
      try
      {
        ArrayList CalcList = new ArrayList();
        buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, StringList2, ref CalcList);
        if (CalcList.Count <= 0)
          return;
        buSerilization5.Decode(StringList2, "_varCamCommon", SerilizationMode5.MultiLine, (object) buMWCutterVars.varCamCutter.buPar);
      }
      catch (Exception ex)
      {
        buLog.addLog("MW Cutter Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Cutter Settings Decoder Error");
      }
    }
    else
    {
      buLog.addLog("Cutter Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buString.MessageBoxError("Cutter Cam Settings File Missing");
    }
  }

  public void AddCutterThingsToNestingResult(ref buNestedResult Result)
  {
    if (Result.NestingSheetList.Count <= 0)
      return;
    Result.PastalWidth = Result.NestedResultSheets[0].MaterialWidth;
  }

  public void ExtendEntitiesByRules1()
  {
    List<RulStrectPoints> rulStrectPointsList1 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList2 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList3 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList4 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList5 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList6 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList7 = new List<RulStrectPoints>();
    List<CutterNotch> cutterNotchList1 = new List<CutterNotch>();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<Entity> entityList4 = new List<Entity>();
    List<Entity> entityList5 = new List<Entity>();
    List<Entity> entityList6 = new List<Entity>();
    List<Entity> entityList7 = new List<Entity>();
    List<Entity> entityList8 = new List<Entity>();
    List<Entity> entityList9 = new List<Entity>();
    List<Entity> entityList10 = new List<Entity>();
    List<Entity> entityList11 = new List<Entity>();
    List<Entity> entityList12 = new List<Entity>();
    List<Entity> entityList13 = new List<Entity>();
    List<Entity> entityList14 = new List<Entity>();
    List<Entity> entityList15 = new List<Entity>();
    List<Entity> entityList16 = new List<Entity>();
    List<Entity> entityList17 = new List<Entity>();
    List<Entity> entityList18 = new List<Entity>();
    List<Entity> entityList19 = new List<Entity>();
    List<Entity> entityList20 = new List<Entity>();
    List<Entity> entityList21 = new List<Entity>();
    this.NotchList.Clear();
    this.NotchList = new List<CutterNotch>();
    FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
    List<ePoint> ePointList = new List<ePoint>();
    if (fileInfo.Exists)
    {
      List<eEntities> RefEntities = new List<eEntities>();
      List<LayerBase> Layers = new List<LayerBase>();
      new buFile.Dxf().ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
      for (int index = RefEntities.Count - 1; index >= 0; --index)
      {
        if (RefEntities[index].GetType() == typeof (ePoint))
        {
          eEntities CalcEnt = (eEntities) new ePoint();
          clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[index], ref CalcEnt);
          CalcEnt.geoAngleXY = RefEntities[index].geoAngleXY;
          ePointList.Add((ePoint) CalcEnt);
        }
      }
    }
    Layer layer1 = new Layer(clsCutter.varCutterSettings.NotchLayerName, Color.DarkRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer1);
    Layer layer2 = new Layer(clsCutter.varCutterSettings.InfoLayerName, Color.MediumVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer2);
    Layer layer3 = new Layer(clsCutter.varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer3);
    if (this.Properties.SizeList.Count == 0)
      this.Properties.SizeList.Add("");
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (devDept.Eyeshot.Entities.Point))
        entityList20.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == clsCutter.varCutterSettings.MirrorLayerName)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
        entityList21.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    for (int index1 = 0; index1 <= this.Properties.SizeList.Count - 1; ++index1)
    {
      List<RulStrectPoints> rulStrectPointsList8 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList9 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList10 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList11 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList12 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList13 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList14 = new List<RulStrectPoints>();
      List<CutterNotch> cutterNotchList2 = new List<CutterNotch>();
      List<Entity> entityList22 = new List<Entity>();
      List<Entity> entityList23 = new List<Entity>();
      List<Entity> entityList24 = new List<Entity>();
      List<Entity> entityList25 = new List<Entity>();
      List<Entity> entityList26 = new List<Entity>();
      List<Entity> entityList27 = new List<Entity>();
      for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] is devDept.Eyeshot.Entities.Point)
        {
          devDept.Eyeshot.Entities.Point entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] as devDept.Eyeshot.Entities.Point;
          for (int index3 = 0; index3 <= ePointList.Count - 1; ++index3)
          {
            if (buCompare5.EQ(ePointList[index3].StartPoint.X, entity.StartPoint.X, 0.01) & buCompare5.EQ(ePointList[index3].StartPoint.Y, entity.StartPoint.Y, 0.01) && ePointList[index3].auxText.IndexOf("39") >= 0 | ePointList[index3].auxText.IndexOf("50") >= 0)
            {
              if (entity.LayerName == clsCutter.varCutterSettings.NotchInsideLayerName)
              {
                CutterNotch cutterNotch = new CutterNotch();
                cutterNotch.Position = new Point3D(entity.StartPoint.X, entity.StartPoint.Y, 0.0);
                cutterNotch.NotchType = CutterNotchType.INotch;
                cutterNotch.Length = entity.StartPoint.Z;
                cutterNotch.Direction = InOutType.Inside;
                cutterNotch.DirectionAngle = ePointList[index3].geoAngleXY;
                if (cutterNotchList2.Count == 0)
                {
                  cutterNotchList2.Add(cutterNotch);
                }
                else
                {
                  bool flag = true;
                  for (int index4 = 0; index4 <= cutterNotchList2.Count - 1; ++index4)
                  {
                    if (buCompare5.EQ(cutterNotchList2[index4].Position, cutterNotch.Position))
                    {
                      flag = false;
                      index4 = cutterNotchList2.Count;
                    }
                  }
                  if (flag)
                    cutterNotchList2.Add(cutterNotch);
                }
              }
              if (entity.LayerName == clsCutter.varCutterSettings.NotchOutsideLayerName)
              {
                CutterNotch cutterNotch = new CutterNotch();
                cutterNotch.Position = new Point3D(entity.StartPoint.X, entity.StartPoint.Y, 0.0);
                cutterNotch.Length = entity.StartPoint.Z;
                cutterNotch.Direction = InOutType.Outside;
                cutterNotch.DirectionAngle = ePointList[index3].geoAngleXY;
                if (ePointList[index3].auxText.IndexOf("39") >= 0)
                {
                  cutterNotch.Width = ePointList[index3].auxValue;
                  cutterNotch.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch.Width / 2.0 / cutterNotch.Length)) * 2.0;
                  cutterNotch.NotchType = CutterNotchType.VNotch;
                }
                else
                  cutterNotch.NotchType = CutterNotchType.INotch;
                if (cutterNotchList2.Count == 0)
                {
                  cutterNotchList2.Add(cutterNotch);
                }
                else
                {
                  bool flag = true;
                  for (int index5 = 0; index5 <= cutterNotchList2.Count - 1; ++index5)
                  {
                    if (buCompare5.EQ(cutterNotchList2[index5].Position, cutterNotch.Position))
                    {
                      flag = false;
                      index5 = cutterNotchList2.Count;
                    }
                  }
                  if (flag)
                    cutterNotchList2.Add(cutterNotch);
                }
              }
            }
          }
        }
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] is Text)
        {
          Text entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] as Text;
          bool flag = false;
          if (entity.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index6 = 0; index6 <= this.Properties.RuleList.Count - 1; ++index6)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index6].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index6].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index6].Position[index1].Y;
              }
            }
            rulStrectPointsList8.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index7 = 0; index7 <= this.Properties.RuleList.Count - 1; ++index7)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index7].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index7].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index7].Position[index1].Y;
              }
            }
            rulStrectPointsList9.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index8 = 0; index8 <= this.Properties.RuleList.Count - 1; ++index8)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index8].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index8].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index8].Position[index1].Y;
              }
            }
            rulStrectPointsList10.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index9 = 0; index9 <= this.Properties.RuleList.Count - 1; ++index9)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index9].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index9].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index9].Position[index1].Y;
              }
            }
            rulStrectPointsList11.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.DrillLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index10 = 0; index10 <= this.Properties.RuleList.Count - 1; ++index10)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index10].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index10].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index10].Position[index1].Y;
              }
            }
            rulStrectPointsList12.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index11 = 0; index11 <= this.Properties.RuleList.Count - 1; ++index11)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index11].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index11].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index11].Position[index1].Y;
              }
            }
            rulStrectPointsList13.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index12 = 0; index12 <= this.Properties.RuleList.Count - 1; ++index12)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index12].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index12].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index12].Position[index1].Y;
              }
            }
            rulStrectPointsList14.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.DrillLayerName & index1 == 0 && entity.TextString.IndexOf("#-") >= 0)
          {
            double num = 5.0;
            for (int index13 = 0; index13 <= entityList20.Count - 1; ++index13)
            {
              if (entityList20[index13].LayerName == clsCutter.varCutterSettings.DrillLayerName && buCompare5.EQ(entity.InsertionPoint, ((devDept.Eyeshot.Entities.Point) entityList20[index13]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point) entityList20[index13]).StartPoint.Z > 0.0)
                num = ((devDept.Eyeshot.Entities.Point) entityList20[index13]).StartPoint.Z;
            }
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, entity.InsertionPoint);
            CustomData customData = new CustomData();
            Circle Ent = new Circle(entity.InsertionPoint, num / 2.0);
            clsInit.appCommand.CreateCircle(entity.InsertionPoint, num / 2.0, Plane.XY, entData, customData, ref Ent);
            ((CustomData) Ent.EntityData).infoData = this.Properties.SizeList[index1];
            entityList5.Add((Entity) Ent);
            flag = true;
          }
          if (!clsCutter.varCutterSettings.AddAttribute && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] is devDept.Eyeshot.Entities.Attribute)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            flag = true;
          }
          if (!flag && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            flag = true;
          }
          if (!flag & index1 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            Text text = (Text) entity.Clone();
            text.EntityData = (object) new CustomData((CustomData) entity.EntityData);
            text.LayerName = clsCutter.varCutterSettings.InfoLayerName;
            entityList17.Add((Entity) text);
          }
        }
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2] is ICurve)
        {
          Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2];
          ((CustomData) entity.EntityData).infoData = this.Properties.SizeList[index1];
          if (entity.LayerName == clsCutter.varCutterSettings.ContourLayerName)
          {
            entityList22.Add(buVector5.CopyEntities(entity));
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourLayerName)
          {
            entityList23.Add(buVector5.CopyEntities(entity));
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.ContourRefLayerName)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourRefLayerName)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
          if (entity.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName & index1 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            entityList24.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName & index1 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = false;
            entityList25.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName & index1 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            entityList26.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName & index1 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].Selected = true;
            entityList27.Add(buVector5.CopyEntities(entity));
          }
        }
      }
      if (entityList21.Count > 0)
      {
        List<RulStrectPoints> rulStrectPointsList15 = new List<RulStrectPoints>();
        List<CutterNotch> cutterNotchList3 = new List<CutterNotch>();
        for (int index14 = 0; index14 <= entityList21.Count - 1; ++index14)
        {
          Point3D startPoint = ((ICurve) entityList21[index14]).StartPoint;
          Point3D endPoint = ((ICurve) entityList21[index14]).EndPoint;
          Point3D point3D1 = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
          for (int index15 = 0; index15 <= entityList22.Count - 1; ++index15)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList22[index15].Vertices, ref point3DList);
            bool flag = false;
            for (int index16 = 1; index16 <= point3DList.Count - 1; ++index16)
            {
              Point3D point3D2 = clsInit.cVector5.MiddlePointOfLine(point3DList[index16 - 1], point3DList[index16]);
              if (buCompare5.EQ(point3D1, point3D2))
              {
                point3DList.RemoveAt(index16);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D3 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D3))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              for (int index17 = 0; index17 <= rulStrectPointsList8.Count - 1; ++index17)
              {
                Point3D refPoint = new Point3D(rulStrectPointsList8[index17].Position.X, rulStrectPointsList8[index17].Position.Y);
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList22[index15], refPoint, 0.1))
                {
                  RulStrectPoints rulStrectPoints = new RulStrectPoints(rulStrectPointsList8[index17]);
                  Point3D mirrorPoint = new Point3D();
                  clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                  rulStrectPoints.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
                  rulStrectPoints.dY = -rulStrectPointsList8[index17].dY;
                  rulStrectPointsList15.Add(rulStrectPoints);
                }
              }
              for (int index18 = 0; index18 <= cutterNotchList2.Count - 1; ++index18)
              {
                Point3D refPoint = new Point3D(cutterNotchList2[index18].Position.X, cutterNotchList2[index18].Position.Y);
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList22[index15], refPoint, 0.1))
                {
                  CutterNotch cutterNotch = new CutterNotch(cutterNotchList2[index18]);
                  Point3D mirrorPoint = new Point3D();
                  clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                  cutterNotch.Position = new Point3D(mirrorPoint.X, mirrorPoint.Y);
                  cutterNotch.DirectionAngle += 180.0;
                  cutterNotchList3.Add(cutterNotch);
                }
              }
              List<Point3D> mirrorPoint1 = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint1);
              mirrorPoint1.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint1);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList22[index15], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index1];
              entityList22[index15] = copiedEntity;
            }
          }
          for (int index19 = 0; index19 <= entityList26.Count - 1; ++index19)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList26[index19].Vertices, ref point3DList);
            bool flag = false;
            for (int index20 = 1; index20 <= point3DList.Count - 1; ++index20)
            {
              Point3D point3D4 = clsInit.cVector5.MiddlePointOfLine(point3DList[index20 - 1], point3DList[index20]);
              if (buCompare5.EQ(point3D1, point3D4))
              {
                point3DList.RemoveAt(index20);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D5 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D5, clsCutter.varCutterSettings.MirrorCenterPointCatchGapDistance))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              List<Point3D> mirrorPoint = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
              mirrorPoint.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList26[index19], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index1];
              entityList26[index19] = copiedEntity;
            }
          }
          for (int index21 = 0; index21 <= entityList27.Count - 1; ++index21)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList27[index21].Vertices, ref point3DList);
            bool flag = false;
            for (int index22 = 1; index22 <= point3DList.Count - 1; ++index22)
            {
              Point3D point3D6 = clsInit.cVector5.MiddlePointOfLine(point3DList[index22 - 1], point3DList[index22]);
              if (buCompare5.EQ(point3D1, point3D6))
              {
                point3DList.RemoveAt(index22);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D7 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D7, clsCutter.varCutterSettings.MirrorCenterPointCatchGapDistance))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index14], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              List<Point3D> mirrorPoint = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
              mirrorPoint.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList27[index21], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index1];
              entityList27[index21] = copiedEntity;
            }
          }
        }
        for (int index23 = 0; index23 <= rulStrectPointsList15.Count - 1; ++index23)
          rulStrectPointsList8.Add(new RulStrectPoints(rulStrectPointsList15[index23]));
        for (int index24 = 0; index24 <= cutterNotchList3.Count - 1; ++index24)
        {
          bool flag = true;
          for (int index25 = 0; index25 <= cutterNotchList2.Count - 1; ++index25)
          {
            if (buCompare5.EQ(cutterNotchList2[index25].Position, cutterNotchList3[index24].Position))
            {
              flag = false;
              index25 = cutterNotchList2.Count;
            }
          }
          if (flag)
            cutterNotchList2.Add(new CutterNotch(cutterNotchList3[index24]));
        }
      }
      for (int index26 = 0; index26 <= entityList22.Count - 1; ++index26)
      {
        List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt1 = new Pnt3D();
        Pnt3D pnt3D1 = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint1 = new Point3D();
        Point3D MidPoint1 = new Point3D();
        Point3D MaxPoint1 = new Point3D();
        ICurve refCurve = entityList22[index26] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList22[index26], ref MinPoint1, ref MidPoint1, ref MaxPoint1);
        for (int index27 = 0; index27 <= cutterNotchList2.Count - 1; ++index27)
        {
          Point3D point3D = new Point3D(cutterNotchList2[index27].Position.X, cutterNotchList2[index27].Position.Y);
          clsInit.cVector5.PointAngle(MidPoint1, point3D, Plane.XY);
          double t = 0.0;
          cutterNotchList2[index27].CurveAtLength = refCurve.Length();
          ((ICurve) entityList22[index26]).ClosestPointTo(point3D, out t);
          cutterNotchList2[index27].InCurve = clsInit.cVector5.isPointInsideEntity(refCurve, point3D, 1.0);
          cutterNotchList2[index27].CurveAtPersentage = t / cutterNotchList2[index27].CurveAtLength;
          if (cutterNotchList2[index27].InCurve)
          {
            Point3D BasePoint = refCurve.PointAt(t);
            Point3D TipPoint = refCurve.PointAt(t + 0.1);
            double num = clsInit.cVector5.PointAngle(TipPoint, BasePoint, Plane.XY);
            double Angle1 = num + 90.0;
            double Angle2 = num - 90.0;
            Point3D EndPnt1 = new Point3D();
            Point3D EndPnt2 = new Point3D();
            clsInit.cVector5.LineWithLengthAndAngle(new Point3D(cutterNotchList2[index27].Position.X, cutterNotchList2[index27].Position.Y), 2.0, Angle1, ref EndPnt1);
            clsInit.cVector5.LineWithLengthAndAngle(new Point3D(cutterNotchList2[index27].Position.X, cutterNotchList2[index27].Position.Y), 2.0, Angle2, ref EndPnt2);
            Utility.PointInPolygon((Point2D) EndPnt1, (IList<Point2D>) entityList22[index26].Vertices);
            Utility.PointInPolygon((Point2D) EndPnt2, (IList<Point2D>) entityList22[index26].Vertices);
            cutterNotchList2[index27].baseEntityIndex = index26;
            cutterNotchList2[index27].baseEntityName = ((CustomData) entityList22[index26].EntityData).EntityName;
          }
        }
        for (int index28 = 0; index28 <= entityList22[index26].Vertices.Length - 1; ++index28)
        {
          Pnt3D Pnt2 = new Pnt3D(entityList22[index26].Vertices[index28].X, entityList22[index26].Vertices[index28].Y, entityList22[index26].Vertices[index28].Z);
          bool flag = false;
          for (int index29 = 0; index29 <= rulStrectPointsList8.Count - 1; ++index29)
          {
            if (buCompare5.EQ(Pnt2, rulStrectPointsList8[index29].Position))
            {
              Pnt1 = new Pnt3D(Pnt2);
              double dX = rulStrectPointsList8[index29].dX;
              double dY = rulStrectPointsList8[index29].dY;
              Pnt2 = new Pnt3D(Pnt2.X + rulStrectPointsList8[index29].dX, Pnt2.Y + rulStrectPointsList8[index29].dY, Pnt2.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D1));
              Points.Add(new Pnt3D(Pnt1));
              Pnt3D MinPoint2 = new Pnt3D();
              Pnt3D MidPoint2 = new Pnt3D();
              Pnt3D MaxPoint2 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
              double RatioX = (Pnt2.X - CopiedPnt1[CopiedPnt1.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt2.Y - CopiedPnt1[CopiedPnt1.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D1, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num1 = CopiedPnt1[CopiedPnt1.Count - 1].X - Points[0].X;
              double num2 = CopiedPnt1[CopiedPnt1.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt1[CopiedPnt1.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt1);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt1.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
            pnt3D1 = new Pnt3D(Pnt1);
          }
          else
            Points.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList22[index26].EntityData);
        LinearPath Ent1 = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt2 = new List<Point3D>();
        if (CopiedPnt1.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt1, ref CopiedPnt2);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
        clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData, customData, ref Ent1);
        Ent1.EntityData = (object) customData;
        entityList2.Add((Entity) Ent1);
        for (int index30 = 0; index30 <= cutterNotchList2.Count - 1; ++index30)
        {
          Pnt3D Pnt3 = new Pnt3D(cutterNotchList2[index30].Position.X, cutterNotchList2[index30].Position.Y, cutterNotchList2[index30].Position.Z);
          for (int index31 = 0; index31 <= rulStrectPointsList8.Count - 1; ++index31)
          {
            if (buCompare5.EQ(Pnt3, rulStrectPointsList8[index31].Position))
            {
              Pnt3D pnt3D2 = new Pnt3D(Pnt3);
              double dX = rulStrectPointsList8[index30].dX;
              double dY = rulStrectPointsList8[index30].dY;
              cutterNotchList2[index30].Position = new Point3D(Pnt3.X + rulStrectPointsList8[index31].dX, Pnt3.Y + rulStrectPointsList8[index31].dY, Pnt3.Z);
              index31 = rulStrectPointsList8.Count;
            }
          }
          if (cutterNotchList2[index30].InCurve | !cutterNotchList2[index30].InCurve)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy((Entity) Ent1, ref copiedEntity);
            ICurve baseEntity = (ICurve) copiedEntity;
            List<Entity> notchEntities = new List<Entity>();
            Point3D point3D = buVector5.ToPoint3D(cutterNotchList2[index30].Position);
            clsInit.cCutter.CreateNotch(cutterNotchList2[index30].NotchType, point3D, cutterNotchList2[index30].Length, cutterNotchList2[index30].DirectionAngle, cutterNotchList2[index30].Angle, baseEntity, ref notchEntities);
            for (int index32 = 0; index32 <= notchEntities.Count - 1; ++index32)
            {
              Entity Ent2 = (Entity) null;
              clsInit.appCommand.CreateEntity(notchEntities[index32], ref Ent2);
              Ent2.LayerName = clsCutter.varCutterSettings.NotchLayerName;
              ((CustomData) Ent2.EntityData).infoBasePoint = new Point3D(cutterNotchList2[index30].Position.X, cutterNotchList2[index30].Position.Y, cutterNotchList2[index30].Position.Z);
              ((CustomData) Ent2.EntityData).infoLength = cutterNotchList2[index30].Length;
              ((CustomData) Ent2.EntityData).infoWidth = cutterNotchList2[index30].Width;
              ((CustomData) Ent2.EntityData).infoAngle = cutterNotchList2[index30].Angle;
              ((CustomData) Ent2.EntityData).infoDirection = cutterNotchList2[index30].DirectionAngle;
              ((CustomData) Ent2.EntityData).ActionName = ((CustomData) entityList22[index26].EntityData).EntityName;
              ((CustomData) Ent2.EntityData).infoString = cutterNotchList2[index30].NotchType.ToString();
              ((CustomData) Ent2.EntityData).infoData = this.Properties.SizeList[index1];
              entityList19.Add(Ent2);
            }
          }
        }
      }
      for (int index33 = 0; index33 <= entityList23.Count - 1; ++index33)
      {
        List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt4 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint3 = new Point3D();
        Point3D MidPoint3 = new Point3D();
        Point3D MaxPoint3 = new Point3D();
        ICurve curve = entityList23[index33] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList23[index33], ref MinPoint3, ref MidPoint3, ref MaxPoint3);
        for (int index34 = 0; index34 <= entityList23[index33].Vertices.Length - 1; ++index34)
        {
          Pnt3D Pnt5 = new Pnt3D(entityList23[index33].Vertices[index34].X, entityList23[index33].Vertices[index34].Y, entityList23[index33].Vertices[index34].Z);
          bool flag = false;
          for (int index35 = 0; index35 <= rulStrectPointsList9.Count - 1; ++index35)
          {
            if (buCompare5.EQ(Pnt5, rulStrectPointsList9[index35].Position))
            {
              Pnt4 = new Pnt3D(Pnt5);
              double dX = rulStrectPointsList9[index35].dX;
              double dY = rulStrectPointsList9[index35].dY;
              Pnt5 = new Pnt3D(Pnt5.X + rulStrectPointsList9[index35].dX, Pnt5.Y + rulStrectPointsList9[index35].dY, Pnt5.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt4));
              Pnt3D MinPoint4 = new Pnt3D();
              Pnt3D MidPoint4 = new Pnt3D();
              Pnt3D MaxPoint4 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
              double RatioX = (Pnt5.X - CopiedPnt3[CopiedPnt3.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt5.Y - CopiedPnt3[CopiedPnt3.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num3 = CopiedPnt3[CopiedPnt3.Count - 1].X - Points[0].X;
              double num4 = CopiedPnt3[CopiedPnt3.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt3[CopiedPnt3.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt3);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt3.Add(new Pnt3D(Pnt5.X, Pnt5.Y, Pnt5.Z));
            pnt3D = new Pnt3D(Pnt4);
          }
          else
            Points.Add(new Pnt3D(Pnt5.X, Pnt5.Y, Pnt5.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList23[index33].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt4 = new List<Point3D>();
        if (CopiedPnt3.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt3, ref CopiedPnt4);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt4);
        clsInit.appCommand.CreatePolyLine(CopiedPnt4, entData, customData, ref Ent);
        entityList4.Add((Entity) Ent);
      }
      for (int index36 = 0; index36 <= entityList25.Count - 1; ++index36)
      {
        List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt6 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint5 = new Point3D();
        Point3D MidPoint5 = new Point3D();
        Point3D MaxPoint5 = new Point3D();
        ICurve curve = entityList25[index36] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList25[index36], ref MinPoint5, ref MidPoint5, ref MaxPoint5);
        for (int index37 = 0; index37 <= entityList25[index36].Vertices.Length - 1; ++index37)
        {
          Pnt3D Pnt7 = new Pnt3D(entityList25[index36].Vertices[index37].X, entityList25[index36].Vertices[index37].Y, entityList25[index36].Vertices[index37].Z);
          bool flag = false;
          for (int index38 = 0; index38 <= rulStrectPointsList10.Count - 1; ++index38)
          {
            if (buCompare5.EQ(Pnt7, rulStrectPointsList10[index38].Position))
            {
              Pnt6 = new Pnt3D(Pnt7);
              double dX = rulStrectPointsList10[index38].dX;
              double dY = rulStrectPointsList10[index38].dY;
              Pnt7 = new Pnt3D(Pnt7.X + rulStrectPointsList10[index38].dX, Pnt7.Y + rulStrectPointsList10[index38].dY, Pnt7.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt6));
              Pnt3D MinPoint6 = new Pnt3D();
              Pnt3D MidPoint6 = new Pnt3D();
              Pnt3D MaxPoint6 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint6, ref MidPoint6, ref MaxPoint6);
              double RatioX = (Pnt7.X - CopiedPnt5[CopiedPnt5.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt7.Y - CopiedPnt5[CopiedPnt5.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num5 = CopiedPnt5[CopiedPnt5.Count - 1].X - Points[0].X;
              double num6 = CopiedPnt5[CopiedPnt5.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt5[CopiedPnt5.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt5);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt5.Add(new Pnt3D(Pnt7.X, Pnt7.Y, Pnt7.Z));
            pnt3D = new Pnt3D(Pnt6);
          }
          else
            Points.Add(new Pnt3D(Pnt7.X, Pnt7.Y, Pnt7.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourNoCutLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList25[index36].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt6 = new List<Point3D>();
        if (CopiedPnt5.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt5, ref CopiedPnt6);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt6);
        clsInit.appCommand.CreatePolyLine(CopiedPnt6, entData, customData, ref Ent);
        entityList12.Add((Entity) Ent);
      }
      for (int index39 = 0; index39 <= entityList24.Count - 1; ++index39)
      {
        List<Pnt3D> CopiedPnt7 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt8 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint7 = new Point3D();
        Point3D MidPoint7 = new Point3D();
        Point3D MaxPoint7 = new Point3D();
        ICurve curve = entityList24[index39] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList24[index39], ref MinPoint7, ref MidPoint7, ref MaxPoint7);
        for (int index40 = 0; index40 <= entityList24[index39].Vertices.Length - 1; ++index40)
        {
          Pnt3D Pnt9 = new Pnt3D(entityList24[index39].Vertices[index40].X, entityList24[index39].Vertices[index40].Y, entityList24[index39].Vertices[index40].Z);
          bool flag = false;
          for (int index41 = 0; index41 <= rulStrectPointsList11.Count - 1; ++index41)
          {
            if (buCompare5.EQ(Pnt9, rulStrectPointsList11[index41].Position))
            {
              Pnt8 = new Pnt3D(Pnt9);
              double dX = rulStrectPointsList11[index41].dX;
              double dY = rulStrectPointsList11[index41].dY;
              Pnt9 = new Pnt3D(Pnt9.X + rulStrectPointsList11[index41].dX, Pnt9.Y + rulStrectPointsList11[index41].dY, Pnt9.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt8));
              Pnt3D MinPoint8 = new Pnt3D();
              Pnt3D MidPoint8 = new Pnt3D();
              Pnt3D MaxPoint8 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint8, ref MidPoint8, ref MaxPoint8);
              double RatioX = (Pnt9.X - CopiedPnt7[CopiedPnt7.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt9.Y - CopiedPnt7[CopiedPnt7.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num7 = CopiedPnt7[CopiedPnt7.Count - 1].X - Points[0].X;
              double num8 = CopiedPnt7[CopiedPnt7.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt7[CopiedPnt7.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt7);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt7.Add(new Pnt3D(Pnt9.X, Pnt9.Y, Pnt9.Z));
            pnt3D = new Pnt3D(Pnt8);
          }
          else
            Points.Add(new Pnt3D(Pnt9.X, Pnt9.Y, Pnt9.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.RopeDirectionLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList24[index39].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt8 = new List<Point3D>();
        if (CopiedPnt7.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt7, ref CopiedPnt8);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt8);
        clsInit.appCommand.CreatePolyLine(CopiedPnt8, entData, customData, ref Ent);
        entityList10.Add((Entity) Ent);
      }
      for (int index42 = 0; index42 <= entityList5.Count - 1; ++index42)
      {
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(entityList5[index42], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt3D pnt3D = new Pnt3D(((Circle) entityList5[index42]).Center.X, ((Circle) entityList5[index42]).Center.Y, ((Circle) entityList5[index42]).Center.Z);
        double radius = ((Circle) entityList5[index42]).Radius;
        for (int index43 = 0; index43 <= rulStrectPointsList12.Count - 1; ++index43)
        {
          if (buCompare5.EQ(pnt3D, rulStrectPointsList12[index43].Position))
            pnt3D = new Pnt3D(pnt3D.X + rulStrectPointsList12[index43].dX, pnt3D.Y + rulStrectPointsList12[index43].dY, pnt3D.Z);
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList5[index42].EntityData);
        customData.infoData = this.Properties.SizeList[index1];
        Circle Ent = (Circle) null;
        clsInit.appCommand.CreateCircle(new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z), radius, Plane.XY, entData, customData, ref Ent);
        entityList8.Add((Entity) Ent);
      }
      for (int index44 = 0; index44 <= entityList26.Count - 1; ++index44)
      {
        List<Pnt3D> CopiedPnt9 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt10 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint9 = new Point3D();
        Point3D MidPoint9 = new Point3D();
        Point3D MaxPoint9 = new Point3D();
        ICurve curve = entityList26[index44] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList26[index44], ref MinPoint9, ref MidPoint9, ref MaxPoint9);
        for (int index45 = 0; index45 <= entityList26[index44].Vertices.Length - 1; ++index45)
        {
          Pnt3D Pnt11 = new Pnt3D(entityList26[index44].Vertices[index45].X, entityList26[index44].Vertices[index45].Y, entityList26[index44].Vertices[index45].Z);
          bool flag = false;
          for (int index46 = 0; index46 <= rulStrectPointsList13.Count - 1; ++index46)
          {
            if (buCompare5.EQ(Pnt11, rulStrectPointsList13[index46].Position))
            {
              Pnt10 = new Pnt3D(Pnt11);
              double dX = rulStrectPointsList13[index46].dX;
              double dY = rulStrectPointsList13[index46].dY;
              Pnt11 = new Pnt3D(Pnt11.X + rulStrectPointsList13[index46].dX, Pnt11.Y + rulStrectPointsList13[index46].dY, Pnt11.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt10));
              Pnt3D MinPoint10 = new Pnt3D();
              Pnt3D MidPoint10 = new Pnt3D();
              Pnt3D MaxPoint10 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint10, ref MidPoint10, ref MaxPoint10);
              double RatioX = (Pnt11.X - CopiedPnt9[CopiedPnt9.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt11.Y - CopiedPnt9[CopiedPnt9.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num9 = CopiedPnt9[CopiedPnt9.Count - 1].X - Points[0].X;
              double num10 = CopiedPnt9[CopiedPnt9.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt9[CopiedPnt9.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt9);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt9.Add(new Pnt3D(Pnt11.X, Pnt11.Y, Pnt11.Z));
            pnt3D = new Pnt3D(Pnt10);
          }
          else
            Points.Add(new Pnt3D(Pnt11.X, Pnt11.Y, Pnt11.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourPloter1LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList26[index44].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt10 = new List<Point3D>();
        if (CopiedPnt9.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt9, ref CopiedPnt10);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt10);
        clsInit.appCommand.CreatePolyLine(CopiedPnt10, entData, customData, ref Ent);
        entityList14.Add((Entity) Ent);
      }
      for (int index47 = 0; index47 <= entityList27.Count - 1; ++index47)
      {
        List<Pnt3D> CopiedPnt11 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt12 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint11 = new Point3D();
        Point3D MidPoint11 = new Point3D();
        Point3D MaxPoint11 = new Point3D();
        ICurve curve = entityList27[index47] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList27[index47], ref MinPoint11, ref MidPoint11, ref MaxPoint11);
        for (int index48 = 0; index48 <= entityList27[index47].Vertices.Length - 1; ++index48)
        {
          Pnt3D Pnt13 = new Pnt3D(entityList27[index47].Vertices[index48].X, entityList27[index47].Vertices[index48].Y, entityList27[index47].Vertices[index48].Z);
          bool flag = false;
          for (int index49 = 0; index49 <= rulStrectPointsList14.Count - 1; ++index49)
          {
            if (buCompare5.EQ(Pnt13, rulStrectPointsList14[index49].Position))
            {
              Pnt12 = new Pnt3D(Pnt13);
              double dX = rulStrectPointsList14[index49].dX;
              double dY = rulStrectPointsList14[index49].dY;
              Pnt13 = new Pnt3D(Pnt13.X + rulStrectPointsList14[index49].dX, Pnt13.Y + rulStrectPointsList14[index49].dY, Pnt13.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt12));
              Pnt3D MinPoint12 = new Pnt3D();
              Pnt3D MidPoint12 = new Pnt3D();
              Pnt3D MaxPoint12 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint12, ref MidPoint12, ref MaxPoint12);
              double RatioX = (Pnt13.X - CopiedPnt11[CopiedPnt11.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt13.Y - CopiedPnt11[CopiedPnt11.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num11 = CopiedPnt11[CopiedPnt11.Count - 1].X - Points[0].X;
              double num12 = CopiedPnt11[CopiedPnt11.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt11[CopiedPnt11.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt11);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt11.Add(new Pnt3D(Pnt13.X, Pnt13.Y, Pnt13.Z));
            pnt3D = new Pnt3D(Pnt12);
          }
          else
            Points.Add(new Pnt3D(Pnt13.X, Pnt13.Y, Pnt13.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourPloter2LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList27[index47].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt12 = new List<Point3D>();
        if (CopiedPnt11.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt11, ref CopiedPnt12);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt12);
        clsInit.appCommand.CreatePolyLine(CopiedPnt12, entData, customData, ref Ent);
        entityList16.Add((Entity) Ent);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    for (int index = 0; index <= entityList2.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList2[index].EntityData).typeDefination = entityTypeDefination.Cutting;
      clsInit.appCommand.AddEntity(entityList2[index]);
    }
    for (int index = 0; index <= entityList19.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList19[index].EntityData).typeDefination = entityTypeDefination.Notch;
      clsInit.appCommand.AddEntity(entityList19[index]);
    }
    for (int index = 0; index <= entityList4.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList4[index].EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
      clsInit.appCommand.AddEntity(entityList4[index]);
    }
    for (int index = 0; index <= entityList14.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      clsInit.appCommand.AddEntity(entityList14[index]);
      ((CustomData) entityList14[index].EntityData).typeDefination = entityTypeDefination.InnerAux;
    }
    for (int index = 0; index <= entityList16.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList16[index].EntityData).typeDefination = entityTypeDefination.InnerAux;
      clsInit.appCommand.AddEntity(entityList16[index]);
    }
    for (int index50 = 0; index50 <= entityList10.Count - 1; ++index50)
    {
      ((CustomData) entityList10[index50].EntityData).typeDefination = entityTypeDefination.Direction;
      double num = Point3D.Distance(entityList10[index50].Vertices[0], entityList10[index50].Vertices[entityList10[index50].Vertices.Length - 1]);
      List<Entity> calcEntities = new List<Entity>();
      clsInit.cVector5.DrawWireArrow(entityList10[index50].Vertices[0], entityList10[index50].Vertices[entityList10[index50].Vertices.Length - 1], num * 0.1, 15.0, Plane.XY, ref calcEntities);
      for (int index51 = 0; index51 <= calcEntities.Count - 1; ++index51)
      {
        Entity copiedEntity = calcEntities[index51];
        clsInit.cVector5.CopyEntityProperties(entityList10[index50], ref copiedEntity);
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(copiedEntity);
      }
    }
    for (int index52 = 0; index52 <= entityList17.Count - 1; ++index52)
    {
      ccVars.UndoDont = true;
      bool flag = false;
      for (int index53 = 0; index53 <= entityList2.Count - 1; ++index53)
      {
        Point3D insertionPoint = ((Text) entityList17[index52]).InsertionPoint;
        if (entityList2[index53].BoxMin == (Point3D) null)
          entityList2[index53].Regen(new RegenParams(0.01, (IWorkspace) ccVars.Pages[ccVars.PageIndex].Form.viewportcad));
        if (clsInit.cVector5.IsPointInsideBoxsize(((Text) entityList17[index52]).InsertionPoint, entityList2[index53].BoxMin, entityList2[index53].BoxMax, Plane.XY))
          flag = true;
      }
      ((CustomData) entityList17[index52].EntityData).typeDefination = entityTypeDefination.Info;
      if (flag)
      {
        entityList17[index52].LayerName = clsCutter.varCutterSettings.PartInfoLayerName;
        clsInit.appCommand.AddEntity(entityList17[index52]);
      }
      else
        clsInit.appCommand.AddEntity(entityList17[index52]);
    }
    for (int index = 0; index <= entityList8.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList8[index].EntityData).typeDefination = entityTypeDefination.Drill;
      clsInit.appCommand.AddEntity(entityList8[index]);
    }
  }

  public void ExtendEntitiesByRules2()
  {
    List<RulStrectPoints> rulStrectPointsList1 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList2 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList3 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList4 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList5 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList6 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList7 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList8 = new List<RulStrectPoints>();
    List<CutterNotch> cutterNotchList1 = new List<CutterNotch>();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<Entity> entityList4 = new List<Entity>();
    List<Entity> entityList5 = new List<Entity>();
    List<Entity> entityList6 = new List<Entity>();
    List<Entity> entityList7 = new List<Entity>();
    List<Entity> entityList8 = new List<Entity>();
    List<Entity> entityList9 = new List<Entity>();
    List<Entity> entityList10 = new List<Entity>();
    List<Entity> entityList11 = new List<Entity>();
    List<Entity> entityList12 = new List<Entity>();
    List<Entity> entityList13 = new List<Entity>();
    List<Entity> entityList14 = new List<Entity>();
    List<Entity> entityList15 = new List<Entity>();
    List<Entity> entityList16 = new List<Entity>();
    List<Entity> entityList17 = new List<Entity>();
    List<Entity> entityList18 = new List<Entity>();
    List<Entity> entityList19 = new List<Entity>();
    List<Entity> entityList20 = new List<Entity>();
    List<Entity> entityList21 = new List<Entity>();
    this.NotchList.Clear();
    this.NotchList = new List<CutterNotch>();
    FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
    List<ePoint> ePointList = new List<ePoint>();
    if (fileInfo.Exists)
    {
      List<eEntities> RefEntities = new List<eEntities>();
      List<LayerBase> Layers = new List<LayerBase>();
      new buFile.Dxf().ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
      for (int index = RefEntities.Count - 1; index >= 0; --index)
      {
        if (RefEntities[index].GetType() == typeof (ePoint))
        {
          eEntities CalcEnt = (eEntities) new ePoint();
          clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[index], ref CalcEnt);
          CalcEnt.geoAngleXY = RefEntities[index].geoAngleXY;
          ePointList.Add((ePoint) CalcEnt);
        }
      }
    }
    Layer layer1 = new Layer(clsCutter.varCutterSettings.NotchLayerName, Color.DarkRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer1);
    Layer layer2 = new Layer(clsCutter.varCutterSettings.InfoLayerName, Color.MediumVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer2);
    Layer layer3 = new Layer(clsCutter.varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer3);
    if (this.Properties.SizeList.Count == 0)
      this.Properties.SizeList.Add("");
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (devDept.Eyeshot.Entities.Point))
        entityList20.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].LayerName == clsCutter.varCutterSettings.MirrorLayerName)
      {
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
        entityList21.Add((Entity) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Clone());
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    for (int index1 = 0; index1 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index1)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1] is devDept.Eyeshot.Entities.Point)
      {
        devDept.Eyeshot.Entities.Point entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index1] as devDept.Eyeshot.Entities.Point;
        for (int index2 = 0; index2 <= ePointList.Count - 1; ++index2)
        {
          if (buCompare5.EQ(ePointList[index2].StartPoint.X, entity.StartPoint.X, 0.01) & buCompare5.EQ(ePointList[index2].StartPoint.Y, entity.StartPoint.Y, 0.01) && ePointList[index2].auxText.IndexOf("39") >= 0 | ePointList[index2].auxText.IndexOf("50") >= 0)
          {
            if (entity.LayerName == clsCutter.varCutterSettings.NotchInsideLayerName)
              cutterNotchList1.Add(new CutterNotch()
              {
                Position = new Point3D(entity.StartPoint.X, entity.StartPoint.Y, 0.0),
                NotchType = CutterNotchType.INotch,
                Length = entity.StartPoint.Z,
                Direction = InOutType.Inside,
                DirectionAngle = ePointList[index2].geoAngleXY
              });
            if (entity.LayerName == clsCutter.varCutterSettings.NotchOutsideLayerName)
            {
              CutterNotch cutterNotch = new CutterNotch();
              cutterNotch.Position = new Point3D(entity.StartPoint.X, entity.StartPoint.Y, 0.0);
              cutterNotch.Length = entity.StartPoint.Z;
              cutterNotch.Direction = InOutType.Outside;
              cutterNotch.DirectionAngle = ePointList[index2].geoAngleXY;
              if (ePointList[index2].auxText.IndexOf("39") >= 0)
              {
                cutterNotch.Width = ePointList[index2].auxValue;
                cutterNotch.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch.Width / 2.0 / cutterNotch.Length)) * 2.0;
                cutterNotch.NotchType = CutterNotchType.VNotch;
              }
              else
                cutterNotch.NotchType = CutterNotchType.INotch;
              cutterNotchList1.Add(cutterNotch);
            }
          }
        }
      }
    }
    for (int index3 = 0; index3 <= this.Properties.SizeList.Count - 1; ++index3)
    {
      List<RulStrectPoints> rulStrectPointsList9 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList10 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList11 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList12 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList13 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList14 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList15 = new List<RulStrectPoints>();
      List<RulStrectPoints> rulStrectPointsList16 = new List<RulStrectPoints>();
      List<Entity> entityList22 = new List<Entity>();
      List<Entity> entityList23 = new List<Entity>();
      List<Entity> entityList24 = new List<Entity>();
      List<Entity> entityList25 = new List<Entity>();
      List<Entity> entityList26 = new List<Entity>();
      List<Entity> entityList27 = new List<Entity>();
      for (int index4 = 0; index4 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index4)
      {
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] is Text)
        {
          Text entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] as Text;
          bool flag = false;
          if (entity.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32_1 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints1 = new RulStrectPoints();
            rulStrectPoints1.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints1.No = int32_1;
            for (int index5 = 0; index5 <= this.Properties.RuleList.Count - 1; ++index5)
            {
              if (rulStrectPoints1.No == this.Properties.RuleList[index5].No)
              {
                rulStrectPoints1.dX = this.Properties.RuleList[index5].Position[index3].X;
                rulStrectPoints1.dY = this.Properties.RuleList[index5].Position[index3].Y;
              }
            }
            rulStrectPointsList9.Add(rulStrectPoints1);
            flag = true;
            for (int index6 = 0; index6 <= cutterNotchList1.Count - 1; ++index6)
            {
              if (buCompare5.EQ(buVector5.ToPoint3D(cutterNotchList1[index6].Position), entity.InsertionPoint, 0.1))
              {
                int int32_2 = Convert.ToInt32(entity.TextString.Replace("#", ""));
                RulStrectPoints rulStrectPoints2 = new RulStrectPoints();
                rulStrectPoints2.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
                rulStrectPoints2.No = int32_2;
                for (int index7 = 0; index7 <= this.Properties.RuleList.Count - 1; ++index7)
                {
                  if (rulStrectPoints2.No == this.Properties.RuleList[index7].No)
                  {
                    rulStrectPoints2.dX = this.Properties.RuleList[index7].Position[index3].X;
                    rulStrectPoints2.dY = this.Properties.RuleList[index7].Position[index3].Y;
                  }
                }
                rulStrectPointsList16.Add(rulStrectPoints2);
              }
            }
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index8 = 0; index8 <= this.Properties.RuleList.Count - 1; ++index8)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index8].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index8].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index8].Position[index3].Y;
              }
            }
            rulStrectPointsList10.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index9 = 0; index9 <= this.Properties.RuleList.Count - 1; ++index9)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index9].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index9].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index9].Position[index3].Y;
              }
            }
            rulStrectPointsList11.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index10 = 0; index10 <= this.Properties.RuleList.Count - 1; ++index10)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index10].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index10].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index10].Position[index3].Y;
              }
            }
            rulStrectPointsList12.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.DrillLayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index11 = 0; index11 <= this.Properties.RuleList.Count - 1; ++index11)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index11].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index11].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index11].Position[index3].Y;
              }
            }
            rulStrectPointsList13.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index12 = 0; index12 <= this.Properties.RuleList.Count - 1; ++index12)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index12].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index12].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index12].Position[index3].Y;
              }
            }
            rulStrectPointsList14.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            int int32 = Convert.ToInt32(entity.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(entity.InsertionPoint.X, entity.InsertionPoint.Y, entity.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index13 = 0; index13 <= this.Properties.RuleList.Count - 1; ++index13)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index13].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index13].Position[index3].X;
                rulStrectPoints.dY = this.Properties.RuleList[index13].Position[index3].Y;
              }
            }
            rulStrectPointsList15.Add(rulStrectPoints);
            flag = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.DrillLayerName & index3 == 0 && entity.TextString.IndexOf("#-") >= 0)
          {
            double num = 5.0;
            for (int index14 = 0; index14 <= entityList20.Count - 1; ++index14)
            {
              if (entityList20[index14].LayerName == clsCutter.varCutterSettings.DrillLayerName && buCompare5.EQ(entity.InsertionPoint, ((devDept.Eyeshot.Entities.Point) entityList20[index14]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point) entityList20[index14]).StartPoint.Z > 0.0)
                num = ((devDept.Eyeshot.Entities.Point) entityList20[index14]).StartPoint.Z;
            }
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, entity.InsertionPoint);
            CustomData customData = new CustomData();
            Circle Ent = new Circle(entity.InsertionPoint, num / 2.0);
            clsInit.appCommand.CreateCircle(entity.InsertionPoint, num / 2.0, Plane.XY, entData, customData, ref Ent);
            ((CustomData) Ent.EntityData).infoData = this.Properties.SizeList[index3];
            entityList5.Add((Entity) Ent);
            flag = true;
          }
          if (!clsCutter.varCutterSettings.AddAttribute && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] is devDept.Eyeshot.Entities.Attribute)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            flag = true;
          }
          if (!flag && entity.TextString.IndexOf("#-") >= 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            flag = true;
          }
          if (!flag & index3 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            Text text = (Text) entity.Clone();
            text.EntityData = (object) new CustomData((CustomData) entity.EntityData);
            text.LayerName = clsCutter.varCutterSettings.InfoLayerName;
            entityList17.Add((Entity) text);
          }
        }
        if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4] is ICurve)
        {
          Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4];
          ((CustomData) entity.EntityData).infoData = this.Properties.SizeList[index3];
          if (entity.LayerName == clsCutter.varCutterSettings.ContourLayerName)
          {
            entityList22.Add(buVector5.CopyEntities(entity));
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourLayerName)
          {
            entityList23.Add(buVector5.CopyEntities(entity));
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
          }
          if (entity.LayerName == clsCutter.varCutterSettings.ContourRefLayerName)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourRefLayerName)
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
          if (entity.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName & index3 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            entityList24.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName & index3 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = false;
            entityList25.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName & index3 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            entityList26.Add(buVector5.CopyEntities(entity));
          }
          if (entity.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName & index3 == 0)
          {
            ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index4].Selected = true;
            entityList27.Add(buVector5.CopyEntities(entity));
          }
        }
      }
      if (entityList21.Count > 0)
      {
        List<RulStrectPoints> rulStrectPointsList17 = new List<RulStrectPoints>();
        List<CutterNotch> cutterNotchList2 = new List<CutterNotch>();
        for (int index15 = 0; index15 <= entityList21.Count - 1; ++index15)
        {
          Point3D startPoint = ((ICurve) entityList21[index15]).StartPoint;
          Point3D endPoint = ((ICurve) entityList21[index15]).EndPoint;
          Point3D point3D1 = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
          for (int index16 = 0; index16 <= entityList22.Count - 1; ++index16)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList22[index16].Vertices, ref point3DList);
            bool flag = false;
            for (int index17 = 1; index17 <= point3DList.Count - 1; ++index17)
            {
              Point3D point3D2 = clsInit.cVector5.MiddlePointOfLine(point3DList[index17 - 1], point3DList[index17]);
              if (buCompare5.EQ(point3D1, point3D2))
              {
                point3DList.RemoveAt(index17);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D3 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D3))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              for (int index18 = 0; index18 <= rulStrectPointsList9.Count - 1; ++index18)
              {
                Point3D refPoint = new Point3D(rulStrectPointsList9[index18].Position.X, rulStrectPointsList9[index18].Position.Y);
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList22[index16], refPoint, 0.1))
                {
                  RulStrectPoints rulStrectPoints = new RulStrectPoints(rulStrectPointsList9[index18]);
                  Point3D mirrorPoint = new Point3D();
                  clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                  rulStrectPoints.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
                  rulStrectPoints.dY = -rulStrectPointsList9[index18].dY;
                  rulStrectPointsList17.Add(rulStrectPoints);
                }
              }
              for (int index19 = 0; index19 <= cutterNotchList1.Count - 1; ++index19)
              {
                Point3D refPoint = new Point3D(cutterNotchList1[index19].Position.X, cutterNotchList1[index19].Position.Y);
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList22[index16], refPoint, 0.1))
                {
                  CutterNotch cutterNotch = new CutterNotch(cutterNotchList1[index19]);
                  Point3D mirrorPoint = new Point3D();
                  clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                  cutterNotch.Position = new Point3D(mirrorPoint.X, mirrorPoint.Y);
                  cutterNotch.DirectionAngle += 180.0;
                  cutterNotchList2.Add(cutterNotch);
                }
              }
              List<Point3D> mirrorPoint1 = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint1);
              mirrorPoint1.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint1);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList22[index16], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index3];
              entityList22[index16] = copiedEntity;
            }
          }
          for (int index20 = 0; index20 <= entityList26.Count - 1; ++index20)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList26[index20].Vertices, ref point3DList);
            bool flag = false;
            for (int index21 = 1; index21 <= point3DList.Count - 1; ++index21)
            {
              Point3D point3D4 = clsInit.cVector5.MiddlePointOfLine(point3DList[index21 - 1], point3DList[index21]);
              if (buCompare5.EQ(point3D1, point3D4))
              {
                point3DList.RemoveAt(index21);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D5 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D5, clsCutter.varCutterSettings.MirrorCenterPointCatchGapDistance))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              List<Point3D> mirrorPoint = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
              mirrorPoint.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList26[index20], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index3];
              entityList26[index20] = copiedEntity;
            }
          }
          for (int index22 = 0; index22 <= entityList27.Count - 1; ++index22)
          {
            List<Point3D> point3DList = new List<Point3D>();
            buVector5.VerticeToPointsList(entityList27[index22].Vertices, ref point3DList);
            bool flag = false;
            for (int index23 = 1; index23 <= point3DList.Count - 1; ++index23)
            {
              Point3D point3D6 = clsInit.cVector5.MiddlePointOfLine(point3DList[index23 - 1], point3DList[index23]);
              if (buCompare5.EQ(point3D1, point3D6))
              {
                point3DList.RemoveAt(index23);
                flag = true;
              }
            }
            if (!flag)
            {
              Point3D point3D7 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
              if (buCompare5.EQ(point3D1, point3D7, clsCutter.varCutterSettings.MirrorCenterPointCatchGapDistance))
                flag = true;
            }
            if (!flag)
            {
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[0], 0.1))
                flag = true;
              if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index15], point3DList[point3DList.Count - 1], 0.1))
                flag = true;
            }
            if (flag)
            {
              List<Point3D> mirrorPoint = new List<Point3D>();
              clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
              mirrorPoint.Reverse();
              point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
              clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
              Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
              clsInit.cVector5.CopyEntityProperties(entityList27[index22], ref copiedEntity);
              ((CustomData) copiedEntity.EntityData).infoData = this.Properties.SizeList[index3];
              entityList27[index22] = copiedEntity;
            }
          }
        }
        for (int index24 = 0; index24 <= rulStrectPointsList17.Count - 1; ++index24)
          rulStrectPointsList9.Add(new RulStrectPoints(rulStrectPointsList17[index24]));
        for (int index25 = 0; index25 <= cutterNotchList2.Count - 1; ++index25)
          cutterNotchList1.Add(new CutterNotch(cutterNotchList2[index25]));
      }
      for (int index26 = 0; index26 <= entityList22.Count - 1; ++index26)
      {
        List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt1 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint1 = new Point3D();
        Point3D MidPoint1 = new Point3D();
        Point3D MaxPoint1 = new Point3D();
        ICurve refCurve = entityList22[index26] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList22[index26], ref MinPoint1, ref MidPoint1, ref MaxPoint1);
        for (int index27 = 0; index27 <= cutterNotchList1.Count - 1; ++index27)
        {
          Point3D point3D = new Point3D(cutterNotchList1[index27].Position.X, cutterNotchList1[index27].Position.Y);
          clsInit.cVector5.PointAngle(MidPoint1, point3D, Plane.XY);
          double t = 0.0;
          cutterNotchList1[index27].CurveAtLength = refCurve.Length();
          ((ICurve) entityList22[index26]).ClosestPointTo(point3D, out t);
          cutterNotchList1[index27].InCurve = clsInit.cVector5.isPointInsideEntity(refCurve, point3D, 1.0);
          cutterNotchList1[index27].CurveAtPersentage = t / cutterNotchList1[index27].CurveAtLength;
          if (cutterNotchList1[index27].InCurve)
          {
            Point3D BasePoint = refCurve.PointAt(t);
            Point3D TipPoint = refCurve.PointAt(t + 0.1);
            double num = clsInit.cVector5.PointAngle(TipPoint, BasePoint, Plane.XY);
            double Angle1 = num + 90.0;
            double Angle2 = num - 90.0;
            Point3D EndPnt1 = new Point3D();
            Point3D EndPnt2 = new Point3D();
            clsInit.cVector5.LineWithLengthAndAngle(new Point3D(cutterNotchList1[index27].Position.X, cutterNotchList1[index27].Position.Y), 2.0, Angle1, ref EndPnt1);
            clsInit.cVector5.LineWithLengthAndAngle(new Point3D(cutterNotchList1[index27].Position.X, cutterNotchList1[index27].Position.Y), 2.0, Angle2, ref EndPnt2);
            Utility.PointInPolygon((Point2D) EndPnt1, (IList<Point2D>) entityList22[index26].Vertices);
            Utility.PointInPolygon((Point2D) EndPnt2, (IList<Point2D>) entityList22[index26].Vertices);
            cutterNotchList1[index27].baseEntityIndex = index26;
            cutterNotchList1[index27].baseEntityName = ((CustomData) entityList22[index26].EntityData).EntityName;
          }
        }
        for (int index28 = 0; index28 <= entityList22[index26].Vertices.Length - 1; ++index28)
        {
          Pnt3D Pnt2 = new Pnt3D(entityList22[index26].Vertices[index28].X, entityList22[index26].Vertices[index28].Y, entityList22[index26].Vertices[index28].Z);
          bool flag = false;
          for (int index29 = 0; index29 <= rulStrectPointsList9.Count - 1; ++index29)
          {
            if (buCompare5.EQ(Pnt2, rulStrectPointsList9[index29].Position))
            {
              Pnt1 = new Pnt3D(Pnt2);
              double dX = rulStrectPointsList9[index29].dX;
              double dY = rulStrectPointsList9[index29].dY;
              Pnt2 = new Pnt3D(Pnt2.X + rulStrectPointsList9[index29].dX, Pnt2.Y + rulStrectPointsList9[index29].dY, Pnt2.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt1));
              Pnt3D MinPoint2 = new Pnt3D();
              Pnt3D MidPoint2 = new Pnt3D();
              Pnt3D MaxPoint2 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
              double RatioX = (Pnt2.X - CopiedPnt1[CopiedPnt1.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt2.Y - CopiedPnt1[CopiedPnt1.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num1 = CopiedPnt1[CopiedPnt1.Count - 1].X - Points[0].X;
              double num2 = CopiedPnt1[CopiedPnt1.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt1[CopiedPnt1.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt1);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt1.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
            pnt3D = new Pnt3D(Pnt1);
          }
          else
            Points.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList22[index26].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt2 = new List<Point3D>();
        if (CopiedPnt1.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt1, ref CopiedPnt2);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
        clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData, customData, ref Ent);
        Ent.EntityData = (object) customData;
        entityList2.Add((Entity) Ent);
      }
      for (int index30 = 0; index30 <= cutterNotchList1.Count - 1; ++index30)
      {
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D Pnt = new Pnt3D(cutterNotchList1[index30].Position.X, cutterNotchList1[index30].Position.Y, cutterNotchList1[index30].Position.Z);
        for (int index31 = 0; index31 <= rulStrectPointsList16.Count - 1; ++index31)
        {
          if (buCompare5.EQ(Pnt, rulStrectPointsList16[index31].Position))
          {
            Pnt3D pnt3D2 = new Pnt3D(Pnt);
            double dX = rulStrectPointsList16[index31].dX;
            double dY = rulStrectPointsList16[index31].dY;
            Pnt = new Pnt3D(Pnt.X + rulStrectPointsList16[index31].dX, Pnt.Y + rulStrectPointsList16[index31].dY, Pnt.Z);
            cutterNotchList1[index30].Position = new Point3D(Pnt.X, Pnt.Y, Pnt.Z);
          }
        }
        if (cutterNotchList1[index30].InCurve & cutterNotchList1[index30].baseEntityIndex >= 0)
        {
          int baseEntityIndex = cutterNotchList1[index30].baseEntityIndex;
          Entity copiedEntity = (Entity) null;
          buEntity.Copy(entityList22[baseEntityIndex], ref copiedEntity);
          ICurve baseEntity = (ICurve) copiedEntity;
          List<Entity> notchEntities = new List<Entity>();
          clsInit.cCutter.CreateNotch(cutterNotchList1[index30].NotchType, buVector5.ToPoint3D(cutterNotchList1[index30].Position), cutterNotchList1[index30].Length, cutterNotchList1[index30].DirectionAngle, cutterNotchList1[index30].Angle, baseEntity, ref notchEntities);
          for (int index32 = 0; index32 <= notchEntities.Count - 1; ++index32)
          {
            Entity Ent = (Entity) null;
            clsInit.appCommand.CreateEntity(notchEntities[index32], ref Ent);
            Ent.LayerName = clsCutter.varCutterSettings.NotchLayerName;
            ((CustomData) Ent.EntityData).infoBasePoint = new Point3D(cutterNotchList1[index30].Position.X, cutterNotchList1[index30].Position.Y, cutterNotchList1[index30].Position.Z);
            ((CustomData) Ent.EntityData).infoLength = cutterNotchList1[index30].Length;
            ((CustomData) Ent.EntityData).infoWidth = cutterNotchList1[index30].Width;
            ((CustomData) Ent.EntityData).infoAngle = cutterNotchList1[index30].Angle;
            ((CustomData) Ent.EntityData).infoDirection = cutterNotchList1[index30].DirectionAngle;
            ((CustomData) Ent.EntityData).ActionName = ((CustomData) entityList22[baseEntityIndex].EntityData).EntityName;
            ((CustomData) Ent.EntityData).infoString = cutterNotchList1[index30].NotchType.ToString();
            ((CustomData) Ent.EntityData).infoData = this.Properties.SizeList[index3];
            entityList19.Add(Ent);
          }
        }
      }
      for (int index33 = 0; index33 <= entityList23.Count - 1; ++index33)
      {
        List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt3 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint3 = new Point3D();
        Point3D MidPoint3 = new Point3D();
        Point3D MaxPoint3 = new Point3D();
        ICurve curve = entityList23[index33] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList23[index33], ref MinPoint3, ref MidPoint3, ref MaxPoint3);
        for (int index34 = 0; index34 <= entityList23[index33].Vertices.Length - 1; ++index34)
        {
          Pnt3D Pnt4 = new Pnt3D(entityList23[index33].Vertices[index34].X, entityList23[index33].Vertices[index34].Y, entityList23[index33].Vertices[index34].Z);
          bool flag = false;
          for (int index35 = 0; index35 <= rulStrectPointsList10.Count - 1; ++index35)
          {
            if (buCompare5.EQ(Pnt4, rulStrectPointsList10[index35].Position))
            {
              Pnt3 = new Pnt3D(Pnt4);
              double dX = rulStrectPointsList10[index35].dX;
              double dY = rulStrectPointsList10[index35].dY;
              Pnt4 = new Pnt3D(Pnt4.X + rulStrectPointsList10[index35].dX, Pnt4.Y + rulStrectPointsList10[index35].dY, Pnt4.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt3));
              Pnt3D MinPoint4 = new Pnt3D();
              Pnt3D MidPoint4 = new Pnt3D();
              Pnt3D MaxPoint4 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
              double RatioX = (Pnt4.X - CopiedPnt3[CopiedPnt3.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt4.Y - CopiedPnt3[CopiedPnt3.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num3 = CopiedPnt3[CopiedPnt3.Count - 1].X - Points[0].X;
              double num4 = CopiedPnt3[CopiedPnt3.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt3[CopiedPnt3.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt3);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt3.Add(new Pnt3D(Pnt4.X, Pnt4.Y, Pnt4.Z));
            pnt3D = new Pnt3D(Pnt3);
          }
          else
            Points.Add(new Pnt3D(Pnt4.X, Pnt4.Y, Pnt4.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList23[index33].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt4 = new List<Point3D>();
        if (CopiedPnt3.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt3, ref CopiedPnt4);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt4);
        clsInit.appCommand.CreatePolyLine(CopiedPnt4, entData, customData, ref Ent);
        entityList4.Add((Entity) Ent);
      }
      for (int index36 = 0; index36 <= entityList25.Count - 1; ++index36)
      {
        List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt5 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint5 = new Point3D();
        Point3D MidPoint5 = new Point3D();
        Point3D MaxPoint5 = new Point3D();
        ICurve curve = entityList25[index36] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList25[index36], ref MinPoint5, ref MidPoint5, ref MaxPoint5);
        for (int index37 = 0; index37 <= entityList25[index36].Vertices.Length - 1; ++index37)
        {
          Pnt3D Pnt6 = new Pnt3D(entityList25[index36].Vertices[index37].X, entityList25[index36].Vertices[index37].Y, entityList25[index36].Vertices[index37].Z);
          bool flag = false;
          for (int index38 = 0; index38 <= rulStrectPointsList11.Count - 1; ++index38)
          {
            if (buCompare5.EQ(Pnt6, rulStrectPointsList11[index38].Position))
            {
              Pnt5 = new Pnt3D(Pnt6);
              double dX = rulStrectPointsList11[index38].dX;
              double dY = rulStrectPointsList11[index38].dY;
              Pnt6 = new Pnt3D(Pnt6.X + rulStrectPointsList11[index38].dX, Pnt6.Y + rulStrectPointsList11[index38].dY, Pnt6.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt5));
              Pnt3D MinPoint6 = new Pnt3D();
              Pnt3D MidPoint6 = new Pnt3D();
              Pnt3D MaxPoint6 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint6, ref MidPoint6, ref MaxPoint6);
              double RatioX = (Pnt6.X - CopiedPnt5[CopiedPnt5.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt6.Y - CopiedPnt5[CopiedPnt5.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num5 = CopiedPnt5[CopiedPnt5.Count - 1].X - Points[0].X;
              double num6 = CopiedPnt5[CopiedPnt5.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt5[CopiedPnt5.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt5);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt5.Add(new Pnt3D(Pnt6.X, Pnt6.Y, Pnt6.Z));
            pnt3D = new Pnt3D(Pnt5);
          }
          else
            Points.Add(new Pnt3D(Pnt6.X, Pnt6.Y, Pnt6.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourNoCutLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList25[index36].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt6 = new List<Point3D>();
        if (CopiedPnt5.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt5, ref CopiedPnt6);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt6);
        clsInit.appCommand.CreatePolyLine(CopiedPnt6, entData, customData, ref Ent);
        entityList12.Add((Entity) Ent);
      }
      for (int index39 = 0; index39 <= entityList24.Count - 1; ++index39)
      {
        List<Pnt3D> CopiedPnt7 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt7 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint7 = new Point3D();
        Point3D MidPoint7 = new Point3D();
        Point3D MaxPoint7 = new Point3D();
        ICurve curve = entityList24[index39] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList24[index39], ref MinPoint7, ref MidPoint7, ref MaxPoint7);
        for (int index40 = 0; index40 <= entityList24[index39].Vertices.Length - 1; ++index40)
        {
          Pnt3D Pnt8 = new Pnt3D(entityList24[index39].Vertices[index40].X, entityList24[index39].Vertices[index40].Y, entityList24[index39].Vertices[index40].Z);
          bool flag = false;
          for (int index41 = 0; index41 <= rulStrectPointsList12.Count - 1; ++index41)
          {
            if (buCompare5.EQ(Pnt8, rulStrectPointsList12[index41].Position))
            {
              Pnt7 = new Pnt3D(Pnt8);
              double dX = rulStrectPointsList12[index41].dX;
              double dY = rulStrectPointsList12[index41].dY;
              Pnt8 = new Pnt3D(Pnt8.X + rulStrectPointsList12[index41].dX, Pnt8.Y + rulStrectPointsList12[index41].dY, Pnt8.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt7));
              Pnt3D MinPoint8 = new Pnt3D();
              Pnt3D MidPoint8 = new Pnt3D();
              Pnt3D MaxPoint8 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint8, ref MidPoint8, ref MaxPoint8);
              double RatioX = (Pnt8.X - CopiedPnt7[CopiedPnt7.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt8.Y - CopiedPnt7[CopiedPnt7.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num7 = CopiedPnt7[CopiedPnt7.Count - 1].X - Points[0].X;
              double num8 = CopiedPnt7[CopiedPnt7.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt7[CopiedPnt7.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt7);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt7.Add(new Pnt3D(Pnt8.X, Pnt8.Y, Pnt8.Z));
            pnt3D = new Pnt3D(Pnt7);
          }
          else
            Points.Add(new Pnt3D(Pnt8.X, Pnt8.Y, Pnt8.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.RopeDirectionLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList24[index39].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt8 = new List<Point3D>();
        if (CopiedPnt7.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt7, ref CopiedPnt8);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt8);
        clsInit.appCommand.CreatePolyLine(CopiedPnt8, entData, customData, ref Ent);
        entityList10.Add((Entity) Ent);
      }
      for (int index42 = 0; index42 <= entityList5.Count - 1; ++index42)
      {
        Point3D MinPoint = new Point3D();
        Point3D MidPoint = new Point3D();
        Point3D MaxPoint = new Point3D();
        clsInit.cVector5.BoxSizeCalculate(entityList5[index42], ref MinPoint, ref MidPoint, ref MaxPoint);
        Pnt3D pnt3D = new Pnt3D(((Circle) entityList5[index42]).Center.X, ((Circle) entityList5[index42]).Center.Y, ((Circle) entityList5[index42]).Center.Z);
        double radius = ((Circle) entityList5[index42]).Radius;
        for (int index43 = 0; index43 <= rulStrectPointsList13.Count - 1; ++index43)
        {
          if (buCompare5.EQ(pnt3D, rulStrectPointsList13[index43].Position))
            pnt3D = new Pnt3D(pnt3D.X + rulStrectPointsList13[index43].dX, pnt3D.Y + rulStrectPointsList13[index43].dY, pnt3D.Z);
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList5[index42].EntityData);
        customData.infoData = this.Properties.SizeList[index3];
        Circle Ent = (Circle) null;
        clsInit.appCommand.CreateCircle(new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z), radius, Plane.XY, entData, customData, ref Ent);
        entityList8.Add((Entity) Ent);
      }
      for (int index44 = 0; index44 <= entityList26.Count - 1; ++index44)
      {
        List<Pnt3D> CopiedPnt9 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt9 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint9 = new Point3D();
        Point3D MidPoint9 = new Point3D();
        Point3D MaxPoint9 = new Point3D();
        ICurve curve = entityList26[index44] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList26[index44], ref MinPoint9, ref MidPoint9, ref MaxPoint9);
        for (int index45 = 0; index45 <= entityList26[index44].Vertices.Length - 1; ++index45)
        {
          Pnt3D Pnt10 = new Pnt3D(entityList26[index44].Vertices[index45].X, entityList26[index44].Vertices[index45].Y, entityList26[index44].Vertices[index45].Z);
          bool flag = false;
          for (int index46 = 0; index46 <= rulStrectPointsList14.Count - 1; ++index46)
          {
            if (buCompare5.EQ(Pnt10, rulStrectPointsList14[index46].Position))
            {
              Pnt9 = new Pnt3D(Pnt10);
              double dX = rulStrectPointsList14[index46].dX;
              double dY = rulStrectPointsList14[index46].dY;
              Pnt10 = new Pnt3D(Pnt10.X + rulStrectPointsList14[index46].dX, Pnt10.Y + rulStrectPointsList14[index46].dY, Pnt10.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt9));
              Pnt3D MinPoint10 = new Pnt3D();
              Pnt3D MidPoint10 = new Pnt3D();
              Pnt3D MaxPoint10 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint10, ref MidPoint10, ref MaxPoint10);
              double RatioX = (Pnt10.X - CopiedPnt9[CopiedPnt9.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt10.Y - CopiedPnt9[CopiedPnt9.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num9 = CopiedPnt9[CopiedPnt9.Count - 1].X - Points[0].X;
              double num10 = CopiedPnt9[CopiedPnt9.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt9[CopiedPnt9.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt9);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt9.Add(new Pnt3D(Pnt10.X, Pnt10.Y, Pnt10.Z));
            pnt3D = new Pnt3D(Pnt9);
          }
          else
            Points.Add(new Pnt3D(Pnt10.X, Pnt10.Y, Pnt10.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourPloter1LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList26[index44].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt10 = new List<Point3D>();
        if (CopiedPnt9.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt9, ref CopiedPnt10);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt10);
        clsInit.appCommand.CreatePolyLine(CopiedPnt10, entData, customData, ref Ent);
        entityList14.Add((Entity) Ent);
      }
      for (int index47 = 0; index47 <= entityList27.Count - 1; ++index47)
      {
        List<Pnt3D> CopiedPnt11 = new List<Pnt3D>();
        List<Pnt3D> Points = new List<Pnt3D>();
        Pnt3D Pnt11 = new Pnt3D();
        Pnt3D pnt3D = new Pnt3D();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        Point3D MinPoint11 = new Point3D();
        Point3D MidPoint11 = new Point3D();
        Point3D MaxPoint11 = new Point3D();
        ICurve curve = entityList27[index47] as ICurve;
        clsInit.cVector5.BoxSizeCalculate(entityList27[index47], ref MinPoint11, ref MidPoint11, ref MaxPoint11);
        for (int index48 = 0; index48 <= entityList27[index47].Vertices.Length - 1; ++index48)
        {
          Pnt3D Pnt12 = new Pnt3D(entityList27[index47].Vertices[index48].X, entityList27[index47].Vertices[index48].Y, entityList27[index47].Vertices[index48].Z);
          bool flag = false;
          for (int index49 = 0; index49 <= rulStrectPointsList15.Count - 1; ++index49)
          {
            if (buCompare5.EQ(Pnt12, rulStrectPointsList15[index49].Position))
            {
              Pnt11 = new Pnt3D(Pnt12);
              double dX = rulStrectPointsList15[index49].dX;
              double dY = rulStrectPointsList15[index49].dY;
              Pnt12 = new Pnt3D(Pnt12.X + rulStrectPointsList15[index49].dX, Pnt12.Y + rulStrectPointsList15[index49].dY, Pnt12.Z);
              flag = true;
            }
          }
          if (flag)
          {
            if (Points.Count > 0)
            {
              Points.Insert(0, new Pnt3D(pnt3D));
              Points.Add(new Pnt3D(Pnt11));
              Pnt3D MinPoint12 = new Pnt3D();
              Pnt3D MidPoint12 = new Pnt3D();
              Pnt3D MaxPoint12 = new Pnt3D();
              clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint12, ref MidPoint12, ref MaxPoint12);
              double RatioX = (Pnt12.X - CopiedPnt11[CopiedPnt11.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
              double RatioY = (Pnt12.Y - CopiedPnt11[CopiedPnt11.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
              clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
              double num11 = CopiedPnt11[CopiedPnt11.Count - 1].X - Points[0].X;
              double num12 = CopiedPnt11[CopiedPnt11.Count - 1].Y - Points[0].Y;
              clsInit.cVector.Move(Points[0], CopiedPnt11[CopiedPnt11.Count - 1], ref Points);
              Points.RemoveAt(0);
              Points.RemoveAt(Points.Count - 1);
              Pnt3D.Add(Points, ref CopiedPnt11);
              Points.Clear();
              Points = new List<Pnt3D>();
            }
            CopiedPnt11.Add(new Pnt3D(Pnt12.X, Pnt12.Y, Pnt12.Z));
            pnt3D = new Pnt3D(Pnt11);
          }
          else
            Points.Add(new Pnt3D(Pnt12.X, Pnt12.Y, Pnt12.Z));
        }
        EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.InnerContourPloter2LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
        CustomData customData = new CustomData((CustomData) entityList27[index47].EntityData);
        LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
        List<Point3D> CopiedPnt12 = new List<Point3D>();
        if (CopiedPnt11.Count > 0)
          buConversion5.Pnt3DToPoint3D(CopiedPnt11, ref CopiedPnt12);
        else
          buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt12);
        clsInit.appCommand.CreatePolyLine(CopiedPnt12, entData, customData, ref Ent);
        entityList16.Add((Entity) Ent);
      }
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    for (int index = 0; index <= entityList2.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList2[index].EntityData).typeDefination = entityTypeDefination.Cutting;
      clsInit.appCommand.AddEntity(entityList2[index]);
    }
    for (int index = 0; index <= entityList19.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList19[index].EntityData).typeDefination = entityTypeDefination.Notch;
      clsInit.appCommand.AddEntity(entityList19[index]);
    }
    for (int index = 0; index <= entityList4.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList4[index].EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
      clsInit.appCommand.AddEntity(entityList4[index]);
    }
    for (int index = 0; index <= entityList14.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      clsInit.appCommand.AddEntity(entityList14[index]);
      ((CustomData) entityList14[index].EntityData).typeDefination = entityTypeDefination.InnerAux;
    }
    for (int index = 0; index <= entityList16.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList16[index].EntityData).typeDefination = entityTypeDefination.InnerAux;
      clsInit.appCommand.AddEntity(entityList16[index]);
    }
    for (int index50 = 0; index50 <= entityList10.Count - 1; ++index50)
    {
      ((CustomData) entityList10[index50].EntityData).typeDefination = entityTypeDefination.Direction;
      double num = Point3D.Distance(entityList10[index50].Vertices[0], entityList10[index50].Vertices[entityList10[index50].Vertices.Length - 1]);
      List<Entity> calcEntities = new List<Entity>();
      clsInit.cVector5.DrawWireArrow(entityList10[index50].Vertices[0], entityList10[index50].Vertices[entityList10[index50].Vertices.Length - 1], num * 0.1, 15.0, Plane.XY, ref calcEntities);
      for (int index51 = 0; index51 <= calcEntities.Count - 1; ++index51)
      {
        Entity copiedEntity = calcEntities[index51];
        clsInit.cVector5.CopyEntityProperties(entityList10[index50], ref copiedEntity);
        ccVars.UndoDont = true;
        clsInit.appCommand.AddEntity(copiedEntity);
      }
    }
    for (int index52 = 0; index52 <= entityList17.Count - 1; ++index52)
    {
      ccVars.UndoDont = true;
      bool flag = false;
      for (int index53 = 0; index53 <= entityList2.Count - 1; ++index53)
      {
        Point3D insertionPoint = ((Text) entityList17[index52]).InsertionPoint;
        if (entityList2[index53].BoxMin == (Point3D) null)
          entityList2[index53].Regen(new RegenParams(0.01, (IWorkspace) ccVars.Pages[ccVars.PageIndex].Form.viewportcad));
        if (clsInit.cVector5.IsPointInsideBoxsize(((Text) entityList17[index52]).InsertionPoint, entityList2[index53].BoxMin, entityList2[index53].BoxMax, Plane.XY))
          flag = true;
      }
      ((CustomData) entityList17[index52].EntityData).typeDefination = entityTypeDefination.Info;
      if (flag)
      {
        entityList17[index52].LayerName = clsCutter.varCutterSettings.PartInfoLayerName;
        clsInit.appCommand.AddEntity(entityList17[index52]);
      }
      else
        clsInit.appCommand.AddEntity(entityList17[index52]);
    }
    for (int index = 0; index <= entityList8.Count - 1; ++index)
    {
      ccVars.UndoDont = true;
      ((CustomData) entityList8[index].EntityData).typeDefination = entityTypeDefination.Drill;
      clsInit.appCommand.AddEntity(entityList8[index]);
    }
  }

  public void ExtendEntitiesByRules()
  {
    List<RulStrectPoints> rulStrectPointsList1 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList2 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList3 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList4 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList5 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList6 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList7 = new List<RulStrectPoints>();
    List<RulStrectPoints> rulStrectPointsList8 = new List<RulStrectPoints>();
    List<CutterNotch> cutterNotchList1 = new List<CutterNotch>();
    List<Entity> entityList1 = new List<Entity>();
    List<Entity> entityList2 = new List<Entity>();
    List<Entity> entityList3 = new List<Entity>();
    List<Entity> entityList4 = new List<Entity>();
    List<Entity> entityList5 = new List<Entity>();
    List<Entity> entityList6 = new List<Entity>();
    List<Entity> entityList7 = new List<Entity>();
    List<Entity> entityList8 = new List<Entity>();
    List<Entity> entityList9 = new List<Entity>();
    List<Entity> entityList10 = new List<Entity>();
    List<Entity> entityList11 = new List<Entity>();
    List<Entity> entityList12 = new List<Entity>();
    List<Entity> entityList13 = new List<Entity>();
    List<Entity> entityList14 = new List<Entity>();
    List<Entity> entityList15 = new List<Entity>();
    List<Entity> entityList16 = new List<Entity>();
    List<Entity> entityList17 = new List<Entity>();
    List<Entity> entityList18 = new List<Entity>();
    List<Entity> entityList19 = new List<Entity>();
    List<Entity> entityList20 = new List<Entity>();
    List<Entity> entityList21 = new List<Entity>();
    List<string> stringList1 = new List<string>();
    this.NotchList.Clear();
    this.NotchList = new List<CutterNotch>();
    FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
    List<ePoint> ePointList = new List<ePoint>();
    if (fileInfo.Exists)
    {
      List<eEntities> RefEntities = new List<eEntities>();
      List<LayerBase> Layers = new List<LayerBase>();
      new buFile.Dxf().ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
      for (int index = RefEntities.Count - 1; index >= 0; --index)
      {
        if (RefEntities[index].GetType() == typeof (ePoint))
        {
          eEntities CalcEnt = (eEntities) new ePoint();
          clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[index], ref CalcEnt);
          CalcEnt.geoAngleXY = RefEntities[index].geoAngleXY;
          ePointList.Add((ePoint) CalcEnt);
        }
      }
    }
    Layer layer1 = new Layer(clsCutter.varCutterSettings.NotchLayerName, Color.DarkRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer1);
    Layer layer2 = new Layer(clsCutter.varCutterSettings.InfoLayerName, Color.MediumVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer2);
    Layer layer3 = new Layer(clsCutter.varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(layer3);
    if (this.Properties.SizeList.Count == 0)
      this.Properties.SizeList.Add("");
    List<Entity> copiedEnt = new List<Entity>();
    buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref copiedEnt);
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
    ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
    ccVars.Pages[ccVars.PageIndex].OsnapTempPoints.Clear();
    List<string> stringList2 = new List<string>((IEnumerable<string>) clsCutter.varCutterSettings.ContourRuleScaleLayerName.Split(';'));
    for (int index1 = 0; index1 <= this.Properties.SizeList.Count - 1; ++index1)
    {
      List<RulStrectPoints> StrectPnt1 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt2 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt3 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt4 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt5 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt6 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt7 = new List<RulStrectPoints>();
      List<RulStrectPoints> StrectPnt8 = new List<RulStrectPoints>();
      List<CutterPart> cutterPartList = new List<CutterPart>();
      CutterPart cutterPart1 = new CutterPart();
      for (int index2 = 0; index2 <= copiedEnt.Count - 1; ++index2)
      {
        if (copiedEnt[index2].GetType() == typeof (devDept.Eyeshot.Entities.Point))
          entityList20.Add((Entity) copiedEnt[index2].Clone());
        if (copiedEnt[index2] is ICurve && copiedEnt[index2].LayerName == clsCutter.varCutterSettings.MirrorLayerName)
        {
          copiedEnt[index2].Selected = true;
          entityList21.Add((Entity) copiedEnt[index2].Clone());
        }
      }
      for (int index3 = 0; index3 <= copiedEnt.Count - 1; ++index3)
      {
        Entity entity = copiedEnt[index3];
        if (copiedEnt[index3] is devDept.Eyeshot.Entities.Point)
        {
          devDept.Eyeshot.Entities.Point point = copiedEnt[index3] as devDept.Eyeshot.Entities.Point;
          for (int index4 = 0; index4 <= ePointList.Count - 1; ++index4)
          {
            if (buCompare5.EQ(ePointList[index4].StartPoint.X, point.StartPoint.X, 0.01) & buCompare5.EQ(ePointList[index4].StartPoint.Y, point.StartPoint.Y, 0.01) && ePointList[index4].auxText.IndexOf("39") >= 0 | ePointList[index4].auxText.IndexOf("50") >= 0)
            {
              if (point.LayerName == clsCutter.varCutterSettings.NotchInsideLayerName)
              {
                cutterNotchList1.Add(new CutterNotch()
                {
                  Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0),
                  NotchType = CutterNotchType.INotch,
                  Length = point.StartPoint.Z,
                  Direction = InOutType.Inside,
                  DirectionAngle = ePointList[index4].geoAngleXY
                });
                copiedEnt[index3].Selected = true;
              }
              if (point.LayerName == clsCutter.varCutterSettings.NotchOutsideLayerName)
              {
                CutterNotch cutterNotch = new CutterNotch();
                cutterNotch.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
                cutterNotch.Length = point.StartPoint.Z;
                cutterNotch.Direction = InOutType.Outside;
                cutterNotch.DirectionAngle = ePointList[index4].geoAngleXY;
                if (ePointList[index4].auxText.IndexOf("39") >= 0)
                {
                  cutterNotch.Width = ePointList[index4].auxValue;
                  cutterNotch.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch.Width / 2.0 / cutterNotch.Length)) * 2.0;
                  cutterNotch.NotchType = CutterNotchType.VNotch;
                }
                else
                  cutterNotch.NotchType = CutterNotchType.INotch;
                cutterNotchList1.Add(cutterNotch);
                copiedEnt[index3].Selected = true;
              }
            }
          }
        }
        if (entity is Text)
        {
          bool flag = false;
          Text text = entity as Text;
          for (int index5 = 0; index5 <= stringList2.Count - 1; ++index5)
          {
            if (text.LayerName == stringList2[index5] && text.TextString.IndexOf("#-") >= 0)
            {
              copiedEnt[index3].Selected = true;
              int int32_1 = Convert.ToInt32(text.TextString.Replace("#", ""));
              RulStrectPoints rulStrectPoints1 = new RulStrectPoints();
              rulStrectPoints1.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
              rulStrectPoints1.No = int32_1;
              for (int index6 = 0; index6 <= this.Properties.RuleList.Count - 1; ++index6)
              {
                if (rulStrectPoints1.No == this.Properties.RuleList[index6].No)
                {
                  rulStrectPoints1.dX = this.Properties.RuleList[index6].Position[index1].X;
                  rulStrectPoints1.dY = this.Properties.RuleList[index6].Position[index1].Y;
                }
              }
              StrectPnt1.Add(rulStrectPoints1);
              flag = true;
              for (int index7 = 0; index7 <= cutterNotchList1.Count - 1; ++index7)
              {
                if (buCompare5.EQ(buVector5.ToPoint3D(cutterNotchList1[index7].Position), text.InsertionPoint, 0.1))
                {
                  int int32_2 = Convert.ToInt32(text.TextString.Replace("#", ""));
                  RulStrectPoints rulStrectPoints2 = new RulStrectPoints();
                  rulStrectPoints2.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
                  rulStrectPoints2.No = int32_2;
                  for (int index8 = 0; index8 <= this.Properties.RuleList.Count - 1; ++index8)
                  {
                    if (rulStrectPoints2.No == this.Properties.RuleList[index8].No)
                    {
                      rulStrectPoints2.dX = this.Properties.RuleList[index8].Position[index1].X;
                      rulStrectPoints2.dY = this.Properties.RuleList[index8].Position[index1].Y;
                    }
                  }
                  StrectPnt8.Add(rulStrectPoints2);
                }
              }
            }
          }
          if (text.LayerName == clsCutter.varCutterSettings.InnerContourLayerName | text.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index9 = 0; index9 <= this.Properties.RuleList.Count - 1; ++index9)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index9].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index9].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index9].Position[index1].Y;
              }
            }
            StrectPnt2.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName | text.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index10 = 0; index10 <= this.Properties.RuleList.Count - 1; ++index10)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index10].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index10].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index10].Position[index1].Y;
              }
            }
            StrectPnt3.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index11 = 0; index11 <= this.Properties.RuleList.Count - 1; ++index11)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index11].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index11].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index11].Position[index1].Y;
              }
            }
            StrectPnt4.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.DrillLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index12 = 0; index12 <= this.Properties.RuleList.Count - 1; ++index12)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index12].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index12].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index12].Position[index1].Y;
              }
            }
            StrectPnt5.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName | text.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index13 = 0; index13 <= this.Properties.RuleList.Count - 1; ++index13)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index13].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index13].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index13].Position[index1].Y;
              }
            }
            StrectPnt6.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName | text.LayerName == clsCutter.varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index14 = 0; index14 <= this.Properties.RuleList.Count - 1; ++index14)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index14].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index14].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index14].Position[index1].Y;
              }
            }
            StrectPnt7.Add(rulStrectPoints);
            flag = true;
          }
          if (text.LayerName == clsCutter.varCutterSettings.NotchInsideLayerName | text.LayerName == clsCutter.varCutterSettings.NotchOutsideLayerName && text.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index3].Selected = true;
            int int32 = Convert.ToInt32(text.TextString.Replace("#", ""));
            RulStrectPoints rulStrectPoints = new RulStrectPoints();
            rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
            rulStrectPoints.No = int32;
            for (int index15 = 0; index15 <= this.Properties.RuleList.Count - 1; ++index15)
            {
              if (rulStrectPoints.No == this.Properties.RuleList[index15].No)
              {
                rulStrectPoints.dX = this.Properties.RuleList[index15].Position[index1].X;
                rulStrectPoints.dY = this.Properties.RuleList[index15].Position[index1].Y;
              }
            }
            StrectPnt8.Add(rulStrectPoints);
            flag = true;
          }
          if (flag)
            copiedEnt[index3].Selected = true;
        }
      }
      for (int index16 = 0; index16 <= copiedEnt.Count - 1; ++index16)
      {
        Entity entity = copiedEnt[index16];
        if (copiedEnt[index16] is ICurve && entity.LayerName == clsCutter.varCutterSettings.ContourLayerName)
        {
          if (entityList21.Count > 0)
          {
            List<RulStrectPoints> rulStrectPointsList9 = new List<RulStrectPoints>();
            List<CutterNotch> cutterNotchList2 = new List<CutterNotch>();
            for (int index17 = 0; index17 <= entityList21.Count - 1; ++index17)
            {
              Point3D startPoint = ((ICurve) entityList21[index17]).StartPoint;
              Point3D endPoint = ((ICurve) entityList21[index17]).EndPoint;
              Point3D point3D1 = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
              List<Point3D> point3DList = new List<Point3D>();
              buVector5.VerticeToPointsList(entity.Vertices, ref point3DList);
              bool flag1 = false;
              for (int index18 = 1; index18 <= point3DList.Count - 1; ++index18)
              {
                Point3D point3D2 = clsInit.cVector5.MiddlePointOfLine(point3DList[index18 - 1], point3DList[index18]);
                if (buCompare5.EQ(point3D1, point3D2))
                {
                  point3DList.RemoveAt(index18);
                  flag1 = true;
                }
              }
              if (!flag1)
              {
                Point3D point3D3 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
                if (buCompare5.EQ(point3D1, point3D3))
                  flag1 = true;
              }
              if (!flag1)
              {
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index17], point3DList[0], 0.1))
                  flag1 = true;
                if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index17], point3DList[point3DList.Count - 1], 0.1))
                  flag1 = true;
              }
              if (flag1)
              {
                for (int index19 = 0; index19 <= StrectPnt1.Count - 1; ++index19)
                {
                  Point3D refPoint = new Point3D(StrectPnt1[index19].Position.X, StrectPnt1[index19].Position.Y);
                  if (clsInit.cVector5.isPointInsideEntity((ICurve) entity, refPoint, 0.1))
                  {
                    RulStrectPoints rulStrectPoints = new RulStrectPoints(StrectPnt1[index19]);
                    Point3D mirrorPoint = new Point3D();
                    clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                    rulStrectPoints.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
                    rulStrectPoints.dY = -StrectPnt1[index19].dY;
                    rulStrectPointsList9.Add(rulStrectPoints);
                  }
                }
                if (rulStrectPointsList9.Count > 0)
                {
                  for (int index20 = 0; index20 <= rulStrectPointsList9.Count - 1; ++index20)
                  {
                    bool flag2 = false;
                    for (int index21 = 0; index21 <= StrectPnt1.Count - 1; ++index21)
                    {
                      if (buCompare5.EQ(StrectPnt1[index21].Position, rulStrectPointsList9[index20].Position, 0.1))
                      {
                        flag2 = true;
                        index21 = StrectPnt1.Count;
                      }
                    }
                    if (!flag2)
                      StrectPnt1.Add(new RulStrectPoints(rulStrectPointsList9[index20]));
                  }
                }
                for (int index22 = 0; index22 <= cutterNotchList1.Count - 1; ++index22)
                {
                  Point3D refPoint = new Point3D(cutterNotchList1[index22].Position.X, cutterNotchList1[index22].Position.Y);
                  if (clsInit.cVector5.isPointInsideEntity((ICurve) entity, refPoint, 0.1))
                  {
                    CutterNotch cutterNotch = new CutterNotch(cutterNotchList1[index22]);
                    Point3D mirrorPoint = new Point3D();
                    clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
                    cutterNotch.Position = new Point3D(mirrorPoint.X, mirrorPoint.Y);
                    cutterNotch.DirectionAngle += 180.0;
                    cutterNotchList2.Add(cutterNotch);
                  }
                }
                if (cutterNotchList2.Count > 0)
                {
                  for (int index23 = 0; index23 <= cutterNotchList2.Count - 1; ++index23)
                  {
                    bool flag3 = false;
                    for (int index24 = 0; index24 <= cutterNotchList1.Count - 1; ++index24)
                    {
                      if (buCompare5.EQ(cutterNotchList1[index24].Position, cutterNotchList2[index23].Position, 0.1))
                      {
                        flag3 = true;
                        index24 = cutterNotchList1.Count;
                      }
                    }
                    if (!flag3)
                      cutterNotchList1.Add(new CutterNotch(cutterNotchList2[index23]));
                  }
                }
                List<Point3D> mirrorPoint1 = new List<Point3D>();
                clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint1);
                mirrorPoint1.Reverse();
                point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint1);
                clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
                Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
                clsInit.cVector5.CopyEntityProperties(entity, ref copiedEntity);
                entity = copiedEntity;
              }
            }
          }
          if (entity.BoxMin == (Point3D) null)
            entity.Regen(0.01);
          CutterPart cutterPart2 = new CutterPart();
          Entity copiedEntity1 = (Entity) null;
          buEntity.Copy(entity, ref copiedEntity1);
          cutterPart2.Cut = copiedEntity1;
          cutterPart2.pntMin = buVector5.ToPoint3D(entity.BoxMin);
          cutterPart2.pntMax = buVector5.ToPoint3D(entity.BoxMax);
          copiedEnt[index16].Selected = true;
          cutterPartList.Add(cutterPart2);
        }
      }
      for (int index25 = 0; index25 <= copiedEnt.Count - 1; ++index25)
      {
        Entity refEntity1 = copiedEnt[index25];
        if (refEntity1.BoxMax == (Point3D) null)
          refEntity1.Regen(0.01);
        if (copiedEnt[index25] is ICurve)
        {
          if (refEntity1.LayerName == clsCutter.varCutterSettings.InnerContourLayerName)
          {
            for (int index26 = 0; index26 <= cutterPartList.Count - 1; ++index26)
            {
              if (clsInit.cVector5.isBoxSizeInsideBoxSize(cutterPartList[index26].pntMin, cutterPartList[index26].pntMax, refEntity1.BoxMin, refEntity1.BoxMax, Plane.XY))
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity);
                cutterPartList[index26].InnerCut.Add(copiedEntity);
                index26 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = true;
          }
          if (refEntity1.LayerName == clsCutter.varCutterSettings.ContourRefLayerName)
            copiedEnt[index25].Selected = true;
          if (refEntity1.LayerName == clsCutter.varCutterSettings.InnerContourRefLayerName)
            copiedEnt[index25].Selected = true;
          if (refEntity1.LayerName == clsCutter.varCutterSettings.RopeDirectionLayerName)
          {
            for (int index27 = 0; index27 <= cutterPartList.Count - 1; ++index27)
            {
              if (clsInit.cVector5.isBoxSizeInsideBoxSize(cutterPartList[index27].pntMin, cutterPartList[index27].pntMax, refEntity1.BoxMin, refEntity1.BoxMax, Plane.XY))
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity);
                cutterPartList[index27].RopeDirection.Add(copiedEntity);
                index27 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = true;
          }
          if (refEntity1.LayerName == clsCutter.varCutterSettings.InnerContourNoCutLayerName)
          {
            for (int index28 = 0; index28 <= cutterPartList.Count - 1; ++index28)
            {
              if (clsInit.cVector5.isBoxSizeInsideBoxSize(cutterPartList[index28].pntMin, cutterPartList[index28].pntMax, refEntity1.BoxMin, refEntity1.BoxMax, Plane.XY))
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity);
                cutterPartList[index28].InnerNoCut.Add(copiedEntity);
                index28 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = false;
          }
          if (refEntity1.LayerName == clsCutter.varCutterSettings.InnerContourPloter1LayerName)
          {
            for (int index29 = 0; index29 <= cutterPartList.Count - 1; ++index29)
            {
              if (clsInit.cVector5.isBoxSizeInsideBoxSize(cutterPartList[index29].pntMin, cutterPartList[index29].pntMax, refEntity1.BoxMin, refEntity1.BoxMax, Plane.XY))
              {
                if (entityList21.Count > 0)
                {
                  for (int index30 = 0; index30 <= entityList21.Count - 1; ++index30)
                  {
                    Point3D startPoint = ((ICurve) entityList21[index30]).StartPoint;
                    Point3D endPoint = ((ICurve) entityList21[index30]).EndPoint;
                    Point3D point3D4 = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
                    List<Point3D> point3DList = new List<Point3D>();
                    buVector5.VerticeToPointsList(refEntity1.Vertices, ref point3DList);
                    bool flag = false;
                    for (int index31 = 1; index31 <= point3DList.Count - 1; ++index31)
                    {
                      Point3D point3D5 = clsInit.cVector5.MiddlePointOfLine(point3DList[index31 - 1], point3DList[index31]);
                      if (buCompare5.EQ(point3D4, point3D5))
                      {
                        point3DList.RemoveAt(index31);
                        flag = true;
                      }
                    }
                    if (!flag)
                    {
                      Point3D point3D6 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
                      if (buCompare5.EQ(point3D4, point3D6))
                        flag = true;
                    }
                    if (!flag)
                    {
                      if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index30], point3DList[0], 0.1))
                        flag = true;
                      if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index30], point3DList[point3DList.Count - 1], 0.1))
                        flag = true;
                    }
                    if (flag)
                    {
                      List<Point3D> mirrorPoint = new List<Point3D>();
                      clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
                      mirrorPoint.Reverse();
                      point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
                      clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
                      Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
                      clsInit.cVector5.CopyEntityProperties(refEntity1, ref copiedEntity);
                      refEntity1 = copiedEntity;
                    }
                  }
                }
                Entity copiedEntity2 = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity2);
                cutterPartList[index29].Plotter1.Add(copiedEntity2);
                index29 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = true;
          }
          if (refEntity1.LayerName == clsCutter.varCutterSettings.InnerContourPloter2LayerName)
          {
            for (int index32 = 0; index32 <= cutterPartList.Count - 1; ++index32)
            {
              if (clsInit.cVector5.isBoxSizeInsideBoxSize(cutterPartList[index32].pntMin, cutterPartList[index32].pntMax, refEntity1.BoxMin, refEntity1.BoxMax, Plane.XY))
              {
                if (entityList21.Count > 0)
                {
                  for (int index33 = 0; index33 <= entityList21.Count - 1; ++index33)
                  {
                    Point3D startPoint = ((ICurve) entityList21[index33]).StartPoint;
                    Point3D endPoint = ((ICurve) entityList21[index33]).EndPoint;
                    Point3D point3D7 = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
                    List<Point3D> point3DList = new List<Point3D>();
                    buVector5.VerticeToPointsList(refEntity1.Vertices, ref point3DList);
                    bool flag = false;
                    for (int index34 = 1; index34 <= point3DList.Count - 1; ++index34)
                    {
                      Point3D point3D8 = clsInit.cVector5.MiddlePointOfLine(point3DList[index34 - 1], point3DList[index34]);
                      if (buCompare5.EQ(point3D7, point3D8))
                      {
                        point3DList.RemoveAt(index34);
                        flag = true;
                      }
                    }
                    if (!flag)
                    {
                      Point3D point3D9 = clsInit.cVector5.MiddlePointOfLine(point3DList[0], point3DList[point3DList.Count - 1]);
                      if (buCompare5.EQ(point3D7, point3D9))
                        flag = true;
                    }
                    if (!flag)
                    {
                      if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index33], point3DList[0], 0.1))
                        flag = true;
                      if (clsInit.cVector5.isPointInsideEntity((ICurve) entityList21[index33], point3DList[point3DList.Count - 1], 0.1))
                        flag = true;
                    }
                    if (flag)
                    {
                      List<Point3D> mirrorPoint = new List<Point3D>();
                      clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, point3DList, ref mirrorPoint);
                      mirrorPoint.Reverse();
                      point3DList.AddRange((IEnumerable<Point3D>) mirrorPoint);
                      clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref point3DList);
                      Entity copiedEntity = (Entity) new LinearPath((ICollection<Point3D>) point3DList);
                      clsInit.cVector5.CopyEntityProperties(refEntity1, ref copiedEntity);
                      refEntity1 = copiedEntity;
                    }
                  }
                }
                Entity copiedEntity3 = (Entity) null;
                buEntity.Copy(refEntity1, ref copiedEntity3);
                cutterPartList[index32].Plotter2.Add(copiedEntity3);
                index32 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = true;
          }
        }
        if (refEntity1 is Text)
        {
          bool flag = false;
          Text text1 = refEntity1 as Text;
          if (refEntity1.LayerName == clsCutter.varCutterSettings.DrillLayerName && text1.TextString.IndexOf("#-") >= 0)
          {
            double num = 5.0;
            for (int index35 = 0; index35 <= entityList20.Count - 1; ++index35)
            {
              if (entityList20[index35].LayerName == clsCutter.varCutterSettings.DrillLayerName && buCompare5.EQ(text1.InsertionPoint, ((devDept.Eyeshot.Entities.Point) entityList20[index35]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point) entityList20[index35]).StartPoint.Z > 0.0)
                num = ((devDept.Eyeshot.Entities.Point) entityList20[index35]).StartPoint.Z;
            }
            Circle refEntity2 = new Circle(text1.InsertionPoint, num / 2.0);
            for (int index36 = 0; index36 <= cutterPartList.Count - 1; ++index36)
            {
              if (clsInit.cVector5.IsPointInsideBoxsize(refEntity2.Center, cutterPartList[index36].pntMin, cutterPartList[index36].pntMax, Plane.XY))
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy((Entity) refEntity2, ref copiedEntity);
                cutterPartList[index36].Drill.Add(copiedEntity);
                index36 = cutterPartList.Count;
              }
            }
            copiedEnt[index25].Selected = true;
            flag = true;
          }
          if (!clsCutter.varCutterSettings.AddAttribute && refEntity1 is devDept.Eyeshot.Entities.Attribute)
          {
            copiedEnt[index25].Selected = true;
            flag = true;
          }
          if (!flag && text1.TextString.IndexOf("#-") >= 0)
          {
            copiedEnt[index25].Selected = true;
            flag = true;
          }
          if (!flag & index1 == 0)
          {
            copiedEnt[index25].Selected = true;
            Text text2 = (Text) refEntity1.Clone();
            text2.LayerName = clsCutter.varCutterSettings.InfoLayerName;
            entityList17.Add((Entity) text2);
          }
        }
      }
      for (int index37 = 0; index37 <= cutterPartList.Count - 1; ++index37)
      {
        for (int index38 = 0; index38 <= cutterNotchList1.Count - 1; ++index38)
        {
          if (clsInit.cVector5.isPointOverEntity((ICurve) cutterPartList[index37].Cut, cutterNotchList1[index38].Position, 0.1))
            cutterPartList[index37].Notch.Add(new CutterNotch(cutterNotchList1[index38]));
        }
      }
      clsInit.appCommand.undoBuffer();
      Entity entCalculted1 = (Entity) null;
      for (int index39 = 0; index39 <= cutterPartList.Count - 1; ++index39)
      {
        ccVars.UndoDont = true;
        this.ScaleEntityFromStrectPoints(cutterPartList[index39].Cut, StrectPnt1, ref entCalculted1);
        if (entCalculted1.BoxMax == (Point3D) null)
          entCalculted1.Regen(0.01);
        string str = $"Cut{index39.ToString()}{this.Properties.SizeList[index1]}";
        entCalculted1.LayerName = clsCutter.varCutterSettings.ContourLayerName;
        ((CustomData) entCalculted1.EntityData).typeDefination = entityTypeDefination.Cutting;
        ((CustomData) entCalculted1.EntityData).EntityName = str;
        ((CustomData) entCalculted1.EntityData).ActionName = "OutterEntity";
        ((CustomData) entCalculted1.EntityData).Tags = "";
        ((CustomData) entCalculted1.EntityData).infoData = this.Properties.SizeList[index1];
        Entity copiedEntity4 = (Entity) null;
        buEntity.Copy(entCalculted1, ref copiedEntity4);
        cutterPartList[index39].Cut = copiedEntity4;
        clsInit.appCommand.AddEntity(entCalculted1);
        for (int index40 = 0; index40 <= cutterPartList[index39].InnerCut.Count - 1; ++index40)
        {
          ccVars.UndoDont = true;
          Entity entCalculted2 = (Entity) null;
          this.ScaleEntityFromStrectPoints(cutterPartList[index39].InnerCut[index40], StrectPnt2, ref entCalculted2);
          entCalculted2.LayerName = clsCutter.varCutterSettings.InnerContourLayerName;
          ((CustomData) entCalculted2.EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
          ((CustomData) entCalculted2.EntityData).EntityName = "InnerCut" + index40.ToString();
          ((CustomData) entCalculted2.EntityData).ActionName = "InnerEntity";
          ((CustomData) entCalculted2.EntityData).Tags = str;
          clsInit.appCommand.AddEntity(entCalculted2);
        }
        for (int index41 = 0; index41 <= cutterPartList[index39].InnerNoCut.Count - 1; ++index41)
        {
          ccVars.UndoDont = true;
          Entity entCalculted3 = (Entity) null;
          this.ScaleEntityFromStrectPoints(cutterPartList[index39].InnerNoCut[index41], StrectPnt3, ref entCalculted3);
          entCalculted3.LayerName = clsCutter.varCutterSettings.InnerContourNoCutLayerName;
          ((CustomData) entCalculted3.EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
          ((CustomData) entCalculted3.EntityData).EntityName = "InnerNoCut" + index41.ToString();
          ((CustomData) entCalculted3.EntityData).ActionName = "InnerEntity";
          ((CustomData) entCalculted3.EntityData).Tags = str;
          entCalculted3.Selectable = false;
          clsInit.appCommand.AddEntity(entCalculted3);
        }
        for (int index42 = 0; index42 <= cutterPartList[index39].Plotter1.Count - 1; ++index42)
        {
          ccVars.UndoDont = true;
          Entity entCalculted4 = (Entity) null;
          this.ScaleEntityFromStrectPoints(cutterPartList[index39].Plotter1[index42], StrectPnt6, ref entCalculted4);
          entCalculted4.LayerName = clsCutter.varCutterSettings.InnerContourPloter1LayerName;
          ((CustomData) entCalculted4.EntityData).EntityName = "Plotter1" + index42.ToString();
          ((CustomData) entCalculted4.EntityData).ActionName = "InnerEntity";
          ((CustomData) entCalculted4.EntityData).Tags = str;
          ((CustomData) entCalculted4.EntityData).typeDefination = entityTypeDefination.InnerAux;
          clsInit.appCommand.AddEntity(entCalculted4);
        }
        for (int index43 = 0; index43 <= cutterPartList[index39].Plotter2.Count - 1; ++index43)
        {
          ccVars.UndoDont = true;
          Entity entCalculted5 = (Entity) null;
          this.ScaleEntityFromStrectPoints(cutterPartList[index39].Plotter2[index43], StrectPnt7, ref entCalculted5);
          entCalculted5.LayerName = clsCutter.varCutterSettings.InnerContourPloter2LayerName;
          ((CustomData) entCalculted5.EntityData).EntityName = "Plotter2" + index43.ToString();
          ((CustomData) entCalculted5.EntityData).ActionName = "InnerEntity";
          ((CustomData) entCalculted5.EntityData).Tags = str;
          ((CustomData) entCalculted5.EntityData).typeDefination = entityTypeDefination.InnerAux;
          clsInit.appCommand.AddEntity(entCalculted5);
        }
        for (int index44 = 0; index44 <= cutterPartList[index39].Drill.Count - 1; ++index44)
        {
          ccVars.UndoDont = true;
          Entity entCalculted6 = (Entity) null;
          this.ScaleDrillFromStrectPoints(cutterPartList[index39].Drill[index44], StrectPnt5, ref entCalculted6);
          entCalculted6.LayerName = clsCutter.varCutterSettings.InnerContourPloter1LayerName;
          ((CustomData) entCalculted6.EntityData).EntityName = "Drill" + index44.ToString();
          ((CustomData) entCalculted6.EntityData).ActionName = "InnerEntity";
          ((CustomData) entCalculted6.EntityData).Tags = str;
          ((CustomData) entCalculted6.EntityData).typeDefination = entityTypeDefination.DrillAux;
          clsInit.appCommand.AddEntity(entCalculted6);
        }
        for (int index45 = 0; index45 <= cutterPartList[index39].RopeDirection.Count - 1; ++index45)
        {
          ccVars.UndoDont = true;
          Point3D point3D10 = buVector5.ToPoint3D(((ICurve) cutterPartList[index39].RopeDirection[index45]).StartPoint);
          Point3D point3D11 = buVector5.ToPoint3D(((ICurve) cutterPartList[index39].RopeDirection[index45]).EndPoint);
          double num = Point3D.Distance(point3D10, point3D11);
          List<Entity> calcEntities = new List<Entity>();
          clsInit.cVector5.DrawWireArrow(point3D10, point3D11, num * 0.1, 15.0, Plane.XY, ref calcEntities);
          for (int index46 = 0; index46 <= calcEntities.Count - 1; ++index46)
          {
            Entity entCalculted7 = (Entity) null;
            this.ScaleEntityFromStrectPoints(calcEntities[index46], StrectPnt4, ref entCalculted7);
            entCalculted7.LayerName = clsCutter.varCutterSettings.RopeDirectionLayerName;
            ((CustomData) entCalculted7.EntityData).typeDefination = entityTypeDefination.Direction;
            ((CustomData) entCalculted7.EntityData).EntityName = "RopeDir" + index45.ToString();
            ((CustomData) entCalculted7.EntityData).ActionName = "InnerEntity";
            ((CustomData) entCalculted7.EntityData).Tags = str;
            clsInit.appCommand.AddEntity(entCalculted7);
          }
        }
        for (int index47 = 0; index47 <= cutterPartList[index39].Notch.Count - 1; ++index47)
        {
          List<Entity> notchEntities = new List<Entity>();
          CutterNotch calcNotch = new CutterNotch();
          this.ScaleNotchFromStrectPoints(cutterPartList[index39].Notch[index47], StrectPnt8, ref calcNotch);
          clsInit.cCutter.CreateNotch(calcNotch.NotchType, buVector5.ToPoint3D(calcNotch.Position), calcNotch.Length, calcNotch.DirectionAngle, calcNotch.Angle, (ICurve) cutterPartList[index39].Cut, ref notchEntities);
          for (int index48 = 0; index48 <= notchEntities.Count - 1; ++index48)
          {
            ccVars.UndoDont = true;
            Entity copiedEntity5 = (Entity) null;
            buEntity.Copy(notchEntities[index48], ref copiedEntity5);
            copiedEntity5.LayerName = clsCutter.varCutterSettings.NotchLayerName;
            ((CustomData) copiedEntity5.EntityData).EntityName = "Notch" + index47.ToString();
            ((CustomData) copiedEntity5.EntityData).ActionName = "InnerEntity";
            ((CustomData) copiedEntity5.EntityData).Tags = str;
            ((CustomData) copiedEntity5.EntityData).typeDefination = entityTypeDefination.Notch;
            ((CustomData) copiedEntity5.EntityData).infoBasePoint = new Point3D(cutterNotchList1[index48].Position.X, cutterNotchList1[index48].Position.Y, cutterNotchList1[index48].Position.Z);
            ((CustomData) copiedEntity5.EntityData).infoLength = cutterNotchList1[index48].Length;
            ((CustomData) copiedEntity5.EntityData).infoWidth = cutterNotchList1[index48].Width;
            ((CustomData) copiedEntity5.EntityData).infoAngle = cutterNotchList1[index48].Angle;
            ((CustomData) copiedEntity5.EntityData).infoDirection = cutterNotchList1[index48].DirectionAngle;
            ((CustomData) copiedEntity5.EntityData).infoString = cutterNotchList1[index48].NotchType.ToString();
            clsInit.appCommand.AddEntity(copiedEntity5);
          }
        }
      }
      if (index1 == 0)
      {
        for (int index49 = 0; index49 <= entityList17.Count - 1; ++index49)
        {
          ccVars.UndoDont = true;
          Entity Ent = buVector5.CopyEntities(entityList17[index49]);
          Point3D point3D = buVector5.ToPoint3D(((Text) entityList17[index49]).InsertionPoint);
          bool flag = false;
          for (int index50 = 0; index50 <= cutterPartList.Count - 1; ++index50)
          {
            Entity copiedEntity = (Entity) null;
            buEntity.Copy(cutterPartList[index50].Cut, ref copiedEntity);
            copiedEntity.Regen(0.01);
            if (clsInit.cVector5.IsPointInsideBoxsize(point3D, copiedEntity.BoxMin, copiedEntity.BoxMax, Plane.XY))
            {
              flag = true;
              index50 = cutterPartList.Count;
            }
          }
          Ent.LayerName = !flag ? clsCutter.varCutterSettings.InfoLayerName : clsCutter.varCutterSettings.PartInfoLayerName;
          ((CustomData) Ent.EntityData).typeDefination = entityTypeDefination.Text;
          clsInit.appCommand.AddEntity(Ent);
        }
      }
    }
  }

  public void ScaleEntityFromStrectPoints(
    Entity refEntity,
    List<RulStrectPoints> StrectPnt,
    ref Entity entCalculted)
  {
    List<Pnt3D> CopiedPnt1 = new List<Pnt3D>();
    List<Pnt3D> Points = new List<Pnt3D>();
    Pnt3D Pnt1 = new Pnt3D();
    Pnt3D pnt3D = new Pnt3D();
    List<Pnt3D> pnt3DList = new List<Pnt3D>();
    Point3D point3D1 = new Point3D();
    Point3D point3D2 = new Point3D();
    Point3D point3D3 = new Point3D();
    Entity entity = (Entity) null;
    buEntity.Copy(refEntity);
    for (int index1 = 0; index1 <= entity.Vertices.Length - 1; ++index1)
    {
      Pnt3D Pnt2 = new Pnt3D(entity.Vertices[index1].X, entity.Vertices[index1].Y, entity.Vertices[index1].Z);
      bool flag = false;
      for (int index2 = 0; index2 <= StrectPnt.Count - 1; ++index2)
      {
        if (buCompare5.EQ(Pnt2, StrectPnt[index2].Position))
        {
          Pnt1 = new Pnt3D(Pnt2);
          double dX = StrectPnt[index2].dX;
          double dY = StrectPnt[index2].dY;
          Pnt2 = new Pnt3D(Pnt2.X + StrectPnt[index2].dX, Pnt2.Y + StrectPnt[index2].dY, Pnt2.Z);
          flag = true;
        }
      }
      if (flag)
      {
        if (Points.Count > 0 & CopiedPnt1.Count > 0)
        {
          Points.Insert(0, new Pnt3D(pnt3D));
          Points.Add(new Pnt3D(Pnt1));
          Pnt3D MinPoint = new Pnt3D();
          Pnt3D MidPoint = new Pnt3D();
          Pnt3D MaxPoint = new Pnt3D();
          clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint, ref MidPoint, ref MaxPoint);
          double num1 = Pnt2.X - CopiedPnt1[CopiedPnt1.Count - 1].X;
          double num2 = Pnt2.Y - CopiedPnt1[CopiedPnt1.Count - 1].Y;
          double num3 = Points[Points.Count - 1].X - Points[0].X;
          double num4 = Points[Points.Count - 1].Y - Points[0].Y;
          double RatioX = (Pnt2.X - CopiedPnt1[CopiedPnt1.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
          double RatioY = (Pnt2.Y - CopiedPnt1[CopiedPnt1.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
          clsInit.cVector.Scale(pnt3D, RatioX, RatioY, 1.0, true, true, false, ref Points);
          double num5 = CopiedPnt1[CopiedPnt1.Count - 1].X - Points[0].X;
          double num6 = CopiedPnt1[CopiedPnt1.Count - 1].Y - Points[0].Y;
          clsInit.cVector.Move(Points[0], CopiedPnt1[CopiedPnt1.Count - 1], ref Points);
          Points.RemoveAt(0);
          Points.RemoveAt(Points.Count - 1);
          Pnt3D.Add(Points, ref CopiedPnt1);
          Points.Clear();
          Points = new List<Pnt3D>();
        }
        if (Points.Count > 0 & CopiedPnt1.Count == 0)
        {
          Points.Add(new Pnt3D(Pnt2));
          Pnt3D.Add(Points, ref CopiedPnt1);
          Points.Clear();
          Points = new List<Pnt3D>();
        }
        CopiedPnt1.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
        pnt3D = new Pnt3D(Pnt1);
      }
      else
        Points.Add(new Pnt3D(Pnt2.X, Pnt2.Y, Pnt2.Z));
    }
    if (Points.Count > 0)
      Pnt3D.Add(Points, ref CopiedPnt1);
    EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
    CustomData customData = new CustomData((CustomData) entity.EntityData);
    LinearPath Ent = new LinearPath(Array.Empty<Point3D>());
    List<Point3D> CopiedPnt2 = new List<Point3D>();
    if (CopiedPnt1.Count > 0)
      buConversion5.Pnt3DToPoint3D(CopiedPnt1, ref CopiedPnt2);
    else
      buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
    clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData, customData, ref Ent);
    Ent.EntityData = (object) customData;
    entCalculted = (Entity) Ent;
  }

  public void ScaleNotchFromStrectPoints(
    CutterNotch refNotch,
    List<RulStrectPoints> StrectPnt,
    ref CutterNotch calcNotch)
  {
    Pnt3D pnt3D1 = new Pnt3D();
    Pnt3D pnt3D2 = new Pnt3D();
    Pnt3D Pnt = new Pnt3D(refNotch.Position.X, refNotch.Position.Y, refNotch.Position.Z);
    calcNotch = new CutterNotch(refNotch);
    for (int index = 0; index <= StrectPnt.Count - 1; ++index)
    {
      if (buCompare5.EQ(StrectPnt[index].Position, new Pnt3D(refNotch.Position.X, refNotch.Position.Y, refNotch.Position.Z)))
      {
        Pnt3D pnt3D3 = new Pnt3D(Pnt);
        double dX = StrectPnt[index].dX;
        double dY = StrectPnt[index].dY;
        calcNotch.Position = new Point3D(Pnt.X + StrectPnt[index].dX, Pnt.Y + StrectPnt[index].dY, Pnt.Z);
      }
    }
  }

  public void ScaleDrillFromStrectPoints(
    Entity refEntity,
    List<RulStrectPoints> StrectPnt,
    ref Entity entCalculted)
  {
    Pnt3D pnt3D = new Pnt3D(((Circle) refEntity).Center.X, ((Circle) refEntity).Center.Y, ((Circle) refEntity).Center.Z);
    double radius = ((Circle) refEntity).Radius;
    for (int index = 0; index <= StrectPnt.Count - 1; ++index)
    {
      if (buCompare5.EQ(pnt3D, StrectPnt[index].Position))
        pnt3D = new Pnt3D(pnt3D.X + StrectPnt[index].dX, pnt3D.Y + StrectPnt[index].dY, pnt3D.Z);
    }
    Entity copiedEntity = (Entity) null;
    buEntity.Copy(refEntity, ref copiedEntity);
    EntityDataSet entData = new EntityDataSet(-1, clsCutter.varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", (string) null, ccVars.pntBase);
    CustomData customData = new CustomData((CustomData) copiedEntity.EntityData);
    Circle Ent = (Circle) null;
    clsInit.appCommand.CreateCircle(new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z), radius, Plane.XY, entData, customData, ref Ent);
    Ent.EntityData = (object) customData;
    entCalculted = (Entity) Ent;
  }

  public void doNewExtension()
  {
    ccVars.MaterialList.Clear();
    if (!clsCutter.varCutterSettings.ShowMachineSize)
      return;
    for (int index = 0; (double) index <= clsCutter.varCutterSettings.RepeatCount - 1.0; ++index)
      ccVars.MaterialList.Add(new MaterialBase5(clsCutter.varCutterSettings.MachineWidth, clsCutter.varCutterSettings.MachineHeight, 1.0)
      {
        dX = (double) index * clsCutter.varCutterSettings.MachineWidth
      });
  }

  public void doOpenPage()
  {
    ccVars.MaterialList.Clear();
    if (!clsCutter.varCutterSettings.ShowMachineSize)
      return;
    for (int index = 0; (double) index <= clsCutter.varCutterSettings.RepeatCount - 1.0; ++index)
      ccVars.MaterialList.Add(new MaterialBase5(clsCutter.varCutterSettings.MachineWidth, clsCutter.varCutterSettings.MachineHeight, 1.0)
      {
        dX = (double) index * clsCutter.varCutterSettings.MachineWidth
      });
  }

  public void doConvertText(List<buEntity> refEntities)
  {
    if (refEntities.Count <= 0)
      return;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
    {
      if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() == typeof (Text))
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Selected = true;
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
    List<Entity> entityList = new List<Entity>();
    SortbuSettings Settings = new SortbuSettings();
    List<buEntity> SortedEntities = new List<buEntity>();
    clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref refEntities, Settings, ref SortedEntities);
    List<List<buEntity>> buEntityListList = new List<List<buEntity>>();
    List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
    clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
    List<buEntity> buEntityList = new List<buEntity>();
    for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
    {
      buEntity buEntity1 = SplitedEntitites[index1][0];
      if (!buEntity1.Info.CamSelected)
        buEntityList.Add(buEntity1);
      if (!buEntity1.Info.CamSelected)
      {
        for (int index2 = 0; index2 <= SplitedEntitites.Count - 1; ++index2)
        {
          if (index2 != index1)
          {
            buEntity buEntity2 = SplitedEntitites[index2][0];
            if (!buEntity2.Info.CamSelected)
            {
              for (int index3 = 0; index3 <= buEntity1.Vertices.Count - 1; ++index3)
              {
                for (int index4 = 0; index4 <= buEntity2.Vertices.Count - 1; ++index4)
                {
                  if (buCompare5.EQ(buEntity1.Vertices[index3], buEntity2.Vertices[index4]))
                  {
                    buEntity2.Info.CamSelected = true;
                    buEntityList.Add(buEntity2);
                  }
                }
              }
            }
          }
        }
      }
      if (buEntityList.Count > 0)
      {
        buEntity1.Info.CamSelected = true;
        buEntityListList.Add(buEntityList);
        buEntityList = new List<buEntity>();
      }
    }
    for (int index5 = buEntityListList.Count - 1; index5 >= 0; --index5)
    {
      bool flag = false;
      if (index5 <= buEntityListList.Count - 1)
      {
        for (int index6 = 0; index6 <= ccVars.CharLibList.Count - 1; ++index6)
        {
          for (int index7 = 0; index7 <= ccVars.CharLibList[index6].CharEntities.Count - 1; ++index7)
          {
            if (!flag && buEntityListList[index5].Count >= 1 && buEntityListList[index5][0] is buLinearPath & ccVars.CharLibList[index6].CharEntities[index7] is buLinearPath)
            {
              buLinearPath buLinearPath = buEntityListList[index5][0] as buLinearPath;
              buLinearPath charEntity = ccVars.CharLibList[index6].CharEntities[index7] as buLinearPath;
              Point3D MinPoint1 = new Point3D();
              Point3D MidPoint1 = new Point3D();
              Point3D MaxPoint1 = new Point3D();
              clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[index6].CharEntities, ref MinPoint1, ref MidPoint1, ref MaxPoint1);
              if (buLinearPath.Vertices.Count == charEntity.Vertices.Count)
              {
                double num1 = clsInit.cVector5.Length3D(buLinearPath.Vertices);
                double num2 = clsInit.cVector5.Length3D(charEntity.Vertices);
                double num3 = clsInit.cVector5.PointAngle(buLinearPath.Vertices[1], buLinearPath.Vertices[0]);
                double num4 = clsInit.cVector5.PointAngle(charEntity.Vertices[1], charEntity.Vertices[0]);
                if (buCompare5.EQ(num1, num2, 0.5))
                {
                  if (ccVars.CharLibList[index6].CharEntities.Count == 1)
                  {
                    Point3D MinPoint2 = new Point3D();
                    Point3D MidPoint2 = new Point3D();
                    Point3D MaxPoint2 = new Point3D();
                    clsInit.cVector5.BoxSizeCalculate(buLinearPath.Vertices, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
                    Entity entity = (Entity) new Text(Plane.XY, MidPoint2, ccVars.CharLibList[index6].Char, MaxPoint1.Y - MinPoint1.Y, Text.alignmentType.MiddleCenter);
                    if (!buCompare5.EQ(num3, num4, 1.0))
                    {
                      double radian = buConversion5.DegreeToRadian(num3 - num4);
                      entity.Rotate(radian, Vector3D.AxisZ, MidPoint2);
                    }
                    entityList.Add(entity);
                    flag = true;
                  }
                  else
                  {
                    Point3D MinPoint3 = new Point3D();
                    Point3D MidPoint3 = new Point3D();
                    Point3D MaxPoint3 = new Point3D();
                    clsInit.cVector5.BoxSizeCalculate(buEntityListList[index5], ref MinPoint3, ref MidPoint3, ref MaxPoint3);
                    Entity entity = (Entity) new Text(Plane.XY, MidPoint3, ccVars.CharLibList[index6].Char, MaxPoint1.Y - MinPoint1.Y, Text.alignmentType.MiddleCenter);
                    if (!buCompare5.EQ(num3, num4, 1.0))
                    {
                      double radian = buConversion5.DegreeToRadian(num3 - num4);
                      entity.Rotate(radian, Vector3D.AxisZ, MidPoint3);
                    }
                    entityList.Add(entity);
                    flag = true;
                  }
                }
              }
            }
          }
        }
      }
      if (flag)
        buEntityListList.RemoveAt(index5);
    }
    if (entityList.Count > 0)
    {
      for (int index = 0; index <= entityList.Count - 1; ++index)
      {
        entityList[index].LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[0].Name;
        ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(entityList[index]);
      }
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    ccVars.pntDrawDynamicLinesArr = new List<List<Point3D>>();
    for (int index = 0; index <= buEntityListList.Count - 1; ++index)
    {
      List<Point3D> copiedPoint = new List<Point3D>();
      buVector5.Copy(buEntityListList[index][0].Vertices, ref copiedPoint);
      ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
    }
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void doOffsetDrawing()
  {
    F_CutterOffsetEntities cutterOffsetEntities = new F_CutterOffsetEntities();
    cutterOffsetEntities.OffsetValue = clsCutter.varCutterSettings.OffsetValue;
    cutterOffsetEntities.OffsetType = clsCutter.varCutterSettings.OffsetType;
    cutterOffsetEntities.DeleteOriginal = clsCutter.varCutterSettings.DeleteOriginal;
    cutterOffsetEntities.Init();
    int num = (int) cutterOffsetEntities.ShowDialog();
    if (cutterOffsetEntities.PropertiesForm.Result != DialogResult.OK)
      return;
    clsCutter.varCutterSettings.OffsetValue = cutterOffsetEntities.OffsetValue;
    clsCutter.varCutterSettings.OffsetType = cutterOffsetEntities.OffsetType;
    clsCutter.varCutterSettings.DeleteOriginal = cutterOffsetEntities.DeleteOriginal;
    camTp Cam = new camTp();
    this.cmdCamContour(ref Cam);
  }

  public void doOperationAfterFileLoad()
  {
    if (!clsCutter.varCutterSettings.LockLayers)
      return;
    for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; ++index)
      ccVars.Pages[ccVars.PageIndex].Layers[index].Lock = !(ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsCutter.varCutterSettings.ContourLayerName | ccVars.Pages[ccVars.PageIndex].Layers[index].Name == clsCutter.varCutterSettings.ContourRefLayerName);
    clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, true, 0);
  }

  public void doNotchRotate()
  {
    for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
    {
      Entity entity = buVector5.CopyEntities(ccVars.SelectionOP.Selections[index1].SelectedEntity);
      CustomData entityData1 = entity.EntityData as CustomData;
      if (entityData1.typeDefination == entityTypeDefination.Notch)
      {
        F_NotchEdit fNotchEdit = new F_NotchEdit();
        fNotchEdit.Notch = new CutterNotch(new CutterNotch()
        {
          DirectionAngle = entityData1.infoDirection,
          Length = entityData1.infoLength,
          baseEntityName = entityData1.ActionName,
          Position = new Point3D(entityData1.infoBasePoint.X, entityData1.infoBasePoint.Y, entityData1.infoBasePoint.Z),
          NotchType = !(entityData1.infoString == "VNotch") ? CutterNotchType.INotch : CutterNotchType.VNotch
        });
        fNotchEdit.Init();
        int num = (int) fNotchEdit.ShowDialog();
        if (fNotchEdit.PropertiesForm.Result == DialogResult.OK)
        {
          CutterNotch cutterNotch = new CutterNotch(fNotchEdit.Notch);
          cutterNotch.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch.Width / 2.0 / cutterNotch.Length)) * 2.0;
          if (fNotchEdit.ChangeDirection)
          {
            cutterNotch.DirectionAngle += 180.0;
            if (cutterNotch.DirectionAngle >= 360.0)
              cutterNotch.DirectionAngle -= 360.0;
          }
          ICurve baseEntity = (ICurve) null;
          for (int index2 = 0; index2 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index2)
          {
            CustomData entityData2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData as CustomData;
            if (cutterNotch.baseEntityName == entityData2.EntityName)
            {
              Entity copiedEntity = (Entity) null;
              buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2], ref copiedEntity);
              baseEntity = (ICurve) copiedEntity;
            }
          }
          if (baseEntity != null)
          {
            List<Entity> notchEntities = new List<Entity>();
            clsInit.cCutter.CreateNotch(cutterNotch.NotchType, new Point3D(cutterNotch.Position.X, cutterNotch.Position.Y, cutterNotch.Position.Z), cutterNotch.Length, cutterNotch.DirectionAngle, cutterNotch.Angle, baseEntity, ref notchEntities);
            if (notchEntities.Count > 0)
            {
              notchEntities[0].EntityData = entity.EntityData;
              ((CustomData) notchEntities[0].EntityData).infoLength = cutterNotch.Length;
              ((CustomData) notchEntities[0].EntityData).infoWidth = cutterNotch.Width;
              ((CustomData) notchEntities[0].EntityData).infoAngle = cutterNotch.Angle;
              ((CustomData) notchEntities[0].EntityData).infoDirection = cutterNotch.DirectionAngle;
              ((CustomData) notchEntities[0].EntityData).infoString = cutterNotch.NotchType.ToString();
              int index3 = ccVars.SelectionOP.Selections[index1].Index;
              if (index3 >= 0 & index3 <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
              {
                Entity copiedEntity = (Entity) null;
                buEntity.Copy(notchEntities[0], ref copiedEntity);
                copiedEntity.LayerName = entity.LayerName;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index3] = copiedEntity;
                ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index3].Regen(clsVar.varEntities.RegenDeviation);
              }
            }
          }
        }
      }
    }
    clsInit.appCommand.Reset();
    ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
  }

  public void cmdCamContour(ref camTp Cam)
  {
    try
    {
      clsInit.appCommand.Reset(false);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
      Cam = new camTp();
      this.doWireframeContour(new MWCalculationOptions()
      {
        NumberofAxis = 3,
        CamWireframeType = CamWireFrameType.Contour,
        Mode = CamMode.WireFrame,
        DontApplyReset = true,
        isBuWireframeCalculation = false,
        AddToCamListInLocalCalculation = false,
        AddToCamListInMWCalculation = false,
        ShowLeadInOutPage = false,
        DontShowDialogBox = true
      }, new ToolBase5()
      {
        Purpose = ToolPurpose.Milling,
        Geometry = {
          GeometryType = ToolType.Flat,
          Diameter = clsCutter.varCutterSettings.OffsetValue * 2.0,
          Length = 100.0
        }
      }, ref Cam);
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public int doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
  {
    Cam = new camTp();
    buMWCutterVars.varCamCutter.buPar.Offsets.OpenContour = CamOpenContourType.Center;
    buMWCutterVars.varCamCutter.buPar.Offsets.ClosedContour = clsCutter.varCutterSettings.OffsetType;
    buMWCutterVars.varCamCutter.buPar.Distances.Air = 0.0;
    buMWCutterVars.varCamCutter.buPar.Distances.Safe = 0.0;
    buMWCutterVars.varCamCutter.buPar.Distances.Rapid = 0.0;
    buMWCutterVars.varCamCutter.buPar.Distances.EntryAndExit = 0.0;
    buMWCutterVars.varCamCutter.buPar.Distances.EntryAndExit = 0.0;
    buMWCutterVars.varCamCutter.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWCutterVars.varCamCutter.mwPar, buMWCutterVars.varCamCutter.buPar);
    clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWCutterVars.varCamCutter.mwPar, buMWCutterVars.varCamCutter.buPar, out clsMW.varbuCamWFContourPars);
    clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = true;
    camResult Result1 = (camResult) null;
    int num1 = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result1);
    int num2;
    if (Result1.Errors.Count > 0)
    {
      F_ErrorList fErrorList = new F_ErrorList();
      fErrorList.Init(Result1.Errors);
      int num3 = (int) fErrorList.ShowDialog();
      clsInit.appCommand.Reset();
      num2 = -2;
    }
    else
    {
      ccVars.UndoDont = false;
      clsInit.appCommand.undoBuffer();
      buMWCutterVars.varCamCutter.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWCutterVars.varCamCutter.buPar);
      if (num1 < 1)
      {
        clsInit.appCommand.Reset();
        num2 = num1;
      }
      else
      {
        Cam.Mode = MWCalcoptions.Mode;
        Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
        Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
        Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
        Cam.Action = actionTypeBU.None;
        new List<camTp>() { Cam };
        List<Entity> BaseRefEntities = new List<Entity>();
        if (Cam.EntitiesG1Orj.Count > 0)
        {
          for (int index = 0; index <= Cam.EntitiesG1Orj.Count - 1; ++index)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(Cam.EntitiesG1Orj[index], ref copiedEnt);
            copiedEnt.EntityData = (object) new CustomData();
            BaseRefEntities.Add(copiedEnt);
          }
        }
        else if (Cam.EntitiesG1.Count > 0)
        {
          for (int index = 0; index <= Cam.EntitiesG1.Count - 1; ++index)
          {
            Entity copiedEnt = (Entity) null;
            buVector5.CopyEntities(Cam.EntitiesG1[index], ref copiedEnt);
            copiedEnt.EntityData = (object) new CustomData();
            BaseRefEntities.Add(copiedEnt);
          }
        }
        if (BaseRefEntities.Count > 0)
        {
          SortSettings Settings = new SortSettings();
          Settings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
          Settings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
          Settings.Option.UseCamSelectedProps = true;
          SortResult Result2 = new SortResult();
          List<Entity> SortedEntities = new List<Entity>();
          clsInit.cVector5.SortEntitiesByRefPoint(((ICurve) BaseRefEntities[0]).StartPoint, ref BaseRefEntities, Settings, ref SortedEntities, ref Result2);
          List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
          clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
          for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
          {
            bool flag = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]);
            ccVars.UndoDont = true;
            if (flag)
            {
              List<ICurve> curveList = new List<ICurve>();
              for (int index2 = 0; index2 <= SplitedEntitites[index1].Count - 1; ++index2)
                curveList.Add((ICurve) SplitedEntitites[index1][index2]);
              CompositeCurve compositeCurve = new CompositeCurve((IEnumerable<ICurve>) curveList, true);
              List<Point3D> Points = new List<Point3D>();
              clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[index1], 0.01, ref Points);
              LinearPath Ent = new LinearPath((ICollection<Point3D>) Points);
              clsInit.appCommand.AddEntity((Entity) Ent);
            }
            else
            {
              for (int index3 = 0; index3 <= SplitedEntitites[index1].Count - 1; ++index3)
              {
                ccVars.UndoDont = true;
                clsInit.appCommand.AddEntity(SplitedEntitites[index1][index3]);
              }
            }
          }
          if (clsCutter.varCutterSettings.DeleteOriginal)
            clsInit.appCommand.Delete(false);
          clsInit.appCommand.Reset();
          clsFiles.SaveParameter();
        }
        num2 = 1;
      }
    }
    return num2;
  }
}
