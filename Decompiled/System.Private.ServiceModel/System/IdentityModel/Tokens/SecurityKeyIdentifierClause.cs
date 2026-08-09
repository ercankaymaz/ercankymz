using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public abstract class SecurityKeyIdentifierClause
{
	private byte[] _derivationNonce;

	private string _id;

	public virtual bool CanCreateKey => false;

	public string ClauseType { get; }

	public string Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public int DerivationLength { get; }

	protected SecurityKeyIdentifierClause(string clauseType)
		: this(clauseType, null, 0)
	{
	}

	protected SecurityKeyIdentifierClause(string clauseType, byte[] nonce, int length)
	{
		ClauseType = clauseType;
		_derivationNonce = nonce;
		DerivationLength = length;
	}

	public virtual SecurityKey CreateKey()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.KeyIdentifierClauseDoesNotSupportKeyCreation));
	}

	public virtual bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		return this == keyIdentifierClause;
	}

	public byte[] GetDerivationNonce()
	{
		if (_derivationNonce == null)
		{
			return null;
		}
		return (byte[])_derivationNonce.Clone();
	}
}
