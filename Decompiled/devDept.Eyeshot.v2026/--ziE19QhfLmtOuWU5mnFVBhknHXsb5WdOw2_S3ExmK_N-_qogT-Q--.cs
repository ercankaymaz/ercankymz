using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

internal static class _0023_003DziE19QhfLmtOuWU5mnFVBhknHXsb5WdOw2_S3ExmK_N_0024_qogT_0024Q_003D_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<string, bool> _0023_003DzzXfVjLO8QehtBZRX_0024A_003D_003D;

		public static Func<string, bool> _0023_003DzMZhMJpobUKPB_0024vgkIg_003D_003D;

		public static Func<string, bool> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		internal bool _0023_003DzU357PyMHvIEpWRgoDg_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzxhMitywRYYB4dwX4tztF60TyZosCvQ6tmQ_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzKmXlFU4B_UJA3BVj3nF6lGh0fupo9667Tg_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}
	}

	public static int _0023_003DzuuY9lIM_003D(StreamReader _0023_003DzobRoKyGqWXPE, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzDtqAooE_003D)
	{
		int num = 0;
		int num2 = 0;
		double item = 0.0;
		_0023_003DzDtqAooE_003D._0023_003DzttBXI_0024c_003D();
		List<double> list = new List<double>();
		if (_0023_003DzobRoKyGqWXPE != null)
		{
			string text;
			while ((text = _0023_003DzobRoKyGqWXPE.ReadLine()) != null)
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
				{
					text = text.Trim(']');
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					string[] array = Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728));
					num = Convert.ToInt32(array[0]);
					num2 = Convert.ToInt32(array[1]);
				}
				else
				{
					string[] array2 = text.Split('\r', ' ').Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzU357PyMHvIEpWRgoDg_003D_003D).ToArray();
					foreach (string text2 in array2)
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
						if (converter.CanConvertFrom(text2.GetType()))
						{
							item = (double)converter.ConvertFrom(text2);
						}
						list.Add(item);
					}
				}
				if (list.Count == num * num2)
				{
					break;
				}
			}
		}
		if (!_0023_003DzDtqAooE_003D._0023_003DzroU3nqY_003D(Convert.ToUInt32(num), Convert.ToUInt32(num2)))
		{
			return -199;
		}
		for (uint num3 = 0u; num3 < num; num3++)
		{
			for (uint num4 = 0u; num4 < num2; num4++)
			{
				_0023_003DzDtqAooE_003D._0023_003DzQmya_mnFMQ1t(num3, num4, list[Convert.ToInt32(num3 + num4)]);
			}
		}
		if (list.Count != num * num2)
		{
			return -1;
		}
		return 0;
	}

	public static int _0023_003DzfCQaBoCGmdnIKGVfXsLN2WI_003D(StreamReader _0023_003DzobRoKyGqWXPE, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzDtqAooE_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		double item = 0.0;
		_0023_003DzDtqAooE_003D._0023_003DzttBXI_0024c_003D();
		List<double> list = new List<double>();
		if (_0023_003DzobRoKyGqWXPE != null)
		{
			string text;
			while ((text = _0023_003DzobRoKyGqWXPE.ReadLine()) != null)
			{
				if (text == string.Empty || Regex.IsMatch(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668717)))
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
				{
					text = text.Trim(']');
					if (text == string.Empty || Regex.IsMatch(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668717)))
					{
						continue;
					}
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					string[] array = Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728));
					num = Convert.ToInt32(array[0]);
					num2 = Convert.ToInt32(array[1]);
				}
				else
				{
					string[] array2 = text.Split('\r', ' ', '\t').Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzxhMitywRYYB4dwX4tztF60TyZosCvQ6tmQ_003D_003D).ToArray();
					foreach (string text2 in array2)
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
						if (converter.CanConvertFrom(text2.GetType()))
						{
							item = (double)converter.ConvertFrom(text2);
						}
						list.Add(item);
					}
				}
				if (list.Count == num * num2)
				{
					break;
				}
			}
		}
		if (!_0023_003DzDtqAooE_003D._0023_003DzroU3nqY_003D(Convert.ToUInt32(num2), Convert.ToUInt32(num)))
		{
			return -199;
		}
		for (uint num4 = 0u; num4 < num; num4++)
		{
			for (uint num5 = 0u; num5 < num2; num5++)
			{
				_0023_003DzDtqAooE_003D._0023_003DzQmya_mnFMQ1t(num5, num4, list[num3]);
				num3++;
			}
		}
		if (list.Count != num * num2)
		{
			return -1;
		}
		return 0;
	}

	public static int _0023_003DzfCQaBoCGmdnIKGVfXsLN2WI_003D(StreamReader _0023_003DzobRoKyGqWXPE, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzDtqAooE_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		uint item = 0u;
		_0023_003DzDtqAooE_003D._0023_003DzttBXI_0024c_003D();
		List<uint> list = new List<uint>();
		if (_0023_003DzobRoKyGqWXPE != null)
		{
			string text;
			while ((text = _0023_003DzobRoKyGqWXPE.ReadLine()) != null)
			{
				if (text == string.Empty || Regex.IsMatch(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668717)))
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
				{
					text = text.Trim(']');
					if (text == string.Empty || Regex.IsMatch(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668717)))
					{
						continue;
					}
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					string[] array = Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728));
					num = Convert.ToInt32(array[0]);
					num2 = Convert.ToInt32(array[1]);
				}
				else
				{
					string[] array2 = text.Split('\r', ' ', '\t').Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzKmXlFU4B_UJA3BVj3nF6lGh0fupo9667Tg_003D_003D).ToArray();
					foreach (string text2 in array2)
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(uint));
						if (converter.CanConvertFrom(text2.GetType()))
						{
							item = (uint)converter.ConvertFrom(text2);
						}
						list.Add(item);
					}
				}
				if (list.Count == num * num2)
				{
					break;
				}
			}
		}
		if (!_0023_003DzDtqAooE_003D._0023_003DzroU3nqY_003D(Convert.ToUInt32(num2), Convert.ToUInt32(num)))
		{
			return -199;
		}
		for (uint num4 = 0u; num4 < num; num4++)
		{
			for (uint num5 = 0u; num5 < num2; num5++)
			{
				_0023_003DzDtqAooE_003D._0023_003DzQmya_mnFMQ1t(num5, num4, list[num3]);
				num3++;
			}
		}
		if (list.Count != num * num2)
		{
			return -1;
		}
		return 0;
	}

	public static void _0023_003Dzh7uemm0_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzDtqAooE_003D)
	{
		uint num = _0023_003DzDtqAooE_003D._0023_003DzO_0024xvpvo_003D();
		uint num2 = _0023_003DzDtqAooE_003D._0023_003DzO_0024xvpvo_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302935446) + num2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		for (uint num3 = 0u; num3 < num; num3++)
		{
			_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			for (uint num4 = 0u; num4 < num2; num4++)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzDtqAooE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num3, num4) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668698));
	}

	public static void _0023_003DzKrk7EoXYSbH3zUCTqRsYxic_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003Dz4rzdYKa1XuIx_Imdw_WlPSpzrHlvzPor3A_003D_003D _0023_003DzDtqAooE_003D, string _0023_003DzZ2xafH7Y4O40)
	{
		uint num = _0023_003DzDtqAooE_003D._0023_003DzO_0024xvpvo_003D();
		uint num2 = _0023_003DzDtqAooE_003D._0023_003DzmVsXTy4_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668673) + num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		if (_0023_003DzZ2xafH7Y4O40 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011411))
		{
			for (uint num3 = 0u; num3 < num2; num3++)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668683));
				for (uint num4 = 0u; num4 < num; num4++)
				{
					double num5 = _0023_003DzDtqAooE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num4, num3);
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num5.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382)));
				}
			}
		}
		else
		{
			for (uint num6 = 0u; num6 < num2; num6++)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668683));
				for (uint num7 = 0u; num7 < num; num7++)
				{
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzDtqAooE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num7, num6) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				}
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668698));
	}

	public static void _0023_003DzKrk7EoXYSbH3zUCTqRsYxic_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003DzflOFEhjyfgUAHLUM9yF1zxIDb5aaQRJ4MLHrF64_003D _0023_003DzDtqAooE_003D, string _0023_003DzZ2xafH7Y4O40)
	{
		uint num = _0023_003DzDtqAooE_003D._0023_003DzO_0024xvpvo_003D();
		uint num2 = _0023_003DzDtqAooE_003D._0023_003DzmVsXTy4_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668673) + num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		if (_0023_003DzZ2xafH7Y4O40 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011411))
		{
			for (uint num3 = 0u; num3 < num2; num3++)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668683));
				for (uint num4 = 0u; num4 < num; num4++)
				{
					uint num5 = _0023_003DzDtqAooE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num4, num3);
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num5.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382)));
				}
			}
		}
		else
		{
			for (uint num6 = 0u; num6 < num2; num6++)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668683));
				for (uint num7 = 0u; num7 < num; num7++)
				{
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzDtqAooE_003D._0023_003Dz7_0024mrUE1_JLUdoHA1gg_003D_003D(num7, num6) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				}
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302668698));
	}
}
