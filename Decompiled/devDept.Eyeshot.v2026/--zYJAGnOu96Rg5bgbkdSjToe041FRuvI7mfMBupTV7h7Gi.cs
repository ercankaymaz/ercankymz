using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using devDept;
using devDept.Geometry;

internal sealed class _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi
{
	private sealed class _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D
	{
		public double[][] _0023_003DzEtfQXlQ_003D;

		public int[] _0023_003DzJY3u_0024zfLZR6b;

		public int _0023_003DzhY366QI_003D;

		public int[] _0023_003DzsYdWi8orojUl;

		public double[] _0023_003DzXrexKjY_003D;

		public List<double> _0023_003DzE8QrneA_003D;

		public List<int> _0023_003DzeV5N9i0_003D;

		public int[] _0023_003DzmQTFaQA_003D;

		internal void _0023_003Dzsj4zk79M08rAMQA9bw_003D_003D(int _0023_003Dz437_00244ak_003D)
		{
			Array.Clear(_0023_003DzEtfQXlQ_003D[_0023_003Dz437_00244ak_003D], _0023_003DzJY3u_0024zfLZR6b[_0023_003Dz437_00244ak_003D], _0023_003DzhY366QI_003D - _0023_003DzJY3u_0024zfLZR6b[_0023_003Dz437_00244ak_003D]);
			_0023_003DzIN9Qf_TTj08u(_0023_003DzJY3u_0024zfLZR6b[_0023_003Dz437_00244ak_003D], _0023_003DzsYdWi8orojUl[_0023_003Dz437_00244ak_003D], _0023_003DzXrexKjY_003D, _0023_003DzE8QrneA_003D, _0023_003DzeV5N9i0_003D, _0023_003DzmQTFaQA_003D, _0023_003DzEtfQXlQ_003D[_0023_003Dz437_00244ak_003D]);
		}
	}

	private double _0023_003DzyBEVPDRib1xZ = Utility._0023_003DzxhnLabVjXjPg;

	private int[] _0023_003DzmQTFaQA_003D;

	private List<int> _0023_003DzeV5N9i0_003D;

	private List<double> _0023_003DzE8QrneA_003D;

	private double[] _0023_003Dz1v6oPQk_003D;

	private double[] _0023_003DzBJFJHwk_003D;

	private int _0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D;

	internal bool _0023_003DzqcfH4idvU5LE;

	public _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi()
	{
	}

	public _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi(int[] _0023_003DzUwUkqtI_003D, List<int> _0023_003DzNvr1RNQ_003D, List<double> _0023_003DzwTCTGKg_003D, double[] _0023_003DzlP92nO4_003D, double[] _0023_003DzSbaQfts_003D, double _0023_003DzezTples_003D, int _0023_003DzcYxYLpypbh1h)
	{
		_0023_003DzmQTFaQA_003D = _0023_003DzUwUkqtI_003D;
		_0023_003DzeV5N9i0_003D = _0023_003DzNvr1RNQ_003D;
		_0023_003DzE8QrneA_003D = _0023_003DzwTCTGKg_003D;
		_0023_003Dz1v6oPQk_003D = _0023_003DzlP92nO4_003D;
		_0023_003DzBJFJHwk_003D = _0023_003DzSbaQfts_003D;
		_0023_003DzyBEVPDRib1xZ = _0023_003DzezTples_003D;
		_0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D = _0023_003DzcYxYLpypbh1h;
	}

	public _0023_003DzYJAGnOu96Rg5bgbkdSjToe041FRuvI7mfMBupTV7h7Gi(double _0023_003DzezTples_003D)
	{
		_0023_003DzyBEVPDRib1xZ = _0023_003DzezTples_003D;
	}

