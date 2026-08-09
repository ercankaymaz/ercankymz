using System.IdentityModel.Tokens;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

internal class WSTrustFeb2005 : WSTrust
{
	public class DriverFeb2005 : Driver
	{
		public override TrustDictionary DriverDictionary => XD.TrustFeb2005Dictionary;

		public override XmlDictionaryString RequestSecurityTokenResponseFinalAction => XD.TrustFeb2005Dictionary.RequestSecurityTokenIssuanceResponse;

		public override bool IsSessionSupported => true;

		public override bool IsIssuedTokensSupported => true;

		public override string IssuedTokensHeaderName => DriverDictionary.IssuedTokensHeader.Value;

		public override string IssuedTokensHeaderNamespace => DriverDictionary.Namespace.Value;

		public override string RequestTypeRenew => DriverDictionary.RequestTypeRenew.Value;

		public override string RequestTypeClose => DriverDictionary.RequestTypeClose.Value;

		public DriverFeb2005(SecurityStandardsManager standardsManager)
			: base(standardsManager)
		{
		}

		protected override void ReadReferences(XmlElement rstrXml, out SecurityKeyIdentifierClause requestedAttachedReference, out SecurityKeyIdentifierClause requestedUnattachedReference)
		{
			XmlElement xmlElement = null;
			requestedAttachedReference = null;
			requestedUnattachedReference = null;
			for (int i = 0; i < rstrXml.ChildNodes.Count; i++)
			{
				if (rstrXml.ChildNodes[i] is XmlElement xmlElement2)
				{
					if (xmlElement2.LocalName == DriverDictionary.RequestedSecurityToken.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						xmlElement = XmlHelper.GetChildElement(xmlElement2);
					}
					else if (xmlElement2.LocalName == DriverDictionary.RequestedAttachedReference.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						requestedAttachedReference = GetKeyIdentifierXmlReferenceClause(XmlHelper.GetChildElement(xmlElement2));
					}
					else if (xmlElement2.LocalName == DriverDictionary.RequestedUnattachedReference.Value && xmlElement2.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						requestedUnattachedReference = GetKeyIdentifierXmlReferenceClause(XmlHelper.GetChildElement(xmlElement2));
					}
				}
			}
			try
			{
				if (xmlElement != null)
				{
					if (requestedAttachedReference == null)
					{
						StandardsManager.TryCreateKeyIdentifierClauseFromTokenXml(xmlElement, SecurityTokenReferenceStyle.Internal, out requestedAttachedReference);
					}
					if (requestedUnattachedReference == null)
					{
						StandardsManager.TryCreateKeyIdentifierClauseFromTokenXml(xmlElement, SecurityTokenReferenceStyle.External, out requestedUnattachedReference);
					}
				}
			}
			catch (XmlException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(System.SR.Format(System.SR.TrustDriverIsUnableToCreatedNecessaryAttachedOrUnattachedReferences, xmlElement.ToString())));
			}
		}

		protected override bool ReadRequestedTokenClosed(XmlElement rstrXml)
		{
			for (int i = 0; i < rstrXml.ChildNodes.Count; i++)
			{
				if (rstrXml.ChildNodes[i] is XmlElement xmlElement && xmlElement.LocalName == DriverDictionary.RequestedTokenClosed.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
				{
					return true;
				}
			}
			return false;
		}

		protected override void ReadTargets(XmlElement rstXml, out SecurityKeyIdentifierClause renewTarget, out SecurityKeyIdentifierClause closeTarget)
		{
			renewTarget = null;
			closeTarget = null;
			for (int i = 0; i < rstXml.ChildNodes.Count; i++)
			{
				if (rstXml.ChildNodes[i] is XmlElement xmlElement)
				{
					if (xmlElement.LocalName == DriverDictionary.RenewTarget.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						renewTarget = StandardsManager.SecurityTokenSerializer.ReadKeyIdentifierClause(new XmlNodeReader(xmlElement.FirstChild));
					}
					else if (xmlElement.LocalName == DriverDictionary.CloseTarget.Value && xmlElement.NamespaceURI == DriverDictionary.Namespace.Value)
					{
						closeTarget = StandardsManager.SecurityTokenSerializer.ReadKeyIdentifierClause(new XmlNodeReader(xmlElement.FirstChild));
					}
				}
			}
		}

		protected override void WriteReferences(RequestSecurityTokenResponse rstr, XmlDictionaryWriter writer)
		{
			if (rstr.RequestedAttachedReference != null)
			{
				writer.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestedAttachedReference, DriverDictionary.Namespace);
				StandardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, rstr.RequestedAttachedReference);
				writer.WriteEndElement();
			}
			if (rstr.RequestedUnattachedReference != null)
			{
				writer.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RequestedUnattachedReference, DriverDictionary.Namespace);
				StandardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, rstr.RequestedUnattachedReference);
				writer.WriteEndElement();
			}
		}

		protected override void WriteRequestedTokenClosed(RequestSecurityTokenResponse rstr, XmlDictionaryWriter writer)
		{
			if (rstr.IsRequestedTokenClosed)
			{
				writer.WriteElementString(DriverDictionary.RequestedTokenClosed, DriverDictionary.Namespace, string.Empty);
			}
		}

		protected override void WriteTargets(RequestSecurityToken rst, XmlDictionaryWriter writer)
		{
			if (rst.RenewTarget != null)
			{
				writer.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.RenewTarget, DriverDictionary.Namespace);
				StandardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, rst.RenewTarget);
				writer.WriteEndElement();
			}
			if (rst.CloseTarget != null)
			{
				writer.WriteStartElement(DriverDictionary.Prefix.Value, DriverDictionary.CloseTarget, DriverDictionary.Namespace);
				StandardsManager.SecurityTokenSerializer.WriteKeyIdentifierClause(writer, rst.CloseTarget);
				writer.WriteEndElement();
			}
		}
	}

	public override TrustDictionary SerializerDictionary => XD.TrustFeb2005Dictionary;

	public WSTrustFeb2005(WSSecurityTokenSerializer tokenSerializer)
		: base(tokenSerializer)
	{
	}
}
