// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OcspResp
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class OcspResp
{
  private OcspResponse resp;

  public OcspResp(OcspResponse resp) => this.resp = resp;

  public OcspResp(byte[] resp)
    : this(new Asn1InputStream(resp))
  {
  }

  public OcspResp(Stream inStr)
    : this(new Asn1InputStream(inStr))
  {
  }

  private OcspResp(Asn1InputStream aIn)
  {
    try
    {
      this.resp = OcspResponse.GetInstance((object) aIn.ReadObject());
    }
    catch (Exception ex)
    {
      throw new IOException("malformed response: " + ex.Message, ex);
    }
  }

  public int Status => this.resp.ResponseStatus.IntValueExact;

  public object GetResponseObject()
  {
    ResponseBytes responseBytes = this.resp.ResponseBytes;
    if (responseBytes == null)
      return (object) null;
    if (!responseBytes.ResponseType.Equals((Asn1Object) OcspObjectIdentifiers.PkixOcspBasic))
      return (object) responseBytes.Response;
    try
    {
      return (object) new BasicOcspResp(BasicOcspResponse.GetInstance((object) Asn1Object.FromByteArray(responseBytes.Response.GetOctets())));
    }
    catch (Exception ex)
    {
      throw new OcspException("problem decoding object: " + ex?.ToString(), ex);
    }
  }

  public byte[] GetEncoded() => this.resp.GetEncoded();

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is OcspResp ocspResp && this.resp.Equals((object) ocspResp.resp);
  }

  public override int GetHashCode() => this.resp.GetHashCode();
}
