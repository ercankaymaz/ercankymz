using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PublishedEventsState : PublishedDataSetState
{
	private const string ModifyFieldSelection_InitializationString = "//////////8EYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVJbnN0YW5jZQEA7DgBAOw47DgAAP////8GAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA9jgALgBE9jgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCNOwAuAESNOwAAAQC7OP////8BAf////8AAAAAFWDJCgIAAAATAAAAUHViU3ViRXZlbnROb3RpZmllcgAADQAAAEV2ZW50Tm90aWZpZXIBAPo4AC4ARPo4AAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABTZWxlY3RlZEZpZWxkcwEA+zgALgBE+zgAAAEAWQIBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAYAAABGaWx0ZXIBAPw4AC4ARPw4AAABAEoC/////wEB/////wAAAAAEYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<NodeId> m_pubSubEventNotifier;

	private PropertyState<SimpleAttributeOperand[]> m_selectedFields;

	private PropertyState<ContentFilter> m_filter;

	private PublishedEventsTypeModifyFieldSelectionMethodState m_modifyFieldSelectionMethod;

	public PropertyState<NodeId> PubSubEventNotifier
	{
		get
		{
			return m_pubSubEventNotifier;
		}
		set
		{
			if (m_pubSubEventNotifier != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_pubSubEventNotifier = value;
		}
	}

	public PropertyState<SimpleAttributeOperand[]> SelectedFields
	{
		get
		{
			return m_selectedFields;
		}
		set
		{
			if (m_selectedFields != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_selectedFields = value;
		}
	}

	public PropertyState<ContentFilter> Filter
	{
		get
		{
			return m_filter;
		}
		set
		{
			if (m_filter != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_filter = value;
		}
	}

	public PublishedEventsTypeModifyFieldSelectionMethodState ModifyFieldSelection
	{
		get
		{
			return m_modifyFieldSelectionMethod;
		}
		set
		{
			if (m_modifyFieldSelectionMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_modifyFieldSelectionMethod = value;
		}
	}

	public PublishedEventsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(14572u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFB1Ymxpc2hlZEV2ZW50c1R5cGVJbnN0YW5jZQEA7DgBAOw47DgAAP////8GAAAAFWCJCgIAAAAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEA9jgALgBE9jgAAAEAATn/////AQH/////AAAAABVgiQoCAAAAAAAPAAAARGF0YVNldE1ldGFEYXRhAQCNOwAuAESNOwAAAQC7OP////8BAf////8AAAAAFWDJCgIAAAATAAAAUHViU3ViRXZlbnROb3RpZmllcgAADQAAAEV2ZW50Tm90aWZpZXIBAPo4AC4ARPo4AAAAEf////8BAf////8AAAAAF2CJCgIAAAAAAA4AAABTZWxlY3RlZEZpZWxkcwEA+zgALgBE+zgAAAEAWQIBAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAYAAABGaWx0ZXIBAPw4AC4ARPw4AAABAEoC/////wEB/////wAAAAAEYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (ModifyFieldSelection != null)
		{
			ModifyFieldSelection.Initialize(context, "//////////8EYYIKBAAAAAAAFAAAAE1vZGlmeUZpZWxkU2VsZWN0aW9uAQDMOgAvAQDMOsw6AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAzToALgBEzToAAJYEAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIwAAABAAAABGaWVsZE5hbWVBbGlhc2VzAAwBAAAAAQAAAAAAAAAAAQAqAQEhAAAADgAAAFByb21vdGVkRmllbGRzAAEBAAAAAQAAAAAAAAAAAQAqAQEjAAAADgAAAFNlbGVjdGVkRmllbGRzAQBZAgEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCdPAAuAESdPAAAlgEAAAABACoBASgAAAAXAAAATmV3Q29uZmlndXJhdGlvblZlcnNpb24BAAE5/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_pubSubEventNotifier != null)
		{
			children.Add(m_pubSubEventNotifier);
		}
		if (m_selectedFields != null)
		{
			children.Add(m_selectedFields);
		}
		if (m_filter != null)
		{
			children.Add(m_filter);
		}
		if (m_modifyFieldSelectionMethod != null)
		{
			children.Add(m_modifyFieldSelectionMethod);
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
		case "EventNotifier":
			if (createOrReplace && PubSubEventNotifier == null)
			{
				if (replacement == null)
				{
					PubSubEventNotifier = new PropertyState<NodeId>(this);
				}
				else
				{
					PubSubEventNotifier = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = PubSubEventNotifier;
			break;
		case "SelectedFields":
			if (createOrReplace && SelectedFields == null)
			{
				if (replacement == null)
				{
					SelectedFields = new PropertyState<SimpleAttributeOperand[]>(this);
				}
				else
				{
					SelectedFields = (PropertyState<SimpleAttributeOperand[]>)replacement;
				}
			}
			baseInstanceState = SelectedFields;
			break;
		case "Filter":
			if (createOrReplace && Filter == null)
			{
				if (replacement == null)
				{
					Filter = new PropertyState<ContentFilter>(this);
				}
				else
				{
					Filter = (PropertyState<ContentFilter>)replacement;
				}
			}
			baseInstanceState = Filter;
			break;
		case "ModifyFieldSelection":
			if (createOrReplace && ModifyFieldSelection == null)
			{
				if (replacement == null)
				{
					ModifyFieldSelection = new PublishedEventsTypeModifyFieldSelectionMethodState(this);
				}
				else
				{
					ModifyFieldSelection = (PublishedEventsTypeModifyFieldSelectionMethodState)replacement;
				}
			}
			baseInstanceState = ModifyFieldSelection;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
