// Decompiled with JetBrains decompiler
// Type: CmdLanguage.API.LanguageDatabase
// Assembly: CmdLangAPI, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DDC57675-BB9D-4653-8FAD-2A25490EEE99
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\CmdLangAPI.dll

using System.Collections.Generic;

#nullable disable
namespace CmdLanguage.API;

public class LanguageDatabase
{
  public List<string> SupportedLanguages = new List<string>();
  public List<LanguageItem> Items = new List<LanguageItem>();
}
