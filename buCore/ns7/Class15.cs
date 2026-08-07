// Decompiled with JetBrains decompiler
// Type: ns7.Class15
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

#nullable disable
namespace ns7;

internal static class Class15
{
  public static List<KeyValuePair<string, string>> smethod_0(string string_0)
  {
    string_0 = string_0 != null ? Regex.Replace(string_0, "=\\s*\"(?<value>[^\"]*)\"\\s", "=\"${value}\"; ") : throw new ArgumentNullException("toDecode");
    string_0 = Regex.Replace(string_0, "^(?<first>[^;\\s]+)\\s(?<second>[^;\\s]+)", "${first}; ${second}");
    List<string> stringList = Class30.smethod_189(';', string_0.Trim());
    List<KeyValuePair<string, string>> list_0 = new List<KeyValuePair<string, string>>(stringList.Count);
    foreach (string str in stringList)
    {
      if (str.Trim().Length != 0)
      {
        string[] strArray = str.Trim().Split(new char[1]
        {
          '='
        }, 2);
        if (strArray.Length == 1)
          list_0.Add(new KeyValuePair<string, string>("", strArray[0]));
        else if (strArray.Length == 2)
          list_0.Add(new KeyValuePair<string, string>(strArray[0], strArray[1]));
        else
          throw new ArgumentException($"When splitting the part \"{str}\" by = there was {strArray.Length.ToString()} parts. Only 1 and 2 are supported");
      }
    }
    return Class15.smethod_1(list_0);
  }

  private static List<KeyValuePair<string, string>> smethod_1(
    List<KeyValuePair<string, string>> list_0)
  {
    List<KeyValuePair<string, string>> keyValuePairList = list_0 != null ? new List<KeyValuePair<string, string>>(list_0.Count) : throw new ArgumentNullException("pairs");
    int count = list_0.Count;
    for (int index1 = 0; index1 < count; ++index1)
    {
      KeyValuePair<string, string> keyValuePair = list_0[index1];
      string key1 = keyValuePair.Key;
      string string_1_1 = Class30.smethod_10(keyValuePair.Value);
      if ((key1.EndsWith("*0", StringComparison.OrdinalIgnoreCase) ? 1 : (key1.EndsWith("*0*", StringComparison.OrdinalIgnoreCase) ? 1 : 0)) != 0)
      {
        string string_0 = "notEncoded - Value here is never used";
        string key2;
        if (key1.EndsWith("*0*", StringComparison.OrdinalIgnoreCase))
        {
          string_1_1 = Class30.smethod_229(ref string_0, string_1_1);
          key2 = key1.Replace("*0*", "");
        }
        else
          key2 = key1.Replace("*0", "");
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string_1_1);
        int index2 = index1 + 1;
        int num = 1;
        while (index2 < count)
        {
          string key3 = list_0[index2].Key;
          string string_1_2 = Class30.smethod_10(list_0[index2].Value);
          if (key3.Equals($"{key2}*{num.ToString()}"))
          {
            stringBuilder.Append(string_1_2);
            ++index1;
          }
          else if (key3.Equals($"{key2}*{num.ToString()}*"))
          {
            if (string_0 != null)
              string_1_2 = Class30.smethod_72(string_0, string_1_2);
            stringBuilder.Append(string_1_2);
            ++index1;
          }
          else
            break;
          ++index2;
          ++num;
        }
        string str = stringBuilder.ToString();
        keyValuePairList.Add(new KeyValuePair<string, string>(key2, str));
      }
      else if (key1.EndsWith("*", StringComparison.OrdinalIgnoreCase))
      {
        string key4 = key1.Replace("*", "");
        string string_0;
        string str = Class30.smethod_229(ref string_0, string_1_1);
        keyValuePairList.Add(new KeyValuePair<string, string>(key4, str));
      }
      else
        keyValuePairList.Add(keyValuePair);
    }
    return keyValuePairList;
  }
}
