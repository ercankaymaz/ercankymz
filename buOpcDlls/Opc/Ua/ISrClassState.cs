// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ISrClassState
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
public class ISrClassState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAFAAAAElTckNsYXNzVHlwZUluc3RhbmNlAQBpXgEAaV5pXgAA/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQBqXgAvAD9qXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAUHJpb3JpdHkBAGteAC8AP2teAAAAA/////8BAf////8AAAAAFWCJCgIAAAAAAAMAAABWaWQBAGxeAC8AP2xeAAAABf////8BAf////8AAAAA";
  private BaseDataVariableState<byte> m_id;
  private BaseDataVariableState<byte> m_priority;
  private BaseDataVariableState<ushort> m_vid;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24169U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFAAAAElTckNsYXNzVHlwZUluc3RhbmNlAQBpXgEAaV5pXgAA/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQBqXgAvAD9qXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAUHJpb3JpdHkBAGteAC8AP2teAAAAA/////8BAf////8AAAAAFWCJCgIAAAAAAAMAAABWaWQBAGxeAC8AP2xeAAAABf////8BAf////8AAAAA");
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

  public BaseDataVariableState<byte> Id
  {
    get => this.m_id;
    set
    {
      if (this.m_id != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_id = value;
    }
  }

  public BaseDataVariableState<byte> Priority
  {
    get => this.m_priority;
    set
    {
      if (this.m_priority != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_priority = value;
    }
  }

  public BaseDataVariableState<ushort> Vid
  {
    get => this.m_vid;
    set
    {
      if (this.m_vid != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_vid = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_id != null)
      children.Add((BaseInstanceState) this.m_id);
    if (this.m_priority != null)
      children.Add((BaseInstanceState) this.m_priority);
    if (this.m_vid != null)
      children.Add((BaseInstanceState) this.m_vid);
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
      case "Id":
        if (createOrReplace && this.Id == null)
          this.Id = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Id;
        break;
      case "Priority":
        if (createOrReplace && this.Priority == null)
          this.Priority = replacement != null ? (BaseDataVariableState<byte>) replacement : new BaseDataVariableState<byte>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Priority;
        break;
      case "Vid":
        if (createOrReplace && this.Vid == null)
          this.Vid = replacement != null ? (BaseDataVariableState<ushort>) replacement : new BaseDataVariableState<ushort>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Vid;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
