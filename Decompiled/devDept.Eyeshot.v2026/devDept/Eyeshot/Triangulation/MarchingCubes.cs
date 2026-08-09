using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation;

public class MarchingCubes : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<List<Point3D[]>> _0023_003DzJpcDcI8c57wA5DGAdg_003D_003D;

		internal List<Point3D[]> _0023_003DzhJUmc81ru8FJpKiMM_0024C6t64_003D()
		{
			return new List<Point3D[]>();
		}
	}

	private sealed class _0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D
	{
		public MarchingCubes _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public List<Point3D[]> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;

		internal List<Point3D[]> _0023_003DzImyailaPCZRVSZ9_lg_003D_003D(int _0023_003DzN6G05Lg_003D, ParallelLoopState _0023_003DzLdZiL78_003D, List<Point3D[]> _0023_003DzxmCET83Y2zEO)
		{
			double[,] array = new double[8, 3];
			double[] array2 = new double[8];
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs.nCellsInY; i++)
			{
				for (int j = 0; j < _0023_003DzopRx0_MBcTQs.nCellsInX; j++)
				{
					_0023_003DzopRx0_MBcTQs.ComputeCoords(j, i, _0023_003DzN6G05Lg_003D, array);
					array2[0] = _0023_003DzopRx0_MBcTQs.grid[j, i + 1, _0023_003DzN6G05Lg_003D];
					array2[1] = _0023_003DzopRx0_MBcTQs.grid[j + 1, i + 1, _0023_003DzN6G05Lg_003D];
					array2[2] = _0023_003DzopRx0_MBcTQs.grid[j + 1, i, _0023_003DzN6G05Lg_003D];
					array2[3] = _0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D];
					array2[4] = _0023_003DzopRx0_MBcTQs.grid[j, i + 1, _0023_003DzN6G05Lg_003D + 1];
					array2[5] = _0023_003DzopRx0_MBcTQs.grid[j + 1, i + 1, _0023_003DzN6G05Lg_003D + 1];
					array2[6] = _0023_003DzopRx0_MBcTQs.grid[j + 1, i, _0023_003DzN6G05Lg_003D + 1];
					array2[7] = _0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D + 1];
					_0023_003Dz5muzE45ca__0024hKx9QbA_003D_003D(array, array2, _0023_003DzopRx0_MBcTQs.IsoLevel, _0023_003DzxmCET83Y2zEO);
				}
			}
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003DzopRx0_MBcTQs.nCellsInZ, _0023_003DzopRx0_MBcTQs.ProgressBarText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003DzxmCET83Y2zEO;
		}

		internal void _0023_003DzKWjLAL76_0024Xb8wu9w4g_003D_003D(List<Point3D[]> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
			{
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		}
	}

	private sealed class _0023_003DzzfenD6ngsni7RY41oYe4G5I_003D
	{
		public MarchingCubes _0023_003DzopRx0_MBcTQs;

		public ScalarField3D _0023_003Dz743TWCo_003D;

		internal void _0023_003Dz_00246uQotdONA_0024NfDrTnA_003D_003D(int _0023_003DzN6G05Lg_003D)
		{
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs.nCellsInY + 1; i++)
			{
				for (int j = 0; j < _0023_003DzopRx0_MBcTQs.nCellsInX + 1; j++)
				{
					_0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D] = _0023_003Dz743TWCo_003D((float)(_0023_003DzopRx0_MBcTQs.gridOrigin.X + (double)((float)j * _0023_003DzopRx0_MBcTQs.cellSizeX)), (float)(_0023_003DzopRx0_MBcTQs.gridOrigin.Y + (double)((float)i * _0023_003DzopRx0_MBcTQs.cellSizeY)), (float)(_0023_003DzopRx0_MBcTQs.gridOrigin.Z + (double)((float)_0023_003DzN6G05Lg_003D * _0023_003DzopRx0_MBcTQs.cellSizeZ)));
				}
			}
		}
	}

	protected float[,,] grid;

	protected Point3D gridOrigin = Point3D.Origin;

	protected int nCellsInX;

	protected int nCellsInY;

	protected int nCellsInZ;

	protected float cellSizeX;

	protected float cellSizeY;

	protected float cellSizeZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzRmG6R1QGHAu__0024cNoQ4O78rY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302990892);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzmJo3pUxhOIfweQL2nlLUE9w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzuJyU_0024Mf8xSDiLCcInyNIhCI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Mesh.natureType _0023_003Dzcu3ag2JlMJ3_OsDY1fylKyY_003D = Mesh.natureType.Smooth;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int[] _0023_003DzaYsLbLWMUjkG = new int[256]
	{
		0, 265, 515, 778, 1030, 1295, 1541, 1804, 2060, 2309,
		2575, 2822, 3082, 3331, 3593, 3840, 400, 153, 915, 666,
		1430, 1183, 1941, 1692, 2460, 2197, 2975, 2710, 3482, 3219,
		3993, 3728, 560, 825, 51, 314, 1590, 1855, 1077, 1340,
		2620, 2869, 2111, 2358, 3642, 3891, 3129, 3376, 928, 681,
		419, 170, 1958, 1711, 1445, 1196, 2988, 2725, 2479, 2214,
		4010, 3747, 3497, 3232, 1120, 1385, 1635, 1898, 102, 367,
		613, 876, 3180, 3429, 3695, 3942, 2154, 2403, 2665, 2912,
		1520, 1273, 2035, 1786, 502, 255, 1013, 764, 3580, 3317,
		4095, 3830, 2554, 2291, 3065, 2800, 1616, 1881, 1107, 1370,
		598, 863, 85, 348, 3676, 3925, 3167, 3414, 2650, 2899,
		2137, 2384, 1984, 1737, 1475, 1226, 966, 719, 453, 204,
		4044, 3781, 3535, 3270, 3018, 2755, 2505, 2240, 2240, 2505,
		2755, 3018, 3270, 3535, 3781, 4044, 204, 453, 719, 966,
		1226, 1475, 1737, 1984, 2384, 2137, 2899, 2650, 3414, 3167,
		3925, 3676, 348, 85, 863, 598, 1370, 1107, 1881, 1616,
		2800, 3065, 2291, 2554, 3830, 4095, 3317, 3580, 764, 1013,
		255, 502, 1786, 2035, 1273, 1520, 2912, 2665, 2403, 2154,
		3942, 3695, 3429, 3180, 876, 613, 367, 102, 1898, 1635,
		1385, 1120, 3232, 3497, 3747, 4010, 2214, 2479, 2725, 2988,
		1196, 1445, 1711, 1958, 170, 419, 681, 928, 3376, 3129,
		3891, 3642, 2358, 2111, 2869, 2620, 1340, 1077, 1855, 1590,
		314, 51, 825, 560, 3728, 3993, 3219, 3482, 2710, 2975,
		2197, 2460, 1692, 1941, 1183, 1430, 666, 915, 153, 400,
		3840, 3593, 3331, 3082, 2822, 2575, 2309, 2060, 1804, 1541,
		1295, 1030, 778, 515, 265, 0
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int[,] _0023_003Dzy0JD_D_0024EUu3S = new int[256, 16]
	{
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 1, 9, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 8, 3, 9, 8, 1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, 1, 2, 10, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 2, 10, 0, 2, 9, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 8, 3, 2, 10, 8, 10, 9, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 11, 2, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 11, 2, 8, 11, 0, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 9, 0, 2, 3, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 11, 2, 1, 9, 11, 9, 8, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 10, 1, 11, 10, 3, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 10, 1, 0, 8, 10, 8, 11, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 9, 0, 3, 11, 9, 11, 10, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 8, 10, 10, 8, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 7, 8, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 3, 0, 7, 3, 4, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 1, 9, 8, 4, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 1, 9, 4, 7, 1, 7, 3, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, 8, 4, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 4, 7, 3, 0, 4, 1, 2, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 2, 10, 9, 0, 2, 8, 4, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 10, 9, 2, 9, 7, 2, 7, 3, 7,
			9, 4, -1, -1, -1, -1
		},
		{
			8, 4, 7, 3, 11, 2, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 4, 7, 11, 2, 4, 2, 0, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 0, 1, 8, 4, 7, 2, 3, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 7, 11, 9, 4, 11, 9, 11, 2, 9,
			2, 1, -1, -1, -1, -1
		},
		{
			3, 10, 1, 3, 11, 10, 7, 8, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 11, 10, 1, 4, 11, 1, 0, 4, 7,
			11, 4, -1, -1, -1, -1
		},
		{
			4, 7, 8, 9, 0, 11, 9, 11, 10, 11,
			0, 3, -1, -1, -1, -1
		},
		{
			4, 7, 11, 4, 11, 9, 9, 11, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 5, 4, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 5, 4, 0, 8, 3, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 5, 4, 1, 5, 0, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 5, 4, 8, 3, 5, 3, 1, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, 9, 5, 4, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 0, 8, 1, 2, 10, 4, 9, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 2, 10, 5, 4, 2, 4, 0, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 10, 5, 3, 2, 5, 3, 5, 4, 3,
			4, 8, -1, -1, -1, -1
		},
		{
			9, 5, 4, 2, 3, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 11, 2, 0, 8, 11, 4, 9, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 5, 4, 0, 1, 5, 2, 3, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 1, 5, 2, 5, 8, 2, 8, 11, 4,
			8, 5, -1, -1, -1, -1
		},
		{
			10, 3, 11, 10, 1, 3, 9, 5, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 9, 5, 0, 8, 1, 8, 10, 1, 8,
			11, 10, -1, -1, -1, -1
		},
		{
			5, 4, 0, 5, 0, 11, 5, 11, 10, 11,
			0, 3, -1, -1, -1, -1
		},
		{
			5, 4, 8, 5, 8, 10, 10, 8, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 7, 8, 5, 7, 9, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 3, 0, 9, 5, 3, 5, 7, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 7, 8, 0, 1, 7, 1, 5, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 5, 3, 3, 5, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 7, 8, 9, 5, 7, 10, 1, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 1, 2, 9, 5, 0, 5, 3, 0, 5,
			7, 3, -1, -1, -1, -1
		},
		{
			8, 0, 2, 8, 2, 5, 8, 5, 7, 10,
			5, 2, -1, -1, -1, -1
		},
		{
			2, 10, 5, 2, 5, 3, 3, 5, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 9, 5, 7, 8, 9, 3, 11, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 5, 7, 9, 7, 2, 9, 2, 0, 2,
			7, 11, -1, -1, -1, -1
		},
		{
			2, 3, 11, 0, 1, 8, 1, 7, 8, 1,
			5, 7, -1, -1, -1, -1
		},
		{
			11, 2, 1, 11, 1, 7, 7, 1, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 5, 8, 8, 5, 7, 10, 1, 3, 10,
			3, 11, -1, -1, -1, -1
		},
		{
			5, 7, 0, 5, 0, 9, 7, 11, 0, 1,
			0, 10, 11, 10, 0, -1
		},
		{
			11, 10, 0, 11, 0, 3, 10, 5, 0, 8,
			0, 7, 5, 7, 0, -1
		},
		{
			11, 10, 5, 7, 11, 5, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 6, 5, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, 5, 10, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 0, 1, 5, 10, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 8, 3, 1, 9, 8, 5, 10, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 6, 5, 2, 6, 1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 6, 5, 1, 2, 6, 3, 0, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 6, 5, 9, 0, 6, 0, 2, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 9, 8, 5, 8, 2, 5, 2, 6, 3,
			2, 8, -1, -1, -1, -1
		},
		{
			2, 3, 11, 10, 6, 5, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 0, 8, 11, 2, 0, 10, 6, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 1, 9, 2, 3, 11, 5, 10, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 10, 6, 1, 9, 2, 9, 11, 2, 9,
			8, 11, -1, -1, -1, -1
		},
		{
			6, 3, 11, 6, 5, 3, 5, 1, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 11, 0, 11, 5, 0, 5, 1, 5,
			11, 6, -1, -1, -1, -1
		},
		{
			3, 11, 6, 0, 3, 6, 0, 6, 5, 0,
			5, 9, -1, -1, -1, -1
		},
		{
			6, 5, 9, 6, 9, 11, 11, 9, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 10, 6, 4, 7, 8, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 3, 0, 4, 7, 3, 6, 5, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 9, 0, 5, 10, 6, 8, 4, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 6, 5, 1, 9, 7, 1, 7, 3, 7,
			9, 4, -1, -1, -1, -1
		},
		{
			6, 1, 2, 6, 5, 1, 4, 7, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 5, 5, 2, 6, 3, 0, 4, 3,
			4, 7, -1, -1, -1, -1
		},
		{
			8, 4, 7, 9, 0, 5, 0, 6, 5, 0,
			2, 6, -1, -1, -1, -1
		},
		{
			7, 3, 9, 7, 9, 4, 3, 2, 9, 5,
			9, 6, 2, 6, 9, -1
		},
		{
			3, 11, 2, 7, 8, 4, 10, 6, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 10, 6, 4, 7, 2, 4, 2, 0, 2,
			7, 11, -1, -1, -1, -1
		},
		{
			0, 1, 9, 4, 7, 8, 2, 3, 11, 5,
			10, 6, -1, -1, -1, -1
		},
		{
			9, 2, 1, 9, 11, 2, 9, 4, 11, 7,
			11, 4, 5, 10, 6, -1
		},
		{
			8, 4, 7, 3, 11, 5, 3, 5, 1, 5,
			11, 6, -1, -1, -1, -1
		},
		{
			5, 1, 11, 5, 11, 6, 1, 0, 11, 7,
			11, 4, 0, 4, 11, -1
		},
		{
			0, 5, 9, 0, 6, 5, 0, 3, 6, 11,
			6, 3, 8, 4, 7, -1
		},
		{
			6, 5, 9, 6, 9, 11, 4, 7, 9, 7,
			11, 9, -1, -1, -1, -1
		},
		{
			10, 4, 9, 6, 4, 10, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 10, 6, 4, 9, 10, 0, 8, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 0, 1, 10, 6, 0, 6, 4, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 3, 1, 8, 1, 6, 8, 6, 4, 6,
			1, 10, -1, -1, -1, -1
		},
		{
			1, 4, 9, 1, 2, 4, 2, 6, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 0, 8, 1, 2, 9, 2, 4, 9, 2,
			6, 4, -1, -1, -1, -1
		},
		{
			0, 2, 4, 4, 2, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 3, 2, 8, 2, 4, 4, 2, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 4, 9, 10, 6, 4, 11, 2, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 2, 2, 8, 11, 4, 9, 10, 4,
			10, 6, -1, -1, -1, -1
		},
		{
			3, 11, 2, 0, 1, 6, 0, 6, 4, 6,
			1, 10, -1, -1, -1, -1
		},
		{
			6, 4, 1, 6, 1, 10, 4, 8, 1, 2,
			1, 11, 8, 11, 1, -1
		},
		{
			9, 6, 4, 9, 3, 6, 9, 1, 3, 11,
			6, 3, -1, -1, -1, -1
		},
		{
			8, 11, 1, 8, 1, 0, 11, 6, 1, 9,
			1, 4, 6, 4, 1, -1
		},
		{
			3, 11, 6, 3, 6, 0, 0, 6, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			6, 4, 8, 11, 6, 8, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 10, 6, 7, 8, 10, 8, 9, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 7, 3, 0, 10, 7, 0, 9, 10, 6,
			7, 10, -1, -1, -1, -1
		},
		{
			10, 6, 7, 1, 10, 7, 1, 7, 8, 1,
			8, 0, -1, -1, -1, -1
		},
		{
			10, 6, 7, 10, 7, 1, 1, 7, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 6, 1, 6, 8, 1, 8, 9, 8,
			6, 7, -1, -1, -1, -1
		},
		{
			2, 6, 9, 2, 9, 1, 6, 7, 9, 0,
			9, 3, 7, 3, 9, -1
		},
		{
			7, 8, 0, 7, 0, 6, 6, 0, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 3, 2, 6, 7, 2, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 3, 11, 10, 6, 8, 10, 8, 9, 8,
			6, 7, -1, -1, -1, -1
		},
		{
			2, 0, 7, 2, 7, 11, 0, 9, 7, 6,
			7, 10, 9, 10, 7, -1
		},
		{
			1, 8, 0, 1, 7, 8, 1, 10, 7, 6,
			7, 10, 2, 3, 11, -1
		},
		{
			11, 2, 1, 11, 1, 7, 10, 6, 1, 6,
			7, 1, -1, -1, -1, -1
		},
		{
			8, 9, 6, 8, 6, 7, 9, 1, 6, 11,
			6, 3, 1, 3, 6, -1
		},
		{
			0, 9, 1, 11, 6, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 8, 0, 7, 0, 6, 3, 11, 0, 11,
			6, 0, -1, -1, -1, -1
		},
		{
			7, 11, 6, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 6, 11, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 0, 8, 11, 7, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 1, 9, 11, 7, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 1, 9, 8, 3, 1, 11, 7, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 1, 2, 6, 11, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, 3, 0, 8, 6, 11, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 9, 0, 2, 10, 9, 6, 11, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			6, 11, 7, 2, 10, 3, 10, 8, 3, 10,
			9, 8, -1, -1, -1, -1
		},
		{
			7, 2, 3, 6, 2, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			7, 0, 8, 7, 6, 0, 6, 2, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 7, 6, 2, 3, 7, 0, 1, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 6, 2, 1, 8, 6, 1, 9, 8, 8,
			7, 6, -1, -1, -1, -1
		},
		{
			10, 7, 6, 10, 1, 7, 1, 3, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 7, 6, 1, 7, 10, 1, 8, 7, 1,
			0, 8, -1, -1, -1, -1
		},
		{
			0, 3, 7, 0, 7, 10, 0, 10, 9, 6,
			10, 7, -1, -1, -1, -1
		},
		{
			7, 6, 10, 7, 10, 8, 8, 10, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			6, 8, 4, 11, 8, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 6, 11, 3, 0, 6, 0, 4, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 6, 11, 8, 4, 6, 9, 0, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 4, 6, 9, 6, 3, 9, 3, 1, 11,
			3, 6, -1, -1, -1, -1
		},
		{
			6, 8, 4, 6, 11, 8, 2, 10, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, 3, 0, 11, 0, 6, 11, 0,
			4, 6, -1, -1, -1, -1
		},
		{
			4, 11, 8, 4, 6, 11, 0, 2, 9, 2,
			10, 9, -1, -1, -1, -1
		},
		{
			10, 9, 3, 10, 3, 2, 9, 4, 3, 11,
			3, 6, 4, 6, 3, -1
		},
		{
			8, 2, 3, 8, 4, 2, 4, 6, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 4, 2, 4, 6, 2, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 9, 0, 2, 3, 4, 2, 4, 6, 4,
			3, 8, -1, -1, -1, -1
		},
		{
			1, 9, 4, 1, 4, 2, 2, 4, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 1, 3, 8, 6, 1, 8, 4, 6, 6,
			10, 1, -1, -1, -1, -1
		},
		{
			10, 1, 0, 10, 0, 6, 6, 0, 4, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 6, 3, 4, 3, 8, 6, 10, 3, 0,
			3, 9, 10, 9, 3, -1
		},
		{
			10, 9, 4, 6, 10, 4, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 9, 5, 7, 6, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, 4, 9, 5, 11, 7, 6, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 0, 1, 5, 4, 0, 7, 6, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 7, 6, 8, 3, 4, 3, 5, 4, 3,
			1, 5, -1, -1, -1, -1
		},
		{
			9, 5, 4, 10, 1, 2, 7, 6, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			6, 11, 7, 1, 2, 10, 0, 8, 3, 4,
			9, 5, -1, -1, -1, -1
		},
		{
			7, 6, 11, 5, 4, 10, 4, 2, 10, 4,
			0, 2, -1, -1, -1, -1
		},
		{
			3, 4, 8, 3, 5, 4, 3, 2, 5, 10,
			5, 2, 11, 7, 6, -1
		},
		{
			7, 2, 3, 7, 6, 2, 5, 4, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 5, 4, 0, 8, 6, 0, 6, 2, 6,
			8, 7, -1, -1, -1, -1
		},
		{
			3, 6, 2, 3, 7, 6, 1, 5, 0, 5,
			4, 0, -1, -1, -1, -1
		},
		{
			6, 2, 8, 6, 8, 7, 2, 1, 8, 4,
			8, 5, 1, 5, 8, -1
		},
		{
			9, 5, 4, 10, 1, 6, 1, 7, 6, 1,
			3, 7, -1, -1, -1, -1
		},
		{
			1, 6, 10, 1, 7, 6, 1, 0, 7, 8,
			7, 0, 9, 5, 4, -1
		},
		{
			4, 0, 10, 4, 10, 5, 0, 3, 10, 6,
			10, 7, 3, 7, 10, -1
		},
		{
			7, 6, 10, 7, 10, 8, 5, 4, 10, 4,
			8, 10, -1, -1, -1, -1
		},
		{
			6, 9, 5, 6, 11, 9, 11, 8, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 6, 11, 0, 6, 3, 0, 5, 6, 0,
			9, 5, -1, -1, -1, -1
		},
		{
			0, 11, 8, 0, 5, 11, 0, 1, 5, 5,
			6, 11, -1, -1, -1, -1
		},
		{
			6, 11, 3, 6, 3, 5, 5, 3, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 10, 9, 5, 11, 9, 11, 8, 11,
			5, 6, -1, -1, -1, -1
		},
		{
			0, 11, 3, 0, 6, 11, 0, 9, 6, 5,
			6, 9, 1, 2, 10, -1
		},
		{
			11, 8, 5, 11, 5, 6, 8, 0, 5, 10,
			5, 2, 0, 2, 5, -1
		},
		{
			6, 11, 3, 6, 3, 5, 2, 10, 3, 10,
			5, 3, -1, -1, -1, -1
		},
		{
			5, 8, 9, 5, 2, 8, 5, 6, 2, 3,
			8, 2, -1, -1, -1, -1
		},
		{
			9, 5, 6, 9, 6, 0, 0, 6, 2, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 5, 8, 1, 8, 0, 5, 6, 8, 3,
			8, 2, 6, 2, 8, -1
		},
		{
			1, 5, 6, 2, 1, 6, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 3, 6, 1, 6, 10, 3, 8, 6, 5,
			6, 9, 8, 9, 6, -1
		},
		{
			10, 1, 0, 10, 0, 6, 9, 5, 0, 5,
			6, 0, -1, -1, -1, -1
		},
		{
			0, 3, 8, 5, 6, 10, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 5, 6, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 5, 10, 7, 5, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 5, 10, 11, 7, 5, 8, 3, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 11, 7, 5, 10, 11, 1, 9, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			10, 7, 5, 10, 11, 7, 9, 8, 1, 8,
			3, 1, -1, -1, -1, -1
		},
		{
			11, 1, 2, 11, 7, 1, 7, 5, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, 1, 2, 7, 1, 7, 5, 7,
			2, 11, -1, -1, -1, -1
		},
		{
			9, 7, 5, 9, 2, 7, 9, 0, 2, 2,
			11, 7, -1, -1, -1, -1
		},
		{
			7, 5, 2, 7, 2, 11, 5, 9, 2, 3,
			2, 8, 9, 8, 2, -1
		},
		{
			2, 5, 10, 2, 3, 5, 3, 7, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 2, 0, 8, 5, 2, 8, 7, 5, 10,
			2, 5, -1, -1, -1, -1
		},
		{
			9, 0, 1, 5, 10, 3, 5, 3, 7, 3,
			10, 2, -1, -1, -1, -1
		},
		{
			9, 8, 2, 9, 2, 1, 8, 7, 2, 10,
			2, 5, 7, 5, 2, -1
		},
		{
			1, 3, 5, 3, 7, 5, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 7, 0, 7, 1, 1, 7, 5, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 0, 3, 9, 3, 5, 5, 3, 7, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 8, 7, 5, 9, 7, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 8, 4, 5, 10, 8, 10, 11, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			5, 0, 4, 5, 11, 0, 5, 10, 11, 11,
			3, 0, -1, -1, -1, -1
		},
		{
			0, 1, 9, 8, 4, 10, 8, 10, 11, 10,
			4, 5, -1, -1, -1, -1
		},
		{
			10, 11, 4, 10, 4, 5, 11, 3, 4, 9,
			4, 1, 3, 1, 4, -1
		},
		{
			2, 5, 1, 2, 8, 5, 2, 11, 8, 4,
			5, 8, -1, -1, -1, -1
		},
		{
			0, 4, 11, 0, 11, 3, 4, 5, 11, 2,
			11, 1, 5, 1, 11, -1
		},
		{
			0, 2, 5, 0, 5, 9, 2, 11, 5, 4,
			5, 8, 11, 8, 5, -1
		},
		{
			9, 4, 5, 2, 11, 3, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 5, 10, 3, 5, 2, 3, 4, 5, 3,
			8, 4, -1, -1, -1, -1
		},
		{
			5, 10, 2, 5, 2, 4, 4, 2, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 10, 2, 3, 5, 10, 3, 8, 5, 4,
			5, 8, 0, 1, 9, -1
		},
		{
			5, 10, 2, 5, 2, 4, 1, 9, 2, 9,
			4, 2, -1, -1, -1, -1
		},
		{
			8, 4, 5, 8, 5, 3, 3, 5, 1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 4, 5, 1, 0, 5, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			8, 4, 5, 8, 5, 3, 9, 0, 5, 0,
			3, 5, -1, -1, -1, -1
		},
		{
			9, 4, 5, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 11, 7, 4, 9, 11, 9, 10, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 8, 3, 4, 9, 7, 9, 11, 7, 9,
			10, 11, -1, -1, -1, -1
		},
		{
			1, 10, 11, 1, 11, 4, 1, 4, 0, 7,
			4, 11, -1, -1, -1, -1
		},
		{
			3, 1, 4, 3, 4, 8, 1, 10, 4, 7,
			4, 11, 10, 11, 4, -1
		},
		{
			4, 11, 7, 9, 11, 4, 9, 2, 11, 9,
			1, 2, -1, -1, -1, -1
		},
		{
			9, 7, 4, 9, 11, 7, 9, 1, 11, 2,
			11, 1, 0, 8, 3, -1
		},
		{
			11, 7, 4, 11, 4, 2, 2, 4, 0, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			11, 7, 4, 11, 4, 2, 8, 3, 4, 3,
			2, 4, -1, -1, -1, -1
		},
		{
			2, 9, 10, 2, 7, 9, 2, 3, 7, 7,
			4, 9, -1, -1, -1, -1
		},
		{
			9, 10, 7, 9, 7, 4, 10, 2, 7, 8,
			7, 0, 2, 0, 7, -1
		},
		{
			3, 7, 10, 3, 10, 2, 7, 4, 10, 1,
			10, 0, 4, 0, 10, -1
		},
		{
			1, 10, 2, 8, 7, 4, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 9, 1, 4, 1, 7, 7, 1, 3, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 9, 1, 4, 1, 7, 0, 8, 1, 8,
			7, 1, -1, -1, -1, -1
		},
		{
			4, 0, 3, 7, 4, 3, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			4, 8, 7, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 10, 8, 10, 11, 8, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 0, 9, 3, 9, 11, 11, 9, 10, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 1, 10, 0, 10, 8, 8, 10, 11, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 1, 10, 11, 3, 10, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 2, 11, 1, 11, 9, 9, 11, 8, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 0, 9, 3, 9, 11, 1, 2, 9, 2,
			11, 9, -1, -1, -1, -1
		},
		{
			0, 2, 11, 8, 0, 11, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			3, 2, 11, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 3, 8, 2, 8, 10, 10, 8, 9, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			9, 10, 2, 0, 9, 2, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			2, 3, 8, 2, 8, 10, 0, 1, 8, 1,
			10, 8, -1, -1, -1, -1
		},
		{
			1, 10, 2, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			1, 3, 8, 9, 1, 8, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 9, 1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			0, 3, 8, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		},
		{
			-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
			-1, -1, -1, -1, -1, -1
		}
	};

	public string ProgressBarText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRmG6R1QGHAu__0024cNoQ4O78rY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzRmG6R1QGHAu__0024cNoQ4O78rY_003D = value;
		}
	}

	public double IsoLevel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzmJo3pUxhOIfweQL2nlLUE9w_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzmJo3pUxhOIfweQL2nlLUE9w_003D = value;
		}
	}

	public Mesh Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
	}

	public bool LightWeight
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuJyU_0024Mf8xSDiLCcInyNIhCI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuJyU_0024Mf8xSDiLCcInyNIhCI_003D = value;
		}
	}

	public Mesh.natureType Nature
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzcu3ag2JlMJ3_OsDY1fylKyY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzcu3ag2JlMJ3_OsDY1fylKyY_003D = value;
		}
	}

	public MarchingCubes(int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, int nCellsInZ, float cellSizeZ, ScalarField3D func)
		: this(Point3D.Origin, nCellsInX, cellSizeX, nCellsInY, cellSizeY, nCellsInZ, cellSizeZ, func)
	{
	}

	public MarchingCubes(Point3D gridOrigin, int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, int nCellsInZ, float cellSizeZ, ScalarField3D func)
	{
		this.gridOrigin = gridOrigin;
		this.nCellsInX = nCellsInX;
		this.nCellsInY = nCellsInY;
		this.nCellsInZ = nCellsInZ;
		this.cellSizeX = cellSizeX;
		this.cellSizeY = cellSizeY;
		this.cellSizeZ = cellSizeZ;
		grid = new float[nCellsInX + 1, nCellsInY + 1, nCellsInZ + 1];
		if (func != null)
		{
			FillGrid(func);
		}
	}

	private void _0023_003DzijhYAd8_003D(Mesh _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	protected virtual void FillGrid(ScalarField3D func)
	{
		_0023_003DzzfenD6ngsni7RY41oYe4G5I_003D CS_0024_003C_003E8__locals12 = new _0023_003DzzfenD6ngsni7RY41oYe4G5I_003D();
		CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals12._0023_003Dz743TWCo_003D = func;
		Parallel.For(0, nCellsInZ + 1, delegate(int _0023_003DzN6G05Lg_003D)
		{
			for (int i = 0; i < CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.nCellsInY + 1; i++)
			{
				for (int j = 0; j < CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.nCellsInX + 1; j++)
				{
					CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.grid[j, i, _0023_003DzN6G05Lg_003D] = CS_0024_003C_003E8__locals12._0023_003Dz743TWCo_003D((float)(CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.gridOrigin.X + (double)((float)j * CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.cellSizeX)), (float)(CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.gridOrigin.Y + (double)((float)i * CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.cellSizeY)), (float)(CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.gridOrigin.Z + (double)((float)_0023_003DzN6G05Lg_003D * CS_0024_003C_003E8__locals12._0023_003DzopRx0_MBcTQs.cellSizeZ)));
				}
			}
		});
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D CS_0024_003C_003E8__locals17 = new _0023_003Dz8zgww5w68Io7P7YHLuAnPSU_003D();
		CS_0024_003C_003E8__locals17._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals17._0023_003DzmHS7frs_003D = progress;
		CS_0024_003C_003E8__locals17._0023_003Dzjvn7P10_003D = ct;
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D = new List<Point3D[]>();
		ResetProgressParallel();
		Parallel.For(0, nCellsInZ, () => new List<Point3D[]>(), CS_0024_003C_003E8__locals17._0023_003DzImyailaPCZRVSZ9_lg_003D_003D, delegate(List<Point3D[]> _0023_003DzBJFJHwk_003D)
		{
			lock (CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
			{
				CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		});
		UpdateProgressTo100(ProgressBarText, CS_0024_003C_003E8__locals17._0023_003DzmHS7frs_003D);
		if (Cancelled(CS_0024_003C_003E8__locals17._0023_003Dzjvn7P10_003D))
		{
			return;
		}
		Point3D[] array2 = new Point3D[CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count * 3];
		for (int num = 0; num < CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Count; num++)
		{
			if (!LightWeight)
			{
				Point3D point3D = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][0];
				switch (Nature)
				{
				case Mesh.natureType.Plain:
				case Mesh.natureType.ColorPlain:
				case Mesh.natureType.RichPlain:
				case Mesh.natureType.Smooth:
				case Mesh.natureType.ColorSmooth:
				case Mesh.natureType.RichSmooth:
					array2[num * 3] = point3D;
					break;
				case Mesh.natureType.MulticolorPlain:
				case Mesh.natureType.MulticolorSmooth:
					array2[num * 3] = new PointRGB(point3D.X, point3D.Y, point3D.Z, 0, 0, 0);
					break;
				}
				Point3D point3D2 = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][1];
				switch (Nature)
				{
				case Mesh.natureType.Plain:
				case Mesh.natureType.ColorPlain:
				case Mesh.natureType.RichPlain:
				case Mesh.natureType.Smooth:
				case Mesh.natureType.ColorSmooth:
				case Mesh.natureType.RichSmooth:
					array2[num * 3 + 1] = point3D2;
					break;
				case Mesh.natureType.MulticolorPlain:
				case Mesh.natureType.MulticolorSmooth:
					array2[num * 3 + 1] = new PointRGB(point3D2.X, point3D2.Y, point3D2.Z, 0, 0, 0);
					break;
				}
				Point3D point3D3 = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][2];
				switch (Nature)
				{
				case Mesh.natureType.Plain:
				case Mesh.natureType.ColorPlain:
				case Mesh.natureType.RichPlain:
				case Mesh.natureType.Smooth:
				case Mesh.natureType.ColorSmooth:
				case Mesh.natureType.RichSmooth:
					array2[num * 3 + 2] = point3D3;
					break;
				case Mesh.natureType.MulticolorPlain:
				case Mesh.natureType.MulticolorSmooth:
					array2[num * 3 + 2] = new PointRGB(point3D3.X, point3D3.Y, point3D3.Z, 0, 0, 0);
					break;
				}
			}
			else
			{
				array2[num * 3] = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][0];
				array2[num * 3 + 1] = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][1];
				array2[num * 3 + 2] = CS_0024_003C_003E8__locals17._0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D[num][2];
			}
		}
		Mesh mesh;
		if (!LightWeight)
		{
			Mesh.natureType nature = Nature;
			mesh = new Mesh(nature);
			mesh.NormalAveragingMode = Mesh.normalAveragingType.Averaged;
			Utility.TrianglesToIndexedTriangles(array2, out var uniqueVertices, out var cleanedTriangles, nature);
			mesh.Vertices = uniqueVertices;
			mesh.Triangles = cleanedTriangles;
		}
		else
		{
			mesh = new Mesh(Mesh.natureType.Plain);
			mesh.Vertices = array2;
			int num2 = mesh.Vertices.Length / 3;
			mesh.Triangles = new IndexTriangle[num2];
			mesh.EdgeStyle = Mesh.edgeStyleType.None;
			for (int num3 = 0; num3 < num2; num3++)
			{
				mesh.Triangles[num3] = new IndexTriangle(num3 * 3, num3 * 3 + 1, num3 * 3 + 2);
			}
			mesh.UpdateNormals();
		}
		mesh.LightWeight = LightWeight;
		_0023_003DzijhYAd8_003D(mesh);
	}

	protected virtual void ComputeCoords(int column, int row, int z, double[,] coords)
	{
		coords[0, 0] = gridOrigin.X + (double)((float)column * cellSizeX);
		coords[0, 1] = gridOrigin.Y + (double)((float)(row + 1) * cellSizeY);
		coords[0, 2] = gridOrigin.Z + (double)((float)z * cellSizeZ);
		coords[1, 0] = gridOrigin.X + (double)((float)(column + 1) * cellSizeX);
		coords[1, 1] = gridOrigin.Y + (double)((float)(row + 1) * cellSizeY);
		coords[1, 2] = gridOrigin.Z + (double)((float)z * cellSizeZ);
		coords[2, 0] = gridOrigin.X + (double)((float)(column + 1) * cellSizeX);
		coords[2, 1] = gridOrigin.Y + (double)((float)row * cellSizeY);
		coords[2, 2] = gridOrigin.Z + (double)((float)z * cellSizeZ);
		coords[3, 0] = gridOrigin.X + (double)((float)column * cellSizeX);
		coords[3, 1] = gridOrigin.Y + (double)((float)row * cellSizeY);
		coords[3, 2] = gridOrigin.Z + (double)((float)z * cellSizeZ);
		coords[4, 0] = gridOrigin.X + (double)((float)column * cellSizeX);
		coords[4, 1] = gridOrigin.Y + (double)((float)(row + 1) * cellSizeY);
		coords[4, 2] = gridOrigin.Z + (double)((float)(z + 1) * cellSizeZ);
		coords[5, 0] = gridOrigin.X + (double)((float)(column + 1) * cellSizeX);
		coords[5, 1] = gridOrigin.Y + (double)((float)(row + 1) * cellSizeY);
		coords[5, 2] = gridOrigin.Z + (double)((float)(z + 1) * cellSizeZ);
		coords[6, 0] = gridOrigin.X + (double)((float)(column + 1) * cellSizeX);
		coords[6, 1] = gridOrigin.Y + (double)((float)row * cellSizeY);
		coords[6, 2] = gridOrigin.Z + (double)((float)(z + 1) * cellSizeZ);
		coords[7, 0] = gridOrigin.X + (double)((float)column * cellSizeX);
		coords[7, 1] = gridOrigin.Y + (double)((float)row * cellSizeY);
		coords[7, 2] = gridOrigin.Z + (double)((float)(z + 1) * cellSizeZ);
	}

	private static void _0023_003Dz5muzE45ca__0024hKx9QbA_003D_003D(double[,] _0023_003DzD0vYoclJjkWP, double[] _0023_003DzHSO_00246A0_003D, double _0023_003DzXJmcxGRWCE8F, List<Point3D[]> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D)
	{
		double[,] array = new double[12, 3];
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (_0023_003DzHSO_00246A0_003D[i] < _0023_003DzXJmcxGRWCE8F)
			{
				num |= 1 << i;
			}
		}
		int num2 = _0023_003DzaYsLbLWMUjkG[num];
		if (num2 != 0)
		{
			if ((num2 & 1) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[0, 0], _0023_003DzD0vYoclJjkWP[0, 1], _0023_003DzD0vYoclJjkWP[0, 2], _0023_003DzHSO_00246A0_003D[0], _0023_003DzD0vYoclJjkWP[1, 0], _0023_003DzD0vYoclJjkWP[1, 1], _0023_003DzD0vYoclJjkWP[1, 2], _0023_003DzHSO_00246A0_003D[1], 0, array);
			}
			if ((num2 & 2) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[1, 0], _0023_003DzD0vYoclJjkWP[1, 1], _0023_003DzD0vYoclJjkWP[1, 2], _0023_003DzHSO_00246A0_003D[1], _0023_003DzD0vYoclJjkWP[2, 0], _0023_003DzD0vYoclJjkWP[2, 1], _0023_003DzD0vYoclJjkWP[2, 2], _0023_003DzHSO_00246A0_003D[2], 1, array);
			}
			if ((num2 & 4) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[2, 0], _0023_003DzD0vYoclJjkWP[2, 1], _0023_003DzD0vYoclJjkWP[2, 2], _0023_003DzHSO_00246A0_003D[2], _0023_003DzD0vYoclJjkWP[3, 0], _0023_003DzD0vYoclJjkWP[3, 1], _0023_003DzD0vYoclJjkWP[3, 2], _0023_003DzHSO_00246A0_003D[3], 2, array);
			}
			if ((num2 & 8) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[3, 0], _0023_003DzD0vYoclJjkWP[3, 1], _0023_003DzD0vYoclJjkWP[3, 2], _0023_003DzHSO_00246A0_003D[3], _0023_003DzD0vYoclJjkWP[0, 0], _0023_003DzD0vYoclJjkWP[0, 1], _0023_003DzD0vYoclJjkWP[0, 2], _0023_003DzHSO_00246A0_003D[0], 3, array);
			}
			if ((num2 & 0x10) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[4, 0], _0023_003DzD0vYoclJjkWP[4, 1], _0023_003DzD0vYoclJjkWP[4, 2], _0023_003DzHSO_00246A0_003D[4], _0023_003DzD0vYoclJjkWP[5, 0], _0023_003DzD0vYoclJjkWP[5, 1], _0023_003DzD0vYoclJjkWP[5, 2], _0023_003DzHSO_00246A0_003D[5], 4, array);
			}
			if ((num2 & 0x20) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[5, 0], _0023_003DzD0vYoclJjkWP[5, 1], _0023_003DzD0vYoclJjkWP[5, 2], _0023_003DzHSO_00246A0_003D[5], _0023_003DzD0vYoclJjkWP[6, 0], _0023_003DzD0vYoclJjkWP[6, 1], _0023_003DzD0vYoclJjkWP[6, 2], _0023_003DzHSO_00246A0_003D[6], 5, array);
			}
			if ((num2 & 0x40) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[6, 0], _0023_003DzD0vYoclJjkWP[6, 1], _0023_003DzD0vYoclJjkWP[6, 2], _0023_003DzHSO_00246A0_003D[6], _0023_003DzD0vYoclJjkWP[7, 0], _0023_003DzD0vYoclJjkWP[7, 1], _0023_003DzD0vYoclJjkWP[7, 2], _0023_003DzHSO_00246A0_003D[7], 6, array);
			}
			if ((num2 & 0x80) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[7, 0], _0023_003DzD0vYoclJjkWP[7, 1], _0023_003DzD0vYoclJjkWP[7, 2], _0023_003DzHSO_00246A0_003D[7], _0023_003DzD0vYoclJjkWP[4, 0], _0023_003DzD0vYoclJjkWP[4, 1], _0023_003DzD0vYoclJjkWP[4, 2], _0023_003DzHSO_00246A0_003D[4], 7, array);
			}
			if ((num2 & 0x100) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[0, 0], _0023_003DzD0vYoclJjkWP[0, 1], _0023_003DzD0vYoclJjkWP[0, 2], _0023_003DzHSO_00246A0_003D[0], _0023_003DzD0vYoclJjkWP[4, 0], _0023_003DzD0vYoclJjkWP[4, 1], _0023_003DzD0vYoclJjkWP[4, 2], _0023_003DzHSO_00246A0_003D[4], 8, array);
			}
			if ((num2 & 0x200) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[1, 0], _0023_003DzD0vYoclJjkWP[1, 1], _0023_003DzD0vYoclJjkWP[1, 2], _0023_003DzHSO_00246A0_003D[1], _0023_003DzD0vYoclJjkWP[5, 0], _0023_003DzD0vYoclJjkWP[5, 1], _0023_003DzD0vYoclJjkWP[5, 2], _0023_003DzHSO_00246A0_003D[5], 9, array);
			}
			if ((num2 & 0x400) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[2, 0], _0023_003DzD0vYoclJjkWP[2, 1], _0023_003DzD0vYoclJjkWP[2, 2], _0023_003DzHSO_00246A0_003D[2], _0023_003DzD0vYoclJjkWP[6, 0], _0023_003DzD0vYoclJjkWP[6, 1], _0023_003DzD0vYoclJjkWP[6, 2], _0023_003DzHSO_00246A0_003D[6], 10, array);
			}
			if ((num2 & 0x800) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[3, 0], _0023_003DzD0vYoclJjkWP[3, 1], _0023_003DzD0vYoclJjkWP[3, 2], _0023_003DzHSO_00246A0_003D[3], _0023_003DzD0vYoclJjkWP[7, 0], _0023_003DzD0vYoclJjkWP[7, 1], _0023_003DzD0vYoclJjkWP[7, 2], _0023_003DzHSO_00246A0_003D[7], 11, array);
			}
			for (int j = 0; _0023_003Dzy0JD_D_0024EUu3S[num, j] != -1; j += 3)
			{
				int num3 = _0023_003Dzy0JD_D_0024EUu3S[num, j];
				int num4 = _0023_003Dzy0JD_D_0024EUu3S[num, j + 2];
				int num5 = _0023_003Dzy0JD_D_0024EUu3S[num, j + 1];
				_0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D.Add(new Point3D[3]
				{
					new Point3D(array[num3, 0], array[num3, 1], array[num3, 2]),
					new Point3D(array[num4, 0], array[num4, 1], array[num4, 2]),
					new Point3D(array[num5, 0], array[num5, 1], array[num5, 2])
				});
			}
		}
	}

	private static bool _0023_003DzJKa28AMa1U1O(double _0023_003DzhZSN110_003D, double _0023_003DzgKzwQJg_003D, double _0023_003DzaOxPANw_003D, double _0023_003Dz30ChO94_003D, double _0023_003DzpIDPCIM_003D, double _0023_003DzC9ml0oQ_003D)
	{
		if (_0023_003DzhZSN110_003D < _0023_003Dz30ChO94_003D)
		{
			return true;
		}
		if (_0023_003DzhZSN110_003D > _0023_003Dz30ChO94_003D)
		{
			return false;
		}
		if (_0023_003DzgKzwQJg_003D < _0023_003DzpIDPCIM_003D)
		{
			return true;
		}
		if (_0023_003DzgKzwQJg_003D > _0023_003DzpIDPCIM_003D)
		{
			return false;
		}
		return _0023_003DzaOxPANw_003D < _0023_003DzC9ml0oQ_003D;
	}

	private static void _0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(double _0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D, double _0023_003Dz81J0Y4Q_003D, double _0023_003Dzd_0024HoPb0_003D, double _0023_003DzTGiwtP0_003D, double _0023_003Dzb2BdBiUHdTXP, double _0023_003Dz7mbD2AY_003D, double _0023_003DzPqpigS8_003D, double _0023_003DzXUTrJ2M_003D, double _0023_003Dzm06VjWteaXuo, int _0023_003DzyzK8swU_003D, double[,] _0023_003Dz7pqWuheV0uU_0024)
	{
		if (Math.Abs(_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzb2BdBiUHdTXP) < 0.001)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 2] = _0023_003DzTGiwtP0_003D;
		}
		else if (Math.Abs(_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzm06VjWteaXuo) < 0.001)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz7mbD2AY_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003DzPqpigS8_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 2] = _0023_003DzXUTrJ2M_003D;
		}
		else if (Math.Abs(_0023_003Dzb2BdBiUHdTXP - _0023_003Dzm06VjWteaXuo) < 0.001)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 2] = _0023_003DzTGiwtP0_003D;
		}
		else
		{
			double num = (_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzb2BdBiUHdTXP) / (_0023_003Dzm06VjWteaXuo - _0023_003Dzb2BdBiUHdTXP);
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D + num * (_0023_003Dz7mbD2AY_003D - _0023_003Dz81J0Y4Q_003D);
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D + num * (_0023_003DzPqpigS8_003D - _0023_003Dzd_0024HoPb0_003D);
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 2] = _0023_003DzTGiwtP0_003D + num * (_0023_003DzXUTrJ2M_003D - _0023_003DzTGiwtP0_003D);
		}
	}
}
