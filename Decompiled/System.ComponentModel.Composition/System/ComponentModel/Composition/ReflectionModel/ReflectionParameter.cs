using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ReflectionParameter : ReflectionItem
{
	private readonly ParameterInfo _parameter;

	public ParameterInfo UnderlyingParameter => _parameter;

	public override string? Name => UnderlyingParameter.Name;

	public override Type ReturnType => UnderlyingParameter.ParameterType;

	public override ReflectionItemType ItemType => ReflectionItemType.Parameter;

	public ReflectionParameter(ParameterInfo parameter)
	{
		ArgumentNullException.ThrowIfNull(parameter, "parameter");
		_parameter = parameter;
	}

	public override string GetDisplayName()
	{
		return UnderlyingParameter.Member.GetDisplayName() + " (Parameter=\"" + UnderlyingParameter.Name + "\")";
	}
}
