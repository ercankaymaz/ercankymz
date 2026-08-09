using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ExtensionFieldsState : BaseObjectState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGwAAAEV4dGVuc2lvbkZpZWxkc1R5cGVJbnN0YW5jZQEAgTwBAIE8gTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAgzwALwEAgzyDPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQ8AC4ARIQ8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCFPAAuAESFPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQCGPAAvAQCGPIY8AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhzwALgBEhzwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";

	private AddExtensionFieldMethodState m_addExtensionFieldMethod;

	private RemoveExtensionFieldMethodState m_removeExtensionFieldMethod;

	public AddExtensionFieldMethodState AddExtensionField
	{
		get
		{
			return m_addExtensionFieldMethod;
		}
		set
		{
			if (m_addExtensionFieldMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_addExtensionFieldMethod = value;
		}
	}

	public RemoveExtensionFieldMethodState RemoveExtensionField
	{
		get
		{
			return m_removeExtensionFieldMethod;
		}
		set
		{
			if (m_removeExtensionFieldMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_removeExtensionFieldMethod = value;
		}
	}

	public ExtensionFieldsState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15489u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGwAAAEV4dGVuc2lvbkZpZWxkc1R5cGVJbnN0YW5jZQEAgTwBAIE8gTwAAP////8CAAAABGGCCgQAAAAAABEAAABBZGRFeHRlbnNpb25GaWVsZAEAgzwALwEAgzyDPAAAAQH/////AgAAABdgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAIQ8AC4ARIQ8AACWAgAAAAEAKgEBGAAAAAkAAABGaWVsZE5hbWUAFP////8AAAAAAAEAKgEBGQAAAAoAAABGaWVsZFZhbHVlABj+////AAAAAAABACgBAQAAAAEAAAAAAAAAAQH/////AAAAABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQCFPAAuAESFPAAAlgEAAAABACoBARYAAAAHAAAARmllbGRJZAAR/////wAAAAAAAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAEYYIKBAAAAAAAFAAAAFJlbW92ZUV4dGVuc2lvbkZpZWxkAQCGPAAvAQCGPIY8AAABAf////8BAAAAF2CpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEAhzwALgBEhzwAAJYBAAAAAQAqAQEWAAAABwAAAEZpZWxkSWQAEf////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA");
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
		if (m_addExtensionFieldMethod != null)
		{
			children.Add(m_addExtensionFieldMethod);
		}
		if (m_removeExtensionFieldMethod != null)
		{
			children.Add(m_removeExtensionFieldMethod);
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
		string name = browseName.Name;
		if (!(name == "AddExtensionField"))
		{
			if (name == "RemoveExtensionField")
			{
				if (createOrReplace && RemoveExtensionField == null)
				{
					if (replacement == null)
					{
						RemoveExtensionField = new RemoveExtensionFieldMethodState(this);
					}
					else
					{
						RemoveExtensionField = (RemoveExtensionFieldMethodState)replacement;
					}
				}
				baseInstanceState = RemoveExtensionField;
			}
		}
		else
		{
			if (createOrReplace && AddExtensionField == null)
			{
				if (replacement == null)
				{
					AddExtensionField = new AddExtensionFieldMethodState(this);
				}
				else
				{
					AddExtensionField = (AddExtensionFieldMethodState)replacement;
				}
			}
			baseInstanceState = AddExtensionField;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
