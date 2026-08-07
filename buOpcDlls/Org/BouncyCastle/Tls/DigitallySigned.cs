// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DigitallySigned
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class DigitallySigned
{
  private readonly SignatureAndHashAlgorithm m_algorithm;
  private readonly byte[] m_signature;

  public DigitallySigned(SignatureAndHashAlgorithm algorithm, byte[] signature)
  {
    if (signature == null)
      throw new ArgumentNullException(nameof (signature));
    this.m_algorithm = algorithm;
    this.m_signature = signature;
  }

  public SignatureAndHashAlgorithm Algorithm => this.m_algorithm;

  public byte[] Signature => this.m_signature;

  public void Encode(Stream output)
  {
    if (this.m_algorithm != null)
      this.m_algorithm.Encode(output);
    TlsUtilities.WriteOpaque16(this.m_signature, output);
  }

  public static DigitallySigned Parse(TlsContext context, Stream input)
  {
    SignatureAndHashAlgorithm algorithm = (SignatureAndHashAlgorithm) null;
    if (TlsUtilities.IsTlsV12(context))
    {
      algorithm = SignatureAndHashAlgorithm.Parse(input);
      if (algorithm.Signature == (short) 0)
        throw new TlsFatalAlert((short) 47);
    }
    byte[] signature = TlsUtilities.ReadOpaque16(input);
    return new DigitallySigned(algorithm, signature);
  }
}
