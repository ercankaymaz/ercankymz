// Decompiled with JetBrains decompiler
// Type: buClass.SimulationBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass;

public class SimulationBase : buSerilization
{
  public bool ShowSimulationTool = true;
  public bool DevideG0Movement = true;
  public double G0DevideLength = 2.0;
  public bool DevideG1Movement = true;
  public double G1DevideLength = 2.0;
  public bool UseG1Filter = true;
  public double G1FilterLength = 2.0;

  public SimulationBase()
  {
  }

  public SimulationBase(SimulationBase data)
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
    return $"G0DevideLength: {this.G0DevideLength.ToString()} - G1DevideLength: {this.G1DevideLength.ToString()}";
  }
}
