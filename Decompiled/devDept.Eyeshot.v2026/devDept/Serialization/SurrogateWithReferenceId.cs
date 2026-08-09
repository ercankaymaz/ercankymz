using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Serialization;

public abstract class SurrogateWithReferenceId<T> : Surrogate<T>, ISurrogateWithReferenceId
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dzmf0riQ8blvBYVi1v1w_003D_003D;

	public int ReferenceId
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzmf0riQ8blvBYVi1v1w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzmf0riQ8blvBYVi1v1w_003D_003D = value;
		}
	}

	protected SurrogateWithReferenceId(T obj)
		: base(obj)
	{
		ReferenceId = -1;
	}

	protected SurrogateWithReferenceId(int referenceId)
		: base(referenceId)
	{
		ReferenceId = referenceId;
	}

	public override bool Equals(object obj)
	{
		if (ReferenceId > 0 || !base.Equals(obj))
		{
			if (ReferenceId > 0 && obj is ISurrogateWithReferenceId surrogateWithReferenceId)
			{
				return surrogateWithReferenceId.ReferenceId == ReferenceId;
			}
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		if (ReferenceId > 0)
		{
			return ReferenceId;
		}
		return base.GetHashCode();
	}
}
