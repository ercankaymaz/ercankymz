using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Memory;
using Xbim.IO.Step21.Parser;
using Xbim.Ifc4;

namespace Xbim.IO.Xml;

public class XbimXmlReader4
{
	private readonly ExpressMetaData _metadata;

	private readonly GetOrCreateEntity _getOrCreate;

	private readonly FinishEntity _finish;

	private static readonly Dictionary<string, StepParserType> Primitives;

	private Dictionary<string, int> _idMap;

	private int _lastId;

	private readonly string _xsi = "http://www.w3.org/2001/XMLSchema-instance";

	private readonly ILogger Logger;

	private readonly char[] _separator = new char[1] { ' ' };

	private long _streamSize;

	private int _percentageParsed;

	public Dictionary<string, int> IdMap => _idMap;

	public event ReportProgressDelegate ProgressStatus;

	public XbimXmlReader4(GetOrCreateEntity getOrCreate, FinishEntity finish, ExpressMetaData metadata, ILoggerFactory loggerFactory)
		: this(loggerFactory, null)
	{
		if (getOrCreate == null)
		{
			throw new ArgumentNullException("getOrCreate");
		}
		if (finish == null)
		{
			throw new ArgumentNullException("finish");
		}
		if (metadata == null)
		{
			throw new ArgumentNullException("metadata");
		}
		_getOrCreate = getOrCreate;
		_finish = finish;
		_metadata = metadata;
	}

	[Obsolete]
	public XbimXmlReader4(GetOrCreateEntity getOrCreate, FinishEntity finish, ExpressMetaData metadata, ILogger logger)
		: this(null, logger)
	{
		if (getOrCreate == null)
		{
			throw new ArgumentNullException("getOrCreate");
		}
		if (finish == null)
		{
			throw new ArgumentNullException("finish");
		}
		if (metadata == null)
		{
			throw new ArgumentNullException("metadata");
		}
		_getOrCreate = getOrCreate;
		_finish = finish;
		_metadata = metadata;
	}

