using System;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Planning;

public interface IAppointment
{
	string Title { get; }

	IView View { get; }

	DateTime DateTimeStart { get; }

	DateTime DateTimeEnd { get; }

	IController Controller { get; set; }

	bool ContainsDateTime(DateTime p_DateTime);
}
