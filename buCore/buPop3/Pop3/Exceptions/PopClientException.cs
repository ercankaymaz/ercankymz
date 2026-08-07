// Decompiled with JetBrains decompiler
// Type: buPop3.Pop3.Exceptions.PopClientException
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace buPop3.Pop3.Exceptions;

public abstract class PopClientException : Exception
{
  protected PopClientException(string message, Exception innerException)
    : base(message, innerException)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    if (innerException == null)
      throw new ArgumentNullException(nameof (innerException));
  }

  protected PopClientException(string message)
    : base(message)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
  }
}
