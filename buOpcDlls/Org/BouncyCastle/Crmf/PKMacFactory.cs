// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.PKMacFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Crmf;

internal class PKMacFactory : IMacFactory
{
  protected readonly PbmParameter parameters;
  private readonly byte[] key;

  public PKMacFactory(byte[] key, PbmParameter parameters)
  {
    this.key = Arrays.Clone(key);
    this.parameters = parameters;
  }

  public virtual object AlgorithmDetails
  {
    get
    {
      return (object) new AlgorithmIdentifier(CmpObjectIdentifiers.passwordBasedMac, (Asn1Encodable) this.parameters);
    }
  }

  public virtual IStreamCalculator<IBlockResult> CreateCalculator()
  {
    IMac mac = MacUtilities.GetMac(this.parameters.Mac.Algorithm);
    mac.Init((ICipherParameters) new KeyParameter(this.key));
    return (IStreamCalculator<IBlockResult>) new PKMacStreamCalculator(mac);
  }
}
