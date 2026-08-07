// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.Kdf.ECDHKekGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.Kdf;

public sealed class ECDHKekGenerator : IDerivationFunction
{
  private readonly IDerivationFunction m_kdf;
  private DerObjectIdentifier algorithm;
  private int keySize;
  private byte[] z;

  public ECDHKekGenerator(IDigest digest)
  {
    this.m_kdf = (IDerivationFunction) new Kdf2BytesGenerator(digest);
  }

  public void Init(IDerivationParameters param)
  {
    DHKdfParameters dhKdfParameters = (DHKdfParameters) param;
    this.algorithm = dhKdfParameters.Algorithm;
    this.keySize = dhKdfParameters.KeySize;
    this.z = dhKdfParameters.GetZ();
  }

  public IDigest Digest => this.m_kdf.Digest;

  public int GenerateBytes(byte[] outBytes, int outOff, int length)
  {
    Check.OutputLength(outBytes, outOff, length, "output buffer too small");
    this.m_kdf.Init((IDerivationParameters) new KdfParameters(this.z, new DerSequence((Asn1Encodable) new AlgorithmIdentifier(this.algorithm, (Asn1Encodable) DerNull.Instance), (Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) new DerOctetString(Pack.UInt32_To_BE((uint) this.keySize)))).GetDerEncoded()));
    return this.m_kdf.GenerateBytes(outBytes, outOff, length);
  }
}
