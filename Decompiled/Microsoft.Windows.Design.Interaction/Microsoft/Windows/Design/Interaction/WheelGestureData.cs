using System;
using System.Windows;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class WheelGestureData : GestureData
{
	private int _delta;

	public int Delta => _delta;

	public WheelGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, int delta)
		: this(context, sourceModel, targetModel, delta, null, null)
	{
	}

	public WheelGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, int delta, DependencyObject sourceAdorner, DependencyObject targetAdorner)
		: base(context, sourceModel, targetModel, sourceAdorner, targetAdorner)
	{
		_delta = delta;
	}

	public new static WheelGestureData FromEventArgs(ExecutedToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<WheelGestureData>(e.Parameter);
	}

	public new static WheelGestureData FromEventArgs(CanExecuteToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<WheelGestureData>(e.Parameter);
	}
}
