using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace DevAge.ComponentModel.Validator;

[ToolboxItem(false)]
public class ValidatorBase : ComponentLight, IValidator
{
	private bool bool_0;

	private string string_0;

	private string string_1;

	private bool bool_1 = true;

	private ConvertingObjectEventHandler convertingObjectEventHandler_0;

	private ConvertingObjectEventHandler convertingObjectEventHandler_1;

	private ConvertingObjectEventHandler convertingObjectEventHandler_2;

	private object object_0 = null;

	private object object_1 = null;

	private Type type_0;

	private object object_2;

	private ICollection icollection_0;

	private bool bool_2;

	private CultureInfo cultureInfo_0 = null;

	private EventHandler eventHandler_0;

	[DefaultValue(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AllowNull
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue("")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string NullString
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				string_0 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue("")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string NullDisplayString
	{
		get
		{
			return string_1;
		}
		set
		{
			if (string_1 != value)
			{
				string_1 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool AllowStringConversion
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object MinimumValue
	{
		get
		{
			return object_0;
		}
		set
		{
			if (object_0 != value)
			{
				object_0 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object MaximumValue
	{
		get
		{
			return object_1;
		}
		set
		{
			if (object_1 != value)
			{
				object_1 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Type ValueType
	{
		get
		{
			return type_0;
		}
		set
		{
			if (type_0 != value)
			{
				type_0 = value;
				OnLoadingValueType();
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue("")]
	[Browsable(true)]
	public string ValueTypeName
	{
		get
		{
			if (!(ValueType == null))
			{
				return ValueType.AssemblyQualifiedName;
			}
			return string.Empty;
		}
		set
		{
			if (value != null && value.Trim().Length != 0)
			{
				ValueType = Type.GetType(value, throwOnError: true, ignoreCase: true);
			}
			else
			{
				ValueType = null;
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public object DefaultValue
	{
		get
		{
			return object_2;
		}
		set
		{
			if (object_2 != value)
			{
				object_2 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ICollection StandardValues
	{
		get
		{
			return icollection_0;
		}
		set
		{
			if (icollection_0 != value)
			{
				icollection_0 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool StandardValuesExclusive
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public CultureInfo CultureInfo
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			if (cultureInfo_0 != value)
			{
				cultureInfo_0 = value;
				OnChanged(EventArgs.Empty);
			}
		}
	}

	public event ConvertingObjectEventHandler ConvertingObjectToValue
	{
		add
		{
			convertingObjectEventHandler_0 = (ConvertingObjectEventHandler)Delegate.Combine(convertingObjectEventHandler_0, value);
		}
		remove
		{
			convertingObjectEventHandler_0 = (ConvertingObjectEventHandler)Delegate.Remove(convertingObjectEventHandler_0, value);
		}
	}

	public event ConvertingObjectEventHandler ConvertingValueToObject
	{
		add
		{
			convertingObjectEventHandler_1 = (ConvertingObjectEventHandler)Delegate.Combine(convertingObjectEventHandler_1, value);
		}
		remove
		{
			convertingObjectEventHandler_1 = (ConvertingObjectEventHandler)Delegate.Remove(convertingObjectEventHandler_1, value);
		}
	}

	public event ConvertingObjectEventHandler ConvertingValueToDisplayString
	{
		add
		{
			convertingObjectEventHandler_2 = (ConvertingObjectEventHandler)Delegate.Combine(convertingObjectEventHandler_2, value);
		}
		remove
		{
			convertingObjectEventHandler_2 = (ConvertingObjectEventHandler)Delegate.Remove(convertingObjectEventHandler_2, value);
		}
	}

	public event EventHandler Changed
	{
		add
		{
			eventHandler_0 = (EventHandler)Delegate.Combine(eventHandler_0, value);
		}
		remove
		{
			eventHandler_0 = (EventHandler)Delegate.Remove(eventHandler_0, value);
		}
	}

	public ValidatorBase()
	{
		ValueType = null;
	}

	public ValidatorBase(Type type)
	{
		ValueType = type;
	}

	protected virtual void OnLoadingValueType()
	{
		if (!(ValueType != null))
		{
			bool_0 = true;
			object_2 = null;
			icollection_0 = null;
			bool_2 = false;
			object_1 = null;
			object_0 = null;
			string_0 = "";
			string_1 = "";
			return;
		}
		if (!ValueType.IsValueType)
		{
			object_2 = null;
			bool_0 = true;
		}
		else
		{
			bool_0 = false;
			if (!ValueType.IsEnum)
			{
				object_2 = Activator.CreateInstance(ValueType);
			}
			else
			{
				FieldInfo[] fields = ValueType.GetFields(BindingFlags.Static | BindingFlags.Public);
				object_2 = fields[0].GetValue(null);
			}
		}
		icollection_0 = null;
		bool_2 = false;
		object_1 = null;
		object_0 = null;
		string_0 = "";
		string_1 = "";
	}

	public virtual bool IsNullString(string p_str)
	{
		return p_str == null || p_str == string_0;
	}

	public virtual string ObjectToStringForError(object val)
	{
		try
		{
			if (val != null)
			{
				return val.ToString();
			}
			return "<null>";
		}
		catch (Exception)
		{
			return "<object>";
		}
	}

	public object ObjectToValue(object p_Object)
	{
		Type type = ValueType;
		if (type == null && p_Object != null)
		{
			type = p_Object.GetType();
		}
		ConvertingObjectEventArgs e = new ConvertingObjectEventArgs(p_Object, type);
		OnConvertingObjectToValue(e);
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (!IsValidValue(e.Value))
			{
				throw new ConversionErrorException(ValueTypeName, ObjectToStringForError(e.Value));
			}
			return e.Value;
		}
		throw new ConversionErrorException(ValueTypeName, ObjectToStringForError(e.Value));
	}

	public object ValueToObject(object p_Value, Type p_ReturnObjectType)
	{
		if (!(p_ReturnObjectType == null))
		{
			ConvertingObjectEventArgs e = new ConvertingObjectEventArgs(p_Value, p_ReturnObjectType);
			OnConvertingValueToObject(e);
			if (e.ConvertingStatus != ConvertingStatus.Error)
			{
				if (e.Value != null)
				{
					if (!e.DestinationType.IsAssignableFrom(e.Value.GetType()))
					{
						throw new ConversionErrorException(p_ReturnObjectType.Name, ObjectToStringForError(e.Value));
					}
					return e.Value;
				}
				return null;
			}
			throw new ConversionErrorException(p_ReturnObjectType.Name, ObjectToStringForError(e.Value));
		}
		throw new DevAgeApplicationException("Invalid parameter returnObjectType cannot be null");
	}

	public string ValueToString(object p_Value)
	{
		object obj = ValueToObject(p_Value, typeof(string));
		if (obj != null)
		{
			return (string)obj;
		}
		return null;
	}

	public object StringToValue(string p_str)
	{
		return ObjectToValue(p_str);
	}

	public virtual bool IsStringConversionSupported()
	{
		return (AllowStringConversion && typeof(string) == ValueType) || ValueType == null;
	}

	public virtual string ValueToDisplayString(object p_Value)
	{
		ConvertingObjectEventArgs e = new ConvertingObjectEventArgs(p_Value, typeof(string));
		OnConvertingValueToDisplayString(e);
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.Value != null)
			{
				if (!(e.Value is string))
				{
					throw new ConversionErrorException("display String", ObjectToStringForError(e.Value));
				}
				return (string)e.Value;
			}
			return NullDisplayString;
		}
		throw new ConversionErrorException("display String", ObjectToStringForError(e.Value));
	}

	protected virtual void OnConvertingObjectToValue(ConvertingObjectEventArgs e)
	{
		if (convertingObjectEventHandler_0 != null)
		{
			convertingObjectEventHandler_0(this, e);
		}
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.ConvertingStatus != ConvertingStatus.Completed && e.Value is string)
			{
				string p_str = (string)e.Value;
				if (IsNullString(p_str))
				{
					e.Value = null;
				}
			}
			return;
		}
		throw new ConversionErrorException(e.DestinationType.Name, ObjectToStringForError(e.Value));
	}

	protected virtual void OnConvertingValueToObject(ConvertingObjectEventArgs e)
	{
		if (convertingObjectEventHandler_1 != null)
		{
			convertingObjectEventHandler_1(this, e);
		}
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.ConvertingStatus != ConvertingStatus.Completed)
			{
			}
			return;
		}
		throw new ConversionErrorException(e.DestinationType.Name, ObjectToStringForError(e.Value));
	}

	protected virtual void OnConvertingValueToDisplayString(ConvertingObjectEventArgs e)
	{
		if (convertingObjectEventHandler_2 != null)
		{
			convertingObjectEventHandler_2(this, e);
		}
		if (e.ConvertingStatus != ConvertingStatus.Error)
		{
			if (e.ConvertingStatus == ConvertingStatus.Completed)
			{
				return;
			}
			if (e.Value != null)
			{
				if (!IsStringConversionSupported())
				{
					e.Value = e.Value.ToString();
				}
				else
				{
					e.Value = ValueToString(e.Value);
				}
			}
			else
			{
				e.Value = NullDisplayString;
			}
			return;
		}
		throw new ConversionErrorException("display String", ObjectToStringForError(e.Value));
	}

	public bool IsValidValue(object p_Value)
	{
		try
		{
			if (!IsInStandardValues(p_Value))
			{
				if (p_Value != null)
				{
					if (!bool_2)
					{
						if (object_1 != null)
						{
							IComparable comparable = (IComparable)object_1;
							if (comparable.CompareTo(p_Value) < 0)
							{
								return false;
							}
						}
						if (object_0 != null)
						{
							IComparable comparable2 = (IComparable)object_0;
							if (comparable2.CompareTo(p_Value) > 0)
							{
								return false;
							}
						}
						if (!(ValueType != null))
						{
							return true;
						}
						return ValueType.IsAssignableFrom(p_Value.GetType());
					}
					return false;
				}
				if (!AllowNull)
				{
					return false;
				}
				return true;
			}
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool IsValidObject(object p_Object)
	{
		object p_ValueConverted;
		return IsValidObject(p_Object, out p_ValueConverted);
	}

	public bool IsValidObject(object p_Object, out object p_ValueConverted)
	{
		p_ValueConverted = null;
		try
		{
			p_ValueConverted = ObjectToValue(p_Object);
			return IsValidValue(p_ValueConverted);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public bool IsValidString(string p_strValue)
	{
		object p_ValueConverted;
		return IsValidString(p_strValue, out p_ValueConverted);
	}

	public bool IsValidString(string p_strValue, out object p_ValueConverted)
	{
		return IsValidObject(p_strValue, out p_ValueConverted);
	}

	public virtual bool IsInStandardValues(object p_Value)
	{
		if (icollection_0 != null)
		{
			foreach (object item in icollection_0)
			{
				if ((item == null && p_Value == null) || (item != null && item.Equals(p_Value)))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	public virtual object StandardValueAtIndex(int p_Index)
	{
		if (icollection_0 != null)
		{
			if (!(icollection_0 is IList list))
			{
				int num = 0;
				foreach (object item in icollection_0)
				{
					if (num != p_Index)
					{
						num++;
						continue;
					}
					return item;
				}
				throw new DevAgeApplicationException("Invalid Index");
			}
			return list[p_Index];
		}
		throw new DevAgeApplicationException("StandardValues is null");
	}

	public virtual int StandardValuesIndexOf(object p_StandardValue)
	{
		if (icollection_0 != null)
		{
			if (!(icollection_0 is IList list))
			{
				int num = 0;
				foreach (object item in icollection_0)
				{
					if (item != null || p_StandardValue != null)
					{
						if (item == null || !item.Equals(p_StandardValue))
						{
							num++;
							continue;
						}
						return num;
					}
					return num;
				}
				return -1;
			}
			return list.IndexOf(p_StandardValue);
		}
		throw new DevAgeApplicationException("StandardValues is null");
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected virtual void OnChanged(EventArgs e)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, e);
		}
	}
}
