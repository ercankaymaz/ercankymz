using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FiniteStateVariableState : StateVariableState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAHwAAAEZpbml0ZVN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMgKAQDICsgKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyQoALgBEyQoAAAAR/////wEB/////wAAAAA=";

	public new PropertyState<NodeId> Id
	{
		get
		{
			return (PropertyState<NodeId>)base.Id;
		}
		set
		{
			base.Id = value;
		}
	}

	public FiniteStateVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2760u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAHwAAAEZpbml0ZVN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMgKAQDICsgKAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEAyQoALgBEyQoAAAAR/////wEB/////wAAAAA=");
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
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		if (browseName.Name == "Id")
		{
			if (createOrReplace && Id == null)
			{
				if (replacement == null)
				{
					Id = new PropertyState<NodeId>(this);
				}
				else
				{
					Id = (PropertyState<NodeId>)replacement;
				}
			}
			baseInstanceState = Id;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
