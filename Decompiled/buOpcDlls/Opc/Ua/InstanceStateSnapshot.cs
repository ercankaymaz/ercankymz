using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class InstanceStateSnapshot : IFilterTarget
{
	private class ChildNode
	{
		public NodeClass NodeClass;

		public QualifiedName BrowseName;

		public object Value;

		public List<ChildNode> Children;
	}

	private NodeId m_typeDefinitionId;

	private ChildNode m_snapshot;

	private object m_handle;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public void Initialize(ISystemContext context, BaseInstanceState state)
	{
		m_typeDefinitionId = state.TypeDefinitionId;
		m_snapshot = CreateChildNode(context, state);
		m_handle = state;
	}

	public void SetChildValue(QualifiedName browseName, NodeClass nodeClass, object value)
	{
		SetChildValue(m_snapshot, browseName, nodeClass, value);
	}

	public bool IsTypeOf(FilterContext context, NodeId typeDefinitionId)
	{
		if (!NodeId.IsNull(typeDefinitionId) && !context.TypeTree.IsTypeOf(m_typeDefinitionId, typeDefinitionId))
		{
			return false;
		}
		return true;
	}

	public object GetAttributeValue(FilterContext context, NodeId typeDefinitionId, IList<QualifiedName> relativePath, uint attributeId, NumericRange indexRange)
	{
		if (!NodeId.IsNull(typeDefinitionId) && !context.TypeTree.IsTypeOf(m_typeDefinitionId, typeDefinitionId))
		{
			return null;
		}
		object value = GetAttributeValue(m_snapshot, relativePath, 0, attributeId);
		if (indexRange != NumericRange.Empty && StatusCode.IsBad(indexRange.ApplyRange(ref value)))
		{
			value = null;
		}
		return value;
	}

	private void SetChildValue(ChildNode node, QualifiedName browseName, NodeClass nodeClass, object value)
	{
		ChildNode childNode = null;
		if (node.Children != null)
		{
			for (int i = 0; i < node.Children.Count; i++)
			{
				childNode = node.Children[i];
				if (childNode.BrowseName == browseName)
				{
					break;
				}
				childNode = null;
			}
		}
		else
		{
			node.Children = new List<ChildNode>();
		}
		if (childNode == null)
		{
			childNode = new ChildNode();
			node.Children.Add(childNode);
		}
		childNode.BrowseName = browseName;
		childNode.NodeClass = nodeClass;
		childNode.Value = value;
	}

	private ChildNode CreateChildNode(ISystemContext context, BaseInstanceState state)
	{
		ChildNode childNode = new ChildNode();
		childNode.NodeClass = state.NodeClass;
		childNode.BrowseName = state.BrowseName;
		if (state is BaseVariableState baseVariableState && !StatusCode.IsBad(baseVariableState.StatusCode))
		{
			childNode.Value = Utils.Clone(baseVariableState.Value);
		}
		if (state is BaseObjectState baseObjectState)
		{
			childNode.Value = baseObjectState.NodeId;
		}
		childNode.Children = CreateChildNodes(context, state);
		return childNode;
	}

	private List<ChildNode> CreateChildNodes(ISystemContext context, BaseInstanceState state)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		state.GetChildren(context, list);
		List<ChildNode> list2 = new List<ChildNode>();
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			if (baseInstanceState != null && (baseInstanceState.NodeClass == NodeClass.Object || baseInstanceState.NodeClass == NodeClass.Variable))
			{
				ChildNode item = CreateChildNode(context, baseInstanceState);
				list2.Add(item);
			}
		}
		return list2;
	}

	private object GetAttributeValue(ChildNode node, IList<QualifiedName> relativePath, int index, uint attributeId)
	{
		if (index >= relativePath.Count)
		{
			if (attributeId == 1)
			{
				return node.Value;
			}
			if (node.NodeClass == NodeClass.Variable && attributeId == 13)
			{
				return node.Value;
			}
			return attributeId switch
			{
				2u => node.NodeClass, 
				3u => node.BrowseName, 
				_ => null, 
			};
		}
		for (int i = 0; i < node.Children.Count; i++)
		{
			if (node.Children[i].BrowseName == relativePath[index])
			{
				return GetAttributeValue(node.Children[i], relativePath, index + 1, attributeId);
			}
		}
		return null;
	}
}
