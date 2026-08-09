using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security.Tokens;

internal sealed class DerivedKeySecurityTokenStub : SecurityToken
{
	private string _id;

	private string _derivationAlgorithm;

	private string _label;

	private int _length;

	private byte[] _nonce;

	private int _offset;

	private int _generation;

	public override string Id => _id;

	public override DateTime ValidFrom
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotImplementedException());
		}
	}

	public override DateTime ValidTo
	{
		get
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotImplementedException());
		}
	}

	public override ReadOnlyCollection<SecurityKey> SecurityKeys => null;

	public SecurityKeyIdentifierClause TokenToDeriveIdentifier { get; }

	public DerivedKeySecurityTokenStub(int generation, int offset, int length, string label, byte[] nonce, SecurityKeyIdentifierClause tokenToDeriveIdentifier, string derivationAlgorithm, string id)
	{
		_id = id;
		_generation = generation;
		_offset = offset;
		_length = length;
		_label = label;
		_nonce = nonce;
		TokenToDeriveIdentifier = tokenToDeriveIdentifier;
		_derivationAlgorithm = derivationAlgorithm;
	}

	public DerivedKeySecurityToken CreateToken(SecurityToken tokenToDerive, int maxKeyLength)
	{
		DerivedKeySecurityToken derivedKeySecurityToken = new DerivedKeySecurityToken(_generation, _offset, _length, _label, _nonce, tokenToDerive, TokenToDeriveIdentifier, _derivationAlgorithm, Id);
		derivedKeySecurityToken.InitializeDerivedKey(maxKeyLength);
		return derivedKeySecurityToken;
	}
}
