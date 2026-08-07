// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateRevokedEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateRevokedEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVSZXZva2VkRXZlbnRUeXBlSW5zdGFuY2UBACgIAQAoCCgIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATA0ALgBETA0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATQ0ALgBETQ0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE4NAC4ARE4NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBPDQAuAERPDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUA0ALgBEUA0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFENAC4ARFENAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFMNAC4ARFMNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVA0ALgBEVA0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVQ0ALgBEVQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBWDQAuAERWDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFcNAC4ARFcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFgNAC4ARFgNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFkNAC4ARFkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEAWg0ALgBEWg0AAAAP/////wEB/////wAAAAA=";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2088U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEF1ZGl0Q2VydGlmaWNhdGVSZXZva2VkRXZlbnRUeXBlSW5zdGFuY2UBACgIAQAoCCgIAAD/////DgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEATA0ALgBETA0AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEATQ0ALgBETQ0AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAE4NAC4ARE4NAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQBPDQAuAERPDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAUA0ALgBEUA0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAFENAC4ARFENAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAFMNAC4ARFMNAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAVA0ALgBEVA0AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEAVQ0ALgBEVQ0AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQBWDQAuAERWDQAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAFcNAC4ARFcNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAFgNAC4ARFgNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAFkNAC4ARFkNAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABDZXJ0aWZpY2F0ZQEAWg0ALgBEWg0AAAAP/////wEB/////wAAAAA=");
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
