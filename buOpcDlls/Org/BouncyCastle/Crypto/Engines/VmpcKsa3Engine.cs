// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.VmpcKsa3Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class VmpcKsa3Engine : VmpcEngine
{
  public override string AlgorithmName => "VMPC-KSA3";

  protected override void InitKey(byte[] keyBytes, byte[] ivBytes)
  {
    base.InitKey(keyBytes, ivBytes);
    VmpcEngine.KsaRound(this.P, ref this.s, keyBytes);
  }
}
