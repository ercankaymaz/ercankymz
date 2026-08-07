// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeBaseEthernetPortState
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
public class IIeeeBaseEthernetPortState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAElJZWVlQmFzZUV0aGVybmV0UG9ydFR5cGVJbnN0YW5jZQEAXl4BAF5eXl4AAP////8DAAAAFWCJCgIAAAAAAAUAAABTcGVlZAEAX14ALwEAWURfXgAAAAn/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAZF4ALgBEZF4AABYBAHkDAWUAAAAvAAAAaHR0cDovL3d3dy5vcGNmb3VuZGF0aW9uLm9yZy9VQS91bml0cy91bi9jZWZhY3QwMkUAAwIAAABlbgYAAABNYml0L3MDAgAAAGVuEgAAAG1lZ2FiaXQgcGVyIHNlY29uZAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARHVwbGV4AQBlXgAvAD9lXgAAAQCSXv////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABNYXhGcmFtZUxlbmd0aAEAZl4ALwA/Zl4AAAAF/////wEB/////wAAAAA=";
  private AnalogUnitState<ulong> m_speed;
  private BaseDataVariableState<Opc.Ua.Duplex> m_duplex;
  private BaseDataVariableState<ushort> m_maxFrameLength;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24158U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAElJZWVlQmFzZUV0aGVybmV0UG9ydFR5cGVJbnN0YW5jZQEAXl4BAF5eXl4AAP////8DAAAAFWCJCgIAAAAAAAUAAABTcGVlZAEAX14ALwEAWURfXgAAAAn/////AQH/////AQAAABVgqQoCAAAAAAAQAAAARW5naW5lZXJpbmdVbml0cwEAZF4ALgBEZF4AABYBAHkDAWUAAAAvAAAAaHR0cDovL3d3dy5vcGNmb3VuZGF0aW9uLm9yZy9VQS91bml0cy91bi9jZWZhY3QwMkUAAwIAAABlbgYAAABNYml0L3MDAgAAAGVuEgAAAG1lZ2FiaXQgcGVyIHNlY29uZAEAdwP/////AQH/////AAAAABVgiQoCAAAAAAAGAAAARHVwbGV4AQBlXgAvAD9lXgAAAQCSXv////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABNYXhGcmFtZUxlbmd0aAEAZl4ALwA/Zl4AAAAF/////wEB/////wAAAAA=");
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

  public BaseDataVariableState<Opc.Ua.Duplex> Duplex
  {
    get => this.m_duplex;
    set
    {
      if (this.m_duplex != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_duplex = value;
    }
  }

  public BaseDataVariableState<ushort> MaxFrameLength
  {
    get => this.m_maxFrameLength;
    set
    {
      if (this.m_maxFrameLength != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxFrameLength = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_speed != null)
      children.Add((BaseInstanceState) this.m_speed);
    if (this.m_duplex != null)
      children.Add((BaseInstanceState) this.m_duplex);
    if (this.m_maxFrameLength != null)
      children.Add((BaseInstanceState) this.m_maxFrameLength);
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
      case "Speed":
        if (createOrReplace && this.Speed == null)
          this.Speed = replacement != null ? (AnalogUnitState<ulong>) replacement : new AnalogUnitState<ulong>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Speed;
        break;
      case "Duplex":
        if (createOrReplace && this.Duplex == null)
          this.Duplex = replacement != null ? (BaseDataVariableState<Opc.Ua.Duplex>) replacement : new BaseDataVariableState<Opc.Ua.Duplex>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Duplex;
        break;
      case "MaxFrameLength":
        if (createOrReplace && this.MaxFrameLength == null)
          this.MaxFrameLength = replacement != null ? (BaseDataVariableState<ushort>) replacement : new BaseDataVariableState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxFrameLength;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
