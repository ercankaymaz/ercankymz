// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.EncryptedPrivateKeyInfoFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public sealed class EncryptedPrivateKeyInfoFactory
{
  private EncryptedPrivateKeyInfoFactory()
  {
  }

  public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(
    DerObjectIdentifier algorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    AsymmetricKeyParameter key)
  {
    return EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(algorithm.Id, passPhrase, salt, iterationCount, PrivateKeyInfoFactory.CreatePrivateKeyInfo(key));
  }

  public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(
    string algorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    AsymmetricKeyParameter key)
  {
    return EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(algorithm, passPhrase, salt, iterationCount, PrivateKeyInfoFactory.CreatePrivateKeyInfo(key));
  }

  public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(
    string algorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    PrivateKeyInfo keyInfo)
  {
    if (!(PbeUtilities.CreateEngine(algorithm) is IBufferedCipher engine))
      throw new Exception("Unknown encryption algorithm: " + algorithm);
    Asn1Encodable algorithmParameters = PbeUtilities.GenerateAlgorithmParameters(algorithm, salt, iterationCount);
    engine.Init(true, PbeUtilities.GenerateCipherParameters(algorithm, passPhrase, algorithmParameters));
    byte[] encoding = engine.DoFinal(keyInfo.GetEncoded());
    return new EncryptedPrivateKeyInfo(new AlgorithmIdentifier(PbeUtilities.GetObjectIdentifier(algorithm), algorithmParameters), encoding);
  }

  public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(
    DerObjectIdentifier cipherAlgorithm,
    DerObjectIdentifier prfAlgorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    SecureRandom random,
    AsymmetricKeyParameter key)
  {
    return EncryptedPrivateKeyInfoFactory.CreateEncryptedPrivateKeyInfo(cipherAlgorithm, prfAlgorithm, passPhrase, salt, iterationCount, random, PrivateKeyInfoFactory.CreatePrivateKeyInfo(key));
  }

  public static EncryptedPrivateKeyInfo CreateEncryptedPrivateKeyInfo(
    DerObjectIdentifier cipherAlgorithm,
    DerObjectIdentifier prfAlgorithm,
    char[] passPhrase,
    byte[] salt,
    int iterationCount,
    SecureRandom random,
    PrivateKeyInfo keyInfo)
  {
    IBufferedCipher cipher = CipherUtilities.GetCipher(cipherAlgorithm);
    if (cipher == null)
      throw new Exception("Unknown encryption algorithm: " + cipherAlgorithm?.ToString());
    Asn1Encodable algorithmParameters = PbeUtilities.GenerateAlgorithmParameters(cipherAlgorithm, prfAlgorithm, salt, iterationCount, random);
    cipher.Init(true, PbeUtilities.GenerateCipherParameters(PkcsObjectIdentifiers.IdPbeS2, passPhrase, algorithmParameters));
    byte[] encoding = cipher.DoFinal(keyInfo.GetEncoded());
    return new EncryptedPrivateKeyInfo(new AlgorithmIdentifier(PkcsObjectIdentifiers.IdPbeS2, algorithmParameters), encoding);
  }
}
