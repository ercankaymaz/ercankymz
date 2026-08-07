// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariableTypeNode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class VariableTypeNode : TypeNode, IVariableType, IVariableBase, ILocalNode, INode
{
  private Variant m_value;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private bool m_isAbstract;

  public VariableTypeNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_value = Variant.Null;
    this.m_dataType = (NodeId) null;
    this.m_valueRank = 0;
    this.m_arrayDimensions = new UInt32Collection();
    this.m_isAbstract = true;
  }

  [DataMember(Name = "Value", IsRequired = false, Order = 1)]
  public Variant Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  [DataMember(Name = "DataType", IsRequired = false, Order = 2)]
  public NodeId DataType
  {
    get => this.m_dataType;
    set => this.m_dataType = value;
  }

  [DataMember(Name = "ValueRank", IsRequired = false, Order = 3)]
  public int ValueRank
  {
    get => this.m_valueRank;
    set => this.m_valueRank = value;
  }

  [DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 4)]
  public UInt32Collection ArrayDimensions
  {
    get => this.m_arrayDimensions;
    set
    {
      this.m_arrayDimensions = value;
      if (value != null)
        return;
      this.m_arrayDimensions = new UInt32Collection();
    }
  }

  [DataMember(Name = "IsAbstract", IsRequired = false, Order = 5)]
  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set => this.m_isAbstract = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.VariableTypeNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeNode_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteVariant("Value", this.Value);
    encoder.WriteNodeId("DataType", this.DataType);
    encoder.WriteInt32("ValueRank", this.ValueRank);
    encoder.WriteUInt32Array("ArrayDimensions", (IList<uint>) this.ArrayDimensions);
    encoder.WriteBoolean("IsAbstract", this.IsAbstract);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Value = decoder.ReadVariant("Value");
    this.DataType = decoder.ReadNodeId("DataType");
    this.ValueRank = decoder.ReadInt32("ValueRank");
    this.ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
    this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is VariableTypeNode variableTypeNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_value, (object) variableTypeNode.m_value) && Utils.IsEqual((object) this.m_dataType, (object) variableTypeNode.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) variableTypeNode.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) variableTypeNode.m_arrayDimensions) && Utils.IsEqual((object) this.m_isAbstract, (object) variableTypeNode.m_isAbstract) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (VariableTypeNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    VariableTypeNode variableTypeNode = (VariableTypeNode) base.MemberwiseClone();
    variableTypeNode.m_value = (Variant) Utils.Clone((object) this.m_value);
    variableTypeNode.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    variableTypeNode.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    variableTypeNode.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    variableTypeNode.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    return (object) variableTypeNode;
  }

  public VariableTypeNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.VariableType;
    if (!(source is IVariableType variableType))
      return;
    this.IsAbstract = variableType.IsAbstract;
    this.Value = new Variant(variableType.Value);
    this.DataType = variableType.DataType;
    this.ValueRank = variableType.ValueRank;
    if (variableType.ArrayDimensions == null)
      return;
    this.ArrayDimensions = new UInt32Collection((IEnumerable<uint>) variableType.ArrayDimensions);
  }

  object IVariableBase.Value
  {
    get => this.m_value.Value;
    set => this.m_value.Value = value;
  }

  IList<uint> IVariableBase.ArrayDimensions
  {
    get => (IList<uint>) this.m_arrayDimensions;
    set
    {
      if (value == null)
        this.m_arrayDimensions = new UInt32Collection();
      else
        this.m_arrayDimensions = new UInt32Collection((IEnumerable<uint>) value);
    }
  }

  public override bool SupportsAttribute(uint attributeId)
  {
    switch (attributeId)
    {
      case 8:
      case 14:
      case 15:
        return true;
      case 13:
        return this.m_value.Value != null;
      case 16 /*0x10*/:
        return this.m_arrayDimensions != null && this.m_arrayDimensions.Count != 0;
      default:
        return base.SupportsAttribute(attributeId);
    }
  }

  protected override object Read(uint attributeId)
  {
    switch (attributeId)
    {
      case 13:
        return this.m_value.Value;
      case 14:
        return (object) this.m_dataType;
      case 15:
        return (object) this.m_valueRank;
      case 16 /*0x10*/:
        return this.m_arrayDimensions != null && this.m_arrayDimensions.Count != 0 ? (object) this.m_arrayDimensions.ToArray() : (object) 2150957056U /*0x80350000*/;
      default:
        return base.Read(attributeId);
    }
  }

  protected override ServiceResult Write(uint attributeId, object value)
  {
    switch (attributeId)
    {
      case 13:
        this.m_value.Value = Utils.Clone(value);
        return ServiceResult.Good;
      case 14:
        NodeId nodeId = (NodeId) value;
        if (nodeId != (object) this.m_dataType)
          this.m_value.Value = (object) null;
        this.m_dataType = nodeId;
        return ServiceResult.Good;
      case 15:
        int num = (int) value;
        if (num != this.m_valueRank)
          this.m_value.Value = (object) null;
        this.m_valueRank = num;
        return ServiceResult.Good;
      case 16 /*0x10*/:
        this.m_arrayDimensions = new UInt32Collection((IEnumerable<uint>) (uint[]) value);
        if (this.m_arrayDimensions.Count > 0 && this.m_valueRank != this.m_arrayDimensions.Count)
        {
          this.m_valueRank = this.m_arrayDimensions.Count;
          this.m_value.Value = (object) null;
        }
        return ServiceResult.Good;
      default:
        return base.Write(attributeId, value);
    }
  }
}
