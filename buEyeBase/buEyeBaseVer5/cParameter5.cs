// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.cParameter5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buClipperLib;
using buEyeBaseVer5.Variables;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

#nullable disable
namespace buEyeBaseVer5;

public class cParameter5
{
  public double Persentage;
  public static byte f000965;
  public double FoundAngle;
  public bool Outside;
  public Point3D pntPick;
  public static byte f000969;
  [SpecialName]
  public int value__;

  public static void OpenDxfDwg(ref List<Entity> EntityList, string FileName, string LayerName = "Default")
  {
    try
    {
      ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(FileName);
      ((ReadAutodesk) readFileAsync).ExtrudeByThickness = false;
      Design design = new Design();
      design.Clear();
      design.DoWork((WorkUnit) readFileAsync);
      for (int index = 0; index <= readFileAsync.Entities.Count - 1; ++index)
      {
        Entity entity = readFileAsync.Entities[index];
        entity.EntityData = (object) new ClipperOffset();
        if (LayerName.Length > 0)
          entity.LayerName = "Default";
        EntityList.Add(entity);
      }
    }
    catch (Exception ex)
    {
      string str = "FileNmae : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public static void OpenDxfDwg(ref Design Viewport, string FileName)
  {
    try
    {
      ReadFileAsync readFileAsync = (ReadFileAsync) new ReadAutodesk(FileName);
      Viewport.Clear();
      Viewport.DoWork((WorkUnit) readFileAsync);
      if (readFileAsync.Entities == null || readFileAsync.Entities.Count <= 0)
        return;
      readFileAsync.OpenTo((IDesign) Viewport);
    }
    catch (Exception ex)
    {
      string str = "FileNmae : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }

  public Task<ReadFileAsync> OpenDxfDwgAsync(Design Viewport, string filePath)
  {
    // ISSUE: variable of a compiler-generated type
    buFile5.\u0003 stateMachine = (buFile5.\u0003) new buVector5();
    ((EditorSettings) stateMachine).\u0001 = AsyncTaskMethodBuilder<ReadFileAsync>.Create();
    ((EditorSettings) stateMachine).\u0001 = (buFile5) this;
    ((EditorSettings) stateMachine).\u0001 = Viewport;
    ((EditorSettings) stateMachine).\u0001 = filePath;
    ((EditorSettings) stateMachine).\u0001 = -1;
    ((EditorSettings) stateMachine).\u0001.Start<buFile5.\u0003>(ref stateMachine);
    return ((EditorSettings) stateMachine).\u0001.Task;
  }

  public static void SaveDxfDwg(List<Entity> EntityList, string FileName)
  {
    try
    {
      Design viewport = (Design) null;
      EyeCreateProps Properties = (EyeCreateProps) new ShapeEdit();
      ((DiameterDepthPoint) Properties).ShowToolBar = false;
      ((DiameterDepthPoint) Properties).ShowViewCube = false;
      ((MaterialBase5) Properties).ShowCoordinateArrow = false;
      buConversion5.CreateControlsTool(true, Properties, ref viewport);
      for (int index = 0; index <= EntityList.Count - 1; ++index)
      {
        EntityList[index].LayerName = "Default";
        viewport.Entities.Add(EntityList[index]);
      }
      WriteFileAsync writeFileAsync = (WriteFileAsync) new WriteAutodesk(new WriteAutodeskParams(viewport.Document), FileName);
      viewport.StartWork((WorkUnit) writeFileAsync);
    }
    catch (Exception ex)
    {
      string str = "FileNmae : " + FileName;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, true, str);
    }
  }
}
