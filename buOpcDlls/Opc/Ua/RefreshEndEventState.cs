// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RefreshEndEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RefreshEndEventState(NodeState parent) : SystemEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFJlZnJlc2hFbmRFdmVudFR5cGVJbnN0YW5jZQEA5AoBAOQK5AoAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCKDwAuAESKDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCLDwAuAESLDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAjA8ALgBEjA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAI0PAC4ARI0PAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCODwAuAESODwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjw8ALgBEjw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkQ8ALgBEkQ8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCSDwAuAESSDwAAAAX/////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2788U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFJlZnJlc2hFbmRFdmVudFR5cGVJbnN0YW5jZQEA5AoBAOQK5AoAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCKDwAuAESKDwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCLDwAuAESLDwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAjA8ALgBEjA8AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAI0PAC4ARI0PAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCODwAuAESODwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAjw8ALgBEjw8AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAkQ8ALgBEkQ8AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCSDwAuAESSDwAAAAX/////AQH/////AAAAAA==");
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
