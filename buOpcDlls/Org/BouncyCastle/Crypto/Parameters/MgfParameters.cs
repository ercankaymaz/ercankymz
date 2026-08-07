// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.MgfParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class MgfParameters : IDerivationParameters
{
  private readonly byte[] m_seed;

  public MgfParameters(byte[] seed)
    : this(seed, 0, seed.Length)
  {
  }

  public MgfParameters(byte[] seed, int off, int len)
  {
    this.m_seed = Arrays.CopyOfRange(seed, off, len);
  }

  public byte[] GetSeed() => (byte[]) this.m_seed.Clone();

  public void GetSeed(byte[] buffer, int offset) => this.m_seed.CopyTo((Array) buffer, offset);

  public int SeedLength => this.m_seed.Length;
}
