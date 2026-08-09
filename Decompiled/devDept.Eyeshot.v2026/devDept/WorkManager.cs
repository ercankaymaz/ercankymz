using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace devDept;

[Obsolete("WorkManager<T> is deprecated. Use Workspace.DoWorkAsync(IReadOnlyList<devDept.WorkUnit>) to execute and queue WorkUnit instances asynchronously.")]
public class WorkManager<T> : IDisposable where T : WorkUnit
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<T, bool> _0023_003DzMj0BD8rSnks5VxBWig_003D_003D;

		internal bool _0023_003Dz1mQtJGJgoX_h8YL9nk9lm9Q_003D(T _0023_003DzBJFJHwk_003D)
		{
			if (_0023_003DzBJFJHwk_003D.Status != workUnitStatus.Idle)
			{
				return _0023_003DzBJFJHwk_003D.Status == workUnitStatus.Cancelled;
			}
			return true;
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public workUnitStatus _0023_003Dz7duJoMQ_003D;

		internal bool _0023_003Dzqlc4k0vETjxvk42c3g_003D_003D(T _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Status == _0023_003Dz7duJoMQ_003D;
		}
	}

	public delegate void QueueCancelledEventHandler(object sender, WorkUnitEventArgs e);

	public delegate void QueueCompletedEventHandler(object sender, EventArgs e);

	public delegate void WorkUnitCompletedEventHandler(object sender, WorkUnitEventArgs e);

	public delegate void WorkUnitFailedEventHandler(object sender, WorkUnitEventArgs e);

	public delegate void WorkUnitProgressChangedEventHandler(object sender, WorkUnit.ProgressChangedEventArgs e);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly List<T> _0023_003DzytWbHqk_003D = new List<T>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private T _0023_003Dzbkb9VeGJdkec;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISupportWorkManager _0023_003DzqkJjmY9b569J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzu5_0024h6B7dmnCC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QueueCompletedEventHandler _0023_003DzCts4nPupInTH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QueueCancelledEventHandler _0023_003DzVXBvq7PjWBZt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnitCompletedEventHandler _0023_003DzCnlMyDPc2fEh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnitFailedEventHandler _0023_003Dzo3Bo107Asg4H;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WorkUnitProgressChangedEventHandler _0023_003Dz_0024cEc_0024sUIVALQ;

	public bool IsQueueEmpty => _0023_003DzE_0024oQzD3BjTzq() == null;

	public int QueueCount => _0023_003DzytWbHqk_003D.Count;

	public event QueueCompletedEventHandler QueueCompleted
	{
		[CompilerGenerated]
		add
		{
			QueueCompletedEventHandler queueCompletedEventHandler = _0023_003DzCts4nPupInTH;
			QueueCompletedEventHandler queueCompletedEventHandler2;
			do
			{
				queueCompletedEventHandler2 = queueCompletedEventHandler;
				QueueCompletedEventHandler value2 = (QueueCompletedEventHandler)Delegate.Combine(queueCompletedEventHandler2, value);
				queueCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003DzCts4nPupInTH, value2, queueCompletedEventHandler2);
			}
			while ((object)queueCompletedEventHandler != queueCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			QueueCompletedEventHandler queueCompletedEventHandler = _0023_003DzCts4nPupInTH;
			QueueCompletedEventHandler queueCompletedEventHandler2;
			do
			{
				queueCompletedEventHandler2 = queueCompletedEventHandler;
				QueueCompletedEventHandler value2 = (QueueCompletedEventHandler)Delegate.Remove(queueCompletedEventHandler2, value);
				queueCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003DzCts4nPupInTH, value2, queueCompletedEventHandler2);
			}
			while ((object)queueCompletedEventHandler != queueCompletedEventHandler2);
		}
	}

	public event QueueCancelledEventHandler QueueCancelled
	{
		[CompilerGenerated]
		add
		{
			QueueCancelledEventHandler queueCancelledEventHandler = _0023_003DzVXBvq7PjWBZt;
			QueueCancelledEventHandler queueCancelledEventHandler2;
			do
			{
				queueCancelledEventHandler2 = queueCancelledEventHandler;
				QueueCancelledEventHandler value2 = (QueueCancelledEventHandler)Delegate.Combine(queueCancelledEventHandler2, value);
				queueCancelledEventHandler = Interlocked.CompareExchange(ref _0023_003DzVXBvq7PjWBZt, value2, queueCancelledEventHandler2);
			}
			while ((object)queueCancelledEventHandler != queueCancelledEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			QueueCancelledEventHandler queueCancelledEventHandler = _0023_003DzVXBvq7PjWBZt;
			QueueCancelledEventHandler queueCancelledEventHandler2;
			do
			{
				queueCancelledEventHandler2 = queueCancelledEventHandler;
				QueueCancelledEventHandler value2 = (QueueCancelledEventHandler)Delegate.Remove(queueCancelledEventHandler2, value);
				queueCancelledEventHandler = Interlocked.CompareExchange(ref _0023_003DzVXBvq7PjWBZt, value2, queueCancelledEventHandler2);
			}
			while ((object)queueCancelledEventHandler != queueCancelledEventHandler2);
		}
	}

	public event WorkUnitCompletedEventHandler WorkUnitCompleted
	{
		[CompilerGenerated]
		add
		{
			WorkUnitCompletedEventHandler workUnitCompletedEventHandler = _0023_003DzCnlMyDPc2fEh;
			WorkUnitCompletedEventHandler workUnitCompletedEventHandler2;
			do
			{
				workUnitCompletedEventHandler2 = workUnitCompletedEventHandler;
				WorkUnitCompletedEventHandler value2 = (WorkUnitCompletedEventHandler)Delegate.Combine(workUnitCompletedEventHandler2, value);
				workUnitCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003DzCnlMyDPc2fEh, value2, workUnitCompletedEventHandler2);
			}
			while ((object)workUnitCompletedEventHandler != workUnitCompletedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnitCompletedEventHandler workUnitCompletedEventHandler = _0023_003DzCnlMyDPc2fEh;
			WorkUnitCompletedEventHandler workUnitCompletedEventHandler2;
			do
			{
				workUnitCompletedEventHandler2 = workUnitCompletedEventHandler;
				WorkUnitCompletedEventHandler value2 = (WorkUnitCompletedEventHandler)Delegate.Remove(workUnitCompletedEventHandler2, value);
				workUnitCompletedEventHandler = Interlocked.CompareExchange(ref _0023_003DzCnlMyDPc2fEh, value2, workUnitCompletedEventHandler2);
			}
			while ((object)workUnitCompletedEventHandler != workUnitCompletedEventHandler2);
		}
	}

	public event WorkUnitFailedEventHandler WorkUnitFailed
	{
		[CompilerGenerated]
		add
		{
			WorkUnitFailedEventHandler workUnitFailedEventHandler = _0023_003Dzo3Bo107Asg4H;
			WorkUnitFailedEventHandler workUnitFailedEventHandler2;
			do
			{
				workUnitFailedEventHandler2 = workUnitFailedEventHandler;
				WorkUnitFailedEventHandler value2 = (WorkUnitFailedEventHandler)Delegate.Combine(workUnitFailedEventHandler2, value);
				workUnitFailedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzo3Bo107Asg4H, value2, workUnitFailedEventHandler2);
			}
			while ((object)workUnitFailedEventHandler != workUnitFailedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnitFailedEventHandler workUnitFailedEventHandler = _0023_003Dzo3Bo107Asg4H;
			WorkUnitFailedEventHandler workUnitFailedEventHandler2;
			do
			{
				workUnitFailedEventHandler2 = workUnitFailedEventHandler;
				WorkUnitFailedEventHandler value2 = (WorkUnitFailedEventHandler)Delegate.Remove(workUnitFailedEventHandler2, value);
				workUnitFailedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzo3Bo107Asg4H, value2, workUnitFailedEventHandler2);
			}
			while ((object)workUnitFailedEventHandler != workUnitFailedEventHandler2);
		}
	}

	public event WorkUnitProgressChangedEventHandler WorkUnitProgressChanged
	{
		[CompilerGenerated]
		add
		{
			WorkUnitProgressChangedEventHandler workUnitProgressChangedEventHandler = _0023_003Dz_0024cEc_0024sUIVALQ;
			WorkUnitProgressChangedEventHandler workUnitProgressChangedEventHandler2;
			do
			{
				workUnitProgressChangedEventHandler2 = workUnitProgressChangedEventHandler;
				WorkUnitProgressChangedEventHandler value2 = (WorkUnitProgressChangedEventHandler)Delegate.Combine(workUnitProgressChangedEventHandler2, value);
				workUnitProgressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024cEc_0024sUIVALQ, value2, workUnitProgressChangedEventHandler2);
			}
			while ((object)workUnitProgressChangedEventHandler != workUnitProgressChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			WorkUnitProgressChangedEventHandler workUnitProgressChangedEventHandler = _0023_003Dz_0024cEc_0024sUIVALQ;
			WorkUnitProgressChangedEventHandler workUnitProgressChangedEventHandler2;
			do
			{
				workUnitProgressChangedEventHandler2 = workUnitProgressChangedEventHandler;
				WorkUnitProgressChangedEventHandler value2 = (WorkUnitProgressChangedEventHandler)Delegate.Remove(workUnitProgressChangedEventHandler2, value);
				workUnitProgressChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dz_0024cEc_0024sUIVALQ, value2, workUnitProgressChangedEventHandler2);
			}
			while ((object)workUnitProgressChangedEventHandler != workUnitProgressChangedEventHandler2);
		}
	}

	public WorkManager()
	{
	}

	public WorkManager(IEnumerable<T> workUnits)
	{
		AppendToQueue(workUnits);
	}

	public WorkManager(T workUnit)
	{
		AppendToQueue(workUnit);
	}

	public void AppendToQueue(T workUnit)
	{
		_0023_003DzytWbHqk_003D.Add(workUnit);
	}

	public void AppendToQueue(IEnumerable<T> workUnits)
	{
		_0023_003DzytWbHqk_003D.AddRange(workUnits);
	}

	public void RemoveFromQueue(T workUnit)
	{
		if (workUnit == _0023_003Dzbkb9VeGJdkec)
		{
			Cancel();
		}
		_0023_003DzytWbHqk_003D.Remove(workUnit);
	}

	public void RemoveFromQueue(workUnitStatus status)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003Dz7duJoMQ_003D = status;
		if (_0023_003Dzbkb9VeGJdkec.Status == _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003Dz7duJoMQ_003D)
		{
			Cancel();
		}
		_0023_003DzytWbHqk_003D.RemoveAll(_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D2._0023_003Dzqlc4k0vETjxvk42c3g_003D_003D);
	}

	public void ClearQueue()
	{
		Cancel();
		_0023_003DzytWbHqk_003D.Clear();
	}

	public T[] GetQueueItems()
	{
		return _0023_003DzytWbHqk_003D.ToArray();
	}

	private T _0023_003DzE_0024oQzD3BjTzq()
	{
		return _0023_003DzytWbHqk_003D.FirstOrDefault(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz1mQtJGJgoX_h8YL9nk9lm9Q_003D);
	}

	private void _0023_003Dz7zAiMj99ijq6()
	{
		_0023_003Dzbkb9VeGJdkec = null;
		_0023_003DzGgazebWUCof9();
		_0023_003Dzu5_0024h6B7dmnCC = false;
	}

	public void Run()
	{
		if (_0023_003DzytWbHqk_003D.Count != 0 && _0023_003Dzbkb9VeGJdkec == null)
		{
			_0023_003Dzbkb9VeGJdkec = _0023_003DzE_0024oQzD3BjTzq();
			if (_0023_003Dzbkb9VeGJdkec != null)
			{
				_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.InProgress;
				_0023_003Dzbkb9VeGJdkec.DoWork();
				_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Completed;
			}
		}
	}

	public void RunAll()
	{
		if (_0023_003DzytWbHqk_003D.Count != 0 && _0023_003Dzbkb9VeGJdkec == null)
		{
			while (_0023_003DzE_0024oQzD3BjTzq() != null)
			{
				Run();
				_0023_003Dz7zAiMj99ijq6();
			}
		}
	}

	private void _0023_003DztExtU9w_003D(ISupportWorkManager _0023_003DzP_00248akTAZ8J1d, bool _0023_003DzT7r5VPCOrI1x)
	{
		if (_0023_003DzytWbHqk_003D.Count == 0 || _0023_003Dzbkb9VeGJdkec != null || _0023_003DzP_00248akTAZ8J1d == null)
		{
			return;
		}
		_0023_003Dzu5_0024h6B7dmnCC = _0023_003DzT7r5VPCOrI1x;
		_0023_003Dzbkb9VeGJdkec = _0023_003DzE_0024oQzD3BjTzq();
		if (_0023_003Dzbkb9VeGJdkec != null)
		{
			_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.InProgress;
			_0023_003DzcCQ5nk_0024bykqJ(_0023_003DzP_00248akTAZ8J1d);
			if (!_0023_003DzqkJjmY9b569J.IsBusy)
			{
				_0023_003DzqkJjmY9b569J.StartWork(_0023_003Dzbkb9VeGJdkec);
			}
		}
	}

	public void Run(ISupportWorkManager externalObj)
	{
		_0023_003DztExtU9w_003D(externalObj, _0023_003DzT7r5VPCOrI1x: false);
	}

	public void RunAll(ISupportWorkManager externalObj)
	{
		_0023_003DztExtU9w_003D(externalObj, _0023_003DzT7r5VPCOrI1x: true);
	}

	public void Cancel()
	{
		if (_0023_003Dzbkb9VeGJdkec != null && _0023_003DzqkJjmY9b569J != null)
		{
			_0023_003DzqkJjmY9b569J.CancelWork();
		}
	}

	public void Reset()
	{
		Cancel();
		_0023_003Dz7zAiMj99ijq6();
		ClearQueue();
	}

	public void Dispose()
	{
		Reset();
	}

	private void _0023_003DzcCQ5nk_0024bykqJ(ISupportWorkManager _0023_003DzP_00248akTAZ8J1d)
	{
		if (_0023_003DzP_00248akTAZ8J1d == null)
		{
			return;
		}
		_0023_003DzqkJjmY9b569J = _0023_003DzP_00248akTAZ8J1d;
		_0023_003DzqkJjmY9b569J.WorkCompleted += delegate(object _0023_003Dz9VjL5i0_003D, WorkCompletedEventArgs _0023_003DzbfrNXYE_003D)
		{
			if (_0023_003DzpJB3Fy0weocf(_0023_003DzbfrNXYE_003D))
			{
				_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Completed;
				if (_0023_003Dzu5_0024h6B7dmnCC)
				{
					_0023_003DzCnlMyDPc2fEh?.Invoke(_0023_003Dz9VjL5i0_003D, new WorkUnitEventArgs(_0023_003Dzbkb9VeGJdkec));
					_0023_003Dz7zAiMj99ijq6();
					if (IsQueueEmpty)
					{
						_0023_003DzCts4nPupInTH?.Invoke(_0023_003Dz9VjL5i0_003D, EventArgs.Empty);
					}
					else
					{
						RunAll((ISupportWorkManager)_0023_003Dz9VjL5i0_003D);
					}
				}
				else
				{
					_0023_003Dz7zAiMj99ijq6();
				}
			}
		};
		_0023_003DzqkJjmY9b569J.WorkFailed += _0023_003Dz1lGO0DvqJmW7dsQDqA_003D_003D;
		_0023_003DzqkJjmY9b569J.WorkCancelled += _0023_003DzWmsiP2KCUZOyeqsb7Q_003D_003D;
		_0023_003DzqkJjmY9b569J.ProgressChanged += _0023_003DzNeWnmYhMQRNl;
	}

	private void _0023_003DzGgazebWUCof9()
	{
		if (_0023_003DzqkJjmY9b569J == null)
		{
			return;
		}
		_0023_003DzqkJjmY9b569J.WorkCompleted -= delegate(object _0023_003Dz9VjL5i0_003D, WorkCompletedEventArgs _0023_003DzbfrNXYE_003D)
		{
			if (_0023_003DzpJB3Fy0weocf(_0023_003DzbfrNXYE_003D))
			{
				_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Completed;
				if (_0023_003Dzu5_0024h6B7dmnCC)
				{
					_0023_003DzCnlMyDPc2fEh?.Invoke(_0023_003Dz9VjL5i0_003D, new WorkUnitEventArgs(_0023_003Dzbkb9VeGJdkec));
					_0023_003Dz7zAiMj99ijq6();
					if (IsQueueEmpty)
					{
						_0023_003DzCts4nPupInTH?.Invoke(_0023_003Dz9VjL5i0_003D, EventArgs.Empty);
					}
					else
					{
						RunAll((ISupportWorkManager)_0023_003Dz9VjL5i0_003D);
					}
				}
				else
				{
					_0023_003Dz7zAiMj99ijq6();
				}
			}
		};
		_0023_003DzqkJjmY9b569J.WorkFailed -= _0023_003Dz1lGO0DvqJmW7dsQDqA_003D_003D;
		_0023_003DzqkJjmY9b569J.WorkCancelled -= _0023_003DzWmsiP2KCUZOyeqsb7Q_003D_003D;
		_0023_003DzqkJjmY9b569J.ProgressChanged -= _0023_003DzNeWnmYhMQRNl;
		_0023_003DzqkJjmY9b569J = null;
	}

	private void _0023_003DzWmsiP2KCUZOyeqsb7Q_003D_003D(object _0023_003Dz9VjL5i0_003D, WorkUnitEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzpJB3Fy0weocf(_0023_003DzbfrNXYE_003D))
		{
			_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Cancelled;
			_0023_003DzVXBvq7PjWBZt?.Invoke(_0023_003Dz9VjL5i0_003D, new WorkUnitEventArgs(_0023_003Dzbkb9VeGJdkec));
			_0023_003Dz7zAiMj99ijq6();
		}
	}

	private void _0023_003Dz1lGO0DvqJmW7dsQDqA_003D_003D(object _0023_003Dz9VjL5i0_003D, WorkFailedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzpJB3Fy0weocf(_0023_003DzbfrNXYE_003D))
		{
			_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Failed;
			if (_0023_003Dzu5_0024h6B7dmnCC)
			{
				_0023_003Dzo3Bo107Asg4H?.Invoke(_0023_003Dz9VjL5i0_003D, new WorkUnitEventArgs(_0023_003Dzbkb9VeGJdkec));
				_0023_003Dz7zAiMj99ijq6();
				RunAll((ISupportWorkManager)_0023_003Dz9VjL5i0_003D);
			}
			else
			{
				_0023_003Dz7zAiMj99ijq6();
			}
		}
	}

	private void _0023_003Dz0FwiBfIZp__0024d_00248_HAg_003D_003D(object _0023_003Dz9VjL5i0_003D, WorkCompletedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (!_0023_003DzpJB3Fy0weocf(_0023_003DzbfrNXYE_003D))
		{
			return;
		}
		_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Completed;
		if (_0023_003Dzu5_0024h6B7dmnCC)
		{
			_0023_003DzCnlMyDPc2fEh?.Invoke(_0023_003Dz9VjL5i0_003D, new WorkUnitEventArgs(_0023_003Dzbkb9VeGJdkec));
			_0023_003Dz7zAiMj99ijq6();
			if (IsQueueEmpty)
			{
				_0023_003DzCts4nPupInTH?.Invoke(_0023_003Dz9VjL5i0_003D, EventArgs.Empty);
			}
			else
			{
				RunAll((ISupportWorkManager)_0023_003Dz9VjL5i0_003D);
			}
		}
		else
		{
			_0023_003Dz7zAiMj99ijq6();
		}
	}

	private void _0023_003DzNeWnmYhMQRNl(object _0023_003Dz9VjL5i0_003D, WorkUnit.ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		_0023_003Dz_0024cEc_0024sUIVALQ?.Invoke(_0023_003Dz9VjL5i0_003D, _0023_003DzbfrNXYE_003D);
	}

	private bool _0023_003DzpJB3Fy0weocf(WorkUnitEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzbfrNXYE_003D.WorkUnit != _0023_003Dzbkb9VeGJdkec)
		{
			T val = _0023_003Dzbkb9VeGJdkec;
			if (val != null && val.Status == workUnitStatus.InProgress)
			{
				_0023_003Dzbkb9VeGJdkec.Status = workUnitStatus.Idle;
			}
			if (_0023_003Dzu5_0024h6B7dmnCC)
			{
				RunAll(_0023_003DzqkJjmY9b569J);
			}
			else
			{
				Run(_0023_003DzqkJjmY9b569J);
			}
			return false;
		}
		return true;
	}
}
