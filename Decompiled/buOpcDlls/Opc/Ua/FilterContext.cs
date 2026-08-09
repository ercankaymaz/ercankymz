using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class FilterContext : IOperationContext
{
	private NamespaceTable m_namespaceUris;

	private ITypeTable m_typeTree;

	private IOperationContext m_context;

	private IList<string> m_preferredLocales;

	public NamespaceTable NamespaceUris => m_namespaceUris;

	public ITypeTable TypeTree => m_typeTree;

	public NodeId SessionId
	{
		get
		{
			if (m_context != null)
			{
				return m_context.SessionId;
			}
			return null;
		}
	}

	public IUserIdentity UserIdentity
	{
		get
		{
			if (m_context != null)
			{
				return m_context.UserIdentity;
			}
			return null;
		}
	}

	public IList<string> PreferredLocales
	{
		get
		{
			if (m_context != null)
			{
				return m_context.PreferredLocales;
			}
			return m_preferredLocales;
		}
	}

	public DiagnosticsMasks DiagnosticsMask
	{
		get
		{
			if (m_context != null)
			{
				return m_context.DiagnosticsMask;
			}
			return DiagnosticsMasks.SymbolicId;
		}
	}

	public StringTable StringTable
	{
		get
		{
			if (m_context != null)
			{
				return m_context.StringTable;
			}
			return null;
		}
	}

	public DateTime OperationDeadline
	{
		get
		{
			if (m_context != null)
			{
				return m_context.OperationDeadline;
			}
			return DateTime.MaxValue;
		}
	}

	public StatusCode OperationStatus
	{
		get
		{
			if (m_context != null)
			{
				return m_context.OperationStatus;
			}
			return 0u;
		}
	}

	public string AuditEntryId
	{
		get
		{
			if (m_context != null)
			{
				return m_context.AuditEntryId;
			}
			return null;
		}
	}

	public FilterContext(NamespaceTable namespaceUris, ITypeTable typeTree, IOperationContext context)
	{
		if (namespaceUris == null)
		{
			throw new ArgumentNullException("namespaceUris");
		}
		if (typeTree == null)
		{
			throw new ArgumentNullException("typeTree");
		}
		m_namespaceUris = namespaceUris;
		m_typeTree = typeTree;
		m_context = context;
	}

	public FilterContext(NamespaceTable namespaceUris, ITypeTable typeTree)
		: this(namespaceUris, typeTree, (IList<string>)null)
	{
	}

	public FilterContext(NamespaceTable namespaceUris, ITypeTable typeTree, IList<string> preferredLocales)
	{
		if (namespaceUris == null)
		{
			throw new ArgumentNullException("namespaceUris");
		}
		if (typeTree == null)
		{
			throw new ArgumentNullException("typeTree");
		}
		m_namespaceUris = namespaceUris;
		m_typeTree = typeTree;
		m_context = null;
		m_preferredLocales = preferredLocales;
	}
}
