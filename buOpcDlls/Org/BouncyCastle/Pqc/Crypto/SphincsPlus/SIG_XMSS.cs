// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_XMSS
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class SIG_XMSS
{
  internal byte[] sig;
  internal byte[][] auth;

  internal SIG_XMSS(byte[] sig, byte[][] auth)
  {
    this.sig = sig;
    this.auth = auth;
  }

  internal byte[] WotsSig => this.sig;

  internal byte[][] XmssAuth => this.auth;
}
