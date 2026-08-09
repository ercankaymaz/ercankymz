using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using buEyeBaseVer5.Apps.Robotic;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Robotic;

public class ComauRacer7FullKinematics
{
	public static class RobotSpecs
	{
		public const double MaxReach = 1789.0;

		public const double Payload = 7.0;

		public static readonly double[] JointLowerLimits = new double[6] { -185.0, -140.0, -168.0, -270.0, -125.0, -270.0 };

		public static readonly double[] JointUpperLimits = new double[6] { 185.0, 140.0, 32.0, 270.0, 125.0, 270.0 };

		public static readonly DhParameters[] DhParams = new DhParameters[6]
		{
			new DhParameters(0.0, 355.0, 0.0, -90.0),
			new DhParameters(0.0, 0.0, 850.0, 0.0),
			new DhParameters(0.0, 0.0, 145.0, 90.0),
			new DhParameters(0.0, 820.0, 0.0, -90.0),
			new DhParameters(0.0, 0.0, 0.0, 90.0),
			new DhParameters(0.0, 170.0, 0.0, 0.0)
		};
	}

	public class DhParameters
	{
		[CompilerGenerated]
		private double double_0;

		[CompilerGenerated]
		private double double_1;

		[CompilerGenerated]
		private double double_2;

		[CompilerGenerated]
		private double double_3;

		public double Theta
		{
			[CompilerGenerated]
			get
			{
				return double_0;
			}
			[CompilerGenerated]
			set
			{
				double_0 = value;
			}
		}

		public double D
		{
			[CompilerGenerated]
			get
			{
				return double_1;
			}
			[CompilerGenerated]
			set
			{
				double_1 = value;
			}
		}

		public double A
		{
			[CompilerGenerated]
			get
			{
				return double_2;
			}
			[CompilerGenerated]
			set
			{
				double_2 = value;
			}
		}

		public double Alpha
		{
			[CompilerGenerated]
			get
			{
				return double_3;
			}
			[CompilerGenerated]
			set
			{
				double_3 = value;
			}
		}

		public DhParameters(double theta, double d, double a, double alpha)
		{
			Theta = theta;
			D = d;
			A = a;
			Alpha = alpha;
		}
	}

	public static RobotPose ForwardKinematics(double[] jointAngles)
	{
		double[] array = new double[6];
		for (int i = 0; i < 6; i++)
		{
			array[i] = jointAngles[i] * Math.PI / 180.0;
		}
		DhParameters[] dhParams = RobotSpecs.DhParams;
		DhParameters[] array2 = new DhParameters[6];
		for (int j = 0; j < 6; j++)
		{
			array2[j] = new DhParameters(array[j] + dhParams[j].Theta * Math.PI / 180.0, dhParams[j].D, dhParams[j].A, dhParams[j].Alpha * Math.PI / 180.0);
		}
		double[,] array3 = Class5.smethod_215(array2);
		Point3D position = new Point3D(array3[0, 3], array3[1, 3], array3[2, 3]);
		EulerAngles orientation = Class5.smethod_120(array3);
		return new RobotPose(position, orientation);
	}

	public static double[][] InverseKinematics(RobotPose pose, double[] previousJoints = null)
	{
		List<double[]> list = new List<double[]>();
		DhParameters[] dhParams = RobotSpecs.DhParams;
		Point3D position = pose.Position;
		double[,] array = Class5.smethod_149(pose.Orientation);
		Vector3DD vector3DD = new Vector3DD(position.X - dhParams[5].D * array[0, 2], position.Y - dhParams[5].D * array[1, 2], position.Z - dhParams[5].D * array[2, 2]);
		double num = Math.Atan2(vector3DD.Y, vector3DD.X);
		double num2 = num + Math.PI;
		double[] array2 = new double[2] { num, num2 };
		foreach (double num3 in array2)
		{
			double num4 = vector3DD.X * Math.Cos(num3) + vector3DD.Y * Math.Sin(num3);
			double num5 = vector3DD.Z - dhParams[0].D;
			double num6 = num4 - dhParams[1].A;
			double num7 = (num6 * num6 + num5 * num5 - dhParams[2].A * dhParams[2].A - dhParams[3].D * dhParams[3].D) / (2.0 * dhParams[2].A * dhParams[3].D);
			if (!(Math.Abs(num7) <= 1.0))
			{
				continue;
			}
			double num8 = Math.Atan2(Math.Sqrt(1.0 - num7 * num7), num7);
			double num9 = Math.Atan2(0.0 - Math.Sqrt(1.0 - num7 * num7), num7);
			double[] array3 = new double[2] { num8, num9 };
			foreach (double num10 in array3)
			{
				double x = dhParams[2].A + dhParams[3].D * Math.Cos(num10);
				double y = dhParams[3].D * Math.Sin(num10);
				double num11 = Math.Atan2(num5, num6) - Math.Atan2(y, x);
				double[,] double_ = Class5.smethod_180(num10, num11, num3);
				double[,] array4 = Class5.smethod_157(array, Class5.smethod_18(double_));
				double num12;
				double num13;
				double num14;
				if (!(Math.Abs(array4[2, 2]) < 0.9999))
				{
					num12 = ((array4[2, 2] <= 0.0) ? Math.PI : 0.0);
					num13 = Math.Atan2(array4[1, 0], array4[0, 0]);
					num14 = 0.0;
				}
				else
				{
					num12 = Math.Atan2(Math.Sqrt(1.0 - array4[2, 2] * array4[2, 2]), array4[2, 2]);
					num13 = Math.Atan2(array4[1, 2], array4[0, 2]);
					num14 = Math.Atan2(array4[2, 1], 0.0 - array4[2, 0]);
				}
				double[] array5 = new double[6]
				{
					num3 * 180.0 / Math.PI,
					num11 * 180.0 / Math.PI,
					num10 * 180.0 / Math.PI,
					num13 * 180.0 / Math.PI,
					num12 * 180.0 / Math.PI,
					num14 * 180.0 / Math.PI
				};
				if (CheckJointLimits(array5))
				{
					list.Add(array5);
				}
			}
		}
		return list.ToArray();
	}

	public static bool CheckJointLimits(double[] jointAngles)
	{
		for (int i = 0; i < 6; i++)
		{
			if (!(jointAngles[i] >= RobotSpecs.JointLowerLimits[i]) || jointAngles[i] > RobotSpecs.JointUpperLimits[i])
			{
				return false;
			}
		}
		return true;
	}

	public static double[] SelectBestSolution(double[][] solutions, double[] previousJoints)
	{
		if (solutions.Length != 0)
		{
			if (previousJoints != null)
			{
				double num = double.MaxValue;
				double[] result = solutions[0];
				foreach (double[] array in solutions)
				{
					double num2 = 0.0;
					for (int j = 0; j < 6; j++)
					{
						double num3 = array[j] - previousJoints[j];
						num2 += num3 * num3;
					}
					if (num2 < num)
					{
						num = num2;
						result = array;
					}
				}
				return result;
			}
			return solutions[0];
		}
		return null;
	}
}
