using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Step21;
using Xbim.IO.Xml.BsConf;

namespace Xbim.IO.Xml;

public class XbimXmlWriter4
{
	private const string Xsi = "http://www.w3.org/2001/XMLSchema-instance";

	private const string Xlink = "http://www.w3.org/1999/xlink";

	private readonly string _ns;

	private readonly string _nsLocation;

	private readonly string _expressUri;

	private readonly string _configurationUri;

	private readonly string _nsPrefix = "ifc";

	private readonly string _rootElementName = "ifcXML";

	private HashSet<long> _written;

	private readonly configuration _conf;

	public string Name;

	public string TimeStamp;

	public string Author;

	public string Organization;

	public string PreprocessorVersion;

	public string OriginatingSystem;

	public string Authorization;

	public string Documentation;

	private IStepFileHeader _fileHeader;

	private ExpressMetaData _metadata;

	private readonly Dictionary<Type, List<XmlMetaProperty>> _propertiesCache = new Dictionary<Type, List<XmlMetaProperty>>();

	public XbimXmlWriter4(XbimXmlSettings settings)
	{
		_conf = settings.Configuration ?? configuration.IFC4Add2;
		TimeStamp = DateTime.Now.ToString("s");
		Version version = GetType().Assembly.GetName().Version;
		PreprocessorVersion = $"Xbim File Processor version {version}";
		OriginatingSystem = $"Xbim version {version}";
		_ns = settings.Namespace;
		_nsPrefix = settings.NamespacePrefix;
		_nsLocation = settings.NamespaceLocation;
		_expressUri = settings.ExpressUri;
		_configurationUri = settings.ConfigurationUri;
		_rootElementName = settings.RootName;
	}

	public void Write(IModel model, XmlWriter output, IEnumerable<IPersistEntity> entities = null)
	{
		_metadata = model.Metadata;
		try
		{
			_written = new HashSet<long>();
			output.WriteStartDocument();
			output.WriteStartElement(_rootElementName, _ns);
			output.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
			output.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
			output.WriteAttributeString("xmlns", _nsPrefix, null, _ns);
			if (!string.IsNullOrWhiteSpace(_nsLocation))
			{
				output.WriteAttributeString("schemaLocation", "http://www.w3.org/2001/XMLSchema-instance", $"{_ns} {_nsLocation}");
			}
			output.WriteAttributeString("id", "uos_1");
			if (!string.IsNullOrWhiteSpace(_expressUri))
			{
				output.WriteAttributeString("express", _expressUri);
			}
			if (!string.IsNullOrWhiteSpace(_configurationUri))
			{
				output.WriteAttributeString("configuration", _configurationUri);
			}
			_fileHeader = model.Header;
			WriteHeader(output);
			entities = entities ?? model.Instances;
			foreach (IPersistEntity entity in entities)
			{
				WriteEntity(entity, output, onlyOnce: true);
			}
			output.WriteEndElement();
			output.WriteEndDocument();
		}
		catch (Exception innerException)
		{
			throw new Exception("Failed to write XML file", innerException);
		}
		finally
		{
			_written = null;
		}
	}

	private void WriteHeader(XmlWriter output)
	{
		output.WriteStartElement("header");
		if (!string.IsNullOrWhiteSpace(_fileHeader.FileName.Name))
		{
			output.WriteElementString("name", _fileHeader.FileName.Name);
		}
		if (!string.IsNullOrWhiteSpace(_fileHeader.FileName.TimeStamp))
		{
			output.WriteElementString("time_stamp", _fileHeader.FileName.TimeStamp);
		}
		if (_fileHeader.FileName.AuthorName.Count > 0)
		{
			output.WriteElementString("author", string.Join(", ", _fileHeader.FileName.AuthorName));
		}
		if (_fileHeader.FileName.Organization.Any())
		{
			output.WriteElementString("organization", string.Join(", ", _fileHeader.FileName.Organization));
		}
		if (!string.IsNullOrWhiteSpace(_fileHeader.FileName.PreprocessorVersion))
		{
			output.WriteElementString("preprocessor_version", _fileHeader.FileName.PreprocessorVersion);
		}
		if (!string.IsNullOrWhiteSpace(_fileHeader.FileName.OriginatingSystem))
		{
			output.WriteElementString("originating_system", _fileHeader.FileName.OriginatingSystem);
		}
		if (!string.IsNullOrWhiteSpace(_fileHeader.FileName.AuthorizationName))
		{
			output.WriteElementString("authorization", _fileHeader.FileName.AuthorizationName);
		}
		if (_fileHeader.FileDescription.Description.Any())
		{
			output.WriteElementString("documentation", string.Join(", ", _fileHeader.FileDescription.Description));
		}
		output.WriteEndElement();
	}

