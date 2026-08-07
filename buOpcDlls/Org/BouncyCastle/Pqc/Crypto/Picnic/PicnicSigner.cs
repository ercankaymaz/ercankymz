// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public sealed class PicnicSigner : IMessageSigner
{
  private PicnicPrivateKeyParameters privKey;
  private PicnicPublicKeyParameters pubKey;

  public void Init(bool forSigning, ICipherParameters param)
  {
    if (forSigning)
      this.privKey = (PicnicPrivateKeyParameters) param;
    else
      this.pubKey = (PicnicPublicKeyParameters) param;
  }

  public byte[] GenerateSignature(byte[] message)
  {
    PicnicEngine engine = this.privKey.Parameters.GetEngine();
    byte[] numArray = new byte[engine.GetSignatureSize(message.Length)];
    engine.crypto_sign(numArray, message, this.privKey.GetEncoded());
    return Arrays.CopyOfRange(numArray, message.Length + 4, engine.GetTrueSignatureSize() + message.Length);
  }

  public bool VerifySignature(byte[] message, byte[] signature)
  {
    PicnicEngine engine = this.pubKey.Parameters.GetEngine();
    byte[] b = new byte[message.Length];
    byte[] m = b;
    byte[] sm = signature;
    byte[] encoded = this.pubKey.GetEncoded();
    bool flag = engine.crypto_sign_open(m, sm, encoded);
    return Arrays.AreEqual(message, b) && flag;
  }
}
