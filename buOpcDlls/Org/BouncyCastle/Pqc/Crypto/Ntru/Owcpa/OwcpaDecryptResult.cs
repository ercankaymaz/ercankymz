// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa.OwcpaDecryptResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.Owcpa;

internal class OwcpaDecryptResult
{
  internal byte[] Rm;
  internal int Fail;

  internal OwcpaDecryptResult(byte[] rm, int fail)
  {
    this.Rm = rm;
    this.Fail = fail;
  }
}
