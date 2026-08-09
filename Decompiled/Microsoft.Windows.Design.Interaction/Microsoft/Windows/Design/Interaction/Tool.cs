using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

public class Tool : ContextItem
{
	private class TaskCollection : Collection<Task>
	{
		protected override void InsertItem(int index, Task item)
		{
			base.InsertItem(index, item);
			CommandManager.InvalidateRequerySuggested();
		}

		protected override void ClearItems()
		{
			base.ClearItems();
			CommandManager.InvalidateRequerySuggested();
		}

		protected override void RemoveItem(int index)
		{
			base.RemoveItem(index);
			CommandManager.InvalidateRequerySuggested();
		}

		protected override void SetItem(int index, Task item)
		{
			base.SetItem(index, item);
			CommandManager.InvalidateRequerySuggested();
		}
	}

	private EditingContext _context;

	private Cursor _cursor;

	private Collection<Task> _tasks;

	private Task _focusedTask;

	private bool _isUpdatingTaskItem;

	public Task FocusedTask => _focusedTask;

	protected EditingContext Context
	{
		get
		{
			if (_context == null)
			{
				throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ObjectNotActive);
			}
			return _context;
		}
	}

	public Cursor Cursor
	{
		get
		{
			Cursor cursor = _cursor;
			if (_focusedTask != null && _focusedTask.Cursor != null)
			{
				cursor = _focusedTask.Cursor;
			}
			return cursor;
		}
		set
		{
			_cursor = value;
		}
	}

	internal bool IsUpdatingTaskItem => _isUpdatingTaskItem;

	public sealed override Type ItemType => typeof(Tool);

	public Collection<Task> Tasks
	{
		get
		{
			if (_tasks == null)
			{
				_tasks = new TaskCollection();
			}
			return _tasks;
		}
	}

	internal void ClearFocusedTask()
	{
		_focusedTask = null;
		UpdateTaskItem();
	}

	internal CommandBinding GetCommandBinding(ICommand command, DependencyObject sourceAdorner, DependencyObject targetAdorner)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		foreach (Task item in GetTaskRoute(null, sourceAdorner, targetAdorner))
		{
			foreach (CommandBinding commandBinding in item.CommandBindings)
			{
				CommandBinding val = commandBinding;
				if (val.Command.Equals(command))
				{
					return val;
				}
			}
		}
		return null;
	}

	private IEnumerable<Task> GetTaskRoute(Task sourceTask, DependencyObject sourceAdorner, DependencyObject targetAdorner)
	{
		if (_focusedTask != null)
		{
			yield return _focusedTask;
			yield break;
		}
		Task task = sourceTask;
		if (task != null)
		{
			yield return task;
		}
		if (sourceAdorner != null)
		{
			task = AdornerProperties.GetTask(sourceAdorner);
			if (task != null && task != sourceTask)
			{
				yield return task;
			}
		}
		if (targetAdorner != null && targetAdorner != sourceAdorner)
		{
			Task previousTask = task;
			task = AdornerProperties.GetTask(targetAdorner);
			if (task != null && task != previousTask && task != sourceTask)
			{
				yield return task;
			}
		}
		if (_tasks == null)
		{
			yield break;
		}
		foreach (Task task2 in _tasks)
		{
			yield return task2;
		}
	}

	internal ToolCommandBinding GetToolCommandBinding(ICommand command, GestureData data)
	{
		foreach (Task item in GetTaskRoute(data.SourceTask, data.SourceAdorner, data.TargetAdorner))
		{
			foreach (ToolCommandBinding toolCommandBinding in item.ToolCommandBindings)
			{
				if (toolCommandBinding.Command.Equals(command))
				{
					return toolCommandBinding;
				}
			}
		}
		return null;
	}

	protected virtual void OnActivate(Tool previousTool)
	{
	}

	protected virtual void OnDeactivate()
	{
	}

	protected sealed override void OnItemChanged(EditingContext context, ContextItem previousItem)
	{
		Tool tool = (Tool)previousItem;
		tool.OnDeactivate();
		if (tool.FocusedTask != null)
		{
			try
			{
				_isUpdatingTaskItem = true;
				tool.FocusedTask.Revert();
			}
			finally
			{
				_isUpdatingTaskItem = false;
			}
		}
		tool._context = null;
		if (_focusedTask != null)
		{
			_focusedTask.Revert();
			_focusedTask = null;
		}
		_context = context;
		bool flag = false;
		try
		{
			OnActivate(tool);
			CommandManager.InvalidateRequerySuggested();
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				_context = null;
			}
		}
	}

	internal void SetFocusedTask(Task task)
	{
		if (_focusedTask != null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_TaskAlreadyFocused);
		}
		_focusedTask = task;
		bool flag = false;
		try
		{
			UpdateTaskItem();
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				_focusedTask = null;
			}
		}
	}

	private void UpdateTaskItem()
	{
		try
		{
			_isUpdatingTaskItem = true;
			FocusedTask value = new FocusedTask(_focusedTask);
			Context.Items.SetValue(value);
			CommandManager.InvalidateRequerySuggested();
		}
		finally
		{
			_isUpdatingTaskItem = false;
		}
	}
}
