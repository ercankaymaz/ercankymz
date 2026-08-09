using System;
using System.Windows.Input;
using System.Windows.Media;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class Task
{
	private InputBindingCollection _inputBindings;

	private CommandBindingCollection _commandBindings;

	private ToolCommandBindingCollection _toolCommandBindings;

	private Cursor _cursor;

	private string _description;

	private ModelEditingScope _editingScope;

	private Tool _activeTool;

	private HitTestFilterCallback _adornerFilter;

	private ModelHitTestFilterCallback _modelFilter;

	public HitTestFilterCallback AdornerFilter
	{
		get
		{
			return _adornerFilter;
		}
		set
		{
			_adornerFilter = value;
		}
	}

	public CommandBindingCollection CommandBindings
	{
		get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			if (_commandBindings == null)
			{
				_commandBindings = new CommandBindingCollection();
			}
			return _commandBindings;
		}
	}

	public Cursor Cursor
	{
		get
		{
			return _cursor;
		}
		set
		{
			_cursor = value;
		}
	}

	public string Description
	{
		get
		{
			if (_description == null)
			{
				return string.Empty;
			}
			return _description;
		}
		set
		{
			_description = value;
		}
	}

	public InputBindingCollection InputBindings
	{
		get
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			if (_inputBindings == null)
			{
				_inputBindings = new InputBindingCollection();
			}
			return _inputBindings;
		}
	}

	public bool IsFocused => _activeTool != null;

	public ModelHitTestFilterCallback ModelFilter
	{
		get
		{
			return _modelFilter;
		}
		set
		{
			_modelFilter = value;
		}
	}

	public ToolCommandBindingCollection ToolCommandBindings
	{
		get
		{
			if (_toolCommandBindings == null)
			{
				_toolCommandBindings = new ToolCommandBindingCollection();
			}
			return _toolCommandBindings;
		}
	}

	public event EventHandler FocusDeactivated;

	public event EventHandler Reverted;

	public event EventHandler Completed;

	public void BeginFocus(GestureData data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (_activeTool != null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_TaskAlreadyFocused);
		}
		EditingContext context = data.Context;
		Tool value = context.Items.GetValue<Tool>();
		value.SetFocusedTask(this);
		_activeTool = value;
		_editingScope = data.TargetModel.BeginEdit();
	}

	public void Complete()
	{
		if (_activeTool == null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ObjectNotActive);
		}
		ModelEditingScope modelEditingScope = _editingScope;
		try
		{
			OnCompleted(EventArgs.Empty);
			if (modelEditingScope != null)
			{
				if (Description.Length > 0)
				{
					modelEditingScope.Description = Description;
				}
				modelEditingScope.Complete();
				modelEditingScope = null;
			}
		}
		finally
		{
			_activeTool.ClearFocusedTask();
			_activeTool = null;
			_editingScope = null;
			modelEditingScope?.Revert();
			OnFocusDeactivated(EventArgs.Empty);
		}
	}

	public void Revert()
	{
		if (_activeTool == null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ObjectNotActive);
		}
		try
		{
			OnReverted(EventArgs.Empty);
			if (_editingScope != null)
			{
				_editingScope.Revert();
			}
		}
		finally
		{
			_activeTool.ClearFocusedTask();
			_activeTool = null;
			_editingScope = null;
			OnFocusDeactivated(EventArgs.Empty);
		}
	}

	protected virtual void OnCompleted(EventArgs e)
	{
		if (this.Completed != null)
		{
			this.Completed(this, e);
		}
	}

	protected virtual void OnFocusDeactivated(EventArgs e)
	{
		if (this.FocusDeactivated != null)
		{
			this.FocusDeactivated(this, e);
		}
	}

	protected virtual void OnReverted(EventArgs e)
	{
		if (this.Reverted != null)
		{
			this.Reverted(this, e);
		}
	}
}
