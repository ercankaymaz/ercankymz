// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramWriterGroupTransportDataType
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
public class DatagramWriterGroupTransportDataType : WriterGroupTransportDataType
{
  private byte m_messageRepeatCount;
  private double m_messageRepeatDelay;

  public DatagramWriterGroupTransportDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_messageRepeatCount = (byte) 0;
    this.m_messageRepeatDelay = 0.0;
  }

  [DataMember(Name = "MessageRepeatCount", IsRequired = false, Order = 1)]
  public byte MessageRepeatCount
  {
    get => this.m_messageRepeatCount;
    set => this.m_messageRepeatCount = value;
  }

  [DataMember(Name = "MessageRepeatDelay", IsRequired = false, Order = 2)]
  public double MessageRepeatDelay
  {
    get => this.m_messageRepeatDelay;
    set => this.m_messageRepeatDelay = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.DatagramWriterGroupTransportDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramWriterGroupTransportDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteByte("MessageRepeatCount", this.MessageRepeatCount);
    encoder.WriteDouble("MessageRepeatDelay", this.MessageRepeatDelay);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.MessageRepeatCount = decoder.ReadByte("MessageRepeatCount");
    this.MessageRepeatDelay = decoder.ReadDouble("MessageRepeatDelay");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DatagramWriterGroupTransportDataType transportDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_messageRepeatCount, (object) transportDataType.m_messageRepeatCount) && Utils.IsEqual((object) this.m_messageRepeatDelay, (object) transportDataType.m_messageRepeatDelay) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (DatagramWriterGroupTransportDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DatagramWriterGroupTransportDataType transportDataType = (DatagramWriterGroupTransportDataType) base.MemberwiseClone();
    transportDataType.m_messageRepeatCount = (byte) Utils.Clone((object) this.m_messageRepeatCount);
    transportDataType.m_messageRepeatDelay = (double) Utils.Clone((object) this.m_messageRepeatDelay);
    return (object) transportDataType;
  }
}
