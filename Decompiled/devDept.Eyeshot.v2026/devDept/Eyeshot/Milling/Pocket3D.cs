using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Pocket3D : Contour3D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stock _0023_003DzuS2gpoXwUHMF;

	public override Ramp Ramp
	{
		get
		{
			return pocketRamp;
		}
		set
		{
			pocketRamp = value;
		}
	}

	public Pocket3D(Setup setup, EndMill cutter, Geometry3D geometry, Interval zRange, double stepDown, double stepOver)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		_0023_003DztGdcVOA_003D(setup, cutter, stepOver);
	}

	public Pocket3D(Setup setup, EndMill cutter, Geometry3D geometry, double[] zHeights, double stepOver)
		: base(setup, cutter, geometry, zHeights)
	{
		_0023_003DztGdcVOA_003D(setup, cutter, stepOver);
	}

	public Pocket3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, Interval zRange, double stepDown, double stepOver)
		: this(setup, cutter, geometry, zRange, stepDown, stepOver)
	{
		base.boundary = boundary;
	}

	public Pocket3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, double[] zHeights, double stepOver)
		: this(setup, cutter, geometry, zHeights, stepOver)
	{
		base.boundary = boundary;
	}

	private void _0023_003DztGdcVOA_003D(Setup _0023_003Dz9cS3uG0_003D, EndMill _0023_003DzzhSDYPa50tjn, double _0023_003Dz8uslNzRAwfBK)
	{
		stepOver = _0023_003Dz8uslNzRAwfBK;
		_0023_003DzuS2gpoXwUHMF = _0023_003Dz9cS3uG0_003D.Stock;
		base.Tolerance = 0.1 * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, _0023_003Dz9cS3uG0_003D.Units);
		base.LeadIn = null;
		base.LeadOut = null;
		pocketRamp = new HelixRamp(GetDefaultHelixRampRadius(_0023_003DzzhSDYPa50tjn), DefaultHelixRampAngle, GetDefaultRampClearanceHeight(_0023_003DzzhSDYPa50tjn));
		Ramp = pocketRamp;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		Tuple<double, PolyRegion2D[]>[] rawPasses = GetRawPasses(progress, ct);
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		Tuple<double, PolyRegion2D[]>[] array = rawPasses;
		foreach (Tuple<double, PolyRegion2D[]> tuple in array)
		{
			PolyRegion2D[] item = tuple.Item2;
			for (int j = 0; j < item.Length; j++)
			{
				Region region = item[j].ToRegion(new Plane(new Point3D(0.0, 0.0, tuple.Item1), Vector3D.AxisX, Vector3D.AxisY));
				list.Add(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(region, Machining._0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(region.ContourList, base.Tolerance), cutter, stepOver, 0.0, tuple.Item1, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: true, base.CutDirectionMode == cutDirectionType.Conventional, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, progress, ct));
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(list.ToArray(), log, _0023_003DzoQcRoMY_003D: true, 0.0, _0023_003Dzbu8BV15Qqzan: false);
	}

	protected new Tuple<double, PolyRegion2D[]>[] GetRawPasses(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		PolyRegion2D boundaryPolyReg;
		Tuple<double, Point2D[][]>[] waterlines = GetWaterlines(_0023_003DzuS2gpoXwUHMF, progress, ct, out boundaryPolyReg);
		if (waterlines == null)
		{
			return Array.Empty<Tuple<double, PolyRegion2D[]>>();
		}
		if (boundaryPolyReg == null && _0023_003DzuS2gpoXwUHMF != null)
		{
			boundaryPolyReg = new PolyRegion2D(_0023_003DzuS2gpoXwUHMF, tolerance);
		}
		return GetRawPasses(waterlines, boundaryPolyReg, progress, ct);
	}
}
