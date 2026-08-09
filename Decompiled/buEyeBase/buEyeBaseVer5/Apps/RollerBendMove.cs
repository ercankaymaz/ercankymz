using System;
using System.Reflection;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class RollerBendMove : buSerilization5
{
	public double XPosition = 0.0;

	public double LeftDistance = 0.0;

	public double LeftAngle = 0.0;

	public double RightDistance = 0.0;

	public double RightAngle = 0.0;

	public double UpDistance = 0.0;

	public int Index = -1;

	public bool Enable = true;

	public RollerBendMoveCommand Command = RollerBendMoveCommand.None;

	public Point3D Position = new Point3D();

	public RollerBendMove()
	{
	}

	public RollerBendMove(double xPosition, double leftDistance, double leftAngle, double rightDistance, double rightAngle, double upDistance, RollerBendMoveCommand Cmd, int index = -1)
	{
		LeftDistance = leftDistance;
		RightDistance = rightDistance;
		LeftAngle = leftAngle;
		RightAngle = rightAngle;
		XPosition = xPosition;
		UpDistance = upDistance;
		Command = Cmd;
		Index = index;
	}

	public RollerBendMove(double xPosition, double leftDistance, double rightDistance, double upDistance, RollerBendMoveCommand Cmd, int index = -1)
	{
		LeftDistance = leftDistance;
		RightDistance = rightDistance;
		XPosition = xPosition;
		UpDistance = upDistance;
		Command = Cmd;
		Index = index;
	}

	public RollerBendMove(RollerBendMove data)
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
		if (data.Position != null)
		{
			Position = new Point3D(data.Position.X, data.Position.Y, data.Position.Z);
		}
	}

	public override string ToString()
	{
		return "X: " + XPosition.ToString("f2") + " - Left: " + LeftDistance.ToString("f2") + " - Right: " + RightDistance.ToString("f2") + " - Up: " + UpDistance.ToString("f2") + " - Cmd: " + Command;
	}
}
