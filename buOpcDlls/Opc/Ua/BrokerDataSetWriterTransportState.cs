// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerDataSetWriterTransportState
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
public class BrokerDataSetWriterTransportState(NodeState parent) : DataSetWriterTransportState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEJyb2tlckRhdGFTZXRXcml0ZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAJJSAQCSUpJSAAD/////BgAAABVgiQoCAAAAAAAJAAAAUXVldWVOYW1lAQCTUgAuAESTUgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWV0YURhdGFRdWV1ZU5hbWUBAJRSAC4ARJRSAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZXNvdXJjZVVyaQEAkjsALgBEkjsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAEF1dGhlbnRpY2F0aW9uUHJvZmlsZVVyaQEAkzsALgBEkzsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFJlcXVlc3RlZERlbGl2ZXJ5R3VhcmFudGVlAQDiOwAuAETiOwAAAQCgOv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNZXRhRGF0YVVwZGF0ZVRpbWUBAJVSAC4ARJVSAAABACIB/////wEB/////wAAAAA=";
  private PropertyState<string> m_queueName;
  private PropertyState<string> m_metaDataQueueName;
  private PropertyState<string> m_resourceUri;
  private PropertyState<string> m_authenticationProfileUri;
  private PropertyState<BrokerTransportQualityOfService> m_requestedDeliveryGuarantee;
  private PropertyState<double> m_metaDataUpdateTime;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 21138U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEJyb2tlckRhdGFTZXRXcml0ZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAJJSAQCSUpJSAAD/////BgAAABVgiQoCAAAAAAAJAAAAUXVldWVOYW1lAQCTUgAuAESTUgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWV0YURhdGFRdWV1ZU5hbWUBAJRSAC4ARJRSAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZXNvdXJjZVVyaQEAkjsALgBEkjsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAGAAAAEF1dGhlbnRpY2F0aW9uUHJvZmlsZVVyaQEAkzsALgBEkzsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAGgAAAFJlcXVlc3RlZERlbGl2ZXJ5R3VhcmFudGVlAQDiOwAuAETiOwAAAQCgOv////8BAf////8AAAAAFWCJCgIAAAAAABIAAABNZXRhRGF0YVVwZGF0ZVRpbWUBAJVSAC4ARJVSAAABACIB/////wEB/////wAAAAA=");
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

  public PropertyState<string> QueueName
  {
    get => this.m_queueName;
    set
    {
      if (this.m_queueName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_queueName = value;
    }
  }

  public PropertyState<string> MetaDataQueueName
  {
    get => this.m_metaDataQueueName;
    set
    {
      if (this.m_metaDataQueueName != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_metaDataQueueName = value;
    }
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

  public PropertyState<string> AuthenticationProfileUri
  {
    get => this.m_authenticationProfileUri;
    set
    {
      if (this.m_authenticationProfileUri != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_authenticationProfileUri = value;
    }
  }

  public PropertyState<BrokerTransportQualityOfService> RequestedDeliveryGuarantee
  {
    get => this.m_requestedDeliveryGuarantee;
    set
    {
      if (this.m_requestedDeliveryGuarantee != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_requestedDeliveryGuarantee = value;
    }
  }

  public PropertyState<double> MetaDataUpdateTime
  {
    get => this.m_metaDataUpdateTime;
    set
    {
      if (this.m_metaDataUpdateTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_metaDataUpdateTime = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_queueName != null)
      children.Add((BaseInstanceState) this.m_queueName);
    if (this.m_metaDataQueueName != null)
      children.Add((BaseInstanceState) this.m_metaDataQueueName);
    if (this.m_resourceUri != null)
      children.Add((BaseInstanceState) this.m_resourceUri);
    if (this.m_authenticationProfileUri != null)
      children.Add((BaseInstanceState) this.m_authenticationProfileUri);
    if (this.m_requestedDeliveryGuarantee != null)
      children.Add((BaseInstanceState) this.m_requestedDeliveryGuarantee);
    if (this.m_metaDataUpdateTime != null)
      children.Add((BaseInstanceState) this.m_metaDataUpdateTime);
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
      case "QueueName":
        if (createOrReplace && this.QueueName == null)
          this.QueueName = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.QueueName;
        break;
      case "MetaDataQueueName":
        if (createOrReplace && this.MetaDataQueueName == null)
          this.MetaDataQueueName = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MetaDataQueueName;
        break;
      case "ResourceUri":
        if (createOrReplace && this.ResourceUri == null)
          this.ResourceUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.ResourceUri;
        break;
      case "AuthenticationProfileUri":
        if (createOrReplace && this.AuthenticationProfileUri == null)
          this.AuthenticationProfileUri = replacement != null ? (PropertyState<string>) replacement : new PropertyState<string>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.AuthenticationProfileUri;
        break;
      case "RequestedDeliveryGuarantee":
        if (createOrReplace && this.RequestedDeliveryGuarantee == null)
          this.RequestedDeliveryGuarantee = replacement != null ? (PropertyState<BrokerTransportQualityOfService>) replacement : new PropertyState<BrokerTransportQualityOfService>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.RequestedDeliveryGuarantee;
        break;
      case "MetaDataUpdateTime":
        if (createOrReplace && this.MetaDataUpdateTime == null)
          this.MetaDataUpdateTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.MetaDataUpdateTime;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
