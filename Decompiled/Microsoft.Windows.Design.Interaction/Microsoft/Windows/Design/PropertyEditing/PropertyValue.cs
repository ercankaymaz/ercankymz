using System;
using System.ComponentModel;
using System.Globalization;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class PropertyValue : INotifyPropertyChanged
{
	private PropertyEntry _parentProperty;

	public virtual PropertyEntry ParentProperty => _parentProperty;

	public abstract PropertyValueSource Source { get; }

	public abstract bool IsDefaultValue { get; }

	public abstract bool IsMixedValue { get; }

	public abstract bool CanConvertFromString { get; }

	public object Value
	{
		get
		{
			object result = null;
			if (CatchExceptions)
			{
				try
				{
					result = GetValueCore();
				}
				catch (Exception exception)
				{
					OnPropertyValueException(new PropertyValueExceptionEventArgs(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ValueGetFailed), this, PropertyValueExceptionSource.Get, exception));
				}
			}
			else
			{
				result = GetValueCore();
			}
			return result;
		}
		set
		{
			if (CatchExceptions)
			{
				try
				{
					SetValueImpl(value);
					return;
				}
				catch (Exception exception)
				{
					OnPropertyValueException(new PropertyValueExceptionEventArgs(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ValueSetFailed), this, PropertyValueExceptionSource.Set, exception));
					return;
				}
			}
			SetValueImpl(value);
		}
	}

	public string StringValue
	{
		get
		{
			string result = string.Empty;
			if (CatchExceptions)
			{
				try
				{
					result = ConvertValueToString(Value);
				}
				catch (Exception exception)
				{
					OnPropertyValueException(new PropertyValueExceptionEventArgs(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_CannotConvertValueToString), this, PropertyValueExceptionSource.Get, exception));
				}
			}
			else
			{
				result = ConvertValueToString(Value);
			}
			return result;
		}
		set
		{
			if (CatchExceptions)
			{
				try
				{
					Value = ConvertStringToValue(value);
					return;
				}
				catch (Exception exception)
				{
					OnPropertyValueException(new PropertyValueExceptionEventArgs(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_CannotUpdateValueFromStringValue), this, PropertyValueExceptionSource.Set, exception));
					return;
				}
			}
			Value = ConvertStringToValue(value);
		}
	}

	public abstract bool HasSubProperties { get; }

	public abstract PropertyEntryCollection SubProperties { get; }

	public abstract bool IsCollection { get; }

	public abstract PropertyValueCollection Collection { get; }

	protected virtual bool CatchExceptions => this.PropertyValueException != null;

	public event PropertyChangedEventHandler PropertyChanged;

	public event EventHandler RootValueChanged;

	public event EventHandler SubPropertyChanged;

	public event EventHandler<PropertyValueExceptionEventArgs> PropertyValueException;

	protected PropertyValue(PropertyEntry parentProperty)
	{
		if (parentProperty == null)
		{
			throw new ArgumentNullException("parentProperty");
		}
		_parentProperty = parentProperty;
	}

	protected abstract void ValidateValue(object valueToValidate);

	protected abstract object ConvertStringToValue(string value);

	protected abstract string ConvertValueToString(object value);

	protected abstract object GetValueCore();

	protected abstract void SetValueCore(object value);

	public abstract void ClearValue();

	private void SetValueImpl(object value)
	{
		ValidateValue(value);
		SetValueCore(value);
		NotifyValueChanged();
		OnRootValueChanged();
	}

	protected virtual void OnPropertyValueException(PropertyValueExceptionEventArgs e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (this.PropertyValueException != null)
		{
			this.PropertyValueException(this, e);
		}
	}

	protected virtual void NotifyRootValueChanged()
	{
		OnPropertyChanged("IsDefaultValue");
		OnPropertyChanged("IsMixedValue");
		OnPropertyChanged("IsCollection");
		OnPropertyChanged("Collection");
		OnPropertyChanged("HasSubProperties");
		OnPropertyChanged("SubProperties");
		OnPropertyChanged("Source");
		OnPropertyChanged("CanConvertFromString");
		NotifyValueChanged();
		OnRootValueChanged();
	}

	protected void NotifySubPropertyChanged()
	{
		NotifyValueChanged();
		OnSubPropertyChanged();
	}

	private void NotifyValueChanged()
	{
		OnPropertyChanged("Value");
		NotifyStringValueChanged();
	}

	private void NotifyStringValueChanged()
	{
		OnPropertyChanged("StringValue");
	}

	private void OnRootValueChanged()
	{
		if (this.RootValueChanged != null)
		{
			this.RootValueChanged(this, EventArgs.Empty);
		}
	}

	private void OnSubPropertyChanged()
	{
		if (this.SubPropertyChanged != null)
		{
			this.SubPropertyChanged(this, EventArgs.Empty);
		}
	}

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}
	}
}
