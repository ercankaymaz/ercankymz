using System.Xml;

namespace System.ServiceModel.Security;

internal class WSTrustDec2005 : WSTrustFeb2005
{
	public class DriverDec2005 : DriverFeb2005
	{
		public override TrustDictionary DriverDictionary => DXD.TrustDec2005Dictionary;

		public override XmlDictionaryString RequestSecurityTokenResponseFinalAction => DXD.TrustDec2005Dictionary.RequestSecurityTokenCollectionIssuanceFinalResponse;

		public DriverDec2005(SecurityStandardsManager standardsManager)
			: base(standardsManager)
		{
		}

		internal virtual bool IsSecondaryParametersElement(XmlElement element)
		{
			if (element.LocalName == DXD.TrustDec2005Dictionary.SecondaryParameters.Value)
			{
				return element.NamespaceURI == DXD.TrustDec2005Dictionary.Namespace.Value;
			}
			return false;
		}

		public virtual XmlElement CreateKeyWrapAlgorithmElement(string keyWrapAlgorithm)
		{
			if (keyWrapAlgorithm == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyWrapAlgorithm");
			}
			XmlDocument xmlDocument = new XmlDocument();
			XmlElement xmlElement = xmlDocument.CreateElement(DXD.TrustDec2005Dictionary.Prefix.Value, DXD.TrustDec2005Dictionary.KeyWrapAlgorithm.Value, DXD.TrustDec2005Dictionary.Namespace.Value);
			xmlElement.AppendChild(xmlDocument.CreateTextNode(keyWrapAlgorithm));
			return xmlElement;
		}
	}

	public override TrustDictionary SerializerDictionary => DXD.TrustDec2005Dictionary;

	public WSTrustDec2005(WSSecurityTokenSerializer tokenSerializer)
		: base(tokenSerializer)
	{
	}
}
