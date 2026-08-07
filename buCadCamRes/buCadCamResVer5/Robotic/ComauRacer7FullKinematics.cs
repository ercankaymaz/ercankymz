// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Robotic.ComauRacer7FullKinematics
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buEyeBaseVer5.Apps.Robotic;
using devDept.Geometry;
using ns8;
using System;
using System.Collections.Generic;

#nullable disable
namespace buCadCamResVer5.Robotic;

public class ComauRacer7FullKinematics
{
  public static RobotPose ForwardKinematics(double[] jointAngles)
  {
    double[] numArray = new double[6];
    for (int index = 0; index < 6; ++index)
      numArray[index] = jointAngles[index] * Math.PI / 180.0;
    ComauRacer7FullKinematics.DhParameters[] dhParams = ComauRacer7FullKinematics.RobotSpecs.DhParams;
    ComauRacer7FullKinematics.DhParameters[] dhParameters_0 = new ComauRacer7FullKinematics.DhParameters[6];
    for (int index = 0; index < 6; ++index)
      dhParameters_0[index] = new ComauRacer7FullKinematics.DhParameters(numArray[index] + dhParams[index].Theta * Math.PI / 180.0, dhParams[index].D, dhParams[index].A, dhParams[index].Alpha * Math.PI / 180.0);
    double[,] double_0 = Class5.smethod_215(dhParameters_0);
    return new RobotPose(new Point3D(double_0[0, 3], double_0[1, 3], double_0[2, 3]), Class5.smethod_120(double_0));
  }

  public static double[][] InverseKinematics(RobotPose pose, double[] previousJoints = null)
  {
    List<double[]> numArrayList = new List<double[]>();
    ComauRacer7FullKinematics.DhParameters[] dhParams = ComauRacer7FullKinematics.RobotSpecs.DhParams;
    Point3D position = pose.Position;
    double[,] double_0_1 = Class5.smethod_149(pose.Orientation);
    Vector3DD vector3Dd = new Vector3DD(position.X - dhParams[5].D * double_0_1[0, 2], position.Y - dhParams[5].D * double_0_1[1, 2], position.Z - dhParams[5].D * double_0_1[2, 2]);
    double num1 = Math.Atan2(vector3Dd.Y, vector3Dd.X);
    double num2 = num1 + Math.PI;
    double[] numArray1 = new double[2]{ num1, num2 };
    foreach (double num3 in numArray1)
    {
      double num4 = vector3Dd.X * Math.Cos(num3) + vector3Dd.Y * Math.Sin(num3);
      double y1 = vector3Dd.Z - dhParams[0].D;
      double x1 = num4 - dhParams[1].A;
      double x2 = (x1 * x1 + y1 * y1 - dhParams[2].A * dhParams[2].A - dhParams[3].D * dhParams[3].D) / (2.0 * dhParams[2].A * dhParams[3].D);
      if (Math.Abs(x2) <= 1.0)
      {
        double[] numArray2 = new double[2]
        {
          Math.Atan2(Math.Sqrt(1.0 - x2 * x2), x2),
          Math.Atan2(-Math.Sqrt(1.0 - x2 * x2), x2)
        };
        foreach (double num5 in numArray2)
        {
          double x3 = dhParams[2].A + dhParams[3].D * Math.Cos(num5);
          double y2 = dhParams[3].D * Math.Sin(num5);
          double double_1 = Math.Atan2(y1, x1) - Math.Atan2(y2, x3);
          double[,] double_0_2 = Class5.smethod_180(num5, double_1, num3);
          double[,] numArray3 = Class5.smethod_157(double_0_1, Class5.smethod_18(double_0_2));
          double num6;
          double num7;
          double num8;
          if (Math.Abs(numArray3[2, 2]) < 0.9999)
          {
            num6 = Math.Atan2(Math.Sqrt(1.0 - numArray3[2, 2] * numArray3[2, 2]), numArray3[2, 2]);
            num7 = Math.Atan2(numArray3[1, 2], numArray3[0, 2]);
            num8 = Math.Atan2(numArray3[2, 1], -numArray3[2, 0]);
          }
          else
          {
            num6 = numArray3[2, 2] > 0.0 ? 0.0 : Math.PI;
            num7 = Math.Atan2(numArray3[1, 0], numArray3[0, 0]);
            num8 = 0.0;
          }
          double[] jointAngles = new double[6]
          {
            num3 * 180.0 / Math.PI,
            double_1 * 180.0 / Math.PI,
            num5 * 180.0 / Math.PI,
            num7 * 180.0 / Math.PI,
            num6 * 180.0 / Math.PI,
            num8 * 180.0 / Math.PI
          };
          if (ComauRacer7FullKinematics.CheckJointLimits(jointAngles))
            numArrayList.Add(jointAngles);
        }
      }
    }
    return numArrayList.ToArray();
  }

