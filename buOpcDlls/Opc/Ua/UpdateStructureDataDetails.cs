// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UpdateStructureDataDetails
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
public class UpdateStructureDataDetails : HistoryUpdateDetails
{
  private PerformUpdateType m_performInsertReplace;
  private DataValueCollection m_updateValues;

  public UpdateStructureDataDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_performInsertReplace = PerformUpdateType.Insert;
    this.m_updateValues = new DataValueCollection();
  }

  [DataMember(Name = "PerformInsertReplace", IsRequired = false, Order = 1)]
  public PerformUpdateType PerformInsertReplace
  {
    get => this.m_performInsertReplace;
    set => this.m_performInsertReplace = value;
  }

  [DataMember(Name = "UpdateValues", IsRequired = false, Order = 2)]
  public DataValueCollection UpdateValues
  {
    get => this.m_updateValues;
    set
    {
      this.m_updateValues = value;
      if (value != null)
        return;
      this.m_updateValues = new DataValueCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UpdateStructureDataDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateStructureDataDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateStructureDataDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UpdateStructureDataDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("PerformInsertReplace", (Enum) this.PerformInsertReplace);
    encoder.WriteDataValueArray("UpdateValues", (IList<DataValue>) this.UpdateValues);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PerformInsertReplace = (PerformUpdateType) decoder.ReadEnumerated("PerformInsertReplace", typeof (PerformUpdateType));
    this.UpdateValues = decoder.ReadDataValueArray("UpdateValues");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UpdateStructureDataDetails structureDataDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_performInsertReplace, (object) structureDataDetails.m_performInsertReplace) && Utils.IsEqual((object) this.m_updateValues, (object) structureDataDetails.m_updateValues) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (UpdateStructureDataDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UpdateStructureDataDetails structureDataDetails = (UpdateStructureDataDetails) base.MemberwiseClone();
    structureDataDetails.m_performInsertReplace = (PerformUpdateType) Utils.Clone((object) this.m_performInsertReplace);
    structureDataDetails.m_updateValues = (DataValueCollection) Utils.Clone((object) this.m_updateValues);
    return (object) structureDataDetails;
  }
}
