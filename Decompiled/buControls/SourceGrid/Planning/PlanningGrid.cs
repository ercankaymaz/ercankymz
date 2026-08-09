using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using ns27;

namespace SourceGrid.Planning;

public class PlanningGrid : UserControl
{
	public delegate void AppointmentEventHandler(object sender, AppointmentEventArgs e);

	private sealed class Control0 : ControllerBase
	{
		private PlanningGrid planningGrid_0;

		public Control0(PlanningGrid planningGrid_1)
		{
			planningGrid_0 = planningGrid_1;
		}

		public override void OnClick(CellContext sender, EventArgs e)
		{
			base.OnClick(sender, e);
			if (!(sender.Cell is CellAppointment))
			{
				if (sender.Cell is CellEmpty)
				{
					CellEmpty cellEmpty = (CellEmpty)sender.Cell;
					planningGrid_0.OnAppointmentClick(new AppointmentEventArgs(cellEmpty.Start, cellEmpty.End, null));
				}
			}
			else
			{
				CellAppointment cellAppointment = (CellAppointment)sender.Cell;
				planningGrid_0.OnAppointmentClick(new AppointmentEventArgs(cellAppointment.Appointment.DateTimeStart, cellAppointment.Appointment.DateTimeEnd, cellAppointment.Appointment));
			}
		}

		public override void OnDoubleClick(CellContext sender, EventArgs e)
		{
			base.OnDoubleClick(sender, e);
			if (!(sender.Cell is CellAppointment))
			{
				if (sender.Cell is CellEmpty)
				{
					CellEmpty cellEmpty = (CellEmpty)sender.Cell;
					planningGrid_0.OnAppointmentDoubleClick(new AppointmentEventArgs(cellEmpty.Start, cellEmpty.End, null));
				}
			}
			else
			{
				CellAppointment cellAppointment = (CellAppointment)sender.Cell;
				planningGrid_0.OnAppointmentDoubleClick(new AppointmentEventArgs(cellAppointment.Appointment.DateTimeStart, cellAppointment.Appointment.DateTimeEnd, cellAppointment.Appointment));
			}
		}
	}

	internal Grid grid_0;

	private Container container_0 = null;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private int int_0;

	private AppointmentCollection appointmentCollection_0 = new AppointmentCollection();

	[CompilerGenerated]
	private AppointmentEventHandler appointmentEventHandler_0;

	[CompilerGenerated]
	private AppointmentEventHandler appointmentEventHandler_1;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public AppointmentCollection Appointments => appointmentCollection_0;

	public DateTime DateTimeStart => dateTime_0;

	public DateTime DateTimeEnd => dateTime_1;

	public int MinAppointmentLength => int_0;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Grid Grid => grid_0;

