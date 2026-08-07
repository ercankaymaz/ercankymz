// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditChannelEventState
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
public class AuditChannelEventState(NodeState parent) : AuditSecurityEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0Q2hhbm5lbEV2ZW50VHlwZUluc3RhbmNlAQALCAEACwgLCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJcMAC4ARJcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJgMAC4ARJgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCZDAAuAESZDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAmgwALgBEmgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJsMAC4ARJsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCcDAAuAEScDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCeDAAuAESeDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJ8MAC4ARJ8MAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKAMAC4ARKAMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAoQwALgBEoQwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCiDAAuAESiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCjDAAuAESjDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCkDAAuAESkDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQC5CgAuAES5CgAAAAz/////AQH/////AAAAAA==";
  private PropertyState<string> m_secureChannelId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2059U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHQAAAEF1ZGl0Q2hhbm5lbEV2ZW50VHlwZUluc3RhbmNlAQALCAEACwgLCAAA/////w4AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAJcMAC4ARJcMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAJgMAC4ARJgMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQCZDAAuAESZDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAmgwALgBEmgwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAJsMAC4ARJsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQCcDAAuAEScDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQCeDAAuAESeDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAJ8MAC4ARJ8MAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAKAMAC4ARKAMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAoQwALgBEoQwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQCiDAAuAESiDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQCjDAAuAESjDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQCkDAAuAESkDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQC5CgAuAES5CgAAAAz/////AQH/////AAAAAA==");
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

  public PropertyState<string> SecureChannelId
  {
    get => this.m_secureChannelId;
    set
    {
      if (this.m_secureChannelId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_secureChannelId = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_secureChannelId != null)
      children.Add((BaseInstanceState) this.m_secureChannelId);
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
    if (browseName.Name == "SecureChannelId")
    {
      if (createOrReplace && this.SecureChannelId == null)
        this.SecureChannelId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.SecureChannelId;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
