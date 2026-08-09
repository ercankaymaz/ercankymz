using System;

namespace devDept.Geometry.ConstraintSolver;

[Serializable]
internal sealed class ExpVector : ICloneable
{
	public Exp x;

	public Exp y;

	public Exp z;

	public ExpVector(Exp _0023_003DzBJFJHwk_003D, Exp _0023_003Dz40R7bAU_003D, Exp _0023_003DzId5C3LA_003D)
	{
		x = _0023_003DzBJFJHwk_003D;
		y = _0023_003Dz40R7bAU_003D;
		z = _0023_003DzId5C3LA_003D;
	}

	public ExpVector(Vector3D _0023_003DzY5pSLwI_003D)
	{
		x = new Exp(_0023_003DzY5pSLwI_003D.X);
		y = new Exp(_0023_003DzY5pSLwI_003D.Y);
		z = new Exp(_0023_003DzY5pSLwI_003D.Z);
	}

	protected ExpVector(ExpVector _0023_003DzySgeilxprQOK)
	{
		x = (Exp)_0023_003DzySgeilxprQOK.x.Clone();
		y = (Exp)_0023_003DzySgeilxprQOK.y.Clone();
		z = (Exp)_0023_003DzySgeilxprQOK.z.Clone();
	}

	public ExpVector _0023_003DzVvKWaJM_003D()
	{
		return new ExpVector(x._0023_003DzBUjqlpM_003D(), y._0023_003DzBUjqlpM_003D(), z._0023_003DzBUjqlpM_003D());
	}

	public ExpVector _0023_003DzSOlfnhbkZ12J(Param _0023_003DzB68dg9Q_003D)
	{
		return new ExpVector(x._0023_003DzSOlfnhbkZ12J(_0023_003DzB68dg9Q_003D), y._0023_003DzSOlfnhbkZ12J(_0023_003DzB68dg9Q_003D), z._0023_003DzSOlfnhbkZ12J(_0023_003DzB68dg9Q_003D));
	}

	public static implicit operator ExpVector(Vector3D _0023_003Dz77g161c_003D)
	{
		return new ExpVector(_0023_003Dz77g161c_003D.X, _0023_003Dz77g161c_003D.Y, _0023_003Dz77g161c_003D.Z);
	}

