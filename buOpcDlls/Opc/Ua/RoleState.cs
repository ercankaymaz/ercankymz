// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RoleState
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
public class RoleState(NodeState parent) : BaseObjectState(parent)
{
  private const string Applications_InitializationString = "//////////8XYIkKAgAAAAAADAAAAEFwcGxpY2F0aW9ucwEALj8ALgBELj8AAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string ApplicationsExclude_InitializationString = "//////////8VYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAA";
  private const string Endpoints_InitializationString = "//////////8XYIkKAgAAAAAACQAAAEVuZHBvaW50cwEALz8ALgBELz8AAAEAqDwBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string EndpointsExclude_InitializationString = "//////////8VYIkKAgAAAAAAEAAAAEVuZHBvaW50c0V4Y2x1ZGUBADM8AC4ARDM8AAAAAf////8BAf////8AAAAA";
  private const string AddIdentity_InitializationString = "//////////8EYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string RemoveIdentity_InitializationString = "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private const string AddApplication_InitializationString = "//////////8EYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string RemoveApplication_InitializationString = "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUFwcGxpY2F0aW9uAQAyPwAvAQAyPzI/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMz8ALgBEMz8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";
  private const string AddEndpoint_InitializationString = "//////////8EYYIKBAAAAAAACwAAAEFkZEVuZHBvaW50AQA0PwAvAQA0PzQ/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANT8ALgBENT8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string RemoveEndpoint_InitializationString = "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUVuZHBvaW50AQA2PwAvAQA2PzY/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANz8ALgBENz8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
  private const string InitializationString = "//////////8EYIACAQAAAAAAEAAAAFJvbGVUeXBlSW5zdGFuY2UBAAQ9AQAEPQQ9AAD/////CwAAABdgiQoCAAAAAAAKAAAASWRlbnRpdGllcwEALT8ALgBELT8AAAEAEj0BAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAwAAABBcHBsaWNhdGlvbnMBAC4/AC4ARC4/AAAADAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABFbmRwb2ludHMBAC8/AC4ARC8/AAABAKg8AQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAARW5kcG9pbnRzRXhjbHVkZQEAMzwALgBEMzwAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAARAAAAUmVtb3ZlQXBwbGljYXRpb24BADI/AC8BADI/Mj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAzPwAuAEQzPwAAlgEAAAABACoBAR0AAAAOAAAAQXBwbGljYXRpb25VcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABBZGRFbmRwb2ludAEAND8ALwEAND80PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADU/AC4ARDU/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAUmVtb3ZlRW5kcG9pbnQBADY/AC8BADY/Nj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQA3PwAuAEQ3PwAAlgEAAAABACoBARkAAAAIAAAARW5kcG9pbnQBAKg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";
  private PropertyState<IdentityMappingRuleType[]> m_identities;
  private PropertyState<string[]> m_applications;
  private PropertyState<bool> m_applicationsExclude;
  private PropertyState<EndpointType[]> m_endpoints;
  private PropertyState<bool> m_endpointsExclude;
  private AddIdentityMethodState m_addIdentityMethod;
  private RemoveIdentityMethodState m_removeIdentityMethod;
  private AddApplicationMethodState m_addApplicationMethod;
  private RemoveApplicationMethodState m_removeApplicationMethod;
  private AddEndpointMethodState m_addEndpointMethod;
  private RemoveEndpointMethodState m_removeEndpointMethod;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15620U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAEAAAAFJvbGVUeXBlSW5zdGFuY2UBAAQ9AQAEPQQ9AAD/////CwAAABdgiQoCAAAAAAAKAAAASWRlbnRpdGllcwEALT8ALgBELT8AAAEAEj0BAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAwAAABBcHBsaWNhdGlvbnMBAC4/AC4ARC4/AAAADAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABFbmRwb2ludHMBAC8/AC4ARC8/AAABAKg8AQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAARW5kcG9pbnRzRXhjbHVkZQEAMzwALgBEMzwAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAARAAAAUmVtb3ZlQXBwbGljYXRpb24BADI/AC8BADI/Mj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAzPwAuAEQzPwAAlgEAAAABACoBAR0AAAAOAAAAQXBwbGljYXRpb25VcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABBZGRFbmRwb2ludAEAND8ALwEAND80PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADU/AC4ARDU/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAUmVtb3ZlRW5kcG9pbnQBADY/AC8BADY/Nj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQA3PwAuAEQ3PwAAlgEAAAABACoBARkAAAAIAAAARW5kcG9pbnQBAKg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
    if (this.Applications != null)
      this.Applications.Initialize(context, "//////////8XYIkKAgAAAAAADAAAAEFwcGxpY2F0aW9ucwEALj8ALgBELj8AAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.ApplicationsExclude != null)
      this.ApplicationsExclude.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAA");
    if (this.Endpoints != null)
      this.Endpoints.Initialize(context, "//////////8XYIkKAgAAAAAACQAAAEVuZHBvaW50cwEALz8ALgBELz8AAAEAqDwBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.EndpointsExclude != null)
      this.EndpointsExclude.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEVuZHBvaW50c0V4Y2x1ZGUBADM8AC4ARDM8AAAAAf////8BAf////8AAAAA");
    if (this.AddIdentity != null)
      this.AddIdentity.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.RemoveIdentity != null)
      this.RemoveIdentity.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
    if (this.AddApplication != null)
      this.AddApplication.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.RemoveApplication != null)
      this.RemoveApplication.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUFwcGxpY2F0aW9uAQAyPwAvAQAyPzI/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMz8ALgBEMz8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
    if (this.AddEndpoint != null)
      this.AddEndpoint.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAEFkZEVuZHBvaW50AQA0PwAvAQA0PzQ/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANT8ALgBENT8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
    if (this.RemoveEndpoint == null)
      return;
    this.RemoveEndpoint.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUVuZHBvaW50AQA2PwAvAQA2PzY/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANz8ALgBENz8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
  }

  public PropertyState<IdentityMappingRuleType[]> Identities
  {
    get => this.m_identities;
    set
    {
      if (this.m_identities != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_identities = value;
    }
  }

  public PropertyState<string[]> Applications
  {
    get => this.m_applications;
    set
    {
      if (this.m_applications != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_applications = value;
    }
  }

  public PropertyState<bool> ApplicationsExclude
  {
    get => this.m_applicationsExclude;
    set
    {
      if (this.m_applicationsExclude != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_applicationsExclude = value;
    }
  }

  public PropertyState<EndpointType[]> Endpoints
  {
    get => this.m_endpoints;
    set
    {
      if (this.m_endpoints != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endpoints = value;
    }
  }

  public PropertyState<bool> EndpointsExclude
  {
    get => this.m_endpointsExclude;
    set
    {
      if (this.m_endpointsExclude != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_endpointsExclude = value;
    }
  }

  public AddIdentityMethodState AddIdentity
  {
    get => this.m_addIdentityMethod;
    set
    {
      if (this.m_addIdentityMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addIdentityMethod = value;
    }
  }

  public RemoveIdentityMethodState RemoveIdentity
  {
    get => this.m_removeIdentityMethod;
    set
    {
      if (this.m_removeIdentityMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeIdentityMethod = value;
    }
  }

  public AddApplicationMethodState AddApplication
  {
    get => this.m_addApplicationMethod;
    set
    {
      if (this.m_addApplicationMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addApplicationMethod = value;
    }
  }

  public RemoveApplicationMethodState RemoveApplication
  {
    get => this.m_removeApplicationMethod;
    set
    {
      if (this.m_removeApplicationMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeApplicationMethod = value;
    }
  }

  public AddEndpointMethodState AddEndpoint
  {
    get => this.m_addEndpointMethod;
    set
    {
      if (this.m_addEndpointMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_addEndpointMethod = value;
    }
  }

  public RemoveEndpointMethodState RemoveEndpoint
  {
    get => this.m_removeEndpointMethod;
    set
    {
      if (this.m_removeEndpointMethod != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_removeEndpointMethod = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_identities != null)
      children.Add((BaseInstanceState) this.m_identities);
    if (this.m_applications != null)
      children.Add((BaseInstanceState) this.m_applications);
    if (this.m_applicationsExclude != null)
      children.Add((BaseInstanceState) this.m_applicationsExclude);
    if (this.m_endpoints != null)
      children.Add((BaseInstanceState) this.m_endpoints);
    if (this.m_endpointsExclude != null)
      children.Add((BaseInstanceState) this.m_endpointsExclude);
    if (this.m_addIdentityMethod != null)
      children.Add((BaseInstanceState) this.m_addIdentityMethod);
    if (this.m_removeIdentityMethod != null)
      children.Add((BaseInstanceState) this.m_removeIdentityMethod);
    if (this.m_addApplicationMethod != null)
      children.Add((BaseInstanceState) this.m_addApplicationMethod);
    if (this.m_removeApplicationMethod != null)
      children.Add((BaseInstanceState) this.m_removeApplicationMethod);
    if (this.m_addEndpointMethod != null)
      children.Add((BaseInstanceState) this.m_addEndpointMethod);
    if (this.m_removeEndpointMethod != null)
      children.Add((BaseInstanceState) this.m_removeEndpointMethod);
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
        case 9:
          if (name == "Endpoints")
          {
            if (createOrReplace && this.Endpoints == null)
              this.Endpoints = replacement != null ? (PropertyState<EndpointType[]>) replacement : new PropertyState<EndpointType[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Endpoints;
            break;
          }
          break;
        case 10:
          if (name == "Identities")
          {
            if (createOrReplace && this.Identities == null)
              this.Identities = replacement != null ? (PropertyState<IdentityMappingRuleType[]>) replacement : new PropertyState<IdentityMappingRuleType[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Identities;
            break;
          }
          break;
        case 11:
          switch (name[3])
          {
            case 'E':
              if (name == "AddEndpoint")
              {
                if (createOrReplace && this.AddEndpoint == null)
                  this.AddEndpoint = replacement != null ? (AddEndpointMethodState) replacement : new AddEndpointMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddEndpoint;
                break;
              }
              break;
            case 'I':
              if (name == "AddIdentity")
              {
                if (createOrReplace && this.AddIdentity == null)
                  this.AddIdentity = replacement != null ? (AddIdentityMethodState) replacement : new AddIdentityMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddIdentity;
                break;
              }
              break;
          }
          break;
        case 12:
          if (name == "Applications")
          {
            if (createOrReplace && this.Applications == null)
              this.Applications = replacement != null ? (PropertyState<string[]>) replacement : new PropertyState<string[]>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.Applications;
            break;
          }
          break;
        case 14:
          switch (name[6])
          {
            case 'E':
              if (name == "RemoveEndpoint")
              {
                if (createOrReplace && this.RemoveEndpoint == null)
                  this.RemoveEndpoint = replacement != null ? (RemoveEndpointMethodState) replacement : new RemoveEndpointMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RemoveEndpoint;
                break;
              }
              break;
            case 'I':
              if (name == "RemoveIdentity")
              {
                if (createOrReplace && this.RemoveIdentity == null)
                  this.RemoveIdentity = replacement != null ? (RemoveIdentityMethodState) replacement : new RemoveIdentityMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.RemoveIdentity;
                break;
              }
              break;
            case 'l':
              if (name == "AddApplication")
              {
                if (createOrReplace && this.AddApplication == null)
                  this.AddApplication = replacement != null ? (AddApplicationMethodState) replacement : new AddApplicationMethodState((NodeState) this);
                baseInstanceState = (BaseInstanceState) this.AddApplication;
                break;
              }
              break;
          }
          break;
        case 16 /*0x10*/:
          if (name == "EndpointsExclude")
          {
            if (createOrReplace && this.EndpointsExclude == null)
              this.EndpointsExclude = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.EndpointsExclude;
            break;
          }
          break;
        case 17:
          if (name == "RemoveApplication")
          {
            if (createOrReplace && this.RemoveApplication == null)
              this.RemoveApplication = replacement != null ? (RemoveApplicationMethodState) replacement : new RemoveApplicationMethodState((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.RemoveApplication;
            break;
          }
          break;
        case 19:
          if (name == "ApplicationsExclude")
          {
            if (createOrReplace && this.ApplicationsExclude == null)
              this.ApplicationsExclude = replacement != null ? (PropertyState<bool>) replacement : new PropertyState<bool>((NodeState) this);
            baseInstanceState = (BaseInstanceState) this.ApplicationsExclude;
            break;
          }
          break;
      }
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
