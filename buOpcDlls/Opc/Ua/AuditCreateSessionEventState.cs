// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditCreateSessionEventState
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
public class AuditCreateSessionEventState(NodeState parent) : AuditSessionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0Q3JlYXRlU2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAXCAEAFwgXCAAA/////xIAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMIMAC4ARMIMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAMMMAC4ARMMMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDEDAAuAETEDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAxQwALgBExQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAMYMAC4ARMYMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDHDAAuAETHDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDJDAAuAETJDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMoMAC4ARMoMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAMsMAC4ARMsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAzAwALgBEzAwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDNDAAuAETNDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDODAAuAETODAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDPDAAuAETPDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQBNOAAuAERNOAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQAYCAAuAEQYCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBABkIAC4ARBkIAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAABsAAABDbGllbnRDZXJ0aWZpY2F0ZVRodW1icHJpbnQBALsKAC4ARLsKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXZpc2VkU2Vzc2lvblRpbWVvdXQBABoIAC4ARBoIAAABACIB/////wEB/////wAAAAA=";
  private PropertyState<string> m_secureChannelId;
  private PropertyState<byte[]> m_clientCertificate;
  private PropertyState<string> m_clientCertificateThumbprint;
  private PropertyState<double> m_revisedSessionTimeout;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2071U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIwAAAEF1ZGl0Q3JlYXRlU2Vzc2lvbkV2ZW50VHlwZUluc3RhbmNlAQAXCAEAFwgXCAAA/////xIAAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAMIMAC4ARMIMAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAMMMAC4ARMMMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQDEDAAuAETEDAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAxQwALgBExQwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAMYMAC4ARMYMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDHDAAuAETHDAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDJDAAuAETJDAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMoMAC4ARMoMAAAABf////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABBY3Rpb25UaW1lU3RhbXABAMsMAC4ARMsMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAFN0YXR1cwEAzAwALgBEzAwAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNlcnZlcklkAQDNDAAuAETNDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAASAAAAQ2xpZW50QXVkaXRFbnRyeUlkAQDODAAuAETODAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAMAAAAQ2xpZW50VXNlcklkAQDPDAAuAETPDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAU2Vzc2lvbklkAQBNOAAuAERNOAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQAYCAAuAEQYCAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAAQ2xpZW50Q2VydGlmaWNhdGUBABkIAC4ARBkIAAAAD/////8BAf////8AAAAAFWCJCgIAAAAAABsAAABDbGllbnRDZXJ0aWZpY2F0ZVRodW1icHJpbnQBALsKAC4ARLsKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABUAAABSZXZpc2VkU2Vzc2lvblRpbWVvdXQBABoIAC4ARBoIAAABACIB/////wEB/////wAAAAA=");
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

  public PropertyState<byte[]> ClientCertificate
  {
    get => this.m_clientCertificate;
    set
    {
      if (this.m_clientCertificate != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientCertificate = value;
    }
  }

  public PropertyState<string> ClientCertificateThumbprint
  {
    get => this.m_clientCertificateThumbprint;
    set
    {
      if (this.m_clientCertificateThumbprint != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientCertificateThumbprint = value;
    }
  }

  public PropertyState<double> RevisedSessionTimeout
  {
    get => this.m_revisedSessionTimeout;
    set
    {
      if (this.m_revisedSessionTimeout != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_revisedSessionTimeout = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_secureChannelId != null)
      children.Add((BaseInstanceState) this.m_secureChannelId);
    if (this.m_clientCertificate != null)
      children.Add((BaseInstanceState) this.m_clientCertificate);
    if (this.m_clientCertificateThumbprint != null)
      children.Add((BaseInstanceState) this.m_clientCertificateThumbprint);
    if (this.m_revisedSessionTimeout != null)
      children.Add((BaseInstanceState) this.m_revisedSessionTimeout);
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
    switch (browseName.Name)
    {
      case "SecureChannelId":
        if (createOrReplace && this.SecureChannelId == null)
          this.SecureChannelId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecureChannelId;
        break;
      case "ClientCertificate":
        if (createOrReplace && this.ClientCertificate == null)
          this.ClientCertificate = replacement != null ? (PropertyState<byte[]>) replacement : new PropertyState<byte[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientCertificate;
        break;
      case "ClientCertificateThumbprint":
        if (createOrReplace && this.ClientCertificateThumbprint == null)
          this.ClientCertificateThumbprint = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientCertificateThumbprint;
        break;
      case "RevisedSessionTimeout":
        if (createOrReplace && this.RevisedSessionTimeout == null)
          this.RevisedSessionTimeout = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RevisedSessionTimeout;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
