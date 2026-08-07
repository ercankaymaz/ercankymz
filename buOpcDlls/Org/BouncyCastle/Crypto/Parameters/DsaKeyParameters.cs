// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DsaKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public abstract class DsaKeyParameters : AsymmetricKeyParameter
{
  private readonly DsaParameters parameters;

  protected DsaKeyParameters(bool isPrivate, DsaParameters parameters)
    : base(isPrivate)
  {
    this.parameters = parameters;
  }

  public DsaParameters Parameters => this.parameters;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is DsaKeyParameters other && this.Equals(other);
  }

  protected bool Equals(DsaKeyParameters other)
  {
    return object.Equals((object) this.parameters, (object) other.parameters) && this.Equals((AsymmetricKeyParameter) other);
  }

  public override int GetHashCode()
  {
    int hashCode = base.GetHashCode();
    if (this.parameters != null)
      hashCode ^= this.parameters.GetHashCode();
    return hashCode;
  }
}
