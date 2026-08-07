// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ObjectTypeAttributes
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
public class ObjectTypeAttributes : NodeAttributes
{
  private bool m_isAbstract;

  public ObjectTypeAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_isAbstract = true;

  [DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set => this.m_isAbstract = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ObjectTypeAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeAttributes_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsAbstract", this.IsAbstract);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ObjectTypeAttributes objectTypeAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isAbstract, (object) objectTypeAttributes.m_isAbstract) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ObjectTypeAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ObjectTypeAttributes objectTypeAttributes = (ObjectTypeAttributes) base.MemberwiseClone();
    objectTypeAttributes.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    return (object) objectTypeAttributes;
  }
}
