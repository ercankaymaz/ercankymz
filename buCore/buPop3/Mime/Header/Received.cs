// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Header.Received
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace buPop3.Mime.Header;

public class Received
{
  public DateTime Date { get; private set; }

  public Dictionary<string, string> Names { get; private set; }

  public string Raw { get; private set; }

  public Received(string headerValue)
  {
    this.Raw = headerValue != null ? headerValue : throw new ArgumentNullException(nameof (headerValue));
    this.Date = DateTime.MinValue;
    if (headerValue.Contains(";"))
      this.Date = Class30.smethod_236(headerValue.Substring(headerValue.LastIndexOf(";") + 1));
    this.Names = Class30.smethod_14(headerValue);
  }
}
