// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseResult
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
public class BrowseResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private byte[] m_continuationPoint;
  private ReferenceDescriptionCollection m_references;

  public BrowseResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_continuationPoint = (byte[]) null;
    this.m_references = new ReferenceDescriptionCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 2)]
  public byte[] ContinuationPoint
  {
    get => this.m_continuationPoint;
    set => this.m_continuationPoint = value;
  }

  [DataMember(Name = "References", IsRequired = false, Order = 3)]
  public ReferenceDescriptionCollection References
  {
    get => this.m_references;
    set
    {
      this.m_references = value;
      if (value != null)
        return;
      this.m_references = new ReferenceDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowseResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowseResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteByteString("ContinuationPoint", this.ContinuationPoint);
    encoder.WriteEncodeableArray("References", (IList<IEncodeable>) this.References.ToArray(), typeof (ReferenceDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
    this.References = (ReferenceDescriptionCollection) (ReferenceDescription[]) decoder.ReadEncodeableArray("References", typeof (ReferenceDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowseResult browseResult && Utils.IsEqual((object) this.m_statusCode, (object) browseResult.m_statusCode) && Utils.IsEqual((object) this.m_continuationPoint, (object) browseResult.m_continuationPoint) && Utils.IsEqual((object) this.m_references, (object) browseResult.m_references);
  }

  public virtual object Clone() => (object) (BrowseResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowseResult browseResult = (BrowseResult) base.MemberwiseClone();
    browseResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    browseResult.m_continuationPoint = (byte[]) Utils.Clone((object) this.m_continuationPoint);
    browseResult.m_references = (ReferenceDescriptionCollection) Utils.Clone((object) this.m_references);
    return (object) browseResult;
  }
}
