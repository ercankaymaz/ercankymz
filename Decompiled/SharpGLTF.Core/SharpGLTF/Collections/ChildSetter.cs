using System.Diagnostics;

namespace SharpGLTF.Collections;

public readonly struct ChildSetter<TParent> where TParent : class
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly TParent _Parent;

	public ChildSetter(TParent parent)
	{
		Guard.NotNull(parent, "parent");
		_Parent = parent;
	}

	public void SetProperty<TProperty, TValue>(ref TProperty target, TValue value) where TProperty : class where TValue : TProperty
	{
		if ((object)value != target)
		{
			if (target is IChildOf<TParent> childOf)
			{
				childOf.SetLogicalParent(null);
			}
			target = (TProperty)(object)value;
			if (target is IChildOf<TParent> childOf2)
			{
				childOf2.SetLogicalParent(_Parent);
			}
		}
	}
}
