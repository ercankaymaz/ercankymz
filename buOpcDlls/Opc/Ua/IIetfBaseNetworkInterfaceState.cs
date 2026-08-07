// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIetfBaseNetworkInterfaceState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIetfBaseNetworkInterfaceState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string PhysAddress_InitializationString = "//////////8VYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAElJZXRmQmFzZU5ldHdvcmtJbnRlcmZhY2VUeXBlSW5zdGFuY2UBAFReAQBUXlReAAD/////BAAAABVgiQoCAAAAAAALAAAAQWRtaW5TdGF0dXMBAFVeAC8AP1VeAAABAJRe/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAE9wZXJTdGF0dXMBAFZeAC8AP1ZeAAABAJZe/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3BlZWQBAFheAC8BAFlEWF4AAAAJ/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAF1eAC4ARF1eAAAWAQB5AwFgAAAALwAAAGh0dHA6Ly93d3cub3BjZm91bmRhdGlvbi5vcmcvVUEvdW5pdHMvdW4vY2VmYWN0MDFCAAMCAAAAZW4FAAAAYml0L3MDAgAAAGVuDgAAAGJpdCBwZXIgc2Vjb25kAQB3A/////8BAf////8AAAAA";
  private BaseDataVariableState<InterfaceAdminStatus> m_adminStatus;
  private BaseDataVariableState<InterfaceOperStatus> m_operStatus;
  private BaseDataVariableState<string> m_physAddress;
  private AnalogUnitState<ulong> m_speed;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24148U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJQAAAElJZXRmQmFzZU5ldHdvcmtJbnRlcmZhY2VUeXBlSW5zdGFuY2UBAFReAQBUXlReAAD/////BAAAABVgiQoCAAAAAAALAAAAQWRtaW5TdGF0dXMBAFVeAC8AP1VeAAABAJRe/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAE9wZXJTdGF0dXMBAFZeAC8AP1ZeAAABAJZe/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3BlZWQBAFheAC8BAFlEWF4AAAAJ/////wEB/////wEAAAAVYKkKAgAAAAAAEAAAAEVuZ2luZWVyaW5nVW5pdHMBAF1eAC4ARF1eAAAWAQB5AwFgAAAALwAAAGh0dHA6Ly93d3cub3BjZm91bmRhdGlvbi5vcmcvVUEvdW5pdHMvdW4vY2VmYWN0MDFCAAMCAAAAZW4FAAAAYml0L3MDAgAAAGVuDgAAAGJpdCBwZXIgc2Vjb25kAQB3A/////8BAf////8AAAAA");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.PhysAddress == null)
      return;
    this.PhysAddress.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAFBoeXNBZGRyZXNzAQBXXgAvAD9XXgAAAAz/////AQH/////AAAAAA==");
  }

  public BaseDataVariableState<InterfaceAdminStatus> AdminStatus
  {
    get => this.m_adminStatus;
    set
    {
      if (this.m_adminStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_adminStatus = value;
    }
  }

  public BaseDataVariableState<InterfaceOperStatus> OperStatus
  {
    get => this.m_operStatus;
    set
    {
      if (this.m_operStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_operStatus = value;
    }
  }

  public BaseDataVariableState<string> PhysAddress
  {
    get => this.m_physAddress;
    set
    {
      if (this.m_physAddress != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_physAddress = value;
    }
  }

  public AnalogUnitState<ulong> Speed
  {
    get => this.m_speed;
    set
    {
      if (this.m_speed != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_speed = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_adminStatus != null)
      children.Add((BaseInstanceState) this.m_adminStatus);
    if (this.m_operStatus != null)
      children.Add((BaseInstanceState) this.m_operStatus);
    if (this.m_physAddress != null)
      children.Add((BaseInstanceState) this.m_physAddress);
    if (this.m_speed != null)
      children.Add((BaseInstanceState) this.m_speed);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    switch (browseName.Name)
    {
      case "AdminStatus":
        if (createOrReplace && this.AdminStatus == null)
          this.AdminStatus = replacement != null ? (BaseDataVariableState<InterfaceAdminStatus>) replacement : new BaseDataVariableState<InterfaceAdminStatus>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AdminStatus;
        break;
      case "OperStatus":
        if (createOrReplace && this.OperStatus == null)
          this.OperStatus = replacement != null ? (BaseDataVariableState<InterfaceOperStatus>) replacement : new BaseDataVariableState<InterfaceOperStatus>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OperStatus;
        break;
      case "PhysAddress":
        if (createOrReplace && this.PhysAddress == null)
          this.PhysAddress = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.PhysAddress;
        break;
      case "Speed":
        if (createOrReplace && this.Speed == null)
          this.Speed = replacement != null ? (AnalogUnitState<ulong>) replacement : new AnalogUnitState<ulong>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Speed;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
