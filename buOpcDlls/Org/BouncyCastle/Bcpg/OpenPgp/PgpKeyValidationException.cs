// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKeyValidationException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

[Serializable]
public class PgpKeyValidationException : PgpException
{
  public PgpKeyValidationException()
  {
  }

  public PgpKeyValidationException(string message)
    : base(message)
  {
  }

  public PgpKeyValidationException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected PgpKeyValidationException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
