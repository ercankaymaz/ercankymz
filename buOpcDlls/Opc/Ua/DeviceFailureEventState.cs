// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DeviceFailureEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class DeviceFailureEventState(NodeState parent) : SystemEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHgAAAERldmljZUZhaWx1cmVFdmVudFR5cGVJbnN0YW5jZQEAUwgBAFMIUwgAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBODgAuAERODgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBPDgAuAERPDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUA4ALgBEUA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFEOAC4ARFEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBSDgAuAERSDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAUw4ALgBEUw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAVQ4ALgBEVQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBWDgAuAERWDgAAAAX/////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2131U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHgAAAERldmljZUZhaWx1cmVFdmVudFR5cGVJbnN0YW5jZQEAUwgBAFMIUwgAAP////8IAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBODgAuAERODgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBPDgAuAERPDgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAUA4ALgBEUA4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFEOAC4ARFEOAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBSDgAuAERSDgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAUw4ALgBEUw4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAVQ4ALgBEVQ4AAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBWDgAuAERWDgAAAAX/////AQH/////AAAAAA==");
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
