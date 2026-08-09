using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Diagnostics;
using System.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace System.ServiceModel.Diagnostics;

internal static class TraceUtility
{
	internal class TracingAsyncCallbackState
	{
		private Guid _activityId;

		internal object InnerState { get; }

		internal Guid ActivityId => _activityId;

		internal TracingAsyncCallbackState(object innerState)
		{
			InnerState = innerState;
			_activityId = DiagnosticTraceBase.ActivityId;
		}
	}

	internal sealed class ExecuteUserCodeAsync
	{
		private AsyncCallback _callback;

		public AsyncCallback Callback => Fx.ThunkCallback(ExecuteUserCode);

		public ExecuteUserCodeAsync(AsyncCallback callback)
		{
			_callback = callback;
		}

		private void ExecuteUserCode(IAsyncResult result)
		{
			using ServiceModelActivity activity = ServiceModelActivity.CreateBoundedActivity();
			ServiceModelActivity.Start(activity, System.SR.ActivityCallback, ActivityType.ExecuteUserCode);
			_callback(result);
		}
	}

	internal class EventTraceActivityTimeProperty
	{
		private EventTraceActivity _eventTraceActivity;

		internal long StartTime { get; }

		internal EventTraceActivity EventTraceActivity => _eventTraceActivity;

		public EventTraceActivityTimeProperty(EventTraceActivity eventTraceActivity, long startTime)
		{
			_eventTraceActivity = eventTraceActivity;
			StartTime = startTime;
		}
	}

	private const string ActivityIdKey = "ActivityId";

	private const string AsyncOperationActivityKey = "AsyncOperationActivity";

	private const string AsyncOperationStartTimeKey = "AsyncOperationStartTime";

	private static long s_messageNumber;

	public const string E2EActivityId = "E2EActivityId";

	public const string TraceApplicationReference = "TraceApplicationReference";

	public static Func<Action<AsyncCallback, IAsyncResult>> asyncCallbackGenerator;

	public static bool PropagateUserActivity
	{
		get
		{
			if (ShouldPropagateActivity)
			{
				return PropagateUserActivityCore;
			}
			return false;
		}
	}

