// Decompiled with JetBrains decompiler
// Type: DevAge.Data.StreamDataSet
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Data;
using System.IO;

#nullable disable
namespace DevAge.Data;

public static class StreamDataSet
{
  public static void Write(Stream destination, DataSet source, StreamDataSetFormat format)
  {
    switch (format)
    {
      case StreamDataSetFormat.XML:
        source.WriteXml(destination, XmlWriteMode.WriteSchema);
        break;
      case StreamDataSetFormat.Binary:
        Class39.smethod_764(destination, source);
        break;
      default:
        throw new ApplicationException("StreamDataSet Format not supported");
    }
  }

  public static void Read(
    Stream source,
    DataSet destination,
    StreamDataSetFormat format,
    bool mergeSchema)
  {
    bool enforceConstraints = destination.EnforceConstraints;
    destination.EnforceConstraints = false;
    try
    {
      switch (format)
      {
        case StreamDataSetFormat.XML:
          if (mergeSchema)
          {
            int num = (int) destination.ReadXml(source, XmlReadMode.ReadSchema);
            break;
          }
          int num1 = (int) destination.ReadXml(source, XmlReadMode.IgnoreSchema);
          break;
        case StreamDataSetFormat.Binary:
          Class39.smethod_756(source, destination, mergeSchema);
          break;
        default:
          throw new ApplicationException("StreamDataSet Format not supported");
      }
    }
    finally
    {
      destination.EnforceConstraints = enforceConstraints;
    }
  }
}
