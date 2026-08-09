using System.Globalization;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public sealed class EncryptedKeyIdentifierClause : BinaryKeyIdentifierClause
{
	private readonly string _encryptionMethod;

	public string CarriedKeyName { get; }

	public SecurityKeyIdentifier EncryptingKeyIdentifier { get; }

	public string EncryptionMethod => _encryptionMethod;

	public EncryptedKeyIdentifierClause(byte[] encryptedKey, string encryptionMethod)
		: this(encryptedKey, encryptionMethod, null)
	{
	}

	public EncryptedKeyIdentifierClause(byte[] encryptedKey, string encryptionMethod, SecurityKeyIdentifier encryptingKeyIdentifier)
		: this(encryptedKey, encryptionMethod, encryptingKeyIdentifier, null)
	{
	}

	public EncryptedKeyIdentifierClause(byte[] encryptedKey, string encryptionMethod, SecurityKeyIdentifier encryptingKeyIdentifier, string carriedKeyName)
		: this(encryptedKey, encryptionMethod, encryptingKeyIdentifier, carriedKeyName, cloneBuffer: true, null, 0)
	{
	}

	public EncryptedKeyIdentifierClause(byte[] encryptedKey, string encryptionMethod, SecurityKeyIdentifier encryptingKeyIdentifier, string carriedKeyName, byte[] derivationNonce, int derivationLength)
		: this(encryptedKey, encryptionMethod, encryptingKeyIdentifier, carriedKeyName, cloneBuffer: true, derivationNonce, derivationLength)
	{
	}

	internal EncryptedKeyIdentifierClause(byte[] encryptedKey, string encryptionMethod, SecurityKeyIdentifier encryptingKeyIdentifier, string carriedKeyName, bool cloneBuffer, byte[] derivationNonce, int derivationLength)
		: base("http://www.w3.org/2001/04/xmlenc#EncryptedKey", encryptedKey, cloneBuffer, derivationNonce, derivationLength)
	{
		CarriedKeyName = carriedKeyName;
		_encryptionMethod = encryptionMethod ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("encryptionMethod");
		EncryptingKeyIdentifier = encryptingKeyIdentifier;
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		EncryptedKeyIdentifierClause encryptedKeyIdentifierClause = keyIdentifierClause as EncryptedKeyIdentifierClause;
		if (this != encryptedKeyIdentifierClause)
		{
			return encryptedKeyIdentifierClause?.Matches(GetRawBuffer(), _encryptionMethod, CarriedKeyName) ?? false;
		}
		return true;
	}

	public bool Matches(byte[] encryptedKey, string encryptionMethod, string carriedKeyName)
	{
		if (Matches(encryptedKey) && _encryptionMethod == encryptionMethod)
		{
			return CarriedKeyName == carriedKeyName;
		}
		return false;
	}

	public byte[] GetEncryptedKey()
	{
		return GetBuffer();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "EncryptedKeyIdentifierClause(EncryptedKey = {0}, Method '{1}')", Convert.ToBase64String(GetRawBuffer()), EncryptionMethod);
	}
}
