// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.ICellVirtual
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;
using System;

#nullable disable
namespace SourceGrid.Cells;

public interface ICellVirtual
{
  EditorBase Editor { get; set; }

  ControllerContainer Controller { get; }

  void AddController(IController controller);

  void RemoveController(IController controller);

  IController FindController(Type pControllerType);

  T FindController<T>() where T : class, IController;

  IView View { get; set; }

  ModelContainer Model { get; set; }

  ICellVirtual Copy();
}
