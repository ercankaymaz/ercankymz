using System.ServiceModel;
using System.Xml;

namespace System.IdentityModel;

internal class SamlDictionary
{
	public XmlDictionaryString Access;

	public XmlDictionaryString AccessDecision;

	public XmlDictionaryString Action;

	public XmlDictionaryString Advice;

	public XmlDictionaryString Assertion;

	public XmlDictionaryString AssertionId;

	public XmlDictionaryString AssertionIdReference;

	public XmlDictionaryString Attribute;

	public XmlDictionaryString AttributeName;

	public XmlDictionaryString AttributeNamespace;

	public XmlDictionaryString AttributeStatement;

	public XmlDictionaryString AttributeValue;

	public XmlDictionaryString Audience;

	public XmlDictionaryString AudienceRestrictionCondition;

	public XmlDictionaryString AuthenticationInstant;

	public XmlDictionaryString AuthenticationMethod;

	public XmlDictionaryString AuthenticationStatement;

	public XmlDictionaryString AuthorityBinding;

	public XmlDictionaryString AuthorityKind;

	public XmlDictionaryString AuthorizationDecisionStatement;

	public XmlDictionaryString Binding;

	public XmlDictionaryString Condition;

	public XmlDictionaryString Conditions;

	public XmlDictionaryString Decision;

	public XmlDictionaryString DoNotCacheCondition;

	public XmlDictionaryString Evidence;

	public XmlDictionaryString IssueInstant;

	public XmlDictionaryString Issuer;

	public XmlDictionaryString Location;

	public XmlDictionaryString MajorVersion;

	public XmlDictionaryString MinorVersion;

	public XmlDictionaryString Namespace;

	public XmlDictionaryString NameIdentifier;

	public XmlDictionaryString NameIdentifierFormat;

	public XmlDictionaryString NameIdentifierNameQualifier;

	public XmlDictionaryString ActionNamespaceAttribute;

	public XmlDictionaryString NotBefore;

	public XmlDictionaryString NotOnOrAfter;

	public XmlDictionaryString PreferredPrefix;

	public XmlDictionaryString Statement;

	public XmlDictionaryString Subject;

	public XmlDictionaryString SubjectConfirmation;

	public XmlDictionaryString SubjectConfirmationData;

	public XmlDictionaryString SubjectConfirmationMethod;

	public XmlDictionaryString HolderOfKey;

	public XmlDictionaryString SenderVouches;

	public XmlDictionaryString SubjectLocality;

	public XmlDictionaryString SubjectLocalityDNSAddress;

	public XmlDictionaryString SubjectLocalityIPAddress;

	public XmlDictionaryString SubjectStatement;

	public XmlDictionaryString UnspecifiedAuthenticationMethod;

	public XmlDictionaryString NamespaceAttributePrefix;

	public XmlDictionaryString Resource;

	public XmlDictionaryString UserName;

	public XmlDictionaryString UserNameNamespace;

	public XmlDictionaryString EmailName;

	public XmlDictionaryString EmailNamespace;

