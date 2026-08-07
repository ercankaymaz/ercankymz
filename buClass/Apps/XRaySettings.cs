// Decompiled with JetBrains decompiler
// Type: buClass.Apps.XRaySettings
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class XRaySettings : buSerilization
{
  public double SurfaceFollowDistance = 150.0;
  public double ScanStep = 50.0;
  public double GridOffset = 20.0;
  public double DevideLength = 100.0;
  public double G1Feed = 5000.0;
  public double G1FeedForAC = 1000.0;
  public double AMinLimit = -45.0;
  public double AMaxLimit = 45.0;
  public double CMinLimit = -45.0;
  public double CMaxLimit = 45.0;
  public double AChangeFixValue = 3.0;
  public double CChangeFixValue = 3.0;
  public double ACAxisChangeLength = 1000.0;

  public XRaySettings()
  {
  }

  public XRaySettings(XRaySettings data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
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

  public override string ToString() => "Scan Step: " + this.ScanStep.ToString();
}
