using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Pocket2D : Machining
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stock _0023_003DzuS2gpoXwUHMF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D;

	public bool OrderByDepth
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D = value;
		}
	}

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

	public Pocket2D(Setup setup, EndMill cutter, Geometry2D geometry, Interval zRange, double stepDown, double stepOver)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		_0023_003DzuS2gpoXwUHMF = setup.Stock;
		base.stepOver = stepOver;
		EstimateSafetyHeights(_0023_003DzuS2gpoXwUHMF);
		base.LeadIn = null;
		pocketRamp = new HelixRamp(GetDefaultHelixRampRadius(cutter), DefaultHelixRampAngle, GetDefaultRampClearanceHeight(cutter));
		Ramp = pocketRamp;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		double[] array = Machining.ComputeStepsZ(zRange.Low, zRange.High, stepDown, tolerance, 0.0);
		PolyRegion2D[] rawPass = GetRawPass(progress, ct);
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		for (int i = 0; i < rawPass.Length; i++)
		{
			Region region = rawPass[i].ToRegion(Plane.XY);
			list.Add(_0023_003Dz55Dkmbmg6624t0dJodGYNCykzCexP6X33sHWwetdiIoK._0023_003DzL9woobs_003D(region, Machining._0023_003DzCbWHpRMtyGGHDyDCFQ_003D_003D(region.ContourList, base.Tolerance), cutter, stepOver, 0.0, 0.0, _0023_003DzmOwRH7DwvzwvKXv51_0024EFGd8_003D: false, base.CutDirectionMode == cutDirectionType.Conventional, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, progress, ct));
		}
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list2 = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>(array.Length * list.Count);
		if (!OrderByDepth)
		{
			int count = list.Count;
			for (int j = 0; j < count; j++)
			{
				double[] array2 = array;
				foreach (double _0023_003DzId5C3LA_003D in array2)
				{
					list2.Add(Machining._0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(list[j], _0023_003DzId5C3LA_003D));
				}
				if (!UpdateProgressAndCheckCancelled(j, count, base.ComputingPassesText, progress, ct))
				{
					return;
				}
			}
		}
		else
		{
			int num = array.Length;
			for (int l = 0; l < num; l++)
			{
				foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item in list)
				{
					list2.Add(Machining._0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(item, array[l]));
				}
				if (!UpdateProgressAndCheckCancelled(l, num, base.ComputingPassesText, progress, ct))
				{
					return;
				}
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(list2.ToArray(), log, _0023_003DzoQcRoMY_003D: true, 0.0, _0023_003Dzbu8BV15Qqzan: false);
	}

	protected PolyRegion2D[] GetRawPass(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		PolyRegion2D boundaryPolyReg = ((_0023_003DzuS2gpoXwUHMF != null) ? new PolyRegion2D(Machining.GetTransformedBoundary(_0023_003DzuS2gpoXwUHMF, _0023_003Dz9cS3uG0_003D), tolerance) : null);
		Point2D[][] polylines = ((Geometry2D)geometry).GetPolylines(_0023_003Dz9cS3uG0_003D);
		Tuple<double, Point2D[][]>[] levels = new Tuple<double, Point2D[][]>[1] { Tuple.Create(0.0, polylines) };
		return GetRawPasses(levels, boundaryPolyReg, progress, ct)[0].Item2;
	}
}
