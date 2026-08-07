// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditActivateSessionEventState
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
public class AuditActivateSessionEventState(NodeState parent) : AuditSessionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEF1ZGl0QWN0aXZhdGVTZXNzaW9uRXZlbnRUeXBlSW5zdGFuY2UBABsIAQAbCBsIAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5AwALgBE5AwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5QwALgBE5QwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYMAC4AROYMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnDAAuAETnDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6AwALgBE6AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkMAC4AROkMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsMAC4AROsMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7AwALgBE7AwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA7QwALgBE7QwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDuDAAuAETuDAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAO8MAC4ARO8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPAMAC4ARPAMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPEMAC4ARPEMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAPIMAC4ARPIMAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABoAAABDbGllbnRTb2Z0d2FyZUNlcnRpZmljYXRlcwEAHAgALgBEHAgAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABEAAABVc2VySWRlbnRpdHlUb2tlbgEAHQgALgBEHQgAAAEAPAH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQDdLAAuAETdLAAAAAz/////AQH/////AAAAAA==";
  private PropertyState<SignedSoftwareCertificate[]> m_clientSoftwareCertificates;
  private PropertyState<Opc.Ua.UserIdentityToken> m_userIdentityToken;
  private PropertyState<string> m_secureChannelId;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2075U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEF1ZGl0QWN0aXZhdGVTZXNzaW9uRXZlbnRUeXBlSW5zdGFuY2UBABsIAQAbCBsIAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5AwALgBE5AwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5QwALgBE5QwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYMAC4AROYMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnDAAuAETnDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6AwALgBE6AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkMAC4AROkMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsMAC4AROsMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7AwALgBE7AwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA7QwALgBE7QwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDuDAAuAETuDAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAO8MAC4ARO8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPAMAC4ARPAMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPEMAC4ARPEMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAPIMAC4ARPIMAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABoAAABDbGllbnRTb2Z0d2FyZUNlcnRpZmljYXRlcwEAHAgALgBEHAgAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABEAAABVc2VySWRlbnRpdHlUb2tlbgEAHQgALgBEHQgAAAEAPAH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQDdLAAuAETdLAAAAAz/////AQH/////AAAAAA==");
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

  public PropertyState<SignedSoftwareCertificate[]> ClientSoftwareCertificates
  {
    get => this.m_clientSoftwareCertificates;
    set
    {
      if (this.m_clientSoftwareCertificates != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_clientSoftwareCertificates = value;
    }
  }

  public PropertyState<Opc.Ua.UserIdentityToken> UserIdentityToken
  {
    get => this.m_userIdentityToken;
    set
    {
      if (this.m_userIdentityToken != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_userIdentityToken = value;
    }
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
    if (this.m_clientSoftwareCertificates != null)
      children.Add((BaseInstanceState) this.m_clientSoftwareCertificates);
    if (this.m_userIdentityToken != null)
      children.Add((BaseInstanceState) this.m_userIdentityToken);
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
    switch (browseName.Name)
    {
      case "ClientSoftwareCertificates":
        if (createOrReplace && this.ClientSoftwareCertificates == null)
          this.ClientSoftwareCertificates = replacement != null ? (PropertyState<SignedSoftwareCertificate[]>) replacement : new PropertyState<SignedSoftwareCertificate[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ClientSoftwareCertificates;
        break;
      case "UserIdentityToken":
        if (createOrReplace && this.UserIdentityToken == null)
          this.UserIdentityToken = replacement != null ? (PropertyState<Opc.Ua.UserIdentityToken>) replacement : new PropertyState<Opc.Ua.UserIdentityToken>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.UserIdentityToken;
        break;
      case "SecureChannelId":
        if (createOrReplace && this.SecureChannelId == null)
          this.SecureChannelId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecureChannelId;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
