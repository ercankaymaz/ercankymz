// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeTypeDescription
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
public class NodeTypeDescription : IEncodeable, ICloneable, IJsonEncodeable
{
  private ExpandedNodeId m_typeDefinitionNode;
  private bool m_includeSubTypes;
  private QueryDataDescriptionCollection m_dataToReturn;

  public NodeTypeDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_typeDefinitionNode = (ExpandedNodeId) null;
    this.m_includeSubTypes = true;
    this.m_dataToReturn = new QueryDataDescriptionCollection();
  }

  [DataMember(Name = "TypeDefinitionNode", IsRequired = false, Order = 1)]
  public ExpandedNodeId TypeDefinitionNode
  {
    get => this.m_typeDefinitionNode;
    set => this.m_typeDefinitionNode = value;
  }

  [DataMember(Name = "IncludeSubTypes", IsRequired = false, Order = 2)]
  public bool IncludeSubTypes
  {
    get => this.m_includeSubTypes;
    set => this.m_includeSubTypes = value;
  }

  [DataMember(Name = "DataToReturn", IsRequired = false, Order = 3)]
  public QueryDataDescriptionCollection DataToReturn
  {
    get => this.m_dataToReturn;
    set
    {
      this.m_dataToReturn = value;
      if (value != null)
        return;
      this.m_dataToReturn = new QueryDataDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.NodeTypeDescription;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeTypeDescription_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeTypeDescription_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.NodeTypeDescription_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExpandedNodeId("TypeDefinitionNode", this.TypeDefinitionNode);
    encoder.WriteBoolean("IncludeSubTypes", this.IncludeSubTypes);
    encoder.WriteEncodeableArray("DataToReturn", (IList<IEncodeable>) this.DataToReturn.ToArray(), typeof (QueryDataDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TypeDefinitionNode = decoder.ReadExpandedNodeId("TypeDefinitionNode");
    this.IncludeSubTypes = decoder.ReadBoolean("IncludeSubTypes");
    this.DataToReturn = (QueryDataDescriptionCollection) (QueryDataDescription[]) decoder.ReadEncodeableArray("DataToReturn", typeof (QueryDataDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is NodeTypeDescription nodeTypeDescription && Utils.IsEqual((object) this.m_typeDefinitionNode, (object) nodeTypeDescription.m_typeDefinitionNode) && Utils.IsEqual((object) this.m_includeSubTypes, (object) nodeTypeDescription.m_includeSubTypes) && Utils.IsEqual((object) this.m_dataToReturn, (object) nodeTypeDescription.m_dataToReturn);
  }

  public virtual object Clone() => (object) (NodeTypeDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    NodeTypeDescription nodeTypeDescription = (NodeTypeDescription) base.MemberwiseClone();
    nodeTypeDescription.m_typeDefinitionNode = (ExpandedNodeId) Utils.Clone((object) this.m_typeDefinitionNode);
    nodeTypeDescription.m_includeSubTypes = (bool) Utils.Clone((object) this.m_includeSubTypes);
    nodeTypeDescription.m_dataToReturn = (QueryDataDescriptionCollection) Utils.Clone((object) this.m_dataToReturn);
    return (object) nodeTypeDescription;
  }

  public object Handle { get; set; }

  public bool Processed { get; set; }
}
