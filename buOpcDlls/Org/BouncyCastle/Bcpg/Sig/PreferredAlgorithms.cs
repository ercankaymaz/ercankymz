// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.PreferredAlgorithms
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class PreferredAlgorithms : SignatureSubpacket
{
  private static byte[] IntToByteArray(int[] v)
  {
    byte[] byteArray = new byte[v.Length];
    for (int index = 0; index != v.Length; ++index)
      byteArray[index] = (byte) v[index];
    return byteArray;
  }

  public PreferredAlgorithms(
    SignatureSubpacketTag type,
    bool critical,
    bool isLongLength,
    byte[] data)
    : base(type, critical, isLongLength, data)
  {
  }

  public PreferredAlgorithms(SignatureSubpacketTag type, bool critical, int[] preferences)
    : base(type, critical, false, PreferredAlgorithms.IntToByteArray(preferences))
  {
  }

  public int[] GetPreferences()
  {
    int[] preferences = new int[this.data.Length];
    for (int index = 0; index != preferences.Length; ++index)
      preferences[index] = (int) this.data[index] & (int) byte.MaxValue;
    return preferences;
  }
}
