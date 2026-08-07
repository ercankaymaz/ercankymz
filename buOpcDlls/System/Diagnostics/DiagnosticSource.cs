// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DiagnosticSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public abstract class DiagnosticSource
{
  internal const string WriteRequiresUnreferencedCode = "The type of object being written to DiagnosticSource cannot be discovered statically.";

  [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
  public abstract void Write(string name, [Nullable(2)] object value);

  public abstract bool IsEnabled(string name);

  [NullableContext(2)]
  public virtual bool IsEnabled([Nullable(1)] string name, object arg1, object arg2 = null)
  {
    return this.IsEnabled(name);
  }

  [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
  public Activity StartActivity(Activity activity, [Nullable(2)] object args)
  {
    activity.Start();
    this.Write(activity.OperationName + ".Start", args);
    return activity;
  }

  [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
  public void StopActivity(Activity activity, [Nullable(2)] object args)
  {
    if (activity.Duration == TimeSpan.Zero)
      activity.SetEndTime(Activity.GetUtcNow());
    this.Write(activity.OperationName + ".Stop", args);
    activity.Stop();
  }

  public virtual void OnActivityImport(Activity activity, [Nullable(2)] object payload)
  {
  }

  public virtual void OnActivityExport(Activity activity, [Nullable(2)] object payload)
  {
  }
}
