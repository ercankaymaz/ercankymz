using System.Windows;

namespace Xceed.Wpf.AvalonDock.Controls;

public class DropArea<T> : IDropArea where T : FrameworkElement
{
	private Rect _detectionRect;

	private DropAreaType _type;

	private T _element;

	public Rect DetectionRect => _detectionRect;

	public DropAreaType Type => _type;

	public T AreaElement => _element;

	internal DropArea(T areaElement, DropAreaType type)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		_element = areaElement;
		_detectionRect = areaElement.GetScreenArea();
		_type = type;
	}
}
