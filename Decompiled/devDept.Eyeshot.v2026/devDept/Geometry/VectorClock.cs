using System;
using System.Diagnostics;

namespace devDept.Geometry;

public class VectorClock
{
	public Vector2D MainAxis;

	public Vector2D SecAxis;

	public bool SwappedAxis;

	public double StartAngle;

	public double QAngle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly CircularSector[] _0023_003DzIDavK_00243UDgItqCFTBg_003D_003D = new CircularSector[4];

	public VectorClock(Vector2D mainAxis, Vector2D secAxis)
	{
		MainAxis = (Vector2D)mainAxis.Clone();
		SecAxis = (Vector2D)secAxis.Clone();
		StartAngle = CircularSector._0023_003DzhC77ON751qRg(MainAxis.Angle);
		QAngle = Vector2D.SignedAngleBetween(MainAxis, SecAxis);
		Vector2D vector2D = (Vector2D)MainAxis.Clone();
		Vector2D vector2D2 = (Vector2D)SecAxis.Clone();
		vector2D.Negate();
		vector2D2.Negate();
		SwappedAxis = QAngle < 0.0;
		if (SwappedAxis)
		{
			QAngle += Math.PI;
		}
		_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[0] = new CircularSector(MainAxis, SwappedAxis ? vector2D2 : secAxis);
		_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[1] = new CircularSector(_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[0].End, vector2D);
		_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[2] = new CircularSector(_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[1].End, SwappedAxis ? secAxis : vector2D2);
		_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[3] = new CircularSector(_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[2].End, mainAxis);
	}

	public int Quadrant(Point2D point)
	{
		for (int i = 0; i < _0023_003DzIDavK_00243UDgItqCFTBg_003D_003D.Length; i++)
		{
			if (_0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[i].Contains(point.AsVector))
			{
				return i;
			}
		}
		return 0;
	}

	public Interval Locate(Point2D point, out int quadIndex)
	{
		return _0023_003DzIDavK_00243UDgItqCFTBg_003D_003D[quadIndex = Quadrant(point)].Domain;
	}
}
