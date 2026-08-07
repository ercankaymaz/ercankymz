// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ServerName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ServerName
{
  private readonly short nameType;
  private readonly byte[] nameData;

  public ServerName(short nameType, byte[] nameData)
  {
    if (!TlsUtilities.IsValidUint8(nameType))
      throw new ArgumentException("must be from 0 to 255", nameof (nameType));
    if (nameData == null)
      throw new ArgumentNullException(nameof (nameData));
    if (nameData.Length < 1 || !TlsUtilities.IsValidUint16(nameData.Length))
      throw new ArgumentException("must have length from 1 to 65535", nameof (nameData));
    this.nameType = nameType;
    this.nameData = nameData;
  }

  public byte[] NameData => this.nameData;

  public short NameType => this.nameType;

  public void Encode(Stream output)
  {
    TlsUtilities.WriteUint8(this.nameType, output);
    TlsUtilities.WriteOpaque16(this.nameData, output);
  }

  public static ServerName Parse(Stream input)
  {
    return new ServerName(TlsUtilities.ReadUint8(input), TlsUtilities.ReadOpaque16(input, 1));
  }
}
