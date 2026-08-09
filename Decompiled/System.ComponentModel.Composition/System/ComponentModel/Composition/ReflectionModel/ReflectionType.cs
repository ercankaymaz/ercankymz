using System.Reflection;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ReflectionType : ReflectionMember
{
	private readonly Type _type;

	public override MemberInfo UnderlyingMember => _type;

	public override bool CanRead => true;

	public override bool RequiresInstance => true;

	public override Type ReturnType => _type;

	public override ReflectionItemType ItemType => ReflectionItemType.Type;

	public ReflectionType(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		_type = type;
	}

	public override object? GetValue(object? instance)
	{
		return instance;
	}
}
