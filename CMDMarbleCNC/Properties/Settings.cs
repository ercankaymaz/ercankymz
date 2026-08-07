// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Properties.Settings
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

#nullable disable
namespace MarbleCNC.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.1.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
  private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

  public static Settings Default
  {
    get
    {
      Settings defaultInstance = Settings.defaultInstance;
      return defaultInstance;
    }
  }
}
