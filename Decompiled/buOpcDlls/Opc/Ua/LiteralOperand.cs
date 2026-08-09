using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class LiteralOperand : FilterOperand, IFormattable
{
	private Variant m_value;

	[DataMember(Name = "Value", IsRequired = false, Order = 1)]
	public Variant Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.LiteralOperand;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.LiteralOperand_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.LiteralOperand_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.LiteralOperand_Encoding_DefaultJson;

	public LiteralOperand()
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
		m_value = Variant.Null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteVariant("Value", Value);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Value = decoder.ReadVariant("Value");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is LiteralOperand literalOperand))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, literalOperand.m_value))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (LiteralOperand)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		LiteralOperand obj = (LiteralOperand)base.MemberwiseClone();
		obj.m_value = (Variant)Utils.Clone(m_value);
		return obj;
	}

	public LiteralOperand(object value)
	{
		m_value = new Variant(value);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return $"{m_value}";
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public override ServiceResult Validate(FilterContext context, int index)
	{
		if (m_value.Value == null)
		{
			return ServiceResult.Create(2152136704u, "LiteralOperand specifies a null Value.");
		}
		return ServiceResult.Good;
	}

	public override string ToString(INodeTable nodeTable)
	{
		ExpandedNodeId expandedNodeId = Value.Value as ExpandedNodeId;
		if (expandedNodeId == null)
		{
			expandedNodeId = Value.Value as NodeId;
		}
		if (expandedNodeId != null)
		{
			INode node = nodeTable.Find(expandedNodeId);
			if (node != null)
			{
				return Utils.Format("{0} ({1})", node, expandedNodeId);
			}
		}
		return Utils.Format("{0}", Value);
	}
}
