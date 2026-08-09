using System.IdentityModel.Claims;
using System.Xml;

namespace System.ServiceModel;

public class DnsEndpointIdentity : EndpointIdentity
{
	public DnsEndpointIdentity(string dnsName)
	{
		if (dnsName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("dnsName");
		}
		Initialize(Claim.CreateDnsClaim(dnsName));
	}

	public DnsEndpointIdentity(Claim identity)
	{
		if (identity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identity");
		}
		if (!identity.ClaimType.Equals(ClaimTypes.Dns))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.UnrecognizedClaimTypeForIdentity, identity.ClaimType, ClaimTypes.Dns));
		}
		Initialize(identity);
	}

	internal override void WriteContentsTo(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		writer.WriteElementString(XD.AddressingDictionary.Dns, XD.AddressingDictionary.IdentityExtensionNamespace, (string)base.IdentityClaim.Resource);
	}
}
