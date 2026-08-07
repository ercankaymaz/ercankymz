// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StateMachineStateState
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
public class StateMachineStateState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAEQAAAFN0YXRlVHlwZUluc3RhbmNlAQADCQEAAwkDCQAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAECQAuAEQECQAAAAf/////AQH/////AAAAAA==";
  private PropertyState<uint> m_stateNumber;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2307U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAEQAAAFN0YXRlVHlwZUluc3RhbmNlAQADCQEAAwkDCQAA/////wEAAAAVYIkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQAECQAuAEQECQAAAAf/////AQH/////AAAAAA==");
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

  public PropertyState<uint> StateNumber
  {
    get => this.m_stateNumber;
    set
    {
      if (this.m_stateNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_stateNumber = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_stateNumber != null)
      children.Add((BaseInstanceState) this.m_stateNumber);
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
    if (browseName.Name == "StateNumber")
    {
      if (createOrReplace && this.StateNumber == null)
        this.StateNumber = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.StateNumber;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
