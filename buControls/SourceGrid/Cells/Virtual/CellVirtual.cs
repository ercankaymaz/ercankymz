// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Virtual.CellVirtual
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;
using System;

#nullable disable
namespace SourceGrid.Cells.Virtual;

public class CellVirtual : ICellVirtual
{
  private ModelContainer modelContainer_0;
  private IView iview_0;
  private ControllerContainer controllerContainer_0;
  private EditorBase editorBase_0 = (EditorBase) null;

  public CellVirtual()
  {
    this.View = (IView) SourceGrid.Cells.Views.Cell.Default;
    this.Editor = (EditorBase) null;
    this.Model = new ModelContainer();
    this.Model.AddModel((IModel) NullValueModel.Default);
  }

  public CellVirtual(Type type)
    : this()
  {
    this.Editor = Factory.Create(type);
  }

  public ModelContainer Model
  {
    get => this.modelContainer_0;
    set
    {
      this.modelContainer_0 = value != null ? value : throw new SourceGridException("Model cannot be null");
    }
  }

  public virtual IView View
  {
    get => this.iview_0;
    set => this.iview_0 = value != null ? value : throw new ArgumentNullException(nameof (View));
  }

  public ControllerContainer Controller => this.controllerContainer_0;

  public void AddController(IController controller)
  {
    if (this.controllerContainer_0 == null)
      this.controllerContainer_0 = new ControllerContainer();
    this.controllerContainer_0.AddController(controller);
  }

  public void RemoveController(IController controller)
  {
    if (this.controllerContainer_0 == null)
      return;
    this.controllerContainer_0.RemoveController(controller);
  }

  public IController FindController(Type pControllerType)
  {
    return this.controllerContainer_0 == null ? (IController) null : this.controllerContainer_0.FindController(pControllerType);
  }

  public T FindController<T>() where T : class, IController => this.FindController(typeof (T)) as T;

  public EditorBase Editor
  {
    get => this.editorBase_0;
    set => this.editorBase_0 = value;
  }

  public ICellVirtual Copy() => (ICellVirtual) this.MemberwiseClone();
}
