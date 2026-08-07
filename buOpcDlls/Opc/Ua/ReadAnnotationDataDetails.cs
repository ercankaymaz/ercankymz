// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadAnnotationDataDetails
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
public class ReadAnnotationDataDetails : HistoryReadDetails
{
  private DateTimeCollection m_reqTimes;

  public ReadAnnotationDataDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_reqTimes = new DateTimeCollection();

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

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadAnnotationDataDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAnnotationDataDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAnnotationDataDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadAnnotationDataDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTimeArray("ReqTimes", (IList<DateTime>) this.ReqTimes);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ReqTimes = decoder.ReadDateTimeArray("ReqTimes");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReadAnnotationDataDetails annotationDataDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_reqTimes, (object) annotationDataDetails.m_reqTimes) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReadAnnotationDataDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadAnnotationDataDetails annotationDataDetails = (ReadAnnotationDataDetails) base.MemberwiseClone();
    annotationDataDetails.m_reqTimes = (DateTimeCollection) Utils.Clone((object) this.m_reqTimes);
    return (object) annotationDataDetails;
  }
}
