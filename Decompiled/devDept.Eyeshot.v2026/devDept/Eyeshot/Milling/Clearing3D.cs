using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Clearing3D : Contour3D
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

	public Clearing3D(Setup setup, EndMill cutter, Geometry3D geometry, Interval zRange, double stepDown, double stepOver)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		base.stepOver = stepOver;
		_0023_003DzuS2gpoXwUHMF = setup.Stock;
		EstimateSafetyHeights(_0023_003DzuS2gpoXwUHMF);
		base.Tolerance = 0.1 * Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, setup.Units);
		base.LeadIn = null;
		base.LeadOut = null;
		pocketRamp = new HelixRamp(GetDefaultHelixRampRadius(cutter), DefaultHelixRampAngle, GetDefaultRampClearanceHeight(cutter));
		Ramp = pocketRamp;
	}

	public Clearing3D(Setup setup, EndMill cutter, Geometry3D geometry, Region boundary, Interval zRange, double stepDown, double stepOver)
		: this(setup, cutter, geometry, zRange, stepDown, stepOver)
	{
		base.boundary = boundary;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		PolyRegion2D boundaryPolyReg;
		Tuple<double, Point2D[][]>[] waterlines = GetWaterlines(null, progress, ct, out boundaryPolyReg);
		if (waterlines == null)
		{
			return;
		}
		Region transformedBoundary = Machining.GetTransformedBoundary(_0023_003DzuS2gpoXwUHMF, _0023_003Dz9cS3uG0_003D);
		Region outerRegion = Machining.GetOuterRegion(cutter, transformedBoundary, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D), geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D), tolerance);
		base.ComputingPassesText = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870);
		bool _0023_003DzEXLcE10_003D = base.CutDirectionMode != cutDirectionType.Conventional;
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>();
		for (int i = 0; i < waterlines.Length; i++)
		{
			Tuple<double, Point2D[][]> tuple = waterlines[i];
			double item = tuple.Item1;
			if (tuple.Item2.Length != 0)
			{
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item2 = _0023_003DzEHrosn01le6VGB6o1hxgJL17jjLqVuSXsBL1dho_003D._0023_003DzL9woobs_003D(tuple, cutter, outerRegion, boundaryPolyReg, outerRegion.BoxMin, outerRegion.BoxMax, stepOver, 0.0, item, tolerance, _0023_003DzEXLcE10_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), this, progress, ct);
				list.Add(item2);
			}
			else
			{
				if (!Machining.AreEqualZ(item, geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z, tolerance) && !(item > geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Z))
				{
					continue;
				}
				_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item3 = Face2D._0023_003DzgawiDGPWgmCX(outerRegion.BoxMin, outerRegion.BoxMax, 0.0, stepOver, item, base.CutDirectionMode, base.BoundaryOffset);
				list.Add(item3);
			}
			if (!UpdateProgressAndCheckCancelled(i, waterlines.Length, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994870), progress, ct))
			{
				return;
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(list.ToArray(), log, _0023_003DzoQcRoMY_003D: false, 0.0, _0023_003Dzbu8BV15Qqzan: false);
	}
}
