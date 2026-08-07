// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DsaValidationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DsaValidationParameters
{
  private readonly byte[] seed;
  private readonly int counter;
  private readonly int usageIndex;

  public DsaValidationParameters(byte[] seed, int counter)
    : this(seed, counter, -1)
  {
  }

  public DsaValidationParameters(byte[] seed, int counter, int usageIndex)
  {
    this.seed = seed != null ? (byte[]) seed.Clone() : throw new ArgumentNullException(nameof (seed));
    this.counter = counter;
    this.usageIndex = usageIndex;
  }

  public virtual byte[] GetSeed() => (byte[]) this.seed.Clone();

  public virtual int Counter => this.counter;

  public virtual int UsageIndex => this.usageIndex;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DsaValidationParameters other && this.Equals(other);
  }

  protected virtual bool Equals(DsaValidationParameters other)
  {
    return this.counter == other.counter && Arrays.AreEqual(this.seed, other.seed);
  }

  public override int GetHashCode() => this.counter.GetHashCode() ^ Arrays.GetHashCode(this.seed);
}
