// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.DataLengthException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Crypto;

[Serializable]
public class DataLengthException : CryptoException
{
  public DataLengthException()
  {
  }

  public DataLengthException(string message)
    : base(message)
  {
  }

  public DataLengthException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected DataLengthException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
