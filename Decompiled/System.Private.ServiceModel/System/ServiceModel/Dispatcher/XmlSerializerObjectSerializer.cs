using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace System.ServiceModel.Dispatcher;

internal class XmlSerializerObjectSerializer : XmlObjectSerializer
{
	private XmlSerializer _serializer;

	private Type _rootType;

	private string _rootName;

	private string _rootNamespace;

	private bool _isSerializerSetExplicit;

	internal XmlSerializerObjectSerializer(Type type)
	{
		Initialize(type, null, null, null);
	}

	internal XmlSerializerObjectSerializer(Type type, XmlQualifiedName qualifiedName, XmlSerializer xmlSerializer)
	{
		if (qualifiedName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("qualifiedName");
		}
		Initialize(type, qualifiedName.Name, qualifiedName.Namespace, xmlSerializer);
	}

	private void Initialize(Type type, string rootName, string rootNamespace, XmlSerializer xmlSerializer)
	{
		_rootType = type ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("type");
		_rootName = rootName;
		_rootNamespace = ((rootNamespace == null) ? string.Empty : rootNamespace);
		_serializer = xmlSerializer;
		if (_serializer == null)
		{
			if (_rootName == null)
			{
				_serializer = new XmlSerializer(type);
			}
			else
			{
				XmlRootAttribute xmlRootAttribute = new XmlRootAttribute();
				xmlRootAttribute.ElementName = _rootName;
				xmlRootAttribute.Namespace = _rootNamespace;
				_serializer = new XmlSerializer(type, xmlRootAttribute);
			}
		}
		else
		{
			_isSerializerSetExplicit = true;
		}
		if (_rootName == null)
		{
			XmlTypeMapping xmlTypeMapping = new XmlReflectionImporter().ImportTypeMapping(_rootType);
			_rootName = xmlTypeMapping.ElementName;
			_rootNamespace = xmlTypeMapping.Namespace;
		}
	}

	public override void WriteObject(XmlDictionaryWriter writer, object graph)
	{
		if (_isSerializerSetExplicit)
		{
			_serializer.Serialize(writer, new object[1] { graph });
		}
		else
		{
			_serializer.Serialize(writer, graph);
		}
	}

	public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public override void WriteEndObject(XmlDictionaryWriter writer)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesign);
	}

	public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
	{
		if (_isSerializerSetExplicit)
		{
			object[] array = (object[])_serializer.Deserialize(reader);
			if (array != null && array.Length != 0)
			{
				return array[0];
			}
			return null;
		}
		return _serializer.Deserialize(reader);
	}

	public override bool IsStartObject(XmlDictionaryReader reader)
	{
		if (reader == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("reader"));
		}
		reader.MoveToElement();
		if (_rootName != null)
		{
			return reader.IsStartElement(_rootName, _rootNamespace);
		}
		return reader.IsStartElement();
	}
}
