using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditActivateSessionEventState : AuditSessionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJQAAAEF1ZGl0QWN0aXZhdGVTZXNzaW9uRXZlbnRUeXBlSW5zdGFuY2UBABsIAQAbCBsIAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5AwALgBE5AwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5QwALgBE5QwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYMAC4AROYMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnDAAuAETnDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6AwALgBE6AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkMAC4AROkMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsMAC4AROsMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7AwALgBE7AwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA7QwALgBE7QwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDuDAAuAETuDAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAO8MAC4ARO8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPAMAC4ARPAMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPEMAC4ARPEMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAPIMAC4ARPIMAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABoAAABDbGllbnRTb2Z0d2FyZUNlcnRpZmljYXRlcwEAHAgALgBEHAgAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABEAAABVc2VySWRlbnRpdHlUb2tlbgEAHQgALgBEHQgAAAEAPAH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQDdLAAuAETdLAAAAAz/////AQH/////AAAAAA==";

	private PropertyState<SignedSoftwareCertificate[]> m_clientSoftwareCertificates;

	private PropertyState<UserIdentityToken> m_userIdentityToken;

	private PropertyState<string> m_secureChannelId;

	public PropertyState<SignedSoftwareCertificate[]> ClientSoftwareCertificates
	{
		get
		{
			return m_clientSoftwareCertificates;
		}
		set
		{
			if (m_clientSoftwareCertificates != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_clientSoftwareCertificates = value;
		}
	}

	public PropertyState<UserIdentityToken> UserIdentityToken
	{
		get
		{
			return m_userIdentityToken;
		}
		set
		{
			if (m_userIdentityToken != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_userIdentityToken = value;
		}
	}

	public PropertyState<string> SecureChannelId
	{
		get
		{
			return m_secureChannelId;
		}
		set
		{
			if (m_secureChannelId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_secureChannelId = value;
		}
	}

	public AuditActivateSessionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2075u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJQAAAEF1ZGl0QWN0aXZhdGVTZXNzaW9uRXZlbnRUeXBlSW5zdGFuY2UBABsIAQAbCBsIAAD/////EQAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5AwALgBE5AwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5QwALgBE5QwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYMAC4AROYMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnDAAuAETnDAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6AwALgBE6AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkMAC4AROkMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsMAC4AROsMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7AwALgBE7AwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA7QwALgBE7QwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQDuDAAuAETuDAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAO8MAC4ARO8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAPAMAC4ARPAMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAPEMAC4ARPEMAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAPIMAC4ARPIMAAAAEf////8BAf////8AAAAAF2CJCgIAAAAAABoAAABDbGllbnRTb2Z0d2FyZUNlcnRpZmljYXRlcwEAHAgALgBEHAgAAAEAWAEBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAABEAAABVc2VySWRlbnRpdHlUb2tlbgEAHQgALgBEHQgAAAEAPAH/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAU2VjdXJlQ2hhbm5lbElkAQDdLAAuAETdLAAAAAz/////AQH/////AAAAAA==");
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
		if (m_clientSoftwareCertificates != null)
		{
			children.Add(m_clientSoftwareCertificates);
		}
		if (m_userIdentityToken != null)
		{
			children.Add(m_userIdentityToken);
		}
		if (m_secureChannelId != null)
		{
			children.Add(m_secureChannelId);
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
		case "ClientSoftwareCertificates":
			if (createOrReplace && ClientSoftwareCertificates == null)
			{
				if (replacement == null)
				{
					ClientSoftwareCertificates = new PropertyState<SignedSoftwareCertificate[]>(this);
				}
				else
				{
					ClientSoftwareCertificates = (PropertyState<SignedSoftwareCertificate[]>)replacement;
				}
			}
			baseInstanceState = ClientSoftwareCertificates;
			break;
		case "UserIdentityToken":
			if (createOrReplace && UserIdentityToken == null)
			{
				if (replacement == null)
				{
					UserIdentityToken = new PropertyState<UserIdentityToken>(this);
				}
				else
				{
					UserIdentityToken = (PropertyState<UserIdentityToken>)replacement;
				}
			}
			baseInstanceState = UserIdentityToken;
			break;
		case "SecureChannelId":
			if (createOrReplace && SecureChannelId == null)
			{
				if (replacement == null)
				{
					SecureChannelId = new PropertyState<string>(this);
				}
				else
				{
					SecureChannelId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecureChannelId;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
