using System.CodeDom.Compiler;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class MultiStateDictionaryEntryDiscreteState : MultiStateDictionaryEntryDiscreteBaseState
{
	private const string InitializationString = "//////////8VYIECAgAAAAAALQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZVR5cGVJbnN0YW5jZQEAjEoBAIxKjEoAAAAaAQH/////BAAAABdgiQoCAAAAAAAKAAAARW51bVZhbHVlcwEAj0oALgBEj0oAAAEAqh0BAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABWYWx1ZUFzVGV4dAEAkEoALgBEkEoAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAFQAAAEVudW1EaWN0aW9uYXJ5RW50cmllcwEAkUoALgBEkUoAAAARAgAAAAIAAAAAAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAkkoALgBEkkoAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==";

	public MultiStateDictionaryEntryDiscreteState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19084u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(26u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -2;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIECAgAAAAAALQAAAE11bHRpU3RhdGVEaWN0aW9uYXJ5RW50cnlEaXNjcmV0ZVR5cGVJbnN0YW5jZQEAjEoBAIxKjEoAAAAaAQH/////BAAAABdgiQoCAAAAAAAKAAAARW51bVZhbHVlcwEAj0oALgBEj0oAAAEAqh0BAAAAAQAAAAAAAAABAf////8AAAAAFWCJCgIAAAAAAAsAAABWYWx1ZUFzVGV4dAEAkEoALgBEkEoAAAAV/////wEB/////wAAAAAXYIkKAgAAAAAAFQAAAEVudW1EaWN0aW9uYXJ5RW50cmllcwEAkUoALgBEkUoAAAARAgAAAAIAAAAAAAAAAAAAAAEB/////wAAAAAXYIkKAgAAAAAAGAAAAFZhbHVlQXNEaWN0aW9uYXJ5RW50cmllcwEAkkoALgBEkkoAAAARAQAAAAEAAAAAAAAAAQH/////AAAAAA==");
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
public class MultiStateDictionaryEntryDiscreteState<T> : MultiStateDictionaryEntryDiscreteState
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

	public MultiStateDictionaryEntryDiscreteState(NodeState parent)
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
