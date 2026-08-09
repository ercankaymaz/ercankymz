using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class SystemContext : ISystemContext, IOperationContext
{
	private object m_systemHandle;

	private NodeId m_sessionId;

	private IList<string> m_preferredLocales;

	private string m_auditEntryId;

	private IUserIdentity m_userIdentity;

	private NamespaceTable m_namespaceUris;

	private StringTable m_serverUris;

	private ITypeTable m_typeTable;

	private IEncodeableFactory m_encodeableFactory;

	private INodeIdFactory m_nodeIdFactory;

	private IOperationContext m_operationContext;

	private NodeStateFactory m_nodeStateFactory;

	public object SystemHandle
	{
		get
		{
			return m_systemHandle;
		}
		set
		{
			m_systemHandle = value;
		}
	}

	public NodeId SessionId
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.SessionId;
			}
			return m_sessionId;
		}
		set
		{
			m_sessionId = value;
		}
	}

	public IUserIdentity UserIdentity
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.UserIdentity;
			}
			return m_userIdentity;
		}
		set
		{
			m_userIdentity = value;
		}
	}

	public IList<string> PreferredLocales
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.PreferredLocales;
			}
			return m_preferredLocales;
		}
		set
		{
			m_preferredLocales = value;
		}
	}

	public string AuditEntryId
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.AuditEntryId;
			}
			return m_auditEntryId;
		}
		set
		{
			m_auditEntryId = value;
		}
	}

	public NamespaceTable NamespaceUris
	{
		get
		{
			return m_namespaceUris;
		}
		set
		{
			m_namespaceUris = value;
		}
	}

	public StringTable ServerUris
	{
		get
		{
			return m_serverUris;
		}
		set
		{
			m_serverUris = value;
		}
	}

	public ITypeTable TypeTable
	{
		get
		{
			return m_typeTable;
		}
		set
		{
			m_typeTable = value;
		}
	}

	public IEncodeableFactory EncodeableFactory
	{
		get
		{
			return m_encodeableFactory;
		}
		set
		{
			m_encodeableFactory = value;
		}
	}

	public NodeStateFactory NodeStateFactory
	{
		get
		{
			return m_nodeStateFactory;
		}
		set
		{
			m_nodeStateFactory = value;
		}
	}

	public INodeIdFactory NodeIdFactory
	{
		get
		{
			return m_nodeIdFactory;
		}
		set
		{
			m_nodeIdFactory = value;
		}
	}

	public IOperationContext OperationContext
	{
		get
		{
			return m_operationContext;
		}
		protected set
		{
			m_operationContext = value;
		}
	}

	public DiagnosticsMasks DiagnosticsMask
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.DiagnosticsMask;
			}
			return DiagnosticsMasks.None;
		}
	}

	public StringTable StringTable
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.StringTable;
			}
			return null;
		}
	}

	public DateTime OperationDeadline
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.OperationDeadline;
			}
			return DateTime.MaxValue;
		}
	}

	public StatusCode OperationStatus
	{
		get
		{
			if (m_operationContext != null)
			{
				return m_operationContext.OperationStatus;
			}
			return 0u;
		}
	}

	public SystemContext()
	{
		m_nodeStateFactory = new NodeStateFactory();
	}

	public SystemContext(IOperationContext context)
	{
		m_nodeStateFactory = new NodeStateFactory();
		m_operationContext = context;
	}

	public ISystemContext Copy(IOperationContext context)
	{
		SystemContext systemContext = (SystemContext)MemberwiseClone();
		if (context != null)
		{
			systemContext.m_operationContext = context;
		}
		return systemContext;
	}
}
