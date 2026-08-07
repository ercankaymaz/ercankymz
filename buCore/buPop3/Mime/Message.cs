// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Message
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Mime.Header;
using ns1;
using ns3;
using ns4;
using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

#nullable disable
namespace buPop3.Mime;

public class Message
{
  public MessageHeader Headers { get; private set; }

  public MessagePart MessagePart { get; private set; }

  public byte[] RawMessage { get; private set; }

  public Message(byte[] rawMessageContent)
    : this(rawMessageContent, true)
  {
  }

  public Message(byte[] rawMessageContent, bool parseBody)
  {
    this.RawMessage = rawMessageContent;
    byte[] byte_0;
    MessageHeader messageHeader_0;
    Class30.smethod_191(ref byte_0, out messageHeader_0, rawMessageContent);
    this.Headers = messageHeader_0;
    if (!parseBody)
      return;
    this.MessagePart = new MessagePart(byte_0, this.Headers);
  }

  public MailMessage ToMailMessage()
  {
    MailMessage mailMessage = new MailMessage();
    mailMessage.Subject = this.Headers.Subject;
    mailMessage.SubjectEncoding = Encoding.UTF8;
    MessagePart messagePart = this.FindFirstHtmlVersion();
    if (messagePart != null)
      mailMessage.IsBodyHtml = true;
    else
      messagePart = this.FindFirstPlainTextVersion();
    if (messagePart != null)
    {
      mailMessage.Body = messagePart.GetBodyAsText();
      mailMessage.BodyEncoding = messagePart.BodyEncoding;
    }
    foreach (MessagePart allTextVersion in (IEnumerable<MessagePart>) this.FindAllTextVersions())
    {
      if (allTextVersion != messagePart)
      {
        AlternateView alternateView = new AlternateView((Stream) new MemoryStream(allTextVersion.Body));
        alternateView.ContentId = allTextVersion.ContentId;
        alternateView.ContentType = allTextVersion.ContentType;
        mailMessage.AlternateViews.Add(alternateView);
      }
    }
    foreach (MessagePart allAttachment in (IEnumerable<MessagePart>) this.FindAllAttachments())
    {
      Attachment attachment = new Attachment((Stream) new MemoryStream(allAttachment.Body), allAttachment.ContentType);
      attachment.ContentId = allAttachment.ContentId;
      mailMessage.Attachments.Add(attachment);
    }
    if ((this.Headers.From == null ? 0 : (this.Headers.From.HasValidMailAddress ? 1 : 0)) != 0)
      mailMessage.From = this.Headers.From.MailAddress;
    if ((this.Headers.ReplyTo == null ? 0 : (this.Headers.ReplyTo.HasValidMailAddress ? 1 : 0)) != 0)
      mailMessage.ReplyToList.Add(this.Headers.ReplyTo.MailAddress);
    if ((this.Headers.Sender == null ? 0 : (this.Headers.Sender.HasValidMailAddress ? 1 : 0)) != 0)
      mailMessage.Sender = this.Headers.Sender.MailAddress;
    foreach (RfcMailAddress rfcMailAddress in this.Headers.To)
    {
      if (rfcMailAddress.HasValidMailAddress)
        mailMessage.To.Add(rfcMailAddress.MailAddress);
    }
    foreach (RfcMailAddress rfcMailAddress in this.Headers.Cc)
    {
      if (rfcMailAddress.HasValidMailAddress)
        mailMessage.CC.Add(rfcMailAddress.MailAddress);
    }
    foreach (RfcMailAddress rfcMailAddress in this.Headers.Bcc)
    {
      if (rfcMailAddress.HasValidMailAddress)
        mailMessage.Bcc.Add(rfcMailAddress.MailAddress);
    }
    return mailMessage;
  }

  public MessagePart FindFirstPlainTextVersion()
  {
    return this.FindFirstMessagePartWithMediaType("text/plain");
  }

  public MessagePart FindFirstHtmlVersion() => this.FindFirstMessagePartWithMediaType("text/html");

  public List<MessagePart> FindAllTextVersions() => new Class7().VisitMessage(this);

  public List<MessagePart> FindAllAttachments() => new Class6().VisitMessage(this);

  public MessagePart FindFirstMessagePartWithMediaType(string mediaType)
  {
    return new Class9().VisitMessage(this, mediaType);
  }

  public List<MessagePart> FindAllMessagePartsWithMediaType(string mediaType)
  {
    return new Class8().VisitMessage(this, mediaType);
  }

  public void Save(FileInfo file)
  {
    if (file == null)
      throw new ArgumentNullException(nameof (file));
    using (FileStream messageStream = new FileStream(file.FullName, FileMode.Create))
      this.Save((Stream) messageStream);
  }

  public void Save(Stream messageStream)
  {
    if (messageStream == null)
      throw new ArgumentNullException(nameof (messageStream));
    messageStream.Write(this.RawMessage, 0, this.RawMessage.Length);
  }

  public static Message Load(FileInfo file)
  {
    if (file == null)
      throw new ArgumentNullException(nameof (file));
    if (!file.Exists)
      throw new FileNotFoundException("Cannot load message from non-existent file", file.FullName);
    using (FileStream messageStream = new FileStream(file.FullName, FileMode.Open))
      return Message.Load((Stream) messageStream);
  }

  public static Message Load(Stream messageStream)
  {
    if (messageStream == null)
      throw new ArgumentNullException(nameof (messageStream));
    using (MemoryStream memoryStream = new MemoryStream())
    {
      byte[] buffer = new byte[4096 /*0x1000*/];
      int count;
      while ((count = messageStream.Read(buffer, 0, 4096 /*0x1000*/)) > 0)
        memoryStream.Write(buffer, 0, count);
      return new Message(memoryStream.ToArray());
    }
  }
}
