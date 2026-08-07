// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Tracing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class Tracing
{
  private static readonly object s_syncRoot = new object();
  private static Tracing s_instance;

  private Tracing()
  {
  }

  public static bool IsEnabled()
  {
    return Tracing.s_instance != null && Tracing.s_instance.TraceEventHandler != null;
  }

  public static Tracing Instance
  {
    get
    {
      if (Tracing.s_instance == null)
      {
        lock (Tracing.s_syncRoot)
        {
          if (Tracing.s_instance == null)
            Tracing.s_instance = new Tracing();
        }
      }
      return Tracing.s_instance;
    }
  }

  public event EventHandler<TraceEventArgs> TraceEventHandler;

  internal void RaiseTraceEvent(TraceEventArgs eventArgs)
  {
    if (this.TraceEventHandler == null)
      return;
    try
    {
      this.TraceEventHandler((object) this, eventArgs);
    }
    catch (Exception ex)
    {
      Utils.Trace(ex, "Exception invoking Trace Event Handler", true, (object[]) null);
    }
  }
}
