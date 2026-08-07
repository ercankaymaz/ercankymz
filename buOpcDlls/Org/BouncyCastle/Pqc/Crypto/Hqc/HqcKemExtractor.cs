// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public class HqcKemExtractor : IEncapsulatedSecretExtractor
{
  private HqcEngine engine;
  private HqcKeyParameters key;

  public HqcKemExtractor(HqcPrivateKeyParameters privParams)
  {
    this.key = (HqcKeyParameters) privParams;
    this.InitCipher(this.key.Parameters);
  }

  private void InitCipher(HqcParameters param) => this.engine = param.Engine;

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    byte[] ss = new byte[this.engine.GetSessionKeySize()];
    byte[] privateKey = ((HqcPrivateKeyParameters) this.key).PrivateKey;
    this.engine.Decaps(ss, encapsulation, privateKey);
    return ss;
  }

  public int EncapsulationLength
  {
    get => this.key.Parameters.NBytes + this.key.Parameters.N1n2Bytes + 64 /*0x40*/;
  }
}
