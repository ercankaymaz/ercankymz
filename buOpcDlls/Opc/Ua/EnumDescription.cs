// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumDescription : DataTypeDescription
{
  private EnumDefinition m_enumDefinition;
  private byte m_builtInType;

  public EnumDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_enumDefinition = new EnumDefinition();
    this.m_builtInType = (byte) 0;
  }

  [DataMember(Name = "EnumDefinition", IsRequired = false, Order = 1)]
  public EnumDefinition EnumDefinition
  {
    get => this.m_enumDefinition;
    set
    {
      this.m_enumDefinition = value;
      if (value != null)
        return;
      this.m_enumDefinition = new EnumDefinition();
    }
  }

  [DataMember(Name = "BuiltInType", IsRequired = false, Order = 2)]
  public byte BuiltInType
  {
    get => this.m_builtInType;
    set => this.m_builtInType = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EnumDescription;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDescription_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDescription_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDescription_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("EnumDefinition", (IEncodeable) this.EnumDefinition, typeof (EnumDefinition));
    encoder.WriteByte("BuiltInType", this.BuiltInType);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EnumDefinition = (EnumDefinition) decoder.ReadEncodeable("EnumDefinition", typeof (EnumDefinition));
    this.BuiltInType = decoder.ReadByte("BuiltInType");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is EnumDescription enumDescription && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_enumDefinition, (object) enumDescription.m_enumDefinition) && Utils.IsEqual((object) this.m_builtInType, (object) enumDescription.m_builtInType) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (EnumDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumDescription enumDescription = (EnumDescription) base.MemberwiseClone();
    enumDescription.m_enumDefinition = (EnumDefinition) Utils.Clone((object) this.m_enumDefinition);
    enumDescription.m_builtInType = (byte) Utils.Clone((object) this.m_builtInType);
    return (object) enumDescription;
  }
}
