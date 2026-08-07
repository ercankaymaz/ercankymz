// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.SkeinMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class SkeinMac : IMac
{
  public const int SKEIN_256 = 256 /*0x0100*/;
  public const int SKEIN_512 = 512 /*0x0200*/;
  public const int SKEIN_1024 = 1024 /*0x0400*/;
  private readonly SkeinEngine engine;

  public SkeinMac(int stateSizeBits, int digestSizeBits)
  {
    this.engine = new SkeinEngine(stateSizeBits, digestSizeBits);
  }

  public SkeinMac(SkeinMac mac) => this.engine = new SkeinEngine(mac.engine);

  public string AlgorithmName
  {
    get
    {
      int num = this.engine.BlockSize * 8;
      string str1 = num.ToString();
      num = this.engine.OutputSize * 8;
      string str2 = num.ToString();
      return $"Skein-MAC-{str1}-{str2}";
    }
  }

  public void Init(ICipherParameters parameters)
  {
    SkeinParameters parameters1;
    switch (parameters)
    {
      case SkeinParameters _:
        parameters1 = (SkeinParameters) parameters;
        break;
      case KeyParameter _:
        parameters1 = new SkeinParameters.Builder().SetKey(((KeyParameter) parameters).GetKey()).Build();
        break;
      default:
        throw new ArgumentException("Invalid parameter passed to Skein MAC init - " + Platform.GetTypeName((object) parameters));
    }
    if (parameters1.GetKey() == null)
      throw new ArgumentException("Skein MAC requires a key parameter.");
    this.engine.Init(parameters1);
  }

  public int GetMacSize() => this.engine.OutputSize;

  public void Reset() => this.engine.Reset();

  public void Update(byte inByte) => this.engine.Update(inByte);

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.engine.BlockUpdate(input, inOff, len);
  }

  public int DoFinal(byte[] output, int outOff) => this.engine.DoFinal(output, outOff);
}
