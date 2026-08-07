// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.EmptyTypeDescriptorContext
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel;

public class EmptyTypeDescriptorContext : IServiceProvider, ITypeDescriptorContext
{
  public static readonly EmptyTypeDescriptorContext Empty;
  private EmptyContainer emptyContainer_0 = new EmptyContainer();

  public IContainer Container => (IContainer) this.emptyContainer_0;

  public object Instance => (object) null;

  public void OnComponentChanged()
  {
  }

  public bool OnComponentChanging() => true;

  public PropertyDescriptor PropertyDescriptor => (PropertyDescriptor) null;

  public object GetService(Type serviceType) => (object) null;
}
