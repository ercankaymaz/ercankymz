// Decompiled with JetBrains decompiler
// Type: buClass.ZHeightAdjustmentByDistance
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ZHeightAdjustmentByDistance : buSerilization
{
  public double ZHeightValue = 0.0;
  public double LevelCenter = 0.0;
  public double LevelMin = 0.0;
  public double LevelMax = 0.0;
  public VectorXYType Direction = VectorXYType.YVector;
  public ZHeightProfileType ZType = ZHeightProfileType.Linear;

  public ZHeightAdjustmentByDistance()
  {
  }

  public ZHeightAdjustmentByDistance(ZHeightAdjustmentByDistance data)
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
}
