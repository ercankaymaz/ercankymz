// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.TrustAnchor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class TrustAnchor
{
  private readonly AsymmetricKeyParameter pubKey;
  private readonly string caName;
  private readonly X509Name caPrincipal;
  private readonly X509Certificate trustedCert;
  private byte[] ncBytes;
  private NameConstraints nc;

  public TrustAnchor(X509Certificate trustedCert, byte[] nameConstraints)
  {
    this.trustedCert = trustedCert != null ? trustedCert : throw new ArgumentNullException(nameof (trustedCert));
    this.pubKey = (AsymmetricKeyParameter) null;
    this.caName = (string) null;
    this.caPrincipal = (X509Name) null;
    this.setNameConstraints(nameConstraints);
  }

  public TrustAnchor(X509Name caPrincipal, AsymmetricKeyParameter pubKey, byte[] nameConstraints)
  {
    if (caPrincipal == null)
      throw new ArgumentNullException(nameof (caPrincipal));
    if (pubKey == null)
      throw new ArgumentNullException(nameof (pubKey));
    this.trustedCert = (X509Certificate) null;
    this.caPrincipal = caPrincipal;
    this.caName = caPrincipal.ToString();
    this.pubKey = pubKey;
    this.setNameConstraints(nameConstraints);
  }

  public TrustAnchor(string caName, AsymmetricKeyParameter pubKey, byte[] nameConstraints)
  {
    if (caName == null)
      throw new ArgumentNullException(nameof (caName));
    if (pubKey == null)
      throw new ArgumentNullException(nameof (pubKey));
    this.caPrincipal = caName.Length != 0 ? new X509Name(caName) : throw new ArgumentException("caName can not be an empty string");
    this.pubKey = pubKey;
    this.caName = caName;
    this.trustedCert = (X509Certificate) null;
    this.setNameConstraints(nameConstraints);
  }

  public X509Certificate TrustedCert => this.trustedCert;

  public X509Name CA => this.caPrincipal;

  public string CAName => this.caName;

  public AsymmetricKeyParameter CAPublicKey => this.pubKey;

  private void setNameConstraints(byte[] bytes)
  {
    if (bytes == null)
    {
      this.ncBytes = (byte[]) null;
      this.nc = (NameConstraints) null;
    }
    else
    {
      this.ncBytes = (byte[]) bytes.Clone();
      this.nc = NameConstraints.GetInstance((object) Asn1Object.FromByteArray(bytes));
    }
  }

  public byte[] GetNameConstraints => Arrays.Clone(this.ncBytes);

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("[");
    if (this.pubKey != null)
    {
      stringBuilder.Append("  Trusted CA Public Key: ").Append((object) this.pubKey).AppendLine();
      stringBuilder.Append("  Trusted CA Issuer Name: ").Append(this.caName).AppendLine();
    }
    else
      stringBuilder.Append("  Trusted CA cert: ").Append((object) this.TrustedCert).AppendLine();
    if (this.nc != null)
      stringBuilder.Append("  Name Constraints: ").Append((object) this.nc).AppendLine();
    return stringBuilder.ToString();
  }
}
