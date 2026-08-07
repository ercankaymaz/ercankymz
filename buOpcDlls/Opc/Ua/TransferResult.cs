// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransferResult
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
public class TransferResult : IEncodeable, ICloneable, IJsonEncodeable
{
  private StatusCode m_statusCode;
  private UInt32Collection m_availableSequenceNumbers;

  public TransferResult() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_statusCode = (StatusCode) 0U;
    this.m_availableSequenceNumbers = new UInt32Collection();
  }

  [DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
  public StatusCode StatusCode
  {
    get => this.m_statusCode;
    set => this.m_statusCode = value;
  }

  [DataMember(Name = "AvailableSequenceNumbers", IsRequired = false, Order = 2)]
  public UInt32Collection AvailableSequenceNumbers
  {
    get => this.m_availableSequenceNumbers;
    set
    {
      this.m_availableSequenceNumbers = value;
      if (value != null)
        return;
      this.m_availableSequenceNumbers = new UInt32Collection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.TransferResult;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferResult_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferResult_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TransferResult_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteStatusCode("StatusCode", this.StatusCode);
    encoder.WriteUInt32Array("AvailableSequenceNumbers", (IList<uint>) this.AvailableSequenceNumbers);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StatusCode = decoder.ReadStatusCode("StatusCode");
    this.AvailableSequenceNumbers = decoder.ReadUInt32Array("AvailableSequenceNumbers");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is TransferResult transferResult && Utils.IsEqual((object) this.m_statusCode, (object) transferResult.m_statusCode) && Utils.IsEqual((object) this.m_availableSequenceNumbers, (object) transferResult.m_availableSequenceNumbers);
  }

  public virtual object Clone() => (object) (TransferResult) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TransferResult transferResult = (TransferResult) base.MemberwiseClone();
    transferResult.m_statusCode = (StatusCode) Utils.Clone((object) this.m_statusCode);
    transferResult.m_availableSequenceNumbers = (UInt32Collection) Utils.Clone((object) this.m_availableSequenceNumbers);
    return (object) transferResult;
  }
}
