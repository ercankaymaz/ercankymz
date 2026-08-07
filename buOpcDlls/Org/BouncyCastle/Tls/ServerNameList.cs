// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ServerNameList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class ServerNameList
{
  private readonly IList<ServerName> m_serverNameList;

  public ServerNameList(IList<ServerName> serverNameList)
  {
    this.m_serverNameList = serverNameList != null ? serverNameList : throw new ArgumentNullException(nameof (serverNameList));
  }

  public IList<ServerName> ServerNames => this.m_serverNameList;

  public void Encode(Stream output)
  {
    MemoryStream output1 = new MemoryStream();
    short[] nameTypesSeen = TlsUtilities.EmptyShorts;
    foreach (ServerName serverName in (IEnumerable<ServerName>) this.ServerNames)
    {
      nameTypesSeen = ServerNameList.CheckNameType(nameTypesSeen, serverName.NameType);
      if (nameTypesSeen == null)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      serverName.Encode((Stream) output1);
    }
    int int32 = Convert.ToInt32(output1.Length);
    TlsUtilities.CheckUint16(int32);
    TlsUtilities.WriteUint16(int32, output);
    output1.WriteTo(output);
  }

  public static ServerNameList Parse(Stream input)
  {
    MemoryStream input1 = new MemoryStream(TlsUtilities.ReadOpaque16(input, 1), false);
    short[] nameTypesSeen = TlsUtilities.EmptyShorts;
    List<ServerName> serverNameList = new List<ServerName>();
    while (input1.Position < input1.Length)
    {
      ServerName serverName = ServerName.Parse((Stream) input1);
      nameTypesSeen = ServerNameList.CheckNameType(nameTypesSeen, serverName.NameType);
      if (nameTypesSeen == null)
        throw new TlsFatalAlert((short) 47);
      serverNameList.Add(serverName);
    }
    return new ServerNameList((IList<ServerName>) serverNameList);
  }

  private static short[] CheckNameType(short[] nameTypesSeen, short nameType)
  {
    return Arrays.Contains(nameTypesSeen, nameType) ? (short[]) null : Arrays.Append(nameTypesSeen, nameType);
  }
}
