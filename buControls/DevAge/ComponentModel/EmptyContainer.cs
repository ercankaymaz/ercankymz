// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.EmptyContainer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel;

public class EmptyContainer : IDisposable, IContainer
{
  public void Add(IComponent component, string name) => throw new NotImplementedException();

  public void Add(IComponent component) => throw new NotImplementedException();

  public ComponentCollection Components => new ComponentCollection((IComponent[]) null);

  public void Remove(IComponent component) => throw new NotImplementedException();

  public void Dispose()
  {
  }
}
