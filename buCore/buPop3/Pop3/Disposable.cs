// Decompiled with JetBrains decompiler
// Type: buPop3.Pop3.Disposable
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Globalization;

#nullable disable
namespace buPop3.Pop3;

public abstract class Disposable : IDisposable
{
  protected bool IsDisposed { get; private set; }

  ~Disposable() => this.Dispose(false);

  public void Dispose()
  {
    if (this.IsDisposed)
      return;
    try
    {
      this.Dispose(true);
    }
    finally
    {
      this.IsDisposed = true;
      GC.SuppressFinalize((object) this);
    }
  }

  protected virtual void Dispose(bool disposing)
  {
  }

  protected void AssertDisposed()
  {
    if (this.IsDisposed)
    {
      string fullName = this.GetType().FullName;
      throw new ObjectDisposedException(fullName, string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Cannot access a disposed {0}.", (object) fullName));
    }
  }
}
