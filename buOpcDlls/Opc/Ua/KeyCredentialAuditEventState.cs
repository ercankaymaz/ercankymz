// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyCredentialAuditEventState
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
public class KeyCredentialAuditEventState(NodeState parent) : AuditUpdateMethodEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEtleUNyZWRlbnRpYWxBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQBbRgEAW0ZbRgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFxGAC4ARFxGAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAF1GAC4ARF1GAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBeRgAuAEReRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAX0YALgBEX0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGBGAC4ARGBGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBhRgAuAERhRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBjRgAuAERjRgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGRGAC4ARGRGAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGVGAC4ARGVGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZkYALgBEZkYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBnRgAuAERnRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBoRgAuAERoRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBpRgAuAERpRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAGpGAC4ARGpGAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAa0YALgBEa0YAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAGxGAC4ARGxGAAAADP////8BAf////8AAAAA";
  private PropertyState<string> m_resourceUri;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18011U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEtleUNyZWRlbnRpYWxBdWRpdEV2ZW50VHlwZUluc3RhbmNlAQBbRgEAW0ZbRgAA/////xAAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAFxGAC4ARFxGAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAF1GAC4ARF1GAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQBeRgAuAEReRgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAX0YALgBEX0YAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAGBGAC4ARGBGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQBhRgAuAERhRgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQBjRgAuAERjRgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAGRGAC4ARGRGAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAGVGAC4ARGVGAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAZkYALgBEZkYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQBnRgAuAERnRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQBoRgAuAERoRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQBpRgAuAERpRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATWV0aG9kSWQBAGpGAC4ARGpGAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAa0YALgBEa0YAAAAYAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAGxGAC4ARGxGAAAADP////8BAf////8AAAAA");
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

  public PropertyState<string> ResourceUri
  {
    get => this.m_resourceUri;
    set
    {
      if (this.m_resourceUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_resourceUri = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_resourceUri != null)
      children.Add((BaseInstanceState) this.m_resourceUri);
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
    if (browseName.Name == "ResourceUri")
    {
      if (createOrReplace && this.ResourceUri == null)
        this.ResourceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ResourceUri;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
