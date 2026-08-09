using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Parallel3D : Project3D
{
	protected double angle;

	public Parallel3D(Setup setup, EndMill cutter, Geometry3D geometry, double stepOver, double angleInRadians, double verticalLeadAmount)
		: base(setup, cutter, geometry, verticalLeadAmount)
	{
		base.stepOver = stepOver;
		angle = angleInRadians;
		base.CutDirectionMode = cutDirectionType.Mixed;
		base.LeadIn = null;
		OpenContoursRamp = null;
		pocketRamp = null;
		Ramp = null;
		zRange = new Interval(geometry.GetBoxMin(setup).Z, geometry.GetBoxMax(setup).Z + geometry.GetBoxSize(setup).Z * 0.1);
		EstimateSafetyHeights();
		base.StayDownDistance = cutter.Diameter;
	}

	public Parallel3D(Setup setup, EndMill cutter, Geometry3D geometry, double stepOver, double angleInRadians, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, stepOver, angleInRadians, verticalLeadAmount)
	{
		zRange = Project3D.InitRangeZ(setup, geometry, zLow);
	}

	public Parallel3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, double stepOver, double angleInRadians, double verticalLeadAmount)
		: this(setup, cutter, geometry, stepOver, angleInRadians, verticalLeadAmount)
	{
		base.boundary = boundary;
	}

	public Parallel3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, double stepOver, double angleInRadians, double verticalLeadAmount, double zLow)
		: this(setup, cutter, geometry, boundary, stepOver, angleInRadians, verticalLeadAmount)
	{
		zRange = Project3D.InitRangeZ(setup, geometry, zLow);
	}

	private protected override List<IList<Line>> _0023_003DzMYW_00247MY_003D(Region _0023_003DzFDwqpgU_003D)
	{
		_0023_003DzdHAEsWFt2rbg _0023_003DzVTN8X_RiGktX = (_0023_003DzdHAEsWFt2rbg)1;
		switch (base.CutDirectionMode)
		{
		case cutDirectionType.Climb:
			_0023_003DzVTN8X_RiGktX = (_0023_003DzdHAEsWFt2rbg)1;
			break;
		case cutDirectionType.Conventional:
			_0023_003DzVTN8X_RiGktX = (_0023_003DzdHAEsWFt2rbg)0;
			break;
		case cutDirectionType.Mixed:
			_0023_003DzVTN8X_RiGktX = (_0023_003DzdHAEsWFt2rbg)2;
			break;
		}
		return Machining._0023_003DzIBirOvc_003D(_0023_003DzFDwqpgU_003D, angle, stepOver, _0023_003DzVTN8X_RiGktX, null);
	}

	private protected override Point3D[][][] _0023_003DzJKePfk0_003D(Point3D[][][] _0023_003DzyZlWguvcpRpK)
	{
		return _0023_003DzyZlWguvcpRpK;
	}
}
