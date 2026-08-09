using System;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public class CreationTool : Tool
{
	private Type _creationType;

	public Type CreationType
	{
		get
		{
			return _creationType;
		}
		set
		{
			_creationType = value;
		}
	}

	public event EventHandler CreationComplete;

	public CreationTool()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		base.Cursor = Cursors.Cross;
		Task task = new Task();
		task.InputBindings.Add(new InputBinding((ICommand)DesignerCommands.Cancel, (InputGesture)new KeyGesture((Key)13)));
		task.CommandBindings.Add(new CommandBinding((ICommand)DesignerCommands.Cancel, new ExecutedRoutedEventHandler(OnCancel)));
		base.Tasks.Add(task);
	}

	private void OnCancel(object sender, ExecutedRoutedEventArgs e)
	{
		if (base.FocusedTask != null)
		{
			base.FocusedTask.Revert();
		}
		this.CreationComplete(sender, (EventArgs)(object)e);
	}

	protected virtual void OnCreationComplete(EventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (this.CreationComplete != null)
		{
			this.CreationComplete(this, e);
		}
	}

	public void PerformCreationComplete()
	{
		OnCreationComplete(EventArgs.Empty);
	}
}
