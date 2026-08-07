// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.PskIdentity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class PskIdentity
{
  private readonly byte[] m_identity;
  private readonly long m_obfuscatedTicketAge;

  public PskIdentity(byte[] identity, long obfuscatedTicketAge)
  {
    if (identity == null)
      throw new ArgumentNullException(nameof (identity));
    if (identity.Length < 1 || !TlsUtilities.IsValidUint16(identity.Length))
      throw new ArgumentException("should have length from 1 to 65535", nameof (identity));
    if (!TlsUtilities.IsValidUint32(obfuscatedTicketAge))
      throw new ArgumentException("should be a uint32", nameof (obfuscatedTicketAge));
    this.m_identity = identity;
    this.m_obfuscatedTicketAge = obfuscatedTicketAge;
  }

  public int GetEncodedLength() => 6 + this.m_identity.Length;

  public byte[] Identity => this.m_identity;

  public long ObfuscatedTicketAge => this.m_obfuscatedTicketAge;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteOpaque16(this.Identity, output);
    TlsUtilities.WriteUint32(this.ObfuscatedTicketAge, output);
  }

  public static PskIdentity Parse(Stream input)
  {
    return new PskIdentity(TlsUtilities.ReadOpaque16(input, 1), TlsUtilities.ReadUint32(input));
  }

  public override bool Equals(object obj)
  {
    return obj is PskIdentity pskIdentity && this.m_obfuscatedTicketAge == pskIdentity.m_obfuscatedTicketAge && Arrays.FixedTimeEquals(this.m_identity, pskIdentity.m_identity);
  }

  public override int GetHashCode()
  {
    return Arrays.GetHashCode(this.m_identity) ^ this.m_obfuscatedTicketAge.GetHashCode();
  }
}
