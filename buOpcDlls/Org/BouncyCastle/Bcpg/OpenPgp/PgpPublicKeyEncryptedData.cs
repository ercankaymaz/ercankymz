// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPublicKeyEncryptedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cryptlib;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpPublicKeyEncryptedData : PgpEncryptedData
{
  private PublicKeyEncSessionPacket keyData;

  internal PgpPublicKeyEncryptedData(PublicKeyEncSessionPacket keyData, InputStreamPacket encData)
    : base(encData)
  {
    this.keyData = keyData;
  }

  private static IBufferedCipher GetKeyCipher(PublicKeyAlgorithmTag algorithm)
  {
    try
    {
      switch (algorithm)
      {
        case PublicKeyAlgorithmTag.RsaGeneral:
        case PublicKeyAlgorithmTag.RsaEncrypt:
          return CipherUtilities.GetCipher("RSA//PKCS1Padding");
        case PublicKeyAlgorithmTag.ElGamalEncrypt:
        case PublicKeyAlgorithmTag.ElGamalGeneral:
          return CipherUtilities.GetCipher("ElGamal/ECB/PKCS1Padding");
        default:
          throw new PgpException("unknown asymmetric algorithm: " + algorithm.ToString());
      }
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("Exception creating cipher", ex);
    }
  }

  private bool ConfirmCheckSum(byte[] sessionInfo)
  {
    int num = 0;
    for (int index = 1; index != sessionInfo.Length - 2; ++index)
      num += (int) sessionInfo[index] & (int) byte.MaxValue;
    return (int) sessionInfo[sessionInfo.Length - 2] == (int) (byte) (num >> 8) && (int) sessionInfo[sessionInfo.Length - 1] == (int) (byte) num;
  }

  public long KeyId => this.keyData.KeyId;

  public SymmetricKeyAlgorithmTag GetSymmetricAlgorithm(PgpPrivateKey privKey)
  {
    return (SymmetricKeyAlgorithmTag) this.RecoverSessionData(privKey)[0];
  }

  public Stream GetDataStream(PgpPrivateKey privKey)
  {
    byte[] numArray1 = this.RecoverSessionData(privKey);
    SymmetricKeyAlgorithmTag algorithm = this.ConfirmCheckSum(numArray1) ? (SymmetricKeyAlgorithmTag) numArray1[0] : throw new PgpKeyValidationException("key checksum failed");
    if (algorithm == SymmetricKeyAlgorithmTag.Null)
      return (Stream) this.encData.GetInputStream();
    string symmetricCipherName = PgpUtilities.GetSymmetricCipherName(algorithm);
    string str = symmetricCipherName;
    IBufferedCipher cipher;
    try
    {
      cipher = CipherUtilities.GetCipher(!(this.encData is SymmetricEncIntegrityPacket) ? str + "/OpenPGPCFB/NoPadding" : str + "/CFB/NoPadding");
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("exception creating cipher", ex);
    }
    try
    {
      KeyParameter keyParameter = ParameterUtilities.CreateKeyParameter(symmetricCipherName, numArray1, 1, numArray1.Length - 3);
      byte[] numArray2 = new byte[cipher.GetBlockSize()];
      cipher.Init(false, (ICipherParameters) new ParametersWithIV((ICipherParameters) keyParameter, numArray2));
      this.encStream = (Stream) BcpgInputStream.Wrap((Stream) new CipherStream((Stream) this.encData.GetInputStream(), cipher, (IBufferedCipher) null));
      if (this.encData is SymmetricEncIntegrityPacket)
      {
        this.truncStream = new PgpEncryptedData.TruncatedStream(this.encStream);
        this.encStream = (Stream) new DigestStream((Stream) this.truncStream, PgpUtilities.CreateDigest(HashAlgorithmTag.Sha1), (IDigest) null);
      }
      if (Streams.ReadFully(this.encStream, numArray2, 0, numArray2.Length) < numArray2.Length)
        throw new EndOfStreamException("unexpected end of stream.");
      int num1 = this.encStream.ReadByte();
      int num2 = this.encStream.ReadByte();
      if (num1 < 0 || num2 < 0)
        throw new EndOfStreamException("unexpected end of stream.");
      return this.encStream;
    }
    catch (PgpException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new PgpException("Exception starting decryption", ex);
    }
  }

  private byte[] RecoverSessionData(PgpPrivateKey privKey)
  {
    byte[][] encSessionKey = this.keyData.GetEncSessionKey();
    if (this.keyData.Algorithm != PublicKeyAlgorithmTag.ECDH)
    {
      IBufferedCipher keyCipher = PgpPublicKeyEncryptedData.GetKeyCipher(this.keyData.Algorithm);
      try
      {
        keyCipher.Init(false, (ICipherParameters) privKey.Key);
      }
      catch (InvalidKeyException ex)
      {
        throw new PgpException("error setting asymmetric cipher", (Exception) ex);
      }
      if (this.keyData.Algorithm != PublicKeyAlgorithmTag.RsaEncrypt && this.keyData.Algorithm != PublicKeyAlgorithmTag.RsaGeneral)
      {
        int size = (((ElGamalKeyParameters) privKey.Key).Parameters.P.BitLength + 7) / 8;
        PgpPublicKeyEncryptedData.ProcessEncodedMpi(keyCipher, size, encSessionKey[0]);
        PgpPublicKeyEncryptedData.ProcessEncodedMpi(keyCipher, size, encSessionKey[1]);
      }
      else
      {
        byte[] input = encSessionKey[0];
        keyCipher.ProcessBytes(input, 2, input.Length - 2);
      }
      try
      {
        return keyCipher.DoFinal();
      }
      catch (Exception ex)
      {
        throw new PgpException("exception decrypting secret key", ex);
      }
    }
    else
    {
      ECDHPublicBcpgKey key = (ECDHPublicBcpgKey) privKey.PublicKeyPacket.Key;
      byte[] sourceArray = encSessionKey[0];
      int length1 = ((((int) sourceArray[0] & (int) byte.MaxValue) << 8) + ((int) sourceArray[1] & (int) byte.MaxValue) + 7) / 8;
      if (2 + length1 + 1 > sourceArray.Length)
        throw new PgpException("encoded length out of range");
      byte[] numArray1 = new byte[length1];
      Array.Copy((Array) sourceArray, 2, (Array) numArray1, 0, length1);
      int length2 = (int) sourceArray[length1 + 2];
      if (2 + length1 + 1 + length2 > sourceArray.Length)
        throw new PgpException("encoded length out of range");
      byte[] numArray2 = new byte[length2];
      Array.Copy((Array) sourceArray, 2 + length1 + 1, (Array) numArray2, 0, numArray2.Length);
      DerObjectIdentifier curveOid = key.CurveOid;
      byte[] numArray3;
      if (!EdECObjectIdentifiers.id_X25519.Equals((Asn1Object) curveOid) && !CryptlibObjectIdentifiers.curvey25519.Equals((Asn1Object) curveOid))
      {
        if (EdECObjectIdentifiers.id_X448.Equals((Asn1Object) curveOid))
        {
          if (numArray1.Length != 1 + X448PublicKeyParameters.KeySize || (byte) 64 /*0x40*/ != numArray1[0])
            throw new ArgumentException("Invalid X448 public key");
          X448PublicKeyParameters publicKey = new X448PublicKeyParameters(numArray1, 1);
          X448Agreement x448Agreement = new X448Agreement();
          x448Agreement.Init((ICipherParameters) privKey.Key);
          numArray3 = new byte[x448Agreement.AgreementSize];
          x448Agreement.CalculateAgreement((ICipherParameters) publicKey, numArray3, 0);
        }
        else
        {
          ECDomainParameters parameters = ((ECKeyParameters) privKey.Key).Parameters;
          ECPublicKeyParameters pubKey = new ECPublicKeyParameters(parameters.Curve.DecodePoint(numArray1), parameters);
          ECDHBasicAgreement ecdhBasicAgreement = new ECDHBasicAgreement();
          ecdhBasicAgreement.Init((ICipherParameters) privKey.Key);
          BigInteger agreement = ecdhBasicAgreement.CalculateAgreement((ICipherParameters) pubKey);
          numArray3 = BigIntegers.AsUnsignedByteArray(ecdhBasicAgreement.GetFieldSize(), agreement);
        }
      }
      else
      {
        if (numArray1.Length != 1 + X25519PublicKeyParameters.KeySize || (byte) 64 /*0x40*/ != numArray1[0])
          throw new ArgumentException("Invalid X25519 public key");
        X25519PublicKeyParameters publicKey = new X25519PublicKeyParameters(numArray1, 1);
        X25519Agreement x25519Agreement = new X25519Agreement();
        x25519Agreement.Init((ICipherParameters) privKey.Key);
        numArray3 = new byte[x25519Agreement.AgreementSize];
        x25519Agreement.CalculateAgreement((ICipherParameters) publicKey, numArray3, 0);
      }
      KeyParameter parameters1 = new KeyParameter(Rfc6637Utilities.CreateKey(privKey.PublicKeyPacket, numArray3));
      IWrapper wrapper = PgpUtilities.CreateWrapper(key.SymmetricKeyAlgorithm);
      wrapper.Init(false, (ICipherParameters) parameters1);
      return PgpPad.UnpadSessionData(wrapper.Unwrap(numArray2, 0, numArray2.Length));
    }
  }

  private static void ProcessEncodedMpi(IBufferedCipher cipher, int size, byte[] mpiEnc)
  {
    if (mpiEnc.Length - 2 > size)
    {
      cipher.ProcessBytes(mpiEnc, 3, mpiEnc.Length - 3);
    }
    else
    {
      byte[] numArray = new byte[size];
      Array.Copy((Array) mpiEnc, 2, (Array) numArray, numArray.Length - (mpiEnc.Length - 2), mpiEnc.Length - 2);
      cipher.ProcessBytes(numArray, 0, numArray.Length);
    }
  }
}
