using System;

namespace DevAge.ComponentModel;

public class ConvertingObjectEventArgs : EventArgs
{
	private object p_Value;

	private Type p_DestinationType;

	private ConvertingStatus convertingStatus_0 = ConvertingStatus.Converting;

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

	public Type DestinationType => p_DestinationType;

	public ConvertingStatus ConvertingStatus
	{
		get
		{
			return convertingStatus_0;
		}
		set
		{
			convertingStatus_0 = value;
		}
	}

	public ConvertingObjectEventArgs(object p_Value, Type p_DestinationType)
	{
		this.p_Value = p_Value;
		this.p_DestinationType = p_DestinationType;
	}
}
