// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateInvalidEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateInvalidEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVJbnZhbGlkRXZlbnRUeXBlSW5zdGFuY2UBACYIAQAmCCYIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEALg0ALgBELg0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEALw0ALgBELw0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADANAC4ARDANAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAxDQAuAEQxDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAMg0ALgBEMg0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADMNAC4ARDMNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBADUNAC4ARDUNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEANg0ALgBENg0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEANw0ALgBENw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQA4DQAuAEQ4DQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADkNAC4ARDkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADoNAC4ARDoNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADsNAC4ARDsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEAPA0ALgBEPA0AAAAP/////wEB/////wAAAAA=";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2086U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVJbnZhbGlkRXZlbnRUeXBlSW5zdGFuY2UBACYIAQAmCCYIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEALg0ALgBELg0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEALw0ALgBELw0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBADANAC4ARDANAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQAxDQAuAEQxDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAMg0ALgBEMg0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBADMNAC4ARDMNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBADUNAC4ARDUNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEANg0ALgBENg0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEANw0ALgBENw0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQA4DQAuAEQ4DQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBADkNAC4ARDkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBADoNAC4ARDoNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBADsNAC4ARDsNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEAPA0ALgBEPA0AAAAP/////wEB/////wAAAAA=");
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
