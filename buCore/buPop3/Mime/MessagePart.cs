// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.MessagePart
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Mime.Header;
using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;

#nullable disable
namespace buPop3.Mime;

public class MessagePart
{
  public ContentType ContentType { get; private set; }

  public string ContentDescription { get; private set; }

  public buPop3.Mime.Header.ContentTransferEncoding ContentTransferEncoding { get; private set; }

  public string ContentId { get; private set; }

  public ContentDisposition ContentDisposition { get; private set; }

  public Encoding BodyEncoding { get; private set; }

  public byte[] Body { get; internal set; }

  public bool IsMultiPart
  {
    get => this.ContentType.MediaType.StartsWith("multipart/", StringComparison.OrdinalIgnoreCase);
  }

  public bool IsText
  {
    get
    {
      string mediaType = this.ContentType.MediaType;
      return mediaType.StartsWith("text/", StringComparison.OrdinalIgnoreCase) || mediaType.Equals("message/rfc822", StringComparison.OrdinalIgnoreCase);
    }
  }

  public bool IsAttachment
  {
    get
    {
      if (!this.IsText && !this.IsMultiPart)
        return true;
      return this.ContentDisposition != null && !this.ContentDisposition.Inline;
    }
  }

  public string FileName { get; private set; }

  public List<MessagePart> MessageParts { get; private set; }

  internal MessagePart(byte[] byte_1, MessageHeader messageHeader_0)
  {
    if (byte_1 == null)
      throw new ArgumentNullException("rawBody");
    this.ContentType = messageHeader_0 != null ? messageHeader_0.ContentType : throw new ArgumentNullException("headers");
    this.ContentDescription = messageHeader_0.ContentDescription;
    this.ContentTransferEncoding = messageHeader_0.ContentTransferEncoding;
    this.ContentId = messageHeader_0.ContentId;
    this.ContentDisposition = messageHeader_0.ContentDisposition;
    this.FileName = Class30.smethod_147("(no name)", this.ContentDisposition, this.ContentType);
    this.BodyEncoding = Class30.smethod_268(this.ContentType.CharSet);
    Class30.smethod_274(this, byte_1);
  }

  internal void method_0(byte[] byte_1)
  {
    List<byte[]> numArrayList = Class30.smethod_0(this.ContentType.Boundary, byte_1);
    this.MessageParts = new List<MessagePart>(numArrayList.Count);
    foreach (byte[] byte_0 in numArrayList)
      this.MessageParts.Add(Class30.smethod_169(byte_0));
  }

  public string GetBodyAsText() => this.BodyEncoding.GetString(this.Body);

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
    messageStream.Write(this.Body, 0, this.Body.Length);
  }
}
