using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class ComputeDistances : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<double, int, KeyValuePair<double, int>> _0023_003Dz4r8Rr35Bk_fzaIJ7Cg_003D_003D;

		public static Func<KeyValuePair<double, int>, double> _0023_003DzcjzqlJOdQgZUyFL5XA_003D_003D;

		public static Func<KeyValuePair<double, int>, double> _0023_003DzLnbJ6u3K93TYGQV_NA_003D_003D;

		public static Func<KeyValuePair<double, int>, int> _0023_003DzUXTy2E3znn13OQfjeA_003D_003D;

		internal KeyValuePair<double, int> _0023_003DzQMdA4jYF0SlJ3K_q4B5U3yY_003D(double _0023_003DzBJFJHwk_003D, int _0023_003DzN6G05Lg_003D)
		{
			return new KeyValuePair<double, int>(_0023_003DzBJFJHwk_003D, _0023_003DzN6G05Lg_003D);
		}

		internal double _0023_003Dz7jtLJ9pgs3SqqrlUqIl0Bac_003D(KeyValuePair<double, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal double _0023_003DzjBxe4nuE6I1wcSnjv3R3d4c_003D(KeyValuePair<double, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Key;
		}

		internal int _0023_003DzMCPL43vMOpnUxcHfBAlpgeg_003D(KeyValuePair<double, int> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_GhejBCMkU7hEyRkiTv7XaXtPYu1 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953164);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Surface[] _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly PointCloud _0023_003Dzq5RhxIs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz0Jn_0024JRQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzAZT6BTk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzbYQNlNI_003D;

	public string ComputingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_GhejBCMkU7hEyRkiTv7XaXtPYu1;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_GhejBCMkU7hEyRkiTv7XaXtPYu1 = value;
		}
	}

	public double[] Result => _0023_003DzbYQNlNI_003D;

	public double Min => _0023_003DzAZT6BTk_003D;

	public double Max => _0023_003Dz0Jn_0024JRQ_003D;

	private ComputeDistances()
	{
		_0023_003DzZEROl_YJ_9b_0024tIOMvw_003D_003D._0023_003DzCBXaK_002496NUpX(3, this);
	}

	public ComputeDistances(IList<Surface> surfaces, FastPointCloud fpc)
		: this()
	{
		if (surfaces.Count == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953149), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953117));
		}
		_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D = surfaces.ToArray();
		_0023_003Dzq5RhxIs_003D = fpc.ConvertToPointCloud();
	}

	public ComputeDistances(Brep brep, PointCloud pc)
		: this()
	{
		brep.Rebuild(0.0, soft: true);
		_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D = brep.ConvertToSurfaces();
		_0023_003Dzq5RhxIs_003D = pc;
	}

	public ComputeDistances(IList<Surface> surfaces, PointCloud pc)
		: this()
	{
		if (surfaces.Count == 0)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953149), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953098));
		}
		_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D = surfaces.ToArray();
		_0023_003Dzq5RhxIs_003D = pc;
	}

	public ComputeDistances(Brep brep, FastPointCloud fpc)
		: this()
	{
		brep.Rebuild(0.0, soft: true);
		_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D = brep.ConvertToSurfaces();
		_0023_003Dzq5RhxIs_003D = fpc.ConvertToPointCloud();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		int num = _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D.Length;
		Surface[] array = new Surface[num];
		Point3D[] array2 = new Point3D[num];
		Point3D[] array3 = new Point3D[num];
		for (int i = 0; i < num; i++)
		{
			(array[i] = (Surface)_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[i].Clone()).ControlBoundingBox(out array2[i], out array3[i]);
		}
		double num2 = 0.0;
		_0023_003DzbYQNlNI_003D = new double[_0023_003Dzq5RhxIs_003D.Vertices.Length];
		for (int j = 0; j < _0023_003DzbYQNlNI_003D.Length; j++)
		{
			_0023_003DzbYQNlNI_003D[j] = double.MaxValue;
		}
		_0023_003DzAZT6BTk_003D = double.MaxValue;
		_0023_003Dz0Jn_0024JRQ_003D = double.MinValue;
		for (int k = 0; k < _0023_003Dzq5RhxIs_003D.Vertices.Length; k++)
		{
			Point3D point3D = _0023_003Dzq5RhxIs_003D.Vertices[k];
			double[] array4 = new double[array.Length];
			for (int l = 0; l < num; l++)
			{
				array4[l] = _0023_003DzWNU0A70C687_0024(point3D, array2[l], array3[l]);
			}
			List<KeyValuePair<double, int>> source = array4.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzQMdA4jYF0SlJ3K_q4B5U3yY_003D).OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz7jtLJ9pgs3SqqrlUqIl0Bac_003D).ToList();
			List<double> list = source.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzjBxe4nuE6I1wcSnjv3R3d4c_003D).ToList();
			List<int> list2 = source.Select(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzMCPL43vMOpnUxcHfBAlpgeg_003D).ToList();
			for (int m = 0; m < num; m++)
			{
				if (list[m] <= _0023_003DzbYQNlNI_003D[k] + num2)
				{
					array[list2[m]].ClosestPointTo(point3D, out var closest);
					double num3 = Point3D.Distance(point3D, closest);
					if (num3 < _0023_003DzbYQNlNI_003D[k])
					{
						_0023_003DzbYQNlNI_003D[k] = num3;
					}
					continue;
				}
				if (_0023_003DzbYQNlNI_003D[k] < _0023_003DzAZT6BTk_003D)
				{
					_0023_003DzAZT6BTk_003D = _0023_003DzbYQNlNI_003D[k];
				}
				if (_0023_003DzbYQNlNI_003D[k] > _0023_003Dz0Jn_0024JRQ_003D)
				{
					_0023_003Dz0Jn_0024JRQ_003D = _0023_003DzbYQNlNI_003D[k];
				}
				m = num;
			}
			if (!UpdateProgressAndCheckCancelled(k, _0023_003Dzq5RhxIs_003D.Vertices.Length, ComputingText, progress, ct))
			{
				break;
			}
		}
	}

	private static double _0023_003DzWNU0A70C687_0024(Point3D _0023_003DzMlCq3wk_003D, Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		if (_0023_003DzMlCq3wk_003D.X < _0023_003DzF7v9r2A_003D.X - Utility._0023_003DzheSR8QM7q9ya)
		{
			num = Math.Abs(_0023_003DzF7v9r2A_003D.X - _0023_003DzMlCq3wk_003D.X);
		}
		else if (_0023_003DzMlCq3wk_003D.X > _0023_003Dz8dK2uhU_003D.X + Utility._0023_003DzheSR8QM7q9ya)
		{
			num = Math.Abs(_0023_003Dz8dK2uhU_003D.X - _0023_003DzMlCq3wk_003D.X);
		}
		if (_0023_003DzMlCq3wk_003D.Y < _0023_003DzF7v9r2A_003D.Y - Utility._0023_003DzheSR8QM7q9ya)
		{
			num2 = Math.Abs(_0023_003DzF7v9r2A_003D.Y - _0023_003DzMlCq3wk_003D.Y);
		}
		else if (_0023_003DzMlCq3wk_003D.Y > _0023_003Dz8dK2uhU_003D.Y + Utility._0023_003DzheSR8QM7q9ya)
		{
			num2 = Math.Abs(_0023_003Dz8dK2uhU_003D.Y - _0023_003DzMlCq3wk_003D.Y);
		}
		if (_0023_003DzMlCq3wk_003D.Z < _0023_003DzF7v9r2A_003D.Z - Utility._0023_003DzheSR8QM7q9ya)
		{
			num3 = Math.Abs(_0023_003DzF7v9r2A_003D.Z - _0023_003DzMlCq3wk_003D.Z);
		}
		else if (_0023_003DzMlCq3wk_003D.Z > _0023_003Dz8dK2uhU_003D.Z + Utility._0023_003DzheSR8QM7q9ya)
		{
			num3 = Math.Abs(_0023_003Dz8dK2uhU_003D.Z - _0023_003DzMlCq3wk_003D.Z);
		}
		return Math.Sqrt(num * num + num2 * num2 + num3 * num3);
	}
}
