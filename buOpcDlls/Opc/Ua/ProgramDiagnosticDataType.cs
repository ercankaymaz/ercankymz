// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramDiagnosticDataType
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
public class ProgramDiagnosticDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private NodeId m_createSessionId;
  private string m_createClientName;
  private DateTime m_invocationCreationTime;
  private DateTime m_lastTransitionTime;
  private string m_lastMethodCall;
  private NodeId m_lastMethodSessionId;
  private ArgumentCollection m_lastMethodInputArguments;
  private ArgumentCollection m_lastMethodOutputArguments;
  private DateTime m_lastMethodCallTime;
  private StatusResult m_lastMethodReturnStatus;

  public ProgramDiagnosticDataType() => this.Initialize();

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
    this.m_lastMethodCallTime = DateTime.MinValue;
    this.m_lastMethodReturnStatus = new StatusResult();
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

  [DataMember(Name = "LastMethodCallTime", IsRequired = false, Order = 9)]
  public DateTime LastMethodCallTime
  {
    get => this.m_lastMethodCallTime;
    set => this.m_lastMethodCallTime = value;
  }

  [DataMember(Name = "LastMethodReturnStatus", IsRequired = false, Order = 10)]
  public StatusResult LastMethodReturnStatus
  {
    get => this.m_lastMethodReturnStatus;
    set
    {
      this.m_lastMethodReturnStatus = value;
      if (value != null)
        return;
      this.m_lastMethodReturnStatus = new StatusResult();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ProgramDiagnosticDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ProgramDiagnosticDataType_Encoding_DefaultJson;
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
    encoder.WriteDateTime("LastMethodCallTime", this.LastMethodCallTime);
    encoder.WriteEncodeable("LastMethodReturnStatus", (IEncodeable) this.LastMethodReturnStatus, typeof (StatusResult));
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
    this.LastMethodCallTime = decoder.ReadDateTime("LastMethodCallTime");
    this.LastMethodReturnStatus = (StatusResult) decoder.ReadEncodeable("LastMethodReturnStatus", typeof (StatusResult));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ProgramDiagnosticDataType diagnosticDataType && Utils.IsEqual((object) this.m_createSessionId, (object) diagnosticDataType.m_createSessionId) && Utils.IsEqual((object) this.m_createClientName, (object) diagnosticDataType.m_createClientName) && Utils.IsEqual(this.m_invocationCreationTime, diagnosticDataType.m_invocationCreationTime) && Utils.IsEqual(this.m_lastTransitionTime, diagnosticDataType.m_lastTransitionTime) && Utils.IsEqual((object) this.m_lastMethodCall, (object) diagnosticDataType.m_lastMethodCall) && Utils.IsEqual((object) this.m_lastMethodSessionId, (object) diagnosticDataType.m_lastMethodSessionId) && Utils.IsEqual((object) this.m_lastMethodInputArguments, (object) diagnosticDataType.m_lastMethodInputArguments) && Utils.IsEqual((object) this.m_lastMethodOutputArguments, (object) diagnosticDataType.m_lastMethodOutputArguments) && Utils.IsEqual(this.m_lastMethodCallTime, diagnosticDataType.m_lastMethodCallTime) && Utils.IsEqual((object) this.m_lastMethodReturnStatus, (object) diagnosticDataType.m_lastMethodReturnStatus);
  }

  public virtual object Clone() => (object) (ProgramDiagnosticDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ProgramDiagnosticDataType diagnosticDataType = (ProgramDiagnosticDataType) base.MemberwiseClone();
    diagnosticDataType.m_createSessionId = (NodeId) Utils.Clone((object) this.m_createSessionId);
    diagnosticDataType.m_createClientName = (string) Utils.Clone((object) this.m_createClientName);
    diagnosticDataType.m_invocationCreationTime = (DateTime) Utils.Clone((object) this.m_invocationCreationTime);
    diagnosticDataType.m_lastTransitionTime = (DateTime) Utils.Clone((object) this.m_lastTransitionTime);
    diagnosticDataType.m_lastMethodCall = (string) Utils.Clone((object) this.m_lastMethodCall);
    diagnosticDataType.m_lastMethodSessionId = (NodeId) Utils.Clone((object) this.m_lastMethodSessionId);
    diagnosticDataType.m_lastMethodInputArguments = (ArgumentCollection) Utils.Clone((object) this.m_lastMethodInputArguments);
    diagnosticDataType.m_lastMethodOutputArguments = (ArgumentCollection) Utils.Clone((object) this.m_lastMethodOutputArguments);
    diagnosticDataType.m_lastMethodCallTime = (DateTime) Utils.Clone((object) this.m_lastMethodCallTime);
    diagnosticDataType.m_lastMethodReturnStatus = (StatusResult) Utils.Clone((object) this.m_lastMethodReturnStatus);
    return (object) diagnosticDataType;
  }
}
