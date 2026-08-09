using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using _0005;
using Basler.Pylon;

namespace buMarble;

public class baslerCamcs
{
	public delegate void CameraImage(Bitmap bmp);

	public int CameraNumber = 0;

	[CompilerGenerated]
	private CameraImage m__0001;

	public static bool isCameraStarted;

	private Camera m__0001;

	internal PixelDataConverter _0001 = new PixelDataConverter();

	private bool m__0001 = false;

	public event CameraImage CameraImageEvent
	{
		[CompilerGenerated]
		add
		{
			CameraImage cameraImage = this.m__0001;
			while (true)
			{
				CameraImage cameraImage2 = cameraImage;
				while (true)
				{
					CameraImage obj = (CameraImage)global::_0088_0002._0008_000E(cameraImage2, value);
					CameraImage value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cameraImage = Interlocked.CompareExchange(ref this.m__0001, value2, cameraImage2);
					if ((object)cameraImage != cameraImage2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			CameraImage cameraImage = this.m__0001;
			while (true)
			{
				CameraImage cameraImage2 = cameraImage;
				while (true)
				{
					CameraImage obj = (CameraImage)global::_0088_0002._000E_000E(cameraImage2, value);
					CameraImage value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					cameraImage = Interlocked.CompareExchange(ref this.m__0001, value2, cameraImage2);
					if ((object)cameraImage != cameraImage2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public void CameraInit()
	{
		this.m__0001 = new Camera();
		_0089_0006._007E_0005_0013(this.m__0001, Configuration.AcquireContinuous);
		_0089_0006._007E_0006_0013(this.m__0001, _0002);
		_0089_0006._007E_0007_0013(_008A_0006._007E_0008_0013(this.m__0001), _0001);
		_008B_0006._007E_000E_0013(_008A_0006._007E_0008_0013(this.m__0001), _0001);
		_008C_0006._007E_000F_0013(_008A_0006._007E_0008_0013(this.m__0001), _0001);
		_008D_0006._007E_0010_0013(this.m__0001);
	}

	private void _0001(object P_0, EventArgs P_1)
	{
		this.m__0001 = true;
	}

	private void _0001(object P_0, ImageGrabbedEventArgs P_1)
	{
		do
		{
			IGrabResult grabResult = _008E_0006._007E_0011_0013(P_1);
			do
			{
				if (false)
				{
					continue;
				}
				bool num = global::_0003._007E_0015(grabResult);
				if (uint.MaxValue != 0)
				{
					bool flag = num;
					if (0 == 0 && !flag)
					{
						break;
					}
					num = this.m__0001;
				}
				if (num)
				{
					this.m__0001(_0005._0003._0001(grabResult, this));
				}
			}
			while (4 == 0);
		}
		while (false);
	}

	private void _0001(object P_0, GrabStopEventArgs P_1)
	{
		this.m__0001 = false;
	}

	private void _0002(object P_0, EventArgs P_1)
	{
		while (true)
		{
			global::_0011._007E_0096_0003(_008A_0006._007E_0008_0013(this.m__0001));
			if (0 == 0 && 7u != 0 && 8u != 0)
			{
				if (0 == 0)
				{
					DestroyCamera();
				}
				if (0 == 0)
				{
					break;
				}
			}
		}
	}

	public void SetExposureTime(int Val)
	{
		global::_0095._007E_0011_0008(_0091_0006._007E_0014_0013(_008F_0006._007E_0012_0013(this.m__0001), _0090_0006._0013_0013()), Val);
	}

	public void SetReverseX(bool Val)
	{
		if (4u != 0)
		{
			global::_0082._007E_009B_0005(_0093_0006._007E_0017_0013(_008F_0006._007E_0012_0013(this.m__0001), _0092_0006._0015_0013()), Val);
		}
	}

	public void SetReverseY(bool Val)
	{
		if (4u != 0)
		{
			global::_0082._007E_009B_0005(_0093_0006._007E_0017_0013(_008F_0006._007E_0012_0013(this.m__0001), _0092_0006._0016_0013()), Val);
		}
	}

	public void OneShot()
	{
		if (uint.MaxValue != 0 && 5u != 0 && this.m__0001 != null)
		{
			global::_008B._007E_009A_0006(_0096_0006._007E_001A_0013(_008F_0006._007E_0012_0013(this.m__0001), _0095_0006._0019_0013(_0094_0006._0018_0013())), global::_0005._007E_008E(_0094_0006._0018_0013()));
			_0097_0006._007E_001B_0013(_008A_0006._007E_0008_0013(this.m__0001), 1L, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
		}
	}

	public void KeepShot()
	{
		if (uint.MaxValue != 0)
		{
			goto IL_0007;
		}
		goto IL_0099;
		IL_0007:
		if (5u != 0 && this.m__0001 != null)
		{
			goto IL_002a;
		}
		goto IL_0099;
		IL_0092:
		isCameraStarted = true;
		goto IL_0099;
		IL_002a:
		while (3u != 0)
		{
			global::_008B._007E_009A_0006(_0096_0006._007E_001A_0013(_008F_0006._007E_0012_0013(this.m__0001), _0095_0006._0019_0013(_0094_0006._0018_0013())), global::_0005._007E_008F(_0094_0006._0018_0013()));
			_0098_0006._007E_001C_0013(_008A_0006._007E_0008_0013(this.m__0001), GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
			if (2 == 0)
			{
				continue;
			}
			goto IL_0092;
		}
		goto IL_0007;
		IL_0099:
		if (5u != 0)
		{
			return;
		}
		goto IL_002a;
	}

	public void Stop()
	{
		while (true)
		{
			if (8u != 0)
			{
				bool num = this.m__0001 != null;
				if (0 == 0)
				{
					bool flag = num;
					num = flag;
				}
				if (!num)
				{
					break;
				}
			}
			while (-1 == 0)
			{
			}
			global::_0011._007E_0096_0003(_008A_0006._007E_0008_0013(this.m__0001));
			if (0 == 0)
			{
				isCameraStarted = false;
				break;
			}
		}
	}

	public void DestroyCamera()
	{
		while (true)
		{
			if (4 == 0)
			{
				goto IL_002c;
			}
			bool num = this.m__0001 != null;
			while (true)
			{
				bool flag;
				if (uint.MaxValue != 0)
				{
					flag = num;
				}
				if (6 == 0)
				{
					break;
				}
				num = flag;
				if (false)
				{
					continue;
				}
				goto IL_001a;
			}
			goto IL_0043;
			IL_002c:
			global::_0011._007E_0098_0003(this.m__0001);
			goto IL_0068;
			IL_0068:
			this.m__0001 = null;
			goto IL_0043;
			IL_001a:
			if (!num)
			{
				break;
			}
			global::_0011._007E_0097_0003(this.m__0001);
			goto IL_002c;
			IL_0043:
			if (1 == 0)
			{
				continue;
			}
			if (false)
			{
				goto IL_0068;
			}
			break;
		}
	}
}
