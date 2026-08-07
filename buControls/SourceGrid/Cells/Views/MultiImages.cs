// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.MultiImages
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns7;
using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid.Cells.Views;

[Serializable]
public class MultiImages : Cell
{
  private VisualElementList mImages = new VisualElementList();

  public MultiImages() => this.ElementsDrawMode = ElementsDrawMode.Covering;

  public MultiImages(MultiImages other)
    : base((Cell) other)
  {
    this.mImages = (VisualElementList) other.mImages.Clone();
  }

  public VisualElementList SubImages => this.mImages;

  protected override IEnumerable<IVisualElement> GetElements()
  {
    IEnumerator<IVisualElement> enumerator1 = this.method_0().GetEnumerator();
    while (enumerator1.MoveNext())
    {
      IVisualElement element = enumerator1.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_199(this);
    enumerator1 = (IEnumerator<IVisualElement>) null;
    List<IVisualElement>.Enumerator enumerator2 = this.SubImages.GetEnumerator();
    while (enumerator2.MoveNext())
    {
      IVisualElement element = enumerator2.Current;
      yield return element;
      element = (IVisualElement) null;
    }
    Class39.smethod_417(this);
    enumerator2 = new List<IVisualElement>.Enumerator();
  }

  private IEnumerable<IVisualElement> method_0() => base.GetElements();

  public override object Clone() => (object) new MultiImages(this);
}
