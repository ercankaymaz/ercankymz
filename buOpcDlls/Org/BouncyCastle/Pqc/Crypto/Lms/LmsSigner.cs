// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LmsSigner : IMessageSigner
{
  private LmsPrivateKeyParameters m_privateKey;
  private LmsPublicKeyParameters m_publicKey;

  public void Init(bool forSigning, ICipherParameters param)
  {
    if (forSigning)
      this.m_privateKey = (LmsPrivateKeyParameters) param;
    else
      this.m_publicKey = (LmsPublicKeyParameters) param;
  }

  public byte[] GenerateSignature(byte[] message)
  {
    try
    {
      return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.GenerateSign(this.m_privateKey, message).GetEncoded();
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
      return Org.BouncyCastle.Pqc.Crypto.Lms.Lms.VerifySignature(this.m_publicKey, LmsSignature.GetInstance((object) signature), message);
    }
    catch (IOException ex)
    {
      throw new Exception("unable to decode signature: " + ex.Message);
    }
  }
}
