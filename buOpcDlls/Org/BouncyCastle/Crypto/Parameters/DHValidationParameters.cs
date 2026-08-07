// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DHValidationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DHValidationParameters
{
  private readonly byte[] seed;
  private readonly int counter;

  public DHValidationParameters(byte[] seed, int counter)
  {
    this.seed = seed != null ? (byte[]) seed.Clone() : throw new ArgumentNullException(nameof (seed));
    this.counter = counter;
  }

  public byte[] GetSeed() => (byte[]) this.seed.Clone();

  public int Counter => this.counter;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DHValidationParameters other && this.Equals(other);
  }

  protected bool Equals(DHValidationParameters other)
  {
    return this.counter == other.counter && Arrays.AreEqual(this.seed, other.seed);
  }

  public override int GetHashCode() => this.counter.GetHashCode() ^ Arrays.GetHashCode(this.seed);
}
