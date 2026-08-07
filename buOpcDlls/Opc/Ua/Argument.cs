// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Argument
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
public class Argument : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_name;
  private NodeId m_dataType;
  private int m_valueRank;
  private UInt32Collection m_arrayDimensions;
  private LocalizedText m_description;
  private object m_value;

  public Argument() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_name = (string) null;
    this.m_dataType = (NodeId) null;
    this.m_valueRank = 0;
    this.m_arrayDimensions = new UInt32Collection();
    this.m_description = (LocalizedText) null;
  }

  [DataMember(Name = "Name", IsRequired = false, Order = 1)]
  public string Name
  {
    get => this.m_name;
    set => this.m_name = value;
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

  [DataMember(Name = "Description", IsRequired = false, Order = 5)]
  public LocalizedText Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.Argument;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Argument_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Argument_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Argument_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Name", this.Name);
    encoder.WriteNodeId("DataType", this.DataType);
    encoder.WriteInt32("ValueRank", this.ValueRank);
    encoder.WriteUInt32Array("ArrayDimensions", (IList<uint>) this.ArrayDimensions);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Name = decoder.ReadString("Name");
    this.DataType = decoder.ReadNodeId("DataType");
    this.ValueRank = decoder.ReadInt32("ValueRank");
    this.ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
    this.Description = decoder.ReadLocalizedText("Description");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is Argument obj && Utils.IsEqual((object) this.m_name, (object) obj.m_name) && Utils.IsEqual((object) this.m_dataType, (object) obj.m_dataType) && Utils.IsEqual((object) this.m_valueRank, (object) obj.m_valueRank) && Utils.IsEqual((object) this.m_arrayDimensions, (object) obj.m_arrayDimensions) && Utils.IsEqual((object) this.m_description, (object) obj.m_description);
  }

  public virtual object Clone() => (object) (Argument) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    Argument obj = (Argument) base.MemberwiseClone();
    obj.m_name = (string) Utils.Clone((object) this.m_name);
    obj.m_dataType = (NodeId) Utils.Clone((object) this.m_dataType);
    obj.m_valueRank = (int) Utils.Clone((object) this.m_valueRank);
    obj.m_arrayDimensions = (UInt32Collection) Utils.Clone((object) this.m_arrayDimensions);
    obj.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    return (object) obj;
  }

  public Argument(string name, NodeId dataType, int valueRank, string description)
  {
    this.m_name = name;
    this.m_dataType = dataType;
    this.m_valueRank = valueRank;
    this.m_description = (LocalizedText) description;
  }

  public object Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }
}
