using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal sealed class _0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D : _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D
{
	private object _0023_003DzjYYAPCA_003D;

	public _0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D(object _0023_003DzjYYAPCA_003D)
		: base(25)
	{
		if (_0023_003DzjYYAPCA_003D != null && !(_0023_003DzjYYAPCA_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
	}

	public object _0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL()
	{
		return _0023_003DzjYYAPCA_003D;
	}

	public void _0023_003DzXnQWQqDhC8nmTpI3KTHbOpw_003D(object _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D != null && !(_0023_003DzjYYAPCA_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003DzjYYAPCA_003D = _0023_003DzjYYAPCA_003D;
	}

	[SpecialName]
	public override object _0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D()
	{
		return _0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL();
	}

	[SpecialName]
	public override void _0023_003DzJ_00243zxDoz_EC2ZmGwNXvz3C7v3EjPShf7WXfj3bqqUgJuXtVcXDnwxF8xdcUJcRwU58dzdxpX0qKZsv_sB56GJqw_003D(object _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzXnQWQqDhC8nmTpI3KTHbOpw_003D(_0023_003DzjYYAPCA_003D);
	}

	private static bool _0023_003DzOoOwC30ZPA_0024vEKj1Uov6TAKSGfbE(Type _0023_003DzjYYAPCA_003D)
	{
		if (_0023_003DzjYYAPCA_003D.IsGenericType && _0023_003DzjYYAPCA_003D.Namespace == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619539))
		{
			string name = _0023_003DzjYYAPCA_003D.Name;
			if (name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619558) || name == _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348619577))
			{
				return false;
			}
		}
		return true;
	}

	public override _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzUjF1jaxTAlACHZjlKVwb3utxWFbL8UAxj8JMx6v3T3l9JLTXA1zEh6EUkIavn9UCBlmxTfaBYs3QOk5LUA_003D_003D(_0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzjYYAPCA_003D)
	{
		_0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzjYYAPCA_003D._0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
		switch (_0023_003DzjYYAPCA_003D._0023_003Dzctco6_mYmOmM9hglQeieP6_459Anxjl2Iw6XT88_003D())
		{
		case 25:
		{
			object obj = ((_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D)_0023_003DzjYYAPCA_003D)._0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL();
			object obj2 = _0023_003DzLs6Xp1xlLKbW249CpS1HcCadFmqL();
			if (obj2 != null && obj != null)
			{
				Type type = obj2.GetType();
				if (!type.IsPrimitive && !type.IsEnum && type == obj.GetType() && _0023_003DzOoOwC30ZPA_0024vEKj1Uov6TAKSGfbE(type))
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						fieldInfo.SetValue(obj2, fieldInfo.GetValue(obj));
					}
					break;
				}
			}
			_0023_003DzXnQWQqDhC8nmTpI3KTHbOpw_003D(obj);
			break;
		}
		case 7:
			_0023_003DzXnQWQqDhC8nmTpI3KTHbOpw_003D(((_0023_003Dq6tsYctsQQ5GQ6RFr34KBs4oSv0P_sDVUQA7FJCPn3Ss_003D)_0023_003DzjYYAPCA_003D)._0023_003DzbxMVv9p9wKFTXDEHbUUrzRSF_jqdjYqX8REqAOpnd1TT());
			break;
		default:
			_0023_003DzXnQWQqDhC8nmTpI3KTHbOpw_003D(_0023_003DzjYYAPCA_003D._0023_003DzXg_Lbyrw65cVX0HzE9VkI6AiDu8WxwNkZaGD4Htr_JbGxzCxas81xOSoCpsrrbQKTX67X6I_003D());
			break;
		}
		return this;
	}

	public override _0023_003DqU1aZsgTLvcHpfSUL_IyTN_EMrDMYVEhGMM1zxXNPhxk_003D _0023_003DzmoCa7lXUL7yvAaxU1Zbpx5T8XWXmYhrCsBrXsJwFxW7A2fsxJ1WfvAJMxdHd5pFpu_0024_0024m9jzUqDJr()
	{
		_0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D obj = new _0023_003Dq9o_OPfa_DuRpdjQlVA0ailX6N2r287AneVNcwCigij0_003D(_0023_003DzjYYAPCA_003D);
		obj._0023_003DzbbM1fqPboxBa8WM3KUGc4WZTjETi(_0023_003DzyysRbVXbLQkpMJEi9ewlNFA_003D());
		return obj;
	}
}
