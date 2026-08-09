using System;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells;

public interface ICellVirtual
{
	EditorBase Editor { get; set; }

	ControllerContainer Controller { get; }

	IView View { get; set; }

	ModelContainer Model { get; set; }

	void AddController(IController controller);

	void RemoveController(IController controller);

	IController FindController(Type pControllerType);

	T FindController<T>() where T : class, IController;

	ICellVirtual Copy();
}
