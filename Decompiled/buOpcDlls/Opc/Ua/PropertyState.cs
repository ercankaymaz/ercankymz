using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PropertyState : BaseVariableState
{
	public PropertyState(NodeState parent)
		: base(parent)
	{
		base.StatusCode = 2150760448u;
	}

	public static NodeState Construct(NodeState parent)
	{
		return new PropertyState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SymbolicName = Utils.Format("{0}_Instance1", "PropertyType");
		base.NodeId = null;
		base.BrowseName = new QualifiedName(base.SymbolicName, 1);
		base.DisplayName = base.SymbolicName;
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.ReferenceTypeId = ReferenceTypeIds.HasProperty;
		base.TypeDefinitionId = GetDefaultTypeDefinitionId(context.NamespaceUris);
		base.NumericId = 68u;
		base.Value = null;
		base.DataType = GetDefaultDataTypeId(context.NamespaceUris);
		base.ValueRank = GetDefaultValueRank();
		base.ArrayDimensions = null;
		base.AccessLevel = 3;
		base.UserAccessLevel = 3;
		base.MinimumSamplingInterval = 0.0;
		base.Historizing = false;
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return 68u;
	}
}
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PropertyState<T> : PropertyState
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

	public PropertyState(NodeState parent)
		: base(parent)
	{
		Value = default(T);
		base.IsValueType = !typeof(T).GetTypeInfo().IsValueType;
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
