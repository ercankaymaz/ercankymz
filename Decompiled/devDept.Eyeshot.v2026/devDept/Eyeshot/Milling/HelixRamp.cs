using System;
using System.Collections.Generic;
using System.Diagnostics;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class HelixRamp : Ramp
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003Dzrs3b507aH5yJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003DzzLEIz0x_MhlT3_zf7Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly bool _0023_003DzUnE1iSIQ6guR595n7g_003D_003D;

	public HelixRamp(double radius, double angleInRad, double clearanceHeight, bool reverseTwist = true)
		: base(clearanceHeight)
	{
		_0023_003Dzrs3b507aH5yJ = radius;
		_0023_003DzzLEIz0x_MhlT3_zf7Q_003D_003D = angleInRad;
		_0023_003DzUnE1iSIQ6guR595n7g_003D_003D = reverseTwist;
		BuildAsLollipop(radius, 0.0);
	}

	public override void Init(double tolerance, double height)
	{
		LinearPath linearPath = LinearPath.CreateHelix(_0023_003Dzrs3b507aH5yJ, _0023_003DzzLEIz0x_MhlT3_zf7Q_003D_003D, height + ClearanceHeight, tolerance, _0023_003DzUnE1iSIQ6guR595n7g_003D_003D);
		linearPath.Rotate(-Math.PI / 2.0, Vector3D.AxisZ);
		linearPath.Translate(0.0, _0023_003Dzrs3b507aH5yJ);
		List<Toolpath.Motion> list = new List<Toolpath.Motion>();
		for (int num = linearPath.Vertices.Length - 1; num > 0; num--)
		{
			Point3D point3D = linearPath.Vertices[num];
			Point3D to = linearPath.Vertices[num - 1];
			list.Add(new Toolpath.LinearMotion(point3D, to, motionType.G01, 0.0, 0.0, string.Empty)
			{
				Approach = approachType.Ramp
			});
		}
		Motions = list.ToArray();
		base.Init(tolerance, height);
	}
}
