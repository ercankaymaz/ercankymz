using System;
using SourceGrid.Cells.Controllers;
using SourceGrid.Cells.Editors;
using SourceGrid.Cells.Models;
using SourceGrid.Cells.Views;

namespace SourceGrid.Cells.Virtual;

public class CellVirtual : ICellVirtual
{
	private ModelContainer modelContainer_0;

	private IView iview_0;

	private ControllerContainer controllerContainer_0;

	private EditorBase editorBase_0 = null;

	public ModelContainer Model
	{
		get
		{
			return modelContainer_0;
		}
		set
		{
			if (value == null)
			{
				throw new SourceGridException("Model cannot be null");
			}
			modelContainer_0 = value;
		}
	}

	public virtual IView View
	{
		get
		{
			return iview_0;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("View");
			}
			iview_0 = value;
		}
	}

	public ControllerContainer Controller => controllerContainer_0;

	public EditorBase Editor
	{
		get
		{
			return editorBase_0;
		}
		set
		{
			editorBase_0 = value;
		}
	}

	public CellVirtual()
	{
		View = SourceGrid.Cells.Views.Cell.Default;
		Editor = null;
		Model = new ModelContainer();
		Model.AddModel(NullValueModel.Default);
	}

	public CellVirtual(Type type)
		: this()
	{
		Editor = Factory.Create(type);
	}

	public void AddController(IController controller)
	{
		if (controllerContainer_0 == null)
		{
			controllerContainer_0 = new ControllerContainer();
		}
		controllerContainer_0.AddController(controller);
	}

	public void RemoveController(IController controller)
	{
		if (controllerContainer_0 != null)
		{
			controllerContainer_0.RemoveController(controller);
		}
	}

	public IController FindController(Type pControllerType)
	{
		if (controllerContainer_0 == null)
		{
			return null;
		}
		return controllerContainer_0.FindController(pControllerType);
	}

	public T FindController<T>() where T : class, IController
	{
		return FindController(typeof(T)) as T;
	}

	public ICellVirtual Copy()
	{
		return (ICellVirtual)MemberwiseClone();
	}
}
