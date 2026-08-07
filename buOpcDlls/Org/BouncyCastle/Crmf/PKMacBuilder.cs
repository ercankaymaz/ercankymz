// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.PKMacBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Iana;
using Org.BouncyCastle.Asn1.Oiw;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crmf;

public class PKMacBuilder
{
  private AlgorithmIdentifier owf;
  private AlgorithmIdentifier mac;
  private IPKMacPrimitivesProvider provider;
  private SecureRandom random;
  private PbmParameter parameters;
  private int iterationCount;
  private int saltLength = 20;
  private int maxIterations;

  public PKMacBuilder()
    : this(new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1), 1000, new AlgorithmIdentifier(IanaObjectIdentifiers.HmacSha1, (Asn1Encodable) DerNull.Instance), (IPKMacPrimitivesProvider) new DefaultPKMacPrimitivesProvider())
  {
  }

  public PKMacBuilder(IPKMacPrimitivesProvider provider)
    : this(new AlgorithmIdentifier(OiwObjectIdentifiers.IdSha1), 1000, new AlgorithmIdentifier(IanaObjectIdentifiers.HmacSha1, (Asn1Encodable) DerNull.Instance), provider)
  {
  }

  public PKMacBuilder(
    IPKMacPrimitivesProvider provider,
    AlgorithmIdentifier digestAlgorithmIdentifier,
    AlgorithmIdentifier macAlgorithmIdentifier)
    : this(digestAlgorithmIdentifier, 1000, macAlgorithmIdentifier, provider)
  {
  }

  public PKMacBuilder(IPKMacPrimitivesProvider provider, int maxIterations)
  {
    this.provider = provider;
    this.maxIterations = maxIterations;
  }

  private PKMacBuilder(
    AlgorithmIdentifier digestAlgorithmIdentifier,
    int iterationCount,
    AlgorithmIdentifier macAlgorithmIdentifier,
    IPKMacPrimitivesProvider provider)
  {
    this.iterationCount = iterationCount;
    this.mac = macAlgorithmIdentifier;
    this.owf = digestAlgorithmIdentifier;
    this.provider = provider;
  }

  public PKMacBuilder SetSaltLength(int saltLength)
  {
    this.saltLength = saltLength >= 8 ? saltLength : throw new ArgumentException("salt length must be at least 8 bytes");
    return this;
  }

  public PKMacBuilder SetIterationCount(int iterationCount)
  {
    if (iterationCount < 100)
      throw new ArgumentException("iteration count must be at least 100");
    this.CheckIterationCountCeiling(iterationCount);
    this.iterationCount = iterationCount;
    return this;
  }

  public PKMacBuilder SetParameters(PbmParameter parameters)
  {
    this.CheckIterationCountCeiling(parameters.IterationCount.IntValueExact);
    this.parameters = parameters;
    return this;
  }

  public PKMacBuilder SetSecureRandom(SecureRandom random)
  {
    this.random = random;
    return this;
  }

  public IMacFactory Build(char[] password)
  {
    return this.GenCalculator(this.parameters ?? this.GenParameters(), password);
  }

  private void CheckIterationCountCeiling(int iterationCount)
  {
    if (this.maxIterations > 0 && iterationCount > this.maxIterations)
      throw new ArgumentException($"iteration count exceeds limit ({iterationCount.ToString()} > {this.maxIterations.ToString()})");
  }

  private IMacFactory GenCalculator(PbmParameter parameters, char[] password)
  {
    return this.GenCalculator(parameters, Strings.ToUtf8ByteArray(password));
  }

  private IMacFactory GenCalculator(PbmParameter parameters, byte[] pw)
  {
    byte[] octets = parameters.Salt.GetOctets();
    byte[] numArray1 = new byte[pw.Length + octets.Length];
    Array.Copy((Array) pw, 0, (Array) numArray1, 0, pw.Length);
    Array.Copy((Array) octets, 0, (Array) numArray1, pw.Length, octets.Length);
    IDigest digest = this.provider.CreateDigest(parameters.Owf);
    int intValueExact = parameters.IterationCount.IntValueExact;
    digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray2 = new byte[digest.GetDigestSize()];
    digest.DoFinal(numArray2, 0);
    while (--intValueExact > 0)
    {
      digest.BlockUpdate(numArray2, 0, numArray2.Length);
      digest.DoFinal(numArray2, 0);
    }
    return (IMacFactory) new PKMacFactory(numArray2, parameters);
  }

  private PbmParameter GenParameters()
  {
    return new PbmParameter(SecureRandom.GetNextBytes(CryptoServicesRegistrar.GetSecureRandom(this.random), this.saltLength), this.owf, this.iterationCount, this.mac);
  }
}
