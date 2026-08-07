// Decompiled with JetBrains decompiler
// Type: buPop3.Pop3.Exceptions.InvalidLoginException
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;

#nullable disable
namespace buPop3.Pop3.Exceptions;

public class InvalidLoginException(Exception innerException) : PopClientException("Server did not accept user credentials", innerException)
{
}
