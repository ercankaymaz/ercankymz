// Decompiled with JetBrains decompiler
// Type: buPop3.Pop3.Exceptions.LoginDelayException
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace buPop3.Pop3.Exceptions;

public class LoginDelayException(PopServerException innerException) : PopClientException("Login denied because of recent connection to this maildrop. Increase time between connections.", (Exception) innerException)
{
}
