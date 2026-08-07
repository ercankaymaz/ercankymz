// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TwoStateDiscreteState
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
public class TwoStateDiscreteState(NodeState parent) : DiscreteItemState<bool>(parent)
{
  private const string InitializationString = "//////////8VYIECAgAAAAAAHAAAAFR3b1N0YXRlRGlzY3JldGVUeXBlSW5zdGFuY2UBAEUJAQBFCUUJAAAAAQEB/////wIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEYJAC4AREYJAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAEcJAC4AREcJAAAAFf////8BAf////8AAAAA";
  private PropertyState<LocalizedText> m_falseState;
  private PropertyState<LocalizedText> m_trueState;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2373U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 1U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override int GetDefaultValueRank() => -1;

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8VYIECAgAAAAAAHAAAAFR3b1N0YXRlRGlzY3JldGVUeXBlSW5zdGFuY2UBAEUJAQBFCUUJAAAAAQEB/////wIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEYJAC4AREYJAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAEcJAC4AREcJAAAAFf////8BAf////8AAAAA");
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

  public PropertyState<LocalizedText> FalseState
  {
    get => this.m_falseState;
    set
    {
      if (this.m_falseState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_falseState = value;
    }
  }

  public PropertyState<LocalizedText> TrueState
  {
    get => this.m_trueState;
    set
    {
      if (this.m_trueState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_trueState = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_falseState != null)
      children.Add((BaseInstanceState) this.m_falseState);
    if (this.m_trueState != null)
      children.Add((BaseInstanceState) this.m_trueState);
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
      case "FalseState":
        if (createOrReplace && this.FalseState == null)
          this.FalseState = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FalseState;
        break;
      case "TrueState":
        if (createOrReplace && this.TrueState == null)
          this.TrueState = replacement != null ? (PropertyState<LocalizedText>) replacement : new PropertyState<LocalizedText>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.TrueState;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