	private void WriteEntity(IPersistEntity entity, XmlWriter output, bool onlyOnce, int[] pos = null, string name = null)
	{
		bool flag = _written.Contains(entity.EntityLabel);
		if (!(flag && onlyOnce))
		{
			if (!flag)
			{
				_written.Add(entity.EntityLabel);
			}
			ExpressType expressType = _metadata.ExpressType(entity);
			string localName = name ?? expressType.ExpressName;
			output.WriteStartElement(localName);
			output.WriteAttributeString(flag ? "ref" : "id", $"i{entity.EntityLabel}");
			if (pos != null)
			{
				output.WriteAttributeString("pos", string.Join(" ", pos));
			}
			if (name != null && string.CompareOrdinal(name, expressType.ExpressName) != 0)
			{
				output.WriteAttributeString("type", "http://www.w3.org/2001/XMLSchema-instance", expressType.ExpressName);
			}
			if (!flag)
			{
				WriteProperties(entity, output, expressType);
			}
			else
			{
				output.WriteAttributeString("nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
			}
			output.WriteEndElement();
		}
	}

	private void WriteProperties(IPersistEntity entity, XmlWriter output, ExpressType expressType)
	{
		if (!_propertiesCache.TryGetValue(expressType.Type, out var value))
		{
			value = XmlMetaProperty.GetProperties(expressType, _conf);
			_propertiesCache.Add(expressType.Type, value);
		}
		foreach (XmlMetaProperty item in value)
		{
			WriteProperty(item, entity, output);
		}
	}

	private void WriteProperty(string propName, Type propType, object propVal, XmlWriter output, int[] pos, EntityAttributeAttribute attr, bool wrap = false)
	{
		if (propVal is IOptionalItemSet { Initialized: false })
		{
			return;
		}
		if (propVal == null)
		{
			if (typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(propType) && attr.State == EntityAttributeState.Mandatory)
			{
				output.WriteStartElement(propName);
				output.WriteEndElement();
			}
			return;
		}
		if (propType.GetTypeInfo().IsInterface && typeof(IExpressSelectType).GetTypeInfo().IsAssignableFrom(propType))
		{
			Type type2 = propVal.GetType();
			ExpressType expressType = _metadata.ExpressType(type2);
			string propName2 = ((expressType != null) ? expressType.ExpressName : type2.Name);
			output.WriteStartElement(propName);
			WriteProperty(propName2, type2, propVal, output, null, attr, wrap: true);
			output.WriteEndElement();
			return;
		}
		propType = XmlMetaProperty.GetNonNullableType(propType);
		if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(propType))
		{
			IExpressComplexType expressComplexType = propVal as IExpressComplexType;
			if (expressComplexType != null)
			{
				ExpressType expressType2 = _metadata.ExpressType(propVal.GetType());
				if (expressType2 != null && expressType2.UnderlyingType != null && typeof(IEnumerable<IPersistEntity>).GetTypeInfo().IsAssignableFrom(expressType2.UnderlyingType))
				{
					output.WriteStartElement(expressType2.ExpressName + (wrap ? "-wrapper" : ""));
					int[] array = new int[1];
					foreach (IPersistEntity item in expressComplexType.Properties.Cast<IPersistEntity>())
					{
						WriteEntity(item, output, onlyOnce: false, array);
						array[0]++;
					}
					output.WriteEndElement();
					return;
				}
			}
			string value = ((expressComplexType == null) ? propVal.ToString() : string.Join(" ", expressComplexType.Properties));
			output.WriteStartElement(propName + (wrap ? "-wrapper" : ""));
			if (pos != null)
			{
				output.WriteAttributeString("pos", string.Join(" ", pos));
			}
			output.WriteValue(value);
			output.WriteEndElement();
		}
		else if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propType) && propType != typeof(string))
		{
			if (attr.MaxCardinality != null && attr.MaxCardinality.Length == 1 && attr.MaxCardinality[0] == 1)
			{
				propVal = ((IEnumerable)propVal).Cast<object>().FirstOrDefault();
				if (propVal is IPersistEntity persistEntity)
				{
					WriteEntity(persistEntity, output, onlyOnce: false, null, propName);
				}
				return;
			}
			List<object> list = ((IEnumerable)propVal).Cast<object>().ToList();
			if (attr.Order < 0 && !list.Any())
			{
				return;
			}
			List<int> list2 = new List<int>(pos ?? new int[0]) { 0 };
			int num = list2.Count - 1;
			if (num == 0)
			{
				output.WriteStartElement(propName);
			}
			foreach (object item2 in list)
			{
				ExpressType expressType3 = _metadata.ExpressType(item2.GetType());
				string propName3 = ((expressType3 != null) ? expressType3.ExpressName : item2.GetType().Name);
				WriteProperty(propName3, item2.GetType(), item2, output, list2.ToArray(), attr, wrap: true);
				list2[num]++;
			}
			if (num == 0)
			{
				output.WriteEndElement();
			}
		}
		else if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(propType))
		{
			IPersistEntity persistEntity2 = (IPersistEntity)propVal;
			WriteEntity(persistEntity2, output, onlyOnce: false, pos, propName);
		}
		else
		{
			if (!propType.GetTypeInfo().IsValueType && !(typeof(string) == propType) && !(typeof(byte[]) == propType))
			{
				return;
			}
			Type type3 = propVal.GetType();
			string value2;
			if (type3.GetTypeInfo().IsEnum)
			{
				output.WriteStartElement(propName);
				value2 = propVal.ToString().ToLower();
			}
			else if (type3.GetTypeInfo().UnderlyingSystemType == typeof(bool))
			{
				output.WriteStartElement("boolean-wrapper");
				value2 = (((bool)propVal) ? "true" : "false");
			}
			else if (type3.GetTypeInfo().UnderlyingSystemType == typeof(double) || type3.GetTypeInfo().UnderlyingSystemType == typeof(float))
			{
				output.WriteStartElement("double-wrapper");
				value2 = string.Format(new Part21Formatter(), "{0:R}", propVal);
			}
			else if (type3.GetTypeInfo().UnderlyingSystemType == typeof(short))
			{
				output.WriteStartElement("integer-wrapper");
				value2 = propVal.ToString();
			}
			else if (type3.GetTypeInfo().UnderlyingSystemType == typeof(int) || type3.GetTypeInfo().UnderlyingSystemType == typeof(long))
			{
				output.WriteStartElement("long-wrapper");
				value2 = propVal.ToString();
			}
			else if (type3.GetTypeInfo().UnderlyingSystemType == typeof(string))
			{
				output.WriteStartElement("string-wrapper");
				value2 = string.Format(new Part21Formatter(), "{0}", propVal);
			}
			else
			{
				if (!(type3.GetTypeInfo().UnderlyingSystemType == typeof(byte[])))
				{
					throw new NotSupportedException($"Invalid Value Type {type3.Name}");
				}
				output.WriteStartElement("hexBinary-wrapper");
				byte[] obj = (byte[])propVal;
				StringBuilder stringBuilder = new StringBuilder(obj.Length * 2);
				byte[] array2 = obj;
				foreach (byte b in array2)
				{
					stringBuilder.AppendFormat("{0:X2}", b);
				}
				value2 = stringBuilder.ToString();
			}
			output.WriteAttributeString("pos", string.Join(" ", pos));
			output.WriteValue(value2);
			output.WriteEndElement();
		}
	}

	private void WriteProperty(XmlMetaProperty property, IPersistEntity entity, XmlWriter output)
	{
		object value = property.MetaProperty.PropertyInfo.GetValue(entity, null);
		if (property.IsAttributeValue)
		{
			property.AttributeSetter(value, output);
			return;
		}
		Type propertyType = property.MetaProperty.PropertyInfo.PropertyType;
		string name = property.MetaProperty.PropertyInfo.Name;
		EntityAttributeAttribute entityAttribute = property.MetaProperty.EntityAttribute;
		WriteProperty(name, propertyType, value, output, null, entityAttribute);
	}
}
