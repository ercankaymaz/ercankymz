using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel.Tokens;

public class GenericXmlSecurityKeyIdentifierClause : SecurityKeyIdentifierClause
{
	public XmlElement ReferenceXml { get; }

	public GenericXmlSecurityKeyIdentifierClause(XmlElement referenceXml)
		: this(referenceXml, null, 0)
	{
	}

	public GenericXmlSecurityKeyIdentifierClause(XmlElement referenceXml, byte[] derivationNonce, int derivationLength)
		: base(null, derivationNonce, derivationLength)
	{
		ReferenceXml = referenceXml ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("referenceXml");
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		GenericXmlSecurityKeyIdentifierClause genericXmlSecurityKeyIdentifierClause = keyIdentifierClause as GenericXmlSecurityKeyIdentifierClause;
		if (this != genericXmlSecurityKeyIdentifierClause)
		{
			return genericXmlSecurityKeyIdentifierClause?.Matches(ReferenceXml) ?? false;
		}
		return true;
	}

	private bool Matches(XmlElement xmlElement)
	{
		if (xmlElement == null)
		{
			return false;
		}
		return CompareNodes(ReferenceXml, xmlElement);
	}

	private bool CompareNodes(XmlNode originalNode, XmlNode newNode)
	{
		if (originalNode.OuterXml == newNode.OuterXml)
		{
			return true;
		}
		if (originalNode.LocalName != newNode.LocalName || originalNode.InnerText != newNode.InnerText)
		{
			return false;
		}
		if (originalNode.InnerXml == newNode.InnerXml)
		{
			return true;
		}
		if (originalNode.HasChildNodes)
		{
			if (!newNode.HasChildNodes || originalNode.ChildNodes.Count != newNode.ChildNodes.Count)
			{
				return false;
			}
			bool flag = true;
			for (int i = 0; i < originalNode.ChildNodes.Count; i++)
			{
				flag &= CompareNodes(originalNode.ChildNodes[i], newNode.ChildNodes[i]);
			}
			return flag;
		}
		if (newNode.HasChildNodes)
		{
			return false;
		}
		return true;
	}
}
