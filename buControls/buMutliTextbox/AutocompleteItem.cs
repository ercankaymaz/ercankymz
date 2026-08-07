// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.AutocompleteItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace buMutliTextbox;

public class AutocompleteItem
{
  public string Text;
  public int ImageIndex = -1;
  public object Tag;
  private string toolTipTitle;
  private string toolTipText;
  private string menuText;

  public AutocompleteMenu Parent { get; internal set; }

  public AutocompleteItem()
  {
  }

  public AutocompleteItem(string text) => this.Text = text;

  public AutocompleteItem(string text, int imageIndex)
    : this(text)
  {
    this.ImageIndex = imageIndex;
  }

  public AutocompleteItem(string text, int imageIndex, string menuText)
    : this(text, imageIndex)
  {
    this.menuText = menuText;
  }

  public AutocompleteItem(
    string text,
    int imageIndex,
    string menuText,
    string toolTipTitle,
    string toolTipText)
    : this(text, imageIndex, menuText)
  {
    this.toolTipTitle = toolTipTitle;
    this.toolTipText = toolTipText;
  }

  public virtual string GetTextForReplace() => this.Text;

  public virtual CompareResult Compare(string fragmentText)
  {
    return (!this.Text.StartsWith(fragmentText, StringComparison.InvariantCultureIgnoreCase) ? 0 : (this.Text != fragmentText ? 1 : 0)) == 0 ? CompareResult.Hidden : CompareResult.VisibleAndSelected;
  }

  public override string ToString() => this.menuText ?? this.Text;

  public virtual void OnSelected(AutocompleteMenu popupMenu, SelectedEventArgs e)
  {
  }

  public virtual string ToolTipTitle
  {
    get => this.toolTipTitle;
    set => this.toolTipTitle = value;
  }

  public virtual string ToolTipText
  {
    get => this.toolTipText;
    set => this.toolTipText = value;
  }

  public virtual string MenuText
  {
    get => this.menuText;
    set => this.menuText = value;
  }

  public virtual Color ForeColor
  {
    get => Color.Transparent;
    set => throw new NotImplementedException("Override this property to change color");
  }

  public virtual Color BackColor
  {
    get => Color.Transparent;
    set => throw new NotImplementedException("Override this property to change color");
  }
}
