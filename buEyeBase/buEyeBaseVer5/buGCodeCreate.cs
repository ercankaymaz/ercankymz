// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.buGCodeCreate
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buClass.Apps;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

public class buGCodeCreate
{
  public string Option1;
  public string Option2;
  public string Option3;
  public string Option4;
  public static byte f000957;
  public SortingIntersectionRulesType IntersectionRules;
  public SortingNextGroupFindRulesType NextFroupRules;
  public double SortResolution;
  public ClockDirectionType ClockDirection;
  public ClockDirectionType InsideClockDirection;
  public double DiameterMin;
  public double DiameterMax;
  public double DevideLength;

  public static void SaveUndoFile(string FileName, Undo Undo)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "<UndoItem>");
      for (int index = 0; index <= Undo.Entities.Count - 1; ++index)
      {
        buSerilization.ExceptionalVariables.Clear();
        if (Undo.Entities[index].GetType() != typeof (ePolyline))
          buSerilization.ExceptionalVariables.Add("Vertice");
        ArrayList arrayList = new ArrayList();
        arrayList.AddRange((ICollection) Undo.Entities[index].ToDefAll(2).ToArray());
        StringList.AddRange((ICollection) arrayList.ToArray());
      }
      for (int index = 0; index <= Undo.Cams.Count - 1; ++index)
      {
        buSerilization.ExceptionalVariables.Clear();
        ArrayList arrayList = new ArrayList();
        arrayList.AddRange((ICollection) Undo.Cams[index].ToDefAll(2).ToArray());
        StringList.AddRange((ICollection) arrayList.ToArray());
      }
      if (Undo.DiemakerProp != null)
      {
        StringList.Add((object) "  <DiemakerUndo>");
        StringList.Add((object) "    <DiemakerCuttingUndo>");
        for (int index = 0; index <= Undo.DiemakerProp.Cutting.Count - 1; ++index)
          Undo.DiemakerProp.Cutting[index].ToDefAll("", 6, SerilizationMode.MultiLine);
        StringList.Add((object) "    <DiemakerCuttingUndo>");
        StringList.Add((object) "    <DiemakerCreasingUndo>");
        for (int index = 0; index <= Undo.DiemakerProp.Creasing.Count - 1; ++index)
          Undo.DiemakerProp.Creasing[index].ToDefAll("", 6, SerilizationMode.MultiLine);
        StringList.Add((object) "    <DiemakerCreasingUndo>");
        StringList.Add((object) "    <DiemakerPerfoUndo>");
        for (int index = 0; index <= Undo.DiemakerProp.Perfo.Count - 1; ++index)
          Undo.DiemakerProp.Perfo[index].ToDefAll("", 6, SerilizationMode.MultiLine);
        StringList.Add((object) "    <DiemakerPerfoUndo>");
        StringList.Add((object) "    <DiemakerCutCreaseUndo>");
        for (int index = 0; index <= Undo.DiemakerProp.CutCrease.Count - 1; ++index)
          Undo.DiemakerProp.CutCrease[index].ToDefAll("", 6, SerilizationMode.MultiLine);
        StringList.Add((object) "    <DiemakerCutCreaseUndo>");
        StringList.Add((object) "  </DiemakerUndo>");
      }
      StringList.Add((object) "</UndoItem>");
      buVector5.SaveToFile(StringList, FileName, true);
    }
    catch (Exception ex)
    {
      string str = $"FileName: {FileName.ToString()} - Undo: {Undo.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref List<eEntities> Entities)
  {
    List<camBase> CamList = new List<camBase>();
    List<LayerBase> Layers = new List<LayerBase>();
    List<string> Tags = new List<string>();
    buGCodeCreate.OpenBuCadCam(FileName, Options, ref Entities, ref CamList, ref Layers, ref Tags);
  }

  public static void OpenBuCadCam(ArrayList EntitiesLines, ref List<eEntities> Entities)
  {
    List<List<string>> CalcList = new List<List<string>>();
    Entities.Clear();
    buImage5.ListToSpecificList("<eEntities>", "</eEntities>", false, EntitiesLines, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      eEntities eEntities1 = new eEntities();
      eEntities eEntities2 = eEntities.Decode(CalcList[index], "", SerilizationMode.MultiLine);
      Entities.Add(eEntities2);
    }
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref List<eEntities> Entities,
    ref List<camBase> CamList,
    ref List<LayerBase> Layers,
    ref List<string> Tags)
  {
    buCadCamFileInfo FileInfo = new buCadCamFileInfo();
    buGCodeCreate.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags);
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref buCadCamFileInfo FileInfo,
    ref List<eEntities> Entities,
    ref List<LayerBase> Layers)
  {
    try
    {
      object AppOption = (object) null;
      List<camBase> CamList = new List<camBase>();
      List<string> Tags = new List<string>();
      List<ProfileJob> Profiles = new List<ProfileJob>();
      buGCodeCreate.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref buCadCamFileInfo FileInfo,
    ref List<eEntities> Entities,
    ref List<camBase> CamList,
    ref List<LayerBase> Layers,
    ref List<string> Tags)
  {
    try
    {
      object AppOption = (object) null;
      List<ProfileJob> Profiles = new List<ProfileJob>();
      buGCodeCreate.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref buCadCamFileInfo FileInfo,
    ref List<eEntities> Entities,
    ref List<camBase> CamList,
    ref List<LayerBase> Layers,
    ref List<string> Tags,
    ref object AppOption)
  {
    try
    {
      List<ProfileJob> Profiles = new List<ProfileJob>();
      buGCodeCreate.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenBuCadCam(
    string FileName,
    buCadFileOpenOptions Options,
    ref buCadCamFileInfo FileInfo,
    ref List<eEntities> Entities,
    ref List<camBase> CamList,
    ref List<LayerBase> Layers,
    ref List<string> Tags,
    ref object AppOption,
    ref List<ProfileJob> Profiles)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      buVector5.OpenFromFile(FileName, ref StringList);
      buGCodeCreate.OpenBuCadCam(StringList, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenBuCadCam(
    ArrayList Lines,
    buCadFileOpenOptions Options,
    ref buCadCamFileInfo FileInfo,
    ref List<eEntities> Entities,
    ref List<camBase> CamList,
    ref List<LayerBase> Layers,
    ref List<string> Tags,
    ref object AppOption,
    ref List<ProfileJob> Profiles)
  {
    try
    {
      List<List<string>> CalcList1 = new List<List<string>>();
      Entities.Clear();
      Profiles.Clear();
      buImage5.ListToSpecificList("<eEntities>", "</eEntities>", true, Lines, ref CalcList1);
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.Decode(CalcList1[index], "", SerilizationMode.MultiLine);
        eEntities2.EntityIndex = Entities.Count;
        Entities.Add(eEntities2);
      }
      List<List<string>> CalcList2 = new List<List<string>>();
      buImage5.ListToSpecificList("<LayerBase>", "</LayerBase>", false, Lines, ref CalcList2);
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        ArrayList AL = new ArrayList();
        AL.AddRange((ICollection) CalcList2[index].ToArray());
        AL.Insert(0, (object) "<LayerBase>");
        AL.Add((object) "</LayerBase>");
        LayerBase data = new LayerBase();
        buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) data);
        LayerBase layerBase = new LayerBase(data);
        Layers.Add(layerBase);
      }
      List<List<string>> CalcList3 = new List<List<string>>();
      buImage5.ListToSpecificList("<ProfileJob>", "</ProfileJob>", true, Lines, ref CalcList3);
      for (int index = 0; index <= CalcList3.Count - 1; ++index)
      {
        ProfileJob Job = new ProfileJob();
        ProfileJob.Decode(CalcList3[index], ref Job);
        Profiles.Add(Job);
      }
      if (AppOption != null)
      {
        if (AppOption.GetType() == typeof (DiemakerPageProp))
        {
          DiemakerPageProp Diemaker = new DiemakerPageProp();
          DiemakerPageProp.Decode(Lines, ref Diemaker);
          AppOption = (object) Diemaker;
        }
        if (AppOption.GetType() == typeof (jewelInterface))
        {
          jewelInterface jewelInterface = new jewelInterface();
          buSerilization.Decode(Lines, "", SerilizationMode.MultiLine, (object) jewelInterface);
          AppOption = (object) jewelInterface;
        }
      }
      List<List<string>> CalcList4 = new List<List<string>>();
      buImage5.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", true, Lines, ref CalcList4);
      if (CalcList4.Count > 0)
      {
        buCadCamFileInfo buCadCamFileInfo = new buCadCamFileInfo();
        buSerilization.Decode(CalcList4[0], "", SerilizationMode.MultiLine, (object) buCadCamFileInfo);
        string notes = buCadCamFileInfo.Notes;
        buCadCamFileInfo.Notes = notes.Replace("{[NewLine]}", "\r\n");
        FileInfo = buCadCamFileInfo;
      }
      CalcList4.Clear();
      Lines.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "Lines : " + Lines.Count.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void SaveBuCadCam(
    string FileName,
    buCadFileSaveOptions Options,
    List<eEntities> Entities,
    List<camBase> CamList,
    List<LayerBase> Layers,
    List<string> Tags)
  {
    buGCodeCreate.SaveBuCadCam(FileName, Options, new buCadCamFileInfo(), Entities, CamList, Layers, Tags, (object) null, (object) null, (List<ProfileJob>) null);
  }

  public static void SaveBuCadCam(
    string FileName,
    buCadFileSaveOptions Options,
    buCadCamFileInfo FileInfo,
    List<eEntities> Entities,
    List<camBase> CamList,
    List<LayerBase> Layers,
    List<string> Tags)
  {
    try
    {
      buGCodeCreate.SaveBuCadCam(FileName, Options, FileInfo, Entities, CamList, Layers, Tags, (object) null, (object) null, (List<ProfileJob>) null);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void SaveBuCadCam(
    string FileName,
    buCadFileSaveOptions Options,
    buCadCamFileInfo FileInfo,
    List<eEntities> Entities,
    List<camBase> CamList,
    List<LayerBase> Layers,
    List<string> Tags,
    object AppOption,
    object AuxOption,
    List<ProfileJob> ProfileJobs)
  {
    try
    {
      ArrayList arrayList1 = new ArrayList();
      string notes = FileInfo.Notes;
      FileInfo.Notes = notes.Replace("\r\n", "{[NewLine]}");
      arrayList1.AddRange((ICollection) FileInfo.ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
      for (int index = 0; index <= Layers.Count - 1; ++index)
        arrayList1.AddRange((ICollection) Layers[index].ToDefAll("", 2, SerilizationMode.MultiLine).ToArray());
      for (int index = 0; index <= Entities.Count - 1; ++index)
      {
        buSerilization.ExceptionalVariables.Clear();
        if (Entities[index].GetType() != typeof (ePolyline))
          buSerilization.ExceptionalVariables.Add("Vertice");
        ArrayList arrayList2 = new ArrayList();
        arrayList2.AddRange((ICollection) Entities[index].ToDefAll(2).ToArray());
        arrayList1.AddRange((ICollection) arrayList2.ToArray());
      }
      if (Options.SaveCamList)
      {
        for (int index = 0; index <= CamList.Count - 1; ++index)
        {
          buSerilization.ExceptionalVariables.Clear();
          ArrayList arrayList3 = new ArrayList();
          arrayList3.AddRange((ICollection) CamList[index].ToDefAll(2).ToArray());
          arrayList1.AddRange((ICollection) arrayList3.ToArray());
        }
      }
      if (AppOption != null)
      {
        if (AppOption.GetType() == typeof (DiemakerPageProp))
          arrayList1.AddRange((ICollection) ((DiemakerPageProp) AppOption).ToDef(2));
        if (AppOption.GetType() == typeof (jewelInterface))
          arrayList1.AddRange((ICollection) ((buSerilization) AppOption).ToDefAll("", 2, SerilizationMode.MultiLine));
      }
      if (Options.SaveProfileList && ProfileJobs != null && ProfileJobs.Count > 0)
        arrayList1.AddRange((ICollection) ProfileJob.ToDef(ProfileJobs, 2));
      TextWriter text = (TextWriter) File.CreateText(FileName);
      for (int index = 0; index <= arrayList1.Count - 1; ++index)
        text.WriteLine(arrayList1[index].ToString());
      text.Close();
      arrayList1.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenKinemticFile(string FileName, ref KinematicBase5 Kinematic)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      Kinematic = (KinematicBase5) new OsnapPoint();
      List<List<string>> stringListList = new List<List<string>>();
      buVector5.OpenFromFile(FileName, ref StringList);
      buSerilization5.Decode(StringList, "", (SerilizationMode5) 1, (object) Kinematic);
      ((MeshToSurfacePointsSettings) Kinematic).FileName = FileName;
      GC.Collect();
      buLog.addLog("Kinematic File Opened - ", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void SaveKinematicFile(string FileName, KinematicBase5 Kinematic)
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) Kinematic.ToDefAll("", 2, (SerilizationMode5) 1));
      TextWriter text = (TextWriter) File.CreateText(FileName);
      for (int index = 0; index <= arrayList.Count - 1; ++index)
        text.WriteLine(arrayList[index].ToString());
      text.Close();
      arrayList.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenPostProcessorFile(string FileName, ref PostProcessor Post)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      Post = new PostProcessor();
      List<List<string>> stringListList = new List<List<string>>();
      buVector5.OpenFromFile(FileName, ref StringList);
      Post.RepetitionDef.AxesRepetation = new AxesEnableWithUVW(false, false, false, false, false, false, false, false, false);
      buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) Post);
      ArrayList arrayList1 = new ArrayList();
      for (int index = 0; index <= Post.CamPageVelocity.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageVelocity[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList1.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList1.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList1.Count > 0)
      {
        Post.CamPageVelocity.Clear();
        Post.CamPageVelocity.AddRange((ICollection) arrayList1.ToArray());
      }
      ArrayList arrayList2 = new ArrayList();
      for (int index = 0; index <= Post.CamPageDistance.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageDistance[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList2.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList2.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList2.Count > 0)
      {
        Post.CamPageDistance.Clear();
        Post.CamPageDistance.AddRange((ICollection) arrayList2.ToArray());
      }
      ArrayList arrayList3 = new ArrayList();
      for (int index = 0; index <= Post.CamPageStep.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageStep[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList3.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList3.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList3.Count > 0)
      {
        Post.CamPageStep.Clear();
        Post.CamPageStep.AddRange((ICollection) arrayList3.ToArray());
      }
      ArrayList arrayList4 = new ArrayList();
      for (int index = 0; index <= Post.CamPageOperation.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageOperation[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList4.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList4.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList4.Count > 0)
      {
        Post.CamPageOperation.Clear();
        Post.CamPageOperation.AddRange((ICollection) arrayList4.ToArray());
      }
      ArrayList arrayList5 = new ArrayList();
      for (int index = 0; index <= Post.CamPageOffset.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageOffset[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList5.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList5.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList5.Count > 0)
      {
        Post.CamPageOffset.Clear();
        Post.CamPageOffset.AddRange((ICollection) arrayList5.ToArray());
      }
      ArrayList arrayList6 = new ArrayList();
      for (int index = 0; index <= Post.CamPageLeadIn.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageLeadIn[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList6.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList6.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList6.Count > 0)
      {
        Post.CamPageLeadIn.Clear();
        Post.CamPageLeadIn.AddRange((ICollection) arrayList6.ToArray());
      }
      ArrayList arrayList7 = new ArrayList();
      for (int index = 0; index <= Post.CamPageLeadOut.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageLeadOut[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList7.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList7.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList7.Count > 0)
      {
        Post.CamPageLeadOut.Clear();
        Post.CamPageLeadOut.AddRange((ICollection) arrayList7.ToArray());
      }
      ArrayList arrayList8 = new ArrayList();
      for (int index = 0; index <= Post.CamPageTools.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageTools[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList8.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList8.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList8.Count > 0)
      {
        Post.CamPageTools.Clear();
        Post.CamPageTools.AddRange((ICollection) arrayList8.ToArray());
      }
      ArrayList arrayList9 = new ArrayList();
      for (int index = 0; index <= Post.CamPageMisc.Count - 1; ++index)
      {
        string[] strArray = Post.CamPageMisc[index].ToString().Split(',');
        if (strArray != null)
        {
          if (strArray.Length >= 2)
          {
            if (strArray[1].Trim() == "1" | strArray[1].Trim().ToLower() == "true" | strArray[1].Trim().ToLower() == "visible")
              arrayList9.Add((object) strArray[0].Trim());
          }
          else if (strArray.Length == 1)
            arrayList9.Add((object) strArray[0].Trim());
        }
      }
      if (arrayList9.Count > 0)
      {
        Post.CamPageMisc.Clear();
        Post.CamPageMisc.AddRange((ICollection) arrayList9.ToArray());
      }
      Post.FileName = FileName;
      buLog.addLog("Post File Opened", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void SavePostProcessorFile(string FileName, PostProcessor Post)
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) Post.ToDefAll("", 2, SerilizationMode.MultiLine));
      arrayList[arrayList.Count - 1].ToString();
      TextWriter text = (TextWriter) File.CreateText(FileName);
      for (int index = 0; index <= arrayList.Count - 1; ++index)
        text.WriteLine(arrayList[index].ToString());
      text.Close();
      arrayList.Clear();
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void SavePlaneFile(string FileName, List<Plane> Planes)
  {
    try
    {
      if (Planes.Count <= 0)
        return;
      ArrayList StringList = new ArrayList();
      for (int index = 0; index <= Planes.Count - 1; ++index)
      {
        string str = "Plane: " + buSerilization5.ToDef(Planes[index]);
        StringList.Add((object) str);
      }
      buVector5.SaveToFile(StringList, FileName);
      buLogVer5.addToLog(nameof (SavePlaneFile), nameof (SavePlaneFile), "SavePlaneFile Saved", "Ok", -1.0, 0.0);
    }
    catch (Exception ex)
    {
      string auxMessage = "FileName : " + FileName;
      buLogVer5.addToLog(nameof (SavePlaneFile), nameof (SavePlaneFile), "SavePlaneFile Saved", "Error", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public static void SavePlaneFile(string FileName, List<SelectedPlaneInfo> Planes)
  {
    try
    {
      if (Planes.Count <= 0)
        return;
      ArrayList StringList = new ArrayList();
      for (int index = 0; index <= Planes.Count - 1; ++index)
      {
        StringList.Add((object) "<SelectedPlaneInfo>");
        StringList.Add((object) ("  Plane: " + buSerilization5.ToDef(((WriteDxfDwgPropeties) Planes[index]).refPlane)));
        StringList.Add((object) ("  Explanation: " + ((ColorDrawType) Planes[index]).Explanation));
        StringList.Add((object) ("  Length: " + ((ColorDrawType) Planes[index]).Length.ToString()));
        StringList.Add((object) ("  Height: " + ((ColorDrawType) Planes[index]).Height.ToString()));
        StringList.Add((object) "</SelectedPlaneInfo>");
      }
      buVector5.SaveToFile(StringList, FileName);
      buLogVer5.addToLog(nameof (SavePlaneFile), nameof (SavePlaneFile), "SavePlaneFile Saved", "Ok", -1.0, 0.0);
    }
    catch (Exception ex)
    {
      string auxMessage = "FileName : " + FileName;
      buLogVer5.addToLog(nameof (SavePlaneFile), nameof (SavePlaneFile), "SavePlaneFile Saved", "Error", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public static void OpenPlaneFile(string FileName, ref List<Plane> Planes)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      Planes = new List<Plane>();
      buVector5.OpenFromFile(FileName, ref StringList);
      for (int index = 0; index <= StringList.Count - 1; ++index)
        Planes.Add(buSerilization5.DecoderFromPlane(StringList[index].ToString()));
      buLogVer5.addToLog(nameof (OpenPlaneFile), nameof (OpenPlaneFile), "OpenPlaneFile Opened", "Ok", -1.0, 0.0);
      GC.Collect();
    }
    catch (Exception ex)
    {
      string auxMessage = "FileName : " + FileName;
      buLogVer5.addToLog(nameof (OpenPlaneFile), nameof (OpenPlaneFile), "OpenPlaneFile Opened", "Error", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public static void OpenPlaneFile(string FileName, ref List<SelectedPlaneInfo> Planes)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      List<List<string>> CalcList = new List<List<string>>();
      buVector5.OpenFromFile(FileName, ref StringList);
      buImage5.ListToSpecificList("<SelectedPlaneInfo>", "</SelectedPlaneInfo>", false, StringList, ref CalcList);
      Planes = new List<SelectedPlaneInfo>();
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        SelectedPlaneInfo selectedPlaneInfo = (SelectedPlaneInfo) null;
        if (CalcList[index].Count >= 1)
        {
          selectedPlaneInfo = (SelectedPlaneInfo) new hmiUISettings();
          ((WriteDxfDwgPropeties) selectedPlaneInfo).refPlane = buSerilization5.DecoderFromPlane(CalcList[index][0]);
        }
        if (CalcList[index].Count >= 2)
        {
          string[] strArray = CalcList[index][1].Split(':');
          if (strArray != null & strArray.Length >= 2)
            ((ColorDrawType) selectedPlaneInfo).Explanation = strArray[1].Trim();
        }
        if (CalcList[index].Count >= 3)
        {
          string[] strArray = CalcList[index][2].Split(':');
          if (strArray != null & strArray.Length >= 2 && buFile5.IsNumeric(strArray[1]))
            ((ColorDrawType) selectedPlaneInfo).Length = Convert.ToDouble(strArray[1].Trim());
        }
        if (CalcList[index].Count >= 3)
        {
          string[] strArray = CalcList[index][3].Split(':');
          if (strArray != null & strArray.Length >= 2 && buFile5.IsNumeric(strArray[1]))
            ((ColorDrawType) selectedPlaneInfo).Height = Convert.ToDouble(strArray[1].Trim());
        }
        if (selectedPlaneInfo != null)
        {
          Region region = new Region((ICurve) CompositeCurve.CreateRectangle(((WriteDxfDwgPropeties) selectedPlaneInfo).refPlane, ((WriteDxfDwgPropeties) selectedPlaneInfo).refPlane.AxisX.X * ((ColorDrawType) selectedPlaneInfo).Length, ((ColorDrawType) selectedPlaneInfo).Height));
          ((WriteDxfDwgPropeties) selectedPlaneInfo).entityPlane = (Entity) region.ConvertToMesh();
          Planes.Add(selectedPlaneInfo);
        }
      }
      buLogVer5.addToLog(nameof (OpenPlaneFile), nameof (OpenPlaneFile), "OpenPlaneFile Opened", "Ok", -1.0, 0.0);
      GC.Collect();
    }
    catch (Exception ex)
    {
      string auxMessage = "FileName : " + FileName;
      buLogVer5.addToLog(nameof (OpenPlaneFile), nameof (OpenPlaneFile), "OpenPlaneFile Opened", "Error", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public static void SaveMachineConfigFile(string FileName, MachineDef Config)
  {
    try
    {
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenMachineConfigFile(
    string FileName,
    ref MachineDef Mach,
    MachineConfigSettings Settings)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      Mach = (MachineDef) new Pnt6DSimMove();
      List<List<string>> CalcList1 = new List<List<string>>();
      buVector5.OpenFromFile(FileName, ref StringList);
      buImage5.ListToSpecificList("<MachineDefPart>", "</MachineDefPart>", true, StringList, ref CalcList1);
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        MachineDefPart machineDefPart = (MachineDefPart) new Pnt6DSimMove();
        buSerilization5.Decode(CalcList1[index], "", (SerilizationMode5) 1, (object) machineDefPart);
        if (((Pnt6DSimMove) machineDefPart).PartType.Trim() == ((GCodeSetting5) Settings).PartTypeInfo.Trim())
        {
          string path = buFile5.bunesting.GetPath(((Pnt6DSimMove) machineDefPart).PartFileName);
          string withoutExtension = buFile5.bunesting.getFileNameWithoutExtension(((Pnt6DSimMove) machineDefPart).PartFileName);
          string fileExtension = buFile5.bunesting.getFileExtension(((Pnt6DSimMove) machineDefPart).PartFileName);
          ((Pnt6DSimMove) machineDefPart).PartFileName = $"{path}\\{withoutExtension}{((GCodeSetting5) Settings).PartTypeAdder}{fileExtension}";
        }
        FileInfo fileInfo = new FileInfo($"{AppPath.MachineSimConfig}\\{((Pnt6DSimMove) machineDefPart).PartFileName}");
        if (fileInfo.Exists)
        {
          ((F_DeleteType) buCall.\u0001).ReadStlFile(fileInfo.FullName, ref ((Pnt6DSimMove) machineDefPart).Entities);
          ((Pnt6DSimMove) machineDefPart).Entities[0].Regen(0.1);
          ((Pnt6DSimMove) Mach).MachineParts.Add(machineDefPart);
        }
      }
      List<List<string>> CalcList2 = new List<List<string>>();
      buVector5.OpenFromFile(FileName, ref StringList);
      buImage5.ListToSpecificList("<ClamperDefPart>", "</ClamperDefPart>", false, StringList, ref CalcList2);
      for (int index = 0; index <= CalcList2.Count - 1; ++index)
      {
        CalcList2[index].Insert(0, "<MachineDefPart>");
        CalcList2[index].Add("/<MachineDefPart>");
        MachineDefPart machineDefPart = (MachineDefPart) new Pnt6DSimMove();
        buSerilization5.Decode(CalcList2[index], "", (SerilizationMode5) 1, (object) machineDefPart);
        FileInfo fileInfo = new FileInfo($"{AppPath.MachineSimConfig}\\{((Pnt6DSimMove) machineDefPart).PartFileName}");
        if (fileInfo.Exists)
        {
          ((F_DeleteType) buCall.\u0001).ReadStlFile(fileInfo.FullName, ref ((Pnt6DSimMove) machineDefPart).Entities);
          ((Pnt6DSimMove) Mach).Clampers.Add(machineDefPart);
        }
      }
      buLog.addLog("Macihne Config File Opened", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
      GC.Collect();
    }
    catch (Exception ex)
    {
      string str = "FileName : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public event CalculationEventHandler CalculationInProgress;

  public event CalculationEventHandler CalculationStarted;

  public event CalculationEventHandler CalculationEnded;

  public event CalculationEventHandler CalculationCanceled;

  public event CalculationErrorEventHandler CalculationError;
}
