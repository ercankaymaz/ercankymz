// Decompiled with JetBrains decompiler
// Type: buCore.buFile
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buClass;
using buClass.Apps;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace buCore;

public class buFile
{
  private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";
  private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";
  private static string string_2 = "";
  private static string string_3 = "";
  private static double double_0 = 0.0;
  private static double double_1 = 0.0;

  public buFile()
  {
    if (!buVector.smethod_0(nameof (buFile)))
      throw new RegisterException(nameof (buFile));
  }

  public static void getFiles(string Path, ref List<string> Files)
  {
    try
    {
      if (!new DirectoryInfo(Path).Exists)
        return;
      Files = new List<string>();
      string[] files = Directory.GetFiles(Path);
      if (files == null)
        return;
      for (int index = 0; index <= files.Length - 1; ++index)
        Files.Add(files[index]);
    }
    catch (Exception ex)
    {
      string str = "Path: " + Path.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void getDirectories(string Path, ref List<string> Directories)
  {
    try
    {
      if (!new DirectoryInfo(Path).Exists)
        return;
      Directories = new List<string>();
      string[] directories = Directory.GetDirectories(Path);
      if (directories == null)
        return;
      for (int index = 0; index <= directories.Length - 1; ++index)
        Directories.Add(directories[index]);
    }
    catch (Exception ex)
    {
      string str = "Path: " + Path.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static List<string> GetPathInPath(string Path)
  {
    List<string> pathInPath = new List<string>();
    foreach (string directory in Directory.GetDirectories(Path))
      pathInPath.Add(directory);
    return pathInPath;
  }

  public static string getFileName(string FullPath) => Path.GetFileName(FullPath);

  public static string getFileNameWithoutExtension(string FullPath)
  {
    return Path.GetFileNameWithoutExtension(FullPath);
  }

  public static string GetPreviousPath(string FullPath)
  {
    try
    {
      return Directory.GetParent(FullPath).FullName;
    }
    catch (Exception ex)
    {
      string str = "FullPath: " + FullPath.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string GetPath(string FullFileName)
  {
    try
    {
      return FullFileName.Length > 1 ? Path.GetDirectoryName(FullFileName) : "";
    }
    catch (Exception ex)
    {
      string str = "FullFileName: " + FullFileName.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static void GetFilesInDirectory(string Dir, string Extension, ref List<string> Files)
  {
    try
    {
      string str = Extension.Replace(".", "").Replace("*", "");
      if (!new DirectoryInfo(Dir).Exists)
        return;
      string[] files = Directory.GetFiles(Dir, "*." + str);
      for (int index = 0; index <= files.Length - 1; ++index)
        Files.Add(files[index]);
    }
    catch (Exception ex)
    {
      string str = $"Dir: {Dir.ToString()} - FileType: {Extension.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static string PathToFileWithExtension(string FullPath)
  {
    try
    {
      string fileWithExtension = "";
      for (int startIndex = FullPath.Length - 1; startIndex > 0; --startIndex)
      {
        if (FullPath.Substring(startIndex, 1) == "\\")
        {
          fileWithExtension = FullPath.Substring(startIndex + 1, FullPath.Length - startIndex - 1);
          break;
        }
      }
      return fileWithExtension;
    }
    catch (Exception ex)
    {
      string str = "FullPath: " + FullPath.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string PathToFileWithoutExtension(string FullPath)
  {
    try
    {
      string withoutExtension = "";
      int startIndex1 = 0;
      for (int startIndex2 = FullPath.Length - 1; startIndex2 > 0; --startIndex2)
      {
        if (FullPath.Substring(startIndex2, 1) == "\\")
        {
          startIndex1 = startIndex2 + 1;
          break;
        }
      }
      for (int startIndex3 = startIndex1; startIndex3 <= FullPath.Length - 1; ++startIndex3)
      {
        if (FullPath.Substring(startIndex3, 1) == ".")
        {
          withoutExtension = FullPath.Substring(startIndex1, startIndex3 - startIndex1);
          break;
        }
      }
      return withoutExtension;
    }
    catch (Exception ex)
    {
      string str = "FullPath: " + FullPath.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static List<string> FindFilesOneDirectory(
    string Dir,
    string FileType,
    FileFilterType FileFilter)
  {
    try
    {
      List<string> filesOneDirectory = new List<string>();
      if (new DirectoryInfo(Dir).Exists)
      {
        string[] files = Directory.GetFiles(Dir, "*." + FileType);
        if (files != null)
        {
          for (int index = 0; index <= files.Length - 1; ++index)
          {
            if (FileFilter == FileFilterType.FileWithExtension)
              filesOneDirectory.Add(buFile.PathToFileWithExtension(files[index]));
            if (FileFilter == FileFilterType.FileWithoutExtension)
              filesOneDirectory.Add(buFile.PathToFileWithoutExtension(files[index]));
            if (FileFilter == FileFilterType.FullPath)
              filesOneDirectory.Add(files[index]);
          }
        }
      }
      return filesOneDirectory;
    }
    catch (Exception ex)
    {
      string str = $"Dir: {Dir.ToString()} - FileType: {FileType.ToString()} - FileFilter: {FileFilter.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return new List<string>();
    }
  }

  public static void GetFileArgumans(string FileName, ref FileEventArg FileArg)
  {
    try
    {
      FileArg.FileName = FileName;
      FileArg.FilePath = buFile.GetPath(FileName);
      FileArg.JustFileName = buFile.getFileName(FileName);
      FileArg.JustFileNameWithoutExtension = buFile.getFileNameWithoutExtension(FileName);
    }
    catch (Exception ex)
    {
      string str = "FileName: " + FileName.ToString();
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
  }

  public static void GetLineCounfOfFile(string FileName, ref int LineCount)
  {
    try
    {
      LineCount = 0;
      LineCount = File.ReadLines(FileName).Count<string>();
    }
    catch (Exception ex)
    {
    }
  }

  public static void GetFileInitPathByType(
    List<string> ExtensionList,
    int Index,
    FileOpenModes Settings,
    ref string Path)
  {
    ArrayList ExtensionList1 = new ArrayList();
    for (int index = 0; index <= ExtensionList.Count - 1; ++index)
      ExtensionList1.Add((object) ExtensionList[index]);
    buFile.GetFileInitPathByType(ExtensionList1, Index, Settings, ref Path);
    ExtensionList1.Clear();
  }

  public static void GetFileInitPathByType(
    ArrayList ExtensionList,
    int Index,
    FileOpenModes Settings,
    ref string Path)
  {
    if (Path.Trim().Length <= 0)
      Path = Application.StartupPath;
    if (!(Index >= 0 & Index <= ExtensionList.Count - 1))
      return;
    string lower = ExtensionList[Index].ToString().ToLower();
    if (lower.IndexOf("bucad") >= 0)
      Path = Settings.InitPathBuCadV5;
    if (lower.IndexOf("dwc") >= 0)
      Path = Settings.InitPathDwc;
    if (lower.IndexOf("dwx") >= 0)
      Path = Settings.InitPathDxf;
    if (lower.IndexOf("dwg") >= 0)
      Path = Settings.InitPathDwg;
    if (lower.IndexOf("stl") >= 0)
      Path = Settings.InitPathStl;
    if (lower.IndexOf("igs") >= 0)
      Path = Settings.InitPathIges;
    if (lower.IndexOf("step") < 0)
      return;
    Path = Settings.InitPathStep;
  }

  public static void SetFileInitPathByType(
    ArrayList ExtensionList,
    int Index,
    string Path,
    ref FileOpenModes Settings)
  {
    if (Path.Trim().Length <= 0)
      Path = Application.StartupPath;
    if (!(Index >= 0 & Index <= ExtensionList.Count - 1))
      return;
    string lower = ExtensionList[Index].ToString().ToLower();
    if (lower.IndexOf("bucad") >= 0)
      Settings.InitPathBuCadV5 = Path;
    if (lower.IndexOf("dwc") >= 0)
      Settings.InitPathDwc = Path;
    if (lower.IndexOf("dwx") >= 0)
      Settings.InitPathDxf = Path;
    if (lower.IndexOf("dwg") >= 0)
      Settings.InitPathDwg = Path;
    if (lower.IndexOf("stl") >= 0)
      Settings.InitPathStl = Path;
    if (lower.IndexOf("igs") >= 0)
      Settings.InitPathIges = Path;
    if (lower.IndexOf("step") < 0)
      return;
    Settings.InitPathStep = Path;
  }

  public static string FileNameFromDate(int Mode)
  {
    string str = "";
    if (Mode == 0)
    {
      string[] strArray = new string[11];
      DateTime now = DateTime.Now;
      strArray[0] = now.Year.ToString();
      strArray[1] = "_";
      now = DateTime.Now;
      strArray[2] = now.Month.ToString();
      strArray[3] = "_";
      now = DateTime.Now;
      strArray[4] = now.Day.ToString();
      strArray[5] = "_";
      now = DateTime.Now;
      strArray[6] = now.Hour.ToString();
      strArray[7] = "_";
      now = DateTime.Now;
      strArray[8] = now.Minute.ToString();
      strArray[9] = "_";
      now = DateTime.Now;
      strArray[10] = now.Second.ToString();
      str = string.Concat(strArray);
    }
    return str;
  }

  public static void CopyFromDirectortToAnotherDirectory(string sourceDir, string targetDir)
  {
    Directory.CreateDirectory(targetDir);
    foreach (string file in Directory.GetFiles(sourceDir))
      File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
    foreach (string directory in Directory.GetDirectories(sourceDir))
      buFile.CopyFromDirectortToAnotherDirectory(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
  }

  public static void DeleteAllFilesInDirectory(string sourceDir)
  {
    DirectoryInfo directoryInfo = new DirectoryInfo(sourceDir);
    foreach (string file in Directory.GetFiles(sourceDir))
      File.Delete(file);
    foreach (string directory in Directory.GetDirectories(sourceDir))
      buFile.DeleteAllFilesInDirectory(directory);
  }

  public static void DeleteAllEmptyDirectoryInDirectory(string sourceDir)
  {
    foreach (string directory in Directory.GetDirectories(sourceDir))
    {
      string[] directories = Directory.GetDirectories(directory);
      if (directories.Length == 0)
      {
        new DirectoryInfo(directory).Delete();
      }
      else
      {
        for (int index = 0; index <= directories.Length - 1; ++index)
          buFile.DeleteAllEmptyDirectoryInDirectory(directories[index]);
        new DirectoryInfo(directory).Delete();
      }
    }
  }

  public static void OpenPassword(string FileName, double Key)
  {
    try
    {
      string str1 = "";
      if (new FileInfo(FileName).Exists)
      {
        BinaryReader binaryReader = new BinaryReader((Stream) new FileStream(FileName, FileMode.Open));
        int num1 = binaryReader.ReadInt32();
        for (int index = 0; index < num1; ++index)
        {
          byte num2 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str1 += Convert.ToChar(num2).ToString();
          AppSecurity.Pass1 = str1;
        }
        string str2 = "";
        int num3 = binaryReader.ReadInt32();
        for (int index = 0; index < num3; ++index)
        {
          byte num4 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str2 += Convert.ToChar(num4).ToString();
          AppSecurity.Pass2 = str2;
        }
        string str3 = "";
        int num5 = binaryReader.ReadInt32();
        for (int index = 0; index < num5; ++index)
        {
          byte num6 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str3 += Convert.ToChar(num6).ToString();
          AppSecurity.Pass3 = str3;
        }
        string str4 = "";
        int num7 = binaryReader.ReadInt32();
        for (int index = 0; index < num7; ++index)
        {
          byte num8 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str4 += Convert.ToChar(num8).ToString();
          AppSecurity.Pass4 = str4;
        }
        string str5 = "";
        int num9 = binaryReader.ReadInt32();
        for (int index = 0; index < num9; ++index)
        {
          byte num10 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str5 += Convert.ToChar(num10).ToString();
          AppSecurity.Pass5 = str5;
        }
        string str6 = "";
        int num11 = binaryReader.ReadInt32();
        for (int index = 0; index < num11; ++index)
        {
          byte num12 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str6 += Convert.ToChar(num12).ToString();
          AppSecurity.Pass6 = str6;
        }
        string str7 = "";
        int num13 = binaryReader.ReadInt32();
        for (int index = 0; index < num13; ++index)
        {
          byte num14 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str7 += Convert.ToChar(num14).ToString();
          AppSecurity.Pass7 = str7;
        }
        string str8 = "";
        int num15 = binaryReader.ReadInt32();
        for (int index = 0; index < num15; ++index)
        {
          byte num16 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str8 += Convert.ToChar(num16).ToString();
          AppSecurity.Pass8 = str8;
        }
        string str9 = "";
        int num17 = binaryReader.ReadInt32();
        for (int index = 0; index < num17; ++index)
        {
          byte num18 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str9 += Convert.ToChar(num18).ToString();
          AppSecurity.Pass9 = str9;
        }
        string str10 = "";
        int num19 = binaryReader.ReadInt32();
        for (int index = 0; index < num19; ++index)
        {
          byte num20 = Convert.ToByte(binaryReader.ReadDouble() / (34.365 * Key));
          str10 += Convert.ToChar(num20).ToString();
          AppSecurity.Pass10 = str10;
        }
        binaryReader.Close();
      }
      buLogVer5.addToLog(nameof (buFile), "PasswordOpen", "Password Load", "Ok", -1.0, 0.0);
    }
    catch (Exception ex)
    {
      string auxMessage = "";
      buLogVer5.addToLog(nameof (buFile), "PasswordOpen", "Password Load", "Fail", -1.0, 0.0);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, auxMessage);
    }
  }

  public static void OpenLastUndoItem(string FileName, int GetCount, ref List<Undo> UndoItems)
  {
    try
    {
      UndoItems = new List<Undo>();
      ArrayList StringList1 = new ArrayList();
      List<List<string>> CalcList1 = new List<List<string>>();
      buFile.OpenFromFile(FileName, ref StringList1);
      buString.ListToSpecificList("<UndoItem>", "</UndoItem>", false, StringList1, ref CalcList1);
      if (CalcList1.Count > 0)
      {
        int num = 0;
        for (int index1 = CalcList1.Count - 1; index1 >= 0; --index1)
        {
          Undo undo = new Undo();
          List<List<string>> CalcList2 = new List<List<string>>();
          buString.ListToSpecificList("<eEntities>", "</eEntities>", false, CalcList1[index1], ref CalcList2);
          for (int index2 = 0; index2 <= CalcList2.Count - 1; ++index2)
          {
            eEntities eEntities1 = new eEntities();
            eEntities eEntities2 = eEntities.Decode(CalcList2[index2], "", SerilizationMode.MultiLine);
            undo.Entities.Add(eEntities2);
          }
          UndoItems.Add(undo);
          ++num;
          CalcList1.RemoveAt(index1);
          if (num >= GetCount)
            index1 = -1;
        }
      }
      StringList1.Clear();
      ArrayList StringList2 = new ArrayList();
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        StringList2.Add((object) "<UndoItem>");
        StringList2.AddRange((ICollection) CalcList1[index].ToArray());
        StringList2.Add((object) "</UndoItem>");
      }
      buFile.SaveToFile(StringList2, FileName);
    }
    catch (Exception ex)
    {
      string str = $"FileName: {FileName.ToString()} - GetCount: {GetCount.ToString()}";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

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
      buFile.SaveToFile(StringList, FileName, true);
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
    buFile.OpenBuCadCam(FileName, Options, ref Entities, ref CamList, ref Layers, ref Tags);
  }

  public static void OpenBuCadCam(ArrayList EntitiesLines, ref List<eEntities> Entities)
  {
    List<List<string>> CalcList = new List<List<string>>();
    Entities.Clear();
    buString.ListToSpecificList("<eEntities>", "</eEntities>", false, EntitiesLines, ref CalcList);
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
    buFile.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags);
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
      buFile.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
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
      buFile.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
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
      buFile.OpenBuCadCam(FileName, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
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
      buFile.OpenFromFile(FileName, ref StringList);
      buFile.OpenBuCadCam(StringList, Options, ref FileInfo, ref Entities, ref CamList, ref Layers, ref Tags, ref AppOption, ref Profiles);
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
      buString.ListToSpecificList("<eEntities>", "</eEntities>", true, Lines, ref CalcList1);
      for (int index = 0; index <= CalcList1.Count - 1; ++index)
      {
        eEntities eEntities1 = new eEntities();
        eEntities eEntities2 = eEntities.Decode(CalcList1[index], "", SerilizationMode.MultiLine);
        eEntities2.EntityIndex = Entities.Count;
        Entities.Add(eEntities2);
      }
      List<List<string>> CalcList2 = new List<List<string>>();
      buString.ListToSpecificList("<LayerBase>", "</LayerBase>", false, Lines, ref CalcList2);
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
      buString.ListToSpecificList("<ProfileJob>", "</ProfileJob>", true, Lines, ref CalcList3);
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
      buString.ListToSpecificList("<buCadCamFileInfo>", "</buCadCamFileInfo>", true, Lines, ref CalcList4);
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
    buFile.SaveBuCadCam(FileName, Options, new buCadCamFileInfo(), Entities, CamList, Layers, Tags, (object) null, (object) null, (List<ProfileJob>) null);
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
      buFile.SaveBuCadCam(FileName, Options, FileInfo, Entities, CamList, Layers, Tags, (object) null, (object) null, (List<ProfileJob>) null);
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

  public static void OpenKinemticFile(string FileName, ref KinematicBase Kinematic)
  {
    try
    {
      ArrayList StringList = new ArrayList();
      Kinematic = new KinematicBase();
      List<List<string>> CalcList1 = new List<List<string>>();
      buFile.OpenFromFile(FileName, ref StringList);
      buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, (object) Kinematic);
      buString.ListToSpecificList("<KinematicItem>", "</KinematicItem>", false, StringList, ref CalcList1);
      for (int index1 = 0; index1 <= CalcList1.Count - 1; ++index1)
      {
        ArrayList AL = new ArrayList();
        AL.AddRange((ICollection) CalcList1[index1].ToArray());
        AL.Insert(0, (object) "<KinematicItem>");
        AL.Add((object) "</KinematicItem>");
        KinematicItem kinematicItem = new KinematicItem();
        buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) kinematicItem);
        eEntities eEntities1 = new eEntities();
        List<string> stringList = new List<string>();
        List<List<string>> CalcList2 = new List<List<string>>();
        buString.ListToSpecificList("<SubEntities>", "</SubEntities>", true, CalcList1[index1], ref CalcList2);
        for (int index2 = 0; index2 <= CalcList2.Count - 1; ++index2)
        {
          eEntities eEntities2 = new eEntities();
          eEntities eEntities3 = eEntities.Decode(CalcList2[index2], "", SerilizationMode.MultiLine);
          kinematicItem.Entities.Add(eEntities3);
        }
        Kinematic.Items.Add(kinematicItem);
      }
      Kinematic.FileName = FileName;
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

  public static void SaveKinematicFile(string FileName, KinematicBase Kinematic)
  {
    try
    {
      ArrayList arrayList = new ArrayList();
      arrayList.AddRange((ICollection) Kinematic.ToDefAll("", 2, SerilizationMode.MultiLine));
      string str1 = arrayList[arrayList.Count - 1].ToString();
      arrayList.RemoveAt(arrayList.Count - 1);
      for (int index1 = 0; index1 <= Kinematic.Items.Count - 1; ++index1)
      {
        buSerilization.ExceptionalVariables.Clear();
        arrayList.AddRange((ICollection) Kinematic.Items[index1].ToDefAll("", 4, SerilizationMode.MultiLine));
        string str2 = arrayList[arrayList.Count - 1].ToString();
        arrayList.RemoveAt(arrayList.Count - 1);
        for (int index2 = 0; index2 <= Kinematic.Items[index1].Entities.Count - 1; ++index2)
        {
          arrayList.Add((object) "<SubEntities>");
          arrayList.AddRange((ICollection) Kinematic.Items[index1].Entities[index2].ToDefAll(6));
          arrayList.Add((object) "</SubEntities>");
        }
        arrayList.Add((object) str2);
      }
      arrayList.Add((object) str1);
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
      buFile.OpenFromFile(FileName, ref StringList);
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

  public static void OpenFromFile(string FileName, ref List<string> StringList)
  {
    try
    {
      if (!buVector.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
      }
      else
      {
        StringList = new List<string>();
        TextReader textReader = (TextReader) File.OpenText(FileName);
        string str;
        while ((str = textReader.ReadLine()) != null)
          StringList.Add(str);
        textReader.Close();
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
    }
  }

  public static void OpenFromFile(string FileName, ref ArrayList StringList)
  {
    try
    {
      if (!buVector.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
      }
      else
      {
        StringList = new ArrayList();
        TextReader textReader = (TextReader) File.OpenText(FileName);
        string str;
        while ((str = textReader.ReadLine()) != null)
          StringList.Add((object) str);
        textReader.Close();
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
    }
  }

  public static void OpenFromFile(string FileName, ref string Str)
  {
    try
    {
      if (!buVector.bool_0)
      {
        int num = (int) MessageBox.Show("License Error");
      }
      else
      {
        StreamReader streamReader = new StreamReader(FileName);
        Str = streamReader.ReadToEnd();
        streamReader.Close();
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
    }
  }

  public static void SaveToFile(string String, string FileName)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter text = (TextWriter) File.CreateText(FileName);
      try
      {
        text.WriteLine(String);
        text.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        text.Close();
      }
    }
  }

  public static void SaveToFile(string String, string FileName, bool Append)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter textWriter = !Append ? (TextWriter) File.CreateText(FileName) : (TextWriter) File.AppendText(FileName);
      try
      {
        textWriter.WriteLine(String);
        textWriter.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        textWriter.Close();
      }
    }
  }

  public static void SaveToFile(List<string> StringList, string FileName)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter text = (TextWriter) File.CreateText(FileName);
      try
      {
        for (int index = 0; index <= StringList.Count - 1; ++index)
          text.WriteLine(StringList[index].ToString());
        text.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        text.Close();
      }
    }
  }

  public static void SaveToFile(List<string> StringList, string FileName, bool Append)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter textWriter = !Append ? (TextWriter) File.CreateText(FileName) : (TextWriter) File.AppendText(FileName);
      try
      {
        for (int index = 0; index <= StringList.Count - 1; ++index)
          textWriter.WriteLine(StringList[index].ToString());
        textWriter.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        textWriter.Close();
      }
    }
  }

  public static void SaveToFile(List<List<string>> StringList, string FileName)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter text = (TextWriter) File.CreateText(FileName);
      try
      {
        for (int index1 = 0; index1 <= StringList.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= StringList[index1].Count - 1; ++index2)
            text.WriteLine(StringList[index1][index2].ToString());
        }
        text.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        text.Close();
      }
    }
  }

  public static void SaveToFile(List<List<string>> StringList, string FileName, bool Append)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter textWriter = !Append ? (TextWriter) File.CreateText(FileName) : (TextWriter) File.AppendText(FileName);
      try
      {
        for (int index1 = 0; index1 <= StringList.Count - 1; ++index1)
        {
          for (int index2 = 0; index2 <= StringList[index1].Count - 1; ++index2)
            textWriter.WriteLine(StringList[index1][index2].ToString());
        }
        textWriter.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        textWriter.Close();
      }
    }
  }

  public static void SaveToFile(ArrayList StringList, string FileName)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter text = (TextWriter) File.CreateText(FileName);
      try
      {
        for (int index = 0; index <= StringList.Count - 1; ++index)
          text.WriteLine(StringList[index].ToString());
        text.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        text.Close();
      }
    }
  }

  public static void SaveToFile(ArrayList StringList, string FileName, bool Append)
  {
    if (!buVector.bool_0)
    {
      int num = (int) MessageBox.Show("License Error");
    }
    else
    {
      TextWriter textWriter = !Append ? (TextWriter) File.CreateText(FileName) : (TextWriter) File.AppendText(FileName);
      try
      {
        for (int index = 0; index <= StringList.Count - 1; ++index)
          textWriter.WriteLine(StringList[index].ToString());
        textWriter.Close();
      }
      catch (Exception ex)
      {
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
      }
      finally
      {
        textWriter.Close();
      }
    }
  }

  public static void AppendToFile(string String, string FileName)
  {
    TextWriter textWriter = (TextWriter) File.AppendText(FileName);
    try
    {
      textWriter.WriteLine(String);
      textWriter.Close();
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, FileName);
    }
    finally
    {
      textWriter.Close();
    }
  }

  public static void ZipFolderToFile(string Folder, string FileName)
  {
    ZipFile.CreateFromDirectory(Folder, FileName);
  }

  public static void ZipFolderToFile(string Folder, string FileName, CompressionLevel Level)
  {
    ZipFile.CreateFromDirectory(Folder, FileName, Level, false);
  }

  public static void ExtractToFolder(string Folder, string FileName)
  {
    ZipFile.ExtractToDirectory(FileName, Folder);
  }

  public static void OpenSurfaceReadFile(string Filename, ref List<Pnt3D> pntTeachList)
  {
    ArrayList StringList = new ArrayList();
    buFile.OpenFromFile(Filename, ref StringList);
    ArrayList CalcList1 = new ArrayList();
    buString.ListToSpecificList("<CalibRatio>", "</CalibRatio>", false, StringList, ref CalcList1);
    double result = 1.0;
    if (CalcList1.Count > 0)
      double.TryParse(CalcList1[0].ToString(), out result);
    ArrayList CalcList2 = new ArrayList();
    pntTeachList.Clear();
    buString.ListToSpecificList("<ReadSurface>", "</ReadSurface>", false, StringList, ref CalcList2);
    double num = 0.0;
    for (int index = 0; index <= CalcList2.Count - 1; ++index)
    {
      Pnt3D pnt3D1 = new Pnt3D();
      Pnt3D pnt3D2 = Pnt3D.DecodeFromString(CalcList2[index].ToString());
      pnt3D2.Z *= -1.0;
      pnt3D2.Z /= result;
      if (index == 0)
        num = pnt3D2.Z;
      pnt3D2.Z -= num;
      pntTeachList.Add(pnt3D2);
    }
    if (pntTeachList.Count <= 2 || Math.Abs(pntTeachList[pntTeachList.Count - 1].X - pntTeachList[pntTeachList.Count - 2].X) <= 100.0)
      return;
    pntTeachList.RemoveAt(pntTeachList.Count - 1);
  }

  public static string SoapSerialize(object graph)
  {
    try
    {
      using (MemoryStream serializationStream = new MemoryStream())
      {
        new SoapFormatter().Serialize((Stream) serializationStream, graph);
        return Encoding.UTF8.GetString(serializationStream.GetBuffer(), 0, (int) serializationStream.Position);
      }
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, graph.ToString());
      return "";
    }
  }

  public static object SoapDeserialize(string buffer)
  {
    try
    {
      using (MemoryStream serializationStream = new MemoryStream(Encoding.UTF8.GetBytes(buffer)))
        return new SoapFormatter().Deserialize((Stream) serializationStream);
    }
    catch (Exception ex)
    {
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, buffer);
      return (object) null;
    }
  }

  public class GCodeRead
  {
    public GCodeChars Chars = new GCodeChars();
    public AxesEnableWithUVW DecodeAxes = new AxesEnableWithUVW(true, true, true);
    public List<eEntities> EntitiesG1 = new List<eEntities>();
    public List<eEntities> EntitiesG0 = new List<eEntities>();
    public List<eEntities> EntitiesPlunge = new List<eEntities>();
    public List<eEntities> EntitiesLeave = new List<eEntities>();
    public Pnt9D MaxCoordinates = new Pnt9D();
    public Pnt9D MinCoordinates = new Pnt9D();
    public int MaxLineCount = -1;
    private buVector buVector_0 = (buVector) null;

    public GCodeRead()
    {
      if (!buVector.smethod_0(nameof (GCodeRead)))
        throw new RegisterException(nameof (GCodeRead));
      this.buVector_0 = new buVector();
    }

    public void OpenGCode(string FileName, ref List<GCodePoint> GCodeList)
    {
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(FileName, ref StringList);
      this.OpenGCode(StringList, ref GCodeList);
    }

    public void OpenGCode(List<string> GCodes, ref List<GCodePoint> GCodeList)
    {
      try
      {
        GCodeList.Clear();
        Pnt9D Pnt = new Pnt9D();
        double num1 = 0.0;
        bool flag1 = false;
        int num2 = -1;
        bool flag2 = false;
        List<Pnt3D> CopiedPnt = new List<Pnt3D>();
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        List<GCodeGraphPoint> Points = new List<GCodeGraphPoint>();
        this.EntitiesG1.Clear();
        this.EntitiesG0.Clear();
        this.EntitiesLeave.Clear();
        this.EntitiesPlunge.Clear();
        this.EntitiesG1 = new List<eEntities>();
        this.EntitiesG0 = new List<eEntities>();
        this.EntitiesLeave = new List<eEntities>();
        this.EntitiesPlunge = new List<eEntities>();
        this.MaxCoordinates = new Pnt9D(double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        this.MinCoordinates = new Pnt9D(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
        for (int index = 0; index <= GCodes.Count - 1; ++index)
        {
          bool flag3 = false;
          GCodePoint gcodePoint = new GCodePoint();
          gcodePoint.Positions = new Pnt9D(Pnt);
          gcodePoint.isGCode = flag1;
          gcodePoint.CodeType = num2;
          string Line = GCodes[index].Trim();
          if (Line.IndexOf(",") >= 0)
            Line = Line.Replace(",", ".");
          if (index % 1000 == 0)
            GC.Collect();
          if (Line.Length > 0)
          {
            gcodePoint.CodeString = Line;
          }
          else
          {
            gcodePoint.isGCode = false;
            gcodePoint.isG0Move = false;
            gcodePoint.isMCode = false;
            gcodePoint.isTCode = false;
            gcodePoint.CodeType = -1;
          }
          if (Line.IndexOf(this.Chars.G) >= 0)
          {
            gcodePoint.isGCode = true;
            gcodePoint.isMCode = false;
            if (buString.ReadStringValue(this.Chars.G, Line, ref gcodePoint.GValue))
              gcodePoint.CodeType = Convert.ToInt32(gcodePoint.GValue);
          }
          if (Line.IndexOf(this.Chars.M) >= 0)
          {
            gcodePoint.isMCode = true;
            gcodePoint.isGCode = false;
          }
          if (Line.IndexOf(this.Chars.T) >= 0)
          {
            gcodePoint.isTCode = true;
            gcodePoint.isGCode = false;
          }
          gcodePoint.Entity = (geoEntity) new geoPoint(new Pnt3D());
          gcodePoint.Entity.Visible = false;
          if (gcodePoint.isGCode)
          {
            flag3 = true;
            if (this.DecodeAxes.X && buString.ReadStringValue(this.Chars.X, Line, ref gcodePoint.Positions.X))
            {
              if (gcodePoint.Positions.X > this.MaxCoordinates.X)
                this.MaxCoordinates.X = gcodePoint.Positions.X;
              if (gcodePoint.Positions.X < this.MinCoordinates.X)
                this.MinCoordinates.X = gcodePoint.Positions.X;
            }
            if (this.DecodeAxes.Y && buString.ReadStringValue(this.Chars.Y, Line, ref gcodePoint.Positions.Y))
            {
              if (gcodePoint.Positions.Y > this.MaxCoordinates.Y)
                this.MaxCoordinates.Y = gcodePoint.Positions.Y;
              if (gcodePoint.Positions.Y < this.MinCoordinates.Y)
                this.MinCoordinates.Y = gcodePoint.Positions.Y;
            }
            if (this.DecodeAxes.Z && buString.ReadStringValue(this.Chars.Z, Line, ref gcodePoint.Positions.Z))
            {
              if (gcodePoint.Positions.Z > this.MaxCoordinates.Z)
                this.MaxCoordinates.Z = gcodePoint.Positions.Z;
              if (gcodePoint.Positions.Z < this.MinCoordinates.Z)
                this.MinCoordinates.Z = gcodePoint.Positions.Z;
            }
            if (this.DecodeAxes.A && buString.ReadStringValue(this.Chars.A, Line, ref gcodePoint.Positions.A))
            {
              if (gcodePoint.Positions.A > this.MaxCoordinates.A)
                this.MaxCoordinates.A = gcodePoint.Positions.A;
              if (gcodePoint.Positions.A < this.MinCoordinates.A)
                this.MinCoordinates.A = gcodePoint.Positions.A;
            }
            if (this.DecodeAxes.B && buString.ReadStringValue(this.Chars.B, Line, ref gcodePoint.Positions.B))
            {
              if (gcodePoint.Positions.B > this.MaxCoordinates.B)
                this.MaxCoordinates.B = gcodePoint.Positions.B;
              if (gcodePoint.Positions.B < this.MinCoordinates.B)
                this.MinCoordinates.B = gcodePoint.Positions.B;
            }
            if (this.DecodeAxes.C && buString.ReadStringValue(this.Chars.C, Line, ref gcodePoint.Positions.C))
            {
              if (gcodePoint.Positions.C > this.MaxCoordinates.C)
                this.MaxCoordinates.C = gcodePoint.Positions.C;
              if (gcodePoint.Positions.C < this.MinCoordinates.C)
                this.MinCoordinates.C = gcodePoint.Positions.C;
            }
            if (this.DecodeAxes.U && buString.ReadStringValue(this.Chars.U, Line, ref gcodePoint.Positions.U))
            {
              if (gcodePoint.Positions.U > this.MaxCoordinates.U)
                this.MaxCoordinates.U = gcodePoint.Positions.U;
              if (gcodePoint.Positions.U < this.MinCoordinates.U)
                this.MinCoordinates.U = gcodePoint.Positions.U;
            }
            if (this.DecodeAxes.V && buString.ReadStringValue(this.Chars.V, Line, ref gcodePoint.Positions.V))
            {
              if (gcodePoint.Positions.V > this.MaxCoordinates.V)
                this.MaxCoordinates.V = gcodePoint.Positions.V;
              if (gcodePoint.Positions.V < this.MinCoordinates.V)
                this.MinCoordinates.V = gcodePoint.Positions.V;
            }
            if (this.DecodeAxes.W && buString.ReadStringValue(this.Chars.W, Line, ref gcodePoint.Positions.W))
            {
              if (gcodePoint.Positions.W > this.MaxCoordinates.W)
                this.MaxCoordinates.W = gcodePoint.Positions.W;
              if (gcodePoint.Positions.W < this.MinCoordinates.W)
                this.MinCoordinates.W = gcodePoint.Positions.W;
            }
            buString.ReadStringValue(this.Chars.R, Line, ref gcodePoint.R);
            buString.ReadStringValue(this.Chars.I, Line, ref gcodePoint.IJKValue.I);
            buString.ReadStringValue(this.Chars.J, Line, ref gcodePoint.IJKValue.J);
            buString.ReadStringValue(this.Chars.K, Line, ref gcodePoint.IJKValue.K);
            buString.ReadStringValue("F", Line, ref num1);
            gcodePoint.Feed = num1;
            if (flag2)
            {
              if (gcodePoint.CodeType == 0)
              {
                gcodePoint.Entity = (geoEntity) new geoLine(new Pnt3D(Pnt.X, Pnt.Y, Pnt.Z), new Pnt3D(gcodePoint.Positions.X, gcodePoint.Positions.Y, gcodePoint.Positions.Z));
                gcodePoint.Entity.Color = Color.Red;
              }
              if (gcodePoint.CodeType == 1)
              {
                gcodePoint.Entity = (geoEntity) new geoLine(new Pnt3D(Pnt.X, Pnt.Y, Pnt.Z), new Pnt3D(gcodePoint.Positions.X, gcodePoint.Positions.Y, gcodePoint.Positions.Z));
                gcodePoint.Entity.Color = Color.Black;
              }
              if (gcodePoint.CodeType == 2)
              {
                Pnt3D ArcCenter = new Pnt3D();
                double StartAngle = 0.0;
                double EndAngle = 0.0;
                Pnt3D pnt3D1 = new Pnt3D(Pnt.X, Pnt.Y, Pnt.Z);
                Pnt3D pnt3D2 = new Pnt3D(gcodePoint.Positions.X, gcodePoint.Positions.Y, gcodePoint.Positions.Z);
                if (gcodePoint.R > 0.0)
                  this.buVector_0.ArcWithTwoPointAndRadius(pnt3D1, pnt3D2, Math.Abs(gcodePoint.R), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (gcodePoint.R < 0.0)
                {
                  this.buVector_0.ArcWithTwoPointAndRadius(pnt3D1, pnt3D2, Math.Abs(gcodePoint.R), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                  if (EndAngle - StartAngle < 180.0)
                  {
                    double num3 = StartAngle;
                    StartAngle = EndAngle;
                    EndAngle = num3;
                  }
                  if (StartAngle > EndAngle)
                    EndAngle += 360.0;
                }
                double Radius = Math.Abs(gcodePoint.R);
                if (gcodePoint.IJKValue.I != 0.0 | gcodePoint.IJKValue.J != 0.0 | gcodePoint.IJKValue.K != 0.0)
                  this.buVector_0.ArcWithIJK(pnt3D1, pnt3D2, gcodePoint.IJKValue.I, gcodePoint.IJKValue.J, gcodePoint.IJKValue.K, gcodePoint.CodeType, ref ArcCenter, ref Radius, ref StartAngle, ref EndAngle);
                List<Pnt3D> Vertices = new List<Pnt3D>();
                this.buVector_0.ArcWithCenter(ArcCenter, Radius, StartAngle, EndAngle, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
                gcodePoint.Entity = (geoEntity) new geoPolyline(Vertices);
                gcodePoint.Entity.Color = Color.Black;
              }
              if (gcodePoint.CodeType == 3)
              {
                Pnt3D ArcCenter = new Pnt3D();
                double StartAngle = 0.0;
                double EndAngle = 0.0;
                Pnt3D pnt3D3 = new Pnt3D(Pnt.X, Pnt.Y, Pnt.Z);
                Pnt3D pnt3D4 = new Pnt3D(gcodePoint.Positions.X, gcodePoint.Positions.Y, gcodePoint.Positions.Z);
                if (gcodePoint.R > 0.0)
                  this.buVector_0.ArcWithTwoPointAndRadius(pnt3D3, pnt3D4, Math.Abs(gcodePoint.R), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (gcodePoint.R < 0.0)
                {
                  this.buVector_0.ArcWithTwoPointAndRadius(pnt3D3, pnt3D4, Math.Abs(gcodePoint.R), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                  if (EndAngle - StartAngle < 180.0)
                  {
                    double num4 = StartAngle;
                    StartAngle = EndAngle;
                    EndAngle = num4;
                  }
                  if (StartAngle > EndAngle)
                    EndAngle += 360.0;
                }
                double Radius = Math.Abs(gcodePoint.R);
                if (gcodePoint.IJKValue.I != 0.0 | gcodePoint.IJKValue.J != 0.0 | gcodePoint.IJKValue.K != 0.0)
                  this.buVector_0.ArcWithIJK(pnt3D3, pnt3D4, gcodePoint.IJKValue.I, gcodePoint.IJKValue.J, gcodePoint.IJKValue.K, gcodePoint.CodeType, ref ArcCenter, ref Radius, ref StartAngle, ref EndAngle);
                List<Pnt3D> Vertices = new List<Pnt3D>();
                this.buVector_0.ArcWithCenter(ArcCenter, Radius, StartAngle, EndAngle, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
                gcodePoint.Entity = (geoEntity) new geoPolyline(Vertices);
                gcodePoint.Entity.Color = Color.Black;
              }
            }
            if (gcodePoint.CodeType >= 0 & gcodePoint.CodeType <= 3)
              flag2 = true;
          }
          if (gcodePoint.isMCode && buString.ReadStringValue(this.Chars.M, Line, ref gcodePoint.MValue))
          {
            flag3 = true;
            gcodePoint.CodeType = Convert.ToInt32(gcodePoint.MValue);
            buString.ReadStringValue(this.Chars.X, Line, ref gcodePoint.Positions.X);
          }
          if (gcodePoint.isTCode && buString.ReadStringValue(this.Chars.T, Line, ref gcodePoint.TValue))
          {
            flag3 = true;
            gcodePoint.CodeType = Convert.ToInt32(gcodePoint.TValue);
            gcodePoint.Tool = new ToolBase();
            gcodePoint.Tool.Data.No = Convert.ToInt32(gcodePoint.TValue);
          }
          if (gcodePoint.isGCode & gcodePoint.CodeType >= 0 & gcodePoint.CodeType <= 3 & flag2)
            Points.Add(new GCodeGraphPoint()
            {
              Positions = new Pnt9D(gcodePoint.Positions.X, gcodePoint.Positions.Y, gcodePoint.Positions.Z),
              CodeType = gcodePoint.CodeType,
              Radius = gcodePoint.R,
              IJKValues = new IJK(gcodePoint.IJKValue)
            });
          if (flag3)
          {
            GCodeList.Add(gcodePoint);
            Pnt = new Pnt9D(gcodePoint.Positions);
          }
          flag1 = gcodePoint.isGCode;
          num2 = gcodePoint.CodeType;
          if (this.MaxLineCount > 0 & index > this.MaxLineCount & index > 0)
            index = GCodes.Count;
        }
        if (Points.Count <= 1)
          return;
        this.buVector_0.CheckDuplicatedPointsWithPrevious(ref Points);
        if (Points.Count > 1 && Points[0].CodeType == 0 && Points[0].Positions.X == 0.0 & Points[0].Positions.Y == 0.0 && Points[0].Positions.Z == Points[1].Positions.Z)
          Points.RemoveAt(0);
        Pnt3D pnt3D5 = new Pnt3D();
        for (int index = 1; index <= Points.Count - 1; ++index)
        {
          Pnt3D pnt3D6 = new Pnt3D(Points[index - 1].Positions.X, Points[index - 1].Positions.Y, Points[index - 1].Positions.Z);
          Pnt3D pnt3D7 = new Pnt3D(Points[index].Positions.X, Points[index].Positions.Y, Points[index].Positions.Z);
          if (!Pnt3D.Equal(pnt3D6, pnt3D7))
          {
            if (Points[index].CodeType == 0)
            {
              if (CopiedPnt.Count > 1)
              {
                this.EntitiesG1.Add((eEntities) new ePolyline(CopiedPnt));
                CopiedPnt = new List<Pnt3D>();
              }
              eLine eLine = new eLine(pnt3D6, pnt3D7);
              if (Pnt3D.EqualXY(pnt3D6, pnt3D7))
              {
                if (pnt3D6.Z > pnt3D7.Z)
                  this.EntitiesPlunge.Add((eEntities) eLine);
                if (pnt3D6.Z < pnt3D7.Z)
                  this.EntitiesLeave.Add((eEntities) eLine);
              }
              else
                this.EntitiesG0.Add((eEntities) eLine);
            }
            if (Points[index].CodeType == 1)
            {
              if (Pnt3D.EqualXY(pnt3D6, pnt3D7))
              {
                eLine eLine = new eLine(pnt3D6, pnt3D7);
                if (pnt3D6.Z > pnt3D7.Z)
                  this.EntitiesPlunge.Add((eEntities) eLine);
                if (pnt3D6.Z < pnt3D7.Z)
                  this.EntitiesLeave.Add((eEntities) eLine);
              }
              if (Points[index - 1].CodeType == 0)
                CopiedPnt.Add(pnt3D6);
              CopiedPnt.Add(pnt3D7);
            }
            if (Points[index].CodeType == 2)
            {
              Pnt3D ArcCenter = new Pnt3D();
              double StartAngle = 0.0;
              double EndAngle = 0.0;
              if (Points[index].Radius > 0.0)
              {
                this.buVector_0.ArcWithTwoPointAndRadius(pnt3D6, pnt3D7, Math.Abs(Points[index].Radius), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              if (Points[index].Radius < 0.0)
              {
                this.buVector_0.ArcWithTwoPointAndRadius(pnt3D6, pnt3D7, Math.Abs(Points[index].Radius), true, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (EndAngle - StartAngle < 180.0)
                {
                  double num5 = StartAngle;
                  StartAngle = EndAngle;
                  EndAngle = num5;
                }
                if (StartAngle > EndAngle)
                  EndAngle += 360.0;
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              double Radius = Math.Abs(Points[index].Radius);
              if (Points[index].IJKValues.I != 0.0 | Points[index].IJKValues.J != 0.0 | Points[index].IJKValues.K != 0.0)
              {
                this.buVector_0.ArcWithIJK(pnt3D6, pnt3D7, Points[index].IJKValues.I, Points[index].IJKValues.J, Points[index].IJKValues.K, Points[index].CodeType, ref ArcCenter, ref Radius, ref StartAngle, ref EndAngle);
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              List<Pnt3D> Vertices = new List<Pnt3D>();
              this.buVector_0.ArcWithCenter(ArcCenter, Radius, StartAngle, EndAngle, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
              Vertices.Reverse();
              Pnt3D.Add(Vertices, ref CopiedPnt);
            }
            if (Points[index].CodeType == 3)
            {
              Pnt3D ArcCenter = new Pnt3D();
              double StartAngle = 0.0;
              double EndAngle = 0.0;
              if (Points[index].Radius > 0.0)
              {
                this.buVector_0.ArcWithTwoPointAndRadius(pnt3D6, pnt3D7, Math.Abs(Points[index].Radius), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              if (Points[index].Radius < 0.0)
              {
                this.buVector_0.ArcWithTwoPointAndRadius(pnt3D6, pnt3D7, Math.Abs(Points[index].Radius), false, new WorkPlane(), ref ArcCenter, ref StartAngle, ref EndAngle);
                if (EndAngle - StartAngle < 180.0)
                {
                  double num6 = StartAngle;
                  StartAngle = EndAngle;
                  EndAngle = num6;
                }
                if (StartAngle > EndAngle)
                  EndAngle += 360.0;
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              double Radius = Math.Abs(Points[index].Radius);
              if (Points[index].IJKValues.I != 0.0 | Points[index].IJKValues.J != 0.0 | Points[index].IJKValues.K != 0.0)
              {
                this.buVector_0.ArcWithIJK(pnt3D6, pnt3D7, Points[index].IJKValues.I, Points[index].IJKValues.J, Points[index].IJKValues.K, Points[index].CodeType, ref ArcCenter, ref Radius, ref StartAngle, ref EndAngle);
                if (pnt3D6.Z == pnt3D7.Z)
                  ArcCenter.Z = pnt3D6.Z;
              }
              List<Pnt3D> Vertices = new List<Pnt3D>();
              this.buVector_0.ArcWithCenter(ArcCenter, Radius, StartAngle, EndAngle, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
              Pnt3D.Add(Vertices, ref CopiedPnt);
            }
            Pnt3D pnt3D8 = new Pnt3D(pnt3D7);
          }
        }
        if (CopiedPnt.Count <= 1)
          return;
        this.EntitiesG1.Add((eEntities) new ePolyline(CopiedPnt));
        CopiedPnt = new List<Pnt3D>();
      }
      catch (Exception ex)
      {
        string str = GCodes.Count.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
      }
    }
  }

  public class Dxf
  {
    public Pnt3D MaxPnt = new Pnt3D();
    public Pnt3D MinPnt = new Pnt3D();
    internal double double_0;
    internal double double_1;
    private string string_0 = "SEO-DXF.Ver:1.2.0.1-1906ZG";
    public Color[] ColorCode = new Color[256 /*0x0100*/];
    public string Key;
    public bool ArcToLine;
    public double ArcToLineLength;
    public string LayerName;
    public Color LayerColor;
    public float PointThicknessOffset = 1f;
    public bool TextToUpperCase = false;
    public bool OnlyPoints = false;
    public bool ArcToLineWithRadiusLimitEnable = true;
    public double ArcToLineRadiusLimit = 0.9;
    public double ArcToLineWithRadiusType = 0.0;
    public Pnt3D BoxSizeMax = new Pnt3D();
    public Pnt3D BoxSizeMin = new Pnt3D();
    public int LayerType;
    public string LayerFilterChars = "";
    public List<DxfText> DXFText = new List<DxfText>();
    public Vec3D UCSOffset = new Vec3D();
    public Color ViewportBackColor = Color.Yellow;
    public entityBSplineType SplineType = entityBSplineType.BSplineQuadratic;
    internal double double_2 = 0.001;
    private bool bool_0 = false;
    private bool bool_1 = true;
    private bool bool_2 = true;
    public buFile.Dxf L_Data = (buFile.Dxf) null;
    public List<eEntities> BlockEntityList = new List<eEntities>();
    internal NumberFormatInfo numberFormatInfo_0 = new CultureInfo("en-US", false).NumberFormat;
    internal List<string> list_0 = new List<string>();
    private CultureInfo cultureInfo_0 = new CultureInfo("en-US", false);

    public Dxf()
    {
      if (!buVector.smethod_0(nameof (Dxf)))
        throw new RegisterException(nameof (Dxf));
      this.ColorCode[0] = Color.Black;
      this.ColorCode[1] = Color.DarkGray;
      this.ColorCode[2] = Color.Yellow;
      this.ColorCode[3] = Color.Green;
      this.ColorCode[4] = Color.Blue;
      this.ColorCode[5] = Color.Cyan;
      this.ColorCode[6] = Color.Gray;
      this.ColorCode[7] = Color.Red;
      this.ColorCode[8] = Color.Brown;
      this.ColorCode[9] = Color.Lime;
      this.ColorCode[10] = Color.Orange;
      this.ColorCode[11] = Color.Tan;
      this.ColorCode[12] = Color.LightBlue;
      this.ColorCode[13] = Color.Magenta;
      this.ColorCode[14] = Color.Purple;
      this.ColorCode[15] = Color.Salmon;
      this.ColorCode[16 /*0x10*/] = Color.Sienna;
      this.ColorCode[17] = Color.Thistle;
      this.ColorCode[18] = Color.Wheat;
      this.ColorCode[19] = Color.White;
      this.ColorCode[20] = Color.Turquoise;
    }

    public Dxf(Pnt3D MinP, Pnt3D MaxP)
    {
      if (buSystem.strIDScale != "IUTvstjutru784gfsbtNYRJGdrebgre75RFSDVCSD-?YT?_?.<+!%+^&GSDGDSGA5&bdfbdrb" | buSystem.strTest != "AtWR65*-vftyfc74dafqw124fFSTEWFEEVAEARHGFVSDVERGVd89eet98rbFREGRAVRETTBYWFVDetrqVVR" | buSystem.valCheckFactor != 97245796635758.766 | buSystem.valMidPointConstant != -598745789953.89551)
        throw new RegisterException("buVector");
      this.MaxPnt = new Pnt3D(MaxP);
      this.MinPnt = new Pnt3D(MinP);
      this.ColorCode[0] = Color.Black;
      this.ColorCode[1] = Color.Red;
      this.ColorCode[2] = Color.Yellow;
      this.ColorCode[3] = Color.Green;
      this.ColorCode[4] = Color.Blue;
      this.ColorCode[5] = Color.Cyan;
      this.ColorCode[6] = Color.Gray;
      this.ColorCode[7] = Color.Pink;
      this.ColorCode[8] = Color.Brown;
      this.ColorCode[9] = Color.Lime;
      this.ColorCode[10] = Color.Orange;
      this.ColorCode[11] = Color.Tan;
      this.ColorCode[12] = Color.LightBlue;
      this.ColorCode[13] = Color.Magenta;
      this.ColorCode[14] = Color.Purple;
      this.ColorCode[15] = Color.Salmon;
      this.ColorCode[16 /*0x10*/] = Color.Sienna;
      this.ColorCode[17] = Color.Thistle;
      this.ColorCode[18] = Color.Wheat;
      this.ColorCode[19] = Color.White;
      this.ColorCode[20] = Color.Turquoise;
    }

    public void WriteDXF(string FileName, List<eEntities> RefEntities)
    {
      try
      {
        TextWriter text = (TextWriter) File.CreateText(FileName);
        text.WriteLine("  0");
        text.WriteLine("SECTION");
        text.WriteLine("  2");
        text.WriteLine("HEADER");
        text.WriteLine("  9");
        text.WriteLine("$LIMMIN");
        text.WriteLine(" 10");
        text.WriteLine(this.MinPnt.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
        text.WriteLine(" 20");
        text.WriteLine(this.MinPnt.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
        text.WriteLine("  9");
        text.WriteLine("$LIMMAX");
        text.WriteLine(" 10");
        text.WriteLine(this.MaxPnt.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
        text.WriteLine(" 20");
        text.WriteLine(this.MaxPnt.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
        text.WriteLine("  0");
        text.WriteLine("ENDSEC");
        text.WriteLine("  0");
        text.WriteLine("SECTION");
        text.WriteLine("  2");
        text.WriteLine("ENTITIES");
        text.WriteLine("  0");
        for (int index1 = 0; index1 <= RefEntities.Count - 1; ++index1)
        {
          if (RefEntities[index1].GetType() == typeof (eLine))
          {
            text.WriteLine("LINE");
            text.WriteLine("  8");
            text.WriteLine("0");
            text.WriteLine(" 62");
            text.WriteLine("13");
            text.WriteLine(" 10");
            text.WriteLine(((eLine) RefEntities[index1]).StartPoint.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 20");
            text.WriteLine(((eLine) RefEntities[index1]).StartPoint.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 30");
            text.WriteLine(((eLine) RefEntities[index1]).StartPoint.Z.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 11");
            text.WriteLine(((eLine) RefEntities[index1]).EndPoint.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 21");
            text.WriteLine(((eLine) RefEntities[index1]).EndPoint.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 31");
            text.WriteLine(((eLine) RefEntities[index1]).EndPoint.Z.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine("  0");
          }
          if (RefEntities[index1].GetType() == typeof (eArc))
          {
            text.WriteLine("ARC");
            text.WriteLine("  8");
            text.WriteLine("0");
            text.WriteLine(" 62");
            text.WriteLine("13");
            text.WriteLine(" 10");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 20");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 30");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.Z.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 40");
            text.WriteLine(((eCircle) RefEntities[index1]).Radius.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 50");
            text.WriteLine(((eArc) RefEntities[index1]).StartAngle.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 51");
            text.WriteLine(((eArc) RefEntities[index1]).EndAngle.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine("  0");
          }
          if (RefEntities[index1].GetType() == typeof (eCircle))
          {
            text.WriteLine("CIRCLE");
            text.WriteLine("  8");
            text.WriteLine("0");
            text.WriteLine(" 62");
            text.WriteLine("13");
            text.WriteLine(" 10");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 20");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 30");
            text.WriteLine(((ePlaneEntities) RefEntities[index1]).CenterPoint.Z.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine(" 40");
            text.WriteLine(((eCircle) RefEntities[index1]).Radius.ToString("f10", (IFormatProvider) this.cultureInfo_0));
            text.WriteLine("  0");
          }
          if (RefEntities[index1].GetType() == typeof (ePolyline) | RefEntities[index1].GetType() == typeof (eBSpline) | RefEntities[index1].GetType() == typeof (eBezeir))
          {
            text.WriteLine("POLYLINE");
            text.WriteLine("  8");
            text.WriteLine("0");
            text.WriteLine(" 66");
            text.WriteLine("1");
            text.WriteLine("  70");
            text.WriteLine("0");
            text.WriteLine("  0");
            for (int index2 = 0; index2 <= RefEntities[index1].Vertice.Count - 1; ++index2)
            {
              text.WriteLine("VERTEX");
              text.WriteLine("  8");
              text.WriteLine("0");
              text.WriteLine(" 10");
              text.WriteLine(RefEntities[index1].Vertice[index2].X.ToString("f10", (IFormatProvider) this.cultureInfo_0));
              text.WriteLine(" 20");
              text.WriteLine(RefEntities[index1].Vertice[index2].Y.ToString("f10", (IFormatProvider) this.cultureInfo_0));
              text.WriteLine(" 30");
              text.WriteLine(RefEntities[index1].Vertice[index2].Z.ToString("f10", (IFormatProvider) this.cultureInfo_0));
              text.WriteLine("  0");
            }
            text.WriteLine("SEQEND");
            text.WriteLine("  0");
          }
        }
        text.WriteLine("ENDSEC");
        text.WriteLine("  0");
        text.WriteLine("EOF");
        text.Close();
      }
      catch (Exception ex)
      {
        string str = "FileName: " + FileName.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
      }
    }

    public void ReadDXF(
      string FileName,
      ref List<eEntities> RefEntities,
      ref List<LayerBase> Layers)
    {
      try
      {
        bool flag1 = false;
        bool flag2 = false;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;
        Pnt3D pnt3D1 = new Pnt3D();
        Pnt3D pnt3D2 = new Pnt3D();
        Pnt3D pnt3D3 = new Pnt3D();
        Pnt3D pnt3D4 = new Pnt3D();
        Color color_0 = Color.Black;
        float Thickness = 1f;
        bool flag3 = false;
        bool bool_0 = false;
        double num5 = 0.0;
        double num6 = 0.0;
        double double_4_1 = 0.0;
        double num7 = 0.0;
        double num8 = 0.0;
        double num9 = 0.0;
        float float_0 = 1f;
        double x = 0.0;
        double y1 = 0.0;
        double z1 = 0.0;
        double num10 = 0.0;
        double y2 = 0.0;
        double z2 = 0.0;
        double double_2_1 = 1.0;
        double double_0_1 = 1.0;
        double double_5_1 = 0.0;
        string string_1 = "";
        List<Pnt3D> pnt3DList = new List<Pnt3D>();
        List<double> doubleList1 = new List<double>();
        List<double> doubleList2 = new List<double>();
        List<double> doubleList3 = new List<double>();
        List<double> list_5 = new List<double>();
        List<double> list_0_1 = new List<double>();
        List<double> list_3 = new List<double>();
        List<double> list_7 = new List<double>();
        List<double> list_2 = new List<double>();
        List<double> list_10 = new List<double>();
        List<double> list_11 = new List<double>();
        List<double> list_9 = new List<double>();
        List<double> list_6 = new List<double>();
        List<int> list_1_1 = new List<int>();
        List<string> list_8 = new List<string>();
        List<int> list_4 = new List<int>();
        this.numberFormatInfo_0.NumberDecimalSeparator = ".";
        int num11 = 0;
        string str1 = "";
        float num12 = 1f;
        this.double_2 = 0.0001;
        int num13 = -1;
        int length = this.LayerFilterChars.Length;
        FileInfo fileInfo = new FileInfo(FileName);
        this.list_0 = new List<string>();
        if (fileInfo.Exists)
        {
          this.list_0.AddRange((IEnumerable<string>) File.ReadLines(fileInfo.FullName, Encoding.GetEncoding(1254)).ToList<string>());
          num11 = this.list_0.Count;
        }
        RefEntities = new List<eEntities>();
        this.BlockEntityList = new List<eEntities>();
        Layers.Clear();
        bool flag4 = false;
        string str2 = "";
        List<double> doubleList4 = new List<double>();
        List<double> doubleList5 = new List<double>();
        List<double> doubleList6 = new List<double>();
        List<double> doubleList7 = new List<double>();
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        this.DXFText.Clear();
        for (int index1 = 1; index1 <= num11 - 1; ++index1)
        {
          if (this.list_0[index1] == "ENTITIES")
            flag2 = true;
          if (this.list_0[index1] == "$UCSORG")
          {
            this.UCSOffset.X = Class30.smethod_256(this, this.list_0[index1 + 2]);
            this.UCSOffset.Y = Class30.smethod_256(this, this.list_0[index1 + 4]);
            this.UCSOffset.Z = Class30.smethod_256(this, this.list_0[index1 + 6]);
          }
          if (this.list_0[index1] == "$EXTMIN")
          {
            pnt3D1.X = Class30.smethod_256(this, this.list_0[index1 + 2]);
            pnt3D1.Y = Class30.smethod_256(this, this.list_0[index1 + 4]);
          }
          if (this.list_0[index1] == "$EXTMAX")
          {
            pnt3D2.X = Class30.smethod_256(this, this.list_0[index1 + 2]);
            pnt3D2.Y = Class30.smethod_256(this, this.list_0[index1 + 4]);
          }
          if (this.list_0[index1] == "BLOCK")
          {
            flag4 = true;
            flag1 = true;
          }
          if (this.list_0[index1] == "ENDBLK")
            flag1 = false;
          if (flag1 & !flag2 & flag4 && this.list_0[index1] == "  2")
          {
            flag4 = false;
            str2 = this.list_0[index1 + 1];
          }
          if (this.list_0[index1] == "LAYER")
          {
            LayerBase layerBase_0 = new LayerBase();
            Color black = Color.Black;
            flag3 = Class30.smethod_93(ref black, index1, this, ref layerBase_0);
            layerBase_0.LayerColor = black;
            if (layerBase_0.LayerColor == this.ViewportBackColor)
              layerBase_0.LayerColor = buImage.InvertColor(layerBase_0.LayerColor);
            if (layerBase_0.Name.Length > 0)
              Layers.Add(layerBase_0);
          }
          if (this.list_0[index1] == "LINE" & !this.OnlyPoints)
          {
            if (!(flag3 = Class30.smethod_222(ref z2, ref x, this, ref y1, ref color_0, ref num10, ref str1, ref z1, index1, ref y2)) && !(flag3 = Class30.smethod_79(ref z1, ref y1, this, ref z2, ref color_0, index1, ref str1, ref num10, ref x, ref y2)))
              flag3 = Class30.smethod_43(index1, ref color_0, ref z2, this, ref num10, ref y1, ref str1, ref y2, ref x, ref z1);
            ++num13;
            Thickness = num12;
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            eEntities eEntities = (eEntities) new eLine(new Pnt3D(x, y1, z1), new Pnt3D(num10, y2, z2), Thickness, color_0);
            for (int index2 = 0; index2 <= Layers.Count - 1; ++index2)
            {
              if (Layers[index2].Name == str1)
                eEntities.LayerIndex = index2;
            }
            bool flag5 = true;
            if (this.LayerType == 1 & str1.Length >= length & Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, length) != this.LayerFilterChars)
              flag5 = false;
            if (flag5)
            {
              if (!flag1 & flag2)
              {
                ++num1;
                RefEntities.Add(eEntities);
              }
              if (flag1 & !flag2)
              {
                ++num1;
                eEntities.Tag = str2;
                this.BlockEntityList.Add(eEntities);
              }
            }
          }
          if (this.list_0[index1] == "LWPOLYLINE" & !this.OnlyPoints)
          {
            List<eEntities> list_0_2 = new List<eEntities>();
            Class30.smethod_221(ref float_0, this, index1, ref color_0, ref str1, ref list_0_2, ref bool_0);
            for (int index3 = 0; index3 <= list_0_2.Count - 1; ++index3)
            {
              eEntities copiedEnt = new eEntities();
              eEntities.CopyEntity(list_0_2[index3], ref copiedEnt);
              if (copiedEnt.Vertice.Count > 0)
                RefEntities.Add(copiedEnt);
            }
          }
          if (this.list_0[index1] == "SPLINE" & !this.OnlyPoints)
          {
            List<Pnt3D> list_0_3 = new List<Pnt3D>();
            List<double> list_1_2 = new List<double>();
            double double_0_2 = 1.0;
            Class30.smethod_220(ref float_0, ref list_0_3, this, ref bool_0, ref list_1_2, ref color_0, index1, ref double_0_2, ref str1);
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            if (list_0_3.Count > 0)
            {
              eEntities eEntities = (eEntities) new eBSpline(list_0_3, float_0, color_0, false, this.SplineType);
              for (int index4 = 0; index4 <= Layers.Count - 1; ++index4)
              {
                if (Layers[index4].Name == str1)
                  eEntities.LayerIndex = index4;
              }
              ++num13;
              bool flag6 = true;
              if (this.LayerType == 1 & str1.Length >= length & Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, length) != this.LayerFilterChars)
                flag6 = false;
              if (flag6)
              {
                if (!flag1 & flag2)
                {
                  ++num4;
                  RefEntities.Add(eEntities);
                }
                if (flag1 & !flag2)
                {
                  eEntities.Tag = str2;
                  this.BlockEntityList.Add(eEntities);
                }
              }
            }
          }
          if (this.list_0[index1] == "CIRCLE" & !this.OnlyPoints)
          {
            Class30.smethod_254(ref color_0, ref num5, ref str1, index1, this, ref num6, ref num9);
            ++num13;
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            eEntities eEntities = (eEntities) new eCircle(new Pnt3D(num5, num6, 0.0), num9, new WorkPlane(), Thickness, color_0);
            bool flag7 = true;
            if (this.ArcToLine)
            {
              List<Pnt3D> list_0_4 = new List<Pnt3D>();
              Class30.smethod_104(360.0, this.ArcToLineLength, ref list_0_4, this, num5, num9, 0.0, num6);
              eEntities = (eEntities) new ePolyline(list_0_4, Thickness, color_0);
            }
            for (int index5 = 0; index5 <= Layers.Count - 1; ++index5)
            {
              if (Layers[index5].Name == str1)
                eEntities.LayerIndex = index5;
            }
            if (this.LayerType == 1 & str1.Length >= length & Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, length) != this.LayerFilterChars)
              flag7 = false;
            if (flag7)
            {
              ++num2;
              if (!flag1 & flag2 && eEntities.Vertice.Count > 0)
                RefEntities.Add(eEntities);
              if (flag1 & !flag2)
              {
                ++num1;
                eEntities.Tag = str2;
                this.BlockEntityList.Add(eEntities);
              }
            }
          }
          if (this.list_0[index1] == "ARC" & !this.OnlyPoints)
          {
            Vec3D vec3D_0 = new Vec3D(0.0, 0.0, 1.0);
            if (!(flag3 = Class30.smethod_206(ref num8, ref num9, ref num7, this, ref color_0, ref str1, ref vec3D_0, ref num6, ref double_4_1, ref num5, index1)))
              flag3 = Class30.smethod_250(ref num6, index1, ref str1, ref num7, ref color_0, this, ref num5, ref num8, ref num9);
            ++num13;
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            WorkPlane Plane = new WorkPlane();
            if (vec3D_0.X != 0.0)
            {
              Plane = new WorkPlane(planeType.YZ, (int) vec3D_0.X);
              double num14 = num5;
              double num15 = num6;
              double num16 = double_4_1;
              num6 = num14;
              double_4_1 = num15;
              num5 = num16;
              if (vec3D_0.X < 0.0)
              {
                num7 -= 90.0;
                num8 -= 90.0;
                num5 *= -1.0;
                num6 *= -1.0;
                double_4_1 *= 1.0;
              }
            }
            if (vec3D_0.Y != 0.0)
              Plane = new WorkPlane(planeType.XZ, (int) vec3D_0.Y);
            eEntities CalcEntity = (eEntities) new eArc(new Pnt3D(num5, num6, double_4_1), num9, num7, num8, Plane, Thickness, color_0);
            if (vec3D_0.Z == -1.0)
              buAppCalc.cVector.Mirror(new Pnt3D(0.0, num6, 0.0), new Pnt3D(0.0, 10.0, 0.0), new WorkPlane(), 0.0, ref CalcEntity);
            if (this.ArcToLine)
            {
              List<Pnt3D> list_0_5 = new List<Pnt3D>();
              Class30.smethod_104(num8, this.ArcToLineLength, ref list_0_5, this, num5, num9, num7, num6);
              CalcEntity = (eEntities) new ePolyline(list_0_5, Thickness, color_0);
            }
            for (int index6 = 0; index6 <= Layers.Count - 1; ++index6)
            {
              if (Layers[index6].Name == str1)
                CalcEntity.LayerIndex = index6;
            }
            bool flag8 = true;
            if (this.LayerType == 1 & str1.Length >= length & Layers.Count > 0 && Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, length) != this.LayerFilterChars)
              flag8 = false;
            if (flag8)
            {
              if (!flag1 & flag2)
              {
                ++num3;
                if (CalcEntity.Vertice.Count > 0)
                {
                  if (((eArc) CalcEntity).EndAngle - ((eArc) CalcEntity).StartAngle > 180.0)
                  {
                    double num17 = (((eArc) CalcEntity).EndAngle + ((eArc) CalcEntity).StartAngle) / 2.0;
                    eEntities eEntities = (eEntities) new eArc(new Pnt3D(num5, num6, 0.0), num9, num7, num17, new WorkPlane(), Thickness, color_0);
                    RefEntities.Add(eEntities);
                    if (num17 > 360.0 & num8 > 360.0)
                    {
                      num17 -= 360.0;
                      num8 -= 360.0;
                    }
                    CalcEntity = (eEntities) new eArc(new Pnt3D(num5, num6, 0.0), num9, num17, num8, new WorkPlane(), Thickness, color_0);
                    RefEntities.Add(CalcEntity);
                  }
                  else
                    RefEntities.Add(CalcEntity);
                }
              }
              if (flag1 & !flag2)
              {
                ++num3;
                CalcEntity.Tag = str2;
                if (CalcEntity.Vertice.Count > 0)
                  this.BlockEntityList.Add(CalcEntity);
              }
            }
          }
          if (this.list_0[index1] == "POLYLINE" & !this.OnlyPoints)
          {
            Class30.smethod_82(ref list_0_1, ref list_1_1, this, ref list_2, ref list_3, ref list_4, ref list_5, ref list_6, ref list_7, ref list_8, index1, ref list_9, ref list_10, ref list_11);
            if (list_4.Count > 0)
            {
              bool flag9 = true;
              for (int index7 = 0; index7 <= list_4.Count - 1; ++index7)
              {
                if (list_4[index7] != 1)
                {
                  flag9 = false;
                  index7 = list_4.Count + 1;
                }
              }
              if (color_0 == this.ViewportBackColor)
                color_0 = buImage.InvertColor(color_0);
              if (flag9)
              {
                List<Pnt3D> Vertices = new List<Pnt3D>();
                for (int index8 = 0; index8 <= list_5.Count - 1; ++index8)
                  Vertices.Add(new Pnt3D(list_5[index8], list_0_1[index8]));
                Vertices.Add(new Pnt3D(list_3[list_3.Count - 1], list_7[list_7.Count - 1]));
                eEntities eEntities = (eEntities) new ePolyline(Vertices, Thickness, color_0);
                if (Vertices.Count == 2 && buCompare.EQ(Vertices[0], Vertices[1]))
                  eEntities = (eEntities) new ePoint(new Pnt3D(Vertices[0]), Thickness + this.PointThicknessOffset, color_0);
                for (int index9 = 0; index9 <= Layers.Count - 1; ++index9)
                {
                  for (int index10 = 0; index10 <= list_8.Count - 1; ++index10)
                  {
                    if (Layers[index9].Name == list_8[index10])
                      eEntities.LayerIndex = index9;
                  }
                }
                if (flag2)
                {
                  RefEntities.Add(eEntities);
                }
                else
                {
                  ++num1;
                  eEntities.Tag = str2;
                  this.BlockEntityList.Add(eEntities);
                }
              }
              if (!flag9)
              {
                for (int index11 = 0; index11 <= list_4.Count - 1; ++index11)
                {
                  if (list_4[index11] == 10)
                  {
                    eEntities eEntities = (eEntities) new ePoint(new Pnt3D(list_5[index11], list_0_1[index11], 0.0), Thickness + this.PointThicknessOffset, color_0);
                    for (int index12 = 0; index12 <= Layers.Count - 1; ++index12)
                    {
                      for (int index13 = 0; index13 <= list_8.Count - 1; ++index13)
                      {
                        if (Layers[index12].Name == list_8[index13])
                          eEntities.LayerIndex = index12;
                      }
                    }
                    if (flag2)
                    {
                      RefEntities.Add(eEntities);
                    }
                    else
                    {
                      ++num1;
                      eEntities.Tag = str2;
                      this.BlockEntityList.Add(eEntities);
                    }
                  }
                  if (list_4[index11] == 1)
                  {
                    eEntities eEntities = (eEntities) new eLine(new Pnt3D(list_5[index11], list_0_1[index11], 0.0), new Pnt3D(list_3[index11], list_7[index11], 0.0), Thickness, color_0);
                    for (int index14 = 0; index14 <= Layers.Count - 1; ++index14)
                    {
                      for (int index15 = 0; index15 <= list_8.Count - 1; ++index15)
                      {
                        if (Layers[index14].Name == list_8[index15])
                          eEntities.LayerIndex = index14;
                      }
                    }
                    if (flag2)
                    {
                      ++num1;
                      RefEntities.Add(eEntities);
                    }
                    else
                    {
                      ++num1;
                      eEntities.Tag = str2;
                      this.BlockEntityList.Add(eEntities);
                    }
                  }
                  if (list_4[index11] == 3)
                  {
                    eEntities eEntities = (eEntities) new eArc(new Pnt3D(list_2[index11], list_10[index11], 0.0), list_11[index11], list_9[index11], list_6[index11], new WorkPlane(), Thickness, color_0);
                    for (int index16 = 0; index16 <= Layers.Count - 1; ++index16)
                    {
                      for (int index17 = 0; index17 <= list_8.Count - 1; ++index17)
                      {
                        if (Layers[index16].Name == list_8[index17])
                          eEntities.LayerIndex = index16;
                      }
                    }
                    if (this.ArcToLine)
                    {
                      List<Pnt3D> list_0_6 = new List<Pnt3D>();
                      double double_2_2 = list_2[index11];
                      double double_5_2 = list_10[index11];
                      double double_3 = list_11[index11];
                      double double_4_2 = list_9[index11];
                      Class30.smethod_104(list_6[index11], this.ArcToLineLength, ref list_0_6, this, double_2_2, double_3, double_4_2, double_5_2);
                    }
                    if (flag2)
                    {
                      ++num3;
                      RefEntities.Add(eEntities);
                    }
                    else
                    {
                      ++num3;
                      eEntities.Tag = str2;
                      this.BlockEntityList.Add(eEntities);
                    }
                  }
                }
              }
            }
          }
          if (this.list_0[index1] == "INSERT" & !flag1 & flag2 & !this.OnlyPoints)
          {
            Class30.smethod_56(ref double_0_1, ref str1, ref x, ref double_2_1, index1, ref string_1, ref z1, ref y1, this, ref double_5_1, ref color_0);
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            if (this.BlockEntityList.Count > 0)
            {
              for (int index18 = 0; index18 <= this.BlockEntityList.Count - 1; ++index18)
              {
                if (this.BlockEntityList[index18].Tag == string_1)
                {
                  if (this.BlockEntityList[index18].GetType() == typeof (eLine))
                  {
                    Pnt3D StartPoint = new Pnt3D(((eLine) this.BlockEntityList[index18]).StartPoint);
                    Pnt3D EndPoint = new Pnt3D(((eLine) this.BlockEntityList[index18]).EndPoint);
                    StartPoint.X *= double_2_1;
                    StartPoint.Y *= double_0_1;
                    EndPoint.X *= double_2_1;
                    EndPoint.Y *= double_0_1;
                    double num18 = Math.Sqrt(StartPoint.X * StartPoint.X + StartPoint.Y * StartPoint.Y);
                    double double_0_3 = Class30.smethod_149(this, StartPoint.X, StartPoint.Y, 0.0, 0.0) + double_5_1;
                    StartPoint.X = num18 * Math.Cos(Class30.smethod_204(this, double_0_3)) + x;
                    StartPoint.Y = num18 * Math.Sin(Class30.smethod_204(this, double_0_3)) + y1;
                    double num19 = Math.Sqrt(EndPoint.X * EndPoint.X + EndPoint.Y * EndPoint.Y);
                    double double_0_4 = Class30.smethod_149(this, EndPoint.X, EndPoint.Y, 0.0, 0.0) + double_5_1;
                    EndPoint.X = num19 * Math.Cos(Class30.smethod_204(this, double_0_4)) + x;
                    EndPoint.Y = num19 * Math.Sin(Class30.smethod_204(this, double_0_4)) + y1;
                    eEntities eEntities = (eEntities) new eLine(StartPoint, EndPoint, Thickness, color_0);
                    ++num1;
                    RefEntities.Add(eEntities);
                  }
                  if (this.BlockEntityList[index18].GetType() == typeof (eArc))
                  {
                    Pnt3D CenterPoint = new Pnt3D(((ePlaneEntities) this.BlockEntityList[index18]).CenterPoint);
                    num9 = ((eCircle) this.BlockEntityList[index18]).Radius;
                    double startAngle = ((eArc) this.BlockEntityList[index18]).StartAngle;
                    double endAngle = ((eArc) this.BlockEntityList[index18]).EndAngle;
                    CenterPoint.X *= double_2_1;
                    CenterPoint.Y *= double_0_1;
                    num9 *= double_2_1;
                    double num20 = Math.Sqrt(CenterPoint.X * CenterPoint.X + CenterPoint.Y * CenterPoint.Y);
                    double double_0_5 = Class30.smethod_149(this, CenterPoint.X, CenterPoint.Y, 0.0, 0.0) + double_5_1;
                    CenterPoint.X = num20 * Math.Cos(Class30.smethod_204(this, double_0_5)) + x;
                    CenterPoint.Y = num20 * Math.Sin(Class30.smethod_204(this, double_0_5)) + y1;
                    num7 = startAngle + double_5_1;
                    num8 = num7 + double_5_1;
                    eEntities eEntities = (eEntities) new eArc(CenterPoint, num9, num7, num8, new WorkPlane(), Thickness, color_0);
                    ++num3;
                    RefEntities.Add(eEntities);
                  }
                  if (this.BlockEntityList[index18].GetType() == typeof (ePolyline))
                  {
                    List<Pnt3D> Vertices = new List<Pnt3D>();
                    for (int index19 = 0; index19 < this.BlockEntityList[index18].Vertice.Count; ++index19)
                    {
                      num10 = this.BlockEntityList[index18].Vertice[index19].X * double_2_1;
                      double double_1 = this.BlockEntityList[index18].Vertice[index19].Y * double_0_1;
                      double num21 = Math.Sqrt(num10 * num10 + double_1 * double_1);
                      double double_0_6 = Class30.smethod_149(this, num10, double_1, 0.0, 0.0) + double_5_1;
                      num10 = num21 * Math.Cos(Class30.smethod_204(this, double_0_6)) + x;
                      y2 = num21 * Math.Sin(Class30.smethod_204(this, double_0_6)) + y1;
                      Vertices.Add(new Pnt3D(num10, y2));
                    }
                    eEntities eEntities = (eEntities) new ePolyline(Vertices, Thickness, color_0);
                    ++num4;
                    RefEntities.Add(eEntities);
                  }
                  if (this.BlockEntityList[index18].GetType() == typeof (ePoint))
                  {
                    Pnt3D StartPoint = new Pnt3D(((ePoint) this.BlockEntityList[index18]).StartPoint);
                    StartPoint.X += x;
                    StartPoint.Y += y1;
                    eEntities eEntities = (eEntities) new ePoint(StartPoint, Thickness, color_0);
                    eEntities.geoAngleXY = this.BlockEntityList[index18].geoAngleXY;
                    eEntities.auxText = this.BlockEntityList[index18].auxText;
                    eEntities.auxValue = this.BlockEntityList[index18].auxValue;
                    ++num1;
                    RefEntities.Add(eEntities);
                  }
                }
              }
            }
          }
          if (this.list_0[index1] == "TEXT" & !this.OnlyPoints)
          {
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            DxfText dxfText = new DxfText();
            ref double local1 = ref dxfText.Rotation;
            ref double local2 = ref dxfText.Height;
            ref string local3 = ref dxfText.Text;
            ref Color local4 = ref dxfText.Color;
            ref string local5 = ref dxfText.Layer;
            bool flag10 = Class30.smethod_278(index1, ref y1, ref local4, ref x, ref local5, this, ref local1, ref z1, ref local3, ref local2);
            dxfText.StartPoint = new Pnt3D(x, y1, z1);
            ++num13;
            if (this.TextToUpperCase)
              dxfText.Text = dxfText.Text.ToUpper();
            if (flag10)
              this.DXFText.Add(dxfText);
          }
          if (this.list_0[index1] == "POINT")
          {
            double double_4_3 = 0.0;
            double double_2_3 = 0.0;
            string string_0 = "";
            flag3 = Class30.smethod_70(ref y1, ref x, ref string_0, ref str1, ref color_0, ref double_2_3, ref z1, this, ref double_4_3, index1);
            ++num13;
            Thickness = num12;
            if (color_0 == this.ViewportBackColor)
              color_0 = buImage.InvertColor(color_0);
            eEntities eEntities = (eEntities) new ePoint(new Pnt3D(x, y1, z1), Thickness, color_0);
            eEntities.auxValue = double_4_3;
            eEntities.geoAngleXY = double_2_3;
            eEntities.auxText = string_0;
            for (int index20 = 0; index20 <= Layers.Count - 1; ++index20)
            {
              if (Layers[index20].Name == str1)
                eEntities.LayerIndex = index20;
            }
            bool flag11 = true;
            if (this.LayerType == 1 & str1.Length >= length & Layers.Count > 0 && Layers[Layers.Count - 1].Name.Substring(0, length) != this.LayerFilterChars)
              flag11 = false;
            if (flag11)
            {
              if (!flag1 & flag2)
              {
                ++num1;
                RefEntities.Add(eEntities);
              }
              if (flag1 & !flag2)
              {
                ++num1;
                eEntities.Tag = str2;
                this.BlockEntityList.Add(eEntities);
              }
            }
          }
        }
        if (this.BlockEntityList.Count > 0)
        {
          int num22 = 0;
          while (num22 <= this.BlockEntityList.Count - 1)
            ++num22;
        }
        buAppCalc.cVector.BoxSizeCalculate(RefEntities, ref this.BoxSizeMin, ref this.BoxSizeMax);
      }
      catch (Exception ex)
      {
        string str = "FileName: " + FileName.ToString();
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
      }
    }
  }

  [Serializable]
  public class Ply : buSerilization
  {
    public Ply()
    {
      if (!buVector.smethod_0("buPly"))
        throw new RegisterException("buPly");
    }

    public void ReadPly(string FileName, ref List<eEntities> Entities)
    {
      try
      {
        if (!new FileInfo(FileName).Exists)
          return;
        Entities.Clear();
        List<Pnt3D> vertices = new List<Pnt3D>();
        List<TriangleIndex> trianglesindex = new List<TriangleIndex>();
        bool bool_0 = false;
        int int_0 = 0;
        int int_1 = 0;
        FileStream input = File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        Class30.smethod_63(ref bool_0, this, ref int_0, ref int_1, new StreamReader((Stream) input));
        if (bool_0)
        {
          BinaryReader binaryReader = new BinaryReader((Stream) input);
          for (int index = 0; index <= int_0 - 1; ++index)
          {
            Pnt3D pnt3D = new Pnt3D((double) binaryReader.ReadSingle(), (double) binaryReader.ReadSingle(), (double) binaryReader.ReadSingle());
            vertices.Add(pnt3D);
          }
          for (int index = 0; index <= int_1 - 1; ++index)
          {
            int num = (int) binaryReader.ReadByte();
            TriangleIndex triangleIndex = new TriangleIndex(binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
            trianglesindex.Add(triangleIndex);
          }
        }
        else
        {
          StreamReader streamReader = new StreamReader((Stream) input);
          for (int index = 0; index <= int_0 - 1; ++index)
          {
            string[] strArray = streamReader.ReadLine().Split(' ');
            if (strArray != null)
            {
              double x = 0.0;
              double y = 0.0;
              double z = 0.0;
              if (strArray.Length >= 2)
              {
                x = double.Parse(strArray[0]);
                y = double.Parse(strArray[1]);
              }
              if (strArray.Length >= 3)
                z = double.Parse(strArray[2]);
              Pnt3D pnt3D = new Pnt3D(x, y, z);
              vertices.Add(pnt3D);
            }
          }
          for (int index = 0; index <= int_1 - 1; ++index)
          {
            string[] strArray = streamReader.ReadLine().Split(' ');
            if (strArray != null)
            {
              int v1 = 0;
              int v2 = 0;
              int v3 = 0;
              int result = 0;
              if (strArray.Length >= 4)
              {
                v1 = int.Parse(strArray[1]);
                v2 = int.Parse(strArray[2]);
                v3 = int.Parse(strArray[3]);
              }
              if (strArray.Length >= 5)
                int.TryParse(strArray[4], out result);
              TriangleIndex triangleIndex = new TriangleIndex(v1, v2, v3);
              trianglesindex.Add(triangleIndex);
            }
          }
        }
        if (!(trianglesindex.Count > 0 & vertices.Count > 0))
          return;
        eMesh eMesh = new eMesh(trianglesindex, vertices, Color.Gray);
        Entities.Add((eEntities) eMesh);
      }
      catch (Exception ex)
      {
      }
    }
  }

  public class PLYToSchematic : buSerilization
  {
    private static buFile.PLYToSchematic.Class21 smethod_0(
      buFile.PLYToSchematic.Class20 class20_0,
      BinaryReader binaryReader_0)
    {
      buFile.PLYToSchematic.Class21 class21_0 = new buFile.PLYToSchematic.Class21(class20_0.int_0, class20_0.int_1);
      float float_0 = 0.0f;
      float float_1 = 0.0f;
      float float_2 = 0.0f;
      byte byte_0 = byte.MaxValue;
      byte byte_1 = byte.MaxValue;
      byte byte_2 = byte.MaxValue;
      for (int index = 0; index < class20_0.int_0; ++index)
      {
        foreach (buFile.PLYToSchematic.Enum1 enum1 in class20_0.list_0)
        {
          switch (enum1)
          {
            case buFile.PLYToSchematic.Enum1.const_1:
              byte_0 = binaryReader_0.ReadByte();
              continue;
            case buFile.PLYToSchematic.Enum1.const_2:
              byte_1 = binaryReader_0.ReadByte();
              continue;
            case buFile.PLYToSchematic.Enum1.const_3:
              byte_2 = binaryReader_0.ReadByte();
              continue;
            case buFile.PLYToSchematic.Enum1.const_4:
              int num1 = (int) binaryReader_0.ReadByte();
              continue;
            case buFile.PLYToSchematic.Enum1.const_5:
              byte_0 = (byte) ((uint) binaryReader_0.ReadUInt16() >> 8);
              continue;
            case buFile.PLYToSchematic.Enum1.const_6:
              byte_1 = (byte) ((uint) binaryReader_0.ReadUInt16() >> 8);
              continue;
            case buFile.PLYToSchematic.Enum1.const_7:
              byte_2 = (byte) ((uint) binaryReader_0.ReadUInt16() >> 8);
              continue;
            case buFile.PLYToSchematic.Enum1.const_8:
              int num2 = (int) (byte) ((uint) binaryReader_0.ReadUInt16() >> 8);
              continue;
            case buFile.PLYToSchematic.Enum1.const_9:
              float_0 = binaryReader_0.ReadSingle();
              continue;
            case buFile.PLYToSchematic.Enum1.const_10:
              float_1 = binaryReader_0.ReadSingle();
              continue;
            case buFile.PLYToSchematic.Enum1.const_11:
              float_2 = binaryReader_0.ReadSingle();
              continue;
            case buFile.PLYToSchematic.Enum1.const_12:
              float_0 = (float) binaryReader_0.ReadDouble();
              continue;
            case buFile.PLYToSchematic.Enum1.const_13:
              float_1 = (float) binaryReader_0.ReadDouble();
              continue;
            case buFile.PLYToSchematic.Enum1.const_14:
              float_2 = (float) binaryReader_0.ReadDouble();
              continue;
            case buFile.PLYToSchematic.Enum1.const_15:
              int num3 = (int) binaryReader_0.ReadByte();
              continue;
            case buFile.PLYToSchematic.Enum1.const_16:
              binaryReader_0.BaseStream.Position += 2L;
              continue;
            case buFile.PLYToSchematic.Enum1.const_17:
              binaryReader_0.BaseStream.Position += 4L;
              continue;
            case buFile.PLYToSchematic.Enum1.const_18:
              binaryReader_0.BaseStream.Position += 8L;
              continue;
            default:
              continue;
          }
        }
        Class30.smethod_172(class21_0, float_0, float_1, float_2, byte_0, byte_1, byte_2);
      }
      return class21_0;
    }

    public PLYToSchematic(string path, int scale)
    {
      FileStream input = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
      buFile.PLYToSchematic.Class20 class20_0 = Class30.smethod_270(new StreamReader((Stream) input));
      buFile.PLYToSchematic.Class21 class21 = class20_0.bool_0 ? buFile.PLYToSchematic.smethod_0(class20_0, new BinaryReader((Stream) input)) : Class30.smethod_151(new StreamReader((Stream) input), class20_0);
    }

    internal enum Enum1
    {
      const_0,
      const_1,
      const_2,
      const_3,
      const_4,
      const_5,
      const_6,
      const_7,
      const_8,
      const_9,
      const_10,
      const_11,
      const_12,
      const_13,
      const_14,
      const_15,
      const_16,
      const_17,
      const_18,
    }

    internal class Class20
    {
      public List<buFile.PLYToSchematic.Enum1> list_0 = new List<buFile.PLYToSchematic.Enum1>();
      public int int_0 = -1;
      public int int_1 = -1;
      public bool bool_0 = true;
    }

    internal class Class21
    {
      public List<Pnt3D> list_0;
      public List<TriangleIndex> list_1;
      public List<Color> list_2;

      public Class21(int int_0, int int_1)
      {
        this.list_0 = new List<Pnt3D>(int_0);
        this.list_2 = new List<Color>(int_0);
        this.list_1 = new List<TriangleIndex>(int_1);
      }
    }
  }

  [Serializable]
  public class Cf2 : buSerilization
  {
    public double BridgeMinLimit = 3.0;
    public double BridgeMaxLimit = 20.0;
    public double MinEntityLength = 0.0;
    private List<List<eEntities>> SubEntites = new List<List<eEntities>>();
    private List<List<eEntities>> SubBridges = new List<List<eEntities>>();
    private List<string> SubName = new List<string>();
    public List<Cf2FileProperties> FileDefinations = new List<Cf2FileProperties>();
    public List<LayerBase> Layers = new List<LayerBase>();
    public List<LayerBase> FoundLayers = new List<LayerBase>();
    internal Cf2FileProperties FoundBridgeProperties = new Cf2FileProperties();

    public Cf2()
    {
      if (!buVector.smethod_0("buCf2"))
        throw new RegisterException("buCf2");
    }

    public void ReadCf2(string FileName, ref List<eEntities> Entities, ref List<eEntities> Bridges)
    {
      try
      {
        List<string> stringList = new List<string>();
        FileInfo fileInfo = new FileInfo(FileName);
        this.FoundLayers = new List<LayerBase>();
        if (!fileInfo.Exists)
          return;
        TextReader textReader = (TextReader) File.OpenText(FileName);
        string str1;
        while ((str1 = textReader.ReadLine()) != null)
          stringList.Add(str1);
        textReader.Close();
        Entities.Clear();
        Bridges.Clear();
        Pnt3D pnt3D = new Pnt3D();
        bool flag1 = false;
        bool flag2 = false;
        string str2 = "";
        List<eEntities> eEntitiesList1 = new List<eEntities>();
        List<eEntities> eEntitiesList2 = new List<eEntities>();
        for (int index = 0; index <= this.FileDefinations.Count - 1; ++index)
        {
          if (this.FileDefinations[index].CodeType == DiemakerType.Bridge)
          {
            this.FoundBridgeProperties = new Cf2FileProperties(this.FileDefinations[index]);
            if (this.FoundBridgeProperties.LayerIndex < 0)
              this.FoundBridgeProperties.LayerIndex = index;
          }
        }
        for (int index = 0; index <= stringList.Count - 1; ++index)
        {
          bool flag3 = true;
          string[] string_0 = stringList[index].Split(',');
          if (string_0.Length >= 1)
          {
            if (string_0[0].ToLower() == "end" & flag1)
            {
              flag1 = false;
              this.SubEntites.Add(eEntitiesList1);
              this.SubName.Add(str2);
              this.SubBridges.Add(eEntitiesList2);
              eEntitiesList1 = new List<eEntities>();
              eEntitiesList2 = new List<eEntities>();
            }
            if (flag1)
            {
              if (string_0.Length >= 10 && string_0[0] == "L")
              {
                eLine eLine_0 = new eLine();
                List<eEntities> list_0 = new List<eEntities>();
                Class30.smethod_38(ref list_0, ref eLine_0, this, string_0);
                if (this.MinEntityLength > 0.0 && eLine_0.geoLength < this.MinEntityLength)
                  flag3 = false;
                if (flag3)
                {
                  eEntitiesList1.Add((eEntities) eLine_0);
                  eEntitiesList2.AddRange((IEnumerable<eEntities>) list_0.ToArray());
                }
              }
              if (string_0.Length >= 13 && string_0[0] == "A")
              {
                eEntities eEntities_0 = new eEntities();
                List<eEntities> list_0 = new List<eEntities>();
                Class30.smethod_186(ref list_0, this, ref eEntities_0, string_0);
                if (this.MinEntityLength > 0.0 && eEntities_0.geoLength < this.MinEntityLength)
                  flag3 = false;
                if (flag3)
                {
                  eEntitiesList1.Add(eEntities_0);
                  eEntitiesList2.AddRange((IEnumerable<eEntities>) list_0.ToArray());
                }
              }
            }
            if (string_0[0].ToLower() == "sub")
            {
              flag1 = true;
              str2 = string_0[1];
              eEntitiesList1 = new List<eEntities>();
              eEntitiesList2 = new List<eEntities>();
            }
          }
        }
        for (int index1 = 0; index1 <= stringList.Count - 1; ++index1)
        {
          bool flag4 = true;
          List<Pnt3D> pnt3DList = new List<Pnt3D>();
          string[] string_0 = stringList[index1].Split(',');
          if (string_0.Length >= 1)
          {
            if (string_0[0].ToLower() == "end" & flag2)
              flag2 = false;
            if (flag2)
            {
              if (string_0.Length >= 10 && string_0[0] == "L")
              {
                eLine eLine_0 = new eLine();
                Class30.smethod_38(ref Bridges, ref eLine_0, this, string_0);
                if (this.MinEntityLength > 0.0 && eLine_0.geoLength < this.MinEntityLength)
                  flag4 = false;
                if (flag4)
                {
                  this.method_0((eEntities) eLine_0);
                  Entities.Add((eEntities) eLine_0);
                }
              }
              if (string_0.Length >= 13 && string_0[0] == "A")
              {
                eEntities eEntities_0 = new eEntities();
                Class30.smethod_186(ref Bridges, this, ref eEntities_0, string_0);
                if (this.MinEntityLength > 0.0 && eEntities_0.geoLength < this.MinEntityLength)
                  flag4 = false;
                if (flag4)
                {
                  this.method_0(eEntities_0);
                  Entities.Add(eEntities_0);
                }
              }
              if (string_0.Length >= 9 && string_0[0] == "T")
              {
                string TextString_ = stringList[index1 + 1];
                Pnt3D Pnt = new Pnt3D(double.Parse(string_0[4], (IFormatProvider) buSystem.CI), double.Parse(string_0[5], (IFormatProvider) buSystem.CI));
                double Height_ = double.Parse(string_0[7], (IFormatProvider) buSystem.CI);
                eText eEntities_0 = new eText(Pnt, TextString_, Height_, Color.Black, new WorkPlane());
                eEntities_0.Diemaker = new DiemakerData();
                eEntities_0.Diemaker.Pt = double.Parse(string_0[1], (IFormatProvider) buSystem.CI);
                eEntities_0.Diemaker.DiemakerTYpeAsInteger = Convert.ToInt32(double.Parse(string_0[2], (IFormatProvider) buSystem.CI));
                this.method_0((eEntities) eEntities_0);
                Entities.Add((eEntities) eEntities_0);
              }
              if (string_0.Length >= 4 && string_0[0] == "C")
              {
                for (int index2 = 0; index2 <= this.SubName.Count - 1; ++index2)
                {
                  if (string_0[1].Trim() == this.SubName[index2].Trim())
                  {
                    for (int index3 = 0; index3 <= this.SubEntites[index2].Count - 1; ++index3)
                    {
                      eEntities eEntities = new eEntities();
                      eEntities RefEntities = eEntities.CopyEntity(this.SubEntites[index2][index3]);
                      Pnt3D To = new Pnt3D(double.Parse(string_0[2], (IFormatProvider) buSystem.CI), double.Parse(string_0[3], (IFormatProvider) buSystem.CI));
                      double Angle = double.Parse(string_0[4]);
                      double num1 = double.Parse(string_0[5]);
                      double num2 = double.Parse(string_0[6]);
                      eEntities baseEnt = new eEntities();
                      buAppCalc.cVector.Rotate(new Pnt3D(), Angle, ClockDirectionType.CW, new WorkPlane(), RefEntities, ref baseEnt);
                      eEntities Ent = eEntities.CopyEntity(baseEnt);
                      baseEnt = new eEntities();
                      if (num1 == -1.0)
                      {
                        buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), Ent, new WorkPlane(), 0.0, ref baseEnt);
                        Ent = eEntities.CopyEntity(baseEnt);
                      }
                      baseEnt = new eEntities();
                      if (num2 == -1.0)
                      {
                        buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), Ent, new WorkPlane(), 0.0, ref baseEnt);
                        Ent = eEntities.CopyEntity(baseEnt);
                      }
                      buAppCalc.cVector.Move(new Pnt3D(), To, ref Ent);
                      this.method_0(Ent);
                      Entities.Add(Ent);
                    }
                    for (int index4 = 0; index4 <= this.SubBridges[index2].Count - 1; ++index4)
                    {
                      eEntities eEntities = new eEntities();
                      eEntities RefEntities = eEntities.CopyEntity(this.SubBridges[index2][index4]);
                      Pnt3D To = new Pnt3D(double.Parse(string_0[2], (IFormatProvider) buSystem.CI), double.Parse(string_0[3], (IFormatProvider) buSystem.CI));
                      double Angle = double.Parse(string_0[4]);
                      double num3 = double.Parse(string_0[5]);
                      double num4 = double.Parse(string_0[6]);
                      eEntities baseEnt = new eEntities();
                      buAppCalc.cVector.Rotate(new Pnt3D(), Angle, ClockDirectionType.CW, new WorkPlane(), RefEntities, ref baseEnt);
                      eEntities Ent = eEntities.CopyEntity(baseEnt);
                      baseEnt = new eEntities();
                      if (num3 == -1.0)
                      {
                        buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(10.0, 0.0, 0.0), Ent, new WorkPlane(), 0.0, ref baseEnt);
                        Ent = eEntities.CopyEntity(baseEnt);
                      }
                      baseEnt = new eEntities();
                      if (num4 == -1.0)
                      {
                        buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(0.0, 10.0, 0.0), Ent, new WorkPlane(), 0.0, ref baseEnt);
                        Ent = eEntities.CopyEntity(baseEnt);
                      }
                      buAppCalc.cVector.Move(new Pnt3D(), To, ref Ent);
                      Bridges.Add(Ent);
                    }
                  }
                }
              }
            }
            if (string_0[0].ToLower() == "main")
              flag2 = true;
          }
        }
      }
      catch (Exception ex)
      {
        string str = FileName;
        buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
        buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      }
    }

    private void method_0(eEntities eEntities_0)
    {
      if (eEntities_0.Diemaker == null)
        return;
      bool flag = true;
      for (int index = 0; index <= this.FoundLayers.Count - 1; ++index)
      {
        if (this.FoundLayers[index].Diemaker.Pt == eEntities_0.Diemaker.Pt & this.FoundLayers[index].Diemaker.Type == eEntities_0.Diemaker.DiemakerType)
          flag = false;
      }
      if (!flag)
        return;
      LayerBase layerBase = new LayerBase()
      {
        Diemaker = new LayerDiemakerProps()
      };
      layerBase.Diemaker.Pt = eEntities_0.Diemaker.Pt;
      layerBase.Diemaker.Type = eEntities_0.Diemaker.DiemakerType;
      layerBase.LayerColor = eEntities_0.dispColor;
      layerBase.LayerThickness = eEntities_0.dispThickness;
      layerBase.Name = $"{eEntities_0.Diemaker.DiemakerType.ToString()}-{eEntities_0.Diemaker.Pt.ToString()} Pt";
      this.FoundLayers.Add(layerBase);
    }

    public static void SaveCf2Properties(string FileName, List<Cf2FileProperties> Cf2Properties)
    {
      ArrayList StringList = new ArrayList();
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "   CF2 File Properties ");
      StringList.Add((object) "------------------------------------------------------------------------");
      StringList.Add((object) "<CF2Prop>");
      for (int index = 0; index <= Cf2Properties.Count - 1; ++index)
        StringList.AddRange((ICollection) Cf2Properties[index].ToDefAll("", 2, SerilizationMode.MultiLine));
      StringList.Add((object) "</CF2Prop>");
      buFile.SaveToFile(StringList, FileName);
    }

    public static void OpenCf2Properties(string FileName, ref List<Cf2FileProperties> Cf2Properties)
    {
      ArrayList StringList = new ArrayList();
      buFile.OpenFromFile(FileName, ref StringList);
      Cf2Properties.Clear();
      Cf2Properties = new List<Cf2FileProperties>();
      List<List<string>> CalcList = new List<List<string>>();
      buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", true, StringList, ref CalcList);
      for (int index = 0; index <= CalcList.Count - 1; ++index)
      {
        ArrayList AL = new ArrayList();
        AL.AddRange((ICollection) CalcList[index].ToArray());
        Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
        buSerilization.Decode(AL, "", SerilizationMode.MultiLine, (object) cf2FileProperties);
        Cf2Properties.Add(cf2FileProperties);
      }
      buLog.addLog("CF2 Properties Loaded", "Ok", MethodBase.GetCurrentMethod().Name, FileName, "", 0.0, 0.0);
    }
  }

  public class HPGLFile
  {
    public List<eEntities> Entities = new List<eEntities>();
    public List<Pnt3D> CoordinateList = new List<Pnt3D>();

    public HPGLFile()
    {
      if (!buVector.smethod_0(nameof (HPGLFile)))
        throw new RegisterException(nameof (HPGLFile));
    }

    public void ReadHPGL(string Name)
    {
      List<string> stringList = new List<string>();
      if (new FileInfo(Name).Exists)
      {
        this.CoordinateList = new List<Pnt3D>();
        TextReader textReader = (TextReader) File.OpenText(Name);
        string str;
        while ((str = textReader.ReadLine()) != null)
          stringList.Add(str);
        textReader.Close();
      }
      this.Entities.Clear();
      List<Pnt3D> Vertices = new List<Pnt3D>();
      for (int index1 = 0; index1 <= stringList.Count - 1; ++index1)
      {
        string[] strArray1 = stringList[index1].Split(';');
        if (strArray1 != null)
        {
          Pnt3D pnt3D1 = new Pnt3D();
          Pnt3D pnt3D2 = new Pnt3D();
          for (int index2 = 0; index2 <= strArray1.Length - 1; ++index2)
          {
            if (strArray1[index2].ToLower().IndexOf("pd") >= 0)
            {
              string[] strArray2 = strArray1[index2].Replace("PD", "").Split(',');
              if (strArray2 != null && strArray2.Length >= 2)
              {
                Pnt3D pnt3D3 = new Pnt3D(new Pnt3D(double.Parse(strArray2[0].Trim()) / 10.0, double.Parse(strArray2[1].Trim()) / 10.0));
                Vertices.Add(pnt3D3);
              }
            }
            if (strArray1[index2].ToLower().IndexOf("pu") >= 0)
            {
              if (Vertices.Count > 1)
                this.Entities.Add((eEntities) new ePolyline(Vertices));
              Vertices.Clear();
              string[] strArray3 = strArray1[index2].Replace("PU", "").Split(',');
              if (strArray3 != null && strArray3.Length >= 2)
              {
                Pnt3D pnt3D4 = new Pnt3D(double.Parse(strArray3[0].Trim()) / 10.0, double.Parse(strArray3[1].Trim()) / 10.0);
                Vertices.Add(pnt3D4);
              }
            }
          }
        }
      }
      if (Vertices.Count > 1)
        this.Entities.Add((eEntities) new ePolyline(Vertices));
      Vertices.Clear();
    }
  }

  [Serializable]
  public class Rul : buSerilization
  {
    public void ReadRulFile(string FileName, ref RulProperties Properties)
    {
      FileInfo fileInfo = new FileInfo(FileName);
      Properties = new RulProperties();
      if (!fileInfo.Exists)
        return;
      List<string> StringList = new List<string>();
      buFile.OpenFromFile(FileName, ref StringList);
      if (StringList.Count <= 0)
        return;
      for (int index1 = 0; index1 <= StringList.Count - 1; ++index1)
      {
        string[] strArray = StringList[index1].Split(':');
        if (strArray != null && strArray.Length >= 2)
        {
          if (strArray[0].ToLower().IndexOf("version") >= 0)
            Properties.Version = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("author") >= 0)
            Properties.Author = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("date") >= 0)
            Properties.Date = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("time") >= 0)
            Properties.Time = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("unit") >= 0)
            Properties.Unit = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("rule table") >= 0)
            Properties.RuleTable = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("sample size") >= 0)
            Properties.SampleSize = strArray[1].Trim();
          if (strArray[0].ToLower().IndexOf("number of sizes") >= 0)
            Properties.NumberOfSize = Convert.ToInt32(strArray[1].Trim());
          if (strArray[0].ToLower().IndexOf("size list") >= 0)
          {
            string[] Lines = (string[]) null;
            buString.SplitStringByRefWord(strArray[1], " ", ref Lines);
            if (Lines != null)
            {
              for (int index2 = 0; index2 <= Lines.Length - 1; ++index2)
                Properties.SizeList.Add(Lines[index2].Trim());
            }
          }
          if (strArray[0].ToLower().IndexOf("rule") >= 0)
          {
            string[] Lines1 = (string[]) null;
            buString.SplitStringByRefWord(strArray[1], "   ", ref Lines1);
            if (Lines1 != null)
            {
              RulRule rulRule = new RulRule();
              if (Lines1.Length == 2)
              {
                string[] Lines2 = (string[]) null;
                buString.SplitStringByRefWord(Lines1[0], " ", ref Lines2);
                if (Lines2 != null && Lines2.Length == 2 && Lines2[0].ToLower().IndexOf("delta") >= 0)
                  rulRule.No = Convert.ToInt32(Lines2[1]);
                string[] Lines3 = (string[]) null;
                buString.SplitStringByRefWord(Lines1[1], "  ", ref Lines3);
                if (Lines3 != null)
                {
                  for (int index3 = 0; index3 <= Lines3.Length - 1; ++index3)
                  {
                    string[] Lines4 = (string[]) null;
                    buString.SplitStringByRefWord(Lines3[index3], ",", ref Lines4);
                    if (Lines4 != null)
                    {
                      if (Lines4.Length >= 2)
                      {
                        rulRule.Position.Add(new Pnt3D(Convert.ToDouble(Lines4[0]), Convert.ToDouble(Lines4[1])));
                      }
                      else
                      {
                        string[] Lines5 = (string[]) null;
                        buString.SplitStringByRefWord(Lines3[index3], " ", ref Lines5);
                        if (Lines5.Length >= 2)
                          rulRule.Position.Add(new Pnt3D(Convert.ToDouble(Lines5[0]), Convert.ToDouble(Lines5[1])));
                      }
                    }
                  }
                }
                Properties.RuleList.Add(rulRule);
              }
            }
          }
        }
      }
    }
  }

  [Serializable]
  public class bunesting : buSerilization
  {
  }
}
