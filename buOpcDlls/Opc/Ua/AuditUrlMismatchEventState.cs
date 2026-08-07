// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditUrlMismatchEventState
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
public class AuditUrlMismatchEventState(NodeState parent) : AuditCreateSessionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXJsTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAvAoBALwKvAoAAP////8TAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDRDAAuAETRDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDSDAAuAETSDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA0wwALgBE0wwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBANQMAC4ARNQMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDVDAAuAETVDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA1gwALgBE1gwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA2AwALgBE2AwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDZDAAuAETZDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDaDAAuAETaDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBANsMAC4ARNsMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA3AwALgBE3AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA3QwALgBE3QwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA3gwALgBE3gwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEATjgALgBETjgAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEA4AwALgBE4AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQDhDAAuAEThDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQDiDAAuAETiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmV2aXNlZFNlc3Npb25UaW1lb3V0AQDjDAAuAETjDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAvQoALgBEvQoAAAAM/////wEB/////wAAAAA=";
  private PropertyState<string> m_endpointUrl;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2748U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIQAAAEF1ZGl0VXJsTWlzbWF0Y2hFdmVudFR5cGVJbnN0YW5jZQEAvAoBALwKvAoAAP////8TAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQDRDAAuAETRDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQDSDAAuAETSDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEA0wwALgBE0wwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBANQMAC4ARNQMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQDVDAAuAETVDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEA1gwALgBE1gwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEA2AwALgBE2AwAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQDZDAAuAETZDAAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQDaDAAuAETaDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBANsMAC4ARNsMAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEA3AwALgBE3AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEA3QwALgBE3QwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEA3gwALgBE3gwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFNlc3Npb25JZAEATjgALgBETjgAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAFNlY3VyZUNoYW5uZWxJZAEA4AwALgBE4AwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAENsaWVudENlcnRpZmljYXRlAQDhDAAuAEThDAAAAA//////AQH/////AAAAABVgiQoCAAAAAAAbAAAAQ2xpZW50Q2VydGlmaWNhdGVUaHVtYnByaW50AQDiDAAuAETiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAVAAAAUmV2aXNlZFNlc3Npb25UaW1lb3V0AQDjDAAuAETjDAAAAQAiAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABFbmRwb2ludFVybAEAvQoALgBEvQoAAAAM/////wEB/////wAAAAA=");
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

  public PropertyState<string> EndpointUrl
  {
    get => this.m_endpointUrl;
    set
    {
      if (this.m_endpointUrl != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endpointUrl = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_endpointUrl != null)
      children.Add((BaseInstanceState) this.m_endpointUrl);
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
    if (browseName.Name == "EndpointUrl")
    {
      if (createOrReplace && this.EndpointUrl == null)
        this.EndpointUrl = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.EndpointUrl;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
