// Decompiled with JetBrains decompiler
// Type: SourceGrid.Planning.PlanningGrid
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Cells;
using SourceGrid.Cells.Controllers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Planning;

public class PlanningGrid : UserControl
{
  internal Grid grid_0;
  private System.ComponentModel.Container container_0 = (System.ComponentModel.Container) null;
  private DateTime dateTime_0;
  private DateTime dateTime_1;
  private int int_0;
  private AppointmentCollection appointmentCollection_0 = new AppointmentCollection();

  public PlanningGrid()
  {
    Class39.smethod_466(this);
    this.grid_0.Selection.FocusStyle = FocusStyle.None;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.container_0 != null)
      this.container_0.Dispose();
    base.Dispose(disposing);
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    this.grid_0.Controller.AddController((IController) new PlanningGrid.Control0(this));
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public AppointmentCollection Appointments => this.appointmentCollection_0;

  public DateTime DateTimeStart => this.dateTime_0;

  public DateTime DateTimeEnd => this.dateTime_1;

  public int MinAppointmentLength => this.int_0;

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Grid Grid => this.grid_0;

  public void LoadPlanning(DateTime dateTimeStart, DateTime dateTimeEnd, int minAppointmentLength)
  {
    this.dateTime_0 = dateTimeStart;
    this.dateTime_1 = dateTimeEnd;
    this.int_0 = minAppointmentLength;
    if (dateTimeStart >= dateTimeEnd)
      throw new ApplicationException("Invalid Planning Range");
    if (dateTimeStart.TimeOfDay >= dateTimeEnd.TimeOfDay)
      throw new ApplicationException("Invalid Plannnin Range");
    if ((dateTimeStart.TimeOfDay.Minutes != 0 ? 1 : (dateTimeEnd.TimeOfDay.Minutes != 0 ? 1 : 0)) != 0)
      throw new ApplicationException("Invalid Start or End hours must be with 0 minutes");
    if ((minAppointmentLength <= 0 ? 1 : (minAppointmentLength > 60 ? 1 : 0)) != 0)
      throw new ApplicationException("Invalid Minimum Appointment Length");
    if (60 % minAppointmentLength != 0)
      throw new ApplicationException("Invalid Minimum Appointment Length must be multiple of 60");
    TimeSpan timeSpan1 = dateTimeEnd - dateTimeStart;
    TimeSpan timeSpan2 = dateTimeEnd.TimeOfDay - dateTimeStart.TimeOfDay;
    int num1 = 60 / minAppointmentLength;
    if (timeSpan1.TotalDays > 30.0)
      throw new ApplicationException("Range too big");
    if (timeSpan2.TotalMinutes < (double) minAppointmentLength)
      throw new ApplicationException("Invalid Minimum Appointment Length for current Planning Range");
    this.grid_0.Redim((int) ((timeSpan2.TotalHours + 1.0) * (double) num1 + 2.0), (int) (timeSpan1.TotalDays + 1.0 + 2.0));
    this.grid_0[0, 0] = (ICell) new Header00((object) null);
    this.grid_0[0, 0].RowSpan = 2;
    this.grid_0[0, 0].ColumnSpan = 2;
    DateTime dateTime1 = dateTimeStart;
    for (int col = 2; col < this.grid_0.ColumnsCount; ++col)
    {
      this.grid_0[0, col] = (ICell) new HeaderDay1((object) dateTime1.ToShortDateString());
      this.grid_0[1, col] = (ICell) new HeaderDay2((object) dateTime1.ToString("dddd"));
      dateTime1 = dateTime1.AddDays(1.0);
    }
    int hour = dateTimeStart.Hour;
    for (int row1 = 2; row1 < this.grid_0.RowsCount; row1 += num1)
    {
      this.grid_0[row1, 0] = (ICell) new HeaderHour1((object) hour);
      this.grid_0[row1, 0].RowSpan = num1;
      int val = 0;
      for (int row2 = row1; row2 < row1 + num1; ++row2)
      {
        this.grid_0[row2, 1] = (ICell) new HeaderHour2((object) val);
        val += minAppointmentLength;
      }
      ++hour;
    }
    this.grid_0.FixedColumns = 2;
    this.grid_0.FixedRows = 2;
    this.grid_0.Columns[0].Width = 40;
    this.grid_0.Columns[0].AutoSizeMode = SourceGrid.AutoSizeMode.None;
    this.grid_0.Columns[1].Width = 40;
    this.grid_0.Columns[1].AutoSizeMode = SourceGrid.AutoSizeMode.None;
    this.grid_0.AutoStretchColumnsToFitWidth = true;
    this.grid_0.AutoStretchRowsToFitHeight = true;
    this.grid_0.AutoSizeCells();
    for (int col = 2; col < this.grid_0.ColumnsCount; ++col)
    {
      DateTime dateTime2 = dateTimeStart.AddDays((double) (col - 2));
      int num2 = -1;
      Cell cell = (Cell) null;
      for (int index1 = 2; index1 < this.grid_0.RowsCount; index1 += num1)
      {
        for (int row = index1; row < index1 + num1; ++row)
        {
          bool flag = false;
          for (int index2 = 0; index2 < this.appointmentCollection_0.Count; ++index2)
          {
            if (this.appointmentCollection_0[index2].ContainsDateTime(dateTime2))
            {
              flag = true;
              if (num2 != index2)
              {
                cell = (Cell) new CellAppointment(this.appointmentCollection_0[index2]);
                cell.View = this.appointmentCollection_0[index2].View;
                if (this.appointmentCollection_0[index2].Controller != null)
                  cell.AddController(this.appointmentCollection_0[index2].Controller);
                this.grid_0[row, col] = (ICell) cell;
                num2 = index2;
                break;
              }
              this.grid_0[row, col] = (ICell) null;
              ++cell.RowSpan;
              break;
            }
          }
          if (!flag)
          {
            this.grid_0[row, col] = (ICell) new CellEmpty(dateTime2, dateTime2.AddMinutes((double) minAppointmentLength));
            num2 = -1;
            cell = (Cell) null;
          }
          dateTime2 = dateTime2.AddMinutes((double) minAppointmentLength);
        }
      }
    }
  }

