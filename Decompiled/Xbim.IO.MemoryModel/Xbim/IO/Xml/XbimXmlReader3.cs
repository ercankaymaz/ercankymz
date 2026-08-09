using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Xbim.Common;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO.Xml;

public class XbimXmlReader3
{
	private abstract class XmlNode
	{
		public readonly XmlNode Parent;

		public int? Position;

		protected XmlNode()
		{
		}

		protected XmlNode(XmlNode parent)
		{
			Parent = parent;
		}
	}

	private class XmlEntity : XmlNode
	{
		public readonly IPersistEntity Entity;

		public XmlEntity(XmlNode parent, IPersistEntity ent)
			: base(parent)
		{
			Entity = ent;
		}
	}

	private class XmlExpressType : XmlNode
	{
		public readonly Type Type;

		public string Value { get; set; }

		public XmlExpressType(XmlNode parent, Type type)
			: base(parent)
		{
			Type = type;
		}
	}

	private class XmlBasicType : XmlNode
	{
		public readonly StepParserType Type;

		public string Value { get; set; }

		public XmlBasicType(XmlNode parent, StepParserType type)
			: base(parent)
		{
			Type = type;
		}
	}

	private class XmlProperty : XmlNode
	{
		public readonly PropertyInfo Property;

		public readonly int PropertyIndex;

		public XmlProperty(XmlNode parent, PropertyInfo prop, int propIndex)
			: base(parent)
		{
			Property = prop;
			PropertyIndex = propIndex;
		}

		public void SetValue(string val, StepParserType parserType)
		{
			if (parserType != StepParserType.Boolean || string.Compare(val, "unknown", StringComparison.OrdinalIgnoreCase) != 0)
			{
				PropertyValue propertyValue = default(PropertyValue);
				propertyValue.Init(val, parserType);
				((XmlEntity)Parent).Entity.Parse(PropertyIndex - 1, propertyValue, null);
			}
		}

		public void SetValue(object o)
		{
			PropertyValue propertyValue = default(PropertyValue);
			propertyValue.Init(o);
			((XmlEntity)Parent).Entity.Parse(PropertyIndex - 1, propertyValue, null);
		}
	}

	public enum CollectionType
	{
		List,
		ListUnique,
		Set
	}

	private class XmlUosCollection : XmlCollectionProperty
	{
		internal override void SetCollection(IModel model, XmlReader reader)
		{
		}
	}

	private class XmlCollectionProperty : XmlNode
	{
		public readonly List<XmlNode> Entities = new List<XmlNode>();

		public readonly PropertyInfo Property;

		public CollectionType CType = CollectionType.Set;

		public readonly int PropertyIndex;

		internal XmlCollectionProperty()
		{
		}

		public XmlCollectionProperty(XmlNode parent, PropertyInfo prop, int propIndex)
			: base(parent)
		{
			Property = prop;
			PropertyIndex = propIndex;
		}

		public static int CompareNodes(XmlNode a, XmlNode b)
		{
			if (a.Position > b.Position)
			{
				return 1;
			}
			if (a.Position < b.Position)
			{
				return -1;
			}
			return 0;
		}

		internal virtual void SetCollection(IModel model, XmlReader reader)
		{
			switch (CType)
			{
			case CollectionType.List:
			case CollectionType.ListUnique:
				Entities.Sort(CompareNodes);
				break;
			default:
				throw new Exception("Unknown list type, " + CType);
			case CollectionType.Set:
				break;
			}
		}
	}

	private readonly ExpressMetaData _metadata;

	private readonly GetOrCreateEntity _create;

	private readonly FinishEntity _finish;

	private static readonly Dictionary<string, StepParserType> Primitives;

	private Dictionary<string, int> _idMap;

	private int _lastId;

	private XmlNode _currentNode;

	private int _entitiesParsed;

	private string _expressNamespace;

	private string _cTypeAttribute;

	private string _posAttribute;

	private long _streamSize;

