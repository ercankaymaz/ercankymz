// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.SnippetAutocompleteItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class SnippetAutocompleteItem : AutocompleteItem
{
  public SnippetAutocompleteItem(string snippet)
  {
    this.Text = snippet.Replace("\r", "");
    this.ToolTipTitle = "Code snippet:";
    this.ToolTipText = this.Text;
  }

  public override string ToString()
  {
    return this.MenuText ?? this.Text.Replace("\n", " ").Replace("^", "");
  }

  public override string GetTextForReplace() => this.Text;

  public override void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
  {
    e.Tb.BeginUpdate();
    e.Tb.Selection.BeginUpdate();
    Place start1 = popupMenu.Fragment.Start;
    Place start2 = e.Tb.Selection.Start;
    if (e.Tb.AutoIndent)
    {
      for (int iLine = start1.iLine + 1; iLine <= start2.iLine; ++iLine)
      {
        e.Tb.Selection.Start = new Place(0, iLine);
        e.Tb.DoAutoIndent(iLine);
      }
    }
    e.Tb.Selection.Start = start1;
    do
      ;
    while (e.Tb.Selection.CharBeforeStart != '^' && e.Tb.Selection.GoRightThroughFolded());
    e.Tb.Selection.GoLeft(true);
    e.Tb.InsertText("");
    e.Tb.Selection.EndUpdate();
    e.Tb.EndUpdate();
  }

  public override CompareResult Compare(string fragmentText)
  {
    return (!this.Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) ? 0 : (this.Text != fragmentText ? 1 : 0)) == 0 ? CompareResult.Hidden : CompareResult.Visible;
  }
}
