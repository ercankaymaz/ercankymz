using System;

namespace Basler.Pylon;

public class ParameterValueChangedEventArgs(IParameter parameter, object oldValue, object newValue) : EventArgs
{
	private IParameter m_parameter = parameter;

	private object m_previousValue = oldValue;

	private object m_currentValue = newValue;

	public object CurrentValue => m_currentValue;

	public object PreviousValue => m_previousValue;

	public IParameter Parameter => m_parameter;
}
