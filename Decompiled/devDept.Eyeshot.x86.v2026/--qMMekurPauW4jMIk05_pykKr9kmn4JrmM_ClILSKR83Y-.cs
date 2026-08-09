using System;
using System.Diagnostics;
using System.Security.Cryptography;

internal sealed class _0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D : SymmetricAlgorithm
{
	private sealed class _0023_003DzZzVr6_0024U_003D : ICryptoTransform, IDisposable
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] _0023_003Dzq80RbjQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly byte[] m__0023_003DzZzVr6_0024U_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly SymmetricAlgorithm[] _0023_003Dz7hRN5Rg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ICryptoTransform[] _0023_003DzcbLoSrg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly bool _0023_003DzqMLoHoQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly int _0023_003DzuwE9t4w_003D;

		public int InputBlockSize => _0023_003DzuwE9t4w_003D;

		public int OutputBlockSize => _0023_003DzuwE9t4w_003D;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => true;

		public _0023_003DzZzVr6_0024U_003D(SymmetricAlgorithm[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, byte[] _0023_003Dz7hRN5Rg_003D, bool _0023_003DzcbLoSrg_003D)
		{
			this._0023_003Dzq80RbjQ_003D = _0023_003DzZzVr6_0024U_003D;
			this.m__0023_003DzZzVr6_0024U_003D = _0023_003Dz7hRN5Rg_003D;
			this._0023_003Dz7hRN5Rg_003D = _0023_003Dzq80RbjQ_003D;
			_0023_003DzqMLoHoQ_003D = _0023_003DzcbLoSrg_003D;
			_0023_003DzuwE9t4w_003D = _0023_003Dzq80RbjQ_003D[_0023_003Dzq80RbjQ_003D.Length - 1].BlockSize / 8;
		}

		public void Dispose()
		{
			if (_0023_003DzcbLoSrg_003D != null)
			{
				ICryptoTransform[] array = _0023_003DzcbLoSrg_003D;
				for (int i = 0; i < array.Length; i++)
				{
					array[i]?.Dispose();
				}
				_0023_003DzcbLoSrg_003D = null;
			}
		}

		private void _0023_003DztFjN0NK7IrqMVBv3O6Pyxb8NHI8d018D3g_003D_003D()
		{
			SymmetricAlgorithm[] array = _0023_003Dz7hRN5Rg_003D;
			int num = array.Length;
			if (_0023_003DzcbLoSrg_003D == null)
			{
				ICryptoTransform[] array2 = new ICryptoTransform[num];
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					SymmetricAlgorithm symmetricAlgorithm = array[i];
					int num3 = symmetricAlgorithm.KeySize / 8;
					byte[] array3 = new byte[num3];
					Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, num2, array3, 0, num3);
					num2 += num3;
					byte[] rgbIV = new byte[symmetricAlgorithm.BlockSize / 8];
					ICryptoTransform cryptoTransform = (_0023_003DzqMLoHoQ_003D ? symmetricAlgorithm.CreateEncryptor(array3, rgbIV) : symmetricAlgorithm.CreateDecryptor(array3, rgbIV));
					array2[i] = cryptoTransform;
				}
				_0023_003DzcbLoSrg_003D = array2;
			}
		}

		public byte[] TransformFinalBlock(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
		{
			byte[] result = new byte[_0023_003Dz7hRN5Rg_003D];
			TransformBlock(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D, result, 0);
			return result;
		}

		public int TransformBlock(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D, byte[] _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D)
		{
			Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003Dz7hRN5Rg_003D);
			_0023_003DztFjN0NK7IrqMVBv3O6Pyxb8NHI8d018D3g_003D_003D();
			if (this._0023_003DzqMLoHoQ_003D)
			{
				_0023_003DzwNk2KJukrOB4XEuTO06EtPk_003D(_0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003Dz7hRN5Rg_003D);
			}
			else
			{
				_0023_003DzdXGLNBP7yaVK1uNPYpj7lyXm7SJWcFEZ_0024RCJcFc_003D(_0023_003DzcbLoSrg_003D, _0023_003DzqMLoHoQ_003D, _0023_003Dz7hRN5Rg_003D);
			}
			return _0023_003Dz7hRN5Rg_003D;
		}

		private void _0023_003DzwNk2KJukrOB4XEuTO06EtPk_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
		{
			byte[] array = new byte[this.m__0023_003DzZzVr6_0024U_003D.Length];
			Buffer.BlockCopy(this.m__0023_003DzZzVr6_0024U_003D, 0, array, 0, array.Length);
			int num = 0;
			ICryptoTransform[] array2 = _0023_003DzcbLoSrg_003D;
			foreach (ICryptoTransform cryptoTransform in array2)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003Dz7hRN5Rg_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003DzZzVr6_0024U_003D;
					_0023_003Dz1FLj1mh3vh6eTIBd43xqPUk_003D(_0023_003Dzq80RbjQ_003D, num4, array, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003Dzq80RbjQ_003D, num4, inputBlockSize, _0023_003Dzq80RbjQ_003D, num4);
					Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, num4, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003Dz7hRN5Rg_003D)
				{
					break;
				}
			}
		}

		private void _0023_003DzdXGLNBP7yaVK1uNPYpj7lyXm7SJWcFEZ_0024RCJcFc_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, int _0023_003Dz7hRN5Rg_003D)
		{
			byte[] array = new byte[this.m__0023_003DzZzVr6_0024U_003D.Length];
			Buffer.BlockCopy(this.m__0023_003DzZzVr6_0024U_003D, 0, array, 0, array.Length);
			byte[] array2 = new byte[array.Length];
			int num = 0;
			ICryptoTransform[] array3 = _0023_003DzcbLoSrg_003D;
			foreach (ICryptoTransform cryptoTransform in array3)
			{
				int inputBlockSize = cryptoTransform.InputBlockSize;
				int num2 = (_0023_003Dz7hRN5Rg_003D - num) & ~(inputBlockSize - 1);
				int num3 = num + num2;
				for (int j = num; j < num3; j += inputBlockSize)
				{
					int num4 = j + _0023_003DzZzVr6_0024U_003D;
					Buffer.BlockCopy(_0023_003Dzq80RbjQ_003D, num4, array2, 0, inputBlockSize);
					cryptoTransform.TransformBlock(_0023_003Dzq80RbjQ_003D, num4, inputBlockSize, _0023_003Dzq80RbjQ_003D, num4);
					_0023_003Dz1FLj1mh3vh6eTIBd43xqPUk_003D(_0023_003Dzq80RbjQ_003D, num4, array, 0, inputBlockSize);
					Buffer.BlockCopy(array2, 0, array, 0, inputBlockSize);
				}
				num = num3;
				if (num3 == _0023_003Dz7hRN5Rg_003D)
				{
					break;
				}
			}
		}

		private static void _0023_003Dz1FLj1mh3vh6eTIBd43xqPUk_003D(byte[] _0023_003Dzq80RbjQ_003D, int _0023_003DzZzVr6_0024U_003D, byte[] _0023_003Dz7hRN5Rg_003D, int _0023_003DzcbLoSrg_003D, int _0023_003DzqMLoHoQ_003D)
		{
			for (int i = 0; i < _0023_003DzqMLoHoQ_003D; i++)
			{
				_0023_003Dzq80RbjQ_003D[_0023_003DzZzVr6_0024U_003D + i] ^= _0023_003Dz7hRN5Rg_003D[_0023_003DzcbLoSrg_003D + i];
			}
		}
	}

	[Serializable]
	private sealed class _0023_003Dzq80RbjQ_003D
	{
		public static readonly _0023_003Dzq80RbjQ_003D _0023_003Dzq80RbjQ_003D = new _0023_003Dzq80RbjQ_003D();

		public static Comparison<SymmetricAlgorithm> _0023_003DzZzVr6_0024U_003D;

		internal int _0023_003DzmR7huJ_0024tTqzVsht5ofGKgxU_003D(SymmetricAlgorithm _0023_003Dzq80RbjQ_003D, SymmetricAlgorithm _0023_003DzZzVr6_0024U_003D)
		{
			return _0023_003DzZzVr6_0024U_003D.BlockSize.CompareTo(_0023_003Dzq80RbjQ_003D.BlockSize);
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly SymmetricAlgorithm[] m__0023_003Dzq80RbjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int m__0023_003DzZzVr6_0024U_003D;

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

	public _0023_003DqMMekurPauW4jMIk05_pykKr9kmn4JrmM_ClILSKR83Y_003D(params SymmetricAlgorithm[] _0023_003Dzq80RbjQ_003D)
	{
		_0023_003Dzq80RbjQ_003D = (SymmetricAlgorithm[])_0023_003Dzq80RbjQ_003D.Clone();
		Array.Sort(_0023_003Dzq80RbjQ_003D, (SymmetricAlgorithm symmetricAlgorithm3, SymmetricAlgorithm symmetricAlgorithm2) => symmetricAlgorithm2.BlockSize.CompareTo(symmetricAlgorithm3.BlockSize));
		this.m__0023_003Dzq80RbjQ_003D = _0023_003Dzq80RbjQ_003D;
		int num = 0;
		SymmetricAlgorithm[] array = _0023_003Dzq80RbjQ_003D;
		foreach (SymmetricAlgorithm symmetricAlgorithm in array)
		{
			num += symmetricAlgorithm.KeySize;
			symmetricAlgorithm.Mode = CipherMode.ECB;
			symmetricAlgorithm.Padding = PaddingMode.None;
		}
		BlockSizeValue = _0023_003Dzq80RbjQ_003D[_0023_003Dzq80RbjQ_003D.Length - 1].BlockSize;
		LegalBlockSizesValue = new KeySizes[1]
		{
			new KeySizes(BlockSizeValue, BlockSizeValue, 0)
		};
		KeySizeValue = num;
		LegalKeySizesValue = new KeySizes[1]
		{
			new KeySizes(num, num, 0)
		};
		this.m__0023_003DzZzVr6_0024U_003D = _0023_003Dzq80RbjQ_003D[0].BlockSize;
		Mode = CipherMode.ECB;
		Padding = PaddingMode.None;
	}

	public int _0023_003Dz_0024KbFjgGgMMzh5q2AKcFFjpw_003D()
	{
		return this.m__0023_003DzZzVr6_0024U_003D;
	}

	public override ICryptoTransform CreateDecryptor(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D)
	{
		return _0023_003DzRu9mhv1yBYQc0VImHF9WAv7ryugxyKuE1MOS0G0_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D: false);
	}

	public override ICryptoTransform CreateEncryptor(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D)
	{
		return _0023_003DzRu9mhv1yBYQc0VImHF9WAv7ryugxyKuE1MOS0G0_003D(_0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D: true);
	}

	private ICryptoTransform _0023_003DzRu9mhv1yBYQc0VImHF9WAv7ryugxyKuE1MOS0G0_003D(byte[] _0023_003Dzq80RbjQ_003D, byte[] _0023_003DzZzVr6_0024U_003D, bool _0023_003Dz7hRN5Rg_003D)
	{
		if (_0023_003Dzq80RbjQ_003D.Length * 8 != KeySize)
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525363), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355525339));
		}
		if (_0023_003DzZzVr6_0024U_003D.Length * 8 != _0023_003Dz_0024KbFjgGgMMzh5q2AKcFFjpw_003D())
		{
			throw new ArgumentException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527982), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527993));
		}
		return new _0023_003DzZzVr6_0024U_003D(this.m__0023_003Dzq80RbjQ_003D, _0023_003Dzq80RbjQ_003D, _0023_003DzZzVr6_0024U_003D, _0023_003Dz7hRN5Rg_003D);
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
