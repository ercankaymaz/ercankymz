// Decompiled with JetBrains decompiler
// Type: DevAge.Runtime.Serialization.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#nullable disable
namespace DevAge.Runtime.Serialization;

public static class Utilities
{
  public static object BinDeserialize(Stream p_Stream)
  {
    return new BinaryFormatter().Deserialize(p_Stream);
  }

  public static void BinSerialize(Stream p_Stream, object p_Object)
  {
    new BinaryFormatter().Serialize(p_Stream, p_Object);
  }

  public static object BinDeserialize(string p_strFileName)
  {
    object obj;
    using (FileStream p_Stream = new FileStream(p_strFileName, FileMode.Open, FileAccess.Read))
    {
      obj = Utilities.BinDeserialize((Stream) p_Stream);
      p_Stream.Close();
    }
    return obj;
  }

  public static void BinSerialize(string p_strFileName, object p_Object)
  {
    using (FileStream p_Stream = new FileStream(p_strFileName, FileMode.Create, FileAccess.Write))
    {
      Utilities.BinSerialize((Stream) p_Stream, p_Object);
      p_Stream.Close();
    }
  }
}
