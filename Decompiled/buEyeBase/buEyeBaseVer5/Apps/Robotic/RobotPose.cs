using System;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Robotic;

[Serializable]
public class RobotPose : buSerilization5
{
	public Point3D Position = new Point3D();

	public Point3D PositionNoTool = new Point3D();

	public EulerAngles Orientation = new EulerAngles();

	public PlaneAngles PlaneAngle = new PlaneAngles();

	public Vector3D IJKVector = new Vector3D();

	public Vector3D DirectionVector = new Vector3D();

	public bool isQuickMove = false;

	public bool isPlungeMove = false;

	public bool isCuttingMove = false;

	public RobotPose()
	{
	}

	public RobotPose(Point3D position, EulerAngles orientation)
	{
		Position = new Point3D(position.X, position.Y, position.Z);
		Orientation = new EulerAngles(orientation.Roll, orientation.Pitch, orientation.Yaw);
	}

	public RobotPose(Point3D position, EulerAngles orientation, Vector3D ijk)
	{
		Position = new Point3D(position.X, position.Y, position.Z);
		Orientation = new EulerAngles(orientation.Roll, orientation.Pitch, orientation.Yaw);
		IJKVector = new Vector3D(ijk.X, ijk.Y, ijk.Z);
	}

	public RobotPose(RobotPose data)
	{
		if (this != null)
		{
			Position = new Point3D(data.Position.X, data.Position.Y, data.Position.Z);
			PositionNoTool = new Point3D(data.PositionNoTool.X, data.PositionNoTool.Y, data.PositionNoTool.Z);
			IJKVector = new Vector3D(data.IJKVector.X, data.IJKVector.Y, data.IJKVector.Z);
			DirectionVector = new Vector3D(data.DirectionVector.X, data.DirectionVector.Y, data.DirectionVector.Z);
			Orientation = new EulerAngles(data.Orientation.Roll, data.Orientation.Pitch, data.Orientation.Yaw);
			PlaneAngle = new PlaneAngles(data.PlaneAngle.A, data.PlaneAngle.B, data.PlaneAngle.C);
			isQuickMove = data.isQuickMove;
			isPlungeMove = data.isPlungeMove;
			isCuttingMove = data.isCuttingMove;
		}
	}

	public override string ToString()
	{
		string text = "X: " + PositionNoTool.X.ToString("f3") + " , Y: " + PositionNoTool.Y.ToString("f3") + " , Z: " + PositionNoTool.Z.ToString("f3");
		return text + " - Roll A: " + Orientation.Roll.ToString("f3") + " , Pitch B: " + Orientation.Pitch.ToString("f3") + " , Yaw C: " + Orientation.Yaw.ToString("f3");
	}
}
