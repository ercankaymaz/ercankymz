using System;
using System.Windows;
using System.Windows.Media;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class DragGestureData : MouseGestureData
{
	private DragDropEffects _effects;

	private DragDropEffects _allowedEffects;

	private IDataObject _data;

	public DragDropEffects Effects
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _effects;
		}
		set
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			if ((DragDropEffects)(value & _allowedEffects) != value)
			{
				throw new ArgumentException(MS.Internal.Properties.Resources.Error_EffectsNotAllowed);
			}
			_effects = value;
		}
	}

	public DragDropEffects AllowedEffects => _allowedEffects;

	public IDataObject Data => _data;

	public DragGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, Visual coordinateReference, Point startPosition, Point currentPosition, DragDropEffects allowedEffects, IDataObject data)
		: this(context, sourceModel, targetModel, coordinateReference, startPosition, currentPosition, allowedEffects, data, null, null)
	{
	}//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	//IL_0008: Unknown result type (might be due to invalid IL or missing references)
	//IL_000a: Unknown result type (might be due to invalid IL or missing references)


	public DragGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, Visual coordinateReference, Point startPosition, Point currentPosition, DragDropEffects allowedEffects, IDataObject data, DependencyObject sourceAdorner, DependencyObject targetAdorner)
		: base(context, sourceModel, targetModel, coordinateReference, startPosition, currentPosition, sourceAdorner, targetAdorner)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		_allowedEffects = allowedEffects;
		_data = data;
		_effects = (DragDropEffects)0;
	}

	public new static DragGestureData FromEventArgs(ExecutedToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<DragGestureData>(e.Parameter);
	}

	public new static DragGestureData FromEventArgs(CanExecuteToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<DragGestureData>(e.Parameter);
	}
}
