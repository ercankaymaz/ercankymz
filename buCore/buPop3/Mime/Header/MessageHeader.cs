// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Header.MessageHeader
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns7;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Mime;

#nullable disable
namespace buPop3.Mime.Header;

public sealed class MessageHeader
{
  public NameValueCollection UnknownHeaders { get; private set; }

  public string ContentDescription { get; internal set; }

  public string ContentId { get; internal set; }

  public List<string> Keywords { get; private set; }

  public List<RfcMailAddress> DispositionNotificationTo { get; internal set; }

  public List<buPop3.Mime.Header.Received> Received { get; private set; }

  public MailPriority Importance { get; internal set; }

  public ContentTransferEncoding ContentTransferEncoding { get; internal set; }

  public List<RfcMailAddress> Cc { get; internal set; }

  public List<RfcMailAddress> Bcc { get; internal set; }

  public List<RfcMailAddress> To { get; internal set; }

  public RfcMailAddress From { get; internal set; }

  public RfcMailAddress ReplyTo { get; internal set; }

  public List<string> InReplyTo { get; internal set; }

  public List<string> References { get; internal set; }

  public RfcMailAddress Sender { get; internal set; }

  public ContentType ContentType { get; internal set; }

  public ContentDisposition ContentDisposition { get; internal set; }

  public string Date { get; internal set; }

  public DateTime DateSent { get; internal set; }

  public string MessageId { get; internal set; }

  public string MimeVersion { get; internal set; }

  public RfcMailAddress ReturnPath { get; internal set; }

  public string Subject { get; internal set; }

  internal MessageHeader(NameValueCollection nameValueCollection_1)
  {
    if (nameValueCollection_1 == null)
      throw new ArgumentNullException("headers");
    this.To = new List<RfcMailAddress>(0);
    this.Cc = new List<RfcMailAddress>(0);
    this.Bcc = new List<RfcMailAddress>(0);
    this.Received = new List<buPop3.Mime.Header.Received>();
    this.Keywords = new List<string>();
    this.InReplyTo = new List<string>(0);
    this.References = new List<string>(0);
    this.DispositionNotificationTo = new List<RfcMailAddress>();
    this.UnknownHeaders = new NameValueCollection();
    this.Importance = MailPriority.Normal;
    this.ContentTransferEncoding = ContentTransferEncoding.SevenBit;
    this.ContentType = new ContentType("text/plain; charset=us-ascii");
    Class30.smethod_244(this, nameValueCollection_1);
  }
}
