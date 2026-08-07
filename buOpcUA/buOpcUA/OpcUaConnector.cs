// Decompiled with JetBrains decompiler
// Type: buOpcUA.OpcUaConnector
// Assembly: buOpcUA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF9DFBD0-0B81-4B3D-BD5F-1E30872BDC2B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcUA.dll

using Opc.Ua.Client;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace buOpcUA;

public class OpcUaConnector
{
  private void \u0001()
  {
    TaskAwaiter awaiter1;
    int num;
    TaskAwaiter<Session> awaiter2;
    // ISSUE: reference to a compiler-generated field
    switch (((OpcClient.\u0003) this).\u0001)
    {
      case 0:
        // ISSUE: reference to a compiler-generated field
        awaiter1 = ((OpcUaConnector.\u0001) this).\u0001;
        // ISSUE: reference to a compiler-generated field
        ((OpcUaConnector.\u0001) this).\u0001 = new TaskAwaiter();
        num = -1;
        // ISSUE: reference to a compiler-generated field
        ((OpcClient.\u0003) this).\u0001 = -1;
        break;
      case 1:
        // ISSUE: reference to a compiler-generated field
        awaiter2 = ((OpcUaConnector.\u0001) this).\u0001;
        // ISSUE: reference to a compiler-generated field
        ((OpcUaConnector.\u0001) this).\u0001 = new TaskAwaiter<Session>();
        num = -1;
        // ISSUE: reference to a compiler-generated field
        ((OpcClient.\u0003) this).\u0001 = -1;
        goto label_9;
      default:
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((((OpcUaConnector.\u0001) this).\u0001.Session == null ? 0 : (((OpcUaConnector.\u0001) this).\u0001.Session.Connected ? 1 : 0)) != 0)
        {
          // ISSUE: reference to a compiler-generated field
          awaiter1 = ((OpcUaConnector.\u0001) this).\u0001.DisconnectAsync().GetAwaiter();
          if (!awaiter1.IsCompleted)
          {
            num = 0;
            // ISSUE: reference to a compiler-generated field
            ((OpcClient.\u0003) this).\u0001 = 0;
            // ISSUE: reference to a compiler-generated field
            ((OpcUaConnector.\u0001) this).\u0001 = awaiter1;
            // ISSUE: variable of a compiler-generated type
            OpcClient.\u0003 stateMachine = (OpcClient.\u0003) this;
            // ISSUE: reference to a compiler-generated field
            ((OpcClient.\u0003) this).\u0001.AwaitUnsafeOnCompleted<TaskAwaiter, OpcClient.\u0003>(ref awaiter1, ref stateMachine);
            return;
          }
          break;
        }
        goto label_7;
    }
    awaiter1.GetResult();
label_7:
    // ISSUE: reference to a compiler-generated field
    awaiter2 = ((OpcUaConnector.\u0001) this).\u0001.ConnectAsync().GetAwaiter();
    if (!awaiter2.IsCompleted)
    {
      num = 1;
      // ISSUE: reference to a compiler-generated field
      ((OpcClient.\u0003) this).\u0001 = 1;
      // ISSUE: reference to a compiler-generated field
      ((OpcUaConnector.\u0001) this).\u0001 = awaiter2;
      // ISSUE: variable of a compiler-generated type
      OpcClient.\u0003 stateMachine = (OpcClient.\u0003) this;
      // ISSUE: reference to a compiler-generated field
      ((OpcClient.\u0003) this).\u0001.AwaitUnsafeOnCompleted<TaskAwaiter<Session>, OpcClient.\u0003>(ref awaiter2, ref stateMachine);
      return;
    }
label_9:
    awaiter2.GetResult();
    // ISSUE: reference to a compiler-generated field
    ((OpcClient.\u0003) this).\u0001 = -2;
    // ISSUE: reference to a compiler-generated field
    ((OpcClient.\u0003) this).\u0001.SetResult();
  }

  private void \u0001([In] IAsyncStateMachine obj0)
  {
  }
}
