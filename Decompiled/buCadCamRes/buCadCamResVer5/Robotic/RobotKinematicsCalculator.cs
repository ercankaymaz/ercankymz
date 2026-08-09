using System;
using buEyeBaseVer5.Apps.Robotic;
using ns8;

namespace buCadCamResVer5.Robotic;

public class RobotKinematicsCalculator
{
	public static EulerAngles CalculateEulerAngles(Vector3DD position, Vector3DD approachVector, Vector3DD orientationVector = null)
	{
		Vector3DD vector3DD = approachVector.Normalize();
		Vector3DD vector3DD3;
		Vector3DD vector3DD2;
		if (orientationVector == null)
		{
			vector3DD2 = ((Math.Abs(vector3DD.Z) > 0.999) ? new Vector3DD(1.0, 0.0, 0.0) : new Vector3DD(0.0 - vector3DD.Y, vector3DD.X, 0.0).Normalize());
			vector3DD3 = Vector3DD.Cross(vector3DD, vector3DD2).Normalize();
		}
		else
		{
			vector3DD2 = orientationVector.Normalize();
			vector3DD3 = Vector3DD.Cross(vector3DD, vector3DD2).Normalize();
			vector3DD2 = Vector3DD.Cross(vector3DD3, vector3DD).Normalize();
		}
		return Class5.smethod_133(new double[3, 3]
		{
			{ vector3DD2.X, vector3DD3.X, vector3DD.X },
			{ vector3DD2.Y, vector3DD3.Y, vector3DD.Y },
			{ vector3DD2.Z, vector3DD3.Z, vector3DD.Z }
		});
	}

	public static EulerAngles CalculateBasicOrientation(Vector3DD approachVector)
	{
		Vector3DD vector3DD = approachVector.Normalize();
		double pitch = Math.Asin(0.0 - vector3DD.X) * 180.0 / Math.PI;
		double roll = Math.Atan2(vector3DD.Y, vector3DD.Z) * 180.0 / Math.PI;
		return new EulerAngles(roll, pitch, 0.0);
	}
}
