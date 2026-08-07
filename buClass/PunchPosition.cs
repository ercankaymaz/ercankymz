// Decompiled with JetBrains decompiler
// Type: buClass.PunchPosition
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class PunchPosition : buSerilization
{
  public Pnt3D BasePosition = new Pnt3D();
  public Pnt3D OrjinalPosition = new Pnt3D();
  public Pnt3D Offsets = new Pnt3D();
  public Vec3D Size = new Vec3D();
  public int ToolIndex = 0;
  public bool NextJob = false;

  public PunchPosition()
  {
  }

  public PunchPosition(PunchPosition data)
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

  public override string ToString()
  {
    return $"X : {this.BasePosition.X.ToString("f3")} - Y : {this.BasePosition.Y.ToString("f3")}";
  }
}
