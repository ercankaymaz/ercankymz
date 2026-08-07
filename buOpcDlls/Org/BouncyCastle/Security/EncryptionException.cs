// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.EncryptionException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Security;

[Serializable]
public class EncryptionException : IOException
{
  public EncryptionException()
  {
  }

  public EncryptionException(string message)
    : base(message)
  {
  }

  public EncryptionException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected EncryptionException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
