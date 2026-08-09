using System;

namespace devDept;

[Obsolete("ISupportWorkManager is deprecated. Use Workspace.DoWorkAsync(IReadOnlyList<devDept.WorkUnit>) to execute and queue WorkUnit instances asynchronously.")]
public interface ISupportWorkManager
{
	bool IsBusy { get; }

	event WorkUnit.WorkCompletedEventHandler WorkCompleted;

	event WorkUnit.WorkCancelledEventHandler WorkCancelled;

	event WorkUnit.WorkFailedEventHandler WorkFailed;

	event WorkUnit.ProgressChangedEventHandler ProgressChanged;

	void DoWork(WorkUnit workUnit);

	void StartWork(WorkUnit workUnit);

	void CancelWork();
}