	public static ExpVector operator +(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x + _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D.y + _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D.z + _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator -(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x - _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D.y - _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D.z - _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator *(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x * _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D.y * _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D.z * _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator /(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x / _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D.y / _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D.z / _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator -(ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(-_0023_003Dz1v6oPQk_003D.x, -_0023_003Dz1v6oPQk_003D.y, -_0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator *(Exp _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D * _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D * _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D * _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator *(ExpVector _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x * _0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D.y * _0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D.z * _0023_003Dz1v6oPQk_003D);
	}

	public static ExpVector operator /(Exp _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D / _0023_003Dz1v6oPQk_003D.x, _0023_003DzjbqS1qE_003D / _0023_003Dz1v6oPQk_003D.y, _0023_003DzjbqS1qE_003D / _0023_003Dz1v6oPQk_003D.z);
	}

	public static ExpVector operator /(ExpVector _0023_003DzjbqS1qE_003D, Exp _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.x / _0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D.y / _0023_003Dz1v6oPQk_003D, _0023_003DzjbqS1qE_003D.z / _0023_003Dz1v6oPQk_003D);
	}

	public static Exp _0023_003DzBWYOAtM_003D(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return _0023_003DzjbqS1qE_003D.x * _0023_003Dz1v6oPQk_003D.x + _0023_003DzjbqS1qE_003D.y * _0023_003Dz1v6oPQk_003D.y + _0023_003DzjbqS1qE_003D.z * _0023_003Dz1v6oPQk_003D.z;
	}

	public static ExpVector _0023_003DzyJipUOg_003D(ExpVector _0023_003DzjbqS1qE_003D, ExpVector _0023_003Dz1v6oPQk_003D)
	{
		return new ExpVector(_0023_003DzjbqS1qE_003D.y * _0023_003Dz1v6oPQk_003D.z - _0023_003Dz1v6oPQk_003D.y * _0023_003DzjbqS1qE_003D.z, _0023_003DzjbqS1qE_003D.z * _0023_003Dz1v6oPQk_003D.x - _0023_003Dz1v6oPQk_003D.z * _0023_003DzjbqS1qE_003D.x, _0023_003DzjbqS1qE_003D.x * _0023_003Dz1v6oPQk_003D.y - _0023_003Dz1v6oPQk_003D.x * _0023_003DzjbqS1qE_003D.y);
	}

	public static Exp _0023_003DzBXPOPvhM6vc_0024(ExpVector _0023_003DzlY77YgY_003D, ExpVector _0023_003DzEIpBwhg_003D, ExpVector _0023_003DziMjqlCo_003D)
	{
		ExpVector expVector = _0023_003DzEIpBwhg_003D - _0023_003DziMjqlCo_003D;
		return _0023_003DzyJipUOg_003D(expVector, _0023_003DzEIpBwhg_003D - _0023_003DzlY77YgY_003D)._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D() / expVector._0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	public static double _0023_003DzBXPOPvhM6vc_0024(Vector3D _0023_003DzlY77YgY_003D, Vector3D _0023_003DzEIpBwhg_003D, Vector3D _0023_003DziMjqlCo_003D)
	{
		Vector3D vector3D = _0023_003DzEIpBwhg_003D - _0023_003DziMjqlCo_003D;
		return Vector3D.Cross(vector3D, _0023_003DzEIpBwhg_003D - _0023_003DzlY77YgY_003D).Length / vector3D.Length;
	}

	public static ExpVector _0023_003DznYxWvL7b9wGF(ExpVector _0023_003DzB68dg9Q_003D, ExpVector _0023_003DzEIpBwhg_003D, ExpVector _0023_003DziMjqlCo_003D)
	{
		ExpVector expVector = _0023_003DziMjqlCo_003D - _0023_003DzEIpBwhg_003D;
		Exp exp = _0023_003DzBWYOAtM_003D(expVector, _0023_003DzB68dg9Q_003D - _0023_003DzEIpBwhg_003D) / _0023_003DzBWYOAtM_003D(expVector, expVector);
		return _0023_003DzEIpBwhg_003D + expVector * exp;
	}

	public static Vector3D _0023_003DznYxWvL7b9wGF(Vector3D _0023_003DzB68dg9Q_003D, Vector3D _0023_003DzEIpBwhg_003D, Vector3D _0023_003DziMjqlCo_003D)
	{
		Vector3D vector3D = _0023_003DziMjqlCo_003D - _0023_003DzEIpBwhg_003D;
		double num = Vector3D.Dot(vector3D, _0023_003DzB68dg9Q_003D - _0023_003DzEIpBwhg_003D) / Vector3D.Dot(vector3D, vector3D);
		return _0023_003DzEIpBwhg_003D + vector3D * num;
	}

	public Exp _0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D()
	{
		return Exp._0023_003Dzn7TsgvrQX_0024_7(Exp._0023_003DzKSdA2AY_003D(x) + Exp._0023_003DzKSdA2AY_003D(y) + Exp._0023_003DzKSdA2AY_003D(z));
	}

	public Exp _0023_003Dzv2_0024_0024bTe2Lsf7qf9MBkQarAU_003D()
	{
		return Exp._0023_003DzKSdA2AY_003D(x) + Exp._0023_003DzKSdA2AY_003D(y) + Exp._0023_003DzKSdA2AY_003D(z);
	}

	public ExpVector _0023_003DznLBUdKk_003D()
	{
		return this / _0023_003Dz9AfN_TRv_0024HgPy9WmXQ_003D_003D();
	}

	public Vector3D _0023_003DzBUjqlpM_003D()
	{
		return new Vector3D(x._0023_003DzBUjqlpM_003D(), y._0023_003DzBUjqlpM_003D(), z._0023_003DzBUjqlpM_003D());
	}

	public bool _0023_003DzjvGilh3NxuTT(ExpVector _0023_003Dz0yNzT9M_003D, double _0023_003DzezTples_003D)
	{
		if (Math.Abs(x._0023_003DzBUjqlpM_003D() - _0023_003Dz0yNzT9M_003D.x._0023_003DzBUjqlpM_003D()) < _0023_003DzezTples_003D && Math.Abs(y._0023_003DzBUjqlpM_003D() - _0023_003Dz0yNzT9M_003D.y._0023_003DzBUjqlpM_003D()) < _0023_003DzezTples_003D)
		{
			return Math.Abs(z._0023_003DzBUjqlpM_003D() - _0023_003Dz0yNzT9M_003D.z._0023_003DzBUjqlpM_003D()) < _0023_003DzezTples_003D;
		}
		return false;
	}

	public static ExpVector _0023_003DzdjTbdkc7Qbsy(ExpVector _0023_003DzlY77YgY_003D, ExpVector _0023_003DzxuJqjrs_003D, ExpVector _0023_003DzeoY7iyo_003D, Exp _0023_003Dz6pajdGM_003D)
	{
		ExpVector expVector = _0023_003DzxuJqjrs_003D._0023_003DznLBUdKk_003D();
		Exp exp = Exp._0023_003DzHqHPcG0_003D(_0023_003Dz6pajdGM_003D);
		Exp exp2 = Exp._0023_003DzzFteY6c_003D(_0023_003Dz6pajdGM_003D);
		ExpVector expVector2 = new ExpVector(exp + (1.0 - exp) * expVector.x * expVector.x, (1.0 - exp) * expVector.y * expVector.x + exp2 * expVector.z, (1.0 - exp) * expVector.z * expVector.x - exp2 * expVector.y);
		ExpVector expVector3 = new ExpVector((1.0 - exp) * expVector.x * expVector.y - exp2 * expVector.z, exp + (1.0 - exp) * expVector.y * expVector.y, (1.0 - exp) * expVector.z * expVector.y + exp2 * expVector.x);
		ExpVector expVector4 = new ExpVector((1.0 - exp) * expVector.x * expVector.z + exp2 * expVector.y, (1.0 - exp) * expVector.y * expVector.z - exp2 * expVector.x, exp + (1.0 - exp) * expVector.z * expVector.z);
		ExpVector expVector5 = _0023_003DzlY77YgY_003D - _0023_003DzeoY7iyo_003D;
		return expVector5.x * expVector2 + expVector5.y * expVector3 + expVector5.z * expVector4 + _0023_003DzeoY7iyo_003D;
	}

	public static Vector3D _0023_003DzdjTbdkc7Qbsy(Vector3D _0023_003DzlY77YgY_003D, Vector3D _0023_003DzxuJqjrs_003D, Vector3D _0023_003DzeoY7iyo_003D, double _0023_003Dz6pajdGM_003D)
	{
		Vector3D vector3D = _0023_003DzxuJqjrs_003D.Clone() as Vector3D;
		vector3D.Normalize();
		double num = Math.Cos(_0023_003Dz6pajdGM_003D);
		double num2 = Math.Sin(_0023_003Dz6pajdGM_003D);
		Vector3D vector3D2 = new Vector3D(num + (1.0 - num) * vector3D.X * vector3D.X, (1.0 - num) * vector3D.Y * vector3D.X + num2 * vector3D.Z, (1.0 - num) * vector3D.Z * vector3D.X - num2 * vector3D.Y);
		Vector3D vector3D3 = new Vector3D((1.0 - num) * vector3D.X * vector3D.Y - num2 * vector3D.Z, num + (1.0 - num) * vector3D.Y * vector3D.Y, (1.0 - num) * vector3D.Z * vector3D.Y + num2 * vector3D.X);
		Vector3D vector3D4 = new Vector3D((1.0 - num) * vector3D.X * vector3D.Z + num2 * vector3D.Y, (1.0 - num) * vector3D.Y * vector3D.Z - num2 * vector3D.X, num + (1.0 - num) * vector3D.Z * vector3D.Z);
		Vector3D vector3D5 = _0023_003DzlY77YgY_003D - _0023_003DzeoY7iyo_003D;
		return vector3D5.X * vector3D2 + vector3D5.Y * vector3D3 + vector3D5.Z * vector3D4 + _0023_003DzeoY7iyo_003D;
	}

	public object Clone()
	{
		return new ExpVector(this);
	}
}
