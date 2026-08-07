// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillCalcItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillCalcItem : buSerilization5
{
  public static byte f003D14;
  public static LengthUnit UnitLength;
  public static SpeedUnit UnitsSpeed;
  public static List<string> LangFoamStatus;
  public static List<string> LangFoamMessage;
  public static List<string> LangFoamCaptions;
  public static List<string> LangFoamCommands;
  public static FoamTempVars varTemps;
  public static FoamSettings varFoamSettings;
  public static FoamEditorSettings varFoamEditorSettings;
  public static GCodeConverter varFoamGCodeConverter;
  public static FoamRuntimeSettings varFoamRunSettings;
  public static List<camRadiusFeed> RadiusFeedList;
  public static List<camLengthFeed> LengthFeedList;
  public static int EntityID;
  public static string UnlockString;
  public static byte f003D24;
  public string ItemName;
  public string FileName;
  public string FileNameFull;
  public bool isError;
  public bool isGCodeCreated;
  public bool CreatedFromDrawing;
  public MaterialBase5 Material;
  public string TextureName;
  public Color colorFoam;
  public int Transparency;
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public Entity SolidEntity;
  public List<FoamBlock> BlockXZ;
  public List<FoamBlock> BlockYZ;
  public camTp CamXZ;
  public camTp CamYZ;
  public List<buEntity> sortedEntitiesYZ;
  public List<buEntity> sortedEntitiesXZ;
  public static byte f003D38;
  public string BlockName;

  public abstract void m001B3C();

  public DrillCalcItem()
  {
    ((SewingDevideOptions) this).pathLRAFiles = Application.StartupPath;
    ((SewingDevideOptions) this).SimulationIntervalMs = 5;
    ((SewingDevideOptions) this).CollisionCheck = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillCalcItem(PipeBendingProgramSettings data)
  {
    ((SewingDevideOptions) this).pathLRAFiles = Application.StartupPath;
    ((SewingDevideOptions) this).SimulationIntervalMs = 5;
    ((SewingDevideOptions) this).CollisionCheck = true;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public static void Copy(PipeBendingProgramSettings Source, ref PipeBendingProgramSettings Target)
  {
    Target = (PipeBendingProgramSettings) new DrillCalcItem(Source);
  }

  public override string ToString() => "";

  static DrillCalcItem() => SewingDevideOptions.Captions = new List<string>();

  public DrillCalcItem()
  {
    ((SewingDevideOptions) this).ShowOperationInfo = false;
    ((SewingOffsetOptions) this).pathFromFile = "C:\\";
    ((SewingOffsetOptions) this).UnitLength = LengthUnit.mm;
    ((SewingOffsetOptions) this).UnitSpeed = SpeedUnit.mmPerSec;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillCalcItem(PipeBendSettings data)
  {
    ((SewingDevideOptions) this).ShowOperationInfo = false;
    ((SewingOffsetOptions) this).pathFromFile = "C:\\";
    ((SewingOffsetOptions) this).UnitLength = LengthUnit.mm;
    ((SewingOffsetOptions) this).UnitSpeed = SpeedUnit.mmPerSec;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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

  public abstract void m001B44();
}
