using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Step21;

namespace Xbim.IO.Xml;

public class IfcXmlWriter3
{
	private const string Xsi = "http://www.w3.org/2001/XMLSchema-instance";

	private const string Xlink = "http://www.w3.org/1999/xlink";

	private const string Namespace = "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL";

	private const string IfcXsd = "https://standards.buildingsmart.org/IFC/RELEASE/IFC2x3/TC1/XML/IFC2X3.xsd";

	private const string Iso10303Urn = "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common";

	private const string ExXsd = "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL/ex.xsd";

	private HashSet<long> _written;

	public bool WriteInverses;

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

	public IfcXmlWriter3()
	{
		Version version = GetType().Assembly.GetName().Version;
		DateTime now = DateTime.Now;
		TimeStamp = $"{now.Year:0000}-{now.Month:00}-{now.Day:00}T{now.Hour:00}:{now.Minute:00}:{now.Second:00}";
		PreprocessorVersion = $"Xbim.Ifc File Processor version {version}";
		OriginatingSystem = $"Xbim version {version}";
	}

	public void Write(IModel model, XmlWriter output, IEnumerable<IPersistEntity> entities = null)
	{
		_metadata = model.Metadata;
		try
		{
			_written = new HashSet<long>();
			output.WriteStartDocument();
			output.WriteStartElement("ex", "iso_10303_28", "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common");
			output.WriteAttributeString("version", "2.0");
			output.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
			output.WriteAttributeString("xmlns", "xlink", null, "http://www.w3.org/1999/xlink");
			output.WriteAttributeString("xmlns", "ex", null, "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common");
			output.WriteAttributeString("xsi", "schemaLocation", null, string.Format("{0} {1}", "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common", "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL/ex.xsd"));
			_fileHeader = model.Header;
			WriteISOHeader(output);
			output.WriteStartElement("uos", "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL");
			output.WriteAttributeString("id", "uos_1");
			output.WriteAttributeString("description", "Xbim IfcXml Export");
			output.WriteAttributeString("configuration", "i_ifc2x3");
			output.WriteAttributeString("edo", "");
			output.WriteAttributeString("xmlns", "ex", null, "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common");
			output.WriteAttributeString("xmlns", "ifc", null, "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL");
			output.WriteAttributeString("xsi", "schemaLocation", null, string.Format("{0} {1}", "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL", "https://standards.buildingsmart.org/IFC/RELEASE/IFC2x3/TC1/XML/IFC2X3.xsd"));
			if (entities != null)
			{
				foreach (IPersistEntity entity in entities)
				{
					Write(entity, output);
				}
			}
			else
			{
				foreach (IPersistEntity instance in model.Instances)
				{
					Write(instance, output);
				}
			}
			output.WriteEndElement();
			output.WriteEndElement();
			output.WriteEndDocument();
		}
		catch (Exception innerException)
		{
			throw new Exception("Failed to write IfcXml file", innerException);
		}
		finally
		{
			_written = null;
		}
	}

	private void WriteISOHeader(XmlWriter output)
	{
		output.WriteStartElement("ex", "iso_10303_28_header", null);
		WriteInHeader(output, "ex", "name", null, _fileHeader.FileName.Name);
		WriteInHeader(output, "ex", "time_stamp", null, _fileHeader.FileName.TimeStamp);
		if (_fileHeader.FileName.AuthorName.Count > 0)
		{
			foreach (string item in _fileHeader.FileName.AuthorName)
			{
				WriteInHeader(output, "ex", "author", null, item);
			}
		}
		else
		{
			WriteInHeader(output, "ex", "author", null, "");
		}
		if (_fileHeader.FileName.Organization.Count > 0)
		{
			foreach (string item2 in _fileHeader.FileName.Organization)
			{
				WriteInHeader(output, "ex", "organization", null, item2);
			}
		}
		else
		{
			WriteInHeader(output, "ex", "organization", null, "");
		}
		WriteInHeader(output, "ex", "preprocessor_version", null, _fileHeader.FileName.PreprocessorVersion);
		WriteInHeader(output, "ex", "originating_system", null, _fileHeader.FileName.OriginatingSystem);
		WriteInHeader(output, "ex", "authorization", null, _fileHeader.FileName.AuthorizationName);
		if (_fileHeader.FileDescription.Description.Count > 0)
		{
			foreach (string item3 in _fileHeader.FileDescription.Description)
			{
				WriteInHeader(output, "ex", "documentation", null, item3);
			}
		}
		else
		{
			WriteInHeader(output, "ex", "documentation", null, "");
		}
		output.WriteEndElement();
	}