	private XbimXmlReader4(ILoggerFactory loggerFactory, ILogger logger)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		Logger = logger ?? loggerFactory.CreateLogger<XbimXmlReader4>();
	}

	static XbimXmlReader4()
	{
		Primitives = new Dictionary<string, StepParserType>
		{
			{
				"double-wrapper",
				StepParserType.Real
			},
			{
				"long-wrapper",
				StepParserType.Integer
			},
			{
				"string-wrapper",
				StepParserType.String
			},
			{
				"integer-wrapper",
				StepParserType.Integer
			},
			{
				"boolean-wrapper",
				StepParserType.Boolean
			},
			{
				"logical-wrapper",
				StepParserType.Boolean
			},
			{
				"decimal-wrapper",
				StepParserType.Real
			},
			{
				"hexBinary-wrapper",
				StepParserType.HexaDecimal
			},
			{
				"base64Binary-wrapper",
				StepParserType.Entity
			},
			{
				typeof(double).Name,
				StepParserType.Real
			},
			{
				typeof(long).Name,
				StepParserType.Integer
			},
			{
				typeof(string).Name,
				StepParserType.String
			},
			{
				typeof(int).Name,
				StepParserType.Integer
			},
			{
				typeof(bool).Name,
				StepParserType.Boolean
			},
			{
				"Enum",
				StepParserType.Enum
			}
		};
	}

	public StepFileHeader Read(Stream xmlStream, IModel model, bool onlyHeader = false)
	{
		using XmlReader xmlReader = XmlReader.Create(xmlStream);
		_streamSize = xmlStream.Length;
		_idMap = new Dictionary<string, int>();
		StepFileHeader stepFileHeader = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, model);
		bool flag = true;
		bool flag2 = true;
		while (xmlReader.Read())
		{
			if (xmlReader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			if (flag)
			{
				ReadSchemaInHeader(xmlReader, stepFileHeader);
				flag = false;
				continue;
			}
			if (flag2)
			{
				flag2 = false;
				string text = xmlReader.LocalName.ToLowerInvariant();
				if ((text == "header" || text == "iso_10303_28_header") && !xmlReader.IsEmptyElement)
				{
					stepFileHeader = ReadHeader(xmlReader, stepFileHeader);
					continue;
				}
			}
			if (xmlReader.LocalName == "uos")
			{
				ReadSchemaInHeader(xmlReader, stepFileHeader);
			}
			if (onlyHeader)
			{
				return stepFileHeader;
			}
			ReadEntity(xmlReader);
			if (_streamSize != -1 && this.ProgressStatus != null)
			{
				int num = Convert.ToInt32((double)xmlStream.Position / (double)_streamSize * 100.0);
				if (num > _percentageParsed)
				{
					this.ProgressStatus(_percentageParsed, "Parsing");
					_percentageParsed = num;
				}
			}
		}
		if (this.ProgressStatus != null)
		{
			this.ProgressStatus(100, "Parsing");
		}
		return stepFileHeader;
	}

	private void ReadSchemaInHeader(XmlReader input, IStepFileHeader header)
	{
		if (input.IsEmptyElement || !input.HasAttributes)
		{
			return;
		}
		while (input.MoveToNextAttribute())
		{
			if (input.Value == "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL")
			{
				header.FileSchema.Schemas.Add("IFC2X3");
				break;
			}
			if (input.Value == "http://www.buildingsmart-tech.org/ifcXML/MVD4/IFC4" || input.Value == "http://www.buildingsmart-tech.org/ifcXML/IFC4/Add1")
			{
				header.FileSchema.Schemas.Add("IFC4");
				header.FileSchema.Schemas.Add("IFC4Add1");
				break;
			}
			if (input.Value == "http://www.buildingsmart-tech.org/ifcXML/IFC4/final")
			{
				header.FileSchema.Schemas.Add("IFC4");
				break;
			}
			if (input.Value == "http://www.buildingsmart-tech.org/ifcXML/IFC4/Add2")
			{
				header.FileSchema.Schemas.Add("IFC4");
				break;
			}
		}
		input.MoveToElement();
	}

	private ExpressType GetExpresType(XmlReader input)
	{
		string typeName = (input.GetAttribute("type", _xsi) ?? input.LocalName).ToUpper();
		if (_metadata.TryGetExpressType(typeName, out var expressType))
		{
			return expressType;
		}
		typeName = input.LocalName.ToUpper();
		if (!typeName.Contains("-"))
		{
			return null;
		}
		typeName = typeName.Replace("-WRAPPER", "");
		_metadata.TryGetExpressType(typeName, out expressType);
		return expressType;
	}

	private IPersistEntity ReadEntity(XmlReader input, Type suggestedType = null)
	{
		ExpressType expressType = GetExpresType(input);
		if (expressType == null && suggestedType != null && !suggestedType.IsAbstract)
		{
			expressType = _metadata.ExpressType(suggestedType);
		}
		if (expressType == null)
		{
			throw new XbimParserException((input.GetAttribute("type") ?? input.LocalName) + "is not an IPersistEntity type");
		}
		bool isRefType;
		int? id = GetId(input, expressType, out isRefType);
		if (!id.HasValue)
		{
			throw new XbimParserException("Wrong entity XML format");
		}
		IPersistEntity persistEntity = _getOrCreate(id.Value, expressType.Type);
		if (isRefType)
		{
			if (!input.IsEmptyElement)
			{
				int depth = input.Depth;
				bool flag = false;
				while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth))
				{
					flag = true;
				}
				if (flag)
				{
					Logger.LogWarning("Reference to element {0}, ref='{1}' is not empty. This is a wrong practise.", persistEntity.ExpressType.Name, id);
				}
			}
			return persistEntity;
		}
		while (input.MoveToNextAttribute())
		{
			ExpressMetaProperty metaProperty = GetMetaProperty(expressType, input.LocalName);
			if (metaProperty != null)
			{
				SetPropertyFromString(metaProperty, persistEntity, input.Value, null);
			}
		}
		input.MoveToElement();
		if (input.IsEmptyElement)
		{
			_finish(persistEntity);
			return persistEntity;
		}
		int depth2 = input.Depth;
		while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth2))
		{
			if (input.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			ExpressMetaProperty metaProperty2 = GetMetaProperty(expressType, input.LocalName);
			if (metaProperty2 != null)
			{
				SetPropertyFromElement(metaProperty2, persistEntity, input, null);
				if (input.NodeType == XmlNodeType.EndElement && input.Depth == depth2)
				{
					break;
				}
			}
		}
		_finish(persistEntity);
		return persistEntity;
	}

	private bool InitPropertyValue(Type type, string value, out IPropertyValue propertyValue)
	{
		PropertyValue propertyValue2 = default(PropertyValue);
		if (type == typeof(bool))
		{
			propertyValue2.Init((string.CompareOrdinal(value, "true") == 0) ? ".T." : ".F.", StepParserType.Boolean);
			propertyValue = propertyValue2;
			return true;
		}
		if (type == typeof(bool?))
		{
			if (string.CompareOrdinal(value, "unknown") == 0)
			{
				propertyValue = null;
				return false;
			}
			propertyValue2.Init((string.CompareOrdinal(value, "true") == 0) ? ".T." : ".F.", StepParserType.Boolean);
			propertyValue = propertyValue2;
			return true;
		}
		if (typeof(string) == type)
		{
			propertyValue2.Init("'" + value + "'", StepParserType.String);
			propertyValue = propertyValue2;
			return true;
		}
		if (typeof(int) == type || typeof(long) == type)
		{
			propertyValue2.Init(value, StepParserType.Integer);
			propertyValue = propertyValue2;
			return true;
		}
		if (typeof(float) == type || typeof(double) == type)
		{
			propertyValue2.Init(value, StepParserType.Real);
			propertyValue = propertyValue2;
			return true;
		}
		if (typeof(byte[]) == type)
		{
			propertyValue2.Init("\"0" + value + "\"", StepParserType.HexaDecimal);
			propertyValue = propertyValue2;
			return true;
		}
		throw new XbimParserException("Unexpected type: " + type.Name);
	}

	private void Parse(IPersistEntity entity, int propIndex, IPropertyValue value, int[] nested)
	{
		try
		{
			entity.Parse(propIndex, value, nested);
		}
		catch (InvalidCastException exception)
		{
			ExpressMetaProperty expressMetaProperty = entity.ExpressType.Properties[propIndex + 1];
			StepParserType type = value.Type;
			string text = "";
			switch (type)
			{
			case StepParserType.Boolean:
				text = "Boolean";
				break;
			case StepParserType.Enum:
				text = "Enumeration value " + value.EnumVal;
				break;
			case StepParserType.Entity:
				text = value.EntityVal.GetType().Name;
				if (value.EntityVal is IPersistEntity entity2)
				{
					string errIdentityInfo = GetErrIdentityInfo(entity2);
					if (!string.IsNullOrWhiteSpace(errIdentityInfo))
					{
						text = text + " (" + errIdentityInfo + ")";
					}
				}
				break;
			case StepParserType.HexaDecimal:
				text = "HexaDecimal";
				break;
			case StepParserType.Integer:
				text = "Integer";
				break;
			case StepParserType.Real:
				text = "Real";
				break;
			case StepParserType.String:
				text = "String";
				break;
			default:
				text = "Undefined";
				break;
			}
			string errIdentityInfo2 = GetErrIdentityInfo(entity);
			string message = $"{text} is not assignable to {entity.ExpressType.ExpressName}.{expressMetaProperty.Name} ({errIdentityInfo2})";
			Logger.LogError(new EventId(1000, "Failed Assignment"), exception, message);
		}
	}

	private string GetErrIdentityInfo(IPersistEntity entity)
	{
		string key = _idMap.FirstOrDefault((KeyValuePair<string, int> kv) => kv.Value == entity.EntityLabel).Key;
		ExpressType expressType = entity.ExpressType;
		ExpressMetaProperty value = expressType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.Name == "GlobalId").Value;
		ExpressMetaProperty value2 = expressType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.Name == "Name").Value;
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrWhiteSpace(key))
		{
			stringBuilder.AppendFormat("id/ref={0} ", key);
		}
		if (value != null)
		{
			object value3 = value.PropertyInfo.GetValue(entity);
			if (value3 != null && !string.IsNullOrWhiteSpace(value3.ToString()))
			{
				stringBuilder.AppendFormat("guid='{0}' ", value3.ToString());
			}
		}
		if (value2 != null)
		{
			object value4 = value2.PropertyInfo.GetValue(entity);
			if (value4 != null && !string.IsNullOrWhiteSpace(value4.ToString()))
			{
				stringBuilder.AppendFormat("name='{0}' ", value4.ToString());
			}
		}
		return stringBuilder.ToString().Trim();
	}

	private void SetPropertyFromElement(ExpressMetaProperty property, IPersistEntity entity, XmlReader input, int[] pos, ExpressType valueType = null)
	{
		string localName = input.LocalName;
		Type type = ((valueType != null) ? valueType.Type : GetNonNullableType(property.PropertyInfo.PropertyType));
		int propIndex = property.EntityAttribute.Order - 1;
		ExpressType expressType = valueType ?? GetExpresType(input);
		try
		{
			if (typeof(IExpressSelectType).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsInterface)
			{
				int depth = input.Depth;
				while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth))
				{
					if (input.NodeType == XmlNodeType.Element)
					{
						expressType = GetExpresType(input);
						if (expressType == null)
						{
							throw new XbimParserException("Unexpected select data type " + localName);
						}
						if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(expressType.Type))
						{
							SetPropertyFromElement(property, entity, input, pos, expressType);
							break;
						}
						if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(expressType.Type))
						{
							SetPropertyFromElement(property, entity, input, pos, expressType);
							break;
						}
						throw new XbimParserException("Unexpected select data type " + expressType.Name);
					}
				}
				return;
			}
			if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type))
			{
				Type underlyingComplexType = expressType.UnderlyingComplexType;
				if (type == property.PropertyInfo.PropertyType && (!(underlyingComplexType != null) || !typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(underlyingComplexType)))
				{
					string value = input.ReadElementContentAsString();
					SetPropertyFromString(property, entity, value, pos);
				}
				else if (underlyingComplexType != null)
				{
					Type typeFromHandle = typeof(List<>);
					typeFromHandle = typeFromHandle.MakeGenericType(underlyingComplexType);
					if (!(Activator.CreateInstance(typeFromHandle) is IList list))
					{
						throw new XbimParserException("Initialization of " + typeFromHandle.Name + " failed.");
					}
					if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(underlyingComplexType))
					{
						if (input.IsEmptyElement)
						{
							return;
						}
						int depth2 = input.Depth;
						while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth2))
						{
							if (input.NodeType == XmlNodeType.Element)
							{
								IPersistEntity value2 = ReadEntity(input);
								list.Add(value2);
								if (input.NodeType == XmlNodeType.EndElement && input.Depth == depth2)
								{
									break;
								}
							}
						}
						object value3 = Activator.CreateInstance(expressType.Type, list);
						PropertyValue propertyValue = default(PropertyValue);
						propertyValue.Init(value3);
						Parse(entity, propIndex, propertyValue, null);
					}
					else
					{
						string value4 = input.ReadElementContentAsString();
						SetPropertyFromString(property, entity, value4, pos);
					}
				}
				else
				{
					string text = input.ReadElementContentAsString();
					if (property.EnumerableType == expressType.Type)
					{
						InitPropertyValue(expressType.UnderlyingType, text, out var propertyValue2);
						Parse(entity, propIndex, propertyValue2, pos);
						return;
					}
					PropertyValue propertyValue3 = default(PropertyValue);
					object value5 = Activator.CreateInstance(expressType.Type, text);
					propertyValue3.Init(value5);
					Parse(entity, propIndex, propertyValue3, pos);
				}
				return;
			}
			if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(type) || (typeof(IEnumerable).IsAssignableFrom(type) && property.EntityAttribute.MaxCardinality != null && property.EntityAttribute.MaxCardinality[0] == 1) || (typeof(IEnumerable).IsAssignableFrom(type) && input.GetAttribute("type", _xsi) != null))
			{
				if (typeof(IEnumerable).IsAssignableFrom(type) && property.EntityAttribute.MaxCardinality != null && property.EntityAttribute.MaxCardinality[0] == 1)
				{
					type = type.GetGenericArguments()[0];
				}
				IPersistEntity persistEntity = ReadEntity(input, type);
				PropertyValue propertyValue4 = default(PropertyValue);
				if (property.IsInverse)
				{
					propertyValue4.Init(entity);
					string remotePropName = property.InverseAttributeProperty.RemoteProperty;
					ExpressMetaProperty value6 = persistEntity.ExpressType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.Name == remotePropName).Value;
					if (value6 == null)
					{
						throw new XbimParserException("Non existing counterpart to " + property.Name);
					}
					Parse(persistEntity, value6.EntityAttribute.Order - 1, propertyValue4, null);
				}
				else
				{
					propertyValue4.Init(persistEntity);
					Parse(entity, propIndex, propertyValue4, null);
				}
				return;
			}
			if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type))
			{
				if (input.IsEmptyElement)
				{
					return;
				}
				int depth3 = input.Depth;
				while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth3))
				{
					if (input.NodeType != XmlNodeType.Element)
					{
						continue;
					}
					string attribute = input.GetAttribute("pos");
					pos = null;
					if (!string.IsNullOrWhiteSpace(attribute))
					{
						List<int> list2 = (from i in attribute.Split(_separator, StringSplitOptions.RemoveEmptyEntries)
							select Convert.ToInt32(i)).ToList();
						if (list2.Count > 0)
						{
							list2.RemoveAt(list2.Count - 1);
						}
						if (list2.Count > 0)
						{
							pos = list2.ToArray();
						}
					}
					localName = input.LocalName;
					if (Primitives.ContainsKey(input.LocalName))
					{
						string value7 = input.ReadElementContentAsString();
						PropertyValue propertyValue5 = default(PropertyValue);
						propertyValue5.Init(value7, Primitives[localName]);
						Parse(entity, propIndex, propertyValue5, pos);
						if (input.NodeType == XmlNodeType.EndElement && input.Depth == depth3)
						{
							break;
						}
						continue;
					}
					ExpressType expresType = GetExpresType(input);
					if (expresType == null)
					{
						throw new XbimParserException("Unexpected type " + localName);
					}
					SetPropertyFromElement(property, entity, input, pos, expresType);
					if (input.NodeType == XmlNodeType.EndElement && input.Depth == depth3)
					{
						break;
					}
				}
				return;
			}
		}
		catch (XbimParserException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			throw new XbimParserException(ex2.Message, ex2);
		}
		throw new XbimParserException("Unexpected type: " + type.Name);
	}

	private void SetPropertyFromString(ExpressMetaProperty property, IPersistEntity entity, string value, int[] pos, Type valueType = null)
	{
		int propIndex = property.EntityAttribute.Order - 1;
		Type type = valueType ?? property.PropertyInfo.PropertyType;
		type = GetNonNullableType(type);
		PropertyValue propertyValue = default(PropertyValue);
		try
		{
			if (type.GetTypeInfo().IsValueType || type == typeof(string))
			{
				if (typeof(IExpressComplexType).GetTypeInfo().IsAssignableFrom(type))
				{
					ExpressType expressType = _metadata.ExpressType(type);
					string[] array = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
					Type underlyingComplexType = expressType.UnderlyingComplexType;
					string[] array2 = array;
					foreach (string value2 in array2)
					{
						if (InitPropertyValue(underlyingComplexType, value2, out var propertyValue2))
						{
							Parse(entity, propIndex, propertyValue2, pos);
						}
					}
				}
				else if (type.GetTypeInfo().IsEnum)
				{
					propertyValue.Init(value, StepParserType.Enum);
					Parse(entity, propIndex, propertyValue, pos);
				}
				else
				{
					if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type))
					{
						type = _metadata.ExpressType(type).UnderlyingType;
					}
					if (InitPropertyValue(type, value, out var propertyValue3))
					{
						Parse(entity, propIndex, propertyValue3, pos);
					}
				}
				return;
			}
			if (!typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type) || !type.GetTypeInfo().IsGenericType)
			{
				throw new XbimParserException("Unexpected enumerable type " + type.Name);
			}
			Type type2 = type.GetTypeInfo().GetGenericArguments()[0];
			if (type2.GetTypeInfo().IsValueType || type2 == typeof(string))
			{
				string[] array2 = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
				foreach (string value3 in array2)
				{
					SetPropertyFromString(property, entity, value3, pos, type2);
				}
			}
			else if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type2))
			{
				int num = ((property.EntityAttribute.MaxCardinality != null) ? property.EntityAttribute.MaxCardinality.LastOrDefault() : 0);
				int num2 = ((property.EntityAttribute.MinCardinality != null) ? property.EntityAttribute.MinCardinality.LastOrDefault() : (-1));
				if (num != num2)
				{
					throw new XbimParserException(property.Name + " is not rectangular so it can't be serialized as a simple text string");
				}
				string[] array3 = value.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
				Type type3 = GetNonGenericType(type2);
				if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type3))
				{
					type3 = (_metadata.ExpressType(type3) ?? throw new XbimParserException("Unexpected data type " + type3.Name)).UnderlyingType;
				}
				for (int j = 0; j < array3.Length; j++)
				{
					InitPropertyValue(type3, array3[j], out var propertyValue4);
					int num3 = j / num;
					Parse(entity, propIndex, propertyValue4, new int[1] { num3 });
				}
			}
		}
		catch (XbimParserException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			throw new XbimParserException(ex2.Message, ex2);
		}
	}

	private static Type GetNonGenericType(Type type)
	{
		if (!type.GetTypeInfo().IsGenericType)
		{
			return type;
		}
		while (type.GetTypeInfo().IsGenericType && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type))
		{
			Type[] genericArguments = type.GetTypeInfo().GetGenericArguments();
			if (!genericArguments.Any())
			{
				break;
			}
			type = genericArguments[0];
		}
		return type;
	}

	private static Type GetNonNullableType(Type type)
	{
		if (!type.GetTypeInfo().IsValueType)
		{
			return type;
		}
		if (!type.GetTypeInfo().IsGenericType)
		{
			return type;
		}
		if (type.GetGenericTypeDefinition() != typeof(Nullable<>))
		{
			return type;
		}
		return type.GetTypeInfo().GetGenericArguments()[0];
	}

	private static ExpressMetaProperty GetMetaProperty(ExpressType expType, string name)
	{
		return expType.Properties.FirstOrDefault((KeyValuePair<int, ExpressMetaProperty> p) => string.CompareOrdinal(p.Value.Name, name) == 0).Value ?? expType.Inverses.FirstOrDefault((ExpressMetaProperty p) => string.CompareOrdinal(p.Name, name) == 0);
	}

	private int? GetId(XmlReader input, ExpressType expressType, out bool isRefType)
	{
		isRefType = false;
		int? result = null;
		string attribute = input.GetAttribute("id");
		if (string.IsNullOrEmpty(attribute))
		{
			attribute = input.GetAttribute("ref");
			if (!string.IsNullOrEmpty(attribute))
			{
				isRefType = true;
			}
		}
		if (!string.IsNullOrEmpty(attribute))
		{
			if (!_idMap.TryGetValue(attribute, out var value))
			{
				_lastId++;
				result = _lastId;
				_idMap.Add(attribute, result.Value);
			}
			else
			{
				result = value;
			}
		}
		else if (!typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(expressType.Type))
		{
			_lastId++;
			result = _lastId;
		}
		return result;
	}

	private bool IsExpressEntity(string elementName, out ExpressType expressType)
	{
		return _metadata.TryGetExpressType(elementName.ToUpperInvariant(), out expressType);
	}

	private StepFileHeader ReadHeader(XmlReader input, StepFileHeader header)
	{
		int depth = input.Depth;
		while (input.Read() && (input.NodeType != XmlNodeType.EndElement || input.Depth != depth))
		{
			if (input.NodeType == XmlNodeType.Element)
			{
				switch (input.LocalName.ToLowerInvariant())
				{
				case "name":
					header.FileName.Name = GetTextFromElement(input);
					break;
				case "time_stamp":
					header.FileName.TimeStamp = GetTextFromElement(input);
					break;
				case "author":
					header.FileName.AuthorName.Add(GetTextFromElement(input));
					break;
				case "organization":
					header.FileName.Organization.Add(GetTextFromElement(input));
					break;
				case "preprocessor_version":
					header.FileName.PreprocessorVersion = GetTextFromElement(input);
					break;
				case "originating_system":
					header.FileName.OriginatingSystem = GetTextFromElement(input);
					break;
				case "authorization":
					header.FileName.AuthorizationName = GetTextFromElement(input);
					break;
				case "documentation":
					header.FileDescription.Description.Add(GetTextFromElement(input));
					break;
				}
			}
		}
		return header;
	}

	private string GetTextFromElement(XmlReader input)
	{
		if (input.NodeType != XmlNodeType.Element || input.IsEmptyElement)
		{
			return null;
		}
		if (!input.Read())
		{
			return null;
		}
		if (input.NodeType == XmlNodeType.EndElement)
		{
			return null;
		}
		if (input.NodeType != XmlNodeType.Text)
		{
			throw new FormatException("Unexpected node type");
		}
		return input.Value;
	}

	[Obsolete("Prefer ILogger constructor injection")]
	public static IStepFileHeader ReadHeader(Stream input, ILogger logger)
	{
		XbimXmlReader4 xbimXmlReader = new XbimXmlReader4(null, logger);
		MemoryModel model = new MemoryModel(new EntityFactoryIfc4(), logger, 0);
		return xbimXmlReader.Read(input, model, onlyHeader: true);
	}

	public static IStepFileHeader ReadHeader(Stream input)
	{
		ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();
		XbimXmlReader4 xbimXmlReader = new XbimXmlReader4(loggerFactory, null);
		MemoryModel model = new MemoryModel(new EntityFactoryIfc4(), loggerFactory);
		return xbimXmlReader.Read(input, model, onlyHeader: true);
	}

	public static XmlSchemaVersion ReadSchemaVersion(XmlReader input)
	{
		int num = 0;
		while (input.Read())
		{
			if (num > 100)
			{
				return XmlSchemaVersion.Unknown;
			}
			if (input.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			num++;
			while (input.MoveToNextAttribute())
			{
				if (string.Equals(input.Value, "http://www.iai-tech.org/ifcXML/IFC2x3/FINAL", StringComparison.OrdinalIgnoreCase) || string.Equals(input.Value, "http://www.iai-international.org/ifcXML2/RC2/IFC2X3", StringComparison.OrdinalIgnoreCase))
				{
					return XmlSchemaVersion.Ifc2x3;
				}
				if (string.Equals(input.Value, "http://www.buildingsmart-tech.org/ifcXML/MVD4/IFC", StringComparison.OrdinalIgnoreCase) || string.Equals(input.Value, "http://www.buildingsmart-tech.org/ifcXML/IFC4/Add1", StringComparison.OrdinalIgnoreCase))
				{
					return XmlSchemaVersion.Ifc4Add1;
				}
				if (string.Equals(input.Value, "http://www.buildingsmart-tech.org/ifcXML/IFC4/final", StringComparison.OrdinalIgnoreCase))
				{
					return XmlSchemaVersion.Ifc4;
				}
				if (string.Equals(input.Value, "http://www.buildingsmart-tech.org/ifcXML/IFC4/Add2", StringComparison.OrdinalIgnoreCase))
				{
					return XmlSchemaVersion.Ifc4Add2;
				}
			}
			input.MoveToElement();
		}
		return XmlSchemaVersion.Unknown;
	}
}
