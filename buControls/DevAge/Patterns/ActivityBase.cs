// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.ActivityBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Threading;

#nullable disable
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
  private ManualResetEvent manualResetEvent_0 = new ManualResetEvent(true);

  public ActivityBase()
  {
    ++ActivityBase.int_1;
    this.Name = "Activity " + ActivityBase.int_1.ToString();
    this.activityCollection_0 = new ActivityCollection((IActivity) this);
  }

  public int SubActivitiesTimeOut
  {
    get => this.int_0;
    set => this.int_0 = value;
  }

  public bool PropagateException
  {
    get => this.bool_1;
    set => this.bool_1 = value;
  }

  public SubActivityWaitMode SubActivityWaitMode
  {
    get => this.subActivityWaitMode_0;
    set => this.subActivityWaitMode_0 = value;
  }

  protected virtual void ResetRunningStatus()
  {
    if (this.activityStatus_0 == ActivityStatus.Running)
      throw new ActivityStatusNotValidException();
    this.bool_0 = false;
    this.activityStatus_0 = ActivityStatus.Pending;
    this.exception_0 = (Exception) null;
    this.manualResetEvent_0.Set();
  }

  protected abstract void OnWork();

  protected void DoWork()
  {
    bool flag = false;
    try
    {
      this.OnWork();
      for (int index = 0; index < this.SubActivities.Count; ++index)
      {
        if (this.bool_0)
          throw new ActivityCanceledException();
        this.SubActivities[index].Start(this.iactivityEvents_0);
        if (this.SubActivityWaitMode == SubActivityWaitMode.WaitOnEach)
        {
          ActivityBase.WaitActivity(this.SubActivities[index], this.SubActivitiesTimeOut);
          ActivityBase.CheckActivityException(this.SubActivities[index]);
        }
      }
      if (this.SubActivityWaitMode == SubActivityWaitMode.WaitAtTheEnd)
      {
        ActivityBase.WaitActivities(this.SubActivities, this.SubActivitiesTimeOut);
        if (this.PropagateException)
          ActivityBase.CheckActivitiesException(this.SubActivities);
      }
      flag = true;
    }
    catch (Exception ex)
    {
      this.OnException(ex);
    }
    if (!flag)
      return;
    this.OnCompleted();
  }

  public static void WaitActivities(ActivityCollection activities, int timeout)
  {
    for (int index = 0; index < activities.Count; ++index)
      ActivityBase.WaitActivity(activities[index], timeout);
  }

  public static void WaitActivity(IActivity activity, int timeout)
  {
    if (activity.Status == ActivityStatus.Pending)
      throw new DevAgeApplicationException("Activity not started");
    if (activity.Status == ActivityStatus.Running && !activity.WaitHandle.WaitOne(timeout, false))
      throw new TimeOutActivityException();
  }

  public static void CheckActivitiesException(ActivityCollection activities)
  {
    for (int index = 0; index < activities.Count; ++index)
      ActivityBase.CheckActivityException(activities[index]);
  }

  public static void CheckActivityException(IActivity activity)
  {
    if (activity.Status == ActivityStatus.Exception)
      throw new SubActivityException(activity.Name, activity.Exception);
  }

  protected virtual void StartActivity() => this.DoWork();

  protected virtual void OnStarted()
  {
    this.manualResetEvent_0.Reset();
    this.activityStatus_0 = ActivityStatus.Running;
    if (this.iactivityEvents_0 == null)
      return;
    this.iactivityEvents_0.ActivityStarted((IActivity) this);
  }

  protected virtual void OnCompleted()
  {
    this.activityStatus_0 = ActivityStatus.Completed;
    this.manualResetEvent_0.Set();
    if (this.iactivityEvents_0 == null)
      return;
    this.iactivityEvents_0.ActivityCompleted((IActivity) this);
  }

  protected virtual void OnException(Exception e)
  {
    this.activityStatus_0 = ActivityStatus.Exception;
    this.exception_0 = e;
    this.manualResetEvent_0.Set();
    if (this.iactivityEvents_0 == null)
      return;
    this.iactivityEvents_0.ActivityException((IActivity) this, e);
  }

  public void Start(IActivityEvents events)
  {
    this.ResetRunningStatus();
    if (this.activityStatus_0 != 0)
      throw new ActivityStatusNotValidException();
    this.iactivityEvents_0 = events;
    try
    {
      this.OnStarted();
      this.StartActivity();
    }
    catch (Exception ex)
    {
      this.OnException(ex);
    }
  }

  public void Cancel() => this.bool_0 = true;

  public ActivityCollection SubActivities => this.activityCollection_0;

  public ActivityStatus Status => this.activityStatus_0;

  public string Name
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  public virtual WaitHandle WaitHandle => (WaitHandle) this.manualResetEvent_0;

  public Exception Exception => this.exception_0;

  public IActivity Parent
  {
    get => this.iactivity_0;
    set
    {
      this.iactivity_0 = (this.iactivity_0 == null ? 0 : (value != null ? 1 : 0)) == 0 ? value : throw new DevAgeApplicationException("Activity already has a parent");
    }
  }

  public string FullName => this.Parent != null ? $"{this.Parent.Name}\\{this.Name}" : this.Name;
}
