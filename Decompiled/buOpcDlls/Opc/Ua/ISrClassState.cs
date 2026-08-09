using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ISrClassState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAFAAAAElTckNsYXNzVHlwZUluc3RhbmNlAQBpXgEAaV5pXgAA/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQBqXgAvAD9qXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAUHJpb3JpdHkBAGteAC8AP2teAAAAA/////8BAf////8AAAAAFWCJCgIAAAAAAAMAAABWaWQBAGxeAC8AP2xeAAAABf////8BAf////8AAAAA";

	private BaseDataVariableState<byte> m_id;

	private BaseDataVariableState<byte> m_priority;

	private BaseDataVariableState<ushort> m_vid;

	public BaseDataVariableState<byte> Id
	{
		get
		{
			return m_id;
		}
		set
		{
			if (m_id != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_id = value;
		}
	}

	public BaseDataVariableState<byte> Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			if (m_priority != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_priority = value;
		}
	}

	public BaseDataVariableState<ushort> Vid
	{
		get
		{
			return m_vid;
		}
		set
		{
			if (m_vid != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_vid = value;
		}
	}

	public ISrClassState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24169u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFAAAAElTckNsYXNzVHlwZUluc3RhbmNlAQBpXgEAaV5pXgAA/////wMAAAAVYIkKAgAAAAAAAgAAAElkAQBqXgAvAD9qXgAAAAP/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAUHJpb3JpdHkBAGteAC8AP2teAAAAA/////8BAf////8AAAAAFWCJCgIAAAAAAAMAAABWaWQBAGxeAC8AP2xeAAAABf////8BAf////8AAAAA");
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
		if (m_id != null)
		{
			children.Add(m_id);
		}
		if (m_priority != null)
		{
			children.Add(m_priority);
		}
		if (m_vid != null)
		{
			children.Add(m_vid);
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
		case "Id":
			if (createOrReplace && Id == null)
			{
				if (replacement == null)
				{
					Id = new BaseDataVariableState<byte>(this);
				}
				else
				{
					Id = (BaseDataVariableState<byte>)replacement;
				}
			}
			baseInstanceState = Id;
			break;
		case "Priority":
			if (createOrReplace && Priority == null)
			{
				if (replacement == null)
				{
					Priority = new BaseDataVariableState<byte>(this);
				}
				else
				{
					Priority = (BaseDataVariableState<byte>)replacement;
				}
			}
			baseInstanceState = Priority;
			break;
		case "Vid":
			if (createOrReplace && Vid == null)
			{
				if (replacement == null)
				{
					Vid = new BaseDataVariableState<ushort>(this);
				}
				else
				{
					Vid = (BaseDataVariableState<ushort>)replacement;
				}
			}
			baseInstanceState = Vid;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
