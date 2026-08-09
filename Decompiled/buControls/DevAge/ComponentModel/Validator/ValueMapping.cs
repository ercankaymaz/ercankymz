using System;
using System.Collections;

namespace DevAge.ComponentModel.Validator;

public class ValueMapping
{
	private IList ilist_0;

	private Type type_0 = typeof(string);

	private IList ilist_1;

	private IList ilist_2;

	private bool bool_0 = true;

	public IList ValueList
	{
		get
		{
			return ilist_0;
		}
		set
		{
			ilist_0 = value;
		}
	}

	public IList SpecialList
	{
		get
		{
			return ilist_1;
		}
		set
		{
			ilist_1 = value;
		}
	}

	public Type SpecialType
	{
		get
		{
			return type_0;
		}
		set
		{
			type_0 = value;
		}
	}

	public IList DisplayStringList
	{
		get
		{
			return ilist_2;
		}
		set
		{
			ilist_2 = value;
		}
	}

	public bool ThrowErrorIfNotFound
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public ValueMapping()
	{
	}

	public ValueMapping(IValidator validator, IList valueList, IList displayStringList, IList specialList, Type specialType)
	{
		ValueList = valueList;
		DisplayStringList = displayStringList;
		SpecialList = specialList;
		if (validator != null)
		{
			BindValidator(validator);
		}
	}

	public void BindValidator(IValidator p_Validator)
	{
		p_Validator.ConvertingValueToDisplayString += method_0;
		p_Validator.ConvertingObjectToValue += method_1;
		p_Validator.ConvertingValueToObject += method_2;
	}

	public void UnBindValidator(IValidator p_Validator)
	{
		p_Validator.ConvertingValueToDisplayString -= method_0;
		p_Validator.ConvertingObjectToValue -= method_1;
		p_Validator.ConvertingValueToObject -= method_2;
	}

	private void method_0(object sender, ConvertingObjectEventArgs e)
	{
		if (ilist_2 == null)
		{
			return;
		}
		if (ilist_0 != null)
		{
			int num = ilist_0.IndexOf(e.Value);
			if (num < 0)
			{
				if (bool_0)
				{
					e.ConvertingStatus = ConvertingStatus.Error;
				}
			}
			else
			{
				e.Value = ilist_2[num];
				e.ConvertingStatus = ConvertingStatus.Completed;
			}
			return;
		}
		throw new ApplicationException("ValueList cannot be null");
	}

	private void method_1(object sender, ConvertingObjectEventArgs e)
	{
		if (ilist_1 == null || e.Value == null || !(e.Value.GetType() == SpecialType))
		{
			return;
		}
		if (ilist_0 != null)
		{
			int num = ilist_0.IndexOf(e.Value);
			if (num < 0)
			{
				num = ilist_1.IndexOf(e.Value);
				if (num < 0)
				{
					if (bool_0)
					{
						e.ConvertingStatus = ConvertingStatus.Error;
					}
				}
				else
				{
					e.Value = ilist_0[num];
					e.ConvertingStatus = ConvertingStatus.Completed;
				}
			}
			else
			{
				e.Value = ilist_0[num];
				e.ConvertingStatus = ConvertingStatus.Completed;
			}
			return;
		}
		throw new ApplicationException("ValueList cannot be null");
	}

	private void method_2(object sender, ConvertingObjectEventArgs e)
	{
		if (ilist_1 == null || !(e.DestinationType == SpecialType))
		{
			return;
		}
		if (ilist_0 != null)
		{
			int num = ilist_0.IndexOf(e.Value);
			if (num < 0)
			{
				if (bool_0)
				{
					e.ConvertingStatus = ConvertingStatus.Error;
				}
			}
			else
			{
				e.Value = ilist_1[num];
				e.ConvertingStatus = ConvertingStatus.Completed;
			}
			return;
		}
		throw new ApplicationException("ValueList cannot be null");
	}
}
