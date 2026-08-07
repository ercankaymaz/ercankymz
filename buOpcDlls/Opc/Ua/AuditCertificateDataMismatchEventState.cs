// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateDataMismatchEventState
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
public class AuditCertificateDataMismatchEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1ZGl0Q2VydGlmaWNhdGVEYXRhTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAIggBACIIIggAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAQDQAuAEQQDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQARDQAuAEQRDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAEg0ALgBEEg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABMNAC4ARBMNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAUDQAuAEQUDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAFQ0ALgBEFQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAFw0ALgBEFw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAYDQAuAEQYDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQAZDQAuAEQZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBABoNAC4ARBoNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAGw0ALgBEGw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAHA0ALgBEHA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAHQ0ALgBEHQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAeDQAuAEQeDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAPAAAASW52YWxpZEhvc3RuYW1lAQAjCAAuAEQjCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW52YWxpZFVyaQEAJAgALgBEJAgAAAAM/////wEB/////wAAAAA=";
  private PropertyState<string> m_invalidHostname;
  private PropertyState<string> m_invalidUri;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2082U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1ZGl0Q2VydGlmaWNhdGVEYXRhTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAIggBACIIIggAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQAQDQAuAEQQDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQARDQAuAEQRDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAEg0ALgBEEg0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBABMNAC4ARBMNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAUDQAuAEQUDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAFQ0ALgBEFQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAFw0ALgBEFw0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAYDQAuAEQYDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQAZDQAuAEQZDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBABoNAC4ARBoNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAGw0ALgBEGw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAHA0ALgBEHA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAHQ0ALgBEHQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAeDQAuAEQeDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAPAAAASW52YWxpZEhvc3RuYW1lAQAjCAAuAEQjCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAASW52YWxpZFVyaQEAJAgALgBEJAgAAAAM/////wEB/////wAAAAA=");
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

  public PropertyState<string> InvalidHostname
  {
    get => this.m_invalidHostname;
    set
    {
      if (this.m_invalidHostname != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_invalidHostname = value;
    }
  }

  public PropertyState<string> InvalidUri
  {
    get => this.m_invalidUri;
    set
    {
      if (this.m_invalidUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_invalidUri = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_invalidHostname != null)
      children.Add((BaseInstanceState) this.m_invalidHostname);
    if (this.m_invalidUri != null)
      children.Add((BaseInstanceState) this.m_invalidUri);
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
      case "InvalidHostname":
        if (createOrReplace && this.InvalidHostname == null)
          this.InvalidHostname = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InvalidHostname;
        break;
      case "InvalidUri":
        if (createOrReplace && this.InvalidUri == null)
          this.InvalidUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InvalidUri;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
