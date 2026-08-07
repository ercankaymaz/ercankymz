// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.KeyParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class KeyParameter : ICipherParameters
{
  private readonly byte[] m_key;

  public KeyParameter(byte[] key)
  {
    this.m_key = key != null ? (byte[]) key.Clone() : throw new ArgumentNullException(nameof (key));
  }

  public KeyParameter(byte[] key, int keyOff, int keyLen)
  {
    if (key == null)
      throw new ArgumentNullException(nameof (key));
    if (keyOff < 0 || keyOff > key.Length)
      throw new ArgumentOutOfRangeException(nameof (keyOff));
    if (keyLen < 0 || keyLen > key.Length - keyOff)
      throw new ArgumentOutOfRangeException(nameof (keyLen));
    this.m_key = new byte[keyLen];
    Array.Copy((Array) key, keyOff, (Array) this.m_key, 0, keyLen);
  }

  private KeyParameter(int length)
  {
    this.m_key = length >= 1 ? new byte[length] : throw new ArgumentOutOfRangeException(nameof (length));
  }

  internal void CopyTo(byte[] buf, int off, int len)
  {
    if (this.m_key.Length != len)
      throw new ArgumentOutOfRangeException(nameof (len));
    Array.Copy((Array) this.m_key, 0, (Array) buf, off, len);
  }

  public byte[] GetKey() => (byte[]) this.m_key.Clone();

  public int KeyLength => this.m_key.Length;

  internal bool FixedTimeEquals(byte[] data) => Arrays.FixedTimeEquals(this.m_key, data);
}
