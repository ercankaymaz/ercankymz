using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public class GestureData
{
	private EditingContext _context;

	private ModelItem _sourceModel;

	private ModelItem _targetModel;

	private ModelItem _impliedSource;

	private ModelItem _impliedTarget;

	private DependencyObject _sourceAdorner;

	private DependencyObject _targetAdorner;

	private Task _sourceTask;

	public EditingContext Context => _context;

	public ModelItem ImpliedSource
	{
		get
		{
			if (_impliedSource == null)
			{
				_impliedSource = GetImpliedModel(_sourceAdorner, _sourceModel);
			}
			return _impliedSource;
		}
	}

	public ModelItem ImpliedTarget
	{
		get
		{
			if (_impliedTarget == null)
			{
				_impliedTarget = GetImpliedModel(_targetAdorner, _targetModel);
			}
			return _impliedTarget;
		}
	}

	public DependencyObject SourceAdorner => _sourceAdorner;

	public ModelItem SourceModel => _sourceModel;

	internal Task SourceTask
	{
		get
		{
			return _sourceTask;
		}
		set
		{
			_sourceTask = value;
		}
	}

	public DependencyObject TargetAdorner => _targetAdorner;

	public ModelItem TargetModel => _targetModel;

	public ICollection<UIElement> Adorners
	{
		get
		{
			DesignerView designerView = DesignerView.FromContext(Context);
			if (designerView == null)
			{
				throw new NotSupportedException(MS.Internal.Properties.Resources.Error_NoDesignerView);
			}
			return designerView.Adorners;
		}
	}

	public GestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel)
		: this(context, sourceModel, targetModel, null, null)
	{
	}

	public GestureData(EditingContext context, ModelItem sourceModel, ModelItem targetModel, DependencyObject sourceAdorner, DependencyObject targetAdorner)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (sourceModel == null)
		{
			throw new ArgumentNullException("sourceModel");
		}
		if (targetModel == null)
		{
			throw new ArgumentNullException("targetModel");
		}
		_context = context;
		_sourceModel = sourceModel;
		_targetModel = targetModel;
		_sourceAdorner = sourceAdorner;
		_targetAdorner = targetAdorner;
	}

	public static GestureData FromEventArgs(ExecutedToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return FromParameter<GestureData>(e.Parameter);
	}

	public static GestureData FromEventArgs(CanExecuteToolEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		return FromParameter<GestureData>(e.Parameter);
	}

	internal static GestureDataType FromParameter<GestureDataType>(object parameter) where GestureDataType : GestureData
	{
		if (!(parameter is GestureDataType result))
		{
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_NoGestureData, new object[1] { typeof(GestureDataType).Name }));
		}
		return result;
	}

	private static ModelItem GetImpliedModel(DependencyObject adorner, ModelItem model)
	{
		ModelItem modelItem = null;
		if (adorner != null)
		{
			modelItem = AdornerProperties.GetModel(adorner);
		}
		if (modelItem == null)
		{
			modelItem = model;
		}
		return modelItem;
	}
}
