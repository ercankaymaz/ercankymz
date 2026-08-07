// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityListener
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[NullableContext(2)]
[Nullable(0)]
[ComVisible(true)]
public sealed class ActivityListener : IDisposable
{
  [Nullable(new byte[] {2, 1})]
  public Action<Activity> ActivityStarted { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  [Nullable(new byte[] {2, 1})]
  public Action<Activity> ActivityStopped { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  [Nullable(new byte[] {2, 1})]
  public Func<ActivitySource, bool> ShouldListenTo { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  [Nullable(new byte[] {2, 1})]
  public SampleActivity<string> SampleUsingParentId { [return: Nullable(new byte[] {2, 1})] get; [param: Nullable(new byte[] {2, 1})] set; }

  public SampleActivity<ActivityContext> Sample { get; set; }

  public void Dispose() => ActivitySource.DetachListener(this);
}
