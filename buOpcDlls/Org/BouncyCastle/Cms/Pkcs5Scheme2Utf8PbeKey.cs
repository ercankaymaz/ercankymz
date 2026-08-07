// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.Pkcs5Scheme2Utf8PbeKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class Pkcs5Scheme2Utf8PbeKey : CmsPbeKey
{
  public Pkcs5Scheme2Utf8PbeKey(char[] password, byte[] salt, int iterationCount)
    : base(password, salt, iterationCount)
  {
  }

  public Pkcs5Scheme2Utf8PbeKey(char[] password, AlgorithmIdentifier keyDerivationAlgorithm)
    : base(password, keyDerivationAlgorithm)
  {
  }

  internal override KeyParameter GetEncoded(string algorithmOid)
  {
    Pkcs5S2ParametersGenerator parametersGenerator = new Pkcs5S2ParametersGenerator();
    parametersGenerator.Init(PbeParametersGenerator.Pkcs5PasswordToUtf8Bytes(this.password), this.salt, this.iterationCount);
    return (KeyParameter) parametersGenerator.GenerateDerivedParameters(algorithmOid, CmsEnvelopedHelper.Instance.GetKeySize(algorithmOid));
  }
}
