using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

internal static class _0023_003DzXrsqhReO_0024chgdgM4_kWuTbEOgsEckzyUyB_5MEd60DAM6UuNl73QtA0_003D
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<string, bool> _0023_003DzzXfVjLO8QehtBZRX_0024A_003D_003D;

		public static Func<string, bool> _0023_003DzMZhMJpobUKPB_0024vgkIg_003D_003D;

		public static Func<string, bool> _0023_003Dzn4WoGQzxG5TqtWY9sA_003D_003D;

		public static Func<string, bool> _0023_003Dz1_0024Aj5hrJaAa4ofcrCw_003D_003D;

		public static Func<string, bool> _0023_003Dz8mWNjyVhUk2mhvFl3g_003D_003D;

		public static Func<string, bool> _0023_003Dzb1k3XlgLXpaOl9ZXog_003D_003D;

		public static Func<string, bool> _0023_003DzoAoPnkdvef9hk7unLQ_003D_003D;

		internal bool _0023_003DzU357PyMHvIEpWRgoDg_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzXqRERD0TAy6vv2T45w_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzbjPVODUoR0Zsor8GGA_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzYp92oJhFIWUY4qBwAg_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003Dz_0024UPQ2xZ0wnDVvYhVWQ_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DzVP00EbngJA1MsBgY7g_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}

		internal bool _0023_003DztDqy74CE_sizOeNEIg_003D_003D(string _0023_003DzBJFJHwk_003D)
		{
			return !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D);
		}
	}

	public static int _0023_003DzuuY9lIM_003D(StreamReader _0023_003DzX1gmNL5wFvK5, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003Dz61IPlm0_003D)
	{
		int num = 0;
		int num2 = 0;
		double item = 0.0;
		_0023_003Dz61IPlm0_003D._0023_003DzttBXI_0024c_003D();
		List<double> list = new List<double>();
		if (_0023_003DzX1gmNL5wFvK5 != null)
		{
			string text;
			while ((text = _0023_003DzX1gmNL5wFvK5.ReadLine()) != null)
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					string[] array = Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728));
					num2 = Convert.ToInt32(array[0]);
					if (array[1] == string.Empty)
					{
						num = 0;
					}
					if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
					{
						break;
					}
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
		if (list.Count != num * num2)
		{
			return -1;
		}
		return 0;
	}

	public static int _0023_003DzuuY9lIM_003D(StreamReader _0023_003DzX1gmNL5wFvK5, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003Dz61IPlm0_003D)
	{
		int num = 0;
		int num2 = 0;
		uint item = 0u;
		_0023_003Dz61IPlm0_003D._0023_003DzttBXI_0024c_003D();
		List<uint> list = new List<uint>();
		if (_0023_003DzX1gmNL5wFvK5 != null)
		{
			string text;
			while ((text = _0023_003DzX1gmNL5wFvK5.ReadLine()) != null)
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					string[] array = Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728));
					num2 = Convert.ToInt32(array[0]);
					if (array[1] == string.Empty)
					{
						num = 0;
					}
					if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
					{
						break;
					}
				}
				else
				{
					string[] array2 = text.Split('\r', ' ').Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzXqRERD0TAy6vv2T45w_003D_003D).ToArray();
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
		if (list.Count != num * num2)
		{
			return -1;
		}
		return 0;
	}

	public static int _0023_003DzuuY9lIM_003D(StreamReader _0023_003DzX1gmNL5wFvK5, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003Dz61IPlm0_003D, string _0023_003DzeWllF6o_003D)
	{
		int num = 0;
		double num2 = 0.0;
		_0023_003Dz61IPlm0_003D._0023_003DzttBXI_0024c_003D();
		List<double> list = new List<double>();
		if (_0023_003DzX1gmNL5wFvK5 != null)
		{
			string text;
			while ((text = _0023_003DzX1gmNL5wFvK5.ReadLine()) != null)
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					num = Convert.ToInt32(Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728))[0]);
				}
				char[] separator = new char[2] { '\r', ' ' };
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					text = text.Split('[')[1];
				}
				string[] array;
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
				{
					array = text.Split('\r', ' ', ']');
					new List<string>(array);
					array.ToList().Remove(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
					array = array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzbjPVODUoR0Zsor8GGA_003D_003D).ToArray();
				}
				else
				{
					array = text.Split(separator);
					array = array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzYp92oJhFIWUY4qBwAg_003D_003D).ToArray();
				}
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
					if (converter.CanConvertFrom(text2.GetType()))
					{
						num2 = (double)converter.ConvertFrom(text2);
						list.Add(num2);
					}
					else
					{
						int num3 = Convert.ToInt32(text2);
						list.Add(num3);
					}
				}
				if (list.Count == num)
				{
					break;
				}
			}
			foreach (double item in list)
			{
				_0023_003Dz61IPlm0_003D._0023_003DzccHNBKidQXxY(item);
			}
		}
		return 0;
	}

	public static int _0023_003DzuuY9lIM_003D(StreamReader _0023_003DzX1gmNL5wFvK5, _0023_003DzjzsJu51FzmelLIXl8K_TyMA7iiqxIk_0024S0HhkZyk_003D _0023_003Dz61IPlm0_003D, string _0023_003DzeWllF6o_003D)
	{
		int num = 0;
		int num2 = 0;
		_0023_003Dz61IPlm0_003D._0023_003DzttBXI_0024c_003D();
		List<int> list = new List<int>();
		if (_0023_003DzX1gmNL5wFvK5 != null)
		{
			string text;
			while ((text = _0023_003DzX1gmNL5wFvK5.ReadLine()) != null)
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					num = Convert.ToInt32(Regex.Split(text, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667728))[0]);
				}
				char[] separator = new char[2] { '\r', ' ' };
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195)))
				{
					text = text.Split('[')[1];
				}
				string[] array;
				if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377)))
				{
					array = text.Split('\r', ' ', ']');
					new List<string>(array);
					array.ToList().Remove(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
					array = array.Where((string _0023_003DzBJFJHwk_003D) => !string.IsNullOrEmpty(_0023_003DzBJFJHwk_003D)).ToArray();
				}
				else
				{
					array = text.Split(separator);
					array = array.Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzVP00EbngJA1MsBgY7g_003D_003D).ToArray();
				}
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					if (converter.CanConvertFrom(text2.GetType()))
					{
						num2 = (int)converter.ConvertFrom(text2);
						list.Add(num2);
					}
					else
					{
						int item = Convert.ToInt32(text2);
						list.Add(item);
					}
				}
				if (list.Count == num)
				{
					break;
				}
			}
			foreach (int item2 in list)
			{
				_0023_003Dz61IPlm0_003D._0023_003DzccHNBKidQXxY(item2);
			}
		}
		return 0;
	}

	public static int _0023_003DzuuY9lIM_003D(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzW6BC8eo_003D, StreamReader _0023_003DzX1gmNL5wFvK5)
	{
		uint num = 0u;
		uint _0023_003DzELu0Pss_003D = 0u;
		uint num2 = 0u;
		_0023_003DzW6BC8eo_003D._0023_003DzttBXI_0024c_003D();
		if (_0023_003DzX1gmNL5wFvK5 != null)
		{
			string text;
			while ((text = _0023_003DzX1gmNL5wFvK5.ReadLine()) != null)
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
					num2 = Convert.ToUInt32(array[0]) * Convert.ToUInt32(array[1]);
				}
				else
				{
					string[] array2 = text.Split('\r', ' ').Where(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DztDqy74CE_sizOeNEIg_003D_003D).ToArray();
					foreach (string text2 in array2)
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(uint));
						if (converter.CanConvertFrom(text2.GetType()))
						{
							_0023_003DzELu0Pss_003D = (uint)converter.ConvertFrom(text2);
						}
						_0023_003DzW6BC8eo_003D._0023_003DzSZ0NwQM_003D(num, _0023_003DzELu0Pss_003D);
						num++;
					}
				}
				if (_0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D() == num2)
				{
					break;
				}
			}
			if (_0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D() == num2)
			{
				return 0;
			}
		}
		return -1;
	}

	public static void _0023_003Dzh7uemm0_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzW6BC8eo_003D, string _0023_003DzZ2xafH7Y4O40, uint _0023_003DzoMNiNRw_003D)
	{
		uint num = _0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D();
		uint num2 = _0023_003DzW6BC8eo_003D._0023_003DzIBRMQdw_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		if (_0023_003DzZ2xafH7Y4O40 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667761))
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num3 = 0u; num3 < _0023_003DzoMNiNRw_003D; num3++)
				{
					uint num4 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num4.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				uint num5 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num5.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		else
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num6 = 0u; num6 < _0023_003DzoMNiNRw_003D; num6++)
				{
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667669));
	}

	public static void _0023_003Dzh7uemm0_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003DzjzsJu51FzmelLIXl8K_TyMA7iiqxIk_0024S0HhkZyk_003D _0023_003DzW6BC8eo_003D, string _0023_003DzZ2xafH7Y4O40, uint _0023_003DzoMNiNRw_003D)
	{
		uint num = _0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D();
		uint num2 = _0023_003DzW6BC8eo_003D._0023_003DzIBRMQdw_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		if (_0023_003DzZ2xafH7Y4O40 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667761))
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num3 = 0u; num3 < _0023_003DzoMNiNRw_003D; num3++)
				{
					int num4 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num4.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				int num5 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num5.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		else
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num6 = 0u; num6 < _0023_003DzoMNiNRw_003D; num6++)
				{
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667669));
	}

	public static void _0023_003Dzh7uemm0_003D(StreamWriter _0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D, _0023_003DzXCoxfl7OPP_B0f59ACYgCyfwrTWiPHxsLw_003D_003D _0023_003DzW6BC8eo_003D, string _0023_003DzZ2xafH7Y4O40, uint _0023_003DzoMNiNRw_003D)
	{
		uint num = _0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D();
		uint num2 = _0023_003DzW6BC8eo_003D._0023_003DzIBRMQdw_003D();
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		if (_0023_003DzZ2xafH7Y4O40 == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667761))
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num3 = 0u; num3 < _0023_003DzoMNiNRw_003D; num3++)
				{
					double num4 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num4.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				double num5 = _0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2);
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), num5.ToString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667706))) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		else
		{
			while (num >= _0023_003DzoMNiNRw_003D)
			{
				num -= _0023_003DzoMNiNRw_003D;
				for (uint num6 = 0u; num6 < _0023_003DzoMNiNRw_003D; num6++)
				{
					_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
					num2++;
				}
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302915165));
			}
			while (num-- != 0)
			{
				_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
		}
		_0023_003DzFPjwCkYq_Ind0qmZ_g_003D_003D.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302667669));
	}

	public static void _0023_003Dzh7uemm0_003D(_0023_003Dz3GjzoP0yRzXuryLde64bDE8ETLkdYg_0024_8zq_0024JZI_003D _0023_003DzW6BC8eo_003D, uint _0023_003DzoMNiNRw_003D)
	{
		uint num = _0023_003DzW6BC8eo_003D._0023_003Dz14lzA48_003D();
		uint num2 = _0023_003DzW6BC8eo_003D._0023_003DzIBRMQdw_003D();
		Console.Write(num + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004195));
		while (num >= _0023_003DzoMNiNRw_003D)
		{
			num -= _0023_003DzoMNiNRw_003D;
			for (uint num3 = 0u; num3 < _0023_003DzoMNiNRw_003D; num3++)
			{
				Console.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
				num2++;
			}
			Console.WriteLine();
		}
		while (num-- != 0)
		{
			Console.Write(_0023_003DzW6BC8eo_003D._0023_003DzYBaDcXE_003D(num2) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382));
			num2++;
		}
		Console.WriteLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011377));
	}
}
