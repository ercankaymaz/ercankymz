// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Header.RfcMailAddress
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Net.Mail;

#nullable disable
namespace buPop3.Mime.Header;

public class RfcMailAddress
{
  public string Address { get; private set; }

  public string DisplayName { get; private set; }

  public string Raw { get; private set; }

  public MailAddress MailAddress { get; private set; }

  public bool HasValidMailAddress => this.MailAddress != null;

  internal RfcMailAddress(MailAddress mailAddress_1, string string_3)
  {
    if (mailAddress_1 == null)
      throw new ArgumentNullException("mailAddress");
    if (string_3 == null)
      throw new ArgumentNullException("raw");
    this.MailAddress = mailAddress_1;
    this.Address = mailAddress_1.Address;
    this.DisplayName = mailAddress_1.DisplayName;
    this.Raw = string_3;
  }

  internal RfcMailAddress(string string_3)
  {
    if (string_3 == null)
      throw new ArgumentNullException("raw");
    this.MailAddress = (MailAddress) null;
    this.Address = string.Empty;
    this.DisplayName = string_3;
    this.Raw = string_3;
  }

  public override string ToString()
  {
    return !this.HasValidMailAddress ? this.Raw : this.MailAddress.ToString();
  }
}
