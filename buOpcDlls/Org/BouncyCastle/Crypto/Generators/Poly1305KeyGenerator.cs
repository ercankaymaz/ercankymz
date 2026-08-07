// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Poly1305KeyGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class Poly1305KeyGenerator : CipherKeyGenerator
{
  private const byte R_MASK_LOW_2 = 252;
  private const byte R_MASK_HIGH_4 = 15;

  protected override void EngineInit(KeyGenerationParameters param)
  {
    this.random = param.Random;
    this.strength = 32 /*0x20*/;
  }

  protected override byte[] EngineGenerateKey()
  {
    byte[] key = base.EngineGenerateKey();
    Poly1305KeyGenerator.Clamp(key);
    return key;
  }

  public static void Clamp(byte[] key)
  {
    if (key.Length != 32 /*0x20*/)
      throw new ArgumentException("Poly1305 key must be 256 bits.");
    key[3] &= (byte) 15;
    key[7] &= (byte) 15;
    key[11] &= (byte) 15;
    key[15] &= (byte) 15;
    key[4] &= (byte) 252;
    key[8] &= (byte) 252;
    key[12] &= (byte) 252;
  }

  public static void CheckKey(byte[] key)
  {
    if (key.Length != 32 /*0x20*/)
      throw new ArgumentException("Poly1305 key must be 256 bits.");
    Poly1305KeyGenerator.CheckMask(key[3], (byte) 15);
    Poly1305KeyGenerator.CheckMask(key[7], (byte) 15);
    Poly1305KeyGenerator.CheckMask(key[11], (byte) 15);
    Poly1305KeyGenerator.CheckMask(key[15], (byte) 15);
    Poly1305KeyGenerator.CheckMask(key[4], (byte) 252);
    Poly1305KeyGenerator.CheckMask(key[8], (byte) 252);
    Poly1305KeyGenerator.CheckMask(key[12], (byte) 252);
  }

  private static void CheckMask(byte b, byte mask)
  {
    if (((int) b & (int) ~mask) != 0)
      throw new ArgumentException("Invalid format for r portion of Poly1305 key.");
  }
}
