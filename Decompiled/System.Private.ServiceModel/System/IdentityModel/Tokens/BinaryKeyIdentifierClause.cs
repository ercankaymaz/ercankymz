using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public abstract class BinaryKeyIdentifierClause : SecurityKeyIdentifierClause
{
	private readonly byte[] _identificationData;

	protected BinaryKeyIdentifierClause(string clauseType, byte[] identificationData, bool cloneBuffer)
		: this(clauseType, identificationData, cloneBuffer, null, 0)
	{
	}

	protected BinaryKeyIdentifierClause(string clauseType, byte[] identificationData, bool cloneBuffer, byte[] derivationNonce, int derivationLength)
		: base(clauseType, derivationNonce, derivationLength)
	{
		if (identificationData == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("identificationData"));
		}
		if (identificationData.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("identificationData", System.SR.LengthMustBeGreaterThanZero));
		}
		if (cloneBuffer)
		{
			_identificationData = SecurityUtils.CloneBuffer(identificationData);
		}
		else
		{
			_identificationData = identificationData;
		}
	}

	public byte[] GetBuffer()
	{
		return SecurityUtils.CloneBuffer(_identificationData);
	}

	protected byte[] GetRawBuffer()
	{
		return _identificationData;
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		BinaryKeyIdentifierClause binaryKeyIdentifierClause = keyIdentifierClause as BinaryKeyIdentifierClause;
		if (this != binaryKeyIdentifierClause)
		{
			return binaryKeyIdentifierClause?.Matches(_identificationData) ?? false;
		}
		return true;
	}

	public bool Matches(byte[] data)
	{
		return Matches(data, 0);
	}

	public bool Matches(byte[] data, int offset)
	{
		if (offset < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset", System.SR.ValueMustBeNonNegative));
		}
		return SecurityUtils.MatchesBuffer(_identificationData, 0, data, offset);
	}

	internal string ToBase64String()
	{
		return Convert.ToBase64String(_identificationData);
	}

	internal string ToHexString()
	{
		return new SoapHexBinary(_identificationData).ToString();
	}
}
