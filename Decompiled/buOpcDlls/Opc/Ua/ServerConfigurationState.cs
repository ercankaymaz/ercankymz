using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ServerConfigurationState : BaseObjectState
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

	public CertificateGroupFolderState CertificateGroups
	{
		get
		{
			return m_certificateGroups;
		}
		set
		{
			if (m_certificateGroups != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_certificateGroups = value;
		}
	}

	public PropertyState<string[]> ServerCapabilities
	{
		get
		{
			return m_serverCapabilities;
		}
		set
		{
			if (m_serverCapabilities != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_serverCapabilities = value;
		}
	}

	public PropertyState<string[]> SupportedPrivateKeyFormats
	{
		get
		{
			return m_supportedPrivateKeyFormats;
		}
		set
		{
			if (m_supportedPrivateKeyFormats != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_supportedPrivateKeyFormats = value;
		}
	}

	public PropertyState<uint> MaxTrustListSize
	{
		get
		{
			return m_maxTrustListSize;
		}
		set
		{
			if (m_maxTrustListSize != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxTrustListSize = value;
		}
	}

	public PropertyState<bool> MulticastDnsEnabled
	{
		get
		{
			return m_multicastDnsEnabled;
		}
		set
		{
			if (m_multicastDnsEnabled != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_multicastDnsEnabled = value;
		}
	}

	public UpdateCertificateMethodState UpdateCertificate
	{
		get
		{
			return m_updateCertificateMethod;
		}
		set
		{
			if (m_updateCertificateMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_updateCertificateMethod = value;
		}
	}

	public MethodState ApplyChanges
	{
		get
		{
			return m_applyChangesMethod;
		}
		set
		{
			if (m_applyChangesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_applyChangesMethod = value;
		}
	}

	public CreateSigningRequestMethodState CreateSigningRequest
	{
		get
		{
			return m_createSigningRequestMethod;
		}
		set
		{
			if (m_createSigningRequestMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_createSigningRequestMethod = value;
		}
	}

	public GetRejectedListMethodState GetRejectedList
	{
		get
		{
			return m_getRejectedListMethod;
		}
		set
		{
			if (m_getRejectedListMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_getRejectedListMethod = value;
		}
	}

	public ServerConfigurationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(12581u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHwAAAFNlcnZlckNvbmZpZ3VyYXRpb25UeXBlSW5zdGFuY2UBACUxAQAlMSUxAAD/////CQAAAARggAoBAAAAAAARAAAAQ2VydGlmaWNhdGVHcm91cHMBAH42AC8BAPU1fjYAAP////8BAAAABGCACgEAAAAAABcAAABEZWZhdWx0QXBwbGljYXRpb25Hcm91cAEAfzYALwEACzF/NgAA/////wIAAAAEYIAKAQAAAAAACQAAAFRydXN0TGlzdAEAgDYALwEA6jCANgAA/////wwAAAAVYIkKAgAAAAAABAAAAFNpemUBAIE2AC4ARIE2AAAACf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABXcml0YWJsZQEAgjYALgBEgjYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAFVzZXJXcml0YWJsZQEAgzYALgBEgzYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAE9wZW5Db3VudAEAhDYALgBEhDYAAAAF/////wEB/////wAAAAAEYYIKBAAAAAAABAAAAE9wZW4BAIY2AC8BADwthjYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCHNgAuAESHNgAAlgEAAAABACoBARMAAAAEAAAATW9kZQAD/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAiDYALgBEiDYAAJYBAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAUAAABDbG9zZQEAiTYALwEAPy2JNgAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIo2AC4ARIo2AACWAQAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAEAAAAUmVhZAEAizYALwEAQS2LNgAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIw2AC4ARIw2AACWAgAAAAEAKgEBGQAAAAoAAABGaWxlSGFuZGxlAAf/////AAAAAAABACoBARUAAAAGAAAATGVuZ3RoAAb/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCNNgAuAESNNgAAlgEAAAABACoBARMAAAAEAAAARGF0YQAP/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAABQAAAFdyaXRlAQCONgAvAQBELY42AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAjzYALgBEjzYAAJYCAAAAAQAqAQEZAAAACgAAAEZpbGVIYW5kbGUAB/////8AAAAAAAEAKgEBEwAAAAQAAABEYXRhAA//////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAR2V0UG9zaXRpb24BAJA2AC8BAEYtkDYAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCRNgAuAESRNgAAlgEAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAkjYALgBEkjYAAJYBAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAALAAAAU2V0UG9zaXRpb24BAJM2AC8BAEktkzYAAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQCUNgAuAESUNgAAlgIAAAABACoBARkAAAAKAAAARmlsZUhhbmRsZQAH/////wAAAAAAAQAqAQEXAAAACAAAAFBvc2l0aW9uAAn/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAOAAAATGFzdFVwZGF0ZVRpbWUBAJU2AC4ARJU2AAABACYB/////wEB/////wAAAAAEYYIKBAAAAAAADQAAAE9wZW5X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");
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
		if (m_certificateGroups != null)
		{
			children.Add(m_certificateGroups);
		}
		if (m_serverCapabilities != null)
		{
			children.Add(m_serverCapabilities);
		}
		if (m_supportedPrivateKeyFormats != null)
		{
			children.Add(m_supportedPrivateKeyFormats);
		}
		if (m_maxTrustListSize != null)
		{
			children.Add(m_maxTrustListSize);
		}
		if (m_multicastDnsEnabled != null)
		{
			children.Add(m_multicastDnsEnabled);
		}
		if (m_updateCertificateMethod != null)
		{
			children.Add(m_updateCertificateMethod);
		}
		if (m_applyChangesMethod != null)
		{
			children.Add(m_applyChangesMethod);
		}
		if (m_createSigningRequestMethod != null)
		{
			children.Add(m_createSigningRequestMethod);
		}
		if (m_getRejectedListMethod != null)
		{
			children.Add(m_getRejectedListMethod);
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
		case "CertificateGroups":
			if (createOrReplace && CertificateGroups == null)
			{
				if (replacement == null)
				{
					CertificateGroups = new CertificateGroupFolderState(this);
				}
				else
				{
					CertificateGroups = (CertificateGroupFolderState)replacement;
				}
			}
			baseInstanceState = CertificateGroups;
			break;
		case "ServerCapabilities":
			if (createOrReplace && ServerCapabilities == null)
			{
				if (replacement == null)
				{
					ServerCapabilities = new PropertyState<string[]>(this);
				}
				else
				{
					ServerCapabilities = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = ServerCapabilities;
			break;
		case "SupportedPrivateKeyFormats":
			if (createOrReplace && SupportedPrivateKeyFormats == null)
			{
				if (replacement == null)
				{
					SupportedPrivateKeyFormats = new PropertyState<string[]>(this);
				}
				else
				{
					SupportedPrivateKeyFormats = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = SupportedPrivateKeyFormats;
			break;
		case "MaxTrustListSize":
			if (createOrReplace && MaxTrustListSize == null)
			{
				if (replacement == null)
				{
					MaxTrustListSize = new PropertyState<uint>(this);
				}
				else
				{
					MaxTrustListSize = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxTrustListSize;
			break;
		case "MulticastDnsEnabled":
			if (createOrReplace && MulticastDnsEnabled == null)
			{
				if (replacement == null)
				{
					MulticastDnsEnabled = new PropertyState<bool>(this);
				}
				else
				{
					MulticastDnsEnabled = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = MulticastDnsEnabled;
			break;
		case "UpdateCertificate":
			if (createOrReplace && UpdateCertificate == null)
			{
				if (replacement == null)
				{
					UpdateCertificate = new UpdateCertificateMethodState(this);
				}
				else
				{
					UpdateCertificate = (UpdateCertificateMethodState)replacement;
				}
			}
			baseInstanceState = UpdateCertificate;
			break;
		case "ApplyChanges":
			if (createOrReplace && ApplyChanges == null)
			{
				if (replacement == null)
				{
					ApplyChanges = new MethodState(this);
				}
				else
				{
					ApplyChanges = (MethodState)replacement;
				}
			}
			baseInstanceState = ApplyChanges;
			break;
		case "CreateSigningRequest":
			if (createOrReplace && CreateSigningRequest == null)
			{
				if (replacement == null)
				{
					CreateSigningRequest = new CreateSigningRequestMethodState(this);
				}
				else
				{
					CreateSigningRequest = (CreateSigningRequestMethodState)replacement;
				}
			}
			baseInstanceState = CreateSigningRequest;
			break;
		case "GetRejectedList":
			if (createOrReplace && GetRejectedList == null)
			{
				if (replacement == null)
				{
					GetRejectedList = new GetRejectedListMethodState(this);
				}
				else
				{
					GetRejectedList = (GetRejectedListMethodState)replacement;
				}
			}
			baseInstanceState = GetRejectedList;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
