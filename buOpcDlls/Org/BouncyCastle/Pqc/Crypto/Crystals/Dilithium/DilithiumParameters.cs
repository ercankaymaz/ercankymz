// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.DilithiumParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public sealed class DilithiumParameters : ICipherParameters
{
  public static DilithiumParameters Dilithium2 = new DilithiumParameters(2, false);
  public static DilithiumParameters Dilithium2Aes = new DilithiumParameters(2, true);
  public static DilithiumParameters Dilithium3 = new DilithiumParameters(3, false);
  public static DilithiumParameters Dilithium3Aes = new DilithiumParameters(3, true);
  public static DilithiumParameters Dilithium5 = new DilithiumParameters(5, false);
  public static DilithiumParameters Dilithium5Aes = new DilithiumParameters(5, true);
  private int k;
  private bool usingAes;

  private DilithiumParameters(int param, bool usingAes)
  {
    this.k = param;
    this.usingAes = usingAes;
  }

  internal DilithiumEngine GetEngine(SecureRandom Random)
  {
    return new DilithiumEngine(this.k, Random, this.usingAes);
  }
}