	private int _percentageParsed;

	public event ReportProgressDelegate ProgressStatus;

	public XbimXmlReader3(GetOrCreateEntity create, FinishEntity finish, ExpressMetaData metadata)
	{
		if (create == null)
		{
			throw new ArgumentNullException("create");
		}
		if (finish == null)
		{
			throw new ArgumentNullException("finish");
		}
		if (metadata == null)
		{
			throw new ArgumentNullException("metadata");
		}
		_create = create;
		_finish = finish;
		_metadata = metadata;
	}

	static XbimXmlReader3()
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

	private void StartElement(XmlReader input)
	{
		string localName = input.LocalName;
		bool isRefType;
		int? id = GetId(input, out isRefType);
		int index;
		ExpressMetaProperty prop;
		if (id.HasValue && IsIfcEntity(localName, out var expressType))
		{
			IPersistEntity persistEntity = _create(id.Value, expressType.Type);
			XmlEntity xmlEntity = new XmlEntity(_currentNode, persistEntity);
			if (input.IsEmptyElement && !isRefType)
			{
				_entitiesParsed++;
				_finish(persistEntity);
			}
			string attribute = input.GetAttribute(_posAttribute);
			if (string.IsNullOrEmpty(attribute))
			{
				attribute = input.GetAttribute("pos");
			}
			if (!string.IsNullOrEmpty(attribute))
			{
				xmlEntity.Position = Convert.ToInt32(attribute);
			}
			if (!input.IsEmptyElement)
			{
				_currentNode = xmlEntity;
			}
			else if (_currentNode is XmlProperty)
			{
				((XmlProperty)_currentNode).SetValue(persistEntity);
			}
			else if (!(_currentNode is XmlUosCollection) && _currentNode is XmlCollectionProperty && !(_currentNode.Parent is XmlUosCollection))
			{
				((XmlCollectionProperty)_currentNode).Entities.Add(xmlEntity);
			}
		}
		else if (input.IsEmptyElement)
		{
			if (IsIfcProperty(localName, out index, out prop))
			{
				XmlProperty xmlProperty = new XmlProperty(_currentNode, prop.PropertyInfo, index);
				PropertyValue propertyValue = default(PropertyValue);
				Type type = xmlProperty.Property.PropertyType;
				if (typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(type))
				{
					return;
				}
				if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					type = Nullable.GetUnderlyingType(type);
				}
				IExpressValueType expressValueType = null;
				if (type != null && typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type))
				{
					expressValueType = (IExpressValueType)Activator.CreateInstance(type);
				}
				StepParserType type2 = StepParserType.Undefined;
				if (expressValueType != null)
				{
					type2 = Primitives[expressValueType.UnderlyingSystemType.Name];
				}
				else if (type != null && type.GetTypeInfo().IsEnum)
				{
					type2 = StepParserType.Enum;
				}
				else if (type != null)
				{
					type2 = Primitives[type.Name];
				}
				string text = type2.ToString().ToLower();
				if (!(text == "string"))
				{
					if (text == "boolean")
					{
						propertyValue.Init(Convert.ToBoolean(input.Value) ? ".T." : ".F", type2);
					}
					else
					{
						propertyValue.Init(input.Value, type2);
					}
				}
				else
				{
					propertyValue.Init("'" + input.Value + "'", type2);
				}
				((XmlEntity)xmlProperty.Parent).Entity.Parse(xmlProperty.PropertyIndex - 1, propertyValue, null);
			}
			else if (IsIfcType(localName, out expressType))
			{
				IPersist value = (IPersist)Activator.CreateInstance(args: new object[1] { "" }, type: expressType.Type);
				((XmlProperty)_currentNode).SetValue(value);
			}
		}
		else if (!id.HasValue && IsIfcProperty(localName, out index, out prop))
		{
			string attribute2 = input.GetAttribute(_cTypeAttribute);
			if (string.IsNullOrEmpty(attribute2))
			{
				attribute2 = input.GetAttribute("cType");
			}
			if (IsCollection(prop))
			{
				XmlCollectionProperty xmlCollectionProperty = new XmlCollectionProperty(_currentNode, prop.PropertyInfo, index);
				switch (attribute2)
				{
				case "list":
					xmlCollectionProperty.CType = CollectionType.List;
					break;
				case "list-unique":
					xmlCollectionProperty.CType = CollectionType.ListUnique;
					break;
				case "set":
					xmlCollectionProperty.CType = CollectionType.Set;
					break;
				default:
					xmlCollectionProperty.CType = CollectionType.List;
					break;
				}
				_currentNode = xmlCollectionProperty;
			}
			else
			{
				XmlNode xmlNode = new XmlProperty(_currentNode, prop.PropertyInfo, index);
				if (_currentNode is XmlCollectionProperty xmlCollectionProperty2 && !(xmlCollectionProperty2.Parent is XmlUosCollection))
				{
					xmlCollectionProperty2.Entities.Add(xmlNode);
				}
				if (!input.IsEmptyElement)
				{
					_currentNode = xmlNode;
				}
			}
		}
		else if (!id.HasValue && IsIfcType(localName, out expressType))
		{
			XmlNode xmlNode2 = new XmlExpressType(_currentNode, expressType.Type);
			if (_currentNode is XmlCollectionProperty xmlCollectionProperty3 && !(xmlCollectionProperty3.Parent is XmlUosCollection))
			{
				xmlCollectionProperty3.Entities.Add(xmlNode2);
			}
			if (!input.IsEmptyElement)
			{
				_currentNode = xmlNode2;
			}
		}
		else
		{
			if (id.HasValue || !IsPrimitiveType(localName, out var basicType))
			{
				throw new Exception("Illegal XML element tag");
			}
			XmlNode xmlNode3 = new XmlBasicType(_currentNode, basicType);
			if (_currentNode is XmlCollectionProperty xmlCollectionProperty4 && !(xmlCollectionProperty4.Parent is XmlUosCollection))
			{
				xmlCollectionProperty4.Entities.Add(xmlNode3);
			}
			if (!input.IsEmptyElement)
			{
				_currentNode = xmlNode3;
			}
		}
	}

	private bool IsIfcProperty(string elementName, out int index, out ExpressMetaProperty prop)
	{
		if (_currentNode is XmlEntity xmlEntity && !_metadata.TryGetExpressType(elementName.ToUpper(), out var _))
		{
			using IEnumerator<KeyValuePair<int, ExpressMetaProperty>> enumerator = _metadata.ExpressType(xmlEntity.Entity).Properties.Where((KeyValuePair<int, ExpressMetaProperty> p) => p.Value.PropertyInfo.Name == elementName).GetEnumerator();
			if (enumerator.MoveNext())
			{
				KeyValuePair<int, ExpressMetaProperty> current = enumerator.Current;
				prop = current.Value;
				index = current.Key;
				return true;
			}
		}
		prop = null;
		index = -1;
		return false;
	}

	private bool IsCollection(ExpressMetaProperty prop)
	{
		return typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(prop.PropertyInfo.PropertyType);
	}

	private bool IsPrimitiveType(string elementName, out StepParserType basicType)
	{
		return Primitives.TryGetValue(elementName, out basicType);
	}

	private bool IsIfcType(string elementName, out ExpressType expressType)
	{
		bool flag = _metadata.TryGetExpressType(elementName.ToUpper(), out expressType);
		if (!flag && elementName.Contains("-wrapper") && !elementName.StartsWith(_expressNamespace))
		{
			string text = elementName.Substring(0, elementName.LastIndexOf("-", StringComparison.Ordinal));
			flag = _metadata.TryGetExpressType(text.ToUpper(), out expressType);
		}
		if (flag)
		{
			return typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(expressType.Type);
		}
		return false;
	}

	private int? GetId(XmlReader input, out bool isRefType)
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
		ExpressType expressType;
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
		else if (IsIfcEntity(input.LocalName, out expressType) && !typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(expressType.Type))
		{
			_lastId++;
			result = _lastId;
		}
		return result;
	}

	private bool IsIfcEntity(string elementName, out ExpressType expressType)
	{
		return _metadata.TryGetExpressType(elementName.ToUpper(), out expressType);
	}

	private void EndElement(XmlReader input, XmlNodeType prevInputType, string prevInputName, out IPersistEntity writeEntity)
	{
		try
		{
			if (_currentNode is XmlCollectionProperty { CType: var cType } xmlCollectionProperty)
			{
				switch (cType)
				{
				case CollectionType.List:
				case CollectionType.ListUnique:
					xmlCollectionProperty.Entities.Sort(XmlCollectionProperty.CompareNodes);
					break;
				default:
					throw new Exception("Unknown list type, " + cType);
				case CollectionType.Set:
					break;
				}
				foreach (XmlNode entity3 in xmlCollectionProperty.Entities)
				{
					if (!(entity3 is XmlEntity xmlEntity))
					{
						continue;
					}
					XmlEntity xmlEntity2 = xmlEntity;
					XmlEntity xmlEntity3 = xmlEntity.Parent.Parent as XmlEntity;
					XmlCollectionProperty xmlCollectionProperty2 = xmlEntity.Parent as XmlCollectionProperty;
					if (xmlEntity3 != null)
					{
						IPersist entity = xmlEntity3.Entity;
						PropertyValue propertyValue = default(PropertyValue);
						propertyValue.Init(xmlEntity2.Entity);
						if (xmlCollectionProperty2 != null)
						{
							entity.Parse(xmlCollectionProperty2.PropertyIndex - 1, propertyValue, null);
						}
					}
				}
			}
			else if (_currentNode.Parent is XmlProperty)
			{
				XmlProperty xmlProperty = (XmlProperty)_currentNode.Parent;
				if (_currentNode is XmlEntity xmlEntity4)
				{
					XmlEntity xmlEntity5 = xmlEntity4;
					xmlProperty.SetValue(xmlEntity5.Entity);
				}
				else if (_currentNode is XmlExpressType)
				{
					XmlExpressType xmlExpressType = (XmlExpressType)_currentNode;
					if (xmlExpressType.Type != xmlProperty.Property.PropertyType)
					{
						if (IsIfcType(input.LocalName, out var expressType))
						{
							IPersist value = (IPersist)Activator.CreateInstance(args: new object[1] { xmlExpressType.Value }, type: expressType.Type);
							xmlProperty.SetValue(value);
						}
					}
					else
					{
						xmlProperty.SetValue(xmlExpressType.Value, Primitives[xmlExpressType.Type.Name]);
					}
				}
				else if (_currentNode is XmlBasicType)
				{
					XmlBasicType xmlBasicType = (XmlBasicType)_currentNode;
					xmlProperty.SetValue(xmlBasicType.Value, xmlBasicType.Type);
				}
			}
			else if (prevInputType == XmlNodeType.Element && prevInputName == input.LocalName && _currentNode is XmlProperty && _currentNode.Parent is XmlEntity)
			{
				XmlProperty xmlProperty2 = (XmlProperty)_currentNode;
				PropertyValue propertyValue2 = default(PropertyValue);
				Type type = xmlProperty2.Property.PropertyType;
				if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					type = Nullable.GetUnderlyingType(type);
				}
				IExpressValueType expressValueType = null;
				if (type != null && typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type))
				{
					expressValueType = (IExpressValueType)Activator.CreateInstance(type);
				}
				StepParserType stepParserType = StepParserType.Undefined;
				if (expressValueType != null)
				{
					stepParserType = Primitives[expressValueType.UnderlyingSystemType.Name];
				}
				else if (type != null && type.GetTypeInfo().IsEnum)
				{
					stepParserType = StepParserType.Enum;
				}
				else if (type != null && Primitives.ContainsKey(type.Name))
				{
					stepParserType = Primitives[type.Name];
				}
				if (stepParserType != StepParserType.Undefined)
				{
					switch (stepParserType)
					{
					case StepParserType.String:
						propertyValue2.Init("'" + input.Value + "'", stepParserType);
						break;
					case StepParserType.HexaDecimal:
						propertyValue2.Init("\"0" + input.Value + "\"", stepParserType);
						break;
					case StepParserType.Boolean:
						propertyValue2.Init(Convert.ToBoolean(input.Value) ? ".T." : ".F", stepParserType);
						break;
					default:
						propertyValue2.Init(input.Value, stepParserType);
						break;
					}
					((XmlEntity)xmlProperty2.Parent).Entity.Parse(xmlProperty2.PropertyIndex - 1, propertyValue2, null);
				}
			}
			else if (_currentNode.Parent is XmlCollectionProperty && !(_currentNode.Parent is XmlUosCollection))
			{
				if (_currentNode is XmlEntity xmlEntity6)
				{
					((XmlCollectionProperty)xmlEntity6.Parent).Entities.Add(xmlEntity6);
				}
				else if (_currentNode is XmlExpressType)
				{
					XmlExpressType xmlExpressType2 = (XmlExpressType)_currentNode;
					Type type2 = xmlExpressType2.Type;
					if (type2.GetTypeInfo().IsGenericType && type2.GetGenericTypeDefinition() == typeof(Nullable<>))
					{
						type2 = Nullable.GetUnderlyingType(type2);
					}
					XmlCollectionProperty xmlCollectionProperty3 = (XmlCollectionProperty)_currentNode.Parent;
					Type propertyType = xmlCollectionProperty3.Property.PropertyType;
					bool num = GetItemTypeFromGenericType(propertyType) == type2;
					PropertyValue propertyValue3 = default(PropertyValue);
					if (num)
					{
						IExpressValueType expressValueType2 = (IExpressValueType)Activator.CreateInstance(type2);
						StepParserType stepParserType2 = Primitives[expressValueType2.UnderlyingSystemType.Name];
						if (stepParserType2 == StepParserType.String)
						{
							propertyValue3.Init("'" + xmlExpressType2.Value + "'", stepParserType2);
						}
						else
						{
							propertyValue3.Init(xmlExpressType2.Value, stepParserType2);
						}
					}
					else
					{
						IExpressValueType value2 = (IExpressValueType)Activator.CreateInstance(args: new object[1] { xmlExpressType2.Value }, type: xmlExpressType2.Type);
						propertyValue3.Init(value2);
					}
					if (_currentNode.Parent.Parent is XmlEntity xmlEntity7)
					{
						xmlEntity7.Entity.Parse(xmlCollectionProperty3.PropertyIndex - 1, propertyValue3, null);
					}
				}
				else if (_currentNode is XmlBasicType)
				{
					XmlBasicType xmlBasicType2 = (XmlBasicType)_currentNode;
					XmlEntity xmlEntity8 = _currentNode.Parent.Parent as XmlEntity;
					XmlCollectionProperty xmlCollectionProperty4 = (XmlCollectionProperty)_currentNode.Parent;
					if (xmlEntity8 != null)
					{
						IPersistEntity entity2 = xmlEntity8.Entity;
						PropertyValue propertyValue4 = default(PropertyValue);
						propertyValue4.Init(xmlBasicType2.Value, xmlBasicType2.Type);
						entity2.Parse(xmlCollectionProperty4.PropertyIndex - 1, propertyValue4, null);
					}
				}
			}
			writeEntity = null;
			if (_currentNode.Parent != null)
			{
				if (_currentNode is XmlEntity xmlEntity9)
				{
					writeEntity = xmlEntity9.Entity;
				}
				_currentNode = _currentNode.Parent;
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("Error reading IfcXML data at node " + input.LocalName, innerException);
		}
	}

	public Type GetItemTypeFromGenericType(Type genericType)
	{
		if (genericType.GetTypeInfo().IsGenericType || genericType.GetTypeInfo().IsInterface)
		{
			Type[] genericArguments = genericType.GetTypeInfo().GetGenericArguments();
			if (genericArguments.GetUpperBound(0) < 0)
			{
				return null;
			}
			return genericArguments[genericArguments.GetUpperBound(0)];
		}
		if (genericType.GetTypeInfo().BaseType != null)
		{
			return GetItemTypeFromGenericType(genericType.GetTypeInfo().BaseType);
		}
		return null;
	}

	private void SetValue(XmlReader input, XmlNodeType prevInputType)
	{
		try
		{
			if (prevInputType != XmlNodeType.Element)
			{
				return;
			}
			if (_currentNode is XmlExpressType xmlExpressType)
			{
				xmlExpressType.Value = input.Value;
			}
			else if (_currentNode is XmlBasicType)
			{
				((XmlBasicType)_currentNode).Value = input.Value;
			}
			else
			{
				if (!(_currentNode is XmlProperty))
				{
					return;
				}
				XmlProperty xmlProperty = (XmlProperty)_currentNode;
				PropertyValue propertyValue = default(PropertyValue);
				Type type = xmlProperty.Property.PropertyType;
				if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
				{
					type = Nullable.GetUnderlyingType(type);
				}
				if (type.GetTypeInfo().IsAbstract)
				{
					return;
				}
				StepParserType value;
				if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(type) && !typeof(IExpressComplexType).GetTypeInfo().IsAssignableFrom(type))
				{
					IExpressValueType expressValueType = (IExpressValueType)Activator.CreateInstance(type);
					value = ((!(expressValueType.UnderlyingSystemType == typeof(bool?))) ? Primitives[expressValueType.UnderlyingSystemType.Name] : StepParserType.Boolean);
				}
				else if (type.GetTypeInfo().IsEnum)
				{
					value = StepParserType.Enum;
				}
				else if (!Primitives.TryGetValue(type.Name, out value))
				{
					value = StepParserType.Undefined;
				}
				switch (value)
				{
				case StepParserType.String:
					propertyValue.Init("'" + input.Value + "'", value);
					((XmlEntity)xmlProperty.Parent).Entity.Parse(xmlProperty.PropertyIndex - 1, propertyValue, null);
					return;
				case StepParserType.Undefined:
					return;
				}
				if (string.IsNullOrWhiteSpace(input.Value))
				{
					return;
				}
				if (value == StepParserType.Boolean)
				{
					if (string.Compare(input.Value, "unknown", StringComparison.OrdinalIgnoreCase) != 0)
					{
						propertyValue.Init(Convert.ToBoolean(input.Value) ? ".T." : ".F.", value);
					}
				}
				else
				{
					propertyValue.Init(input.Value, value);
				}
				((XmlEntity)xmlProperty.Parent).Entity.Parse(xmlProperty.PropertyIndex - 1, propertyValue, null);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("Error reading IfcXML data at node " + input.LocalName, innerException);
		}
	}

	public StepFileHeader Read(Stream xmlStream, IModel model, long streamSize)
	{
		using XmlReader xmlReader = XmlReader.Create(xmlStream);
		_streamSize = streamSize;
		_idMap = new Dictionary<string, int>();
		_lastId = 0;
		_entitiesParsed = 0;
		bool flag = false;
		StepFileHeader stepFileHeader = new StepFileHeader(StepFileHeader.HeaderCreationMode.LeaveEmpty, model);
		stepFileHeader.FileSchema.Schemas.Add("IFC2X3");
		string text = "";
		while (_currentNode == null && xmlReader.Read())
		{
			switch (xmlReader.NodeType)
			{
			case XmlNodeType.Element:
				if (string.Compare(xmlReader.LocalName, "uos", StringComparison.OrdinalIgnoreCase) == 0)
				{
					_currentNode = new XmlUosCollection();
				}
				else if (string.Compare(xmlReader.LocalName, "iso_10303_28", StringComparison.OrdinalIgnoreCase) == 0)
				{
					flag = true;
					if (!string.IsNullOrWhiteSpace(xmlReader.Prefix))
					{
						_expressNamespace = xmlReader.Prefix;
						_cTypeAttribute = _expressNamespace + ":cType";
						_posAttribute = _expressNamespace + ":pos";
						_expressNamespace += ":";
					}
					else
					{
						_cTypeAttribute = "cType";
						_posAttribute = "pos";
					}
					while (xmlReader.MoveToNextAttribute())
					{
						if (xmlReader.Value == "urn:oid:1.0.10303.28.2.1.1" || xmlReader.Value == "urn:iso.org:standard:10303:part(28):version(2):xmlschema:common")
						{
							_expressNamespace = xmlReader.LocalName;
							_cTypeAttribute = _expressNamespace + ":cType";
							_posAttribute = _expressNamespace + ":pos";
							_expressNamespace += ":";
							break;
						}
					}
				}
				else
				{
					text = xmlReader.LocalName.ToLower();
				}
				break;
			case XmlNodeType.Text:
				switch (text)
				{
				case "name":
					stepFileHeader.FileName.Name = xmlReader.Value;
					break;
				case "time_stamp":
					stepFileHeader.FileName.TimeStamp = xmlReader.Value;
					break;
				case "author":
					stepFileHeader.FileName.AuthorName.Add(xmlReader.Value);
					break;
				case "organization":
					stepFileHeader.FileName.Organization.Add(xmlReader.Value);
					break;
				case "preprocessor_version":
					stepFileHeader.FileName.PreprocessorVersion = xmlReader.Value;
					break;
				case "originating_system":
					stepFileHeader.FileName.OriginatingSystem = xmlReader.Value;
					break;
				case "authorization":
					stepFileHeader.FileName.AuthorizationName = xmlReader.Value;
					break;
				case "documentation":
					stepFileHeader.FileDescription.Description.Add(xmlReader.Value);
					break;
				}
				break;
			}
		}
		if (!flag)
		{
			throw new Exception("Invalid XML format, iso_10303_28 tag not found");
		}
		XmlNodeType prevInputType = XmlNodeType.None;
		string prevInputName = "";
		try
		{
			while (xmlReader.Read())
			{
				if (_streamSize != -1 && this.ProgressStatus != null && xmlStream.CanSeek)
				{
					int num = Convert.ToInt32((double)xmlStream.Position / (double)_streamSize * 100.0);
					if (num > _percentageParsed)
					{
						this.ProgressStatus(_percentageParsed, "Parsing");
						_percentageParsed = num;
					}
				}
				switch (xmlReader.NodeType)
				{
				case XmlNodeType.Element:
					StartElement(xmlReader);
					break;
				case XmlNodeType.EndElement:
				{
					EndElement(xmlReader, prevInputType, prevInputName, out var writeEntity);
					if (writeEntity != null)
					{
						_entitiesParsed++;
						_finish(writeEntity);
					}
					break;
				}
				case XmlNodeType.Whitespace:
					SetValue(xmlReader, prevInputType);
					break;
				case XmlNodeType.Text:
					SetValue(xmlReader, prevInputType);
					break;
				}
				prevInputType = xmlReader.NodeType;
				prevInputName = xmlReader.LocalName;
			}
		}
		catch (Exception innerException)
		{
			throw new Exception($"Error reading XML, Line={((IXmlLineInfo)xmlReader).LineNumber}, Position={((IXmlLineInfo)xmlReader).LinePosition}, Tag='{xmlReader.LocalName}'", innerException);
		}
		if (this.ProgressStatus != null)
		{
			this.ProgressStatus(100, "Parsing");
		}
		return stepFileHeader;
	}
}
