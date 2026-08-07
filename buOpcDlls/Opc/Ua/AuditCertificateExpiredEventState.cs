// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateExpiredEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateExpiredEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVFeHBpcmVkRXZlbnRUeXBlSW5zdGFuY2UBACUIAQAlCCUIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAHw0ALgBEHw0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAIA0ALgBEIA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACENAC4ARCENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAiDQAuAEQiDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAIw0ALgBEIw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACQNAC4ARCQNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBACYNAC4ARCYNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAJw0ALgBEJw0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAKA0ALgBEKA0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQApDQAuAEQpDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBACoNAC4ARCoNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBACsNAC4ARCsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBACwNAC4ARCwNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEALQ0ALgBELQ0AAAAP/////wEB/////wAAAAA=";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2085U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVFeHBpcmVkRXZlbnRUeXBlSW5zdGFuY2UBACUIAQAlCCUIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAHw0ALgBEHw0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAIA0ALgBEIA0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBACENAC4ARCENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAiDQAuAEQiDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAIw0ALgBEIw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBACQNAC4ARCQNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBACYNAC4ARCYNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAJw0ALgBEJw0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAKA0ALgBEKA0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQApDQAuAEQpDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBACoNAC4ARCoNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBACsNAC4ARCsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBACwNAC4ARCwNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEALQ0ALgBELQ0AAAAP/////wEB/////wAAAAA=");
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
