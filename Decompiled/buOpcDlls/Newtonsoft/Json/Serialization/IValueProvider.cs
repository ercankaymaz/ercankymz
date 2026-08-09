using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
public interface IValueProvider
{
	void SetValue(object target, [Newtonsoft_002EJson_002ENullable(2)] object value);

	[return: Newtonsoft_002EJson_002ENullable(2)]
	object GetValue(object target);
}
