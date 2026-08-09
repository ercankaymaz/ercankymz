using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TargetVariablesState : SubscribedDataSetState
{
	private const string AddTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAEgAAAEFkZFRhcmdldFZhcmlhYmxlcwEACzsALwEACzsLOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAw7AC4ARAw7AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAA07AC4ARA07AACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private const string RemoveTargetVariables_InitializationString = "//////////8EYYIKBAAAAAAAFQAAAFJlbW92ZVRhcmdldFZhcmlhYmxlcwEADjsALwEADjsOOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAA87AC4ARA87AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASIAAAAPAAAAVGFyZ2V0c1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEDsALgBEEDsAAJYBAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAFRhcmdldFZhcmlhYmxlc1R5cGVJbnN0YW5jZQEABzsBAAc7BzsAAP////8DAAAAF2CJCgIAAAAAAA8AAABUYXJnZXRWYXJpYWJsZXMBAAo7AC4ARAo7AAABAJg5AQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAASAAAAQWRkVGFyZ2V0VmFyaWFibGVzAQALOwAvAQALOws7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADDsALgBEDDsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEADTsALgBEDTsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAVAAAAUmVtb3ZlVGFyZ2V0VmFyaWFibGVzAQAOOwAvAQAOOw47AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADzsALgBEDzsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAQOwAuAEQQOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private PropertyState<FieldTargetDataType[]> m_targetVariables;

	private TargetVariablesTypeAddTargetVariablesMethodState m_addTargetVariablesMethod;

	private TargetVariablesTypeRemoveTargetVariablesMethodState m_removeTargetVariablesMethod;

	public PropertyState<FieldTargetDataType[]> TargetVariables
	{
		get
		{
			return m_targetVariables;
		}
		set
		{
			if (m_targetVariables != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_targetVariables = value;
		}
	}

	public TargetVariablesTypeAddTargetVariablesMethodState AddTargetVariables
	{
		get
		{
			return m_addTargetVariablesMethod;
		}
		set
		{
			if (m_addTargetVariablesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addTargetVariablesMethod = value;
		}
	}

	public TargetVariablesTypeRemoveTargetVariablesMethodState RemoveTargetVariables
	{
		get
		{
			return m_removeTargetVariablesMethod;
		}
		set
		{
			if (m_removeTargetVariablesMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeTargetVariablesMethod = value;
		}
	}

	public TargetVariablesState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15111u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAFRhcmdldFZhcmlhYmxlc1R5cGVJbnN0YW5jZQEABzsBAAc7BzsAAP////8DAAAAF2CJCgIAAAAAAA8AAABUYXJnZXRWYXJpYWJsZXMBAAo7AC4ARAo7AAABAJg5AQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAASAAAAQWRkVGFyZ2V0VmFyaWFibGVzAQALOwAvAQALOws7AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADDsALgBEDDsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBKQAAABQAAABUYXJnZXRWYXJpYWJsZXNUb0FkZAEAmDkBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEADTsALgBEDTsAAJYBAAAAAQAqAQEdAAAACgAAAEFkZFJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAARhggoEAAAAAAAVAAAAUmVtb3ZlVGFyZ2V0VmFyaWFibGVzAQAOOwAvAQAOOw47AAABAf////8CAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEADzsALgBEDzsAAJYCAAAAAQAqAQElAAAAFAAAAENvbmZpZ3VyYXRpb25WZXJzaW9uAQABOf////8AAAAAAAEAKgEBIgAAAA8AAABUYXJnZXRzVG9SZW1vdmUABwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQAQOwAuAEQQOwAAlgEAAAABACoBASAAAAANAAAAUmVtb3ZlUmVzdWx0cwATAQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (AddTargetVariables != null)
		{
			AddTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAEgAAAEFkZFRhcmdldFZhcmlhYmxlcwEACzsALwEACzsLOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAAw7AC4ARAw7AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASkAAAAUAAAAVGFyZ2V0VmFyaWFibGVzVG9BZGQBAJg5AQAAAAEAAAAAAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAAF2CpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAA07AC4ARA07AACWAQAAAAEAKgEBHQAAAAoAAABBZGRSZXN1bHRzABMBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAA=");
		}
		if (RemoveTargetVariables != null)
		{
			RemoveTargetVariables.Initialize(context, "//////////8EYYIKBAAAAAAAFQAAAFJlbW92ZVRhcmdldFZhcmlhYmxlcwEADjsALwEADjsOOwAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAA87AC4ARA87AACWAgAAAAEAKgEBJQAAABQAAABDb25maWd1cmF0aW9uVmVyc2lvbgEAATn/////AAAAAAABACoBASIAAAAPAAAAVGFyZ2V0c1RvUmVtb3ZlAAcBAAAAAQAAAAAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAXYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEAEDsALgBEEDsAAJYBAAAAAQAqAQEgAAAADQAAAFJlbW92ZVJlc3VsdHMAEwEAAAABAAAAAAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_targetVariables != null)
		{
			children.Add(m_targetVariables);
		}
		if (m_addTargetVariablesMethod != null)
		{
			children.Add(m_addTargetVariablesMethod);
		}
		if (m_removeTargetVariablesMethod != null)
		{
			children.Add(m_removeTargetVariablesMethod);
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
		case "TargetVariables":
			if (createOrReplace && TargetVariables == null)
			{
				if (replacement == null)
				{
					TargetVariables = new PropertyState<FieldTargetDataType[]>(this);
				}
				else
				{
					TargetVariables = (PropertyState<FieldTargetDataType[]>)replacement;
				}
			}
			baseInstanceState = TargetVariables;
			break;
		case "AddTargetVariables":
			if (createOrReplace && AddTargetVariables == null)
			{
				if (replacement == null)
				{
					AddTargetVariables = new TargetVariablesTypeAddTargetVariablesMethodState(this);
				}
				else
				{
					AddTargetVariables = (TargetVariablesTypeAddTargetVariablesMethodState)replacement;
				}
			}
			baseInstanceState = AddTargetVariables;
			break;
		case "RemoveTargetVariables":
			if (createOrReplace && RemoveTargetVariables == null)
			{
				if (replacement == null)
				{
					RemoveTargetVariables = new TargetVariablesTypeRemoveTargetVariablesMethodState(this);
				}
				else
				{
					RemoveTargetVariables = (TargetVariablesTypeRemoveTargetVariablesMethodState)replacement;
				}
			}
			baseInstanceState = RemoveTargetVariables;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
