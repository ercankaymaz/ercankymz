namespace ComponentFactory.Krypton.Ribbon;

internal class GroupSizeWidth
{
	private int _width;

	private ItemSizeWidth[] _sizing;

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

	public ItemSizeWidth[] Sizing
	{
		get
		{
			return _sizing;
		}
		set
		{
			_sizing = value;
		}
	}

	public GroupSizeWidth(int width, ItemSizeWidth[] sizing)
	{
		_width = width;
		_sizing = sizing;
	}
}
