using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace System.ServiceModel.Security.Tokens;

public class IssuedSecurityTokenParameters : SecurityTokenParameters
{
	internal struct AlternativeIssuerEndpoint
	{
		public EndpointAddress IssuerAddress;

		public EndpointAddress IssuerMetadataAddress;

		public Binding IssuerBinding;
	}

	internal const SecurityKeyType defaultKeyType = SecurityKeyType.SymmetricKey;

	internal const bool defaultUseStrTransform = false;

	private int _keySize;

	private SecurityKeyType _keyType;

	protected internal override bool HasAsymmetricKey => KeyType == SecurityKeyType.AsymmetricKey;

	public Collection<XmlElement> AdditionalRequestParameters { get; } = new Collection<XmlElement>();

	public MessageSecurityVersion DefaultMessageSecurityVersion { get; set; }

	internal Collection<AlternativeIssuerEndpoint> AlternativeIssuerEndpoints { get; } = new Collection<AlternativeIssuerEndpoint>();

	public EndpointAddress IssuerAddress { get; set; }

	public EndpointAddress IssuerMetadataAddress { get; set; }

	public Binding IssuerBinding { get; set; }

	public SecurityKeyType KeyType
	{
		get
		{
			return _keyType;
		}
		set
		{
			SecurityKeyTypeHelper.Validate(value);
			_keyType = value;
		}
	}

	public int KeySize
	{
		get
		{
			return _keySize;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.ValueMustBeNonNegative));
			}
			_keySize = value;
		}
	}

	public bool UseStrTransform { get; set; }

	public Collection<ClaimTypeRequirement> ClaimTypeRequirements { get; } = new Collection<ClaimTypeRequirement>();

	public string TokenType { get; set; }

	protected internal override bool SupportsClientAuthentication => true;

	protected internal override bool SupportsServerAuthentication => true;

	protected internal override bool SupportsClientWindowsIdentity => false;

	protected IssuedSecurityTokenParameters(IssuedSecurityTokenParameters other)
		: base(other)
	{
		DefaultMessageSecurityVersion = other.DefaultMessageSecurityVersion;
		IssuerAddress = other.IssuerAddress;
		_keyType = other._keyType;
		TokenType = other.TokenType;
		_keySize = other._keySize;
		UseStrTransform = other.UseStrTransform;
		foreach (XmlElement additionalRequestParameter in other.AdditionalRequestParameters)
		{
			AdditionalRequestParameters.Add((XmlElement)additionalRequestParameter.Clone());
		}
		foreach (ClaimTypeRequirement claimTypeRequirement in other.ClaimTypeRequirements)
		{
			ClaimTypeRequirements.Add(claimTypeRequirement);
		}
		if (other.IssuerBinding != null)
		{
			IssuerBinding = new CustomBinding(other.IssuerBinding);
		}
		IssuerMetadataAddress = other.IssuerMetadataAddress;
	}

	public IssuedSecurityTokenParameters()
		: this(null, null, null)
	{
	}

	public IssuedSecurityTokenParameters(string tokenType)
		: this(tokenType, null, null)
	{
	}

	public IssuedSecurityTokenParameters(string tokenType, EndpointAddress issuerAddress)
		: this(tokenType, issuerAddress, null)
	{
	}

	public IssuedSecurityTokenParameters(string tokenType, EndpointAddress issuerAddress, Binding issuerBinding)
	{
		TokenType = tokenType;
		IssuerAddress = issuerAddress;
		IssuerBinding = issuerBinding;
	}

	protected override SecurityTokenParameters CloneCore()
	{
		return new IssuedSecurityTokenParameters(this);
	}

	protected internal override SecurityKeyIdentifierClause CreateKeyIdentifierClause(SecurityToken token, SecurityTokenReferenceStyle referenceStyle)
	{
		if (token is GenericXmlSecurityToken)
		{
			return CreateGenericXmlTokenKeyIdentifierClause(token, referenceStyle);
		}
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(base.ToString());
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "TokenType: {0}", (TokenType == null) ? "null" : TokenType));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "KeyType: {0}", _keyType.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "KeySize: {0}", _keySize.ToString(CultureInfo.InvariantCulture)));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "IssuerAddress: {0}", (IssuerAddress == null) ? "null" : IssuerAddress.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "IssuerMetadataAddress: {0}", (IssuerMetadataAddress == null) ? "null" : IssuerMetadataAddress.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "DefaultMessgeSecurityVersion: {0}", (DefaultMessageSecurityVersion == null) ? "null" : DefaultMessageSecurityVersion.ToString()));
		stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "UseStrTransform: {0}", UseStrTransform.ToString()));
		if (IssuerBinding == null)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "IssuerBinding: null"));
		}
		else
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "IssuerBinding:"));
			BindingElementCollection bindingElementCollection = IssuerBinding.CreateBindingElements();
			for (int i = 0; i < bindingElementCollection.Count; i++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "  BindingElement[{0}]:", i.ToString(CultureInfo.InvariantCulture)));
				stringBuilder.AppendLine("    " + bindingElementCollection[i].ToString().Trim().Replace("\n", "\n    "));
			}
		}
		if (ClaimTypeRequirements.Count == 0)
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "ClaimTypeRequirements: none"));
		}
		else
		{
			stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "ClaimTypeRequirements:"));
			for (int j = 0; j < ClaimTypeRequirements.Count; j++)
			{
				stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "  {0}, optional={1}", ClaimTypeRequirements[j].ClaimType, ClaimTypeRequirements[j].IsOptional));
			}
		}
		return stringBuilder.ToString().Trim();
	}

	protected internal override void InitializeSecurityTokenRequirement(SecurityTokenRequirement requirement)
	{
		requirement.TokenType = TokenType;
		requirement.RequireCryptographicToken = true;
		requirement.KeyType = KeyType;
		if (requirement is ServiceModelSecurityTokenRequirement serviceModelSecurityTokenRequirement)
		{
			serviceModelSecurityTokenRequirement.DefaultMessageSecurityVersion = DefaultMessageSecurityVersion;
		}
		else
		{
			requirement.Properties[ServiceModelSecurityTokenRequirement.DefaultMessageSecurityVersionProperty] = DefaultMessageSecurityVersion;
		}
		if (KeySize > 0)
		{
			requirement.KeySize = KeySize;
		}
		requirement.Properties[ServiceModelSecurityTokenRequirement.IssuerAddressProperty] = IssuerAddress;
		if (IssuerBinding != null)
		{
			requirement.Properties[ServiceModelSecurityTokenRequirement.IssuerBindingProperty] = IssuerBinding;
		}
		requirement.Properties[ServiceModelSecurityTokenRequirement.IssuedSecurityTokenParametersProperty] = Clone();
	}
}
