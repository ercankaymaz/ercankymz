using System.Globalization;
using System.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Xml;

namespace System.ServiceModel.Security;

[TypeForwardedFrom("System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SecurityContextKeyIdentifierClause : SecurityKeyIdentifierClause
{
	private readonly UniqueId _generation;

	public UniqueId ContextId { get; }

	public UniqueId Generation => _generation;

	public SecurityContextKeyIdentifierClause(UniqueId contextId)
		: this(contextId, null)
	{
	}

	public SecurityContextKeyIdentifierClause(UniqueId contextId, UniqueId generation)
		: this(contextId, generation, null, 0)
	{
	}

	public SecurityContextKeyIdentifierClause(UniqueId contextId, UniqueId generation, byte[] derivationNonce, int derivationLength)
		: base(null, derivationNonce, derivationLength)
	{
		ContextId = contextId ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contextId");
		_generation = generation;
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		SecurityContextKeyIdentifierClause securityContextKeyIdentifierClause = keyIdentifierClause as SecurityContextKeyIdentifierClause;
		if (this != securityContextKeyIdentifierClause)
		{
			return securityContextKeyIdentifierClause?.Matches(ContextId, _generation) ?? false;
		}
		return true;
	}

	public bool Matches(UniqueId contextId, UniqueId generation)
	{
		if (contextId == ContextId)
		{
			return generation == _generation;
		}
		return false;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "SecurityContextKeyIdentifierClause(ContextId = '{0}', Generation = '{1}')", ContextId, Generation);
	}
}
