// Decompiled with JetBrains decompiler
// Type: buClass.Apps.XRayMisalignment
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class XRayMisalignment : buSerilization
{
  public double AngleOfXVector = 0.0;
  public double AngleOfYVector = 0.0;
  public double AngleOfZVector = 0.0;
  public Pnt3D MovedPositionARotation = new Pnt3D();
  public Pnt3D MovedPositionCRotation = new Pnt3D();

  public XRayMisalignment()
  {
  }

  public XRayMisalignment(XRayMisalignment data)
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

  public override string ToString() => "AngleOfZVector: " + this.AngleOfZVector.ToString();
}
