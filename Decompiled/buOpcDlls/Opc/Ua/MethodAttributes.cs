using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MethodAttributes : NodeAttributes
{
	private bool m_executable;

	private bool m_userExecutable;

	[DataMember(Name = "Executable", IsRequired = false, Order = 1)]
	public bool Executable
	{
		get
		{
			return m_executable;
		}
		set
		{
			m_executable = value;
		}
	}

	[DataMember(Name = "UserExecutable", IsRequired = false, Order = 2)]
	public bool UserExecutable
	{
		get
		{
			return m_userExecutable;
		}
		set
		{
			m_userExecutable = value;
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.MethodAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.MethodAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.MethodAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.MethodAttributes_Encoding_DefaultJson;

	public MethodAttributes()
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
		m_executable = true;
		m_userExecutable = true;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("Executable", Executable);
		encoder.WriteBoolean("UserExecutable", UserExecutable);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Executable = decoder.ReadBoolean("Executable");
		UserExecutable = decoder.ReadBoolean("UserExecutable");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is MethodAttributes methodAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_executable, methodAttributes.m_executable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userExecutable, methodAttributes.m_userExecutable))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (MethodAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MethodAttributes obj = (MethodAttributes)base.MemberwiseClone();
		obj.m_executable = (bool)Utils.Clone(m_executable);
		obj.m_userExecutable = (bool)Utils.Clone(m_userExecutable);
		return obj;
	}
}