	public bool _0023_003DzOykoXtw_003D(WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, out int _0023_003DzdcIp_Hg_003D)
	{
		double num = 0.0;
		int num2 = _0023_003DzmQTFaQA_003D.Length - 1;
		int[] startIndex;
		int[] endIndex;
		int cpuCount = Utility.GetCpuCount(num2, out startIndex, out endIndex);
		double[][] array = new double[cpuCount][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new double[num2];
		}
		double[] array2 = new double[num2];
		double[] array3 = new double[num2];
		double[] array4 = new double[num2];
		int num3 = (_0023_003DzdcIp_Hg_003D = 0);
		_0023_003Dz1v6oPQk_003D.CopyTo(array2, 0);
		array2.CopyTo(array3, 0);
		double num4 = _0023_003Dz71n58RgE0a02(array2, array2);
		double num5 = num4;
		while (num3 < _0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D && num4 > _0023_003DzyBEVPDRib1xZ * _0023_003DzyBEVPDRib1xZ * num5)
		{
			array4 = _0023_003DzT6_002425rA_003D(num2, array3, _0023_003DzE8QrneA_003D, _0023_003DzeV5N9i0_003D, _0023_003DzmQTFaQA_003D, cpuCount, startIndex, endIndex, array);
			double num6 = num4 / _0023_003Dz71n58RgE0a02(array3, array4);
			double num7 = num4;
			for (int j = 0; j < num2; j++)
			{
				_0023_003DzBJFJHwk_003D[j] += num6 * array3[j];
				array2[j] -= num6 * array4[j];
			}
			num4 = _0023_003Dz71n58RgE0a02(array2, array2);
			double num8 = num4 / num7;
			for (int k = 0; k < num2; k++)
			{
				array3[k] = array2[k] + num8 * array3[k];
			}
			num3++;
			double num9 = num5 - num4;
			if (_0023_003DzqcfH4idvU5LE && num9 > num)
			{
				_0023_003Dz_IUshyU_003D.UpdateProgress(num9, num5 - _0023_003DzyBEVPDRib1xZ * _0023_003DzyBEVPDRib1xZ * num5, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D);
				num = num9;
			}
			if (_0023_003Dz_IUshyU_003D.Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return false;
			}
		}
		_0023_003DzdcIp_Hg_003D = num3;
		if (_0023_003DzdcIp_Hg_003D == _0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D)
		{
			return false;
		}
		return true;
	}

