using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Security.Tokens;

internal sealed class DerivedKeySecurityToken : SecurityToken
{
	private static readonly byte[] s_DefaultLabel = new byte[42]
	{
		87, 83, 45, 83, 101, 99, 117, 114, 101, 67,
		111, 110, 118, 101, 114, 115, 97, 116, 105, 111,
		110, 87, 83, 45, 83, 101, 99, 117, 114, 101,
		67, 111, 110, 118, 101, 114, 115, 97, 116, 105,
		111, 110
	};

	public const int DefaultNonceLength = 16;

	public const int DefaultDerivedKeyLength = 32;

	private string _id;

	private byte[] _key;

	private string _label;

	private byte[] _nonce;

	private ReadOnlyCollection<SecurityKey> _securityKeys;

	public override string Id => _id;

	public override DateTime ValidFrom => TokenToDerive.ValidFrom;

	public override DateTime ValidTo => TokenToDerive.ValidTo;

	public string KeyDerivationAlgorithm { get; private set; }

	public int Generation { get; private set; } = -1;

	public string Label => _label;

	public int Length { get; private set; } = -1;

	internal byte[] Nonce => _nonce;

	public int Offset { get; private set; } = -1;

	internal SecurityToken TokenToDerive { get; private set; }

	internal SecurityKeyIdentifierClause TokenToDeriveIdentifier { get; private set; }

	public override ReadOnlyCollection<SecurityKey> SecurityKeys
	{
		get
		{
			if (_securityKeys == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.DerivedKeyNotInitialized));
			}
			return _securityKeys;
		}
	}

	internal DerivedKeySecurityToken(int generation, int offset, int length, string label, int minNonceLength, SecurityToken tokenToDerive, SecurityKeyIdentifierClause tokenToDeriveIdentifier, string derivationAlgorithm, string id)
	{
		byte[] array = new byte[minNonceLength];
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		rNGCryptoServiceProvider.GetBytes(array);
		Initialize(id, generation, offset, length, label, array, tokenToDerive, tokenToDeriveIdentifier, derivationAlgorithm);
	}

	internal DerivedKeySecurityToken(int generation, int offset, int length, string label, byte[] nonce, SecurityToken tokenToDerive, SecurityKeyIdentifierClause tokenToDeriveIdentifier, string derivationAlgorithm, string id)
	{
		Initialize(id, generation, offset, length, label, nonce, tokenToDerive, tokenToDeriveIdentifier, derivationAlgorithm, initializeDerivedKey: false);
	}

	public byte[] GetKeyBytes()
	{
		return SecurityUtils.CloneBuffer(_key);
	}

	public byte[] GetNonce()
	{
		return SecurityUtils.CloneBuffer(_nonce);
	}

	internal bool TryGetSecurityKeys(out ReadOnlyCollection<SecurityKey> keys)
	{
		keys = _securityKeys;
		return keys != null;
	}

	public override string ToString()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		stringWriter.WriteLine("DerivedKeySecurityToken:");
		stringWriter.WriteLine("   Generation: {0}", Generation);
		stringWriter.WriteLine("   Offset: {0}", Offset);
		stringWriter.WriteLine("   Length: {0}", Length);
		stringWriter.WriteLine("   Label: {0}", Label);
		stringWriter.WriteLine("   Nonce: {0}", Convert.ToBase64String(Nonce));
		stringWriter.WriteLine("   TokenToDeriveFrom:");
		using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
		{
			xmlTextWriter.Formatting = Formatting.Indented;
			SecurityStandardsManager.DefaultInstance.SecurityTokenSerializer.WriteKeyIdentifierClause(XmlDictionaryWriter.CreateDictionaryWriter(xmlTextWriter), TokenToDeriveIdentifier);
		}
		return stringWriter.ToString();
	}

	private void Initialize(string id, int generation, int offset, int length, string label, byte[] nonce, SecurityToken tokenToDerive, SecurityKeyIdentifierClause tokenToDeriveIdentifier, string derivationAlgorithm)
	{
		Initialize(id, generation, offset, length, label, nonce, tokenToDerive, tokenToDeriveIdentifier, derivationAlgorithm, initializeDerivedKey: true);
	}

	private void Initialize(string id, int generation, int offset, int length, string label, byte[] nonce, SecurityToken tokenToDerive, SecurityKeyIdentifierClause tokenToDeriveIdentifier, string derivationAlgorithm, bool initializeDerivedKey)
	{
		if (tokenToDerive == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenToDerive");
		}
		if (!SecurityUtils.IsSupportedAlgorithm(derivationAlgorithm, tokenToDerive))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.DerivedKeyCannotDeriveFromSecret));
		}
		if (length == -1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("length"));
		}
		if (offset == -1 && generation == -1)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.DerivedKeyPosAndGenNotSpecified);
		}
		if (offset >= 0 && generation >= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.DerivedKeyPosAndGenBothSpecified);
		}
		_id = id ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("id");
		_label = label;
		_nonce = nonce ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("nonce");
		Length = length;
		Offset = offset;
		Generation = generation;
		TokenToDerive = tokenToDerive;
		TokenToDeriveIdentifier = tokenToDeriveIdentifier ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenToDeriveIdentifier");
		KeyDerivationAlgorithm = derivationAlgorithm;
		if (initializeDerivedKey)
		{
			InitializeDerivedKey(Length);
		}
	}

	internal void InitializeDerivedKey(int maxKeyLength)
	{
		if (_key == null)
		{
			if (Length > maxKeyLength)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.DerivedKeyLengthTooLong, Length, maxKeyLength));
			}
			_key = SecurityUtils.GenerateDerivedKey(TokenToDerive, KeyDerivationAlgorithm, (_label != null) ? Encoding.UTF8.GetBytes(_label) : s_DefaultLabel, _nonce, Length * 8, (Offset >= 0) ? Offset : (Generation * Length));
			if (_key == null || _key.Length == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.DerivedKeyCannotDeriveFromSecret);
			}
			List<SecurityKey> list = new List<SecurityKey>(1);
			list.Add(new InMemorySymmetricSecurityKey(_key, cloneBuffer: false));
			_securityKeys = list.AsReadOnly();
		}
	}

	internal static void EnsureAcceptableOffset(int offset, int generation, int length, int maxOffset)
	{
		if (offset != -1)
		{
			if (offset > maxOffset)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyTokenOffsetTooHigh, offset, maxOffset)));
			}
			return;
		}
		int num = generation * length;
		if ((num < generation && num < length) || num > maxOffset)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new MessageSecurityException(System.SR.Format(System.SR.DerivedKeyTokenGenerationAndLengthTooHigh, generation, length, maxOffset)));
		}
	}
}
