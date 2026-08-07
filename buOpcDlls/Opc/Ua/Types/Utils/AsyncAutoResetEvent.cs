// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Types.Utils.AsyncAutoResetEvent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Types.Utils;

[ComVisible(true)]
public class AsyncAutoResetEvent
{
  private static readonly Task s_completed = (Task) Task.FromResult<bool>(true);
  private readonly Queue<TaskCompletionSource<bool>> m_waits = new Queue<TaskCompletionSource<bool>>();
  private bool m_signaled;

  public Task WaitAsync()
  {
    lock (this.m_waits)
    {
      if (this.m_signaled)
      {
        this.m_signaled = false;
        return AsyncAutoResetEvent.s_completed;
      }
      TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();
      this.m_waits.Enqueue(completionSource);
      return (Task) completionSource.Task;
    }
  }

  public void Set()
  {
    TaskCompletionSource<bool> completionSource;
    lock (this.m_waits)
    {
      if (this.m_waits.Count > 0)
      {
        completionSource = this.m_waits.Dequeue();
      }
      else
      {
        this.m_signaled = true;
        return;
      }
    }
    completionSource.SetResult(true);
  }

  public void SetAll()
  {
    lock (this.m_waits)
    {
      while (this.m_waits.Count > 0)
        this.m_waits.Dequeue().SetResult(true);
      this.m_signaled = true;
    }
  }
}
