using System.Threading;

namespace System.ServiceModel.Diagnostics;

internal class ServiceModelActivity : IDisposable
{
	private enum ActivityState
	{
		Unknown,
		Start,
		Suspend,
		Resume,
		Stop
	}

	internal class TransferActivity : Activity
	{
		private bool _addTransfer;

		private bool _changeCurrentServiceModelActivity;

		private ServiceModelActivity _previousActivity;

		private TransferActivity(Guid activityId, Guid parentId)
			: base(activityId, parentId)
		{
		}

		internal static TransferActivity CreateActivity(Guid activityId, bool addTransfer)
		{
			if (!DiagnosticUtility.ShouldUseActivity)
			{
				return null;
			}
			return null;
		}

		internal void SetPreviousServiceModelActivity(ServiceModelActivity previous)
		{
			_previousActivity = previous;
			_changeCurrentServiceModelActivity = true;
		}

		public override void Dispose()
		{
			try
			{
				if (!_addTransfer)
				{
					return;
				}
				using (Activity.CreateActivity(base.Id))
				{
					if (FxTrace.Trace != null)
					{
						FxTrace.Trace.TraceTransfer(parentId);
					}
				}
			}
			finally
			{
				if (_changeCurrentServiceModelActivity)
				{
					Current = _previousActivity;
				}
				base.Dispose();
			}
		}
	}

	[ThreadStatic]
	private static ServiceModelActivity s_currentActivity;

	private static string[] s_ActivityTypeNames;

	private static string s_activityBoundaryDescription;

	private bool _autoStop;

	private bool _autoResume;

	private bool _disposed;

	private bool _isAsync;

	private int _stopCount;

	private const int AsyncStopCount = 2;

	private TransferActivity _activity;

	private static string ActivityBoundaryDescription
	{
		get
		{
			if (s_activityBoundaryDescription == null)
			{
				s_activityBoundaryDescription = System.SR.ActivityBoundary;
			}
			return s_activityBoundaryDescription;
		}
	}

	internal ActivityType ActivityType { get; private set; }

	internal ServiceModelActivity PreviousActivity { get; }

	internal static ServiceModelActivity Current
	{
		get
		{
			return s_currentActivity;
		}
		private set
		{
			s_currentActivity = value;
		}
	}

	internal Guid Id { get; }

	private ActivityState LastState { get; set; }

	internal string Name { get; set; }

	static ServiceModelActivity()
	{
		s_ActivityTypeNames = new string[14];
		s_activityBoundaryDescription = null;
		s_ActivityTypeNames[0] = "Unknown";
		s_ActivityTypeNames[1] = "Close";
		s_ActivityTypeNames[2] = "Construct";
		s_ActivityTypeNames[3] = "ExecuteUserCode";
		s_ActivityTypeNames[4] = "ListenAt";
		s_ActivityTypeNames[5] = "Open";
		s_ActivityTypeNames[6] = "Open";
		s_ActivityTypeNames[7] = "ProcessMessage";
		s_ActivityTypeNames[8] = "ProcessAction";
		s_ActivityTypeNames[9] = "ReceiveBytes";
		s_ActivityTypeNames[10] = "SecuritySetup";
		s_ActivityTypeNames[11] = "TransferToComPlus";
		s_ActivityTypeNames[12] = "WmiGetObject";
		s_ActivityTypeNames[13] = "WmiPutInstance";
	}

	private ServiceModelActivity(Guid activityId)
	{
		Id = activityId;
		PreviousActivity = Current;
	}

