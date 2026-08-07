// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditSecurityEventState
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
public class AuditSecurityEventState(NodeState parent) : AuditEventState(parent)
{
  private const string StatusCodeId_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0U2VjdXJpdHlFdmVudFR5cGVJbnN0YW5jZQEACggBAAoICggAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCJDAAuAESJDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCKDAAuAESKDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiwwALgBEiwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIwMAC4ARIwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCNDAAuAESNDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjgwALgBEjgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkAwALgBEkAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCRDAAuAESRDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCSDAAuAESSDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJMMAC4ARJMMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAlAwALgBElAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAlQwALgBElQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAlgwALgBElgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=";
  private PropertyState<StatusCode> m_statusCodeId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2058U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAEF1ZGl0U2VjdXJpdHlFdmVudFR5cGVJbnN0YW5jZQEACggBAAoICggAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCJDAAuAESJDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCKDAAuAESKDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAiwwALgBEiwwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAIwMAC4ARIwMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCNDAAuAESNDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjgwALgBEjgwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkAwALgBEkAwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCRDAAuAESRDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQCSDAAuAESSDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAJMMAC4ARJMMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAlAwALgBElAwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAlQwALgBElQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAlgwALgBElgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=");
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
    if (this.StatusCodeId == null)
      return;
    this.StatusCodeId.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFN0YXR1c0NvZGVJZAEAz0QALgBEz0QAAAAT/////wEB/////wAAAAA=");
  }

  public PropertyState<StatusCode> StatusCodeId
  {
    get => this.m_statusCodeId;
    set
    {
      if (this.m_statusCodeId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_statusCodeId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_statusCodeId != null)
      children.Add((BaseInstanceState) this.m_statusCodeId);
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
    if (browseName.Name == "StatusCodeId")
    {
      if (createOrReplace && this.StatusCodeId == null)
        this.StatusCodeId = replacement != null ? (PropertyState<StatusCode>) replacement : new PropertyState<StatusCode>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.StatusCodeId;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
