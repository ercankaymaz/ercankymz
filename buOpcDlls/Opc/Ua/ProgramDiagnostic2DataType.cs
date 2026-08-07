// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramDiagnostic2DataType
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
public class ProgramDiagnostic2DataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_createSessionId;
  private string m_createClientName;
  private DateTime m_invocationCreationTime;
  private DateTime m_lastTransitionTime;
  private string m_lastMethodCall;
  private NodeId m_lastMethodSessionId;
  private ArgumentCollection m_lastMethodInputArguments;
  private ArgumentCollection m_lastMethodOutputArguments;
  private VariantCollection m_lastMethodInputValues;
  private VariantCollection m_lastMethodOutputValues;
  private DateTime m_lastMethodCallTime;
  private StatusCode m_lastMethodReturnStatus;

  public ProgramDiagnostic2DataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_createSessionId = (NodeId) null;
    this.m_createClientName = (string) null;
    this.m_invocationCreationTime = DateTime.MinValue;
    this.m_lastTransitionTime = DateTime.MinValue;
    this.m_lastMethodCall = (string) null;
    this.m_lastMethodSessionId = (NodeId) null;
    this.m_lastMethodInputArguments = new ArgumentCollection();
    this.m_lastMethodOutputArguments = new ArgumentCollection();
    this.m_lastMethodInputValues = new VariantCollection();
    this.m_lastMethodOutputValues = new VariantCollection();
    this.m_lastMethodCallTime = DateTime.MinValue;
    this.m_lastMethodReturnStatus = (StatusCode) 0U;
  }

  [DataMember(Name = "CreateSessionId", IsRequired = false, Order = 1)]
  public NodeId CreateSessionId
  {
    get => this.m_createSessionId;
    set => this.m_createSessionId = value;
  }

  [DataMember(Name = "CreateClientName", IsRequired = false, Order = 2)]
  public string CreateClientName
  {
    get => this.m_createClientName;
    set => this.m_createClientName = value;
  }

  [DataMember(Name = "InvocationCreationTime", IsRequired = false, Order = 3)]
  public DateTime InvocationCreationTime
  {
    get => this.m_invocationCreationTime;
    set => this.m_invocationCreationTime = value;
  }

  [DataMember(Name = "LastTransitionTime", IsRequired = false, Order = 4)]
  public DateTime LastTransitionTime
  {
    get => this.m_lastTransitionTime;
    set => this.m_lastTransitionTime = value;
  }

  [DataMember(Name = "LastMethodCall", IsRequired = false, Order = 5)]
  public string LastMethodCall
  {
    get => this.m_lastMethodCall;
    set => this.m_lastMethodCall = value;
  }

  [DataMember(Name = "LastMethodSessionId", IsRequired = false, Order = 6)]
  public NodeId LastMethodSessionId
  {
    get => this.m_lastMethodSessionId;
    set => this.m_lastMethodSessionId = value;
  }

  [DataMember(Name = "LastMethodInputArguments", IsRequired = false, Order = 7)]
  public ArgumentCollection LastMethodInputArguments
  {
    get => this.m_lastMethodInputArguments;
    set
    {
      this.m_lastMethodInputArguments = value;
      if (value != null)
        return;
      this.m_lastMethodInputArguments = new ArgumentCollection();
    }
  }

  [DataMember(Name = "LastMethodOutputArguments", IsRequired = false, Order = 8)]
  public ArgumentCollection LastMethodOutputArguments
  {
    get => this.m_lastMethodOutputArguments;
    set
    {
      this.m_lastMethodOutputArguments = value;
      if (value != null)
        return;
      this.m_lastMethodOutputArguments = new ArgumentCollection();
    }
  }

  [DataMember(Name = "LastMethodInputValues", IsRequired = false, Order = 9)]
  public VariantCollection LastMethodInputValues
  {
    get => this.m_lastMethodInputValues;
    set
    {
      this.m_lastMethodInputValues = value;
      if (value != null)
        return;
      this.m_lastMethodInputValues = new VariantCollection();
    }
  }

  [DataMember(Name = "LastMethodOutputValues", IsRequired = false, Order = 10)]
  public VariantCollection LastMethodOutputValues
  {
    get => this.m_lastMethodOutputValues;
    set
    {
      this.m_lastMethodOutputValues = value;
      if (value != null)
        return;
      this.m_lastMethodOutputValues = new VariantCollection();
    }
  }

  [DataMember(Name = "LastMethodCallTime", IsRequired = false, Order = 11)]
  public DateTime LastMethodCallTime
  {
    get => this.m_lastMethodCallTime;
    set => this.m_lastMethodCallTime = value;
  }

  [DataMember(Name = "LastMethodReturnStatus", IsRequired = false, Order = 12)]
  public StatusCode LastMethodReturnStatus
  {
    get => this.m_lastMethodReturnStatus;
    set => this.m_lastMethodReturnStatus = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ProgramDiagnostic2DataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnostic2DataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("CreateSessionId", this.CreateSessionId);
    encoder.WriteString("CreateClientName", this.CreateClientName);
    encoder.WriteDateTime("InvocationCreationTime", this.InvocationCreationTime);
    encoder.WriteDateTime("LastTransitionTime", this.LastTransitionTime);
    encoder.WriteString("LastMethodCall", this.LastMethodCall);
    encoder.WriteNodeId("LastMethodSessionId", this.LastMethodSessionId);
    encoder.WriteEncodeableArray("LastMethodInputArguments", (IList<IEncodeable>) this.LastMethodInputArguments.ToArray(), typeof (Argument));
    encoder.WriteEncodeableArray("LastMethodOutputArguments", (IList<IEncodeable>) this.LastMethodOutputArguments.ToArray(), typeof (Argument));
    encoder.WriteVariantArray("LastMethodInputValues", (IList<Variant>) this.LastMethodInputValues);
    encoder.WriteVariantArray("LastMethodOutputValues", (IList<Variant>) this.LastMethodOutputValues);
    encoder.WriteDateTime("LastMethodCallTime", this.LastMethodCallTime);
    encoder.WriteStatusCode("LastMethodReturnStatus", this.LastMethodReturnStatus);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.CreateSessionId = decoder.ReadNodeId("CreateSessionId");
    this.CreateClientName = decoder.ReadString("CreateClientName");
    this.InvocationCreationTime = decoder.ReadDateTime("InvocationCreationTime");
    this.LastTransitionTime = decoder.ReadDateTime("LastTransitionTime");
    this.LastMethodCall = decoder.ReadString("LastMethodCall");
    this.LastMethodSessionId = decoder.ReadNodeId("LastMethodSessionId");
    this.LastMethodInputArguments = (ArgumentCollection) (Argument[]) decoder.ReadEncodeableArray("LastMethodInputArguments", typeof (Argument));
    this.LastMethodOutputArguments = (ArgumentCollection) (Argument[]) decoder.ReadEncodeableArray("LastMethodOutputArguments", typeof (Argument));
    this.LastMethodInputValues = decoder.ReadVariantArray("LastMethodInputValues");
    this.LastMethodOutputValues = decoder.ReadVariantArray("LastMethodOutputValues");
    this.LastMethodCallTime = decoder.ReadDateTime("LastMethodCallTime");
    this.LastMethodReturnStatus = decoder.ReadStatusCode("LastMethodReturnStatus");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ProgramDiagnostic2DataType diagnostic2DataType && Utils.IsEqual((object) this.m_createSessionId, (object) diagnostic2DataType.m_createSessionId) && Utils.IsEqual((object) this.m_createClientName, (object) diagnostic2DataType.m_createClientName) && Utils.IsEqual(this.m_invocationCreationTime, diagnostic2DataType.m_invocationCreationTime) && Utils.IsEqual(this.m_lastTransitionTime, diagnostic2DataType.m_lastTransitionTime) && Utils.IsEqual((object) this.m_lastMethodCall, (object) diagnostic2DataType.m_lastMethodCall) && Utils.IsEqual((object) this.m_lastMethodSessionId, (object) diagnostic2DataType.m_lastMethodSessionId) && Utils.IsEqual((object) this.m_lastMethodInputArguments, (object) diagnostic2DataType.m_lastMethodInputArguments) && Utils.IsEqual((object) this.m_lastMethodOutputArguments, (object) diagnostic2DataType.m_lastMethodOutputArguments) && Utils.IsEqual((object) this.m_lastMethodInputValues, (object) diagnostic2DataType.m_lastMethodInputValues) && Utils.IsEqual((object) this.m_lastMethodOutputValues, (object) diagnostic2DataType.m_lastMethodOutputValues) && Utils.IsEqual(this.m_lastMethodCallTime, diagnostic2DataType.m_lastMethodCallTime) && Utils.IsEqual((object) this.m_lastMethodReturnStatus, (object) diagnostic2DataType.m_lastMethodReturnStatus);
  }

  public virtual object Clone() => (object) (ProgramDiagnostic2DataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ProgramDiagnostic2DataType diagnostic2DataType = (ProgramDiagnostic2DataType) base.MemberwiseClone();
    diagnostic2DataType.m_createSessionId = (NodeId) Utils.Clone((object) this.m_createSessionId);
    diagnostic2DataType.m_createClientName = (string) Utils.Clone((object) this.m_createClientName);
    diagnostic2DataType.m_invocationCreationTime = (DateTime) Utils.Clone((object) this.m_invocationCreationTime);
    diagnostic2DataType.m_lastTransitionTime = (DateTime) Utils.Clone((object) this.m_lastTransitionTime);
    diagnostic2DataType.m_lastMethodCall = (string) Utils.Clone((object) this.m_lastMethodCall);
    diagnostic2DataType.m_lastMethodSessionId = (NodeId) Utils.Clone((object) this.m_lastMethodSessionId);
    diagnostic2DataType.m_lastMethodInputArguments = (ArgumentCollection) Utils.Clone((object) this.m_lastMethodInputArguments);
    diagnostic2DataType.m_lastMethodOutputArguments = (ArgumentCollection) Utils.Clone((object) this.m_lastMethodOutputArguments);
    diagnostic2DataType.m_lastMethodInputValues = (VariantCollection) Utils.Clone((object) this.m_lastMethodInputValues);
    diagnostic2DataType.m_lastMethodOutputValues = (VariantCollection) Utils.Clone((object) this.m_lastMethodOutputValues);
    diagnostic2DataType.m_lastMethodCallTime = (DateTime) Utils.Clone((object) this.m_lastMethodCallTime);
    diagnostic2DataType.m_lastMethodReturnStatus = (StatusCode) Utils.Clone((object) this.m_lastMethodReturnStatus);
    return (object) diagnostic2DataType;
  }
}
