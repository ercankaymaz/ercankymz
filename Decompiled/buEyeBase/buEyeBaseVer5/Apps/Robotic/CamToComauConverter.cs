using System;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Apps.Robotic;

public class CamToComauConverter
{
	public static Vector3D xAxisLast;

	public static ComauPose ConvertCamToComau(Point3D position, Vector3D direction, Vector3D upVector = null, double toolLength = 0.0)
	{
		Point3D position2 = CalculateTcpPosition(position, direction, toolLength);
		double[,] array = Class186.smethod_161(direction, upVector);
		if (array != null)
		{
			EulerAngles orientation = RotationMatrixToComauEulerZYZ(array);
			return TransformToComauCoordinateSystem(position2, orientation);
		}
		return null;
	}

	public static void CorrectNegativeBAngle(ref EulerAngles eulerAngles)
	{
		eulerAngles.Pitch = Class186.smethod_332(eulerAngles.Pitch);
		if (eulerAngles.Pitch > 180.0)
		{
			eulerAngles.Pitch = 360.0 - eulerAngles.Pitch;
		}
		eulerAngles.Yaw = Class186.smethod_332(eulerAngles.Yaw);
	}

	public static Point3D CalculateTcpPosition(Point3D camPosition, Vector3D direction, double toolLength)
	{
		if (toolLength != 0.0)
		{
			Vector3D vector3D = Class186.smethod_38(direction);
			return new Point3D(camPosition.X - vector3D.X * toolLength, camPosition.Y - vector3D.Y * toolLength, camPosition.Z - vector3D.Z * toolLength);
		}
		return camPosition;
	}

	public static double[,] CreateRotationMatrixFromVectors11(Vector3D approach, Vector3D upVector)
	{
		Vector3D vector3D = Class186.smethod_38(approach);
		Vector3D vector3D2;
		Vector3D vector3D3;
		if (!(upVector != null) || !(upVector.Length > 0.1))
		{
			if (!(Math.Abs(vector3D.Z) > 0.99999999))
			{
				vector3D2 = new Vector3D(0.0 - vector3D.Y, vector3D.X, 0.0);
				vector3D2.Normalize();
			}
			else
			{
				vector3D2 = new Vector3D(0.0, 1.0, 0.0);
			}
			vector3D3 = Vector3D.Cross(vector3D, vector3D2);
			vector3D3.Normalize();
		}
		else
		{
			Vector3D a = Class186.smethod_38(upVector);
			vector3D2 = Vector3D.Cross(a, vector3D);
			vector3D2.Normalize();
			vector3D3 = Vector3D.Cross(vector3D, vector3D2);
			vector3D3.Normalize();
		}
		return new double[3, 3]
		{
			{ vector3D2.X, vector3D3.X, vector3D.X },
			{ vector3D2.Y, vector3D3.Y, vector3D.Y },
			{ vector3D2.Z, vector3D3.Z, vector3D.Z }
		};
	}

	public static EulerAngles RotationMatrixToComauEulerZYZ(double[,] R)
	{
		double x = R[0, 0];
		_ = R[0, 1];
		double x2 = R[0, 2];
		double y = R[1, 0];
		_ = R[1, 1];
		double y2 = R[1, 2];
		double num = R[2, 0];
		double num2 = R[2, 1];
		double num3 = R[2, 2];
		double num4;
		double num5;
		double num6;
		if (!(Math.Abs(num3) < 0.999999))
		{
			num4 = ((num3 <= 0.0) ? Math.PI : 0.0);
			num5 = Math.Atan2(y, x);
			num6 = 0.0;
		}
		else
		{
			num4 = Math.Atan2(Math.Sqrt(num * num + num2 * num2), num3);
			num5 = Math.Atan2(y2, x2);
			num6 = Math.Atan2(num2, 0.0 - num);
		}
		return new EulerAngles(num5 * 180.0 / Math.PI, num4 * 180.0 / Math.PI, num6 * 180.0 / Math.PI);
	}

	public static ComauPose TransformToComauCoordinateSystem(Point3D position, EulerAngles orientation)
	{
		return new ComauPose(position, orientation);
	}
}
