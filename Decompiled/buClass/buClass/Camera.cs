using System;
using System.Drawing;

namespace buClass;

public class Camera
{
	private Pnt3D loc = new Pnt3D(0.0, 0.0, 0.0);

	private double _d = 500.0;

	private Quaternion quan = new Quaternion(1.0, 0.0, 0.0, 0.0);

	public Pnt3D Location
	{
		get
		{
			return loc;
		}
		set
		{
			loc = value;
		}
	}

	public double FocalDistance
	{
		get
		{
			return _d;
		}
		set
		{
			_d = value;
		}
	}

	public Quaternion Quaternion
	{
		get
		{
			return quan;
		}
		set
		{
			quan = value;
		}
	}

	public void MoveRight(double d)
	{
		loc.X += d;
	}

	public void MoveLeft(double d)
	{
		loc.X -= d;
	}

	public void MoveUp(double d)
	{
		loc.Y -= d;
	}

	public void MoveDown(double d)
	{
		loc.Y += d;
	}

	public void MoveIn(double d)
	{
		loc.Z += d;
	}

	public void MoveOut(double d)
	{
		loc.Z -= d;
	}

	public void Roll(int degree)
	{
		Quaternion quaternion = default(Quaternion);
		quaternion.FromAxisAngle(new Vec3D(0.0, 0.0, 1.0), (double)degree * Math.PI / 180.0);
		quan = quaternion * quan;
	}

	public void Yaw(int degree)
	{
		Quaternion quaternion = default(Quaternion);
		quaternion.FromAxisAngle(new Vec3D(0.0, 1.0, 0.0), (double)degree * Math.PI / 180.0);
		quan = quaternion * quan;
	}

	public void Pitch(int degree)
	{
		Quaternion quaternion = default(Quaternion);
		quaternion.FromAxisAngle(new Vec3D(1.0, 0.0, 0.0), (double)degree * Math.PI / 180.0);
		quan = quaternion * quan;
	}

	public void TurnUp(int degree)
	{
		Pitch(-degree);
	}

	public void TurnDown(int degree)
	{
		Pitch(degree);
	}

	public void TurnLeft(int degree)
	{
		Yaw(degree);
	}

	public void TurnRight(int degree)
	{
		Yaw(-degree);
	}

	public PointF[] GetProjection(Pnt3D[] pts)
	{
		PointF[] array = new PointF[pts.Length];
		Pnt3D[] pts2 = Pnt3D.Copy(pts);
		Pnt3D.Offset(ref pts2, 0.0 - loc.X, 0.0 - loc.Y, 0.0 - loc.Z);
		quan.Rotate(pts2);
		for (int i = 0; i < pts.Length; i++)
		{
			if (pts2[i].Z > 0.1)
			{
				array[i] = new PointF((float)(loc.X + pts2[i].X * _d / pts2[i].Z), (float)(loc.Y + pts2[i].Y * _d / pts2[i].Z));
			}
			else
			{
				array[i] = new PointF(float.MaxValue, float.MaxValue);
			}
		}
		return array;
	}

	public PointF GetProjection(Pnt3D pts)
	{
		PointF pointF = default(PointF);
		Pnt3D pts2 = new Pnt3D(pts);
		Pnt3D.Offset(ref pts2, 0.0 - loc.X, 0.0 - loc.Y, 0.0 - loc.Z);
		quan.Rotate(pts2);
		return (!(pts2.Z > 0.1)) ? new PointF(float.MaxValue, float.MaxValue) : new PointF((float)(loc.X + pts2.X * _d / pts2.Z), (float)(loc.Y + pts2.Y * _d / pts2.Z));
	}
}
