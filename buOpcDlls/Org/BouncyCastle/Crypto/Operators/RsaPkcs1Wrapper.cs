// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.RsaPkcs1Wrapper
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class RsaPkcs1Wrapper : IKeyWrapper, IKeyUnwrapper
{
  private readonly AlgorithmIdentifier algId;
  private readonly IAsymmetricBlockCipher engine;

  public RsaPkcs1Wrapper(bool forWrapping, ICipherParameters parameters)
  {
    this.algId = new AlgorithmIdentifier(PkcsObjectIdentifiers.RsaEncryption, (Asn1Encodable) DerNull.Instance);
    this.engine = (IAsymmetricBlockCipher) new Pkcs1Encoding((IAsymmetricBlockCipher) new RsaBlindedEngine());
    this.engine.Init(forWrapping, parameters);
  }

  public object AlgorithmDetails => (object) this.algId;

  public IBlockResult Unwrap(byte[] cipherText, int offset, int length)
  {
    return (IBlockResult) new SimpleBlockResult(this.engine.ProcessBlock(cipherText, offset, length));
  }

  public IBlockResult Wrap(byte[] keyData)
  {
    return (IBlockResult) new SimpleBlockResult(this.engine.ProcessBlock(keyData, 0, keyData.Length));
  }
}
