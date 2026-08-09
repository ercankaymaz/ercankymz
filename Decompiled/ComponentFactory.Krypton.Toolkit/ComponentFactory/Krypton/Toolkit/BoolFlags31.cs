namespace ComponentFactory.Krypton.Toolkit;

public struct BoolFlags31
{
	private int _flags;

	public int Flags
	{
		get
		{
			return _flags;
		}
		set
		{
			_flags = value;
		}
	}

	public int SetFlags(int flags)
	{
		int flags2 = _flags;
		_flags |= flags;
		return flags2 ^ _flags;
	}

	public int ClearFlags(int flags)
	{
		int flags2 = _flags;
		_flags &= ~flags;
		return flags2 ^ _flags;
	}

	public bool AreFlagsSet(int flags)
	{
		return (_flags & flags) == flags;
	}
}
