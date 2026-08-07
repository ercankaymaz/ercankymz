// Decompiled with JetBrains decompiler
// Type: ns0.Class11
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Collections.Generic;
using System.Net.Mime;

#nullable disable
namespace ns0;

internal static class Class11
{
  public static ContentType smethod_0(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("headerValue");
    ContentType contentType = new ContentType();
    foreach (KeyValuePair<string, string> keyValuePair in Class15.smethod_0(string_0))
    {
      string key = keyValuePair.Key.ToUpperInvariant().Trim();
      string string_0_1 = Class30.smethod_10(keyValuePair.Value.Trim());
      switch (key)
      {
        case "":
          if (string_0_1.ToUpperInvariant().Equals("TEXT"))
            string_0_1 = "text/plain";
          contentType.MediaType = string_0_1;
          continue;
        case "BOUNDARY":
          contentType.Boundary = string_0_1;
          continue;
        case "CHARSET":
          contentType.CharSet = string_0_1;
          continue;
        case "NAME":
          contentType.Name = Class30.smethod_179(string_0_1);
          continue;
        default:
          if (contentType.Parameters == null)
            throw new Exception("The ContentType parameters property is null. This will never be thrown.");
          contentType.Parameters.Add(key, string_0_1);
          continue;
      }
    }
    return contentType;
  }

  public static ContentDisposition smethod_1(string string_0)
  {
    if (string_0 == null)
      throw new ArgumentNullException("headerValue");
    ContentDisposition contentDisposition = new ContentDisposition();
    foreach (KeyValuePair<string, string> keyValuePair in Class15.smethod_0(string_0))
    {
      string key = keyValuePair.Key.ToUpperInvariant().Trim();
      string string_0_1 = Class30.smethod_10(keyValuePair.Value.Trim());
      string string_0_2 = key;
      switch (Class30.smethod_119(string_0_2))
      {
        case 1387956774:
          if (string_0_2 == "NAME")
            break;
          goto default;
        case 1636987420:
          if (string_0_2 == "SIZE")
          {
            contentDisposition.Size = Class30.smethod_265(string_0_1);
            continue;
          }
          goto default;
        case 1871182975:
          if (string_0_2 == "CREATION-DATE")
          {
            DateTime dateTime = new DateTime(Class30.smethod_236(string_0_1).Ticks);
            contentDisposition.CreationDate = dateTime;
            continue;
          }
          goto default;
        case 2166136261:
          if (string_0_2 != null && string_0_2.Length == 0)
          {
            contentDisposition.DispositionType = string_0_1;
            continue;
          }
          goto default;
        case 2878731272:
          if (!(string_0_2 == "FILENAME"))
            goto default;
          break;
        case 3159649708:
          if (string_0_2 == "READ-DATE")
          {
            DateTime dateTime = new DateTime(Class30.smethod_236(string_0_1).Ticks);
            contentDisposition.ReadDate = dateTime;
            continue;
          }
          goto default;
        case 4267520964:
          if (string_0_2 == "MODIFICATION-DATE")
          {
            DateTime dateTime = new DateTime(Class30.smethod_236(string_0_1).Ticks);
            contentDisposition.ModificationDate = dateTime;
            continue;
          }
          goto default;
        default:
          if (!key.StartsWith("X-"))
            throw new ArgumentException("Unknown parameter in Content-Disposition. Ask developer to fix! Parameter: " + key);
          contentDisposition.Parameters.Add(key, string_0_1);
          continue;
      }
      contentDisposition.FileName = Class30.smethod_179(string_0_1);
    }
    return contentDisposition;
  }
}
