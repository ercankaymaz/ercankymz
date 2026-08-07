// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509CrlParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Security.Certificates;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509CrlParser
{
  private static readonly PemParser PemCrlParser = new PemParser("CRL");
  private Asn1Set sCrlData;
  private int sCrlDataObjectCount;
  private Stream currentCrlStream;

  public X509CrlParser()
  {
  }

  [Obsolete("Will be removed")]
  public X509CrlParser(bool lazyAsn1)
  {
  }

  private X509Crl ReadDerCrl(Asn1InputStream dIn)
  {
    Asn1Sequence asn1Sequence = (Asn1Sequence) dIn.ReadObject();
    if (asn1Sequence.Count <= 1 || !(asn1Sequence[0] is DerObjectIdentifier) || !asn1Sequence[0].Equals((object) PkcsObjectIdentifiers.SignedData))
      return new X509Crl(CertificateList.GetInstance((object) asn1Sequence));
    this.sCrlData = SignedData.GetInstance((object) Asn1Sequence.GetInstance((Asn1TaggedObject) asn1Sequence[1], true)).Crls;
    return this.GetCrl();
  }

  private X509Crl ReadPemCrl(Stream inStream)
  {
    Asn1Sequence asn1Sequence = X509CrlParser.PemCrlParser.ReadPemObject(inStream);
    return asn1Sequence != null ? new X509Crl(CertificateList.GetInstance((object) asn1Sequence)) : (X509Crl) null;
  }

  private X509Crl GetCrl()
  {
    return this.sCrlData != null && this.sCrlDataObjectCount < this.sCrlData.Count ? new X509Crl(CertificateList.GetInstance((object) this.sCrlData[this.sCrlDataObjectCount++])) : (X509Crl) null;
  }

  public X509Crl ReadCrl(byte[] input) => this.ReadCrl((Stream) new MemoryStream(input, false));

  public IList<X509Crl> ReadCrls(byte[] input)
  {
    return this.ReadCrls((Stream) new MemoryStream(input, false));
  }

  public X509Crl ReadCrl(Stream inStream)
  {
    if (inStream == null)
      throw new ArgumentNullException(nameof (inStream));
    if (!inStream.CanRead)
      throw new ArgumentException("inStream must be read-able", nameof (inStream));
    if (this.currentCrlStream == null)
    {
      this.currentCrlStream = inStream;
      this.sCrlData = (Asn1Set) null;
      this.sCrlDataObjectCount = 0;
    }
    else if (this.currentCrlStream != inStream)
    {
      this.currentCrlStream = inStream;
      this.sCrlData = (Asn1Set) null;
      this.sCrlDataObjectCount = 0;
    }
    try
    {
      if (this.sCrlData != null)
      {
        if (this.sCrlDataObjectCount != this.sCrlData.Count)
          return this.GetCrl();
        this.sCrlData = (Asn1Set) null;
        this.sCrlDataObjectCount = 0;
        return (X509Crl) null;
      }
      int b = inStream.ReadByte();
      if (b < 0)
        return (X509Crl) null;
      if (inStream.CanSeek)
      {
        inStream.Seek(-1L, SeekOrigin.Current);
      }
      else
      {
        PushbackStream pushbackStream = new PushbackStream(inStream);
        pushbackStream.Unread(b);
        inStream = (Stream) pushbackStream;
      }
      if (b != 48 /*0x30*/)
        return this.ReadPemCrl(inStream);
      using (Asn1InputStream dIn = new Asn1InputStream(inStream, int.MaxValue, true))
        return this.ReadDerCrl(dIn);
    }
    catch (CrlException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new CrlException(ex.ToString());
    }
  }

  public IList<X509Crl> ReadCrls(Stream inStream)
  {
    return (IList<X509Crl>) new List<X509Crl>(this.ParseCrls(inStream));
  }

  public IEnumerable<X509Crl> ParseCrls(Stream inStream)
  {
    X509Crl crl;
    while ((crl = this.ReadCrl(inStream)) != null)
      yield return crl;
  }
}
