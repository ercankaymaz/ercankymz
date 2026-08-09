using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua.Types.Utils;

[ComVisible(true)]
public class AsyncAutoResetEvent
{
	private static readonly Task s_completed = Task.FromResult(result: true);

	private readonly Queue<TaskCompletionSource<bool>> m_waits = new Queue<TaskCompletionSource<bool>>();

	private bool m_signaled;

	public Task WaitAsync()
	{
		lock (m_waits)
		{
			if (m_signaled)
			{
				m_signaled = false;
				return s_completed;
			}
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			m_waits.Enqueue(taskCompletionSource);
			return taskCompletionSource.Task;
		}
	}

	public void Set()
	{
		TaskCompletionSource<bool> taskCompletionSource;
		lock (m_waits)
		{
			if (m_waits.Count <= 0)
			{
				m_signaled = true;
				return;
			}
			taskCompletionSource = m_waits.Dequeue();
		}
		taskCompletionSource.SetResult(result: true);
	}

	public void SetAll()
	{
		lock (m_waits)
		{
			while (m_waits.Count > 0)
			{
				m_waits.Dequeue().SetResult(result: true);
			}
			m_signaled = true;
		}
	}
}