  public void UnLoadPlanning() => this.grid_0.Redim(0, 0);

  public event PlanningGrid.AppointmentEventHandler AppointmentClick;

  protected virtual void OnAppointmentClick(AppointmentEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.appointmentEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.appointmentEventHandler_0((object) this, e);
  }

  public event PlanningGrid.AppointmentEventHandler AppointmentDoubleClick;

  protected virtual void OnAppointmentDoubleClick(AppointmentEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.appointmentEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.appointmentEventHandler_1((object) this, e);
  }

  public delegate void AppointmentEventHandler(object sender, AppointmentEventArgs e);

  private sealed class Control0 : ControllerBase
  {
    private PlanningGrid planningGrid_0;

    public Control0(PlanningGrid planningGrid_1) => this.planningGrid_0 = planningGrid_1;

    public override void OnClick(CellContext sender, EventArgs e)
    {
      base.OnClick(sender, e);
      if (sender.Cell is CellAppointment)
      {
        CellAppointment cell = (CellAppointment) sender.Cell;
        this.planningGrid_0.OnAppointmentClick(new AppointmentEventArgs(cell.Appointment.DateTimeStart, cell.Appointment.DateTimeEnd, cell.Appointment));
      }
      else
      {
        if (!(sender.Cell is CellEmpty))
          return;
        CellEmpty cell = (CellEmpty) sender.Cell;
        this.planningGrid_0.OnAppointmentClick(new AppointmentEventArgs(cell.Start, cell.End, (IAppointment) null));
      }
    }

    public override void OnDoubleClick(CellContext sender, EventArgs e)
    {
      base.OnDoubleClick(sender, e);
      if (sender.Cell is CellAppointment)
      {
        CellAppointment cell = (CellAppointment) sender.Cell;
        this.planningGrid_0.OnAppointmentDoubleClick(new AppointmentEventArgs(cell.Appointment.DateTimeStart, cell.Appointment.DateTimeEnd, cell.Appointment));
      }
      else
      {
        if (!(sender.Cell is CellEmpty))
          return;
        CellEmpty cell = (CellEmpty) sender.Cell;
        this.planningGrid_0.OnAppointmentDoubleClick(new AppointmentEventArgs(cell.Start, cell.End, (IAppointment) null));
      }
    }
  }
}
