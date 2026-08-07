// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.Hints
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace buMutliTextbox;

public class Hints : IDisposable, IEnumerable, ICollection<Hint>, IEnumerable<Hint>
{
  internal buMultiTextBox tb;
  private List<Hint> list_0 = new List<Hint>();

  public Hints(buMultiTextBox tb)
  {
    this.tb = tb;
    tb.TextChanged += new EventHandler<TextChangedEventArgs>(this.OnTextBoxTextChanged);
    tb.KeyDown += new KeyEventHandler(this.OnTextBoxKeyDown);
    tb.VisibleRangeChanged += new EventHandler(this.method_0);
  }

  protected virtual void OnTextBoxKeyDown(object sender, KeyEventArgs e)
  {
    if ((e.KeyCode != Keys.Escape ? 0 : (e.Modifiers == Keys.None ? 1 : 0)) == 0)
      return;
    this.Clear();
  }

  protected virtual void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
  {
    this.Clear();
  }

  public void Dispose()
  {
    this.tb.TextChanged -= new EventHandler<TextChangedEventArgs>(this.OnTextBoxTextChanged);
    this.tb.KeyDown -= new KeyEventHandler(this.OnTextBoxKeyDown);
    this.tb.VisibleRangeChanged -= new EventHandler(this.method_0);
  }

  private void method_0(object sender, EventArgs e)
  {
    if (this.list_0.Count == 0)
      return;
    this.tb.NeedRecalc(true);
    foreach (Hint hint_0 in this.list_0)
    {
      Class39.smethod_508(this, hint_0);
      hint_0.HostPanel.Invalidate();
    }
  }

  public IEnumerator<Hint> GetEnumerator()
  {
    List<Hint>.Enumerator enumerator = this.list_0.GetEnumerator();
    while (enumerator.MoveNext())
    {
      Hint hint = enumerator.Current;
      yield return hint;
      hint = (Hint) null;
    }
    Class39.smethod_629(this);
    enumerator = new List<Hint>.Enumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public void Clear()
  {
    this.list_0.Clear();
    if (this.tb.Controls.Count == 0)
      return;
    List<Control> controlList = new List<Control>();
    foreach (Control control in (ArrangedElementCollection) this.tb.Controls)
    {
      if (control is UnfocusablePanel)
        controlList.Add(control);
    }
    foreach (Control control in controlList)
      this.tb.Controls.Remove(control);
    for (int index = 0; index < this.tb.LineInfos.Count; ++index)
    {
      LineInfo lineInfo = this.tb.LineInfos[index] with
      {
        int_0 = 0
      };
      this.tb.LineInfos[index] = lineInfo;
    }
    this.tb.NeedRecalc();
    this.tb.Invalidate();
    this.tb.Select();
    this.tb.ActiveControl = (Control) null;
  }

  public void Add(Hint hint)
  {
    this.list_0.Add(hint);
    if (hint.Inline)
    {
      LineInfo lineInfo = this.tb.LineInfos[hint.Range.Start.iLine];
      hint.method_1(lineInfo.int_0);
      lineInfo.int_0 += hint.HostPanel.Height;
      this.tb.LineInfos[hint.Range.Start.iLine] = lineInfo;
      this.tb.NeedRecalc(true);
    }
    Class39.smethod_508(this, hint);
    this.tb.OnVisibleRangeChanged();
    hint.HostPanel.Parent = (Control) this.tb;
    this.tb.Select();
    this.tb.ActiveControl = (Control) null;
    this.tb.Invalidate();
  }

  public bool Contains(Hint item) => this.list_0.Contains(item);

  public void CopyTo(Hint[] array, int arrayIndex) => this.list_0.CopyTo(array, arrayIndex);

  public int Count => this.list_0.Count;

  public bool IsReadOnly => false;

  public bool Remove(Hint item) => throw new NotImplementedException();
}