	public bool _0023_003DzGhs2wJhjEHb8Q5ikpg_003D_003D(WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, out int _0023_003DzdcIp_Hg_003D)
	{
		double num = 0.0;
		int num2 = _0023_003DzmQTFaQA_003D.Length - 1;
		int[] startIndex;
		int[] endIndex;
		int cpuCount = Utility.GetCpuCount(num2, out startIndex, out endIndex);
		double[][] array = new double[cpuCount][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new double[num2];
		}
		double[] array2 = new double[num2];
		double[] array3 = new double[num2];
		double[] array4 = new double[num2];
		double[] array5 = new double[num2];
		double[] array6 = new double[num2];
		for (int j = 0; j < num2; j++)
		{
			double num3 = _0023_003DzE8QrneA_003D[_0023_003DzmQTFaQA_003D[j]];
			if (num3 == 0.0)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984310));
			}
			array6[j] = 1.0 / num3;
		}
		int num4 = (_0023_003DzdcIp_Hg_003D = 0);
		_0023_003Dz1v6oPQk_003D.CopyTo(array2, 0);
		for (int k = 0; k < num2; k++)
		{
			array3[k] = array6[k] * array2[k];
		}
		double num5 = _0023_003Dz71n58RgE0a02(array2, array3);
		double num6 = num5;
		while (num4 < _0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D && num5 > _0023_003DzyBEVPDRib1xZ * _0023_003DzyBEVPDRib1xZ * num6)
		{
			array4 = _0023_003DzT6_002425rA_003D(num2, array3, _0023_003DzE8QrneA_003D, _0023_003DzeV5N9i0_003D, _0023_003DzmQTFaQA_003D, cpuCount, startIndex, endIndex, array);
			double num7 = num5 / _0023_003Dz71n58RgE0a02(array3, array4);
			double num8 = num5;
			for (int l = 0; l < num2; l++)
			{
				_0023_003DzBJFJHwk_003D[l] += num7 * array3[l];
				array2[l] -= num7 * array4[l];
				array5[l] = array6[l] * array2[l];
			}
			num5 = _0023_003Dz71n58RgE0a02(array2, array5);
			double num9 = num5 / num8;
			for (int m = 0; m < num2; m++)
			{
				array3[m] = array5[m] + num9 * array3[m];
			}
			num4++;
			double num10 = num6 - num5;
			if (_0023_003DzqcfH4idvU5LE && num10 > num)
			{
				_0023_003Dz_IUshyU_003D.UpdateProgress(num10, num6 - _0023_003DzyBEVPDRib1xZ * _0023_003DzyBEVPDRib1xZ * num6, _0023_003DzZTLfq0HwLoIIGJqSAnopwacT_0024_4L, _0023_003DzmHS7frs_003D);
				num = num10;
			}
			if (_0023_003Dz_IUshyU_003D.Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return false;
			}
		}
		_0023_003DzdcIp_Hg_003D = num4;
		if (_0023_003DzdcIp_Hg_003D == _0023_003DzCCqkSOO0dVeI1DjHVw_003D_003D)
		{
			return false;
		}
		return true;
	}

	private static double _0023_003Dz71n58RgE0a02(double[] _0023_003DzRVoDPs0_003D, double[] _0023_003Dz_0024ozI2Ww_003D)
	{
		double num = 0.0;
		int num2 = _0023_003DzRVoDPs0_003D.Length;
		for (int i = 0; i < num2; i++)
		{
			num += _0023_003DzRVoDPs0_003D[i] * _0023_003Dz_0024ozI2Ww_003D[i];
		}
		return num;
	}

	public static double[] _0023_003DzT6_002425rA_003D(int _0023_003DzhY366QI_003D, double[] _0023_003DzXrexKjY_003D, List<double> _0023_003DzE8QrneA_003D, List<int> _0023_003DzeV5N9i0_003D, int[] _0023_003DzmQTFaQA_003D, int _0023_003DzgWCiBuA_003D, int[] _0023_003DzJY3u_0024zfLZR6b, int[] _0023_003DzsYdWi8orojUl, double[][] _0023_003DzEtfQXlQ_003D)
	{
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2 = new _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D();
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzEtfQXlQ_003D = _0023_003DzEtfQXlQ_003D;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzJY3u_0024zfLZR6b = _0023_003DzJY3u_0024zfLZR6b;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzhY366QI_003D = _0023_003DzhY366QI_003D;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzsYdWi8orojUl = _0023_003DzsYdWi8orojUl;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzXrexKjY_003D = _0023_003DzXrexKjY_003D;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzE8QrneA_003D = _0023_003DzE8QrneA_003D;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzeV5N9i0_003D = _0023_003DzeV5N9i0_003D;
		_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzmQTFaQA_003D = _0023_003DzmQTFaQA_003D;
		Parallel.For(0, _0023_003DzgWCiBuA_003D, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003Dzsj4zk79M08rAMQA9bw_003D_003D);
		double[] array = new double[_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzhY366QI_003D];
		double[] _0023_003Dzt_m8zV0_003D = new double[_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzhY366QI_003D];
		_0023_003DzmjVbKj4VTP0d(_0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzEtfQXlQ_003D, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzJY3u_0024zfLZR6b, _0023_003Dzs3fHJXzt17zCtNvVhZof6xw_003D2._0023_003DzhY366QI_003D, _0023_003DzgWCiBuA_003D, array, _0023_003Dzt_m8zV0_003D);
		return array;
	}

	private static void _0023_003DzmjVbKj4VTP0d(double[][] _0023_003Dz0EsKsC8_003D, int[] _0023_003DzJY3u_0024zfLZR6b, int _0023_003DzhY366QI_003D, int _0023_003DzgWCiBuA_003D, double[] _0023_003DzH1SwwS4_003D, double[] _0023_003Dzt_m8zV0_003D)
	{
		for (int i = 0; i < _0023_003DzgWCiBuA_003D; i++)
		{
			for (int j = _0023_003DzJY3u_0024zfLZR6b[i]; j < _0023_003DzhY366QI_003D; j++)
			{
				double num = _0023_003Dz0EsKsC8_003D[i][j] - _0023_003Dzt_m8zV0_003D[j];
				double num2 = _0023_003DzH1SwwS4_003D[j] + num;
				_0023_003Dzt_m8zV0_003D[j] = num2 - _0023_003DzH1SwwS4_003D[j] - num;
				_0023_003DzH1SwwS4_003D[j] = num2;
			}
		}
	}

	private static void _0023_003DzIN9Qf_TTj08u(int _0023_003DzAddCv_o_003D, int _0023_003Dz9iVQ96E_003D, double[] _0023_003DzXrexKjY_003D, List<double> _0023_003DzE8QrneA_003D, List<int> _0023_003DzeV5N9i0_003D, int[] _0023_003DzmQTFaQA_003D, double[] _0023_003DzO_0024iiQ4U_003D)
	{
		for (int i = _0023_003DzAddCv_o_003D; i < _0023_003Dz9iVQ96E_003D; i++)
		{
			int num = _0023_003DzmQTFaQA_003D[i];
			_0023_003DzO_0024iiQ4U_003D[i] += _0023_003DzE8QrneA_003D[num] * _0023_003DzXrexKjY_003D[_0023_003DzeV5N9i0_003D[num]];
			for (int j = num + 1; j < _0023_003DzmQTFaQA_003D[i + 1]; j++)
			{
				int num2 = _0023_003DzeV5N9i0_003D[j];
				double num3 = _0023_003DzE8QrneA_003D[j];
				_0023_003DzO_0024iiQ4U_003D[i] += num3 * _0023_003DzXrexKjY_003D[num2];
				_0023_003DzO_0024iiQ4U_003D[num2] += num3 * _0023_003DzXrexKjY_003D[i];
			}
		}
	}
}
