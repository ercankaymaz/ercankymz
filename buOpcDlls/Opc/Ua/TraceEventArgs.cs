// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TraceEventArgs
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TraceEventArgs : EventArgs
{
  internal TraceEventArgs(
    int traceMask,
    string format,
    string message,
    Exception exception,
    object[] args)
  {
    this.TraceMask = traceMask;
    this.Format = format;
    this.Message = message;
    this.Exception = exception;
    this.Arguments = args;
  }

  public int TraceMask { get; private set; }

  public string Format { get; private set; }

  public object[] Arguments { get; private set; }

  public string Message { get; private set; }

  public Exception Exception { get; private set; }
}
