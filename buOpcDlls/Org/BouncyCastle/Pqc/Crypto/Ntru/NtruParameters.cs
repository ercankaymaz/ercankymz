// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.NtruParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru;

public sealed class NtruParameters : ICipherParameters
{
  public static readonly NtruParameters NtruHps2048509 = new NtruParameters("ntruhps2048509", (NtruParameterSet) new Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHps2048509());
  public static readonly NtruParameters NtruHps2048677 = new NtruParameters("ntruhps2048677", (NtruParameterSet) new Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHps2048677());
  public static readonly NtruParameters NtruHps4096821 = new NtruParameters("ntruhps4096821", (NtruParameterSet) new Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHps4096821());
  public static readonly NtruParameters NtruHrss701 = new NtruParameters("ntruhrss701", (NtruParameterSet) new Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHrss701());
  internal readonly NtruParameterSet ParameterSet;
  private readonly string _name;

  private NtruParameters(string name, NtruParameterSet parameterSet)
  {
    this._name = name;
    this.ParameterSet = parameterSet;
  }

  public string Name => this._name;

  public int DefaultKeySize => this.ParameterSet.SharedKeyBytes * 8;
}