	private void WriteInHeader(XmlWriter output, string prefix, string localName, string ns, string value)
	{
		try
		{
			string value2 = XmlString(value);
			output.WriteElementString(prefix, localName, ns, value2);
		}
		catch (Exception innerException)
		{
			throw new Exception("Failed to write the property called '" + localName + "' in the header section.", innerException);
		}
	}

	private void Write(IPersistEntity entity, XmlWriter output, int pos = -1)
	{
		if (_written.Contains(entity.EntityLabel))
		{
			return;
		}
		_written.Add(entity.EntityLabel);
		ExpressType expressType = _metadata.ExpressType(entity);
		output.WriteStartElement(expressType.Type.Name);
		output.WriteAttributeString("id", $"i{entity.EntityLabel}");
		if (pos > -1)
		{
			output.WriteAttributeString("pos", pos.ToString());
		}
		IEnumerable<ExpressMetaProperty> enumerable;
		if (WriteInverses)
		{
			List<ExpressMetaProperty> list = new List<ExpressMetaProperty>(expressType.Properties.Values);
			list.AddRange(expressType.Inverses);
			enumerable = list;
		}
		else
		{
			enumerable = expressType.Properties.Values;
		}
		foreach (ExpressMetaProperty item in enumerable)
		{
			if (item.EntityAttribute.State != EntityAttributeState.DerivedOverride)
			{
				Type propertyType = item.PropertyInfo.PropertyType;
				object value = item.PropertyInfo.GetValue(entity, null);
				WriteProperty(item.PropertyInfo.Name, propertyType, value, entity, output, -1, item.EntityAttribute);
			}
		}
		output.WriteEndElement();
	}

