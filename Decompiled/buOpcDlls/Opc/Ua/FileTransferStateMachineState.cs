using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FileTransferStateMachineState : FiniteStateMachineState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAJAAAAEZpbGVUcmFuc2ZlclN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEAuz0BALs9uz0AAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBALw9AC8BAMgKvD0AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQC9PQAuAES9PQAAABH/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOM9AC8BAOM94z0AAAEB/////wAAAAA=";

	private MethodState m_resetMethod;

	public MethodState Reset
	{
		get
		{
			return m_resetMethod;
		}
		set
		{
			if (m_resetMethod != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_resetMethod = value;
		}
	}

	public FileTransferStateMachineState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15803u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJAAAAEZpbGVUcmFuc2ZlclN0YXRlTWFjaGluZVR5cGVJbnN0YW5jZQEAuz0BALs9uz0AAP////8CAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBALw9AC8BAMgKvD0AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQC9PQAuAES9PQAAABH/////AQH/////AAAAAARhggoEAAAAAAAFAAAAUmVzZXQBAOM9AC8BAOM94z0AAAEB/////wAAAAA=");
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
		if (m_resetMethod != null)
		{
			children.Add(m_resetMethod);
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
		if (browseName.Name == "Reset")
		{
			if (createOrReplace && Reset == null)
			{
				if (replacement == null)
				{
					Reset = new MethodState(this);
				}
				else
				{
					Reset = (MethodState)replacement;
				}
			}
			baseInstanceState = Reset;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
