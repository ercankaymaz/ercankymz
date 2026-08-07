// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateUntrustedEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateUntrustedEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q2VydGlmaWNhdGVVbnRydXN0ZWRFdmVudFR5cGVJbnN0YW5jZQEAJwgBACcIJwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQA9DQAuAEQ9DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQA+DQAuAEQ+DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAPw0ALgBEPw0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAEANAC4AREANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBBDQAuAERBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAQg0ALgBEQg0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEARA0ALgBERA0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBFDQAuAERFDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBGDQAuAERGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAEcNAC4AREcNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEASA0ALgBESA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEASQ0ALgBESQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEASg0ALgBESg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQBLDQAuAERLDQAAAA//////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2087U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKgAAAEF1ZGl0Q2VydGlmaWNhdGVVbnRydXN0ZWRFdmVudFR5cGVJbnN0YW5jZQEAJwgBACcIJwgAAP////8OAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQA9DQAuAEQ9DQAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQA+DQAuAEQ+DQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAPw0ALgBEPw0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAEANAC4AREANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBBDQAuAERBDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAQg0ALgBEQg0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEARA0ALgBERA0AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBFDQAuAERFDQAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBGDQAuAERGDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAEcNAC4AREcNAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEASA0ALgBESA0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEASQ0ALgBESQ0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEASg0ALgBESg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAENlcnRpZmljYXRlAQBLDQAuAERLDQAAAA//////AQH/////AAAAAA==");
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
}
