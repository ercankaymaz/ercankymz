// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Robotic.DoorJob
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using devDept.Geometry;
using System;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class DoorJob : buSerilization5
{
  public bool isFinish;
  public bool isOffset;
  public bool UseKinematic;
  public double DevideLength;
  public Point3D ShiftPoint;
  public bool ShiftEnable;
  public bool UseClockDirection;
  public bool UseContantAngle;
  public double ConstantAngle;
  public ClockDirectionType SetClockDir;
  public bool UseLeadIn;

  public DoorJob()
  {
    ((marbleSawMillingPars) this).ViewportSettings = (MarbleDisplayViewportSettings) new RoboticRuntimeSettings();
    ((marbleSawMillingPars) this).ShowCamG1Entities = true;
    ((marbleSawMillingPars) this).ShowCamG0Entities = true;
    ((marbleSawMillingPars) this).ShowCamPlungeEntities = true;
    ((marbleSawMillingPars) this).ShowCamLeaveEntities = true;
    ((marbleSawMillingPars) this).ShowCamLeadInOutEntities = true;
    ((marbleSawMillingPars) this).ShowCamConnectionEntities = true;
    ((marbleSawMillingPars) this).DrawItemSizeEntities = true;
    ((marbleSawMillingPars) this).buttonColorSolidEnable = false;
    ((marbleSawMillingPars) this).PartMaterialSkinEnable = false;
    ((marbleSawMillingPars) this).WoodMaterialSkinEnable = true;
    ((marbleSawMillingPars) this).ViewPanAmount = 15;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DoorJob(MarbleDisplaySettings data)
  {
    ((marbleSawMillingPars) this).ViewportSettings = (MarbleDisplayViewportSettings) new RoboticRuntimeSettings();
    ((marbleSawMillingPars) this).ShowCamG1Entities = true;
    ((marbleSawMillingPars) this).ShowCamG0Entities = true;
    ((marbleSawMillingPars) this).ShowCamPlungeEntities = true;
    ((marbleSawMillingPars) this).ShowCamLeaveEntities = true;
    ((marbleSawMillingPars) this).ShowCamLeadInOutEntities = true;
    ((marbleSawMillingPars) this).ShowCamConnectionEntities = true;
    ((marbleSawMillingPars) this).DrawItemSizeEntities = true;
    ((marbleSawMillingPars) this).buttonColorSolidEnable = false;
    ((marbleSawMillingPars) this).PartMaterialSkinEnable = false;
    ((marbleSawMillingPars) this).WoodMaterialSkinEnable = true;
    ((marbleSawMillingPars) this).ViewPanAmount = 15;
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

  public static void Copy(MarbleDisplaySettings Source, ref MarbleDisplaySettings Target)
  {
    Target = (MarbleDisplaySettings) new DoorJob(Source);
  }
}
