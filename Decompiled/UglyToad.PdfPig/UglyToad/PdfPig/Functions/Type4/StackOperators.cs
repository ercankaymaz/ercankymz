using System;
using System.Collections.Generic;
using System.Linq;

namespace UglyToad.PdfPig.Functions.Type4;

internal sealed class StackOperators
{
	internal sealed class Copy : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = (int)context.Stack.Pop();
			if (num > 0)
			{
				context.AddAllToStack(context.Stack.ToList().Take(num));
			}
		}
	}

	internal sealed class Dup : Operator
	{
		public void Execute(ExecutionContext context)
		{
			context.Stack.Push(context.Stack.Peek());
		}
	}

	internal sealed class Exch : Operator
	{
		public void Execute(ExecutionContext context)
		{
			object item = context.Stack.Pop();
			object item2 = context.Stack.Pop();
			context.Stack.Push(item);
			context.Stack.Push(item2);
		}
	}

	internal sealed class Index : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = Convert.ToInt32(context.Stack.Pop());
			if (num < 0)
			{
				throw new ArgumentException("rangecheck: " + num);
			}
			context.Stack.Push(context.Stack.ElementAt(num));
		}
	}

	internal sealed class Pop : Operator
	{
		public void Execute(ExecutionContext context)
		{
			context.Stack.Pop();
		}
	}

	internal sealed class Roll : Operator
	{
		public void Execute(ExecutionContext context)
		{
			int num = (int)context.Stack.Pop();
			int num2 = (int)context.Stack.Pop();
			if (num == 0)
			{
				return;
			}
			if (num2 < 0)
			{
				throw new ArgumentException("rangecheck: " + num2);
			}
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			if (num < 0)
			{
				int num3 = num2 + num;
				for (int i = 0; i < num3; i++)
				{
					list2.Add(context.Stack.Pop());
				}
				for (int j = num; j < 0; j++)
				{
					list.Add(context.Stack.Pop());
				}
				context.AddAllToStack(list2);
				context.AddAllToStack(list);
				return;
			}
			int num4 = num2 - num;
			for (int num5 = num; num5 > 0; num5--)
			{
				list.Add(context.Stack.Pop());
			}
			for (int k = 0; k < num4; k++)
			{
				list2.Add(context.Stack.Pop());
			}
			context.AddAllToStack(list);
			context.AddAllToStack(list2);
		}
	}

	private StackOperators()
	{
	}
}
