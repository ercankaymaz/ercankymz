// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.TweakableBlockCipherParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class TweakableBlockCipherParameters : ICipherParameters
{
  private readonly byte[] tweak;
  private readonly KeyParameter key;

  public TweakableBlockCipherParameters(KeyParameter key, byte[] tweak)
  {
    this.key = key;
    this.tweak = Arrays.Clone(tweak);
  }

  public KeyParameter Key => this.key;

  public byte[] Tweak => this.tweak;
}
