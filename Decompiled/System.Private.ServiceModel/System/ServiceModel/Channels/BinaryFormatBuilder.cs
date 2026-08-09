using System.Collections.Generic;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class BinaryFormatBuilder
{
	private List<byte> _bytes;

	public int Count => _bytes.Count;

	public BinaryFormatBuilder()
	{
		_bytes = new List<byte>();
	}

	public void AppendPrefixDictionaryElement(char prefix, int key)
	{
		AppendNode((System.Xml.XmlBinaryNodeType)(68 + GetPrefixOffset(prefix)));
		AppendKey(key);
	}

	public void AppendDictionaryXmlnsAttribute(char prefix, int key)
	{
		AppendNode(System.Xml.XmlBinaryNodeType.DictionaryXmlnsAttribute);
		AppendUtf8(prefix);
		AppendKey(key);
	}

	public void AppendPrefixDictionaryAttribute(char prefix, int key, char value)
	{
		AppendNode((System.Xml.XmlBinaryNodeType)(12 + GetPrefixOffset(prefix)));
		AppendKey(key);
		if (value == '1')
		{
			AppendNode(System.Xml.XmlBinaryNodeType.OneText);
			return;
		}
		AppendNode(System.Xml.XmlBinaryNodeType.Chars8Text);
		AppendUtf8(value);
	}

	public void AppendDictionaryAttribute(char prefix, int key, char value)
	{
		AppendNode(System.Xml.XmlBinaryNodeType.DictionaryAttribute);
		AppendUtf8(prefix);
		AppendKey(key);
		AppendNode(System.Xml.XmlBinaryNodeType.Chars8Text);
		AppendUtf8(value);
	}

	public void AppendDictionaryTextWithEndElement(int key)
	{
		AppendNode(System.Xml.XmlBinaryNodeType.DictionaryTextWithEndElement);
		AppendKey(key);
	}

	public void AppendDictionaryTextWithEndElement()
	{
		AppendNode(System.Xml.XmlBinaryNodeType.DictionaryTextWithEndElement);
	}

	public void AppendUniqueIDWithEndElement()
	{
		AppendNode(System.Xml.XmlBinaryNodeType.UniqueIdTextWithEndElement);
	}

	public void AppendEndElement()
	{
		AppendNode(System.Xml.XmlBinaryNodeType.EndElement);
	}

	private void AppendKey(int key)
	{
		if (key < 0 || key >= 16384)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("key", key, System.SR.Format(System.SR.ValueMustBeInRange, 0, 16384)));
		}
		if (key >= 128)
		{
			AppendByte((key & 0x7F) | 0x80);
			AppendByte(key >> 7);
		}
		else
		{
			AppendByte(key);
		}
	}

	private void AppendNode(System.Xml.XmlBinaryNodeType value)
	{
		AppendByte((int)value);
	}

	private void AppendByte(int value)
	{
		if (value < 0 || value > 255)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.Format(System.SR.ValueMustBeInRange, 0, 255)));
		}
		_bytes.Add((byte)value);
	}

	private void AppendUtf8(char value)
	{
		AppendByte(1);
		AppendByte(value);
	}

	public int GetStaticKey(int value)
	{
		return value * 2;
	}

	public int GetSessionKey(int value)
	{
		return value * 2 + 1;
	}

	private int GetPrefixOffset(char prefix)
	{
		if (prefix < 'a' && prefix > 'z')
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("prefix", prefix, System.SR.Format(System.SR.ValueMustBeInRange, 'a', 'z')));
		}
		return prefix - 97;
	}

	public byte[] ToByteArray()
	{
		byte[] result = _bytes.ToArray();
		_bytes.Clear();
		return result;
	}
}
