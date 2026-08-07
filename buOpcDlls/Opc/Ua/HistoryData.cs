// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryData
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
public class HistoryData : IEncodeable, ICloneable, IJsonEncodeable
{
  private DataValueCollection m_dataValues;

  public HistoryData() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_dataValues = new DataValueCollection();

  [DataMember(Name = "DataValues", IsRequired = false, Order = 1)]
  public DataValueCollection DataValues
  {
    get => this.m_dataValues;
    set
    {
      this.m_dataValues = value;
      if (value != null)
        return;
      this.m_dataValues = new DataValueCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryData;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryData_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryData_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryData_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDataValueArray("DataValues", (IList<DataValue>) this.DataValues);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DataValues = decoder.ReadDataValueArray("DataValues");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is HistoryData historyData && Utils.IsEqual((object) this.m_dataValues, (object) historyData.m_dataValues);
  }

  public virtual object Clone() => (object) (HistoryData) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryData historyData = (HistoryData) base.MemberwiseClone();
    historyData.m_dataValues = (DataValueCollection) Utils.Clone((object) this.m_dataValues);
    return (object) historyData;
  }
}
