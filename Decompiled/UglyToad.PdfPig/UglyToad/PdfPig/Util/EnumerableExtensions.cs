using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace UglyToad.PdfPig.Util;

internal static class EnumerableExtensions
{
	public static List<T> ToRecursiveOrderList<T>(this IEnumerable<T> collection, Expression<Func<T, IEnumerable<T>>> childCollection)
	{
		List<T> list = new List<T>();
		Queue<(int, T, int)> queue = new Queue<(int, T, int)>(collection.Select<T, (int, T, int)>((T i) => (0, i: i, 0)));
		int num = 0;
		int num2 = 0;
		PropertyInfo propertyInfo = (PropertyInfo)((MemberExpression)childCollection.Body).Member;
		while (queue.Count > 0)
		{
			(int, T, int) tuple = queue.Dequeue();
			if (tuple.Item3 != num2)
			{
				num = 0;
			}
			int num3 = tuple.Item1 + num++;
			list.Insert(num3, tuple.Item2);
			foreach (T item in (propertyInfo.GetValue(tuple.Item2) as IEnumerable<T>) ?? Enumerable.Empty<T>())
			{
				queue.Enqueue((num3 + 1, item, tuple.Item3 + 1));
			}
			num2 = tuple.Item3;
		}
		return list;
	}
}
