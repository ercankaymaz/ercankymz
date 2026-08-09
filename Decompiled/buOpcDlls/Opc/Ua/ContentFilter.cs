using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilter : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
	public class Result
	{
		private ServiceResult m_status;

		private List<ElementResult> m_elementResults;

		public ServiceResult Status
		{
			get
			{
				return m_status;
			}
			set
			{
				m_status = value;
			}
		}

		public List<ElementResult> ElementResults
		{
			get
			{
				if (m_elementResults == null)
				{
					m_elementResults = new List<ElementResult>();
				}
				return m_elementResults;
			}
		}

		public Result(ServiceResult status)
		{
			m_status = status;
		}

		public static implicit operator Result(ServiceResult status)
		{
			return new Result(status);
		}

		public ContentFilterResult ToContextFilterResult(DiagnosticsMasks diagnosticsMasks, StringTable stringTable)
		{
			ContentFilterResult contentFilterResult = new ContentFilterResult();
			if (m_elementResults == null || m_elementResults.Count == 0)
			{
				return contentFilterResult;
			}
			bool flag = false;
			foreach (ElementResult elementResult in m_elementResults)
			{
				ContentFilterElementResult contentFilterElementResult = null;
				if (elementResult == null || ServiceResult.IsGood(elementResult.Status))
				{
					contentFilterElementResult = new ContentFilterElementResult();
					contentFilterElementResult.StatusCode = 0u;
					contentFilterResult.ElementResults.Add(contentFilterElementResult);
					contentFilterResult.ElementDiagnosticInfos.Add(null);
				}
				else
				{
					flag = true;
					contentFilterElementResult = elementResult.ToContentFilterElementResult(diagnosticsMasks, stringTable);
					contentFilterResult.ElementResults.Add(contentFilterElementResult);
					contentFilterResult.ElementDiagnosticInfos.Add(new DiagnosticInfo(elementResult.Status, diagnosticsMasks, serviceLevel: false, stringTable));
				}
			}
			if (!flag)
			{
				contentFilterResult.ElementResults.Clear();
				contentFilterResult.ElementDiagnosticInfos.Clear();
			}
			return contentFilterResult;
		}
	}

	public class ElementResult
	{
		private ServiceResult m_status;

		private List<ServiceResult> m_operandResults;

		public ServiceResult Status
		{
			get
			{
				return m_status;
			}
			set
			{
				m_status = value;
			}
		}

		public List<ServiceResult> OperandResults
		{
			get
			{
				if (m_operandResults == null)
				{
					m_operandResults = new List<ServiceResult>();
				}
				return m_operandResults;
			}
		}

		public ElementResult(ServiceResult status)
		{
			m_status = status;
		}

		public static implicit operator ElementResult(ServiceResult status)
		{
			return new ElementResult(status);
		}

		public ContentFilterElementResult ToContentFilterElementResult(DiagnosticsMasks diagnosticsMasks, StringTable stringTable)
		{
			ContentFilterElementResult contentFilterElementResult = new ContentFilterElementResult();
			if (ServiceResult.IsGood(m_status))
			{
				contentFilterElementResult.StatusCode = 0u;
				return contentFilterElementResult;
			}
			contentFilterElementResult.StatusCode = m_status.StatusCode;
			if (m_operandResults.Count == 0)
			{
				return contentFilterElementResult;
			}
			foreach (ServiceResult operandResult in m_operandResults)
			{
				if (ServiceResult.IsGood(operandResult))
				{
					contentFilterElementResult.OperandStatusCodes.Add(0u);
					contentFilterElementResult.OperandDiagnosticInfos.Add(null);
				}
				else
				{
					contentFilterElementResult.OperandStatusCodes.Add(operandResult.StatusCode);
					contentFilterElementResult.OperandDiagnosticInfos.Add(new DiagnosticInfo(operandResult, diagnosticsMasks, serviceLevel: false, stringTable));
				}
			}
			return contentFilterElementResult;
		}
	}

	private ContentFilterElementCollection m_elements;

	[DataMember(Name = "Elements", IsRequired = false, Order = 1)]
	public ContentFilterElementCollection Elements
	{
		get
		{
			return m_elements;
		}
		set
		{
			m_elements = value;
			if (value == null)
			{
				m_elements = new ContentFilterElementCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ContentFilter;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ContentFilter_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ContentFilter_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ContentFilter_Encoding_DefaultJson;

	public ContentFilter()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_elements = new ContentFilterElementCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Elements", Elements.ToArray(), typeof(ContentFilterElement));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Elements = (ContentFilterElement[])decoder.ReadEncodeableArray("Elements", typeof(ContentFilterElement));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ContentFilter contentFilter))
		{
			return false;
		}
		if (!Utils.IsEqual(m_elements, contentFilter.m_elements))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ContentFilter)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilter obj = (ContentFilter)base.MemberwiseClone();
		obj.m_elements = (ContentFilterElementCollection)Utils.Clone(m_elements);
		return obj;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Elements.Count; i++)
			{
				stringBuilder.AppendFormat(formatProvider, "[{0}:{1}]", i, Elements[i]);
			}
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public Result Validate(FilterContext context)
	{
		Result result = new Result(null);
		if (m_elements == null || m_elements.Count == 0)
		{
			return result;
		}
		bool flag = false;
		for (int i = 0; i < m_elements.Count; i++)
		{
			ContentFilterElement contentFilterElement = m_elements[i];
			if (contentFilterElement == null)
			{
				ServiceResult status = ServiceResult.Create(2152071168u, "ContentFilterElement is null (Index={0}).", i);
				result.ElementResults.Add(new ElementResult(status));
				flag = true;
				continue;
			}
			contentFilterElement.Parent = this;
			ElementResult elementResult = contentFilterElement.Validate(context, i);
			if (ServiceResult.IsBad(elementResult.Status))
			{
				result.ElementResults.Add(elementResult);
				flag = true;
			}
			else
			{
				result.ElementResults.Add(null);
			}
		}
		if (flag)
		{
			result.Status = 2152202240u;
		}
		else
		{
			result.ElementResults.Clear();
		}
		return result;
	}

	public ContentFilterElement Push(FilterOperator op, params object[] operands)
	{
		if (operands == null || operands.Length == 0)
		{
			throw ServiceResultException.Create(2158690304u, "ContentFilterElement does not have an operands.");
		}
		ContentFilterElement contentFilterElement = new ContentFilterElement();
		contentFilterElement.FilterOperator = op;
		for (int i = 0; i < operands.Length; i++)
		{
			if (operands[i] is FilterOperand body)
			{
				contentFilterElement.FilterOperands.Add(new ExtensionObject(body));
			}
			else if (operands[i] is ContentFilterElement target)
			{
				int num = FindElementIndex(target);
				if (num == -1)
				{
					throw ServiceResultException.Create(2158690304u, "ContentFilterElement is not part of the ContentFilter.");
				}
				ElementOperand elementOperand = new ElementOperand();
				elementOperand.Index = (uint)num;
				contentFilterElement.FilterOperands.Add(new ExtensionObject(elementOperand));
			}
			else
			{
				LiteralOperand literalOperand = new LiteralOperand();
				literalOperand.Value = new Variant(operands[i]);
				contentFilterElement.FilterOperands.Add(new ExtensionObject(literalOperand));
			}
		}
		m_elements.Insert(0, contentFilterElement);
		for (int j = 0; j < m_elements.Count; j++)
		{
			foreach (ExtensionObject filterOperand in m_elements[j].FilterOperands)
			{
				if (filterOperand != null && filterOperand.Body is ElementOperand elementOperand2)
				{
					elementOperand2.Index++;
				}
			}
		}
		return contentFilterElement;
	}

	private int FindElementIndex(ContentFilterElement target)
	{
		for (int i = 0; i < m_elements.Count; i++)
		{
			if (target == m_elements[i])
			{
				return i;
			}
		}
		return -1;
	}

	public bool Evaluate(FilterContext context, IFilterTarget target)
	{
		if (Elements.Count == 0)
		{
			return true;
		}
		bool? flag = Evaluate(context, target, 0) as bool?;
		if (!flag.HasValue)
		{
			return false;
		}
		return flag.Value;
	}

	private object Evaluate(FilterContext context, IFilterTarget target, int index)
	{
		ContentFilterElement contentFilterElement = Elements[index];
		return contentFilterElement.FilterOperator switch
		{
			FilterOperator.And => And(context, target, contentFilterElement), 
			FilterOperator.Or => Or(context, target, contentFilterElement), 
			FilterOperator.Not => Not(context, target, contentFilterElement), 
			FilterOperator.Equals => Equals(context, target, contentFilterElement), 
			FilterOperator.GreaterThan => GreaterThan(context, target, contentFilterElement), 
			FilterOperator.GreaterThanOrEqual => GreaterThanOrEqual(context, target, contentFilterElement), 
			FilterOperator.LessThan => LessThan(context, target, contentFilterElement), 
			FilterOperator.LessThanOrEqual => LessThanOrEqual(context, target, contentFilterElement), 
			FilterOperator.Between => Between(context, target, contentFilterElement), 
			FilterOperator.InList => InList(context, target, contentFilterElement), 
			FilterOperator.Like => Like(context, target, contentFilterElement), 
			FilterOperator.IsNull => IsNull(context, target, contentFilterElement), 
			FilterOperator.Cast => Cast(context, target, contentFilterElement), 
			FilterOperator.OfType => OfType(context, target, contentFilterElement), 
			FilterOperator.InView => InView(context, target, contentFilterElement), 
			FilterOperator.RelatedTo => RelatedTo(context, target, contentFilterElement), 
			FilterOperator.BitwiseAnd => BitwiseAnd(context, target, contentFilterElement), 
			FilterOperator.BitwiseOr => BitwiseOr(context, target, contentFilterElement), 
			_ => throw new ServiceResultException(2147549184u, "FilterOperator is not recognized."), 
		};
	}

	private FilterOperand[] GetOperands(ContentFilterElement element, int expectedCount)
	{
		FilterOperand[] array = new FilterOperand[element.FilterOperands.Count];
		int num = 0;
		foreach (ExtensionObject filterOperand2 in element.FilterOperands)
		{
			if (ExtensionObject.IsNull(filterOperand2))
			{
				throw new ServiceResultException(2147549184u, "FilterOperand is null.");
			}
			if (!(filterOperand2.Body is FilterOperand filterOperand))
			{
				throw new ServiceResultException(2147549184u, "FilterOperand is not supported.");
			}
			array[num++] = filterOperand;
		}
		if (expectedCount > 0 && expectedCount != array.Length)
		{
			throw new ServiceResultException(2147549184u, "ContentFilterElement does not have the correct number of operands.");
		}
		return array;
	}

	private Tuple<object, object> GetBitwiseOperands(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		if (value == null || value2 == null)
		{
			return Tuple.Create<object, object>(null, null);
		}
		if (!isIntegerType(GetBuiltInType(value)) || !isIntegerType(GetBuiltInType(value2)))
		{
			return Tuple.Create<object, object>(null, null);
		}
		DoImplicitConversion(ref value, ref value2);
		return Tuple.Create(value, value2);
	}

	private object GetValue(FilterContext context, FilterOperand operand, IFilterTarget target)
	{
		if (operand is LiteralOperand { Value: var value })
		{
			return value.Value;
		}
		if (operand is SimpleAttributeOperand simpleAttributeOperand)
		{
			return target.GetAttributeValue(context, simpleAttributeOperand.TypeDefinitionId, simpleAttributeOperand.BrowsePath, simpleAttributeOperand.AttributeId, simpleAttributeOperand.ParsedIndexRange);
		}
		if (operand is AttributeOperand attributeOperand)
		{
			if (!(target is IAdvancedFilterTarget advancedFilterTarget))
			{
				return false;
			}
			return advancedFilterTarget.GetRelatedAttributeValue(context, attributeOperand.NodeId, attributeOperand.BrowsePath, attributeOperand.AttributeId, attributeOperand.ParsedIndexRange);
		}
		if (operand is ElementOperand elementOperand)
		{
			return Evaluate(context, target, (int)elementOperand.Index);
		}
		throw new ServiceResultException(2147549184u, "FilterOperand is not supported.");
	}

	private static BuiltInType GetBuiltInType(object value)
	{
		if (value == null)
		{
			return BuiltInType.Null;
		}
		Type type = value.GetType();
		if (value is Array)
		{
			type = type.GetElementType();
		}
		if (type == typeof(bool))
		{
			return BuiltInType.Boolean;
		}
		if (type == typeof(sbyte))
		{
			return BuiltInType.SByte;
		}
		if (type == typeof(byte))
		{
			return BuiltInType.Byte;
		}
		if (type == typeof(short))
		{
			return BuiltInType.Int16;
		}
		if (type == typeof(ushort))
		{
			return BuiltInType.UInt16;
		}
		if (type == typeof(int))
		{
			return BuiltInType.Int32;
		}
		if (type == typeof(uint))
		{
			return BuiltInType.UInt32;
		}
		if (type == typeof(long))
		{
			return BuiltInType.Int64;
		}
		if (type == typeof(ulong))
		{
			return BuiltInType.UInt64;
		}
		if (type == typeof(float))
		{
			return BuiltInType.Float;
		}
		if (type == typeof(double))
		{
			return BuiltInType.Double;
		}
		if (type == typeof(string))
		{
			return BuiltInType.String;
		}
		if (type == typeof(DateTime))
		{
			return BuiltInType.DateTime;
		}
		if (type == typeof(Guid))
		{
			return BuiltInType.Guid;
		}
		if (type == typeof(Uuid))
		{
			return BuiltInType.Guid;
		}
		if (type == typeof(byte[]))
		{
			return BuiltInType.ByteString;
		}
		if (type == typeof(XmlElement))
		{
			return BuiltInType.XmlElement;
		}
		if (type == typeof(NodeId))
		{
			return BuiltInType.NodeId;
		}
		if (type == typeof(ExpandedNodeId))
		{
			return BuiltInType.ExpandedNodeId;
		}
		if (type == typeof(StatusCode))
		{
			return BuiltInType.StatusCode;
		}
		if (type == typeof(DiagnosticInfo))
		{
			return BuiltInType.DiagnosticInfo;
		}
		if (type == typeof(QualifiedName))
		{
			return BuiltInType.QualifiedName;
		}
		if (type == typeof(LocalizedText))
		{
			return BuiltInType.LocalizedText;
		}
		if (type == typeof(ExtensionObject))
		{
			return BuiltInType.ExtensionObject;
		}
		if (type == typeof(DataValue))
		{
			return BuiltInType.DataValue;
		}
		if (type == typeof(Variant))
		{
			return BuiltInType.Variant;
		}
		if (type == typeof(object))
		{
			return BuiltInType.Variant;
		}
		if (type.GetTypeInfo().IsEnum)
		{
			return BuiltInType.Enumeration;
		}
		return BuiltInType.Null;
	}

	private static BuiltInType GetBuiltInType(NodeId datatypeId)
	{
		if (datatypeId == null || datatypeId.NamespaceIndex != 0 || datatypeId.IdType != IdType.Numeric)
		{
			return BuiltInType.Null;
		}
		return (BuiltInType)Enum.ToObject(typeof(BuiltInType), datatypeId.Identifier);
	}

	private static int GetDataTypePrecedence(BuiltInType type)
	{
		return type switch
		{
			BuiltInType.Double => 18, 
			BuiltInType.Float => 17, 
			BuiltInType.Int64 => 16, 
			BuiltInType.UInt64 => 15, 
			BuiltInType.Int32 => 14, 
			BuiltInType.UInt32 => 13, 
			BuiltInType.StatusCode => 12, 
			BuiltInType.Int16 => 11, 
			BuiltInType.UInt16 => 10, 
			BuiltInType.SByte => 9, 
			BuiltInType.Byte => 8, 
			BuiltInType.Boolean => 7, 
			BuiltInType.Guid => 6, 
			BuiltInType.String => 5, 
			BuiltInType.ExpandedNodeId => 4, 
			BuiltInType.NodeId => 3, 
			BuiltInType.LocalizedText => 2, 
			BuiltInType.QualifiedName => 1, 
			_ => 0, 
		};
	}

	private static void DoImplicitConversion(ref object value1, ref object value2)
	{
		BuiltInType builtInType = GetBuiltInType(value1);
		BuiltInType builtInType2 = GetBuiltInType(value2);
		int dataTypePrecedence = GetDataTypePrecedence(builtInType);
		int dataTypePrecedence2 = GetDataTypePrecedence(builtInType2);
		if (dataTypePrecedence != dataTypePrecedence2)
		{
			if (dataTypePrecedence > dataTypePrecedence2)
			{
				value2 = Cast(value2, builtInType2, builtInType);
			}
			else
			{
				value1 = Cast(value1, builtInType, builtInType2);
			}
		}
	}

	private static bool IsEqual(object value1, object value2)
	{
		if (value1 == null || value2 == null)
		{
			if (value1 == null)
			{
				return value2 == null;
			}
			return false;
		}
		if (value1 is DBNull || value2 is DBNull)
		{
			if (value1 is DBNull)
			{
				return value2 is DBNull;
			}
			return false;
		}
		if (value1.GetType() != value2.GetType())
		{
			return false;
		}
		return Utils.IsEqual(value1, value2);
	}

	private static bool Match(string target, string pattern)
	{
		string input = pattern;
		input = Regex.Replace(input, "([\\^\\$\\.\\|\\?\\*\\+\\(\\)])", "\\$1", RegexOptions.Compiled);
		input = Regex.Replace(input, "(?<!\\\\)%", ".*", RegexOptions.Compiled);
		input = Regex.Replace(input, "(?<!\\\\)_", ".", RegexOptions.Compiled);
		input = Regex.Replace(input, "(?<!\\\\)(\\[!)", "[^", RegexOptions.Compiled);
		return Regex.IsMatch(target, input);
	}

	private static bool isIntegerType(BuiltInType aType)
	{
		if (aType == BuiltInType.Byte || aType == BuiltInType.SByte || aType == BuiltInType.Int16 || aType == BuiltInType.UInt16 || aType == BuiltInType.Int32 || aType == BuiltInType.UInt32 || aType == BuiltInType.Int64 || aType == BuiltInType.UInt64)
		{
			return true;
		}
		return false;
	}

	private static object ToBoolean(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			bool[] array2 = new bool[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (bool)Cast(array.GetValue(i), BuiltInType.Boolean);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.Boolean => (bool)value, 
			BuiltInType.SByte => Convert.ToBoolean((byte)value), 
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
			_ => DBNull.Value, 
		};
	}

	private static object ToSByte(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			sbyte[] array2 = new sbyte[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (sbyte)Cast(array.GetValue(i), BuiltInType.SByte);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToByte(object value, BuiltInType sourceType)
	{
		if (value is Array)
		{
			throw new NotImplementedException("Arrays of Byte not supported. Use ByteString instead.");
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToInt16(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			short[] array2 = new short[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (short)Cast(array.GetValue(i), BuiltInType.Int16);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToUInt16(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			ushort[] array2 = new ushort[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (ushort)Cast(array.GetValue(i), BuiltInType.UInt16);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToInt32(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (int)Cast(array.GetValue(i), BuiltInType.Int32);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToUInt32(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			uint[] array2 = new uint[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (uint)Cast(array.GetValue(i), BuiltInType.UInt32);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToInt64(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			long[] array2 = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (long)Cast(array.GetValue(i), BuiltInType.Int64);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToUInt64(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			ulong[] array2 = new ulong[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (ulong)Cast(array.GetValue(i), BuiltInType.UInt64);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToFloat(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			float[] array2 = new float[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (float)Cast(array.GetValue(i), BuiltInType.Float);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToDouble(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			double[] array2 = new double[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (double)Cast(array.GetValue(i), BuiltInType.Double);
			}
			return array2;
		}
		return sourceType switch
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
			_ => DBNull.Value, 
		};
	}

	private static object ToString(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (string)Cast(array.GetValue(i), BuiltInType.String);
			}
			return array2;
		}
		return sourceType switch
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
			BuiltInType.Guid => ((Guid)value/*cast due to constrained. prefix*/).ToString(), 
			BuiltInType.NodeId => ((NodeId)value).ToString(), 
			BuiltInType.ExpandedNodeId => ((ExpandedNodeId)value).ToString(), 
			BuiltInType.LocalizedText => ((LocalizedText)value).Text, 
			BuiltInType.QualifiedName => ((QualifiedName)value).ToString(), 
			_ => DBNull.Value, 
		};
	}

	private static object ToDateTime(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			DateTime[] array2 = new DateTime[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (DateTime)Cast(array.GetValue(i), BuiltInType.DateTime);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.DateTime => (DateTime)value, 
			BuiltInType.String => XmlConvert.ToDateTimeOffset((string)value), 
			_ => null, 
		};
	}

	private static object ToGuid(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			Guid[] array2 = new Guid[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (Guid)Cast(array.GetValue(i), BuiltInType.Guid);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.Guid => (Guid)value, 
			BuiltInType.String => new Guid((string)value), 
			BuiltInType.ByteString => new Guid((byte[])value), 
			_ => null, 
		};
	}

	private static object ToByteString(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			byte[][] array2 = new byte[array.Length][];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (byte[])Cast(array.GetValue(i), BuiltInType.ByteString);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.ByteString => (byte[])value, 
			BuiltInType.Guid => ((Guid)value).ToByteArray(), 
			_ => null, 
		};
	}

	private static object ToNodeId(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			NodeId[] array2 = new NodeId[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (NodeId)Cast(array.GetValue(i), BuiltInType.NodeId);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.NodeId => (NodeId)value, 
			BuiltInType.ExpandedNodeId => (NodeId)(ExpandedNodeId)value, 
			BuiltInType.String => NodeId.Parse((string)value), 
			_ => null, 
		};
	}

	private static object ToExpandedNodeId(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			ExpandedNodeId[] array2 = new ExpandedNodeId[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (ExpandedNodeId)Cast(array.GetValue(i), BuiltInType.ExpandedNodeId);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.ExpandedNodeId => (ExpandedNodeId)value, 
			BuiltInType.NodeId => (ExpandedNodeId)(NodeId)value, 
			BuiltInType.String => ExpandedNodeId.Parse((string)value), 
			_ => null, 
		};
	}

	private static object ToStatusCode(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			StatusCode[] array2 = new StatusCode[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (StatusCode)Cast(array.GetValue(i), BuiltInType.StatusCode);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.StatusCode => (StatusCode)value, 
			BuiltInType.UInt16 => (StatusCode)(Convert.ToUInt32((ushort)value) << 16), 
			BuiltInType.Int32 => (StatusCode)Convert.ToUInt32((int)value), 
			BuiltInType.UInt32 => (StatusCode)(uint)value, 
			BuiltInType.Int64 => (StatusCode)Convert.ToUInt32((long)value), 
			BuiltInType.UInt64 => (StatusCode)Convert.ToUInt32((ulong)value), 
			_ => null, 
		};
	}

	private static object ToQualifiedName(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			QualifiedName[] array2 = new QualifiedName[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (QualifiedName)Cast(array.GetValue(i), BuiltInType.QualifiedName);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.QualifiedName => (QualifiedName)value, 
			BuiltInType.String => QualifiedName.Parse((string)value), 
			_ => null, 
		};
	}

	private static object ToLocalizedText(object value, BuiltInType sourceType)
	{
		if (value is Array array)
		{
			LocalizedText[] array2 = new LocalizedText[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (LocalizedText)Cast(array.GetValue(i), BuiltInType.LocalizedText);
			}
			return array2;
		}
		return sourceType switch
		{
			BuiltInType.LocalizedText => (LocalizedText)value, 
			BuiltInType.String => new LocalizedText((string)value), 
			_ => null, 
		};
	}

	private static object Cast(object source, BuiltInType targetType)
	{
		BuiltInType builtInType = GetBuiltInType(source);
		if (builtInType == BuiltInType.Null)
		{
			return null;
		}
		return Cast(source, builtInType, targetType);
	}

	private static object Cast(object source, BuiltInType sourceType, BuiltInType targetType)
	{
		if (source == null)
		{
			return null;
		}
		if (source is Variant variant)
		{
			return Cast(variant.Value, targetType);
		}
		try
		{
			switch (targetType)
			{
			case BuiltInType.Boolean:
				return ToBoolean(source, sourceType);
			case BuiltInType.SByte:
				return ToSByte(source, sourceType);
			case BuiltInType.Byte:
				return ToByte(source, sourceType);
			case BuiltInType.Int16:
				return ToInt16(source, sourceType);
			case BuiltInType.UInt16:
				return ToUInt16(source, sourceType);
			case BuiltInType.Int32:
				return ToInt32(source, sourceType);
			case BuiltInType.UInt32:
				return ToUInt32(source, sourceType);
			case BuiltInType.Int64:
				return ToInt64(source, sourceType);
			case BuiltInType.UInt64:
				return ToUInt64(source, sourceType);
			case BuiltInType.Float:
				return ToFloat(source, sourceType);
			case BuiltInType.Double:
				return ToDouble(source, sourceType);
			case BuiltInType.String:
				return ToString(source, sourceType);
			case BuiltInType.DateTime:
				return ToDateTime(source, sourceType);
			case BuiltInType.Guid:
				return ToGuid(source, sourceType);
			case BuiltInType.ByteString:
				return ToByteString(source, sourceType);
			case BuiltInType.NodeId:
				return ToNodeId(source, sourceType);
			case BuiltInType.ExpandedNodeId:
				return ToExpandedNodeId(source, sourceType);
			case BuiltInType.StatusCode:
				return ToStatusCode(source, sourceType);
			case BuiltInType.QualifiedName:
				return ToQualifiedName(source, sourceType);
			case BuiltInType.LocalizedText:
				return ToLocalizedText(source, sourceType);
			case BuiltInType.XmlElement:
				break;
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Error converting a {0} (Value={1}) to {2}.", sourceType, source, targetType);
		}
		return null;
	}

	private bool? And(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		bool? flag = GetValue(context, operands[0], target) as bool?;
		if (flag.HasValue && !flag.Value)
		{
			return false;
		}
		bool? flag2 = GetValue(context, operands[1], target) as bool?;
		if (!flag.HasValue)
		{
			if (!flag2.HasValue || flag2 == true)
			{
				return null;
			}
			return false;
		}
		if (!flag2.HasValue)
		{
			if (!flag.HasValue || flag == true)
			{
				return null;
			}
			return false;
		}
		return flag.Value && flag2.Value;
	}

	private bool? Or(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		bool? flag = GetValue(context, operands[0], target) as bool?;
		if (flag.HasValue && flag.Value)
		{
			return true;
		}
		bool? flag2 = GetValue(context, operands[1], target) as bool?;
		if (!flag.HasValue)
		{
			if (!flag2.HasValue || flag2 == false)
			{
				return null;
			}
			return true;
		}
		if (!flag2.HasValue)
		{
			if (!flag.HasValue || flag == false)
			{
				return null;
			}
			return true;
		}
		return flag.Value || flag2.Value;
	}

	private bool? Not(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 1);
		bool? flag = GetValue(context, operands[0], target) as bool?;
		if (!flag.HasValue)
		{
			return null;
		}
		return !flag.Value;
	}

	private bool Equals(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		DoImplicitConversion(ref value, ref value2);
		return IsEqual(value, value2);
	}

	private bool? GreaterThan(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		DoImplicitConversion(ref value, ref value2);
		if (value is IComparable && value2 is IComparable)
		{
			return ((IComparable)value).CompareTo(value2) > 0;
		}
		return null;
	}

	private bool? GreaterThanOrEqual(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		DoImplicitConversion(ref value, ref value2);
		if (value is IComparable && value2 is IComparable)
		{
			return ((IComparable)value).CompareTo(value2) >= 0;
		}
		return null;
	}

	private bool? LessThan(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		DoImplicitConversion(ref value, ref value2);
		if (value is IComparable && value2 is IComparable)
		{
			return ((IComparable)value).CompareTo(value2) < 0;
		}
		return null;
	}

	private bool? LessThanOrEqual(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		DoImplicitConversion(ref value, ref value2);
		if (value is IComparable && value2 is IComparable)
		{
			return ((IComparable)value).CompareTo(value2) <= 0;
		}
		return null;
	}

	private bool? Between(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 3);
		object value = GetValue(context, operands[0], target);
		object value2 = GetValue(context, operands[1], target);
		object value3 = GetValue(context, operands[2], target);
		object value4 = value;
		DoImplicitConversion(ref value4, ref value2);
		bool? flag = null;
		if (value4 is IComparable && value2 is IComparable)
		{
			if (((IComparable)value4).CompareTo(value2) < 0)
			{
				return false;
			}
			flag = true;
		}
		value4 = value;
		DoImplicitConversion(ref value4, ref value3);
		if (value4 is IComparable && value3 is IComparable)
		{
			if (((IComparable)value4).CompareTo(value3) > 0)
			{
				return false;
			}
			return flag.HasValue;
		}
		return null;
	}

	private bool? InList(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 0);
		object value = GetValue(context, operands[0], target);
		for (int i = 1; i < operands.Length; i++)
		{
			object value2 = value;
			object value3 = GetValue(context, operands[i], target);
			DoImplicitConversion(ref value2, ref value3);
			if (IsEqual(value2, value3))
			{
				return true;
			}
		}
		return false;
	}

	private bool Like(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		LocalizedText localizedText = value as LocalizedText;
		string text = ((!(localizedText != null)) ? (value as string) : localizedText.Text);
		object value2 = GetValue(context, operands[1], target);
		LocalizedText localizedText2 = value2 as LocalizedText;
		string text2 = ((!(localizedText2 != null)) ? (value2 as string) : localizedText2.Text);
		if (text == null || text2 == null)
		{
			return false;
		}
		return Match(text, text2);
	}

	private bool IsNull(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 1);
		if (GetValue(context, operands[0], target) == null)
		{
			return true;
		}
		return false;
	}

	private object Cast(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 2);
		object value = GetValue(context, operands[0], target);
		if (value == null)
		{
			return null;
		}
		NodeId nodeId = GetValue(context, operands[1], target) as NodeId;
		if (nodeId == null)
		{
			return null;
		}
		BuiltInType builtInType = GetBuiltInType(nodeId);
		return Cast(value, builtInType);
	}

	private bool OfType(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		FilterOperand[] operands = GetOperands(element, 1);
		NodeId nodeId = GetValue(context, operands[0], target) as NodeId;
		if (nodeId == null || target == null)
		{
			return false;
		}
		try
		{
			return target.IsTypeOf(context, nodeId);
		}
		catch
		{
			return false;
		}
	}

	private bool InView(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		if (!(target is IAdvancedFilterTarget advancedFilterTarget))
		{
			return false;
		}
		FilterOperand[] operands = GetOperands(element, 1);
		NodeId nodeId = GetValue(context, operands[0], target) as NodeId;
		if (nodeId == null || target == null)
		{
			return false;
		}
		try
		{
			return advancedFilterTarget.IsInView(context, nodeId);
		}
		catch
		{
			return false;
		}
	}

	private bool RelatedTo(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		return RelatedTo(context, target, element, null);
	}

	private bool RelatedTo(FilterContext context, IFilterTarget target, ContentFilterElement element, NodeId intermediateNodeId)
	{
		if (!(target is IAdvancedFilterTarget advancedFilterTarget))
		{
			return false;
		}
		FilterOperand[] operands = GetOperands(element, 6);
		NodeId nodeId = GetValue(context, operands[0], target) as NodeId;
		if (nodeId == null)
		{
			return false;
		}
		NodeId nodeId2 = GetValue(context, operands[2], target) as NodeId;
		if (nodeId2 == null)
		{
			return false;
		}
		int? num = 1;
		object value = GetValue(context, operands[3], target);
		if (value != null)
		{
			num = Cast(value, BuiltInType.Int32) as int?;
			if (!num.HasValue)
			{
				num = 1;
			}
		}
		bool? flag = true;
		object value2 = GetValue(context, operands[4], target);
		if (value2 != null)
		{
			flag = Cast(value2, BuiltInType.Boolean) as bool?;
			if (!flag.HasValue)
			{
				flag = true;
			}
		}
		bool? flag2 = true;
		value2 = GetValue(context, operands[5], target);
		if (value2 != null)
		{
			flag2 = Cast(value2, BuiltInType.Boolean) as bool?;
			if (!flag2.HasValue)
			{
				flag2 = true;
			}
		}
		NodeId nodeId3 = null;
		if (operands[1] is ElementOperand elementOperand)
		{
			if (elementOperand.Index >= Elements.Count)
			{
				return false;
			}
			ContentFilterElement contentFilterElement = Elements[(int)elementOperand.Index];
			if (contentFilterElement.FilterOperator == FilterOperator.RelatedTo)
			{
				FilterOperand operand = ExtensionObject.ToEncodeable(contentFilterElement.FilterOperands[0]) as FilterOperand;
				nodeId3 = GetValue(context, operand, target) as NodeId;
				if (nodeId3 == null)
				{
					return false;
				}
				IList<NodeId> relatedNodes = advancedFilterTarget.GetRelatedNodes(context, intermediateNodeId, nodeId, nodeId3, nodeId2, num.Value, flag.Value, flag2.Value);
				if (relatedNodes == null || relatedNodes.Count == 0)
				{
					return false;
				}
				for (int i = 0; i < relatedNodes.Count; i++)
				{
					if (RelatedTo(context, target, contentFilterElement, relatedNodes[i]))
					{
						return true;
					}
				}
				return false;
			}
		}
		if (nodeId3 == null)
		{
			nodeId3 = GetValue(context, operands[1], target) as NodeId;
			if (nodeId3 == null)
			{
				return false;
			}
		}
		try
		{
			return advancedFilterTarget.IsRelatedTo(context, intermediateNodeId, nodeId, nodeId3, nodeId2, num.Value, flag.Value, flag2.Value);
		}
		catch
		{
			return false;
		}
	}

	private object BitwiseAnd(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		var (obj3, obj4) = GetBitwiseOperands(context, target, element);
		if (obj3 == null || obj4 == null)
		{
			return null;
		}
		Type type = obj3.GetType();
		if (type == typeof(byte))
		{
			return (byte)obj3 & (byte)obj4;
		}
		if (type == typeof(sbyte))
		{
			return (sbyte)obj3 & (sbyte)obj4;
		}
		if (type == typeof(short))
		{
			return (short)obj3 & (short)obj4;
		}
		if (type == typeof(ushort))
		{
			return (ushort)obj3 & (ushort)obj4;
		}
		if (type == typeof(int))
		{
			return (int)obj3 & (int)obj4;
		}
		if (type == typeof(uint))
		{
			return (uint)obj3 & (uint)obj4;
		}
		if (type == typeof(long))
		{
			return (long)obj3 & (long)obj4;
		}
		if (type == typeof(ulong))
		{
			return (ulong)obj3 & (ulong)obj4;
		}
		return null;
	}

	private object BitwiseOr(FilterContext context, IFilterTarget target, ContentFilterElement element)
	{
		var (obj3, obj4) = GetBitwiseOperands(context, target, element);
		if (obj3 == null || obj4 == null)
		{
			return null;
		}
		Type type = obj3.GetType();
		if (type == typeof(byte))
		{
			return (byte)obj3 | (byte)obj4;
		}
		if (type == typeof(sbyte))
		{
			return (sbyte)obj3 | (sbyte)obj4;
		}
		if (type == typeof(short))
		{
			return (short)obj3 | (short)obj4;
		}
		if (type == typeof(ushort))
		{
			return (ushort)obj3 | (ushort)obj4;
		}
		if (type == typeof(int))
		{
			return (int)obj3 | (int)obj4;
		}
		if (type == typeof(uint))
		{
			return (uint)obj3 | (uint)obj4;
		}
		if (type == typeof(long))
		{
			return (long)obj3 | (long)obj4;
		}
		if (type == typeof(ulong))
		{
			return (ulong)obj3 | (ulong)obj4;
		}
		return null;
	}
}
