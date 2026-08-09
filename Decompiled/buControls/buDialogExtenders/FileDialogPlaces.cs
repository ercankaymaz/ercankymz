using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Win32;
using ns27;

namespace buDialogExtenders;

public static class FileDialogPlaces
{
	[CompilerGenerated]
	private sealed class Class78
	{
		public FileDialog fileDialog_0;

		internal void method_0(object sender, EventArgs e)
		{
			if (object_0 != null && fileDialog_0 != null)
			{
				fileDialog_0.ResetPlaces();
			}
		}
	}

	internal static readonly string string_0;

	private static RegistryKey registryKey_0;

	private static IntPtr intptr_0;

	private static object[] object_0;

	internal static readonly UIntPtr uintptr_0;

	public static void SetPlaces(this FileDialog fd, object[] places)
	{
		if (fd == null || places == null)
		{
			return;
		}
		if (object_0 == null)
		{
			object_0 = new object[places.GetLength(0)];
		}
		for (int i = 0; i < object_0.GetLength(0); i++)
		{
			object_0[i] = places[i];
		}
		if (registryKey_0 != null)
		{
			fd.ResetPlaces();
		}
		smethod_0();
		if (fd == null)
		{
			return;
		}
		fd.Disposed += delegate
		{
			if (object_0 != null && fd != null)
			{
				fd.ResetPlaces();
			}
		};
	}

	static FileDialogPlaces()
	{
		string_0 = "TempPredefKey_" + Guid.NewGuid().ToString();
		uintptr_0 = new UIntPtr(2147483649u);
	}

	public static void ResetPlaces(this FileDialog fd)
	{
		if (intptr_0 != IntPtr.Zero)
		{
			Class76.smethod_810(intptr_0);
			intptr_0 = IntPtr.Zero;
		}
		if (registryKey_0 != null)
		{
			registryKey_0.Close();
			registryKey_0 = null;
		}
		Registry.CurrentUser.DeleteSubKeyTree(string_0);
		object_0 = null;
	}

	private static void smethod_0()
	{
		try
		{
			registryKey_0 = Registry.CurrentUser.CreateSubKey(string_0);
			intptr_0 = Class76.smethod_446();
			RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ComDlg32\\PlacesBar");
			for (int i = 0; i < object_0.GetLength(0); i++)
			{
				if (object_0[i] != null)
				{
					registryKey.SetValue("Place" + i, object_0[i]);
				}
			}
		}
		catch
		{
		}
	}
}
