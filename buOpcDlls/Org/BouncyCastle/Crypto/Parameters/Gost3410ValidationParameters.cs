// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Gost3410ValidationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class Gost3410ValidationParameters
{
  private int x0;
  private int c;
  private long x0L;
  private long cL;

  public Gost3410ValidationParameters(int x0, int c)
  {
    this.x0 = x0;
    this.c = c;
  }

  public Gost3410ValidationParameters(long x0L, long cL)
  {
    this.x0L = x0L;
    this.cL = cL;
  }

  public int C => this.c;

  public int X0 => this.x0;

  public long CL => this.cL;

  public long X0L => this.x0L;

  public override bool Equals(object obj)
  {
    return obj is Gost3410ValidationParameters validationParameters && validationParameters.c == this.c && validationParameters.x0 == this.x0 && validationParameters.cL == this.cL && validationParameters.x0L == this.x0L;
  }

  public override int GetHashCode()
  {
    return this.c.GetHashCode() ^ this.x0.GetHashCode() ^ this.cL.GetHashCode() ^ this.x0L.GetHashCode();
  }
}
