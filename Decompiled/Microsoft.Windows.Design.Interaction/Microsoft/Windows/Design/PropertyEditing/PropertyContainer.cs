using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Microsoft.Windows.Design.PropertyEditing;

public class PropertyContainer : Control, INotifyPropertyChanged
{
	private static RoutedCommand _openDialogWindow;

	private DependencyPropertyChangedEventHandler m_DependencyPropertyChanged;

	private bool _attachedToPropertyEntryEvents;

	public static readonly DependencyProperty PropertyEntryProperty = DependencyProperty.Register("PropertyEntry", typeof(PropertyEntry), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(PropertyEntryPropertyChanged)));

	public static readonly DependencyProperty ActiveEditModeProperty = DependencyProperty.Register("ActiveEditMode", typeof(PropertyContainerEditMode), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)PropertyContainerEditMode.Inline, new PropertyChangedCallback(OnActiveEditModePropertyChanged)));

	public static readonly DependencyProperty DialogCommandSourceProperty = DependencyProperty.Register("DialogCommandSource", typeof(IInputElement), typeof(PropertyContainer), new PropertyMetadata((object)null));

	public static readonly DependencyProperty OwningPropertyContainerProperty = DependencyProperty.RegisterAttached("OwningPropertyContainer", typeof(PropertyContainer), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)32));

	public static readonly DependencyProperty InlineRowTemplateProperty = DependencyProperty.Register("InlineRowTemplate", typeof(ControlTemplate), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)0, new PropertyChangedCallback(RowTemplateChanged)));

	public static readonly DependencyProperty ExtendedPopupRowTemplateProperty = DependencyProperty.Register("ExtendedPopupRowTemplate", typeof(ControlTemplate), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)0, new PropertyChangedCallback(RowTemplateChanged)));

	public static readonly DependencyProperty ExtendedPinnedRowTemplateProperty = DependencyProperty.Register("ExtendedPinnedRowTemplate", typeof(ControlTemplate), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, (FrameworkPropertyMetadataOptions)0, new PropertyChangedCallback(RowTemplateChanged)));

	public static readonly DependencyProperty DefaultStandardValuesPropertyValueEditorProperty = DependencyProperty.Register("DefaultStandardValuesPropertyValueEditor", typeof(PropertyValueEditor), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(DefaultPropertyValueEditorChanged)));

	public static readonly DependencyProperty DefaultPropertyValueEditorProperty = DependencyProperty.Register("DefaultPropertyValueEditor", typeof(PropertyValueEditor), typeof(PropertyContainer), (PropertyMetadata)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(DefaultPropertyValueEditorChanged)));

	public PropertyEntry PropertyEntry
	{
		get
		{
			return (PropertyEntry)((DependencyObject)this).GetValue(PropertyEntryProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PropertyEntryProperty, (object)value);
		}
	}

	public PropertyContainerEditMode ActiveEditMode
	{
		get
		{
			return (PropertyContainerEditMode)((DependencyObject)this).GetValue(ActiveEditModeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveEditModeProperty, (object)value);
		}
	}

	public IInputElement DialogCommandSource
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (IInputElement)((DependencyObject)this).GetValue(DialogCommandSourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DialogCommandSourceProperty, (object)value);
		}
	}

	public ControlTemplate InlineRowTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ControlTemplate)((DependencyObject)this).GetValue(InlineRowTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InlineRowTemplateProperty, (object)value);
		}
	}

	public ControlTemplate ExtendedPopupRowTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ControlTemplate)((DependencyObject)this).GetValue(ExtendedPopupRowTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExtendedPopupRowTemplateProperty, (object)value);
		}
	}

	public ControlTemplate ExtendedPinnedRowTemplate
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (ControlTemplate)((DependencyObject)this).GetValue(ExtendedPinnedRowTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ExtendedPinnedRowTemplateProperty, (object)value);
		}
	}

	public PropertyValueEditor DefaultStandardValuesPropertyValueEditor
	{
		get
		{
			return (PropertyValueEditor)((DependencyObject)this).GetValue(DefaultStandardValuesPropertyValueEditorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultStandardValuesPropertyValueEditorProperty, (object)value);
		}
	}

	public PropertyValueEditor DefaultPropertyValueEditor
	{
		get
		{
			return (PropertyValueEditor)((DependencyObject)this).GetValue(DefaultPropertyValueEditorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultPropertyValueEditorProperty, (object)value);
		}
	}

	public DataTemplate InlineEditorTemplate => FindPropertyValueEditorTemplate(PropertyContainerEditMode.Inline);

	public DataTemplate ExtendedEditorTemplate => FindPropertyValueEditorTemplate(PropertyContainerEditMode.ExtendedPinned);

	public DataTemplate DialogEditorTemplate => FindPropertyValueEditorTemplate(PropertyContainerEditMode.Dialog);

	public bool MatchesFilter => PropertyEntry?.MatchesFilter ?? false;

	public static RoutedCommand OpenDialogWindow
	{
		get
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			if (_openDialogWindow == null)
			{
				_openDialogWindow = new RoutedCommand("OpenDialogWindow", typeof(PropertyContainer));
			}
			return _openDialogWindow;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	internal event DependencyPropertyChangedEventHandler DependencyPropertyChanged
	{
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			DependencyPropertyChangedEventHandler val = this.m_DependencyPropertyChanged;
			DependencyPropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				DependencyPropertyChangedEventHandler value2 = (DependencyPropertyChangedEventHandler)Delegate.Combine((Delegate)(object)val2, (Delegate)(object)value);
				val = Interlocked.CompareExchange(ref this.m_DependencyPropertyChanged, value2, val2);
			}
			while (val != val2);
		}
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			DependencyPropertyChangedEventHandler val = this.m_DependencyPropertyChanged;
			DependencyPropertyChangedEventHandler val2;
			do
			{
				val2 = val;
				DependencyPropertyChangedEventHandler value2 = (DependencyPropertyChangedEventHandler)Delegate.Remove((Delegate)(object)val2, (Delegate)(object)value);
				val = Interlocked.CompareExchange(ref this.m_DependencyPropertyChanged, value2, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler PropertyEntryChanged;

	public event EventHandler ActiveEditModeChanged;

	public PropertyContainer()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		SetOwningPropertyContainer((DependencyObject)(object)this, this);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(OnLoaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(OnUnloaded);
	}

	private static void PropertyEntryPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		PropertyContainer propertyContainer = (PropertyContainer)(object)obj;
		propertyContainer.NotifyTemplatesChanged();
		propertyContainer.OnPropertyChanged("MatchesFilter");
		propertyContainer.ActiveEditMode = PropertyContainerEditMode.Inline;
		UpdateControlTemplate(propertyContainer);
		if (((DependencyPropertyChangedEventArgs)(ref e)).OldValue != null)
		{
			propertyContainer.DisassociatePropertyEventHandlers((PropertyEntry)((DependencyPropertyChangedEventArgs)(ref e)).OldValue);
		}
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue != null)
		{
			propertyContainer.AssociatePropertyEventHandlers((PropertyEntry)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
		}
		if (propertyContainer.PropertyEntryChanged != null)
		{
			propertyContainer.PropertyEntryChanged(propertyContainer, EventArgs.Empty);
		}
	}

	private static void OnActiveEditModePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		PropertyContainer propertyContainer = (PropertyContainer)(object)obj;
		UpdateControlTemplate(propertyContainer);
		if (propertyContainer.ActiveEditModeChanged != null)
		{
			propertyContainer.ActiveEditModeChanged(propertyContainer, EventArgs.Empty);
		}
		if (object.Equals(((DependencyPropertyChangedEventArgs)(ref e)).NewValue, PropertyContainerEditMode.Dialog))
		{
			IInputElement val = (IInputElement)(((object)propertyContainer.DialogCommandSource) ?? ((object)propertyContainer));
			if (OpenDialogWindow.CanExecute((object)propertyContainer.PropertyEntry, val))
			{
				OpenDialogWindow.Execute((object)propertyContainer.PropertyEntry, val);
			}
			else
			{
				propertyContainer.FindDialogPropertyValueEditor()?.ShowDialog(propertyContainer.PropertyEntry.PropertyValue, val);
			}
			propertyContainer.ActiveEditMode = (PropertyContainerEditMode)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		}
	}

	public static void SetOwningPropertyContainer(DependencyObject dependencyObject, PropertyContainer value)
	{
		if (dependencyObject == null)
		{
			throw new ArgumentNullException("dependencyObject");
		}
		dependencyObject.SetValue(OwningPropertyContainerProperty, (object)value);
	}

	public static PropertyContainer GetOwningPropertyContainer(DependencyObject dependencyObject)
	{
		if (dependencyObject == null)
		{
			throw new ArgumentNullException("dependencyObject");
		}
		return (PropertyContainer)dependencyObject.GetValue(OwningPropertyContainerProperty);
	}

	private static void RowTemplateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		PropertyContainer propertyContainer = (PropertyContainer)(object)obj;
		bool flag = false;
		flag |= ((DependencyPropertyChangedEventArgs)(ref e)).Property == InlineRowTemplateProperty && propertyContainer.ActiveEditMode == PropertyContainerEditMode.Inline;
		flag |= ((DependencyPropertyChangedEventArgs)(ref e)).Property == ExtendedPopupRowTemplateProperty && propertyContainer.ActiveEditMode == PropertyContainerEditMode.ExtendedPopup;
		if (flag | (((DependencyPropertyChangedEventArgs)(ref e)).Property == ExtendedPinnedRowTemplateProperty && propertyContainer.ActiveEditMode == PropertyContainerEditMode.ExtendedPinned))
		{
			UpdateControlTemplate(propertyContainer);
		}
	}

	private static void DefaultPropertyValueEditorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
	{
		PropertyContainer propertyContainer = (PropertyContainer)(object)obj;
		propertyContainer.NotifyTemplatesChanged();
	}

	internal bool SupportsEditMode(PropertyContainerEditMode mode)
	{
		if (mode == PropertyContainerEditMode.Dialog)
		{
			return FindDialogPropertyValueEditor() != null;
		}
		return FindPropertyValueEditorTemplate(mode) != null;
	}

	private void OnUnloaded(object sender, RoutedEventArgs e)
	{
		PropertyEntry propertyEntry = PropertyEntry;
		if (propertyEntry != null)
		{
			DisassociatePropertyEventHandlers(propertyEntry);
		}
	}

	private void OnLoaded(object sender, RoutedEventArgs e)
	{
		PropertyEntry propertyEntry = PropertyEntry;
		if (propertyEntry != null)
		{
			AssociatePropertyEventHandlers(propertyEntry);
		}
	}

	private void AssociatePropertyEventHandlers(PropertyEntry property)
	{
		if (!_attachedToPropertyEntryEvents)
		{
			property.PropertyChanged += OnPropertyPropertyChanged;
			_attachedToPropertyEntryEvents = true;
		}
	}

	private void DisassociatePropertyEventHandlers(PropertyEntry property)
	{
		if (_attachedToPropertyEntryEvents)
		{
			property.PropertyChanged -= OnPropertyPropertyChanged;
			_attachedToPropertyEntryEvents = false;
		}
	}

	private void OnPropertyPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if ("MatchesFilter".Equals(e.PropertyName))
		{
			OnPropertyChanged("MatchesFilter");
		}
		else if ("PropertyValueEditor".Equals(e.PropertyName))
		{
			NotifyTemplatesChanged();
		}
	}

	private DataTemplate FindPropertyValueEditorTemplate(PropertyContainerEditMode editMode)
	{
		PropertyEntry propertyEntry = PropertyEntry;
		PropertyValueEditor propertyValueEditor = null;
		DataTemplate val = null;
		if (propertyEntry != null && val == null)
		{
			propertyValueEditor = propertyEntry.PropertyValueEditor;
			if (propertyValueEditor != null)
			{
				val = propertyValueEditor.GetPropertyValueEditor(editMode);
			}
		}
		if (val != null)
		{
			return val;
		}
		if (propertyEntry != null && propertyEntry.HasStandardValuesInternal)
		{
			propertyValueEditor = DefaultStandardValuesPropertyValueEditor;
			if (propertyValueEditor != null)
			{
				val = propertyValueEditor.GetPropertyValueEditor(editMode);
			}
		}
		if (val != null)
		{
			return val;
		}
		propertyValueEditor = DefaultPropertyValueEditor;
		if (propertyValueEditor != null)
		{
			val = propertyValueEditor.GetPropertyValueEditor(editMode);
		}
		return val;
	}

	private DialogPropertyValueEditor FindDialogPropertyValueEditor()
	{
		PropertyEntry propertyEntry = PropertyEntry;
		DialogPropertyValueEditor dialogPropertyValueEditor = null;
		if (propertyEntry != null)
		{
			dialogPropertyValueEditor = propertyEntry.PropertyValueEditor as DialogPropertyValueEditor;
		}
		if (dialogPropertyValueEditor != null)
		{
			return dialogPropertyValueEditor;
		}
		if (propertyEntry != null && propertyEntry.HasStandardValuesInternal)
		{
			dialogPropertyValueEditor = DefaultStandardValuesPropertyValueEditor as DialogPropertyValueEditor;
		}
		if (dialogPropertyValueEditor != null)
		{
			return dialogPropertyValueEditor;
		}
		return DefaultPropertyValueEditor as DialogPropertyValueEditor;
	}

	private static void UpdateControlTemplate(PropertyContainer container)
	{
		PropertyContainerEditMode activeEditMode = container.ActiveEditMode;
		ControlTemplate val = null;
		switch (activeEditMode)
		{
		case PropertyContainerEditMode.Inline:
			val = container.InlineRowTemplate;
			break;
		case PropertyContainerEditMode.ExtendedPopup:
			val = container.ExtendedPopupRowTemplate;
			break;
		case PropertyContainerEditMode.ExtendedPinned:
			val = container.ExtendedPinnedRowTemplate;
			break;
		case PropertyContainerEditMode.Dialog:
			return;
		default:
			val = ((Control)container).Template;
			break;
		}
		if (val != ((Control)container).Template)
		{
			((Control)container).Template = val;
		}
	}

	private void NotifyTemplatesChanged()
	{
		OnPropertyChanged("InlineEditorTemplate");
		OnPropertyChanged("ExtendedEditorTemplate");
		OnPropertyChanged("DialogEditorTemplate");
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (this.DependencyPropertyChanged != null)
		{
			this.DependencyPropertyChanged.Invoke((object)this, e);
		}
		((FrameworkElement)this).OnPropertyChanged(e);
	}
}
