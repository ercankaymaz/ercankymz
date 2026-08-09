using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
[System_002EDiagnostics_002EDiagnosticSource_002ENullable(0)]
[ComVisible(true)]
public sealed class ActivitySource : IDisposable
{
	internal delegate void Function<T, TParent>(T item, ref ActivityCreationOptions<TParent> data, ref ActivitySamplingResult samplingResult, ref ActivityCreationOptions<ActivityContext> dataWithContext);

	private static readonly SynchronizedList<ActivitySource> s_activeSources = new SynchronizedList<ActivitySource>();

	private static readonly SynchronizedList<ActivityListener> s_allListeners = new SynchronizedList<ActivityListener>();

	private SynchronizedList<ActivityListener> _listeners;

	public string Name { get; }

	[System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public string Version
	{
		[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
		get;
	}

	public ActivitySource(string name, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] string version = "")
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		Name = name;
		Version = version;
		s_activeSources.Add(this);
		if (s_allListeners.Count > 0)
		{
			s_allListeners.EnumWithAction(delegate(ActivityListener listener, object source)
			{
				Func<ActivitySource, bool> shouldListenTo = listener.ShouldListenTo;
				if (shouldListenTo != null)
				{
					ActivitySource activitySource = (ActivitySource)source;
					if (shouldListenTo(activitySource))
					{
						activitySource.AddListener(listener);
					}
				}
			}, this);
		}
		GC.KeepAlive(DiagnosticSourceEventSource.Log);
	}

