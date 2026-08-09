using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class MouseGestureData : GestureData
{
	private Visual _coordinateReference;

	private Point _currentPosition;

	private Point _startPosition;

	public Point CurrentPosition => _currentPosition;

	public Point StartPosition => _startPosition;

	public Vector PositionDelta => new Vector(((Point)(ref _currentPosition)).X - ((Point)(ref _startPosition)).X, ((Point)(ref _currentPosition)).Y - ((Point)(ref _startPosition)).Y);

	public MouseGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, Visual coordinateReference, Point startPosition, Point currentPosition)
		: this(context, sourceModel, targetModel, coordinateReference, startPosition, currentPosition, null, null)
	{
	}//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	//IL_0008: Unknown result type (might be due to invalid IL or missing references)


	public MouseGestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, Visual coordinateReference, Point startPosition, Point currentPosition, DependencyObject sourceAdorner, DependencyObject targetAdorner)
		: base(context, sourceModel, targetModel, sourceAdorner, targetAdorner)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (coordinateReference == null)
		{
			throw new ArgumentNullException("coordinateReference");
		}
		_coordinateReference = coordinateReference;
		_startPosition = startPosition;
		_currentPosition = currentPosition;
	}

	public Point TranslatePoint(Point pt, ModelItem referenceTo)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		if (referenceTo == null)
		{
			throw new ArgumentNullException("referenceTo");
		}
		ViewItem view = referenceTo.View;
		if (view == null)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_VisualNotInDesigner, new object[1] { referenceTo }));
		}
		try
		{
			GeneralTransform val = view.TransformFromVisual(_coordinateReference);
			if (val != null)
			{
				pt = val.Transform(pt);
			}
		}
		catch (InvalidOperationException)
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_VisualNotInDesigner, new object[1] { referenceTo }));
		}
		return pt;
	}

	public new static MouseGestureData FromEventArgs(ExecutedToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<MouseGestureData>(e.Parameter);
	}

	public new static MouseGestureData FromEventArgs(CanExecuteToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return GestureData.FromParameter<MouseGestureData>(e.Parameter);
	}
}
