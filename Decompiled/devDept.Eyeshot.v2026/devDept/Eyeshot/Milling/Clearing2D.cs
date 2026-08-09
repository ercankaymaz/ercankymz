using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Clearing2D : Machining
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

	public Clearing2D(Setup setup, EndMill cutter, Geometry2D geometry, Interval zRange, double stepOver, double stepDown)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		_0023_003DzuS2gpoXwUHMF = setup.Stock;
		base.stepOver = stepOver;
		EstimateSafetyHeights(_0023_003DzuS2gpoXwUHMF);
		pocketRamp = new HelixRamp(GetDefaultHelixRampRadius(cutter), DefaultHelixRampAngle, GetDefaultRampClearanceHeight(cutter));
		Ramp = pocketRamp;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		double[] array = Machining.ComputeStepsZ(zRange.Low, Math.Max(zRange.High, _0023_003DzuS2gpoXwUHMF.RangeZ.Max), stepDown, tolerance, 0.0);
		Region outerRegion = Machining.GetOuterRegion(cutter, _0023_003DzuS2gpoXwUHMF, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), tolerance);
		bool flag = base.CutDirectionMode != cutDirectionType.Conventional;
		Point2D[][] polylines = ((Geometry2D)geometry).GetPolylines(_0023_003Dz9cS3uG0_003D);
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D>(polylines.Length);
		list.AddRange(_0023_003DzEHrosn01le6VGB6o1hxgJL17jjLqVuSXsBL1dho_003D._0023_003DzGXWQSv7Yxgb3eaY4Ig_003D_003D(Tuple.Create(0.0, polylines), outerRegion.BoxMin, outerRegion.BoxMax, base.RadialStockToLeave + cutter.Diameter / 2.0, stepOver, 0.0, outerRegion, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: false, flag, out var _0023_003DzWaFlkhfmYCja));
		Region[] array2 = _0023_003DzWaFlkhfmYCja;
		foreach (Region region in array2)
		{
			list.AddRange(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(region, Machining._0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(region.ContourList, tolerance), cutter, stepOver, base.RadialStockToLeave, 0.0, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: false, !flag, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, progress, ct));
		}
		base.ComputingPassesText = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870);
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] array3 = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[array.Length][];
		for (int j = 0; j < array.Length; j++)
		{
			array3[j] = Machining._0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(list, array[j]);
			if (!UpdateProgressAndCheckCancelled(j, array.Length, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), progress, ct))
			{
				return;
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(array3, log, _0023_003DzoQcRoMY_003D: false, 0.0, _0023_003Dzbu8BV15Qqzan: false);
	}
}
