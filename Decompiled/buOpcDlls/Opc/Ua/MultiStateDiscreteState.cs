using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDiscreteState : DiscreteItemState
{
	private const string InitializationString = "//////////8VYIECAgAAAAAAHgAAAE11bHRpU3RhdGVEaXNjcmV0ZVR5cGVJbnN0YW5jZQEASAkBAEgJSAkAAAAcAQH/////AQAAABdgiQoCAAAAAAALAAAARW51bVN0cmluZ3MBAEkJAC4AREkJAAAAFQEAAAABAAAAAAAAAAEB/////wAAAAA=";

	public MultiStateDiscreteState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2376u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(28u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAAHgAAAE11bHRpU3RhdGVEaXNjcmV0ZVR5cGVJbnN0YW5jZQEASAkBAEgJSAkAAAAcAQH/////AQAAABdgiQoCAAAAAAALAAAARW51bVN0cmluZ3MBAEkJAC4AREkJAAAAFQEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
}
[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDiscreteState<T> : MultiStateDiscreteState
{
	public new T Value
	{
		get
		{
			return BaseVariableState.CheckTypeBeforeCast<T>(base.Value, throwOnError: true);
		}
		set
		{
			base.Value = value;
		}
	}

	public MultiStateDiscreteState(NodeState parent)
		: base(parent)
	{
		Value = default(T);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Value = default(T);
		base.DataType = TypeInfo.GetDataTypeId(typeof(T));
		base.ValueRank = TypeInfo.GetValueRank(typeof(T));
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}
}
