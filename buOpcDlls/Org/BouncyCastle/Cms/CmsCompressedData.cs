// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsCompressedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.IO.Compression;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class CmsCompressedData
{
  internal ContentInfo contentInfo;

  public CmsCompressedData(byte[] compressedData)
    : this(CmsUtilities.ReadContentInfo(compressedData))
  {
  }

  public CmsCompressedData(Stream compressedDataStream)
    : this(CmsUtilities.ReadContentInfo(compressedDataStream))
  {
  }

  public CmsCompressedData(ContentInfo contentInfo) => this.contentInfo = contentInfo;

  public byte[] GetContent()
  {
    Stream inStream = ZLib.DecompressInput(((Asn1OctetString) CompressedData.GetInstance((object) this.contentInfo.Content).EncapContentInfo.Content).GetOctetStream());
    try
    {
      return CmsUtilities.StreamToByteArray(inStream);
    }
    catch (IOException ex)
    {
      throw new CmsException("exception reading compressed stream.", (Exception) ex);
    }
    finally
    {
      inStream.Dispose();
    }
  }

  public byte[] GetContent(int limit)
  {
    Stream inStream = ZLib.DecompressInput(((Asn1OctetString) CompressedData.GetInstance((object) this.contentInfo.Content).EncapContentInfo.Content).GetOctetStream());
    try
    {
      return CmsUtilities.StreamToByteArray(inStream, limit);
    }
    catch (IOException ex)
    {
      throw new CmsException("exception reading compressed stream.", (Exception) ex);
    }
  }

  public ContentInfo ContentInfo => this.contentInfo;

  public byte[] GetEncoded() => this.contentInfo.GetEncoded();
}
