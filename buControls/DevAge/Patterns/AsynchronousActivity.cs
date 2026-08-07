// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.AsynchronousActivity
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Patterns;

public class AsynchronousActivity : AsyncActivityBase
{
  private AsynchronousActivity.Delegate0 delegate0_0;

  public AsynchronousActivity()
  {
    this.delegate0_0 = new AsynchronousActivity.Delegate0(this.OnAsyncWork);
  }

  protected override void OnBeginWork(AsyncCallback callback)
  {
    this.delegate0_0.BeginInvoke(callback, new object());
  }

  protected virtual void OnAsyncWork()
  {
  }

  protected override void OnEndWork(IAsyncResult asyncResult)
  {
    this.delegate0_0.EndInvoke(asyncResult);
  }

  private delegate void Delegate0();
}
