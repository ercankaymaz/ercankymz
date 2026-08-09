using System;
using System.IO;
using System.Runtime.InteropServices;

internal sealed class _0023_003Dzky71NbzzZtXT
{
	public static int _0023_003DzQYBuDLs_003D = _0023_003Dz_0024oxQthahZeIK._0023_003DzPz59Q49i5BOkok0U0Za7iv0_003D - Marshal.SizeOf(typeof(_0023_003Dz0AB_S2XI_0024JM8xOABsA_003D_003D));

	public _0023_003Dz0AB_S2XI_0024JM8xOABsA_003D_003D _0023_003Dz8Vwa6Pc_003D;

	public byte[] _0023_003Dzmm_B7W0_003D = new byte[_0023_003DzQYBuDLs_003D];

	public _0023_003Dzky71NbzzZtXT()
	{
	}

	public _0023_003Dzky71NbzzZtXT(byte[] _0023_003DzEBnCHDkN86Zx)
	{
		_0023_003Dz8Vwa6Pc_003D = new _0023_003Dz0AB_S2XI_0024JM8xOABsA_003D_003D();
		Stream stream = new MemoryStream(_0023_003DzEBnCHDkN86Zx);
		try
		{
			BinaryReader binaryReader = new BinaryReader(stream);
			try
			{
				_0023_003Dz8Vwa6Pc_003D._0023_003DzNaZfx10_003D = binaryReader.ReadByte();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzMbtCZBg_003D = binaryReader.ReadByte();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzfMOL2E_0024F0iBbZ3RI8w_003D_003D = binaryReader.ReadUInt16();
				_0023_003Dz8Vwa6Pc_003D._0023_003DzXetXdncvj9ZeCm4oeA_003D_003D = binaryReader.ReadUInt16();
				_0023_003Dzmm_B7W0_003D = binaryReader.ReadBytes(_0023_003DzQYBuDLs_003D);
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)stream).Dispose();
		}
	}

	public long _0023_003Dz2T_VTbnfNhS9AzofsCm3QZ4_003D(int _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D)
	{
		_0023_003Dzt7Y0eIkmcJcSPolnZQ_003D_003D(_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, out var _0023_003DzCGqlNAU_003D);
		return _0023_003DzCGqlNAU_003D;
	}

	public byte[] _0023_003Dzt7Y0eIkmcJcSPolnZQ_003D_003D(int _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D, out long _0023_003DzCGqlNAU_003D)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003Dzmm_B7W0_003D);
		try
		{
			BinaryReader binaryReader = new BinaryReader(memoryStream);
			try
			{
				ushort[] array = new ushort[_0023_003Dz8Vwa6Pc_003D._0023_003DzXetXdncvj9ZeCm4oeA_003D_003D];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = binaryReader.ReadUInt16();
				}
				int num = _0023_003Dz8Vwa6Pc_003D._0023_003DzXetXdncvj9ZeCm4oeA_003D_003D * 2;
				memoryStream.Seek(num, SeekOrigin.Begin);
				byte[] sourceArray = binaryReader.ReadBytes(_0023_003Dzmm_B7W0_003D.Length - num);
				int num2 = 0;
				for (int j = 0; j < _0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D; j++)
				{
					num2 += array[j];
				}
				_0023_003DzCGqlNAU_003D = array[_0023_003Dz1jrm9N_0024UfoLGZQPQWwCBF9Q_003D];
				byte[] array2 = new byte[_0023_003Dzmm_B7W0_003D.Length - num + 1];
				Array.Copy(sourceArray, num2, array2, 0, _0023_003Dzmm_B7W0_003D.Length - num - num2);
				return array2;
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}
}
