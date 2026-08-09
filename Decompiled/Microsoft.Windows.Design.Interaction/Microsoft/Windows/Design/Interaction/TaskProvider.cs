using System.Collections.Generic;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

[FeatureConnector(typeof(TaskProviderFeatureConnector))]
public abstract class TaskProvider : FeatureProvider
{
	private ICollection<Task> _tasks;

	private EditingContext _context;

	public ICollection<Task> Tasks
	{
		get
		{
			if (_tasks == null)
			{
				_tasks = new List<Task>();
			}
			return _tasks;
		}
	}

	protected EditingContext Context => _context;

	public virtual bool IsToolSupported(Tool tool)
	{
		if (tool is SelectionTool)
		{
			return true;
		}
		return false;
	}

	protected virtual void Activate(ModelItem item)
	{
	}

	protected virtual void Deactivate()
	{
	}

	internal void InvokeActivate(EditingContext context, ModelItem item)
	{
		_context = context;
		Activate(item);
	}

	internal void InvokeDeactivate()
	{
		if (_context != null)
		{
			Deactivate();
			_context = null;
		}
	}
}
