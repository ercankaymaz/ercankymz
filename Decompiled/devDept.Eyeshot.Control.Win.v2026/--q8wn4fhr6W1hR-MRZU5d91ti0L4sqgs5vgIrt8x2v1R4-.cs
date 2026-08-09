using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D : SymmetricAlgorithm
{
	private sealed class _0023_003DzVC9FBdo_003D : ICryptoTransform, IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] _0023_003DzjYYAPCA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] m__0023_003DzVC9FBdo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly SymmetricAlgorithm[] _0023_003DzwBouG0w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ICryptoTransform[] _0023_003Dzf4Pqh9s_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzTFNDoh0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzraVZG9g_003D;

		public int InputBlockSize => _0023_003DzraVZG9g_003D;

		public int OutputBlockSize => _0023_003DzraVZG9g_003D;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0023_003DzVC9FBdo_003D(SymmetricAlgorithm[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, byte[] _0023_003DzwBouG0w_003D, bool _0023_003Dzf4Pqh9s_003D)
		{
			this._0023_003DzjYYAPCA_003D = _0023_003DzVC9FBdo_003D;
			this.m__0023_003DzVC9FBdo_003D = _0023_003DzwBouG0w_003D;
			this._0023_003DzwBouG0w_003D = _0023_003DzjYYAPCA_003D;
			_0023_003DzTFNDoh0_003D = _0023_003Dzf4Pqh9s_003D;
			_0023_003DzraVZG9g_003D = _0023_003DzjYYAPCA_003D[_0023_003DzjYYAPCA_003D.Length - 1].BlockSize / 8;
		}

		public void Dispose()
		{
			if (_0023_003Dzf4Pqh9s_003D != null)
			{
				ICryptoTransform[] array = _0023_003Dzf4Pqh9s_003D;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Dispose();
				}
				_0023_003Dzf4Pqh9s_003D = null;
			}
		}

		private void _0023_003DzHfyhIAwysh4YSGydIhjrBhiN3XqLYTAV0Q_003D_003D()
		{
			SymmetricAlgorithm[] array = _0023_003DzwBouG0w_003D;
			int num = array.Length;
			if (_0023_003Dzf4Pqh9s_003D == null)
			{
				ICryptoTransform[] array2 = new ICryptoTransform[num];
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					SymmetricAlgorithm symmetricAlgorithm = array[i];
					int num3 = symmetricAlgorithm.KeySize / 8;
					byte[] array3 = new byte[num3];
					Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, num2, array3, 0, num3);
					num2 += num3;
					byte[] rgbIV = new byte[symmetricAlgorithm.BlockSize / 8];
					ICryptoTransform cryptoTransform = (_0023_003DzTFNDoh0_003D ? symmetricAlgorithm.CreateEncryptor(array3, rgbIV) : symmetricAlgorithm.CreateDecryptor(array3, rgbIV));
					array2[i] = cryptoTransform;
				}
				_0023_003Dzf4Pqh9s_003D = array2;
			}
		}

		public byte[] TransformFinalBlock(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
		{
			byte[] result = new byte[_0023_003DzwBouG0w_003D];
			TransformBlock(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D, result, 0);
			return result;
		}

		public int TransformBlock(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D, byte[] _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
		{
			Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzwBouG0w_003D);
			_0023_003DzHfyhIAwysh4YSGydIhjrBhiN3XqLYTAV0Q_003D_003D();
			if (this._0023_003DzTFNDoh0_003D)
			{
				_0023_003Dz8gmENCLpAUpEMoccRs7IkyI_003D(_0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzwBouG0w_003D);
			}
			else
			{
				_0023_003DzO4XbII8aepFI6cC95865h_8CmSEB7zEpQRLt5Co_003D(_0023_003Dzf4Pqh9s_003D, _0023_003DzTFNDoh0_003D, _0023_003DzwBouG0w_003D);
			}
			return _0023_003DzwBouG0w_003D;
		}

		private void _0023_003Dz8gmENCLpAUpEMoccRs7IkyI_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
		{
			byte[] array = new byte[this.m__0023_003DzVC9FBdo_003D.Length];
			Buffer.BlockCopy(this.m__0023_003DzVC9FBdo_003D, 0, array, 0, array.Length);
			int num = 0;
			ICryptoTransform[] array2 = _0023_003Dzf4Pqh9s_003D;
			foreach (ICryptoTransform cryptoTransform in array2)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003DzwBouG0w_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003DzVC9FBdo_003D;
					_0023_003DzQnvWmP9A2ZandYwUlV5Xne0_003D(_0023_003DzjYYAPCA_003D, num4, array, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003DzjYYAPCA_003D, num4, inputBlockSize, _0023_003DzjYYAPCA_003D, num4);
					Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, num4, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003DzwBouG0w_003D)
				{
					break;
				}
			}
		}

		private void _0023_003DzO4XbII8aepFI6cC95865h_8CmSEB7zEpQRLt5Co_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, int _0023_003DzwBouG0w_003D)
		{
			byte[] array = new byte[this.m__0023_003DzVC9FBdo_003D.Length];
			Buffer.BlockCopy(this.m__0023_003DzVC9FBdo_003D, 0, array, 0, array.Length);
			byte[] array2 = new byte[array.Length];
			int num = 0;
			ICryptoTransform[] array3 = _0023_003Dzf4Pqh9s_003D;
			foreach (ICryptoTransform cryptoTransform in array3)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003DzwBouG0w_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003DzVC9FBdo_003D;
					Buffer.BlockCopy(_0023_003DzjYYAPCA_003D, num4, array2, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003DzjYYAPCA_003D, num4, inputBlockSize, _0023_003DzjYYAPCA_003D, num4);
					_0023_003DzQnvWmP9A2ZandYwUlV5Xne0_003D(_0023_003DzjYYAPCA_003D, num4, array, 0, inputBlockSize);
					Buffer.BlockCopy(array2, 0, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003DzwBouG0w_003D)
				{
					break;
				}
			}
		}

		private static void _0023_003DzQnvWmP9A2ZandYwUlV5Xne0_003D(byte[] _0023_003DzjYYAPCA_003D, int _0023_003DzVC9FBdo_003D, byte[] _0023_003DzwBouG0w_003D, int _0023_003Dzf4Pqh9s_003D, int _0023_003DzTFNDoh0_003D)
		{
			for (int i = 0; i < _0023_003DzTFNDoh0_003D; i++)
			{
				_0023_003DzjYYAPCA_003D[_0023_003DzVC9FBdo_003D + i] ^= _0023_003DzwBouG0w_003D[_0023_003Dzf4Pqh9s_003D + i];
			}
		}
	}

	[Serializable]
	private sealed class _0023_003DzjYYAPCA_003D
	{
		public static readonly _0023_003DzjYYAPCA_003D _0023_003DzjYYAPCA_003D = new _0023_003DzjYYAPCA_003D();

		public static Comparison<SymmetricAlgorithm> _0023_003DzVC9FBdo_003D;

		internal int _0023_003DzwV3OqqXkDBkQ7F3RgEpaE7s_003D(SymmetricAlgorithm _0023_003DzjYYAPCA_003D, SymmetricAlgorithm _0023_003DzVC9FBdo_003D)
		{
			return _0023_003DzVC9FBdo_003D.BlockSize.CompareTo(_0023_003DzjYYAPCA_003D.BlockSize);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SymmetricAlgorithm[] m__0023_003DzjYYAPCA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int m__0023_003DzVC9FBdo_003D;

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

	public _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D(params SymmetricAlgorithm[] _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzjYYAPCA_003D = (SymmetricAlgorithm[])_0023_003DzjYYAPCA_003D.Clone();
		Array.Sort(_0023_003DzjYYAPCA_003D, _0023_003Dq8wn4fhr6W1hR_0024MRZU5d91ti0L4sqgs5vgIrt8x2v1R4_003D._0023_003DzjYYAPCA_003D._0023_003DzjYYAPCA_003D._0023_003DzwV3OqqXkDBkQ7F3RgEpaE7s_003D);
		this.m__0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
		int num = 0;
		SymmetricAlgorithm[] array = _0023_003DzjYYAPCA_003D;
		foreach (SymmetricAlgorithm symmetricAlgorithm in array)
		{
			num += symmetricAlgorithm.KeySize;
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.None;
		}
		BlockSizeValue = _0023_003DzjYYAPCA_003D[_0023_003DzjYYAPCA_003D.Length - 1].BlockSize;
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(BlockSizeValue, BlockSizeValue, 0)
		};
		KeySizeValue = num;
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(num, num, 0)
		};
		this.m__0023_003DzVC9FBdo_003D = _0023_003DzjYYAPCA_003D[0].BlockSize;
		Mode = CipherMode.ECB;
		Padding = PaddingMode.None;
	}

	public int _0023_003DztYcYBAC4dcSo6fQS7a0CWBo_003D()
	{
		return this.m__0023_003DzVC9FBdo_003D;
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D)
	{
		return _0023_003DzM37rxJ9Jz9_VapY8PVGCX7BzO327sVKoReVNQ5U_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D)
	{
		return _0023_003DzM37rxJ9Jz9_VapY8PVGCX7BzO327sVKoReVNQ5U_003D(_0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D: true);
	}

	private ICryptoTransform _0023_003DzM37rxJ9Jz9_VapY8PVGCX7BzO327sVKoReVNQ5U_003D(byte[] _0023_003DzjYYAPCA_003D, byte[] _0023_003DzVC9FBdo_003D, bool _0023_003DzwBouG0w_003D)
	{
		if (_0023_003DzjYYAPCA_003D.Length * 8 != KeySize)
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622162), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348622202));
		}
		if (_0023_003DzVC9FBdo_003D.Length * 8 != _0023_003DztYcYBAC4dcSo6fQS7a0CWBo_003D())
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619407), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619416));
		}
		return new _0023_003DzVC9FBdo_003D(this.m__0023_003DzjYYAPCA_003D, _0023_003DzjYYAPCA_003D, _0023_003DzVC9FBdo_003D, _0023_003DzwBouG0w_003D);
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
