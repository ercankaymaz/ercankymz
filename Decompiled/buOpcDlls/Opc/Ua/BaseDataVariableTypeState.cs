using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class BaseDataVariableTypeState : BaseVariableTypeState
{
	public static NodeState Construct(NodeState parent)
	{
		return new BaseDataVariableTypeState();
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SuperTypeId = NodeId.Create(62u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.NodeId = NodeId.Create(63u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.BrowseName = QualifiedName.Create("BaseDataVariableType", "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.DisplayName = new LocalizedText("BaseDataVariableType", string.Empty, "BaseDataVariableType");
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.IsAbstract = false;
		base.Value = null;
		base.DataType = NodeId.Create(24u, "http://opcfoundation.org/UA/", context.NamespaceUris);
		base.ValueRank = -2;
		base.ArrayDimensions = null;
	}
}
[ComVisible(true)]
public class BaseDataVariableTypeState<T> : BaseDataVariableTypeState
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

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Value = default(T);
		base.DataType = TypeInfo.GetDataTypeId(typeof(T));
		base.ValueRank = TypeInfo.GetValueRank(typeof(T));
	}

	protected override object ExtractValueFromVariant(ISystemContext context, object value, bool throwOnError)
	{
		return BaseVariableState.ExtractValueFromVariant<T>(context, value, throwOnError);
	}
}
