// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilter : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
  private ContentFilterElementCollection m_elements;

  public ContentFilter() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_elements = new ContentFilterElementCollection();

  [DataMember(Name = "Elements", IsRequired = false, Order = 1)]
  public ContentFilterElementCollection Elements
  {
    get => this.m_elements;
    set
    {
      this.m_elements = value;
      if (value != null)
        return;
      this.m_elements = new ContentFilterElementCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ContentFilter;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilter_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilter_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilter_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Elements", (IList<IEncodeable>) this.Elements.ToArray(), typeof (ContentFilterElement));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Elements = (ContentFilterElementCollection) (ContentFilterElement[]) decoder.ReadEncodeableArray("Elements", typeof (ContentFilterElement));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ContentFilter contentFilter && Utils.IsEqual((object) this.m_elements, (object) contentFilter.m_elements);
  }

  public virtual object Clone() => (object) (ContentFilter) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilter contentFilter = (ContentFilter) base.MemberwiseClone();
    contentFilter.m_elements = (ContentFilterElementCollection) Utils.Clone((object) this.m_elements);
    return (object) contentFilter;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.Elements.Count; ++index)
        stringBuilder.AppendFormat(formatProvider, "[{0}:{1}]", (object) index, (object) this.Elements[index]);
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public ContentFilter.Result Validate(FilterContext context)
  {
    ContentFilter.Result result = new ContentFilter.Result((ServiceResult) null);
    if (this.m_elements == null || this.m_elements.Count == 0)
      return result;
    bool flag = false;
    for (int index = 0; index < this.m_elements.Count; ++index)
    {
      ContentFilterElement element = this.m_elements[index];
      if (element == null)
      {
        ServiceResult status = ServiceResult.Create(2152071168U /*0x80460000*/, "ContentFilterElement is null (Index={0}).", (object) index);
        result.ElementResults.Add(new ContentFilter.ElementResult(status));
        flag = true;
      }
      else
      {
        element.Parent = this;
        ContentFilter.ElementResult elementResult = element.Validate(context, index);
        if (ServiceResult.IsBad(elementResult.Status))
        {
          result.ElementResults.Add(elementResult);
          flag = true;
        }
        else
          result.ElementResults.Add((ContentFilter.ElementResult) null);
      }
    }
    if (flag)
      result.Status = (ServiceResult) 2152202240U /*0x80480000*/;
    else
      result.ElementResults.Clear();
    return result;
  }

  public ContentFilterElement Push(FilterOperator op, params object[] operands)
  {
    if (operands == null || operands.Length == 0)
      throw ServiceResultException.Create(2158690304U /*0x80AB0000*/, "ContentFilterElement does not have an operands.");
    ContentFilterElement contentFilterElement = new ContentFilterElement();
    contentFilterElement.FilterOperator = op;
    for (int index = 0; index < operands.Length; ++index)
    {
      if (operands[index] is FilterOperand operand2)
        contentFilterElement.FilterOperands.Add(new ExtensionObject((object) operand2));
      else if (operands[index] is ContentFilterElement operand1)
      {
        int elementIndex = this.FindElementIndex(operand1);
        if (elementIndex == -1)
          throw ServiceResultException.Create(2158690304U /*0x80AB0000*/, "ContentFilterElement is not part of the ContentFilter.");
        contentFilterElement.FilterOperands.Add(new ExtensionObject((object) new ElementOperand()
        {
          Index = (uint) elementIndex
        }));
      }
      else
        contentFilterElement.FilterOperands.Add(new ExtensionObject((object) new LiteralOperand()
        {
          Value = new Variant(operands[index])
        }));
    }
    this.m_elements.Insert(0, contentFilterElement);
    for (int index = 0; index < this.m_elements.Count; ++index)
    {
      foreach (ExtensionObject filterOperand in (List<ExtensionObject>) this.m_elements[index].FilterOperands)
      {
        if (filterOperand != null && filterOperand.Body is ElementOperand body)
          ++body.Index;
      }
    }
    return contentFilterElement;
  }

  private int FindElementIndex(ContentFilterElement target)
  {
    for (int index = 0; index < this.m_elements.Count; ++index)
    {
      if (target == this.m_elements[index])
        return index;
    }
    return -1;
  }

  public bool Evaluate(FilterContext context, IFilterTarget target)
  {
    if (this.Elements.Count == 0)
      return true;
    bool? nullable = this.Evaluate(context, target, 0) as bool?;
    return nullable.HasValue && nullable.Value;
  }

  private object Evaluate(FilterContext context, IFilterTarget target, int index)
  {
    ContentFilterElement element = this.Elements[index];
    switch (element.FilterOperator)
    {
      case FilterOperator.Equals:
        return (object) this.Equals(context, target, element);
      case FilterOperator.IsNull:
        return (object) this.IsNull(context, target, element);
      case FilterOperator.GreaterThan:
        return (object) this.GreaterThan(context, target, element);
      case FilterOperator.LessThan:
        return (object) this.LessThan(context, target, element);
      case FilterOperator.GreaterThanOrEqual:
        return (object) this.GreaterThanOrEqual(context, target, element);
      case FilterOperator.LessThanOrEqual:
        return (object) this.LessThanOrEqual(context, target, element);
      case FilterOperator.Like:
        return (object) this.Like(context, target, element);
      case FilterOperator.Not:
        return (object) this.Not(context, target, element);
      case FilterOperator.Between:
        return (object) this.Between(context, target, element);
      case FilterOperator.InList:
        return (object) this.InList(context, target, element);
      case FilterOperator.And:
        return (object) this.And(context, target, element);
      case FilterOperator.Or:
        return (object) this.Or(context, target, element);
      case FilterOperator.Cast:
        return this.Cast(context, target, element);
      case FilterOperator.InView:
        return (object) this.InView(context, target, element);
      case FilterOperator.OfType:
        return (object) this.OfType(context, target, element);
      case FilterOperator.RelatedTo:
        return (object) this.RelatedTo(context, target, element);
      case FilterOperator.BitwiseAnd:
        return this.BitwiseAnd(context, target, element);
      case FilterOperator.BitwiseOr:
        return this.BitwiseOr(context, target, element);
      default:
        throw new ServiceResultException(2147549184U /*0x80010000*/, "FilterOperator is not recognized.");
    }
  }

  private FilterOperand[] GetOperands(ContentFilterElement element, int expectedCount)
  {
    FilterOperand[] operands = new FilterOperand[element.FilterOperands.Count];
    int num = 0;
    foreach (ExtensionObject filterOperand in (List<ExtensionObject>) element.FilterOperands)
    {
      if (ExtensionObject.IsNull(filterOperand))
        throw new ServiceResultException(2147549184U /*0x80010000*/, "FilterOperand is null.");
      if (!(filterOperand.Body is FilterOperand body))
        throw new ServiceResultException(2147549184U /*0x80010000*/, "FilterOperand is not supported.");
      operands[num++] = body;
    }
    if (expectedCount > 0 && expectedCount != operands.Length)
      throw new ServiceResultException(2147549184U /*0x80010000*/, "ContentFilterElement does not have the correct number of operands.");
    return operands;
  }

  private Tuple<object, object> GetBitwiseOperands(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    if (obj1 == null || obj2 == null)
      return Tuple.Create<object, object>((object) null, (object) null);
    if (!ContentFilter.isIntegerType(ContentFilter.GetBuiltInType(obj1)) || !ContentFilter.isIntegerType(ContentFilter.GetBuiltInType(obj2)))
      return Tuple.Create<object, object>((object) null, (object) null);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return Tuple.Create<object, object>(obj1, obj2);
  }

  private object GetValue(FilterContext context, FilterOperand operand, IFilterTarget target)
  {
    switch (operand)
    {
      case LiteralOperand literalOperand:
        return literalOperand.Value.Value;
      case SimpleAttributeOperand attributeOperand1:
        return target.GetAttributeValue(context, attributeOperand1.TypeDefinitionId, (IList<QualifiedName>) attributeOperand1.BrowsePath, attributeOperand1.AttributeId, attributeOperand1.ParsedIndexRange);
      case AttributeOperand attributeOperand2:
        return !(target is IAdvancedFilterTarget advancedFilterTarget) ? (object) false : advancedFilterTarget.GetRelatedAttributeValue(context, attributeOperand2.NodeId, attributeOperand2.BrowsePath, attributeOperand2.AttributeId, attributeOperand2.ParsedIndexRange);
      case ElementOperand elementOperand:
        return this.Evaluate(context, target, (int) elementOperand.Index);
      default:
        throw new ServiceResultException(2147549184U /*0x80010000*/, "FilterOperand is not supported.");
    }
  }

  private static BuiltInType GetBuiltInType(object value)
  {
    if (value == null)
      return BuiltInType.Null;
    Type type = value.GetType();
    if (value is Array)
      type = type.GetElementType();
    if (type == typeof (bool))
      return BuiltInType.Boolean;
    if (type == typeof (sbyte))
      return BuiltInType.SByte;
    if (type == typeof (byte))
      return BuiltInType.Byte;
    if (type == typeof (short))
      return BuiltInType.Int16;
    if (type == typeof (ushort))
      return BuiltInType.UInt16;
    if (type == typeof (int))
      return BuiltInType.Int32;
    if (type == typeof (uint))
      return BuiltInType.UInt32;
    if (type == typeof (long))
      return BuiltInType.Int64;
    if (type == typeof (ulong))
      return BuiltInType.UInt64;
    if (type == typeof (float))
      return BuiltInType.Float;
    if (type == typeof (double))
      return BuiltInType.Double;
    if (type == typeof (string))
      return BuiltInType.String;
    if (type == typeof (DateTime))
      return BuiltInType.DateTime;
    if (type == typeof (Guid) || type == typeof (Uuid))
      return BuiltInType.Guid;
    if (type == typeof (byte[]))
      return BuiltInType.ByteString;
    if (type == typeof (XmlElement))
      return BuiltInType.XmlElement;
    if (type == typeof (NodeId))
      return BuiltInType.NodeId;
    if (type == typeof (ExpandedNodeId))
      return BuiltInType.ExpandedNodeId;
    if (type == typeof (StatusCode))
      return BuiltInType.StatusCode;
    if (type == typeof (DiagnosticInfo))
      return BuiltInType.DiagnosticInfo;
    if (type == typeof (QualifiedName))
      return BuiltInType.QualifiedName;
    if (type == typeof (LocalizedText))
      return BuiltInType.LocalizedText;
    if (type == typeof (ExtensionObject))
      return BuiltInType.ExtensionObject;
    if (type == typeof (DataValue))
      return BuiltInType.DataValue;
    if (type == typeof (Variant) || type == typeof (object))
      return BuiltInType.Variant;
    return type.GetTypeInfo().IsEnum ? BuiltInType.Enumeration : BuiltInType.Null;
  }

  private static BuiltInType GetBuiltInType(NodeId datatypeId)
  {
    return !(datatypeId == (object) null) && datatypeId.NamespaceIndex == (ushort) 0 && datatypeId.IdType == IdType.Numeric ? (BuiltInType) Enum.ToObject(typeof (BuiltInType), datatypeId.Identifier) : BuiltInType.Null;
  }

  private static int GetDataTypePrecedence(BuiltInType type)
  {
    switch (type)
    {
      case BuiltInType.Boolean:
        return 7;
      case BuiltInType.SByte:
        return 9;
      case BuiltInType.Byte:
        return 8;
      case BuiltInType.Int16:
        return 11;
      case BuiltInType.UInt16:
        return 10;
      case BuiltInType.Int32:
        return 14;
      case BuiltInType.UInt32:
        return 13;
      case BuiltInType.Int64:
        return 16 /*0x10*/;
      case BuiltInType.UInt64:
        return 15;
      case BuiltInType.Float:
        return 17;
      case BuiltInType.Double:
        return 18;
      case BuiltInType.String:
        return 5;
      case BuiltInType.Guid:
        return 6;
      case BuiltInType.NodeId:
        return 3;
      case BuiltInType.ExpandedNodeId:
        return 4;
      case BuiltInType.StatusCode:
        return 12;
      case BuiltInType.QualifiedName:
        return 1;
      case BuiltInType.LocalizedText:
        return 2;
      default:
        return 0;
    }
  }

  private static void DoImplicitConversion(ref object value1, ref object value2)
  {
    BuiltInType builtInType1 = ContentFilter.GetBuiltInType(value1);
    BuiltInType builtInType2 = ContentFilter.GetBuiltInType(value2);
    int dataTypePrecedence1 = ContentFilter.GetDataTypePrecedence(builtInType1);
    int dataTypePrecedence2 = ContentFilter.GetDataTypePrecedence(builtInType2);
    if (dataTypePrecedence1 == dataTypePrecedence2)
      return;
    if (dataTypePrecedence1 > dataTypePrecedence2)
      value2 = ContentFilter.Cast(value2, builtInType2, builtInType1);
    else
      value1 = ContentFilter.Cast(value1, builtInType1, builtInType2);
  }

  private static bool IsEqual(object value1, object value2)
  {
    return value1 != null && value2 != null ? (!(value1 is DBNull) && !(value2 is DBNull) ? !(value1.GetType() != value2.GetType()) && Utils.IsEqual(value1, value2) : value1 is DBNull && value2 is DBNull) : value1 == null && value2 == null;
  }

  private static bool Match(string target, string pattern)
  {
    string pattern1 = Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(pattern, "([\\^\\$\\.\\|\\?\\*\\+\\(\\)])", "\\$1", RegexOptions.Compiled), "(?<!\\\\)%", ".*", RegexOptions.Compiled), "(?<!\\\\)_", ".", RegexOptions.Compiled), "(?<!\\\\)(\\[!)", "[^", RegexOptions.Compiled);
    return Regex.IsMatch(target, pattern1);
  }

  private static bool isIntegerType(BuiltInType aType)
  {
    return aType == BuiltInType.Byte || aType == BuiltInType.SByte || aType == BuiltInType.Int16 || aType == BuiltInType.UInt16 || aType == BuiltInType.Int32 || aType == BuiltInType.UInt32 || aType == BuiltInType.Int64 || aType == BuiltInType.UInt64;
  }

  private static object ToBoolean(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      bool[] boolean = new bool[array.Length];
      for (int index = 0; index < array.Length; ++index)
        boolean[index] = (bool) ContentFilter.Cast(array.GetValue(index), BuiltInType.Boolean);
      return (object) boolean;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) (bool) value;
      case BuiltInType.SByte:
        return (object) Convert.ToBoolean((byte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToBoolean((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToBoolean((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToBoolean((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToBoolean((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToBoolean((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToBoolean((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToBoolean((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToBoolean((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToBoolean((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToBoolean((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToSByte(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      sbyte[] numArray = new sbyte[array.Length];
      for (int index = 0; index < array.Length; ++index)
        numArray[index] = (sbyte) ContentFilter.Cast(array.GetValue(index), BuiltInType.SByte);
      return (object) numArray;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToSByte((bool) value);
      case BuiltInType.SByte:
        return (object) (sbyte) value;
      case BuiltInType.Byte:
        return (object) Convert.ToSByte((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToSByte((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToSByte((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToSByte((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToSByte((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToSByte((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToSByte((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToSByte((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToSByte((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToSByte((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToByte(object value, BuiltInType sourceType)
  {
    if (value is Array)
      throw new NotImplementedException("Arrays of Byte not supported. Use ByteString instead.");
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToByte((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToByte((sbyte) value);
      case BuiltInType.Byte:
        return (object) (byte) value;
      case BuiltInType.Int16:
        return (object) Convert.ToByte((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToByte((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToByte((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToByte((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToByte((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToByte((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToByte((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToByte((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToByte((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToInt16(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      short[] int16 = new short[array.Length];
      for (int index = 0; index < array.Length; ++index)
        int16[index] = (short) ContentFilter.Cast(array.GetValue(index), BuiltInType.Int16);
      return (object) int16;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToInt16((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToInt16((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToInt16((byte) value);
      case BuiltInType.Int16:
        return (object) (short) value;
      case BuiltInType.UInt16:
        return (object) Convert.ToInt16((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToInt16((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToInt16((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToInt16((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToInt16((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToInt16((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToInt16((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToInt16((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToUInt16(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      ushort[] uint16 = new ushort[array.Length];
      for (int index = 0; index < array.Length; ++index)
        uint16[index] = (ushort) ContentFilter.Cast(array.GetValue(index), BuiltInType.UInt16);
      return (object) uint16;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToUInt16((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToUInt16((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToUInt16((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToUInt16((short) value);
      case BuiltInType.UInt16:
        return (object) (ushort) value;
      case BuiltInType.Int32:
        return (object) Convert.ToUInt16((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToUInt16((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToUInt16((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToUInt16((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToUInt16((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToUInt16((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToUInt16((string) value);
      case BuiltInType.StatusCode:
        return (object) (ushort) (((StatusCode) value).CodeBits >> 16 /*0x10*/);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToInt32(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      int[] int32 = new int[array.Length];
      for (int index = 0; index < array.Length; ++index)
        int32[index] = (int) ContentFilter.Cast(array.GetValue(index), BuiltInType.Int32);
      return (object) int32;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToInt32((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToInt32((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToInt32((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToInt32((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToInt32((ushort) value);
      case BuiltInType.Int32:
        return (object) (int) value;
      case BuiltInType.UInt32:
        return (object) Convert.ToInt32((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToInt32((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToInt32((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToInt32((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToInt32((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToInt32((string) value);
      case BuiltInType.StatusCode:
        return (object) Convert.ToInt32(((StatusCode) value).Code);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToUInt32(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      uint[] uint32 = new uint[array.Length];
      for (int index = 0; index < array.Length; ++index)
        uint32[index] = (uint) ContentFilter.Cast(array.GetValue(index), BuiltInType.UInt32);
      return (object) uint32;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToUInt32((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToUInt32((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToUInt32((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToUInt32((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToUInt32((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToUInt32((int) value);
      case BuiltInType.UInt32:
        return (object) (uint) value;
      case BuiltInType.Int64:
        return (object) Convert.ToUInt32((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToUInt32((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToUInt32((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToUInt32((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToUInt32((string) value);
      case BuiltInType.StatusCode:
        return (object) Convert.ToUInt32(((StatusCode) value).Code);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToInt64(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      long[] int64 = new long[array.Length];
      for (int index = 0; index < array.Length; ++index)
        int64[index] = (long) ContentFilter.Cast(array.GetValue(index), BuiltInType.Int64);
      return (object) int64;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToInt64((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToInt64((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToInt64((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToInt64((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToInt64((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToInt64((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToInt64((uint) value);
      case BuiltInType.Int64:
        return (object) (long) value;
      case BuiltInType.UInt64:
        return (object) Convert.ToInt64((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToInt64((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToInt64((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToInt64((string) value);
      case BuiltInType.StatusCode:
        return (object) Convert.ToInt64(((StatusCode) value).Code);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToUInt64(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      ulong[] uint64 = new ulong[array.Length];
      for (int index = 0; index < array.Length; ++index)
        uint64[index] = (ulong) ContentFilter.Cast(array.GetValue(index), BuiltInType.UInt64);
      return (object) uint64;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToUInt64((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToUInt64((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToUInt64((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToUInt64((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToUInt64((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToUInt64((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToUInt64((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToUInt64((long) value);
      case BuiltInType.UInt64:
        return (object) (ulong) value;
      case BuiltInType.Float:
        return (object) Convert.ToUInt64((float) value);
      case BuiltInType.Double:
        return (object) Convert.ToUInt64((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToUInt64((string) value);
      case BuiltInType.StatusCode:
        return (object) Convert.ToUInt64(((StatusCode) value).Code);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToFloat(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      float[] numArray = new float[array.Length];
      for (int index = 0; index < array.Length; ++index)
        numArray[index] = (float) ContentFilter.Cast(array.GetValue(index), BuiltInType.Float);
      return (object) numArray;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToSingle((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToSingle((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToSingle((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToSingle((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToSingle((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToSingle((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToSingle((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToSingle((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToSingle((ulong) value);
      case BuiltInType.Float:
        return (object) (float) value;
      case BuiltInType.Double:
        return (object) Convert.ToSingle((double) value);
      case BuiltInType.String:
        return (object) XmlConvert.ToSingle((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToDouble(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      double[] numArray = new double[array.Length];
      for (int index = 0; index < array.Length; ++index)
        numArray[index] = (double) ContentFilter.Cast(array.GetValue(index), BuiltInType.Double);
      return (object) numArray;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) Convert.ToDouble((bool) value);
      case BuiltInType.SByte:
        return (object) Convert.ToDouble((sbyte) value);
      case BuiltInType.Byte:
        return (object) Convert.ToDouble((byte) value);
      case BuiltInType.Int16:
        return (object) Convert.ToDouble((short) value);
      case BuiltInType.UInt16:
        return (object) Convert.ToDouble((ushort) value);
      case BuiltInType.Int32:
        return (object) Convert.ToDouble((int) value);
      case BuiltInType.UInt32:
        return (object) Convert.ToDouble((uint) value);
      case BuiltInType.Int64:
        return (object) Convert.ToDouble((long) value);
      case BuiltInType.UInt64:
        return (object) Convert.ToDouble((ulong) value);
      case BuiltInType.Float:
        return (object) Convert.ToDouble((float) value);
      case BuiltInType.Double:
        return (object) (double) value;
      case BuiltInType.String:
        return (object) XmlConvert.ToDouble((string) value);
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToString(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      string[] strArray = new string[array.Length];
      for (int index = 0; index < array.Length; ++index)
        strArray[index] = (string) ContentFilter.Cast(array.GetValue(index), BuiltInType.String);
      return (object) strArray;
    }
    switch (sourceType)
    {
      case BuiltInType.Boolean:
        return (object) XmlConvert.ToString((bool) value);
      case BuiltInType.SByte:
        return (object) XmlConvert.ToString((sbyte) value);
      case BuiltInType.Byte:
        return (object) XmlConvert.ToString((byte) value);
      case BuiltInType.Int16:
        return (object) XmlConvert.ToString((short) value);
      case BuiltInType.UInt16:
        return (object) XmlConvert.ToString((ushort) value);
      case BuiltInType.Int32:
        return (object) XmlConvert.ToString((int) value);
      case BuiltInType.UInt32:
        return (object) XmlConvert.ToString((uint) value);
      case BuiltInType.Int64:
        return (object) XmlConvert.ToString((long) value);
      case BuiltInType.UInt64:
        return (object) XmlConvert.ToString((ulong) value);
      case BuiltInType.Float:
        return (object) XmlConvert.ToString((float) value);
      case BuiltInType.Double:
        return (object) XmlConvert.ToString((double) value);
      case BuiltInType.String:
        return (object) (string) value;
      case BuiltInType.DateTime:
        return (object) XmlConvert.ToString((DateTime) value, XmlDateTimeSerializationMode.Unspecified);
      case BuiltInType.Guid:
        return (object) ((Guid) value).ToString();
      case BuiltInType.NodeId:
        return (object) ((NodeId) value).ToString();
      case BuiltInType.ExpandedNodeId:
        return (object) ((ExpandedNodeId) value).ToString();
      case BuiltInType.QualifiedName:
        return (object) ((QualifiedName) value).ToString();
      case BuiltInType.LocalizedText:
        return (object) ((LocalizedText) value).Text;
      default:
        return (object) DBNull.Value;
    }
  }

  private static object ToDateTime(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      DateTime[] dateTime = new DateTime[array.Length];
      for (int index = 0; index < array.Length; ++index)
        dateTime[index] = (DateTime) ContentFilter.Cast(array.GetValue(index), BuiltInType.DateTime);
      return (object) dateTime;
    }
    if (sourceType == BuiltInType.String)
      return (object) XmlConvert.ToDateTimeOffset((string) value);
    return sourceType == BuiltInType.DateTime ? (object) (DateTime) value : (object) null;
  }

  private static object ToGuid(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      Guid[] guid = new Guid[array.Length];
      for (int index = 0; index < array.Length; ++index)
        guid[index] = (Guid) ContentFilter.Cast(array.GetValue(index), BuiltInType.Guid);
      return (object) guid;
    }
    switch (sourceType)
    {
      case BuiltInType.String:
        return (object) new Guid((string) value);
      case BuiltInType.Guid:
        return (object) (Guid) value;
      case BuiltInType.ByteString:
        return (object) new Guid((byte[]) value);
      default:
        return (object) null;
    }
  }

  private static object ToByteString(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      byte[][] byteString = new byte[array.Length][];
      for (int index = 0; index < array.Length; ++index)
        byteString[index] = (byte[]) ContentFilter.Cast(array.GetValue(index), BuiltInType.ByteString);
      return (object) byteString;
    }
    if (sourceType == BuiltInType.Guid)
      return (object) ((Guid) value).ToByteArray();
    return sourceType == BuiltInType.ByteString ? (object) (byte[]) value : (object) null;
  }

  private static object ToNodeId(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      NodeId[] nodeId = new NodeId[array.Length];
      for (int index = 0; index < array.Length; ++index)
        nodeId[index] = (NodeId) ContentFilter.Cast(array.GetValue(index), BuiltInType.NodeId);
      return (object) nodeId;
    }
    switch (sourceType)
    {
      case BuiltInType.String:
        return (object) NodeId.Parse((string) value);
      case BuiltInType.NodeId:
        return (object) (NodeId) value;
      case BuiltInType.ExpandedNodeId:
        return (object) (NodeId) (ExpandedNodeId) value;
      default:
        return (object) null;
    }
  }

  private static object ToExpandedNodeId(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      ExpandedNodeId[] expandedNodeId = new ExpandedNodeId[array.Length];
      for (int index = 0; index < array.Length; ++index)
        expandedNodeId[index] = (ExpandedNodeId) ContentFilter.Cast(array.GetValue(index), BuiltInType.ExpandedNodeId);
      return (object) expandedNodeId;
    }
    switch (sourceType)
    {
      case BuiltInType.String:
        return (object) ExpandedNodeId.Parse((string) value);
      case BuiltInType.NodeId:
        return (object) (ExpandedNodeId) (NodeId) value;
      case BuiltInType.ExpandedNodeId:
        return (object) (ExpandedNodeId) value;
      default:
        return (object) null;
    }
  }

  private static object ToStatusCode(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      StatusCode[] statusCode = new StatusCode[array.Length];
      for (int index = 0; index < array.Length; ++index)
        statusCode[index] = (StatusCode) ContentFilter.Cast(array.GetValue(index), BuiltInType.StatusCode);
      return (object) statusCode;
    }
    switch (sourceType)
    {
      case BuiltInType.UInt16:
        return (object) (StatusCode) (Convert.ToUInt32((ushort) value) << 16 /*0x10*/);
      case BuiltInType.Int32:
        return (object) (StatusCode) Convert.ToUInt32((int) value);
      case BuiltInType.UInt32:
        return (object) (StatusCode) (uint) value;
      case BuiltInType.Int64:
        return (object) (StatusCode) Convert.ToUInt32((long) value);
      case BuiltInType.UInt64:
        return (object) (StatusCode) Convert.ToUInt32((ulong) value);
      case BuiltInType.StatusCode:
        return (object) (StatusCode) value;
      default:
        return (object) null;
    }
  }

  private static object ToQualifiedName(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      QualifiedName[] qualifiedName = new QualifiedName[array.Length];
      for (int index = 0; index < array.Length; ++index)
        qualifiedName[index] = (QualifiedName) ContentFilter.Cast(array.GetValue(index), BuiltInType.QualifiedName);
      return (object) qualifiedName;
    }
    if (sourceType == BuiltInType.String)
      return (object) QualifiedName.Parse((string) value);
    return sourceType == BuiltInType.QualifiedName ? (object) (QualifiedName) value : (object) null;
  }

  private static object ToLocalizedText(object value, BuiltInType sourceType)
  {
    if (value is Array array)
    {
      LocalizedText[] localizedText = new LocalizedText[array.Length];
      for (int index = 0; index < array.Length; ++index)
        localizedText[index] = (LocalizedText) ContentFilter.Cast(array.GetValue(index), BuiltInType.LocalizedText);
      return (object) localizedText;
    }
    if (sourceType == BuiltInType.String)
      return (object) new LocalizedText((string) value);
    return sourceType == BuiltInType.LocalizedText ? (object) (LocalizedText) value : (object) null;
  }

  private static object Cast(object source, BuiltInType targetType)
  {
    BuiltInType builtInType = ContentFilter.GetBuiltInType(source);
    return builtInType == BuiltInType.Null ? (object) null : ContentFilter.Cast(source, builtInType, targetType);
  }

  private static object Cast(object source, BuiltInType sourceType, BuiltInType targetType)
  {
    if (source == null)
      return (object) null;
    if (source is Variant variant)
      return ContentFilter.Cast(variant.Value, targetType);
    try
    {
      switch (targetType)
      {
        case BuiltInType.Boolean:
          return ContentFilter.ToBoolean(source, sourceType);
        case BuiltInType.SByte:
          return ContentFilter.ToSByte(source, sourceType);
        case BuiltInType.Byte:
          return ContentFilter.ToByte(source, sourceType);
        case BuiltInType.Int16:
          return ContentFilter.ToInt16(source, sourceType);
        case BuiltInType.UInt16:
          return ContentFilter.ToUInt16(source, sourceType);
        case BuiltInType.Int32:
          return ContentFilter.ToInt32(source, sourceType);
        case BuiltInType.UInt32:
          return ContentFilter.ToUInt32(source, sourceType);
        case BuiltInType.Int64:
          return ContentFilter.ToInt64(source, sourceType);
        case BuiltInType.UInt64:
          return ContentFilter.ToUInt64(source, sourceType);
        case BuiltInType.Float:
          return ContentFilter.ToFloat(source, sourceType);
        case BuiltInType.Double:
          return ContentFilter.ToDouble(source, sourceType);
        case BuiltInType.String:
          return ContentFilter.ToString(source, sourceType);
        case BuiltInType.DateTime:
          return ContentFilter.ToDateTime(source, sourceType);
        case BuiltInType.Guid:
          return ContentFilter.ToGuid(source, sourceType);
        case BuiltInType.ByteString:
          return ContentFilter.ToByteString(source, sourceType);
        case BuiltInType.NodeId:
          return ContentFilter.ToNodeId(source, sourceType);
        case BuiltInType.ExpandedNodeId:
          return ContentFilter.ToExpandedNodeId(source, sourceType);
        case BuiltInType.StatusCode:
          return ContentFilter.ToStatusCode(source, sourceType);
        case BuiltInType.QualifiedName:
          return ContentFilter.ToQualifiedName(source, sourceType);
        case BuiltInType.LocalizedText:
          return ContentFilter.ToLocalizedText(source, sourceType);
      }
    }
    catch (Exception ex)
    {
      object[] objArray = new object[3]
      {
        (object) sourceType,
        source,
        (object) targetType
      };
      Utils.LogError(ex, "Error converting a {0} (Value={1}) to {2}.", objArray);
    }
    return (object) null;
  }

  private bool? And(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    bool? nullable1 = this.GetValue(context, operands[0], target) as bool?;
    if (nullable1.HasValue && !nullable1.Value)
      return new bool?(false);
    bool? nullable2 = this.GetValue(context, operands[1], target) as bool?;
    if (!nullable1.HasValue)
    {
      bool? nullable3;
      if (nullable2.HasValue)
      {
        nullable3 = nullable2;
        if (!(nullable3.GetValueOrDefault() & nullable3.HasValue))
          return new bool?(false);
      }
      nullable3 = new bool?();
      return nullable3;
    }
    if (nullable2.HasValue)
      return new bool?(nullable1.Value && nullable2.Value);
    bool? nullable4;
    if (nullable1.HasValue)
    {
      nullable4 = nullable1;
      if (!(nullable4.GetValueOrDefault() & nullable4.HasValue))
        return new bool?(false);
    }
    nullable4 = new bool?();
    return nullable4;
  }

  private bool? Or(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    bool? nullable1 = this.GetValue(context, operands[0], target) as bool?;
    if (nullable1.HasValue && nullable1.Value)
      return new bool?(true);
    bool? nullable2 = this.GetValue(context, operands[1], target) as bool?;
    if (!nullable1.HasValue)
    {
      bool? nullable3;
      if (nullable2.HasValue)
      {
        nullable3 = nullable2;
        if (!(!nullable3.GetValueOrDefault() & nullable3.HasValue))
          return new bool?(true);
      }
      nullable3 = new bool?();
      return nullable3;
    }
    if (nullable2.HasValue)
      return new bool?(nullable1.Value || nullable2.Value);
    bool? nullable4;
    if (nullable1.HasValue)
    {
      nullable4 = nullable1;
      if (!(!nullable4.GetValueOrDefault() & nullable4.HasValue))
        return new bool?(true);
    }
    nullable4 = new bool?();
    return nullable4;
  }

  private bool? Not(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 1);
    bool? nullable = this.GetValue(context, operands[0], target) as bool?;
    return !nullable.HasValue ? new bool?() : new bool?(!nullable.Value);
  }

  private bool Equals(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return ContentFilter.IsEqual(obj1, obj2);
  }

  private bool? GreaterThan(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return obj1 is IComparable && obj2 is IComparable ? new bool?(((IComparable) obj1).CompareTo(obj2) > 0) : new bool?();
  }

  private bool? GreaterThanOrEqual(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return obj1 is IComparable && obj2 is IComparable ? new bool?(((IComparable) obj1).CompareTo(obj2) >= 0) : new bool?();
  }

  private bool? LessThan(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return obj1 is IComparable && obj2 is IComparable ? new bool?(((IComparable) obj1).CompareTo(obj2) < 0) : new bool?();
  }

  private bool? LessThanOrEqual(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    ContentFilter.DoImplicitConversion(ref obj1, ref obj2);
    return obj1 is IComparable && obj2 is IComparable ? new bool?(((IComparable) obj1).CompareTo(obj2) <= 0) : new bool?();
  }

  private bool? Between(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 3);
    object obj1 = this.GetValue(context, operands[0], target);
    object obj2 = this.GetValue(context, operands[1], target);
    object obj3 = this.GetValue(context, operands[2], target);
    object obj4 = obj1;
    ContentFilter.DoImplicitConversion(ref obj4, ref obj2);
    bool? nullable = new bool?();
    if (obj4 is IComparable && obj2 is IComparable)
    {
      if (((IComparable) obj4).CompareTo(obj2) < 0)
        return new bool?(false);
      nullable = new bool?(true);
    }
    object obj5 = obj1;
    ContentFilter.DoImplicitConversion(ref obj5, ref obj3);
    if (!(obj5 is IComparable) || !(obj3 is IComparable))
      return new bool?();
    return ((IComparable) obj5).CompareTo(obj3) > 0 ? new bool?(false) : new bool?(nullable.HasValue);
  }

  private bool? InList(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 0);
    object obj1 = this.GetValue(context, operands[0], target);
    for (int index = 1; index < operands.Length; ++index)
    {
      object obj2 = obj1;
      object obj3 = this.GetValue(context, operands[index], target);
      ContentFilter.DoImplicitConversion(ref obj2, ref obj3);
      if (ContentFilter.IsEqual(obj2, obj3))
        return new bool?(true);
    }
    return new bool?(false);
  }

  private bool Like(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object obj1 = this.GetValue(context, operands[0], target);
    LocalizedText localizedText1 = obj1 as LocalizedText;
    string target1 = !(localizedText1 != (LocalizedText) null) ? obj1 as string : localizedText1.Text;
    object obj2 = this.GetValue(context, operands[1], target);
    LocalizedText localizedText2 = obj2 as LocalizedText;
    string pattern = !(localizedText2 != (LocalizedText) null) ? obj2 as string : localizedText2.Text;
    return target1 != null && pattern != null && ContentFilter.Match(target1, pattern);
  }

  private bool IsNull(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 1);
    return this.GetValue(context, operands[0], target) == null;
  }

  private object Cast(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 2);
    object source = this.GetValue(context, operands[0], target);
    if (source == null)
      return (object) null;
    NodeId datatypeId = this.GetValue(context, operands[1], target) as NodeId;
    if (datatypeId == (object) null)
      return (object) null;
    BuiltInType builtInType = ContentFilter.GetBuiltInType(datatypeId);
    return ContentFilter.Cast(source, builtInType);
  }

  private bool OfType(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    FilterOperand[] operands = this.GetOperands(element, 1);
    NodeId typeDefinitionId = this.GetValue(context, operands[0], target) as NodeId;
    if (!(typeDefinitionId == (object) null))
    {
      if (target != null)
      {
        try
        {
          return target.IsTypeOf(context, typeDefinitionId);
        }
        catch
        {
          return false;
        }
      }
    }
    return false;
  }

  private bool InView(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    if (!(target is IAdvancedFilterTarget advancedFilterTarget))
      return false;
    FilterOperand[] operands = this.GetOperands(element, 1);
    NodeId viewId = this.GetValue(context, operands[0], target) as NodeId;
    if (!(viewId == (object) null))
    {
      if (target != null)
      {
        try
        {
          return advancedFilterTarget.IsInView(context, viewId);
        }
        catch
        {
          return false;
        }
      }
    }
    return false;
  }

  private bool RelatedTo(FilterContext context, IFilterTarget target, ContentFilterElement element)
  {
    return this.RelatedTo(context, target, element, (NodeId) null);
  }

  private bool RelatedTo(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element,
    NodeId intermediateNodeId)
  {
    if (!(target is IAdvancedFilterTarget advancedFilterTarget))
      return false;
    FilterOperand[] operands = this.GetOperands(element, 6);
    NodeId sourceTypeId = this.GetValue(context, operands[0], target) as NodeId;
    if (sourceTypeId == (object) null)
      return false;
    NodeId referenceTypeId = this.GetValue(context, operands[2], target) as NodeId;
    if (referenceTypeId == (object) null)
      return false;
    int? nullable1 = new int?(1);
    object source1 = this.GetValue(context, operands[3], target);
    if (source1 != null)
    {
      nullable1 = ContentFilter.Cast(source1, BuiltInType.Int32) as int?;
      if (!nullable1.HasValue)
        nullable1 = new int?(1);
    }
    bool? nullable2 = new bool?(true);
    object source2 = this.GetValue(context, operands[4], target);
    if (source2 != null)
    {
      nullable2 = ContentFilter.Cast(source2, BuiltInType.Boolean) as bool?;
      if (!nullable2.HasValue)
        nullable2 = new bool?(true);
    }
    bool? nullable3 = new bool?(true);
    object source3 = this.GetValue(context, operands[5], target);
    if (source3 != null)
    {
      nullable3 = ContentFilter.Cast(source3, BuiltInType.Boolean) as bool?;
      if (!nullable3.HasValue)
        nullable3 = new bool?(true);
    }
    NodeId targetTypeId1 = (NodeId) null;
    if (operands[1] is ElementOperand elementOperand)
    {
      if ((long) elementOperand.Index >= (long) this.Elements.Count)
        return false;
      ContentFilterElement element1 = this.Elements[(int) elementOperand.Index];
      if (element1.FilterOperator == FilterOperator.RelatedTo)
      {
        FilterOperand encodeable = ExtensionObject.ToEncodeable(element1.FilterOperands[0]) as FilterOperand;
        NodeId targetTypeId2 = this.GetValue(context, encodeable, target) as NodeId;
        if (targetTypeId2 == (object) null)
          return false;
        IList<NodeId> relatedNodes = advancedFilterTarget.GetRelatedNodes(context, intermediateNodeId, sourceTypeId, targetTypeId2, referenceTypeId, nullable1.Value, nullable2.Value, nullable3.Value);
        if (relatedNodes == null || relatedNodes.Count == 0)
          return false;
        for (int index = 0; index < relatedNodes.Count; ++index)
        {
          if (this.RelatedTo(context, target, element1, relatedNodes[index]))
            return true;
        }
        return false;
      }
    }
    if (targetTypeId1 == (object) null)
    {
      targetTypeId1 = this.GetValue(context, operands[1], target) as NodeId;
      if (targetTypeId1 == (object) null)
        return false;
    }
    try
    {
      return advancedFilterTarget.IsRelatedTo(context, intermediateNodeId, sourceTypeId, targetTypeId1, referenceTypeId, nullable1.Value, nullable2.Value, nullable3.Value);
    }
    catch
    {
      return false;
    }
  }

  private object BitwiseAnd(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    object obj1;
    object obj2;
    this.GetBitwiseOperands(context, target, element).Deconstruct<object, object>(out obj1, out obj2);
    object obj3 = obj1;
    object obj4 = obj2;
    if (obj3 == null || obj4 == null)
      return (object) null;
    Type type = obj3.GetType();
    if (type == typeof (byte))
      return (object) ((int) (byte) obj3 & (int) (byte) obj4);
    if (type == typeof (sbyte))
      return (object) ((int) (sbyte) obj3 & (int) (sbyte) obj4);
    if (type == typeof (short))
      return (object) ((int) (short) obj3 & (int) (short) obj4);
    if (type == typeof (ushort))
      return (object) ((int) (ushort) obj3 & (int) (ushort) obj4);
    if (type == typeof (int))
      return (object) ((int) obj3 & (int) obj4);
    if (type == typeof (uint))
      return (object) (uint) ((int) (uint) obj3 & (int) (uint) obj4);
    if (type == typeof (long))
      return (object) ((long) obj3 & (long) obj4);
    return type == typeof (ulong) ? (object) (ulong) ((long) (ulong) obj3 & (long) (ulong) obj4) : (object) null;
  }

  private object BitwiseOr(
    FilterContext context,
    IFilterTarget target,
    ContentFilterElement element)
  {
    object obj1;
    object obj2;
    this.GetBitwiseOperands(context, target, element).Deconstruct<object, object>(out obj1, out obj2);
    object obj3 = obj1;
    object obj4 = obj2;
    if (obj3 == null || obj4 == null)
      return (object) null;
    Type type = obj3.GetType();
    if (type == typeof (byte))
      return (object) ((int) (byte) obj3 | (int) (byte) obj4);
    if (type == typeof (sbyte))
      return (object) ((int) (sbyte) obj3 | (int) (sbyte) obj4);
    if (type == typeof (short))
      return (object) ((int) (short) obj3 | (int) (short) obj4);
    if (type == typeof (ushort))
      return (object) ((int) (ushort) obj3 | (int) (ushort) obj4);
    if (type == typeof (int))
      return (object) ((int) obj3 | (int) obj4);
    if (type == typeof (uint))
      return (object) (uint) ((int) (uint) obj3 | (int) (uint) obj4);
    if (type == typeof (long))
      return (object) ((long) obj3 | (long) obj4);
    return type == typeof (ulong) ? (object) (ulong) ((long) (ulong) obj3 | (long) (ulong) obj4) : (object) null;
  }

  public class Result
  {
    private ServiceResult m_status;
    private List<ContentFilter.ElementResult> m_elementResults;

    public Result(ServiceResult status) => this.m_status = status;

    public static implicit operator ContentFilter.Result(ServiceResult status)
    {
      return new ContentFilter.Result(status);
    }

    public ServiceResult Status
    {
      get => this.m_status;
      set => this.m_status = value;
    }

    public List<ContentFilter.ElementResult> ElementResults
    {
      get
      {
        if (this.m_elementResults == null)
          this.m_elementResults = new List<ContentFilter.ElementResult>();
        return this.m_elementResults;
      }
    }

    public ContentFilterResult ToContextFilterResult(
      DiagnosticsMasks diagnosticsMasks,
      StringTable stringTable)
    {
      ContentFilterResult contextFilterResult = new ContentFilterResult();
      if (this.m_elementResults == null || this.m_elementResults.Count == 0)
        return contextFilterResult;
      bool flag = false;
      foreach (ContentFilter.ElementResult elementResult in this.m_elementResults)
      {
        if (elementResult != null && !ServiceResult.IsGood(elementResult.Status))
        {
          flag = true;
          ContentFilterElementResult filterElementResult = elementResult.ToContentFilterElementResult(diagnosticsMasks, stringTable);
          contextFilterResult.ElementResults.Add(filterElementResult);
          contextFilterResult.ElementDiagnosticInfos.Add(new DiagnosticInfo(elementResult.Status, diagnosticsMasks, false, stringTable));
        }
        else
        {
          contextFilterResult.ElementResults.Add(new ContentFilterElementResult()
          {
            StatusCode = (StatusCode) 0U
          });
          contextFilterResult.ElementDiagnosticInfos.Add((DiagnosticInfo) null);
        }
      }
      if (!flag)
      {
        contextFilterResult.ElementResults.Clear();
        contextFilterResult.ElementDiagnosticInfos.Clear();
      }
      return contextFilterResult;
    }
  }

  public class ElementResult
  {
    private ServiceResult m_status;
    private List<ServiceResult> m_operandResults;

    public ElementResult(ServiceResult status) => this.m_status = status;

    public static implicit operator ContentFilter.ElementResult(ServiceResult status)
    {
      return new ContentFilter.ElementResult(status);
    }

    public ServiceResult Status
    {
      get => this.m_status;
      set => this.m_status = value;
    }

    public List<ServiceResult> OperandResults
    {
      get
      {
        if (this.m_operandResults == null)
          this.m_operandResults = new List<ServiceResult>();
        return this.m_operandResults;
      }
    }

    public ContentFilterElementResult ToContentFilterElementResult(
      DiagnosticsMasks diagnosticsMasks,
      StringTable stringTable)
    {
      ContentFilterElementResult filterElementResult = new ContentFilterElementResult();
      if (ServiceResult.IsGood(this.m_status))
      {
        filterElementResult.StatusCode = (StatusCode) 0U;
        return filterElementResult;
      }
      filterElementResult.StatusCode = this.m_status.StatusCode;
      if (this.m_operandResults.Count == 0)
        return filterElementResult;
      foreach (ServiceResult operandResult in this.m_operandResults)
      {
        if (ServiceResult.IsGood(operandResult))
        {
          filterElementResult.OperandStatusCodes.Add((StatusCode) 0U);
          filterElementResult.OperandDiagnosticInfos.Add((DiagnosticInfo) null);
        }
        else
        {
          filterElementResult.OperandStatusCodes.Add(operandResult.StatusCode);
          filterElementResult.OperandDiagnosticInfos.Add(new DiagnosticInfo(operandResult, diagnosticsMasks, false, stringTable));
        }
      }
      return filterElementResult;
    }
  }
}
