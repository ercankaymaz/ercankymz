using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditHistoryAnnotationUpdateEventState : AuditHistoryUpdateEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALQAAAEF1ZGl0SGlzdG9yeUFubm90YXRpb25VcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEAl0oBAJdKl0oAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCYSgAuAESYSgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCZSgAuAESZSgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmkoALgBEmkoAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJtKAC4ARJtKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCcSgAuAEScSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAnUoALgBEnUoAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAn0oALgBEn0oAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCgSgAuAESgSgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQChSgAuAEShSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAKJKAC4ARKJKAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAWUsALgBEWUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAWksALgBEWksAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAW0sALgBEW0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFBhcmFtZXRlckRhdGFUeXBlSWQBAFxLAC4ARFxLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEAXUsALgBEXUsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQBeSwAuAEReSwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBAF9LAC4ARF9LAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=";

	private PropertyState<PerformUpdateType> m_performInsertReplace;

	private PropertyState<DataValue[]> m_newValues;

	private PropertyState<DataValue[]> m_oldValues;

	public PropertyState<PerformUpdateType> PerformInsertReplace
	{
		get
		{
			return m_performInsertReplace;
		}
		set
		{
			if (m_performInsertReplace != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_performInsertReplace = value;
		}
	}

	public PropertyState<DataValue[]> NewValues
	{
		get
		{
			return m_newValues;
		}
		set
		{
			if (m_newValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_newValues = value;
		}
	}

	public PropertyState<DataValue[]> OldValues
	{
		get
		{
			return m_oldValues;
		}
		set
		{
			if (m_oldValues != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_oldValues = value;
		}
	}

	public AuditHistoryAnnotationUpdateEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(19095u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALQAAAEF1ZGl0SGlzdG9yeUFubm90YXRpb25VcGRhdGVFdmVudFR5cGVJbnN0YW5jZQEAl0oBAJdKl0oAAP////8RAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQCYSgAuAESYSgAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQCZSgAuAESZSgAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAmkoALgBEmkoAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAJtKAC4ARJtKAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQCcSgAuAEScSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAnUoALgBEnUoAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAn0oALgBEn0oAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQCgSgAuAESgSgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQChSgAuAEShSgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAKJKAC4ARKJKAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAWUsALgBEWUsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAWksALgBEWksAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAW0sALgBEW0sAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFBhcmFtZXRlckRhdGFUeXBlSWQBAFxLAC4ARFxLAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABQAAABQZXJmb3JtSW5zZXJ0UmVwbGFjZQEAXUsALgBEXUsAAAEAHSz/////AQH/////AAAAABdgiQoCAAAAAAAJAAAATmV3VmFsdWVzAQBeSwAuAEReSwAAABcBAAAAAQAAAAAAAAABAf////8AAAAAF2CJCgIAAAAAAAkAAABPbGRWYWx1ZXMBAF9LAC4ARF9LAAAAFwEAAAABAAAAAAAAAAEB/////wAAAAA=");
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
		if (m_performInsertReplace != null)
		{
			children.Add(m_performInsertReplace);
		}
		if (m_newValues != null)
		{
			children.Add(m_newValues);
		}
		if (m_oldValues != null)
		{
			children.Add(m_oldValues);
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
		case "PerformInsertReplace":
			if (createOrReplace && PerformInsertReplace == null)
			{
				if (replacement == null)
				{
					PerformInsertReplace = new PropertyState<PerformUpdateType>(this);
				}
				else
				{
					PerformInsertReplace = (PropertyState<PerformUpdateType>)replacement;
				}
			}
			baseInstanceState = PerformInsertReplace;
			break;
		case "NewValues":
			if (createOrReplace && NewValues == null)
			{
				if (replacement == null)
				{
					NewValues = new PropertyState<DataValue[]>(this);
				}
				else
				{
					NewValues = (PropertyState<DataValue[]>)replacement;
				}
			}
			baseInstanceState = NewValues;
			break;
		case "OldValues":
			if (createOrReplace && OldValues == null)
			{
				if (replacement == null)
				{
					OldValues = new PropertyState<DataValue[]>(this);
				}
				else
				{
					OldValues = (PropertyState<DataValue[]>)replacement;
				}
			}
			baseInstanceState = OldValues;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
