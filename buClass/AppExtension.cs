// Decompiled with JetBrains decompiler
// Type: buClass.AppExtension
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;

#nullable disable
namespace buClass;

[Serializable]
public class AppExtension : buSerilization
{
  public static ArrayList OpenFileExtension = new ArrayList();
  public static ArrayList SaveFileExtension = new ArrayList();
  public static ArrayList GCodeFileExtension = new ArrayList();
  public static ArrayList ImportFileExtension = new ArrayList();
  public static ArrayList ExportFileExtension = new ArrayList();
}
