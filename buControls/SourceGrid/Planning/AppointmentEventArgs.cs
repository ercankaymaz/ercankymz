// Decompiled with JetBrains decompiler
// Type: SourceGrid.Planning.AppointmentEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid.Planning;

public class AppointmentEventArgs : EventArgs
{
  private DateTime start;
  private DateTime end;
  private IAppointment appointment;

  public AppointmentEventArgs(DateTime start, DateTime end, IAppointment appointment)
  {
    this.end = end;
    this.start = start;
    this.appointment = appointment;
  }

  public DateTime DateTimeStart => this.start;

  public DateTime DateTimeEnd => this.end;

  public IAppointment Appointment => this.appointment;
}
