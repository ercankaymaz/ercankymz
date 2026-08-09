using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class SecurityGroupState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAFNlY3VyaXR5R3JvdXBUeXBlSW5zdGFuY2UBAG88AQBvPG88AAD/////BQAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQBwPAAuAERwPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAS2V5TGlmZXRpbWUBAMY6AC4ARMY6AAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDHOgAuAETHOgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQBAMg6AC4ARMg6AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhQYXN0S2V5Q291bnQBANA6AC4ARNA6AAAAB/////8BAf////8AAAAA";

	private PropertyState<string> m_securityGroupId;

	private PropertyState<double> m_keyLifetime;

	private PropertyState<string> m_securityPolicyUri;

	private PropertyState<uint> m_maxFutureKeyCount;

	private PropertyState<uint> m_maxPastKeyCount;

	public PropertyState<string> SecurityGroupId
	{
		get
		{
			return m_securityGroupId;
		}
		set
		{
			if (m_securityGroupId != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityGroupId = value;
		}
	}

	public PropertyState<double> KeyLifetime
	{
		get
		{
			return m_keyLifetime;
		}
		set
		{
			if (m_keyLifetime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_keyLifetime = value;
		}
	}

	public PropertyState<string> SecurityPolicyUri
	{
		get
		{
			return m_securityPolicyUri;
		}
		set
		{
			if (m_securityPolicyUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_securityPolicyUri = value;
		}
	}

	public PropertyState<uint> MaxFutureKeyCount
	{
		get
		{
			return m_maxFutureKeyCount;
		}
		set
		{
			if (m_maxFutureKeyCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxFutureKeyCount = value;
		}
	}

	public PropertyState<uint> MaxPastKeyCount
	{
		get
		{
			return m_maxPastKeyCount;
		}
		set
		{
			if (m_maxPastKeyCount != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxPastKeyCount = value;
		}
	}

	public SecurityGroupState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15471u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGQAAAFNlY3VyaXR5R3JvdXBUeXBlSW5zdGFuY2UBAG88AQBvPG88AAD/////BQAAABVgiQoCAAAAAAAPAAAAU2VjdXJpdHlHcm91cElkAQBwPAAuAERwPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAALAAAAS2V5TGlmZXRpbWUBAMY6AC4ARMY6AAABACIB/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAFNlY3VyaXR5UG9saWN5VXJpAQDHOgAuAETHOgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAARAAAATWF4RnV0dXJlS2V5Q291bnQBAMg6AC4ARMg6AAAAB/////8BAf////8AAAAAFWCJCgIAAAAAAA8AAABNYXhQYXN0S2V5Q291bnQBANA6AC4ARNA6AAAAB/////8BAf////8AAAAA");
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
		if (m_securityGroupId != null)
		{
			children.Add(m_securityGroupId);
		}
		if (m_keyLifetime != null)
		{
			children.Add(m_keyLifetime);
		}
		if (m_securityPolicyUri != null)
		{
			children.Add(m_securityPolicyUri);
		}
		if (m_maxFutureKeyCount != null)
		{
			children.Add(m_maxFutureKeyCount);
		}
		if (m_maxPastKeyCount != null)
		{
			children.Add(m_maxPastKeyCount);
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
		case "SecurityGroupId":
			if (createOrReplace && SecurityGroupId == null)
			{
				if (replacement == null)
				{
					SecurityGroupId = new PropertyState<string>(this);
				}
				else
				{
					SecurityGroupId = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecurityGroupId;
			break;
		case "KeyLifetime":
			if (createOrReplace && KeyLifetime == null)
			{
				if (replacement == null)
				{
					KeyLifetime = new PropertyState<double>(this);
				}
				else
				{
					KeyLifetime = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = KeyLifetime;
			break;
		case "SecurityPolicyUri":
			if (createOrReplace && SecurityPolicyUri == null)
			{
				if (replacement == null)
				{
					SecurityPolicyUri = new PropertyState<string>(this);
				}
				else
				{
					SecurityPolicyUri = (PropertyState<string>)replacement;
				}
			}
			baseInstanceState = SecurityPolicyUri;
			break;
		case "MaxFutureKeyCount":
			if (createOrReplace && MaxFutureKeyCount == null)
			{
				if (replacement == null)
				{
					MaxFutureKeyCount = new PropertyState<uint>(this);
				}
				else
				{
					MaxFutureKeyCount = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxFutureKeyCount;
			break;
		case "MaxPastKeyCount":
			if (createOrReplace && MaxPastKeyCount == null)
			{
				if (replacement == null)
				{
					MaxPastKeyCount = new PropertyState<uint>(this);
				}
				else
				{
					MaxPastKeyCount = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = MaxPastKeyCount;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
