// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.Container
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class Container : ContainerBase
{
  private VisualElementList mElements = new VisualElementList();

  public Container()
  {
  }

  public Container(Container other)
    : base((ContainerBase) other)
  {
    if (other.Elements != null)
      this.Elements = (VisualElementList) other.Elements.Clone();
    else
      this.Elements = (VisualElementList) null;
  }

  public new IBorder Border
  {
    get => base.Border;
    set => base.Border = value;
  }

  public new Padding Padding
  {
    get => base.Padding;
    set => base.Padding = value;
  }

  public new IVisualElement Background
  {
    get => base.Background;
    set => base.Background = value;
  }

  public new ElementsDrawMode ElementsDrawMode
  {
    get => base.ElementsDrawMode;
    set => base.ElementsDrawMode = value;
  }

  public virtual VisualElementList Elements
  {
    get => this.mElements;
    set => this.mElements = value;
  }

  protected override IEnumerable<IVisualElement> GetElements()
  {
    return (IEnumerable<IVisualElement>) this.Elements;
  }

  public override object Clone() => (object) new Container(this);
}
