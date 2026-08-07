// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RefreshRequiredEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RefreshRequiredEventState(NodeState parent) : SystemEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIAAAAFJlZnJlc2hSZXF1aXJlZEV2ZW50VHlwZUluc3RhbmNlAQDlCgEA5QrlCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJMPAC4ARJMPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJQPAC4ARJQPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCVDwAuAESVDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlg8ALgBElg8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJcPAC4ARJcPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCYDwAuAESYDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCaDwAuAESaDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJsPAC4ARJsPAAAABf////8BAf////8AAAAA";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2789U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIAAAAFJlZnJlc2hSZXF1aXJlZEV2ZW50VHlwZUluc3RhbmNlAQDlCgEA5QrlCgAA/////wgAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJMPAC4ARJMPAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJQPAC4ARJQPAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCVDwAuAESVDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAlg8ALgBElg8AAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJcPAC4ARJcPAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCYDwAuAESYDwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCaDwAuAESaDwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJsPAC4ARJsPAAAABf////8BAf////8AAAAA");
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
