// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyCredentialUpdatedAuditEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class KeyCredentialUpdatedAuditEventState(NodeState parent) : KeyCredentialAuditEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKgAAAEtleUNyZWRlbnRpYWxVcGRhdGVkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEAbUYBAG1GbUYAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBuRgAuAERuRgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBvRgAuAERvRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAcEYALgBEcEYAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHFGAC4ARHFGAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQByRgAuAERyRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAc0YALgBEc0YAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAdUYALgBEdUYAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQB2RgAuAER2RgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQB3RgAuAER3RgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAHhGAC4ARHhGAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAeUYALgBEeUYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAekYALgBEekYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAe0YALgBEe0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQB8RgAuAER8RgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH1GAC4ARH1GAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlc291cmNlVXJpAQB+RgAuAER+RgAAAAz/////AQH/////AAAAAA==";

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18029U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKgAAAEtleUNyZWRlbnRpYWxVcGRhdGVkQXVkaXRFdmVudFR5cGVJbnN0YW5jZQEAbUYBAG1GbUYAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBuRgAuAERuRgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBvRgAuAERvRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAcEYALgBEcEYAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAHFGAC4ARHFGAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQByRgAuAERyRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAc0YALgBEc0YAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAdUYALgBEdUYAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQB2RgAuAER2RgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQB3RgAuAER3RgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAHhGAC4ARHhGAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAeUYALgBEeUYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAekYALgBEekYAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAe0YALgBEe0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQB8RgAuAER8RgAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAH1GAC4ARH1GAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlc291cmNlVXJpAQB+RgAuAER+RgAAAAz/////AQH/////AAAAAA==");
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
