using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadE57 : ReadFileAsync
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _0023_003Dzi63J9xpsywSe;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private byte[][] _0023_003DzRL_00242wk_0024xLE0K6a9vbw_003D_003D;

	public byte[][] Images
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzRL_00242wk_0024xLE0K6a9vbw_003D_003D;
		}
	}

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.Unitless;

	public ReadE57(string filePath, int pointSize = 1)
		: base(filePath)
	{
		_0023_003Dzi63J9xpsywSe = pointSize;
	}

	public ReadE57(Stream stream, int pointSize = 1)
		: base(stream)
	{
		_0023_003Dzi63J9xpsywSe = pointSize;
	}

	private void _0023_003Dz2JG85LfjctiY(byte[][] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzRL_00242wk_0024xLE0K6a9vbw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
		_0023_003DzHSCeDgu_l220(progress, ct);
		UpdateProgressTo100(base.ParsingText, progress);
	}

	private void _0023_003DzHSCeDgu_l220(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		try
		{
			_0023_003Dzx0lrF_GWi1T74GOixA_003D_003D _0023_003DzdNx9MH0_003D = new _0023_003Dzx0lrF_GWi1T74GOixA_003D_003D();
			_0023_003DzekfVSS0De_0024ld _0023_003DzekfVSS0De_0024ld2 = new _0023_003DzekfVSS0De_0024ld(base.FilePath, _0023_003DzdNx9MH0_003D);
			long num = _0023_003DzekfVSS0De_0024ld2._0023_003DzcL2TV9yTZ2U_0024();
			Entity[] array = new Entity[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = _0023_003Dz9xlHXzk_003D(i, _0023_003DzekfVSS0De_0024ld2);
				if (!UpdateProgressAndCheckCancelled(i, (int)num, base.ReadingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					base.Result = false;
					break;
				}
			}
			base.Entities.AddRange(array);
			long num2 = _0023_003DzekfVSS0De_0024ld2._0023_003Dzm81QodXKF4cF();
			byte[][] array2 = new byte[num2][];
			for (int j = 0; j < num2; j++)
			{
				array2[j] = _0023_003DzjhRBFRi5eA8F(j, _0023_003DzekfVSS0De_0024ld2);
				if (!UpdateProgressAndCheckCancelled(j, (int)num2, base.ReadingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					base.Result = false;
					break;
				}
			}
			_0023_003Dz2JG85LfjctiY(array2);
			base.Result = true;
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
		}
		finally
		{
			CloseStream();
		}
	}

	private Entity _0023_003Dz9xlHXzk_003D(int _0023_003DzyzK8swU_003D, _0023_003DzekfVSS0De_0024ld _0023_003DzkKz7OWA_003D)
	{
		_0023_003DzLmzs72rsWKaq _0023_003DzLmzs72rsWKaq2 = new _0023_003DzLmzs72rsWKaq();
		_0023_003DzkKz7OWA_003D._0023_003DzKzSL4dWj6HEu(_0023_003DzyzK8swU_003D, _0023_003DzLmzs72rsWKaq2);
		ulong _0023_003DzVV8lGoc_003D = (ulong)_0023_003DzLmzs72rsWKaq2._0023_003DzVV8lGoc_003D;
		_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2 = new _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D(_0023_003DzLmzs72rsWKaq2);
		_0023_003DzGMRZVxsGrz7gOYV75w_003D_003D obj = _0023_003DzkKz7OWA_003D._0023_003DzuzIFk7GLobnd7Vhv8g_003D_003D(_0023_003DzyzK8swU_003D, _0023_003DzVV8lGoc_003D, _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2);
		obj._0023_003DzuuY9lIM_003D();
		obj._0023_003DzQZRatpY_003D();
		if (_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D != null)
		{
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003DzLvzvJeeRIzn9();
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003DzulpCNkDlZkWw();
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003DzvP9HELJZvdJh();
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003DzSGqaguHN_0024v_0024m();
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003Dz9vezRsyPSjEe();
			_0023_003DzLmzs72rsWKaq2._0023_003DzDbL2UToMTP_0024vzreDkA_003D_003D._0023_003DzixCHch0Kgbb3();
		}
		float[] array = new float[_0023_003DzVV8lGoc_003D * 3];
		byte[] array2 = null;
		if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzP3ie5zSPTRWi != null)
		{
			array2 = new byte[_0023_003DzVV8lGoc_003D * 3];
		}
		double num = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003DzhgIOXHZxutIC4I3FCQ_003D_003D();
		double num2 = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003DzCPFaF1dgJPXY8wvegA_003D_003D() - num;
		if (num2 <= 0.0)
		{
			num2 = 1.0;
		}
		double num3 = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003DzQh4xyh7NL0yrDasjeA_003D_003D();
		double num4 = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003Dz0hEdE_O8iWebRMkc9Q_003D_003D() - num3;
		if (num4 <= 0.0)
		{
			num4 = 1.0;
		}
		double num5 = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003Dz8J_lkjk0X3Lz_0024LqkVw_003D_003D();
		double num6 = _0023_003DzLmzs72rsWKaq2._0023_003Dzy7es8naIZEpi._0023_003DzxOW1r7hGwETWLhYylA_003D_003D() - num5;
		if (num6 <= 0.0)
		{
			num6 = 1.0;
		}
		if (array2 == null && _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzXoxllMKlzswGAJx4XQ_003D_003D != null)
		{
			array2 = new byte[_0023_003DzVV8lGoc_003D];
		}
		double num7 = _0023_003DzLmzs72rsWKaq2._0023_003DzN5Hh_Cb0wetlu8XbYA_003D_003D._0023_003Dzzz_00242i8I9uCGJLbssgu7qw6w_003D();
		double num8 = _0023_003DzLmzs72rsWKaq2._0023_003DzN5Hh_Cb0wetlu8XbYA_003D_003D._0023_003DzlTI6_ckvE3byRUobHtnxqvg_003D() - num7;
		if (num8 <= 0.0)
		{
			num8 = 1.0;
		}
		int num9 = 0;
		for (ulong num10 = 0uL; num10 < _0023_003DzVV8lGoc_003D; num10++)
		{
			if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzIgil5WuQgnOWbN3Qpg_003D_003D == null || _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzIgil5WuQgnOWbN3Qpg_003D_003D[num10] == 0)
			{
				array[num9 * 3] = _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzhB7sYEPgb1pZiFDh7A_003D_003D[num10];
				array[num9 * 3 + 1] = _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzM8mGBnCJs62vPZvPmw_003D_003D[num10];
				array[num9 * 3 + 2] = _0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzWU2T0Rn2Eb0SbgL17A_003D_003D[num10];
				if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzP3ie5zSPTRWi != null)
				{
					array2[num9 * 3] = (byte)(255.0 * ((double)(int)_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzP3ie5zSPTRWi[num10] - num) / num2);
					array2[num9 * 3 + 1] = (byte)(255.0 * ((double)(int)_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzcmlYHsYD1_b9[num10] - num3) / num4);
					array2[num9 * 3 + 2] = (byte)(255.0 * ((double)(int)_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003Dz5lNncYBacFud[num10] - num5) / num6);
				}
				else if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzXoxllMKlzswGAJx4XQ_003D_003D != null)
				{
					array2[num9] = (byte)(255.0 * (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzXoxllMKlzswGAJx4XQ_003D_003D[num10] - num7) / num8);
				}
				num9++;
			}
		}
		Array.Resize(ref array, num9 * 3);
		if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzP3ie5zSPTRWi != null)
		{
			Array.Resize(ref array2, num9 * 3);
		}
		else
		{
			Array.Resize(ref array2, num9);
		}
		FastPointCloud fastPointCloud = new FastPointCloud(array, array2, _0023_003Dzi63J9xpsywSe);
		if (_0023_003Dz5nHs_00241USxuuVK2xTiQ_003D_003D2._0023_003DzXoxllMKlzswGAJx4XQ_003D_003D != null)
		{
			fastPointCloud.ColorMethod = colorMethodType.byEntity;
			fastPointCloud.Color = Color.White;
		}
		if (_0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa != null)
		{
			string text = _0023_003DzLmzs72rsWKaq2._0023_003DzS_00246o7tc_003D;
			if (string.IsNullOrEmpty(text))
			{
				text = _0023_003DzLmzs72rsWKaq2._0023_003DzG5EGDUs_003D;
			}
			Block block = new Block(text);
			block.Entities.Add(fastPointCloud);
			base.Blocks.Add(block);
			Transformation transformation = Transformation.CreateTranslation(_0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzOeP6q8j2cKMcB_0zTEnNK94_003D()._0023_003DznUaEvbA_003D(), _0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzOeP6q8j2cKMcB_0zTEnNK94_003D()._0023_003DzSUxfHVk_003D(), _0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzOeP6q8j2cKMcB_0zTEnNK94_003D()._0023_003DzYheKMao_003D());
			new Quaternion(_0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzdhM2jNYWIexx()._0023_003DznUaEvbA_003D(), _0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzdhM2jNYWIexx()._0023_003DzSUxfHVk_003D(), _0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzdhM2jNYWIexx()._0023_003DzYheKMao_003D(), _0023_003DzLmzs72rsWKaq2._0023_003DzA6PgTWtstREa._0023_003DzdhM2jNYWIexx()._0023_003Dz9OgBg_0_003D()).ToMatrix(out var matrix);
			Transformation transformation2 = new Transformation(matrix);
			return new BlockReference(transformation * transformation2, text);
		}
		return fastPointCloud;
	}

	private static byte[] _0023_003DzjhRBFRi5eA8F(int _0023_003Dz437_00244ak_003D, _0023_003DzekfVSS0De_0024ld _0023_003DzkKz7OWA_003D)
	{
		_0023_003DzkKz7OWA_003D._0023_003Dz5BrLkEDC__Sd(_0023_003Dz437_00244ak_003D, out var _0023_003Dz4kk5mfF5mi3o, out var _0023_003DzCU2WMrg_003D, out var _, out var _, out var _0023_003DztOsEnaI_003D, out var _, out var _);
		byte[] array = new byte[_0023_003DztOsEnaI_003D];
		_0023_003DzkKz7OWA_003D._0023_003Dz3kgNZ3DB_7mE(_0023_003Dz437_00244ak_003D, _0023_003Dz4kk5mfF5mi3o, _0023_003DzCU2WMrg_003D, array, 0, _0023_003DztOsEnaI_003D);
		return array;
	}
}
