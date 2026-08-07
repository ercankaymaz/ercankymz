// Decompiled with JetBrains decompiler
// Type: buClass.CodesysCNCSets
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysCNCSets : buSerilization
{
  public double setG1Velocity = 200.0;
  public double setG1Acc = 200.0;
  public double setG1Dec = 200.0;
  public double setG0Velocity = 100.0;
  public double setG0Acc = 100.0;
  public double setG0Dec = 100.0;
  public double setMaxVel = 250.0;
  public double setMaxAccDec = 5000.0;
  public double setMaxJerk = 14000.0;
  public bool setReadNC3DMode = true;
  public bool setSyntaxCheck = true;
  public bool setG51Mode = true;
  public bool setSmoothMergeEnable = true;
  public double setSmoothMergeMinCurveRad = 0.01;
  public int setSmoothMergeDegree = 5;
  public bool setSmoothPathEnable = true;
  public double setSmoothPathMinCurveRad = 0.01;
  public double setSmoothPathEdgeDistance = 0.01;
  public double setSmoothPathAngleTol = 10.0;
  public bool setSmoothPathCheckCurvature = true;
  public double setSmoothPathRelativeCurvatureTol = 0.01;
  public bool setSmoothPathSymmetricDis = false;
  public bool setSmoothPathImproveSymmetricCut = false;
  public bool setSmoothPathCheckAddAxVelJump = true;
  public double setSmoothPathMaxAddAxVelDifference = 1000.0;
  public double setCheckVelocityAngleTol = 10.0;
  public bool setCheckVelocityCheckAddAxVelJump = true;
  public double setCheckVelocityMaxAddAxVelDiff = 0.01;
  public bool setExtendedVelEnable = true;
  public bool setExtendedVelStrictlyHoldAccDecABC = true;
  public bool setReComputeABCEnable = true;
  public double setReComputeABCAngleTol = 10.0;
  public CodesysSmcAbcSlopesNoStop setReComputeABCModeNoStop = CodesysSmcAbcSlopesNoStop.SmoothCardinal;
  public CodesysSmcAbcSlopesAtStop setReComputeABCModeAtStop = CodesysSmcAbcSlopesAtStop.SetZero;
  public double RotaryAxisVelocityCorrection = 1.0;
  public int setPreparePathRepeatWaitTimeMicSec = 7500;
  public static List<string> Captions = new List<string>();

  public CodesysCNCSets()
  {
  }

  public CodesysCNCSets(CodesysCNCSets data)
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

  public static void ConvertFromInchToMm(ref CodesysCNCSets camPar, int Round)
  {
    double num = 25.4;
    camPar.setCheckVelocityMaxAddAxVelDiff = Math.Round(camPar.setCheckVelocityMaxAddAxVelDiff * num, Round);
    camPar.setG0Acc = Math.Round(camPar.setG0Acc * num, Round);
    camPar.setG0Dec = Math.Round(camPar.setG0Dec * num, Round);
    camPar.setG0Velocity = Math.Round(camPar.setG0Velocity * num, Round);
    camPar.setG1Acc = Math.Round(camPar.setG1Acc * num, Round);
    camPar.setG1Dec = Math.Round(camPar.setG1Dec * num, Round);
    camPar.setG1Velocity = Math.Round(camPar.setG1Velocity * num, Round);
    camPar.setMaxAccDec = Math.Round(camPar.setMaxAccDec * num, Round);
    camPar.setMaxJerk = Math.Round(camPar.setMaxJerk * num, Round);
    camPar.setMaxVel = Math.Round(camPar.setMaxVel * num, Round);
    camPar.setSmoothMergeMinCurveRad = Math.Round(camPar.setSmoothMergeMinCurveRad * num, Round);
    camPar.setSmoothPathEdgeDistance = Math.Round(camPar.setSmoothPathEdgeDistance * num, Round);
    camPar.setSmoothPathMinCurveRad = Math.Round(camPar.setSmoothPathMinCurveRad * num, Round);
    camPar.setSmoothPathRelativeCurvatureTol = Math.Round(camPar.setSmoothPathRelativeCurvatureTol * num, Round);
  }

  public static void ConvertFromMmToInch(ref CodesysCNCSets camPar, int Round)
  {
    double num = 5.0 / (double) sbyte.MaxValue;
    camPar.setCheckVelocityMaxAddAxVelDiff = Math.Round(camPar.setCheckVelocityMaxAddAxVelDiff * num, Round);
    camPar.setG0Acc = Math.Round(camPar.setG0Acc * num, Round);
    camPar.setG0Dec = Math.Round(camPar.setG0Dec * num, Round);
    camPar.setG0Velocity = Math.Round(camPar.setG0Velocity * num, Round);
    camPar.setG1Acc = Math.Round(camPar.setG1Acc * num, Round);
    camPar.setG1Dec = Math.Round(camPar.setG1Dec * num, Round);
    camPar.setG1Velocity = Math.Round(camPar.setG1Velocity * num, Round);
    camPar.setMaxAccDec = Math.Round(camPar.setMaxAccDec * num, Round);
    camPar.setMaxJerk = Math.Round(camPar.setMaxJerk * num, Round);
    camPar.setMaxVel = Math.Round(camPar.setMaxVel * num, Round);
    camPar.setSmoothMergeMinCurveRad = Math.Round(camPar.setSmoothMergeMinCurveRad * num, Round);
    camPar.setSmoothPathEdgeDistance = Math.Round(camPar.setSmoothPathEdgeDistance * num, Round);
    camPar.setSmoothPathMinCurveRad = Math.Round(camPar.setSmoothPathMinCurveRad * num, Round);
    camPar.setSmoothPathRelativeCurvatureTol = Math.Round(camPar.setSmoothPathRelativeCurvatureTol * num, Round);
  }

  public override string ToString()
  {
    return "setCheckVelocityAngleTol : " + this.setCheckVelocityAngleTol.ToString();
  }
}
