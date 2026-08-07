// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IIeeeAutoNegotiationStatusState
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
public class IIeeeAutoNegotiationStatusState(NodeState parent) : BaseInterfaceState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAElJZWVlQXV0b05lZ290aWF0aW9uU3RhdHVzVHlwZUluc3RhbmNlAQCpXgEAqV6pXgAA/////wEAAAAVYIkKAgAAAAAAEQAAAE5lZ290aWF0aW9uU3RhdHVzAQCqXgAvAD+qXgAAAQCYXv////8BAf////8AAAAA";
  private BaseDataVariableState<Opc.Ua.NegotiationStatus> m_negotiationStatus;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 24233U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAElJZWVlQXV0b05lZ290aWF0aW9uU3RhdHVzVHlwZUluc3RhbmNlAQCpXgEAqV6pXgAA/////wEAAAAVYIkKAgAAAAAAEQAAAE5lZ290aWF0aW9uU3RhdHVzAQCqXgAvAD+qXgAAAQCYXv////8BAf////8AAAAA");
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

  public BaseDataVariableState<Opc.Ua.NegotiationStatus> NegotiationStatus
  {
    get => this.m_negotiationStatus;
    set
    {
      if (this.m_negotiationStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_negotiationStatus = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_negotiationStatus != null)
      children.Add((BaseInstanceState) this.m_negotiationStatus);
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
    if (browseName.Name == "NegotiationStatus")
    {
      if (createOrReplace && this.NegotiationStatus == null)
        this.NegotiationStatus = replacement != null ? (BaseDataVariableState<Opc.Ua.NegotiationStatus>) replacement : new BaseDataVariableState<Opc.Ua.NegotiationStatus>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.NegotiationStatus;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
