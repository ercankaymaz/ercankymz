// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServiceCounterDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServiceCounterDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_totalCount;
  private uint m_errorCount;

  public ServiceCounterDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_totalCount = 0U;
    this.m_errorCount = 0U;
  }

  [DataMember(Name = "TotalCount", IsRequired = false, Order = 1)]
  public uint TotalCount
  {
    get => this.m_totalCount;
    set => this.m_totalCount = value;
  }

  [DataMember(Name = "ErrorCount", IsRequired = false, Order = 2)]
  public uint ErrorCount
  {
    get => this.m_errorCount;
    set => this.m_errorCount = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ServiceCounterDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServiceCounterDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServiceCounterDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServiceCounterDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("TotalCount", this.TotalCount);
    encoder.WriteUInt32("ErrorCount", this.ErrorCount);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TotalCount = decoder.ReadUInt32("TotalCount");
    this.ErrorCount = decoder.ReadUInt32("ErrorCount");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ServiceCounterDataType serviceCounterDataType && Utils.IsEqual((object) this.m_totalCount, (object) serviceCounterDataType.m_totalCount) && Utils.IsEqual((object) this.m_errorCount, (object) serviceCounterDataType.m_errorCount);
  }

  public virtual object Clone() => (object) (ServiceCounterDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ServiceCounterDataType serviceCounterDataType = (ServiceCounterDataType) base.MemberwiseClone();
    serviceCounterDataType.m_totalCount = (uint) Utils.Clone((object) this.m_totalCount);
    serviceCounterDataType.m_errorCount = (uint) Utils.Clone((object) this.m_errorCount);
    return (object) serviceCounterDataType;
  }
}
