// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadAtTimeDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadAtTimeDetails : HistoryReadDetails
{
  private DateTimeCollection m_reqTimes;
  private bool m_useSimpleBounds;

  public ReadAtTimeDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_reqTimes = new DateTimeCollection();
    this.m_useSimpleBounds = true;
  }

  [DataMember(Name = "ReqTimes", IsRequired = false, Order = 1)]
  public DateTimeCollection ReqTimes
  {
    get => this.m_reqTimes;
    set
    {
      this.m_reqTimes = value;
      if (value != null)
        return;
      this.m_reqTimes = new DateTimeCollection();
    }
  }

  [DataMember(Name = "UseSimpleBounds", IsRequired = false, Order = 2)]
  public bool UseSimpleBounds
  {
    get => this.m_useSimpleBounds;
    set => this.m_useSimpleBounds = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadAtTimeDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAtTimeDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAtTimeDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAtTimeDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTimeArray("ReqTimes", (IList<DateTime>) this.ReqTimes);
    encoder.WriteBoolean("UseSimpleBounds", this.UseSimpleBounds);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ReqTimes = decoder.ReadDateTimeArray("ReqTimes");
    this.UseSimpleBounds = decoder.ReadBoolean("UseSimpleBounds");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReadAtTimeDetails readAtTimeDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_reqTimes, (object) readAtTimeDetails.m_reqTimes) && Utils.IsEqual((object) this.m_useSimpleBounds, (object) readAtTimeDetails.m_useSimpleBounds) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReadAtTimeDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadAtTimeDetails readAtTimeDetails = (ReadAtTimeDetails) base.MemberwiseClone();
    readAtTimeDetails.m_reqTimes = (DateTimeCollection) Utils.Clone((object) this.m_reqTimes);
    readAtTimeDetails.m_useSimpleBounds = (bool) Utils.Clone((object) this.m_useSimpleBounds);
    return (object) readAtTimeDetails;
  }
}
