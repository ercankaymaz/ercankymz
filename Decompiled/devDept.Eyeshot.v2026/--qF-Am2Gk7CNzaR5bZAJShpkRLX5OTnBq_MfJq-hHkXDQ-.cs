using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D : SymmetricAlgorithm
{
	private sealed class _0023_003DziDLVpbY_003D : ICryptoTransform, IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] m__0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003Dz5rQzobg_003D;

		public int InputBlockSize => 4;

		public int OutputBlockSize => 4;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0023_003DziDLVpbY_003D(byte[] _0023_003DziDLVpbY_003D, bool _0023_003Dz5rQzobg_003D)
		{
			this.m__0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
			this._0023_003Dz5rQzobg_003D = _0023_003Dz5rQzobg_003D;
		}

		public void Dispose()
		{
		}

		public int TransformBlock(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
		{
			if (_0023_003DzAvn2b38_003D % 4 != 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			for (int i = 0; i < _0023_003DzAvn2b38_003D; i += 4)
			{
				_0023_003DzO9XFKS_Air3_RKp1se72zayzpVhZivX5goEUxUWi74si(this.m__0023_003DziDLVpbY_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D + i, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D + i, this._0023_003Dz5rQzobg_003D);
			}
			return _0023_003DzAvn2b38_003D;
		}

		public byte[] TransformFinalBlock(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
		{
			byte[] array = new byte[_0023_003DzAvn2b38_003D];
			TransformBlock(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, array, 0);
			return array;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static byte[] m__0023_003DziDLVpbY_003D;

	public _0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D()
	{
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(32, 32, 0)
		};
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(80, 80, 0)
		};
		BlockSizeValue = 32;
		KeySizeValue = 80;
		ModeValue = CipherMode.ECB;
		PaddingValue = PaddingMode.None;
	}

	public _0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D(byte[] _0023_003DziDLVpbY_003D)
		: this()
	{
		Key = _0023_003DziDLVpbY_003D ?? throw new ArgumentNullException();
	}

	static _0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D()
	{
		_0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D.m__0023_003DziDLVpbY_003D = new byte[256]
		{
			163, 215, 9, 131, 248, 72, 246, 244, 179, 33,
			21, 120, 153, 177, 175, 249, 231, 45, 77, 138,
			206, 76, 202, 46, 82, 149, 217, 30, 78, 56,
			68, 40, 10, 223, 2, 160, 23, 241, 96, 104,
			18, 183, 122, 195, 233, 250, 61, 83, 150, 132,
			107, 186, 242, 99, 154, 25, 124, 174, 229, 245,
			247, 22, 106, 162, 57, 182, 123, 15, 193, 147,
			129, 27, 238, 180, 26, 234, 208, 145, 47, 184,
			85, 185, 218, 133, 63, 65, 191, 224, 90, 88,
			128, 95, 102, 11, 216, 144, 53, 213, 192, 167,
			51, 6, 101, 105, 69, 0, 148, 86, 109, 152,
			155, 118, 151, 252, 178, 194, 176, 254, 219, 32,
			225, 235, 214, 228, 221, 71, 74, 29, 66, 237,
			158, 110, 73, 60, 205, 67, 39, 210, 7, 212,
			222, 199, 103, 24, 137, 203, 48, 31, 141, 198,
			143, 170, 200, 116, 220, 201, 93, 92, 49, 164,
			112, 136, 97, 44, 159, 13, 43, 135, 80, 130,
			84, 100, 38, 125, 3, 64, 52, 75, 28, 115,
			209, 196, 253, 59, 204, 251, 127, 171, 230, 62,
			91, 165, 173, 4, 35, 156, 20, 81, 34, 240,
			41, 121, 113, 126, 255, 140, 14, 226, 12, 239,
			188, 114, 117, 111, 55, 161, 236, 211, 142, 98,
			139, 134, 16, 232, 8, 119, 17, 190, 146, 79,
			36, 197, 50, 54, 157, 207, 243, 166, 187, 172,
			94, 108, 169, 19, 87, 37, 181, 227, 189, 168,
			58, 1, 5, 89, 42, 70
		};
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
	{
		return new _0023_003DziDLVpbY_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
	{
		return new _0023_003DziDLVpbY_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D: true);
	}

	public override void GenerateIV()
	{
		throw new NotImplementedException();
	}

	public override void GenerateKey()
	{
		throw new NotImplementedException();
	}

	private static ushort _0023_003DzVrmsVHN7lilDihPhgdwD3zxu8qYEJxAhlmqjCD8_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, ushort _0023_003DzAvn2b38_003D)
	{
		byte b = (byte)(_0023_003DzAvn2b38_003D >> 8);
		byte b2 = (byte)_0023_003DzAvn2b38_003D;
		byte b3 = (byte)(_0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D.m__0023_003DziDLVpbY_003D[b2 ^ _0023_003DziDLVpbY_003D[4 * _0023_003Dz5rQzobg_003D % 10]] ^ b);
		byte b4 = (byte)(_0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D.m__0023_003DziDLVpbY_003D[b3 ^ _0023_003DziDLVpbY_003D[(4 * _0023_003Dz5rQzobg_003D + 1) % 10]] ^ b2);
		byte b5 = (byte)(_0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D.m__0023_003DziDLVpbY_003D[b4 ^ _0023_003DziDLVpbY_003D[(4 * _0023_003Dz5rQzobg_003D + 2) % 10]] ^ b3);
		byte b6 = (byte)(_0023_003DqF_0024Am2Gk7CNzaR5bZAJShpkRLX5OTnBq_MfJq_0024hHkXDQ_003D.m__0023_003DziDLVpbY_003D[b5 ^ _0023_003DziDLVpbY_003D[(4 * _0023_003Dz5rQzobg_003D + 3) % 10]] ^ b4);
		return (ushort)((b5 << 8) + b6);
	}

	private static void _0023_003DzO9XFKS_Air3_RKp1se72zayzpVhZivX5goEUxUWi74si(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D, bool _0023_003DzWYPqg2E_003D)
	{
		int num;
		int num2;
		if (_0023_003DzWYPqg2E_003D)
		{
			num = 1;
			num2 = 0;
		}
		else
		{
			num = -1;
			num2 = 23;
		}
		ushort num3 = (ushort)((_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D] << 8) + _0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 1]);
		ushort num4 = (ushort)((_0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 2] << 8) + _0023_003Dz5rQzobg_003D[_0023_003DzAvn2b38_003D + 3]);
		for (int i = 0; i < 12; i++)
		{
			num4 ^= (ushort)(_0023_003DzVrmsVHN7lilDihPhgdwD3zxu8qYEJxAhlmqjCD8_003D(_0023_003DziDLVpbY_003D, num2, num3) ^ num2);
			num2 += num;
			num3 ^= (ushort)(_0023_003DzVrmsVHN7lilDihPhgdwD3zxu8qYEJxAhlmqjCD8_003D(_0023_003DziDLVpbY_003D, num2, num4) ^ num2);
			num2 += num;
		}
		_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D] = (byte)(num4 >> 8);
		_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D + 1] = (byte)num4;
		_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D + 2] = (byte)(num3 >> 8);
		_0023_003DzR58imxw_003D[_0023_003DzmQTFaQA_003D + 3] = (byte)num3;
	}
}