	public event AppointmentEventHandler AppointmentClick
	{
		[CompilerGenerated]
		add
		{
			AppointmentEventHandler appointmentEventHandler = appointmentEventHandler_0;
			AppointmentEventHandler appointmentEventHandler2;
			do
			{
				appointmentEventHandler2 = appointmentEventHandler;
				AppointmentEventHandler value2 = (AppointmentEventHandler)Delegate.Combine(appointmentEventHandler2, value);
				appointmentEventHandler = Interlocked.CompareExchange(ref appointmentEventHandler_0, value2, appointmentEventHandler2);
			}
			while ((object)appointmentEventHandler != appointmentEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			AppointmentEventHandler appointmentEventHandler = appointmentEventHandler_0;
			AppointmentEventHandler appointmentEventHandler2;
			do
			{
				appointmentEventHandler2 = appointmentEventHandler;
				AppointmentEventHandler value2 = (AppointmentEventHandler)Delegate.Remove(appointmentEventHandler2, value);
				appointmentEventHandler = Interlocked.CompareExchange(ref appointmentEventHandler_0, value2, appointmentEventHandler2);
			}
			while ((object)appointmentEventHandler != appointmentEventHandler2);
		}
	}

	public event AppointmentEventHandler AppointmentDoubleClick
	{
		[CompilerGenerated]
		add
		{
			AppointmentEventHandler appointmentEventHandler = appointmentEventHandler_1;
			AppointmentEventHandler appointmentEventHandler2;
			do
			{
				appointmentEventHandler2 = appointmentEventHandler;
				AppointmentEventHandler value2 = (AppointmentEventHandler)Delegate.Combine(appointmentEventHandler2, value);
				appointmentEventHandler = Interlocked.CompareExchange(ref appointmentEventHandler_1, value2, appointmentEventHandler2);
			}
			while ((object)appointmentEventHandler != appointmentEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			AppointmentEventHandler appointmentEventHandler = appointmentEventHandler_1;
			AppointmentEventHandler appointmentEventHandler2;
			do
			{
				appointmentEventHandler2 = appointmentEventHandler;
				AppointmentEventHandler value2 = (AppointmentEventHandler)Delegate.Remove(appointmentEventHandler2, value);
				appointmentEventHandler = Interlocked.CompareExchange(ref appointmentEventHandler_1, value2, appointmentEventHandler2);
			}
			while ((object)appointmentEventHandler != appointmentEventHandler2);
		}
	}

	public PlanningGrid()
	{
		Class76.smethod_466(this);
		grid_0.Selection.FocusStyle = FocusStyle.None;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && container_0 != null)
		{
			container_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		grid_0.Controller.AddController(new Control0(this));
	}

	public void LoadPlanning(DateTime dateTimeStart, DateTime dateTimeEnd, int minAppointmentLength)
	{
		dateTime_0 = dateTimeStart;
		dateTime_1 = dateTimeEnd;
		int_0 = minAppointmentLength;
		if (!(dateTimeStart >= dateTimeEnd))
		{
			if (!(dateTimeStart.TimeOfDay >= dateTimeEnd.TimeOfDay))
			{
				if (dateTimeStart.TimeOfDay.Minutes == 0 && dateTimeEnd.TimeOfDay.Minutes == 0)
				{
					if (minAppointmentLength > 0 && minAppointmentLength <= 60)
					{
						if (60 % minAppointmentLength == 0)
						{
							TimeSpan timeSpan = dateTimeEnd - dateTimeStart;
							TimeSpan timeSpan2 = dateTimeEnd.TimeOfDay - dateTimeStart.TimeOfDay;
							int num = 60 / minAppointmentLength;
							if (!(timeSpan.TotalDays > 30.0))
							{
								if (!(timeSpan2.TotalMinutes < (double)minAppointmentLength))
								{
									grid_0.Redim((int)((timeSpan2.TotalHours + 1.0) * (double)num + 2.0), (int)(timeSpan.TotalDays + 1.0 + 2.0));
									grid_0[0, 0] = new Header00(null);
									grid_0[0, 0].RowSpan = 2;
									grid_0[0, 0].ColumnSpan = 2;
									DateTime dateTime = dateTimeStart;
									for (int i = 2; i < grid_0.ColumnsCount; i++)
									{
										grid_0[0, i] = new HeaderDay1(dateTime.ToShortDateString());
										grid_0[1, i] = new HeaderDay2(dateTime.ToString("dddd"));
										dateTime = dateTime.AddDays(1.0);
									}
									int num2 = dateTimeStart.Hour;
									for (int j = 2; j < grid_0.RowsCount; j += num)
									{
										grid_0[j, 0] = new HeaderHour1(num2);
										grid_0[j, 0].RowSpan = num;
										int num3 = 0;
										for (int k = j; k < j + num; k++)
										{
											grid_0[k, 1] = new HeaderHour2(num3);
											num3 += minAppointmentLength;
										}
										num2++;
									}
									grid_0.FixedColumns = 2;
									grid_0.FixedRows = 2;
									grid_0.Columns[0].Width = 40;
									grid_0.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.None;
									grid_0.Columns[1].Width = 40;
									grid_0.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.None;
									grid_0.AutoStretchColumnsToFitWidth = true;
									grid_0.AutoStretchRowsToFitHeight = true;
									grid_0.AutoSizeCells();
									for (int l = 2; l < grid_0.ColumnsCount; l++)
									{
										DateTime dateTime2 = dateTimeStart.AddDays(l - 2);
										int num4 = -1;
										Cell cell = null;
										for (int m = 2; m < grid_0.RowsCount; m += num)
										{
											for (int n = m; n < m + num; n++)
											{
												bool flag = false;
												for (int num5 = 0; num5 < appointmentCollection_0.Count; num5++)
												{
													if (!appointmentCollection_0[num5].ContainsDateTime(dateTime2))
													{
														continue;
													}
													flag = true;
													if (num4 == num5)
													{
														grid_0[n, l] = null;
														cell.RowSpan++;
														break;
													}
													cell = new CellAppointment(appointmentCollection_0[num5]);
													cell.View = appointmentCollection_0[num5].View;
													if (appointmentCollection_0[num5].Controller != null)
													{
														cell.AddController(appointmentCollection_0[num5].Controller);
													}
													grid_0[n, l] = cell;
													num4 = num5;
													break;
												}
												if (!flag)
												{
													grid_0[n, l] = new CellEmpty(dateTime2, dateTime2.AddMinutes(minAppointmentLength));
													num4 = -1;
													cell = null;
												}
												dateTime2 = dateTime2.AddMinutes(minAppointmentLength);
											}
										}
									}
									return;
								}
								throw new ApplicationException("Invalid Minimum Appointment Length for current Planning Range");
							}
							throw new ApplicationException("Range too big");
						}
						throw new ApplicationException("Invalid Minimum Appointment Length must be multiple of 60");
					}
					throw new ApplicationException("Invalid Minimum Appointment Length");
				}
				throw new ApplicationException("Invalid Start or End hours must be with 0 minutes");
			}
			throw new ApplicationException("Invalid Plannnin Range");
		}
		throw new ApplicationException("Invalid Planning Range");
	}

	public void UnLoadPlanning()
	{
		grid_0.Redim(0, 0);
	}

	protected virtual void OnAppointmentClick(AppointmentEventArgs e)
	{
		if (appointmentEventHandler_0 != null)
		{
			appointmentEventHandler_0(this, e);
		}
	}

	protected virtual void OnAppointmentDoubleClick(AppointmentEventArgs e)
	{
		if (appointmentEventHandler_1 != null)
		{
			appointmentEventHandler_1(this, e);
		}
	}
}
