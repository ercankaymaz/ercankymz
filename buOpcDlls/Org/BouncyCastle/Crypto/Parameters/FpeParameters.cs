// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.FpeParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class FpeParameters : ICipherParameters
{
  private readonly KeyParameter key;
  private readonly int radix;
  private readonly byte[] tweak;
  private readonly bool useInverse;

  public FpeParameters(KeyParameter key, int radix, byte[] tweak)
    : this(key, radix, tweak, false)
  {
  }

  public FpeParameters(KeyParameter key, int radix, byte[] tweak, bool useInverse)
  {
    this.key = key;
    this.radix = radix;
    this.tweak = Arrays.Clone(tweak);
    this.useInverse = useInverse;
  }

  public KeyParameter Key => this.key;

  public int Radix => this.radix;

  public bool UseInverseFunction => this.useInverse;

  public byte[] GetTweak() => Arrays.Clone(this.tweak);
}
