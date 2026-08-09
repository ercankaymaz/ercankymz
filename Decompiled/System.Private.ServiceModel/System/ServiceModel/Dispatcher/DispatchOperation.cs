using System.Collections.Generic;

namespace System.ServiceModel.Dispatcher;

public sealed class DispatchOperation
{
	private readonly SynchronizedCollection<FaultContractInfo> _faultContractInfos;

	private IDispatchFaultFormatter _faultFormatter;

	private bool _isTerminating;

	private bool _isSessionOpenNotificationEnabled;

	private readonly string _replyAction;

	private bool _deserializeRequest = true;

	private bool _serializeReply = true;

	private bool _autoDisposeParameters = true;

	private bool _isFaultFormatterSetExplicit;

	public bool IsOneWay { get; }

	public string Action { get; }

	public SynchronizedCollection<FaultContractInfo> FaultContractInfos => _faultContractInfos;

	public bool AutoDisposeParameters
	{
		get
		{
			return _autoDisposeParameters;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_autoDisposeParameters = value;
			}
		}
	}

	internal IDispatchMessageFormatter Formatter
	{
		get
		{
			return InternalFormatter;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				InternalFormatter = value;
			}
		}
	}

	internal IDispatchFaultFormatter FaultFormatter
	{
		get
		{
			if (_faultFormatter == null)
			{
				_faultFormatter = new DataContractSerializerFaultFormatter(_faultContractInfos);
			}
			return _faultFormatter;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_faultFormatter = value;
				_isFaultFormatterSetExplicit = true;
			}
		}
	}

	internal bool IsFaultFormatterSetExplicit => _isFaultFormatterSetExplicit;

	internal bool HasNoDisposableParameters { get; set; }

	internal IDispatchMessageFormatter InternalFormatter { get; set; }

	internal IOperationInvoker InternalInvoker { get; set; }

	public IOperationInvoker Invoker
	{
		get
		{
			return InternalInvoker;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				InternalInvoker = value;
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
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_isTerminating = value;
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
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_isSessionOpenNotificationEnabled = value;
			}
		}
	}

	public string Name { get; }

	public SynchronizedCollection<IParameterInspector> ParameterInspectors { get; }

	public DispatchRuntime Parent { get; }

	public string ReplyAction => _replyAction;

	public bool DeserializeRequest
	{
		get
		{
			return _deserializeRequest;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_deserializeRequest = value;
			}
		}
	}

	public bool SerializeReply
	{
		get
		{
			return _serializeReply;
		}
		set
		{
			lock (Parent.ThisLock)
			{
				Parent.InvalidateRuntime();
				_serializeReply = value;
			}
		}
	}

	public DispatchOperation(DispatchRuntime parent, string name, string action)
	{
		Parent = parent ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parent");
		Name = name ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		Action = action;
		_faultContractInfos = parent.NewBehaviorCollection<FaultContractInfo>();
		ParameterInspectors = parent.NewBehaviorCollection<IParameterInspector>();
		IsOneWay = true;
	}

	public DispatchOperation(DispatchRuntime parent, string name, string action, string replyAction)
		: this(parent, name, action)
	{
		_replyAction = replyAction;
		IsOneWay = false;
	}
}
