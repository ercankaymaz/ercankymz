// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssSigner : IMessageSigner
{
  private HssPrivateKeyParameters privKey;
  private HssPublicKeyParameters pubKey;

  public void Init(bool forSigning, ICipherParameters param)
  {
    if (forSigning)
      this.privKey = (HssPrivateKeyParameters) param;
    else
      this.pubKey = (HssPublicKeyParameters) param;
  }

  public byte[] GenerateSignature(byte[] message)
  {
    try
    {
      return Hss.GenerateSignature(this.privKey, message).GetEncoded();
    }
    catch (IOException ex)
    {
      throw new Exception("unable to encode signature: " + ex.Message);
    }
  }

  public bool VerifySignature(byte[] message, byte[] signature)
  {
    try
    {
      return Hss.VerifySignature(this.pubKey, HssSignature.GetInstance((object) signature, this.pubKey.L), message);
    }
    catch (IOException ex)
    {
      throw new Exception("unable to decode signature: " + ex.Message);
    }
  }
}
