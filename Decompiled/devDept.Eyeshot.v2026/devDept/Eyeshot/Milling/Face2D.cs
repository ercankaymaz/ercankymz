using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Face2D : Machining
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzH0_axVQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzFRxYk4OWwbvs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzYD_Yi5DJJpo_0024;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz_0024u0_qDOA_2N4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzRJeilrSpQfYaGDQ_0024zQ_003D_003D;

	public Face2D(Setup setup, EndMill cutter, GeometryBase geometry, double zHeight, double stepOver, double angleInRadians, double verticalLeadAmount)
		: base(setup, cutter, geometry)
	{
		_0023_003DztGdcVOA_003D(setup, zHeight, stepOver, angleInRadians, verticalLeadAmount);
	}

	public Face2D(Setup setup, EndMill cutter, GeometryBase geometry, double stepOver, double angleInRadians, double verticalLeadAmount)
		: base(null, cutter, geometry)
	{
		_0023_003DztGdcVOA_003D(setup, geometry.GetBoxMax(setup).Z, stepOver, angleInRadians, verticalLeadAmount);
	}

	private void _0023_003DztGdcVOA_003D(Setup _0023_003Dz9cS3uG0_003D, double _0023_003Dz8ZbKIrg_003D, double _0023_003DzhyOajS0hC3zg, double _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D, double _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D)
	{
		stepOver = _0023_003DzhyOajS0hC3zg;
		_0023_003DzH0_axVQ_003D = _0023_003DzNrnMF6eJlTJhmcp9nA_003D_003D;
		_0023_003Dz_0024u0_qDOA_2N4 = _0023_003Dz8ZbKIrg_003D;
		_0023_003DzRJeilrSpQfYaGDQ_0024zQ_003D_003D = _0023_003Dzseq5WyGhlSKLfWtFbw_003D_003D;
		if (_0023_003Dz9cS3uG0_003D.Stock != null)
		{
			_0023_003Dz9cS3uG0_003D.Stock.GetSizeOnPlane(_0023_003Dz9cS3uG0_003D.Plane, out _0023_003DzFRxYk4OWwbvs, out _0023_003DzYD_Yi5DJJpo_0024);
		}
		else
		{
			if (geometry == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302994662));
			}
			_0023_003DzFRxYk4OWwbvs = new Point2D(geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D).X, geometry.GetBoxMin(_0023_003Dz9cS3uG0_003D).Y);
			_0023_003DzYD_Yi5DJJpo_0024 = new Point2D(geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).X, geometry.GetBoxMax(_0023_003Dz9cS3uG0_003D).Y);
		}
		LinearPath linearPath = new LinearPath(_0023_003Dz9cS3uG0_003D.Plane, _0023_003DzFRxYk4OWwbvs, _0023_003DzYD_Yi5DJJpo_0024);
		linearPath.Regen(0.0);
		geometry = new Geometry2D(linearPath);
		geometry._0023_003DztGdcVOA_003D(_0023_003Dz9cS3uG0_003D);
		base.CutDirectionMode = cutDirectionType.Mixed;
		base.LeadIn = null;
		Ramp = null;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		Point2D point2D = (Point2D)_0023_003DzFRxYk4OWwbvs.Clone();
		Point2D point2D2 = (Point2D)_0023_003DzYD_Yi5DJJpo_0024.Clone();
		point2D.X -= base.RadialStockToLeave;
		point2D.Y -= base.RadialStockToLeave;
		point2D2.X += base.RadialStockToLeave;
		point2D2.Y += base.RadialStockToLeave;
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[][] _0023_003DzosMf4QgVa5ec = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[1][] { _0023_003DzgawiDGPWgmCX(point2D, point2D2, _0023_003DzH0_axVQ_003D, stepOver, _0023_003Dz_0024u0_qDOA_2N4, base.CutDirectionMode, 0.0) };
		_0023_003DzZxtbOpnFrGnWMjYnCQ_003D_003D(_0023_003DzosMf4QgVa5ec, log, _0023_003DzoQcRoMY_003D: false, _0023_003DzRJeilrSpQfYaGDQ_0024zQ_003D_003D, _0023_003Dzbu8BV15Qqzan: false);
	}

	internal static _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] _0023_003DzgawiDGPWgmCX(Point2D _0023_003DzDPcjoBJLcqli, Point2D _0023_003Dz_0024N_0024yKptW9BoC, double _0023_003Dz6pajdGM_003D, double _0023_003Dz8uslNzRAwfBK, double _0023_003Dz9NrCn_o_003D, cutDirectionType _0023_003DzGAgovQqX5UzS, double _0023_003DzfBEBL_o_003D)
	{
		Region region = new Region(new LinearPath(_0023_003DzDPcjoBJLcqli, _0023_003Dz_0024N_0024yKptW9BoC));
		region.Regen(0.0);
		if (_0023_003DzfBEBL_o_003D != 0.0)
		{
			region = Utility.DetectRegionsFromContours(region.QuickOffset(_0023_003DzfBEBL_o_003D, cornerType.Miter, 0.0))[0];
		}
		List<_0023_003Dz3ORRwnUaVbd8> list = Machining._0023_003Dz7VChRYh7zEAu(region, _0023_003Dz6pajdGM_003D, _0023_003Dz8uslNzRAwfBK);
		_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array = new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			Point3D[] array2 = new Point3D[list[i]._0023_003DzQCpIBcjML_Au.Count * 2];
			if (_0023_003DzGAgovQqX5UzS == cutDirectionType.Climb || (_0023_003DzGAgovQqX5UzS == cutDirectionType.Mixed && i % 2 == 1))
			{
				for (int num = list[i]._0023_003DzQCpIBcjML_Au.Count - 1; num >= 0; num--)
				{
					foreach (_0023_003Dzd4ZLeTNSkXOn item in list[i]._0023_003DzQCpIBcjML_Au)
					{
						array2[1] = new Point3D(item._0023_003DzQ9zpGF0_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D, item._0023_003DzQ9zpGF0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D, _0023_003Dz9NrCn_o_003D);
						array2[0] = new Point3D(item._0023_003DzQ9zpGF0_003D._0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D, item._0023_003DzQ9zpGF0_003D._0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D, _0023_003Dz9NrCn_o_003D);
					}
				}
			}
			else
			{
				for (int j = 0; j < list[i]._0023_003DzQCpIBcjML_Au.Count; j++)
				{
					foreach (_0023_003Dzd4ZLeTNSkXOn item2 in list[i]._0023_003DzQCpIBcjML_Au)
					{
						array2[0] = new Point3D(item2._0023_003DzQ9zpGF0_003D._0023_003DzFj_0024IqDQ_003D._0023_003DzBJFJHwk_003D, item2._0023_003DzQ9zpGF0_003D._0023_003DzFj_0024IqDQ_003D._0023_003Dz40R7bAU_003D, _0023_003Dz9NrCn_o_003D);
						array2[1] = new Point3D(item2._0023_003DzQ9zpGF0_003D._0023_003DzjdeMMkk_003D._0023_003DzBJFJHwk_003D, item2._0023_003DzQ9zpGF0_003D._0023_003DzjdeMMkk_003D._0023_003Dz40R7bAU_003D, _0023_003Dz9NrCn_o_003D);
					}
				}
			}
			array[i] = new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(array2);
		}
		if (_0023_003DzGAgovQqX5UzS == cutDirectionType.Mixed)
		{
			List<Point3D> list2 = new List<Point3D>(array.Length * 2);
			_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[] array3 = array;
			foreach (_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2 in array3)
			{
				list2.AddRange(_0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D2._0023_003DzFsatqHw_003D);
			}
			return new _0023_003Dzi_002412OVOc9hQdh7qT5DqhxqX0fLgxhXPIBSZ0u4Q_003D[1]
			{
				new _0023_003DzV2oSLtcAc39qqlMrcWLrfmdnDGqva37BJrJ8NzI_003D(list2.ToArray())
			};
		}
		return array;
	}
}
