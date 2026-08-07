// Decompiled with JetBrains decompiler
// Type: Opc.Ua.KeyCredentialConfigurationState
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
public class KeyCredentialConfigurationState(NodeState parent) : BaseObjectState(parent)
{
  private const string EndpointUrls_InitializationString = "//////////8XYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string ServiceStatus_InitializationString = "//////////8VYIkKAgAAAAAADQAAAFNlcnZpY2VTdGF0dXMBAFVGAC4ARFVGAAAAE/////8BAf////8AAAAA";
  private const string GetEncryptingKey_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string UpdateCredential_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAFVwZGF0ZUNyZWRlbnRpYWwBAFZGAC8BAFZGVkYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBXRgAuAERXRgAAlgQAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBAR8AAAAQAAAAQ3JlZGVudGlhbFNlY3JldAAP/////wAAAAAAAQAqAQEkAAAAFQAAAENlcnRpZmljYXRlVGh1bWJwcmludAAM/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string DeleteCredential_InitializationString = "//////////8EYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJgAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uVHlwZUluc3RhbmNlAQBRRgEAUUZRRgAA/////wcAAAAVYIkKAgAAAAAACwAAAFJlc291cmNlVXJpAQCVRgAuAESVRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAUHJvZmlsZVVyaQEA9UYALgBE9UYAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAU2VydmljZVN0YXR1cwEAVUYALgBEVUYAAAAT/////wEB/////wAAAAAEYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABAAAABVcGRhdGVDcmVkZW50aWFsAQBWRgAvAQBWRlZGAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAV0YALgBEV0YAAJYEAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxTZWNyZXQAD/////8AAAAAAAEAKgEBJAAAABUAAABDZXJ0aWZpY2F0ZVRodW1icHJpbnQADP////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=";
  private PropertyState<string> m_resourceUri;
  private PropertyState<string> m_profileUri;
  private PropertyState<string[]> m_endpointUrls;
  private PropertyState<StatusCode> m_serviceStatus;
  private GetEncryptingKeyMethodState m_getEncryptingKeyMethod;
  private KeyCredentialUpdateMethodState m_updateCredentialMethod;
  private MethodState m_deleteCredentialMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 18001U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uVHlwZUluc3RhbmNlAQBRRgEAUUZRRgAA/////wcAAAAVYIkKAgAAAAAACwAAAFJlc291cmNlVXJpAQCVRgAuAESVRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAUHJvZmlsZVVyaQEA9UYALgBE9UYAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAU2VydmljZVN0YXR1cwEAVUYALgBEVUYAAAAT/////wEB/////wAAAAAEYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABAAAABVcGRhdGVDcmVkZW50aWFsAQBWRgAvAQBWRlZGAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAV0YALgBEV0YAAJYEAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxTZWNyZXQAD/////8AAAAAAAEAKgEBJAAAABUAAABDZXJ0aWZpY2F0ZVRodW1icHJpbnQADP////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=");
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
    if (this.EndpointUrls != null)
      this.EndpointUrls.Initialize(context, "//////////8XYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.ServiceStatus != null)
      this.ServiceStatus.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAFNlcnZpY2VTdGF0dXMBAFVGAC4ARFVGAAAAE/////8BAf////8AAAAA");
    if (this.GetEncryptingKey != null)
      this.GetEncryptingKey.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.UpdateCredential != null)
      this.UpdateCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAFVwZGF0ZUNyZWRlbnRpYWwBAFZGAC8BAFZGVkYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBXRgAuAERXRgAAlgQAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBAR8AAAAQAAAAQ3JlZGVudGlhbFNlY3JldAAP/////wAAAAAAAQAqAQEkAAAAFQAAAENlcnRpZmljYXRlVGh1bWJwcmludAAM/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.DeleteCredential == null)
      return;
    this.DeleteCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=");
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

  public PropertyState<string> ProfileUri
  {
    get => this.m_profileUri;
    set
    {
      if (this.m_profileUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_profileUri = value;
    }
  }

  public PropertyState<string[]> EndpointUrls
  {
    get => this.m_endpointUrls;
    set
    {
      if (this.m_endpointUrls != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endpointUrls = value;
    }
  }

  public PropertyState<StatusCode> ServiceStatus
  {
    get => this.m_serviceStatus;
    set
    {
      if (this.m_serviceStatus != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serviceStatus = value;
    }
  }

  public GetEncryptingKeyMethodState GetEncryptingKey
  {
    get => this.m_getEncryptingKeyMethod;
    set
    {
      if (this.m_getEncryptingKeyMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getEncryptingKeyMethod = value;
    }
  }

  public KeyCredentialUpdateMethodState UpdateCredential
  {
    get => this.m_updateCredentialMethod;
    set
    {
      if (this.m_updateCredentialMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updateCredentialMethod = value;
    }
  }

  public MethodState DeleteCredential
  {
    get => this.m_deleteCredentialMethod;
    set
    {
      if (this.m_deleteCredentialMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_deleteCredentialMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_resourceUri != null)
      children.Add((BaseInstanceState) this.m_resourceUri);
    if (this.m_profileUri != null)
      children.Add((BaseInstanceState) this.m_profileUri);
    if (this.m_endpointUrls != null)
      children.Add((BaseInstanceState) this.m_endpointUrls);
    if (this.m_serviceStatus != null)
      children.Add((BaseInstanceState) this.m_serviceStatus);
    if (this.m_getEncryptingKeyMethod != null)
      children.Add((BaseInstanceState) this.m_getEncryptingKeyMethod);
    if (this.m_updateCredentialMethod != null)
      children.Add((BaseInstanceState) this.m_updateCredentialMethod);
    if (this.m_deleteCredentialMethod != null)
      children.Add((BaseInstanceState) this.m_deleteCredentialMethod);
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
    string name = browseName.Name;
    if (name != null)
    {
      switch (name.Length)
      {
        case 10:
          if (name == "ProfileUri")
          {
            if (createOrReplace && this.ProfileUri == null)
              this.ProfileUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ProfileUri;
            break;
          }
          break;
        case 11:
          if (name == "ResourceUri")
          {
            if (createOrReplace && this.ResourceUri == null)
              this.ResourceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ResourceUri;
            break;
          }
          break;
        case 12:
          if (name == "EndpointUrls")
          {
            if (createOrReplace && this.EndpointUrls == null)
              this.EndpointUrls = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.EndpointUrls;
            break;
          }
          break;
        case 13:
          if (name == "ServiceStatus")
          {
            if (createOrReplace && this.ServiceStatus == null)
              this.ServiceStatus = replacement != null ? (PropertyState<StatusCode>) replacement : new PropertyState<StatusCode>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ServiceStatus;
            break;
          }
          break;
        case 16 /*0x10*/:
          switch (name[0])
          {
            case 'D':
              if (name == "DeleteCredential")
              {
                if (createOrReplace && this.DeleteCredential == null)
                  this.DeleteCredential = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.DeleteCredential;
                break;
              }
              break;
            case 'G':
              if (name == "GetEncryptingKey")
              {
                if (createOrReplace && this.GetEncryptingKey == null)
                  this.GetEncryptingKey = replacement != null ? (GetEncryptingKeyMethodState) replacement : new GetEncryptingKeyMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.GetEncryptingKey;
                break;
              }
              break;
            case 'U':
              if (name == "UpdateCredential")
              {
                if (createOrReplace && this.UpdateCredential == null)
                  this.UpdateCredential = replacement != null ? (KeyCredentialUpdateMethodState) replacement : new KeyCredentialUpdateMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UpdateCredential;
                break;
              }
              break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