	public bool HasListeners()
	{
		SynchronizedList<ActivityListener> listeners = _listeners;
		if (listeners != null)
		{
			return listeners.Count > 0;
		}
		return false;
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public Activity CreateActivity(string name, ActivityKind kind)
	{
		return CreateActivity(name, kind, default(ActivityContext), null, null, null, default(DateTimeOffset), startIt: false);
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public Activity CreateActivity([System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)] string name, ActivityKind kind, ActivityContext parentContext, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags = null, IEnumerable<ActivityLink> links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
	{
		return CreateActivity(name, kind, parentContext, null, tags, links, default(DateTimeOffset), startIt: false, idFormat);
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public Activity CreateActivity(string name, ActivityKind kind, string parentId, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags = null, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] IEnumerable<ActivityLink> links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
	{
		return CreateActivity(name, kind, default(ActivityContext), parentId, tags, links, default(DateTimeOffset), startIt: false, idFormat);
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public Activity StartActivity([CallerMemberName] string name = "", ActivityKind kind = ActivityKind.Internal)
	{
		return CreateActivity(name, kind, default(ActivityContext), null, null, null, default(DateTimeOffset));
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public Activity StartActivity([System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)] string name, ActivityKind kind, ActivityContext parentContext, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags = null, IEnumerable<ActivityLink> links = null, DateTimeOffset startTime = default(DateTimeOffset))
	{
		return CreateActivity(name, kind, parentContext, null, tags, links, startTime);
	}

	[return: System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)]
	public Activity StartActivity(string name, ActivityKind kind, string parentId, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags = null, [System_002EDiagnostics_002EDiagnosticSource_002ENullable(2)] IEnumerable<ActivityLink> links = null, DateTimeOffset startTime = default(DateTimeOffset))
	{
		return CreateActivity(name, kind, default(ActivityContext), parentId, tags, links, startTime);
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public Activity StartActivity(ActivityKind kind, ActivityContext parentContext = default(ActivityContext), [System_002EDiagnostics_002EDiagnosticSource_002ENullable(new byte[] { 2, 0, 1, 2 })] IEnumerable<KeyValuePair<string, object>> tags = null, IEnumerable<ActivityLink> links = null, DateTimeOffset startTime = default(DateTimeOffset), [System_002EDiagnostics_002EDiagnosticSource_002ENullable(1)][CallerMemberName] string name = "")
	{
		return CreateActivity(name, kind, parentContext, null, tags, links, startTime);
	}

	private Activity CreateActivity(string name, ActivityKind kind, ActivityContext context, string parentId, IEnumerable<KeyValuePair<string, object>> tags, IEnumerable<ActivityLink> links, DateTimeOffset startTime, bool startIt = true, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
	{
		SynchronizedList<ActivityListener> listeners = _listeners;
		if (listeners == null || listeners.Count == 0)
		{
			return null;
		}
		Activity result = null;
		ActivitySamplingResult samplingResult = ActivitySamplingResult.None;
		ActivityTagsCollection activityTagsCollection;
		if (parentId != null)
		{
			ActivityCreationOptions<string> activityCreationOptions = default(ActivityCreationOptions<string>);
			ActivityCreationOptions<ActivityContext> dataWithContext = default(ActivityCreationOptions<ActivityContext>);
			activityCreationOptions = new ActivityCreationOptions<string>(this, name, parentId, kind, tags, links, idFormat);
			if (activityCreationOptions.IdFormat == ActivityIdFormat.W3C)
			{
				dataWithContext = new ActivityCreationOptions<ActivityContext>(this, name, activityCreationOptions.GetContext(), kind, tags, links, ActivityIdFormat.W3C);
			}
			listeners.EnumWithFunc(delegate(ActivityListener listener, ref ActivityCreationOptions<string> reference, ref ActivitySamplingResult reference2, ref ActivityCreationOptions<ActivityContext> options)
			{
				SampleActivity<string> sampleUsingParentId = listener.SampleUsingParentId;
				if (sampleUsingParentId != null)
				{
					ActivitySamplingResult activitySamplingResult = sampleUsingParentId(ref reference);
					if (activitySamplingResult > reference2)
					{
						reference2 = activitySamplingResult;
					}
				}
				else if (reference.IdFormat == ActivityIdFormat.W3C)
				{
					SampleActivity<ActivityContext> sample = listener.Sample;
					if (sample != null)
					{
						ActivitySamplingResult activitySamplingResult2 = sample(ref options);
						if (activitySamplingResult2 > reference2)
						{
							reference2 = activitySamplingResult2;
						}
					}
				}
			}, ref activityCreationOptions, ref samplingResult, ref dataWithContext);
			if (context == default(ActivityContext))
			{
				if (activityCreationOptions.GetContext() != default(ActivityContext))
				{
					context = activityCreationOptions.GetContext();
					parentId = null;
				}
				else if (dataWithContext.GetContext() != default(ActivityContext))
				{
					context = dataWithContext.GetContext();
					parentId = null;
				}
			}
			activityTagsCollection = activityCreationOptions.GetSamplingTags();
			ActivityTagsCollection samplingTags = dataWithContext.GetSamplingTags();
			if (samplingTags != null)
			{
				if (activityTagsCollection == null)
				{
					activityTagsCollection = samplingTags;
				}
				else
				{
					foreach (KeyValuePair<string, object> item in samplingTags)
					{
						activityTagsCollection.Add(item);
					}
				}
			}
			idFormat = activityCreationOptions.IdFormat;
		}
		else
		{
			bool flag = context == default(ActivityContext) && Activity.Current != null;
			ActivityCreationOptions<ActivityContext> data = new ActivityCreationOptions<ActivityContext>(this, name, flag ? Activity.Current.Context : context, kind, tags, links, idFormat);
			listeners.EnumWithFunc(delegate(ActivityListener listener, ref ActivityCreationOptions<ActivityContext> options, ref ActivitySamplingResult reference, ref ActivityCreationOptions<ActivityContext> unused)
			{
				SampleActivity<ActivityContext> sample = listener.Sample;
				if (sample != null)
				{
					ActivitySamplingResult activitySamplingResult = sample(ref options);
					if (activitySamplingResult > reference)
					{
						reference = activitySamplingResult;
					}
				}
			}, ref data, ref samplingResult, ref data);
			if (!flag)
			{
				context = data.GetContext();
			}
			activityTagsCollection = data.GetSamplingTags();
			idFormat = data.IdFormat;
		}
		if (samplingResult != ActivitySamplingResult.None)
		{
			result = Activity.Create(this, name, kind, parentId, context, tags, links, startTime, activityTagsCollection, samplingResult, startIt, idFormat);
		}
		return result;
	}

	public void Dispose()
	{
		_listeners = null;
		s_activeSources.Remove(this);
	}

	public static void AddActivityListener(ActivityListener listener)
	{
		if (listener == null)
		{
			throw new ArgumentNullException("listener");
		}
		if (!s_allListeners.AddIfNotExist(listener))
		{
			return;
		}
		s_activeSources.EnumWithAction(delegate(ActivitySource source, object obj)
		{
			Func<ActivitySource, bool> shouldListenTo = ((ActivityListener)obj).ShouldListenTo;
			if (shouldListenTo != null && shouldListenTo(source))
			{
				source.AddListener((ActivityListener)obj);
			}
		}, listener);
	}

	internal void AddListener(ActivityListener listener)
	{
		if (_listeners == null)
		{
			Interlocked.CompareExchange(ref _listeners, new SynchronizedList<ActivityListener>(), null);
		}
		_listeners.AddIfNotExist(listener);
	}

	internal static void DetachListener(ActivityListener listener)
	{
		s_allListeners.Remove(listener);
		s_activeSources.EnumWithAction(delegate(ActivitySource source, object obj)
		{
			source._listeners?.Remove((ActivityListener)obj);
		}, listener);
	}

	internal void NotifyActivityStart(Activity activity)
	{
		SynchronizedList<ActivityListener> listeners = _listeners;
		if (listeners != null && listeners.Count > 0)
		{
			listeners.EnumWithAction(delegate(ActivityListener listener, object obj)
			{
				listener.ActivityStarted?.Invoke((Activity)obj);
			}, activity);
		}
	}

	internal void NotifyActivityStop(Activity activity)
	{
		SynchronizedList<ActivityListener> listeners = _listeners;
		if (listeners != null && listeners.Count > 0)
		{
			listeners.EnumWithAction(delegate(ActivityListener listener, object obj)
			{
				listener.ActivityStopped?.Invoke((Activity)obj);
			}, activity);
		}
	}
}
