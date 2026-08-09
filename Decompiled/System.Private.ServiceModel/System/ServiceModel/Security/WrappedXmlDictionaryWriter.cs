using System.Xml;

namespace System.ServiceModel.Security;

internal class WrappedXmlDictionaryWriter : XmlDictionaryWriter
{
	private XmlDictionaryWriter _innerWriter;

	private int _index;

	private bool _insertId;

	private bool _isStrReferenceElement;

	private string _id;

	public override WriteState WriteState => _innerWriter.WriteState;

	public WrappedXmlDictionaryWriter(XmlDictionaryWriter writer, string id)
	{
		_innerWriter = writer;
		_index = 0;
		_insertId = false;
		_isStrReferenceElement = false;
		_id = id;
	}

	public override void WriteStartAttribute(string prefix, string localName, string namespaceUri)
	{
		if (_isStrReferenceElement && _insertId && localName == XD.UtilityDictionary.IdAttribute.Value)
		{
			_insertId = false;
		}
		_innerWriter.WriteStartAttribute(prefix, localName, namespaceUri);
	}

	public override void WriteStartElement(string prefix, string localName, string namespaceUri)
	{
		if (_isStrReferenceElement && _insertId)
		{
			if (_id != null)
			{
				_innerWriter.WriteAttributeString(XD.UtilityDictionary.Prefix.Value, XD.UtilityDictionary.IdAttribute, XD.UtilityDictionary.Namespace, _id);
			}
			_isStrReferenceElement = false;
			_insertId = false;
		}
		_index++;
		if (_index == 1 && localName == XD.SecurityJan2004Dictionary.SecurityTokenReference.Value)
		{
			_insertId = true;
			_isStrReferenceElement = true;
		}
		_innerWriter.WriteStartElement(prefix, localName, namespaceUri);
	}

	public override void Close()
	{
		_innerWriter.Close();
	}

	public override void Flush()
	{
		_innerWriter.Flush();
	}

	public override string LookupPrefix(string ns)
	{
		return _innerWriter.LookupPrefix(ns);
	}

	public override void WriteBase64(byte[] buffer, int index, int count)
	{
		_innerWriter.WriteBase64(buffer, index, count);
	}

	public override void WriteCData(string text)
	{
		_innerWriter.WriteCData(text);
	}

	public override void WriteCharEntity(char ch)
	{
		_innerWriter.WriteCharEntity(ch);
	}

	public override void WriteChars(char[] buffer, int index, int count)
	{
		_innerWriter.WriteChars(buffer, index, count);
	}

	public override void WriteComment(string text)
	{
		_innerWriter.WriteComment(text);
	}

	public override void WriteDocType(string name, string pubid, string sysid, string subset)
	{
		_innerWriter.WriteDocType(name, pubid, sysid, subset);
	}

	public override void WriteEndAttribute()
	{
		_innerWriter.WriteEndAttribute();
	}

	public override void WriteEndDocument()
	{
		_innerWriter.WriteEndDocument();
	}

	public override void WriteEndElement()
	{
		_innerWriter.WriteEndElement();
	}

	public override void WriteEntityRef(string name)
	{
		_innerWriter.WriteEntityRef(name);
	}

	public override void WriteFullEndElement()
	{
		_innerWriter.WriteFullEndElement();
	}

	public override void WriteProcessingInstruction(string name, string text)
	{
		_innerWriter.WriteProcessingInstruction(name, text);
	}

	public override void WriteRaw(string data)
	{
		_innerWriter.WriteRaw(data);
	}

	public override void WriteRaw(char[] buffer, int index, int count)
	{
		_innerWriter.WriteRaw(buffer, index, count);
	}

	public override void WriteStartDocument(bool standalone)
	{
		_innerWriter.WriteStartDocument(standalone);
	}

	public override void WriteStartDocument()
	{
		_innerWriter.WriteStartDocument();
	}

	public override void WriteString(string text)
	{
		_innerWriter.WriteString(text);
	}

	public override void WriteSurrogateCharEntity(char lowChar, char highChar)
	{
		_innerWriter.WriteSurrogateCharEntity(lowChar, highChar);
	}

	public override void WriteWhitespace(string ws)
	{
		_innerWriter.WriteWhitespace(ws);
	}
}
