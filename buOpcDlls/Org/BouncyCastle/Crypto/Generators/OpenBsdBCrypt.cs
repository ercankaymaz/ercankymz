// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.OpenBsdBCrypt
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class OpenBsdBCrypt
{
  private static readonly byte[] EncodingTable = new byte[64 /*0x40*/]
  {
    (byte) 46,
    (byte) 47,
    (byte) 65,
    (byte) 66,
    (byte) 67,
    (byte) 68,
    (byte) 69,
    (byte) 70,
    (byte) 71,
    (byte) 72,
    (byte) 73,
    (byte) 74,
    (byte) 75,
    (byte) 76,
    (byte) 77,
    (byte) 78,
    (byte) 79,
    (byte) 80 /*0x50*/,
    (byte) 81,
    (byte) 82,
    (byte) 83,
    (byte) 84,
    (byte) 85,
    (byte) 86,
    (byte) 87,
    (byte) 88,
    (byte) 89,
    (byte) 90,
    (byte) 97,
    (byte) 98,
    (byte) 99,
    (byte) 100,
    (byte) 101,
    (byte) 102,
    (byte) 103,
    (byte) 104,
    (byte) 105,
    (byte) 106,
    (byte) 107,
    (byte) 108,
    (byte) 109,
    (byte) 110,
    (byte) 111,
    (byte) 112 /*0x70*/,
    (byte) 113,
    (byte) 114,
    (byte) 115,
    (byte) 116,
    (byte) 117,
    (byte) 118,
    (byte) 119,
    (byte) 120,
    (byte) 121,
    (byte) 122,
    (byte) 48 /*0x30*/,
    (byte) 49,
    (byte) 50,
    (byte) 51,
    (byte) 52,
    (byte) 53,
    (byte) 54,
    (byte) 55,
    (byte) 56,
    (byte) 57
  };
  private static readonly byte[] DecodingTable = new byte[128 /*0x80*/];
  private static readonly string DefaultVersion = "2y";
  private static readonly HashSet<string> AllowedVersions = new HashSet<string>();

  static OpenBsdBCrypt()
  {
    OpenBsdBCrypt.AllowedVersions.Add("2a");
    OpenBsdBCrypt.AllowedVersions.Add("2y");
    OpenBsdBCrypt.AllowedVersions.Add("2b");
    for (int index = 0; index < OpenBsdBCrypt.DecodingTable.Length; ++index)
      OpenBsdBCrypt.DecodingTable[index] = byte.MaxValue;
    for (int index = 0; index < OpenBsdBCrypt.EncodingTable.Length; ++index)
      OpenBsdBCrypt.DecodingTable[(int) OpenBsdBCrypt.EncodingTable[index]] = (byte) index;
  }

  private static string CreateBcryptString(string version, byte[] password, byte[] salt, int cost)
  {
    if (!OpenBsdBCrypt.AllowedVersions.Contains(version))
      throw new ArgumentException($"Version {version} is not accepted by this implementation.", nameof (version));
    StringBuilder stringBuilder = new StringBuilder(60);
    stringBuilder.Append('$');
    stringBuilder.Append(version);
    stringBuilder.Append('$');
    stringBuilder.Append(cost < 10 ? "0" + cost.ToString() : cost.ToString());
    stringBuilder.Append('$');
    stringBuilder.Append(OpenBsdBCrypt.EncodeData(salt));
    stringBuilder.Append(OpenBsdBCrypt.EncodeData(BCrypt.Generate(password, salt, cost)));
    return stringBuilder.ToString();
  }

  public static string Generate(char[] password, byte[] salt, int cost)
  {
    return OpenBsdBCrypt.Generate(OpenBsdBCrypt.DefaultVersion, password, salt, cost);
  }

  public static string Generate(string version, char[] password, byte[] salt, int cost)
  {
    if (!OpenBsdBCrypt.AllowedVersions.Contains(version))
      throw new ArgumentException($"Version {version} is not accepted by this implementation.", nameof (version));
    if (password == null)
      throw new ArgumentNullException(nameof (password));
    if (salt == null)
      throw new ArgumentNullException(nameof (salt));
    if (salt.Length != 16 /*0x10*/)
      throw new DataLengthException("16 byte salt required: " + salt.Length.ToString());
    if (cost < 4 || cost > 31 /*0x1F*/)
      throw new ArgumentException("Invalid cost factor.", nameof (cost));
    byte[] utf8ByteArray = Strings.ToUtf8ByteArray(password);
    byte[] numArray = new byte[utf8ByteArray.Length >= 72 ? 72 : utf8ByteArray.Length + 1];
    int length = Math.Min(utf8ByteArray.Length, numArray.Length);
    Array.Copy((Array) utf8ByteArray, 0, (Array) numArray, 0, length);
    Array.Clear((Array) utf8ByteArray, 0, utf8ByteArray.Length);
    string bcryptString = OpenBsdBCrypt.CreateBcryptString(version, numArray, salt, cost);
    Array.Clear((Array) numArray, 0, numArray.Length);
    return bcryptString;
  }

  public static bool CheckPassword(string bcryptString, char[] password)
  {
    if (bcryptString.Length != 60)
      throw new DataLengthException($"Bcrypt String length: {bcryptString.Length.ToString()}, 60 required.");
    string version = bcryptString[0] == '$' && bcryptString[3] == '$' && bcryptString[6] == '$' ? bcryptString.Substring(1, 2) : throw new ArgumentException("Invalid Bcrypt String format.", nameof (bcryptString));
    if (!OpenBsdBCrypt.AllowedVersions.Contains(version))
      throw new ArgumentException($"Bcrypt version '{version}' is not supported by this implementation", nameof (bcryptString));
    int cost;
    try
    {
      cost = int.Parse(bcryptString.Substring(4, 2));
    }
    catch (Exception ex)
    {
      throw new ArgumentException("Invalid cost factor: " + bcryptString.Substring(4, 2), nameof (bcryptString), ex);
    }
    if (cost < 4 || cost > 31 /*0x1F*/)
      throw new ArgumentException($"Invalid cost factor: {cost.ToString()}, 4 < cost < 31 expected.");
    if (password == null)
      throw new ArgumentNullException("Missing password.");
    int startIndex = bcryptString.LastIndexOf('$') + 1;
    int num = bcryptString.Length - 31 /*0x1F*/;
    byte[] salt = OpenBsdBCrypt.DecodeSaltString(bcryptString.Substring(startIndex, num - startIndex));
    string str = OpenBsdBCrypt.Generate(version, password, salt, cost);
    return bcryptString.Equals(str);
  }

  private static string EncodeData(byte[] data)
  {
    if (data.Length != 24 && data.Length != 16 /*0x10*/)
      throw new DataLengthException($"Invalid length: {data.Length.ToString()}, 24 for key or 16 for salt expected");
    bool flag = false;
    if (data.Length == 16 /*0x10*/)
    {
      flag = true;
      byte[] destinationArray = new byte[18];
      Array.Copy((Array) data, 0, (Array) destinationArray, 0, data.Length);
      data = destinationArray;
    }
    else
      data[data.Length - 1] = (byte) 0;
    MemoryStream memoryStream = new MemoryStream();
    int length1 = data.Length;
    for (int index = 0; index < length1; index += 3)
    {
      uint num1 = (uint) data[index];
      uint num2 = (uint) data[index + 1];
      uint num3 = (uint) data[index + 2];
      memoryStream.WriteByte(OpenBsdBCrypt.EncodingTable[(int) (num1 >> 2) & 63 /*0x3F*/]);
      memoryStream.WriteByte(OpenBsdBCrypt.EncodingTable[((int) num1 << 4 | (int) (num2 >> 4)) & 63 /*0x3F*/]);
      memoryStream.WriteByte(OpenBsdBCrypt.EncodingTable[((int) num2 << 2 | (int) (num3 >> 6)) & 63 /*0x3F*/]);
      memoryStream.WriteByte(OpenBsdBCrypt.EncodingTable[(int) num3 & 63 /*0x3F*/]);
    }
    string str = Strings.FromByteArray(memoryStream.ToArray());
    int length2 = flag ? 22 : str.Length - 1;
    return str.Substring(0, length2);
  }

  private static byte[] DecodeSaltString(string saltString)
  {
    char[] charArray = saltString.ToCharArray();
    MemoryStream memoryStream = new MemoryStream(16 /*0x10*/);
    if (charArray.Length != 22)
      throw new DataLengthException($"Invalid base64 salt length: {charArray.Length.ToString()} , 22 required.");
    for (int index = 0; index < charArray.Length; ++index)
    {
      int num = (int) charArray[index];
      if (num > 122 || num < 46 || num > 57 && num < 65)
        throw new ArgumentException("Salt string contains invalid character: " + num.ToString(), nameof (saltString));
    }
    char[] destinationArray1 = new char[24];
    Array.Copy((Array) charArray, 0, (Array) destinationArray1, 0, charArray.Length);
    char[] chArray = destinationArray1;
    int length1 = chArray.Length;
    for (int index = 0; index < length1; index += 4)
    {
      byte num1 = OpenBsdBCrypt.DecodingTable[(int) chArray[index]];
      byte num2 = OpenBsdBCrypt.DecodingTable[(int) chArray[index + 1]];
      byte num3 = OpenBsdBCrypt.DecodingTable[(int) chArray[index + 2]];
      byte num4 = OpenBsdBCrypt.DecodingTable[(int) chArray[index + 3]];
      memoryStream.WriteByte((byte) ((int) num1 << 2 | (int) num2 >> 4));
      memoryStream.WriteByte((byte) ((int) num2 << 4 | (int) num3 >> 2));
      memoryStream.WriteByte((byte) ((uint) num3 << 6 | (uint) num4));
    }
    byte[] array = memoryStream.ToArray();
    byte[] numArray = new byte[16 /*0x10*/];
    byte[] destinationArray2 = numArray;
    int length2 = numArray.Length;
    Array.Copy((Array) array, 0, (Array) destinationArray2, 0, length2);
    return numArray;
  }
}
