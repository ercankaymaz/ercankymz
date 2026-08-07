// Decompiled with JetBrains decompiler
// Type: SourceGrid.Planning.CellAppointment
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;

#nullable disable
namespace SourceGrid.Planning;

public class CellAppointment : Cell
{
  private IAppointment appointment;

  public CellAppointment(IAppointment appointment)
    : base((object) appointment.Title)
  {
    this.appointment = appointment;
  }

  public IAppointment Appointment => this.appointment;
}
