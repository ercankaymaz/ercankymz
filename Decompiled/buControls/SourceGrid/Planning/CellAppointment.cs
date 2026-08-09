using SourceGrid.Cells;

namespace SourceGrid.Planning;

public class CellAppointment : Cell
{
	private IAppointment appointment;

	public IAppointment Appointment => appointment;

	public CellAppointment(IAppointment appointment)
		: base(appointment.Title)
	{
		this.appointment = appointment;
	}
}
