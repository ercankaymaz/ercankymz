// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeBaseTsnStreamState
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
public class IIeeeBaseTsnStreamState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string AccumulatedLatency_InitializationString = "//////////8VYIkKAgAAAAAAEgAAAEFjY3VtdWxhdGVkTGF0ZW5jeQEAcV4ALwA/cV4AAAAH/////wEB/////wAAAAA=";
  private const string SrClassId_InitializationString = "//////////8VYIkKAgAAAAAACQAAAFNyQ2xhc3NJZAEAcl4ALwA/cl4AAAAD/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAElJZWVlQmFzZVRzblN0cmVhbVR5cGVJbnN0YW5jZQEAbV4BAG1ebV4AAP////8FAAAAF2CJCgIAAAAAAAgAAABTdHJlYW1JZAEAbl4ALwA/bl4AAAADAQAAAAEAAAAIAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAU3RyZWFtTmFtZQEAb14ALwA/b14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBwXgAvAD9wXgAAAQCcXv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBY2N1bXVsYXRlZExhdGVuY3kBAHFeAC8AP3FeAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTckNsYXNzSWQBAHJeAC8AP3JeAAAAA/////8BAf////8AAAAA";
  private BaseDataVariableState<byte[]> m_streamId;
  private BaseDataVariableState<string> m_streamName;
  private BaseDataVariableState<TsnStreamState> m_state;
  private BaseDataVariableState<uint> m_accumulatedLatency;
  private BaseDataVariableState<byte> m_srClassId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24173U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAElJZWVlQmFzZVRzblN0cmVhbVR5cGVJbnN0YW5jZQEAbV4BAG1ebV4AAP////8FAAAAF2CJCgIAAAAAAAgAAABTdHJlYW1JZAEAbl4ALwA/bl4AAAADAQAAAAEAAAAIAAAAAQH/////AAAAABVgiQoCAAAAAAAKAAAAU3RyZWFtTmFtZQEAb14ALwA/b14AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABQAAAFN0YXRlAQBwXgAvAD9wXgAAAQCcXv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABBY2N1bXVsYXRlZExhdGVuY3kBAHFeAC8AP3FeAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTckNsYXNzSWQBAHJeAC8AP3JeAAAAA/////8BAf////8AAAAA");
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
    if (this.AccumulatedLatency != null)
      this.AccumulatedLatency.Initialize(context, "//////////8VYIkKAgAAAAAAEgAAAEFjY3VtdWxhdGVkTGF0ZW5jeQEAcV4ALwA/cV4AAAAH/////wEB/////wAAAAA=");
    if (this.SrClassId == null)
      return;
    this.SrClassId.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAFNyQ2xhc3NJZAEAcl4ALwA/cl4AAAAD/////wEB/////wAAAAA=");
  }

  public BaseDataVariableState<byte[]> StreamId
  {
    get => this.m_streamId;
    set
    {
      if (this.m_streamId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_streamId = value;
    }
  }

  public BaseDataVariableState<string> StreamName
  {
    get => this.m_streamName;
    set
    {
      if (this.m_streamName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_streamName = value;
    }
  }

  public BaseDataVariableState<TsnStreamState> State
  {
    get => this.m_state;
    set
    {
      if (this.m_state != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_state = value;
    }
  }

  public BaseDataVariableState<uint> AccumulatedLatency
  {
    get => this.m_accumulatedLatency;
    set
    {
      if (this.m_accumulatedLatency != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_accumulatedLatency = value;
    }
  }

  public BaseDataVariableState<byte> SrClassId
  {
    get => this.m_srClassId;
    set
    {
      if (this.m_srClassId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_srClassId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_streamId != null)
      children.Add((BaseInstanceState) this.m_streamId);
    if (this.m_streamName != null)
      children.Add((BaseInstanceState) this.m_streamName);
    if (this.m_state != null)
      children.Add((BaseInstanceState) this.m_state);
    if (this.m_accumulatedLatency != null)
      children.Add((BaseInstanceState) this.m_accumulatedLatency);
    if (this.m_srClassId != null)
      children.Add((BaseInstanceState) this.m_srClassId);
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
      case "StreamId":
        if (createOrReplace && this.StreamId == null)
          this.StreamId = replacement != null ? (BaseDataVariableState<byte[]>) replacement : new BaseDataVariableState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.StreamId;
        break;
      case "StreamName":
        if (createOrReplace && this.StreamName == null)
          this.StreamName = replacement != null ? (BaseDataVariableState<string>) replacement : new BaseDataVariableState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.StreamName;
        break;
      case "State":
        if (createOrReplace && this.State == null)
          this.State = replacement != null ? (BaseDataVariableState<TsnStreamState>) replacement : new BaseDataVariableState<TsnStreamState>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.State;
        break;
      case "AccumulatedLatency":
        if (createOrReplace && this.AccumulatedLatency == null)
          this.AccumulatedLatency = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AccumulatedLatency;
        break;
      case "SrClassId":
        if (createOrReplace && this.SrClassId == null)
          this.SrClassId = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SrClassId;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
