using System.Windows.Input;
using MS.Internal;

namespace Microsoft.Windows.Design.Interaction;

public class SelectionTool : Tool
{
	private bool isLocalSelectAll = true;

	public SelectionTool()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		Task task = new Task();
		task.CommandBindings.Add(new CommandBinding((ICommand)DesignerCommands.Cancel, new ExecutedRoutedEventHandler(OnSelectParent)));
		task.CommandBindings.Add(new CommandBinding((ICommand)SelectionCommands.SelectAll, new ExecutedRoutedEventHandler(OnSelectAll)));
		task.CommandBindings.Add(new CommandBinding((ICommand)SelectionCommands.SelectNext, new ExecutedRoutedEventHandler(OnSelectNext)));
		task.CommandBindings.Add(new CommandBinding((ICommand)SelectionCommands.SelectPrevious, new ExecutedRoutedEventHandler(OnSelectPrevious)));
		task.ToolCommandBindings.Add(new ToolCommandBinding(SelectionCommands.SelectTarget, OnSelectObject));
		task.ToolCommandBindings.Add(new ToolCommandBinding(SelectionCommands.SelectOnlyTarget, OnSelectOnlyObject));
		task.ToolCommandBindings.Add(new ToolCommandBinding(SelectionCommands.ToggleSelectTarget, OnToggleSelectObject));
		task.ToolCommandBindings.Add(new ToolCommandBinding(SelectionCommands.UnionSelectTarget, OnUnionSelectObject));
		task.ToolCommandBindings.Add(new ToolCommandBinding(SelectionCommands.ShowEvent, OnShowEvent));
		task.InputBindings.Add(new InputBinding((ICommand)DesignerCommands.Cancel, (InputGesture)new KeyGesture((Key)13)));
		task.InputBindings.Add(new InputBinding((ICommand)SelectionCommands.SelectAll, (InputGesture)new KeyGesture((Key)44, (ModifierKeys)2)));
		task.InputBindings.Add(new InputBinding((ICommand)SelectionCommands.SelectNext, (InputGesture)new KeyGesture((Key)3)));
		task.InputBindings.Add(new InputBinding((ICommand)SelectionCommands.SelectPrevious, (InputGesture)new KeyGesture((Key)3, (ModifierKeys)4)));
		task.InputBindings.Add(new InputBinding((ICommand)SelectionCommands.ShowEvent, (InputGesture)new KeyGesture((Key)6)));
		task.InputBindings.Add(new InputBinding((ICommand)SelectionCommands.ShowEvent, (InputGesture)(object)new ToolGesture(ToolAction.DoubleClick)));
		base.Tasks.Add(task);
	}

	protected override void OnActivate(Tool previousTool)
	{
		base.OnActivate(previousTool);
		base.Context.Items.Subscribe<Selection>(OnSelectionChanged);
	}

	protected override void OnDeactivate()
	{
		base.OnDeactivate();
		base.Context.Items.Unsubscribe<Selection>(OnSelectionChanged);
	}

	private void OnSelectParent(object sender, ExecutedRoutedEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectionChange);
		SelectionImplementation.SelectParent(base.Context);
		Performance.StopTiming(PerformanceMarks.SelectionChange);
	}

	private void OnSelectAll(object sender, ExecutedRoutedEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectAll);
		SelectionImplementation.SelectAll(base.Context, isLocalSelectAll);
		isLocalSelectAll = false;
		Performance.StopTiming(PerformanceMarks.SelectAll);
	}

	private void OnSelectNext(object sender, ExecutedRoutedEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectNext);
		SelectionImplementation.SelectNext(base.Context);
		Performance.StopTiming(PerformanceMarks.SelectNext);
	}

	private void OnSelectPrevious(object sender, ExecutedRoutedEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectPrevious);
		SelectionImplementation.SelectPrevious(base.Context);
		Performance.StopTiming(PerformanceMarks.SelectPrevious);
	}

	private void OnSelectionChanged(Selection s)
	{
		isLocalSelectAll = true;
	}

	private void OnSelectObject(object sender, ExecutedToolEventArgs e)
	{
		GestureData gestureData = GestureData.FromEventArgs(e);
		if (gestureData.ImpliedSource != null)
		{
			Performance.StartTiming(PerformanceMarks.SelectionChange);
			SelectionOperations.Select(base.Context, gestureData.ImpliedSource);
			Performance.StopTiming(PerformanceMarks.SelectionChange);
		}
	}

	private void OnSelectOnlyObject(object sender, ExecutedToolEventArgs e)
	{
		GestureData gestureData = GestureData.FromEventArgs(e);
		if (gestureData.ImpliedSource != null)
		{
			Performance.StartTiming(PerformanceMarks.SelectionChange);
			SelectionOperations.SelectOnly(base.Context, gestureData.ImpliedSource);
			Performance.StopTiming(PerformanceMarks.SelectionChange);
		}
	}

	private void OnToggleSelectObject(object sender, ExecutedToolEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectionChange);
		GestureData gestureData = GestureData.FromEventArgs(e);
		SelectionOperations.Toggle(base.Context, gestureData.ImpliedSource);
		Performance.StopTiming(PerformanceMarks.SelectionChange);
	}

	private void OnUnionSelectObject(object sender, ExecutedToolEventArgs e)
	{
		Performance.StartTiming(PerformanceMarks.SelectionChange);
		GestureData gestureData = GestureData.FromEventArgs(e);
		SelectionOperations.Union(base.Context, gestureData.ImpliedSource);
		Performance.StopTiming(PerformanceMarks.SelectionChange);
	}

	private void OnShowEvent(object sender, ExecutedToolEventArgs e)
	{
		SelectionImplementation.ShowDefaultEvent(base.Context);
	}
}