	private static bool PropagateUserActivityCore
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return false;
		}
	}

	internal static bool ShouldPropagateActivity => false;

	internal static bool ShouldPropagateActivityGlobal => false;

	internal static bool ActivityTracing => false;

	internal static bool MessageFlowTracing => false;

	internal static bool MessageFlowTracingOnly => false;

	internal static void AddActivityHeader(Message message)
	{
		try
		{
			ActivityIdHeader activityIdHeader = new ActivityIdHeader(ExtractActivityId(message));
			activityIdHeader.AddTo(message);
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
	}

	internal static void AddAmbientActivityToMessage(Message message)
	{
		try
		{
			ActivityIdHeader activityIdHeader = new ActivityIdHeader(DiagnosticTraceBase.ActivityId);
			activityIdHeader.AddTo(message);
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
	}

	internal static void CopyActivity(Message source, Message destination)
	{
		if (DiagnosticUtility.ShouldUseActivity)
		{
			SetActivity(destination, ExtractActivity(source));
		}
	}

	internal static long GetUtcBasedDurationForTrace(long startTicks)
	{
		if (startTicks > 0)
		{
			TimeSpan timeSpan = new TimeSpan(DateTime.UtcNow.Ticks - startTicks);
			return (long)timeSpan.TotalMilliseconds;
		}
		return 0L;
	}

	internal static ServiceModelActivity ExtractActivity(Message message)
	{
		ServiceModelActivity result = null;
		if ((DiagnosticUtility.ShouldUseActivity || ShouldPropagateActivityGlobal) && message != null && message.State != MessageState.Closed && message.Properties.TryGetValue("ActivityId", out var value))
		{
			result = value as ServiceModelActivity;
		}
		return result;
	}

	internal static Guid ExtractActivityId(Message message)
	{
		if (MessageFlowTracingOnly)
		{
			return ActivityIdHeader.ExtractActivityId(message);
		}
		return ExtractActivity(message)?.Id ?? Guid.Empty;
	}

	internal static Guid GetReceivedActivityId(OperationContext operationContext)
	{
		if (!operationContext.IncomingMessageProperties.TryGetValue("E2EActivityId", out var value))
		{
			return ExtractActivityId(operationContext.IncomingMessage);
		}
		return (Guid)value;
	}

	internal static ServiceModelActivity ExtractAndRemoveActivity(Message message)
	{
		ServiceModelActivity serviceModelActivity = ExtractActivity(message);
		if (serviceModelActivity != null)
		{
			message.Properties["ActivityId"] = false;
		}
		return serviceModelActivity;
	}

	internal static void ProcessIncomingMessage(Message message, EventTraceActivity eventTraceActivity)
	{
		ServiceModelActivity current = ServiceModelActivity.Current;
		if (current != null && DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity serviceModelActivity = ExtractActivity(message);
			if (serviceModelActivity != null && serviceModelActivity.Id != current.Id)
			{
				using (ServiceModelActivity.BoundOperation(serviceModelActivity))
				{
					if (FxTrace.Trace != null)
					{
						FxTrace.Trace.TraceTransfer(current.Id);
					}
				}
			}
			SetActivity(message, current);
		}
		MessageFlowAtMessageReceived(message, null, eventTraceActivity, createNewActivityId: true);
		if (MessageLogger.LogMessagesAtServiceLevel)
		{
			MessageLogger.LogMessage(ref message, MessageLoggingSource.ServiceLevelReceiveReply | MessageLoggingSource.LastChance);
		}
	}

	internal static void ProcessOutgoingMessage(Message message, EventTraceActivity eventTraceActivity)
	{
		ServiceModelActivity current = ServiceModelActivity.Current;
		if (DiagnosticUtility.ShouldUseActivity)
		{
			SetActivity(message, current);
		}
		if (PropagateUserActivity || ShouldPropagateActivity)
		{
			AddAmbientActivityToMessage(message);
		}
		MessageFlowAtMessageSent(message, eventTraceActivity);
		if (MessageLogger.LogMessagesAtServiceLevel)
		{
			MessageLogger.LogMessage(ref message, MessageLoggingSource.ServiceLevelSendRequest | MessageLoggingSource.LastChance);
		}
	}

	internal static void SetActivity(Message message, ServiceModelActivity activity)
	{
		if (DiagnosticUtility.ShouldUseActivity && message != null && message.State != MessageState.Closed)
		{
			message.Properties["ActivityId"] = activity;
		}
	}

	internal static void TraceDroppedMessage(Message message, EndpointDispatcher dispatcher)
	{
	}

	private static string GenerateMsdnTraceCode(int traceCode)
	{
		int num = (int)(traceCode & 0xFFFF0000u);
		string text = null;
		switch (num)
		{
		case 65536:
			text = "System.ServiceModel.Administration";
			break;
		case 262144:
			text = "System.ServiceModel.Channels";
			break;
		case 327680:
			text = "System.ServiceModel.ComIntegration";
			break;
		case 131072:
			text = "System.ServiceModel.Diagnostics";
			break;
		case 655360:
			text = "System.ServiceModel.PortSharing";
			break;
		case 458752:
			text = "System.ServiceModel.Security";
			break;
		case 196608:
			text = "System.Runtime.Serialization";
			break;
		case 524288:
		case 917504:
			text = "System.ServiceModel";
			break;
		default:
			text = string.Empty;
			break;
		}
		return string.Empty;
	}

	internal static Exception ThrowHelperError(Exception exception, Message message)
	{
		DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception);
		return exception;
	}

	internal static Exception ThrowHelperError(Exception exception, Guid activityId, object source)
	{
		return exception;
	}

	internal static Exception ThrowHelperWarning(Exception exception, Message message)
	{
		return exception;
	}

	internal static ArgumentException ThrowHelperArgument(string paramName, string message, Message msg)
	{
		return (ArgumentException)ThrowHelperError(new ArgumentException(message, paramName), msg);
	}

	internal static ArgumentNullException ThrowHelperArgumentNull(string paramName, Message message)
	{
		return (ArgumentNullException)ThrowHelperError(new ArgumentNullException(paramName), message);
	}

	internal static string CreateSourceString(object source)
	{
		return source.GetType().ToString() + "/" + source.GetHashCode().ToString(CultureInfo.CurrentCulture);
	}

	internal static void TraceHttpConnectionInformation(string localEndpoint, string remoteEndpoint, object source)
	{
	}

	internal static void TraceUserCodeException(Exception e, MethodInfo method)
	{
	}

	static TraceUtility()
	{
		SetEtwProviderId();
		SetEndToEndTracingFlags();
	}

	[SecuritySafeCritical]
	private static void SetEndToEndTracingFlags()
	{
	}

	public static long RetrieveMessageNumber()
	{
		return Interlocked.Increment(ref s_messageNumber);
	}

	internal static string GetCallerInfo(OperationContext context)
	{
		return "null";
	}

	[SecuritySafeCritical]
	internal static void SetEtwProviderId()
	{
	}

	internal static void SetActivityId(MessageProperties properties)
	{
		if (properties != null && properties.TryGetValue("E2EActivityId", out Guid property))
		{
			DiagnosticTraceBase.ActivityId = property;
		}
	}

	internal static void MessageFlowAtMessageSent(Message message, EventTraceActivity eventTraceActivity)
	{
		if (MessageFlowTracing)
		{
			Guid activityId;
			Guid correlationId;
			bool flag = ActivityIdHeader.ExtractActivityAndCorrelationId(message, out activityId, out correlationId);
			if (MessageFlowTracingOnly && flag && activityId != DiagnosticTraceBase.ActivityId)
			{
				DiagnosticTraceBase.ActivityId = activityId;
			}
			if (WcfEventSource.Instance.MessageSentToTransportIsEnabled())
			{
				WcfEventSource.Instance.MessageSentToTransport(eventTraceActivity, correlationId);
			}
		}
	}

	internal static void MessageFlowAtMessageReceived(Message message, OperationContext context, EventTraceActivity eventTraceActivity, bool createNewActivityId)
	{
		if (!MessageFlowTracing)
		{
			return;
		}
		Guid activityId;
		Guid correlationId;
		bool flag = ActivityIdHeader.ExtractActivityAndCorrelationId(message, out activityId, out correlationId);
		if (MessageFlowTracingOnly)
		{
			if (createNewActivityId)
			{
				if (!flag)
				{
					activityId = Guid.NewGuid();
					flag = true;
				}
				DiagnosticTraceBase.ActivityId = Guid.Empty;
			}
			if (flag)
			{
				FxTrace.Trace.SetAndTraceTransfer(activityId, !createNewActivityId);
			}
		}
		if (WcfEventSource.Instance.MessageReceivedFromTransportIsEnabled())
		{
			if (context == null)
			{
				context = OperationContext.Current;
			}
			WcfEventSource.Instance.MessageReceivedFromTransport(eventTraceActivity, correlationId, GetAnnotation(context));
		}
	}

	internal static string GetAnnotation(OperationContext context)
	{
		return string.Empty;
	}

	internal static void TransferFromTransport(Message message)
	{
		if (message == null || !DiagnosticUtility.ShouldUseActivity)
		{
			return;
		}
		Guid guid = Guid.Empty;
		if (ShouldPropagateActivity)
		{
			guid = ActivityIdHeader.ExtractActivityId(message);
		}
		if (guid == Guid.Empty)
		{
			guid = Guid.NewGuid();
		}
		ServiceModelActivity serviceModelActivity = null;
		bool flag = true;
		if (ServiceModelActivity.Current != null)
		{
			if (ServiceModelActivity.Current.Id == guid || ServiceModelActivity.Current.ActivityType == ActivityType.ProcessAction)
			{
				serviceModelActivity = ServiceModelActivity.Current;
				flag = false;
			}
			else if (ServiceModelActivity.Current.PreviousActivity != null && ServiceModelActivity.Current.PreviousActivity.Id == guid)
			{
				serviceModelActivity = ServiceModelActivity.Current.PreviousActivity;
				flag = false;
			}
		}
		if (serviceModelActivity == null)
		{
			serviceModelActivity = ServiceModelActivity.CreateActivity(guid);
		}
		if (DiagnosticUtility.ShouldUseActivity && flag)
		{
			if (FxTrace.Trace != null)
			{
				FxTrace.Trace.TraceTransfer(guid);
			}
			ServiceModelActivity.Start(serviceModelActivity, System.SR.Format(System.SR.ActivityProcessAction, message.Headers.Action), ActivityType.ProcessAction);
		}
		message.Properties["ActivityId"] = serviceModelActivity;
	}

	internal static void UpdateAsyncOperationContextWithActivity(object activity)
	{
		if (OperationContext.Current != null && activity != null)
		{
			OperationContext.Current.OutgoingMessageProperties["AsyncOperationActivity"] = activity;
		}
	}

	internal static object ExtractAsyncOperationContextActivity()
	{
		object value = null;
		if (OperationContext.Current != null && OperationContext.Current.OutgoingMessageProperties.TryGetValue("AsyncOperationActivity", out value))
		{
			OperationContext.Current.OutgoingMessageProperties.Remove("AsyncOperationActivity");
		}
		return value;
	}

	internal static void UpdateAsyncOperationContextWithStartTime(EventTraceActivity eventTraceActivity, long startTime)
	{
		if (OperationContext.Current != null)
		{
			OperationContext.Current.OutgoingMessageProperties["AsyncOperationStartTime"] = new EventTraceActivityTimeProperty(eventTraceActivity, startTime);
		}
	}

	internal static void ExtractAsyncOperationStartTime(out EventTraceActivity eventTraceActivity, out long startTime)
	{
		EventTraceActivityTimeProperty property = null;
		eventTraceActivity = null;
		startTime = 0L;
		if (OperationContext.Current != null && OperationContext.Current.OutgoingMessageProperties.TryGetValue("AsyncOperationStartTime", out property))
		{
			OperationContext.Current.OutgoingMessageProperties.Remove("AsyncOperationStartTime");
			eventTraceActivity = property.EventTraceActivity;
			startTime = property.StartTime;
		}
	}

	internal static void TraceEvent(TraceEventType severity, int traceCode, string traceDescription, object source)
	{
		TraceEvent(severity, traceCode, traceDescription, null, source, null);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TraceEvent(TraceEventType severity, int traceCode, string traceDescription, TraceRecord extendedData, object source, Exception exception)
	{
		DiagnosticUtility.ShouldTrace(severity);
	}

	internal static AsyncCallback WrapExecuteUserCodeAsyncCallback(AsyncCallback callback)
	{
		if (!DiagnosticUtility.ShouldUseActivity || callback == null)
		{
			return callback;
		}
		return new ExecuteUserCodeAsync(callback).Callback;
	}

	public static InputQueue<T> CreateInputQueue<T>() where T : class
	{
		if (asyncCallbackGenerator == null)
		{
			asyncCallbackGenerator = CallbackGenerator;
		}
		return new InputQueue<T>(asyncCallbackGenerator)
		{
			DisposeItemCallback = delegate(T value)
			{
				if (value is ICommunicationObject)
				{
					((ICommunicationObject)value).Abort();
				}
			}
		};
	}

	internal static Action<AsyncCallback, IAsyncResult> CallbackGenerator()
	{
		if (DiagnosticUtility.ShouldUseActivity)
		{
			ServiceModelActivity callbackActivity = ServiceModelActivity.Current;
			if (callbackActivity != null)
			{
				return delegate(AsyncCallback callback, IAsyncResult result)
				{
					using (ServiceModelActivity.BoundOperation(callbackActivity))
					{
						callback(result);
					}
				};
			}
		}
		return null;
	}
}
