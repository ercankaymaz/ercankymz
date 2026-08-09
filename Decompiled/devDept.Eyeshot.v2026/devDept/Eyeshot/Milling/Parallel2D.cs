using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Parallel2D : Machining
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzcSl0AvNzoUMk2BC0Lmxtz70_003D;

	protected double angle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzRJeilrSpQfYaGDQ_0024zQ_003D_003D;

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

	public Parallel2D(Setup setup, EndMill cutter, Geometry2D geometry, double stepOver, double angleInRad, Interval zRange, double stepDown)
		: base(setup, cutter, geometry, zRange, stepDown)
	{
		base.stepOver = stepOver;
		angle = angleInRad;
		EstimateSafetyHeights();
		base.CutDirectionMode = cutDirectionType.Mixed;
		double defaultRampClearanceHeight = GetDefaultRampClearanceHeight(cutter);
		base.LeadIn = null;
		Ramp = new PlungeRamp(defaultRampClearanceHeight);
	}

	public Parallel2D(Setup setup, EndMill cutter, Geometry2D geometry, double stepOver, double angleInRad, double zHeight)
		: this(setup, cutter, geometry, stepOver, angleInRad, new Interval(zHeight, 0.0), Math.Abs(zHeight))
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		double[] array = Machining.ComputeStepsZ(zRange.Low, zRange.High, stepDown, tolerance, 0.0);
		Point2D[][] polylines = ((Geometry2D)geometry).GetPolylines(_0023_003Dz9cS3uG0_003D);
		Point2D[][][] array2 = new Point2D[1][][] { polylines };
		if (_0023_003DzW3dseMxxH7Ha(array2[0], array, angle, stepOver, 0.0 - (base.RadialStockToLeave + cutter.Diameter / 2.0), base.Tolerance, progress, ct, out var _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D))
		{
			return;
		}
		List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]> list = new List<_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[]>(array.Length * _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D.Count);
		if (!OrderByDepth)
		{
			for (int i = 0; i < _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D.Count; i++)
			{
				double[] array3 = array;
				foreach (double _0023_003DzId5C3LA_003D in array3)
				{
					list.Add(Machining._0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(_0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D[i], _0023_003DzId5C3LA_003D));
					if (!UpdateProgressAndCheckCancelled(i, array.Length, base.ComputingPassesText, progress, ct))
					{
						return;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < array.Length; k++)
			{
				foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] item in _0023_003DzX_00249gjOjmY54P_IlmJg_003D_003D)
				{
					list.Add(Machining._0023_003DzJpHEdUozzyq7hbZuBg_003D_003D(item, array[k]));
					if (!UpdateProgressAndCheckCancelled(k, array.Length, base.ComputingPassesText, progress, ct))
					{
						return;
					}
				}
			}
		}
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(list.ToArray(), log, base.CutDirectionMode == cutDirectionType.Mixed, _0023_003DzRJeilrSpQfYaGDQ_0024zQ_003D_003D, _0023_003Dzbu8BV15Qqzan: false);
	}
}
