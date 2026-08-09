namespace ComponentFactory.Krypton.Ribbon;

internal class ItemSizeWidth
{
	private GroupItemSize _groupItemSize;

	private int _width;

	private int _tag;

	public GroupItemSize GroupItemSize
	{
		get
		{
			return _groupItemSize;
		}
		set
		{
			_groupItemSize = value;
		}
	}

	public int Width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
		}
	}

	public int Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	public ItemSizeWidth(GroupItemSize itemSize, int width)
		: this(itemSize, width, -1)
	{
	}

	public ItemSizeWidth(GroupItemSize itemSize, int width, int tag)
	{
		_groupItemSize = itemSize;
		_width = width;
		_tag = tag;
	}
}
