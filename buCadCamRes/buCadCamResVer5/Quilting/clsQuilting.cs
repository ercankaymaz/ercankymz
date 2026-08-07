// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Quilting.clsQuilting
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using buMW;
using buMW.Variables;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Quilting;

public class clsQuilting
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;
  public List<string> cmdExceptionID = new List<string>();
  public SortResult QuiltSortResult = new SortResult();
  public List<List<Entity>> refSortEntitiesLL = new List<List<Entity>>();
  public List<Entity> refSortEntities = new List<Entity>();
  public static QuiltingProgramSettings varQuiltingSettings = new QuiltingProgramSettings();
  public static QuiltingRuntimeSettings varQuiltingRunSettings = new QuiltingRuntimeSettings();

  public clsQuilting()
  {
    if (!clsSystem.smethod_0(nameof (clsQuilting)))
      throw new RegisterException(nameof (clsQuilting));
  }

  public void Init()
  {
    buMWQuiltingVars.Init();
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00100");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00101");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00102");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00103");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00104");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00105");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00106");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00107");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00108");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00109");
    this.cmdExceptionID.Add("clsQuilting - ID = 101-00110");
  }

  public void cmdSelectPattern()
  {
    try
    {
      this.refSortEntitiesLL.Clear();
      ccVars.SortedEntities.Clear();
      this.refSortEntitiesLL = new List<List<Entity>>();
      this.refSortEntities = new List<Entity>();
      List<List<Entity>> entityListList = new List<List<Entity>>();
      List<Entity> copiedEnt = new List<Entity>();
      ccVars.SortedEntities = new List<Entity>();
      if (ccVars.SelectionOP.Selections.Count != 0)
        return;
      ccVars.stpDrawing = 1;
      ccVars.selectionProcess = false;
      ccVars.Action = actionTypeBU.quiltingSelectPattern;
      if (clsQuilting.varQuiltingSettings.SortType == quiltingSortType.All)
      {
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() != typeof (Point))
            copiedEnt.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
        }
      }
      else if (clsQuilting.varQuiltingSettings.SortType == quiltingSortType.FirstDoubleHeadThenSingleHead | clsQuilting.varQuiltingSettings.SortType == quiltingSortType.FirstSingleHeadThenDoubleHead)
      {
        List<Entity> entityList1 = new List<Entity>();
        List<Entity> entityList2 = new List<Entity>();
        for (int index = 0; index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; ++index)
        {
          if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] is ICurve)
          {
            Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
            if (entity.EntityData is CustomData)
            {
              if ((entity.EntityData as CustomData).Tags != "0")
              {
                if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() != typeof (Point))
                  entityList2.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
              }
              else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].GetType() != typeof (Point))
                entityList1.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index]));
            }
          }
        }
        if (clsQuilting.varQuiltingRunSettings.QuiltSortSettings.Option.NextGroupRules == SortingNextGroupFindRulesType.AskMe)
        {
          if (clsQuilting.varQuiltingSettings.SortType == quiltingSortType.FirstDoubleHeadThenSingleHead)
          {
            if (entityList1.Count > 0)
              copiedEnt.AddRange((IEnumerable<Entity>) entityList1);
            if (entityList2.Count > 0)
              copiedEnt.AddRange((IEnumerable<Entity>) entityList2);
          }
          else
          {
            if (entityList2.Count > 0)
              copiedEnt.AddRange((IEnumerable<Entity>) entityList2);
            if (entityList1.Count > 0)
              copiedEnt.AddRange((IEnumerable<Entity>) entityList1);
          }
        }
        else if (clsQuilting.varQuiltingSettings.SortType == quiltingSortType.FirstDoubleHeadThenSingleHead)
        {
          if (entityList1.Count > 0 & entityList2.Count > 0)
          {
            entityListList.Add(entityList1);
            entityListList.Add(entityList2);
          }
          else if (entityList1.Count > 0 & entityList2.Count == 0)
            buVector5.CopyEntities(entityList1, ref copiedEnt);
          else if (entityList1.Count == 0 & entityList2.Count > 0)
            buVector5.CopyEntities(entityList2, ref copiedEnt);
        }
        else if (clsQuilting.varQuiltingSettings.SortType == quiltingSortType.FirstSingleHeadThenDoubleHead)
        {
          if (entityList1.Count > 0 & entityList2.Count > 0)
          {
            entityListList.Add(entityList2);
            entityListList.Add(entityList1);
          }
          else if (entityList1.Count > 0 & entityList2.Count == 0)
            buVector5.CopyEntities(entityList1, ref copiedEnt);
          else if (entityList1.Count == 0 & entityList2.Count > 0)
            buVector5.CopyEntities(entityList2, ref copiedEnt);
        }
      }
      for (int index1 = 0; index1 <= copiedEnt.Count - 1; ++index1)
      {
        if (copiedEnt[index1] is LinearPath)
        {
          for (int index2 = 1; index2 <= copiedEnt[index1].Vertices.Length - 1; ++index2)
          {
            Line line = new Line(copiedEnt[index1].Vertices[index2 - 1], copiedEnt[index1].Vertices[index2]);
            line.EntityData = (object) new CustomData((CustomData) copiedEnt[index1].EntityData);
            this.refSortEntities.Add((Entity) line);
          }
        }
        else
          this.refSortEntities.Add(buVector5.CopyEntities(copiedEnt[index1]));
      }
      for (int index3 = 0; index3 <= entityListList.Count - 1; ++index3)
      {
        List<Entity> entityList = new List<Entity>();
        for (int index4 = 0; index4 <= entityListList[index3].Count - 1; ++index4)
        {
          if (entityListList[index3][index4] is LinearPath)
          {
            for (int index5 = 1; index5 <= entityListList[index3][index4].Vertices.Length - 1; ++index5)
            {
              Line line = new Line(entityListList[index3][index4].Vertices[index5 - 1], entityListList[index3][index4].Vertices[index5]);
              line.EntityData = (object) new CustomData((CustomData) entityListList[index3][index4].EntityData);
              entityList.Add((Entity) line);
            }
          }
          else
            entityList.Add(buVector5.CopyEntities(entityListList[index3][index4]));
        }
        this.refSortEntitiesLL.Add(entityList);
      }
      clsInit.appCommand.cmdMainFormStatusUpdate("Select");
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[0];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdSortSettings()
  {
    try
    {
      F_QuiltingSettings quiltingSettings = new F_QuiltingSettings();
      quiltingSettings.SortSetting = new SortSettings(clsQuilting.varQuiltingRunSettings.QuiltSortSettings);
      quiltingSettings.Init();
      quiltingSettings.StartPosition = FormStartPosition.CenterParent;
      int num = (int) quiltingSettings.ShowDialog();
      if (quiltingSettings.PropertiesForm.Result != DialogResult.OK)
        return;
      clsQuilting.varQuiltingRunSettings.QuiltSortSettings = new SortSettings(quiltingSettings.SortSetting);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[3];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamCreatCode(string FileName)
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
        saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
        saveFileDialog.FilterIndex = 1;
        if (FileName.Length <= 1)
        {
          if (saveFileDialog.ShowDialog() != DialogResult.OK)
            return;
          clsVar.varInterface.pathGCode = buFile.GetPath(saveFileDialog.FileName);
          string Codes = "";
          this.doSelectionToCode(ref Codes);
          buFile.SaveToFile(Codes, saveFileDialog.FileName);
          clsFiles.SaveParameter();
          if (clsItem.FrmProgress == null)
            return;
          clsItem.FrmProgress.Visible = false;
        }
        else
        {
          clsVar.varInterface.pathGCode = buFile.GetPath(FileName);
          string Codes = "";
          this.doSelectionToCode(ref Codes);
          buFile.SaveToFile(Codes, FileName);
          clsFiles.SaveParameter();
          if (clsItem.FrmProgress == null)
            return;
          clsItem.FrmProgress.Visible = false;
        }
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdCamShowCode()
  {
    try
    {
      if (clsVar.appModes_0.DemoMode)
      {
        int num = (int) MessageBox.Show("Not Available in Demo Mode");
      }
      else if (ccVars.Pages.Count <= 0)
      {
        buString.MessageBoxWarning(AppLanguage.Messages[9]);
      }
      else
      {
        string Codes = "";
        this.doSelectionToCode(ref Codes);
        F_Notepad fNotepad = new F_Notepad();
        fNotepad.Init(Codes);
        fNotepad.Show();
        buFile5.SaveToFile(Codes, Application.StartupPath + "\\Temp.cnc");
        this.LoadFile(Application.StartupPath + "\\Temp.cnc");
        if (clsItem.FrmProgress == null)
          return;
        clsItem.FrmProgress.Visible = false;
      }
    }
    catch (Exception ex)
    {
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void cmdShowSettings()
  {
    try
    {
      F_ClassViewerDialog classViewerDialog = new F_ClassViewerDialog();
      classViewerDialog.Text = "Settings";
      classViewerDialog.Value = (object) clsQuilting.varQuiltingSettings;
      classViewerDialog.StartPosition = FormStartPosition.CenterParent;
      classViewerDialog.Width = 500;
      classViewerDialog.Height = 750;
      classViewerDialog.ValuePersentage = 35.0;
      classViewerDialog.Init();
      int num = (int) classViewerDialog.ShowDialog();
      if (classViewerDialog.Result != DialogResult.OK)
        return;
      clsQuilting.varQuiltingSettings = new QuiltingProgramSettings((QuiltingProgramSettings) classViewerDialog.Value);
      clsFiles.SaveParameter();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdUndoSelection()
  {
    try
    {
      buVector5.AskMe.GetBack = true;
      if (this.QuiltSortResult.ResultType == SortingResultType.MultipleEntities)
        buVector5.AskMe.GetBackFromMultiSelection = true;
      clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref clsInit.appQuilting.refSortEntities, clsQuilting.varQuiltingRunSettings.QuiltSortSettings, ref ccVars.SortedEntities, ref this.QuiltSortResult);
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
    }
  }

  public void cmdSetProperties()
  {
    try
    {
      if (ccVars.SelectionOP.Selections.Count == 0)
      {
        ccVars.stpDrawing = 1;
        ccVars.selectionProcess = true;
        ccVars.Action = actionTypeBU.quiltingSetProperties;
      }
      else
        this.doSetProperties();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[3];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadLanguage()
  {
    try
    {
      List<string> stringList = new List<string>();
      FileInfo fileInfo = clsVar.appModes_0.DeveloperPCMode ? new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buQuilting.lng") : new FileInfo(AppPath.Language + "\\buQuilting.lng");
      if (fileInfo.Exists)
      {
        List<string> StringList = new List<string>();
        buFile.OpenFromFile(fileInfo.FullName, ref StringList);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingStatus);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingMessage);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingCaptions);
        buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingCommand);
        StringList.Clear();
      }
      else
      {
        buLog.addLog("Quilting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Quilting Language File Missing");
      }
      if (stringList.Count > 0)
        ;
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[16 /*0x10*/];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void SaveQuiltingFile()
  {
    try
    {
      string FileName1 = AppPath.Settings + "\\Quilting\\Quilting.prm";
      ArrayList StringList1 = new ArrayList();
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "   Quilting Settings");
      StringList1.Add((object) "------------------------------------------------------------------------");
      StringList1.Add((object) "<QuiltingSettings>");
      StringList1.AddRange((ICollection) clsQuilting.varQuiltingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</QuiltingSettings>");
      StringList1.Add((object) "<QuiltingRuntimeSettings>");
      StringList1.AddRange((ICollection) clsQuilting.varQuiltingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
      StringList1.Add((object) "</QuiltingRuntimeSettings>");
      buFile.SaveToFile(StringList1, FileName1);
      buLog.addLog("Quilting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
      buMWQuiltingVars.varCamQuilting.mwPar.Serialize(AppPath.Settings + "\\Quilting\\mwQuilting.bin");
      string FileName2 = AppPath.Settings + "\\Quilting\\QuiltingCam.bucamset";
      ArrayList StringList2 = new ArrayList();
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "   MW Cam Settings");
      StringList2.Add((object) "------------------------------------------------------------------------");
      StringList2.Add((object) "<MwCamSettings>");
      StringList2.AddRange((ICollection) buMWQuiltingVars.varCamQuilting.buPar.ToDefAll("_varCamQuilting", 2, SerilizationMode5.MultiLine));
      StringList2.Add((object) "</MwCamSettings>");
      buFile.SaveToFile(StringList2, FileName2);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[17];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void OpenQuiltingFile()
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      FileInfo fileInfo1 = new FileInfo(AppPath.Settings + "\\Quilting\\Quilting.prm");
      if (fileInfo1.Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(fileInfo1.FullName, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<QuiltingSettings>", "</QuiltingSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsQuilting.varQuiltingSettings);
            buLog.addLog("Quilting Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
          CalcList = new ArrayList();
          buString.ListToSpecificList("<QuiltingRuntimeSettings>", "</QuiltingRuntimeSettings>", true, StringList, ref CalcList);
          if (CalcList.Count > 0)
          {
            buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, (object) clsQuilting.varQuiltingRunSettings);
            buLog.addLog("TuftingRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
          }
        }
        catch (Exception ex)
        {
          buLog.addLog("Quilting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Tufting Settings Decoder Error");
        }
      }
      else if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
      {
        buLog.addLog("Quilting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Quilting Settings File Missing");
      }
      buLog.addLog("Quilting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
      FileInfo fileInfo2 = new FileInfo(AppPath.Settings + "\\Quilting\\mwQuilting.bin");
      if (fileInfo2.Exists)
      {
        buMWQuiltingVars.varCamQuilting.mwPar.Deserialize(fileInfo2.FullName);
      }
      else
      {
        buLog.addLog("Quilting mwCam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Quilting mwCam  Settings File Missing");
        buMWQuiltingVars.varCamQuilting = new MWParameters(Unit.Metric, 0);
      }
      string str = AppPath.Settings + "\\Quilting\\QuiltingCam.bucamset";
      if (new FileInfo(str).Exists)
      {
        ArrayList StringList = new ArrayList();
        buFile.OpenFromFile(str, ref StringList);
        try
        {
          ArrayList CalcList = new ArrayList();
          buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", true, StringList, ref CalcList);
          if (CalcList.Count <= 0)
            return;
          buSerilization.Decode(StringList, "_varCamQuilting", SerilizationMode.MultiLine, (object) buMWQuiltingVars.varCamQuilting.buPar);
        }
        catch (Exception ex)
        {
          buLog.addLog("MW Quilting Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
          buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "Quilting Settings Decoder Error");
        }
      }
      else
      {
        buLog.addLog("Quilting Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
        buString.MessageBoxError("Quilting Cam Settings File Missing");
      }
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[18];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void LoadFile(string FileName)
  {
    try
    {
      Design viewportcad = (Design) ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
      clsInit.appFiles.OpenGCodeFile(FileName, false, ref viewportcad);
    }
    catch (Exception ex)
    {
    }
  }

  public void doSelectionToCode(ref string Codes)
  {
    try
    {
      if (ccVars.SortedEntities.Count <= 0)
        return;
      List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
      List<List<Entity>> copiedEnt1 = new List<List<Entity>>();
      clsInit.cVector5.EntitiesSplitByUpperLine(ccVars.SortedEntities, ref SplitedEntitites);
      for (int index1 = 0; index1 <= SplitedEntitites.Count - 1; ++index1)
      {
        if (clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]))
        {
          bool flag1 = false;
          List<Entity> BaseRefEntities = new List<Entity>();
          Point3D point3D = (Point3D) null;
          for (int index2 = 0; index2 <= SplitedEntitites[index1].Count - 1; ++index2)
          {
            CustomData entityData = SplitedEntitites[index1][index2].EntityData as CustomData;
            if (!flag1 & SplitedEntitites[index1][index2] is Line & clsQuilting.varQuiltingSettings.StartFromMiddle)
            {
              bool flag2 = false;
              if (clsQuilting.varQuiltingSettings.MiddleDirection == quiltingDirectionType.FirstHorizontal)
              {
                double num = clsInit.cVector5.PointAngle(((Line) SplitedEntitites[index1][index2]).EndPoint, ((Line) SplitedEntitites[index1][index2]).StartPoint, Plane.XY);
                if (buCompare5.EQ(num, 0.0, clsQuilting.varQuiltingSettings.MiddleDirectionCompareAngle) | buCompare5.EQ(num, 180.0, clsQuilting.varQuiltingSettings.MiddleDirectionCompareAngle))
                  flag2 = true;
              }
              if (clsQuilting.varQuiltingSettings.MiddleDirection == quiltingDirectionType.FirstVertical)
              {
                double num = clsInit.cVector5.PointAngle(((Line) SplitedEntitites[index1][index2]).EndPoint, ((Line) SplitedEntitites[index1][index2]).StartPoint, Plane.XY);
                if (buCompare5.EQ(num, 90.0, clsQuilting.varQuiltingSettings.MiddleDirectionCompareAngle) | buCompare5.EQ(num, 270.0, clsQuilting.varQuiltingSettings.MiddleDirectionCompareAngle))
                  flag2 = true;
              }
              if (flag2)
              {
                point3D = Point3D.MidPoint(((ICurve) SplitedEntitites[index1][index2]).StartPoint, ((ICurve) SplitedEntitites[index1][index2]).EndPoint);
                ICurve lower = (ICurve) null;
                ICurve upper = (ICurve) null;
                ((ICurve) SplitedEntitites[index1][index2]).SplitBy(point3D, out lower, out upper);
                if (lower != null & upper != null)
                {
                  Entity entity1 = (Entity) lower;
                  entity1.EntityData = (object) new CustomData();
                  ((CustomData) entity1.EntityData).Tags = entityData.Tags;
                  ((CustomData) entity1.EntityData).CamFeedrate = entityData.CamFeedrate;
                  ((CustomData) entity1.EntityData).sortDirection = entityData.sortDirection;
                  Entity entity2 = (Entity) upper;
                  entity2.EntityData = (object) new CustomData();
                  ((CustomData) entity2.EntityData).Tags = entityData.Tags;
                  ((CustomData) entity2.EntityData).CamFeedrate = entityData.CamFeedrate;
                  ((CustomData) entity2.EntityData).sortDirection = entityData.sortDirection;
                  BaseRefEntities.Add(entity1);
                  BaseRefEntities.Add(entity2);
                  flag1 = true;
                }
                else
                  point3D = (Point3D) null;
              }
              else
              {
                Entity copiedEnt2 = (Entity) null;
                buVector5.CopyEntities(SplitedEntitites[index1][index2], ref copiedEnt2);
                ((CustomData) copiedEnt2.EntityData).CamSelected = false;
                BaseRefEntities.Add(copiedEnt2);
              }
            }
            else
            {
              Entity copiedEnt3 = (Entity) null;
              buVector5.CopyEntities(SplitedEntitites[index1][index2], ref copiedEnt3);
              ((CustomData) copiedEnt3.EntityData).CamSelected = false;
              BaseRefEntities.Add(copiedEnt3);
            }
          }
          if (flag1)
          {
            SortSettings Settings = new SortSettings();
            SortResult Result = new SortResult();
            List<Entity> SortedEntities = new List<Entity>();
            clsInit.cVector5.SortEntitiesByRefPoint(point3D, ref BaseRefEntities, Settings, ref SortedEntities, ref Result);
            if (SortedEntities.Count > 0)
            {
              clsInit.cVector5.isEntitiesClosed(SplitedEntitites[index1]);
              SplitedEntitites[index1] = SortedEntities;
            }
          }
        }
        if (clsQuilting.varQuiltingSettings.DevideLength > 0.0)
        {
          if (!clsQuilting.varQuiltingSettings.DevideOnlyLines)
          {
            List<Point3D> points = new List<Point3D>();
            for (int index3 = 0; index3 <= SplitedEntitites[index1].Count - 1; ++index3)
            {
              List<Point3D> pntDevided = new List<Point3D>();
              clsInit.cVector5.EntityDevideByCamDir(SplitedEntitites[index1][index3], clsQuilting.varQuiltingSettings.DevideLength, ref pntDevided);
              if (points.Count == 0)
              {
                if (pntDevided.Count > 0)
                  points.AddRange((IEnumerable<Point3D>) pntDevided);
              }
              else if (pntDevided.Count > 0)
              {
                if (buCompare5.EQ(pntDevided[0], points[points.Count - 1], 0.1))
                  pntDevided.RemoveAt(0);
                if (pntDevided.Count > 0)
                  points.AddRange((IEnumerable<Point3D>) pntDevided);
              }
            }
            if (points.Count >= 2)
            {
              CustomData customData = new CustomData();
              customData.sortDirection = entitySortDirection.Normal;
              customData.CamFeedrate = ((CustomData) SplitedEntitites[index1][0].EntityData).CamFeedrate;
              customData.Tags = ((CustomData) SplitedEntitites[index1][0].EntityData).Tags;
              SplitedEntitites[index1] = new List<Entity>();
              List<Entity> entityList = new List<Entity>();
              LinearPath linearPath = new LinearPath((ICollection<Point3D>) points);
              linearPath.EntityData = (object) customData;
              entityList.Add((Entity) linearPath);
              SplitedEntitites[index1] = entityList;
            }
          }
          else
          {
            List<Entity> entityList = new List<Entity>();
            for (int index4 = 0; index4 <= SplitedEntitites[index1].Count - 1; ++index4)
            {
              if (SplitedEntitites[index1][index4] is Line | SplitedEntitites[index1][index4] is LinearPath)
              {
                List<Point3D> pntDevided = new List<Point3D>();
                clsInit.cVector5.EntityDevideByCamDir(SplitedEntitites[index1][index4], clsQuilting.varQuiltingSettings.DevideLength, ref pntDevided);
                if (pntDevided.Count > 0)
                {
                  LinearPath linearPath = new LinearPath((ICollection<Point3D>) pntDevided);
                  linearPath.EntityData = (object) new CustomData()
                  {
                    sortDirection = entitySortDirection.Normal,
                    CamFeedrate = ((CustomData) SplitedEntitites[index1][index4].EntityData).CamFeedrate,
                    Tags = ((CustomData) SplitedEntitites[index1][index4].EntityData).Tags
                  };
                  entityList.Add((Entity) linearPath);
                }
              }
              else
              {
                Entity entity = buVector5.CopyEntities(SplitedEntitites[index1][index4]);
                if (entity != null)
                  entityList.Add(entity);
              }
            }
            if (entityList.Count > 0)
              SplitedEntitites[index1] = entityList;
          }
        }
      }
      if (clsQuilting.varQuiltingSettings.SharpCornerEnable)
      {
        for (int index5 = 0; index5 <= SplitedEntitites.Count - 1; ++index5)
        {
          List<Entity> entityList1 = new List<Entity>();
          entityList1.Add(buVector5.CopyEntities(SplitedEntitites[index5][0]));
          for (int index6 = 1; index6 <= SplitedEntitites[index5].Count - 2; ++index6)
          {
            double Angle = 0.0;
            if (index6 == 19)
              ;
            clsInit.cVector5.AngleOfTwoEntities(SplitedEntitites[index5][index6 - 1], SplitedEntitites[index5][index6], ref Angle, Plane.XY);
            if (180.0 - Angle > clsQuilting.varQuiltingSettings.CornerAngle)
            {
              copiedEnt1.Add(entityList1);
              entityList1 = new List<Entity>();
              entityList1.Add(buVector5.CopyEntities(SplitedEntitites[index5][index6]));
              if (index6 == SplitedEntitites[index5].Count - 2)
              {
                copiedEnt1.Add(entityList1);
                entityList1 = new List<Entity>();
              }
            }
            else
              entityList1.Add(buVector5.CopyEntities(SplitedEntitites[index5][index6]));
          }
          List<Entity> entityList2;
          if (entityList1.Count == 0)
          {
            entityList1.Add(buVector5.CopyEntities(SplitedEntitites[index5][SplitedEntitites[index5].Count - 1]));
            copiedEnt1.Add(entityList1);
            entityList2 = new List<Entity>();
          }
          else
          {
            entityList1.Add(buVector5.CopyEntities(SplitedEntitites[index5][SplitedEntitites[index5].Count - 1]));
            copiedEnt1.Add(entityList1);
            entityList2 = new List<Entity>();
          }
        }
      }
      else
        buVector5.CopyEntities(SplitedEntitites, ref copiedEnt1);
      clsInit.appCommand.undoBuffer();
      buMWQuiltingVars.varCamQuilting.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
      buMWQuiltingVars.varCamQuilting.buPar.Offsets.OpenContour = CamOpenContourType.Center;
      buMWQuiltingVars.varCamQuilting.buPar.Offsets.OverlapDistance = clsQuilting.varQuiltingSettings.ClosedPatternEndExtentLength;
      buMWQuiltingVars.varCamQuilting.buPar.Options.ExtendPatternOutput = clsQuilting.varQuiltingSettings.OpenPatternEndExtentLength;
      buMWQuiltingVars.varCamQuilting.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
      buMWCalcs.CopyCamParameter(buMWQuiltingVars.varCamQuilting, ref buMWCalcs.varCamWFContourPars);
      ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
      ccVars.toolActive.Geometry.Diameter = 1.0;
      MWCalculationOptions calculationOptions = new MWCalculationOptions()
      {
        SortingSettings = {
          Option = {
            Resolution = clsVar.varSelection.SelectionResolution
          }
        },
        NumberofAxis = 3,
        CamWireframeType = CamWireFrameType.Contour,
        Mode = CamMode.WireFrame,
        DontApplyReset = true,
        isBuWireframeCalculation = false,
        AddToCamListInMWCalculation = false,
        DontShowDialogBox = true,
        isBuSort = true
      };
      calculationOptions.isBuWireframeCalculation = true;
      calculationOptions.UseStartPoint = false;
      calculationOptions.UseConstantStartPoint = true;
      calculationOptions.StartPointX = 0.0;
      calculationOptions.StartPointY = 0.0;
      calculationOptions.HeightFromEntities = false;
      camTp CamCalculated = new camTp();
      clsInit.cCam5.camQuilting(copiedEnt1, false, clsQuilting.varQuiltingSettings.HeadDistance, new ToolBase5(), buMWQuiltingVars.varCamQuilting.buPar, ref CamCalculated);
      clsInit.appCommand.CamAdd(CamCalculated);
      clsInit.appCommand.Reset();
      int num1 = 0;
      for (int index7 = 0; index7 <= CamCalculated.CamPoints.Count - 1; ++index7)
      {
        for (int index8 = 0; index8 <= CamCalculated.CamPoints[index7].Points.Count - 1; ++index8)
        {
          if (CamCalculated.CamPoints[index7].Points[index8].Type == 0)
          {
            if (clsQuilting.varQuiltingSettings.RoundCorner > 0.0)
              CamCalculated.CamPoints[index7].Points[index8].AfterCodes.Add((object) ("G51 D" + clsQuilting.varQuiltingSettings.RoundCorner.ToString("f1")));
            if (num1 == 0)
              ;
            ++num1;
          }
        }
      }
      Codes = "";
      clsInit.cGcodeCreate.CreatGCode(CamCalculated, ccVars.PostActive, ref Codes);
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[1];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doAskMeReturn()
  {
    try
    {
      buVector5.AskMe.Return = true;
      clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref clsInit.appQuilting.refSortEntities, clsQuilting.varQuiltingRunSettings.QuiltSortSettings, ref ccVars.SortedEntities, ref this.QuiltSortResult);
      if (this.QuiltSortResult.ResultType == SortingResultType.Done || this.QuiltSortResult.ResultType == SortingResultType.MultipleEntities || this.QuiltSortResult.ResultType != SortingResultType.SelectNextGroup)
        return;
      buVector5.AskMe.LastMarkPosition.Add(buVector5.ToPoint3D(buVector5.AskMe.CatchPoint));
      ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
    }
    catch (Exception ex)
    {
      string str = this.cmdExceptionID[2];
      buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, "");
    }
  }

  public void doSetProperties()
  {
    F_QuiltingSetProperties quiltingSetProperties = new F_QuiltingSetProperties();
    quiltingSetProperties.Setting = new QuiltingRuntimeSettings(clsQuilting.varQuiltingRunSettings);
    quiltingSetProperties.Init();
    quiltingSetProperties.StartPosition = FormStartPosition.CenterParent;
    int num = (int) quiltingSetProperties.ShowDialog();
    if (quiltingSetProperties.PropertiesForm.Result != DialogResult.OK)
      return;
    clsQuilting.varQuiltingRunSettings = new QuiltingRuntimeSettings(quiltingSetProperties.Setting);
    clsFiles.SaveParameter();
    for (int index1 = 0; index1 <= ccVars.SelectionOP.Selections.Count - 1; ++index1)
    {
      int index2 = ccVars.SelectionOP.Selections[index1].Index;
      ((CustomData) ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index2].EntityData).Tags = Convert.ToInt32((object) clsQuilting.varQuiltingRunSettings.Heads).ToString();
    }
    clsInit.appCommand.Reset();
  }
}