	public SamlDictionary(IdentityModelDictionary dictionary)
	{
		Access = dictionary.CreateString("Access", 24);
		AccessDecision = dictionary.CreateString("AccessDecision", 25);
		Action = dictionary.CreateString("Action", 26);
		Advice = dictionary.CreateString("Advice", 27);
		Assertion = dictionary.CreateString("Assertion", 28);
		AssertionId = dictionary.CreateString("AssertionID", 29);
		AssertionIdReference = dictionary.CreateString("AssertionIDReference", 30);
		Attribute = dictionary.CreateString("Attribute", 31);
		AttributeName = dictionary.CreateString("AttributeName", 32);
		AttributeNamespace = dictionary.CreateString("AttributeNamespace", 33);
		AttributeStatement = dictionary.CreateString("AttributeStatement", 34);
		AttributeValue = dictionary.CreateString("AttributeValue", 35);
		Audience = dictionary.CreateString("Audience", 36);
		AudienceRestrictionCondition = dictionary.CreateString("AudienceRestrictionCondition", 37);
		AuthenticationInstant = dictionary.CreateString("AuthenticationInstant", 38);
		AuthenticationMethod = dictionary.CreateString("AuthenticationMethod", 39);
		AuthenticationStatement = dictionary.CreateString("AuthenticationStatement", 40);
		AuthorityBinding = dictionary.CreateString("AuthorityBinding", 41);
		AuthorityKind = dictionary.CreateString("AuthorityKind", 42);
		AuthorizationDecisionStatement = dictionary.CreateString("AuthorizationDecisionStatement", 43);
		Binding = dictionary.CreateString("Binding", 44);
		Condition = dictionary.CreateString("Condition", 45);
		Conditions = dictionary.CreateString("Conditions", 46);
		Decision = dictionary.CreateString("Decision", 47);
		DoNotCacheCondition = dictionary.CreateString("DoNotCacheCondition", 48);
		Evidence = dictionary.CreateString("Evidence", 49);
		IssueInstant = dictionary.CreateString("IssueInstant", 50);
		Issuer = dictionary.CreateString("Issuer", 51);
		Location = dictionary.CreateString("Location", 52);
		MajorVersion = dictionary.CreateString("MajorVersion", 53);
		MinorVersion = dictionary.CreateString("MinorVersion", 54);
		Namespace = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:assertion", 55);
		NameIdentifier = dictionary.CreateString("NameIdentifier", 56);
		NameIdentifierFormat = dictionary.CreateString("Format", 57);
		NameIdentifierNameQualifier = dictionary.CreateString("NameQualifier", 58);
		ActionNamespaceAttribute = dictionary.CreateString("Namespace", 59);
		NotBefore = dictionary.CreateString("NotBefore", 60);
		NotOnOrAfter = dictionary.CreateString("NotOnOrAfter", 61);
		PreferredPrefix = dictionary.CreateString("saml", 62);
		Statement = dictionary.CreateString("Statement", 63);
		Subject = dictionary.CreateString("Subject", 64);
		SubjectConfirmation = dictionary.CreateString("SubjectConfirmation", 65);
		SubjectConfirmationData = dictionary.CreateString("SubjectConfirmationData", 66);
		SubjectConfirmationMethod = dictionary.CreateString("ConfirmationMethod", 67);
		HolderOfKey = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:cm:holder-of-key", 68);
		SenderVouches = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:cm:sender-vouches", 69);
		SubjectLocality = dictionary.CreateString("SubjectLocality", 70);
		SubjectLocalityDNSAddress = dictionary.CreateString("DNSAddress", 71);
		SubjectLocalityIPAddress = dictionary.CreateString("IPAddress", 72);
		SubjectStatement = dictionary.CreateString("SubjectStatement", 73);
		UnspecifiedAuthenticationMethod = dictionary.CreateString("urn:oasis:names:tc:SAML:1.0:am:unspecified", 74);
		NamespaceAttributePrefix = dictionary.CreateString("xmlns", 75);
		Resource = dictionary.CreateString("Resource", 76);
		UserName = dictionary.CreateString("UserName", 77);
		UserNameNamespace = dictionary.CreateString("urn:oasis:names:tc:SAML:1.1:nameid-format:WindowsDomainQualifiedName", 78);
		EmailName = dictionary.CreateString("EmailName", 79);
		EmailNamespace = dictionary.CreateString("urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress", 80);
	}

