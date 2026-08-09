using System;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[Newtonsoft_002EJson_002ENullableContext(1)]
[Newtonsoft_002EJson_002ENullable(0)]
public class ErrorEventArgs : EventArgs
{
	[Newtonsoft_002EJson_002ENullable(2)]
	[field: Newtonsoft_002EJson_002ENullable(2)]
	public object CurrentObject
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	public ErrorContext ErrorContext { get; }

	public ErrorEventArgs([Newtonsoft_002EJson_002ENullable(2)] object currentObject, ErrorContext errorContext)
	{
		CurrentObject = currentObject;
		ErrorContext = errorContext;
	}
}
