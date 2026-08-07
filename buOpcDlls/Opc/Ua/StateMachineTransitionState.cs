// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StateMachineTransitionState
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
public class StateMachineTransitionState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAFRyYW5zaXRpb25UeXBlSW5zdGFuY2UBAAYJAQAGCQYJAAD/////AQAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEACAkALgBECAkAAAAH/////wEB/////wAAAAA=";
  private PropertyState<uint> m_transitionNumber;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2310U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAFgAAAFRyYW5zaXRpb25UeXBlSW5zdGFuY2UBAAYJAQAGCQYJAAD/////AQAAABVgiQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEACAkALgBECAkAAAAH/////wEB/////wAAAAA=");
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

  public PropertyState<uint> TransitionNumber
  {
    get => this.m_transitionNumber;
    set
    {
      if (this.m_transitionNumber != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transitionNumber = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_transitionNumber != null)
      children.Add((BaseInstanceState) this.m_transitionNumber);
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
    if (browseName.Name == "TransitionNumber")
    {
      if (createOrReplace && this.TransitionNumber == null)
        this.TransitionNumber = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.TransitionNumber;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
