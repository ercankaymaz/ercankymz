using System;
using System.Diagnostics;

namespace UglyToad.PdfPig.Core;

public abstract class Union<A, B>
{
	public sealed class Case1 : Union<A, B>
	{
		public readonly A Item;

		public Case1(A item)
		{
			Item = item;
		}

		[DebuggerStepThrough]
		public override void Match(Action<A> first, Action<B> second)
		{
			first(Item);
		}

		[DebuggerStepThrough]
		public override TResult Match<TResult>(Func<A, TResult> first, Func<B, TResult> second)
		{
			return first(Item);
		}

		public override bool TryGetFirst(out A a)
		{
			a = Item;
			return true;
		}

		public override bool TryGetSecond(out B b)
		{
			b = default(B);
			return false;
		}

		public override string ToString()
		{
			A item = Item;
			return ((item != null) ? item.ToString() : null) ?? string.Empty;
		}
	}

	public sealed class Case2 : Union<A, B>
	{
		public readonly B Item;

		public Case2(B item)
		{
			Item = item;
		}

		[DebuggerStepThrough]
		public override void Match(Action<A> first, Action<B> second)
		{
			second(Item);
		}

		[DebuggerStepThrough]
		public override TResult Match<TResult>(Func<A, TResult> first, Func<B, TResult> second)
		{
			return second(Item);
		}

		public override bool TryGetFirst(out A a)
		{
			a = default(A);
			return false;
		}

		public override bool TryGetSecond(out B b)
		{
			b = Item;
			return true;
		}

		public override string ToString()
		{
			B item = Item;
			return ((item != null) ? item.ToString() : null) ?? string.Empty;
		}
	}

	public abstract void Match(Action<A> first, Action<B> second);

	public abstract TResult Match<TResult>(Func<A, TResult> first, Func<B, TResult> second);

	public abstract bool TryGetFirst(out A a);

	public abstract bool TryGetSecond(out B b);

	private Union()
	{
	}

	public static Case1 One(A item)
	{
		return new Case1(item);
	}

	public static Case2 Two(B item)
	{
		return new Case2(item);
	}
}
