// Decompiled with JetBrains decompiler
// Type: buClass.camHatch
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camHatch : buSerilization
{
  public double OperationZ = 0.0;
  public double CutLength = 1000.0;
  public double CutStep = 5.0;
  public double TotalWidth = 100.0;
  public Pnt3D CornerPoint = new Pnt3D();
  public CamHatchCuttingDirection CuttingDirection = CamHatchCuttingDirection.XDirection;
  public CamHatchCuttingMode CuttingModes = CamHatchCuttingMode.ForwardNextBackward;
  public static List<string> Captions = new List<string>();

  public camHatch()
  {
  }

  public camHatch(
    double operationZ,
    double cutLength,
    double cutStep,
    double totalWidth,
    CamHatchCuttingDirection cuttingDirection,
    CamHatchCuttingMode cuttingModes,
    Pnt3D CornerPnt)
  {
    this.OperationZ = operationZ;
    this.CutLength = cutLength;
    this.CutStep = cutStep;
    this.TotalWidth = totalWidth;
    this.CuttingDirection = cuttingDirection;
    this.CuttingModes = cuttingModes;
    this.CornerPoint = new Pnt3D(CornerPnt);
  }

  public camHatch(camHatch Data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) Data, ref CopiedClass);
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
    return $"OperationZ: {this.OperationZ.ToString()} , CutLength: {this.CutLength.ToString()} , CutStep: {this.CutStep.ToString()} , TotalWidth: {this.TotalWidth.ToString()}";
  }
}
