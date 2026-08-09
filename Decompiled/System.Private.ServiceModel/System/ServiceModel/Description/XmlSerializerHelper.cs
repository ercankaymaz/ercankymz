using System.Collections;
using System.Reflection;
using System.Runtime;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Description;

internal static class XmlSerializerHelper
{
	internal static XmlReflectionMember GetXmlReflectionMember(MessagePartDescription part, bool isRpc, bool isEncoded, bool isWrapped)
	{
		string ns = (isRpc ? null : part.Namespace);
		ICustomAttributeProvider additionalAttributesProvider = null;
		if (isEncoded || part.AdditionalAttributesProvider is MemberInfo)
		{
			additionalAttributesProvider = part.AdditionalAttributesProvider;
		}
		XmlName memberName = (string.IsNullOrEmpty(part.UniquePartName) ? null : new XmlName(part.UniquePartName, isEncoded: true));
		XmlName xmlName = part.XmlName;
		return GetXmlReflectionMember(memberName, xmlName, ns, part.Type, additionalAttributesProvider, part.Multiple, isEncoded, isWrapped);
	}

	internal static XmlReflectionMember GetXmlReflectionMember(XmlName memberName, XmlName elementName, string ns, Type type, ICustomAttributeProvider additionalAttributesProvider, bool isMultiple, bool isEncoded, bool isWrapped)
	{
		if (isEncoded && isMultiple)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxMultiplePartsNotAllowedInEncoded, elementName.DecodedName, ns)));
		}
		XmlReflectionMember xmlReflectionMember = new XmlReflectionMember();
		xmlReflectionMember.MemberName = (memberName ?? elementName).DecodedName;
		xmlReflectionMember.MemberType = type;
		if (xmlReflectionMember.MemberType.IsByRef)
		{
			xmlReflectionMember.MemberType = xmlReflectionMember.MemberType.GetElementType();
		}
		if (isMultiple)
		{
			xmlReflectionMember.MemberType = xmlReflectionMember.MemberType.MakeArrayType();
		}
		if (additionalAttributesProvider != null)
		{
			if (isEncoded)
			{
				xmlReflectionMember.SoapAttributes = new SoapAttributes(additionalAttributesProvider);
			}
			else
			{
				xmlReflectionMember.XmlAttributes = new XmlAttributes(additionalAttributesProvider);
			}
		}
		if (isEncoded)
		{
			if (xmlReflectionMember.SoapAttributes == null)
			{
				xmlReflectionMember.SoapAttributes = new SoapAttributes();
			}
			else
			{
				Type type2 = null;
				if (xmlReflectionMember.SoapAttributes.SoapAttribute != null)
				{
					type2 = typeof(SoapAttributeAttribute);
				}
				else if (xmlReflectionMember.SoapAttributes.SoapIgnore)
				{
					type2 = typeof(SoapIgnoreAttribute);
				}
				else if (xmlReflectionMember.SoapAttributes.SoapType != null)
				{
					type2 = typeof(SoapTypeAttribute);
				}
				if (type2 != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxInvalidSoapAttribute, type2, elementName.DecodedName)));
				}
			}
			if (xmlReflectionMember.SoapAttributes.SoapElement == null)
			{
				xmlReflectionMember.SoapAttributes.SoapElement = new SoapElementAttribute(elementName.DecodedName);
			}
		}
		else
		{
			if (xmlReflectionMember.XmlAttributes == null)
			{
				xmlReflectionMember.XmlAttributes = new XmlAttributes();
			}
			else
			{
				Type type3 = null;
				if (xmlReflectionMember.XmlAttributes.XmlAttribute != null)
				{
					type3 = typeof(XmlAttributeAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.XmlAnyAttribute != null && !isWrapped)
				{
					type3 = typeof(XmlAnyAttributeAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.XmlChoiceIdentifier != null)
				{
					type3 = typeof(XmlChoiceIdentifierAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.XmlIgnore)
				{
					type3 = typeof(XmlIgnoreAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.Xmlns)
				{
					type3 = typeof(XmlNamespaceDeclarationsAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.XmlText != null)
				{
					type3 = typeof(XmlTextAttribute);
				}
				else if (xmlReflectionMember.XmlAttributes.XmlEnum != null)
				{
					type3 = typeof(XmlEnumAttribute);
				}
				if (type3 != null)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(isWrapped ? System.SR.SFxInvalidXmlAttributeInWrapped : System.SR.SFxInvalidXmlAttributeInBare, type3, elementName.DecodedName)));
				}
				if (xmlReflectionMember.XmlAttributes.XmlArray != null && isMultiple)
				{
					throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxXmlArrayNotAllowedForMultiple, elementName.DecodedName, ns)));
				}
			}
			bool isArray = xmlReflectionMember.MemberType.IsArray;
			if ((isArray && !isMultiple && xmlReflectionMember.MemberType != typeof(byte[])) || (!isArray && typeof(IEnumerable).IsAssignableFrom(xmlReflectionMember.MemberType) && xmlReflectionMember.MemberType != typeof(string) && !typeof(XmlNode).IsAssignableFrom(xmlReflectionMember.MemberType) && !typeof(IXmlSerializable).IsAssignableFrom(xmlReflectionMember.MemberType)))
			{
				if (xmlReflectionMember.XmlAttributes.XmlArray != null)
				{
					if (xmlReflectionMember.XmlAttributes.XmlArray.ElementName == string.Empty)
					{
						xmlReflectionMember.XmlAttributes.XmlArray.ElementName = elementName.DecodedName;
					}
					if (xmlReflectionMember.XmlAttributes.XmlArray.Namespace == null)
					{
						xmlReflectionMember.XmlAttributes.XmlArray.Namespace = ns;
					}
				}
				else if (HasNoXmlParameterAttributes(xmlReflectionMember.XmlAttributes))
				{
					xmlReflectionMember.XmlAttributes.XmlArray = new XmlArrayAttribute();
					xmlReflectionMember.XmlAttributes.XmlArray.ElementName = elementName.DecodedName;
					xmlReflectionMember.XmlAttributes.XmlArray.Namespace = ns;
				}
			}
			else if (xmlReflectionMember.XmlAttributes.XmlElements == null || xmlReflectionMember.XmlAttributes.XmlElements.Count == 0)
			{
				if (HasNoXmlParameterAttributes(xmlReflectionMember.XmlAttributes))
				{
					XmlElementAttribute xmlElementAttribute = new XmlElementAttribute();
					xmlElementAttribute.ElementName = elementName.DecodedName;
					xmlElementAttribute.Namespace = ns;
					xmlReflectionMember.XmlAttributes.XmlElements.Add(xmlElementAttribute);
				}
			}
			else
			{
				foreach (XmlElementAttribute xmlElement in xmlReflectionMember.XmlAttributes.XmlElements)
				{
					if (xmlElement.ElementName == string.Empty)
					{
						xmlElement.ElementName = elementName.DecodedName;
					}
					if (xmlElement.Namespace == null)
					{
						xmlElement.Namespace = ns;
					}
				}
			}
		}
		return xmlReflectionMember;
	}

	private static bool HasNoXmlParameterAttributes(XmlAttributes xmlAttributes)
	{
		if (xmlAttributes.XmlAnyAttribute == null && (xmlAttributes.XmlAnyElements == null || xmlAttributes.XmlAnyElements.Count == 0) && xmlAttributes.XmlArray == null && xmlAttributes.XmlAttribute == null && !xmlAttributes.XmlIgnore && xmlAttributes.XmlText == null && xmlAttributes.XmlChoiceIdentifier == null && (xmlAttributes.XmlElements == null || xmlAttributes.XmlElements.Count == 0))
		{
			return !xmlAttributes.Xmlns;
		}
		return false;
	}

	public static XmlSerializer[] FromMappings(XmlMapping[] mappings, Type type)
	{
		if (Fx.IsUap && GeneratedXmlSerializers.IsInitialized)
		{
			return FromMappingsViaInjection(mappings, type);
		}
		return FromMappingsViaReflection(mappings, type);
	}

	private static XmlSerializer[] FromMappingsViaReflection(XmlMapping[] mappings, Type type)
	{
		if (mappings == null || mappings.Length == 0)
		{
			return new XmlSerializer[0];
		}
		return XmlSerializer.FromMappings(mappings, type);
	}

	private static XmlSerializer[] FromMappingsViaInjection(XmlMapping[] mappings, Type type)
	{
		XmlSerializer[] array = new XmlSerializer[mappings.Length];
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			GeneratedXmlSerializers.GetGeneratedSerializers().TryGetValue(mappings[i].GetKey(), out var value);
			if (value == null)
			{
				flag = true;
				break;
			}
			array[i] = new XmlSerializer(value);
		}
		if (flag)
		{
			return XmlSerializer.FromMappings(mappings, type);
		}
		return array;
	}
}
