using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateFactory
{
	private NodeIdDictionary<Type> m_types;

	public virtual NodeState CreateInstance(ISystemContext context, NodeState parent, NodeClass nodeClass, QualifiedName browseName, NodeId referenceTypeId, NodeId typeDefinitionId)
	{
		NodeState nodeState = null;
		if (m_types != null && !NodeId.IsNull(typeDefinitionId))
		{
			Type value = null;
			if (m_types.TryGetValue(typeDefinitionId, out value))
			{
				return Activator.CreateInstance(value, parent) as NodeState;
			}
		}
		switch (nodeClass)
		{
		case NodeClass.Variable:
			if (context.TypeTable != null && context.TypeTable.IsTypeOf(referenceTypeId, ReferenceTypeIds.HasProperty))
			{
				return new PropertyState(parent);
			}
			return new BaseDataVariableState(parent);
		case NodeClass.Object:
			return new BaseObjectState(parent);
		case NodeClass.Method:
			return new MethodState(parent);
		case NodeClass.ReferenceType:
			return new ReferenceTypeState();
		case NodeClass.ObjectType:
			return new BaseObjectTypeState();
		case NodeClass.VariableType:
			return new BaseDataVariableTypeState();
		case NodeClass.DataType:
			return new DataTypeState();
		case NodeClass.View:
			return new ViewState();
		default:
			return null;
		}
	}

	public void RegisterType(NodeId typeDefinitionId, Type type)
	{
		if (NodeId.IsNull(typeDefinitionId))
		{
			throw new ArgumentNullException("typeDefinitionId");
		}
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (m_types == null)
		{
			m_types = new NodeIdDictionary<Type>();
		}
		m_types[typeDefinitionId] = type;
	}

	public void UnRegisterType(NodeId typeDefinitionId)
	{
		if (NodeId.IsNull(typeDefinitionId))
		{
			throw new ArgumentNullException("typeDefinitionId");
		}
		if (m_types != null)
		{
			m_types.Remove(typeDefinitionId);
		}
	}
}
