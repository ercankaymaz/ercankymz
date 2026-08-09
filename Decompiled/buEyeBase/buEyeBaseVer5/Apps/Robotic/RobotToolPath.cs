using System;
using System.Reflection;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RobotToolPath : buSerilization5
{
	public RobotPose RoboPosition = new RobotPose();

	public Entity entVectorNormal = null;

	public RobotToolPath()
	{
	}

	public RobotToolPath(RobotToolPath data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		RoboPosition = new RobotPose(data.RoboPosition);
	}

	public override string ToString()
	{
		string text = "X: " + RoboPosition.PositionNoTool.X.ToString("f3") + " , Y: " + RoboPosition.PositionNoTool.Y.ToString("f3") + " , Z: " + RoboPosition.PositionNoTool.Z.ToString("f3");
		return text + " - Roll A: " + RoboPosition.Orientation.Roll.ToString("f3") + " , Pitch B: " + RoboPosition.Orientation.Pitch.ToString("f3") + " , Yaw C: " + RoboPosition.Orientation.Yaw.ToString("f3");
	}
}
