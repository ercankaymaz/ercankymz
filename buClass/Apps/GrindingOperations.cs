// Decompiled with JetBrains decompiler
// Type: buClass.Apps.GrindingOperations
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass.Apps;

[Serializable]
public class GrindingOperations : buSerilization
{
  public bool SawRampEnable = false;
  public double SawRampLenght = 50.0;
  public double SawRampHeight = 10.0;
  public CamZRampType SawRampType = CamZRampType.Circular;
  public double SawDevideLength = 0.5;
  public bool InsideOperationHoleEnable = false;
  public double IndiseOperationHoleDistance = 100.0;
  public int IndieOperationHoleTool = 0;
  public double VacuumDiameter = 50.0;
  public double VacuumHeight = 0.0;
  public double VacuumThickness = 10.0;
  public double PinDiameter = 50.0;
  public double PinHeight = 0.0;
  public double PinThickness = 10.0;
  public int VacuumLayerIndex = 4;
  public int PinLayerIndex = 4;
  public bool UseGeometryCalculation = false;
  public double GlassThickness = 0.0;

  public GrindingOperations()
  {
  }

  public GrindingOperations(GrindingOperations data)
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
