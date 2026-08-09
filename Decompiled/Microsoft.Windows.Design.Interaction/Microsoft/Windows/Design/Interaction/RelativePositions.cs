namespace Microsoft.Windows.Design.Interaction;

public static class RelativePositions
{
	private static RelativePosition _topLeft;

	private static RelativePosition _topSide;

	private static RelativePosition _topRight;

	private static RelativePosition _rightSide;

	private static RelativePosition _bottomRight;

	private static RelativePosition _bottomSide;

	private static RelativePosition _bottomLeft;

	private static RelativePosition _leftSide;

	private static RelativePosition _center;

	private static RelativePosition[] _bounds;

	private static RelativePosition _internalLeftSide;

	private static RelativePosition _internalTopSide;

	private static RelativePosition _internalBottomSide;

	private static RelativePosition _internalRightSide;

	private static RelativePosition _internalTopLeft;

	private static RelativePosition _internalTopRight;

	private static RelativePosition _internalBottomLeft;

	private static RelativePosition _internalBottomRight;

	private static RelativePosition _externalLeftSide;

	private static RelativePosition _externalTopSide;

	private static RelativePosition _externalBottomSide;

	private static RelativePosition _externalRightSide;

	private static RelativePosition _externalTopLeft;

	private static RelativePosition _externalTopRight;

	private static RelativePosition _externalBottomLeft;

	private static RelativePosition _externalBottomRight;

	public static RelativePosition InternalLeftSide => GetPosition(ref _internalLeftSide, "InternalLeftSide");

	public static RelativePosition InternalTopSide => GetPosition(ref _internalTopSide, "InternalTopSide");

	public static RelativePosition InternalBottomSide => GetPosition(ref _internalBottomSide, "InternalBottomSide");

	public static RelativePosition InternalRightSide => GetPosition(ref _internalRightSide, "InternalRightSide");

	public static RelativePosition InternalBottomLeft => GetPosition(ref _internalBottomLeft, "InternalBottomLeft", InternalBottomSide, InternalLeftSide);

	public static RelativePosition InternalBottomRight => GetPosition(ref _internalBottomRight, "InternalBottomRight", InternalBottomSide, InternalRightSide);

	public static RelativePosition InternalTopLeft => GetPosition(ref _internalTopLeft, "InternalTopLeft", InternalTopSide, InternalLeftSide);

	public static RelativePosition InternalTopRight => GetPosition(ref _internalTopRight, "InternalTopRight", InternalTopSide, InternalRightSide);

	public static RelativePosition ExternalLeftSide => GetPosition(ref _externalLeftSide, "ExternalLeftSide");

	public static RelativePosition ExternalTopSide => GetPosition(ref _externalTopSide, "ExternalTopSide");

	public static RelativePosition ExternalBottomSide => GetPosition(ref _externalBottomSide, "ExternalBottomSide");

	public static RelativePosition ExternalRightSide => GetPosition(ref _externalRightSide, "ExternalRightSide");

	public static RelativePosition ExternalBottomLeft => GetPosition(ref _externalBottomLeft, "ExternalBottomLeft", ExternalBottomSide, ExternalLeftSide);

	public static RelativePosition ExternalBottomRight => GetPosition(ref _externalBottomRight, "ExternalBottomRight", ExternalBottomSide, ExternalRightSide);

	public static RelativePosition ExternalTopLeft => GetPosition(ref _externalTopLeft, "ExternalTopLeft", ExternalTopSide, ExternalLeftSide);

	public static RelativePosition ExternalTopRight => GetPosition(ref _externalTopRight, "ExternalTopRight", ExternalTopSide, ExternalRightSide);

	public static RelativePosition[] Bounds
	{
		get
		{
			if (_bounds == null)
			{
				_bounds = new RelativePosition[4] { LeftSide, TopSide, RightSide, BottomSide };
			}
			return _bounds;
		}
	}

	public static RelativePosition BottomLeft => GetPosition(ref _bottomLeft, "BottomLeft", BottomSide, LeftSide);

	public static RelativePosition BottomRight => GetPosition(ref _bottomRight, "BottomRight", BottomSide, RightSide);

	public static RelativePosition BottomSide => GetPosition(ref _bottomSide, "BottomSide");

	public static RelativePosition Center => GetPosition(ref _center, "Center");

	public static RelativePosition LeftSide => GetPosition(ref _leftSide, "LeftSide");

	public static RelativePosition RightSide => GetPosition(ref _rightSide, "RightSide");

	public static RelativePosition TopLeft => GetPosition(ref _topLeft, "TopLeft", TopSide, LeftSide);

	public static RelativePosition TopRight => GetPosition(ref _topRight, "TopRight", TopSide, RightSide);

	public static RelativePosition TopSide => GetPosition(ref _topSide, "TopSide");

	private static RelativePosition GetPosition(ref RelativePosition pos, string name, params RelativePosition[] values)
	{
		if (object.ReferenceEquals(pos, null))
		{
			pos = new RelativePosition(name, values);
		}
		return pos;
	}
}
