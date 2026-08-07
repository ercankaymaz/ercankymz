// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.IDrbgProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Prng.Drbg;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

internal interface IDrbgProvider
{
  ISP80090Drbg Get(IEntropySource entropySource);
}
