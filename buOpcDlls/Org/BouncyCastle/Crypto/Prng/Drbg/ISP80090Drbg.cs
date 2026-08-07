// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.Drbg.ISP80090Drbg
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng.Drbg;

public interface ISP80090Drbg
{
  int BlockSize { get; }

  int Generate(
    byte[] output,
    int outputOff,
    int outputLen,
    byte[] additionalInput,
    bool predictionResistant);

  void Reseed(byte[] additionalInput);
}
