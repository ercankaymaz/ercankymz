// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SuggestItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace buMutliTextbox;

public class SuggestItem(string text, int imageIndex) : AutocompleteItem(text, imageIndex)
{
  public override CompareResult Compare(string fragmentText) => CompareResult.Visible;
}
