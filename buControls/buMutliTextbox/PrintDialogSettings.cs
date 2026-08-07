// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.PrintDialogSettings
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace buMutliTextbox;

public class PrintDialogSettings
{
  public PrintDialogSettings()
  {
    this.ShowPrintPreviewDialog = true;
    this.Title = "";
    this.Footer = "";
    this.Header = "";
  }

  public bool ShowPageSetupDialog { get; set; }

  public bool ShowPrintDialog { get; set; }

  public bool ShowPrintPreviewDialog { get; set; }

  public string Title { get; set; }

  public string Footer { get; set; }

  public string Header { get; set; }

  public bool IncludeLineNumbers { get; set; }
}
