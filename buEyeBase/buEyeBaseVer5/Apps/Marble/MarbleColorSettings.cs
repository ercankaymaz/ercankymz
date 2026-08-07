// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.MarbleColorSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Eyeshot.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleColorSettings : buSerilization5
{
  public static bool SavingMarble;
  public static bool SavingUserLog;
  public static bool SavingCriticalLog;
  public static bool SavingLog;
  public static bool SavingExceptionsLog;
  public static bool CheckingLogSize;
  public static double Length;
  public static bool CameraFrameShowed;
  public static int HorizontalItemIndex;
  public static int VerticalItemIndex;
  public static int HorVerHorizontalItemIndex;
  public static int HorVerVerticalItemIndex;
  public static int HorizontalItemSelectedRowIndex;
  public static int VerticalItemSelectedRowIndex;
  public static int HorVerHorizontalItemSelectedRowIndex;
  public static int HorVerVerticalItemSelectedRowIndex;
  public static int HorizontalItemSelectedColIndex;
  public static int VerticalItemSelectedColIndex;
  public static int HorVerHorizontalItemSelectedColIndex;
  public static int HorVerVerticalItemSelectedColIndex;
  public static Pnt6D HorizontalStartPos;
  public static Pnt6D HorizontalEndPos;
  public static Pnt6D VerticalStartPos;
  public static Pnt6D VerticalEndPos;
  public static Pnt6D SingleCutPos;
  public static Pnt6DSimMove SimulationPoint;
  public static LayerDefination layerWood;
  public static LayerDefination layerMarbleSheet;
  public static LayerDefination layerMarblePart;
  public static LayerDefination layerDrawing;
  public static LayerDefination layerCutting;
  public static LayerDefination layerMachine;
  public static LayerDefination layerShape;
  public static LayerDefination layer3D;
  public static LayerDefination layerCam;
  public static LayerDefination layerCamG1;
  public static LayerDefination layerCamPlunge;
  public static LayerDefination layerCamLeave;
  public static LayerDefination layerCamConnection;
  public static LayerDefination layerCamLeadInOut;
  public static LayerDefination layerCamDraw;
  public static LayerDefination layerAngle;
  public static LayerDefination layerEngrave;
  public static string pathWood;
  public static string pathMarble;
  public static string fileNameWood;
  public static string fileNameMarble;
  public static List<MaterialBase5> tempMaterials;
  public static List<Entity> ImportedEntitites;
  public static marbleCuttingItems SlicesItem;
  public static List<marbleCuttingItems> listHorizontalItems;

  public MarbleColorSettings()
  {
    ((MarbleRuntimeSettings) this).Depth = 0.0;
    ((MarbleRuntimeSettings) this).TopPosition = 0.0;
    ((MarbleRuntimeSettings) this).BottomPosition = 0.0;
    ((MarbleRuntimeSettings) this).SpindleSpeed = 0.0;
    ((MarbleRuntimeSettings) this).PlungeFeed = 0.0;
    ((MarbleRuntimeSettings) this).PeckingUp = false;
    ((MarbleRuntimeSettings) this).PeckingUpDistance = 0.0;
    ((MarbleRuntimeSettings) this).Wait = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public MarbleColorSettings(DepthPositions data)
  {
    ((MarbleRuntimeSettings) this).Depth = 0.0;
    ((MarbleRuntimeSettings) this).TopPosition = 0.0;
    ((MarbleRuntimeSettings) this).BottomPosition = 0.0;
    ((MarbleRuntimeSettings) this).SpindleSpeed = 0.0;
    ((MarbleRuntimeSettings) this).PlungeFeed = 0.0;
    ((MarbleRuntimeSettings) this).PeckingUp = false;
    ((MarbleRuntimeSettings) this).PeckingUpDistance = 0.0;
    ((MarbleRuntimeSettings) this).Wait = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public static void SaveFile(List<DepthPositions> Depths, string FileName)
  {
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "<DepthValues>");
    for (int index = 0; index <= Depths.Count - 1; ++index)
      StringList.AddRange((ICollection) Depths[index].ToDefAll("", 2, (SerilizationMode5) 1));
    StringList.Add((object) "</DepthValues>");
    buVector5.SaveToFile(StringList, FileName);
    StringList.Clear();
  }

  public static void OpenFile(ref List<DepthPositions> Depths, string FileName)
  {
    List<string> StringList = new List<string>();
    List<List<string>> CalcList = new List<List<string>>();
    buVector5.OpenFromFile(FileName, ref StringList);
    buStatics.ListToSpecificList("<DepthPositions>", "</DepthPositions>", true, StringList, ref CalcList);
    for (int index = 0; index <= CalcList.Count - 1; ++index)
    {
      DepthPositions depthPositions = (DepthPositions) new MarbleColorSettings();
      buSerilization5.Decode(CalcList[index], "", (SerilizationMode5) 1, (object) depthPositions);
      Depths.Add(depthPositions);
    }
    CalcList.Clear();
    StringList.Clear();
  }

  public static void Copy(List<DepthPositions> Depths, ref List<DepthPositions> Copied)
  {
    if (Depths == null)
      return;
    if (Copied == null)
      Copied = new List<DepthPositions>();
    Copied.Clear();
    for (int index = 0; index <= Depths.Count - 1; ++index)
      Copied.Add((DepthPositions) new MarbleColorSettings(Depths[index]));
  }
}
