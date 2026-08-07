// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariableTypeAttributes
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
public class VariableTypeAttributes : NodeAttributes
{
  private Variant m_value;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private bool m_isAbstract;

  public VariableTypeAttributes() => this.Initialize();

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

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.VariableTypeAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableTypeAttributes_Encoding_DefaultJson;
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
    return encodeable is VariableTypeAttributes variableTypeAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_value, (object) variableTypeAttributes.m_value) && Utils.IsEqual((object) this.m_dataType, (object) variableTypeAttributes.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) variableTypeAttributes.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) variableTypeAttributes.m_arrayDimensions) && Utils.IsEqual((object) this.m_isAbstract, (object) variableTypeAttributes.m_isAbstract) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (VariableTypeAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    VariableTypeAttributes variableTypeAttributes = (VariableTypeAttributes) base.MemberwiseClone();
    variableTypeAttributes.m_value = (Variant) Utils.Clone((object) this.m_value);
    variableTypeAttributes.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    variableTypeAttributes.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    variableTypeAttributes.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    variableTypeAttributes.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    return (object) variableTypeAttributes;
  }
}
