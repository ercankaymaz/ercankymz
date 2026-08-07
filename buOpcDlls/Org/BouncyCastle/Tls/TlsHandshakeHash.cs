// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsHandshakeHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsHandshakeHash : TlsHash
{
  void CopyBufferTo(Stream output);

  void ForceBuffering();

  void NotifyPrfDetermined();

  void TrackHashAlgorithm(int cryptoHashAlgorithm);

  void SealHashAlgorithms();

  void StopTracking();

  TlsHash ForkPrfHash();

  byte[] GetFinalHash(int cryptoHashAlgorithm);
}
