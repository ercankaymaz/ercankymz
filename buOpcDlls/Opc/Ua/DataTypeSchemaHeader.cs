// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeSchemaHeader
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
public class DataTypeSchemaHeader : IEncodeable, ICloneable, IJsonEncodeable
{
  private StringCollection m_namespaces;
  private StructureDescriptionCollection m_structureDataTypes;
  private EnumDescriptionCollection m_enumDataTypes;
  private SimpleTypeDescriptionCollection m_simpleDataTypes;

  public DataTypeSchemaHeader() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_namespaces = new StringCollection();
    this.m_structureDataTypes = new StructureDescriptionCollection();
    this.m_enumDataTypes = new EnumDescriptionCollection();
    this.m_simpleDataTypes = new SimpleTypeDescriptionCollection();
  }

  [DataMember(Name = "Namespaces", IsRequired = false, Order = 1)]
  public StringCollection Namespaces
  {
    get => this.m_namespaces;
    set
    {
      this.m_namespaces = value;
      if (value != null)
        return;
      this.m_namespaces = new StringCollection();
    }
  }

  [DataMember(Name = "StructureDataTypes", IsRequired = false, Order = 2)]
  public StructureDescriptionCollection StructureDataTypes
  {
    get => this.m_structureDataTypes;
    set
    {
      this.m_structureDataTypes = value;
      if (value != null)
        return;
      this.m_structureDataTypes = new StructureDescriptionCollection();
    }
  }

  [DataMember(Name = "EnumDataTypes", IsRequired = false, Order = 3)]
  public EnumDescriptionCollection EnumDataTypes
  {
    get => this.m_enumDataTypes;
    set
    {
      this.m_enumDataTypes = value;
      if (value != null)
        return;
      this.m_enumDataTypes = new EnumDescriptionCollection();
    }
  }

  [DataMember(Name = "SimpleDataTypes", IsRequired = false, Order = 4)]
  public SimpleTypeDescriptionCollection SimpleDataTypes
  {
    get => this.m_simpleDataTypes;
    set
    {
      this.m_simpleDataTypes = value;
      if (value != null)
        return;
      this.m_simpleDataTypes = new SimpleTypeDescriptionCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataTypeSchemaHeader;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeSchemaHeader_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeSchemaHeader_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeSchemaHeader_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStringArray("Namespaces", (IList<string>) this.Namespaces);
    encoder.WriteEncodeableArray("StructureDataTypes", (IList<IEncodeable>) this.StructureDataTypes.ToArray(), typeof (StructureDescription));
    encoder.WriteEncodeableArray("EnumDataTypes", (IList<IEncodeable>) this.EnumDataTypes.ToArray(), typeof (EnumDescription));
    encoder.WriteEncodeableArray("SimpleDataTypes", (IList<IEncodeable>) this.SimpleDataTypes.ToArray(), typeof (SimpleTypeDescription));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Namespaces = decoder.ReadStringArray("Namespaces");
    this.StructureDataTypes = (StructureDescriptionCollection) (StructureDescription[]) decoder.ReadEncodeableArray("StructureDataTypes", typeof (StructureDescription));
    this.EnumDataTypes = (EnumDescriptionCollection) (EnumDescription[]) decoder.ReadEncodeableArray("EnumDataTypes", typeof (EnumDescription));
    this.SimpleDataTypes = (SimpleTypeDescriptionCollection) (SimpleTypeDescription[]) decoder.ReadEncodeableArray("SimpleDataTypes", typeof (SimpleTypeDescription));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is DataTypeSchemaHeader typeSchemaHeader && Utils.IsEqual((object) this.m_namespaces, (object) typeSchemaHeader.m_namespaces) && Utils.IsEqual((object) this.m_structureDataTypes, (object) typeSchemaHeader.m_structureDataTypes) && Utils.IsEqual((object) this.m_enumDataTypes, (object) typeSchemaHeader.m_enumDataTypes) && Utils.IsEqual((object) this.m_simpleDataTypes, (object) typeSchemaHeader.m_simpleDataTypes);
  }

  public virtual object Clone() => (object) (DataTypeSchemaHeader) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeSchemaHeader typeSchemaHeader = (DataTypeSchemaHeader) base.MemberwiseClone();
    typeSchemaHeader.m_namespaces = (StringCollection) Utils.Clone((object) this.m_namespaces);
    typeSchemaHeader.m_structureDataTypes = (StructureDescriptionCollection) Utils.Clone((object) this.m_structureDataTypes);
    typeSchemaHeader.m_enumDataTypes = (EnumDescriptionCollection) Utils.Clone((object) this.m_enumDataTypes);
    typeSchemaHeader.m_simpleDataTypes = (SimpleTypeDescriptionCollection) Utils.Clone((object) this.m_simpleDataTypes);
    return (object) typeSchemaHeader;
  }
}
