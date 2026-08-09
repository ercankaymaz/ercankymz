using System;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class EulerAngles : buSerilization5
{
	public double Roll = 0.0;

	public double Pitch = 0.0;

	public double Yaw = 0.0;

	public EulerAngles()
	{
	}

	public EulerAngles(double roll, double pitch, double yaw)
	{
		Roll = roll;
		Pitch = pitch;
		Yaw = yaw;
	}

	public override string ToString()
	{
		return $"Roll: {Roll:F2}°, Pitch: {Pitch:F2}°, Yaw: {Yaw:F2}°";
	}
}
