using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace ACadSharp;

internal class PropertyExpression<TClass, TAttribute> where TClass : class where TAttribute : Attribute
{
	public class Prop
	{
		public Func<TClass, object> Getter { get; internal set; }

		public Action<TClass, object> Setter { get; internal set; }

		public TAttribute Attribute { get; internal set; }

		public PropertyInfo Property { get; internal set; }
	}

	private static readonly ConcurrentDictionary<string, Prop> _cache = new ConcurrentDictionary<string, Prop>();

	public IReadOnlyDictionary<string, Prop> Cache = _cache;

	public PropertyExpression(Func<PropertyInfo, TAttribute, string> keySelector)
	{
		PropertyInfo[] properties = typeof(TClass).GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			TAttribute customAttribute = propertyInfo.GetCustomAttribute<TAttribute>();
			if (customAttribute != null)
			{
				Type declaringType = propertyInfo.DeclaringType;
				Type propertyType = propertyInfo.PropertyType;
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TClass));
				Func<TClass, object> getter = null;
				MethodInfo getMethod = propertyInfo.GetGetMethod(nonPublic: true);
				if (getMethod != null)
				{
					getter = Expression.Lambda<Func<TClass, object>>(Expression.Convert(Expression.Call(Expression.Convert(parameterExpression, declaringType), getMethod), typeof(object)), new ParameterExpression[1] { parameterExpression }).Compile();
				}
				Action<TClass, object> setter = null;
				MethodInfo setMethod = propertyInfo.GetSetMethod(nonPublic: true);
				if (setMethod != null)
				{
					ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object));
					setter = Expression.Lambda<Action<TClass, object>>(Expression.Call(Expression.Convert(parameterExpression, declaringType), setMethod, Expression.Convert(parameterExpression2, propertyType)), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
				}
				_cache.TryAdd(keySelector(propertyInfo, customAttribute), new Prop
				{
					Getter = getter,
					Setter = setter,
					Attribute = customAttribute,
					Property = propertyInfo
				});
			}
		}
	}

	public Prop GetProperty(string propName)
	{
		return _cache[propName];
	}
}
