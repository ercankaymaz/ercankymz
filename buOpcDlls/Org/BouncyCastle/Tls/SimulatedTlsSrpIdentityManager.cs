// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SimulatedTlsSrpIdentityManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class SimulatedTlsSrpIdentityManager : TlsSrpIdentityManager
{
  private static readonly byte[] PrefixPassword = Strings.ToByteArray("password");
  private static readonly byte[] PrefixSalt = Strings.ToByteArray("salt");
  protected readonly Srp6Group m_group;
  protected readonly TlsSrp6VerifierGenerator m_verifierGenerator;
  protected readonly TlsMac m_mac;

  public static SimulatedTlsSrpIdentityManager GetRfc5054Default(
    TlsCrypto crypto,
    Srp6Group group,
    byte[] seedKey)
  {
    TlsMac hmac = (TlsMac) crypto.CreateHmac(2);
    hmac.SetKey(seedKey, 0, seedKey.Length);
    TlsSrpConfig srpConfig = new TlsSrpConfig();
    srpConfig.SetExplicitNG(new BigInteger[2]
    {
      group.N,
      group.G
    });
    return new SimulatedTlsSrpIdentityManager(group, crypto.CreateSrp6VerifierGenerator(srpConfig), hmac);
  }

  public SimulatedTlsSrpIdentityManager(
    Srp6Group group,
    TlsSrp6VerifierGenerator verifierGenerator,
    TlsMac mac)
  {
    this.m_group = group;
    this.m_verifierGenerator = verifierGenerator;
    this.m_mac = mac;
  }

  public virtual TlsSrpLoginParameters GetLoginParameters(byte[] identity)
  {
    this.m_mac.Update(SimulatedTlsSrpIdentityManager.PrefixSalt, 0, SimulatedTlsSrpIdentityManager.PrefixSalt.Length);
    this.m_mac.Update(identity, 0, identity.Length);
    byte[] mac1 = this.m_mac.CalculateMac();
    this.m_mac.Update(SimulatedTlsSrpIdentityManager.PrefixPassword, 0, SimulatedTlsSrpIdentityManager.PrefixPassword.Length);
    this.m_mac.Update(identity, 0, identity.Length);
    byte[] mac2 = this.m_mac.CalculateMac();
    BigInteger verifier = this.m_verifierGenerator.GenerateVerifier(mac1, identity, mac2);
    TlsSrpConfig srpConfig = new TlsSrpConfig();
    srpConfig.SetExplicitNG(new BigInteger[2]
    {
      this.m_group.N,
      this.m_group.G
    });
    return new TlsSrpLoginParameters(identity, srpConfig, verifier, mac1);
  }
}
