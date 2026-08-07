// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

[Serializable]
public class PgpException : Exception
{
  public PgpException()
  {
  }

  public PgpException(string message)
    : base(message)
  {
  }

  public PgpException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected PgpException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
