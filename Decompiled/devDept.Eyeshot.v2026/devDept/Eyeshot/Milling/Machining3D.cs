using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public abstract class Machining3D : Machining
{
	protected const double ANG_THRESHOLD = 1E-06;

	protected internal devDept.Eyeshot.Entities.Region boundary;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzRQu_002482trwaob859WVQ09g2k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFU1GZoRauq_0024sTX3DiG_5QPw_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302995192);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzvGjCoO_0024_c7nPnFBROMspLSs9i6TL;

	public double BoundaryOffset
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRQu_002482trwaob859WVQ09g2k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRQu_002482trwaob859WVQ09g2k_003D = value;
		}
	}

	public string PreparingGeometryText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFU1GZoRauq_0024sTX3DiG_5QPw_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFU1GZoRauq_0024sTX3DiG_5QPw_003D = value;
		}
	}

	public double AxialStockToLeave
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvGjCoO_0024_c7nPnFBROMspLSs9i6TL;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvGjCoO_0024_c7nPnFBROMspLSs9i6TL = value;
		}
	}

	protected Machining3D(Setup setup, EndMill endMill, Geometry3D geometry)
		: base(setup, endMill, geometry)
	{
		_0023_003DztGdcVOA_003D();
	}

	protected Machining3D(Setup setup, EndMill endMill, Geometry3D geometry, Interval zRange, double stepDown)
		: base(setup, endMill, geometry, zRange, stepDown)
	{
		_0023_003DztGdcVOA_003D();
	}

	private void _0023_003DztGdcVOA_003D()
	{
		tessellationColor = Color.MistyRose;
	}

	protected double GetSampling()
	{
		return cutter.Diameter / 10.0;
	}

	protected Point3D[][] Filter(Point3D[][] loops)
	{
		Point3D[][] array = new Point3D[loops.Length][];
		for (int i = 0; i < loops.Length; i++)
		{
			array[i] = Utility.Simplify(loops[i], tolerance / 10.0);
		}
		return array.ToArray();
	}

	public Entity GetBoundary()
	{
		return new MachiningBoundary(boundary.ContourList.ToArray(), boundary.Plane)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = Color.FromArgb(100, Color.GreenYellow)
		};
	}

	public Entity GetBoundary(Color color)
	{
		return new MachiningBoundary(boundary.ContourList.ToArray())
		{
			ColorMethod = colorMethodType.byEntity,
			Color = color
		};
	}

	protected static void TranslateZ(Point3D[][] pass, double axialStockToLeave, Interval zRange)
	{
		foreach (Point3D[] array in pass)
		{
			foreach (Point3D point3D in array)
			{
				point3D.Z += axialStockToLeave;
				if (point3D.Z < zRange.Low)
				{
					point3D.Z = zRange.Low;
				}
			}
		}
	}

	protected static double[] ComputeStepsZ(Interval zRange, double stepDown, bool addFlat, Setup setup, Geometry3D geometry, PolyRegion2D boundary, double axialStockToLeave, double tolerance, out double[] flatZ)
	{
		double min = zRange.Min;
		double max = zRange.Max;
		double[] array = Machining.ComputeStepsZ(min, max, stepDown, tolerance, axialStockToLeave);
		flatZ = null;
		if (addFlat)
		{
			HashSet<double> _0023_003DzZmVLp_g_003D = new HashSet<double>(Geometry3D._0023_003DzF4oOnFoXU6iK(array, zRange));
			flatZ = geometry.GetFlatZ(setup).ToArray();
			if (boundary != null)
			{
				flatZ = geometry.GetInsideFlatZ(setup, boundary, tolerance);
			}
			double[] array2 = flatZ;
			foreach (double num in array2)
			{
				if (num >= min && num <= max)
				{
					double num2 = num + axialStockToLeave;
					if (num2 >= min && num2 <= max)
					{
						_0023_003DzZmVLp_g_003D.Add(num2 + tolerance);
					}
				}
			}
			_0023_003DzOtoR6t0N0mZl(ref _0023_003DzZmVLp_g_003D, flatZ, stepDown, axialStockToLeave, tolerance);
			List<double> list = new List<double>(_0023_003DzZmVLp_g_003D);
			list.Sort();
			list.Reverse();
			for (int j = 0; j < list.Count - 1; j++)
			{
				_ = list[j];
				_ = list[j + 1];
			}
			array = list.ToArray();
		}
		return array;
	}

	private static void _0023_003DzOtoR6t0N0mZl(ref HashSet<double> _0023_003DzZmVLp_g_003D, double[] _0023_003DzgoPbyW0_003D, double _0023_003Dze7BSJGz05Omq, double _0023_003DzgEOOiJekHFyrRbpsQQ_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		HashSet<double> hashSet = new HashSet<double>();
		foreach (double item in _0023_003DzZmVLp_g_003D)
		{
			bool flag = true;
			for (int i = 0; i < _0023_003DzgoPbyW0_003D.Length; i++)
			{
				double num = _0023_003DzgoPbyW0_003D[i] + _0023_003DzgEOOiJekHFyrRbpsQQ_003D_003D + _0023_003Dzm0CYiiE_003D;
				if (item != num && Math.Abs(Math.Abs(num) - Math.Abs(item + _0023_003DzgEOOiJekHFyrRbpsQQ_003D_003D)) < _0023_003Dze7BSJGz05Omq / 10.0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				hashSet.Add(item);
			}
		}
		_0023_003DzZmVLp_g_003D = new HashSet<double>(hashSet);
	}
}
