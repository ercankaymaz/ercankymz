using System;
using System.Diagnostics;
using System.Reflection;

namespace Xbim.Common.Metadata;

[DebuggerDisplay("Name = {Name}, Type = {PropertyInfo.PropertyType.Name}")]
public class ExpressMetaProperty
{
	public PropertyInfo PropertyInfo { get; internal set; }

	public EntityAttributeAttribute EntityAttribute { get; internal set; }

	public InverseProperty InverseAttributeProperty { get; internal set; }

	public Type EnumerableType { get; internal set; }

	public string Name => PropertyInfo.Name;

	public bool IsInverse => EntityAttribute.Order < 0;

	public bool IsDerived => EntityAttribute.State == EntityAttributeState.Derived;

	public bool IsExplicit => EntityAttribute.Order > 0;

	public bool IsIndexed { get; internal set; }
}
