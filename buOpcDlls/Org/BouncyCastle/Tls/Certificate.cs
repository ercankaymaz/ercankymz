// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Certificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class Certificate
{
  private static readonly TlsCertificate[] EmptyCerts = new TlsCertificate[0];
  private static readonly CertificateEntry[] EmptyCertEntries = new CertificateEntry[0];
  public static readonly Certificate EmptyChain = new Certificate(Certificate.EmptyCerts);
  public static readonly Certificate EmptyChainTls13 = new Certificate(TlsUtilities.EmptyBytes, Certificate.EmptyCertEntries);
  private readonly byte[] m_certificateRequestContext;
  private readonly CertificateEntry[] m_certificateEntryList;
  private readonly short m_certificateType;

  private static CertificateEntry[] Convert(TlsCertificate[] certificateList)
  {
    int length = !TlsUtilities.IsNullOrContainsNull((object[]) certificateList) ? certificateList.Length : throw new ArgumentException("cannot be null or contain any nulls", nameof (certificateList));
    CertificateEntry[] certificateEntryArray = new CertificateEntry[length];
    for (int index = 0; index < length; ++index)
      certificateEntryArray[index] = new CertificateEntry(certificateList[index], (IDictionary<int, byte[]>) null);
    return certificateEntryArray;
  }

  public Certificate(TlsCertificate[] certificateList)
    : this((byte[]) null, Certificate.Convert(certificateList))
  {
  }

  public Certificate(byte[] certificateRequestContext, CertificateEntry[] certificateEntryList)
    : this((short) 0, certificateRequestContext, certificateEntryList)
  {
  }

  public Certificate(
    short certificateType,
    byte[] certificateRequestContext,
    CertificateEntry[] certificateEntryList)
  {
    if (certificateRequestContext != null && !TlsUtilities.IsValidUint8(certificateRequestContext.Length))
      throw new ArgumentException("cannot be longer than 255", nameof (certificateRequestContext));
    if (TlsUtilities.IsNullOrContainsNull((object[]) certificateEntryList))
      throw new ArgumentException("cannot be null or contain any nulls", nameof (certificateEntryList));
    this.m_certificateRequestContext = TlsUtilities.Clone(certificateRequestContext);
    this.m_certificateEntryList = certificateEntryList;
    this.m_certificateType = certificateType;
  }

  public byte[] GetCertificateRequestContext()
  {
    return TlsUtilities.Clone(this.m_certificateRequestContext);
  }

  public TlsCertificate[] GetCertificateList() => this.CloneCertificateList();

  public TlsCertificate GetCertificateAt(int index)
  {
    return this.m_certificateEntryList[index].Certificate;
  }

  public CertificateEntry GetCertificateEntryAt(int index) => this.m_certificateEntryList[index];

  public CertificateEntry[] GetCertificateEntryList() => this.CloneCertificateEntryList();

  public short CertificateType => this.m_certificateType;

  public int Length => this.m_certificateEntryList.Length;

  public bool IsEmpty => this.m_certificateEntryList.Length == 0;

  public void Encode(TlsContext context, Stream messageOutput, Stream endPointHashOutput)
  {
    bool flag = TlsUtilities.IsTlsV13(context);
    if (this.m_certificateRequestContext != null != flag)
      throw new InvalidOperationException();
    if (flag)
      TlsUtilities.WriteOpaque8(this.m_certificateRequestContext, messageOutput);
    int length = this.m_certificateEntryList.Length;
    List<byte[]> numArrayList1 = new List<byte[]>(length);
    List<byte[]> numArrayList2 = flag ? new List<byte[]>(length) : (List<byte[]>) null;
    long i = 0;
    for (int index = 0; index < length; ++index)
    {
      CertificateEntry certificateEntry = this.m_certificateEntryList[index];
      TlsCertificate certificate = certificateEntry.Certificate;
      byte[] encoded = certificate.GetEncoded();
      if (index == 0 && endPointHashOutput != null)
        Certificate.CalculateEndPointHash(context, certificate, encoded, endPointHashOutput);
      numArrayList1.Add(encoded);
      i = i + (long) encoded.Length + 3L;
      if (flag)
      {
        IDictionary<int, byte[]> extensions = certificateEntry.Extensions;
        byte[] numArray = extensions == null ? TlsUtilities.EmptyBytes : TlsProtocol.WriteExtensionsData(extensions);
        numArrayList2.Add(numArray);
        i = i + (long) numArray.Length + 2L;
      }
    }
    if (flag || this.m_certificateType != (short) 2)
    {
      TlsUtilities.CheckUint24(i);
      TlsUtilities.WriteUint24((int) i, messageOutput);
    }
    for (int index = 0; index < length; ++index)
    {
      TlsUtilities.WriteOpaque24(numArrayList1[index], messageOutput);
      if (flag)
        TlsUtilities.WriteOpaque16(numArrayList2[index], messageOutput);
    }
  }

  public static Certificate Parse(
    Certificate.ParseOptions options,
    TlsContext context,
    Stream messageInput,
    Stream endPointHashOutput)
  {
    bool flag = TlsUtilities.IsTlsV13(context.SecurityParameters.NegotiatedVersion);
    short certificateType = options.CertificateType;
    byte[] certificateRequestContext = (byte[]) null;
    if (flag)
      certificateRequestContext = TlsUtilities.ReadOpaque8(messageInput);
    int num1 = TlsUtilities.ReadUint24(messageInput);
    if (num1 == 0)
    {
      if (!flag)
        return Certificate.EmptyChain;
      return certificateRequestContext.Length >= 1 ? new Certificate(certificateType, certificateRequestContext, Certificate.EmptyCertEntries) : Certificate.EmptyChainTls13;
    }
    byte[] buffer = TlsUtilities.ReadFully(num1, messageInput);
    MemoryStream input = new MemoryStream(buffer, false);
    TlsCrypto crypto = context.Crypto;
    int num2 = Math.Max(1, options.MaxChainLength);
    List<CertificateEntry> certificateEntryList1 = new List<CertificateEntry>();
    while (input.Position < input.Length)
    {
      if (certificateEntryList1.Count >= num2)
        throw new TlsFatalAlert((short) 80 /*0x50*/, $"Certificate chain longer than maximum ({num2.ToString()})");
      byte[] encoding;
      if (!flag && certificateType == (short) 2)
      {
        encoding = buffer;
        input.Seek((long) num1, SeekOrigin.Current);
      }
      else
        encoding = TlsUtilities.ReadOpaque24((Stream) input, 1);
      TlsCertificate certificate = crypto.CreateCertificate(certificateType, encoding);
      if (certificateEntryList1.Count < 1 && endPointHashOutput != null)
        Certificate.CalculateEndPointHash(context, certificate, encoding, endPointHashOutput);
      IDictionary<int, byte[]> extensions = (IDictionary<int, byte[]>) null;
      if (flag)
        extensions = TlsProtocol.ReadExtensionsData13(11, TlsUtilities.ReadOpaque16((Stream) input));
      certificateEntryList1.Add(new CertificateEntry(certificate, extensions));
    }
    CertificateEntry[] certificateEntryList2 = new CertificateEntry[certificateEntryList1.Count];
    for (int index = 0; index < certificateEntryList1.Count; ++index)
      certificateEntryList2[index] = certificateEntryList1[index];
    return new Certificate(certificateType, certificateRequestContext, certificateEntryList2);
  }

  private static void CalculateEndPointHash(
    TlsContext context,
    TlsCertificate cert,
    byte[] encoding,
    Stream output)
  {
    byte[] endPointHash = TlsUtilities.CalculateEndPointHash(context, cert, encoding);
    if (endPointHash == null || endPointHash.Length == 0)
      return;
    output.Write(endPointHash, 0, endPointHash.Length);
  }

  private TlsCertificate[] CloneCertificateList()
  {
    int length = this.m_certificateEntryList.Length;
    if (length == 0)
      return Certificate.EmptyCerts;
    TlsCertificate[] tlsCertificateArray = new TlsCertificate[length];
    for (int index = 0; index < length; ++index)
      tlsCertificateArray[index] = this.m_certificateEntryList[index].Certificate;
    return tlsCertificateArray;
  }

  private CertificateEntry[] CloneCertificateEntryList()
  {
    int length = this.m_certificateEntryList.Length;
    if (length == 0)
      return Certificate.EmptyCertEntries;
    CertificateEntry[] destinationArray = new CertificateEntry[length];
    Array.Copy((Array) this.m_certificateEntryList, 0, (Array) destinationArray, 0, length);
    return destinationArray;
  }

  public sealed class ParseOptions
  {
    public short CertificateType { get; set; }

    public int MaxChainLength { get; set; } = int.MaxValue;
  }
}
