using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Xml;

namespace System.ServiceModel;

public abstract class EndpointIdentity
{
	private Claim _identityClaim;

	private IEqualityComparer<Claim> _claimComparer;

	public Claim IdentityClaim
	{
		get
		{
			if (_identityClaim == null)
			{
				EnsureIdentityClaim();
			}
			return _identityClaim;
		}
	}

	protected void Initialize(Claim identityClaim)
	{
		if (identityClaim == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identityClaim");
		}
		Initialize(identityClaim, null);
	}

	protected void Initialize(Claim identityClaim, IEqualityComparer<Claim> claimComparer)
	{
		_identityClaim = identityClaim ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identityClaim");
		_claimComparer = claimComparer;
	}

	public static EndpointIdentity CreateIdentity(Claim identity)
	{
		if (identity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identity");
		}
		throw ExceptionHelper.PlatformNotSupported("EndpointIdentity.CreateIdentity is not supported.");
	}

	public static EndpointIdentity CreateDnsIdentity(string dnsName)
	{
		return new DnsEndpointIdentity(dnsName);
	}

	public static EndpointIdentity CreateSpnIdentity(string spnName)
	{
		return new SpnEndpointIdentity(spnName);
	}

	public static EndpointIdentity CreateUpnIdentity(string upnName)
	{
		return new UpnEndpointIdentity(upnName);
	}

	internal virtual void EnsureIdentityClaim()
	{
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (!(obj is EndpointIdentity endpointIdentity))
		{
			return false;
		}
		return Matches(endpointIdentity.IdentityClaim);
	}

	public override int GetHashCode()
	{
		return GetClaimComparer().GetHashCode(IdentityClaim);
	}

	internal bool Matches(Claim claim)
	{
		return GetClaimComparer().Equals(IdentityClaim, claim);
	}

	private IEqualityComparer<Claim> GetClaimComparer()
	{
		if (_claimComparer == null)
		{
			throw ExceptionHelper.PlatformNotSupported("EndpointIdentity.GetClaimComparer is not supported.");
		}
		return _claimComparer;
	}

	internal static EndpointIdentity ReadIdentity(XmlDictionaryReader reader)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
		}
		EndpointIdentity endpointIdentity = null;
		reader.MoveToContent();
		if (reader.IsEmptyElement)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnexpectedEmptyElementExpectingClaim, XD.AddressingDictionary.Identity.Value, XD.AddressingDictionary.IdentityExtensionNamespace.Value)));
		}
		reader.ReadStartElement(XD.AddressingDictionary.Identity, XD.AddressingDictionary.IdentityExtensionNamespace);
		if (reader.IsStartElement(XD.AddressingDictionary.Spn, XD.AddressingDictionary.IdentityExtensionNamespace))
		{
			endpointIdentity = new SpnEndpointIdentity(reader.ReadElementString());
		}
		else if (reader.IsStartElement(XD.AddressingDictionary.Upn, XD.AddressingDictionary.IdentityExtensionNamespace))
		{
			endpointIdentity = new UpnEndpointIdentity(reader.ReadElementString());
		}
		else if (reader.IsStartElement(XD.AddressingDictionary.Dns, XD.AddressingDictionary.IdentityExtensionNamespace))
		{
			endpointIdentity = new DnsEndpointIdentity(reader.ReadElementString());
		}
		else
		{
			if (!reader.IsStartElement(XD.XmlSignatureDictionary.KeyInfo, XD.XmlSignatureDictionary.Namespace))
			{
				if (reader.NodeType == XmlNodeType.Element)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnrecognizedIdentityType, reader.Name, reader.NamespaceURI)));
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.InvalidIdentityElement));
			}
			reader.ReadStartElement();
			if (!reader.IsStartElement(XD.XmlSignatureDictionary.X509Data, XD.XmlSignatureDictionary.Namespace))
			{
				if (reader.IsStartElement(XD.XmlSignatureDictionary.RsaKeyValue, XD.XmlSignatureDictionary.Namespace))
				{
					throw ExceptionHelper.PlatformNotSupported("EndpointIdentity.ReadIdentity RsaEndpointIdentity is not supported.");
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.UnrecognizedIdentityType, reader.Name, reader.NamespaceURI)));
			}
			endpointIdentity = new X509CertificateEndpointIdentity(reader);
			reader.ReadEndElement();
		}
		reader.ReadEndElement();
		return endpointIdentity;
	}

	internal void WriteTo(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		writer.WriteStartElement(XD.AddressingDictionary.Identity, XD.AddressingDictionary.IdentityExtensionNamespace);
		WriteContentsTo(writer);
		writer.WriteEndElement();
	}

	internal virtual void WriteContentsTo(XmlDictionaryWriter writer)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.UnrecognizedIdentityPropertyType, IdentityClaim.GetType().ToString())));
	}
}
