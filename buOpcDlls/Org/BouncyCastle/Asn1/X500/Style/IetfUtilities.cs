// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X500.Style.IetfUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X500.Style;

public abstract class IetfUtilities
{
  public static string ValueToString(Asn1Encodable value)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (value is IAsn1String && !(value is DerUniversalString))
    {
      string str = ((IAsn1String) value).GetString();
      if (str.Length > 0 && str[0] == '#')
        stringBuilder.Append('\\');
      stringBuilder.Append(str);
    }
    else
    {
      try
      {
        stringBuilder.Append('#');
        stringBuilder.Append(Hex.ToHexString(value.ToAsn1Object().GetEncoded("DER")));
      }
      catch (IOException ex)
      {
        throw new ArgumentException("Other value has no encoded form", (Exception) ex);
      }
    }
    int length = stringBuilder.Length;
    int index1 = 0;
    if (stringBuilder.Length >= 2 && stringBuilder[0] == '\\' && stringBuilder[1] == '#')
      index1 += 2;
    while (index1 != length)
    {
      switch (stringBuilder[index1])
      {
        case '"':
        case '+':
        case ',':
        case ';':
        case '<':
        case '=':
        case '>':
        case '\\':
          stringBuilder.Insert(index1, "\\");
          index1 += 2;
          ++length;
          continue;
        default:
          ++index1;
          continue;
      }
    }
    int index2 = 0;
    if (stringBuilder.Length > 0)
    {
      for (; stringBuilder.Length > index2 && stringBuilder[index2] == ' '; index2 += 2)
        stringBuilder.Insert(index2, "\\");
    }
    for (int index3 = stringBuilder.Length - 1; index3 >= 0 && stringBuilder[index3] == ' '; --index3)
      stringBuilder.Insert(index3, "\\");
    return stringBuilder.ToString();
  }

  public static string Canonicalize(string s)
  {
    string str = s.ToLowerInvariant();
    if (str.Length > 0 && str[0] == '#' && IetfUtilities.DecodeObject(str) is IAsn1String asn1String)
      str = asn1String.GetString().ToLowerInvariant();
    if (str.Length > 1)
    {
      int num = 0;
      while (num + 1 < str.Length && str[num] == '\\' && str[num + 1] == ' ')
        num += 2;
      int index = str.Length - 1;
      while (index - 1 > 0 && str[index - 1] == '\\' && str[index] == ' ')
        index -= 2;
      if (num > 0 || index < str.Length - 1)
        str = str.Substring(num, index + 1 - num);
    }
    return IetfUtilities.StripInternalSpaces(str);
  }

  public static string CanonicalString(Asn1Encodable value)
  {
    return IetfUtilities.Canonicalize(IetfUtilities.ValueToString(value));
  }

  private static Asn1Object DecodeObject(string oValue)
  {
    try
    {
      return Asn1Object.FromByteArray(Hex.DecodeStrict(oValue, 1, oValue.Length - 1));
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException("unknown encoding in name: " + ex?.ToString());
    }
  }

  public static string StripInternalSpaces(string str)
  {
    if (str.IndexOf("  ") < 0)
      return str;
    StringBuilder stringBuilder = new StringBuilder();
    char ch1 = str[0];
    stringBuilder.Append(ch1);
    for (int index = 1; index < str.Length; ++index)
    {
      char ch2 = str[index];
      if (' ' != ch1 || ' ' != ch2)
      {
        stringBuilder.Append(ch2);
        ch1 = ch2;
      }
    }
    return stringBuilder.ToString();
  }

  public static bool RdnAreEqual(Rdn rdn1, Rdn rdn2)
  {
    if (rdn1.Count != rdn2.Count)
      return false;
    AttributeTypeAndValue[] typesAndValues1 = rdn1.GetTypesAndValues();
    AttributeTypeAndValue[] typesAndValues2 = rdn2.GetTypesAndValues();
    if (typesAndValues1.Length != typesAndValues2.Length)
      return false;
    for (int index = 0; index != typesAndValues1.Length; ++index)
    {
      if (!IetfUtilities.AtvAreEqual(typesAndValues1[index], typesAndValues2[index]))
        return false;
    }
    return true;
  }

  private static bool AtvAreEqual(AttributeTypeAndValue atv1, AttributeTypeAndValue atv2)
  {
    return atv1 == atv2 || atv1 != null && atv2 != null && atv1.Type.Equals((Asn1Object) atv2.Type) && IetfUtilities.CanonicalString(atv1.Value).Equals(IetfUtilities.CanonicalString(atv2.Value));
  }
}
