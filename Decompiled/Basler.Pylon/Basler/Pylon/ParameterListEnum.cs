using System.ComponentModel;

namespace Basler.Pylon;

[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class ParameterListEnum
{
	public abstract string Name { get; }

	public ParameterListEnum()
	{
	}
}
