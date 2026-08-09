using System;
using System.Globalization;
using DevAge.ComponentModel.Validator;

namespace DevAge.Configuration;

public class PersistableItem
{
	private IValidator ivalidator_0;

	private Type pType;

	private string pName;

	private object pDefaultValue;

	private object pDefaultValue;

	public IValidator Validator => ivalidator_0;

	public Type Type => pType;

	public string Name => pName;

	public object Value
	{
		get
		{
			return this.pDefaultValue;
		}
		set
		{
			this.pDefaultValue = value;
		}
	}

	public object DefaultValue
	{
		get
		{
			return pDefaultValue;
		}
		set
		{
			pDefaultValue = value;
		}
	}

	public bool IsChanged
	{
		get
		{
			if (this.pDefaultValue != null || pDefaultValue != null)
			{
				if (this.pDefaultValue != null)
				{
					return !this.pDefaultValue.Equals(pDefaultValue);
				}
				return true;
			}
			return false;
		}
	}

	public PersistableItem(Type pType, string pName, object pDefaultValue)
	{
		ivalidator_0 = new ValidatorTypeConverter(pType);
		ivalidator_0.CultureInfo = CultureInfo.InvariantCulture;
		this.pType = pType;
		this.pName = pName;
		this.pDefaultValue = pDefaultValue;
		this.pDefaultValue = pDefaultValue;
	}

	public void AcceptAsDefault()
	{
		pDefaultValue = this.pDefaultValue;
	}

	public void Reset()
	{
		this.pDefaultValue = pDefaultValue;
	}

	public override string ToString()
	{
		return "PersistableItem: " + Name + "=" + Validator.ValueToDisplayString(Value);
	}
}
