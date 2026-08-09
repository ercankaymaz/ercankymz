using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutDocumentItem : LayoutItem
{
	private LayoutDocument _document;

	public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(LayoutDocumentItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnDescriptionChanged)));

	public string Description
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(DescriptionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DescriptionProperty, (object)value);
		}
	}

	internal LayoutDocumentItem()
	{
	}

	private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((LayoutDocumentItem)(object)d).OnDescriptionChanged(e);
	}

	protected virtual void OnDescriptionChanged(DependencyPropertyChangedEventArgs e)
	{
		_document.Description = (string)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}

	protected override void Close()
	{
		if (_document.Root != null && _document.Root.Manager != null)
		{
			_document.Root.Manager._ExecuteCloseCommand(_document);
		}
	}

	protected override void OnVisibilityChanged()
	{
		if (_document != null && _document.Root != null)
		{
			_document.IsVisible = base.Visibility == Visibility.Visible;
			if (_document.Parent is LayoutDocumentPane)
			{
				((LayoutDocumentPane)_document.Parent).ComputeVisibility();
			}
		}
		base.OnVisibilityChanged();
	}

	internal override void Attach(LayoutContent model)
	{
		_document = model as LayoutDocument;
		base.Attach(model);
	}

	internal override void Detach()
	{
		_document = null;
		base.Detach();
	}
}
