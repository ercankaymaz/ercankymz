using System;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class ArithmeticOperators
{
	internal sealed class Abs : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int value)
			{
				context.Stack.Push(Math.Abs(value));
			}
			else
			{
				context.Stack.Push(Math.Abs(Convert.ToDouble(obj)));
			}
		}
	}

	internal sealed class Add : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			object obj2 = context.PopNumber();
			if (obj2 is int num && obj is int num2)
			{
				long num3 = (long)num + (long)num2;
				if (num3 < int.MinValue || num3 > int.MaxValue)
				{
					context.Stack.Push((double)num3);
				}
				else
				{
					context.Stack.Push((int)num3);
				}
			}
			else
			{
				double num4 = Convert.ToDouble(obj2) + Convert.ToDouble(obj);
				context.Stack.Push(num4);
			}
		}
	}

	internal sealed class Atan : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double x = context.PopReal();
			double val = Math.Atan2(context.PopReal(), x);
			val = ToDegrees(val) % 360.0;
			if (val < 0.0)
			{
				val += 360.0;
			}
			context.Stack.Push(val);
		}
	}

	internal sealed class Ceiling : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int num)
			{
				context.Stack.Push(num);
			}
			else
			{
				context.Stack.Push(Math.Ceiling(Convert.ToDouble(obj)));
			}
		}
	}

	internal sealed class Cos : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double num = Math.Cos(ToRadians(context.PopReal()));
			context.Stack.Push(num);
		}
	}

	internal sealed class Cvi : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object value = context.PopNumber();
			context.Stack.Push((int)Math.Truncate(Convert.ToDouble(value)));
		}
	}

	internal sealed class Cvr : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object value = context.PopNumber();
			context.Stack.Push(Convert.ToDouble(value));
		}
	}

	internal sealed class Div : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double num = Convert.ToDouble(context.PopNumber());
			double num2 = Convert.ToDouble(context.PopNumber());
			context.Stack.Push(num2 / num);
		}
	}

	internal sealed class Exp : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double y = Convert.ToDouble(context.PopNumber());
			double num = Math.Pow(Convert.ToDouble(context.PopNumber()), y);
			context.Stack.Push(num);
		}
	}

	internal sealed class Floor : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int num)
			{
				context.Stack.Push(num);
			}
			else
			{
				context.Stack.Push(Math.Floor(Convert.ToDouble(obj)));
			}
		}
	}

	internal sealed class IDiv : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = context.PopInt();
			int num2 = context.PopInt();
			context.Stack.Push(num2 / num);
		}
	}

	internal sealed class Ln : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object value = context.PopNumber();
			context.Stack.Push(Math.Log(Convert.ToDouble(value)));
		}
	}

	internal sealed class Log : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object value = context.PopNumber();
			context.Stack.Push(Math.Log10(Convert.ToDouble(value)));
		}
	}

	internal sealed class Mod : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = context.PopInt();
			int num2 = context.PopInt();
			context.Stack.Push(num2 % num);
		}
	}

	internal sealed class Mul : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			object obj2 = context.PopNumber();
			if (obj2 is int num && obj is int num2)
			{
				long num3 = (long)num * (long)num2;
				if (num3 >= int.MinValue && num3 <= int.MaxValue)
				{
					context.Stack.Push((int)num3);
				}
				else
				{
					context.Stack.Push((double)num3);
				}
			}
			else
			{
				double num4 = Convert.ToDouble(obj2) * Convert.ToDouble(obj);
				context.Stack.Push(num4);
			}
		}
	}

	internal sealed class Neg : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int num)
			{
				if (num == int.MinValue)
				{
					context.Stack.Push(0.0 - Convert.ToDouble(num));
				}
				else
				{
					context.Stack.Push(-num);
				}
			}
			else
			{
				context.Stack.Push(0.0 - Convert.ToDouble(obj));
			}
		}
	}

	internal sealed class Round : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int num)
			{
				context.Stack.Push(num);
				return;
			}
			double num2 = Convert.ToDouble(obj);
			double num3 = ((num2 < 0.0) ? Math.Round(num2) : Math.Round(num2, MidpointRounding.AwayFromZero));
			context.Stack.Push(num3);
		}
	}

	internal sealed class Sin : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double num = Math.Sin(ToRadians(context.PopReal()));
			context.Stack.Push(num);
		}
	}

	internal sealed class Sqrt : Operator
	{
		public void Execute(ExecutionContext context)
		{
			double num = context.PopReal();
			if (num < 0.0)
			{
				throw new ArgumentException("argument must be nonnegative");
			}
			context.Stack.Push(Math.Sqrt(num));
		}
	}

	internal sealed class Sub : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			object obj2 = context.PopNumber();
			if (obj2 is int num && obj is int num2)
			{
				long num3 = (long)num - (long)num2;
				if (num3 < int.MinValue || num3 > int.MaxValue)
				{
					context.Stack.Push((double)num3);
				}
				else
				{
					context.Stack.Push((int)num3);
				}
			}
			else
			{
				double num4 = Convert.ToDouble(obj2) - Convert.ToDouble(obj);
				context.Stack.Push(num4);
			}
		}
	}

	internal sealed class Truncate : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object obj = context.PopNumber();
			if (obj is int num)
			{
				context.Stack.Push(num);
			}
			else
			{
				context.Stack.Push(Math.Truncate(Convert.ToDouble(obj)));
			}
		}
	}

	private ArithmeticOperators()
	{
	}

	private static double ToRadians(double val)
	{
		return Math.PI / 180.0 * val;
	}

	private static double ToDegrees(double val)
	{
		return 180.0 / Math.PI * val;
	}
}