	private void WriteProperty(string propName, Type propType, object propVal, object entity, XmlWriter output, int pos, EntityAttributeAttribute attr)
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
				output.WriteAttributeString("ex", "cType", null, attr.ListType);
				output.WriteEndElement();
			}
		}
		else if (propType.GetTypeInfo().IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>) && propVal is IExpressValueType)
		{
			if (string.IsNullOrEmpty(propVal.ToString()))
			{
				output.WriteElementString(propName, propVal.ToString());
				return;
			}
			output.WriteStartElement(propName);
			if (pos > -1)
			{
				output.WriteAttributeString("pos", pos.ToString());
			}
			if (propVal is IExpressComplexType expressComplexType)
			{
				IEnumerable<object> properties = expressComplexType.Properties;
				int num = 0;
				foreach (object item in properties)
				{
					WriteProperty(propName, item.GetType(), item, entity, output, num, attr);
					num++;
				}
			}
			else
			{
				output.WriteValue(propVal.ToString());
			}
			output.WriteEndElement();
		}
		else if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(propType))
		{
			Type type = propVal.GetType();
			if (type != propType)
			{
				output.WriteStartElement(propName);
				WriteProperty(type.Name, type, propVal, entity, output, pos, attr);
				output.WriteEndElement();
			}
			else if (pos > -1)
			{
				output.WriteStartElement(propName);
				output.WriteAttributeString("pos", pos.ToString());
				output.WriteValue(propVal.ToString());
				output.WriteEndElement();
			}
			else
			{
				output.WriteElementString(propName, propVal.ToString());
			}
		}
		else if (typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(propType))
		{
			output.WriteStartElement(propName);
			output.WriteAttributeString("ex", "cType", null, attr.ListType);
			int num2 = 0;
			foreach (object item2 in (IExpressEnumerable)propVal)
			{
				WriteProperty(item2.GetType().Name, item2.GetType(), item2, entity, output, num2, attr);
				num2++;
			}
			output.WriteEndElement();
		}
		else if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(propType))
		{
			IPersistEntity persistEntity = (IPersistEntity)propVal;
			if (pos == -1)
			{
				output.WriteStartElement(propName);
			}
			if (_written.Contains(persistEntity.EntityLabel))
			{
				output.WriteStartElement(propVal.GetType().Name);
				output.WriteAttributeString("ref", $"i{persistEntity.EntityLabel}");
				output.WriteAttributeString("xsi", "nil", null, "true");
				if (pos > -1)
				{
					output.WriteAttributeString("pos", pos.ToString());
				}
				output.WriteEndElement();
			}
			else
			{
				Write(persistEntity, output, pos);
			}
			if (pos == -1)
			{
				output.WriteEndElement();
			}
		}
		else if (typeof(IExpressComplexType).GetTypeInfo().IsAssignableFrom(propType))
		{
			_ = ((IExpressComplexType)propVal).Properties;
		}
		else if (propType.GetTypeInfo().IsValueType || propType == typeof(string) || propType == typeof(byte[]))
		{
			Type type2 = propVal.GetType();
			if (type2.GetTypeInfo().IsEnum)
			{
				if (pos > -1)
				{
					output.WriteStartElement(propName);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(propVal.ToString().ToLower());
			}
			else if (type2.GetTypeInfo().UnderlyingSystemType == typeof(bool))
			{
				if (pos > -1)
				{
					output.WriteStartElement("ex", "boolean-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(((bool)propVal) ? "true" : "false");
			}
			else if (type2.GetTypeInfo().UnderlyingSystemType == typeof(double))
			{
				if (pos > -1)
				{
					output.WriteStartElement("ex", "double-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(string.Format(new Part21Formatter(), "{0:R}", propVal));
			}
			else if (type2.GetTypeInfo().UnderlyingSystemType == typeof(short))
			{
				if (pos > -1)
				{
					output.WriteStartElement("ex", "integer-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(propVal.ToString());
			}
			else if (type2.GetTypeInfo().UnderlyingSystemType == typeof(int) || type2.GetTypeInfo().UnderlyingSystemType == typeof(long))
			{
				if (pos > -1)
				{
					output.WriteStartElement("ex", "long-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(propVal.ToString());
			}
			else if (type2.GetTypeInfo().UnderlyingSystemType == typeof(string))
			{
				if (pos > -1)
				{
					output.WriteStartElement("ex", "string-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				output.WriteValue(string.Format(new Part21Formatter(), "{0}", propVal));
			}
			else
			{
				if (!(type2.GetTypeInfo().UnderlyingSystemType == typeof(byte[])))
				{
					throw new ArgumentException($"Invalid Value Type {type2.Name}", "pInfoType");
				}
				if (pos > -1)
				{
					output.WriteStartElement("ex", "hexBinary-wrapper", null);
					output.WriteAttributeString("pos", pos.ToString());
				}
				else
				{
					output.WriteStartElement(propName);
				}
				byte[] obj = (byte[])propVal;
				StringBuilder stringBuilder = new StringBuilder(obj.Length * 2);
				byte[] array = obj;
				foreach (byte b in array)
				{
					stringBuilder.AppendFormat("{0:X2}", b);
				}
				output.WriteValue(stringBuilder.ToString());
			}
			output.WriteEndElement();
		}
		else
		{
			if (!typeof(IExpressSelectType).GetTypeInfo().IsAssignableFrom(propType))
			{
				return;
			}
			if (propVal != null)
			{
				Type type3 = propVal.GetType();
				output.WriteStartElement(propName);
				if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type3))
				{
					WriteProperty(type3.Name, type3, propVal, entity, output, pos, attr);
				}
				else
				{
					WriteProperty(type3.Name, type3, propVal, entity, output, -2, attr);
				}
			}
			output.WriteEndElement();
		}
	}

	private static string XmlString(string text, bool isAttribute = false)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder(text.Length);
		foreach (char c in text)
		{
			switch (c)
			{
			case '<':
				stringBuilder.Append("&lt;");
				break;
			case '>':
				stringBuilder.Append("&gt;");
				break;
			case '&':
				stringBuilder.Append("&amp;");
				break;
			}
			if (isAttribute)
			{
				switch (c)
				{
				case '"':
					stringBuilder.Append("&quot;");
					break;
				case '\'':
					stringBuilder.Append("&apos;");
					break;
				case '\n':
					stringBuilder.Append("&#xA;");
					break;
				case '\r':
					stringBuilder.Append("&#xD;");
					break;
				case '\t':
					stringBuilder.Append("&#x9;");
					break;
				}
			}
			else if (c < ' ')
			{
				uint num = Convert.ToUInt32(c);
				stringBuilder.AppendFormat("&#{0:X};", num);
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}
}
