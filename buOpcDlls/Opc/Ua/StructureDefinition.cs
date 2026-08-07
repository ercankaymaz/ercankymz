// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureDefinition
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
public class StructureDefinition : DataTypeDefinition
{
  private NodeId m_defaultEncodingId;
  private NodeId m_baseDataType;
  private StructureType m_structureType;
  private StructureFieldCollection m_fields;

  public StructureDefinition() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_defaultEncodingId = (NodeId) null;
    this.m_baseDataType = (NodeId) null;
    this.m_structureType = StructureType.Structure;
    this.m_fields = new StructureFieldCollection();
  }

  [DataMember(Name = "DefaultEncodingId", IsRequired = false, Order = 1)]
  public NodeId DefaultEncodingId
  {
    get => this.m_defaultEncodingId;
    set => this.m_defaultEncodingId = value;
  }

  [DataMember(Name = "BaseDataType", IsRequired = false, Order = 2)]
  public NodeId BaseDataType
  {
    get => this.m_baseDataType;
    set => this.m_baseDataType = value;
  }

  [DataMember(Name = "StructureType", IsRequired = false, Order = 3)]
  public StructureType StructureType
  {
    get => this.m_structureType;
    set => this.m_structureType = value;
  }

  [DataMember(Name = "Fields", IsRequired = false, Order = 4)]
  public StructureFieldCollection Fields
  {
    get => this.m_fields;
    set
    {
      this.m_fields = value;
      if (value != null)
        return;
      this.m_fields = new StructureFieldCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.StructureDefinition;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureDefinition_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureDefinition_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.StructureDefinition_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("DefaultEncodingId", this.DefaultEncodingId);
    encoder.WriteNodeId("BaseDataType", this.BaseDataType);
    encoder.WriteEnumerated("StructureType", (Enum) this.StructureType);
    encoder.WriteEncodeableArray("Fields", (IList<IEncodeable>) this.Fields.ToArray(), typeof (StructureField));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DefaultEncodingId = decoder.ReadNodeId("DefaultEncodingId");
    this.BaseDataType = decoder.ReadNodeId("BaseDataType");
    this.StructureType = (StructureType) decoder.ReadEnumerated("StructureType", typeof (StructureType));
    this.Fields = (StructureFieldCollection) (StructureField[]) decoder.ReadEncodeableArray("Fields", typeof (StructureField));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is StructureDefinition structureDefinition && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_defaultEncodingId, (object) structureDefinition.m_defaultEncodingId) && Utils.IsEqual((object) this.m_baseDataType, (object) structureDefinition.m_baseDataType) && Utils.IsEqual((object) this.m_structureType, (object) structureDefinition.m_structureType) && Utils.IsEqual((object) this.m_fields, (object) structureDefinition.m_fields) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (StructureDefinition) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    StructureDefinition structureDefinition = (StructureDefinition) base.MemberwiseClone();
    structureDefinition.m_defaultEncodingId = (NodeId) Utils.Clone((object) this.m_defaultEncodingId);
    structureDefinition.m_baseDataType = (NodeId) Utils.Clone((object) this.m_baseDataType);
    structureDefinition.m_structureType = (StructureType) Utils.Clone((object) this.m_structureType);
    structureDefinition.m_fields = (StructureFieldCollection) Utils.Clone((object) this.m_fields);
    return (object) structureDefinition;
  }

  public int FirstExplicitFieldIndex { get; set; }

  public void SetDefaultEncodingId(
    ISystemContext context,
    NodeId typeId,
    QualifiedName dataEncoding)
  {
    if (context == null)
      throw new ArgumentNullException(nameof (context));
    if (dataEncoding?.Name == "Default JSON")
    {
      this.DefaultEncodingId = ExpandedNodeId.ToNodeId((ExpandedNodeId) typeId, context.NamespaceUris);
    }
    else
    {
      Type systemType = context.EncodeableFactory?.GetSystemType(NodeId.ToExpandedNodeId(typeId, context.NamespaceUris));
      if (!(systemType != (Type) null) || !(Activator.CreateInstance(systemType) is IEncodeable instance))
        return;
      if (!(dataEncoding == (QualifiedName) null) && !(dataEncoding.Name == "Default Binary"))
      {
        if (!(dataEncoding.Name == "Default XML"))
          return;
        this.DefaultEncodingId = ExpandedNodeId.ToNodeId(instance.XmlEncodingId, context.NamespaceUris);
      }
      else
        this.DefaultEncodingId = ExpandedNodeId.ToNodeId(instance.BinaryEncodingId, context.NamespaceUris);
    }
  }
}
