// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeleteRawModifiedDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteRawModifiedDetails : HistoryUpdateDetails
{
  private bool m_isDeleteModified;
  private DateTime m_startTime;
  private DateTime m_endTime;

  public DeleteRawModifiedDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_isDeleteModified = true;
    this.m_startTime = DateTime.MinValue;
    this.m_endTime = DateTime.MinValue;
  }

  [DataMember(Name = "IsDeleteModified", IsRequired = false, Order = 1)]
  public bool IsDeleteModified
  {
    get => this.m_isDeleteModified;
    set => this.m_isDeleteModified = value;
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 2)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "EndTime", IsRequired = false, Order = 3)]
  public DateTime EndTime
  {
    get => this.m_endTime;
    set => this.m_endTime = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DeleteRawModifiedDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DeleteRawModifiedDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsDeleteModified", this.IsDeleteModified);
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteDateTime("EndTime", this.EndTime);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsDeleteModified = decoder.ReadBoolean("IsDeleteModified");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.EndTime = decoder.ReadDateTime("EndTime");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DeleteRawModifiedDetails rawModifiedDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isDeleteModified, (object) rawModifiedDetails.m_isDeleteModified) && Utils.IsEqual(this.m_startTime, rawModifiedDetails.m_startTime) && Utils.IsEqual(this.m_endTime, rawModifiedDetails.m_endTime) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DeleteRawModifiedDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DeleteRawModifiedDetails rawModifiedDetails = (DeleteRawModifiedDetails) base.MemberwiseClone();
    rawModifiedDetails.m_isDeleteModified = (bool) Utils.Clone((object) this.m_isDeleteModified);
    rawModifiedDetails.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    rawModifiedDetails.m_endTime = (DateTime) Utils.Clone((object) this.m_endTime);
    return (object) rawModifiedDetails;
  }
}
