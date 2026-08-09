using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BaseDataVariableState : BaseVariableState
{
	private PropertyState<LocalizedText[]> m_enumStrings;

	public PropertyState<LocalizedText[]> EnumStrings
	{
		get
		{
			return m_enumStrings;
		}
		set
		{
			if (m_enumStrings != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_enumStrings = value;
		}
	}

	public BaseDataVariableState(NodeState parent)
		: base(parent)
	{
		if (parent != null)
		{
			base.StatusCode = 2150760448u;
			base.ReferenceTypeId = ReferenceTypeIds.HasComponent;
		}
	}

	public static NodeState Construct(NodeState parent)
	{
		return new BaseDataVariableState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.SymbolicName = Utils.Format("{0}_Instance1", "BaseDataVariableType");
		base.NodeId = null;
		base.BrowseName = new QualifiedName(base.SymbolicName, 1);
		base.DisplayName = base.SymbolicName;
		base.Description = null;
		base.WriteMask = AttributeWriteMask.None;
		base.UserWriteMask = AttributeWriteMask.None;
		base.ReferenceTypeId = ReferenceTypeIds.HasComponent;
		base.TypeDefinitionId = GetDefaultTypeDefinitionId(context.NamespaceUris);
		base.NumericId = 63u;
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
		return 63u;
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_enumStrings != null)
		{
			children.Add(m_enumStrings);
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
		if (browseName.Name == "EnumStrings")
		{
			if (createOrReplace && EnumStrings == null)
			{
				if (replacement == null)
				{
					EnumStrings = new PropertyState<LocalizedText[]>(this);
				}
				else
				{
					EnumStrings = (PropertyState<LocalizedText[]>)replacement;
				}
			}
			baseInstanceState = EnumStrings;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BaseDataVariableState<T> : BaseDataVariableState
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

	public BaseDataVariableState(NodeState parent)
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

	[Obsolete("Should use the version that takes a ISystemContext (pass null if ISystemContext is not available).")]
	protected override object ExtractValueFromVariant(object value, bool throwOnError)
	{
		return BaseVariableState.ExtractValueFromVariant<T>(null, value, throwOnError);
	}

	protected override object ExtractValueFromVariant(ISystemContext context, object value, bool throwOnError)
	{
		return BaseVariableState.ExtractValueFromVariant<T>(context, value, throwOnError);
	}
}