	internal static Activity BoundOperation(ServiceModelActivity activity)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		return BoundOperation(activity, addTransfer: false);
	}

	internal static Activity BoundOperation(ServiceModelActivity activity, bool addTransfer)
	{
		if (activity != null)
		{
			return BoundOperationCore(activity, addTransfer);
		}
		return null;
	}

	private static Activity BoundOperationCore(ServiceModelActivity activity, bool addTransfer)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		TransferActivity transferActivity = null;
		if (activity != null)
		{
			transferActivity = TransferActivity.CreateActivity(activity.Id, addTransfer);
			transferActivity?.SetPreviousServiceModelActivity(Current);
			Current = activity;
		}
		return transferActivity;
	}

	internal static ServiceModelActivity CreateActivity()
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		return CreateActivity(Guid.NewGuid(), autoStop: true);
	}

	internal static ServiceModelActivity CreateActivity(bool autoStop)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(Guid.NewGuid(), autoStop: true);
		if (serviceModelActivity != null)
		{
			serviceModelActivity._autoStop = autoStop;
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateActivity(bool autoStop, string activityName, ActivityType activityType)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(autoStop);
		Start(serviceModelActivity, activityName, activityType);
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateAsyncActivity()
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(autoStop: true);
		if (serviceModelActivity != null)
		{
			serviceModelActivity._isAsync = true;
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateBoundedActivity()
	{
		return CreateBoundedActivity(suspendCurrent: false);
	}

	internal static ServiceModelActivity CreateBoundedActivity(bool suspendCurrent)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity current = Current;
		ServiceModelActivity serviceModelActivity = CreateActivity(autoStop: true);
		if (serviceModelActivity != null)
		{
			serviceModelActivity._activity = (TransferActivity)BoundOperation(serviceModelActivity, addTransfer: true);
			serviceModelActivity._activity.SetPreviousServiceModelActivity(current);
			if (suspendCurrent)
			{
				serviceModelActivity._autoResume = true;
			}
		}
		if (suspendCurrent)
		{
			current?.Suspend();
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateBoundedActivity(Guid activityId)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(activityId, autoStop: true);
		if (serviceModelActivity != null)
		{
			serviceModelActivity._activity = (TransferActivity)BoundOperation(serviceModelActivity, addTransfer: true);
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateBoundedActivityWithTransferInOnly(Guid activityId)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(activityId, autoStop: true);
		if (serviceModelActivity != null)
		{
			if (FxTrace.Trace != null)
			{
				FxTrace.Trace.TraceTransfer(activityId);
			}
			serviceModelActivity._activity = (TransferActivity)BoundOperation(serviceModelActivity);
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateLightWeightAsyncActivity(Guid activityId)
	{
		return new ServiceModelActivity(activityId);
	}

	internal static ServiceModelActivity CreateActivity(Guid activityId)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = null;
		if (activityId != Guid.Empty)
		{
			serviceModelActivity = new ServiceModelActivity(activityId);
		}
		if (serviceModelActivity != null)
		{
			Current = serviceModelActivity;
		}
		return serviceModelActivity;
	}

	internal static ServiceModelActivity CreateActivity(Guid activityId, bool autoStop)
	{
		if (!DiagnosticUtility.ShouldUseActivity)
		{
			return null;
		}
		ServiceModelActivity serviceModelActivity = CreateActivity(activityId);
		if (serviceModelActivity != null)
		{
			serviceModelActivity._autoStop = autoStop;
		}
		return serviceModelActivity;
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		_disposed = true;
		try
		{
			if (_activity != null)
			{
				_activity.Dispose();
			}
			if (_autoStop)
			{
				Stop();
			}
			if (_autoResume && Current != null)
			{
				Current.Resume();
			}
		}
		finally
		{
			Current = PreviousActivity;
			GC.SuppressFinalize(this);
		}
	}

	internal void Resume()
	{
		if (LastState == ActivityState.Suspend)
		{
			LastState = ActivityState.Resume;
		}
	}

	internal void Resume(string activityName)
	{
		if (string.IsNullOrEmpty(Name))
		{
			Name = activityName;
		}
		Resume();
	}

	internal static void Start(ServiceModelActivity activity, string activityName, ActivityType activityType)
	{
		if (activity != null && activity.LastState == ActivityState.Unknown)
		{
			activity.LastState = ActivityState.Start;
			activity.Name = activityName;
			activity.ActivityType = activityType;
		}
	}

	internal void Stop()
	{
		int num = 0;
		if (_isAsync)
		{
			num = Interlocked.Increment(ref _stopCount);
		}
		if (LastState != ActivityState.Stop && (!_isAsync || (_isAsync && num >= 2)))
		{
			LastState = ActivityState.Stop;
		}
	}

	internal static void Stop(ServiceModelActivity activity)
	{
		activity?.Stop();
	}

	internal void Suspend()
	{
		if (LastState != ActivityState.Stop)
		{
			LastState = ActivityState.Suspend;
		}
	}

	public override string ToString()
	{
		return Id.ToString();
	}
}
