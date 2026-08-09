namespace SixLabors.ImageSharp.Common.Helpers;

internal readonly struct ExifResolutionValues(ushort resolutionUnit, double? horizontalResolution, double? verticalResolution)
{
	public ushort ResolutionUnit { get; } = resolutionUnit;

	public double? HorizontalResolution { get; } = horizontalResolution;

	public double? VerticalResolution { get; } = verticalResolution;
}
