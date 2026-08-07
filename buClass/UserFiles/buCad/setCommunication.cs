// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setCommunication
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setCommunication : buSerilization
{
  public string IPNumber = "192.168.0.34";
  public string FtpUser = "CNCPC";
  public string FtpPassword = "2016";
  public int FtpPort = 21;
  public string FtpPath = "\\FtpFiles";

  public setCommunication()
  {
  }

  public setCommunication(setCommunication data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
