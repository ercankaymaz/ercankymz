// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TransitionEventState
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
public class TransitionEventState(NodeState parent) : BaseEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEABwkBAAcJBwkAAP////8LAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCZDgAuAESZDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCaDgAuAESaDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmw4ALgBEmw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJwOAC4ARJwOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCdDgAuAESdDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAng4ALgBEng4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAoA4ALgBEoA4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQChDgAuAEShDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA1goALwEAygrWCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKoOAC4ARKoOAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABGcm9tU3RhdGUBANcKAC8BAMMK1woAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCiDgAuAESiDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAVG9TdGF0ZQEA2AoALwEAwwrYCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKYOAC4ARKYOAAAAGP////8BAf////8AAAAA";
  private TransitionVariableState m_transition;
  private StateVariableState m_fromState;
  private StateVariableState m_toState;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2311U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFRyYW5zaXRpb25FdmVudFR5cGVJbnN0YW5jZQEABwkBAAcJBwkAAP////8LAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCZDgAuAESZDgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCaDgAuAESaDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmw4ALgBEmw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJwOAC4ARJwOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCdDgAuAESdDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAng4ALgBEng4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAoA4ALgBEoA4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQChDgAuAEShDgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAVHJhbnNpdGlvbgEA1goALwEAygrWCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKoOAC4ARKoOAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABGcm9tU3RhdGUBANcKAC8BAMMK1woAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQCiDgAuAESiDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAVG9TdGF0ZQEA2AoALwEAwwrYCgAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAKYOAC4ARKYOAAAAGP////8BAf////8AAAAA");
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

  public TransitionVariableState Transition
  {
    get => this.m_transition;
    set
    {
      if (this.m_transition != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_transition = value;
    }
  }

  public StateVariableState FromState
  {
    get => this.m_fromState;
    set
    {
      if (this.m_fromState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_fromState = value;
    }
  }

  public StateVariableState ToState
  {
    get => this.m_toState;
    set
    {
      if (this.m_toState != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_toState = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_transition != null)
      children.Add((BaseInstanceState) this.m_transition);
    if (this.m_fromState != null)
      children.Add((BaseInstanceState) this.m_fromState);
    if (this.m_toState != null)
      children.Add((BaseInstanceState) this.m_toState);
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
      case "Transition":
        if (createOrReplace && this.Transition == null)
          this.Transition = replacement != null ? (TransitionVariableState) replacement : new TransitionVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Transition;
        break;
      case "FromState":
        if (createOrReplace && this.FromState == null)
          this.FromState = replacement != null ? (StateVariableState) replacement : new StateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.FromState;
        break;
      case "ToState":
        if (createOrReplace && this.ToState == null)
          this.ToState = replacement != null ? (StateVariableState) replacement : new StateVariableState((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ToState;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
