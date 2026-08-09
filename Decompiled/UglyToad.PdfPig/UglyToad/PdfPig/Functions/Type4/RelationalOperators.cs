using System;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class RelationalOperators
{
	internal class Eq : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object op = context.Stack.Pop();
			object op2 = context.Stack.Pop();
			bool flag = IsEqual(op2, op);
			context.Stack.Push(flag);
		}

		protected virtual bool IsEqual(object op1, object op2)
		{
			if (op1 is double num && op2 is double obj)
			{
				return num.Equals(obj);
			}
			return op1.Equals(op2);
		}
	}

	internal abstract class AbstractNumberComparisonOperator : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object value = context.Stack.Pop();
			double num = Convert.ToDouble(context.Stack.Pop());
			double num2 = Convert.ToDouble(value);
			bool flag = Compare(num, num2);
			context.Stack.Push(flag);
		}

		protected abstract bool Compare(double num1, double num2);
	}

	internal sealed class Ge : AbstractNumberComparisonOperator
	{
		protected override bool Compare(double num1, double num2)
		{
			return num1 >= num2;
		}
	}

	internal sealed class Gt : AbstractNumberComparisonOperator
	{
		protected override bool Compare(double num1, double num2)
		{
			return num1 > num2;
		}
	}

	internal sealed class Le : AbstractNumberComparisonOperator
	{
		protected override bool Compare(double num1, double num2)
		{
			return num1 <= num2;
		}
	}

	internal sealed class Lt : AbstractNumberComparisonOperator
	{
		protected override bool Compare(double num1, double num2)
		{
			return num1 < num2;
		}
	}

	internal sealed class Ne : Eq
	{
		protected override bool IsEqual(object op1, object op2)
		{
			return !base.IsEqual(op1, op2);
		}
	}

	private RelationalOperators()
	{
	}
}
