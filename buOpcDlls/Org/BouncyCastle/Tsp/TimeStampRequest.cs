// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampRequest : X509ExtensionBase
{
  private TimeStampReq req;
  private X509Extensions extensions;

  public TimeStampRequest(TimeStampReq req)
  {
    this.req = req;
    this.extensions = req.Extensions;
  }

  public TimeStampRequest(byte[] req)
    : this(new Asn1InputStream(req))
  {
  }

  public TimeStampRequest(Stream input)
    : this(new Asn1InputStream(input))
  {
  }

  private TimeStampRequest(Asn1InputStream str)
  {
    try
    {
      this.req = TimeStampReq.GetInstance((object) str.ReadObject());
    }
    catch (InvalidCastException ex)
    {
      throw new IOException("malformed request: " + ex?.ToString());
    }
    catch (ArgumentException ex)
    {
      throw new IOException("malformed request: " + ex?.ToString());
    }
  }

  public int Version => this.req.Version.IntValueExact;

  public string MessageImprintAlgOid => this.req.MessageImprint.HashAlgorithm.Algorithm.Id;

  public byte[] GetMessageImprintDigest() => this.req.MessageImprint.GetHashedMessage();

  public string ReqPolicy => this.req.ReqPolicy != null ? this.req.ReqPolicy.Id : (string) null;

  public BigInteger Nonce => this.req.Nonce != null ? this.req.Nonce.Value : (BigInteger) null;

  public bool CertReq => this.req.CertReq != null && this.req.CertReq.IsTrue;

  public void Validate(IList<string> algorithms, IList<string> policies, IList<string> extensions)
  {
    if (!algorithms.Contains(this.MessageImprintAlgOid))
      throw new TspValidationException("request contains unknown algorithm", 128 /*0x80*/);
    if (policies != null && this.ReqPolicy != null && !policies.Contains(this.ReqPolicy))
      throw new TspValidationException("request contains unknown policy", 256 /*0x0100*/);
    if (this.Extensions != null && extensions != null)
    {
      foreach (DerObjectIdentifier extensionOid in this.Extensions.ExtensionOids)
      {
        if (!extensions.Contains(extensionOid.Id))
          throw new TspValidationException("request contains unknown extension", 8388608 /*0x800000*/);
      }
    }
    if (TspUtil.GetDigestLength(this.MessageImprintAlgOid) != this.GetMessageImprintDigest().Length)
      throw new TspValidationException("imprint digest the wrong length", 4);
  }

  public byte[] GetEncoded() => this.req.GetEncoded();

  internal X509Extensions Extensions => this.req.Extensions;

  public virtual bool HasExtensions => this.extensions != null;

  public virtual X509Extension GetExtension(DerObjectIdentifier oid)
  {
    return this.extensions != null ? this.extensions.GetExtension(oid) : (X509Extension) null;
  }

  public virtual IList<DerObjectIdentifier> GetExtensionOids()
  {
    return TspUtil.GetExtensionOids(this.extensions);
  }

  protected override X509Extensions GetX509Extensions() => this.Extensions;
}