	public SamlDictionary(IXmlDictionary dictionary)
	{
		Access = LookupDictionaryString(dictionary, "Access");
		AccessDecision = LookupDictionaryString(dictionary, "AccessDecision");
		Action = LookupDictionaryString(dictionary, "Action");
		Advice = LookupDictionaryString(dictionary, "Advice");
		Assertion = LookupDictionaryString(dictionary, "Assertion");
		AssertionId = LookupDictionaryString(dictionary, "AssertionID");
		AssertionIdReference = LookupDictionaryString(dictionary, "AssertionIDReference");
		Attribute = LookupDictionaryString(dictionary, "Attribute");
		AttributeName = LookupDictionaryString(dictionary, "AttributeName");
		AttributeNamespace = LookupDictionaryString(dictionary, "AttributeNamespace");
		AttributeStatement = LookupDictionaryString(dictionary, "AttributeStatement");
		AttributeValue = LookupDictionaryString(dictionary, "AttributeValue");
		Audience = LookupDictionaryString(dictionary, "Audience");
		AudienceRestrictionCondition = LookupDictionaryString(dictionary, "AudienceRestrictionCondition");
		AuthenticationInstant = LookupDictionaryString(dictionary, "AuthenticationInstant");
		AuthenticationMethod = LookupDictionaryString(dictionary, "AuthenticationMethod");
		AuthenticationStatement = LookupDictionaryString(dictionary, "AuthenticationStatement");
		AuthorityBinding = LookupDictionaryString(dictionary, "AuthorityBinding");
		AuthorityKind = LookupDictionaryString(dictionary, "AuthorityKind");
		AuthorizationDecisionStatement = LookupDictionaryString(dictionary, "AuthorizationDecisionStatement");
		Binding = LookupDictionaryString(dictionary, "Binding");
		Condition = LookupDictionaryString(dictionary, "Condition");
		Conditions = LookupDictionaryString(dictionary, "Conditions");
		Decision = LookupDictionaryString(dictionary, "Decision");
		DoNotCacheCondition = LookupDictionaryString(dictionary, "DoNotCacheCondition");
		Evidence = LookupDictionaryString(dictionary, "Evidence");
		IssueInstant = LookupDictionaryString(dictionary, "IssueInstant");
		Issuer = LookupDictionaryString(dictionary, "Issuer");
		Location = LookupDictionaryString(dictionary, "Location");
		MajorVersion = LookupDictionaryString(dictionary, "MajorVersion");
		MinorVersion = LookupDictionaryString(dictionary, "MinorVersion");
		Namespace = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.0:assertion");
		NameIdentifier = LookupDictionaryString(dictionary, "NameIdentifier");
		NameIdentifierFormat = LookupDictionaryString(dictionary, "Format");
		NameIdentifierNameQualifier = LookupDictionaryString(dictionary, "NameQualifier");
		ActionNamespaceAttribute = LookupDictionaryString(dictionary, "Namespace");
		NotBefore = LookupDictionaryString(dictionary, "NotBefore");
		NotOnOrAfter = LookupDictionaryString(dictionary, "NotOnOrAfter");
		PreferredPrefix = LookupDictionaryString(dictionary, "saml");
		Statement = LookupDictionaryString(dictionary, "Statement");
		Subject = LookupDictionaryString(dictionary, "Subject");
		SubjectConfirmation = LookupDictionaryString(dictionary, "SubjectConfirmation");
		SubjectConfirmationData = LookupDictionaryString(dictionary, "SubjectConfirmationData");
		SubjectConfirmationMethod = LookupDictionaryString(dictionary, "ConfirmationMethod");
		HolderOfKey = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.0:cm:holder-of-key");
		SenderVouches = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.0:cm:sender-vouches");
		SubjectLocality = LookupDictionaryString(dictionary, "SubjectLocality");
		SubjectLocalityDNSAddress = LookupDictionaryString(dictionary, "DNSAddress");
		SubjectLocalityIPAddress = LookupDictionaryString(dictionary, "IPAddress");
		SubjectStatement = LookupDictionaryString(dictionary, "SubjectStatement");
		UnspecifiedAuthenticationMethod = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.0:am:unspecified");
		NamespaceAttributePrefix = LookupDictionaryString(dictionary, "xmlns");
		Resource = LookupDictionaryString(dictionary, "Resource");
		UserName = LookupDictionaryString(dictionary, "UserName");
		UserNameNamespace = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.1:nameid-format:WindowsDomainQualifiedName");
		EmailName = LookupDictionaryString(dictionary, "EmailName");
		EmailNamespace = LookupDictionaryString(dictionary, "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress");
	}

	private XmlDictionaryString LookupDictionaryString(IXmlDictionary dictionary, string value)
	{
		if (!dictionary.TryLookup(value, out XmlDictionaryString result))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.XDCannotFindValueInDictionaryString, value));
		}
		return result;
	}
}
