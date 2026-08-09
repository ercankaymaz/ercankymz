using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D : SymmetricAlgorithm
{
	private sealed class _0023_003Dz5rQzobg_003D : ICryptoTransform, IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] _0023_003DziDLVpbY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] m__0023_003Dz5rQzobg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly SymmetricAlgorithm[] _0023_003DzAvn2b38_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ICryptoTransform[] _0023_003DzR58imxw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzmQTFaQA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzWYPqg2E_003D;

		public int InputBlockSize => _0023_003DzWYPqg2E_003D;

		public int OutputBlockSize => _0023_003DzWYPqg2E_003D;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0023_003Dz5rQzobg_003D(SymmetricAlgorithm[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, byte[] _0023_003DzAvn2b38_003D, bool _0023_003DzR58imxw_003D)
		{
			this._0023_003DziDLVpbY_003D = _0023_003Dz5rQzobg_003D;
			this.m__0023_003Dz5rQzobg_003D = _0023_003DzAvn2b38_003D;
			this._0023_003DzAvn2b38_003D = _0023_003DziDLVpbY_003D;
			_0023_003DzmQTFaQA_003D = _0023_003DzR58imxw_003D;
			_0023_003DzWYPqg2E_003D = _0023_003DziDLVpbY_003D[^1].BlockSize / 8;
		}

		public void Dispose()
		{
			if (_0023_003DzR58imxw_003D != null)
			{
				ICryptoTransform[] array = _0023_003DzR58imxw_003D;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Dispose();
				}
				_0023_003DzR58imxw_003D = null;
			}
		}

		private void _0023_003Dzjftu3doj_0024yzrAj9qAy_0024__0024jueX8ZULOVqoQ_003D_003D()
		{
			SymmetricAlgorithm[] array = _0023_003DzAvn2b38_003D;
			int num = array.Length;
			if (_0023_003DzR58imxw_003D == null)
			{
				ICryptoTransform[] array2 = new ICryptoTransform[num];
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					SymmetricAlgorithm symmetricAlgorithm = array[i];
					int num3 = symmetricAlgorithm.KeySize / 8;
					byte[] array3 = new byte[num3];
					Buffer.BlockCopy(_0023_003DziDLVpbY_003D, num2, array3, 0, num3);
					num2 += num3;
					byte[] rgbIV = new byte[symmetricAlgorithm.BlockSize / 8];
					ICryptoTransform cryptoTransform = (_0023_003DzmQTFaQA_003D ? symmetricAlgorithm.CreateEncryptor(array3, rgbIV) : symmetricAlgorithm.CreateDecryptor(array3, rgbIV));
					array2[i] = cryptoTransform;
				}
				_0023_003DzR58imxw_003D = array2;
			}
		}

		public byte[] TransformFinalBlock(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
		{
			byte[] result = new byte[_0023_003DzAvn2b38_003D];
			TransformBlock(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D, result, 0);
			return result;
		}

		public int TransformBlock(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D, byte[] _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
		{
			Buffer.BlockCopy(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzAvn2b38_003D);
			_0023_003Dzjftu3doj_0024yzrAj9qAy_0024__0024jueX8ZULOVqoQ_003D_003D();
			if (this._0023_003DzmQTFaQA_003D)
			{
				_0023_003DzDHuCMeKLNB29aP7IPsbtQv8_003D(_0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzAvn2b38_003D);
			}
			else
			{
				_0023_003DzB9Xhfy0wTiYQdIudOLENjYmOR3EoLLmLclv7YKE_003D(_0023_003DzR58imxw_003D, _0023_003DzmQTFaQA_003D, _0023_003DzAvn2b38_003D);
			}
			return _0023_003DzAvn2b38_003D;
		}

		private void _0023_003DzDHuCMeKLNB29aP7IPsbtQv8_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
		{
			byte[] array = new byte[this.m__0023_003Dz5rQzobg_003D.Length];
			Buffer.BlockCopy(this.m__0023_003Dz5rQzobg_003D, 0, array, 0, array.Length);
			int num = 0;
			ICryptoTransform[] array2 = _0023_003DzR58imxw_003D;
			foreach (ICryptoTransform cryptoTransform in array2)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003DzAvn2b38_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003Dz5rQzobg_003D;
					_0023_003Dz0JR_hV3FnxikMKLft03SdSI_003D(_0023_003DziDLVpbY_003D, num4, array, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003DziDLVpbY_003D, num4, inputBlockSize, _0023_003DziDLVpbY_003D, num4);
					Buffer.BlockCopy(_0023_003DziDLVpbY_003D, num4, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003DzAvn2b38_003D)
				{
					break;
				}
			}
		}

		private void _0023_003DzB9Xhfy0wTiYQdIudOLENjYmOR3EoLLmLclv7YKE_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, int _0023_003DzAvn2b38_003D)
		{
			byte[] array = new byte[this.m__0023_003Dz5rQzobg_003D.Length];
			Buffer.BlockCopy(this.m__0023_003Dz5rQzobg_003D, 0, array, 0, array.Length);
			byte[] array2 = new byte[array.Length];
			int num = 0;
			ICryptoTransform[] array3 = _0023_003DzR58imxw_003D;
			foreach (ICryptoTransform cryptoTransform in array3)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003DzAvn2b38_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003Dz5rQzobg_003D;
					Buffer.BlockCopy(_0023_003DziDLVpbY_003D, num4, array2, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003DziDLVpbY_003D, num4, inputBlockSize, _0023_003DziDLVpbY_003D, num4);
					_0023_003Dz0JR_hV3FnxikMKLft03SdSI_003D(_0023_003DziDLVpbY_003D, num4, array, 0, inputBlockSize);
					Buffer.BlockCopy(array2, 0, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003DzAvn2b38_003D)
				{
					break;
				}
			}
		}

		private static void _0023_003Dz0JR_hV3FnxikMKLft03SdSI_003D(byte[] _0023_003DziDLVpbY_003D, int _0023_003Dz5rQzobg_003D, byte[] _0023_003DzAvn2b38_003D, int _0023_003DzR58imxw_003D, int _0023_003DzmQTFaQA_003D)
		{
			for (int i = 0; i < _0023_003DzmQTFaQA_003D; i++)
			{
				_0023_003DziDLVpbY_003D[_0023_003Dz5rQzobg_003D + i] ^= _0023_003DzAvn2b38_003D[_0023_003DzR58imxw_003D + i];
			}
		}
	}

	[Serializable]
	private sealed class _0023_003DziDLVpbY_003D
	{
		public static readonly _0023_003DziDLVpbY_003D _0023_003DziDLVpbY_003D = new _0023_003DziDLVpbY_003D();

		public static Comparison<SymmetricAlgorithm> _0023_003Dz5rQzobg_003D;

		internal int _0023_003Dzxu7sFYj6T3LPIFN_0024dM4GCbA_003D(SymmetricAlgorithm _0023_003DziDLVpbY_003D, SymmetricAlgorithm _0023_003Dz5rQzobg_003D)
		{
			return _0023_003Dz5rQzobg_003D.BlockSize.CompareTo(_0023_003DziDLVpbY_003D.BlockSize);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SymmetricAlgorithm[] m__0023_003DziDLVpbY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int m__0023_003Dz5rQzobg_003D;

	public override byte[] IV
	{
		get
		{
			return base.IV;
		}
		set
		{
			IVValue = (byte[])value.Clone();
		}
	}

	public _0023_003Dql5pn6xf4_RjccikWJ_0024R4_0024vHZ9OKLMWmwSRl0R70mw60_003D(params SymmetricAlgorithm[] _0023_003DziDLVpbY_003D)
	{
		_0023_003DziDLVpbY_003D = (SymmetricAlgorithm[])_0023_003DziDLVpbY_003D.Clone();
		Array.Sort(_0023_003DziDLVpbY_003D, (SymmetricAlgorithm symmetricAlgorithm3, SymmetricAlgorithm symmetricAlgorithm2) => symmetricAlgorithm2.BlockSize.CompareTo(symmetricAlgorithm3.BlockSize));
		this.m__0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
		int num = 0;
		SymmetricAlgorithm[] array = _0023_003DziDLVpbY_003D;
		foreach (SymmetricAlgorithm symmetricAlgorithm in array)
		{
			num += symmetricAlgorithm.KeySize;
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.None;
		}
		BlockSizeValue = _0023_003DziDLVpbY_003D[^1].BlockSize;
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(BlockSizeValue, BlockSizeValue, 0)
		};
		KeySizeValue = num;
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(num, num, 0)
		};
		this.m__0023_003Dz5rQzobg_003D = _0023_003DziDLVpbY_003D[0].BlockSize;
		Mode = CipherMode.ECB;
		Padding = PaddingMode.None;
	}

	public int _0023_003Dz7Mma8g0M4x5oxCURI3UoRMQ_003D()
	{
		return this.m__0023_003Dz5rQzobg_003D;
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
	{
		return _0023_003Dz7QEzQ_0024hOaVvFCdDITxXqMoXpf4sQY2E27wDxwQ4_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D)
	{
		return _0023_003Dz7QEzQ_0024hOaVvFCdDITxXqMoXpf4sQY2E27wDxwQ4_003D(_0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D: true);
	}

	private ICryptoTransform _0023_003Dz7QEzQ_0024hOaVvFCdDITxXqMoXpf4sQY2E27wDxwQ4_003D(byte[] _0023_003DziDLVpbY_003D, byte[] _0023_003Dz5rQzobg_003D, bool _0023_003DzAvn2b38_003D)
	{
		if (_0023_003DziDLVpbY_003D.Length * 8 != KeySize)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909754), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909714));
		}
		if (_0023_003Dz5rQzobg_003D.Length * 8 != _0023_003Dz7Mma8g0M4x5oxCURI3UoRMQ_003D())
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909723), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909940));
		}
		return new _0023_003Dz5rQzobg_003D(this.m__0023_003DziDLVpbY_003D, _0023_003DziDLVpbY_003D, _0023_003Dz5rQzobg_003D, _0023_003DzAvn2b38_003D);
	}

	public override void GenerateIV()
	{
		throw new NotSupportedException();
	}

	public override void GenerateKey()
	{
		throw new NotSupportedException();
	}
}
