using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Utilities;

internal static class ValidationUtils
{
	[Newtonsoft_002EJson_002ENullableContext(1)]
	public static void ArgumentNotNull([Newtonsoft_002EJson_002ENullable(2)][Newtonsoft_002EJson1494283_002ENotNull] object value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}
}
