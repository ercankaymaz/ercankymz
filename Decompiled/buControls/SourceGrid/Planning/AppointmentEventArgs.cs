using System;

namespace SourceGrid.Planning;

public class AppointmentEventArgs : EventArgs
{
	private DateTime start;

	private DateTime end;

	private IAppointment appointment;

	public DateTime DateTimeStart => start;

	public DateTime DateTimeEnd => end;

	public IAppointment Appointment => appointment;

	public AppointmentEventArgs(DateTime start, DateTime end, IAppointment appointment)
	{
		this.end = end;
		this.start = start;
		this.appointment = appointment;
	}
}
