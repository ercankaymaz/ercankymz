using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Basler.Pylon;

public static class Configuration
{
	public static void AcquireContinuous(object sender, EventArgs e)
	{
		DisableAllTriggers(sender, e);
		DisableCompression(sender, e);
		DisableGenDC(sender, e);
		SelectRangeComponent(sender, e);
		ICamera camera = (ICamera)sender;
		EnumName name = (EnumName)"AcquisitionMode";
		if (!camera.Parameters[name].CanSetValue("Continuous"))
		{
			RaiseUnsupportedFeatureException("Could not set AcquisitionMode to Continuous. Feature is not supported on this device.");
		}
		EnumName name2 = (EnumName)"AcquisitionMode";
		camera.Parameters[name2].SetValue("Continuous");
		ProbePacketSize(sender, e);
	}

	public static void AcquireContinuous(ICamera camera)
	{
		if (camera != null && camera.IsOpen)
		{
			AcquireContinuous(camera, null);
		}
	}

	public static void AcquireSingleFrame(object sender, EventArgs e)
	{
		DisableAllTriggers(sender, e);
		DisableCompression(sender, e);
		DisableGenDC(sender, e);
		SelectRangeComponent(sender, e);
		ICamera camera = (ICamera)sender;
		EnumName name = (EnumName)"AcquisitionMode";
		if (!camera.Parameters[name].CanSetValue("SingleFrame"))
		{
			RaiseUnsupportedFeatureException("Could not set AcquisitionMode to SingleFrame. Feature is not supported on this device.");
		}
		EnumName name2 = (EnumName)"AcquisitionMode";
		camera.Parameters[name2].SetValue("SingleFrame");
		ProbePacketSize(sender, e);
	}

	public static void AcquireSingleFrame(ICamera camera)
	{
		if (camera != null && camera.IsOpen)
		{
			AcquireSingleFrame(camera, null);
		}
	}

	public static void SoftwareTrigger(object sender, EventArgs e)
	{
		DisableCompression(sender, e);
		DisableGenDC(sender, e);
		SelectRangeComponent(sender, e);
		ICamera camera = (ICamera)sender;
		EnumName name = (EnumName)"TriggerSelector";
		IEnumParameter enumParameter = camera.Parameters[name];
		EnumName name2 = (EnumName)"TriggerMode";
		IEnumParameter enumParameter2 = camera.Parameters[name2];
		EnumName name3 = (EnumName)"TriggerSource";
		IEnumParameter enumParameter3 = camera.Parameters[name3];
		string text = "FrameStart";
		if (!enumParameter.CanSetValue(text))
		{
			text = "AcquisitionStart";
			if (!enumParameter.CanSetValue(text))
			{
				RaiseUnsupportedFeatureException("Could not select trigger. Neither FrameStart nor AcquisitionStart is available.");
			}
		}
		try
		{
			IEnumerator<string> enumerator = enumParameter.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					enumParameter.SetValue(current);
					if (text == current)
					{
						enumParameter2.SetValue("On");
						enumParameter3.SetValue("Software");
					}
					else
					{
						enumParameter2.SetValue("Off");
					}
				}
			}
			finally
			{
				IEnumerator<string> enumerator2 = enumerator;
				IDisposable disposable = enumerator;
				enumerator?.Dispose();
			}
		}
		finally
		{
			enumParameter.SetValue(text);
		}
		EnumName name4 = (EnumName)"AcquisitionMode";
		camera.Parameters[name4].SetValue("Continuous");
		ProbePacketSize(sender, e);
	}

	public static void SoftwareTrigger(ICamera camera)
	{
		if (camera != null && camera.IsOpen)
		{
			SoftwareTrigger(camera, null);
		}
	}

	public static void DisableAllTriggers(object sender, EventArgs e)
	{
		ICamera camera = (ICamera)sender;
		EnumName name = (EnumName)"TriggerSelector";
		IEnumParameter enumParameter = camera.Parameters[name];
		EnumName name2 = (EnumName)"TriggerMode";
		IEnumParameter enumParameter2 = camera.Parameters[name2];
		string text = ((!enumParameter.IsReadable) ? null : enumParameter.GetValue());
		try
		{
			IEnumerator<string> enumerator = enumParameter.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					enumParameter.SetValue(current);
					enumParameter2.SetValue("Off");
				}
			}
			finally
			{
				IEnumerator<string> enumerator2 = enumerator;
				IDisposable disposable = enumerator;
				enumerator?.Dispose();
			}
		}
		finally
		{
			if (text != null)
			{
				enumParameter.SetValue(text);
			}
		}
	}

	public static void DisableCompression(object sender, EventArgs e)
	{
		ICamera obj = (ICamera)sender;
		EnumName name = (EnumName)"ImageCompressionMode";
		IEnumParameter enumParameter = obj.Parameters[name];
		if (enumParameter.IsWritable)
		{
			enumParameter.SetValue("Off");
		}
	}

	public static void DisableGenDC(object sender, EventArgs e)
	{
		ICamera obj = (ICamera)sender;
		EnumName name = (EnumName)"GenDCStreamingMode";
		IEnumParameter enumParameter = obj.Parameters[name];
		if (enumParameter.IsWritable)
		{
			enumParameter.SetValue("Off");
		}
	}

	public static void SelectRangeComponent(object sender, EventArgs e)
	{
		ICamera camera = (ICamera)sender;
		EnumName name = (EnumName)"ComponentSelector";
		IEnumParameter enumParameter = camera.Parameters[name];
		BooleanName name2 = (BooleanName)"ComponentEnable";
		IBooleanParameter booleanParameter = camera.Parameters[name2];
		EnumName name3 = (EnumName)"PixelFormat";
		IEnumParameter enumParameter2 = camera.Parameters[name3];
		if (!enumParameter.IsWritable)
		{
			return;
		}
		string value = enumParameter.GetValue();
		foreach (string item in enumParameter)
		{
			enumParameter.SetValue(item);
			if (item.CompareTo("Range") == 0)
			{
				booleanParameter.SetValue(value: true);
				if (enumParameter2.CanSetValue("Mono8"))
				{
					enumParameter2.ParseAndSetValue("Mono8");
				}
				else
				{
					enumParameter2.ParseAndSetValue("Mono16");
				}
			}
			else
			{
				booleanParameter.SetValue(value: false);
			}
		}
		enumParameter.ParseAndSetValue(value);
	}

	public static void ProbePacketSize(object sender, EventArgs e)
	{
		ICamera obj = (ICamera)sender;
		CommandName name = (CommandName)"@StreamGrabber0/ProbePacketSize";
		ICommandParameter commandParameter = obj.Parameters[name];
		if (commandParameter.IsWritable)
		{
			commandParameter.Execute();
		}
	}

	private unsafe static void RaiseUnsupportedFeatureException(string msg)
	{
		throw global::_003CModule_003E.Basler_002EPylon_002ESetExceptionSource_003Cclass_0020System_003A_003ANotSupportedException_003E(new NotSupportedException(msg), (char*)System.Runtime.CompilerServices.Unsafe.AsPointer(ref global::_003CModule_003E._003F_003F_C_0040_1BM_0040ICBIINEM_0040_003F_0024AAC_003F_0024AAo_003F_0024AAn_003F_0024AAf_003F_0024AAi_003F_0024AAg_003F_0024AAu_003F_0024AAr_003F_0024AAa_003F_0024AAt_003F_0024AAi_003F_0024AAo_003F_0024AAn_0040));
	}
}
