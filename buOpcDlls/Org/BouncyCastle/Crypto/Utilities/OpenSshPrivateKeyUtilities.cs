// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.OpenSshPrivateKeyUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Utilities;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public static class OpenSshPrivateKeyUtilities
{
  private static readonly byte[] AUTH_MAGIC = Encoding.ASCII.GetBytes("openssh-key-v1\0");

  public static byte[] EncodePrivateKey(AsymmetricKeyParameter parameters)
  {
    switch (parameters)
    {
      case null:
        throw new ArgumentNullException(nameof (parameters));
      case RsaPrivateCrtKeyParameters _:
      case ECPrivateKeyParameters _:
        return PrivateKeyInfoFactory.CreatePrivateKeyInfo(parameters).ParsePrivateKey().GetEncoded();
      case DsaPrivateKeyParameters privateKeyParameters1:
        DsaParameters parameters1 = privateKeyParameters1.Parameters;
        Asn1EncodableVector elementVector = new Asn1EncodableVector()
        {
          (Asn1Encodable) new DerInteger(0),
          (Asn1Encodable) new DerInteger(parameters1.P),
          (Asn1Encodable) new DerInteger(parameters1.Q),
          (Asn1Encodable) new DerInteger(parameters1.G)
        };
        BigInteger bigInteger = parameters1.P.ModPow(privateKeyParameters1.X, parameters1.P);
        elementVector.Add((Asn1Encodable) new DerInteger(bigInteger));
        elementVector.Add((Asn1Encodable) new DerInteger(privateKeyParameters1.X));
        try
        {
          return new DerSequence(elementVector).GetEncoded();
        }
        catch (Exception ex)
        {
          throw new InvalidOperationException("unable to encode DSAPrivateKeyParameters " + ex.Message);
        }
      case Ed25519PrivateKeyParameters privateKeyParameters2:
        Ed25519PublicKeyParameters publicKey = privateKeyParameters2.GeneratePublicKey();
        SshBuilder sshBuilder1 = new SshBuilder();
        sshBuilder1.WriteBytes(OpenSshPrivateKeyUtilities.AUTH_MAGIC);
        sshBuilder1.WriteStringAscii("none");
        sshBuilder1.WriteStringAscii("none");
        sshBuilder1.WriteStringAscii("");
        sshBuilder1.U32(1U);
        sshBuilder1.WriteBlock(OpenSshPublicKeyUtilities.EncodePublicKey((AsymmetricKeyParameter) publicKey));
        SshBuilder sshBuilder2 = new SshBuilder();
        int num = CryptoServicesRegistrar.GetSecureRandom().NextInt();
        sshBuilder2.U32((uint) num);
        sshBuilder2.U32((uint) num);
        sshBuilder2.WriteStringAscii("ssh-ed25519");
        byte[] encoded = publicKey.GetEncoded();
        sshBuilder2.WriteBlock(encoded);
        sshBuilder2.WriteBlock(Arrays.Concatenate(privateKeyParameters2.GetEncoded(), encoded));
        sshBuilder2.WriteStringUtf8("");
        sshBuilder1.WriteBlock(sshBuilder2.GetPaddedBytes());
        return sshBuilder1.GetBytes();
      default:
        throw new ArgumentException($"unable to convert {Platform.GetTypeName((object) parameters)} to openssh private key");
    }
  }

  public static AsymmetricKeyParameter ParsePrivateKeyBlob(byte[] blob)
  {
    AsymmetricKeyParameter asymmetricKeyParameter = (AsymmetricKeyParameter) null;
    if (blob[0] == (byte) 48 /*0x30*/)
    {
      Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) blob);
      if (instance1.Count == 6)
      {
        if (OpenSshPrivateKeyUtilities.AllIntegers(instance1) && ((DerInteger) instance1[0]).PositiveValue.Equals(BigIntegers.Zero))
          asymmetricKeyParameter = (AsymmetricKeyParameter) new DsaPrivateKeyParameters(((DerInteger) instance1[5]).PositiveValue, new DsaParameters(((DerInteger) instance1[1]).PositiveValue, ((DerInteger) instance1[2]).PositiveValue, ((DerInteger) instance1[3]).PositiveValue));
      }
      else if (instance1.Count == 9)
      {
        if (OpenSshPrivateKeyUtilities.AllIntegers(instance1) && ((DerInteger) instance1[0]).PositiveValue.Equals(BigIntegers.Zero))
        {
          RsaPrivateKeyStructure instance2 = RsaPrivateKeyStructure.GetInstance((object) instance1);
          asymmetricKeyParameter = (AsymmetricKeyParameter) new RsaPrivateCrtKeyParameters(instance2.Modulus, instance2.PublicExponent, instance2.PrivateExponent, instance2.Prime1, instance2.Prime2, instance2.Exponent1, instance2.Exponent2, instance2.Coefficient);
        }
      }
      else if (instance1.Count == 4 && instance1[3] is Asn1TaggedObject && instance1[2] is Asn1TaggedObject)
      {
        ECPrivateKeyStructure instance3 = ECPrivateKeyStructure.GetInstance((object) instance1);
        DerObjectIdentifier instance4 = DerObjectIdentifier.GetInstance((object) instance3.GetParameters());
        X9ECParameters byOid = ECNamedCurveTable.GetByOid(instance4);
        asymmetricKeyParameter = (AsymmetricKeyParameter) new ECPrivateKeyParameters(instance3.GetKey(), (ECDomainParameters) new ECNamedDomainParameters(instance4, byOid));
      }
    }
    else
    {
      SshBuffer sshBuffer1 = new SshBuffer(OpenSshPrivateKeyUtilities.AUTH_MAGIC, blob);
      if (!"none".Equals(sshBuffer1.ReadStringAscii()))
        throw new InvalidOperationException("encrypted keys not supported");
      sshBuffer1.SkipBlock();
      sshBuffer1.SkipBlock();
      if (sshBuffer1.ReadU32() != 1)
        throw new InvalidOperationException("multiple keys not supported");
      OpenSshPublicKeyUtilities.ParsePublicKey(sshBuffer1.ReadBlock());
      byte[] buffer = sshBuffer1.ReadPaddedBlock();
      if (sshBuffer1.HasRemaining())
        throw new InvalidOperationException("decoded key has trailing data");
      SshBuffer sshBuffer2 = new SshBuffer(buffer);
      string str = sshBuffer2.ReadU32() == sshBuffer2.ReadU32() ? sshBuffer2.ReadStringAscii() : throw new InvalidOperationException("private key check values are not the same");
      if ("ssh-ed25519".Equals(str))
      {
        sshBuffer2.SkipBlock();
        byte[] buf = sshBuffer2.ReadBlock();
        if (buf.Length != Ed25519PrivateKeyParameters.KeySize + Ed25519PublicKeyParameters.KeySize)
          throw new InvalidOperationException("private key value of wrong length");
        asymmetricKeyParameter = (AsymmetricKeyParameter) new Ed25519PrivateKeyParameters(buf, 0);
      }
      else if (str.StartsWith("ecdsa"))
      {
        DerObjectIdentifier objectIdentifier = SshNamedCurves.GetOid(sshBuffer2.ReadStringAscii()) ?? throw new InvalidOperationException("OID not found for: " + str);
        X9ECParameters x9 = SshNamedCurves.GetByOid(objectIdentifier) ?? throw new InvalidOperationException("Curve not found for: " + objectIdentifier?.ToString());
        sshBuffer2.SkipBlock();
        asymmetricKeyParameter = (AsymmetricKeyParameter) new ECPrivateKeyParameters(sshBuffer2.ReadMpintPositive(), (ECDomainParameters) new ECNamedDomainParameters(objectIdentifier, x9));
      }
      else if (str.StartsWith("ssh-rsa"))
      {
        BigInteger modulus = sshBuffer2.ReadMpintPositive();
        BigInteger publicExponent = sshBuffer2.ReadMpintPositive();
        BigInteger privateExponent = sshBuffer2.ReadMpintPositive();
        BigInteger qInv = sshBuffer2.ReadMpintPositive();
        BigInteger p = sshBuffer2.ReadMpintPositive();
        BigInteger q = sshBuffer2.ReadMpintPositive();
        BigInteger n1 = p.Subtract(BigIntegers.One);
        BigInteger n2 = q.Subtract(BigIntegers.One);
        BigInteger dP = privateExponent.Remainder(n1);
        BigInteger dQ = privateExponent.Remainder(n2);
        asymmetricKeyParameter = (AsymmetricKeyParameter) new RsaPrivateCrtKeyParameters(modulus, publicExponent, privateExponent, p, q, dP, dQ, qInv);
      }
      sshBuffer2.SkipBlock();
      if (sshBuffer2.HasRemaining())
        throw new ArgumentException("private key block has trailing data");
    }
    return asymmetricKeyParameter ?? throw new ArgumentException("unable to parse key");
  }

  private static bool AllIntegers(Asn1Sequence sequence)
  {
    for (int index = 0; index < sequence.Count; ++index)
    {
      if (!(sequence[index] is DerInteger))
        return false;
    }
    return true;
  }
}
