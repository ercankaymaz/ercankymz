// Decompiled with JetBrains decompiler
// Type: Opc.Ua.QueryDataSet
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
public class QueryDataSet : IEncodeable, ICloneable, IJsonEncodeable
{
  private ExpandedNodeId m_nodeId;
  private ExpandedNodeId m_typeDefinitionNode;
  private VariantCollection m_values;

  public QueryDataSet() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (ExpandedNodeId) null;
    this.m_typeDefinitionNode = (ExpandedNodeId) null;
    this.m_values = new VariantCollection();
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public ExpandedNodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "TypeDefinitionNode", IsRequired = false, Order = 2)]
  public ExpandedNodeId TypeDefinitionNode
  {
    get => this.m_typeDefinitionNode;
    set => this.m_typeDefinitionNode = value;
  }

  [DataMember(Name = "Values", IsRequired = false, Order = 3)]
  public VariantCollection Values
  {
    get => this.m_values;
    set
    {
      this.m_values = value;
      if (value != null)
        return;
      this.m_values = new VariantCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.QueryDataSet;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataSet_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataSet_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.QueryDataSet_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExpandedNodeId("NodeId", this.NodeId);
    encoder.WriteExpandedNodeId("TypeDefinitionNode", this.TypeDefinitionNode);
    encoder.WriteVariantArray("Values", (IList<Variant>) this.Values);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadExpandedNodeId("NodeId");
    this.TypeDefinitionNode = decoder.ReadExpandedNodeId("TypeDefinitionNode");
    this.Values = decoder.ReadVariantArray("Values");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is QueryDataSet queryDataSet && Utils.IsEqual((object) this.m_nodeId, (object) queryDataSet.m_nodeId) && Utils.IsEqual((object) this.m_typeDefinitionNode, (object) queryDataSet.m_typeDefinitionNode) && Utils.IsEqual((object) this.m_values, (object) queryDataSet.m_values);
  }

  public virtual object Clone() => (object) (QueryDataSet) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    QueryDataSet queryDataSet = (QueryDataSet) base.MemberwiseClone();
    queryDataSet.m_nodeId = (ExpandedNodeId) Utils.Clone((object) this.m_nodeId);
    queryDataSet.m_typeDefinitionNode = (ExpandedNodeId) Utils.Clone((object) this.m_typeDefinitionNode);
    queryDataSet.m_values = (VariantCollection) Utils.Clone((object) this.m_values);
    return (object) queryDataSet;
  }
}
