// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public abstract class CmceKeyParameters : AsymmetricKeyParameter
{
  private readonly CmceParameters parameters;

  internal CmceKeyParameters(bool isPrivate, CmceParameters parameters)
    : base(isPrivate)
  {
    this.parameters = parameters;
  }

  public CmceParameters Parameters => this.parameters;
}
