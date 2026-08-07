// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCertificateMismatchEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCertificateMismatchEventState(NodeState parent) : AuditCertificateEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0Q2VydGlmaWNhdGVNaXNtYXRjaEV2ZW50VHlwZUluc3RhbmNlAQApCAEAKQgpCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFsNAC4ARFsNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAFwNAC4ARFwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBdDQAuAERdDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAXg0ALgBEXg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAF8NAC4ARF8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBgDQAuAERgDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBiDQAuAERiDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGMNAC4ARGMNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGQNAC4ARGQNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZQ0ALgBEZQ0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBmDQAuAERmDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBnDQAuAERnDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBoDQAuAERoDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQ2VydGlmaWNhdGUBAGkNAC4ARGkNAAAAD/////8BAf////8AAAAA";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2089U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKQAAAEF1ZGl0Q2VydGlmaWNhdGVNaXNtYXRjaEV2ZW50VHlwZUluc3RhbmNlAQApCAEAKQgpCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFsNAC4ARFsNAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAFwNAC4ARFwNAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBdDQAuAERdDQAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAXg0ALgBEXg0AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAF8NAC4ARF8NAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBgDQAuAERgDQAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBiDQAuAERiDQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGMNAC4ARGMNAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGQNAC4ARGQNAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZQ0ALgBEZQ0AAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBmDQAuAERmDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBnDQAuAERnDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBoDQAuAERoDQAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAQ2VydGlmaWNhdGUBAGkNAC4ARGkNAAAAD/////8BAf////8AAAAA");
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
