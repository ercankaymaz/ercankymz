// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.KeyShareEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class KeyShareEntry
{
  private readonly int m_namedGroup;
  private readonly byte[] m_keyExchange;

  private static bool CheckKeyExchangeLength(int length)
  {
    return 0 < length && length < 65536 /*0x010000*/;
  }

  public KeyShareEntry(int namedGroup, byte[] keyExchange)
  {
    if (!TlsUtilities.IsValidUint16(namedGroup))
      throw new ArgumentException("should be a uint16", nameof (namedGroup));
    if (keyExchange == null)
      throw new ArgumentNullException(nameof (keyExchange));
    if (!KeyShareEntry.CheckKeyExchangeLength(keyExchange.Length))
      throw new ArgumentException("must have length from 1 to (2^16 - 1)", nameof (keyExchange));
    this.m_namedGroup = namedGroup;
    this.m_keyExchange = keyExchange;
  }

  public int NamedGroup => this.m_namedGroup;

  public byte[] KeyExchange => this.m_keyExchange;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint16(this.NamedGroup, output);
    TlsUtilities.WriteOpaque16(this.KeyExchange, output);
  }

  public static KeyShareEntry Parse(Stream input)
  {
    return new KeyShareEntry(TlsUtilities.ReadUint16(input), TlsUtilities.ReadOpaque16(input, 1));
  }
}
