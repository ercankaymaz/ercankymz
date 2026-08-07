// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TrustedAuthority
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class TrustedAuthority
{
  private readonly short m_identifierType;
  private readonly object m_identifier;

  public TrustedAuthority(short identifierType, object identifier)
  {
    this.m_identifierType = TrustedAuthority.IsCorrectType(identifierType, identifier) ? identifierType : throw new ArgumentException("not an instance of the correct type", nameof (identifier));
    this.m_identifier = identifier;
  }

  public short IdentifierType => this.m_identifierType;

  public object Identifier => this.m_identifier;

  public byte[] GetCertSha1Hash() => Arrays.Clone((byte[]) this.m_identifier);

  public byte[] GetKeySha1Hash() => Arrays.Clone((byte[]) this.m_identifier);

  public X509Name X509Name
  {
    get
    {
      this.CheckCorrectType((short) 2);
      return (X509Name) this.m_identifier;
    }
  }

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_identifierType, output);
    switch (this.m_identifierType)
    {
      case 0:
        break;
      case 1:
      case 3:
        byte[] identifier = (byte[]) this.m_identifier;
        output.Write(identifier, 0, identifier.Length);
        break;
      case 2:
        TlsUtilities.WriteOpaque16(((Asn1Encodable) this.m_identifier).GetEncoded("DER"), output);
        break;
      default:
        throw new TlsFatalAlert((short) 80 /*0x50*/);
    }
  }

  public static TrustedAuthority Parse(Stream input)
  {
    short identifierType = TlsUtilities.ReadUint8(input);
    object identifier;
    switch (identifierType)
    {
      case 0:
        identifier = (object) null;
        break;
      case 1:
      case 3:
        identifier = (object) TlsUtilities.ReadFully(20, input);
        break;
      case 2:
        byte[] encoding = TlsUtilities.ReadOpaque16(input, 1);
        X509Name instance = X509Name.GetInstance((object) TlsUtilities.ReadAsn1Object(encoding));
        TlsUtilities.RequireDerEncoding((Asn1Encodable) instance, encoding);
        identifier = (object) instance;
        break;
      default:
        throw new TlsFatalAlert((short) 50);
    }
    return new TrustedAuthority(identifierType, identifier);
  }

  private void CheckCorrectType(short expectedIdentifierType)
  {
    if ((int) this.m_identifierType != (int) expectedIdentifierType || !TrustedAuthority.IsCorrectType(expectedIdentifierType, this.m_identifier))
      throw new InvalidOperationException("TrustedAuthority is not of type " + Org.BouncyCastle.Tls.IdentifierType.GetName(expectedIdentifierType));
  }

  private static bool IsCorrectType(short identifierType, object identifier)
  {
    switch (identifierType)
    {
      case 0:
        return identifier == null;
      case 1:
      case 3:
        return TrustedAuthority.IsSha1Hash(identifier);
      case 2:
        return identifier is X509Name;
      default:
        throw new ArgumentException("unsupported IdentifierType", nameof (identifierType));
    }
  }

  private static bool IsSha1Hash(object identifier)
  {
    return identifier is byte[] && ((byte[]) identifier).Length == 20;
  }
}
