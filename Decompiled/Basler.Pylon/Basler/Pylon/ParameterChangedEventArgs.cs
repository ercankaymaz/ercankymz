using System;

namespace Basler.Pylon;

public class ParameterChangedEventArgs(IParameter parameter) : EventArgs
{
	private IParameter m_parameter = parameter;

	public IParameter Parameter => m_parameter;
}
