// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.AsyncActivityBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Patterns;

public abstract class AsyncActivityBase : ActivityBase
{
  private IAsyncResult iasyncResult_0 = (IAsyncResult) null;

  protected override void ResetRunningStatus()
  {
    base.ResetRunningStatus();
    this.iasyncResult_0 = (IAsyncResult) null;
  }

  protected abstract void OnBeginWork(AsyncCallback callback);

  protected abstract void OnEndWork(IAsyncResult asyncResult);

  private void method_0(IAsyncResult iasyncResult_1)
  {
    this.iasyncResult_0 = iasyncResult_1;
    if (this.iasyncResult_0 == null)
      throw new DevAgeApplicationException("Invalid async activity, IAsyncResult is null");
    this.DoWork();
  }

  protected override void OnWork() => this.OnEndWork(this.iasyncResult_0);

  protected override void StartActivity() => this.OnBeginWork(new AsyncCallback(this.method_0));
}
