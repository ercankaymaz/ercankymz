// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.Haraka256EngineProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal sealed class Haraka256EngineProvider : ISphincsPlusEngineProvider
{
  private readonly bool robust;
  private readonly int n;
  private readonly uint w;
  private readonly uint d;
  private readonly int a;
  private readonly int k;
  private readonly uint h;

  public Haraka256EngineProvider(bool robust, int n, uint w, uint d, int a, int k, uint h)
  {
    this.robust = robust;
    this.n = n;
    this.w = w;
    this.d = d;
    this.a = a;
    this.k = k;
    this.h = h;
  }

  public int N => this.n;

  public SphincsPlusEngine Get()
  {
    return (SphincsPlusEngine) new SphincsPlusEngine.HarakaSEngine(this.robust, this.n, this.w, this.d, this.a, this.k, this.h);
  }
}
