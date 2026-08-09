using System;
using System.Threading;

namespace DevAge.Patterns;

public abstract class ActivityBase : IActivity
{
	private ActivityCollection activityCollection_0;

	private bool bool_0 = false;

	private ActivityStatus activityStatus_0 = ActivityStatus.Pending;

	private IActivityEvents iactivityEvents_0;

	private string string_0;

	private int int_0 = -1;

	private static int int_1;

	private SubActivityWaitMode subActivityWaitMode_0 = SubActivityWaitMode.WaitOnEach;

	private bool bool_1 = true;

	private Exception exception_0;

	private IActivity iactivity_0;

	private ManualResetEvent manualResetEvent_0 = new ManualResetEvent(initialState: true);

	public int SubActivitiesTimeOut
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public bool PropagateException
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public SubActivityWaitMode SubActivityWaitMode
	{
		get
		{
			return subActivityWaitMode_0;
		}
		set
		{
			subActivityWaitMode_0 = value;
		}
	}

	public ActivityCollection SubActivities => activityCollection_0;

	public ActivityStatus Status => activityStatus_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public virtual WaitHandle WaitHandle => manualResetEvent_0;

	public Exception Exception => exception_0;

	public IActivity Parent
	{
		get
		{
			return iactivity_0;
		}
		set
		{
			if (iactivity_0 != null && value != null)
			{
				throw new DevAgeApplicationException("Activity already has a parent");
			}
			iactivity_0 = value;
		}
	}

	public string FullName
	{
		get
		{
			if (Parent != null)
			{
				return Parent.Name + "\\" + Name;
			}
			return Name;
		}
	}

	public ActivityBase()
	{
		int_1++;
		Name = "Activity " + int_1;
		activityCollection_0 = new ActivityCollection(this);
	}

	protected virtual void ResetRunningStatus()
	{
		if (activityStatus_0 == ActivityStatus.Running)
		{
			throw new ActivityStatusNotValidException();
		}
		bool_0 = false;
		activityStatus_0 = ActivityStatus.Pending;
		exception_0 = null;
		manualResetEvent_0.Set();
	}

	protected abstract void OnWork();

	protected void DoWork()
	{
		bool flag = false;
		try
		{
			OnWork();
			for (int i = 0; i < SubActivities.Count; i++)
			{
				if (!bool_0)
				{
					SubActivities[i].Start(iactivityEvents_0);
					if (SubActivityWaitMode == SubActivityWaitMode.WaitOnEach)
					{
						WaitActivity(SubActivities[i], SubActivitiesTimeOut);
						CheckActivityException(SubActivities[i]);
					}
					continue;
				}
				throw new ActivityCanceledException();
			}
			if (SubActivityWaitMode == SubActivityWaitMode.WaitAtTheEnd)
			{
				WaitActivities(SubActivities, SubActivitiesTimeOut);
				if (PropagateException)
				{
					CheckActivitiesException(SubActivities);
				}
			}
			flag = true;
		}
		catch (Exception e)
		{
			OnException(e);
		}
		if (flag)
		{
			OnCompleted();
		}
	}

	public static void WaitActivities(ActivityCollection activities, int timeout)
	{
		for (int i = 0; i < activities.Count; i++)
		{
			WaitActivity(activities[i], timeout);
		}
	}

	public static void WaitActivity(IActivity activity, int timeout)
	{
		if (activity.Status != ActivityStatus.Pending)
		{
			if (activity.Status == ActivityStatus.Running && !activity.WaitHandle.WaitOne(timeout, exitContext: false))
			{
				throw new TimeOutActivityException();
			}
			return;
		}
		throw new DevAgeApplicationException("Activity not started");
	}

	public static void CheckActivitiesException(ActivityCollection activities)
	{
		for (int i = 0; i < activities.Count; i++)
		{
			CheckActivityException(activities[i]);
		}
	}

	public static void CheckActivityException(IActivity activity)
	{
		if (activity.Status == ActivityStatus.Exception)
		{
			throw new SubActivityException(activity.Name, activity.Exception);
		}
	}

	protected virtual void StartActivity()
	{
		DoWork();
	}

	protected virtual void OnStarted()
	{
		manualResetEvent_0.Reset();
		activityStatus_0 = ActivityStatus.Running;
		if (iactivityEvents_0 != null)
		{
			iactivityEvents_0.ActivityStarted(this);
		}
	}

	protected virtual void OnCompleted()
	{
		activityStatus_0 = ActivityStatus.Completed;
		manualResetEvent_0.Set();
		if (iactivityEvents_0 != null)
		{
			iactivityEvents_0.ActivityCompleted(this);
		}
	}

	protected virtual void OnException(Exception e)
	{
		activityStatus_0 = ActivityStatus.Exception;
		exception_0 = e;
		manualResetEvent_0.Set();
		if (iactivityEvents_0 != null)
		{
			iactivityEvents_0.ActivityException(this, e);
		}
	}

	public void Start(IActivityEvents events)
	{
		ResetRunningStatus();
		if (activityStatus_0 == ActivityStatus.Pending)
		{
			iactivityEvents_0 = events;
			try
			{
				OnStarted();
				StartActivity();
				return;
			}
			catch (Exception e)
			{
				OnException(e);
				return;
			}
		}
		throw new ActivityStatusNotValidException();
	}

	public void Cancel()
	{
		bool_0 = true;
	}
}
