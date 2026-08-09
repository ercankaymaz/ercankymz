using System;
using System.Threading;

namespace DevAge.Patterns;

public interface IActivity
{
	ActivityCollection SubActivities { get; }

	ActivityStatus Status { get; }

	string Name { get; }

	WaitHandle WaitHandle { get; }

	Exception Exception { get; }

	IActivity Parent { get; set; }

	string FullName { get; }

	void Start(IActivityEvents events);

	void Cancel();
}
