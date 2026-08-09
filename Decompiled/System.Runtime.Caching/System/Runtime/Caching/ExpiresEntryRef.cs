namespace System.Runtime.Caching;

internal readonly struct ExpiresEntryRef : IEquatable<ExpiresEntryRef>
{
	internal static readonly ExpiresEntryRef INVALID = new ExpiresEntryRef(0, 0);

	private const uint ENTRY_MASK = 255u;

	private const int PAGE_SHIFT = 8;

	private readonly uint _ref = (uint)((pageIndex << 8) | (entryIndex & 0xFF));

	internal int PageIndex => (int)(_ref >> 8);

	internal int Index => (int)(_ref & 0xFF);

	internal bool IsInvalid => _ref == 0;

	internal ExpiresEntryRef(int pageIndex, int entryIndex)
	{
	}

	public override bool Equals(object value)
	{
		if (value is ExpiresEntryRef other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ExpiresEntryRef other)
	{
		return _ref == other._ref;
	}

	public static bool operator ==(ExpiresEntryRef r1, ExpiresEntryRef r2)
	{
		return r1.Equals(r2);
	}

	public static bool operator !=(ExpiresEntryRef r1, ExpiresEntryRef r2)
	{
		return !r1.Equals(r2);
	}

	public override int GetHashCode()
	{
		return (int)_ref;
	}
}
