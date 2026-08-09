using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class KeyCredentialConfigurationState : BaseObjectState
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

	public PropertyState<string> ProfileUri
	{
		get
		{
			return m_profileUri;
		}
		set
		{
			if (m_profileUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_profileUri = value;
		}
	}

	public PropertyState<string[]> EndpointUrls
	{
		get
		{
			return m_endpointUrls;
		}
		set
		{
			if (m_endpointUrls != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endpointUrls = value;
		}
	}

	public PropertyState<StatusCode> ServiceStatus
	{
		get
		{
			return m_serviceStatus;
		}
		set
		{
			if (m_serviceStatus != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serviceStatus = value;
		}
	}

	public GetEncryptingKeyMethodState GetEncryptingKey
	{
		get
		{
			return m_getEncryptingKeyMethod;
		}
		set
		{
			if (m_getEncryptingKeyMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_getEncryptingKeyMethod = value;
		}
	}

	public KeyCredentialUpdateMethodState UpdateCredential
	{
		get
		{
			return m_updateCredentialMethod;
		}
		set
		{
			if (m_updateCredentialMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateCredentialMethod = value;
		}
	}

	public MethodState DeleteCredential
	{
		get
		{
			return m_deleteCredentialMethod;
		}
		set
		{
			if (m_deleteCredentialMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_deleteCredentialMethod = value;
		}
	}

	public KeyCredentialConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18001u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJgAAAEtleUNyZWRlbnRpYWxDb25maWd1cmF0aW9uVHlwZUluc3RhbmNlAQBRRgEAUUZRRgAA/////wcAAAAVYIkKAgAAAAAACwAAAFJlc291cmNlVXJpAQCVRgAuAESVRgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAUHJvZmlsZVVyaQEA9UYALgBE9UYAAAAM/////wEB/////wAAAAAXYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAANAAAAU2VydmljZVN0YXR1cwEAVUYALgBEVUYAAAAT/////wEB/////wAAAAAEYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAABAAAABVcGRhdGVDcmVkZW50aWFsAQBWRgAvAQBWRlZGAAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAV0YALgBEV0YAAJYEAAAAAQAqAQEbAAAADAAAAENyZWRlbnRpYWxJZAAM/////wAAAAAAAQAqAQEfAAAAEAAAAENyZWRlbnRpYWxTZWNyZXQAD/////8AAAAAAAEAKgEBJAAAABUAAABDZXJ0aWZpY2F0ZVRodW1icHJpbnQADP////8AAAAAAAEAKgEBIAAAABEAAABTZWN1cml0eVBvbGljeVVyaQAM/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=");
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
		if (EndpointUrls != null)
		{
			EndpointUrls.Initialize(context, "//////////8XYIkKAgAAAAAADAAAAEVuZHBvaW50VXJscwEAVEYALgBEVEYAAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (ServiceStatus != null)
		{
			ServiceStatus.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAFNlcnZpY2VTdGF0dXMBAFVGAC4ARFVGAAAAE/////8BAf////8AAAAA");
		}
		if (GetEncryptingKey != null)
		{
			GetEncryptingKey.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAEdldEVuY3J5cHRpbmdLZXkBAH5EAC8BAH5EfkQAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQB/RAAuAER/RAAAlgIAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBASkAAAAaAAAAUmVxdWVzdGVkU2VjdXJpdHlQb2xpY3lVcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAIBEAC4ARIBEAACWAgAAAAEAKgEBGAAAAAkAAABQdWJsaWNLZXkAD/////8AAAAAAAEAKgEBJwAAABgAAABSZXZpc2VkU2VjdXJpdHlQb2xpY3lVcmkAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (UpdateCredential != null)
		{
			UpdateCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAFVwZGF0ZUNyZWRlbnRpYWwBAFZGAC8BAFZGVkYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQBXRgAuAERXRgAAlgQAAAABACoBARsAAAAMAAAAQ3JlZGVudGlhbElkAAz/////AAAAAAABACoBAR8AAAAQAAAAQ3JlZGVudGlhbFNlY3JldAAP/////wAAAAAAAQAqAQEkAAAAFQAAAENlcnRpZmljYXRlVGh1bWJwcmludAAM/////wAAAAAAAQAqAQEgAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (DeleteCredential != null)
		{
			DeleteCredential.Initialize(context, "//////////8EYYIKBAAAAAAAEAAAAERlbGV0ZUNyZWRlbnRpYWwBAFhGAC8BAFhGWEYAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_resourceUri != null)
		{
			children.Add(m_resourceUri);
		}
		if (m_profileUri != null)
		{
			children.Add(m_profileUri);
		}
		if (m_endpointUrls != null)
		{
			children.Add(m_endpointUrls);
		}
		if (m_serviceStatus != null)
		{
			children.Add(m_serviceStatus);
		}
		if (m_getEncryptingKeyMethod != null)
		{
			children.Add(m_getEncryptingKeyMethod);
		}
		if (m_updateCredentialMethod != null)
		{
			children.Add(m_updateCredentialMethod);
		}
		if (m_deleteCredentialMethod != null)
		{
			children.Add(m_deleteCredentialMethod);
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
		case "ProfileUri":
			if (createOrReplace && ProfileUri == null)
			{
				if (replacement == null)
				{
					ProfileUri = new PropertyState<string>(this);
				}
				else
				{
					ProfileUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = ProfileUri;
			break;
		case "EndpointUrls":
			if (createOrReplace && EndpointUrls == null)
			{
				if (replacement == null)
				{
					EndpointUrls = new PropertyState<string[]>(this);
				}
				else
				{
					EndpointUrls = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = EndpointUrls;
			break;
		case "ServiceStatus":
			if (createOrReplace && ServiceStatus == null)
			{
				if (replacement == null)
				{
					ServiceStatus = new PropertyState<StatusCode>(this);
				}
				else
				{
					ServiceStatus = (PropertyState<StatusCode>)replacement;
				}
			}
			baseInstanceState = ServiceStatus;
			break;
		case "GetEncryptingKey":
			if (createOrReplace && GetEncryptingKey == null)
			{
				if (replacement == null)
				{
					GetEncryptingKey = new GetEncryptingKeyMethodState(this);
				}
				else
				{
					GetEncryptingKey = (GetEncryptingKeyMethodState)replacement;
				}
			}
			baseInstanceState = GetEncryptingKey;
			break;
		case "UpdateCredential":
			if (createOrReplace && UpdateCredential == null)
			{
				if (replacement == null)
				{
					UpdateCredential = new KeyCredentialUpdateMethodState(this);
				}
				else
				{
					UpdateCredential = (KeyCredentialUpdateMethodState)replacement;
				}
			}
			baseInstanceState = UpdateCredential;
			break;
		case "DeleteCredential":
			if (createOrReplace && DeleteCredential == null)
			{
				if (replacement == null)
				{
					DeleteCredential = new MethodState(this);
				}
				else
				{
					DeleteCredential = (MethodState)replacement;
				}
			}
			baseInstanceState = DeleteCredential;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
