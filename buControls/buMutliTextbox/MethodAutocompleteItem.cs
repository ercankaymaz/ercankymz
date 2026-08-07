// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.MethodAutocompleteItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class MethodAutocompleteItem : AutocompleteItem
{
  private string string_0;
  private string string_1;

  public MethodAutocompleteItem(string text)
    : base(text)
  {
    this.string_1 = this.Text.ToLower();
  }

  public override CompareResult Compare(string fragmentText)
  {
    int length = fragmentText.LastIndexOf('.');
    CompareResult compareResult;
    if (length < 0)
    {
      compareResult = CompareResult.Hidden;
    }
    else
    {
      string str = fragmentText.Substring(length + 1);
      this.string_0 = fragmentText.Substring(0, length);
      compareResult = !(str == "") ? (!this.Text.StartsWith(str, StringComparison.InvariantCultureIgnoreCase) ? (!this.string_1.Contains(str.ToLower()) ? CompareResult.Hidden : CompareResult.Visible) : CompareResult.VisibleAndSelected) : CompareResult.Visible;
    }
    return compareResult;
  }

  public override string GetTextForReplace() => $"{this.string_0}.{this.Text}";
}
