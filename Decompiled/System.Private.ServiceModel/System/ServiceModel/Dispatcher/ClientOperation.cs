using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace System.ServiceModel.Dispatcher;

public sealed class ClientOperation : ClientOperationCompatBase
{
	private bool _serializeRequest;

	private bool _deserializeReply;

	private IClientFaultFormatter _faultFormatter;

	private bool _isInitiating = true;

	private bool _isOneWay;

	private bool _isTerminating;

	private bool _isSessionOpenNotificationEnabled;

	private ClientRuntime _parent;

	private MethodInfo _beginMethod;

	private MethodInfo _endMethod;

	private MethodInfo _syncMethod;

	private MethodInfo _taskMethod;

	private Type _taskTResult;

	public string Action { get; }

	public SynchronizedCollection<FaultContractInfo> FaultContractInfos { get; }

	public MethodInfo BeginMethod
	{
		get
		{
			return _beginMethod;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_beginMethod = value;
			}
		}
	}

	public MethodInfo EndMethod
	{
		get
		{
			return _endMethod;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_endMethod = value;
			}
		}
	}

	public MethodInfo SyncMethod
	{
		get
		{
			return _syncMethod;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_syncMethod = value;
			}
		}
	}

	public IClientMessageFormatter Formatter
	{
		get
		{
			return InternalFormatter;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				InternalFormatter = value;
			}
		}
	}

	internal IClientFaultFormatter FaultFormatter
	{
		get
		{
			if (_faultFormatter == null)
			{
				_faultFormatter = new DataContractSerializerFaultFormatter(FaultContractInfos);
			}
			return _faultFormatter;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_faultFormatter = value;
				IsFaultFormatterSetExplicit = true;
			}
		}
	}

	internal bool IsFaultFormatterSetExplicit { get; private set; }

	internal IClientMessageFormatter InternalFormatter { get; set; }

	public bool IsInitiating
	{
		get
		{
			return _isInitiating;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_isInitiating = value;
			}
		}
	}

	public bool IsOneWay
	{
		get
		{
			return _isOneWay;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_isOneWay = value;
			}
		}
	}

	public bool IsTerminating
	{
		get
		{
			return _isTerminating;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_isTerminating = value;
			}
		}
	}

	public string Name { get; }

	public ICollection<IParameterInspector> ClientParameterInspectors => ParameterInspectors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new SynchronizedCollection<IParameterInspector> ParameterInspectors => parameterInspectors;

	public ClientRuntime Parent => _parent;

	public string ReplyAction { get; }

	public bool SerializeRequest
	{
		get
		{
			return _serializeRequest;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_serializeRequest = value;
			}
		}
	}

	public bool DeserializeReply
	{
		get
		{
			return _deserializeReply;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_deserializeReply = value;
			}
		}
	}

	public MethodInfo TaskMethod
	{
		get
		{
			return _taskMethod;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_taskMethod = value;
			}
		}
	}

	public Type TaskTResult
	{
		get
		{
			return _taskTResult;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_taskTResult = value;
			}
		}
	}

	internal bool IsSessionOpenNotificationEnabled
	{
		get
		{
			return _isSessionOpenNotificationEnabled;
		}
		set
		{
			lock (_parent.ThisLock)
			{
				_parent.InvalidateRuntime();
				_isSessionOpenNotificationEnabled = value;
			}
		}
	}

	public ClientOperation(ClientRuntime parent, string name, string action)
		: this(parent, name, action, null)
	{
	}

	public ClientOperation(ClientRuntime parent, string name, string action, string replyAction)
	{
		_parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		Name = name ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		Action = action;
		ReplyAction = replyAction;
		FaultContractInfos = parent.NewBehaviorCollection<FaultContractInfo>();
		parameterInspectors = parent.NewBehaviorCollection<IParameterInspector>();
	}
}
