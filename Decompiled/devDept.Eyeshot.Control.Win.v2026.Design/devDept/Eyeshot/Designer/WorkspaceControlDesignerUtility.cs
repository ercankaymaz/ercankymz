using System;
using System.Linq.Expressions;

namespace devDept.Eyeshot.Designer;

public static class WorkspaceControlDesignerUtility
{
	internal static class _0023_003DzCdDK1Do_003D
	{
		public static string _0023_003DzCNx7EidbRt4k<T>(Expression<Func<T, object>> _0023_003DzFN1WyQ4_003D)
		{
			Expression body = _0023_003DzFN1WyQ4_003D.Body;
			MemberExpression memberExpression = body as MemberExpression;
			if (memberExpression == null)
			{
				memberExpression = (MemberExpression)((UnaryExpression)body).Operand;
			}
			return memberExpression.Member.Name;
		}
	}

	static WorkspaceControlDesignerUtility()
	{
		_0023_003DzYCt3xEKUMLruzQX2jw_003D_003D._0023_003Dz2uVOeAo_003D _0023_003Dz2uVOeAo_003D = (_0023_003DzYCt3xEKUMLruzQX2jw_003D_003D._0023_003Dz2uVOeAo_003D)2;
		object[] array = null;
		array = new object[1] { _0023_003Dz2uVOeAo_003D };
		_0023_003DzyJ6bZ0KU0sX145lvozfAqtngn5gTWHOouXM9_nezjEkpjye46g_003D_003D._0023_003Dz3H38pqy4jEQgzoE7QiWA1O_0024IfM7UiTjmIwRC_0024eBR0VJdD8ZIsA_003D_003D()._0023_003Dzrt3xIajy0T6pgx6H6j8jQiFKktCE(_0023_003DzyJ6bZ0KU0sX145lvozfAqtngn5gTWHOouXM9_nezjEkpjye46g_003D_003D._0023_003Dz1SbCYz9RTf2u6h_00246nsdbsZ6RKLFx890va9Bp3yWNTSgYsbKxIA_003D_003D(), "CAn/3q\"ad<", array);
	}
}
