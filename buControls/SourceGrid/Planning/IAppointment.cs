// Decompiled with JetBrains decompiler
// Type: SourceGrid.Planning.IAppointment
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;
using System;

#nullable disable
namespace SourceGrid.Planning;

public interface IAppointment
{
  string Title { get; }

  IView View { get; }

  DateTime DateTimeStart { get; }

  DateTime DateTimeEnd { get; }

  bool ContainsDateTime(DateTime p_DateTime);

  IController Controller { get; set; }
}
