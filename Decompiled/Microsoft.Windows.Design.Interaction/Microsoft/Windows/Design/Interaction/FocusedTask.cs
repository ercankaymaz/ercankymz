using System;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

public sealed class FocusedTask : ContextItem
{
	private Task _task;

	public override Type ItemType => typeof(FocusedTask);

	public Task Task => _task;

	public FocusedTask()
	{
	}

	internal FocusedTask(Task task)
	{
		_task = task;
	}

	protected override void OnItemChanged(EditingContext context, ContextItem previousItem)
	{
		Tool value = context.Items.GetValue<Tool>();
		if (!value.IsUpdatingTaskItem)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_IncorrectFocusedTask);
		}
		base.OnItemChanged(context, previousItem);
	}
}
