// Decompiled with JetBrains decompiler
// Type: buDialogExtenders.FileDialogPlaces
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using Microsoft.Win32;
using ns7;
using System;
using System.Windows.Forms;

#nullable disable
namespace buDialogExtenders;

public static class FileDialogPlaces
{
  internal static readonly string string_0 = "TempPredefKey_" + Guid.NewGuid().ToString();
  private static RegistryKey registryKey_0;
  private static IntPtr intptr_0;
  private static object[] object_0;
  internal static readonly UIntPtr uintptr_0 = new UIntPtr(2147483649U /*0x80000001*/);

  public static void SetPlaces(this FileDialog fd, object[] places)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    FileDialogPlaces.Class41 class41 = new FileDialogPlaces.Class41();
    // ISSUE: reference to a compiler-generated field
    class41.fileDialog_0 = fd;
    // ISSUE: reference to a compiler-generated field
    if ((class41.fileDialog_0 == null ? 1 : (places == null ? 1 : 0)) != 0)
      return;
    if (FileDialogPlaces.object_0 == null)
      FileDialogPlaces.object_0 = new object[places.GetLength(0)];
    for (int index = 0; index < FileDialogPlaces.object_0.GetLength(0); ++index)
      FileDialogPlaces.object_0[index] = places[index];
    if (FileDialogPlaces.registryKey_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      class41.fileDialog_0.ResetPlaces();
    }
    FileDialogPlaces.smethod_0();
    // ISSUE: reference to a compiler-generated field
    if (class41.fileDialog_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    class41.fileDialog_0.Disposed += new EventHandler(class41.method_0);
  }

  public static void ResetPlaces(this FileDialog fd)
  {
    if (FileDialogPlaces.intptr_0 != IntPtr.Zero)
    {
      Class39.smethod_810(FileDialogPlaces.intptr_0);
      FileDialogPlaces.intptr_0 = IntPtr.Zero;
    }
    if (FileDialogPlaces.registryKey_0 != null)
    {
      FileDialogPlaces.registryKey_0.Close();
      FileDialogPlaces.registryKey_0 = (RegistryKey) null;
    }
    Registry.CurrentUser.DeleteSubKeyTree(FileDialogPlaces.string_0);
    FileDialogPlaces.object_0 = (object[]) null;
  }

  private static void smethod_0()
  {
    try
    {
      FileDialogPlaces.registryKey_0 = Registry.CurrentUser.CreateSubKey(FileDialogPlaces.string_0);
      FileDialogPlaces.intptr_0 = Class39.smethod_446();
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\ComDlg32\\PlacesBar");
      for (int index = 0; index < FileDialogPlaces.object_0.GetLength(0); ++index)
      {
        if (FileDialogPlaces.object_0[index] != null)
          subKey.SetValue("Place" + index.ToString(), FileDialogPlaces.object_0[index]);
      }
    }
    catch
    {
    }
  }
}
