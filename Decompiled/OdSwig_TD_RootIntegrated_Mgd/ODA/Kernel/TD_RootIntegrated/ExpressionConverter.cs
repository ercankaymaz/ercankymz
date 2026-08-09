using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ODA.Kernel.TD_RootIntegrated;

internal static class ExpressionConverter
{
	private static Dictionary<Type, Func<object, object>> _conversionFuncs = new Dictionary<Type, Func<object, object>>();

	private static object _lock = new object();

	public static object CastToExpr(this object o, Type type)
	{
		return GetExpr(type)(o);
	}

	private static Func<object, object> GetExpr(Type type)
	{
		Func<object, object> value;
		lock (_lock)
		{
			if (!_conversionFuncs.TryGetValue(type, out value))
			{
				value = GenerateExpr(type);
				_conversionFuncs.Add(type, value);
			}
		}
		return value;
	}

	private static Func<object, object> GenerateExpr(Type type)
	{
		ParameterExpression parameterExpression = Expression.Parameter(typeof(object));
		return Expression.Lambda<Func<object, object>>(Expression.Convert(parameterExpression, type), new ParameterExpression[1] { parameterExpression }).Compile();
	}
}
