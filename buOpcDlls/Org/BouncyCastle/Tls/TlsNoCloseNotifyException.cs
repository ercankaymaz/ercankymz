// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsNoCloseNotifyException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Tls;

[Serializable]
public class TlsNoCloseNotifyException : EndOfStreamException
{
  public TlsNoCloseNotifyException()
    : base("No close_notify alert received before connection closed")
  {
  }

  protected TlsNoCloseNotifyException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
