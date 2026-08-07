// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.CryptoApiRandomGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Security.Cryptography;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public sealed class CryptoApiRandomGenerator : IRandomGenerator, IDisposable
{
  private readonly RandomNumberGenerator m_randomNumberGenerator;

  public CryptoApiRandomGenerator()
    : this(RandomNumberGenerator.Create())
  {
  }

  public CryptoApiRandomGenerator(RandomNumberGenerator randomNumberGenerator)
  {
    this.m_randomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof (randomNumberGenerator));
  }

  public void AddSeedMaterial(byte[] seed)
  {
  }

  public void AddSeedMaterial(long seed)
  {
  }

  public void NextBytes(byte[] bytes) => this.m_randomNumberGenerator.GetBytes(bytes);

  public void NextBytes(byte[] bytes, int start, int len)
  {
    if (start < 0)
      throw new ArgumentException("Start offset cannot be negative", nameof (start));
    if (start > bytes.Length - len)
      throw new ArgumentException("Byte array too small for requested offset and length");
    if (bytes.Length == len && start == 0)
    {
      this.NextBytes(bytes);
    }
    else
    {
      byte[] bytes1 = new byte[len];
      this.NextBytes(bytes1);
      bytes1.CopyTo((Array) bytes, start);
    }
  }

  public void Dispose()
  {
    this.m_randomNumberGenerator.Dispose();
    GC.SuppressFinalize((object) this);
  }
}
