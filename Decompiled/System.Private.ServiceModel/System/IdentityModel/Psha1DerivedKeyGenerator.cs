using System.Runtime;
using System.Security.Cryptography;
using System.ServiceModel;

namespace System.IdentityModel;

internal sealed class Psha1DerivedKeyGenerator
{
	private sealed class ManagedPsha1
	{
		private byte[] _aValue;

		private byte[] _buffer;

		private byte[] _chunk;

		private KeyedHashAlgorithm _hmac;

		private int _index;

		private int _position;

		private byte[] _secret;

		private byte[] _seed;

		public ManagedPsha1(byte[] secret, byte[] label, byte[] seed)
		{
			_secret = secret;
			checked
			{
				_seed = Fx.AllocateByteArray(label.Length + seed.Length);
				label.CopyTo(_seed, 0);
				seed.CopyTo(_seed, label.Length);
				_aValue = _seed;
				_chunk = new byte[0];
				_index = 0;
				_position = 0;
				_hmac = CryptoHelper.NewHmacSha1KeyedHashAlgorithm(secret);
				_buffer = Fx.AllocateByteArray(unchecked(_hmac.HashSize / 8) + _seed.Length);
			}
		}

		public byte[] GetDerivedKey(int derivedKeySize, int position)
		{
			if (derivedKeySize < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("derivedKeySize", System.SR.ValueMustBeNonNegative));
			}
			if (_position > position)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("position", System.SR.Format(System.SR.ValueMustBeInRange, 0, _position)));
			}
			while (_position < position)
			{
				GetByte();
			}
			int num = derivedKeySize / 8;
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = GetByte();
			}
			return array;
		}

		private byte GetByte()
		{
			if (_index >= _chunk.Length)
			{
				_hmac.Initialize();
				_aValue = _hmac.ComputeHash(_aValue);
				_aValue.CopyTo(_buffer, 0);
				_seed.CopyTo(_buffer, _aValue.Length);
				_hmac.Initialize();
				_chunk = _hmac.ComputeHash(_buffer);
				_index = 0;
			}
			_position++;
			return _chunk[_index++];
		}
	}

	private byte[] _key;

	public Psha1DerivedKeyGenerator(byte[] key)
	{
		_key = key ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("key");
	}

	public byte[] GenerateDerivedKey(byte[] label, byte[] nonce, int derivedKeySize, int position)
	{
		if (label == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("label");
		}
		if (nonce == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("nonce");
		}
		ManagedPsha1 managedPsha = new ManagedPsha1(_key, label, nonce);
		return managedPsha.GetDerivedKey(derivedKeySize, position);
	}
}
