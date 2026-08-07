// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ServerSrpParams
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ServerSrpParams
{
  private BigInteger m_N;
  private BigInteger m_g;
  private BigInteger m_B;
  private byte[] m_s;

  public ServerSrpParams(BigInteger N, BigInteger g, byte[] s, BigInteger B)
  {
    this.m_N = N;
    this.m_g = g;
    this.m_s = Arrays.Clone(s);
    this.m_B = B;
  }

  public BigInteger B => this.m_B;

  public BigInteger G => this.m_g;

  public BigInteger N => this.m_N;

  public byte[] S => this.m_s;

  public void Encode(Stream output)
  {
    TlsSrpUtilities.WriteSrpParameter(this.m_N, output);
    TlsSrpUtilities.WriteSrpParameter(this.m_g, output);
    TlsUtilities.WriteOpaque8(this.m_s, output);
    TlsSrpUtilities.WriteSrpParameter(this.m_B, output);
  }

  public static ServerSrpParams Parse(Stream input)
  {
    BigInteger N = TlsSrpUtilities.ReadSrpParameter(input);
    BigInteger bigInteger1 = TlsSrpUtilities.ReadSrpParameter(input);
    byte[] numArray = TlsUtilities.ReadOpaque8(input, 1);
    BigInteger bigInteger2 = TlsSrpUtilities.ReadSrpParameter(input);
    BigInteger g = bigInteger1;
    byte[] s = numArray;
    BigInteger B = bigInteger2;
    return new ServerSrpParams(N, g, s, B);
  }
}
