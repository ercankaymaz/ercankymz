using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ElementOperand : FilterOperand, IFormattable
{
	private uint m_index;

	[DataMember(Name = "Index", IsRequired = false, Order = 1)]
	public uint Index
	{
		get
		{
			return m_index;
		}
		set
		{
			m_index = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ElementOperand;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ElementOperand_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ElementOperand_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ElementOperand_Encoding_DefaultJson;

	public ElementOperand()
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
		m_index = 0u;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("Index", Index);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Index = decoder.ReadUInt32("Index");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ElementOperand elementOperand))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_index, elementOperand.m_index))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ElementOperand)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ElementOperand obj = (ElementOperand)base.MemberwiseClone();
		obj.m_index = (uint)Utils.Clone(m_index);
		return obj;
	}

	public ElementOperand(uint index)
	{
		m_index = index;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return $"[{m_index}]";
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public override ServiceResult Validate(FilterContext context, int index)
	{
		if (index < 0)
		{
			return ServiceResult.Create(2152267776u, "ElementOperand specifies an Index that is less than zero ({0}).", index);
		}
		if (m_index <= index)
		{
			return ServiceResult.Create(2152267776u, "ElementOperand references an element that precedes it in the ContentFilter.", m_index);
		}
		if (m_index >= base.Parent.Parent.Elements.Count)
		{
			return ServiceResult.Create(2152267776u, "ElementOperand references an element that does not exist.", m_index);
		}
		return ServiceResult.Good;
	}

	public override string ToString(INodeTable nodeTable)
	{
		return Utils.Format("Element[{0}]", Index);
	}
}
