using System.Windows;
using System.Windows.Media;

namespace Standard;

internal static class DpiHelper
{
	private static Matrix _transformToDevice;

	private static Matrix _transformToDip;

	static DpiHelper()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		using Standard.SafeDC hdc = Standard.SafeDC.GetDesktop();
		int deviceCaps = Standard.NativeMethods.GetDeviceCaps(hdc, Standard.DeviceCap.LOGPIXELSX);
		int deviceCaps2 = Standard.NativeMethods.GetDeviceCaps(hdc, Standard.DeviceCap.LOGPIXELSY);
		_transformToDip = Matrix.Identity;
		((Matrix)(ref _transformToDip)).Scale(96.0 / (double)deviceCaps, 96.0 / (double)deviceCaps2);
		_transformToDevice = Matrix.Identity;
		((Matrix)(ref _transformToDevice)).Scale((double)deviceCaps / 96.0, (double)deviceCaps2 / 96.0);
	}

	public static Point LogicalPixelsToDevice(Point logicalPoint)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((Matrix)(ref _transformToDevice)).Transform(logicalPoint);
	}

	public static Point DevicePixelsToLogical(Point devicePoint)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((Matrix)(ref _transformToDip)).Transform(devicePoint);
	}

	public static Rect LogicalRectToDevice(Rect logicalRectangle)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Point val = LogicalPixelsToDevice(new Point(((Rect)(ref logicalRectangle)).Left, ((Rect)(ref logicalRectangle)).Top));
		Point val2 = LogicalPixelsToDevice(new Point(((Rect)(ref logicalRectangle)).Right, ((Rect)(ref logicalRectangle)).Bottom));
		return new Rect(val, val2);
	}

	public static Rect DeviceRectToLogical(Rect deviceRectangle)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		Point val = DevicePixelsToLogical(new Point(((Rect)(ref deviceRectangle)).Left, ((Rect)(ref deviceRectangle)).Top));
		Point val2 = DevicePixelsToLogical(new Point(((Rect)(ref deviceRectangle)).Right, ((Rect)(ref deviceRectangle)).Bottom));
		return new Rect(val, val2);
	}

	public static Size LogicalSizeToDevice(Size logicalSize)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		Point val = LogicalPixelsToDevice(new Point(((Size)(ref logicalSize)).Width, ((Size)(ref logicalSize)).Height));
		Size result = default(Size);
		((Size)(ref result)).Width = ((Point)(ref val)).X;
		((Size)(ref result)).Height = ((Point)(ref val)).Y;
		return result;
	}

	public static Size DeviceSizeToLogical(Size deviceSize)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Point val = DevicePixelsToLogical(new Point(((Size)(ref deviceSize)).Width, ((Size)(ref deviceSize)).Height));
		return new Size(((Point)(ref val)).X, ((Point)(ref val)).Y);
	}
}
