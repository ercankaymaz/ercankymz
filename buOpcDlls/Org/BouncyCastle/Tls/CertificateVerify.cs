// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateVerify
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateVerify
{
  private readonly int m_algorithm;
  private readonly byte[] m_signature;

  public CertificateVerify(int algorithm, byte[] signature)
  {
    if (!TlsUtilities.IsValidUint16(algorithm))
      throw new ArgumentException(nameof (algorithm));
    if (signature == null)
      throw new ArgumentNullException(nameof (signature));
    this.m_algorithm = algorithm;
    this.m_signature = signature;
  }

  public int Algorithm => this.m_algorithm;

  public byte[] Signature => this.m_signature;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint16(this.m_algorithm, output);
    TlsUtilities.WriteOpaque16(this.m_signature, output);
  }

  public static CertificateVerify Parse(TlsContext context, Stream input)
  {
    if (!TlsUtilities.IsTlsV13(context))
      throw new InvalidOperationException();
    return new CertificateVerify(TlsUtilities.ReadUint16(input), TlsUtilities.ReadOpaque16(input));
  }
}
