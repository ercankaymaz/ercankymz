using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Channels;
using System.Text;

namespace System.ServiceModel.Security.Tokens;

public class SecureConversationSecurityTokenParameters : SecurityTokenParameters
{
	internal const bool defaultRequireCancellation = true;

	internal const bool defaultCanRenewSession = true;

	private BindingContext _issuerBindingContext;

	private ChannelProtectionRequirements _bootstrapProtectionRequirements;

	protected internal override bool HasAsymmetricKey => false;

	public SecurityBindingElement BootstrapSecurityBindingElement { get; set; }

	internal BindingContext IssuerBindingContext
	{
		get
		{
			return _issuerBindingContext;
		}
		set
		{
			if (value != null)
			{
				value = value.Clone();
			}
			_issuerBindingContext = value;
		}
	}

	private ISecurityCapabilities BootstrapSecurityCapabilities => BootstrapSecurityBindingElement.GetIndividualProperty<ISecurityCapabilities>();

	public bool RequireCancellation { get; set; }

	public bool CanRenewSession { get; set; } = true;

	protected internal override bool SupportsClientAuthentication
	{
		get
		{
			if (BootstrapSecurityCapabilities != null)
			{
				return BootstrapSecurityCapabilities.SupportsClientAuthentication;
			}
			return false;
		}
	}

	protected internal override bool SupportsServerAuthentication
	{
		get
		{
			if (BootstrapSecurityCapabilities != null)
			{
				return BootstrapSecurityCapabilities.SupportsServerAuthentication;
			}
			return false;
		}
	}

	protected internal override bool SupportsClientWindowsIdentity
	{
		get
		{
			if (BootstrapSecurityCapabilities != null)
			{
				return BootstrapSecurityCapabilities.SupportsClientWindowsIdentity;
			}
			return false;
		}
	}

	protected SecureConversationSecurityTokenParameters(SecureConversationSecurityTokenParameters other)
		: base(other)
	{
		RequireCancellation = other.RequireCancellation;
		CanRenewSession = other.CanRenewSession;
		if (other.BootstrapSecurityBindingElement != null)
		{
			BootstrapSecurityBindingElement = (SecurityBindingElement)other.BootstrapSecurityBindingElement.Clone();
		}
		if (other._issuerBindingContext != null)
		{
			_issuerBindingContext = other._issuerBindingContext.Clone();
		}
	}

	public SecureConversationSecurityTokenParameters()
		: this(null, requireCancellation: true, null)
	{
	}

	public SecureConversationSecurityTokenParameters(SecurityBindingElement bootstrapSecurityBindingElement)
	{
		BootstrapSecurityBindingElement = bootstrapSecurityBindingElement;
	}

	public SecureConversationSecurityTokenParameters(SecurityBindingElement bootstrapSecurityBindingElement, bool requireCancellation, ChannelProtectionRequirements bootstrapProtectionRequirements)
		: this(bootstrapSecurityBindingElement, requireCancellation, canRenewSession: true, null)
	{
	}

	public SecureConversationSecurityTokenParameters(SecurityBindingElement bootstrapSecurityBindingElement, bool requireCancellation, bool canRenewSession, ChannelProtectionRequirements bootstrapProtectionRequirements)
	{
		BootstrapSecurityBindingElement = bootstrapSecurityBindingElement;
		CanRenewSession = canRenewSession;
		if (bootstrapProtectionRequirements != null)
		{
			_bootstrapProtectionRequirements = new ChannelProtectionRequirements(bootstrapProtectionRequirements);
		}
		else
		{
			_bootstrapProtectionRequirements = new ChannelProtectionRequirements();
			_bootstrapProtectionRequirements.IncomingEncryptionParts.AddParts(new MessagePartSpecification(isBodyIncluded: true));
			_bootstrapProtectionRequirements.IncomingSignatureParts.AddParts(new MessagePartSpecification(isBodyIncluded: true));
			_bootstrapProtectionRequirements.OutgoingEncryptionParts.AddParts(new MessagePartSpecification(isBodyIncluded: true));
			_bootstrapProtectionRequirements.OutgoingSignatureParts.AddParts(new MessagePartSpecification(isBodyIncluded: true));
		}
		RequireCancellation = requireCancellation;
	}

	protected override SecurityTokenParameters CloneCore()
	{
		return new SecureConversationSecurityTokenParameters(this);
	}

	protected internal override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
	{
		if (token is GenericXmlSecurityToken)
		{
			return CreateGenericXmlTokenKeyIdentifierClause(token, referenceStyle);
		}
		return CreateKeyIdentifierClause<SecurityContextKeyIdentifierClause, LocalIdKeyIdentifierClause>(token, referenceStyle);
	}

	protected internal override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
	{
		requirement.TokenType = ServiceModelSecurityTokenTypes.SecureConversation;
		requirement.KeyType = SecurityKeyType.SymmetricKey;
		requirement.RequireCryptographicToken = true;
		requirement.Properties[ServiceModelSecurityTokenRequirement.SupportSecurityContextCancellationProperty] = RequireCancellation;
		requirement.Properties[ServiceModelSecurityTokenRequirement.SecureConversationSecurityBindingElementProperty] = BootstrapSecurityBindingElement;
		requirement.Properties[ServiceModelSecurityTokenRequirement.IssuerBindingContextProperty] = IssuerBindingContext.Clone();
		requirement.Properties[ServiceModelSecurityTokenRequirement.IssuedSecurityTokenParametersProperty] = Clone();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(base.ToString());
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "RequireCancellation: {0}", RequireCancellation.ToString()));
		if (BootstrapSecurityBindingElement == null)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "BootstrapSecurityBindingElement: null"));
		}
		else
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "BootstrapSecurityBindingElement:"));
			stringBuilder.AppendLine("  " + BootstrapSecurityBindingElement.ToString().Trim().Replace("\n", "\n  "));
		}
		return stringBuilder.ToString().Trim();
	}
}
