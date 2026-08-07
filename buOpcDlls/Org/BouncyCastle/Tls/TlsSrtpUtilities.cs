// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsSrtpUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class TlsSrtpUtilities
{
  public static void AddUseSrtpExtension(
    IDictionary<int, byte[]> extensions,
    UseSrtpData useSrtpData)
  {
    extensions[14] = TlsSrtpUtilities.CreateUseSrtpExtension(useSrtpData);
  }

  public static UseSrtpData GetUseSrtpExtension(IDictionary<int, byte[]> extensions)
  {
    byte[] extensionData = TlsUtilities.GetExtensionData(extensions, 14);
    return extensionData != null ? TlsSrtpUtilities.ReadUseSrtpExtension(extensionData) : (UseSrtpData) null;
  }

  public static byte[] CreateUseSrtpExtension(UseSrtpData useSrtpData)
  {
    if (useSrtpData == null)
      throw new ArgumentNullException(nameof (useSrtpData));
    MemoryStream output = new MemoryStream();
    TlsUtilities.WriteUint16ArrayWithUint16Length(useSrtpData.ProtectionProfiles, (Stream) output);
    TlsUtilities.WriteOpaque8(useSrtpData.Mki, (Stream) output);
    return output.ToArray();
  }

  public static UseSrtpData ReadUseSrtpExtension(byte[] extensionData)
  {
    MemoryStream memoryStream = extensionData != null ? new MemoryStream(extensionData, false) : throw new ArgumentNullException(nameof (extensionData));
    int num = TlsUtilities.ReadUint16((Stream) memoryStream);
    int[] protectionProfiles = num >= 2 && (num & 1) == 0 ? TlsUtilities.ReadUint16Array(num / 2, (Stream) memoryStream) : throw new TlsFatalAlert((short) 50);
    byte[] numArray = TlsUtilities.ReadOpaque8((Stream) memoryStream);
    TlsProtocol.AssertEmpty(memoryStream);
    byte[] mki = numArray;
    return new UseSrtpData(protectionProfiles, mki);
  }
}
