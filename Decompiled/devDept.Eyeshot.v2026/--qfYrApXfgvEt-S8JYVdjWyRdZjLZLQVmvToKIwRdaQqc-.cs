using System;
using System.Reflection;
using System.Runtime.CompilerServices;

internal sealed class _0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D : _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D
{
	private object _0023_003DziDLVpbY_003D;

	public _0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D(object _0023_003DziDLVpbY_003D)
		: base(25)
	{
		if (_0023_003DziDLVpbY_003D != null && !(_0023_003DziDLVpbY_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
	}

	public object _0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8()
	{
		return _0023_003DziDLVpbY_003D;
	}

	public void _0023_003Dz0EOChGPSrQVmr6ekU0FJFc0_003D(object _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D != null && !(_0023_003DziDLVpbY_003D is ValueType))
		{
			throw new ArgumentException();
		}
		this._0023_003DziDLVpbY_003D = _0023_003DziDLVpbY_003D;
	}

	[SpecialName]
	public override object _0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D()
	{
		return _0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8();
	}

	[SpecialName]
	public override void _0023_003Dzfsh7cMqdAFNS_00248RwnR8_1zXr2ps86Z24aphoSJytHiBZNZ9a7sN31tjwDTy9Bh9DbL0lataI5YTp0c4gcINa8Ms_003D(object _0023_003DziDLVpbY_003D)
	{
		_0023_003Dz0EOChGPSrQVmr6ekU0FJFc0_003D(_0023_003DziDLVpbY_003D);
	}

	private static bool _0023_003DzAsjo2XRKpqDFnE9HPpUtEjMIRhc4(Type _0023_003DziDLVpbY_003D)
	{
		if (_0023_003DziDLVpbY_003D.IsGenericType && _0023_003DziDLVpbY_003D.Namespace == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910327))
		{
			string name = _0023_003DziDLVpbY_003D.Name;
			if (name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910310) || name == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302910289))
			{
				return false;
			}
		}
		return true;
	}

	public override _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dzxd4eGJp9V4yZdeXieQIAqTZ5y4gRve50VSTPXAEO4vHlWc8tywYQVil_AqTg6TA90ZwA8Az16KNFHv_RIA_003D_003D(_0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003DziDLVpbY_003D)
	{
		_0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003DziDLVpbY_003D._0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
		switch (_0023_003DziDLVpbY_003D._0023_003Dz0HXdV9xQkvBthq_IqcWq1ADrgRdwFJvDPvxpZ1A_003D())
		{
		case 25:
		{
			object obj = ((_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D)_0023_003DziDLVpbY_003D)._0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8();
			object obj2 = _0023_003DzHAnywLNcTsWPY7155LurFcQcmnn8();
			if (obj2 != null && obj != null)
			{
				Type type = obj2.GetType();
				if (!type.IsPrimitive && !type.IsEnum && type == obj.GetType() && _0023_003DzAsjo2XRKpqDFnE9HPpUtEjMIRhc4(type))
				{
					FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						fieldInfo.SetValue(obj2, fieldInfo.GetValue(obj));
					}
					break;
				}
			}
			_0023_003Dz0EOChGPSrQVmr6ekU0FJFc0_003D(obj);
			break;
		}
		case 7:
			_0023_003Dz0EOChGPSrQVmr6ekU0FJFc0_003D(((_0023_003Dq0So1GxeA2gcAh9TgG0D5iRI9OKwQAWCLDXh4ko_00244EGw_003D)_0023_003DziDLVpbY_003D)._0023_003DzP7k5Y6ukvcg_ixjUAKpLm2Y7IkNc3hTJEKeYFNObePLS());
			break;
		default:
			_0023_003Dz0EOChGPSrQVmr6ekU0FJFc0_003D(_0023_003DziDLVpbY_003D._0023_003DzPpQkXi3mYRMQ1OtV8Uh24FoPoIrD3_Prv0Pu7yud5Jxd0sod8v261zCSe96wBT7FEcCQerk_003D());
			break;
		}
		return this;
	}

	public override _0023_003DqloSXa2Me_ygEi7N_0024ole3utVi7x8xutBWlunyYuRYB8s_003D _0023_003Dz5lslr6cY84EhmY4zXHchiRWu3kQNhqjmGcu8SDdt4PC3hOVR_dhU_0024Xh6CjBfnPFf6PSrQ7YCFTCw()
	{
		_0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D obj = new _0023_003DqfYrApXfgvEt_0024S8JYVdjWyRdZjLZLQVmvToKIwRdaQqc_003D(_0023_003DziDLVpbY_003D);
		obj._0023_003Dz2L512gC_8rlusWuH8S7cS8cXbKlt(_0023_003Dzq97SJVSI1kgEwtVzsNWxAJc_003D());
		return obj;
	}
}
