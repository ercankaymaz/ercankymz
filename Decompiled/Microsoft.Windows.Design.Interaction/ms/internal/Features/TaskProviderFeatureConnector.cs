using System.Collections.Generic;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace MS.Internal.Features;

[RequiresContextItem(typeof(Tool))]
internal class TaskProviderFeatureConnector : PolicyDrivenToolFeatureConnector<TaskProvider>
{
	private List<Task> _currentTasks;

	public TaskProviderFeatureConnector(FeatureManager manager)
		: base(manager)
	{
	}

	protected override bool IsValidProvider(FeatureProvider featureProvider)
	{
		if (featureProvider is TaskProvider taskProvider)
		{
			return taskProvider.IsToolSupported(base.CurrentTool);
		}
		return false;
	}

	protected override void FeatureProvidersAdded(ModelItem item, IEnumerable<TaskProvider> extensions)
	{
		if (_currentTasks == null)
		{
			_currentTasks = new List<Task>();
		}
		Tool currentTool = base.CurrentTool;
		foreach (TaskProvider extension in extensions)
		{
			extension.InvokeActivate(base.Context, item);
			foreach (Task task in extension.Tasks)
			{
				RequirementValidator requirementValidator = new RequirementValidator(base.Manager, task.GetType());
				if (requirementValidator.MeetsRequirements)
				{
					currentTool.Tasks.Add(task);
					_currentTasks.Add(task);
				}
			}
		}
	}

	protected override void FeatureProvidersRemoved(ModelItem item, IEnumerable<TaskProvider> extensions)
	{
		Tool currentTool = base.CurrentTool;
		foreach (TaskProvider extension in extensions)
		{
			foreach (Task task in extension.Tasks)
			{
				currentTool.Tasks.Remove(task);
				if (_currentTasks != null)
				{
					_currentTasks.Remove(task);
				}
			}
			extension.InvokeDeactivate();
		}
	}

	protected override void UpdateCurrentTool(Tool newTool)
	{
		Tool currentTool = base.CurrentTool;
		if (currentTool == newTool)
		{
			return;
		}
		if (_currentTasks != null)
		{
			foreach (Task currentTask in _currentTasks)
			{
				currentTool?.Tasks.Remove(currentTask);
				newTool?.Tasks.Add(currentTask);
			}
		}
		base.UpdateCurrentTool(newTool);
	}
}
