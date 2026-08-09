using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class RoleState : BaseObjectState
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

	public PropertyState<IdentityMappingRuleType[]> Identities
	{
		get
		{
			return m_identities;
		}
		set
		{
			if (m_identities != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_identities = value;
		}
	}

	public PropertyState<string[]> Applications
	{
		get
		{
			return m_applications;
		}
		set
		{
			if (m_applications != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_applications = value;
		}
	}

	public PropertyState<bool> ApplicationsExclude
	{
		get
		{
			return m_applicationsExclude;
		}
		set
		{
			if (m_applicationsExclude != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_applicationsExclude = value;
		}
	}

	public PropertyState<EndpointType[]> Endpoints
	{
		get
		{
			return m_endpoints;
		}
		set
		{
			if (m_endpoints != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endpoints = value;
		}
	}

	public PropertyState<bool> EndpointsExclude
	{
		get
		{
			return m_endpointsExclude;
		}
		set
		{
			if (m_endpointsExclude != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_endpointsExclude = value;
		}
	}

	public AddIdentityMethodState AddIdentity
	{
		get
		{
			return m_addIdentityMethod;
		}
		set
		{
			if (m_addIdentityMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addIdentityMethod = value;
		}
	}

	public RemoveIdentityMethodState RemoveIdentity
	{
		get
		{
			return m_removeIdentityMethod;
		}
		set
		{
			if (m_removeIdentityMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeIdentityMethod = value;
		}
	}

	public AddApplicationMethodState AddApplication
	{
		get
		{
			return m_addApplicationMethod;
		}
		set
		{
			if (m_addApplicationMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addApplicationMethod = value;
		}
	}

	public RemoveApplicationMethodState RemoveApplication
	{
		get
		{
			return m_removeApplicationMethod;
		}
		set
		{
			if (m_removeApplicationMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeApplicationMethod = value;
		}
	}

	public AddEndpointMethodState AddEndpoint
	{
		get
		{
			return m_addEndpointMethod;
		}
		set
		{
			if (m_addEndpointMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addEndpointMethod = value;
		}
	}

	public RemoveEndpointMethodState RemoveEndpoint
	{
		get
		{
			return m_removeEndpointMethod;
		}
		set
		{
			if (m_removeEndpointMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeEndpointMethod = value;
		}
	}

	public RoleState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15620u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAEAAAAFJvbGVUeXBlSW5zdGFuY2UBAAQ9AQAEPQQ9AAD/////CwAAABdgiQoCAAAAAAAKAAAASWRlbnRpdGllcwEALT8ALgBELT8AAAEAEj0BAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAwAAABBcHBsaWNhdGlvbnMBAC4/AC4ARC4/AAAADAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAAF2CJCgIAAAAAAAkAAABFbmRwb2ludHMBAC8/AC4ARC8/AAABAKg8AQAAAAEAAAAAAAAAAQH/////AAAAABVgiQoCAAAAAAAQAAAARW5kcG9pbnRzRXhjbHVkZQEAMzwALgBEMzwAAAAB/////wEB/////wAAAAAEYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAARAAAAUmVtb3ZlQXBwbGljYXRpb24BADI/AC8BADI/Mj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAzPwAuAEQzPwAAlgEAAAABACoBAR0AAAAOAAAAQXBwbGljYXRpb25VcmkADP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAABGGCCgQAAAAAAAsAAABBZGRFbmRwb2ludAEAND8ALwEAND80PwAAAQH/////AQAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBADU/AC4ARDU/AACWAQAAAAEAKgEBGQAAAAgAAABFbmRwb2ludAEAqDz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAOAAAAUmVtb3ZlRW5kcG9pbnQBADY/AC8BADY/Nj8AAAEB/////wEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQA3PwAuAEQ3PwAAlgEAAAABACoBARkAAAAIAAAARW5kcG9pbnQBAKg8/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (Applications != null)
		{
			Applications.Initialize(context, "//////////8XYIkKAgAAAAAADAAAAEFwcGxpY2F0aW9ucwEALj8ALgBELj8AAAAMAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (ApplicationsExclude != null)
		{
			ApplicationsExclude.Initialize(context, "//////////8VYIkKAgAAAAAAEwAAAEFwcGxpY2F0aW9uc0V4Y2x1ZGUBADI8AC4ARDI8AAAAAf////8BAf////8AAAAA");
		}
		if (Endpoints != null)
		{
			Endpoints.Initialize(context, "//////////8XYIkKAgAAAAAACQAAAEVuZHBvaW50cwEALz8ALgBELz8AAAEAqDwBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (EndpointsExclude != null)
		{
			EndpointsExclude.Initialize(context, "//////////8VYIkKAgAAAAAAEAAAAEVuZHBvaW50c0V4Y2x1ZGUBADM8AC4ARDM8AAAAAf////8BAf////8AAAAA");
		}
		if (AddIdentity != null)
		{
			AddIdentity.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAEFkZElkZW50aXR5AQAIPQAvAQAIPQg9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACT0ALgBECT0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (RemoveIdentity != null)
		{
			RemoveIdentity.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUlkZW50aXR5AQAKPQAvAQAKPQo9AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEACz0ALgBECz0AAJYBAAAAAQAqAQEVAAAABAAAAFJ1bGUBABI9/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (AddApplication != null)
		{
			AddApplication.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAEFkZEFwcGxpY2F0aW9uAQAwPwAvAQAwPzA/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMT8ALgBEMT8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (RemoveApplication != null)
		{
			RemoveApplication.Initialize(context, "//////////8EYYIKBAAAAAAAEQAAAFJlbW92ZUFwcGxpY2F0aW9uAQAyPwAvAQAyPzI/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAMz8ALgBEMz8AAJYBAAAAAQAqAQEdAAAADgAAAEFwcGxpY2F0aW9uVXJpAAz/////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
		if (AddEndpoint != null)
		{
			AddEndpoint.Initialize(context, "//////////8EYYIKBAAAAAAACwAAAEFkZEVuZHBvaW50AQA0PwAvAQA0PzQ/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANT8ALgBENT8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
		if (RemoveEndpoint != null)
		{
			RemoveEndpoint.Initialize(context, "//////////8EYYIKBAAAAAAADgAAAFJlbW92ZUVuZHBvaW50AQA2PwAvAQA2PzY/AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEANz8ALgBENz8AAJYBAAAAAQAqAQEZAAAACAAAAEVuZHBvaW50AQCoPP////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_identities != null)
		{
			children.Add(m_identities);
		}
		if (m_applications != null)
		{
			children.Add(m_applications);
		}
		if (m_applicationsExclude != null)
		{
			children.Add(m_applicationsExclude);
		}
		if (m_endpoints != null)
		{
			children.Add(m_endpoints);
		}
		if (m_endpointsExclude != null)
		{
			children.Add(m_endpointsExclude);
		}
		if (m_addIdentityMethod != null)
		{
			children.Add(m_addIdentityMethod);
		}
		if (m_removeIdentityMethod != null)
		{
			children.Add(m_removeIdentityMethod);
		}
		if (m_addApplicationMethod != null)
		{
			children.Add(m_addApplicationMethod);
		}
		if (m_removeApplicationMethod != null)
		{
			children.Add(m_removeApplicationMethod);
		}
		if (m_addEndpointMethod != null)
		{
			children.Add(m_addEndpointMethod);
		}
		if (m_removeEndpointMethod != null)
		{
			children.Add(m_removeEndpointMethod);
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
		case "Identities":
			if (createOrReplace && Identities == null)
			{
				if (replacement == null)
				{
					Identities = new PropertyState<IdentityMappingRuleType[]>(this);
				}
				else
				{
					Identities = (PropertyState<IdentityMappingRuleType[]>)replacement;
				}
			}
			baseInstanceState = Identities;
			break;
		case "Applications":
			if (createOrReplace && Applications == null)
			{
				if (replacement == null)
				{
					Applications = new PropertyState<string[]>(this);
				}
				else
				{
					Applications = (PropertyState<string[]>)replacement;
				}
			}
			baseInstanceState = Applications;
			break;
		case "ApplicationsExclude":
			if (createOrReplace && ApplicationsExclude == null)
			{
				if (replacement == null)
				{
					ApplicationsExclude = new PropertyState<bool>(this);
				}
				else
				{
					ApplicationsExclude = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = ApplicationsExclude;
			break;
		case "Endpoints":
			if (createOrReplace && Endpoints == null)
			{
				if (replacement == null)
				{
					Endpoints = new PropertyState<EndpointType[]>(this);
				}
				else
				{
					Endpoints = (PropertyState<EndpointType[]>)replacement;
				}
			}
			baseInstanceState = Endpoints;
			break;
		case "EndpointsExclude":
			if (createOrReplace && EndpointsExclude == null)
			{
				if (replacement == null)
				{
					EndpointsExclude = new PropertyState<bool>(this);
				}
				else
				{
					EndpointsExclude = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = EndpointsExclude;
			break;
		case "AddIdentity":
			if (createOrReplace && AddIdentity == null)
			{
				if (replacement == null)
				{
					AddIdentity = new AddIdentityMethodState(this);
				}
				else
				{
					AddIdentity = (AddIdentityMethodState)replacement;
				}
			}
			baseInstanceState = AddIdentity;
			break;
		case "RemoveIdentity":
			if (createOrReplace && RemoveIdentity == null)
			{
				if (replacement == null)
				{
					RemoveIdentity = new RemoveIdentityMethodState(this);
				}
				else
				{
					RemoveIdentity = (RemoveIdentityMethodState)replacement;
				}
			}
			baseInstanceState = RemoveIdentity;
			break;
		case "AddApplication":
			if (createOrReplace && AddApplication == null)
			{
				if (replacement == null)
				{
					AddApplication = new AddApplicationMethodState(this);
				}
				else
				{
					AddApplication = (AddApplicationMethodState)replacement;
				}
			}
			baseInstanceState = AddApplication;
			break;
		case "RemoveApplication":
			if (createOrReplace && RemoveApplication == null)
			{
				if (replacement == null)
				{
					RemoveApplication = new RemoveApplicationMethodState(this);
				}
				else
				{
					RemoveApplication = (RemoveApplicationMethodState)replacement;
				}
			}
			baseInstanceState = RemoveApplication;
			break;
		case "AddEndpoint":
			if (createOrReplace && AddEndpoint == null)
			{
				if (replacement == null)
				{
					AddEndpoint = new AddEndpointMethodState(this);
				}
				else
				{
					AddEndpoint = (AddEndpointMethodState)replacement;
				}
			}
			baseInstanceState = AddEndpoint;
			break;
		case "RemoveEndpoint":
			if (createOrReplace && RemoveEndpoint == null)
			{
				if (replacement == null)
				{
					RemoveEndpoint = new RemoveEndpointMethodState(this);
				}
				else
				{
					RemoveEndpoint = (RemoveEndpointMethodState)replacement;
				}
			}
			baseInstanceState = RemoveEndpoint;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
