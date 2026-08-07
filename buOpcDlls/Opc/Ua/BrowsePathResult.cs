// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowsePathResult
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
public class BrowsePathResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private BrowsePathTargetCollection m_targets;

  public BrowsePathResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_targets = new BrowsePathTargetCollection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "Targets", IsRequired = false, Order = 2)]
  public BrowsePathTargetCollection Targets
  {
    get => this.m_targets;
    set
    {
      this.m_targets = value;
      if (value != null)
        return;
      this.m_targets = new BrowsePathTargetCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.BrowsePathResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrowsePathResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteEncodeableArray("Targets", (IList<IEncodeable>) this.Targets.ToArray(), typeof (BrowsePathTarget));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.Targets = (BrowsePathTargetCollection) (BrowsePathTarget[]) decoder.ReadEncodeableArray("Targets", typeof (BrowsePathTarget));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is BrowsePathResult browsePathResult && Utils.IsEqual((object) this.m_statusCode, (object) browsePathResult.m_statusCode) && Utils.IsEqual((object) this.m_targets, (object) browsePathResult.m_targets);
  }

  public virtual object Clone() => (object) (BrowsePathResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    BrowsePathResult browsePathResult = (BrowsePathResult) base.MemberwiseClone();
    browsePathResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    browsePathResult.m_targets = (BrowsePathTargetCollection) Utils.Clone((object) this.m_targets);
    return (object) browsePathResult;
  }
}
