using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeTsnInterfaceConfigurationTalkerState : IIeeeTsnInterfaceConfigurationState
{
	private const string TimeAwareOffset_InitializationString = "//////////8VYIkKAgAAAAAADwAAAFRpbWVBd2FyZU9mZnNldAEAgl4ALwA/gl4AAAAH/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAMAAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblRhbGtlclR5cGVJbnN0YW5jZQEAf14BAH9ef14AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQCAXgAvAD+AXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAVGltZUF3YXJlT2Zmc2V0AQCCXgAvAD+CXgAAAAf/////AQH/////AAAAAA==";

	private BaseDataVariableState<uint> m_timeAwareOffset;

	public BaseDataVariableState<uint> TimeAwareOffset
	{
		get
		{
			return m_timeAwareOffset;
		}
		set
		{
			if (m_timeAwareOffset != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_timeAwareOffset = value;
		}
	}

	public IIeeeTsnInterfaceConfigurationTalkerState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24191u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAMAAAAElJZWVlVHNuSW50ZXJmYWNlQ29uZmlndXJhdGlvblRhbGtlclR5cGVJbnN0YW5jZQEAf14BAH9ef14AAP////8CAAAAFWCJCgIAAAAAAAoAAABNYWNBZGRyZXNzAQCAXgAvAD+AXgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAVGltZUF3YXJlT2Zmc2V0AQCCXgAvAD+CXgAAAAf/////AQH/////AAAAAA==");
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
		if (TimeAwareOffset != null)
		{
			TimeAwareOffset.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAFRpbWVBd2FyZU9mZnNldAEAgl4ALwA/gl4AAAAH/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_timeAwareOffset != null)
		{
			children.Add(m_timeAwareOffset);
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
		if (browseName.Name == "TimeAwareOffset")
		{
			if (createOrReplace && TimeAwareOffset == null)
			{
				if (replacement == null)
				{
					TimeAwareOffset = new BaseDataVariableState<uint>(this);
				}
				else
				{
					TimeAwareOffset = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = TimeAwareOffset;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
