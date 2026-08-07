// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoKEMExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public class FrodoKEMExtractor : IEncapsulatedSecretExtractor
{
  private FrodoEngine engine;
  private FrodoKeyParameters key;

  public FrodoKEMExtractor(FrodoKeyParameters privParams)
  {
    this.key = privParams;
    this.InitCipher(this.key.Parameters);
  }

  private void InitCipher(FrodoParameters param) => this.engine = param.Engine;

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    byte[] ss = new byte[this.engine.SessionKeySize];
    this.engine.kem_dec(ss, encapsulation, ((FrodoPrivateKeyParameters) this.key).privateKey);
    return ss;
  }

  public int EncapsulationLength => this.engine.CipherTextSize;
}
