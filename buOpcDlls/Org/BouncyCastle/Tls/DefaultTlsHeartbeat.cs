// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsHeartbeat
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DefaultTlsHeartbeat : TlsHeartbeat
{
  private readonly int idleMillis;
  private readonly int timeoutMillis;
  private uint counter;

  public DefaultTlsHeartbeat(int idleMillis, int timeoutMillis)
  {
    if (idleMillis <= 0)
      throw new ArgumentException("must be > 0", nameof (idleMillis));
    if (timeoutMillis <= 0)
      throw new ArgumentException("must be > 0", nameof (timeoutMillis));
    this.idleMillis = idleMillis;
    this.timeoutMillis = timeoutMillis;
  }

  public virtual byte[] GeneratePayload()
  {
    lock (this)
      return Pack.UInt32_To_BE(++this.counter);
  }

  public virtual int IdleMillis => this.idleMillis;

  public virtual int TimeoutMillis => this.timeoutMillis;
}
