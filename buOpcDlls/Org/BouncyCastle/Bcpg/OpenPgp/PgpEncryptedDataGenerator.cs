// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpEncryptedDataGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cryptlib;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.IO;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpEncryptedDataGenerator : IStreamGenerator
{
  private BcpgOutputStream pOut;
  private CipherStream cOut;
  private IBufferedCipher c;
  private bool withIntegrityPacket;
  private bool oldFormat;
  private DigestStream digestOut;
  private readonly List<PgpEncryptedDataGenerator.EncMethod> methods = new List<PgpEncryptedDataGenerator.EncMethod>();
  private readonly SymmetricKeyAlgorithmTag defAlgorithm;
  private readonly SecureRandom rand;

  public PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag encAlgorithm)
  {
    this.defAlgorithm = encAlgorithm;
    this.rand = CryptoServicesRegistrar.GetSecureRandom();
  }

  public PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag encAlgorithm, bool withIntegrityPacket)
  {
    this.defAlgorithm = encAlgorithm;
    this.withIntegrityPacket = withIntegrityPacket;
    this.rand = CryptoServicesRegistrar.GetSecureRandom();
  }

  public PgpEncryptedDataGenerator(SymmetricKeyAlgorithmTag encAlgorithm, SecureRandom random)
  {
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    this.defAlgorithm = encAlgorithm;
    this.rand = random;
  }

  public PgpEncryptedDataGenerator(
    SymmetricKeyAlgorithmTag encAlgorithm,
    bool withIntegrityPacket,
    SecureRandom random)
  {
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    this.defAlgorithm = encAlgorithm;
    this.rand = random;
    this.withIntegrityPacket = withIntegrityPacket;
  }

  public PgpEncryptedDataGenerator(
    SymmetricKeyAlgorithmTag encAlgorithm,
    SecureRandom random,
    bool oldFormat)
  {
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    this.defAlgorithm = encAlgorithm;
    this.rand = random;
    this.oldFormat = oldFormat;
  }

  public void AddMethod(char[] passPhrase, HashAlgorithmTag s2kDigest)
  {
    this.DoAddMethod(PgpUtilities.EncodePassPhrase(passPhrase, false), true, s2kDigest);
  }

  public void AddMethodUtf8(char[] passPhrase, HashAlgorithmTag s2kDigest)
  {
    this.DoAddMethod(PgpUtilities.EncodePassPhrase(passPhrase, true), true, s2kDigest);
  }

  public void AddMethodRaw(byte[] rawPassPhrase, HashAlgorithmTag s2kDigest)
  {
    this.DoAddMethod(rawPassPhrase, false, s2kDigest);
  }

  internal void DoAddMethod(byte[] rawPassPhrase, bool clearPassPhrase, HashAlgorithmTag s2kDigest)
  {
    S2k s2k = PgpUtilities.GenerateS2k(s2kDigest, 96 /*0x60*/, this.rand);
    this.methods.Add((PgpEncryptedDataGenerator.EncMethod) new PgpEncryptedDataGenerator.PbeMethod(this.defAlgorithm, s2k, PgpUtilities.DoMakeKeyFromPassPhrase(this.defAlgorithm, s2k, rawPassPhrase, clearPassPhrase)));
  }

  public void AddMethod(PgpPublicKey key) => this.AddMethod(key, true);

  public void AddMethod(PgpPublicKey key, bool sessionKeyObfuscation)
  {
    if (!key.IsEncryptionKey)
      throw new ArgumentException("passed in key not an encryption key!");
    this.methods.Add((PgpEncryptedDataGenerator.EncMethod) new PgpEncryptedDataGenerator.PubMethod(key, sessionKeyObfuscation));
  }

  private void AddCheckSum(byte[] sessionInfo)
  {
    int num = 0;
    for (int index = 1; index < sessionInfo.Length - 2; ++index)
      num += (int) sessionInfo[index];
    sessionInfo[sessionInfo.Length - 2] = (byte) (num >> 8);
    sessionInfo[sessionInfo.Length - 1] = (byte) num;
  }

  private byte[] CreateSessionInfo(SymmetricKeyAlgorithmTag algorithm, KeyParameter key)
  {
    byte[] key1 = key.GetKey();
    byte[] sessionInfo = new byte[key1.Length + 3];
    sessionInfo[0] = (byte) algorithm;
    key1.CopyTo((Array) sessionInfo, 1);
    this.AddCheckSum(sessionInfo);
    return sessionInfo;
  }

  private Stream Open(Stream outStr, long length, byte[] buffer)
  {
    if (this.cOut != null)
      throw new InvalidOperationException("generator already in open state");
    if (this.methods.Count == 0)
      throw new InvalidOperationException("No encryption methods specified");
    this.pOut = outStr != null ? new BcpgOutputStream(outStr) : throw new ArgumentNullException(nameof (outStr));
    KeyParameter keyParameter;
    if (this.methods.Count == 1)
    {
      if (this.methods[0] is PgpEncryptedDataGenerator.PbeMethod method1)
      {
        keyParameter = method1.GetKey();
      }
      else
      {
        if (!(this.methods[0] is PgpEncryptedDataGenerator.PubMethod method))
          throw new InvalidOperationException();
        keyParameter = PgpUtilities.MakeRandomKey(this.defAlgorithm, this.rand);
        byte[] sessionInfo = this.CreateSessionInfo(this.defAlgorithm, keyParameter);
        try
        {
          method.AddSessionInfo(sessionInfo, this.rand);
        }
        catch (Exception ex)
        {
          throw new PgpException("exception encrypting session key", ex);
        }
      }
      this.pOut.WritePacket((ContainedPacket) this.methods[0]);
    }
    else
    {
      keyParameter = PgpUtilities.MakeRandomKey(this.defAlgorithm, this.rand);
      byte[] sessionInfo = this.CreateSessionInfo(this.defAlgorithm, keyParameter);
      foreach (PgpEncryptedDataGenerator.EncMethod method in this.methods)
      {
        try
        {
          method.AddSessionInfo(sessionInfo, this.rand);
        }
        catch (Exception ex)
        {
          throw new PgpException("exception encrypting session key", ex);
        }
        this.pOut.WritePacket((ContainedPacket) method);
      }
    }
    string symmetricCipherName = PgpUtilities.GetSymmetricCipherName(this.defAlgorithm);
    if (symmetricCipherName == null)
      throw new PgpException("null cipher specified");
    try
    {
      this.c = CipherUtilities.GetCipher(!this.withIntegrityPacket ? symmetricCipherName + "/OpenPGPCFB/NoPadding" : symmetricCipherName + "/CFB/NoPadding");
      byte[] iv = new byte[this.c.GetBlockSize()];
      this.c.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) new ParametersWithIV((ICipherParameters) keyParameter, iv), this.rand));
      if (buffer == null)
      {
        if (this.withIntegrityPacket)
        {
          this.pOut = new BcpgOutputStream(outStr, PacketTag.SymmetricEncryptedIntegrityProtected, length + (long) this.c.GetBlockSize() + 2L + 1L + 22L);
          this.pOut.WriteByte((byte) 1);
        }
        else
          this.pOut = new BcpgOutputStream(outStr, PacketTag.SymmetricKeyEncrypted, length + (long) this.c.GetBlockSize() + 2L, this.oldFormat);
      }
      else if (this.withIntegrityPacket)
      {
        this.pOut = new BcpgOutputStream(outStr, PacketTag.SymmetricEncryptedIntegrityProtected, buffer);
        this.pOut.WriteByte((byte) 1);
      }
      else
        this.pOut = new BcpgOutputStream(outStr, PacketTag.SymmetricKeyEncrypted, buffer);
      int blockSize = this.c.GetBlockSize();
      byte[] numArray = new byte[blockSize + 2];
      this.rand.NextBytes(numArray, 0, blockSize);
      Array.Copy((Array) numArray, numArray.Length - 4, (Array) numArray, numArray.Length - 2, 2);
      Stream stream = (Stream) (this.cOut = new CipherStream((Stream) this.pOut, (IBufferedCipher) null, this.c));
      if (this.withIntegrityPacket)
      {
        IDigest digest = PgpUtilities.CreateDigest(HashAlgorithmTag.Sha1);
        stream = (Stream) (this.digestOut = new DigestStream(stream, (IDigest) null, digest));
      }
      stream.Write(numArray, 0, numArray.Length);
      return (Stream) new WrappedGeneratorStream((IStreamGenerator) this, stream);
    }
    catch (Exception ex)
    {
      throw new PgpException("Exception creating cipher", ex);
    }
  }

  public Stream Open(Stream outStr, long length) => this.Open(outStr, length, (byte[]) null);

  public Stream Open(Stream outStr, byte[] buffer) => this.Open(outStr, 0L, buffer);

  [Obsolete("Dispose any opened Stream directly")]
  public void Close()
  {
    if (this.cOut == null)
      return;
    if (this.digestOut != null)
    {
      new BcpgOutputStream((Stream) this.digestOut, PacketTag.ModificationDetectionCode, 20L).Flush();
      this.digestOut.Flush();
      byte[] buffer = DigestUtilities.DoFinal(this.digestOut.WriteDigest);
      this.cOut.Write(buffer, 0, buffer.Length);
    }
    this.cOut.Flush();
    try
    {
      this.pOut.Write(this.c.DoFinal());
      this.pOut.Finish();
    }
    catch (Exception ex)
    {
      throw new IOException(ex.Message, ex);
    }
    this.cOut = (CipherStream) null;
    this.pOut = (BcpgOutputStream) null;
  }

  private abstract class EncMethod : ContainedPacket
  {
    protected byte[] sessionInfo;
    protected SymmetricKeyAlgorithmTag encAlgorithm;
    protected KeyParameter key;

    public abstract void AddSessionInfo(byte[] si, SecureRandom random);
  }

  private class PbeMethod : PgpEncryptedDataGenerator.EncMethod
  {
    private S2k s2k;

    internal PbeMethod(SymmetricKeyAlgorithmTag encAlgorithm, S2k s2k, KeyParameter key)
    {
      this.encAlgorithm = encAlgorithm;
      this.s2k = s2k;
      this.key = key;
    }

    public KeyParameter GetKey() => this.key;

    public override void AddSessionInfo(byte[] si, SecureRandom random)
    {
      IBufferedCipher cipher = CipherUtilities.GetCipher(PgpUtilities.GetSymmetricCipherName(this.encAlgorithm) + "/CFB/NoPadding");
      byte[] iv = new byte[cipher.GetBlockSize()];
      cipher.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) new ParametersWithIV((ICipherParameters) this.key, iv), random));
      this.sessionInfo = cipher.DoFinal(si, 0, si.Length - 2);
    }

    public override void Encode(BcpgOutputStream pOut)
    {
      SymmetricKeyEncSessionPacket p = new SymmetricKeyEncSessionPacket(this.encAlgorithm, this.s2k, this.sessionInfo);
      pOut.WritePacket((ContainedPacket) p);
    }
  }

  private class PubMethod : PgpEncryptedDataGenerator.EncMethod
  {
    internal PgpPublicKey pubKey;
    internal bool sessionKeyObfuscation;
    internal byte[][] data;

    internal PubMethod(PgpPublicKey pubKey, bool sessionKeyObfuscation)
    {
      this.pubKey = pubKey;
      this.sessionKeyObfuscation = sessionKeyObfuscation;
    }

    public override void AddSessionInfo(byte[] sessionInfo, SecureRandom random)
    {
      this.data = this.ProcessSessionInfo(this.EncryptSessionInfo(sessionInfo, random));
    }

    private byte[] EncryptSessionInfo(byte[] sessionInfo, SecureRandom random)
    {
      AsymmetricKeyParameter key1 = this.pubKey.GetKey();
      if (this.pubKey.Algorithm != PublicKeyAlgorithmTag.ECDH)
      {
        IBufferedCipher cipher;
        switch (this.pubKey.Algorithm)
        {
          case PublicKeyAlgorithmTag.RsaGeneral:
          case PublicKeyAlgorithmTag.RsaEncrypt:
            cipher = CipherUtilities.GetCipher("RSA//PKCS1Padding");
            break;
          case PublicKeyAlgorithmTag.ElGamalEncrypt:
          case PublicKeyAlgorithmTag.ElGamalGeneral:
            cipher = CipherUtilities.GetCipher("ElGamal/ECB/PKCS1Padding");
            break;
          case PublicKeyAlgorithmTag.Dsa:
            throw new PgpException("Can't use DSA for encryption.");
          case PublicKeyAlgorithmTag.ECDsa:
            throw new PgpException("Can't use ECDSA for encryption.");
          case PublicKeyAlgorithmTag.EdDsa:
            throw new PgpException("Can't use EdDSA for encryption.");
          default:
            throw new PgpException("unknown asymmetric algorithm: " + this.pubKey.Algorithm.ToString());
        }
        cipher.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) key1, random));
        return cipher.DoFinal(sessionInfo);
      }
      ECDHPublicBcpgKey key2 = (ECDHPublicBcpgKey) this.pubKey.PublicKeyPacket.Key;
      DerObjectIdentifier curveOid = key2.CurveOid;
      if (!EdECObjectIdentifiers.id_X25519.Equals((Asn1Object) curveOid) && !CryptlibObjectIdentifiers.curvey25519.Equals((Asn1Object) curveOid))
      {
        if (EdECObjectIdentifiers.id_X448.Equals((Asn1Object) curveOid))
        {
          X448KeyPairGenerator keyPairGenerator = new X448KeyPairGenerator();
          keyPairGenerator.Init((KeyGenerationParameters) new X448KeyGenerationParameters(random));
          AsymmetricCipherKeyPair keyPair = keyPairGenerator.GenerateKeyPair();
          X448Agreement x448Agreement = new X448Agreement();
          x448Agreement.Init((ICipherParameters) keyPair.Private);
          byte[] numArray1 = new byte[x448Agreement.AgreementSize];
          x448Agreement.CalculateAgreement((ICipherParameters) key1, numArray1, 0);
          byte[] numArray2 = new byte[1 + X448PublicKeyParameters.KeySize];
          numArray2[0] = (byte) 64 /*0x40*/;
          ((X448PublicKeyParameters) keyPair.Public).Encode(numArray2, 1);
          return this.EncryptSessionInfo(key2, sessionInfo, numArray1, numArray2, random);
        }
        ECDomainParameters parameters = ((ECKeyParameters) key1).Parameters;
        ECKeyPairGenerator keyPairGenerator1 = new ECKeyPairGenerator();
        keyPairGenerator1.Init((KeyGenerationParameters) new ECKeyGenerationParameters(parameters, random));
        AsymmetricCipherKeyPair keyPair1 = keyPairGenerator1.GenerateKeyPair();
        ECDHBasicAgreement ecdhBasicAgreement = new ECDHBasicAgreement();
        ecdhBasicAgreement.Init((ICipherParameters) keyPair1.Private);
        BigInteger agreement = ecdhBasicAgreement.CalculateAgreement((ICipherParameters) key1);
        byte[] secret = BigIntegers.AsUnsignedByteArray(ecdhBasicAgreement.GetFieldSize(), agreement);
        byte[] encoded = ((ECPublicKeyParameters) keyPair1.Public).Q.GetEncoded(false);
        return this.EncryptSessionInfo(key2, sessionInfo, secret, encoded, random);
      }
      X25519KeyPairGenerator keyPairGenerator2 = new X25519KeyPairGenerator();
      keyPairGenerator2.Init((KeyGenerationParameters) new X25519KeyGenerationParameters(random));
      AsymmetricCipherKeyPair keyPair2 = keyPairGenerator2.GenerateKeyPair();
      X25519Agreement x25519Agreement = new X25519Agreement();
      x25519Agreement.Init((ICipherParameters) keyPair2.Private);
      byte[] numArray3 = new byte[x25519Agreement.AgreementSize];
      x25519Agreement.CalculateAgreement((ICipherParameters) key1, numArray3, 0);
      byte[] numArray4 = new byte[1 + X25519PublicKeyParameters.KeySize];
      numArray4[0] = (byte) 64 /*0x40*/;
      ((X25519PublicKeyParameters) keyPair2.Public).Encode(numArray4, 1);
      return this.EncryptSessionInfo(key2, sessionInfo, numArray3, numArray4, random);
    }

    private byte[] EncryptSessionInfo(
      ECDHPublicBcpgKey ecPubKey,
      byte[] sessionInfo,
      byte[] secret,
      byte[] ephPubEncoding,
      SecureRandom random)
    {
      KeyParameter parameters = new KeyParameter(Rfc6637Utilities.CreateKey(this.pubKey.PublicKeyPacket, secret));
      IWrapper wrapper = PgpUtilities.CreateWrapper(ecPubKey.SymmetricKeyAlgorithm);
      wrapper.Init(true, (ICipherParameters) new ParametersWithRandom((ICipherParameters) parameters, random));
      byte[] input = PgpPad.PadSessionData(sessionInfo, this.sessionKeyObfuscation);
      byte[] sourceArray = wrapper.Wrap(input, 0, input.Length);
      byte[] encoded = new MPInteger(new BigInteger(1, ephPubEncoding)).GetEncoded();
      byte[] destinationArray = new byte[encoded.Length + 1 + sourceArray.Length];
      Array.Copy((Array) encoded, 0, (Array) destinationArray, 0, encoded.Length);
      destinationArray[encoded.Length] = (byte) sourceArray.Length;
      Array.Copy((Array) sourceArray, 0, (Array) destinationArray, encoded.Length + 1, sourceArray.Length);
      return destinationArray;
    }

    private byte[][] ProcessSessionInfo(byte[] encryptedSessionInfo)
    {
      byte[][] numArray1;
      switch (this.pubKey.Algorithm)
      {
        case PublicKeyAlgorithmTag.RsaGeneral:
        case PublicKeyAlgorithmTag.RsaEncrypt:
          numArray1 = new byte[1][]
          {
            this.ConvertToEncodedMpi(encryptedSessionInfo)
          };
          break;
        case PublicKeyAlgorithmTag.ElGamalEncrypt:
        case PublicKeyAlgorithmTag.ElGamalGeneral:
          int length = encryptedSessionInfo.Length / 2;
          byte[] numArray2 = new byte[length];
          byte[] numArray3 = new byte[length];
          Array.Copy((Array) encryptedSessionInfo, 0, (Array) numArray2, 0, length);
          Array.Copy((Array) encryptedSessionInfo, length, (Array) numArray3, 0, length);
          numArray1 = new byte[2][]
          {
            this.ConvertToEncodedMpi(numArray2),
            this.ConvertToEncodedMpi(numArray3)
          };
          break;
        case PublicKeyAlgorithmTag.ECDH:
          numArray1 = new byte[1][]{ encryptedSessionInfo };
          break;
        default:
          throw new PgpException("unknown asymmetric algorithm: " + this.pubKey.Algorithm.ToString());
      }
      return numArray1;
    }

    private byte[] ConvertToEncodedMpi(byte[] encryptedSessionInfo)
    {
      try
      {
        return new MPInteger(new BigInteger(1, encryptedSessionInfo)).GetEncoded();
      }
      catch (IOException ex)
      {
        throw new PgpException("Invalid MPI encoding: " + ex.Message, (Exception) ex);
      }
    }

    public override void Encode(BcpgOutputStream pOut)
    {
      PublicKeyEncSessionPacket p = new PublicKeyEncSessionPacket(this.pubKey.KeyId, this.pubKey.Algorithm, this.data);
      pOut.WritePacket((ContainedPacket) p);
    }
  }
}
