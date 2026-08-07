// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.EdEC;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public sealed class PgpUtilities
{
  private static readonly IDictionary<string, HashAlgorithmTag> NameToHashID = PgpUtilities.CreateNameToHashID();
  private static readonly IDictionary<DerObjectIdentifier, string> OidToName = PgpUtilities.CreateOidToName();
  private const int ReadAhead = 60;

  private static IDictionary<string, HashAlgorithmTag> CreateNameToHashID()
  {
    return (IDictionary<string, HashAlgorithmTag>) new Dictionary<string, HashAlgorithmTag>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
    {
      {
        "sha1",
        HashAlgorithmTag.Sha1
      },
      {
        "sha224",
        HashAlgorithmTag.Sha224
      },
      {
        "sha256",
        HashAlgorithmTag.Sha256
      },
      {
        "sha384",
        HashAlgorithmTag.Sha384
      },
      {
        "sha512",
        HashAlgorithmTag.Sha512
      },
      {
        "ripemd160",
        HashAlgorithmTag.RipeMD160
      },
      {
        "rmd160",
        HashAlgorithmTag.RipeMD160
      },
      {
        "md2",
        HashAlgorithmTag.MD2
      },
      {
        "tiger",
        HashAlgorithmTag.Tiger192
      },
      {
        "haval",
        HashAlgorithmTag.Haval5pass160
      },
      {
        "md5",
        HashAlgorithmTag.MD5
      }
    };
  }

  private static IDictionary<DerObjectIdentifier, string> CreateOidToName()
  {
    return (IDictionary<DerObjectIdentifier, string>) new Dictionary<DerObjectIdentifier, string>()
    {
      {
        EdECObjectIdentifiers.id_X25519,
        "Curve25519"
      },
      {
        EdECObjectIdentifiers.id_Ed25519,
        "Ed25519"
      },
      {
        SecObjectIdentifiers.SecP256r1,
        "NIST P-256"
      },
      {
        SecObjectIdentifiers.SecP384r1,
        "NIST P-384"
      },
      {
        SecObjectIdentifiers.SecP521r1,
        "NIST P-521"
      }
    };
  }

  public static MPInteger[] DsaSigToMpi(byte[] encoding)
  {
    DerInteger instance1;
    DerInteger instance2;
    try
    {
      Asn1Sequence instance3 = Asn1Sequence.GetInstance((object) encoding);
      instance1 = DerInteger.GetInstance((object) instance3[0]);
      instance2 = DerInteger.GetInstance((object) instance3[1]);
    }
    catch (Exception ex)
    {
      throw new PgpException("exception encoding signature", ex);
    }
    return new MPInteger[2]
    {
      new MPInteger(instance1.Value),
      new MPInteger(instance2.Value)
    };
  }

  public static MPInteger[] RsaSigToMpi(byte[] encoding)
  {
    return new MPInteger[1]
    {
      new MPInteger(new BigInteger(1, encoding))
    };
  }

  public static string GetDigestName(HashAlgorithmTag hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case HashAlgorithmTag.MD5:
        return "MD5";
      case HashAlgorithmTag.Sha1:
        return "SHA1";
      case HashAlgorithmTag.RipeMD160:
        return "RIPEMD160";
      case HashAlgorithmTag.MD2:
        return "MD2";
      case HashAlgorithmTag.Sha256:
        return "SHA256";
      case HashAlgorithmTag.Sha384:
        return "SHA384";
      case HashAlgorithmTag.Sha512:
        return "SHA512";
      case HashAlgorithmTag.Sha224:
        return "SHA224";
      default:
        throw new PgpException("unknown hash algorithm tag in GetDigestName: " + hashAlgorithm.ToString());
    }
  }

  public static int GetDigestIDForName(string name)
  {
    HashAlgorithmTag digestIdForName;
    if (!PgpUtilities.NameToHashID.TryGetValue(name, out digestIdForName))
      throw new ArgumentException($"unable to map {name} to a hash id", nameof (name));
    return (int) digestIdForName;
  }

  public static string GetCurveName(DerObjectIdentifier oid)
  {
    string str;
    return PgpUtilities.OidToName.TryGetValue(oid, out str) ? str : ECNamedCurveTable.GetName(oid);
  }

  public static string GetSignatureName(
    PublicKeyAlgorithmTag keyAlgorithm,
    HashAlgorithmTag hashAlgorithm)
  {
    string str;
    switch (keyAlgorithm)
    {
      case PublicKeyAlgorithmTag.RsaGeneral:
      case PublicKeyAlgorithmTag.RsaSign:
        str = "RSA";
        break;
      case PublicKeyAlgorithmTag.ElGamalEncrypt:
      case PublicKeyAlgorithmTag.ElGamalGeneral:
        str = "ElGamal";
        break;
      case PublicKeyAlgorithmTag.Dsa:
        str = "DSA";
        break;
      case PublicKeyAlgorithmTag.ECDH:
        str = "ECDH";
        break;
      case PublicKeyAlgorithmTag.ECDsa:
        str = "ECDSA";
        break;
      case PublicKeyAlgorithmTag.EdDsa:
        str = "EdDSA";
        break;
      default:
        throw new PgpException("unknown algorithm tag in signature:" + keyAlgorithm.ToString());
    }
    return $"{PgpUtilities.GetDigestName(hashAlgorithm)}with{str}";
  }

  public static string GetSymmetricCipherName(SymmetricKeyAlgorithmTag algorithm)
  {
    switch (algorithm)
    {
      case SymmetricKeyAlgorithmTag.Null:
        return (string) null;
      case SymmetricKeyAlgorithmTag.Idea:
        return "IDEA";
      case SymmetricKeyAlgorithmTag.TripleDes:
        return "DESEDE";
      case SymmetricKeyAlgorithmTag.Cast5:
        return "CAST5";
      case SymmetricKeyAlgorithmTag.Blowfish:
        return "Blowfish";
      case SymmetricKeyAlgorithmTag.Safer:
        return "SAFER";
      case SymmetricKeyAlgorithmTag.Des:
        return "DES";
      case SymmetricKeyAlgorithmTag.Aes128:
        return "AES";
      case SymmetricKeyAlgorithmTag.Aes192:
        return "AES";
      case SymmetricKeyAlgorithmTag.Aes256:
        return "AES";
      case SymmetricKeyAlgorithmTag.Twofish:
        return "Twofish";
      case SymmetricKeyAlgorithmTag.Camellia128:
        return "Camellia";
      case SymmetricKeyAlgorithmTag.Camellia192:
        return "Camellia";
      case SymmetricKeyAlgorithmTag.Camellia256:
        return "Camellia";
      default:
        throw new PgpException("unknown symmetric algorithm: " + algorithm.ToString());
    }
  }

  public static int GetKeySize(SymmetricKeyAlgorithmTag algorithm)
  {
    int keySize;
    switch (algorithm)
    {
      case SymmetricKeyAlgorithmTag.Idea:
      case SymmetricKeyAlgorithmTag.Cast5:
      case SymmetricKeyAlgorithmTag.Blowfish:
      case SymmetricKeyAlgorithmTag.Safer:
      case SymmetricKeyAlgorithmTag.Aes128:
      case SymmetricKeyAlgorithmTag.Camellia128:
        keySize = 128 /*0x80*/;
        break;
      case SymmetricKeyAlgorithmTag.TripleDes:
      case SymmetricKeyAlgorithmTag.Aes192:
      case SymmetricKeyAlgorithmTag.Camellia192:
        keySize = 192 /*0xC0*/;
        break;
      case SymmetricKeyAlgorithmTag.Des:
        keySize = 64 /*0x40*/;
        break;
      case SymmetricKeyAlgorithmTag.Aes256:
      case SymmetricKeyAlgorithmTag.Twofish:
      case SymmetricKeyAlgorithmTag.Camellia256:
        keySize = 256 /*0x0100*/;
        break;
      default:
        throw new PgpException("unknown symmetric algorithm: " + algorithm.ToString());
    }
    return keySize;
  }

  public static KeyParameter MakeKey(SymmetricKeyAlgorithmTag algorithm, byte[] keyBytes)
  {
    return ParameterUtilities.CreateKeyParameter(PgpUtilities.GetSymmetricCipherName(algorithm), keyBytes);
  }

  public static KeyParameter MakeRandomKey(SymmetricKeyAlgorithmTag algorithm, SecureRandom random)
  {
    byte[] numArray = new byte[(PgpUtilities.GetKeySize(algorithm) + 7) / 8];
    random.NextBytes(numArray);
    return PgpUtilities.MakeKey(algorithm, numArray);
  }

  internal static byte[] EncodePassPhrase(char[] passPhrase, bool utf8)
  {
    if (passPhrase == null)
      return (byte[]) null;
    return !utf8 ? Strings.ToByteArray(passPhrase) : Encoding.UTF8.GetBytes(passPhrase);
  }

  public static KeyParameter MakeKeyFromPassPhrase(
    SymmetricKeyAlgorithmTag algorithm,
    S2k s2k,
    char[] passPhrase)
  {
    return PgpUtilities.DoMakeKeyFromPassPhrase(algorithm, s2k, PgpUtilities.EncodePassPhrase(passPhrase, false), true);
  }

  public static KeyParameter MakeKeyFromPassPhraseUtf8(
    SymmetricKeyAlgorithmTag algorithm,
    S2k s2k,
    char[] passPhrase)
  {
    return PgpUtilities.DoMakeKeyFromPassPhrase(algorithm, s2k, PgpUtilities.EncodePassPhrase(passPhrase, true), true);
  }

  public static KeyParameter MakeKeyFromPassPhraseRaw(
    SymmetricKeyAlgorithmTag algorithm,
    S2k s2k,
    byte[] rawPassPhrase)
  {
    return PgpUtilities.DoMakeKeyFromPassPhrase(algorithm, s2k, rawPassPhrase, false);
  }

  internal static KeyParameter DoMakeKeyFromPassPhrase(
    SymmetricKeyAlgorithmTag algorithm,
    S2k s2k,
    byte[] rawPassPhrase,
    bool clearPassPhrase)
  {
    int keySize = PgpUtilities.GetKeySize(algorithm);
    byte[] input = rawPassPhrase;
    byte[] numArray = new byte[(keySize + 7) / 8];
    int destinationIndex = 0;
    int num = 0;
    while (destinationIndex < numArray.Length)
    {
      IDigest digest;
      if (s2k != null)
      {
        try
        {
          digest = PgpUtilities.CreateDigest(s2k.HashAlgorithm);
        }
        catch (Exception ex)
        {
          throw new PgpException("can't find S2k digest", ex);
        }
        for (int index = 0; index != num; ++index)
          digest.Update((byte) 0);
        byte[] iv = s2k.GetIV();
        switch (s2k.Type)
        {
          case 0:
            digest.BlockUpdate(input, 0, input.Length);
            break;
          case 1:
            digest.BlockUpdate(iv, 0, iv.Length);
            digest.BlockUpdate(input, 0, input.Length);
            break;
          case 3:
            long iterationCount = s2k.IterationCount;
            digest.BlockUpdate(iv, 0, iv.Length);
            digest.BlockUpdate(input, 0, input.Length);
            long inLen1 = iterationCount - (long) (iv.Length + input.Length);
            while (inLen1 > 0L)
            {
              if (inLen1 >= (long) iv.Length)
              {
                digest.BlockUpdate(iv, 0, iv.Length);
                long inLen2 = inLen1 - (long) iv.Length;
                if (inLen2 < (long) input.Length)
                {
                  digest.BlockUpdate(input, 0, (int) inLen2);
                  inLen1 = 0L;
                }
                else
                {
                  digest.BlockUpdate(input, 0, input.Length);
                  inLen1 = inLen2 - (long) input.Length;
                }
              }
              else
              {
                digest.BlockUpdate(iv, 0, (int) inLen1);
                break;
              }
            }
            break;
          default:
            throw new PgpException("unknown S2k type: " + s2k.Type.ToString());
        }
      }
      else
      {
        try
        {
          digest = PgpUtilities.CreateDigest(HashAlgorithmTag.MD5);
          for (int index = 0; index != num; ++index)
            digest.Update((byte) 0);
          digest.BlockUpdate(input, 0, input.Length);
        }
        catch (Exception ex)
        {
          throw new PgpException("can't find MD5 digest", ex);
        }
      }
      byte[] sourceArray = DigestUtilities.DoFinal(digest);
      if (sourceArray.Length > numArray.Length - destinationIndex)
        Array.Copy((Array) sourceArray, 0, (Array) numArray, destinationIndex, numArray.Length - destinationIndex);
      else
        Array.Copy((Array) sourceArray, 0, (Array) numArray, destinationIndex, sourceArray.Length);
      destinationIndex += sourceArray.Length;
      ++num;
    }
    if (clearPassPhrase && rawPassPhrase != null)
      Array.Clear((Array) rawPassPhrase, 0, rawPassPhrase.Length);
    return PgpUtilities.MakeKey(algorithm, numArray);
  }

  public static void WriteFileToLiteralData(Stream output, char fileType, FileInfo file)
  {
    using (Stream pOut = new PgpLiteralDataGenerator().Open(output, fileType, file.Name, file.Length, file.LastWriteTime))
      PgpUtilities.PipeFileContents(file, pOut);
  }

  public static void WriteFileToLiteralData(
    Stream output,
    char fileType,
    FileInfo file,
    byte[] buffer)
  {
    using (Stream pOut = new PgpLiteralDataGenerator().Open(output, fileType, file.Name, file.LastWriteTime, buffer))
      PgpUtilities.PipeFileContents(file, pOut, buffer.Length);
  }

  private static void PipeFileContents(FileInfo file, Stream pOut)
  {
    PgpUtilities.PipeFileContents(file, pOut, Streams.DefaultBufferSize);
  }

  private static void PipeFileContents(FileInfo file, Stream pOut, int bufferSize)
  {
    using (FileStream source = file.OpenRead())
      Streams.CopyTo((Stream) source, pOut, bufferSize);
  }

  private static bool IsPossiblyBase64(int ch)
  {
    return ch >= 65 && ch <= 90 || ch >= 97 && ch <= 122 || ch >= 48 /*0x30*/ && ch <= 57 || ch == 43 || ch == 47 || ch == 13 || ch == 10;
  }

  public static Stream GetDecoderStream(Stream inputStream)
  {
    long num1 = inputStream.CanSeek ? inputStream.Position : throw new ArgumentException("inputStream must be seek-able", nameof (inputStream));
    int ch1 = inputStream.ReadByte();
    if ((ch1 & 128 /*0x80*/) != 0)
    {
      inputStream.Position = num1;
      return inputStream;
    }
    if (!PgpUtilities.IsPossiblyBase64(ch1))
    {
      inputStream.Position = num1;
      return (Stream) new ArmoredInputStream(inputStream);
    }
    byte[] sourceArray = new byte[60];
    int num2 = 1;
    int num3 = 1;
    sourceArray[0] = (byte) ch1;
    int ch2;
    for (; num2 != 60 && (ch2 = inputStream.ReadByte()) >= 0; ++num2)
    {
      if (PgpUtilities.IsPossiblyBase64(ch2))
      {
        if (ch2 != 10 && ch2 != 13)
          sourceArray[num3++] = (byte) ch2;
      }
      else
      {
        inputStream.Position = num1;
        return (Stream) new ArmoredInputStream(inputStream);
      }
    }
    inputStream.Position = num1;
    if (num2 < 4)
      return (Stream) new ArmoredInputStream(inputStream);
    byte[] numArray = new byte[8];
    Array.Copy((Array) sourceArray, 0, (Array) numArray, 0, numArray.Length);
    try
    {
      bool hasHeaders = ((int) Base64.Decode(numArray)[0] & 128 /*0x80*/) == 0;
      return (Stream) new ArmoredInputStream(inputStream, hasHeaders);
    }
    catch (IOException ex)
    {
      throw;
    }
    catch (Exception ex)
    {
      throw new IOException(ex.Message);
    }
  }

  internal static IDigest CreateDigest(HashAlgorithmTag hashAlgorithm)
  {
    return DigestUtilities.GetDigest(PgpUtilities.GetDigestName(hashAlgorithm));
  }

  internal static ISigner CreateSigner(
    PublicKeyAlgorithmTag publicKeyAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    AsymmetricKeyParameter key)
  {
    if (publicKeyAlgorithm != PublicKeyAlgorithmTag.EdDsa)
      return SignerUtilities.GetSigner(PgpUtilities.GetSignatureName(publicKeyAlgorithm, hashAlgorithm));
    ISigner signer;
    switch (key)
    {
      case Ed25519PrivateKeyParameters _:
      case Ed25519PublicKeyParameters _:
        signer = (ISigner) new Ed25519Signer();
        break;
      case Ed448PrivateKeyParameters _:
      case Ed448PublicKeyParameters _:
        signer = (ISigner) new Ed448Signer(Arrays.EmptyBytes);
        break;
      default:
        throw new InvalidOperationException();
    }
    return (ISigner) new EdDsaSigner(signer, PgpUtilities.CreateDigest(hashAlgorithm));
  }

  internal static IWrapper CreateWrapper(SymmetricKeyAlgorithmTag encAlgorithm)
  {
    switch (encAlgorithm)
    {
      case SymmetricKeyAlgorithmTag.Aes128:
      case SymmetricKeyAlgorithmTag.Aes192:
      case SymmetricKeyAlgorithmTag.Aes256:
        return WrapperUtilities.GetWrapper("AESWRAP");
      case SymmetricKeyAlgorithmTag.Camellia128:
      case SymmetricKeyAlgorithmTag.Camellia192:
      case SymmetricKeyAlgorithmTag.Camellia256:
        return WrapperUtilities.GetWrapper("CAMELLIAWRAP");
      default:
        throw new PgpException("unknown wrap algorithm: " + encAlgorithm.ToString());
    }
  }

  internal static byte[] GenerateIV(int length, SecureRandom random)
  {
    byte[] buffer = new byte[length];
    random.NextBytes(buffer);
    return buffer;
  }

  internal static S2k GenerateS2k(
    HashAlgorithmTag hashAlgorithm,
    int s2kCount,
    SecureRandom random)
  {
    byte[] iv = PgpUtilities.GenerateIV(8, random);
    return new S2k(hashAlgorithm, iv, s2kCount);
  }
}
