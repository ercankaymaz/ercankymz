// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateEventState
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
public class AuditCertificateEventState(NodeState parent) : AuditSecurityEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0Q2VydGlmaWNhdGVFdmVudFR5cGVJbnN0YW5jZQEAIAgBACAIIAgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQACDQAuAEQCDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQADDQAuAEQDDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEABA0ALgBEBA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAAUNAC4ARAUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAGDQAuAEQGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEABw0ALgBEBw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEACQ0ALgBECQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAKDQAuAEQKDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQALDQAuAEQLDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAAwNAC4ARAwNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEADQ0ALgBEDQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEADg0ALgBEDg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEADw0ALgBEDw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAhCAAuAEQhCAAAAA//////AQH/////AAAAAA==";
  private PropertyState<byte[]> m_certificate;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2080U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0Q2VydGlmaWNhdGVFdmVudFR5cGVJbnN0YW5jZQEAIAgBACAIIAgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQACDQAuAEQCDQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQADDQAuAEQDDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEABA0ALgBEBA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAAUNAC4ARAUNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQAGDQAuAEQGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEABw0ALgBEBw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEACQ0ALgBECQ0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQAKDQAuAEQKDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQALDQAuAEQLDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAAwNAC4ARAwNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEADQ0ALgBEDQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEADg0ALgBEDg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEADw0ALgBEDw0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQAhCAAuAEQhCAAAAA//////AQH/////AAAAAA==");
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

  public PropertyState<byte[]> Certificate
  {
    get => this.m_certificate;
    set
    {
      if (this.m_certificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificate = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_certificate != null)
      children.Add((BaseInstanceState) this.m_certificate);
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
    if (browseName.Name == "Certificate")
    {
      if (createOrReplace && this.Certificate == null)
        this.Certificate = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Certificate;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
