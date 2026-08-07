// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ObjectAttributes
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
public class ObjectAttributes : NodeAttributes
{
  private byte m_eventNotifier;

  public ObjectAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_eventNotifier = (byte) 0;

  [DataMember(Name = "EventNotifier", IsRequired = false, Order = 1)]
  public byte EventNotifier
  {
    get => this.m_eventNotifier;
    set => this.m_eventNotifier = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ObjectAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectAttributes_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByte("EventNotifier", this.EventNotifier);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EventNotifier = decoder.ReadByte("EventNotifier");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ObjectAttributes objectAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_eventNotifier, (object) objectAttributes.m_eventNotifier) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ObjectAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ObjectAttributes objectAttributes = (ObjectAttributes) base.MemberwiseClone();
    objectAttributes.m_eventNotifier = (byte) Utils.Clone((object) this.m_eventNotifier);
    return (object) objectAttributes;
  }
}
