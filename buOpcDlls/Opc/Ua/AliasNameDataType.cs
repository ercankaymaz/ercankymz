// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AliasNameDataType
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
public class AliasNameDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private QualifiedName m_aliasName;
  private ExpandedNodeIdCollection m_referencedNodes;

  public AliasNameDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_aliasName = (QualifiedName) null;
    this.m_referencedNodes = new ExpandedNodeIdCollection();
  }

  [DataMember(Name = "AliasName", IsRequired = false, Order = 1)]
  public QualifiedName AliasName
  {
    get => this.m_aliasName;
    set => this.m_aliasName = value;
  }

  [DataMember(Name = "ReferencedNodes", IsRequired = false, Order = 2)]
  public ExpandedNodeIdCollection ReferencedNodes
  {
    get => this.m_referencedNodes;
    set
    {
      this.m_referencedNodes = value;
      if (value != null)
        return;
      this.m_referencedNodes = new ExpandedNodeIdCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AliasNameDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AliasNameDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AliasNameDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AliasNameDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteQualifiedName("AliasName", this.AliasName);
    encoder.WriteExpandedNodeIdArray("ReferencedNodes", (IList<ExpandedNodeId>) this.ReferencedNodes);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.AliasName = decoder.ReadQualifiedName("AliasName");
    this.ReferencedNodes = decoder.ReadExpandedNodeIdArray("ReferencedNodes");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AliasNameDataType aliasNameDataType && Utils.IsEqual((object) this.m_aliasName, (object) aliasNameDataType.m_aliasName) && Utils.IsEqual((object) this.m_referencedNodes, (object) aliasNameDataType.m_referencedNodes);
  }

  public virtual object Clone() => (object) (AliasNameDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AliasNameDataType aliasNameDataType = (AliasNameDataType) base.MemberwiseClone();
    aliasNameDataType.m_aliasName = (QualifiedName) Utils.Clone((object) this.m_aliasName);
    aliasNameDataType.m_referencedNodes = (ExpandedNodeIdCollection) Utils.Clone((object) this.m_referencedNodes);
    return (object) aliasNameDataType;
  }
}
