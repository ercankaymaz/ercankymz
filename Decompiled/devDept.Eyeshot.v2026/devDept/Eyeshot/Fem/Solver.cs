using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Fem;

public class Solver : SolverBase
{
	private sealed class _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D
	{
		public double[][] _0023_003Dz90qRVXE_003D;

		public int _0023_003DzhY366QI_003D;

		public int[] _0023_003DzyzK8swU_003D;

		public int[] _0023_003DzAddCv_o_003D;

		public List<int>[] _0023_003DzA84fJPE_003D;

		public List<double>[] _0023_003DzUMBNENw_003D;

		public Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D;

		public int[] _0023_003DzDPPdnUk_003D;

		public int[] _0023_003Dzq2Pn86ffSKxt;

		public Solver _0023_003DzopRx0_MBcTQs;

		public double[] _0023_003Dz1v6oPQk_003D;

		public bool[] _0023_003DzsqRc7NtwlFbe;

		public int _0023_003DzgWCiBuA_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public int[] _0023_003Dz9iVQ96E_003D;

		internal void _0023_003DzB054tt1LZMRRTGMa6QErU_0024w5Tlvx(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
			_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] = _0023_003DzAddCv_o_003D[_0023_003Dz437_00244ak_003D];
			while (_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] < _0023_003Dz9iVQ96E_003D[_0023_003Dz437_00244ak_003D])
			{
				int num = _0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D];
				Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
				_0023_003DzA84fJPE_003D[num] = new List<int>();
				_0023_003DzUMBNENw_003D[num] = new List<double>();
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Process(_0023_003DzDPPdnUk_003D[num], _0023_003Dzq2Pn86ffSKxt, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzopRx0_MBcTQs.femMesh, _0023_003DzopRx0_MBcTQs.numberOfDegreesOfFreedom, freeMem: false, mass: false);
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Compress(num, _0023_003Dzq2Pn86ffSKxt, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzA84fJPE_003D[num], _0023_003DzUMBNENw_003D[num], _0023_003DzXMVGBHVmumq2ImENew_003D_003D, _0023_003Dz1v6oPQk_003D, ref _0023_003DzsqRc7NtwlFbe[_0023_003Dz437_00244ak_003D]);
				int progress = Utility.GetProgress(_0023_003DzyzK8swU_003D, _0023_003DzAddCv_o_003D, _0023_003DzgWCiBuA_003D);
				_0023_003DzopRx0_MBcTQs.UpdateProgress(progress, _0023_003DzhY366QI_003D, _0023_003DzopRx0_MBcTQs.SolvingPopulatingStiffnessText, _0023_003DzmHS7frs_003D);
				if (_0023_003DzopRx0_MBcTQs.Cancelled(_0023_003Dzjvn7P10_003D))
				{
					_0023_003Dz8If0AEk_003D = false;
					_0023_003DzLdZiL78_003D.Stop();
				}
				_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D]++;
			}
		}
	}

	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<bool, bool> _0023_003Dz3Qdk3ItVnOO3AkWkIA_003D_003D;

		public static Func<Equation, bool> _0023_003Dz0XL4MGDAp8_q5T2W4A_003D_003D;

		public static Func<bool, bool> _0023_003Dz96fhXpfiuZPM1zsPvg_003D_003D;

		internal bool _0023_003Dzvr2PPwy3GY7NR9N3NaeZh4hgi7YzvzS4BA_003D_003D(bool _0023_003DzcB8c8dw_003D)
		{
			return _0023_003DzcB8c8dw_003D;
		}

		internal bool _0023_003DzPTh47fVD99XJoW78hzK7vb8_003D(Equation _0023_003DzYO5g7Fc_003D)
		{
			return !_0023_003DzYO5g7Fc_003D.Restrained;
		}

		internal bool _0023_003DzmIQYnm01LDKhEwBZp_0B8XdMe7vNHERFbw_003D_003D(bool _0023_003DzcB8c8dw_003D)
		{
			return _0023_003DzcB8c8dw_003D;
		}
	}

	private sealed class _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D
	{
		public double[][] _0023_003Dz90qRVXE_003D;

		public int _0023_003DzhY366QI_003D;

		public int[] _0023_003DzyzK8swU_003D;

		public int[] _0023_003DzAddCv_o_003D;

		public List<int>[] _0023_003DzA84fJPE_003D;

		public List<double>[] _0023_003DzUMBNENw_003D;

		public Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D;

		public int[] _0023_003DzDPPdnUk_003D;

		public int[] _0023_003Dzq2Pn86ffSKxt;

		public Solver _0023_003DzopRx0_MBcTQs;

		public double[,] _0023_003DzDtqAooE_003D;

		public double[] _0023_003Dz1v6oPQk_003D;

		public bool[] _0023_003DzsqRc7NtwlFbe;

		public int _0023_003DzgWCiBuA_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public int[] _0023_003Dz9iVQ96E_003D;

		internal void _0023_003DzHYiyFEo7tjsbdWCObG2Es_I_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
			_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] = _0023_003DzAddCv_o_003D[_0023_003Dz437_00244ak_003D];
			while (_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] < _0023_003Dz9iVQ96E_003D[_0023_003Dz437_00244ak_003D])
			{
				int num = _0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D];
				Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
				_0023_003DzA84fJPE_003D[num] = new List<int>();
				_0023_003DzUMBNENw_003D[num] = new List<double>();
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Process(_0023_003DzDPPdnUk_003D[num], _0023_003Dzq2Pn86ffSKxt, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzopRx0_MBcTQs.femMesh, _0023_003DzopRx0_MBcTQs.numberOfDegreesOfFreedom, freeMem: true, mass: true);
				if (_0023_003DzDtqAooE_003D != null)
				{
					for (int i = 0; i < _0023_003DzhY366QI_003D; i++)
					{
						_0023_003DzDtqAooE_003D[_0023_003Dz437_00244ak_003D, i] = _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D][i];
					}
				}
				else
				{
					_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Compress(num, _0023_003Dzq2Pn86ffSKxt, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzA84fJPE_003D[num], _0023_003DzUMBNENw_003D[num], _0023_003DzXMVGBHVmumq2ImENew_003D_003D, _0023_003Dz1v6oPQk_003D, ref _0023_003DzsqRc7NtwlFbe[_0023_003Dz437_00244ak_003D]);
				}
				int progress = Utility.GetProgress(_0023_003DzyzK8swU_003D, _0023_003DzAddCv_o_003D, _0023_003DzgWCiBuA_003D);
				_0023_003DzopRx0_MBcTQs.UpdateProgress(progress, _0023_003DzhY366QI_003D, _0023_003DzopRx0_MBcTQs.SolvingPopulatingMassText, _0023_003DzmHS7frs_003D);
				if (_0023_003DzopRx0_MBcTQs.Cancelled(_0023_003Dzjvn7P10_003D))
				{
					_0023_003Dz8If0AEk_003D = false;
					_0023_003DzLdZiL78_003D.Stop();
				}
				_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D]++;
			}
		}
	}

	private sealed class _0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D
	{
		public double[][] _0023_003Dz90qRVXE_003D;

		public int _0023_003DzhY366QI_003D;

		public int[] _0023_003DzyzK8swU_003D;

		public int[] _0023_003DzAddCv_o_003D;

		public List<int>[] _0023_003DzA84fJPE_003D;

		public List<double>[] _0023_003DzUMBNENw_003D;

		public Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D;

		public Solver _0023_003DzopRx0_MBcTQs;

		public double[] _0023_003Dz1v6oPQk_003D;

		public bool[] _0023_003DzsqRc7NtwlFbe;

		public int _0023_003DzgWCiBuA_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public bool _0023_003Dz8If0AEk_003D;

		public int[] _0023_003Dz9iVQ96E_003D;

		internal void _0023_003DzB054tt1LZMRRTGMa6QErU_0024w5Tlvx(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
			_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] = _0023_003DzAddCv_o_003D[_0023_003Dz437_00244ak_003D];
			while (_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] < _0023_003Dz9iVQ96E_003D[_0023_003Dz437_00244ak_003D])
			{
				int num = _0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D];
				Array.Clear(_0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, _0023_003DzhY366QI_003D);
				_0023_003DzA84fJPE_003D[num] = new List<int>();
				_0023_003DzUMBNENw_003D[num] = new List<double>();
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Process(num, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzopRx0_MBcTQs.femMesh, _0023_003DzopRx0_MBcTQs.numberOfDegreesOfFreedom, freeMem: false);
				_0023_003DzXMVGBHVmumq2ImENew_003D_003D[num].Compress(num, _0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], _0023_003DzA84fJPE_003D[num], _0023_003DzUMBNENw_003D[num], _0023_003DzXMVGBHVmumq2ImENew_003D_003D, _0023_003Dz1v6oPQk_003D, ref _0023_003DzsqRc7NtwlFbe[_0023_003Dz437_00244ak_003D]);
				int progress = Utility.GetProgress(_0023_003DzyzK8swU_003D, _0023_003DzAddCv_o_003D, _0023_003DzgWCiBuA_003D);
				_0023_003DzopRx0_MBcTQs.UpdateProgress(progress, _0023_003DzhY366QI_003D, _0023_003DzopRx0_MBcTQs.SolvingPopulatingStiffnessText, _0023_003DzmHS7frs_003D);
				if (_0023_003DzopRx0_MBcTQs.Cancelled(_0023_003Dzjvn7P10_003D))
				{
					_0023_003Dz8If0AEk_003D = false;
					_0023_003DzLdZiL78_003D.Stop();
				}
				_0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D]++;
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzw4q8QBvXIkrSou0crrE9qZFMyFJs2Ztd6VkQrdniEKQJ = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985664);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DznA9GhRNeDwPA5chPJbJ2J_5_mIgPFcdj7wmVdbY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985610);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz8AgsGDBcXNym = 1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzBo0_cM9JSZvs4LPCew_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzaPxEqTfuClSryv3uFQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzdpsHwYjA07RkqJPekFaWUZw_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz5oSSq5ZJpR14jydYc7B53DsdeQKaBSZCRsKZHlXBIVhgzYIrpw_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985319);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzr6q5VHbH6j1z0ictAGz8KeaqSorw7liVg5kqDx4_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985272);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly double _0023_003Dzv8R_0024yK5_mdUd;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003DziGC_lwJxtru7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzyHbnlUWxN4s2hAytnQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DznC8rNG1WdfFlSNUufA_003D_003D;

	public string SolvingPopulatingMassText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzw4q8QBvXIkrSou0crrE9qZFMyFJs2Ztd6VkQrdniEKQJ;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzw4q8QBvXIkrSou0crrE9qZFMyFJs2Ztd6VkQrdniEKQJ = value;
		}
	}

	public string SolvingEigenvaluesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DznA9GhRNeDwPA5chPJbJ2J_5_mIgPFcdj7wmVdbY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DznA9GhRNeDwPA5chPJbJ2J_5_mIgPFcdj7wmVdbY_003D = value;
		}
	}

	public string SolvingPopulatingStiffnessText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz5oSSq5ZJpR14jydYc7B53DsdeQKaBSZCRsKZHlXBIVhgzYIrpw_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz5oSSq5ZJpR14jydYc7B53DsdeQKaBSZCRsKZHlXBIVhgzYIrpw_003D_003D = value;
		}
	}

	public string SolvingEquationsText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzr6q5VHbH6j1z0ictAGz8KeaqSorw7liVg5kqDx4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzr6q5VHbH6j1z0ictAGz8KeaqSorw7liVg5kqDx4_003D = value;
		}
	}

	public bool Converged => _0023_003DzyHbnlUWxN4s2hAytnQ_003D_003D;

	public int Iterations => _0023_003DznC8rNG1WdfFlSNUufA_003D_003D;

	public Solver(FemMesh mesh, int numberOfModes)
		: this(mesh, numberOfModes, 1E-06, 10000, 0.001, 1, false)
	{
	}

	public Solver(FemMesh mesh, int numberOfModes, double tol = 1E-06, int maxIter = 10000, double eigenTolerance = 0.001, int maxLanczosIters = 1, bool lumpMassMatrix = false)
		: this(mesh, tol, maxIter)
	{
		femMesh = mesh;
		_0023_003DzSyKpZB7iGSdW_aNQJQ_003D_003D((_0023_003DzSx8c8OMfZIP3)1);
		_0023_003Dz8AgsGDBcXNym = numberOfModes;
		_0023_003DzBo0_cM9JSZvs4LPCew_003D_003D = eigenTolerance;
		_0023_003DzaPxEqTfuClSryv3uFQ_003D_003D = lumpMassMatrix;
		_0023_003DzdpsHwYjA07RkqJPekFaWUZw_003D = maxLanczosIters;
	}

	public Solver(FemMesh mesh)
		: this(mesh, 1E-06, 10000)
	{
	}

	public Solver(FemMesh mesh, double tol = 1E-06, int maxIter = 10000)
	{
		femMesh = mesh;
		_0023_003Dzv8R_0024yK5_mdUd = tol;
		_0023_003DzSyKpZB7iGSdW_aNQJQ_003D_003D((_0023_003DzSx8c8OMfZIP3)0);
		_0023_003DziGC_lwJxtru7 = maxIter;
	}

	private void _0023_003DzOF4zsRfdbixo4mv73A_003D_003D(int _0023_003DzoMNiNRw_003D, int[] _0023_003DztBCWvI0_003D, List<int> _0023_003Dzosles3E_003D, List<double> _0023_003Dz4oYSX9w_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, int _0023_003DzB68dg9Q_003D, double _0023_003Dzm0CYiiE_003D, int _0023_003DzFT8RxwsaFj2h, WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, out double[] _0023_003DzyUB_0024YqoIqRCs, out double[,] _0023_003DziNwcIVhjwtVt)
	{
		double[,] _0023_003Dzyk2fsPo_003D = null;
		int[] startIndex;
		int[] endIndex;
		int cpuCount = Utility.GetCpuCount(_0023_003DzoMNiNRw_003D, out startIndex, out endIndex);
		double[][] array = new double[cpuCount][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new double[_0023_003DzoMNiNRw_003D];
		}
		_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2 = null;
		int num = 0;
		for (int j = 2; j < _0023_003DzFT8RxwsaFj2h + 2; j++)
		{
			num = j * _0023_003DzB68dg9Q_003D;
			double[,] array2 = _0023_003DzaXpjtV2_Er4yIXUSOQ_003D_003D(_0023_003DzoMNiNRw_003D, _0023_003DztBCWvI0_003D, _0023_003Dzosles3E_003D, _0023_003Dz4oYSX9w_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, num, cpuCount, startIndex, endIndex, array, _0023_003Dz_IUshyU_003D, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, out _0023_003Dzyk2fsPo_003D);
			double[] array3 = new double[_0023_003DzB68dg9Q_003D];
			double num2 = array2[num - 1, num - 2];
			_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2 = new _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz(array2, _0023_003Dzz1zRqomK9jtILG1k2Q_003D_003D: true, _0023_003DzuWbYKRJA_cXR: true, _0023_003DzoQcRoMY_003D: true);
			for (int k = 0; k < _0023_003DzB68dg9Q_003D; k++)
			{
				array3[k] = num2 * _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DziqPmecX6waT2d26HKbXnPEE_003D()[num - 1, k];
			}
			if (array3.Max() < _0023_003Dzm0CYiiE_003D)
			{
				break;
			}
		}
		_0023_003DzyUB_0024YqoIqRCs = new double[_0023_003DzB68dg9Q_003D];
		_0023_003DziNwcIVhjwtVt = new double[_0023_003DzoMNiNRw_003D, _0023_003DzB68dg9Q_003D];
		for (int l = 0; l < _0023_003DzB68dg9Q_003D; l++)
		{
			_0023_003DzyUB_0024YqoIqRCs[l] = 1.0 / _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DzMSUJVwizKGcggd0NSj1eFPw_003D()[l];
		}
		for (int m = 0; m < _0023_003DzB68dg9Q_003D; m++)
		{
			double[] array4 = new double[num];
			for (int n = 0; n < num; n++)
			{
				array4[n] = _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DziqPmecX6waT2d26HKbXnPEE_003D()[n, m];
			}
			double[] array5 = Matrix.Multiply(_0023_003Dzyk2fsPo_003D, array4);
			for (int num3 = 0; num3 < _0023_003DzoMNiNRw_003D; num3++)
			{
				_0023_003DziNwcIVhjwtVt[num3, m] = array5[num3];
			}
		}
	}

	private double[,] _0023_003DzaXpjtV2_Er4yIXUSOQ_003D_003D(int _0023_003DzoMNiNRw_003D, int[] _0023_003DztBCWvI0_003D, List<int> _0023_003Dzosles3E_003D, List<double> _0023_003Dz4oYSX9w_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, int _0023_003DzO_0024iiQ4U_003D, int _0023_003DzgWCiBuA_003D, int[] _0023_003DzAddCv_o_003D, int[] _0023_003Dz9iVQ96E_003D, double[][] _0023_003DzEtfQXlQ_003D, WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, out double[,] _0023_003Dzyk2fsPo_003D)
	{
		double _0023_003Dza_7_00246lWmTw9s = 0.0;
		double[] _0023_003DzPvQLSfM_003D = new double[_0023_003DzoMNiNRw_003D];
		double[] array = new double[_0023_003DzoMNiNRw_003D];
		double[] _0023_003DzTbE_0024JUZjKYG = new double[_0023_003DzoMNiNRw_003D];
		double[] _0023_003DzGmFQrgY_003D = new double[_0023_003DzoMNiNRw_003D];
		double[] _0023_003DzkIwUf9YLL9RO = new double[_0023_003DzoMNiNRw_003D];
		double[,] array2 = new double[_0023_003DzO_0024iiQ4U_003D, _0023_003DzO_0024iiQ4U_003D];
		_0023_003Dzyk2fsPo_003D = new double[_0023_003DzoMNiNRw_003D, _0023_003DzO_0024iiQ4U_003D];
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			array[i] = 1.0;
		}
		double num = _0023_003DzfKmfPyU94wEY(_0023_003DzoMNiNRw_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, array);
		for (int j = 0; j < _0023_003DzoMNiNRw_003D; j++)
		{
			array[j] /= num;
		}
		double _0023_003DzheSR8QM7q9ya = Utility._0023_003DzheSR8QM7q9ya;
		for (int k = 0; k < _0023_003DzoMNiNRw_003D; k++)
		{
			_0023_003Dzyk2fsPo_003D[k, 0] = array[k];
		}
		for (int l = 0; l < _0023_003DzO_0024iiQ4U_003D; l++)
		{
			_0023_003Dz_IUshyU_003D.UpdateProgress(l + 1, _0023_003DzO_0024iiQ4U_003D, SolvingEigenvaluesText, _0023_003DzmHS7frs_003D);
			array = _0023_003Dzb_0024j4Jy4_eaD2UdsNuA_003D_003D(_0023_003DzoMNiNRw_003D, _0023_003DztBCWvI0_003D, _0023_003Dzosles3E_003D, _0023_003Dz4oYSX9w_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzO_0024iiQ4U_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, _0023_003Dz_IUshyU_003D, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003Dzyk2fsPo_003D, array, _0023_003DzGmFQrgY_003D, _0023_003DzheSR8QM7q9ya, _0023_003DzPvQLSfM_003D, l, _0023_003DzkIwUf9YLL9RO, array2, _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, ref _0023_003Dza_7_00246lWmTw9s, ref _0023_003DzTbE_0024JUZjKYG);
		}
		return array2;
	}

	private double[] _0023_003Dzb_0024j4Jy4_eaD2UdsNuA_003D_003D(int _0023_003DzoMNiNRw_003D, int[] _0023_003DztBCWvI0_003D, List<int> _0023_003Dzosles3E_003D, List<double> _0023_003Dz4oYSX9w_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, int _0023_003DzO_0024iiQ4U_003D, int _0023_003DzgWCiBuA_003D, int[] _0023_003DzAddCv_o_003D, int[] _0023_003Dz9iVQ96E_003D, double[][] _0023_003DzEtfQXlQ_003D, WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, double[,] _0023_003Dzyk2fsPo_003D, double[] _0023_003Dzs7sO4pw_003D, double[] _0023_003DzGmFQrgY_003D, double _0023_003DzezTples_003D, double[] _0023_003DzPvQLSfM_003D, int _0023_003Dz437_00244ak_003D, double[] _0023_003DzkIwUf9YLL9RO, double[,] _0023_003DzWWgGxds_003D, bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, ref double _0023_003Dza_7_00246lWmTw9s, ref double[] _0023_003DzTbE_0024JUZjKYG4)
	{
		double[] _0023_003DzlP92nO4_003D = _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi._0023_003DzT6_002425rA_003D(_0023_003DzoMNiNRw_003D, _0023_003Dzs7sO4pw_003D, _0023_003DzrXvyiTY_003D, _0023_003DzuxK_VL8_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D);
		_0023_003DzGmFQrgY_003D = new double[_0023_003DzoMNiNRw_003D];
		_0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2 = new _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi(_0023_003DztBCWvI0_003D, _0023_003Dzosles3E_003D, _0023_003Dz4oYSX9w_003D, _0023_003DzlP92nO4_003D, _0023_003DzGmFQrgY_003D, 1E-09, _0023_003DziGC_lwJxtru7)
		{
			_0023_003DzqcfH4idvU5LE = false
		};
		if (!((!_0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D) ? _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2._0023_003DzGhs2wJhjEHb8Q5ikpg_003D_003D(_0023_003Dz_IUshyU_003D, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, out var _0023_003DzdcIp_Hg_003D) : _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2._0023_003DzOykoXtw_003D(_0023_003Dz_IUshyU_003D, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, out _0023_003DzdcIp_Hg_003D)))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985235));
		}
		double num = _0023_003DzBqRBpKg_003D(_0023_003DzoMNiNRw_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, _0023_003DzGmFQrgY_003D, _0023_003Dzs7sO4pw_003D);
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			_0023_003DzPvQLSfM_003D[i] = _0023_003DzGmFQrgY_003D[i] - num * _0023_003Dzs7sO4pw_003D[i] - _0023_003Dza_7_00246lWmTw9s * _0023_003DzTbE_0024JUZjKYG4[i];
		}
		double[] array = new double[_0023_003DzoMNiNRw_003D];
		for (int j = 0; j <= _0023_003Dz437_00244ak_003D; j++)
		{
			double[] array2 = new double[_0023_003DzoMNiNRw_003D];
			for (int k = 0; k < _0023_003DzoMNiNRw_003D; k++)
			{
				array2[k] = _0023_003Dzyk2fsPo_003D[k, j];
			}
			double num2 = _0023_003DzBqRBpKg_003D(_0023_003DzoMNiNRw_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, _0023_003DzPvQLSfM_003D, array2);
			for (int l = 0; l < _0023_003DzoMNiNRw_003D; l++)
			{
				array[l] -= num2 * array2[l];
			}
		}
		for (int m = 0; m < _0023_003DzoMNiNRw_003D; m++)
		{
			_0023_003DzPvQLSfM_003D[m] += array[m];
		}
		double num3 = _0023_003DzfKmfPyU94wEY(_0023_003DzoMNiNRw_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, _0023_003DzPvQLSfM_003D);
		_0023_003DzTbE_0024JUZjKYG4 = _0023_003Dzs7sO4pw_003D;
		for (int n = 0; n < _0023_003DzoMNiNRw_003D; n++)
		{
			_0023_003DzkIwUf9YLL9RO[n] = _0023_003DzPvQLSfM_003D[n] / num3;
		}
		_0023_003Dzs7sO4pw_003D = _0023_003DzkIwUf9YLL9RO;
		_0023_003DzWWgGxds_003D[_0023_003Dz437_00244ak_003D, _0023_003Dz437_00244ak_003D] = num;
		if (_0023_003Dz437_00244ak_003D + 1 < _0023_003DzO_0024iiQ4U_003D)
		{
			_0023_003DzWWgGxds_003D[_0023_003Dz437_00244ak_003D, _0023_003Dz437_00244ak_003D + 1] = num3;
			_0023_003DzWWgGxds_003D[_0023_003Dz437_00244ak_003D + 1, _0023_003Dz437_00244ak_003D] = num3;
		}
		if (_0023_003Dz437_00244ak_003D + 1 < _0023_003DzO_0024iiQ4U_003D)
		{
			for (int num4 = 0; num4 < _0023_003DzoMNiNRw_003D; num4++)
			{
				_0023_003Dzyk2fsPo_003D[num4, _0023_003Dz437_00244ak_003D + 1] = _0023_003DzkIwUf9YLL9RO[num4];
			}
		}
		_0023_003Dza_7_00246lWmTw9s = num3;
		return _0023_003Dzs7sO4pw_003D;
	}

	private double _0023_003DzBqRBpKg_003D(int _0023_003DzoMNiNRw_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, int _0023_003DzgWCiBuA_003D, int[] _0023_003DzAddCv_o_003D, int[] _0023_003Dz9iVQ96E_003D, double[][] _0023_003DzEtfQXlQ_003D, double[] _0023_003DzBJFJHwk_003D, double[] _0023_003Dz40R7bAU_003D)
	{
		double num = 0.0;
		double[] array = _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi._0023_003DzT6_002425rA_003D(_0023_003Dzxp_0024Apxw_003D.Length - 1, _0023_003Dz40R7bAU_003D, _0023_003DzrXvyiTY_003D, _0023_003DzuxK_VL8_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D);
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			num += _0023_003DzBJFJHwk_003D[i] * array[i];
		}
		return num;
	}

	private double _0023_003DzfKmfPyU94wEY(int _0023_003DzoMNiNRw_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, int _0023_003DzgWCiBuA_003D, int[] _0023_003DzAddCv_o_003D, int[] _0023_003Dz9iVQ96E_003D, double[][] _0023_003DzEtfQXlQ_003D, double[] _0023_003DzBJFJHwk_003D)
	{
		return Math.Sqrt(_0023_003DzBqRBpKg_003D(_0023_003DzoMNiNRw_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003DzgWCiBuA_003D, _0023_003DzAddCv_o_003D, _0023_003Dz9iVQ96E_003D, _0023_003DzEtfQXlQ_003D, _0023_003DzBJFJHwk_003D, _0023_003DzBJFJHwk_003D));
	}

	private void _0023_003Dzd9z0jdc_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, int _0023_003DzhY366QI_003D, int[] _0023_003DztBCWvI0_003D, List<int> _0023_003Dzosles3E_003D, List<double> _0023_003Dz4oYSX9w_003D, double[,] _0023_003DzDtqAooE_003D, bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, double[][] _0023_003DzBJFJHwk_003D, int[] _0023_003DzDPPdnUk_003D)
	{
		_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2 = new _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz(Matrix.Multiply(_0023_003DzR9v6xU9cAbnALisOIg_003D_003D(_0023_003DzhY366QI_003D, _0023_003DztBCWvI0_003D, _0023_003Dzosles3E_003D, _0023_003Dz4oYSX9w_003D, this, SolvingEigenvaluesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D), _0023_003DzDtqAooE_003D), _0023_003Dzz1zRqomK9jtILG1k2Q_003D_003D: false, _0023_003DzuWbYKRJA_cXR: true, _0023_003DzoQcRoMY_003D: true);
		double[] array = new double[_0023_003Dz8AgsGDBcXNym];
		double[,] array2 = new double[_0023_003DzhY366QI_003D, _0023_003Dz8AgsGDBcXNym];
		for (int num = _0023_003Dz8AgsGDBcXNym - 1; num >= 0; num--)
		{
			array[num] = 1.0 / Math.Sqrt(_0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DzMSUJVwizKGcggd0NSj1eFPw_003D()[num]);
		}
		for (int num2 = _0023_003Dz8AgsGDBcXNym - 1; num2 >= 0; num2--)
		{
			for (int i = 0; i < _0023_003DzhY366QI_003D; i++)
			{
				array2[i, num2] = _0023_003DzdOgZt0OiDbquSKdz9ac39Rwhiz7wUkSWVjqjMY_gonPz2._0023_003DziqPmecX6waT2d26HKbXnPEE_003D()[i, num2];
			}
		}
		femMesh._0023_003Dzzf5jb4sXwuH_86CXUvpzOpU_003D(new double[_0023_003Dz8AgsGDBcXNym]);
		for (int j = 0; j < _0023_003Dz8AgsGDBcXNym; j++)
		{
			femMesh.NaturalFrequencies[j] = array[j] / (Math.PI * 2.0);
		}
		for (int k = 0; k < _0023_003Dz8AgsGDBcXNym; k++)
		{
			for (int l = 0; l < _0023_003DzhY366QI_003D; l++)
			{
				double num3 = array2[l, k];
				_0023_003DzBJFJHwk_003D[k][_0023_003DzDPPdnUk_003D[l]] = num3;
			}
		}
	}

	private void _0023_003DzR0KI77JNRcLa0GZA4A_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, int _0023_003DzhY366QI_003D, int[] _0023_003DztBCWvI0_003D, List<int> _0023_003Dzosles3E_003D, List<double> _0023_003Dz4oYSX9w_003D, int[] _0023_003Dzxp_0024Apxw_003D, List<int> _0023_003DzuxK_VL8_003D, List<double> _0023_003DzrXvyiTY_003D, bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, double[][] _0023_003DzBJFJHwk_003D, int[] _0023_003DzDPPdnUk_003D)
	{
		_0023_003DzOF4zsRfdbixo4mv73A_003D_003D(_0023_003DzhY366QI_003D, _0023_003DztBCWvI0_003D, _0023_003Dzosles3E_003D, _0023_003Dz4oYSX9w_003D, _0023_003Dzxp_0024Apxw_003D, _0023_003DzuxK_VL8_003D, _0023_003DzrXvyiTY_003D, _0023_003Dz8AgsGDBcXNym, _0023_003DzBo0_cM9JSZvs4LPCew_003D_003D, _0023_003DzdpsHwYjA07RkqJPekFaWUZw_003D, this, SolvingEigenvaluesText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, out var _0023_003DzyUB_0024YqoIqRCs, out var _0023_003DziNwcIVhjwtVt);
		for (int i = 0; i < _0023_003Dz8AgsGDBcXNym; i++)
		{
			_0023_003DzyUB_0024YqoIqRCs[i] = Math.Sqrt(_0023_003DzyUB_0024YqoIqRCs[i]);
			_0023_003DzyUB_0024YqoIqRCs[i] /= Math.PI * 2.0;
		}
		femMesh._0023_003Dzzf5jb4sXwuH_86CXUvpzOpU_003D(_0023_003DzyUB_0024YqoIqRCs);
		for (int j = 0; j < _0023_003Dz8AgsGDBcXNym; j++)
		{
			double num = 0.0;
			for (int k = 0; k < _0023_003DzhY366QI_003D; k++)
			{
				double num2 = _0023_003DziNwcIVhjwtVt[k, j];
				_0023_003DzBJFJHwk_003D[j][_0023_003DzDPPdnUk_003D[k]] = num2;
				num += num2 * num2;
			}
			num = Math.Sqrt(num);
			for (int l = 0; l < _0023_003DzhY366QI_003D; l++)
			{
				_0023_003DzBJFJHwk_003D[j][_0023_003DzDPPdnUk_003D[l]] /= num;
			}
		}
	}

	private double[,] _0023_003DzR9v6xU9cAbnALisOIg_003D_003D(int _0023_003DzoMNiNRw_003D, int[] _0023_003DzmQTFaQA_003D, List<int> _0023_003DzeV5N9i0_003D, List<double> _0023_003DzE8QrneA_003D, WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		double[,] array = new double[_0023_003DzoMNiNRw_003D, _0023_003DzoMNiNRw_003D];
		for (int i = 0; i < _0023_003DzoMNiNRw_003D; i++)
		{
			double[] array2 = new double[_0023_003DzoMNiNRw_003D];
			double[] array3 = new double[_0023_003DzoMNiNRw_003D];
			array2[i] = 1.0;
			new _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi(_0023_003DzmQTFaQA_003D, _0023_003DzeV5N9i0_003D, _0023_003DzE8QrneA_003D, array2, array3, 1E-09, _0023_003DziGC_lwJxtru7)._0023_003DzGhs2wJhjEHb8Q5ikpg_003D_003D(_0023_003Dz_IUshyU_003D, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, out var _);
			for (int j = 0; j < _0023_003DzoMNiNRw_003D; j++)
			{
				array[i, j] = array3[j];
			}
		}
		return array;
	}

	private bool _0023_003DzI9M1zzoFq893(int _0023_003DzhY366QI_003D, int[] _0023_003DzDPPdnUk_003D, int[] _0023_003Dzq2Pn86ffSKxt, int[] _0023_003DzmQTFaQA_003D, List<int> _0023_003DzeV5N9i0_003D, List<double> _0023_003DzE8QrneA_003D, double[] _0023_003Dz1v6oPQk_003D, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, ref bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, double[,] _0023_003DzDtqAooE_003D)
	{
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2 = new _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D();
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D = _0023_003DzhY366QI_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzXMVGBHVmumq2ImENew_003D_003D = _0023_003DzXMVGBHVmumq2ImENew_003D_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzDPPdnUk_003D = _0023_003DzDPPdnUk_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzq2Pn86ffSKxt = _0023_003Dzq2Pn86ffSKxt;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzopRx0_MBcTQs = this;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzDtqAooE_003D = _0023_003DzDtqAooE_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz1v6oPQk_003D = _0023_003Dz1v6oPQk_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D = Utility.GetCpuCount(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D, out _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzAddCv_o_003D, out _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz9iVQ96E_003D);
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzyzK8swU_003D = new int[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D];
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzsqRc7NtwlFbe = new bool[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D];
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz90qRVXE_003D = new double[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D][];
		for (int i = 0; i < _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D; i++)
		{
			_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz90qRVXE_003D[i] = new double[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D];
		}
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzA84fJPE_003D = new List<int>[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D];
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzUMBNENw_003D = new List<double>[_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D];
		_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz8If0AEk_003D = true;
		Parallel.For(0, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzgWCiBuA_003D, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzHYiyFEo7tjsbdWCObG2Es_I_003D);
		if (_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(SolvingPopulatingMassText, _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzmHS7frs_003D);
			Element[] elements = femMesh.Elements;
			for (int j = 0; j < elements.Length; j++)
			{
				elements[j]._0023_003Dzj_0024GuASrCwPN4();
			}
			bool[] _0023_003DzsqRc7NtwlFbe = _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzsqRc7NtwlFbe;
			for (int j = 0; j < _0023_003DzsqRc7NtwlFbe.Length; j++)
			{
				if (_0023_003DzsqRc7NtwlFbe[j])
				{
					_0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D = true;
					break;
				}
			}
			if (_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzDtqAooE_003D == null)
			{
				for (int k = 0; k < _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzhY366QI_003D; k++)
				{
					int count = _0023_003DzE8QrneA_003D.Count;
					_0023_003DzmQTFaQA_003D[k] = count;
					_0023_003DzE8QrneA_003D.AddRange(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzUMBNENw_003D[k]);
					_0023_003DzeV5N9i0_003D.AddRange(_0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003DzA84fJPE_003D[k]);
				}
			}
		}
		return _0023_003Dz3IvZMC7XbiLQB2P8J7iP4tw_003D2._0023_003Dz8If0AEk_003D;
	}

	private void _0023_003Dzy_00249d0y1gjqKpZr2Nmjh6Q6g_003D(int _0023_003DzhY366QI_003D, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, out int[] _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D, out int[] _0023_003Dzq2Pn86ffSKxt)
	{
		_0023_003Dzq2Pn86ffSKxt = new int[_0023_003DzhY366QI_003D];
		List<int> list = new List<int>(_0023_003DzhY366QI_003D);
		int num = 0;
		for (int i = 0; i < _0023_003DzhY366QI_003D; i++)
		{
			if (_0023_003DzXMVGBHVmumq2ImENew_003D_003D[i].Restrained)
			{
				_0023_003Dzq2Pn86ffSKxt[i] = -1;
				continue;
			}
			_0023_003Dzq2Pn86ffSKxt[i] = num;
			list.Add(i);
			num++;
		}
		_0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D = list.ToArray();
	}

	private bool _0023_003Dz3rosEHYVu7Mbm6Kr7__kgQ4_003D(int _0023_003DzhY366QI_003D, int[] _0023_003DzDPPdnUk_003D, int[] _0023_003Dzq2Pn86ffSKxt, int[] _0023_003DzmQTFaQA_003D, List<int> _0023_003DzeV5N9i0_003D, List<double> _0023_003DzE8QrneA_003D, double[] _0023_003Dz1v6oPQk_003D, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, ref bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D)
	{
		_0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D CS_0024_003C_003E8__locals71 = new _0023_003Dz1hJs_eYOlCbNZaKaGq4SmFc_003D();
		CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D = _0023_003DzhY366QI_003D;
		CS_0024_003C_003E8__locals71._0023_003DzXMVGBHVmumq2ImENew_003D_003D = _0023_003DzXMVGBHVmumq2ImENew_003D_003D;
		CS_0024_003C_003E8__locals71._0023_003DzDPPdnUk_003D = _0023_003DzDPPdnUk_003D;
		CS_0024_003C_003E8__locals71._0023_003Dzq2Pn86ffSKxt = _0023_003Dzq2Pn86ffSKxt;
		CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals71._0023_003Dz1v6oPQk_003D = _0023_003Dz1v6oPQk_003D;
		CS_0024_003C_003E8__locals71._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals71._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		CS_0024_003C_003E8__locals71._0023_003Dz8If0AEk_003D = true;
		CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D = Utility.GetCpuCount(CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D, out CS_0024_003C_003E8__locals71._0023_003DzAddCv_o_003D, out CS_0024_003C_003E8__locals71._0023_003Dz9iVQ96E_003D);
		CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D = new int[CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D];
		CS_0024_003C_003E8__locals71._0023_003DzsqRc7NtwlFbe = new bool[CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D];
		CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D = new double[CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D][];
		for (int i = 0; i < CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D; i++)
		{
			CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D[i] = new double[CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D];
		}
		CS_0024_003C_003E8__locals71._0023_003DzA84fJPE_003D = new List<int>[CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D];
		CS_0024_003C_003E8__locals71._0023_003DzUMBNENw_003D = new List<double>[CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D];
		Parallel.For(0, CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D, delegate(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Array.Clear(CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D);
			CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] = CS_0024_003C_003E8__locals71._0023_003DzAddCv_o_003D[_0023_003Dz437_00244ak_003D];
			while (CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] < CS_0024_003C_003E8__locals71._0023_003Dz9iVQ96E_003D[_0023_003Dz437_00244ak_003D])
			{
				int num3 = CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D];
				Array.Clear(CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D);
				CS_0024_003C_003E8__locals71._0023_003DzA84fJPE_003D[num3] = new List<int>();
				CS_0024_003C_003E8__locals71._0023_003DzUMBNENw_003D[num3] = new List<double>();
				CS_0024_003C_003E8__locals71._0023_003DzXMVGBHVmumq2ImENew_003D_003D[num3].Process(CS_0024_003C_003E8__locals71._0023_003DzDPPdnUk_003D[num3], CS_0024_003C_003E8__locals71._0023_003Dzq2Pn86ffSKxt, CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs.femMesh, CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs.numberOfDegreesOfFreedom, freeMem: false, mass: false);
				CS_0024_003C_003E8__locals71._0023_003DzXMVGBHVmumq2ImENew_003D_003D[num3].Compress(num3, CS_0024_003C_003E8__locals71._0023_003Dzq2Pn86ffSKxt, CS_0024_003C_003E8__locals71._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals71._0023_003DzA84fJPE_003D[num3], CS_0024_003C_003E8__locals71._0023_003DzUMBNENw_003D[num3], CS_0024_003C_003E8__locals71._0023_003DzXMVGBHVmumq2ImENew_003D_003D, CS_0024_003C_003E8__locals71._0023_003Dz1v6oPQk_003D, ref CS_0024_003C_003E8__locals71._0023_003DzsqRc7NtwlFbe[_0023_003Dz437_00244ak_003D]);
				int progress = Utility.GetProgress(CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D, CS_0024_003C_003E8__locals71._0023_003DzAddCv_o_003D, CS_0024_003C_003E8__locals71._0023_003DzgWCiBuA_003D);
				CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs.UpdateProgress(progress, CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D, CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs.SolvingPopulatingStiffnessText, CS_0024_003C_003E8__locals71._0023_003DzmHS7frs_003D);
				if (CS_0024_003C_003E8__locals71._0023_003DzopRx0_MBcTQs.Cancelled(CS_0024_003C_003E8__locals71._0023_003Dzjvn7P10_003D))
				{
					CS_0024_003C_003E8__locals71._0023_003Dz8If0AEk_003D = false;
					_0023_003DzLdZiL78_003D.Stop();
				}
				CS_0024_003C_003E8__locals71._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D]++;
			}
		});
		if (CS_0024_003C_003E8__locals71._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(SolvingPopulatingStiffnessText, CS_0024_003C_003E8__locals71._0023_003DzmHS7frs_003D);
			if (CS_0024_003C_003E8__locals71._0023_003DzsqRc7NtwlFbe.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dzvr2PPwy3GY7NR9N3NaeZh4hgi7YzvzS4BA_003D_003D))
			{
				_0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D = true;
			}
			for (int num = 0; num < CS_0024_003C_003E8__locals71._0023_003DzhY366QI_003D; num++)
			{
				int count = _0023_003DzE8QrneA_003D.Count;
				_0023_003DzmQTFaQA_003D[num] = count;
				_0023_003DzE8QrneA_003D.AddRange(CS_0024_003C_003E8__locals71._0023_003DzUMBNENw_003D[num]);
				_0023_003DzeV5N9i0_003D.AddRange(CS_0024_003C_003E8__locals71._0023_003DzA84fJPE_003D[num]);
			}
		}
		if (CS_0024_003C_003E8__locals71._0023_003Dz8If0AEk_003D)
		{
			Element[] elements = femMesh.Elements;
			for (int num2 = 0; num2 < elements.Length; num2++)
			{
				elements[num2]._0023_003Dzxlnq6Q__3EAt();
			}
		}
		return CS_0024_003C_003E8__locals71._0023_003Dz8If0AEk_003D;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		if (PreProcessing(progress, ct, out var maxNodeId, out var order, out var hasTemperature, out var firstElType, _0023_003DzaPxEqTfuClSryv3uFQ_003D_003D))
		{
			return;
		}
		Equation[] array2 = new Equation[order];
		for (int i = 0; i < order; i++)
		{
			array2[i] = new Equation();
		}
		for (int j = 0; j <= maxNodeId; j++)
		{
			Node node = (Node)femMesh._vertices[j];
			if (node.Restrained)
			{
				if (node.Restraints[0])
				{
					array2[j * numberOfDegreesOfFreedom].Restrained = true;
					array2[j * numberOfDegreesOfFreedom].FixedDispl = node.Displacement[0];
				}
				if (node.Restraints[1])
				{
					array2[j * numberOfDegreesOfFreedom + 1].Restrained = true;
					array2[j * numberOfDegreesOfFreedom + 1].FixedDispl = node.Displacement[1];
				}
				if (numberOfDimensions > 2 && node.Restraints[2])
				{
					array2[j * numberOfDegreesOfFreedom + 2].Restrained = true;
					array2[j * numberOfDegreesOfFreedom + 2].FixedDispl = node.Displacement[2];
				}
			}
			if (!(node is NodeBeam { RotationRestrained: not false } nodeBeam))
			{
				continue;
			}
			if (numberOfDegreesOfFreedom == 3)
			{
				if (nodeBeam.rotationRestraints[0])
				{
					array2[j * numberOfDegreesOfFreedom + 2].Restrained = true;
					array2[j * numberOfDegreesOfFreedom + 2].FixedDispl = nodeBeam.rotationDisplacement[0];
				}
				continue;
			}
			if (nodeBeam.rotationRestraints[0])
			{
				array2[j * numberOfDegreesOfFreedom + 3].Restrained = true;
				array2[j * numberOfDegreesOfFreedom + 3].FixedDispl = nodeBeam.rotationDisplacement[0];
			}
			if (nodeBeam.rotationRestraints[1])
			{
				array2[j * numberOfDegreesOfFreedom + 4].Restrained = true;
				array2[j * numberOfDegreesOfFreedom + 4].FixedDispl = nodeBeam.rotationDisplacement[1];
			}
			if (nodeBeam.rotationRestraints[2])
			{
				array2[j * numberOfDegreesOfFreedom + 5].Restrained = true;
				array2[j * numberOfDegreesOfFreedom + 5].FixedDispl = nodeBeam.rotationDisplacement[2];
			}
		}
		double[] array3 = new double[order];
		double[] _0023_003Dz1v6oPQk_003D = null;
		bool flag2 = _0023_003DzMnDbz804W8yeOXxvHQ_003D_003D() == (_0023_003DzSx8c8OMfZIP3)1;
		if (flag2)
		{
			_0023_003Dz1v6oPQk_003D = new double[order];
		}
		for (int k = 0; k < femMesh.elements.Length; k++)
		{
			Element element = femMesh.elements[k];
			if (!(element is Joint2D))
			{
				for (int l = 0; l < element.TotalDof; l++)
				{
					int num = element.Connection[l / numberOfDegreesOfFreedom] * numberOfDegreesOfFreedom + l % numberOfDegreesOfFreedom;
					array3[num] += element.load[l];
				}
			}
			for (int m = 0; m < element.NumberOfNodes; m++)
			{
				int num2 = element.Connection[m] * numberOfDegreesOfFreedom;
				for (int n = 0; n < numberOfDegreesOfFreedom; n++)
				{
					int _0023_003DzL_8cHN2272me = num2 + n;
					_0023_003Dz3UmAmjo_003D(array2, _0023_003DzL_8cHN2272me, k);
				}
			}
		}
		int[] array4 = new int[order + 1];
		List<int> list = new List<int>(order);
		List<double> list2 = new List<double>(order);
		bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D = false;
		double[][] array5 = new double[_0023_003Dz8AgsGDBcXNym][];
		for (int num3 = 0; num3 < array5.GetLength(0); num3++)
		{
			array5[num3] = new double[order];
		}
		int[] array6 = null;
		List<int> list3 = null;
		List<double> list4 = null;
		int[] _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D;
		int[] _0023_003Dzq2Pn86ffSKxt;
		if (flag2)
		{
			_0023_003Dzy_00249d0y1gjqKpZr2Nmjh6Q6g_003D(order, array2, out _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D, out _0023_003Dzq2Pn86ffSKxt);
			array2 = array2.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzPTh47fVD99XJoW78hzK7vb8_003D).ToArray();
			order = array2.Length;
			array4 = new int[order + 1];
			list = new List<int>(order);
			list2 = new List<double>(order);
			array6 = new int[order + 1];
			list3 = new List<int>(order);
			list4 = new List<double>(order);
		}
		else
		{
			_0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D = Enumerable.Range(0, order).ToArray();
			_0023_003Dzq2Pn86ffSKxt = _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D;
		}
		if (flag2)
		{
			if (!_0023_003Dz3rosEHYVu7Mbm6Kr7__kgQ4_003D(order, _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D, _0023_003Dzq2Pn86ffSKxt, array4, list, list2, array3, array2, progress, ct, ref _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D))
			{
				return;
			}
		}
		else if (!_0023_003Dz3rosEHYVu7Mbm6Kr7__kgQ4_003D(order, array4, list, list2, array3, array2, progress, ct, ref _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D))
		{
			return;
		}
		double[,] _0023_003DzDtqAooE_003D = null;
		bool flag3 = flag2 && order <= 10;
		if (flag2)
		{
			if (!flag3)
			{
				if (!_0023_003DzI9M1zzoFq893(order, _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D, _0023_003Dzq2Pn86ffSKxt, array6, list3, list4, _0023_003Dz1v6oPQk_003D, array2, progress, ct, ref _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, null))
				{
					return;
				}
				array6[order] = list4.Count;
			}
			else
			{
				_0023_003DzDtqAooE_003D = new double[order, order];
				if (!_0023_003DzI9M1zzoFq893(order, _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D, _0023_003Dzq2Pn86ffSKxt, array6, list3, list4, _0023_003Dz1v6oPQk_003D, array2, progress, ct, ref _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, _0023_003DzDtqAooE_003D))
				{
					return;
				}
			}
		}
		array4[order] = list2.Count;
		if (flag2)
		{
			if (flag3)
			{
				_0023_003Dzd9z0jdc_003D(progress, ct, order, array4, list, list2, _0023_003DzDtqAooE_003D, _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, array5, _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D);
			}
			else
			{
				_0023_003DzR0KI77JNRcLa0GZA4A_003D_003D(progress, ct, order, array4, list, list2, array6, list3, list4, _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D, array5, _0023_003Dz8xtw0ZAFyIfzx5Ai0HxAwGE_003D);
			}
		}
		else
		{
			_0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2 = new _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi(array4, list, list2, array3, array5[0], _0023_003Dzv8R_0024yK5_mdUd, _0023_003DziGC_lwJxtru7);
			int _0023_003DzdcIp_Hg_003D;
			if (_0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D)
			{
				_0023_003DzyHbnlUWxN4s2hAytnQ_003D_003D = _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2._0023_003DzOykoXtw_003D(this, SolvingEquationsText, progress, ct, out _0023_003DzdcIp_Hg_003D);
			}
			else
			{
				_0023_003DzyHbnlUWxN4s2hAytnQ_003D_003D = _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi2._0023_003DzGhs2wJhjEHb8Q5ikpg_003D_003D(this, SolvingEquationsText, progress, ct, out _0023_003DzdcIp_Hg_003D);
			}
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985438) + _0023_003DzdcIp_Hg_003D);
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302985401) + _0023_003DzyHbnlUWxN4s2hAytnQ_003D_003D);
			_0023_003DznC8rNG1WdfFlSNUufA_003D_003D = _0023_003DzdcIp_Hg_003D;
		}
		if (_0023_003DzMnDbz804W8yeOXxvHQ_003D_003D() == (_0023_003DzSx8c8OMfZIP3)0)
		{
			for (int num4 = 0; num4 < order; num4++)
			{
				if (!array2[num4].Restrained)
				{
					continue;
				}
				Node node2 = (Node)femMesh._vertices[num4 / numberOfDegreesOfFreedom];
				if (node2.Reactions == null)
				{
					node2.Reactions = new double[numberOfDegreesOfFreedom];
				}
				double num5 = array2[num4].MultiplyBy(array5[0]);
				double num6 = 0.0;
				if (hasTemperature)
				{
					for (int num7 = 0; num7 < femMesh.elements.Length; num7++)
					{
						Element element2 = femMesh.elements[num7];
						for (int num8 = 0; num8 < element2.Connection.Length; num8++)
						{
							if (element2.Connection[num8] == num4 / numberOfDimensions)
							{
								num6 += element2.tLoad[num8 * femMesh.NumberOfDegreesOfFreedom + num4 % numberOfDegreesOfFreedom];
							}
						}
					}
				}
				node2.Reactions[num4 % numberOfDegreesOfFreedom] = num5 - num6;
			}
		}
		PostProcessing(progress, ct, array5, hasTemperature, firstElType);
	}

	private bool _0023_003Dz3rosEHYVu7Mbm6Kr7__kgQ4_003D(int _0023_003DzhY366QI_003D, int[] _0023_003DzmQTFaQA_003D, List<int> _0023_003DzeV5N9i0_003D, List<double> _0023_003DzE8QrneA_003D, double[] _0023_003Dz1v6oPQk_003D, Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, ref bool _0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D)
	{
		_0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D CS_0024_003C_003E8__locals67 = new _0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D();
		CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D = _0023_003DzhY366QI_003D;
		CS_0024_003C_003E8__locals67._0023_003DzXMVGBHVmumq2ImENew_003D_003D = _0023_003DzXMVGBHVmumq2ImENew_003D_003D;
		CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals67._0023_003Dz1v6oPQk_003D = _0023_003Dz1v6oPQk_003D;
		CS_0024_003C_003E8__locals67._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals67._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		CS_0024_003C_003E8__locals67._0023_003Dz8If0AEk_003D = true;
		CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D = Utility.GetCpuCount(CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D, out CS_0024_003C_003E8__locals67._0023_003DzAddCv_o_003D, out CS_0024_003C_003E8__locals67._0023_003Dz9iVQ96E_003D);
		CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D = new int[CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D];
		CS_0024_003C_003E8__locals67._0023_003DzsqRc7NtwlFbe = new bool[CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D];
		CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D = new double[CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D][];
		for (int i = 0; i < CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D; i++)
		{
			CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D[i] = new double[CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D];
		}
		CS_0024_003C_003E8__locals67._0023_003DzA84fJPE_003D = new List<int>[CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D];
		CS_0024_003C_003E8__locals67._0023_003DzUMBNENw_003D = new List<double>[CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D];
		Parallel.For(0, CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D, delegate(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			Array.Clear(CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D);
			CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] = CS_0024_003C_003E8__locals67._0023_003DzAddCv_o_003D[_0023_003Dz437_00244ak_003D];
			while (CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D] < CS_0024_003C_003E8__locals67._0023_003Dz9iVQ96E_003D[_0023_003Dz437_00244ak_003D])
			{
				int num3 = CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D];
				Array.Clear(CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], 0, CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D);
				CS_0024_003C_003E8__locals67._0023_003DzA84fJPE_003D[num3] = new List<int>();
				CS_0024_003C_003E8__locals67._0023_003DzUMBNENw_003D[num3] = new List<double>();
				CS_0024_003C_003E8__locals67._0023_003DzXMVGBHVmumq2ImENew_003D_003D[num3].Process(num3, CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs.femMesh, CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs.numberOfDegreesOfFreedom, freeMem: false);
				CS_0024_003C_003E8__locals67._0023_003DzXMVGBHVmumq2ImENew_003D_003D[num3].Compress(num3, CS_0024_003C_003E8__locals67._0023_003Dz90qRVXE_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals67._0023_003DzA84fJPE_003D[num3], CS_0024_003C_003E8__locals67._0023_003DzUMBNENw_003D[num3], CS_0024_003C_003E8__locals67._0023_003DzXMVGBHVmumq2ImENew_003D_003D, CS_0024_003C_003E8__locals67._0023_003Dz1v6oPQk_003D, ref CS_0024_003C_003E8__locals67._0023_003DzsqRc7NtwlFbe[_0023_003Dz437_00244ak_003D]);
				int progress = Utility.GetProgress(CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D, CS_0024_003C_003E8__locals67._0023_003DzAddCv_o_003D, CS_0024_003C_003E8__locals67._0023_003DzgWCiBuA_003D);
				CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs.UpdateProgress(progress, CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D, CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs.SolvingPopulatingStiffnessText, CS_0024_003C_003E8__locals67._0023_003DzmHS7frs_003D);
				if (CS_0024_003C_003E8__locals67._0023_003DzopRx0_MBcTQs.Cancelled(CS_0024_003C_003E8__locals67._0023_003Dzjvn7P10_003D))
				{
					CS_0024_003C_003E8__locals67._0023_003Dz8If0AEk_003D = false;
					_0023_003DzLdZiL78_003D.Stop();
				}
				CS_0024_003C_003E8__locals67._0023_003DzyzK8swU_003D[_0023_003Dz437_00244ak_003D]++;
			}
		});
		if (CS_0024_003C_003E8__locals67._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(SolvingPopulatingStiffnessText, CS_0024_003C_003E8__locals67._0023_003DzmHS7frs_003D);
			if (CS_0024_003C_003E8__locals67._0023_003DzsqRc7NtwlFbe.Any(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzmIQYnm01LDKhEwBZp_0B8XdMe7vNHERFbw_003D_003D))
			{
				_0023_003Dz4QW7LSR2gH4N9qKFtQ_003D_003D = true;
			}
			for (int num = 0; num < CS_0024_003C_003E8__locals67._0023_003DzhY366QI_003D; num++)
			{
				int count = _0023_003DzE8QrneA_003D.Count;
				_0023_003DzmQTFaQA_003D[num] = count;
				_0023_003DzE8QrneA_003D.AddRange(CS_0024_003C_003E8__locals67._0023_003DzUMBNENw_003D[num]);
				_0023_003DzeV5N9i0_003D.AddRange(CS_0024_003C_003E8__locals67._0023_003DzA84fJPE_003D[num]);
			}
		}
		if (CS_0024_003C_003E8__locals67._0023_003Dz8If0AEk_003D)
		{
			UpdateProgressTo100(SolvingPopulatingStiffnessText, CS_0024_003C_003E8__locals67._0023_003DzmHS7frs_003D);
			Element[] elements = femMesh.Elements;
			for (int num2 = 0; num2 < elements.Length; num2++)
			{
				elements[num2]._0023_003Dzxlnq6Q__3EAt();
			}
		}
		return CS_0024_003C_003E8__locals67._0023_003Dz8If0AEk_003D;
	}

	private void _0023_003Dz3UmAmjo_003D(Equation[] _0023_003DzXMVGBHVmumq2ImENew_003D_003D, int _0023_003DzL_8cHN2272me, int _0023_003DzTSeNR8Q_003D)
	{
		_0023_003DzXMVGBHVmumq2ImENew_003D_003D[_0023_003DzL_8cHN2272me].elements.AddLast(_0023_003DzTSeNR8Q_003D);
	}
}
