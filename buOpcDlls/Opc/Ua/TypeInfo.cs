// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TypeInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TypeInfo : IFormattable
{
  private BuiltInType m_builtInType;
  private int m_valueRank;
  private static readonly TypeInfo s_Unknown = new TypeInfo();

  internal TypeInfo()
  {
    this.m_builtInType = BuiltInType.Null;
    this.m_valueRank = -2;
  }

  public TypeInfo(BuiltInType builtInType, int valueRank)
  {
    this.m_builtInType = builtInType;
    this.m_valueRank = valueRank;
  }

  public static NodeId GetDataTypeId(object value)
  {
    if (value == null)
      return NodeId.Null;
    NodeId dataTypeId = TypeInfo.GetDataTypeId(value.GetType());
    return dataTypeId == (object) NodeId.Null && value is Matrix matrix ? TypeInfo.GetDataTypeId(matrix.TypeInfo) : dataTypeId;
  }

  public static NodeId GetDataTypeId(Type type)
  {
    NodeId dataTypeId = TypeInfo.GetDataTypeId(TypeInfo.Construct(type));
    return NodeId.IsNull(dataTypeId) && (type.GetTypeInfo().IsEnum || type.IsArray && type.GetElementType().GetTypeInfo().IsEnum) ? (NodeId) 29U : dataTypeId;
  }

  public static NodeId GetDataTypeId(TypeInfo typeInfo)
  {
    switch (typeInfo.BuiltInType)
    {
      case BuiltInType.Boolean:
        return DataTypeIds.Boolean;
      case BuiltInType.SByte:
        return DataTypeIds.SByte;
      case BuiltInType.Byte:
        return DataTypeIds.Byte;
      case BuiltInType.Int16:
        return DataTypeIds.Int16;
      case BuiltInType.UInt16:
        return DataTypeIds.UInt16;
      case BuiltInType.Int32:
        return DataTypeIds.Int32;
      case BuiltInType.UInt32:
        return DataTypeIds.UInt32;
      case BuiltInType.Int64:
        return DataTypeIds.Int64;
      case BuiltInType.UInt64:
        return DataTypeIds.UInt64;
      case BuiltInType.Float:
        return DataTypeIds.Float;
      case BuiltInType.Double:
        return DataTypeIds.Double;
      case BuiltInType.String:
        return DataTypeIds.String;
      case BuiltInType.DateTime:
        return DataTypeIds.DateTime;
      case BuiltInType.Guid:
        return DataTypeIds.Guid;
      case BuiltInType.ByteString:
        return DataTypeIds.ByteString;
      case BuiltInType.XmlElement:
        return DataTypeIds.XmlElement;
      case BuiltInType.NodeId:
        return DataTypeIds.NodeId;
      case BuiltInType.ExpandedNodeId:
        return DataTypeIds.ExpandedNodeId;
      case BuiltInType.StatusCode:
        return DataTypeIds.StatusCode;
      case BuiltInType.QualifiedName:
        return DataTypeIds.QualifiedName;
      case BuiltInType.LocalizedText:
        return DataTypeIds.LocalizedText;
      case BuiltInType.ExtensionObject:
        return DataTypeIds.Structure;
      case BuiltInType.DataValue:
        return DataTypeIds.DataValue;
      case BuiltInType.Variant:
        return DataTypeIds.BaseDataType;
      case BuiltInType.DiagnosticInfo:
        return DataTypeIds.DiagnosticInfo;
      case BuiltInType.Number:
        return DataTypeIds.Number;
      case BuiltInType.Integer:
        return DataTypeIds.Integer;
      case BuiltInType.UInteger:
        return DataTypeIds.UInteger;
      case BuiltInType.Enumeration:
        return DataTypeIds.Enumeration;
      default:
        return NodeId.Null;
    }
  }

  public static int GetValueRank(object value)
  {
    if (value == null)
      return -2;
    TypeInfo typeInfo = TypeInfo.Construct(value);
    return typeInfo.BuiltInType == BuiltInType.Null && value is Matrix matrix ? matrix.TypeInfo.ValueRank : typeInfo.ValueRank;
  }

  public static int GetValueRank(Type type)
  {
    TypeInfo typeInfo = TypeInfo.Construct(type);
    if (typeInfo.BuiltInType != BuiltInType.Null || !type.GetTypeInfo().IsEnum && (!type.IsArray || !type.GetElementType().GetTypeInfo().IsEnum))
      return typeInfo.ValueRank;
    return type.IsArray ? 0 : -1;
  }

  public static BuiltInType GetBuiltInType(NodeId datatypeId)
  {
    if (datatypeId == (object) null || datatypeId.NamespaceIndex != (ushort) 0 || datatypeId.IdType != IdType.Numeric)
      return BuiltInType.Null;
    switch ((uint) datatypeId.Identifier)
    {
      case 30:
      case 311:
      case 521:
      case 2000:
      case 2001:
      case 2002:
      case 2003:
      case 16307:
        return BuiltInType.ByteString;
      case 288:
      case 289:
      case 17588:
      case 20998:
        return BuiltInType.UInt32;
      case 290:
        return BuiltInType.Double;
      case 291:
      case 295:
      case 12877:
      case 12878:
      case 12879:
      case 12880:
      case 12881:
        return BuiltInType.String;
      case 294:
        return BuiltInType.DateTime;
      case 388:
        return BuiltInType.NodeId;
      case 11737:
        return BuiltInType.UInt64;
      default:
        BuiltInType builtInType = (BuiltInType) Enum.ToObject(typeof (BuiltInType), datatypeId.Identifier);
        return builtInType > BuiltInType.DiagnosticInfo && builtInType != BuiltInType.Enumeration ? BuiltInType.Null : builtInType;
    }
  }

  public static bool IsNumericType(BuiltInType builtInType)
  {
    return builtInType >= BuiltInType.SByte && builtInType <= BuiltInType.Double || builtInType >= BuiltInType.Number && builtInType <= BuiltInType.UInteger;
  }

  public static bool IsValueType(BuiltInType builtInType)
  {
    return builtInType >= BuiltInType.Boolean && builtInType <= BuiltInType.Double || builtInType == BuiltInType.DateTime || builtInType == BuiltInType.Guid || builtInType == BuiltInType.StatusCode;
  }

  public static bool IsEncodingNullableType(BuiltInType builtInType)
  {
    return (builtInType < BuiltInType.Boolean || builtInType > BuiltInType.Double) && builtInType != BuiltInType.DataValue && builtInType != BuiltInType.DiagnosticInfo;
  }

  public static BuiltInType GetBuiltInType(NodeId datatypeId, ITypeTable typeTree)
  {
    for (NodeId nodeId = datatypeId; !NodeId.IsNull(nodeId); nodeId = typeTree.FindSuperType(nodeId))
    {
      if (nodeId != (object) null && nodeId.NamespaceIndex == (ushort) 0 && nodeId.IdType == IdType.Numeric)
      {
        BuiltInType identifier = (BuiltInType) (uint) nodeId.Identifier;
        if (identifier > BuiltInType.Null && identifier <= BuiltInType.Enumeration && identifier != BuiltInType.DiagnosticInfo)
          return identifier;
      }
      if (typeTree == null)
        break;
    }
    return BuiltInType.Null;
  }

  public static async Task<BuiltInType> GetBuiltInTypeAsync(
    NodeId datatypeId,
    ITypeTable typeTree,
    CancellationToken ct = default (CancellationToken))
  {
    ConfiguredTaskAwaitable<NodeId>.ConfiguredTaskAwaiter awaiter;
    for (NodeId nodeId = datatypeId; !NodeId.IsNull(nodeId); nodeId = awaiter.GetResult())
    {
      if (nodeId != (object) null && nodeId.NamespaceIndex == (ushort) 0 && nodeId.IdType == IdType.Numeric)
      {
        BuiltInType identifier = (BuiltInType) (uint) nodeId.Identifier;
        if (identifier > BuiltInType.Null && identifier <= BuiltInType.Enumeration && identifier != BuiltInType.DiagnosticInfo)
          return identifier;
      }
      if (typeTree != null)
      {
        awaiter = typeTree.FindSuperTypeAsync(nodeId, ct).ConfigureAwait(false).GetAwaiter();
        if (!awaiter.IsCompleted)
        {
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 0;
          ConfiguredTaskAwaitable<NodeId>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<NodeId>.ConfiguredTaskAwaiter, TypeInfo.\u003CGetBuiltInTypeAsync\u003Ed__12>(ref awaiter, this);
          return;
        }
      }
      else
        break;
    }
    return BuiltInType.Null;
  }

  public static Type GetSystemType(ExpandedNodeId datatypeId, IEncodeableFactory factory)
  {
    if (datatypeId == (object) null)
      return (Type) null;
    if (datatypeId.NamespaceIndex != (ushort) 0 || datatypeId.IdType != IdType.Numeric || datatypeId.IsAbsolute)
      return factory.GetSystemType(datatypeId);
    switch ((uint) datatypeId.Identifier)
    {
      case 1:
        return typeof (bool);
      case 2:
        return typeof (sbyte);
      case 3:
        return typeof (byte);
      case 4:
        return typeof (short);
      case 5:
        return typeof (ushort);
      case 6:
        return typeof (int);
      case 7:
      case 288:
      case 289:
      case 17588:
      case 20998:
        return typeof (uint);
      case 8:
        return typeof (long);
      case 9:
      case 11737:
        return typeof (ulong);
      case 10:
        return typeof (float);
      case 11:
      case 290:
        return typeof (double);
      case 12:
      case 291:
      case 295:
      case 12877:
      case 12878:
      case 12879:
      case 12880:
      case 12881:
        return typeof (string);
      case 13:
      case 294:
        return typeof (DateTime);
      case 14:
        return typeof (Uuid);
      case 15:
      case 30:
      case 311:
      case 521:
      case 2000:
      case 2001:
      case 2002:
      case 2003:
      case 16307:
        return typeof (byte[]);
      case 16 /*0x10*/:
        return typeof (XmlElement);
      case 17:
      case 388:
        return typeof (NodeId);
      case 18:
        return typeof (ExpandedNodeId);
      case 19:
        return typeof (StatusCode);
      case 20:
        return typeof (QualifiedName);
      case 21:
        return typeof (LocalizedText);
      case 22:
        return typeof (ExtensionObject);
      case 23:
        return typeof (DataValue);
      case 24:
        return typeof (Variant);
      case 25:
        return typeof (DiagnosticInfo);
      case 26:
        return typeof (Variant);
      case 27:
        return typeof (Variant);
      case 28:
        return typeof (Variant);
      case 29:
        return typeof (int);
      default:
        return factory.GetSystemType(datatypeId);
    }
  }

  public static TypeInfo Unknown => TypeInfo.s_Unknown;

  public BuiltInType BuiltInType => this.m_builtInType;

  public int ValueRank => this.m_valueRank;

  public static TypeInfo IsInstanceOfDataType(
    object value,
    NodeId expectedDataTypeId,
    int expectedValueRank,
    NamespaceTable namespaceUris,
    ITypeTable typeTree)
  {
    TypeInfo typeInfo = TypeInfo.Construct(value);
    if (typeInfo.BuiltInType == BuiltInType.Null)
    {
      BuiltInType builtInType = TypeInfo.GetBuiltInType(expectedDataTypeId, typeTree);
      if (expectedValueRank != -1)
        return new TypeInfo(builtInType, 1);
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
          return (TypeInfo) null;
      }
    }
    else
    {
      if (typeInfo.BuiltInType == BuiltInType.ByteString && typeInfo.ValueRank == -1 && (expectedValueRank == 0 || expectedValueRank == 1))
        return typeTree.IsTypeOf(expectedDataTypeId, (NodeId) 3U) ? typeInfo : (TypeInfo) null;
      if (!ValueRanks.IsValid(typeInfo.ValueRank, expectedValueRank))
        return (TypeInfo) null;
      if (expectedDataTypeId.IdType == IdType.Numeric && expectedDataTypeId.NamespaceIndex == (ushort) 0)
      {
        BuiltInType builtInType = typeInfo.BuiltInType;
        switch ((uint) expectedDataTypeId.Identifier)
        {
          case 22:
            return typeInfo.BuiltInType == BuiltInType.ExtensionObject ? typeInfo : (TypeInfo) null;
          case 24:
            if (typeInfo.BuiltInType != BuiltInType.Variant)
              return typeInfo;
            break;
          case 26:
            switch (builtInType)
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
                if (typeInfo.ValueRank == -1)
                  return (TypeInfo) null;
                break;
              default:
                return (TypeInfo) null;
            }
            break;
          case 27:
            switch (builtInType)
            {
              case BuiltInType.SByte:
              case BuiltInType.Int16:
              case BuiltInType.Int32:
              case BuiltInType.Int64:
                return typeInfo;
              case BuiltInType.Variant:
                if (typeInfo.ValueRank == -1)
                  return (TypeInfo) null;
                break;
              default:
                return (TypeInfo) null;
            }
            break;
          case 28:
            switch (builtInType)
            {
              case BuiltInType.Byte:
              case BuiltInType.UInt16:
              case BuiltInType.UInt32:
              case BuiltInType.UInt64:
                return typeInfo;
              case BuiltInType.Variant:
                if (typeInfo.ValueRank == -1)
                  return (TypeInfo) null;
                break;
              default:
                return (TypeInfo) null;
            }
            break;
          case 29:
            return typeInfo.BuiltInType == BuiltInType.Int32 ? typeInfo : (TypeInfo) null;
        }
      }
      if (typeInfo.BuiltInType != BuiltInType.ExtensionObject && typeInfo.BuiltInType != BuiltInType.Variant)
        return typeTree.IsTypeOf(expectedDataTypeId, new NodeId((uint) typeInfo.BuiltInType)) || typeInfo.BuiltInType == BuiltInType.Int32 && typeTree.IsTypeOf(expectedDataTypeId, (NodeId) 29U) || TypeInfo.GetBuiltInType(expectedDataTypeId, typeTree) == BuiltInType.Variant ? typeInfo : (TypeInfo) null;
      if (typeInfo.ValueRank < 0)
      {
        if (typeInfo.BuiltInType == BuiltInType.ExtensionObject)
        {
          switch (TypeInfo.GetBuiltInType(expectedDataTypeId, typeTree))
          {
            case BuiltInType.ExtensionObject:
              break;
            case BuiltInType.Variant:
              return typeInfo;
            default:
              return (TypeInfo) null;
          }
        }
        NodeId dataTypeId = typeInfo.GetDataTypeId(value, namespaceUris, typeTree);
        return typeTree.IsTypeOf(dataTypeId, expectedDataTypeId) ? typeInfo : (TypeInfo) null;
      }
      if (!(value is Array array) && value is Matrix matrix)
        array = matrix.Elements;
      if (array == null)
        return (TypeInfo) null;
      BuiltInType builtInType1 = TypeInfo.GetBuiltInType(expectedDataTypeId, typeTree);
      BuiltInType builtInType2 = TypeInfo.GetBuiltInType(array.GetType().GetElementType().Name);
      if (builtInType2 != BuiltInType.ExtensionObject && builtInType2 == builtInType1 || builtInType1 == BuiltInType.Variant)
        return typeInfo;
      int[] numArray1 = new int[array.Rank];
      for (int dimension = 0; dimension < numArray1.Length; ++dimension)
        numArray1[dimension] = array.GetLength(dimension);
      int[] numArray2 = new int[numArray1.Length];
      for (int index1 = 0; index1 < array.Length; ++index1)
      {
        int length = array.Length;
        for (int index2 = 0; index2 < numArray2.Length; ++index2)
        {
          length /= numArray1[index2];
          numArray2[index2] = index1 / length % numArray1[index2];
        }
        object obj = array.GetValue(numArray2);
        if (builtInType2 == BuiltInType.Variant)
          obj = ((Variant) obj).Value;
        if (TypeInfo.IsInstanceOfDataType(obj, expectedDataTypeId, -1, namespaceUris, typeTree) == null)
          return (TypeInfo) null;
      }
      return typeInfo;
    }
  }

  public NodeId GetDataTypeId(object value, NamespaceTable namespaceUris, ITypeTable typeTree)
  {
    if (this.BuiltInType == BuiltInType.Null)
      return NodeId.Null;
    if (this.BuiltInType != BuiltInType.ExtensionObject)
      return new NodeId((uint) this.BuiltInType);
    switch (value)
    {
      case IEncodeable encodeable:
        return ExpandedNodeId.ToNodeId(encodeable.TypeId, namespaceUris);
      case ExtensionObject extensionObject:
        return extensionObject.Body is IEncodeable body ? ExpandedNodeId.ToNodeId(body.TypeId, namespaceUris) : typeTree.FindDataTypeId(extensionObject.TypeId);
      default:
        return (NodeId) 22U;
    }
  }

  public static Type GetSystemType(BuiltInType builtInType, int valueRank)
  {
    if (valueRank == -1)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          return typeof (bool);
        case BuiltInType.SByte:
          return typeof (sbyte);
        case BuiltInType.Byte:
          return typeof (byte);
        case BuiltInType.Int16:
          return typeof (short);
        case BuiltInType.UInt16:
          return typeof (ushort);
        case BuiltInType.Int32:
          return typeof (int);
        case BuiltInType.UInt32:
          return typeof (uint);
        case BuiltInType.Int64:
          return typeof (long);
        case BuiltInType.UInt64:
          return typeof (ulong);
        case BuiltInType.Float:
          return typeof (float);
        case BuiltInType.Double:
          return typeof (double);
        case BuiltInType.String:
          return typeof (string);
        case BuiltInType.DateTime:
          return typeof (DateTime);
        case BuiltInType.Guid:
          return typeof (Uuid);
        case BuiltInType.ByteString:
          return typeof (byte[]);
        case BuiltInType.XmlElement:
          return typeof (XmlElement);
        case BuiltInType.NodeId:
          return typeof (NodeId);
        case BuiltInType.ExpandedNodeId:
          return typeof (ExpandedNodeId);
        case BuiltInType.StatusCode:
          return typeof (StatusCode);
        case BuiltInType.QualifiedName:
          return typeof (QualifiedName);
        case BuiltInType.LocalizedText:
          return typeof (LocalizedText);
        case BuiltInType.ExtensionObject:
          return typeof (ExtensionObject);
        case BuiltInType.DataValue:
          return typeof (DataValue);
        case BuiltInType.Variant:
          return typeof (Variant);
        case BuiltInType.DiagnosticInfo:
          return typeof (DiagnosticInfo);
        case BuiltInType.Number:
          return typeof (Variant);
        case BuiltInType.Integer:
          return typeof (Variant);
        case BuiltInType.UInteger:
          return typeof (Variant);
        case BuiltInType.Enumeration:
          return typeof (int);
      }
    }
    else if (valueRank == 1)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          return typeof (bool[]);
        case BuiltInType.SByte:
          return typeof (sbyte[]);
        case BuiltInType.Byte:
          return typeof (byte[]);
        case BuiltInType.Int16:
          return typeof (short[]);
        case BuiltInType.UInt16:
          return typeof (ushort[]);
        case BuiltInType.Int32:
          return typeof (int[]);
        case BuiltInType.UInt32:
          return typeof (uint[]);
        case BuiltInType.Int64:
          return typeof (long[]);
        case BuiltInType.UInt64:
          return typeof (ulong[]);
        case BuiltInType.Float:
          return typeof (float[]);
        case BuiltInType.Double:
          return typeof (double[]);
        case BuiltInType.String:
          return typeof (string[]);
        case BuiltInType.DateTime:
          return typeof (DateTime[]);
        case BuiltInType.Guid:
          return typeof (Uuid[]);
        case BuiltInType.ByteString:
          return typeof (byte[][]);
        case BuiltInType.XmlElement:
          return typeof (XmlElement[]);
        case BuiltInType.NodeId:
          return typeof (NodeId[]);
        case BuiltInType.ExpandedNodeId:
          return typeof (ExpandedNodeId[]);
        case BuiltInType.StatusCode:
          return typeof (StatusCode[]);
        case BuiltInType.QualifiedName:
          return typeof (QualifiedName[]);
        case BuiltInType.LocalizedText:
          return typeof (LocalizedText[]);
        case BuiltInType.ExtensionObject:
          return typeof (ExtensionObject[]);
        case BuiltInType.DataValue:
          return typeof (DataValue[]);
        case BuiltInType.Variant:
          return typeof (Variant[]);
        case BuiltInType.DiagnosticInfo:
          return typeof (DiagnosticInfo[]);
        case BuiltInType.Number:
          return typeof (Variant[]);
        case BuiltInType.Integer:
          return typeof (Variant[]);
        case BuiltInType.UInteger:
          return typeof (Variant[]);
        case BuiltInType.Enumeration:
          return typeof (int[]);
      }
    }
    else if (valueRank >= 2)
    {
      switch (builtInType)
      {
        case BuiltInType.Boolean:
          return typeof (bool).MakeArrayType(valueRank);
        case BuiltInType.SByte:
          return typeof (sbyte).MakeArrayType(valueRank);
        case BuiltInType.Byte:
          return typeof (byte).MakeArrayType(valueRank);
        case BuiltInType.Int16:
          return typeof (short).MakeArrayType(valueRank);
        case BuiltInType.UInt16:
          return typeof (ushort).MakeArrayType(valueRank);
        case BuiltInType.Int32:
          return typeof (int).MakeArrayType(valueRank);
        case BuiltInType.UInt32:
          return typeof (uint).MakeArrayType(valueRank);
        case BuiltInType.Int64:
          return typeof (long).MakeArrayType(valueRank);
        case BuiltInType.UInt64:
          return typeof (ulong).MakeArrayType(valueRank);
        case BuiltInType.Float:
          return typeof (float).MakeArrayType(valueRank);
        case BuiltInType.Double:
          return typeof (double).MakeArrayType(valueRank);
        case BuiltInType.String:
          return typeof (string).MakeArrayType(valueRank);
        case BuiltInType.DateTime:
          return typeof (DateTime).MakeArrayType(valueRank);
        case BuiltInType.Guid:
          return typeof (Uuid).MakeArrayType(valueRank);
        case BuiltInType.ByteString:
          return typeof (byte[]).MakeArrayType(valueRank);
        case BuiltInType.XmlElement:
          return typeof (XmlElement).MakeArrayType(valueRank);
        case BuiltInType.NodeId:
          return typeof (NodeId).MakeArrayType(valueRank);
        case BuiltInType.ExpandedNodeId:
          return typeof (ExpandedNodeId).MakeArrayType(valueRank);
        case BuiltInType.StatusCode:
          return typeof (StatusCode).MakeArrayType(valueRank);
        case BuiltInType.QualifiedName:
          return typeof (QualifiedName).MakeArrayType(valueRank);
        case BuiltInType.LocalizedText:
          return typeof (LocalizedText).MakeArrayType(valueRank);
        case BuiltInType.ExtensionObject:
          return typeof (ExtensionObject).MakeArrayType(valueRank);
        case BuiltInType.DataValue:
          return typeof (DataValue).MakeArrayType(valueRank);
        case BuiltInType.Variant:
          return typeof (Variant).MakeArrayType(valueRank);
        case BuiltInType.DiagnosticInfo:
          return typeof (DiagnosticInfo).MakeArrayType(valueRank);
        case BuiltInType.Number:
        case BuiltInType.Integer:
        case BuiltInType.UInteger:
          return typeof (Variant).MakeArrayType(valueRank);
        case BuiltInType.Enumeration:
          return typeof (int).MakeArrayType(valueRank);
      }
    }
    return typeof (Variant);
  }

  public static TypeInfo Construct(object value)
  {
    if (value == null)
      return TypeInfo.Unknown;
    TypeInfo typeInfo = TypeInfo.Construct(value.GetType());
    return typeInfo.BuiltInType == BuiltInType.Null && value is Matrix matrix ? matrix.TypeInfo : typeInfo;
  }

  public static TypeInfo Construct(Type systemType)
  {
    if (systemType == (Type) null)
      return TypeInfo.Unknown;
    string typeName = systemType.Name;
    string str = (string) null;
    if (typeName[typeName.Length - 1] == ']')
    {
      int num = typeName.IndexOf('[');
      if (num != -1)
      {
        str = typeName.Substring(num);
        typeName = typeName.Substring(0, num);
      }
    }
    if (str == null)
    {
      BuiltInType builtInType1 = TypeInfo.GetBuiltInType(typeName);
      if (builtInType1 != BuiltInType.Null)
        return new TypeInfo(builtInType1, -1);
      if (systemType.GetTypeInfo().IsEnum)
        return new TypeInfo(BuiltInType.Enumeration, -1);
      if (typeName.EndsWith("Collection", StringComparison.Ordinal))
      {
        BuiltInType builtInType2 = TypeInfo.GetBuiltInType(typeName.Substring(0, typeName.Length - "Collection".Length));
        if (builtInType2 != BuiltInType.Null)
          return new TypeInfo(builtInType2, 1);
        return systemType.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType ? TypeInfo.Construct(systemType.GetTypeInfo().BaseType) : TypeInfo.Unknown;
      }
      if (systemType.GetTypeInfo().IsGenericType)
      {
        Type[] genericArguments = systemType.GetGenericArguments();
        if (genericArguments != null && genericArguments.Length == 1)
        {
          TypeInfo typeInfo = TypeInfo.Construct(genericArguments[0]);
          if (typeInfo.BuiltInType != BuiltInType.Null && typeInfo.ValueRank == -1)
            return new TypeInfo(typeInfo.BuiltInType, 1);
        }
        return TypeInfo.Unknown;
      }
      return !typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) && !(typeName == "IEncodeable") ? TypeInfo.Unknown : new TypeInfo(BuiltInType.ExtensionObject, -1);
    }
    if (str.Length == 2)
    {
      BuiltInType builtInType = TypeInfo.GetBuiltInType(typeName);
      switch (builtInType)
      {
        case BuiltInType.Null:
          if (typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetElementType().GetTypeInfo()) || typeName == "IEncodeable")
            return new TypeInfo(BuiltInType.ExtensionObject, 1);
          return systemType.GetTypeInfo().GetElementType().IsEnum ? new TypeInfo(BuiltInType.Enumeration, 1) : TypeInfo.Unknown;
        case BuiltInType.Byte:
          return new TypeInfo(BuiltInType.ByteString, -1);
        default:
          return new TypeInfo(builtInType, 1);
      }
    }
    else
    {
      int valueRank = 1;
      for (int index = 1; index < str.Length - 1; ++index)
      {
        if (str[index] == ',')
          ++valueRank;
      }
      if (valueRank + 1 == str.Length)
      {
        BuiltInType builtInType = TypeInfo.GetBuiltInType(typeName);
        if (builtInType != BuiltInType.Null)
          return new TypeInfo(builtInType, valueRank);
        return !typeof (IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) && !(typeName == "IEncodeable") ? TypeInfo.Unknown : new TypeInfo(BuiltInType.ExtensionObject, valueRank);
      }
      return str[1] == ']' && typeName == "Byte" && valueRank + 3 == str.Length ? new TypeInfo(BuiltInType.ByteString, valueRank) : TypeInfo.Unknown;
    }
  }

  public static object GetDefaultValue(BuiltInType type)
  {
    switch (type)
    {
      case BuiltInType.Boolean:
        return (object) false;
      case BuiltInType.SByte:
        return (object) (sbyte) 0;
      case BuiltInType.Byte:
        return (object) (byte) 0;
      case BuiltInType.Int16:
        return (object) (short) 0;
      case BuiltInType.UInt16:
        return (object) (ushort) 0;
      case BuiltInType.Int32:
        return (object) 0;
      case BuiltInType.UInt32:
        return (object) 0U;
      case BuiltInType.Int64:
        return (object) 0L;
      case BuiltInType.UInt64:
        return (object) 0UL;
      case BuiltInType.Float:
        return (object) 0.0f;
      case BuiltInType.Double:
        return (object) 0.0;
      case BuiltInType.String:
        return (object) null;
      case BuiltInType.DateTime:
        return (object) DateTime.MinValue;
      case BuiltInType.Guid:
        return (object) Uuid.Empty;
      case BuiltInType.ByteString:
        return (object) null;
      case BuiltInType.XmlElement:
        return (object) null;
      case BuiltInType.NodeId:
        return (object) NodeId.Null;
      case BuiltInType.ExpandedNodeId:
        return (object) ExpandedNodeId.Null;
      case BuiltInType.StatusCode:
        return (object) new StatusCode(0U);
      case BuiltInType.QualifiedName:
        return (object) QualifiedName.Null;
      case BuiltInType.LocalizedText:
        return (object) LocalizedText.Null;
      case BuiltInType.DataValue:
        return (object) null;
      case BuiltInType.Variant:
        return (object) Variant.Null;
      case BuiltInType.Number:
        return (object) 0.0;
      case BuiltInType.Integer:
        return (object) 0L;
      case BuiltInType.UInteger:
        return (object) 0UL;
      case BuiltInType.Enumeration:
        return (object) 0;
      default:
        return (object) null;
    }
  }

  public static object GetDefaultValue(NodeId dataType, int valueRank)
  {
    return TypeInfo.GetDefaultValue(dataType, valueRank, (ITypeTable) null);
  }

  public static object GetDefaultValue(NodeId dataType, int valueRank, ITypeTable typeTree)
  {
    if (valueRank != -1)
      return (object) null;
    if (dataType != (object) null && dataType.IdType == IdType.Numeric && dataType.NamespaceIndex == (ushort) 0)
    {
      uint identifier = (uint) dataType.Identifier;
      if (identifier <= 25U)
        return TypeInfo.GetDefaultValue((BuiltInType) identifier);
      if (identifier <= 256U /*0x0100*/)
      {
        switch ((int) identifier - 26)
        {
          case 0:
            return (object) 0.0;
          case 1:
            return (object) 0L;
          case 2:
            return (object) 0UL;
          case 3:
            return (object) 0;
          default:
            if (identifier == 256U /*0x0100*/)
              return (object) 0;
            break;
        }
      }
      else
      {
        if (identifier == 257U)
          return (object) 0;
        switch ((int) identifier - 288)
        {
          case 0:
            return (object) 0U;
          case 1:
            return (object) 0U;
          case 2:
            return (object) 0.0;
          case 6:
            return (object) DateTime.MinValue;
        }
      }
    }
    BuiltInType builtInType = TypeInfo.GetBuiltInType(dataType, typeTree);
    return builtInType != BuiltInType.Null ? TypeInfo.GetDefaultValue(builtInType) : (object) null;
  }

  public static Array CreateArray(BuiltInType type, params int[] dimensions)
  {
    int length = dimensions != null && dimensions.Length != 0 ? dimensions[0] : throw new ArgumentOutOfRangeException("Array dimensions must be specifed.");
    if (dimensions.Length == 1)
    {
      switch (type)
      {
        case BuiltInType.Null:
          return (Array) new object[length];
        case BuiltInType.Boolean:
          return (Array) new bool[length];
        case BuiltInType.SByte:
          return (Array) new sbyte[length];
        case BuiltInType.Byte:
          return (Array) new byte[length];
        case BuiltInType.Int16:
          return (Array) new short[length];
        case BuiltInType.UInt16:
          return (Array) new ushort[length];
        case BuiltInType.Int32:
          return (Array) new int[length];
        case BuiltInType.UInt32:
          return (Array) new uint[length];
        case BuiltInType.Int64:
          return (Array) new long[length];
        case BuiltInType.UInt64:
          return (Array) new ulong[length];
        case BuiltInType.Float:
          return (Array) new float[length];
        case BuiltInType.Double:
          return (Array) new double[length];
        case BuiltInType.String:
          return (Array) new string[length];
        case BuiltInType.DateTime:
          return (Array) new DateTime[length];
        case BuiltInType.Guid:
          return (Array) new Uuid[length];
        case BuiltInType.ByteString:
          return (Array) new byte[length][];
        case BuiltInType.XmlElement:
          return (Array) new XmlElement[length];
        case BuiltInType.NodeId:
          return (Array) new NodeId[length];
        case BuiltInType.ExpandedNodeId:
          return (Array) new ExpandedNodeId[length];
        case BuiltInType.StatusCode:
          return (Array) new StatusCode[length];
        case BuiltInType.QualifiedName:
          return (Array) new QualifiedName[length];
        case BuiltInType.LocalizedText:
          return (Array) new LocalizedText[length];
        case BuiltInType.ExtensionObject:
          return (Array) new ExtensionObject[length];
        case BuiltInType.DataValue:
          return (Array) new DataValue[length];
        case BuiltInType.Variant:
          return (Array) new Variant[length];
        case BuiltInType.DiagnosticInfo:
          return (Array) new DiagnosticInfo[length];
        case BuiltInType.Number:
          return (Array) new Variant[length];
        case BuiltInType.Integer:
          return (Array) new Variant[length];
        case BuiltInType.UInteger:
          return (Array) new Variant[length];
        case BuiltInType.Enumeration:
          return (Array) new int[length];
      }
    }
    else
    {
      switch (type)
      {
        case BuiltInType.Null:
          return Array.CreateInstance(typeof (object), dimensions);
        case BuiltInType.Boolean:
          return Array.CreateInstance(typeof (bool), dimensions);
        case BuiltInType.SByte:
          return Array.CreateInstance(typeof (sbyte), dimensions);
        case BuiltInType.Byte:
          return Array.CreateInstance(typeof (byte), dimensions);
        case BuiltInType.Int16:
          return Array.CreateInstance(typeof (short), dimensions);
        case BuiltInType.UInt16:
          return Array.CreateInstance(typeof (ushort), dimensions);
        case BuiltInType.Int32:
          return Array.CreateInstance(typeof (int), dimensions);
        case BuiltInType.UInt32:
          return Array.CreateInstance(typeof (uint), dimensions);
        case BuiltInType.Int64:
          return Array.CreateInstance(typeof (long), dimensions);
        case BuiltInType.UInt64:
          return Array.CreateInstance(typeof (ulong), dimensions);
        case BuiltInType.Float:
          return Array.CreateInstance(typeof (float), dimensions);
        case BuiltInType.Double:
          return Array.CreateInstance(typeof (double), dimensions);
        case BuiltInType.String:
          return Array.CreateInstance(typeof (string), dimensions);
        case BuiltInType.DateTime:
          return Array.CreateInstance(typeof (DateTime), dimensions);
        case BuiltInType.Guid:
          return Array.CreateInstance(typeof (Uuid), dimensions);
        case BuiltInType.ByteString:
          return Array.CreateInstance(typeof (byte[]), dimensions);
        case BuiltInType.XmlElement:
          return Array.CreateInstance(typeof (XmlElement), dimensions);
        case BuiltInType.NodeId:
          return Array.CreateInstance(typeof (NodeId), dimensions);
        case BuiltInType.ExpandedNodeId:
          return Array.CreateInstance(typeof (ExpandedNodeId), dimensions);
        case BuiltInType.StatusCode:
          return Array.CreateInstance(typeof (StatusCode), dimensions);
        case BuiltInType.QualifiedName:
          return Array.CreateInstance(typeof (QualifiedName), dimensions);
        case BuiltInType.LocalizedText:
          return Array.CreateInstance(typeof (LocalizedText), dimensions);
        case BuiltInType.ExtensionObject:
          return Array.CreateInstance(typeof (ExtensionObject), dimensions);
        case BuiltInType.DataValue:
          return Array.CreateInstance(typeof (DataValue), dimensions);
        case BuiltInType.Variant:
          return Array.CreateInstance(typeof (Variant), dimensions);
        case BuiltInType.DiagnosticInfo:
          return Array.CreateInstance(typeof (DiagnosticInfo), dimensions);
        case BuiltInType.Number:
          return Array.CreateInstance(typeof (Variant), dimensions);
        case BuiltInType.Integer:
          return Array.CreateInstance(typeof (Variant), dimensions);
        case BuiltInType.UInteger:
          return Array.CreateInstance(typeof (Variant), dimensions);
        case BuiltInType.Enumeration:
          return Array.CreateInstance(typeof (int), dimensions);
      }
    }
    return (Array) null;
  }

  public static object Cast(object source, BuiltInType targetType)
  {
    return TypeInfo.Cast(source, TypeInfo.Construct(source), targetType);
  }

  public static object Cast(object source, TypeInfo sourceType, BuiltInType targetType)
  {
    if (sourceType.BuiltInType == BuiltInType.Null)
      return (object) null;
    if (sourceType.BuiltInType == targetType)
      return source;
    if (targetType == BuiltInType.Variant && sourceType.ValueRank < 0)
      return (object) new Variant(source);
    if (sourceType.BuiltInType == BuiltInType.Guid)
      source = TypeInfo.Cast<Uuid>(source, sourceType, new TypeInfo.CastDelegate<Uuid>(TypeInfo.ToGuid));
    switch (targetType)
    {
      case BuiltInType.Boolean:
        return TypeInfo.Cast<bool>(source, sourceType, new TypeInfo.CastDelegate<bool>(TypeInfo.ToBoolean));
      case BuiltInType.SByte:
        return TypeInfo.Cast<sbyte>(source, sourceType, new TypeInfo.CastDelegate<sbyte>(TypeInfo.ToSByte));
      case BuiltInType.Byte:
        return TypeInfo.Cast<byte>(source, sourceType, new TypeInfo.CastDelegate<byte>(TypeInfo.ToByte));
      case BuiltInType.Int16:
        return TypeInfo.Cast<short>(source, sourceType, new TypeInfo.CastDelegate<short>(TypeInfo.ToInt16));
      case BuiltInType.UInt16:
        return TypeInfo.Cast<ushort>(source, sourceType, new TypeInfo.CastDelegate<ushort>(TypeInfo.ToUInt16));
      case BuiltInType.Int32:
        return TypeInfo.Cast<int>(source, sourceType, new TypeInfo.CastDelegate<int>(TypeInfo.ToInt32));
      case BuiltInType.UInt32:
        return TypeInfo.Cast<uint>(source, sourceType, new TypeInfo.CastDelegate<uint>(TypeInfo.ToUInt32));
      case BuiltInType.Int64:
        return TypeInfo.Cast<long>(source, sourceType, new TypeInfo.CastDelegate<long>(TypeInfo.ToInt64));
      case BuiltInType.UInt64:
        return TypeInfo.Cast<ulong>(source, sourceType, new TypeInfo.CastDelegate<ulong>(TypeInfo.ToUInt64));
      case BuiltInType.Float:
        return TypeInfo.Cast<float>(source, sourceType, new TypeInfo.CastDelegate<float>(TypeInfo.ToFloat));
      case BuiltInType.Double:
        return TypeInfo.Cast<double>(source, sourceType, new TypeInfo.CastDelegate<double>(TypeInfo.ToDouble));
      case BuiltInType.String:
        return TypeInfo.Cast<string>(source, sourceType, new TypeInfo.CastDelegate<string>(TypeInfo.ToString));
      case BuiltInType.DateTime:
        return TypeInfo.Cast<DateTime>(source, sourceType, new TypeInfo.CastDelegate<DateTime>(TypeInfo.ToDateTime));
      case BuiltInType.Guid:
        return TypeInfo.Cast<Uuid>(source, sourceType, new TypeInfo.CastDelegate<Uuid>(TypeInfo.ToGuid));
      case BuiltInType.ByteString:
        return TypeInfo.Cast<byte[]>(source, sourceType, new TypeInfo.CastDelegate<byte[]>(TypeInfo.ToByteString));
      case BuiltInType.XmlElement:
        return TypeInfo.Cast<XmlElement>(source, sourceType, new TypeInfo.CastDelegate<XmlElement>(TypeInfo.ToXmlElement));
      case BuiltInType.NodeId:
        return TypeInfo.Cast<NodeId>(source, sourceType, new TypeInfo.CastDelegate<NodeId>(TypeInfo.ToNodeId));
      case BuiltInType.ExpandedNodeId:
        return TypeInfo.Cast<ExpandedNodeId>(source, sourceType, new TypeInfo.CastDelegate<ExpandedNodeId>(TypeInfo.ToExpandedNodeId));
      case BuiltInType.StatusCode:
        return TypeInfo.Cast<StatusCode>(source, sourceType, new TypeInfo.CastDelegate<StatusCode>(TypeInfo.ToStatusCode));
      case BuiltInType.QualifiedName:
        return TypeInfo.Cast<QualifiedName>(source, sourceType, new TypeInfo.CastDelegate<QualifiedName>(TypeInfo.ToQualifiedName));
      case BuiltInType.LocalizedText:
        return TypeInfo.Cast<LocalizedText>(source, sourceType, new TypeInfo.CastDelegate<LocalizedText>(TypeInfo.ToLocalizedText));
      case BuiltInType.Variant:
        return TypeInfo.Cast<Variant>(source, sourceType, new TypeInfo.CastDelegate<Variant>(TypeInfo.ToVariant));
      case BuiltInType.Number:
        return TypeInfo.Cast<double>(source, sourceType, new TypeInfo.CastDelegate<double>(TypeInfo.ToDouble));
      case BuiltInType.Integer:
        return TypeInfo.Cast<long>(source, sourceType, new TypeInfo.CastDelegate<long>(TypeInfo.ToInt64));
      case BuiltInType.UInteger:
        return TypeInfo.Cast<ulong>(source, sourceType, new TypeInfo.CastDelegate<ulong>(TypeInfo.ToUInt64));
      case BuiltInType.Enumeration:
        return TypeInfo.Cast<int>(source, sourceType, new TypeInfo.CastDelegate<int>(TypeInfo.ToInt32));
      default:
        throw new InvalidCastException();
    }
  }

  public static void CastArray(
    Array dst,
    BuiltInType dstType,
    Array src,
    BuiltInType srcType,
    TypeInfo.CastArrayElementHandler convertor)
  {
    bool flag1 = src.GetType().GetElementType() == typeof (Variant);
    bool flag2 = dst.GetType().GetElementType() == typeof (Variant);
    if (src.Rank == 1)
    {
      for (int index = 0; index < dst.Length; ++index)
      {
        object source = src.GetValue(index);
        if (flag1)
          source = ((Variant) source).Value;
        if (convertor != null)
          source = convertor(source, srcType, dstType);
        if (flag2)
          source = (object) new Variant(source);
        dst.SetValue(source, index);
      }
    }
    else
    {
      int[] numArray1 = new int[src.Rank];
      for (int dimension = 0; dimension < numArray1.Length; ++dimension)
        numArray1[dimension] = src.GetLength(dimension);
      int length1 = dst.Length;
      int[] numArray2 = new int[numArray1.Length];
      for (int index1 = 0; index1 < length1; ++index1)
      {
        int length2 = dst.Length;
        for (int index2 = 0; index2 < numArray2.Length; ++index2)
        {
          length2 /= numArray1[index2];
          numArray2[index2] = index1 / length2 % numArray1[index2];
        }
        object source = src.GetValue(numArray2);
        if (source != null)
        {
          if (flag1)
            source = ((Variant) source).Value;
          if (convertor != null)
            source = convertor(source, srcType, dstType);
          if (flag2)
            source = (object) new Variant(source);
          dst.SetValue(source, numArray2);
        }
      }
    }
  }

  public static Array CastArray(
    Array srcArray,
    BuiltInType srcType,
    BuiltInType dstType,
    TypeInfo.CastArrayElementHandler convertor)
  {
    if (srcArray == null)
      return (Array) null;
    int[] numArray = new int[srcArray.Rank];
    for (int dimension = 0; dimension < numArray.Length; ++dimension)
      numArray[dimension] = srcArray.GetLength(dimension);
    Array array = TypeInfo.CreateArray(dstType, numArray);
    TypeInfo.CastArray(array, dstType, srcArray, srcType, convertor);
    return array;
  }

  private static BuiltInType GetBuiltInType(string typeName)
  {
    if (typeName != null)
    {
      switch (typeName.Length)
      {
        case 4:
          switch (typeName[0])
          {
            case 'B':
              if (typeName == "Byte")
                return BuiltInType.Byte;
              break;
            case 'G':
              if (typeName == "Guid")
                return BuiltInType.Guid;
              break;
            case 'U':
              if (typeName == "Uuid")
                return BuiltInType.Guid;
              break;
          }
          break;
        case 5:
          switch (typeName[3])
          {
            case '1':
              if (typeName == "Int16")
                return BuiltInType.Int16;
              break;
            case '3':
              if (typeName == "Int32")
                return BuiltInType.Int32;
              break;
            case '6':
              if (typeName == "Int64")
                return BuiltInType.Int64;
              break;
            case 'a':
              if (typeName == "Float")
                return BuiltInType.Float;
              break;
            case 't':
              if (typeName == "SByte")
                return BuiltInType.SByte;
              break;
          }
          break;
        case 6:
          switch (typeName[4])
          {
            case '1':
              if (typeName == "UInt16")
                return BuiltInType.UInt16;
              break;
            case '3':
              if (typeName == "UInt32")
                return BuiltInType.UInt32;
              break;
            case '6':
              if (typeName == "UInt64")
                return BuiltInType.UInt64;
              break;
            case 'I':
              if (typeName == "NodeId")
                return BuiltInType.NodeId;
              break;
            case 'c':
              if (typeName == "Object")
                return BuiltInType.Variant;
              break;
            case 'l':
              switch (typeName)
              {
                case "Single":
                  return BuiltInType.Float;
                case "Double":
                  return BuiltInType.Double;
              }
              break;
            case 'n':
              if (typeName == "String")
                return BuiltInType.String;
              break;
          }
          break;
        case 7:
          switch (typeName[0])
          {
            case 'B':
              if (typeName == "Boolean")
                return BuiltInType.Boolean;
              break;
            case 'V':
              if (typeName == "Variant")
                return BuiltInType.Variant;
              break;
          }
          break;
        case 8:
          if (typeName == "DateTime")
            return BuiltInType.DateTime;
          break;
        case 9:
          if (typeName == "DataValue")
            return BuiltInType.DataValue;
          break;
        case 10:
          switch (typeName[0])
          {
            case 'B':
              if (typeName == "ByteString")
                return BuiltInType.ByteString;
              break;
            case 'S':
              if (typeName == "StatusCode")
                return BuiltInType.StatusCode;
              break;
            case 'X':
              if (typeName == "XmlElement")
                return BuiltInType.XmlElement;
              break;
          }
          break;
        case 13:
          switch (typeName[0])
          {
            case 'L':
              if (typeName == "LocalizedText")
                return BuiltInType.LocalizedText;
              break;
            case 'Q':
              if (typeName == "QualifiedName")
                return BuiltInType.QualifiedName;
              break;
          }
          break;
        case 14:
          switch (typeName[0])
          {
            case 'D':
              if (typeName == "DiagnosticInfo")
                return BuiltInType.DiagnosticInfo;
              break;
            case 'E':
              if (typeName == "ExpandedNodeId")
                return BuiltInType.ExpandedNodeId;
              break;
          }
          break;
        case 15:
          if (typeName == "ExtensionObject")
            return BuiltInType.ExtensionObject;
          break;
      }
    }
    return BuiltInType.Null;
  }

  private static bool ToBoolean(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return (bool) value;
      case BuiltInType.SByte:
        return Convert.ToBoolean((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToBoolean((byte) value);
      case BuiltInType.Int16:
        return Convert.ToBoolean((short) value);
      case BuiltInType.UInt16:
        return Convert.ToBoolean((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToBoolean((int) value);
      case BuiltInType.UInt32:
        return Convert.ToBoolean((uint) value);
      case BuiltInType.Int64:
        return Convert.ToBoolean((long) value);
      case BuiltInType.UInt64:
        return Convert.ToBoolean((ulong) value);
      case BuiltInType.Float:
        return Convert.ToBoolean((float) value);
      case BuiltInType.Double:
        return Convert.ToBoolean((double) value);
      case BuiltInType.String:
        return XmlConvert.ToBoolean((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static sbyte ToSByte(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToSByte((bool) value);
      case BuiltInType.SByte:
        return (sbyte) value;
      case BuiltInType.Byte:
        return Convert.ToSByte((byte) value);
      case BuiltInType.Int16:
        return Convert.ToSByte((short) value);
      case BuiltInType.UInt16:
        return Convert.ToSByte((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToSByte((int) value);
      case BuiltInType.UInt32:
        return Convert.ToSByte((uint) value);
      case BuiltInType.Int64:
        return Convert.ToSByte((long) value);
      case BuiltInType.UInt64:
        return Convert.ToSByte((ulong) value);
      case BuiltInType.Float:
        return Convert.ToSByte((float) value);
      case BuiltInType.Double:
        return Convert.ToSByte((double) value);
      case BuiltInType.String:
        return XmlConvert.ToSByte((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static byte ToByte(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToByte((bool) value);
      case BuiltInType.SByte:
        return Convert.ToByte((sbyte) value);
      case BuiltInType.Byte:
        return (byte) value;
      case BuiltInType.Int16:
        return Convert.ToByte((short) value);
      case BuiltInType.UInt16:
        return Convert.ToByte((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToByte((int) value);
      case BuiltInType.UInt32:
        return Convert.ToByte((uint) value);
      case BuiltInType.Int64:
        return Convert.ToByte((long) value);
      case BuiltInType.UInt64:
        return Convert.ToByte((ulong) value);
      case BuiltInType.Float:
        return Convert.ToByte((float) value);
      case BuiltInType.Double:
        return Convert.ToByte((double) value);
      case BuiltInType.String:
        return XmlConvert.ToByte((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static short ToInt16(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToInt16((bool) value);
      case BuiltInType.SByte:
        return Convert.ToInt16((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToInt16((byte) value);
      case BuiltInType.Int16:
        return (short) value;
      case BuiltInType.UInt16:
        return Convert.ToInt16((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToInt16((int) value);
      case BuiltInType.UInt32:
        return Convert.ToInt16((uint) value);
      case BuiltInType.Int64:
        return Convert.ToInt16((long) value);
      case BuiltInType.UInt64:
        return Convert.ToInt16((ulong) value);
      case BuiltInType.Float:
        return Convert.ToInt16((float) value);
      case BuiltInType.Double:
        return Convert.ToInt16((double) value);
      case BuiltInType.String:
        return XmlConvert.ToInt16((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static ushort ToUInt16(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToUInt16((bool) value);
      case BuiltInType.SByte:
        return Convert.ToUInt16((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToUInt16((byte) value);
      case BuiltInType.Int16:
        return Convert.ToUInt16((short) value);
      case BuiltInType.UInt16:
        return (ushort) value;
      case BuiltInType.Int32:
        return Convert.ToUInt16((int) value);
      case BuiltInType.UInt32:
        return Convert.ToUInt16((uint) value);
      case BuiltInType.Int64:
        return Convert.ToUInt16((long) value);
      case BuiltInType.UInt64:
        return Convert.ToUInt16((ulong) value);
      case BuiltInType.Float:
        return Convert.ToUInt16((float) value);
      case BuiltInType.Double:
        return Convert.ToUInt16((double) value);
      case BuiltInType.String:
        return XmlConvert.ToUInt16((string) value);
      case BuiltInType.StatusCode:
        return (ushort) (((StatusCode) value).CodeBits >> 16 /*0x10*/);
      default:
        throw new InvalidCastException();
    }
  }

  private static int ToInt32(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToInt32((bool) value);
      case BuiltInType.SByte:
        return Convert.ToInt32((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToInt32((byte) value);
      case BuiltInType.Int16:
        return Convert.ToInt32((short) value);
      case BuiltInType.UInt16:
        return Convert.ToInt32((ushort) value);
      case BuiltInType.Int32:
        return (int) value;
      case BuiltInType.UInt32:
        return Convert.ToInt32((uint) value);
      case BuiltInType.Int64:
        return Convert.ToInt32((long) value);
      case BuiltInType.UInt64:
        return Convert.ToInt32((ulong) value);
      case BuiltInType.Float:
        return Convert.ToInt32((float) value);
      case BuiltInType.Double:
        return Convert.ToInt32((double) value);
      case BuiltInType.String:
        return XmlConvert.ToInt32((string) value);
      case BuiltInType.StatusCode:
        return Convert.ToInt32(((StatusCode) value).Code);
      default:
        throw new InvalidCastException();
    }
  }

  private static uint ToUInt32(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToUInt32((bool) value);
      case BuiltInType.SByte:
        return Convert.ToUInt32((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToUInt32((byte) value);
      case BuiltInType.Int16:
        return Convert.ToUInt32((short) value);
      case BuiltInType.UInt16:
        return Convert.ToUInt32((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToUInt32((int) value);
      case BuiltInType.UInt32:
        return (uint) value;
      case BuiltInType.Int64:
        return Convert.ToUInt32((long) value);
      case BuiltInType.UInt64:
        return Convert.ToUInt32((ulong) value);
      case BuiltInType.Float:
        return Convert.ToUInt32((float) value);
      case BuiltInType.Double:
        return Convert.ToUInt32((double) value);
      case BuiltInType.String:
        return XmlConvert.ToUInt32((string) value);
      case BuiltInType.StatusCode:
        return Convert.ToUInt32(((StatusCode) value).Code);
      default:
        throw new InvalidCastException();
    }
  }

  private static long ToInt64(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToInt64((bool) value);
      case BuiltInType.SByte:
        return Convert.ToInt64((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToInt64((byte) value);
      case BuiltInType.Int16:
        return Convert.ToInt64((short) value);
      case BuiltInType.UInt16:
        return Convert.ToInt64((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToInt64((int) value);
      case BuiltInType.UInt32:
        return Convert.ToInt64((uint) value);
      case BuiltInType.Int64:
        return (long) value;
      case BuiltInType.UInt64:
        return Convert.ToInt64((ulong) value);
      case BuiltInType.Float:
        return Convert.ToInt64((float) value);
      case BuiltInType.Double:
        return Convert.ToInt64((double) value);
      case BuiltInType.String:
        return XmlConvert.ToInt64((string) value);
      case BuiltInType.StatusCode:
        return Convert.ToInt64(((StatusCode) value).Code);
      default:
        throw new InvalidCastException();
    }
  }

  private static ulong ToUInt64(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToUInt64((bool) value);
      case BuiltInType.SByte:
        return Convert.ToUInt64((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToUInt64((byte) value);
      case BuiltInType.Int16:
        return Convert.ToUInt64((short) value);
      case BuiltInType.UInt16:
        return Convert.ToUInt64((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToUInt64((int) value);
      case BuiltInType.UInt32:
        return Convert.ToUInt64((uint) value);
      case BuiltInType.Int64:
        return Convert.ToUInt64((long) value);
      case BuiltInType.UInt64:
        return (ulong) value;
      case BuiltInType.Float:
        return Convert.ToUInt64((float) value);
      case BuiltInType.Double:
        return Convert.ToUInt64((double) value);
      case BuiltInType.String:
        return XmlConvert.ToUInt64((string) value);
      case BuiltInType.StatusCode:
        return Convert.ToUInt64(((StatusCode) value).Code);
      default:
        throw new InvalidCastException();
    }
  }

  private static float ToFloat(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToSingle((bool) value);
      case BuiltInType.SByte:
        return Convert.ToSingle((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToSingle((byte) value);
      case BuiltInType.Int16:
        return Convert.ToSingle((short) value);
      case BuiltInType.UInt16:
        return Convert.ToSingle((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToSingle((int) value);
      case BuiltInType.UInt32:
        return Convert.ToSingle((uint) value);
      case BuiltInType.Int64:
        return Convert.ToSingle((long) value);
      case BuiltInType.UInt64:
        return Convert.ToSingle((ulong) value);
      case BuiltInType.Float:
        return (float) value;
      case BuiltInType.Double:
        return Convert.ToSingle((double) value);
      case BuiltInType.String:
        return XmlConvert.ToSingle((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static double ToDouble(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Boolean:
        return Convert.ToDouble((bool) value);
      case BuiltInType.SByte:
        return Convert.ToDouble((sbyte) value);
      case BuiltInType.Byte:
        return Convert.ToDouble((byte) value);
      case BuiltInType.Int16:
        return Convert.ToDouble((short) value);
      case BuiltInType.UInt16:
        return Convert.ToDouble((ushort) value);
      case BuiltInType.Int32:
        return Convert.ToDouble((int) value);
      case BuiltInType.UInt32:
        return Convert.ToDouble((uint) value);
      case BuiltInType.Int64:
        return Convert.ToDouble((long) value);
      case BuiltInType.UInt64:
        return Convert.ToDouble((ulong) value);
      case BuiltInType.Float:
        return Convert.ToDouble((float) value);
      case BuiltInType.Double:
        return (double) value;
      case BuiltInType.String:
        return XmlConvert.ToDouble((string) value);
      default:
        throw new InvalidCastException();
    }
  }

  private static string ToString(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.Null:
        return (string) null;
      case BuiltInType.Boolean:
        return XmlConvert.ToString((bool) value);
      case BuiltInType.SByte:
        return XmlConvert.ToString((sbyte) value);
      case BuiltInType.Byte:
        return XmlConvert.ToString((byte) value);
      case BuiltInType.Int16:
        return XmlConvert.ToString((short) value);
      case BuiltInType.UInt16:
        return XmlConvert.ToString((ushort) value);
      case BuiltInType.Int32:
        return XmlConvert.ToString((int) value);
      case BuiltInType.UInt32:
        return XmlConvert.ToString((uint) value);
      case BuiltInType.Int64:
        return XmlConvert.ToString((long) value);
      case BuiltInType.UInt64:
        return XmlConvert.ToString((ulong) value);
      case BuiltInType.Float:
        return XmlConvert.ToString((float) value);
      case BuiltInType.Double:
        return XmlConvert.ToString((double) value);
      case BuiltInType.String:
        return (string) value;
      case BuiltInType.DateTime:
        return XmlConvert.ToString((DateTime) value, XmlDateTimeSerializationMode.Unspecified);
      case BuiltInType.Guid:
        return ((Uuid) value).ToString();
      case BuiltInType.XmlElement:
        return ((XmlNode) value).OuterXml;
      case BuiltInType.NodeId:
        return ((NodeId) value).ToString();
      case BuiltInType.ExpandedNodeId:
        return ((ExpandedNodeId) value).ToString();
      case BuiltInType.StatusCode:
        return ((StatusCode) value).Code.ToString();
      case BuiltInType.QualifiedName:
        return ((QualifiedName) value).ToString();
      case BuiltInType.LocalizedText:
        return ((LocalizedText) value).Text;
      case BuiltInType.ExtensionObject:
        return ((ExtensionObject) value).ToString();
      default:
        throw new InvalidCastException();
    }
  }

  private static DateTime ToDateTime(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return XmlConvert.ToDateTime((string) value, XmlDateTimeSerializationMode.Unspecified);
      case BuiltInType.DateTime:
        return (DateTime) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static Uuid ToGuid(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return new Uuid((string) value);
      case BuiltInType.Guid:
        Guid? nullable = value as Guid?;
        return nullable.HasValue ? new Uuid(nullable.Value) : (Uuid) value;
      case BuiltInType.ByteString:
        return new Uuid(new Guid((byte[]) value));
      default:
        throw new InvalidCastException();
    }
  }

  private static byte[] ToByteString(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        string s = (string) value;
        switch (s)
        {
          case null:
            return (byte[]) null;
          case "":
            return Array.Empty<byte>();
          default:
            using (MemoryStream memoryStream = new MemoryStream())
            {
              byte num1 = 0;
              bool flag = false;
              for (int index = 0; index < s.Length; ++index)
              {
                if (!char.IsWhiteSpace(s, index) && !char.IsLetterOrDigit(s, index))
                  throw new FormatException("Invalid character in ByteString. " + s[index].ToString());
                if (!char.IsWhiteSpace(s, index))
                {
                  int num2 = "0123456789ABCDEF".IndexOf(char.ToUpper(s[index]));
                  if (num2 < 0)
                    throw new FormatException("Invalid character in ByteString." + s[index].ToString());
                  num1 = (byte) ((uint) (byte) ((uint) num1 << 4) + (uint) (byte) num2);
                  if (flag)
                  {
                    memoryStream.WriteByte(num1);
                    flag = false;
                  }
                  else
                    flag = true;
                }
              }
              if (flag)
              {
                byte num3 = (byte) ((uint) num1 << 4);
                memoryStream.WriteByte(num3);
              }
              return memoryStream.ToArray();
            }
        }
      case BuiltInType.Guid:
        return ((Guid) (Uuid) value).ToByteArray();
      case BuiltInType.ByteString:
        return (byte[]) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static XmlElement ToXmlElement(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        XmlDocument doc = new XmlDocument();
        doc.LoadInnerXml((string) value);
        return doc.DocumentElement;
      case BuiltInType.XmlElement:
        return (XmlElement) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static NodeId ToNodeId(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return NodeId.Parse((string) value);
      case BuiltInType.NodeId:
        return (NodeId) value;
      case BuiltInType.ExpandedNodeId:
        return (NodeId) (ExpandedNodeId) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static ExpandedNodeId ToExpandedNodeId(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return ExpandedNodeId.Parse((string) value);
      case BuiltInType.NodeId:
        return (ExpandedNodeId) (NodeId) value;
      case BuiltInType.ExpandedNodeId:
        return (ExpandedNodeId) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static StatusCode ToStatusCode(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.UInt16:
        return (StatusCode) (Convert.ToUInt32((ushort) value) << 16 /*0x10*/);
      case BuiltInType.Int32:
        return (StatusCode) Convert.ToUInt32((int) value);
      case BuiltInType.UInt32:
        return (StatusCode) (uint) value;
      case BuiltInType.Int64:
        return (StatusCode) Convert.ToUInt32((long) value);
      case BuiltInType.UInt64:
        return (StatusCode) Convert.ToUInt32((ulong) value);
      case BuiltInType.String:
        string str1 = (string) value;
        if (str1 == null)
          return (StatusCode) 0U;
        string str2 = str1.Trim();
        return str2.StartsWith("0x") ? (StatusCode) Convert.ToUInt32(str2.Substring(2), 16 /*0x10*/) : (StatusCode) Convert.ToUInt32((string) value);
      case BuiltInType.StatusCode:
        return (StatusCode) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static QualifiedName ToQualifiedName(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return QualifiedName.Parse((string) value);
      case BuiltInType.QualifiedName:
        return (QualifiedName) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static LocalizedText ToLocalizedText(object value, TypeInfo sourceType)
  {
    switch (sourceType.BuiltInType)
    {
      case BuiltInType.String:
        return new LocalizedText((string) value);
      case BuiltInType.LocalizedText:
        return (LocalizedText) value;
      default:
        throw new InvalidCastException();
    }
  }

  private static Variant ToVariant(object value, TypeInfo sourceType) => new Variant(value);

  private static object Cast<T>(
    object input,
    TypeInfo sourceType,
    TypeInfo.CastDelegate<T> handler)
  {
    if (sourceType == null)
      sourceType = TypeInfo.Construct(input);
    if (sourceType.ValueRank >= 0)
      return (object) TypeInfo.Cast<T>((Array) input, sourceType, handler);
    if (sourceType.BuiltInType != BuiltInType.Variant)
      return (object) handler(input, sourceType);
    object obj = ((Variant) input).Value;
    sourceType = TypeInfo.Construct(obj);
    return (object) handler(obj, sourceType);
  }

  private static Array Cast<T>(Array input, TypeInfo sourceType, TypeInfo.CastDelegate<T> handler)
  {
    if (input == null)
      return (Array) null;
    TypeInfo sourceType1 = new TypeInfo(sourceType.BuiltInType, -1);
    if (input.Rank == 1)
    {
      T[] objArray = new T[input.Length];
      for (int index = 0; index < input.Length; ++index)
      {
        object obj = input.GetValue(index);
        if (obj != null)
        {
          if (sourceType.BuiltInType == BuiltInType.Variant)
          {
            obj = ((Variant) obj).Value;
            sourceType1 = TypeInfo.Construct(obj);
          }
          objArray[index] = handler(obj, sourceType1);
        }
      }
      return (Array) objArray;
    }
    if (input.Rank == 2)
    {
      int length1 = input.GetLength(0);
      int length2 = input.GetLength(1);
      T[,] objArray = new T[length1, length2];
      for (int index1 = 0; index1 < length1; ++index1)
      {
        for (int index2 = 0; index2 < length2; ++index2)
        {
          object obj = input.GetValue(index1, index2);
          if (obj != null)
          {
            if (sourceType.BuiltInType == BuiltInType.Variant)
            {
              obj = ((Variant) obj).Value;
              sourceType1 = TypeInfo.Construct(obj);
            }
            objArray[index1, index2] = handler(obj, sourceType1);
          }
        }
      }
      return (Array) objArray;
    }
    int[] numArray1 = new int[input.Rank];
    for (int dimension = 0; dimension < numArray1.Length; ++dimension)
      numArray1[dimension] = input.GetLength(dimension);
    Array instance = Array.CreateInstance(typeof (T), numArray1);
    int length3 = instance.Length;
    int[] numArray2 = new int[numArray1.Length];
    for (int index1 = 0; index1 < length3; ++index1)
    {
      int length4 = instance.Length;
      for (int index2 = 0; index2 < numArray2.Length; ++index2)
      {
        length4 /= numArray1[index2];
        numArray2[index2] = index1 / length4 % numArray1[index2];
      }
      object obj = input.GetValue(numArray2);
      if (obj != null)
      {
        if (sourceType.BuiltInType == BuiltInType.Variant)
        {
          obj = ((Variant) obj).Value;
          sourceType1 = TypeInfo.Construct(obj);
        }
        instance.SetValue((object) handler(obj, sourceType1), numArray2);
      }
    }
    return instance;
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append((object) this.m_builtInType);
      if (this.m_valueRank >= 0)
      {
        stringBuilder.Append('[');
        for (int index = 1; index < this.m_valueRank; ++index)
          stringBuilder.Append(',');
        stringBuilder.Append(']');
      }
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is TypeInfo typeInfo && this.m_builtInType == typeInfo.BuiltInType && this.m_valueRank == typeInfo.ValueRank;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine<BuiltInType, int>(this.m_builtInType, this.m_valueRank);
  }

  public delegate object CastArrayElementHandler(
    object source,
    BuiltInType srcType,
    BuiltInType dstType);

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
}
