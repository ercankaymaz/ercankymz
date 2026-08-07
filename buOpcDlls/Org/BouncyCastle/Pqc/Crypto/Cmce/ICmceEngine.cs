// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.ICmceEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

internal interface ICmceEngine
{
  int CipherTextSize { get; }

  byte[] DecompressPrivateKey(byte[] sk);

  int DefaultSessionKeySize { get; }

  byte[] GeneratePublicKeyFromPrivateKey(byte[] sk);

  int KemDec(byte[] key, byte[] cipher_text, byte[] sk);

  int KemEnc(byte[] cipher_text, byte[] key, byte[] pk, SecureRandom random);

  void KemKeypair(byte[] pk, byte[] sk, SecureRandom random);

  int PrivateKeySize { get; }

  int PublicKeySize { get; }
}
