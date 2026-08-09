using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilterElement : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
	private FilterOperator m_filterOperator;

	private ExtensionObjectCollection m_filterOperands;

	private ContentFilter m_parent;

	[DataMember(Name = "FilterOperator", IsRequired = false, Order = 1)]
	public FilterOperator FilterOperator
	{
		get
		{
			return m_filterOperator;
		}
		set
		{
			m_filterOperator = value;
		}
	}

	[DataMember(Name = "FilterOperands", IsRequired = false, Order = 2)]
	public ExtensionObjectCollection FilterOperands
	{
		get
		{
			return m_filterOperands;
		}
		set
		{
			m_filterOperands = value;
			if (value == null)
			{
				m_filterOperands = new ExtensionObjectCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ContentFilterElement;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ContentFilterElement_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ContentFilterElement_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ContentFilterElement_Encoding_DefaultJson;

	public ContentFilter Parent
	{
		get
		{
			return m_parent;
		}
		internal set
		{
			m_parent = value;
		}
	}

	public ContentFilterElement()
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
		m_filterOperator = FilterOperator.Equals;
		m_filterOperands = new ExtensionObjectCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("FilterOperator", FilterOperator);
		encoder.WriteExtensionObjectArray("FilterOperands", FilterOperands);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		FilterOperator = (FilterOperator)(object)decoder.ReadEnumerated("FilterOperator", typeof(FilterOperator));
		FilterOperands = decoder.ReadExtensionObjectArray("FilterOperands");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ContentFilterElement contentFilterElement))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filterOperator, contentFilterElement.m_filterOperator))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filterOperands, contentFilterElement.m_filterOperands))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ContentFilterElement)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterElement obj = (ContentFilterElement)base.MemberwiseClone();
		obj.m_filterOperator = (FilterOperator)Utils.Clone(m_filterOperator);
		obj.m_filterOperands = (ExtensionObjectCollection)Utils.Clone(m_filterOperands);
		return obj;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(formatProvider, "<{0}", FilterOperator);
			for (int i = 0; i < FilterOperands.Count; i++)
			{
				if (FilterOperands[i] != null)
				{
					stringBuilder.AppendFormat(formatProvider, ", {0}", FilterOperands[i].Body);
				}
				else
				{
					stringBuilder.AppendFormat(formatProvider, ", (null)");
				}
			}
			stringBuilder.AppendFormat(formatProvider, ">");
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public virtual ContentFilter.ElementResult Validate(FilterContext context, int index)
	{
		ContentFilter.ElementResult elementResult = new ContentFilter.ElementResult(null);
		int num = -1;
		switch (m_filterOperator)
		{
		case FilterOperator.IsNull:
		case FilterOperator.Not:
		case FilterOperator.InView:
		case FilterOperator.OfType:
			num = 1;
			break;
		case FilterOperator.Equals:
		case FilterOperator.GreaterThan:
		case FilterOperator.LessThan:
		case FilterOperator.GreaterThanOrEqual:
		case FilterOperator.LessThanOrEqual:
		case FilterOperator.Like:
		case FilterOperator.And:
		case FilterOperator.Or:
		case FilterOperator.Cast:
		case FilterOperator.BitwiseAnd:
		case FilterOperator.BitwiseOr:
			num = 2;
			break;
		case FilterOperator.Between:
			num = 3;
			break;
		case FilterOperator.RelatedTo:
			num = 6;
			break;
		case FilterOperator.InList:
			num = -1;
			break;
		}
		if (num != -1)
		{
			if (num != m_filterOperands.Count)
			{
				elementResult.Status = ServiceResult.Create(2152136704u, "ContentFilterElement does not have the correct number of operands (Operator={0} OperandCount={1}).", m_filterOperator, num);
				return elementResult;
			}
		}
		else if (m_filterOperands.Count < 2)
		{
			elementResult.Status = ServiceResult.Create(2152136704u, "ContentFilterElement does not have the correct number of operands (Operator={0} OperandCount={1}).", m_filterOperator, m_filterOperands.Count);
			return elementResult;
		}
		bool flag = false;
		for (int i = 0; i < m_filterOperands.Count; i++)
		{
			ServiceResult serviceResult = null;
			ExtensionObject extensionObject = m_filterOperands[i];
			if (ExtensionObject.IsNull(extensionObject))
			{
				serviceResult = ServiceResult.Create(2152136704u, "The FilterOperand cannot be Null.");
				elementResult.OperandResults.Add(serviceResult);
				flag = true;
				continue;
			}
			if (!(extensionObject.Body is FilterOperand filterOperand))
			{
				serviceResult = ServiceResult.Create(2152136704u, "The FilterOperand is not a supported type ({0}).", extensionObject.Body.GetType());
				elementResult.OperandResults.Add(serviceResult);
				flag = true;
				continue;
			}
			filterOperand.Parent = this;
			serviceResult = filterOperand.Validate(context, index);
			if (ServiceResult.IsBad(serviceResult))
			{
				elementResult.OperandResults.Add(serviceResult);
				flag = true;
			}
			else
			{
				elementResult.OperandResults.Add(null);
			}
		}
		if (flag)
		{
			elementResult.Status = 2152202240u;
		}
		else
		{
			elementResult.OperandResults.Clear();
		}
		return elementResult;
	}

	public List<FilterOperand> GetOperands()
	{
		List<FilterOperand> list = new List<FilterOperand>(FilterOperands.Count);
		foreach (ExtensionObject filterOperand in FilterOperands)
		{
			if (!ExtensionObject.IsNull(filterOperand) && filterOperand.Body is FilterOperand item)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public void SetOperands(IEnumerable<FilterOperand> operands)
	{
		FilterOperands.Clear();
		if (operands == null)
		{
			return;
		}
		foreach (FilterOperand operand in operands)
		{
			if (operand != null)
			{
				FilterOperands.Add(new ExtensionObject(operand));
			}
		}
	}

	public virtual string ToString(INodeTable nodeTable)
	{
		List<FilterOperand> operands = GetOperands();
		string text = ((operands.Count > 0) ? operands[0].ToString(nodeTable) : null);
		string text2 = ((operands.Count > 1) ? operands[1].ToString(nodeTable) : null);
		string text3 = ((operands.Count > 2) ? operands[2].ToString(nodeTable) : null);
		StringBuilder stringBuilder = new StringBuilder();
		switch (FilterOperator)
		{
		case FilterOperator.IsNull:
		case FilterOperator.Not:
		case FilterOperator.InView:
		case FilterOperator.OfType:
			stringBuilder.AppendFormat("{0} '{1}'", FilterOperator, text);
			break;
		case FilterOperator.Equals:
		case FilterOperator.GreaterThan:
		case FilterOperator.LessThan:
		case FilterOperator.GreaterThanOrEqual:
		case FilterOperator.LessThanOrEqual:
		case FilterOperator.Like:
		case FilterOperator.And:
		case FilterOperator.Or:
		case FilterOperator.BitwiseAnd:
		case FilterOperator.BitwiseOr:
			stringBuilder.AppendFormat("'{1}' {0} '{2}'", FilterOperator, text, text2);
			break;
		case FilterOperator.Between:
			stringBuilder.AppendFormat("'{1}' <= '{0}' <= '{2}'", text, text2, text3);
			break;
		case FilterOperator.Cast:
			stringBuilder.AppendFormat("({1}){0}", text, text2);
			break;
		case FilterOperator.InList:
		{
			stringBuilder.AppendFormat("'{0}' in ", text);
			stringBuilder.Append('{');
			for (int i = 1; i < operands.Count; i++)
			{
				stringBuilder.AppendFormat("'{0}'", operands[i].ToString());
				if (i < operands.Count - 1)
				{
					stringBuilder.Append(", ");
				}
			}
			stringBuilder.Append('}');
			break;
		}
		case FilterOperator.RelatedTo:
		{
			stringBuilder.AppendFormat("'{0}' ", text);
			string arg = text2;
			if (operands.Count > 1 && operands[1] is LiteralOperand literalOperand)
			{
				INode node = nodeTable.Find(literalOperand.Value.Value as NodeId);
				if (node != null)
				{
					arg = Utils.Format("{0}", node);
				}
			}
			stringBuilder.AppendFormat("{0} '{1}'", arg, text2);
			if (text3 != null)
			{
				stringBuilder.AppendFormat("Hops='{0}'", text3);
			}
			break;
		}
		}
		return stringBuilder.ToString();
	}
}
