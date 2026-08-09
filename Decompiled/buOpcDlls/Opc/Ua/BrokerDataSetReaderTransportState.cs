using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BrokerDataSetReaderTransportState : DataSetReaderTransportState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAKAAAAEJyb2tlckRhdGFTZXRSZWFkZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAJZSAQCWUpZSAAD/////BQAAABVgiQoCAAAAAAAJAAAAUXVldWVOYW1lAQCXUgAuAESXUgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAOY7AC4AROY7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBADs8AC4ARDs8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABoAAABSZXF1ZXN0ZWREZWxpdmVyeUd1YXJhbnRlZQEAPDwALgBEPDwAAAEAoDr/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWV0YURhdGFRdWV1ZU5hbWUBAJhSAC4ARJhSAAAADP////8BAf////8AAAAA";

	private PropertyState<string> m_queueName;

	private PropertyState<string> m_resourceUri;

	private PropertyState<string> m_authenticationProfileUri;

	private PropertyState<BrokerTransportQualityOfService> m_requestedDeliveryGuarantee;

	private PropertyState<string> m_metaDataQueueName;

	public PropertyState<string> QueueName
	{
		get
		{
			return m_queueName;
		}
		set
		{
			if (m_queueName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_queueName = value;
		}
	}

	public PropertyState<string> ResourceUri
	{
		get
		{
			return m_resourceUri;
		}
		set
		{
			if (m_resourceUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resourceUri = value;
		}
	}

	public PropertyState<string> AuthenticationProfileUri
	{
		get
		{
			return m_authenticationProfileUri;
		}
		set
		{
			if (m_authenticationProfileUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_authenticationProfileUri = value;
		}
	}

	public PropertyState<BrokerTransportQualityOfService> RequestedDeliveryGuarantee
	{
		get
		{
			return m_requestedDeliveryGuarantee;
		}
		set
		{
			if (m_requestedDeliveryGuarantee != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_requestedDeliveryGuarantee = value;
		}
	}

	public PropertyState<string> MetaDataQueueName
	{
		get
		{
			return m_metaDataQueueName;
		}
		set
		{
			if (m_metaDataQueueName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_metaDataQueueName = value;
		}
	}

	public BrokerDataSetReaderTransportState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21142u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAKAAAAEJyb2tlckRhdGFTZXRSZWFkZXJUcmFuc3BvcnRUeXBlSW5zdGFuY2UBAJZSAQCWUpZSAAD/////BQAAABVgiQoCAAAAAAAJAAAAUXVldWVOYW1lAQCXUgAuAESXUgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVzb3VyY2VVcmkBAOY7AC4AROY7AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABgAAABBdXRoZW50aWNhdGlvblByb2ZpbGVVcmkBADs8AC4ARDs8AAAADP////8BAf////8AAAAAFWCJCgIAAAAAABoAAABSZXF1ZXN0ZWREZWxpdmVyeUd1YXJhbnRlZQEAPDwALgBEPDwAAAEAoDr/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWV0YURhdGFRdWV1ZU5hbWUBAJhSAC4ARJhSAAAADP////8BAf////8AAAAA");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_queueName != null)
		{
			children.Add(m_queueName);
		}
		if (m_resourceUri != null)
		{
			children.Add(m_resourceUri);
		}
		if (m_authenticationProfileUri != null)
		{
			children.Add(m_authenticationProfileUri);
		}
		if (m_requestedDeliveryGuarantee != null)
		{
			children.Add(m_requestedDeliveryGuarantee);
		}
		if (m_metaDataQueueName != null)
		{
			children.Add(m_metaDataQueueName);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		switch (browseName.Name)
		{
		case "QueueName":
			if (createOrReplace && QueueName == null)
			{
				if (replacement == null)
				{
					QueueName = new PropertyState<string>(this);
				}
				else
				{
					QueueName = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = QueueName;
			break;
		case "ResourceUri":
			if (createOrReplace && ResourceUri == null)
			{
				if (replacement == null)
				{
					ResourceUri = new PropertyState<string>(this);
				}
				else
				{
					ResourceUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ResourceUri;
			break;
		case "AuthenticationProfileUri":
			if (createOrReplace && AuthenticationProfileUri == null)
			{
				if (replacement == null)
				{
					AuthenticationProfileUri = new PropertyState<string>(this);
				}
				else
				{
					AuthenticationProfileUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = AuthenticationProfileUri;
			break;
		case "RequestedDeliveryGuarantee":
			if (createOrReplace && RequestedDeliveryGuarantee == null)
			{
				if (replacement == null)
				{
					RequestedDeliveryGuarantee = new PropertyState<BrokerTransportQualityOfService>(this);
				}
				else
				{
					RequestedDeliveryGuarantee = (PropertyState<BrokerTransportQualityOfService>)replacement;
				}
			}
			baseInstanceState = RequestedDeliveryGuarantee;
			break;
		case "MetaDataQueueName":
			if (createOrReplace && MetaDataQueueName == null)
			{
				if (replacement == null)
				{
					MetaDataQueueName = new PropertyState<string>(this);
				}
				else
				{
					MetaDataQueueName = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = MetaDataQueueName;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
