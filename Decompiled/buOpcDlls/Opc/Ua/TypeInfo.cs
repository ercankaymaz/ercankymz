using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public class TypeInfo : IFormattable
{
	public delegate object CastArrayElementHandler(object source, BuiltInType srcType, BuiltInType dstType);

	private delegate T CastDelegate<T>(object value, TypeInfo sourceType);

	public static class Scalars
	{
		public static readonly TypeInfo Boolean = new TypeInfo(BuiltInType.Boolean, -1);

		public static readonly TypeInfo SByte = new TypeInfo(BuiltInType.SByte, -1);

		public static readonly TypeInfo Byte = new TypeInfo(BuiltInType.Byte, -1);

		public static readonly TypeInfo Int16 = new TypeInfo(BuiltInType.Int16, -1);

		public static readonly TypeInfo UInt16 = new TypeInfo(BuiltInType.UInt16, -1);

		public static readonly TypeInfo Int32 = new TypeInfo(BuiltInType.Int32, -1);

		public static readonly TypeInfo UInt32 = new TypeInfo(BuiltInType.UInt32, -1);

		public static readonly TypeInfo Int64 = new TypeInfo(BuiltInType.Int64, -1);

		public static readonly TypeInfo UInt64 = new TypeInfo(BuiltInType.UInt64, -1);

		public static readonly TypeInfo Float = new TypeInfo(BuiltInType.Float, -1);

		public static readonly TypeInfo Double = new TypeInfo(BuiltInType.Double, -1);

		public static readonly TypeInfo String = new TypeInfo(BuiltInType.String, -1);

		public static readonly TypeInfo DateTime = new TypeInfo(BuiltInType.DateTime, -1);

		public static readonly TypeInfo Guid = new TypeInfo(BuiltInType.Guid, -1);

		public static readonly TypeInfo ByteString = new TypeInfo(BuiltInType.ByteString, -1);

		public static readonly TypeInfo XmlElement = new TypeInfo(BuiltInType.XmlElement, -1);

		public static readonly TypeInfo NodeId = new TypeInfo(BuiltInType.NodeId, -1);

		public static readonly TypeInfo ExpandedNodeId = new TypeInfo(BuiltInType.ExpandedNodeId, -1);

		public static readonly TypeInfo StatusCode = new TypeInfo(BuiltInType.StatusCode, -1);

		public static readonly TypeInfo QualifiedName = new TypeInfo(BuiltInType.QualifiedName, -1);

		public static readonly TypeInfo LocalizedText = new TypeInfo(BuiltInType.LocalizedText, -1);

		public static readonly TypeInfo ExtensionObject = new TypeInfo(BuiltInType.ExtensionObject, -1);

		public static readonly TypeInfo DataValue = new TypeInfo(BuiltInType.DataValue, -1);

		public static readonly TypeInfo Variant = new TypeInfo(BuiltInType.Variant, -1);

		public static readonly TypeInfo DiagnosticInfo = new TypeInfo(BuiltInType.DiagnosticInfo, -1);
	}

	public static class Arrays
	{
		public static readonly TypeInfo Boolean = new TypeInfo(BuiltInType.Boolean, 1);

		public static readonly TypeInfo SByte = new TypeInfo(BuiltInType.SByte, 1);

		public static readonly TypeInfo Byte = new TypeInfo(BuiltInType.Byte, 1);

		public static readonly TypeInfo Int16 = new TypeInfo(BuiltInType.Int16, 1);

		public static readonly TypeInfo UInt16 = new TypeInfo(BuiltInType.UInt16, 1);

		public static readonly TypeInfo Int32 = new TypeInfo(BuiltInType.Int32, 1);

		public static readonly TypeInfo UInt32 = new TypeInfo(BuiltInType.UInt32, 1);

		public static readonly TypeInfo Int64 = new TypeInfo(BuiltInType.Int64, 1);

		public static readonly TypeInfo UInt64 = new TypeInfo(BuiltInType.UInt64, 1);

		public static readonly TypeInfo Float = new TypeInfo(BuiltInType.Float, 1);

		public static readonly TypeInfo Double = new TypeInfo(BuiltInType.Double, 1);

		public static readonly TypeInfo String = new TypeInfo(BuiltInType.String, 1);

		public static readonly TypeInfo DateTime = new TypeInfo(BuiltInType.DateTime, 1);

		public static readonly TypeInfo Guid = new TypeInfo(BuiltInType.Guid, 1);

		public static readonly TypeInfo ByteString = new TypeInfo(BuiltInType.ByteString, 1);

		public static readonly TypeInfo XmlElement = new TypeInfo(BuiltInType.XmlElement, 1);

		public static readonly TypeInfo NodeId = new TypeInfo(BuiltInType.NodeId, 1);

		public static readonly TypeInfo ExpandedNodeId = new TypeInfo(BuiltInType.ExpandedNodeId, 1);

		public static readonly TypeInfo StatusCode = new TypeInfo(BuiltInType.StatusCode, 1);

		public static readonly TypeInfo QualifiedName = new TypeInfo(BuiltInType.QualifiedName, 1);

		public static readonly TypeInfo LocalizedText = new TypeInfo(BuiltInType.LocalizedText, 1);

		public static readonly TypeInfo ExtensionObject = new TypeInfo(BuiltInType.ExtensionObject, 1);

		public static readonly TypeInfo DataValue = new TypeInfo(BuiltInType.DataValue, 1);

		public static readonly TypeInfo Variant = new TypeInfo(BuiltInType.Variant, 1);

		public static readonly TypeInfo DiagnosticInfo = new TypeInfo(BuiltInType.DiagnosticInfo, 1);
	}

	private BuiltInType m_builtInType;

	private int m_valueRank;

	private static readonly TypeInfo s_Unknown = new TypeInfo();

	public static TypeInfo Unknown => s_Unknown;

	public BuiltInType BuiltInType => m_builtInType;

	public int ValueRank => m_valueRank;

	internal TypeInfo()
	{
		m_builtInType = BuiltInType.Null;
		m_valueRank = -2;
	}

	public TypeInfo(BuiltInType builtInType, int valueRank)
	{
		m_builtInType = builtInType;
		m_valueRank = valueRank;
	}

	public static NodeId GetDataTypeId(object value)
	{
		if (value == null)
		{
			return NodeId.Null;
		}
		NodeId dataTypeId = GetDataTypeId(value.GetType());
		if (dataTypeId == NodeId.Null && value is Matrix matrix)
		{
			return GetDataTypeId(matrix.TypeInfo);
		}
		return dataTypeId;
	}

	public static NodeId GetDataTypeId(Type type)
	{
		NodeId dataTypeId = GetDataTypeId(Construct(type));
		if (NodeId.IsNull(dataTypeId) && (type.GetTypeInfo().IsEnum || (type.IsArray && type.GetElementType().GetTypeInfo().IsEnum)))
		{
			return 29u;
		}
		return dataTypeId;
	}

	public static NodeId GetDataTypeId(TypeInfo typeInfo)
	{
		return typeInfo.BuiltInType switch
		{
			BuiltInType.Boolean => DataTypeIds.Boolean, 
			BuiltInType.SByte => DataTypeIds.SByte, 
			BuiltInType.Byte => DataTypeIds.Byte, 
			BuiltInType.Int16 => DataTypeIds.Int16, 
			BuiltInType.UInt16 => DataTypeIds.UInt16, 
			BuiltInType.Int32 => DataTypeIds.Int32, 
			BuiltInType.UInt32 => DataTypeIds.UInt32, 
			BuiltInType.Int64 => DataTypeIds.Int64, 
			BuiltInType.UInt64 => DataTypeIds.UInt64, 
			BuiltInType.Float => DataTypeIds.Float, 
			BuiltInType.Double => DataTypeIds.Double, 
			BuiltInType.String => DataTypeIds.String, 
			BuiltInType.DateTime => DataTypeIds.DateTime, 
			BuiltInType.Guid => DataTypeIds.Guid, 
			BuiltInType.ByteString => DataTypeIds.ByteString, 
			BuiltInType.XmlElement => DataTypeIds.XmlElement, 
			BuiltInType.NodeId => DataTypeIds.NodeId, 
			BuiltInType.ExpandedNodeId => DataTypeIds.ExpandedNodeId, 
			BuiltInType.StatusCode => DataTypeIds.StatusCode, 
			BuiltInType.DiagnosticInfo => DataTypeIds.DiagnosticInfo, 
			BuiltInType.QualifiedName => DataTypeIds.QualifiedName, 
			BuiltInType.LocalizedText => DataTypeIds.LocalizedText, 
			BuiltInType.ExtensionObject => DataTypeIds.Structure, 
			BuiltInType.DataValue => DataTypeIds.DataValue, 
			BuiltInType.Variant => DataTypeIds.BaseDataType, 
			BuiltInType.Number => DataTypeIds.Number, 
			BuiltInType.Integer => DataTypeIds.Integer, 
			BuiltInType.UInteger => DataTypeIds.UInteger, 
			BuiltInType.Enumeration => DataTypeIds.Enumeration, 
			_ => NodeId.Null, 
		};
	}

	public static int GetValueRank(object value)
	{
		if (value == null)
		{
			return -2;
		}
		TypeInfo typeInfo = Construct(value);
		if (typeInfo.BuiltInType == BuiltInType.Null && value is Matrix matrix)
		{
			return matrix.TypeInfo.ValueRank;
		}
		return typeInfo.ValueRank;
	}

	public static int GetValueRank(Type type)
	{
		TypeInfo typeInfo = Construct(type);
		if (typeInfo.BuiltInType == BuiltInType.Null && (type.GetTypeInfo().IsEnum || (type.IsArray && type.GetElementType().GetTypeInfo().IsEnum)))
		{
			if (type.IsArray)
			{
				return 0;
			}
			return -1;
		}
		return typeInfo.ValueRank;
	}

	public static BuiltInType GetBuiltInType(NodeId datatypeId)
	{
		if (datatypeId == null || datatypeId.NamespaceIndex != 0 || datatypeId.IdType != IdType.Numeric)
		{
			return BuiltInType.Null;
		}
		switch ((uint)datatypeId.Identifier)
		{
		case 294u:
			return BuiltInType.DateTime;
		case 30u:
		case 311u:
		case 521u:
		case 2000u:
		case 2001u:
		case 2002u:
		case 2003u:
		case 16307u:
			return BuiltInType.ByteString;
		case 388u:
			return BuiltInType.NodeId;
		case 290u:
			return BuiltInType.Double;
		case 288u:
		case 289u:
		case 17588u:
		case 20998u:
			return BuiltInType.UInt32;
		case 11737u:
			return BuiltInType.UInt64;
		case 291u:
		case 295u:
		case 12877u:
		case 12878u:
		case 12879u:
		case 12880u:
		case 12881u:
			return BuiltInType.String;
		default:
		{
			BuiltInType builtInType = (BuiltInType)Enum.ToObject(typeof(BuiltInType), datatypeId.Identifier);
			if (builtInType > BuiltInType.DiagnosticInfo && builtInType != BuiltInType.Enumeration)
			{
				return BuiltInType.Null;
			}
			return builtInType;
		}
		}
	}

	public static bool IsNumericType(BuiltInType builtInType)
	{
		if (builtInType >= BuiltInType.SByte && builtInType <= BuiltInType.Double)
		{
			return true;
		}
		if (builtInType >= BuiltInType.Number && builtInType <= BuiltInType.UInteger)
		{
			return true;
		}
		return false;
	}

	public static bool IsValueType(BuiltInType builtInType)
	{
		if (builtInType >= BuiltInType.Boolean && builtInType <= BuiltInType.Double)
		{
			return true;
		}
		if (builtInType == BuiltInType.DateTime || builtInType == BuiltInType.Guid || builtInType == BuiltInType.StatusCode)
		{
			return true;
		}
		return false;
	}

	public static bool IsEncodingNullableType(BuiltInType builtInType)
	{
		if (builtInType >= BuiltInType.Boolean && builtInType <= BuiltInType.Double)
		{
			return false;
		}
		if (builtInType == BuiltInType.DataValue || builtInType == BuiltInType.DiagnosticInfo)
		{
			return false;
		}
		return true;
	}

	public static BuiltInType GetBuiltInType(NodeId datatypeId, ITypeTable typeTree)
	{
		NodeId nodeId = datatypeId;
		while (!NodeId.IsNull(nodeId))
		{
			if (nodeId != null && nodeId.NamespaceIndex == 0 && nodeId.IdType == IdType.Numeric)
			{
				BuiltInType builtInType = (BuiltInType)(uint)nodeId.Identifier;
				if (builtInType > BuiltInType.Null && builtInType <= BuiltInType.Enumeration && builtInType != BuiltInType.DiagnosticInfo)
				{
					return builtInType;
				}
			}
			if (typeTree == null)
			{
				break;
			}
			nodeId = typeTree.FindSuperType(nodeId);
		}
		return BuiltInType.Null;
	}

	public static async Task<BuiltInType> GetBuiltInTypeAsync(NodeId datatypeId, ITypeTable typeTree, CancellationToken ct = default(CancellationToken))
	{
		NodeId nodeId = datatypeId;
		while (!NodeId.IsNull(nodeId))
		{
			if (nodeId != null && nodeId.NamespaceIndex == 0 && nodeId.IdType == IdType.Numeric)
			{
				BuiltInType builtInType = (BuiltInType)(uint)nodeId.Identifier;
				if (builtInType > BuiltInType.Null && builtInType <= BuiltInType.Enumeration && builtInType != BuiltInType.DiagnosticInfo)
				{
					return builtInType;
				}
			}
			if (typeTree == null)
			{
				break;
			}
			nodeId = await typeTree.FindSuperTypeAsync(nodeId, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		return BuiltInType.Null;
	}

	public static Type GetSystemType(ExpandedNodeId datatypeId, IEncodeableFactory factory)
	{
		if (datatypeId == null)
		{
			return null;
		}
		if (datatypeId.NamespaceIndex != 0 || datatypeId.IdType != IdType.Numeric || datatypeId.IsAbsolute)
		{
			return factory.GetSystemType(datatypeId);
		}
		switch ((uint)datatypeId.Identifier)
		{
		case 1u:
			return typeof(bool);
		case 2u:
			return typeof(sbyte);
		case 3u:
			return typeof(byte);
		case 4u:
			return typeof(short);
		case 5u:
			return typeof(ushort);
		case 6u:
			return typeof(int);
		case 7u:
		case 288u:
		case 289u:
		case 17588u:
		case 20998u:
			return typeof(uint);
		case 8u:
			return typeof(long);
		case 9u:
		case 11737u:
			return typeof(ulong);
		case 10u:
			return typeof(float);
		case 11u:
		case 290u:
			return typeof(double);
		case 12u:
		case 291u:
		case 295u:
		case 12877u:
		case 12878u:
		case 12879u:
		case 12880u:
		case 12881u:
			return typeof(string);
		case 13u:
		case 294u:
			return typeof(DateTime);
		case 14u:
			return typeof(Uuid);
		case 15u:
		case 30u:
		case 311u:
		case 521u:
		case 2000u:
		case 2001u:
		case 2002u:
		case 2003u:
		case 16307u:
			return typeof(byte[]);
		case 16u:
			return typeof(XmlElement);
		case 17u:
		case 388u:
			return typeof(NodeId);
		case 18u:
			return typeof(ExpandedNodeId);
		case 19u:
			return typeof(StatusCode);
		case 25u:
			return typeof(DiagnosticInfo);
		case 20u:
			return typeof(QualifiedName);
		case 21u:
			return typeof(LocalizedText);
		case 23u:
			return typeof(DataValue);
		case 24u:
			return typeof(Variant);
		case 22u:
			return typeof(ExtensionObject);
		case 26u:
			return typeof(Variant);
		case 27u:
			return typeof(Variant);
		case 28u:
			return typeof(Variant);
		case 29u:
			return typeof(int);
		default:
			return factory.GetSystemType(datatypeId);
		}
	}

	public static TypeInfo IsInstanceOfDataType(object value, NodeId expectedDataTypeId, int expectedValueRank, NamespaceTable namespaceUris, ITypeTable typeTree)
	{
		BuiltInType builtInType = BuiltInType.Null;
		TypeInfo typeInfo = Construct(value);
		if (typeInfo.BuiltInType == BuiltInType.Null)
		{
			builtInType = GetBuiltInType(expectedDataTypeId, typeTree);
			if (expectedValueRank != -1)
			{
				return new TypeInfo(builtInType, 1);
			}
			switch (builtInType)
			{
			case BuiltInType.String:
			case BuiltInType.ByteString:
			case BuiltInType.XmlElement:
			case BuiltInType.NodeId:
			case BuiltInType.ExpandedNodeId:
			case BuiltInType.QualifiedName:
			case BuiltInType.LocalizedText:
			case BuiltInType.ExtensionObject:
			case BuiltInType.DataValue:
			case BuiltInType.Variant:
				return new TypeInfo(builtInType, -1);
			default:
				return null;
			}
		}
		if (typeInfo.BuiltInType == BuiltInType.ByteString && typeInfo.ValueRank == -1 && (expectedValueRank == 0 || expectedValueRank == 1))
		{
			if (typeTree.IsTypeOf(expectedDataTypeId, 3u))
			{
				return typeInfo;
			}
			return null;
		}
		if (!ValueRanks.IsValid(typeInfo.ValueRank, expectedValueRank))
		{
			return null;
		}
		if (expectedDataTypeId.IdType == IdType.Numeric && expectedDataTypeId.NamespaceIndex == 0)
		{
			BuiltInType builtInType2 = typeInfo.BuiltInType;
			switch ((uint)expectedDataTypeId.Identifier)
			{
			case 26u:
				switch (builtInType2)
				{
				case BuiltInType.SByte:
				case BuiltInType.Byte:
				case BuiltInType.Int16:
				case BuiltInType.UInt16:
				case BuiltInType.Int32:
				case BuiltInType.UInt32:
				case BuiltInType.Int64:
				case BuiltInType.UInt64:
				case BuiltInType.Float:
				case BuiltInType.Double:
					return typeInfo;
				case BuiltInType.Variant:
					break;
				default:
					return null;
				}
				if (typeInfo.ValueRank == -1)
				{
					return null;
				}
				break;
			case 27u:
				switch (builtInType2)
				{
				case BuiltInType.SByte:
				case BuiltInType.Int16:
				case BuiltInType.Int32:
				case BuiltInType.Int64:
					return typeInfo;
				case BuiltInType.Variant:
					break;
				default:
					return null;
				}
				if (typeInfo.ValueRank == -1)
				{
					return null;
				}
				break;
			case 28u:
				switch (builtInType2)
				{
				case BuiltInType.Byte:
				case BuiltInType.UInt16:
				case BuiltInType.UInt32:
				case BuiltInType.UInt64:
					return typeInfo;
				case BuiltInType.Variant:
					break;
				default:
					return null;
				}
				if (typeInfo.ValueRank == -1)
				{
					return null;
				}
				break;
			case 29u:
				if (typeInfo.BuiltInType == BuiltInType.Int32)
				{
					return typeInfo;
				}
				return null;
			case 22u:
				if (typeInfo.BuiltInType == BuiltInType.ExtensionObject)
				{
					return typeInfo;
				}
				return null;
			case 24u:
				if (typeInfo.BuiltInType != BuiltInType.Variant)
				{
					return typeInfo;
				}
				break;
			}
		}
		if (typeInfo.BuiltInType != BuiltInType.ExtensionObject && typeInfo.BuiltInType != BuiltInType.Variant)
		{
			if (typeTree.IsTypeOf(expectedDataTypeId, new NodeId((uint)typeInfo.BuiltInType)))
			{
				return typeInfo;
			}
			if (typeInfo.BuiltInType == BuiltInType.Int32 && typeTree.IsTypeOf(expectedDataTypeId, 29u))
			{
				return typeInfo;
			}
			if (GetBuiltInType(expectedDataTypeId, typeTree) == BuiltInType.Variant)
			{
				return typeInfo;
			}
			return null;
		}
		if (typeInfo.ValueRank < 0)
		{
			if (typeInfo.BuiltInType == BuiltInType.ExtensionObject)
			{
				switch (GetBuiltInType(expectedDataTypeId, typeTree))
				{
				case BuiltInType.Variant:
					return typeInfo;
				default:
					return null;
				case BuiltInType.ExtensionObject:
					break;
				}
			}
			NodeId dataTypeId = typeInfo.GetDataTypeId(value, namespaceUris, typeTree);
			if (typeTree.IsTypeOf(dataTypeId, expectedDataTypeId))
			{
				return typeInfo;
			}
			return null;
		}
		Array array = value as Array;
		if (array == null && value is Matrix matrix)
		{
			array = matrix.Elements;
		}
		if (array != null)
		{
			BuiltInType builtInType3 = GetBuiltInType(expectedDataTypeId, typeTree);
			BuiltInType builtInType4 = GetBuiltInType(array.GetType().GetElementType().Name);
			if (builtInType4 != BuiltInType.ExtensionObject && builtInType4 == builtInType3)
			{
				return typeInfo;
			}
			if (builtInType3 == BuiltInType.Variant)
			{
				return typeInfo;
			}
			int[] array2 = new int[array.Rank];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array.GetLength(i);
			}
			int[] array3 = new int[array2.Length];
			for (int j = 0; j < array.Length; j++)
			{
				int num = array.Length;
				for (int k = 0; k < array3.Length; k++)
				{
					num /= array2[k];
					array3[k] = j / num % array2[k];
				}
				object value2 = array.GetValue(array3);
				if (builtInType4 == BuiltInType.Variant)
				{
					value2 = ((Variant)value2).Value;
				}
				if (IsInstanceOfDataType(value2, expectedDataTypeId, -1, namespaceUris, typeTree) == null)
				{
					return null;
				}
			}
			return typeInfo;
		}
		return null;
	}

	public NodeId GetDataTypeId(object value, NamespaceTable namespaceUris, ITypeTable typeTree)
	{
		if (BuiltInType == BuiltInType.Null)
		{
			return NodeId.Null;
		}
		if (BuiltInType == BuiltInType.ExtensionObject)
		{
			if (value is IEncodeable encodeable)
			{
				return ExpandedNodeId.ToNodeId(encodeable.TypeId, namespaceUris);
			}
			if (value is ExtensionObject extensionObject)
			{
				if (extensionObject.Body is IEncodeable encodeable2)
				{
					return ExpandedNodeId.ToNodeId(encodeable2.TypeId, namespaceUris);
				}
				return typeTree.FindDataTypeId(extensionObject.TypeId);
			}
			return 22u;
		}
		return new NodeId((uint)BuiltInType);
	}

	public static Type GetSystemType(BuiltInType builtInType, int valueRank)
	{
		if (valueRank == -1)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return typeof(bool);
			case BuiltInType.SByte:
				return typeof(sbyte);
			case BuiltInType.Byte:
				return typeof(byte);
			case BuiltInType.Int16:
				return typeof(short);
			case BuiltInType.UInt16:
				return typeof(ushort);
			case BuiltInType.Int32:
				return typeof(int);
			case BuiltInType.UInt32:
				return typeof(uint);
			case BuiltInType.Int64:
				return typeof(long);
			case BuiltInType.UInt64:
				return typeof(ulong);
			case BuiltInType.Float:
				return typeof(float);
			case BuiltInType.Double:
				return typeof(double);
			case BuiltInType.String:
				return typeof(string);
			case BuiltInType.DateTime:
				return typeof(DateTime);
			case BuiltInType.Guid:
				return typeof(Uuid);
			case BuiltInType.ByteString:
				return typeof(byte[]);
			case BuiltInType.XmlElement:
				return typeof(XmlElement);
			case BuiltInType.NodeId:
				return typeof(NodeId);
			case BuiltInType.ExpandedNodeId:
				return typeof(ExpandedNodeId);
			case BuiltInType.LocalizedText:
				return typeof(LocalizedText);
			case BuiltInType.QualifiedName:
				return typeof(QualifiedName);
			case BuiltInType.StatusCode:
				return typeof(StatusCode);
			case BuiltInType.DiagnosticInfo:
				return typeof(DiagnosticInfo);
			case BuiltInType.DataValue:
				return typeof(DataValue);
			case BuiltInType.Variant:
				return typeof(Variant);
			case BuiltInType.ExtensionObject:
				return typeof(ExtensionObject);
			case BuiltInType.Enumeration:
				return typeof(int);
			case BuiltInType.Number:
				return typeof(Variant);
			case BuiltInType.Integer:
				return typeof(Variant);
			case BuiltInType.UInteger:
				return typeof(Variant);
			}
		}
		else if (valueRank == 1)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return typeof(bool[]);
			case BuiltInType.SByte:
				return typeof(sbyte[]);
			case BuiltInType.Byte:
				return typeof(byte[]);
			case BuiltInType.Int16:
				return typeof(short[]);
			case BuiltInType.UInt16:
				return typeof(ushort[]);
			case BuiltInType.Int32:
				return typeof(int[]);
			case BuiltInType.UInt32:
				return typeof(uint[]);
			case BuiltInType.Int64:
				return typeof(long[]);
			case BuiltInType.UInt64:
				return typeof(ulong[]);
			case BuiltInType.Float:
				return typeof(float[]);
			case BuiltInType.Double:
				return typeof(double[]);
			case BuiltInType.String:
				return typeof(string[]);
			case BuiltInType.DateTime:
				return typeof(DateTime[]);
			case BuiltInType.Guid:
				return typeof(Uuid[]);
			case BuiltInType.ByteString:
				return typeof(byte[][]);
			case BuiltInType.XmlElement:
				return typeof(XmlElement[]);
			case BuiltInType.NodeId:
				return typeof(NodeId[]);
			case BuiltInType.ExpandedNodeId:
				return typeof(ExpandedNodeId[]);
			case BuiltInType.LocalizedText:
				return typeof(LocalizedText[]);
			case BuiltInType.QualifiedName:
				return typeof(QualifiedName[]);
			case BuiltInType.StatusCode:
				return typeof(StatusCode[]);
			case BuiltInType.DiagnosticInfo:
				return typeof(DiagnosticInfo[]);
			case BuiltInType.DataValue:
				return typeof(DataValue[]);
			case BuiltInType.Variant:
				return typeof(Variant[]);
			case BuiltInType.ExtensionObject:
				return typeof(ExtensionObject[]);
			case BuiltInType.Enumeration:
				return typeof(int[]);
			case BuiltInType.Number:
				return typeof(Variant[]);
			case BuiltInType.Integer:
				return typeof(Variant[]);
			case BuiltInType.UInteger:
				return typeof(Variant[]);
			}
		}
		else if (valueRank >= 2)
		{
			switch (builtInType)
			{
			case BuiltInType.Boolean:
				return typeof(bool).MakeArrayType(valueRank);
			case BuiltInType.SByte:
				return typeof(sbyte).MakeArrayType(valueRank);
			case BuiltInType.Byte:
				return typeof(byte).MakeArrayType(valueRank);
			case BuiltInType.Int16:
				return typeof(short).MakeArrayType(valueRank);
			case BuiltInType.UInt16:
				return typeof(ushort).MakeArrayType(valueRank);
			case BuiltInType.Int32:
				return typeof(int).MakeArrayType(valueRank);
			case BuiltInType.UInt32:
				return typeof(uint).MakeArrayType(valueRank);
			case BuiltInType.Int64:
				return typeof(long).MakeArrayType(valueRank);
			case BuiltInType.UInt64:
				return typeof(ulong).MakeArrayType(valueRank);
			case BuiltInType.Float:
				return typeof(float).MakeArrayType(valueRank);
			case BuiltInType.Double:
				return typeof(double).MakeArrayType(valueRank);
			case BuiltInType.String:
				return typeof(string).MakeArrayType(valueRank);
			case BuiltInType.DateTime:
				return typeof(DateTime).MakeArrayType(valueRank);
			case BuiltInType.Guid:
				return typeof(Uuid).MakeArrayType(valueRank);
			case BuiltInType.ByteString:
				return typeof(byte[]).MakeArrayType(valueRank);
			case BuiltInType.XmlElement:
				return typeof(XmlElement).MakeArrayType(valueRank);
			case BuiltInType.NodeId:
				return typeof(NodeId).MakeArrayType(valueRank);
			case BuiltInType.ExpandedNodeId:
				return typeof(ExpandedNodeId).MakeArrayType(valueRank);
			case BuiltInType.LocalizedText:
				return typeof(LocalizedText).MakeArrayType(valueRank);
			case BuiltInType.QualifiedName:
				return typeof(QualifiedName).MakeArrayType(valueRank);
			case BuiltInType.StatusCode:
				return typeof(StatusCode).MakeArrayType(valueRank);
			case BuiltInType.DiagnosticInfo:
				return typeof(DiagnosticInfo).MakeArrayType(valueRank);
			case BuiltInType.DataValue:
				return typeof(DataValue).MakeArrayType(valueRank);
			case BuiltInType.Variant:
				return typeof(Variant).MakeArrayType(valueRank);
			case BuiltInType.ExtensionObject:
				return typeof(ExtensionObject).MakeArrayType(valueRank);
			case BuiltInType.Enumeration:
				return typeof(int).MakeArrayType(valueRank);
			case BuiltInType.Number:
			case BuiltInType.Integer:
			case BuiltInType.UInteger:
				return typeof(Variant).MakeArrayType(valueRank);
			}
		}
		return typeof(Variant);
	}

	public static TypeInfo Construct(object value)
	{
		if (value == null)
		{
			return Unknown;
		}
		TypeInfo typeInfo = Construct(value.GetType());
		if (typeInfo.BuiltInType == BuiltInType.Null && value is Matrix matrix)
		{
			return matrix.TypeInfo;
		}
		return typeInfo;
	}

	public static TypeInfo Construct(Type systemType)
	{
		if (systemType == null)
		{
			return Unknown;
		}
		string text = systemType.Name;
		string text2 = null;
		if (text[text.Length - 1] == ']')
		{
			int num = text.IndexOf('[');
			if (num != -1)
			{
				text2 = text.Substring(num);
				text = text.Substring(0, num);
			}
		}
		if (text2 == null)
		{
			BuiltInType builtInType = GetBuiltInType(text);
			if (builtInType != BuiltInType.Null)
			{
				return new TypeInfo(builtInType, -1);
			}
			if (systemType.GetTypeInfo().IsEnum)
			{
				return new TypeInfo(BuiltInType.Enumeration, -1);
			}
			if (text.EndsWith("Collection", StringComparison.Ordinal))
			{
				builtInType = GetBuiltInType(text.Substring(0, text.Length - "Collection".Length));
				if (builtInType != BuiltInType.Null)
				{
					return new TypeInfo(builtInType, 1);
				}
				if (systemType.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType)
				{
					return Construct(systemType.GetTypeInfo().BaseType);
				}
				return Unknown;
			}
			if (systemType.GetTypeInfo().IsGenericType)
			{
				Type[] genericArguments = systemType.GetGenericArguments();
				if (genericArguments != null && genericArguments.Length == 1)
				{
					TypeInfo typeInfo = Construct(genericArguments[0]);
					if (typeInfo.BuiltInType != BuiltInType.Null && typeInfo.ValueRank == -1)
					{
						return new TypeInfo(typeInfo.BuiltInType, 1);
					}
				}
				return Unknown;
			}
			if (typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) || text == "IEncodeable")
			{
				return new TypeInfo(BuiltInType.ExtensionObject, -1);
			}
			return Unknown;
		}
		if (text2.Length == 2)
		{
			BuiltInType builtInType2 = GetBuiltInType(text);
			switch (builtInType2)
			{
			case BuiltInType.Byte:
				return new TypeInfo(BuiltInType.ByteString, -1);
			default:
				return new TypeInfo(builtInType2, 1);
			case BuiltInType.Null:
				if (typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetElementType().GetTypeInfo()) || text == "IEncodeable")
				{
					return new TypeInfo(BuiltInType.ExtensionObject, 1);
				}
				if (systemType.GetTypeInfo().GetElementType().IsEnum)
				{
					return new TypeInfo(BuiltInType.Enumeration, 1);
				}
				return Unknown;
			}
		}
		int num2 = 1;
		for (int i = 1; i < text2.Length - 1; i++)
		{
			if (text2[i] == ',')
			{
				num2++;
			}
		}
		if (num2 + 1 == text2.Length)
		{
			BuiltInType builtInType3 = GetBuiltInType(text);
			if (builtInType3 != BuiltInType.Null)
			{
				return new TypeInfo(builtInType3, num2);
			}
			if (typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) || text == "IEncodeable")
			{
				return new TypeInfo(BuiltInType.ExtensionObject, num2);
			}
			return Unknown;
		}
		if (text2[1] == ']' && text == "Byte" && num2 + 3 == text2.Length)
		{
			return new TypeInfo(BuiltInType.ByteString, num2);
		}
		return Unknown;
	}

	public static object GetDefaultValue(BuiltInType type)
	{
		return type switch
		{
			BuiltInType.Boolean => false, 
			BuiltInType.SByte => (sbyte)0, 
			BuiltInType.Byte => (byte)0, 
			BuiltInType.Int16 => (short)0, 
			BuiltInType.UInt16 => (ushort)0, 
			BuiltInType.Int32 => 0, 
			BuiltInType.UInt32 => 0u, 
			BuiltInType.Int64 => 0L, 
			BuiltInType.UInt64 => 0uL, 
			BuiltInType.Float => 0f, 
			BuiltInType.Double => 0.0, 
			BuiltInType.String => null, 
			BuiltInType.DateTime => DateTime.MinValue, 
			BuiltInType.Guid => Uuid.Empty, 
			BuiltInType.ByteString => null, 
			BuiltInType.XmlElement => null, 
			BuiltInType.StatusCode => new StatusCode(0u), 
			BuiltInType.NodeId => NodeId.Null, 
			BuiltInType.ExpandedNodeId => ExpandedNodeId.Null, 
			BuiltInType.QualifiedName => QualifiedName.Null, 
			BuiltInType.LocalizedText => LocalizedText.Null, 
			BuiltInType.Variant => Variant.Null, 
			BuiltInType.DataValue => null, 
			BuiltInType.Enumeration => 0, 
			BuiltInType.Number => 0.0, 
			BuiltInType.Integer => 0L, 
			BuiltInType.UInteger => 0uL, 
			_ => null, 
		};
	}

	public static object GetDefaultValue(NodeId dataType, int valueRank)
	{
		return GetDefaultValue(dataType, valueRank, null);
	}

	public static object GetDefaultValue(NodeId dataType, int valueRank, ITypeTable typeTree)
	{
		if (valueRank != -1)
		{
			return null;
		}
		BuiltInType builtInType = BuiltInType.Null;
		if (dataType != null && dataType.IdType == IdType.Numeric && dataType.NamespaceIndex == 0)
		{
			uint num = (uint)dataType.Identifier;
			switch (num)
			{
			case 0u:
			case 1u:
			case 2u:
			case 3u:
			case 4u:
			case 5u:
			case 6u:
			case 7u:
			case 8u:
			case 9u:
			case 10u:
			case 11u:
			case 12u:
			case 13u:
			case 14u:
			case 15u:
			case 16u:
			case 17u:
			case 18u:
			case 19u:
			case 20u:
			case 21u:
			case 22u:
			case 23u:
			case 24u:
			case 25u:
				return GetDefaultValue((BuiltInType)num);
			case 290u:
				return 0.0;
			case 294u:
				return DateTime.MinValue;
			case 289u:
				return 0u;
			case 288u:
				return 0u;
			case 26u:
				return 0.0;
			case 28u:
				return 0uL;
			case 27u:
				return 0L;
			case 256u:
				return 0;
			case 257u:
				return 0;
			case 29u:
				return 0;
			}
		}
		builtInType = GetBuiltInType(dataType, typeTree);
		if (builtInType != BuiltInType.Null)
		{
			return GetDefaultValue(builtInType);
		}
		return null;
	}

	public static Array CreateArray(BuiltInType type, params int[] dimensions)
	{
		if (dimensions == null || dimensions.Length == 0)
		{
			throw new ArgumentOutOfRangeException("Array dimensions must be specifed.");
		}
		int num = dimensions[0];
		if (dimensions.Length == 1)
		{
			switch (type)
			{
			case BuiltInType.Null:
				return new object[num];
			case BuiltInType.Boolean:
				return new bool[num];
			case BuiltInType.SByte:
				return new sbyte[num];
			case BuiltInType.Byte:
				return new byte[num];
			case BuiltInType.Int16:
				return new short[num];
			case BuiltInType.UInt16:
				return new ushort[num];
			case BuiltInType.Int32:
				return new int[num];
			case BuiltInType.UInt32:
				return new uint[num];
			case BuiltInType.Int64:
				return new long[num];
			case BuiltInType.UInt64:
				return new ulong[num];
			case BuiltInType.Float:
				return new float[num];
			case BuiltInType.Double:
				return new double[num];
			case BuiltInType.String:
				return new string[num];
			case BuiltInType.DateTime:
				return new DateTime[num];
			case BuiltInType.Guid:
				return new Uuid[num];
			case BuiltInType.ByteString:
				return new byte[num][];
			case BuiltInType.XmlElement:
				return new XmlElement[num];
			case BuiltInType.StatusCode:
				return new StatusCode[num];
			case BuiltInType.NodeId:
				return new NodeId[num];
			case BuiltInType.ExpandedNodeId:
				return new ExpandedNodeId[num];
			case BuiltInType.QualifiedName:
				return new QualifiedName[num];
			case BuiltInType.LocalizedText:
				return new LocalizedText[num];
			case BuiltInType.Variant:
				return new Variant[num];
			case BuiltInType.DataValue:
				return new DataValue[num];
			case BuiltInType.ExtensionObject:
				return new ExtensionObject[num];
			case BuiltInType.DiagnosticInfo:
				return new DiagnosticInfo[num];
			case BuiltInType.Enumeration:
				return new int[num];
			case BuiltInType.Number:
				return new Variant[num];
			case BuiltInType.Integer:
				return new Variant[num];
			case BuiltInType.UInteger:
				return new Variant[num];
			}
		}
		else
		{
			switch (type)
			{
			case BuiltInType.Null:
				return Array.CreateInstance(typeof(object), dimensions);
			case BuiltInType.Boolean:
				return Array.CreateInstance(typeof(bool), dimensions);
			case BuiltInType.SByte:
				return Array.CreateInstance(typeof(sbyte), dimensions);
			case BuiltInType.Byte:
				return Array.CreateInstance(typeof(byte), dimensions);
			case BuiltInType.Int16:
				return Array.CreateInstance(typeof(short), dimensions);
			case BuiltInType.UInt16:
				return Array.CreateInstance(typeof(ushort), dimensions);
			case BuiltInType.Int32:
				return Array.CreateInstance(typeof(int), dimensions);
			case BuiltInType.UInt32:
				return Array.CreateInstance(typeof(uint), dimensions);
			case BuiltInType.Int64:
				return Array.CreateInstance(typeof(long), dimensions);
			case BuiltInType.UInt64:
				return Array.CreateInstance(typeof(ulong), dimensions);
			case BuiltInType.Float:
				return Array.CreateInstance(typeof(float), dimensions);
			case BuiltInType.Double:
				return Array.CreateInstance(typeof(double), dimensions);
			case BuiltInType.String:
				return Array.CreateInstance(typeof(string), dimensions);
			case BuiltInType.DateTime:
				return Array.CreateInstance(typeof(DateTime), dimensions);
			case BuiltInType.Guid:
				return Array.CreateInstance(typeof(Uuid), dimensions);
			case BuiltInType.ByteString:
				return Array.CreateInstance(typeof(byte[]), dimensions);
			case BuiltInType.XmlElement:
				return Array.CreateInstance(typeof(XmlElement), dimensions);
			case BuiltInType.StatusCode:
				return Array.CreateInstance(typeof(StatusCode), dimensions);
			case BuiltInType.NodeId:
				return Array.CreateInstance(typeof(NodeId), dimensions);
			case BuiltInType.ExpandedNodeId:
				return Array.CreateInstance(typeof(ExpandedNodeId), dimensions);
			case BuiltInType.QualifiedName:
				return Array.CreateInstance(typeof(QualifiedName), dimensions);
			case BuiltInType.LocalizedText:
				return Array.CreateInstance(typeof(LocalizedText), dimensions);
			case BuiltInType.Variant:
				return Array.CreateInstance(typeof(Variant), dimensions);
			case BuiltInType.DataValue:
				return Array.CreateInstance(typeof(DataValue), dimensions);
			case BuiltInType.ExtensionObject:
				return Array.CreateInstance(typeof(ExtensionObject), dimensions);
			case BuiltInType.DiagnosticInfo:
				return Array.CreateInstance(typeof(DiagnosticInfo), dimensions);
			case BuiltInType.Enumeration:
				return Array.CreateInstance(typeof(int), dimensions);
			case BuiltInType.Number:
				return Array.CreateInstance(typeof(Variant), dimensions);
			case BuiltInType.Integer:
				return Array.CreateInstance(typeof(Variant), dimensions);
			case BuiltInType.UInteger:
				return Array.CreateInstance(typeof(Variant), dimensions);
			}
		}
		return null;
	}

	public static object Cast(object source, BuiltInType targetType)
	{
		return Cast(source, Construct(source), targetType);
	}

	public static object Cast(object source, TypeInfo sourceType, BuiltInType targetType)
	{
		if (sourceType.BuiltInType == BuiltInType.Null)
		{
			return null;
		}
		if (sourceType.BuiltInType == targetType)
		{
			return source;
		}
		if (targetType == BuiltInType.Variant && sourceType.ValueRank < 0)
		{
			return new Variant(source);
		}
		if (sourceType.BuiltInType == BuiltInType.Guid)
		{
			source = Cast(source, sourceType, ToGuid);
		}
		return targetType switch
		{
			BuiltInType.Boolean => Cast(source, sourceType, ToBoolean), 
			BuiltInType.SByte => Cast(source, sourceType, ToSByte), 
			BuiltInType.Byte => Cast(source, sourceType, ToByte), 
			BuiltInType.Int16 => Cast(source, sourceType, ToInt16), 
			BuiltInType.UInt16 => Cast(source, sourceType, ToUInt16), 
			BuiltInType.Int32 => Cast(source, sourceType, ToInt32), 
			BuiltInType.UInt32 => Cast(source, sourceType, ToUInt32), 
			BuiltInType.Int64 => Cast(source, sourceType, ToInt64), 
			BuiltInType.UInt64 => Cast(source, sourceType, ToUInt64), 
			BuiltInType.Float => Cast(source, sourceType, ToFloat), 
			BuiltInType.Double => Cast(source, sourceType, ToDouble), 
			BuiltInType.String => Cast(source, sourceType, ToString), 
			BuiltInType.DateTime => Cast(source, sourceType, ToDateTime), 
			BuiltInType.Guid => Cast(source, sourceType, ToGuid), 
			BuiltInType.ByteString => Cast(source, sourceType, ToByteString), 
			BuiltInType.NodeId => Cast(source, sourceType, ToNodeId), 
			BuiltInType.ExpandedNodeId => Cast(source, sourceType, ToExpandedNodeId), 
			BuiltInType.StatusCode => Cast(source, sourceType, ToStatusCode), 
			BuiltInType.QualifiedName => Cast(source, sourceType, ToQualifiedName), 
			BuiltInType.LocalizedText => Cast(source, sourceType, ToLocalizedText), 
			BuiltInType.Variant => Cast(source, sourceType, ToVariant), 
			BuiltInType.Number => Cast(source, sourceType, ToDouble), 
			BuiltInType.Integer => Cast(source, sourceType, ToInt64), 
			BuiltInType.UInteger => Cast(source, sourceType, ToUInt64), 
			BuiltInType.Enumeration => Cast(source, sourceType, ToInt32), 
			BuiltInType.XmlElement => Cast(source, sourceType, ToXmlElement), 
			_ => throw new InvalidCastException(), 
		};
	}

	public static void CastArray(Array dst, BuiltInType dstType, Array src, BuiltInType srcType, CastArrayElementHandler convertor)
	{
		bool flag = src.GetType().GetElementType() == typeof(Variant);
		bool flag2 = dst.GetType().GetElementType() == typeof(Variant);
		if (src.Rank == 1)
		{
			for (int i = 0; i < dst.Length; i++)
			{
				object obj = src.GetValue(i);
				if (flag)
				{
					obj = ((Variant)obj).Value;
				}
				if (convertor != null)
				{
					obj = convertor(obj, srcType, dstType);
				}
				if (flag2)
				{
					obj = new Variant(obj);
				}
				dst.SetValue(obj, i);
			}
			return;
		}
		int[] array = new int[src.Rank];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = src.GetLength(j);
		}
		int length = dst.Length;
		int[] array2 = new int[array.Length];
		for (int k = 0; k < length; k++)
		{
			int num = dst.Length;
			for (int l = 0; l < array2.Length; l++)
			{
				num /= array[l];
				array2[l] = k / num % array[l];
			}
			object obj2 = src.GetValue(array2);
			if (obj2 != null)
			{
				if (flag)
				{
					obj2 = ((Variant)obj2).Value;
				}
				if (convertor != null)
				{
					obj2 = convertor(obj2, srcType, dstType);
				}
				if (flag2)
				{
					obj2 = new Variant(obj2);
				}
				dst.SetValue(obj2, array2);
			}
		}
	}

	public static Array CastArray(Array srcArray, BuiltInType srcType, BuiltInType dstType, CastArrayElementHandler convertor)
	{
		if (srcArray == null)
		{
			return null;
		}
		int[] array = new int[srcArray.Rank];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = srcArray.GetLength(i);
		}
		Array array2 = CreateArray(dstType, array);
		CastArray(array2, dstType, srcArray, srcType, convertor);
		return array2;
	}

	private static BuiltInType GetBuiltInType(string typeName)
	{
		return typeName switch
		{
			"Boolean" => BuiltInType.Boolean, 
			"SByte" => BuiltInType.SByte, 
			"Byte" => BuiltInType.Byte, 
			"Int16" => BuiltInType.Int16, 
			"UInt16" => BuiltInType.UInt16, 
			"Int32" => BuiltInType.Int32, 
			"UInt32" => BuiltInType.UInt32, 
			"Int64" => BuiltInType.Int64, 
			"UInt64" => BuiltInType.UInt64, 
			"Float" => BuiltInType.Float, 
			"Single" => BuiltInType.Float, 
			"Double" => BuiltInType.Double, 
			"String" => BuiltInType.String, 
			"DateTime" => BuiltInType.DateTime, 
			"Guid" => BuiltInType.Guid, 
			"Uuid" => BuiltInType.Guid, 
			"ByteString" => BuiltInType.ByteString, 
			"XmlElement" => BuiltInType.XmlElement, 
			"NodeId" => BuiltInType.NodeId, 
			"ExpandedNodeId" => BuiltInType.ExpandedNodeId, 
			"LocalizedText" => BuiltInType.LocalizedText, 
			"QualifiedName" => BuiltInType.QualifiedName, 
			"StatusCode" => BuiltInType.StatusCode, 
			"DiagnosticInfo" => BuiltInType.DiagnosticInfo, 
			"DataValue" => BuiltInType.DataValue, 
			"Variant" => BuiltInType.Variant, 
			"ExtensionObject" => BuiltInType.ExtensionObject, 
			"Object" => BuiltInType.Variant, 
			_ => BuiltInType.Null, 
		};
	}

	private static bool ToBoolean(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Boolean => (bool)value, 
			BuiltInType.SByte => Convert.ToBoolean((sbyte)value), 
			BuiltInType.Byte => Convert.ToBoolean((byte)value), 
			BuiltInType.Int16 => Convert.ToBoolean((short)value), 
			BuiltInType.UInt16 => Convert.ToBoolean((ushort)value), 
			BuiltInType.Int32 => Convert.ToBoolean((int)value), 
			BuiltInType.UInt32 => Convert.ToBoolean((uint)value), 
			BuiltInType.Int64 => Convert.ToBoolean((long)value), 
			BuiltInType.UInt64 => Convert.ToBoolean((ulong)value), 
			BuiltInType.Float => Convert.ToBoolean((float)value), 
			BuiltInType.Double => Convert.ToBoolean((double)value), 
			BuiltInType.String => XmlConvert.ToBoolean((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static sbyte ToSByte(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.SByte => (sbyte)value, 
			BuiltInType.Boolean => Convert.ToSByte((bool)value), 
			BuiltInType.Byte => Convert.ToSByte((byte)value), 
			BuiltInType.Int16 => Convert.ToSByte((short)value), 
			BuiltInType.UInt16 => Convert.ToSByte((ushort)value), 
			BuiltInType.Int32 => Convert.ToSByte((int)value), 
			BuiltInType.UInt32 => Convert.ToSByte((uint)value), 
			BuiltInType.Int64 => Convert.ToSByte((long)value), 
			BuiltInType.UInt64 => Convert.ToSByte((ulong)value), 
			BuiltInType.Float => Convert.ToSByte((float)value), 
			BuiltInType.Double => Convert.ToSByte((double)value), 
			BuiltInType.String => XmlConvert.ToSByte((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static byte ToByte(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Byte => (byte)value, 
			BuiltInType.Boolean => Convert.ToByte((bool)value), 
			BuiltInType.SByte => Convert.ToByte((sbyte)value), 
			BuiltInType.Int16 => Convert.ToByte((short)value), 
			BuiltInType.UInt16 => Convert.ToByte((ushort)value), 
			BuiltInType.Int32 => Convert.ToByte((int)value), 
			BuiltInType.UInt32 => Convert.ToByte((uint)value), 
			BuiltInType.Int64 => Convert.ToByte((long)value), 
			BuiltInType.UInt64 => Convert.ToByte((ulong)value), 
			BuiltInType.Float => Convert.ToByte((float)value), 
			BuiltInType.Double => Convert.ToByte((double)value), 
			BuiltInType.String => XmlConvert.ToByte((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static short ToInt16(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Int16 => (short)value, 
			BuiltInType.Boolean => Convert.ToInt16((bool)value), 
			BuiltInType.SByte => Convert.ToInt16((sbyte)value), 
			BuiltInType.Byte => Convert.ToInt16((byte)value), 
			BuiltInType.UInt16 => Convert.ToInt16((ushort)value), 
			BuiltInType.Int32 => Convert.ToInt16((int)value), 
			BuiltInType.UInt32 => Convert.ToInt16((uint)value), 
			BuiltInType.Int64 => Convert.ToInt16((long)value), 
			BuiltInType.UInt64 => Convert.ToInt16((ulong)value), 
			BuiltInType.Float => Convert.ToInt16((float)value), 
			BuiltInType.Double => Convert.ToInt16((double)value), 
			BuiltInType.String => XmlConvert.ToInt16((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static ushort ToUInt16(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.UInt16 => (ushort)value, 
			BuiltInType.Boolean => Convert.ToUInt16((bool)value), 
			BuiltInType.SByte => Convert.ToUInt16((sbyte)value), 
			BuiltInType.Byte => Convert.ToUInt16((byte)value), 
			BuiltInType.Int16 => Convert.ToUInt16((short)value), 
			BuiltInType.Int32 => Convert.ToUInt16((int)value), 
			BuiltInType.UInt32 => Convert.ToUInt16((uint)value), 
			BuiltInType.Int64 => Convert.ToUInt16((long)value), 
			BuiltInType.UInt64 => Convert.ToUInt16((ulong)value), 
			BuiltInType.Float => Convert.ToUInt16((float)value), 
			BuiltInType.Double => Convert.ToUInt16((double)value), 
			BuiltInType.String => XmlConvert.ToUInt16((string)value), 
			BuiltInType.StatusCode => (ushort)(((StatusCode)value).CodeBits >> 16), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static int ToInt32(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Int32 => (int)value, 
			BuiltInType.Boolean => Convert.ToInt32((bool)value), 
			BuiltInType.SByte => Convert.ToInt32((sbyte)value), 
			BuiltInType.Byte => Convert.ToInt32((byte)value), 
			BuiltInType.Int16 => Convert.ToInt32((short)value), 
			BuiltInType.UInt16 => Convert.ToInt32((ushort)value), 
			BuiltInType.UInt32 => Convert.ToInt32((uint)value), 
			BuiltInType.Int64 => Convert.ToInt32((long)value), 
			BuiltInType.UInt64 => Convert.ToInt32((ulong)value), 
			BuiltInType.Float => Convert.ToInt32((float)value), 
			BuiltInType.Double => Convert.ToInt32((double)value), 
			BuiltInType.String => XmlConvert.ToInt32((string)value), 
			BuiltInType.StatusCode => Convert.ToInt32(((StatusCode)value).Code), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static uint ToUInt32(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.UInt32 => (uint)value, 
			BuiltInType.Boolean => Convert.ToUInt32((bool)value), 
			BuiltInType.SByte => Convert.ToUInt32((sbyte)value), 
			BuiltInType.Byte => Convert.ToUInt32((byte)value), 
			BuiltInType.Int16 => Convert.ToUInt32((short)value), 
			BuiltInType.UInt16 => Convert.ToUInt32((ushort)value), 
			BuiltInType.Int32 => Convert.ToUInt32((int)value), 
			BuiltInType.Int64 => Convert.ToUInt32((long)value), 
			BuiltInType.UInt64 => Convert.ToUInt32((ulong)value), 
			BuiltInType.Float => Convert.ToUInt32((float)value), 
			BuiltInType.Double => Convert.ToUInt32((double)value), 
			BuiltInType.String => XmlConvert.ToUInt32((string)value), 
			BuiltInType.StatusCode => Convert.ToUInt32(((StatusCode)value).Code), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static long ToInt64(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Int64 => (long)value, 
			BuiltInType.Boolean => Convert.ToInt64((bool)value), 
			BuiltInType.SByte => Convert.ToInt64((sbyte)value), 
			BuiltInType.Byte => Convert.ToInt64((byte)value), 
			BuiltInType.Int16 => Convert.ToInt64((short)value), 
			BuiltInType.UInt16 => Convert.ToInt64((ushort)value), 
			BuiltInType.Int32 => Convert.ToInt64((int)value), 
			BuiltInType.UInt32 => Convert.ToInt64((uint)value), 
			BuiltInType.UInt64 => Convert.ToInt64((ulong)value), 
			BuiltInType.Float => Convert.ToInt64((float)value), 
			BuiltInType.Double => Convert.ToInt64((double)value), 
			BuiltInType.String => XmlConvert.ToInt64((string)value), 
			BuiltInType.StatusCode => Convert.ToInt64(((StatusCode)value).Code), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static ulong ToUInt64(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.UInt64 => (ulong)value, 
			BuiltInType.Boolean => Convert.ToUInt64((bool)value), 
			BuiltInType.SByte => Convert.ToUInt64((sbyte)value), 
			BuiltInType.Byte => Convert.ToUInt64((byte)value), 
			BuiltInType.Int16 => Convert.ToUInt64((short)value), 
			BuiltInType.UInt16 => Convert.ToUInt64((ushort)value), 
			BuiltInType.Int32 => Convert.ToUInt64((int)value), 
			BuiltInType.UInt32 => Convert.ToUInt64((uint)value), 
			BuiltInType.Int64 => Convert.ToUInt64((long)value), 
			BuiltInType.Float => Convert.ToUInt64((float)value), 
			BuiltInType.Double => Convert.ToUInt64((double)value), 
			BuiltInType.String => XmlConvert.ToUInt64((string)value), 
			BuiltInType.StatusCode => Convert.ToUInt64(((StatusCode)value).Code), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static float ToFloat(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Float => (float)value, 
			BuiltInType.Boolean => Convert.ToSingle((bool)value), 
			BuiltInType.SByte => Convert.ToSingle((sbyte)value), 
			BuiltInType.Byte => Convert.ToSingle((byte)value), 
			BuiltInType.Int16 => Convert.ToSingle((short)value), 
			BuiltInType.UInt16 => Convert.ToSingle((ushort)value), 
			BuiltInType.Int32 => Convert.ToSingle((int)value), 
			BuiltInType.UInt32 => Convert.ToSingle((uint)value), 
			BuiltInType.Int64 => Convert.ToSingle((long)value), 
			BuiltInType.UInt64 => Convert.ToSingle((ulong)value), 
			BuiltInType.Double => Convert.ToSingle((double)value), 
			BuiltInType.String => XmlConvert.ToSingle((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static double ToDouble(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.Double => (double)value, 
			BuiltInType.Boolean => Convert.ToDouble((bool)value), 
			BuiltInType.SByte => Convert.ToDouble((sbyte)value), 
			BuiltInType.Byte => Convert.ToDouble((byte)value), 
			BuiltInType.Int16 => Convert.ToDouble((short)value), 
			BuiltInType.UInt16 => Convert.ToDouble((ushort)value), 
			BuiltInType.Int32 => Convert.ToDouble((int)value), 
			BuiltInType.UInt32 => Convert.ToDouble((uint)value), 
			BuiltInType.Int64 => Convert.ToDouble((long)value), 
			BuiltInType.UInt64 => Convert.ToDouble((ulong)value), 
			BuiltInType.Float => Convert.ToDouble((float)value), 
			BuiltInType.String => XmlConvert.ToDouble((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static string ToString(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.String => (string)value, 
			BuiltInType.Boolean => XmlConvert.ToString((bool)value), 
			BuiltInType.SByte => XmlConvert.ToString((sbyte)value), 
			BuiltInType.Byte => XmlConvert.ToString((byte)value), 
			BuiltInType.Int16 => XmlConvert.ToString((short)value), 
			BuiltInType.UInt16 => XmlConvert.ToString((ushort)value), 
			BuiltInType.Int32 => XmlConvert.ToString((int)value), 
			BuiltInType.UInt32 => XmlConvert.ToString((uint)value), 
			BuiltInType.Int64 => XmlConvert.ToString((long)value), 
			BuiltInType.UInt64 => XmlConvert.ToString((ulong)value), 
			BuiltInType.Float => XmlConvert.ToString((float)value), 
			BuiltInType.Double => XmlConvert.ToString((double)value), 
			BuiltInType.DateTime => XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Unspecified), 
			BuiltInType.Guid => ((Uuid)value/*cast due to constrained. prefix*/).ToString(), 
			BuiltInType.NodeId => ((NodeId)value).ToString(), 
			BuiltInType.ExpandedNodeId => ((ExpandedNodeId)value).ToString(), 
			BuiltInType.LocalizedText => ((LocalizedText)value).Text, 
			BuiltInType.QualifiedName => ((QualifiedName)value).ToString(), 
			BuiltInType.XmlElement => ((XmlElement)value).OuterXml, 
			BuiltInType.StatusCode => ((StatusCode)value).Code.ToString(), 
			BuiltInType.ExtensionObject => ((ExtensionObject)value).ToString(), 
			BuiltInType.Null => null, 
			_ => throw new InvalidCastException(), 
		};
	}

	private static DateTime ToDateTime(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.DateTime => (DateTime)value, 
			BuiltInType.String => XmlConvert.ToDateTime((string)value, XmlDateTimeSerializationMode.Unspecified), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static Uuid ToGuid(object value, TypeInfo sourceType)
	{
		switch (sourceType.BuiltInType)
		{
		case BuiltInType.String:
			return new Uuid((string)value);
		case BuiltInType.ByteString:
			return new Uuid(new Guid((byte[])value));
		case BuiltInType.Guid:
		{
			Guid? guid = value as Guid?;
			if (guid.HasValue)
			{
				return new Uuid(guid.Value);
			}
			return (Uuid)value;
		}
		default:
			throw new InvalidCastException();
		}
	}

	private static byte[] ToByteString(object value, TypeInfo sourceType)
	{
		switch (sourceType.BuiltInType)
		{
		case BuiltInType.ByteString:
			return (byte[])value;
		case BuiltInType.String:
		{
			string text = (string)value;
			if (text == null)
			{
				return null;
			}
			if (text.Length == 0)
			{
				return Array.Empty<byte>();
			}
			using MemoryStream memoryStream = new MemoryStream();
			byte b = 0;
			bool flag = false;
			for (int i = 0; i < text.Length; i++)
			{
				if (!char.IsWhiteSpace(text, i) && !char.IsLetterOrDigit(text, i))
				{
					throw new FormatException("Invalid character in ByteString. " + text[i]);
				}
				if (!char.IsWhiteSpace(text, i))
				{
					int num = "0123456789ABCDEF".IndexOf(char.ToUpper(text[i]));
					if (num < 0)
					{
						throw new FormatException("Invalid character in ByteString." + text[i]);
					}
					b <<= 4;
					b += (byte)num;
					if (flag)
					{
						memoryStream.WriteByte(b);
						flag = false;
					}
					else
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				b <<= 4;
				memoryStream.WriteByte(b);
			}
			return memoryStream.ToArray();
		}
		case BuiltInType.Guid:
			return ((Guid)(Uuid)value).ToByteArray();
		default:
			throw new InvalidCastException();
		}
	}

	private static XmlElement ToXmlElement(object value, TypeInfo sourceType)
	{
		switch (sourceType.BuiltInType)
		{
		case BuiltInType.XmlElement:
			return (XmlElement)value;
		case BuiltInType.String:
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadInnerXml((string)value);
			return xmlDocument.DocumentElement;
		}
		default:
			throw new InvalidCastException();
		}
	}

	private static NodeId ToNodeId(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.NodeId => (NodeId)value, 
			BuiltInType.ExpandedNodeId => (NodeId)(ExpandedNodeId)value, 
			BuiltInType.String => NodeId.Parse((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static ExpandedNodeId ToExpandedNodeId(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.ExpandedNodeId => (ExpandedNodeId)value, 
			BuiltInType.NodeId => (NodeId)value, 
			BuiltInType.String => ExpandedNodeId.Parse((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static StatusCode ToStatusCode(object value, TypeInfo sourceType)
	{
		switch (sourceType.BuiltInType)
		{
		case BuiltInType.StatusCode:
			return (StatusCode)value;
		case BuiltInType.UInt16:
			return Convert.ToUInt32((ushort)value) << 16;
		case BuiltInType.Int32:
			return Convert.ToUInt32((int)value);
		case BuiltInType.UInt32:
			return (uint)value;
		case BuiltInType.Int64:
			return Convert.ToUInt32((long)value);
		case BuiltInType.UInt64:
			return Convert.ToUInt32((ulong)value);
		case BuiltInType.String:
		{
			string text = (string)value;
			if (text == null)
			{
				return 0u;
			}
			text = text.Trim();
			if (text.StartsWith("0x"))
			{
				return Convert.ToUInt32(text.Substring(2), 16);
			}
			return Convert.ToUInt32((string)value);
		}
		default:
			throw new InvalidCastException();
		}
	}

	private static QualifiedName ToQualifiedName(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.QualifiedName => (QualifiedName)value, 
			BuiltInType.String => QualifiedName.Parse((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static LocalizedText ToLocalizedText(object value, TypeInfo sourceType)
	{
		return sourceType.BuiltInType switch
		{
			BuiltInType.LocalizedText => (LocalizedText)value, 
			BuiltInType.String => new LocalizedText((string)value), 
			_ => throw new InvalidCastException(), 
		};
	}

	private static Variant ToVariant(object value, TypeInfo sourceType)
	{
		return new Variant(value);
	}

	private static object Cast<T>(object input, TypeInfo sourceType, CastDelegate<T> handler)
	{
		if (sourceType == null)
		{
			sourceType = Construct(input);
		}
		if (sourceType.ValueRank >= 0)
		{
			return Cast((Array)input, sourceType, handler);
		}
		if (sourceType.BuiltInType == BuiltInType.Variant)
		{
			object value = ((Variant)input).Value;
			sourceType = Construct(value);
			return handler(value, sourceType);
		}
		return handler(input, sourceType);
	}

	private static Array Cast<T>(Array input, TypeInfo sourceType, CastDelegate<T> handler)
	{
		if (input == null)
		{
			return null;
		}
		TypeInfo sourceType2 = new TypeInfo(sourceType.BuiltInType, -1);
		if (input.Rank == 1)
		{
			T[] array = new T[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				object value = input.GetValue(i);
				if (value != null)
				{
					if (sourceType.BuiltInType == BuiltInType.Variant)
					{
						value = ((Variant)value).Value;
						sourceType2 = Construct(value);
					}
					array[i] = handler(value, sourceType2);
				}
			}
			return array;
		}
		if (input.Rank == 2)
		{
			int length = input.GetLength(0);
			int length2 = input.GetLength(1);
			T[,] array2 = new T[length, length2];
			for (int j = 0; j < length; j++)
			{
				for (int k = 0; k < length2; k++)
				{
					object value2 = input.GetValue(j, k);
					if (value2 != null)
					{
						if (sourceType.BuiltInType == BuiltInType.Variant)
						{
							value2 = ((Variant)value2).Value;
							sourceType2 = Construct(value2);
						}
						array2[j, k] = handler(value2, sourceType2);
					}
				}
			}
			return array2;
		}
		int[] array3 = new int[input.Rank];
		for (int l = 0; l < array3.Length; l++)
		{
			array3[l] = input.GetLength(l);
		}
		Array array4 = Array.CreateInstance(typeof(T), array3);
		int length3 = array4.Length;
		int[] array5 = new int[array3.Length];
		for (int m = 0; m < length3; m++)
		{
			int num = array4.Length;
			for (int n = 0; n < array5.Length; n++)
			{
				num /= array3[n];
				array5[n] = m / num % array3[n];
			}
			object value3 = input.GetValue(array5);
			if (value3 != null)
			{
				if (sourceType.BuiltInType == BuiltInType.Variant)
				{
					value3 = ((Variant)value3).Value;
					sourceType2 = Construct(value3);
				}
				array4.SetValue(handler(value3, sourceType2), array5);
			}
		}
		return array4;
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(m_builtInType);
			if (m_valueRank >= 0)
			{
				stringBuilder.Append('[');
				for (int i = 1; i < m_valueRank; i++)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(']');
			}
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is TypeInfo typeInfo)
		{
			if (m_builtInType == typeInfo.BuiltInType)
			{
				return m_valueRank == typeInfo.ValueRank;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(m_builtInType, m_valueRank);
	}
}
