// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.DrillItemBase
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using devDept.Geometry;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class DrillItemBase : buSerilization5
{
  public double TopZ;
  public double BottomZ;
  public double LeftMin;
  public double LeftMax;
  public bool isError;
  public bool isVertical;
  public SizeObject SizeObj;
  public string TextureName;
  public Color colorFoam;
  public int Transparency;
  public Point3D MinPoint;
  public Point3D MaxPoint;
  public FoamPlaneType planeName;
  public FoamSpeeds Speeds;
  public FoamRuntimeSettings Settings;
  public FoamPattern basePattern;
  public FoamType BlockFoamType;
  public bool isWaveOperation;
  public List<FoamPattern> Pattern;
  public static byte f003D4D;
  public string PatternName;
  public int ID;
  public Point3D BoxMinItem;
  public Point3D BoxMaxItem;

  public DrillItemBase()
  {
    ((SewingOffsetOptions) this).pathPipeBendJob = Application.StartupPath;
    ((SewingPickType) this).SimStep = 1;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DrillItemBase(PipeBendRuntimeSettings data)
  {
    ((SewingOffsetOptions) this).pathPipeBendJob = Application.StartupPath;
    ((SewingPickType) this).SimStep = 1;
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

  public DrillItemBase()
  {
    ((SewingSettings) this).LayerGeneral = "";
    ((SewingSettings) this).LayerFoam = "";
    ((SewingSettings) this).Layer3DPattern = "";
    ((SewingSettings) this).LayerWirePattern = "";
    ((SewingSettings) this).LayerSelection = "";
    ((SewingSettings) this).LayerMark = "";
    ((SewingSettings) this).LayerDefault = "Default";
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public DrillItemBase(PipeBendTempVars data)
  {
    ((SewingSettings) this).LayerGeneral = "";
    ((SewingSettings) this).LayerFoam = "";
    ((SewingSettings) this).Layer3DPattern = "";
    ((SewingSettings) this).LayerWirePattern = "";
    ((SewingSettings) this).LayerSelection = "";
    ((SewingSettings) this).LayerMark = "";
    ((SewingSettings) this).LayerDefault = "Default";
    // ISSUE: explicit constructor call
    base.\u002Ector();
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
}
