namespace System.Runtime.Caching;

internal readonly struct UsageEntryRef : IEquatable<UsageEntryRef>
{
	internal static readonly UsageEntryRef INVALID = new UsageEntryRef(0, 0);

	private const uint ENTRY_MASK = 255u;

	private const int PAGE_SHIFT = 8;

	private readonly uint _ref = (uint)((pageIndex << 8) | (entryIndex & 0xFF));

	internal int PageIndex => (int)(_ref >> 8);

	internal int Ref1Index => (sbyte)(_ref & 0xFF);

	internal int Ref2Index
	{
		get
		{
			int num = (sbyte)(_ref & 0xFF);
			return -num;
		}
	}

	internal bool IsRef1 => (sbyte)(_ref & 0xFF) > 0;

	internal bool IsRef2 => (sbyte)(_ref & 0xFF) < 0;

	internal bool IsInvalid => _ref == 0;

	internal UsageEntryRef(int pageIndex, int entryIndex)
	{
	}

	public override bool Equals(object value)
	{
		if (value is UsageEntryRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(UsageEntryRef other)
	{
		return _ref == other._ref;
	}

	public static bool operator ==(UsageEntryRef r1, UsageEntryRef r2)
	{
		return r1.Equals(r2);
	}

	public static bool operator !=(UsageEntryRef r1, UsageEntryRef r2)
	{
		return !r1.Equals(r2);
	}

	public override int GetHashCode()
	{
		return (int)_ref;
	}
}
