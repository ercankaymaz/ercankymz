// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpOnePassSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpOnePassSignature
{
  private readonly OnePassSignaturePacket sigPack;
  private readonly int signatureType;
  private ISigner sig;
  private byte lastb;

  private static OnePassSignaturePacket Cast(Packet packet)
  {
    return packet is OnePassSignaturePacket passSignaturePacket ? passSignaturePacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }

  internal PgpOnePassSignature(BcpgInputStream bcpgInput)
    : this(PgpOnePassSignature.Cast(bcpgInput.ReadPacket()))
  {
  }

  internal PgpOnePassSignature(OnePassSignaturePacket sigPack)
  {
    this.sigPack = sigPack;
    this.signatureType = sigPack.SignatureType;
  }

  public void InitVerify(PgpPublicKey pubKey)
  {
    this.lastb = (byte) 0;
    AsymmetricKeyParameter key = pubKey.GetKey();
    try
    {
      this.sig = PgpUtilities.CreateSigner(this.sigPack.KeyAlgorithm, this.sigPack.HashAlgorithm, key);
    }
    catch (Exception ex)
    {
      throw new PgpException("can't set up signature object.", ex);
    }
    try
    {
      this.sig.Init(false, (ICipherParameters) key);
    }
    catch (InvalidKeyException ex)
    {
      throw new PgpException("invalid key.", (Exception) ex);
    }
  }

  public void Update(byte b)
  {
    if (this.signatureType == 1)
      this.DoCanonicalUpdateByte(b);
    else
      this.sig.Update(b);
  }

  private void DoCanonicalUpdateByte(byte b)
  {
    switch (b)
    {
      case 10:
        if (this.lastb != (byte) 13)
        {
          this.DoUpdateCRLF();
          break;
        }
        break;
      case 13:
        this.DoUpdateCRLF();
        break;
      default:
        this.sig.Update(b);
        break;
    }
    this.lastb = b;
  }

  private void DoUpdateCRLF()
  {
    this.sig.Update((byte) 13);
    this.sig.Update((byte) 10);
  }

  public void Update(params byte[] bytes) => this.Update(bytes, 0, bytes.Length);

  public void Update(byte[] bytes, int off, int length)
  {
    if (this.signatureType == 1)
    {
      int num = off + length;
      for (int index = off; index != num; ++index)
        this.DoCanonicalUpdateByte(bytes[index]);
    }
    else
      this.sig.BlockUpdate(bytes, off, length);
  }

  public bool Verify(PgpSignature pgpSig)
  {
    byte[] signatureTrailer = pgpSig.GetSignatureTrailer();
    this.sig.BlockUpdate(signatureTrailer, 0, signatureTrailer.Length);
    return this.sig.VerifySignature(pgpSig.GetSignature());
  }

  public long KeyId => this.sigPack.KeyId;

  public int SignatureType => this.sigPack.SignatureType;

  public HashAlgorithmTag HashAlgorithm => this.sigPack.HashAlgorithm;

  public PublicKeyAlgorithmTag KeyAlgorithm => this.sigPack.KeyAlgorithm;

  public byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    this.Encode((Stream) outStr);
    return outStr.ToArray();
  }

  public void Encode(Stream outStr)
  {
    BcpgOutputStream.Wrap(outStr).WritePacket((ContainedPacket) this.sigPack);
  }
}
