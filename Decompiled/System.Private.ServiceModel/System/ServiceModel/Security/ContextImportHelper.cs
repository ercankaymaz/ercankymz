using System.IO;
using System.Runtime;
using System.ServiceModel.Channels;
using System.Xml;

namespace System.ServiceModel.Security;

internal static class ContextImportHelper
{
	internal static XmlDictionaryReader CreateSplicedReader(byte[] decryptedBuffer, XmlAttributeHolder[] outerContext1, XmlAttributeHolder[] outerContext2, XmlAttributeHolder[] outerContext3, XmlDictionaryReaderQuotas quotas)
	{
		MemoryStream memoryStream = new MemoryStream();
		XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(memoryStream);
		xmlDictionaryWriter.WriteStartElement("x");
		WriteNamespaceDeclarations(outerContext1, xmlDictionaryWriter);
		xmlDictionaryWriter.WriteStartElement("y");
		WriteNamespaceDeclarations(outerContext2, xmlDictionaryWriter);
		xmlDictionaryWriter.WriteStartElement("z");
		WriteNamespaceDeclarations(outerContext3, xmlDictionaryWriter);
		xmlDictionaryWriter.WriteString(" ");
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.WriteEndElement();
		xmlDictionaryWriter.Flush();
		byte[] buffer = SpliceBuffers(decryptedBuffer, memoryStream.GetBuffer(), (int)memoryStream.Length, 3);
		XmlDictionaryReader xmlDictionaryReader = XmlDictionaryReader.CreateTextReader(buffer, quotas);
		xmlDictionaryReader.ReadStartElement("x");
		xmlDictionaryReader.ReadStartElement("y");
		xmlDictionaryReader.ReadStartElement("z");
		if (xmlDictionaryReader.NodeType != XmlNodeType.Element)
		{
			xmlDictionaryReader.MoveToContent();
		}
		return xmlDictionaryReader;
	}

	internal static string GetPrefixIfNamespaceDeclaration(string prefix, string localName)
	{
		if (prefix == "xmlns")
		{
			return localName;
		}
		if (prefix.Length == 0 && localName == "xmlns")
		{
			return string.Empty;
		}
		return null;
	}

	private static bool IsNamespaceDeclaration(string prefix, string localName)
	{
		return GetPrefixIfNamespaceDeclaration(prefix, localName) != null;
	}

	internal static byte[] SpliceBuffers(byte[] middle, byte[] wrapper, int wrapperLength, int wrappingDepth)
	{
		int num = 0;
		int num2;
		for (num2 = wrapperLength - 1; num2 >= 0; num2--)
		{
			if (wrapper[num2] == 60)
			{
				num++;
				if (num == wrappingDepth)
				{
					break;
				}
			}
		}
		byte[] array = Fx.AllocateByteArray(checked(middle.Length + wrapperLength - 1));
		int num3 = 0;
		int num4 = num2 - 1;
		Buffer.BlockCopy(wrapper, 0, array, num3, num4);
		num3 += num4;
		num4 = middle.Length;
		Buffer.BlockCopy(middle, 0, array, num3, num4);
		num3 += num4;
		num4 = wrapperLength - num2;
		Buffer.BlockCopy(wrapper, num2, array, num3, num4);
		return array;
	}

	private static void WriteNamespaceDeclarations(XmlAttributeHolder[] attributes, XmlWriter writer)
	{
		if (attributes == null)
		{
			return;
		}
		for (int i = 0; i < attributes.Length; i++)
		{
			XmlAttributeHolder xmlAttributeHolder = attributes[i];
			if (IsNamespaceDeclaration(xmlAttributeHolder.Prefix, xmlAttributeHolder.LocalName))
			{
				xmlAttributeHolder.WriteTo(writer);
			}
		}
	}
}
