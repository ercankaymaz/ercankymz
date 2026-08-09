using System.Windows;
using System.Windows.Media;

namespace Xceed.Wpf.AvalonDock.Controls;

internal static class TransformExtensions
{
	public static Point PointToScreenDPI(this Visual visual, Point pt)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		Point pt2 = visual.PointToScreen(pt);
		return visual.TransformToDeviceDPI(pt2);
	}

	public static Point PointToScreenDPIWithoutFlowDirection(this FrameworkElement element, Point point)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (FrameworkElement.GetFlowDirection((DependencyObject)(object)element) == FlowDirection.RightToLeft)
		{
			Size val = element.TransformActualSizeToAncestor();
			Point pt = default(Point);
			((Point)(ref pt))._002Ector(((Size)(ref val)).Width - ((Point)(ref point)).X, ((Point)(ref point)).Y);
			return element.PointToScreenDPI(pt);
		}
		return element.PointToScreenDPI(point);
	}

	public static Rect GetScreenArea(this FrameworkElement element)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		Point val = element.PointToScreenDPI(default(Point));
		if (FrameworkElement.GetFlowDirection((DependencyObject)(object)element) == FlowDirection.RightToLeft)
		{
			Size val2 = element.TransformActualSizeToAncestor();
			return new Rect(new Point(((Size)(ref val2)).Width - ((Point)(ref val)).X, ((Point)(ref val)).Y), val2);
		}
		return new Rect(val, element.TransformActualSizeToAncestor());
	}

	public static Point TransformToDeviceDPI(this Visual visual, Point pt)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Matrix transformToDevice = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
		return new Point(((Point)(ref pt)).X / ((Matrix)(ref transformToDevice)).M11, ((Point)(ref pt)).Y / ((Matrix)(ref transformToDevice)).M22);
	}

	public static Size TransformFromDeviceDPI(this Visual visual, Size size)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Matrix transformToDevice = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
		return new Size(((Size)(ref size)).Width * ((Matrix)(ref transformToDevice)).M11, ((Size)(ref size)).Height * ((Matrix)(ref transformToDevice)).M22);
	}

	public static Point TransformFromDeviceDPI(this Visual visual, Point pt)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Matrix transformToDevice = PresentationSource.FromVisual(visual).CompositionTarget.TransformToDevice;
		return new Point(((Point)(ref pt)).X * ((Matrix)(ref transformToDevice)).M11, ((Point)(ref pt)).Y * ((Matrix)(ref transformToDevice)).M22);
	}

	public static bool CanTransform(this Visual visual)
	{
		return PresentationSource.FromVisual(visual) != null;
	}

	public static Size TransformActualSizeToAncestor(this FrameworkElement element)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (PresentationSource.FromVisual(element) == null)
		{
			return new Size(element.ActualWidth, element.ActualHeight);
		}
		Visual rootVisual = PresentationSource.FromVisual(element).RootVisual;
		Rect val = element.TransformToAncestor(rootVisual).TransformBounds(new Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight));
		return ((Rect)(ref val)).Size;
	}

	public static Size TransformSizeToAncestor(this FrameworkElement element, Size sizeToTransform)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (PresentationSource.FromVisual(element) == null)
		{
			return sizeToTransform;
		}
		Visual rootVisual = PresentationSource.FromVisual(element).RootVisual;
		Rect val = element.TransformToAncestor(rootVisual).TransformBounds(new Rect(0.0, 0.0, ((Size)(ref sizeToTransform)).Width, ((Size)(ref sizeToTransform)).Height));
		return ((Rect)(ref val)).Size;
	}

	public static GeneralTransform TansformToAncestor(this FrameworkElement element)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		if (PresentationSource.FromVisual(element) == null)
		{
			return new MatrixTransform(Matrix.Identity);
		}
		Visual rootVisual = PresentationSource.FromVisual(element).RootVisual;
		return element.TransformToAncestor(rootVisual);
	}
}
