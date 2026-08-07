// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CertificateUrl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class CertificateUrl
{
  private readonly short m_type;
  private readonly IList<UrlAndHash> m_urlAndHashList;

  public CertificateUrl(short type, IList<UrlAndHash> urlAndHashList)
  {
    if (!CertChainType.IsValid(type))
      throw new ArgumentException("not a valid CertChainType value", nameof (type));
    if (urlAndHashList == null || urlAndHashList.Count < 1)
      throw new ArgumentException("must have length > 0", nameof (urlAndHashList));
    if (type == (short) 1 && urlAndHashList.Count != 1)
      throw new ArgumentException("must contain exactly one entry when type is " + CertChainType.GetText(type), nameof (urlAndHashList));
    this.m_type = type;
    this.m_urlAndHashList = urlAndHashList;
  }

  public short Type => this.m_type;

  public IList<UrlAndHash> UrlAndHashList => this.m_urlAndHashList;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.m_type, output);
    CertificateUrl.ListBuffer16 output1 = new CertificateUrl.ListBuffer16();
    foreach (UrlAndHash urlAndHash in (IEnumerable<UrlAndHash>) this.m_urlAndHashList)
      urlAndHash.Encode((Stream) output1);
    output1.EncodeTo(output);
  }

  public static CertificateUrl Parse(TlsContext context, Stream input)
  {
    short num = TlsUtilities.ReadUint8(input);
    if (!CertChainType.IsValid(num))
      throw new TlsFatalAlert((short) 50);
    int length = TlsUtilities.ReadUint16(input);
    MemoryStream input1 = length >= 1 ? new MemoryStream(TlsUtilities.ReadFully(length, input), false) : throw new TlsFatalAlert((short) 50);
    List<UrlAndHash> urlAndHashList = new List<UrlAndHash>();
    while (input1.Position < input1.Length)
    {
      UrlAndHash urlAndHash = UrlAndHash.Parse(context, (Stream) input1);
      urlAndHashList.Add(urlAndHash);
    }
    if (num == (short) 1 && urlAndHashList.Count != 1)
      throw new TlsFatalAlert((short) 50);
    return new CertificateUrl(num, (IList<UrlAndHash>) urlAndHashList);
  }

  internal class ListBuffer16 : MemoryStream
  {
    internal ListBuffer16() => TlsUtilities.WriteUint16(0, (Stream) this);

    internal void EncodeTo(Stream output)
    {
      int i = Convert.ToInt32(this.Length) - 2;
      TlsUtilities.CheckUint16(i);
      this.Seek(0L, SeekOrigin.Begin);
      TlsUtilities.WriteUint16(i, (Stream) this);
      this.WriteTo(output);
      this.Dispose();
    }
  }
}
