using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadNastran : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Material _0023_003DzmoTRnVwdvz1s = Material.StructuralSteel;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Color[] _0023_003Dz5hMtsIJK5NGw = new Color[8]
	{
		Color.FromArgb(102, 194, 165),
		Color.FromArgb(252, 141, 98),
		Color.FromArgb(141, 160, 203),
		Color.FromArgb(231, 138, 195),
		Color.FromArgb(166, 216, 84),
		Color.FromArgb(255, 217, 47),
		Color.FromArgb(229, 196, 148),
		Color.FromArgb(179, 179, 179)
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz9iUNZVmTuZui;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public ReadNastran(string filePath, int constraintSetId = 0, int loadSetId = 0)
		: base(filePath)
	{
		_0023_003Dz9iUNZVmTuZui = loadSetId;
		_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D = constraintSetId;
	}

	public ReadNastran(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 4;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzUt33S20kRwKfPvmDnQ_003D_003D(progress, ct);
	}

	private void _0023_003DzUt33S20kRwKfPvmDnQ_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
			int num = 0;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int num2 = 0;
			List<Point3D> list = new List<Point3D>();
			Dictionary<int, List<Element>> dictionary2 = new Dictionary<int, List<Element>>();
			Dictionary<int, int> dictionary3 = new Dictionary<int, int>();
			Dictionary<int, Material> dictionary4 = new Dictionary<int, Material>();
			Dictionary<int, double> dictionary5 = new Dictionary<int, double>();
			Dictionary<int, List<string[]>> dictionary6 = new Dictionary<int, List<string[]>>();
			Dictionary<int, List<string[]>> dictionary7 = new Dictionary<int, List<string[]>>();
			Dictionary<int, string[]> dictionary8 = new Dictionary<int, string[]>();
			Dictionary<int, string[]> dictionary9 = new Dictionary<int, string[]>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			List<string> list4 = new List<string>();
			StartContinuousAnimation(base.ReadingText, _0023_003DzmHS7frs_003D);
			string text;
			while ((text = textReader.ReadLine()) != null)
			{
				if (!text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772)) && !string.IsNullOrWhiteSpace(text))
				{
					if (text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302926772)))
					{
						text = text.Split('$')[0];
					}
					list4.Add(text.ToUpper());
				}
			}
			List<string> list5 = new List<string>();
			if (Regex.IsMatch(list4[0], _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010087)))
			{
				list4[0] = Regex.Replace(list4[0], _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010087), string.Empty);
			}
			list5.Add(list4[0]);
			for (int i = 1; i < list4.Count; i++)
			{
				if (Regex.IsMatch(list4[i], _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010087)))
				{
					list4[i] = Regex.Replace(list4[i], _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010087), string.Empty);
				}
				if (list5[list5.Count - 1].EndsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302920962)))
				{
					list5[list5.Count - 1] += list4[i];
					continue;
				}
				switch (list4[i][0])
				{
				case ',':
					list5[list5.Count - 1] += list4[i];
					break;
				case '*':
				{
					int num3 = (char.IsLetter(list5[list5.Count - 1][0]) ? 8 : 0);
					if ((list5[list5.Count - 1].Length - num3) % 16 != 0)
					{
						list5[list5.Count - 1] = list5[list5.Count - 1].PadRight(list5[list5.Count - 1].Length + 16 - (list5[list5.Count - 1].Length - num3) % 16);
					}
					list5[list5.Count - 1] += list4[i].Substring(8);
					break;
				}
				case ' ':
				case '+':
					if (char.IsLetter(list4[i].Trim()[0]))
					{
						list5.Add(list4[i]);
						break;
					}
					if (list5[list5.Count - 1].Length % 8 != 0)
					{
						list5[list5.Count - 1] = list5[list5.Count - 1].PadRight(list5[list5.Count - 1].Length + 8 - list5[list5.Count - 1].Length % 8);
					}
					list5[list5.Count - 1] += list4[i].Substring(8);
					break;
				default:
					list5.Add(list4[i]);
					break;
				}
			}
			StopContinuousAnimation(_0023_003DzmHS7frs_003D);
			int num4 = 0;
			bool flag = true;
			foreach (string item in list5)
			{
				if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010074)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010054)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010290)))
				{
					string[] array = _0023_003DzMXe2igo_003D(item);
					dictionary[int.Parse(array[1])] = num2;
					num2++;
					Node node = new Node(_0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array[3]), _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array[4]), _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array[5]));
					if (array.Length >= 8)
					{
						bool inX = array[7].Contains('1');
						bool inY = array[7].Contains('2');
						bool inZ = array[7].Contains('3');
						node.SetRestraint(inX, inY, inZ);
					}
					list.Add(node);
				}
				else if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010302)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010282)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010262)))
				{
					string[] array2 = _0023_003DzMXe2igo_003D(item);
					double[] array3 = new double[5] { _0023_003DzmoTRnVwdvz1s.Young, _0023_003DzmoTRnVwdvz1s.ShearModulus, _0023_003DzmoTRnVwdvz1s.Poisson, _0023_003DzmoTRnVwdvz1s.Density, _0023_003DzmoTRnVwdvz1s.CoeffOfThermalExp };
					int num5 = 2;
					int num6 = 0;
					while (num5 < array2.Length && num6 < array3.Length)
					{
						if (!string.IsNullOrWhiteSpace(array2[num5]))
						{
							array3[num6] = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array2[num5]);
						}
						num5++;
						num6++;
					}
					int key = int.Parse(array2[1]);
					Material material = new Material(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010242) + key, _0023_003Dz5hMtsIJK5NGw[num % _0023_003Dz5hMtsIJK5NGw.Length], array3[0], array3[2], _0023_003DzmoTRnVwdvz1s.YieldStrength, array3[3], array3[4]);
					num++;
					dictionary4[key] = material;
					base.Materials.Add(material);
				}
				else if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010255)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010237)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010219)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010201)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010186)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009911)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009896)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009878)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009860)))
				{
					string[] array4 = _0023_003DzMXe2igo_003D(item);
					int num7 = int.Parse(array4[2]);
					if (num7 > 0)
					{
						dictionary3[int.Parse(array4[1])] = num7;
					}
				}
				else if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009842)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009854)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009834)))
				{
					string[] array5 = _0023_003DzMXe2igo_003D(item);
					int num8 = int.Parse(array5[2]);
					if (num8 > 0)
					{
						dictionary3[int.Parse(array5[1])] = num8;
					}
					dictionary5[int.Parse(array5[1])] = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array5[3]);
				}
				else if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009814)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009793)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009808)))
				{
					string[] array6 = _0023_003DzMXe2igo_003D(item);
					int key2 = int.Parse(array6[1]);
					if (!dictionary6.ContainsKey(key2))
					{
						dictionary6[key2] = new List<string[]>();
					}
					dictionary6[key2].Add(array6);
				}
				else if ((item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010043)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010024)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010001))) && !item.Contains('='))
				{
					string[] array7 = _0023_003DzMXe2igo_003D(item);
					int key3 = int.Parse(array7[1]);
					if (!dictionary7.ContainsKey(key3))
					{
						dictionary7[key3] = new List<string[]>();
					}
					dictionary7[key3].Add(array7);
				}
				else if (item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010014)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009996)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009978)))
				{
					string[] array8 = _0023_003DzMXe2igo_003D(item);
					dictionary9[int.Parse(array8[1])] = array8;
				}
				else if ((item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009960)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009940)) || item.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009952))) && !item.Contains('='))
				{
					string[] array9 = _0023_003DzMXe2igo_003D(item);
					int key4 = int.Parse(array9[1]);
					dictionary8[key4] = array9;
				}
				else if (item.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009415)) && item.Contains('='))
				{
					Match match = Regex.Match(item, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009932));
					if (match.Success)
					{
						list2.Add(int.Parse(match.Value));
					}
				}
				else if (item.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010679)) && item.Contains('='))
				{
					Match match2 = Regex.Match(item, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303009932));
					if (match2.Success)
					{
						list3.Add(int.Parse(match2.Value));
					}
				}
				if (!UpdateProgressAndCheckCancelled(num4, list5.Count * 2, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					flag = false;
					break;
				}
				num4++;
			}
			if (_0023_003Dz9iUNZVmTuZui <= 0 && list2.Count == 1)
			{
				_0023_003Dz9iUNZVmTuZui = list2[0];
			}
			else if (_0023_003Dz9iUNZVmTuZui <= 0 && list2.Count == 0 && dictionary8.Keys.Count > 0)
			{
				_0023_003Dz9iUNZVmTuZui = dictionary8.Keys.Min();
			}
			if (_0023_003Dz9iUNZVmTuZui > 0 && dictionary8.ContainsKey(_0023_003Dz9iUNZVmTuZui))
			{
				string[] array10 = dictionary8[_0023_003Dz9iUNZVmTuZui];
				double num9 = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array10[2]);
				for (int j = 3; j < array10.Length - 1; j += 2)
				{
					double num10 = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(array10[j]);
					foreach (string[] item2 in dictionary6[int.Parse(array10[j + 1])])
					{
						int key5 = int.Parse(item2[2]);
						double num11 = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(item2[4]);
						double amountInX = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(item2[5]) * num9 * num10 * num11;
						double amountInY = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(item2[6]) * num9 * num10 * num11;
						double amountInZ = _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(item2[7]) * num9 * num10 * num11;
						((Node)list[dictionary[key5]]).SetForce(amountInX, amountInY, amountInZ);
					}
				}
			}
			if (_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D <= 0 && list3.Count == 1)
			{
				_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D = list3[0];
			}
			List<int> list6 = new List<int>();
			if (dictionary9.ContainsKey(_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D))
			{
				string[] array11 = dictionary9[_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D];
				for (int k = 2; k < dictionary9[_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D].Length; k++)
				{
					list6.Add(int.Parse(array11[k]));
				}
			}
			else
			{
				list6.Add(_0023_003Dz1kDp30S9JfcDeMrpBw_003D_003D);
			}
			foreach (int item3 in list6)
			{
				if (item3 <= 0 || !dictionary7.ContainsKey(item3))
				{
					continue;
				}
				foreach (string[] item4 in dictionary7[item3])
				{
					for (int l = 2; l < item4.Length; l += 3)
					{
						bool inX2 = item4[l + 1].Contains('1');
						bool inY2 = item4[l + 1].Contains('2');
						bool inZ2 = item4[l + 1].Contains('3');
						((Node)list[dictionary[int.Parse(item4[l])]]).SetRestraint(inX2, inY2, inZ2);
					}
				}
			}
			foreach (string item5 in list5)
			{
				if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010657)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010671)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010653)))
				{
					string[] array12 = _0023_003DzMXe2igo_003D(item5);
					int num12 = int.Parse(array12[2]);
					if (!dictionary2.ContainsKey(num12))
					{
						dictionary2[num12] = new List<Element>();
					}
					Material mat = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num12);
					dictionary2[num12].Add(new Tria3(dictionary[int.Parse(array12[3])], dictionary[int.Parse(array12[4])], dictionary[int.Parse(array12[5])], mat));
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010635)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010617)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010599)))
				{
					string[] array13 = _0023_003DzMXe2igo_003D(item5);
					int num13 = int.Parse(array13[2]);
					if (!dictionary2.ContainsKey(num13))
					{
						dictionary2[num13] = new List<Element>();
					}
					Material mat2 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num13);
					dictionary2[num13].Add(new Tria6(dictionary[int.Parse(array13[3])], dictionary[int.Parse(array13[6])], dictionary[int.Parse(array13[4])], dictionary[int.Parse(array13[7])], dictionary[int.Parse(array13[5])], dictionary[int.Parse(array13[8])], mat2));
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010581)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010563)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010801)))
				{
					string[] array14 = _0023_003DzMXe2igo_003D(item5);
					int num14 = int.Parse(array14[2]);
					if (!dictionary2.ContainsKey(num14))
					{
						dictionary2[num14] = new List<Element>();
					}
					Material mat3 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num14);
					dictionary2[num14].Add(new Quad4(dictionary[int.Parse(array14[3])], dictionary[int.Parse(array14[4])], dictionary[int.Parse(array14[5])], dictionary[int.Parse(array14[6])], mat3));
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010815)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010797)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010779)))
				{
					string[] array15 = _0023_003DzMXe2igo_003D(item5);
					int num15 = int.Parse(array15[2]);
					if (!dictionary2.ContainsKey(num15))
					{
						dictionary2[num15] = new List<Element>();
					}
					Material mat4 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num15);
					dictionary2[num15].Add(new Quad8(dictionary[int.Parse(array15[3])], dictionary[int.Parse(array15[7])], dictionary[int.Parse(array15[4])], dictionary[int.Parse(array15[8])], dictionary[int.Parse(array15[5])], dictionary[int.Parse(array15[9])], dictionary[int.Parse(array15[6])], dictionary[int.Parse(array15[10])], mat4));
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010761)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010741)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010721)))
				{
					string[] array16 = _0023_003DzMXe2igo_003D(item5);
					int num16 = int.Parse(array16[2]);
					if (!dictionary2.ContainsKey(num16))
					{
						dictionary2[num16] = new List<Element>();
					}
					Material mat5 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num16);
					dictionary2[num16].Add(new Truss(dictionary[int.Parse(array16[3])], dictionary[int.Parse(array16[4])], mat5, dictionary5[int.Parse(array16[2])]));
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010733)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010715)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010697)))
				{
					string[] array17 = _0023_003DzMXe2igo_003D(item5);
					int num17 = int.Parse(array17[2]);
					if (!dictionary2.ContainsKey(num17))
					{
						dictionary2[num17] = new List<Element>();
					}
					Material mat6 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num17);
					if (array17.Length >= 13 && !string.IsNullOrWhiteSpace(array17[12]))
					{
						dictionary2[num17].Add(new Tetra10(dictionary[int.Parse(array17[3])], dictionary[int.Parse(array17[7])], dictionary[int.Parse(array17[4])], dictionary[int.Parse(array17[8])], dictionary[int.Parse(array17[5])], dictionary[int.Parse(array17[9])], dictionary[int.Parse(array17[10])], dictionary[int.Parse(array17[11])], dictionary[int.Parse(array17[12])], dictionary[int.Parse(array17[6])], mat6));
					}
					else
					{
						dictionary2[num17].Add(new Tetra4(dictionary[int.Parse(array17[3])], dictionary[int.Parse(array17[4])], dictionary[int.Parse(array17[5])], dictionary[int.Parse(array17[6])], mat6));
					}
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010423)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010405)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010387)))
				{
					string[] array18 = _0023_003DzMXe2igo_003D(item5);
					int num18 = int.Parse(array18[2]);
					if (!dictionary2.ContainsKey(num18))
					{
						dictionary2[num18] = new List<Element>();
					}
					Material mat7 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num18);
					if (array18.Length >= 18 && !string.IsNullOrWhiteSpace(array18[17]))
					{
						dictionary2[num18].Add(new Penta15(dictionary[int.Parse(array18[3])], dictionary[int.Parse(array18[9])], dictionary[int.Parse(array18[4])], dictionary[int.Parse(array18[10])], dictionary[int.Parse(array18[5])], dictionary[int.Parse(array18[11])], dictionary[int.Parse(array18[12])], dictionary[int.Parse(array18[13])], dictionary[int.Parse(array18[14])], dictionary[int.Parse(array18[6])], dictionary[int.Parse(array18[15])], dictionary[int.Parse(array18[7])], dictionary[int.Parse(array18[16])], dictionary[int.Parse(array18[8])], dictionary[int.Parse(array18[17])], mat7));
					}
					else
					{
						dictionary2[num18].Add(new Penta6(dictionary[int.Parse(array18[3])], dictionary[int.Parse(array18[4])], dictionary[int.Parse(array18[5])], dictionary[int.Parse(array18[6])], dictionary[int.Parse(array18[7])], dictionary[int.Parse(array18[8])], mat7));
					}
				}
				else if (item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010369)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010384)) || item5.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010363)))
				{
					string[] array19 = _0023_003DzMXe2igo_003D(item5);
					int num19 = int.Parse(array19[2]);
					if (!dictionary2.ContainsKey(num19))
					{
						dictionary2[num19] = new List<Element>();
					}
					Material mat8 = _0023_003DzhcS_00IKpqWY(_0023_003DzmoTRnVwdvz1s, dictionary3, dictionary4, num19);
					if (array19.Length >= 23 && !string.IsNullOrWhiteSpace(array19[22]))
					{
						dictionary2[num19].Add(new Hexa20(dictionary[int.Parse(array19[6])], dictionary[int.Parse(array19[14])], dictionary[int.Parse(array19[3])], dictionary[int.Parse(array19[11])], dictionary[int.Parse(array19[4])], dictionary[int.Parse(array19[12])], dictionary[int.Parse(array19[5])], dictionary[int.Parse(array19[13])], dictionary[int.Parse(array19[18])], dictionary[int.Parse(array19[15])], dictionary[int.Parse(array19[16])], dictionary[int.Parse(array19[17])], dictionary[int.Parse(array19[10])], dictionary[int.Parse(array19[22])], dictionary[int.Parse(array19[7])], dictionary[int.Parse(array19[19])], dictionary[int.Parse(array19[8])], dictionary[int.Parse(array19[20])], dictionary[int.Parse(array19[9])], dictionary[int.Parse(array19[21])], mat8));
					}
					else
					{
						dictionary2[num19].Add(new Hexa8(dictionary[int.Parse(array19[6])], dictionary[int.Parse(array19[3])], dictionary[int.Parse(array19[4])], dictionary[int.Parse(array19[5])], dictionary[int.Parse(array19[10])], dictionary[int.Parse(array19[7])], dictionary[int.Parse(array19[8])], dictionary[int.Parse(array19[9])], mat8));
					}
				}
				if (!UpdateProgressAndCheckCancelled(num4, list5.Count * 2, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					flag = false;
					break;
				}
				num4++;
			}
			List<Entity> list7 = new List<Entity>();
			if (flag)
			{
				foreach (List<Element> value in dictionary2.Values)
				{
					FemMesh femMesh = new FemMesh(list, value);
					femMesh.DeleteUnusedNodes();
					list7.Add(femMesh);
				}
				base.Entities.AddRange(list7);
				UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
			}
			base.Result = flag;
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
	}

	private string[] _0023_003DzMXe2igo_003D(string _0023_003DzQ9zpGF0_003D)
	{
		if (_0023_003DzQ9zpGF0_003D.Contains(','))
		{
			return _0023_003DzQ9zpGF0_003D.Trim().Split(',');
		}
		List<string> list = new List<string>();
		string _0023_003Dz_0024n2nrac_003D = _0023_003DzQ9zpGF0_003D.Substring(8);
		bool flag = Regex.IsMatch(_0023_003DzQ9zpGF0_003D, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010346));
		list.Add(_0023_003DzQ9zpGF0_003D.Substring(0, 8));
		_0023_003Dzhx7gjcbMfQeL(_0023_003Dz_0024n2nrac_003D, flag ? 16 : 8, list);
		return list.ToArray();
	}

	private void _0023_003Dzhx7gjcbMfQeL(string _0023_003Dz_0024n2nrac_003D, int _0023_003DzfuNQdKg_003D, IList<string> _0023_003Dzpj08S6yJm2ng)
	{
		int length = _0023_003DzfuNQdKg_003D;
		for (int i = 0; i < _0023_003Dz_0024n2nrac_003D.Length; i += _0023_003DzfuNQdKg_003D)
		{
			if (i + _0023_003DzfuNQdKg_003D > _0023_003Dz_0024n2nrac_003D.Length)
			{
				length = _0023_003Dz_0024n2nrac_003D.Length - i;
			}
			_0023_003Dzpj08S6yJm2ng.Add(_0023_003Dz_0024n2nrac_003D.Substring(i, length));
		}
	}

	private double _0023_003Dzh2_LUDdeRJyM_00248pXsA_003D_003D(string _0023_003Dz8lc6uO0_003D)
	{
		_0023_003Dz8lc6uO0_003D = _0023_003Dz8lc6uO0_003D.Trim();
		if (double.TryParse(_0023_003Dz8lc6uO0_003D, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		bool flag = _0023_003Dz8lc6uO0_003D[0] == '-';
		if (flag)
		{
			_0023_003Dz8lc6uO0_003D = _0023_003Dz8lc6uO0_003D.Substring(1);
		}
		if (_0023_003Dz8lc6uO0_003D.Contains('-'))
		{
			int num = _0023_003Dz8lc6uO0_003D.IndexOf('-');
			string s = _0023_003Dz8lc6uO0_003D.Substring(num + 1, _0023_003Dz8lc6uO0_003D.Length - num - 1);
			_0023_003Dz8lc6uO0_003D = _0023_003Dz8lc6uO0_003D.Substring(0, num);
			return Utility.DoubleParse(_0023_003Dz8lc6uO0_003D) * Math.Pow(10.0, -int.Parse(s)) * (double)((!flag) ? 1 : (-1));
		}
		if (_0023_003Dz8lc6uO0_003D.Contains('+'))
		{
			int num2 = _0023_003Dz8lc6uO0_003D.IndexOf('+');
			string s2 = _0023_003Dz8lc6uO0_003D.Substring(num2 + 1, _0023_003Dz8lc6uO0_003D.Length - num2 - 1);
			_0023_003Dz8lc6uO0_003D = _0023_003Dz8lc6uO0_003D.Substring(0, num2);
			return Utility.DoubleParse(_0023_003Dz8lc6uO0_003D) * Math.Pow(10.0, int.Parse(s2)) * (double)((!flag) ? 1 : (-1));
		}
		throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010335) + _0023_003Dz8lc6uO0_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303010550));
	}

	private Material _0023_003DzhcS_00IKpqWY(Material _0023_003DzV4_0024P_0024OTTy48l, Dictionary<int, int> _0023_003DzNAXLJFCxmxNu, Dictionary<int, Material> _0023_003DzulbANo9vvubg4R4vO50_lN4_003D, int _0023_003Dzhvvip9c_003D)
	{
		if (_0023_003DzNAXLJFCxmxNu.ContainsKey(_0023_003Dzhvvip9c_003D) && _0023_003DzulbANo9vvubg4R4vO50_lN4_003D.ContainsKey(_0023_003DzNAXLJFCxmxNu[_0023_003Dzhvvip9c_003D]))
		{
			return _0023_003DzulbANo9vvubg4R4vO50_lN4_003D[_0023_003DzNAXLJFCxmxNu[_0023_003Dzhvvip9c_003D]];
		}
		return _0023_003DzV4_0024P_0024OTTy48l;
	}
}
