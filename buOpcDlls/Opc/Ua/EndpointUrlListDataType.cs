// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EndpointUrlListDataType
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
public class EndpointUrlListDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private StringCollection m_endpointUrlList;

  public EndpointUrlListDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_endpointUrlList = new StringCollection();

  [DataMember(Name = "EndpointUrlList", IsRequired = false, Order = 1)]
  public StringCollection EndpointUrlList
  {
    get => this.m_endpointUrlList;
    set
    {
      this.m_endpointUrlList = value;
      if (value != null)
        return;
      this.m_endpointUrlList = new StringCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EndpointUrlListDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointUrlListDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointUrlListDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EndpointUrlListDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStringArray("EndpointUrlList", (IList<string>) this.EndpointUrlList);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EndpointUrlList = decoder.ReadStringArray("EndpointUrlList");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is EndpointUrlListDataType endpointUrlListDataType && Utils.IsEqual((object) this.m_endpointUrlList, (object) endpointUrlListDataType.m_endpointUrlList);
  }

  public virtual object Clone() => (object) (EndpointUrlListDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EndpointUrlListDataType endpointUrlListDataType = (EndpointUrlListDataType) base.MemberwiseClone();
    endpointUrlListDataType.m_endpointUrlList = (StringCollection) Utils.Clone((object) this.m_endpointUrlList);
    return (object) endpointUrlListDataType;
  }
}
