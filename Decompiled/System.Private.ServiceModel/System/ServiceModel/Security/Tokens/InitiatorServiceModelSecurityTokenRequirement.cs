using System.Net;

namespace System.ServiceModel.Security.Tokens;

public sealed class InitiatorServiceModelSecurityTokenRequirement : ServiceModelSecurityTokenRequirement
{
	public EndpointAddress TargetAddress
	{
		get
		{
			return GetPropertyOrDefault<EndpointAddress>(ServiceModelSecurityTokenRequirement.TargetAddressProperty, null);
		}
		set
		{
			base.Properties[ServiceModelSecurityTokenRequirement.TargetAddressProperty] = value;
		}
	}

	public Uri Via
	{
		get
		{
			return GetPropertyOrDefault<Uri>(ServiceModelSecurityTokenRequirement.ViaProperty, null);
		}
		set
		{
			base.Properties[ServiceModelSecurityTokenRequirement.ViaProperty] = value;
		}
	}

	internal bool IsOutOfBandToken
	{
		get
		{
			return GetPropertyOrDefault(ServiceModelSecurityTokenRequirement.IsOutOfBandTokenProperty, defaultValue: false);
		}
		set
		{
			base.Properties[ServiceModelSecurityTokenRequirement.IsOutOfBandTokenProperty] = value;
		}
	}

	internal bool PreferSslCertificateAuthenticator
	{
		get
		{
			return GetPropertyOrDefault(ServiceModelSecurityTokenRequirement.PreferSslCertificateAuthenticatorProperty, defaultValue: false);
		}
		set
		{
			base.Properties[ServiceModelSecurityTokenRequirement.PreferSslCertificateAuthenticatorProperty] = value;
		}
	}

	internal WebHeaderCollection WebHeaders { get; set; }

	public InitiatorServiceModelSecurityTokenRequirement()
	{
		base.Properties.Add(ServiceModelSecurityTokenRequirement.IsInitiatorProperty, true);
	}

	public override string ToString()
	{
		return InternalToString();
	}
}
