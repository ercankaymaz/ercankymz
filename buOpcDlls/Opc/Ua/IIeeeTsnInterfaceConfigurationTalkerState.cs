// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeTsnInterfaceConfigurationTalkerState
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
public class IIeeeTsnInterfaceConfigurationTalkerState(NodeState parent) : 
  IIeeeTsnInterfaceConfigurationState(parent)
{
  private const string TimeAwareOffset_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFRpbWVBd2FyZU9mZnNldAEAgl4ALwA/gl4AAAAH/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAMAAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblRhbGtlclR5cGVJbnN0YW5jZQEAf14BAH9ef14AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQCAXgAvAD+AXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAVGltZUF3YXJlT2Zmc2V0AQCCXgAvAD+CXgAAAAf/////AQH/////AAAAAA==";
  private BaseDataVariableState<uint> m_timeAwareOffset;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24191U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAMAAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblRhbGtlclR5cGVJbnN0YW5jZQEAf14BAH9ef14AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQCAXgAvAD+AXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAVGltZUF3YXJlT2Zmc2V0AQCCXgAvAD+CXgAAAAf/////AQH/////AAAAAA==");
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
    if (this.TimeAwareOffset == null)
      return;
    this.TimeAwareOffset.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFRpbWVBd2FyZU9mZnNldAEAgl4ALwA/gl4AAAAH/////wEB/////wAAAAA=");
  }

  public BaseDataVariableState<uint> TimeAwareOffset
  {
    get => this.m_timeAwareOffset;
    set
    {
      if (this.m_timeAwareOffset != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_timeAwareOffset = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_timeAwareOffset != null)
      children.Add((BaseInstanceState) this.m_timeAwareOffset);
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
    if (browseName.Name == "TimeAwareOffset")
    {
      if (createOrReplace && this.TimeAwareOffset == null)
        this.TimeAwareOffset = replacement != null ? (BaseDataVariableState<uint>) replacement : new BaseDataVariableState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.TimeAwareOffset;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
