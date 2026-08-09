using System.Dynamic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class NoThrowGetBinderMember : GetMemberBinder
{
	private readonly GetMemberBinder _innerBinder;

	public NoThrowGetBinderMember(GetMemberBinder innerBinder)
		: base(innerBinder.Name, innerBinder.IgnoreCase)
	{
		_innerBinder = innerBinder;
	}

	public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, [Newtonsoft_002EJson_002ENullable(2)] DynamicMetaObject errorSuggestion)
	{
		DynamicMetaObject dynamicMetaObject = _innerBinder.Bind(target, CollectionUtils.ArrayEmpty<DynamicMetaObject>());
		return new DynamicMetaObject(new NoThrowExpressionVisitor().Visit(dynamicMetaObject.Expression), dynamicMetaObject.Restrictions);
	}
}
