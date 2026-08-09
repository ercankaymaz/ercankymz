using System;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class BitwiseOperators
{
	internal abstract class AbstractLogicalOperator : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.Stack.Pop();
			object obj2 = context.Stack.Pop();
			if (obj2 is bool @bool && obj is bool bool2)
			{
				bool flag = ApplyForBoolean(@bool, bool2);
				context.Stack.Push(flag);
				return;
			}
			if (obj2 is int @int && obj is int int2)
			{
				int num = ApplyForInt(@int, int2);
				context.Stack.Push(num);
				return;
			}
			throw new InvalidCastException("Operands must be bool/bool or int/int");
		}

		protected abstract bool ApplyForBoolean(bool bool1, bool bool2);

		protected abstract int ApplyForInt(int int1, int int2);
	}

	internal sealed class And : AbstractLogicalOperator
	{
		protected override bool ApplyForBoolean(bool bool1, bool bool2)
		{
			return bool1 && bool2;
		}

		protected override int ApplyForInt(int int1, int int2)
		{
			return int1 & int2;
		}
	}

	internal sealed class Bitshift : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = Convert.ToInt32(context.Stack.Pop());
			int num2 = Convert.ToInt32(context.Stack.Pop());
			if (num < 0)
			{
				int num3 = num2 >> Math.Abs(num);
				context.Stack.Push(num3);
			}
			else
			{
				int num4 = num2 << num;
				context.Stack.Push(num4);
			}
		}
	}

	internal sealed class False : Operator
	{
		public void Execute(ExecutionContext context)
		{
			context.Stack.Push(false);
		}
	}

	internal sealed class Not : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.Stack.Pop();
			if (obj is bool flag)
			{
				bool flag2 = !flag;
				context.Stack.Push(flag2);
				return;
			}
			if (obj is int num)
			{
				int num2 = -num;
				context.Stack.Push(num2);
				return;
			}
			throw new InvalidCastException("Operand must be bool or int");
		}
	}

	internal sealed class Or : AbstractLogicalOperator
	{
		protected override bool ApplyForBoolean(bool bool1, bool bool2)
		{
			return bool1 || bool2;
		}

		protected override int ApplyForInt(int int1, int int2)
		{
			return int1 | int2;
		}
	}

	internal sealed class True : Operator
	{
		public void Execute(ExecutionContext context)
		{
			context.Stack.Push(true);
		}
	}

	internal sealed class Xor : AbstractLogicalOperator
	{
		protected override bool ApplyForBoolean(bool bool1, bool bool2)
		{
			return bool1 ^ bool2;
		}

		protected override int ApplyForInt(int int1, int int2)
		{
			return int1 ^ int2;
		}
	}

	private BitwiseOperators()
	{
	}
}
