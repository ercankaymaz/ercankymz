// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.RC2Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class RC2Parameters : KeyParameter
{
  private readonly int bits;

  public RC2Parameters(byte[] key)
    : this(key, key.Length > 128 /*0x80*/ ? 1024 /*0x0400*/ : key.Length * 8)
  {
  }

  public RC2Parameters(byte[] key, int keyOff, int keyLen)
    : this(key, keyOff, keyLen, keyLen > 128 /*0x80*/ ? 1024 /*0x0400*/ : keyLen * 8)
  {
  }

  public RC2Parameters(byte[] key, int bits)
    : base(key)
  {
    this.bits = bits;
  }

  public RC2Parameters(byte[] key, int keyOff, int keyLen, int bits)
    : base(key, keyOff, keyLen)
  {
    this.bits = bits;
  }

  public int EffectiveKeyBits => this.bits;
}
