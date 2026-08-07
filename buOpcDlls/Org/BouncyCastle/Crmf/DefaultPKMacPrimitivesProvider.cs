// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.DefaultPKMacPrimitivesProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class DefaultPKMacPrimitivesProvider : IPKMacPrimitivesProvider
{
  public IDigest CreateDigest(AlgorithmIdentifier digestAlg)
  {
    return DigestUtilities.GetDigest(digestAlg.Algorithm);
  }

  public IMac CreateMac(AlgorithmIdentifier macAlg) => MacUtilities.GetMac(macAlg.Algorithm);
}
