// Decompiled with JetBrains decompiler
// Type: Opc.Ua.VariableNode
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
public class VariableNode : InstanceNode, IVariable, IVariableBase, ILocalNode, INode
{
  private Variant m_value;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private byte m_accessLevel;
  private byte m_userAccessLevel;
  private double m_minimumSamplingInterval;
  private bool m_historizing;
  private uint m_accessLevelEx;

  public VariableNode() => this.Initialize();

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
    this.m_accessLevelEx = 0U;
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

  [DataMember(Name = "AccessLevelEx", IsRequired = false, Order = 9)]
  public uint AccessLevelEx
  {
    get => this.m_accessLevelEx;
    set => this.m_accessLevelEx = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.VariableNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.VariableNode_Encoding_DefaultJson;
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
    encoder.WriteUInt32("AccessLevelEx", this.AccessLevelEx);
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
    this.AccessLevelEx = decoder.ReadUInt32("AccessLevelEx");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is VariableNode variableNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_value, (object) variableNode.m_value) && Utils.IsEqual((object) this.m_dataType, (object) variableNode.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) variableNode.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) variableNode.m_arrayDimensions) && Utils.IsEqual((object) this.m_accessLevel, (object) variableNode.m_accessLevel) && Utils.IsEqual((object) this.m_userAccessLevel, (object) variableNode.m_userAccessLevel) && Utils.IsEqual((object) this.m_minimumSamplingInterval, (object) variableNode.m_minimumSamplingInterval) && Utils.IsEqual((object) this.m_historizing, (object) variableNode.m_historizing) && Utils.IsEqual((object) this.m_accessLevelEx, (object) variableNode.m_accessLevelEx) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (VariableNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    VariableNode variableNode = (VariableNode) base.MemberwiseClone();
    variableNode.m_value = (Variant) Utils.Clone((object) this.m_value);
    variableNode.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    variableNode.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    variableNode.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    variableNode.m_accessLevel = (byte) Utils.Clone((object) this.m_accessLevel);
    variableNode.m_userAccessLevel = (byte) Utils.Clone((object) this.m_userAccessLevel);
    variableNode.m_minimumSamplingInterval = (double) Utils.Clone((object) this.m_minimumSamplingInterval);
    variableNode.m_historizing = (bool) Utils.Clone((object) this.m_historizing);
    variableNode.m_accessLevelEx = (uint) Utils.Clone((object) this.m_accessLevelEx);
    return (object) variableNode;
  }

  public VariableNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.Variable;
    if (!(source is IVariable variable))
      return;
    this.DataType = variable.DataType;
    this.ValueRank = variable.ValueRank;
    this.AccessLevel = variable.AccessLevel;
    this.UserAccessLevel = variable.UserAccessLevel;
    this.MinimumSamplingInterval = variable.MinimumSamplingInterval;
    this.Historizing = variable.Historizing;
    this.Value = new Variant(variable.Value ?? TypeInfo.GetDefaultValue(variable.DataType, variable.ValueRank));
    if (variable.ArrayDimensions == null)
      return;
    this.ArrayDimensions = new UInt32Collection((IEnumerable<uint>) variable.ArrayDimensions);
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
      case 13:
      case 14:
      case 15:
      case 17:
      case 18:
      case 19:
      case 20:
      case 27:
        return true;
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
      case 17:
        return (object) this.m_accessLevel;
      case 18:
        return (object) this.m_userAccessLevel;
      case 19:
        return (object) this.m_minimumSamplingInterval;
      case 20:
        return (object) this.m_historizing;
      case 27:
        return (object) this.m_accessLevelEx;
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
        NodeId dataType = (NodeId) value;
        if (dataType != (object) this.m_dataType)
          this.m_value.Value = TypeInfo.GetDefaultValue(dataType, this.m_valueRank);
        this.m_dataType = dataType;
        return ServiceResult.Good;
      case 15:
        int valueRank = (int) value;
        if (valueRank != this.m_valueRank)
          this.m_value.Value = TypeInfo.GetDefaultValue(this.m_dataType, valueRank);
        this.m_valueRank = valueRank;
        return ServiceResult.Good;
      case 16 /*0x10*/:
        this.m_arrayDimensions = new UInt32Collection((IEnumerable<uint>) (uint[]) value);
        if (this.m_arrayDimensions.Count > 0 && this.m_arrayDimensions.Count != this.m_valueRank)
        {
          this.m_valueRank = this.m_arrayDimensions.Count;
          this.m_value.Value = TypeInfo.GetDefaultValue(this.m_dataType, this.m_valueRank);
        }
        return ServiceResult.Good;
      case 17:
        this.m_accessLevel = (byte) value;
        return ServiceResult.Good;
      case 18:
        this.m_userAccessLevel = (byte) value;
        return ServiceResult.Good;
      case 19:
        this.m_minimumSamplingInterval = (double) (int) value;
        return ServiceResult.Good;
      case 20:
        this.m_historizing = (bool) value;
        return ServiceResult.Good;
      case 27:
        this.m_accessLevelEx = (uint) value;
        return ServiceResult.Good;
      default:
        return base.Write(attributeId, value);
    }
  }
}
