// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.OpenSshPublicKeyUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public static class OpenSshPublicKeyUtilities
{
  private static readonly string RSA = "ssh-rsa";
  private static readonly string ECDSA = "ecdsa";
  private static readonly string ED_25519 = "ssh-ed25519";
  private static readonly string DSS = "ssh-dss";

  public static AsymmetricKeyParameter ParsePublicKey(byte[] encoded)
  {
    return OpenSshPublicKeyUtilities.ParsePublicKey(new SshBuffer(encoded));
  }

  public static byte[] EncodePublicKey(AsymmetricKeyParameter cipherParameters)
  {
    if (cipherParameters == null)
      throw new ArgumentNullException(nameof (cipherParameters));
    if (cipherParameters.IsPrivate)
      throw new ArgumentException("Not a public key", nameof (cipherParameters));
    switch (cipherParameters)
    {
      case RsaKeyParameters rsaKeyParameters:
        SshBuilder sshBuilder1 = new SshBuilder();
        sshBuilder1.WriteStringAscii(OpenSshPublicKeyUtilities.RSA);
        sshBuilder1.WriteMpint(rsaKeyParameters.Exponent);
        sshBuilder1.WriteMpint(rsaKeyParameters.Modulus);
        return sshBuilder1.GetBytes();
      case ECPublicKeyParameters publicKeyParameters1:
        string str = (string) null;
        DerObjectIdentifier publicKeyParamSet = publicKeyParameters1.PublicKeyParamSet;
        if (publicKeyParamSet != null)
          str = SshNamedCurves.GetName(publicKeyParamSet);
        if (str == null)
          throw new ArgumentException("unable to derive ssh curve name for EC public key");
        SshBuilder sshBuilder2 = new SshBuilder();
        sshBuilder2.WriteStringAscii($"{OpenSshPublicKeyUtilities.ECDSA}-sha2-{str}");
        sshBuilder2.WriteStringAscii(str);
        sshBuilder2.WriteBlock(publicKeyParameters1.Q.GetEncoded(false));
        return sshBuilder2.GetBytes();
      case DsaPublicKeyParameters publicKeyParameters2:
        DsaParameters parameters = publicKeyParameters2.Parameters;
        SshBuilder sshBuilder3 = new SshBuilder();
        sshBuilder3.WriteStringAscii(OpenSshPublicKeyUtilities.DSS);
        sshBuilder3.WriteMpint(parameters.P);
        sshBuilder3.WriteMpint(parameters.Q);
        sshBuilder3.WriteMpint(parameters.G);
        sshBuilder3.WriteMpint(publicKeyParameters2.Y);
        return sshBuilder3.GetBytes();
      case Ed25519PublicKeyParameters publicKeyParameters3:
        SshBuilder sshBuilder4 = new SshBuilder();
        sshBuilder4.WriteStringAscii(OpenSshPublicKeyUtilities.ED_25519);
        sshBuilder4.WriteBlock(publicKeyParameters3.GetEncoded());
        return sshBuilder4.GetBytes();
      default:
        throw new ArgumentException($"unable to convert {Platform.GetTypeName((object) cipherParameters)} to private key");
    }
  }

  private static AsymmetricKeyParameter ParsePublicKey(SshBuffer buffer)
  {
    AsymmetricKeyParameter publicKey = (AsymmetricKeyParameter) null;
    string str = buffer.ReadStringAscii();
    if (OpenSshPublicKeyUtilities.RSA.Equals(str))
    {
      BigInteger exponent = buffer.ReadMpintPositive();
      publicKey = (AsymmetricKeyParameter) new RsaKeyParameters(false, buffer.ReadMpintPositive(), exponent);
    }
    else if (OpenSshPublicKeyUtilities.DSS.Equals(str))
    {
      BigInteger p = buffer.ReadMpintPositive();
      BigInteger q = buffer.ReadMpintPositive();
      BigInteger g = buffer.ReadMpintPositive();
      publicKey = (AsymmetricKeyParameter) new DsaPublicKeyParameters(buffer.ReadMpintPositive(), new DsaParameters(p, q, g));
    }
    else if (str.StartsWith(OpenSshPublicKeyUtilities.ECDSA))
    {
      string name = buffer.ReadStringAscii();
      DerObjectIdentifier oid = SshNamedCurves.GetOid(name);
      X9ECParameters byOid = oid == null ? (X9ECParameters) null : SshNamedCurves.GetByOid(oid);
      if (byOid == null)
        throw new InvalidOperationException($"unable to find curve for {str} using curve name {name}");
      byte[] encoded = buffer.ReadBlock();
      publicKey = (AsymmetricKeyParameter) new ECPublicKeyParameters(byOid.Curve.DecodePoint(encoded), (ECDomainParameters) new ECNamedDomainParameters(oid, byOid));
    }
    else if (OpenSshPublicKeyUtilities.ED_25519.Equals(str))
      publicKey = (AsymmetricKeyParameter) new Ed25519PublicKeyParameters(buffer.ReadBlock());
    if (publicKey == null)
      throw new ArgumentException("unable to parse key");
    if (buffer.HasRemaining())
      throw new ArgumentException("decoded key has trailing data");
    return publicKey;
  }
}
