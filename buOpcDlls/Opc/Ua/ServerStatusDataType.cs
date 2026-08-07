// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerStatusDataType
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
public class ServerStatusDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private DateTime m_startTime;
  private DateTime m_currentTime;
  private ServerState m_state;
  private BuildInfo m_buildInfo;
  private uint m_secondsTillShutdown;
  private LocalizedText m_shutdownReason;

  public ServerStatusDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_startTime = DateTime.MinValue;
    this.m_currentTime = DateTime.MinValue;
    this.m_state = ServerState.Running;
    this.m_buildInfo = new BuildInfo();
    this.m_secondsTillShutdown = 0U;
    this.m_shutdownReason = (LocalizedText) null;
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 1)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "CurrentTime", IsRequired = false, Order = 2)]
  public DateTime CurrentTime
  {
    get => this.m_currentTime;
    set => this.m_currentTime = value;
  }

  [DataMember(Name = "State", IsRequired = false, Order = 3)]
  public ServerState State
  {
    get => this.m_state;
    set => this.m_state = value;
  }

  [DataMember(Name = "BuildInfo", IsRequired = false, Order = 4)]
  public BuildInfo BuildInfo
  {
    get => this.m_buildInfo;
    set
    {
      this.m_buildInfo = value;
      if (value != null)
        return;
      this.m_buildInfo = new BuildInfo();
    }
  }

  [DataMember(Name = "SecondsTillShutdown", IsRequired = false, Order = 5)]
  public uint SecondsTillShutdown
  {
    get => this.m_secondsTillShutdown;
    set => this.m_secondsTillShutdown = value;
  }

  [DataMember(Name = "ShutdownReason", IsRequired = false, Order = 6)]
  public LocalizedText ShutdownReason
  {
    get => this.m_shutdownReason;
    set => this.m_shutdownReason = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ServerStatusDataType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerStatusDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerStatusDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ServerStatusDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteDateTime("CurrentTime", this.CurrentTime);
    encoder.WriteEnumerated("State", (Enum) this.State);
    encoder.WriteEncodeable("BuildInfo", (IEncodeable) this.BuildInfo, typeof (BuildInfo));
    encoder.WriteUInt32("SecondsTillShutdown", this.SecondsTillShutdown);
    encoder.WriteLocalizedText("ShutdownReason", this.ShutdownReason);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.CurrentTime = decoder.ReadDateTime("CurrentTime");
    this.State = (ServerState) decoder.ReadEnumerated("State", typeof (ServerState));
    this.BuildInfo = (BuildInfo) decoder.ReadEncodeable("BuildInfo", typeof (BuildInfo));
    this.SecondsTillShutdown = decoder.ReadUInt32("SecondsTillShutdown");
    this.ShutdownReason = decoder.ReadLocalizedText("ShutdownReason");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is ServerStatusDataType serverStatusDataType && Utils.IsEqual(this.m_startTime, serverStatusDataType.m_startTime) && Utils.IsEqual(this.m_currentTime, serverStatusDataType.m_currentTime) && Utils.IsEqual((object) this.m_state, (object) serverStatusDataType.m_state) && Utils.IsEqual((object) this.m_buildInfo, (object) serverStatusDataType.m_buildInfo) && Utils.IsEqual((object) this.m_secondsTillShutdown, (object) serverStatusDataType.m_secondsTillShutdown) && Utils.IsEqual((object) this.m_shutdownReason, (object) serverStatusDataType.m_shutdownReason);
  }

  public virtual object Clone() => (object) (ServerStatusDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ServerStatusDataType serverStatusDataType = (ServerStatusDataType) base.MemberwiseClone();
    serverStatusDataType.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    serverStatusDataType.m_currentTime = (DateTime) Utils.Clone((object) this.m_currentTime);
    serverStatusDataType.m_state = (ServerState) Utils.Clone((object) this.m_state);
    serverStatusDataType.m_buildInfo = (BuildInfo) Utils.Clone((object) this.m_buildInfo);
    serverStatusDataType.m_secondsTillShutdown = (uint) Utils.Clone((object) this.m_secondsTillShutdown);
    serverStatusDataType.m_shutdownReason = (LocalizedText) Utils.Clone((object) this.m_shutdownReason);
    return (object) serverStatusDataType;
  }
}
