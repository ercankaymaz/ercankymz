// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariableAttributes
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
public class VariableAttributes : NodeAttributes
{
  private Variant m_value;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private byte m_accessLevel;
  private byte m_userAccessLevel;
  private double m_minimumSamplingInterval;
  private bool m_historizing;

  public VariableAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_value = Variant.Null;
    this.m_dataType = (NodeId) null;
    this.m_valueRank = 0;
    this.m_arrayDimensions = new UInt32Collection();
    this.m_accessLevel = (byte) 0;
    this.m_userAccessLevel = (byte) 0;
    this.m_minimumSamplingInterval = 0.0;
    this.m_historizing = true;
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

  [DataMember(Name = "AccessLevel", IsRequired = false, Order = 5)]
  public byte AccessLevel
  {
    get => this.m_accessLevel;
    set => this.m_accessLevel = value;
  }

  [DataMember(Name = "UserAccessLevel", IsRequired = false, Order = 6)]
  public byte UserAccessLevel
  {
    get => this.m_userAccessLevel;
    set => this.m_userAccessLevel = value;
  }

  [DataMember(Name = "MinimumSamplingInterval", IsRequired = false, Order = 7)]
  public double MinimumSamplingInterval
  {
    get => this.m_minimumSamplingInterval;
    set => this.m_minimumSamplingInterval = value;
  }

  [DataMember(Name = "Historizing", IsRequired = false, Order = 8)]
  public bool Historizing
  {
    get => this.m_historizing;
    set => this.m_historizing = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.VariableAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableAttributes_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteVariant("Value", this.Value);
    encoder.WriteNodeId("DataType", this.DataType);
    encoder.WriteInt32("ValueRank", this.ValueRank);
    encoder.WriteUInt32Array("ArrayDimensions", (IList<uint>) this.ArrayDimensions);
    encoder.WriteByte("AccessLevel", this.AccessLevel);
    encoder.WriteByte("UserAccessLevel", this.UserAccessLevel);
    encoder.WriteDouble("MinimumSamplingInterval", this.MinimumSamplingInterval);
    encoder.WriteBoolean("Historizing", this.Historizing);
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
    this.AccessLevel = decoder.ReadByte("AccessLevel");
    this.UserAccessLevel = decoder.ReadByte("UserAccessLevel");
    this.MinimumSamplingInterval = decoder.ReadDouble("MinimumSamplingInterval");
    this.Historizing = decoder.ReadBoolean("Historizing");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is VariableAttributes variableAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_value, (object) variableAttributes.m_value) && Utils.IsEqual((object) this.m_dataType, (object) variableAttributes.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) variableAttributes.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) variableAttributes.m_arrayDimensions) && Utils.IsEqual((object) this.m_accessLevel, (object) variableAttributes.m_accessLevel) && Utils.IsEqual((object) this.m_userAccessLevel, (object) variableAttributes.m_userAccessLevel) && Utils.IsEqual((object) this.m_minimumSamplingInterval, (object) variableAttributes.m_minimumSamplingInterval) && Utils.IsEqual((object) this.m_historizing, (object) variableAttributes.m_historizing) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (VariableAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    VariableAttributes variableAttributes = (VariableAttributes) base.MemberwiseClone();
    variableAttributes.m_value = (Variant) Utils.Clone((object) this.m_value);
    variableAttributes.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    variableAttributes.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    variableAttributes.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    variableAttributes.m_accessLevel = (byte) Utils.Clone((object) this.m_accessLevel);
    variableAttributes.m_userAccessLevel = (byte) Utils.Clone((object) this.m_userAccessLevel);
    variableAttributes.m_minimumSamplingInterval = (double) Utils.Clone((object) this.m_minimumSamplingInterval);
    variableAttributes.m_historizing = (bool) Utils.Clone((object) this.m_historizing);
    return (object) variableAttributes;
  }

  public VariableAttributes(object value, byte accessLevel)
  {
    this.Initialize();
    this.Value = new Variant(value);
    this.AccessLevel = accessLevel;
    this.UserAccessLevel = accessLevel;
    this.MinimumSamplingInterval = -1.0;
    this.Historizing = false;
    if (value == null)
    {
      this.DataType = (NodeId) 24U;
      this.ValueRank = -2;
    }
    else
    {
      this.DataType = TypeInfo.GetDataTypeId(value);
      this.ValueRank = TypeInfo.GetValueRank(value);
    }
  }
}
