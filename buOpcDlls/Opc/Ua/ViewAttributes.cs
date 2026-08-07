// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ViewAttributes
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
public class ViewAttributes : NodeAttributes
{
  private bool m_containsNoLoops;
  private byte m_eventNotifier;

  public ViewAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_containsNoLoops = true;
    this.m_eventNotifier = (byte) 0;
  }

  [DataMember(Name = "ContainsNoLoops", IsRequired = false, Order = 1)]
  public bool ContainsNoLoops
  {
    get => this.m_containsNoLoops;
    set => this.m_containsNoLoops = value;
  }

  [DataMember(Name = "EventNotifier", IsRequired = false, Order = 2)]
  public byte EventNotifier
  {
    get => this.m_eventNotifier;
    set => this.m_eventNotifier = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ViewAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ViewAttributes_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("ContainsNoLoops", this.ContainsNoLoops);
    encoder.WriteByte("EventNotifier", this.EventNotifier);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ContainsNoLoops = decoder.ReadBoolean("ContainsNoLoops");
    this.EventNotifier = decoder.ReadByte("EventNotifier");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ViewAttributes viewAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_containsNoLoops, (object) viewAttributes.m_containsNoLoops) && Utils.IsEqual((object) this.m_eventNotifier, (object) viewAttributes.m_eventNotifier) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ViewAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ViewAttributes viewAttributes = (ViewAttributes) base.MemberwiseClone();
    viewAttributes.m_containsNoLoops = (bool) Utils.Clone((object) this.m_containsNoLoops);
    viewAttributes.m_eventNotifier = (byte) Utils.Clone((object) this.m_eventNotifier);
    return (object) viewAttributes;
  }
}
