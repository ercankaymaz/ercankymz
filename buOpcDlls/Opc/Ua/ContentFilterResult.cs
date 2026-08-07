// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ContentFilterResult
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
public class ContentFilterResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private ContentFilterElementResultCollection m_elementResults;
  private DiagnosticInfoCollection m_elementDiagnosticInfos;

  public ContentFilterResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_elementResults = new ContentFilterElementResultCollection();
    this.m_elementDiagnosticInfos = new DiagnosticInfoCollection();
  }

  [DataMember(Name = "ElementResults", IsRequired = false, Order = 1)]
  public ContentFilterElementResultCollection ElementResults
  {
    get => this.m_elementResults;
    set
    {
      this.m_elementResults = value;
      if (value != null)
        return;
      this.m_elementResults = new ContentFilterElementResultCollection();
    }
  }

  [DataMember(Name = "ElementDiagnosticInfos", IsRequired = false, Order = 2)]
  public DiagnosticInfoCollection ElementDiagnosticInfos
  {
    get => this.m_elementDiagnosticInfos;
    set
    {
      this.m_elementDiagnosticInfos = value;
      if (value != null)
        return;
      this.m_elementDiagnosticInfos = new DiagnosticInfoCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ContentFilterResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ContentFilterResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("ElementResults", (IList<IEncodeable>) this.ElementResults.ToArray(), typeof (ContentFilterElementResult));
    encoder.WriteDiagnosticInfoArray("ElementDiagnosticInfos", (IList<DiagnosticInfo>) this.ElementDiagnosticInfos);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ElementResults = (ContentFilterElementResultCollection) (ContentFilterElementResult[]) decoder.ReadEncodeableArray("ElementResults", typeof (ContentFilterElementResult));
    this.ElementDiagnosticInfos = decoder.ReadDiagnosticInfoArray("ElementDiagnosticInfos");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ContentFilterResult contentFilterResult && Utils.IsEqual((object) this.m_elementResults, (object) contentFilterResult.m_elementResults) && Utils.IsEqual((object) this.m_elementDiagnosticInfos, (object) contentFilterResult.m_elementDiagnosticInfos);
  }

  public virtual object Clone() => (object) (ContentFilterResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ContentFilterResult contentFilterResult = (ContentFilterResult) base.MemberwiseClone();
    contentFilterResult.m_elementResults = (ContentFilterElementResultCollection) Utils.Clone((object) this.m_elementResults);
    contentFilterResult.m_elementDiagnosticInfos = (DiagnosticInfoCollection) Utils.Clone((object) this.m_elementDiagnosticInfos);
    return (object) contentFilterResult;
  }
}
