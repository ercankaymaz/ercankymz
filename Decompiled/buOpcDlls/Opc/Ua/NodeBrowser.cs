using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeBrowser : INodeBrowser, IDisposable
{
	private readonly object m_lock = new object();

	private ISystemContext m_context;

	private ViewDescription m_view;

	private NodeId m_referenceType;

	private bool m_includeSubtypes;

	private BrowseDirection m_browseDirection;

	private IReference m_pushBack;

	private List<IReference> m_references;

	private QualifiedName m_browseName;

	private bool m_internalOnly;

	private int m_index;

	protected object DataLock => m_lock;

	public ISystemContext SystemContext => m_context;

	public ViewDescription View => m_view;

	public NodeId ReferenceType => m_referenceType;

	public bool IncludeSubtypes => m_includeSubtypes;

	public BrowseDirection BrowseDirection => m_browseDirection;

	public QualifiedName BrowseName => m_browseName;

	public bool InternalOnly => m_internalOnly;

	public NodeBrowser(ISystemContext context, ViewDescription view, NodeId referenceType, bool includeSubtypes, BrowseDirection browseDirection, QualifiedName browseName, IEnumerable<IReference> additionalReferences, bool internalOnly)
	{
		m_context = context;
		m_view = view;
		m_referenceType = referenceType;
		m_includeSubtypes = includeSubtypes;
		m_browseDirection = browseDirection;
		m_browseName = browseName;
		m_internalOnly = internalOnly;
		m_references = new List<IReference>();
		m_index = 0;
		if (additionalReferences == null)
		{
			return;
		}
		foreach (IReference additionalReference in additionalReferences)
		{
			if (IsRequired(additionalReference.ReferenceTypeId, additionalReference.IsInverse))
			{
				m_references.Add(additionalReference);
			}
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public virtual IReference Next()
	{
		lock (DataLock)
		{
			if (m_pushBack != null)
			{
				IReference pushBack = m_pushBack;
				m_pushBack = null;
				return pushBack;
			}
			if (m_index < m_references.Count)
			{
				return m_references[m_index++];
			}
			return null;
		}
	}

	public virtual void Push(IReference reference)
	{
		lock (DataLock)
		{
			m_pushBack = reference;
		}
	}

	public virtual bool IsRequired(NodeState target)
	{
		return true;
	}

	public virtual bool IsRequired(NodeId referenceType, bool isInverse)
	{
		if (NodeId.IsNull(referenceType))
		{
			return false;
		}
		if (isInverse)
		{
			if (m_browseDirection == BrowseDirection.Forward)
			{
				return false;
			}
		}
		else if (m_browseDirection == BrowseDirection.Inverse)
		{
			return false;
		}
		if (NodeId.IsNull(m_referenceType) || referenceType == m_referenceType)
		{
			return true;
		}
		if (m_includeSubtypes && m_context != null && m_context.TypeTable.IsTypeOf(referenceType, m_referenceType))
		{
			return true;
		}
		return false;
	}

	public virtual void Add(IReference reference)
	{
		lock (DataLock)
		{
			m_references.Add(reference);
		}
	}

	public virtual void Add(NodeId referenceTypeId, bool isInverse, NodeState target)
	{
		lock (DataLock)
		{
			if (QualifiedName.IsNull(m_browseName) || !(target.BrowseName != m_browseName))
			{
				m_references.Add(new NodeStateReference(referenceTypeId, isInverse, target));
			}
		}
	}

	public virtual void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		lock (DataLock)
		{
			m_references.Add(new NodeStateReference(referenceTypeId, isInverse, targetId));
		}
	}
}
