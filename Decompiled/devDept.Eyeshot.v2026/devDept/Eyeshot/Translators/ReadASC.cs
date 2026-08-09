using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadASC : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzSAfnXq_6DzzNsUlrbajLZgM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzokiXPnZxLmOz5QgL3w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private char[] _0023_003DzztCR5srE8eEOYA8UCw_003D_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public bool SkipInvalidLines
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSAfnXq_6DzzNsUlrbajLZgM_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzSAfnXq_6DzzNsUlrbajLZgM_003D = value;
		}
	}

	public float PointSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzokiXPnZxLmOz5QgL3w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzokiXPnZxLmOz5QgL3w_003D_003D = value;
		}
	}

	public ReadASC(string filePath, char[] separators)
		: base(filePath)
	{
		_0023_003DzztCR5srE8eEOYA8UCw_003D_003D = separators;
	}

	public ReadASC(string filePath)
		: this(filePath, new char[3] { ',', ' ', '\t' })
	{
	}

	public ReadASC(Stream stream, char[] separators)
		: base(stream)
	{
		_0023_003DzztCR5srE8eEOYA8UCw_003D_003D = separators;
	}

	public ReadASC(Stream stream)
		: this(stream, new char[3] { ',', ' ', '\t' })
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzuMjkyPi4ALnx(_0023_003DzztCR5srE8eEOYA8UCw_003D_003D, progress, ct);
	}

	private void _0023_003DzuMjkyPi4ALnx(char[] _0023_003DzvcDZOW0_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool flag = true;
		try
		{
			TextReader textReader = new StreamReader(base.Stream, Encoding.ASCII);
			List<float> list = new List<float>();
			List<byte> list2 = new List<byte>();
			List<float> list3 = new List<float>();
			int num = 0;
			int num2 = 0;
			string text;
			while ((text = textReader.ReadLine()) != null)
			{
				num++;
				if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
				{
					continue;
				}
				string[] array = text.Split(_0023_003DzvcDZOW0_003D, StringSplitOptions.RemoveEmptyEntries);
				if (SkipInvalidLines && array.Length < 3)
				{
					continue;
				}
				num2 = array.Length;
				if (num2 == 4)
				{
					try
					{
						Convert.ToSingle(array[3]);
					}
					catch (Exception ex)
					{
						log.AppendLine(ex.Message);
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999529));
						num2 = 3;
					}
				}
				else if (num2 >= 6)
				{
					try
					{
						Convert.ToByte(array[3]);
						Convert.ToByte(array[4]);
						Convert.ToByte(array[5]);
					}
					catch (Exception ex2)
					{
						log.AppendLine(ex2.Message);
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302999517));
						num2 = 3;
					}
				}
				break;
			}
			while (textReader.ReadLine() != null)
			{
				num++;
			}
			base.Stream.Position = 0L;
			float num3 = 0f;
			float num4 = float.MaxValue;
			int num5 = -1;
			Point3D maxValue = Point3D.MaxValue;
			Point3D minValue = Point3D.MinValue;
			int num6 = 1;
			while ((text = textReader.ReadLine()) != null)
			{
				if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302924027)))
				{
					continue;
				}
				string[] array2 = text.Split(_0023_003DzvcDZOW0_003D, StringSplitOptions.RemoveEmptyEntries);
				if (SkipInvalidLines && array2.Length < 3)
				{
					continue;
				}
				float num7 = Convert.ToSingle(array2[0], CultureInfo.InvariantCulture);
				float num8 = Convert.ToSingle(array2[1], CultureInfo.InvariantCulture);
				float num9 = Convert.ToSingle(array2[2], CultureInfo.InvariantCulture);
				if ((double)num7 < maxValue.X)
				{
					maxValue.X = num7;
				}
				if ((double)num8 < maxValue.Y)
				{
					maxValue.Y = num8;
				}
				if ((double)num9 < maxValue.Z)
				{
					maxValue.Z = num9;
				}
				if ((double)num7 > minValue.X)
				{
					minValue.X = num7;
				}
				if ((double)num8 > minValue.Y)
				{
					minValue.Y = num8;
				}
				if ((double)num9 > minValue.Z)
				{
					minValue.Z = num9;
				}
				list.Add(num7);
				list.Add(num8);
				list.Add(num9);
				if (num2 == 4)
				{
					float num10 = Math.Abs(Convert.ToSingle(array2[3], CultureInfo.InvariantCulture));
					if (num10 > num3)
					{
						num3 = num10;
					}
					if (num10 < num4)
					{
						num4 = num10;
					}
					list3.Add(num10);
				}
				else if (num2 >= 6)
				{
					list2.Add(Convert.ToByte(array2[3]));
					list2.Add(Convert.ToByte(array2[4]));
					list2.Add(Convert.ToByte(array2[5]));
				}
				int value = 100 * num6 / num;
				if (value != num5)
				{
					Utility.LimitRange(0, ref value, 100);
					if (!UpdateProgressAndCheckCancelled(value, 100.0, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						flag = false;
						break;
					}
					num5 = value;
				}
				num6++;
			}
			UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
			if (num2 == 4)
			{
				foreach (float item in list3)
				{
					list2.Add(Utility._0023_003DzdceBluUVGYUs(item, num4, num3));
				}
			}
			if (flag)
			{
				base.Result = true;
				byte[] rgbArray = ((list2.Count > 0) ? list2.ToArray() : null);
				FastPointCloud fastPointCloud = ((!(PointSize > 0f)) ? new FastPointCloud(list.ToArray(), rgbArray) : new FastPointCloud(list.ToArray(), rgbArray, PointSize));
				fastPointCloud.localMin = maxValue;
				fastPointCloud.localMax = minValue;
				fastPointCloud.UpdateBoundingBoxSphere();
				fastPointCloud.RegenMode = regenType.CompileOnly;
				base.Entities.Add(fastPointCloud);
			}
		}
		catch (Exception ex3)
		{
			log.AppendLine(ex3.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
		base.Result = flag;
	}
}
