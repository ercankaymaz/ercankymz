// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crmf.DefaultPKMacResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Crmf;

internal sealed class DefaultPKMacResult : IBlockResult
{
  private readonly IMac mac;

  public DefaultPKMacResult(IMac mac) => this.mac = mac;

  public byte[] Collect()
  {
    byte[] output = new byte[this.mac.GetMacSize()];
    this.mac.DoFinal(output, 0);
    return output;
  }

  public int Collect(byte[] buf, int off) => this.mac.DoFinal(buf, off);

  public int GetMaxResultLength() => this.mac.GetMacSize();
}
