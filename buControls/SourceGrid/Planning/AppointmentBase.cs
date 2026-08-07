// Decompiled with JetBrains decompiler
// Type: SourceGrid.Planning.AppointmentBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;
using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Planning;

public class AppointmentBase : IAppointment
{
  private DateTime dateTimeStart;
  private DateTime dateTimeEnd;
  private string title;
  private IView iview_0;
  private IController icontroller_0;

  public AppointmentBase(string title, DateTime dateTimeStart, DateTime dateTimeEnd)
  {
    this.title = title;
    this.dateTimeEnd = dateTimeEnd;
    this.dateTimeStart = dateTimeStart;
    this.iview_0 = (IView) new Cell();
    this.iview_0.Border = (IBorder) RectangleBorder.RectangleBlack1Width;
  }

  public AppointmentBase()
    : this("", DateTime.Now, DateTime.Now)
  {
  }

  public DateTime DateTimeStart
  {
    get => this.dateTimeStart;
    set => this.dateTimeStart = value;
  }

  public DateTime DateTimeEnd
  {
    get => this.dateTimeEnd;
    set => this.dateTimeEnd = value;
  }

  public virtual string Title
  {
    get => this.title;
    set => this.title = value;
  }

  [Browsable(false)]
  public virtual IView View
  {
    get => this.iview_0;
    set => this.iview_0 = value;
  }

  public bool ContainsDateTime(DateTime p_DateTime)
  {
    return this.dateTimeStart <= p_DateTime && this.dateTimeEnd > p_DateTime;
  }

  [Browsable(false)]
  public IController Controller
  {
    get => this.icontroller_0;
    set => this.icontroller_0 = value;
  }
}
