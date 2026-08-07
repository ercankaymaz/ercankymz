// Decompiled with JetBrains decompiler
// Type: Opc.Ua.CertificateUpdatedAuditEventState
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
public class CertificateUpdatedAuditEventState(NodeState parent) : AuditUpdateMethodEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAENlcnRpZmljYXRlVXBkYXRlZEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAEwxAQBMMUwxAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATTEALgBETTEAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATjEALgBETjEAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE8xAC4ARE8xAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBQMQAuAERQMQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUTEALgBEUTEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFIxAC4ARFIxAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFQxAC4ARFQxAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVTEALgBEVTEAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVjEALgBEVjEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBXMQAuAERXMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFgxAC4ARFgxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFkxAC4ARFkxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFoxAC4ARFoxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAWzEALgBEWzEAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBcMQAuAERcMQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABAAAABDZXJ0aWZpY2F0ZUdyb3VwAQCnNQAuAESnNQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQCoNQAuAESoNQAAABH/////AQH/////AAAAAA==";
  private PropertyState<NodeId> m_certificateGroup;
  private PropertyState<NodeId> m_certificateType;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12620U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAENlcnRpZmljYXRlVXBkYXRlZEF1ZGl0RXZlbnRUeXBlSW5zdGFuY2UBAEwxAQBMMUwxAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATTEALgBETTEAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATjEALgBETjEAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE8xAC4ARE8xAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBQMQAuAERQMQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUTEALgBEUTEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFIxAC4ARFIxAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFQxAC4ARFQxAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVTEALgBEVTEAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVjEALgBEVjEAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBXMQAuAERXMQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFgxAC4ARFgxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFkxAC4ARFkxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFoxAC4ARFoxAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABNZXRob2RJZAEAWzEALgBEWzEAAAAR/////wEB/////wAAAAAXYIkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBcMQAuAERcMQAAABgBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABAAAABDZXJ0aWZpY2F0ZUdyb3VwAQCnNQAuAESnNQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQ2VydGlmaWNhdGVUeXBlAQCoNQAuAESoNQAAABH/////AQH/////AAAAAA==");
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

  public PropertyState<NodeId> CertificateGroup
  {
    get => this.m_certificateGroup;
    set
    {
      if (this.m_certificateGroup != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificateGroup = value;
    }
  }

  public PropertyState<NodeId> CertificateType
  {
    get => this.m_certificateType;
    set
    {
      if (this.m_certificateType != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificateType = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_certificateGroup != null)
      children.Add((BaseInstanceState) this.m_certificateGroup);
    if (this.m_certificateType != null)
      children.Add((BaseInstanceState) this.m_certificateType);
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
      case "CertificateGroup":
        if (createOrReplace && this.CertificateGroup == null)
          this.CertificateGroup = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CertificateGroup;
        break;
      case "CertificateType":
        if (createOrReplace && this.CertificateType == null)
          this.CertificateType = replacement != null ? (PropertyState<NodeId>) replacement : new PropertyState<NodeId>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.CertificateType;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
