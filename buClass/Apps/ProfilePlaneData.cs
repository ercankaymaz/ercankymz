// Decompiled with JetBrains decompiler
// Type: buClass.Apps.ProfilePlaneData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class ProfilePlaneData : buSerilization
{
  public planeNames PlaneSelectedName = planeNames.Top;
  public WorkPlane PlaneSelected = new WorkPlane();
  public Pnt3D PlaneCreateSlopeDistance = new Pnt3D();
  public planeInclineType PlaneCreateProfileType = planeInclineType.Distance;
  public LeftRightLocationType PlaneCreateSlopeDirection = LeftRightLocationType.Left;
  public double PlaneCreateProfileAngle = 0.0;
  public double PlaneCreateProfileLength = 0.0;

  public ProfilePlaneData()
  {
  }

  public ProfilePlaneData(ProfilePlaneData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
      FieldInfo[] fields = this.GetType().GetFields();
      if (fields != null)
      {
        for (int index = 0; index <= fields.Length - 1; ++index)
        {
          string name = fields[index].Name;
          object obj = fields[index].GetValue(CopiedClass);
          fields[index].SetValue((object) this, obj);
        }
      }
    }
    this.PlaneSelected = new WorkPlane(data.PlaneSelected);
  }
}
