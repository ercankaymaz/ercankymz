// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerConfigurationState
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
public class ServerConfigurationState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAHwAAAFNlcnZlckNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBACUxAQAlMSUxAAD/////CQAAAARggAoBAAAAAAARAAAAQ2VydGlmaWNhdGVHcm91cHMBAH42AC8BAPU1fjYAAP////8BAAAABGCACgEAAAAAABcAAABEZWZhdWx0QXBwbGljYXRpb25Hcm91cAEAfzYALwEACzF/NgAA/////wIAAAAEYIAKAQAAAAAACQAAAFRydXN0TGlzdAEAgDYALwEA6jCANgAA/////wwAAAAVYIkKAgAAAAAABAAAAFNpemUBAIE2AC4ARIE2AAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAgjYALgBEgjYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAgzYALgBEgzYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAhDYALgBEhDYAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAIY2AC8BADwthjYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCHNgAuAESHNgAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiDYALgBEiDYAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAiTYALwEAPy2JNgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIo2AC4ARIo2AACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAizYALwEAQS2LNgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIw2AC4ARIw2AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCNNgAuAESNNgAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQCONgAvAQBELY42AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAjzYALgBEjzYAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAJA2AC8BAEYtkDYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCRNgAuAESRNgAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAkjYALgBEkjYAAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAJM2AC8BAEktkzYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCUNgAuAESUNgAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFVwZGF0ZVRpbWUBAJU2AC4ARJU2AAABACYB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5X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";
  private CertificateGroupFolderState m_certificateGroups;
  private PropertyState<string[]> m_serverCapabilities;
  private PropertyState<string[]> m_supportedPrivateKeyFormats;
  private PropertyState<uint> m_maxTrustListSize;
  private PropertyState<bool> m_multicastDnsEnabled;
  private UpdateCertificateMethodState m_updateCertificateMethod;
  private MethodState m_applyChangesMethod;
  private CreateSigningRequestMethodState m_createSigningRequestMethod;
  private GetRejectedListMethodState m_getRejectedListMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 12581U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlcnZlckNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBACUxAQAlMSUxAAD/////CQAAAARggAoBAAAAAAARAAAAQ2VydGlmaWNhdGVHcm91cHMBAH42AC8BAPU1fjYAAP////8BAAAABGCACgEAAAAAABcAAABEZWZhdWx0QXBwbGljYXRpb25Hcm91cAEAfzYALwEACzF/NgAA/////wIAAAAEYIAKAQAAAAAACQAAAFRydXN0TGlzdAEAgDYALwEA6jCANgAA/////wwAAAAVYIkKAgAAAAAABAAAAFNpemUBAIE2AC4ARIE2AAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAgjYALgBEgjYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAgzYALgBEgzYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAhDYALgBEhDYAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAIY2AC8BADwthjYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCHNgAuAESHNgAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiDYALgBEiDYAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAiTYALwEAPy2JNgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIo2AC4ARIo2AACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAizYALwEAQS2LNgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIw2AC4ARIw2AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCNNgAuAESNNgAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQCONgAvAQBELY42AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAjzYALgBEjzYAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAJA2AC8BAEYtkDYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCRNgAuAESRNgAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAkjYALgBEkjYAAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAJM2AC8BAEktkzYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCUNgAuAESUNgAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFVwZGF0ZVRpbWUBAJU2AC4ARJU2AAABACYB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5X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");
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

  public CertificateGroupFolderState CertificateGroups
  {
    get => this.m_certificateGroups;
    set
    {
      if (this.m_certificateGroups != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_certificateGroups = value;
    }
  }

  public PropertyState<string[]> ServerCapabilities
  {
    get => this.m_serverCapabilities;
    set
    {
      if (this.m_serverCapabilities != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_serverCapabilities = value;
    }
  }

  public PropertyState<string[]> SupportedPrivateKeyFormats
  {
    get => this.m_supportedPrivateKeyFormats;
    set
    {
      if (this.m_supportedPrivateKeyFormats != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_supportedPrivateKeyFormats = value;
    }
  }

  public PropertyState<uint> MaxTrustListSize
  {
    get => this.m_maxTrustListSize;
    set
    {
      if (this.m_maxTrustListSize != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxTrustListSize = value;
    }
  }

  public PropertyState<bool> MulticastDnsEnabled
  {
    get => this.m_multicastDnsEnabled;
    set
    {
      if (this.m_multicastDnsEnabled != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_multicastDnsEnabled = value;
    }
  }

  public UpdateCertificateMethodState UpdateCertificate
  {
    get => this.m_updateCertificateMethod;
    set
    {
      if (this.m_updateCertificateMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_updateCertificateMethod = value;
    }
  }

  public MethodState ApplyChanges
  {
    get => this.m_applyChangesMethod;
    set
    {
      if (this.m_applyChangesMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_applyChangesMethod = value;
    }
  }

  public CreateSigningRequestMethodState CreateSigningRequest
  {
    get => this.m_createSigningRequestMethod;
    set
    {
      if (this.m_createSigningRequestMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_createSigningRequestMethod = value;
    }
  }

  public GetRejectedListMethodState GetRejectedList
  {
    get => this.m_getRejectedListMethod;
    set
    {
      if (this.m_getRejectedListMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_getRejectedListMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_certificateGroups != null)
      children.Add((BaseInstanceState) this.m_certificateGroups);
    if (this.m_serverCapabilities != null)
      children.Add((BaseInstanceState) this.m_serverCapabilities);
    if (this.m_supportedPrivateKeyFormats != null)
      children.Add((BaseInstanceState) this.m_supportedPrivateKeyFormats);
    if (this.m_maxTrustListSize != null)
      children.Add((BaseInstanceState) this.m_maxTrustListSize);
    if (this.m_multicastDnsEnabled != null)
      children.Add((BaseInstanceState) this.m_multicastDnsEnabled);
    if (this.m_updateCertificateMethod != null)
      children.Add((BaseInstanceState) this.m_updateCertificateMethod);
    if (this.m_applyChangesMethod != null)
      children.Add((BaseInstanceState) this.m_applyChangesMethod);
    if (this.m_createSigningRequestMethod != null)
      children.Add((BaseInstanceState) this.m_createSigningRequestMethod);
    if (this.m_getRejectedListMethod != null)
      children.Add((BaseInstanceState) this.m_getRejectedListMethod);
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
        case 12:
          if (name == "ApplyChanges")
          {
            if (createOrReplace && this.ApplyChanges == null)
              this.ApplyChanges = replacement != null ? (MethodState) replacement : new MethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ApplyChanges;
            break;
          }
          break;
        case 15:
          if (name == "GetRejectedList")
          {
            if (createOrReplace && this.GetRejectedList == null)
              this.GetRejectedList = replacement != null ? (GetRejectedListMethodState) replacement : new GetRejectedListMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.GetRejectedList;
            break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "MaxTrustListSize")
          {
            if (createOrReplace && this.MaxTrustListSize == null)
              this.MaxTrustListSize = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MaxTrustListSize;
            break;
          }
          break;
        case 17:
          switch (name[0])
          {
            case 'C':
              if (name == "CertificateGroups")
              {
                if (createOrReplace && this.CertificateGroups == null)
                  this.CertificateGroups = replacement != null ? (CertificateGroupFolderState) replacement : new CertificateGroupFolderState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.CertificateGroups;
                break;
              }
              break;
            case 'U':
              if (name == "UpdateCertificate")
              {
                if (createOrReplace && this.UpdateCertificate == null)
                  this.UpdateCertificate = replacement != null ? (UpdateCertificateMethodState) replacement : new UpdateCertificateMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.UpdateCertificate;
                break;
              }
              break;
          }
          break;
        case 18:
          if (name == "ServerCapabilities")
          {
            if (createOrReplace && this.ServerCapabilities == null)
              this.ServerCapabilities = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ServerCapabilities;
            break;
          }
          break;
        case 19:
          if (name == "MulticastDnsEnabled")
          {
            if (createOrReplace && this.MulticastDnsEnabled == null)
              this.MulticastDnsEnabled = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.MulticastDnsEnabled;
            break;
          }
          break;
        case 20:
          if (name == "CreateSigningRequest")
          {
            if (createOrReplace && this.CreateSigningRequest == null)
              this.CreateSigningRequest = replacement != null ? (CreateSigningRequestMethodState) replacement : new CreateSigningRequestMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.CreateSigningRequest;
            break;
          }
          break;
        case 26:
          if (name == "SupportedPrivateKeyFormats")
          {
            if (createOrReplace && this.SupportedPrivateKeyFormats == null)
              this.SupportedPrivateKeyFormats = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.SupportedPrivateKeyFormats;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
