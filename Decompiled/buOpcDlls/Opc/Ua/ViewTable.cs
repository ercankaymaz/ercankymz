using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class ViewTable
{
	private readonly object m_lock = new object();

	private Dictionary<NodeId, ViewNode> m_views;

	public ViewTable()
	{
		m_views = new Dictionary<NodeId, ViewNode>();
	}

	public bool IsValid(ViewDescription description)
	{
		if (ViewDescription.IsDefault(description))
		{
			return true;
		}
		lock (m_lock)
		{
			return m_views.ContainsKey(description.ViewId);
		}
	}

	public bool IsNodeInView(ViewDescription description, NodeId nodeId)
	{
		if (ViewDescription.IsDefault(description))
		{
			return true;
		}
		lock (m_lock)
		{
			ViewNode value = null;
			if (m_views.TryGetValue(description.ViewId, out value))
			{
				throw new ServiceResultException(2154496000u);
			}
			return false;
		}
	}

	public bool IsReferenceInView(ViewDescription description, ReferenceDescription reference)
	{
		if (ViewDescription.IsDefault(description))
		{
			return true;
		}
		lock (m_lock)
		{
			ViewNode value = null;
			if (m_views.TryGetValue(description.ViewId, out value))
			{
				throw new ServiceResultException(2154496000u);
			}
			return false;
		}
	}

	public void Add(ViewNode view)
	{
		if (view == null)
		{
			throw new ArgumentNullException("view");
		}
		if (NodeId.IsNull(view.NodeId))
		{
			throw new ServiceResultException(2150825984u, Utils.Format("A view may not have a null node id."));
		}
		lock (m_lock)
		{
			if (m_views.ContainsKey(view.NodeId))
			{
				throw new ServiceResultException(2153644032u, Utils.Format("A view with the node id '{0}' already exists.", view.NodeId));
			}
			m_views.Add(view.NodeId, view);
		}
	}

	public void Remove(NodeId viewId)
	{
		if (NodeId.IsNull(viewId))
		{
			throw new ArgumentNullException("viewId");
		}
		lock (m_lock)
		{
			ViewNode value = null;
			if (!m_views.TryGetValue(viewId, out value))
			{
				throw new ServiceResultException(2154496000u, Utils.Format("A reference type with the node id '{0}' does not exist.", viewId));
			}
			m_views.Remove(viewId);
		}
	}
}
