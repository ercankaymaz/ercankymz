using System.Runtime.Diagnostics;

namespace System.ServiceModel.Diagnostics;

internal class Activity : IDisposable
{
	protected Guid parentId;

	private bool _mustDispose;

	protected Guid Id { get; }

	protected Activity(Guid activityId, Guid parentId)
	{
		Id = activityId;
		this.parentId = parentId;
		_mustDispose = true;
		DiagnosticTraceBase.ActivityId = Id;
	}

	internal static Activity CreateActivity(Guid activityId)
	{
		Activity result = null;
		if (activityId != Guid.Empty)
		{
			Guid activityId2 = DiagnosticTraceBase.ActivityId;
			if (activityId != activityId2)
			{
				result = new Activity(activityId, activityId2);
			}
		}
		return result;
	}

	public virtual void Dispose()
	{
		if (_mustDispose)
		{
			_mustDispose = false;
			DiagnosticTraceBase.ActivityId = parentId;
		}
		GC.SuppressFinalize(this);
	}
}
