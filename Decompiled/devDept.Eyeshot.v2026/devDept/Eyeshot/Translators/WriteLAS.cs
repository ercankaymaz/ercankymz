using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class WriteLAS : WriteFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FastPointCloud _0023_003DzT7_0024nBC4FG7Ix;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double[] _0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ushort[] _0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[] _0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz1C57krXZ7x5xUCisiO2yMS8_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzM141RhzAYJJU1_LBVGjjcwU_003D = -1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz67mjuUwWKdrGPw8jzZeKnyk_003D = -1.0;

	public static supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public double[] Coordinates
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzlpPRfKZqAWd0MqVvxg_003D_003D = value;
		}
	}

	public ushort[] Intensities
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJUzzmJbdiiPOsbgdfNr9lwEG638J = value;
		}
	}

	public byte[] Classifications
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzY4eWp3rXSrpw1uHDkA_003D_003D = value;
		}
	}

	public double CustomScalingFactorX
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz1C57krXZ7x5xUCisiO2yMS8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz1C57krXZ7x5xUCisiO2yMS8_003D = value;
		}
	}

	public double CustomScalingFactorY
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzM141RhzAYJJU1_LBVGjjcwU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzM141RhzAYJJU1_LBVGjjcwU_003D = value;
		}
	}

	public double CustomScalingFactorZ
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz67mjuUwWKdrGPw8jzZeKnyk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz67mjuUwWKdrGPw8jzZeKnyk_003D = value;
		}
	}

	public WriteLAS(FastPointCloud fastPointCloud, string filePath)
		: base(new WriteParams(new List<Entity> { fastPointCloud }), filePath)
	{
		_0023_003DzT7_0024nBC4FG7Ix = fastPointCloud;
	}

	public WriteLAS(FastPointCloud fastPointCloud, Stream stream)
		: base(new WriteParams(new List<Entity> { fastPointCloud }), stream)
	{
		_0023_003DzT7_0024nBC4FG7Ix = fastPointCloud;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		try
		{
			_0023_003DzSfJQCHzYNHkG(progress, ct);
			UpdateProgressTo100(base.ComposingText, progress);
		}
		catch (Exception ex)
		{
			string message = ex.Message;
			log.AppendLine(message);
			throw new EyeshotException(message, ex);
		}
		finally
		{
			CloseStream();
		}
	}

	internal bool _0023_003DzSfJQCHzYNHkG(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		byte[] classifications = Classifications;
		bool flag = classifications != null && classifications.Length != 0;
		bool flag2 = _0023_003DzT7_0024nBC4FG7Ix.Nature == PointCloud.natureType.Multicolor && (_0023_003DzT7_0024nBC4FG7Ix._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.RGB || _0023_003DzT7_0024nBC4FG7Ix._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.RGBA);
		ushort[] intensities = Intensities;
		bool flag3 = intensities != null && intensities.Length != 0;
		ushort[] array = Intensities;
		if (!flag3 && _0023_003DzT7_0024nBC4FG7Ix._0023_003DzcPAo3gzQ86BL() == FastPointCloud._0023_003DzAtKz90KWkOZN.Indeterminate)
		{
			array = new ushort[_0023_003DzT7_0024nBC4FG7Ix.ColorArray.Length];
			byte _0023_003Dz8dK2uhU_003D = _0023_003DzT7_0024nBC4FG7Ix.ColorArray.Max();
			byte _0023_003DzF7v9r2A_003D = _0023_003DzT7_0024nBC4FG7Ix.ColorArray.Min();
			for (int i = 0; i < _0023_003DzT7_0024nBC4FG7Ix.ColorArray.Length; i++)
			{
				array[i] = Utility._0023_003DzdceBluUVGYUs(_0023_003DzT7_0024nBC4FG7Ix.ColorArray[i], _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			}
			flag3 = true;
		}
		byte value = 0;
		ushort num = 20;
		if (flag2)
		{
			value = 2;
			num = 26;
		}
		using (BinaryWriter binaryWriter = new BinaryWriter(base.Stream ?? File.Open(base.FilePath, FileMode.Create, FileAccess.Write)))
		{
			double num2 = double.MaxValue;
			double num3 = double.MaxValue;
			double num4 = double.MaxValue;
			double num5 = double.MinValue;
			double num6 = double.MinValue;
			double num7 = double.MinValue;
			float[] pointArray = _0023_003DzT7_0024nBC4FG7Ix.PointArray;
			byte[] colorArray = _0023_003DzT7_0024nBC4FG7Ix.ColorArray;
			FastPointCloud._0023_003DzAtKz90KWkOZN _0023_003DzAtKz90KWkOZN = _0023_003DzT7_0024nBC4FG7Ix._0023_003DzcPAo3gzQ86BL();
			int num8 = pointArray.Length;
			int num9 = num8 / 3;
			double[] array2 = new double[num8];
			for (int j = 0; j < num8; j++)
			{
				double[] coordinates = Coordinates;
				double num10;
				double num11;
				double num12;
				if (coordinates != null && coordinates.Length != 0)
				{
					num10 = Coordinates[j++];
					num11 = Coordinates[j++];
					num12 = Coordinates[j];
				}
				else
				{
					num10 = pointArray[j++];
					num11 = pointArray[j++];
					num12 = pointArray[j];
				}
				array2[j - 2] = num10;
				array2[j - 1] = num11;
				array2[j] = num12;
				if (num2 > num10)
				{
					num2 = num10;
				}
				if (num3 > num11)
				{
					num3 = num11;
				}
				if (num4 > num12)
				{
					num4 = num12;
				}
				if (num5 < num10)
				{
					num5 = num10;
				}
				if (num6 < num11)
				{
					num6 = num11;
				}
				if (num7 < num12)
				{
					num7 = num12;
				}
			}
			double num13 = (num5 + num2) / 2.0;
			double num14 = (num6 + num3) / 2.0;
			double num15 = (num7 + num4) / 2.0;
			double num16 = 0.01;
			double num17 = 0.01;
			double num18 = 0.01;
			int length = Convert.ToInt32(num5 - num13).ToString().Length;
			int length2 = Convert.ToInt32(num6 - num14).ToString().Length;
			int length3 = Convert.ToInt32(num7 - num15).ToString().Length;
			num16 = Math.Pow(10.0, length - 9);
			num17 = Math.Pow(10.0, length2 - 9);
			num18 = Math.Pow(10.0, length3 - 9);
			if (CustomScalingFactorX > 0.0)
			{
				num16 = CustomScalingFactorX;
			}
			if (CustomScalingFactorY > 0.0)
			{
				num17 = CustomScalingFactorY;
			}
			if (CustomScalingFactorZ > 0.0)
			{
				num18 = CustomScalingFactorZ;
			}
			binaryWriter.Write(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303008285).ToCharArray());
			binaryWriter.Write(Convert.ToUInt16(0));
			binaryWriter.Write(Convert.ToUInt16(0));
			binaryWriter.Write(Convert.ToUInt32(0));
			binaryWriter.Write(Convert.ToUInt16(0));
			binaryWriter.Write(Convert.ToUInt16(0));
			binaryWriter.Write(Convert.ToInt64(0));
			binaryWriter.Write(Convert.ToByte(1));
			binaryWriter.Write(Convert.ToByte(2));
			char[] _0023_003DzxwaSN1c_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013231).ToCharArray();
			ReadLAS._0023_003DzTGq9tzM22U_0024U(ref _0023_003DzxwaSN1c_003D, 32, _0023_003DzrDrboos_003D: true);
			binaryWriter.Write(_0023_003DzxwaSN1c_003D);
			char[] _0023_003DzxwaSN1c_003D2 = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303013189).ToCharArray();
			ReadLAS._0023_003DzTGq9tzM22U_0024U(ref _0023_003DzxwaSN1c_003D2, 32, _0023_003DzrDrboos_003D: true);
			binaryWriter.Write(_0023_003DzxwaSN1c_003D2);
			binaryWriter.Write(Convert.ToUInt16(DateTime.Now.DayOfYear));
			binaryWriter.Write(Convert.ToUInt16(DateTime.Now.Year));
			binaryWriter.Write(Convert.ToUInt16(227));
			binaryWriter.Write(Convert.ToUInt32(281));
			binaryWriter.Write(Convert.ToUInt32(1));
			binaryWriter.Write(Convert.ToByte(value));
			binaryWriter.Write(Convert.ToUInt16(num));
			binaryWriter.Write(Convert.ToUInt32(num9));
			binaryWriter.Write(Convert.ToUInt32(num9));
			binaryWriter.Write(Convert.ToUInt32(0));
			binaryWriter.Write(Convert.ToUInt32(0));
			binaryWriter.Write(Convert.ToUInt32(0));
			binaryWriter.Write(Convert.ToUInt32(0));
			binaryWriter.Write(num16);
			binaryWriter.Write(num17);
			binaryWriter.Write(num18);
			binaryWriter.Write(num13);
			binaryWriter.Write(num14);
			binaryWriter.Write(num15);
			binaryWriter.Write(num5);
			binaryWriter.Write(num2);
			binaryWriter.Write(num6);
			binaryWriter.Write(num3);
			binaryWriter.Write(num7);
			binaryWriter.Write(num4);
			byte[] buffer = new byte[54];
			binaryWriter.Write(buffer);
			double num19 = 1.0 / num16;
			double num20 = 1.0 / num17;
			double num21 = 1.0 / num18;
			byte[] array3 = new byte[num - 12];
			byte[] array4 = new byte[2];
			byte[] array5 = new byte[2];
			Array.Clear(array3, 0, num - 12);
			array3[2] = 9;
			int num22 = 0;
			for (int k = 0; k < num9; k++)
			{
				int num23 = k * 3;
				binaryWriter.Write(Convert.ToInt32((array2[num23] - num13) * num19));
				binaryWriter.Write(Convert.ToInt32((array2[num23 + 1] - num14) * num20));
				binaryWriter.Write(Convert.ToInt32((array2[num23 + 2] - num15) * num21));
				if (flag3)
				{
					array4 = BitConverter.GetBytes(array[k]);
					array3[0] = array4[0];
					array3[1] = array4[1];
				}
				if (flag)
				{
					array3[3] = Classifications[k];
				}
				if (flag2)
				{
					int value2 = 257 * colorArray[num22++];
					int value3 = 257 * colorArray[num22++];
					int value4 = 257 * colorArray[num22++];
					if (_0023_003DzAtKz90KWkOZN == FastPointCloud._0023_003DzAtKz90KWkOZN.RGBA)
					{
						num22++;
					}
					array5 = BitConverter.GetBytes(Convert.ToUInt16(value2));
					array3[8] = array5[0];
					array3[9] = array5[1];
					array5 = BitConverter.GetBytes(Convert.ToUInt16(value3));
					array3[10] = array5[0];
					array3[11] = array5[1];
					array5 = BitConverter.GetBytes(Convert.ToUInt16(value4));
					array3[12] = array5[0];
					array3[13] = array5[1];
				}
				binaryWriter.Write(array3);
				if (!UpdateProgressAndCheckCancelled(k, num9, base.ComposingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return false;
				}
			}
		}
		return true;
	}
}
