using System.Windows;
using System.Windows.Controls;

namespace Xceed.Wpf.AvalonDock.Controls;

public class MenuItemEx : MenuItem
{
	private bool _reentrantFlag;

	public static readonly DependencyProperty IconTemplateProperty;

	public static readonly DependencyProperty IconTemplateSelectorProperty;

	public DataTemplate IconTemplate
	{
		get
		{
			return (DataTemplate)((DependencyObject)this).GetValue(IconTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconTemplateProperty, (object)value);
		}
	}

	public DataTemplateSelector IconTemplateSelector
	{
		get
		{
			return (DataTemplateSelector)((DependencyObject)this).GetValue(IconTemplateSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IconTemplateSelectorProperty, (object)value);
		}
	}

	static MenuItemEx()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		IconTemplateProperty = DependencyProperty.Register("IconTemplate", typeof(DataTemplate), typeof(MenuItemEx), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnIconTemplateChanged)));
		IconTemplateSelectorProperty = DependencyProperty.Register("IconTemplateSelector", typeof(DataTemplateSelector), typeof(MenuItemEx), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(OnIconTemplateSelectorChanged)));
		MenuItem.IconProperty.OverrideMetadata(typeof(MenuItemEx), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIconPropertyChanged)));
	}

	private static void OnIconTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((MenuItemEx)(object)d).OnIconTemplateChanged(e);
	}

	protected virtual void OnIconTemplateChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateIcon();
	}

	private static void OnIconTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((MenuItemEx)(object)d).OnIconTemplateSelectorChanged(e);
	}

	protected virtual void OnIconTemplateSelectorChanged(DependencyPropertyChangedEventArgs e)
	{
		UpdateIcon();
	}

	private static void OnIconPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
	{
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			((MenuItemEx)(object)sender).UpdateIcon();
		}
	}

	private void UpdateIcon()
	{
		if (_reentrantFlag)
		{
			return;
		}
		_reentrantFlag = true;
		if (IconTemplateSelector != null)
		{
			DataTemplate dataTemplate = IconTemplateSelector.SelectTemplate(base.Icon, (DependencyObject)(object)this);
			if (dataTemplate != null)
			{
				base.Icon = dataTemplate.LoadContent();
			}
		}
		else if (IconTemplate != null)
		{
			base.Icon = IconTemplate.LoadContent();
		}
		_reentrantFlag = false;
	}
}
