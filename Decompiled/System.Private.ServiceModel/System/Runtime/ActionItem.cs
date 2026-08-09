using System.Diagnostics;
using System.Runtime.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace System.Runtime;

internal abstract class ActionItem
{
	internal static class CallbackHelper
	{
		private static Action<object> s_invokeCallback;

		private static Func<object, Task> s_invokeAsyncCallback;

		public static Action<object> InvokeCallbackAction
		{
			get
			{
				if (s_invokeCallback == null)
				{
					s_invokeCallback = InvokeCallback;
				}
				return s_invokeCallback;
			}
		}

		public static Func<object, Task> InvokeAsyncCallbackFunc
		{
			get
			{
				if (s_invokeAsyncCallback == null)
				{
					s_invokeAsyncCallback = InvokeAsyncCallback;
				}
				return s_invokeAsyncCallback;
			}
		}

		private static void InvokeCallback(object state)
		{
			((ActionItem)state).Invoke();
			((ActionItem)state)._isScheduled = false;
		}

		private static async Task InvokeAsyncCallback(object state)
		{
			await ((ActionItem)state).InvokeAsync();
			((ActionItem)state)._isScheduled = false;
		}
	}

	internal class DefaultActionItem : ActionItem
	{
		private Action<object> _callback;

		private object _state;

		private bool _flowLegacyActivityId;

		private Guid _activityId;

		private EventTraceActivity _eventTraceActivity;

		private Func<object, Task> _asyncCallback;

		public DefaultActionItem(Action<object> callback, object state)
		{
			_callback = callback;
			_state = state;
			if (WaitCallbackActionItem.ShouldUseActivity)
			{
				_flowLegacyActivityId = true;
				_activityId = DiagnosticTraceBase.ActivityId;
			}
			if (Fx.Trace.IsEnd2EndActivityTracingEnabled)
			{
				_eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
				if (TraceCore.ActionItemScheduledIsEnabled(Fx.Trace))
				{
					TraceCore.ActionItemScheduled(Fx.Trace, _eventTraceActivity);
				}
			}
		}

		public DefaultActionItem(Func<object, Task> callback, object state)
		{
			_asyncCallback = callback;
			_state = state;
			if (WaitCallbackActionItem.ShouldUseActivity)
			{
				_flowLegacyActivityId = true;
				_activityId = DiagnosticTraceBase.ActivityId;
			}
			if (Fx.Trace.IsEnd2EndActivityTracingEnabled)
			{
				_eventTraceActivity = EventTraceActivity.GetFromThreadOrCreate();
				if (TraceCore.ActionItemScheduledIsEnabled(Fx.Trace))
				{
					TraceCore.ActionItemScheduled(Fx.Trace, _eventTraceActivity);
				}
			}
		}

		protected override void Invoke()
		{
			if (_flowLegacyActivityId || Fx.Trace.IsEnd2EndActivityTracingEnabled)
			{
				TraceAndInvoke();
			}
			else
			{
				_callback(_state);
			}
		}

		protected override Task InvokeAsync()
		{
			if (_flowLegacyActivityId || Fx.Trace.IsEnd2EndActivityTracingEnabled)
			{
				return TraceAndInvokeAsync();
			}
			return _asyncCallback(_state);
		}

		private void TraceAndInvoke()
		{
			if (_flowLegacyActivityId)
			{
				Guid activityId = DiagnosticTraceBase.ActivityId;
				try
				{
					DiagnosticTraceBase.ActivityId = _activityId;
					_callback(_state);
					return;
				}
				finally
				{
					DiagnosticTraceBase.ActivityId = activityId;
				}
			}
			Guid activityId2 = Guid.Empty;
			bool flag = false;
			try
			{
				if (_eventTraceActivity != null)
				{
					activityId2 = Trace.CorrelationManager.ActivityId;
					flag = true;
					Trace.CorrelationManager.ActivityId = _eventTraceActivity.ActivityId;
					if (TraceCore.ActionItemCallbackInvokedIsEnabled(Fx.Trace))
					{
						TraceCore.ActionItemCallbackInvoked(Fx.Trace, _eventTraceActivity);
					}
				}
				_callback(_state);
			}
			finally
			{
				if (flag)
				{
					Trace.CorrelationManager.ActivityId = activityId2;
				}
			}
		}

		private async Task TraceAndInvokeAsync()
		{
			Guid currentActivityId;
			if (_flowLegacyActivityId)
			{
				currentActivityId = DiagnosticTraceBase.ActivityId;
				try
				{
					DiagnosticTraceBase.ActivityId = _activityId;
					await _asyncCallback(_state);
				}
				finally
				{
					DiagnosticTraceBase.ActivityId = currentActivityId;
				}
				return;
			}
			currentActivityId = Guid.Empty;
			bool restoreActivityId = false;
			try
			{
				if (_eventTraceActivity != null)
				{
					currentActivityId = Trace.CorrelationManager.ActivityId;
					restoreActivityId = true;
					Trace.CorrelationManager.ActivityId = _eventTraceActivity.ActivityId;
					if (TraceCore.ActionItemCallbackInvokedIsEnabled(Fx.Trace))
					{
						TraceCore.ActionItemCallbackInvoked(Fx.Trace, _eventTraceActivity);
					}
				}
				await _asyncCallback(_state);
			}
			finally
			{
				if (restoreActivityId)
				{
					Trace.CorrelationManager.ActivityId = currentActivityId;
				}
			}
		}
	}

	private bool _isScheduled;

	public static void Schedule(Action<object> callback, object state)
	{
		if (WaitCallbackActionItem.ShouldUseActivity || Fx.Trace.IsEnd2EndActivityTracingEnabled)
		{
			new DefaultActionItem(callback, state).Schedule();
		}
		else
		{
			ScheduleCallback(callback, state);
		}
	}

	public static void Schedule(Func<object, Task> callback, object state)
	{
		if (WaitCallbackActionItem.ShouldUseActivity || Fx.Trace.IsEnd2EndActivityTracingEnabled)
		{
			new DefaultActionItem(callback, state).ScheduleAsync();
		}
		else
		{
			ScheduleCallback(callback, state);
		}
	}

	protected abstract void Invoke();

	protected abstract Task InvokeAsync();

	protected void Schedule()
	{
		if (_isScheduled)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.ActionItemIsAlreadyScheduled));
		}
		_isScheduled = true;
		ScheduleCallback(CallbackHelper.InvokeCallbackAction);
	}

	protected void ScheduleAsync()
	{
		if (_isScheduled)
		{
			throw Fx.Exception.AsError(new InvalidOperationException(InternalSR.ActionItemIsAlreadyScheduled));
		}
		_isScheduled = true;
		ScheduleCallback(CallbackHelper.InvokeAsyncCallbackFunc);
	}

	private static void ScheduleCallback(Action<object> callback, object state)
	{
		IOThreadScheduler.ScheduleCallbackNoFlow(callback, state);
	}

	private static void ScheduleCallback(Func<object, Task> callback, object state)
	{
		Task<Task>.Factory.StartNew(callback, state, CancellationToken.None, TaskCreationOptions.DenyChildAttach, IOThreadScheduler.IOTaskScheduler);
	}

	private void ScheduleCallback(Action<object> callback)
	{
		ScheduleCallback(callback, this);
	}

	private void ScheduleCallback(Func<object, Task> callback)
	{
		ScheduleCallback(callback, this);
	}
}
