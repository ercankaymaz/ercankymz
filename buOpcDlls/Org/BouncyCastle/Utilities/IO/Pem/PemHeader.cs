// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.IO.Pem.PemHeader
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.IO.Pem;

public class PemHeader
{
  private string name;
  private string val;

  public PemHeader(string name, string val)
  {
    this.name = name;
    this.val = val;
  }

  public virtual string Name => this.name;

  public virtual string Value => this.val;

  public override int GetHashCode()
  {
    return this.GetHashCode(this.name) + 31 /*0x1F*/ * this.GetHashCode(this.val);
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    if (!(obj is PemHeader))
      return false;
    PemHeader pemHeader = (PemHeader) obj;
    return object.Equals((object) this.name, (object) pemHeader.name) && object.Equals((object) this.val, (object) pemHeader.val);
  }

  private int GetHashCode(string s) => s == null ? 1 : s.GetHashCode();

  public override string ToString() => $"{this.name}:{this.val}";
}
