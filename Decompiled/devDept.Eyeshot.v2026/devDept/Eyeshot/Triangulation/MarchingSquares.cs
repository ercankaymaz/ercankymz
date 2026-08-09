using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Triangulation;

public class MarchingSquares : WorkUnit
{
	private sealed class _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D
	{
		public MarchingSquares _0023_003DzopRx0_MBcTQs;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public List<Point2D[]> _0023_003DzKTAIrow_003D;

		internal List<Point2D[]> _0023_003DzImyailaPCZRVSZ9_lg_003D_003D(int _0023_003DzTSeNR8Q_003D, ParallelLoopState _0023_003DzLdZiL78_003D, List<Point2D[]> _0023_003DzxmCET83Y2zEO)
		{
			double[,] array = new double[4, 2];
			double[] array2 = new double[4];
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs._0023_003DzbT7t5wz0DaKB; i++)
			{
				_0023_003DzopRx0_MBcTQs.ComputeCoords(i, _0023_003DzTSeNR8Q_003D, array);
				array2[0] = _0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i, _0023_003DzTSeNR8Q_003D + 1];
				array2[1] = _0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i + 1, _0023_003DzTSeNR8Q_003D + 1];
				array2[2] = _0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i + 1, _0023_003DzTSeNR8Q_003D];
				array2[3] = _0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i, _0023_003DzTSeNR8Q_003D];
				_0023_003Dz5muzE45ca__0024hKx9QbA_003D_003D(array, array2, _0023_003DzopRx0_MBcTQs.IsoLevel, _0023_003DzxmCET83Y2zEO);
			}
			if (!_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelledParallel(_0023_003DzopRx0_MBcTQs._0023_003DzxQd3oX6_Iof8 - 1, _0023_003DzopRx0_MBcTQs.ProgressBarText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
			return _0023_003DzxmCET83Y2zEO;
		}

		internal void _0023_003DzKWjLAL76_0024Xb8wu9w4g_003D_003D(List<Point2D[]> _0023_003DzBJFJHwk_003D)
		{
			lock (_0023_003DzKTAIrow_003D)
			{
				_0023_003DzKTAIrow_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<List<Point2D[]>> _0023_003DzfwNMtismau68nVHXSg_003D_003D;

		internal List<Point2D[]> _0023_003DzrzNEh20Fe4m558IC9cy8Vd8_003D()
		{
			return new List<Point2D[]>();
		}
	}

	private sealed class _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D
	{
		public MarchingSquares _0023_003DzopRx0_MBcTQs;

		public ScalarField2D _0023_003Dz743TWCo_003D;

		internal void _0023_003Dz_00246uQotdONA_0024NfDrTnA_003D_003D(int _0023_003DzTSeNR8Q_003D)
		{
			for (int i = 0; i < _0023_003DzopRx0_MBcTQs._0023_003DzbT7t5wz0DaKB + 1; i++)
			{
				_0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i, _0023_003DzTSeNR8Q_003D] = _0023_003Dz743TWCo_003D((float)(_0023_003DzopRx0_MBcTQs._0023_003DzytznN8ALiEzo.X + (double)((float)i * _0023_003DzopRx0_MBcTQs._0023_003Dz_2etYFFHxOYK)), (float)(_0023_003DzopRx0_MBcTQs._0023_003DzytznN8ALiEzo.Y + (double)((float)_0023_003DzTSeNR8Q_003D * _0023_003DzopRx0_MBcTQs._0023_003Dzbm3uSZ0TZIPP)));
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float[,] _0023_003DzfYoOuYA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D _0023_003DzytznN8ALiEzo = Point2D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzbT7t5wz0DaKB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzxQd3oX6_Iof8;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dz_2etYFFHxOYK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dzbm3uSZ0TZIPP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzRmG6R1QGHAu__0024cNoQ4O78rY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653316);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzmJo3pUxhOIfweQL2nlLUE9w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Line[] _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly PictureData<byte> _0023_003DzcKnNJC5XVyW5;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int[] _0023_003DzaYsLbLWMUjkG = new int[16]
	{
		0, 9, 3, 10, 6, 15, 5, 12, 12, 5,
		15, 6, 10, 3, 9, 0
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static int[,] _0023_003Dzy0JD_D_0024EUu3S = new int[16, 5]
	{
		{ -1, -1, -1, -1, -1 },
		{ 3, 0, -1, -1, -1 },
		{ 0, 1, -1, -1, -1 },
		{ 1, 3, -1, -1, -1 },
		{ 1, 2, -1, -1, -1 },
		{ 0, 1, 2, 3, -1 },
		{ 0, 2, -1, -1, -1 },
		{ 2, 3, -1, -1, -1 },
		{ 2, 3, -1, -1, -1 },
		{ 0, 2, -1, -1, -1 },
		{ 1, 2, 3, 0, -1 },
		{ 1, 2, -1, -1, -1 },
		{ 1, 3, -1, -1, -1 },
		{ 0, 1, -1, -1, -1 },
		{ 3, 0, -1, -1, -1 },
		{ -1, -1, -1, -1, -1 }
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

	public Line[] Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
	}

	public MarchingSquares(int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, ScalarField2D func)
		: this(Point2D.Origin, nCellsInX, cellSizeX, nCellsInY, cellSizeY, func)
	{
	}

	public MarchingSquares(PictureData<byte> pictureData, int cellSizeInX = 1, int cellSizeInY = 1)
		: this(Point2D.Origin, pictureData.Rows / cellSizeInX, cellSizeInX, pictureData.Columns / cellSizeInY, cellSizeInY, null)
	{
		_0023_003DzcKnNJC5XVyW5 = pictureData;
		FillGrid(_0023_003DzXF1uvdA_003D);
	}

	public MarchingSquares(Point2D gridOrigin, int nCellsInX, float cellSizeX, int nCellsInY, float cellSizeY, ScalarField2D func)
	{
		_0023_003DzytznN8ALiEzo = gridOrigin;
		_0023_003DzbT7t5wz0DaKB = nCellsInX;
		_0023_003DzxQd3oX6_Iof8 = nCellsInY;
		_0023_003Dz_2etYFFHxOYK = cellSizeX;
		_0023_003Dzbm3uSZ0TZIPP = cellSizeY;
		_0023_003DzfYoOuYA_003D = new float[nCellsInX + 1, nCellsInY + 1];
		if (func != null)
		{
			FillGrid(func);
		}
	}

	private void _0023_003DzijhYAd8_003D(Line[] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private float _0023_003DzXF1uvdA_003D(float _0023_003Dz3YfTAqg_003D, float _0023_003DzpilgH4E_003D)
	{
		return (int)_0023_003DzcKnNJC5XVyW5.Pixels[(int)_0023_003Dz3YfTAqg_003D, (int)_0023_003DzpilgH4E_003D];
	}

	protected virtual void FillGrid(ScalarField2D func)
	{
		_0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D CS_0024_003C_003E8__locals9 = new _0023_003DzCd9SERNZLJdU0v4xjenXyW0_003D();
		CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals9._0023_003Dz743TWCo_003D = func;
		Parallel.For(0, _0023_003DzxQd3oX6_Iof8 + 1, delegate(int _0023_003DzTSeNR8Q_003D)
		{
			for (int i = 0; i < CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003DzbT7t5wz0DaKB + 1; i++)
			{
				CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003DzfYoOuYA_003D[i, _0023_003DzTSeNR8Q_003D] = CS_0024_003C_003E8__locals9._0023_003Dz743TWCo_003D((float)(CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003DzytznN8ALiEzo.X + (double)((float)i * CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003Dz_2etYFFHxOYK)), (float)(CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003DzytznN8ALiEzo.Y + (double)((float)_0023_003DzTSeNR8Q_003D * CS_0024_003C_003E8__locals9._0023_003DzopRx0_MBcTQs._0023_003Dzbm3uSZ0TZIPP)));
			}
		});
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D CS_0024_003C_003E8__locals15 = new _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D();
		CS_0024_003C_003E8__locals15._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals15._0023_003DzmHS7frs_003D = progress;
		CS_0024_003C_003E8__locals15._0023_003Dzjvn7P10_003D = ct;
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D = new List<Point2D[]>();
		ResetProgressParallel();
		Parallel.For(0, _0023_003DzxQd3oX6_Iof8, _0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzrzNEh20Fe4m558IC9cy8Vd8_003D, CS_0024_003C_003E8__locals15._0023_003DzImyailaPCZRVSZ9_lg_003D_003D, delegate(List<Point2D[]> _0023_003DzBJFJHwk_003D)
		{
			lock (CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D)
			{
				CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D.AddRange(_0023_003DzBJFJHwk_003D);
			}
		});
		UpdateProgressTo100(ProgressBarText, CS_0024_003C_003E8__locals15._0023_003DzmHS7frs_003D);
		if (Cancelled(CS_0024_003C_003E8__locals15._0023_003Dzjvn7P10_003D))
		{
			return;
		}
		List<Line> list = new List<Line>(CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D.Count);
		for (int num = 0; num < CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D.Count; num++)
		{
			if (CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D[num][0] != CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D[num][1])
			{
				Line item = new Line(Plane.XY, CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D[num][0], CS_0024_003C_003E8__locals15._0023_003DzKTAIrow_003D[num][1]);
				list.Add(item);
			}
		}
		_0023_003DzijhYAd8_003D(list.ToArray());
	}

	protected virtual void ComputeCoords(int column, int row, double[,] coords)
	{
		coords[0, 0] = _0023_003DzytznN8ALiEzo.X + (double)((float)column * _0023_003Dz_2etYFFHxOYK);
		coords[0, 1] = _0023_003DzytznN8ALiEzo.Y + (double)((float)(row + 1) * _0023_003Dzbm3uSZ0TZIPP);
		coords[1, 0] = _0023_003DzytznN8ALiEzo.X + (double)((float)(column + 1) * _0023_003Dz_2etYFFHxOYK);
		coords[1, 1] = _0023_003DzytznN8ALiEzo.Y + (double)((float)(row + 1) * _0023_003Dzbm3uSZ0TZIPP);
		coords[2, 0] = _0023_003DzytznN8ALiEzo.X + (double)((float)(column + 1) * _0023_003Dz_2etYFFHxOYK);
		coords[2, 1] = _0023_003DzytznN8ALiEzo.Y + (double)((float)row * _0023_003Dzbm3uSZ0TZIPP);
		coords[3, 0] = _0023_003DzytznN8ALiEzo.X + (double)((float)column * _0023_003Dz_2etYFFHxOYK);
		coords[3, 1] = _0023_003DzytznN8ALiEzo.Y + (double)((float)row * _0023_003Dzbm3uSZ0TZIPP);
	}

	private static void _0023_003Dz5muzE45ca__0024hKx9QbA_003D_003D(double[,] _0023_003DzD0vYoclJjkWP, double[] _0023_003DzHSO_00246A0_003D, double _0023_003DzXJmcxGRWCE8F, List<Point2D[]> _0023_003DzKTAIrow_003D)
	{
		double[,] array = new double[4, 2];
		int num = 0;
		for (int i = 0; i < 4; i++)
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
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[0, 0], _0023_003DzD0vYoclJjkWP[0, 1], _0023_003DzHSO_00246A0_003D[0], _0023_003DzD0vYoclJjkWP[1, 0], _0023_003DzD0vYoclJjkWP[1, 1], _0023_003DzHSO_00246A0_003D[1], 0, array);
			}
			if ((num2 & 2) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[1, 0], _0023_003DzD0vYoclJjkWP[1, 1], _0023_003DzHSO_00246A0_003D[1], _0023_003DzD0vYoclJjkWP[2, 0], _0023_003DzD0vYoclJjkWP[2, 1], _0023_003DzHSO_00246A0_003D[2], 1, array);
			}
			if ((num2 & 4) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[2, 0], _0023_003DzD0vYoclJjkWP[2, 1], _0023_003DzHSO_00246A0_003D[2], _0023_003DzD0vYoclJjkWP[3, 0], _0023_003DzD0vYoclJjkWP[3, 1], _0023_003DzHSO_00246A0_003D[3], 2, array);
			}
			if ((num2 & 8) != 0)
			{
				_0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(_0023_003DzXJmcxGRWCE8F, _0023_003DzD0vYoclJjkWP[3, 0], _0023_003DzD0vYoclJjkWP[3, 1], _0023_003DzHSO_00246A0_003D[3], _0023_003DzD0vYoclJjkWP[0, 0], _0023_003DzD0vYoclJjkWP[0, 1], _0023_003DzHSO_00246A0_003D[0], 3, array);
			}
			for (int j = 0; _0023_003Dzy0JD_D_0024EUu3S[num, j] != -1; j += 2)
			{
				int num3 = _0023_003Dzy0JD_D_0024EUu3S[num, j];
				int num4 = _0023_003Dzy0JD_D_0024EUu3S[num, j + 1];
				_0023_003DzKTAIrow_003D.Add(new Point2D[2]
				{
					new Point2D(array[num3, 0], array[num3, 1]),
					new Point2D(array[num4, 0], array[num4, 1])
				});
			}
		}
	}

	private static void _0023_003DzkUmQtpUj8jv0zqoubQ_003D_003D(double _0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D, double _0023_003Dz81J0Y4Q_003D, double _0023_003Dzd_0024HoPb0_003D, double _0023_003Dzb2BdBiUHdTXP, double _0023_003Dz7mbD2AY_003D, double _0023_003DzPqpigS8_003D, double _0023_003Dzm06VjWteaXuo, int _0023_003DzyzK8swU_003D, double[,] _0023_003Dz7pqWuheV0uU_0024)
	{
		if (Math.Abs(_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzb2BdBiUHdTXP) < Utility._0023_003Dzjyaz_Vfaky9X)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D;
		}
		else if (Math.Abs(_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzm06VjWteaXuo) < Utility._0023_003Dzjyaz_Vfaky9X)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz7mbD2AY_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003DzPqpigS8_003D;
		}
		else if (Math.Abs(_0023_003Dzb2BdBiUHdTXP - _0023_003Dzm06VjWteaXuo) < Utility._0023_003Dzjyaz_Vfaky9X)
		{
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D;
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D;
		}
		else
		{
			double num = (_0023_003Dzl26Wmc_sxmlnyhcnBQ_003D_003D - _0023_003Dzb2BdBiUHdTXP) / (_0023_003Dzm06VjWteaXuo - _0023_003Dzb2BdBiUHdTXP);
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 0] = _0023_003Dz81J0Y4Q_003D + num * (_0023_003Dz7mbD2AY_003D - _0023_003Dz81J0Y4Q_003D);
			_0023_003Dz7pqWuheV0uU_0024[_0023_003DzyzK8swU_003D, 1] = _0023_003Dzd_0024HoPb0_003D + num * (_0023_003DzPqpigS8_003D - _0023_003Dzd_0024HoPb0_003D);
		}
	}
}