  public static bool CheckJointLimits(double[] jointAngles)
  {
    bool flag;
    for (int index = 0; index < 6; ++index)
    {
      if ((jointAngles[index] < ComauRacer7FullKinematics.RobotSpecs.JointLowerLimits[index] ? 1 : (jointAngles[index] > ComauRacer7FullKinematics.RobotSpecs.JointUpperLimits[index] ? 1 : 0)) != 0)
      {
        flag = false;
        goto label_6;
      }
    }
    flag = true;
label_6:
    return flag;
  }

  public static double[] SelectBestSolution(double[][] solutions, double[] previousJoints)
  {
    double[] numArray1;
    if (solutions.Length == 0)
      numArray1 = (double[]) null;
    else if (previousJoints == null)
    {
      numArray1 = solutions[0];
    }
    else
    {
      double num1 = double.MaxValue;
      double[] numArray2 = solutions[0];
      foreach (double[] solution in solutions)
      {
        double num2 = 0.0;
        for (int index = 0; index < 6; ++index)
        {
          double num3 = solution[index] - previousJoints[index];
          num2 += num3 * num3;
        }
        if (num2 < num1)
        {
          num1 = num2;
          numArray2 = solution;
        }
      }
      numArray1 = numArray2;
    }
    return numArray1;
  }

  public static class RobotSpecs
  {
    public const double MaxReach = 1789.0;
    public const double Payload = 7.0;
    public static readonly double[] JointLowerLimits = new double[6]
    {
      -185.0,
      -140.0,
      -168.0,
      -270.0,
      -125.0,
      -270.0
    };
    public static readonly double[] JointUpperLimits = new double[6]
    {
      185.0,
      140.0,
      32.0,
      270.0,
      125.0,
      270.0
    };
    public static readonly ComauRacer7FullKinematics.DhParameters[] DhParams = new ComauRacer7FullKinematics.DhParameters[6]
    {
      new ComauRacer7FullKinematics.DhParameters(0.0, 355.0, 0.0, -90.0),
      new ComauRacer7FullKinematics.DhParameters(0.0, 0.0, 850.0, 0.0),
      new ComauRacer7FullKinematics.DhParameters(0.0, 0.0, 145.0, 90.0),
      new ComauRacer7FullKinematics.DhParameters(0.0, 820.0, 0.0, -90.0),
      new ComauRacer7FullKinematics.DhParameters(0.0, 0.0, 0.0, 90.0),
      new ComauRacer7FullKinematics.DhParameters(0.0, 170.0, 0.0, 0.0)
    };
  }

  public class DhParameters
  {
    public double Theta { get; set; }

    public double D { get; set; }

    public double A { get; set; }

    public double Alpha { get; set; }

    public DhParameters(double theta, double d, double a, double alpha)
    {
      this.Theta = theta;
      this.D = d;
      this.A = a;
      this.Alpha = alpha;
    }
  }
}
