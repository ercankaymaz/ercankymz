// Decompiled with JetBrains decompiler
// Type: DevAge.Data.FileDataSet
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

#nullable disable
namespace DevAge.Data;

public abstract class FileDataSet
{
  private StreamDataSetFormat streamDataSetFormat_0 = StreamDataSetFormat.Binary;
  private StreamDataSetFormat streamDataSetFormat_1;
  private bool bool_0 = false;
  private string string_0;

  protected StreamDataSetFormat SaveDataFormat
  {
    get => this.streamDataSetFormat_0;
    set => this.streamDataSetFormat_0 = value;
  }

  protected StreamDataSetFormat FileDataFormat => this.streamDataSetFormat_1;

  protected bool MergeReadedSchema
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public string FileName
  {
    get => this.string_0;
    set => this.string_0 = value;
  }

  protected abstract int GetDataVersion();

  protected abstract DataSet CreateData(int version);

  protected virtual void SaveToFile(DataSet pDataSet)
  {
    if (this.string_0 == null)
      throw new ApplicationException("FileName is null");
    byte[] array1;
    using (MemoryStream w = new MemoryStream())
    {
      XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) w, Encoding.UTF8);
      xmlTextWriter.WriteStartDocument();
      xmlTextWriter.WriteStartElement("filedataset", "http://www.devage.com/FileDataSet");
      xmlTextWriter.WriteStartElement("header", "http://www.devage.com/FileDataSet");
      xmlTextWriter.WriteAttributeString("fileversion", 1.ToString());
      xmlTextWriter.WriteAttributeString("dataversion", this.GetDataVersion().ToString());
      xmlTextWriter.WriteAttributeString("dataformat", ((int) this.streamDataSetFormat_0).ToString());
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.WriteStartElement("data", "http://www.devage.com/FileDataSet");
      byte[] array2;
      using (MemoryStream destination = new MemoryStream())
      {
        StreamDataSet.Write((Stream) destination, pDataSet, this.streamDataSetFormat_0);
        array2 = destination.ToArray();
        destination.Close();
      }
      xmlTextWriter.WriteBase64(array2, 0, array2.Length);
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.WriteEndElement();
      xmlTextWriter.WriteEndDocument();
      xmlTextWriter.Flush();
      array1 = w.ToArray();
      w.Close();
    }
    using (FileStream fileStream = new FileStream(this.string_0, FileMode.Create, FileAccess.Write))
    {
      fileStream.Write(array1, 0, array1.Length);
      fileStream.Close();
    }
  }

  protected virtual DataSet LoadFromFile()
  {
    if (this.string_0 == null)
      throw new ApplicationException("FileName is null");
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.Load(this.string_0);
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
    nsmgr.AddNamespace("fileds", "http://www.devage.com/FileDataSet");
    XmlElement xmlElement = (XmlElement) (xmlDocument.DocumentElement.SelectSingleNode("fileds:header", nsmgr) ?? throw new ApplicationException("File header not found"));
    int num = int.Parse(xmlElement.GetAttribute("fileversion"));
    switch (num)
    {
      case 0:
        this.streamDataSetFormat_1 = StreamDataSetFormat.XML;
        break;
      case 1:
        this.streamDataSetFormat_1 = (StreamDataSetFormat) int.Parse(xmlElement.GetAttribute("dataformat"));
        break;
      default:
        if (num > 1)
          throw new ApplicationException("File Version not supported, expected: " + 1.ToString());
        break;
    }
    DataSet data = this.CreateData(int.Parse(xmlElement.GetAttribute("dataversion")));
    XmlNode xmlNode = xmlDocument.DocumentElement.SelectSingleNode("fileds:data", nsmgr);
    if (xmlNode == null)
      throw new ApplicationException("File data not found");
    using (MemoryStream source = new MemoryStream(Convert.FromBase64String(xmlNode.InnerText)))
      StreamDataSet.Read((Stream) source, data, this.streamDataSetFormat_1, this.MergeReadedSchema);
    return data;
  }
}
