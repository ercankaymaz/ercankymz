// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsContentInfoParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsContentInfoParser : IDisposable
{
  protected ContentInfoParser contentInfo;
  protected Stream data;

  protected CmsContentInfoParser(Stream data)
  {
    this.data = data != null ? data : throw new ArgumentNullException(nameof (data));
    try
    {
      this.contentInfo = new ContentInfoParser((Asn1SequenceParser) new Asn1StreamParser(data).ReadObject());
    }
    catch (IOException ex)
    {
      throw new CmsException("IOException reading content.", (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw new CmsException("Unexpected object reading content.", (Exception) ex);
    }
  }

  [Obsolete("Dispose instead")]
  public void Close() => this.Dispose();

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.data.Dispose();
  }
}
