// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SIG_FORS
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class SIG_FORS
{
  internal byte[][] authPath;
  internal byte[] sk;

  internal SIG_FORS(byte[] sk, byte[][] authPath)
  {
    this.authPath = authPath;
    this.sk = sk;
  }

  public byte[] SK => this.sk;

  public byte[][] AuthPath => this.authPath;
}
