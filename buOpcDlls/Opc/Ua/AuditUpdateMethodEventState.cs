// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditUpdateMethodEventState
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
public class AuditUpdateMethodEventState(NodeState parent) : AuditEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAEF1ZGl0VXBkYXRlTWV0aG9kRXZlbnRUeXBlSW5zdGFuY2UBAE8IAQBPCE8IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEANw4ALgBENw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAOA4ALgBEOA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADkOAC4ARDkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQA6DgAuAEQ6DgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAOw4ALgBEOw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADwOAC4ARDwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAD4OAC4ARD4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAPw4ALgBEPw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAQA4ALgBEQA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBBDgAuAERBDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAEIOAC4AREIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAEMOAC4AREMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEQOAC4AREQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAUAgALgBEUAgAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBRCAAuAERRCAAAABgBAAAAAQAAAAAAAAABAf////8AAAAA";
  private PropertyState<NodeId> m_methodId;
  private PropertyState<object[]> m_inputArguments;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2127U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIgAAAEF1ZGl0VXBkYXRlTWV0aG9kRXZlbnRUeXBlSW5zdGFuY2UBAE8IAQBPCE8IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEANw4ALgBENw4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAOA4ALgBEOA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADkOAC4ARDkOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQA6DgAuAEQ6DgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAOw4ALgBEOw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADwOAC4ARDwOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAD4OAC4ARD4OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAPw4ALgBEPw4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAQA4ALgBEQA4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBBDgAuAERBDgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAEIOAC4AREIOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAEMOAC4AREMOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAEQOAC4AREQOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAUAgALgBEUAgAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBRCAAuAERRCAAAABgBAAAAAQAAAAAAAAABAf////8AAAAA");
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

  public PropertyState<NodeId> MethodId
  {
    get => this.m_methodId;
    set
    {
      if (this.m_methodId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_methodId = value;
    }
  }

  public PropertyState<object[]> InputArguments
  {
    get => this.m_inputArguments;
    set
    {
      if (this.m_inputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_inputArguments = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_methodId != null)
      children.Add((BaseInstanceState) this.m_methodId);
    if (this.m_inputArguments != null)
      children.Add((BaseInstanceState) this.m_inputArguments);
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
      case "MethodId":
        if (createOrReplace && this.MethodId == null)
          this.MethodId = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MethodId;
        break;
      case "InputArguments":
        if (createOrReplace && this.InputArguments == null)
          this.InputArguments = replacement != null ? (PropertyState<object[]>) replacement : new PropertyState<object[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InputArguments;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
