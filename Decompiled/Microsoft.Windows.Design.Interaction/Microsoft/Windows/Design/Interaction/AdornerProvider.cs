using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using MS.Internal.Features;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

[FeatureConnector(typeof(AdornerProviderFeatureConnector))]
public abstract class AdornerProvider : FeatureProvider
{
	private Collection<UIElement> _adorners;

	private EditingContext _context;

	private bool _adornersVisible = true;

	private bool _firstActivate;

	private bool _canClearAdorners;

	public Collection<UIElement> Adorners
	{
		get
		{
			if (_adorners == null)
			{
				_adorners = new Collection<UIElement>();
			}
			return _adorners;
		}
	}

	public bool AdornersVisible
	{
		get
		{
			return _adornersVisible;
		}
		set
		{
			if (_adornersVisible == value)
			{
				return;
			}
			_adornersVisible = value;
			if (_context == null)
			{
				return;
			}
			DesignerView designerView = DesignerView.FromContext(_context);
			if (designerView == null)
			{
				return;
			}
			ICollection<UIElement> adorners = designerView.Adorners;
			if (_adornersVisible)
			{
				foreach (UIElement adorner in Adorners)
				{
					if (LogicalTreeHelper.GetParent((DependencyObject)(object)adorner) == null)
					{
						adorners.Add(adorner);
					}
				}
				return;
			}
			foreach (UIElement adorner2 in Adorners)
			{
				if (LogicalTreeHelper.GetParent((DependencyObject)(object)adorner2) != null)
				{
					adorners.Remove(adorner2);
				}
			}
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
		if (_firstActivate && _canClearAdorners && Adorners.Count > 0)
		{
			Adorners.Clear();
		}
		if (!_firstActivate)
		{
			_firstActivate = true;
			_canClearAdorners = Adorners.Count == 0;
		}
		Activate(item);
		foreach (UIElement adorner in Adorners)
		{
			if (((DependencyObject)adorner).ReadLocalValue(AdornerProperties.ModelProperty) == DependencyProperty.UnsetValue)
			{
				AdornerProperties.SetModel((DependencyObject)(object)adorner, item);
			}
		}
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
