using System;
using System.ComponentModel;
using DevAge.Drawing;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Views;

namespace SourceGrid.Planning;

public class AppointmentBase : IAppointment
{
	private DateTime dateTimeStart;

	private DateTime dateTimeEnd;

	private string title;

	private IView iview_0;

	private IController icontroller_0;

	public DateTime DateTimeStart
	{
		get
		{
			return dateTimeStart;
		}
		set
		{
			dateTimeStart = value;
		}
	}

	public DateTime DateTimeEnd
	{
		get
		{
			return dateTimeEnd;
		}
		set
		{
			dateTimeEnd = value;
		}
	}

	public virtual string Title
	{
		get
		{
			return title;
		}
		set
		{
			title = value;
		}
	}

	[Browsable(false)]
	public virtual IView View
	{
		get
		{
			return iview_0;
		}
		set
		{
			iview_0 = value;
		}
	}

	[Browsable(false)]
	public IController Controller
	{
		get
		{
			return icontroller_0;
		}
		set
		{
			icontroller_0 = value;
		}
	}

	public AppointmentBase(string title, DateTime dateTimeStart, DateTime dateTimeEnd)
	{
		this.title = title;
		this.dateTimeEnd = dateTimeEnd;
		this.dateTimeStart = dateTimeStart;
		iview_0 = new Cell();
		iview_0.Border = RectangleBorder.RectangleBlack1Width;
	}

	public AppointmentBase()
		: this("", DateTime.Now, DateTime.Now)
	{
	}

	public bool ContainsDateTime(DateTime p_DateTime)
	{
		return dateTimeStart <= p_DateTime && dateTimeEnd > p_DateTime;
	}
}
