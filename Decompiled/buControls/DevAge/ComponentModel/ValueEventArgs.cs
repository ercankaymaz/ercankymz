using System;

namespace DevAge.ComponentModel;

public class ValueEventArgs : EventArgs
{
	private object p_Value;

	public object Value
	{
		get
		{
			return p_Value;
		}
		set
		{
			p_Value = value;
		}
	}

	public ValueEventArgs(object p_Value)
	{
		this.p_Value = p_Value;
	}
}
