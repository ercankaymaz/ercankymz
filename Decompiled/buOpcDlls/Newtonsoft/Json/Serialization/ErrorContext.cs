using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class ErrorContext
{
	internal bool Traced { get; set; }

	public Exception Error { get; }

	[Newtonsoft_002EJson_002ENullable(2)]
	[field: Newtonsoft_002EJson_002ENullable(2)]
	public object OriginalObject
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	[Newtonsoft_002EJson_002ENullable(2)]
	[field: Newtonsoft_002EJson_002ENullable(2)]
	public object Member
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	public string Path { get; }

	public bool Handled { get; set; }

	internal ErrorContext([Newtonsoft_002EJson_002ENullable(2)] object originalObject, [Newtonsoft_002EJson_002ENullable(2)] object member, string path, Exception error)
	{
		OriginalObject = originalObject;
		Member = member;
		Error = error;
		Path = path;
	}
}
