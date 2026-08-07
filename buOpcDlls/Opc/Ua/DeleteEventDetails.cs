// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteEventDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteEventDetails : HistoryUpdateDetails
{
  private ByteStringCollection m_eventIds;

  public DeleteEventDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_eventIds = new ByteStringCollection();

  [DataMember(Name = "EventIds", IsRequired = false, Order = 1)]
  public ByteStringCollection EventIds
  {
    get => this.m_eventIds;
    set
    {
      this.m_eventIds = value;
      if (value != null)
        return;
      this.m_eventIds = new ByteStringCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DeleteEventDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteEventDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteEventDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteEventDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByteStringArray("EventIds", (IList<byte[]>) this.EventIds);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EventIds = decoder.ReadByteStringArray("EventIds");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DeleteEventDetails deleteEventDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_eventIds, (object) deleteEventDetails.m_eventIds) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DeleteEventDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteEventDetails deleteEventDetails = (DeleteEventDetails) base.MemberwiseClone();
    deleteEventDetails.m_eventIds = (ByteStringCollection) Utils.Clone((object) this.m_eventIds);
    return (object) deleteEventDetails;
  }
}
