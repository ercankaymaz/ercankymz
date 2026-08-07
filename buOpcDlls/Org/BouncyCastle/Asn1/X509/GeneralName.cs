// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.GeneralName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;
using System.Globalization;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class GeneralName : Asn1Encodable, IAsn1Choice
{
  public const int OtherName = 0;
  public const int Rfc822Name = 1;
  public const int DnsName = 2;
  public const int X400Address = 3;
  public const int DirectoryName = 4;
  public const int EdiPartyName = 5;
  public const int UniformResourceIdentifier = 6;
  public const int IPAddress = 7;
  public const int RegisteredID = 8;
  private readonly int m_tag;
  private readonly Asn1Encodable m_object;

  public static GeneralName GetInstance(object obj)
  {
    if (obj == null)
      return (GeneralName) null;
    return obj is GeneralName generalName ? generalName : GeneralName.GetInstanceSelection(Asn1TaggedObject.GetInstance(obj));
  }

  public static GeneralName GetInstance(Asn1TaggedObject tagObj, bool explicitly)
  {
    return Asn1Utilities.GetInstanceFromChoice<GeneralName>(tagObj, explicitly, new Func<object, GeneralName>(GeneralName.GetInstance));
  }

  private static GeneralName GetInstanceSelection(Asn1TaggedObject taggedObject)
  {
    if (taggedObject.HasContextTag())
    {
      int tagNo = taggedObject.TagNo;
      switch (tagNo)
      {
        case 0:
        case 3:
        case 5:
          return new GeneralName(tagNo, (Asn1Encodable) Asn1Sequence.GetInstance(taggedObject, false));
        case 1:
        case 2:
        case 6:
          return new GeneralName(tagNo, (Asn1Encodable) DerIA5String.GetInstance(taggedObject, false));
        case 4:
          return new GeneralName(tagNo, (Asn1Encodable) X509Name.GetInstance(taggedObject, true));
        case 7:
          return new GeneralName(tagNo, (Asn1Encodable) Asn1OctetString.GetInstance(taggedObject, false));
        case 8:
          return new GeneralName(tagNo, (Asn1Encodable) DerObjectIdentifier.GetInstance(taggedObject, false));
      }
    }
    throw new ArgumentException("unknown tag: " + Asn1Utilities.GetTagText(taggedObject));
  }

  public GeneralName(X509Name directoryName)
  {
    this.m_tag = 4;
    this.m_object = (Asn1Encodable) directoryName;
  }

  public GeneralName(Asn1Object name, int tag)
  {
    this.m_tag = tag;
    this.m_object = (Asn1Encodable) name;
  }

  public GeneralName(int tag, Asn1Encodable name)
  {
    this.m_tag = tag;
    this.m_object = name;
  }

  public GeneralName(int tag, string name)
  {
    this.m_tag = tag;
    switch (tag)
    {
      case 1:
      case 2:
      case 6:
        this.m_object = (Asn1Encodable) new DerIA5String(name);
        break;
      case 4:
        this.m_object = (Asn1Encodable) new X509Name(name);
        break;
      case 7:
        this.m_object = (Asn1Encodable) new DerOctetString(this.ToGeneralNameEncoding(name) ?? throw new ArgumentException("IP Address is invalid", nameof (name)));
        break;
      case 8:
        this.m_object = (Asn1Encodable) new DerObjectIdentifier(name);
        break;
      default:
        throw new ArgumentException($"can't process string for tag: {Asn1Utilities.GetTagText(128 /*0x80*/, tag)}", nameof (tag));
    }
  }

  public int TagNo => this.m_tag;

  public Asn1Encodable Name => this.m_object;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(this.m_tag == 4, this.m_tag, this.m_object);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(this.m_tag);
    stringBuilder.Append(": ");
    switch (this.m_tag)
    {
      case 1:
      case 2:
      case 6:
        stringBuilder.Append(DerIA5String.GetInstance((object) this.m_object).GetString());
        break;
      case 4:
        stringBuilder.Append(X509Name.GetInstance((object) this.m_object).ToString());
        break;
      default:
        stringBuilder.Append(this.m_object.ToString());
        break;
    }
    return stringBuilder.ToString();
  }

  private byte[] ToGeneralNameEncoding(string ip)
  {
    if (!Org.BouncyCastle.Utilities.Net.IPAddress.IsValidIPv6WithNetmask(ip) && !Org.BouncyCastle.Utilities.Net.IPAddress.IsValidIPv6(ip))
    {
      if (!Org.BouncyCastle.Utilities.Net.IPAddress.IsValidIPv4WithNetmask(ip) && !Org.BouncyCastle.Utilities.Net.IPAddress.IsValidIPv4(ip))
        return (byte[]) null;
      int length = Platform.IndexOf(ip, '/');
      if (length < 0)
      {
        byte[] addr = new byte[4];
        GeneralName.ParseIPv4(ip, addr, 0);
        return addr;
      }
      byte[] addr1 = new byte[8];
      GeneralName.ParseIPv4(ip.Substring(0, length), addr1, 0);
      string str = ip.Substring(length + 1);
      if (Platform.IndexOf(str, '.') > 0)
        GeneralName.ParseIPv4(str, addr1, 4);
      else
        GeneralName.ParseIPv4Mask(str, addr1, 4);
      return addr1;
    }
    int length1 = Platform.IndexOf(ip, '/');
    if (length1 < 0)
    {
      byte[] addr = new byte[16 /*0x10*/];
      GeneralName.CopyInts(GeneralName.ParseIPv6(ip), addr, 0);
      return addr;
    }
    byte[] addr2 = new byte[32 /*0x20*/];
    GeneralName.CopyInts(GeneralName.ParseIPv6(ip.Substring(0, length1)), addr2, 0);
    string str1 = ip.Substring(length1 + 1);
    GeneralName.CopyInts(Platform.IndexOf(str1, ':') <= 0 ? GeneralName.ParseIPv6Mask(str1) : GeneralName.ParseIPv6(str1), addr2, 16 /*0x10*/);
    return addr2;
  }

  private static void CopyInts(int[] parsedIp, byte[] addr, int offSet)
  {
    for (int index = 0; index != parsedIp.Length; ++index)
    {
      addr[index * 2 + offSet] = (byte) (parsedIp[index] >> 8);
      addr[index * 2 + 1 + offSet] = (byte) parsedIp[index];
    }
  }

  private static void ParseIPv4(string ip, byte[] addr, int offset)
  {
    string str = ip;
    char[] chArray = new char[2]{ '.', '/' };
    foreach (string s in str.Split(chArray))
      addr[offset++] = (byte) int.Parse(s);
  }

  private static void ParseIPv4Mask(string mask, byte[] addr, int offset)
  {
    int num;
    for (num = int.Parse(mask); num >= 8; num -= 8)
      addr[offset++] = byte.MaxValue;
    if (num <= 0)
      return;
    addr[offset] = (byte) (65280 >> num);
  }

  private static int[] ParseIPv6(string ip)
  {
    if (Platform.StartsWith(ip, "::"))
      ip = ip.Substring(1);
    else if (Platform.EndsWith(ip, "::"))
      ip = ip.Substring(0, ip.Length - 1);
    int num1 = 0;
    int[] ipv6 = new int[8];
    int sourceIndex = -1;
    string str1 = ip;
    char[] chArray = new char[1]{ ':' };
    foreach (string str2 in str1.Split(chArray))
    {
      if (str2.Length == 0)
      {
        sourceIndex = num1;
        ipv6[num1++] = 0;
      }
      else if (Platform.IndexOf(str2, '.') < 0)
      {
        ipv6[num1++] = int.Parse(str2, NumberStyles.AllowHexSpecifier);
      }
      else
      {
        string[] strArray = str2.Split('.');
        int[] numArray1 = ipv6;
        int index1 = num1;
        int num2 = index1 + 1;
        int num3 = int.Parse(strArray[0]) << 8 | int.Parse(strArray[1]);
        numArray1[index1] = num3;
        int[] numArray2 = ipv6;
        int index2 = num2;
        num1 = index2 + 1;
        int num4 = int.Parse(strArray[2]) << 8 | int.Parse(strArray[3]);
        numArray2[index2] = num4;
      }
    }
    if (num1 != ipv6.Length)
    {
      Array.Copy((Array) ipv6, sourceIndex, (Array) ipv6, ipv6.Length - (num1 - sourceIndex), num1 - sourceIndex);
      for (int index = sourceIndex; index != ipv6.Length - (num1 - sourceIndex); ++index)
        ipv6[index] = 0;
    }
    return ipv6;
  }

  private static int[] ParseIPv6Mask(string mask)
  {
    int[] ipv6Mask = new int[8];
    int num = int.Parse(mask);
    int index = 0;
    for (; num >= 16 /*0x10*/; num -= 16 /*0x10*/)
      ipv6Mask[index++] = (int) ushort.MaxValue;
    if (num > 0)
      ipv6Mask[index] = (int) ushort.MaxValue >> 16 /*0x10*/ - num;
    return ipv6Mask;
  }
}
