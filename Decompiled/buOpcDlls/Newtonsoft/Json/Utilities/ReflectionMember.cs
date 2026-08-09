using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class ReflectionMember
{
	public Type MemberType { get; set; }

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	[field: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	public Func<object, object> Getter
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
		get;
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
		set;
	}

	[Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	[field: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
	public Action<object, object> Setter
	{
		[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
		get;
		[param: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 1, 2 })]
		set;
	}
}
