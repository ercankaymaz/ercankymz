// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SecurityGroupState
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
public class SecurityGroupState(NodeState parent) : BaseObjectState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAFNlY3VyaXR5R3JvdXBUeXBlSW5zdGFuY2UBAG88AQBvPG88AAD/////BQAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQBwPAAuAERwPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAS2V5TGlmZXRpbWUBAMY6AC4ARMY6AAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDHOgAuAETHOgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQBAMg6AC4ARMg6AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhQYXN0S2V5Q291bnQBANA6AC4ARNA6AAAAB/////8BAf////8AAAAA";
  private PropertyState<string> m_securityGroupId;
  private PropertyState<double> m_keyLifetime;
  private PropertyState<string> m_securityPolicyUri;
  private PropertyState<uint> m_maxFutureKeyCount;
  private PropertyState<uint> m_maxPastKeyCount;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15471U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAGQAAAFNlY3VyaXR5R3JvdXBUeXBlSW5zdGFuY2UBAG88AQBvPG88AAD/////BQAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQBwPAAuAERwPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAS2V5TGlmZXRpbWUBAMY6AC4ARMY6AAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDHOgAuAETHOgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQBAMg6AC4ARMg6AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhQYXN0S2V5Q291bnQBANA6AC4ARNA6AAAAB/////8BAf////8AAAAA");
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

  public PropertyState<string> SecurityGroupId
  {
    get => this.m_securityGroupId;
    set
    {
      if (this.m_securityGroupId != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityGroupId = value;
    }
  }

  public PropertyState<double> KeyLifetime
  {
    get => this.m_keyLifetime;
    set
    {
      if (this.m_keyLifetime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_keyLifetime = value;
    }
  }

  public PropertyState<string> SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set
    {
      if (this.m_securityPolicyUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_securityPolicyUri = value;
    }
  }

  public PropertyState<uint> MaxFutureKeyCount
  {
    get => this.m_maxFutureKeyCount;
    set
    {
      if (this.m_maxFutureKeyCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxFutureKeyCount = value;
    }
  }

  public PropertyState<uint> MaxPastKeyCount
  {
    get => this.m_maxPastKeyCount;
    set
    {
      if (this.m_maxPastKeyCount != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maxPastKeyCount = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_securityGroupId != null)
      children.Add((BaseInstanceState) this.m_securityGroupId);
    if (this.m_keyLifetime != null)
      children.Add((BaseInstanceState) this.m_keyLifetime);
    if (this.m_securityPolicyUri != null)
      children.Add((BaseInstanceState) this.m_securityPolicyUri);
    if (this.m_maxFutureKeyCount != null)
      children.Add((BaseInstanceState) this.m_maxFutureKeyCount);
    if (this.m_maxPastKeyCount != null)
      children.Add((BaseInstanceState) this.m_maxPastKeyCount);
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
      case "SecurityGroupId":
        if (createOrReplace && this.SecurityGroupId == null)
          this.SecurityGroupId = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityGroupId;
        break;
      case "KeyLifetime":
        if (createOrReplace && this.KeyLifetime == null)
          this.KeyLifetime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.KeyLifetime;
        break;
      case "SecurityPolicyUri":
        if (createOrReplace && this.SecurityPolicyUri == null)
          this.SecurityPolicyUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.SecurityPolicyUri;
        break;
      case "MaxFutureKeyCount":
        if (createOrReplace && this.MaxFutureKeyCount == null)
          this.MaxFutureKeyCount = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxFutureKeyCount;
        break;
      case "MaxPastKeyCount":
        if (createOrReplace && this.MaxPastKeyCount == null)
          this.MaxPastKeyCount = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MaxPastKeyCount;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
