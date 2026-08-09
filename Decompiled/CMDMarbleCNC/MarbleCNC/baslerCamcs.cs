using System;
using System.Drawing;
using System.Drawing.Imaging;
using Basler.Pylon;

namespace MarbleCNC;

public class baslerCamcs
{
	public delegate void CameraImage(Bitmap bmp);

	public int CameraNumber = 0;

	public static bool isCameraStarted;

	private Camera camera;

	private PixelDataConverter pxConvert = new PixelDataConverter();

	private bool GrabOver = false;

	public event CameraImage CameraImageEvent;

	public void CameraInit()
	{
		camera = new Camera();
		camera.CameraOpened += Configuration.AcquireContinuous;
		camera.ConnectionLost += Camera_ConnectionLost;
		camera.StreamGrabber.GrabStarted += StreamGrabber_GrabStarted;
		camera.StreamGrabber.ImageGrabbed += StreamGrabber_ImageGrabbed;
		camera.StreamGrabber.GrabStopped += StreamGrabber_GrabStopped;
		camera.Open();
	}

	private void StreamGrabber_GrabStarted(object sender, EventArgs e)
	{
		GrabOver = true;
	}

	private void StreamGrabber_ImageGrabbed(object sender, ImageGrabbedEventArgs e)
	{
		IGrabResult grabResult = e.GrabResult;
		if (grabResult.IsValid && GrabOver)
		{
			this.CameraImageEvent(GrabResult2Bmp(grabResult));
		}
	}

	private void StreamGrabber_GrabStopped(object sender, GrabStopEventArgs e)
	{
		GrabOver = false;
	}

	private void Camera_ConnectionLost(object sender, EventArgs e)
	{
		camera.StreamGrabber.Stop();
		DestroyCamera();
	}

	public void SetExposureTime(int Val)
	{
		camera.Parameters[PLCamera.ExposureTimeAbs].SetValue(Val);
	}

	public void SetReverseX(bool Val)
	{
		camera.Parameters[PLCamera.ReverseX].SetValue(Val);
	}

	public void SetReverseY(bool Val)
	{
		camera.Parameters[PLCamera.ReverseY].SetValue(Val);
	}

	public void OneShot()
	{
		if (camera != null)
		{
			camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
			camera.StreamGrabber.Start(1L, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
		}
	}

	public void KeepShot()
	{
		if (camera != null)
		{
			camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
			camera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
			isCameraStarted = true;
		}
	}

	public void Stop()
	{
		if (camera != null)
		{
			camera.StreamGrabber.Stop();
			isCameraStarted = false;
		}
	}

	private Bitmap GrabResult2Bmp(IGrabResult grabResult)
	{
		Bitmap bitmap = new Bitmap(grabResult.Width, grabResult.Height, PixelFormat.Format32bppRgb);
		BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
		pxConvert.OutputPixelFormat = PixelType.BGRA8packed;
		IntPtr scan = bitmapData.Scan0;
		pxConvert.Convert(scan, bitmapData.Stride * bitmap.Height, grabResult);
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}

	public void DestroyCamera()
	{
		if (camera != null)
		{
			camera.Close();
			camera.Dispose();
			camera = null;
		}
	}
}
