using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Win32Types;
using ns0;
using ns1;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns8;

namespace buDialogExtenders;

[ToolboxItem(false)]
public class FileDialogControlBase : UserControl
{
	public delegate void PathChangedEventHandler(IWin32Window sender, string filePath);

	public delegate void FilterChangedEventHandler(IWin32Window sender, int index);

	public class WindowWrapper : IWin32Window
	{
		private IntPtr handle;

		public IntPtr Handle => handle;

		public WindowWrapper(IntPtr handle)
		{
			this.handle = handle;
		}
	}

	private class Class1 : NativeWindow, IDisposable
	{
		private int int_0;

		private FileDialogControlBase fileDialogControlBase_0;

		public Class1(FileDialogControlBase fileDialogControlBase_1)
		{
			fileDialogControlBase_0 = fileDialogControlBase_1;
			if (fileDialogControlBase_0 != null)
			{
				fileDialogControlBase_1.MSDialog.Disposed += method_0;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			System_002EIDisposable_002EDispose();
		}

		void IDisposable.Dispose()
		{
			if (fileDialogControlBase_0 != null)
			{
				if (fileDialogControlBase_0.MSDialog != null)
				{
					fileDialogControlBase_0.MSDialog.Disposed -= method_0;
					fileDialogControlBase_0.MSDialog.Dispose();
					if (fileDialogControlBase_0 != null)
					{
						fileDialogControlBase_0.MSDialog = null;
					}
				}
				if (fileDialogControlBase_0 != null)
				{
					if (!fileDialogControlBase_0.IsDisposed)
					{
						fileDialogControlBase_0.Dispose();
					}
					fileDialogControlBase_0 = null;
				}
			}
			DestroyHandle();
		}

		void NativeWindow.WndProc(ref Message m)
		{
			try
			{
				switch ((Enum1)m.Msg)
				{
				case Enum1.const_58:
				{
					Struct6 @struct = (Struct6)Marshal.PtrToStructure(m.LParam, typeof(Struct6));
					switch (@struct.struct3_0.uint_0)
					{
					case 4294966694u:
					{
						StringBuilder stringBuilder2 = new StringBuilder(256);
						Class5.SendMessage_2(new HandleRef(this, Class5.GetParent(base.Handle)), 1125u, (IntPtr)256, stringBuilder2);
						if (fileDialogControlBase_0 != null)
						{
							fileDialogControlBase_0.OnFileNameChanged(this, stringBuilder2.ToString());
						}
						break;
					}
					case 4294966693u:
					{
						StringBuilder stringBuilder = new StringBuilder(256);
						Class5.SendMessage_2(new HandleRef(this, Class5.GetParent(base.Handle)), 1126u, (IntPtr)256, stringBuilder);
						if (fileDialogControlBase_0 != null)
						{
							fileDialogControlBase_0.OnFolderNameChanged(this, stringBuilder.ToString());
						}
						break;
					}
					case 4294966689u:
					{
						int num = ((Struct5)Marshal.PtrToStructure(@struct.intptr_0, typeof(Struct5))).int_0;
						if (fileDialogControlBase_0 != null && int_0 != num)
						{
							int_0 = num;
							Class5.smethod_184((IWin32Window)this, num, fileDialogControlBase_0);
						}
						break;
					}
					}
					break;
				}
				case Enum1.const_106:
					switch (Class5.GetDlgCtrlID(m.LParam))
					{
					}
					break;
				}
				base.WndProc(ref m);
			}
			catch (Exception)
			{
			}
		}
	}

	internal class Class2 : NativeWindow, IDisposable
	{
		internal static readonly IntPtr intptr_0 = new IntPtr(-3);

		internal static readonly IntPtr intptr_1 = IntPtr.Zero;

		internal IntPtr intptr_2 = intptr_1;

		private bool bool_0;

		internal FileDialogControlBase fileDialogControlBase_0 = null;

		private bool bool_1 = false;

		private Size size_0;

		internal IntPtr intptr_3;

		private Struct0 struct0_0;

		private Class1 class1_0;

		private IntPtr intptr_4;

		private Struct0 struct0_1;

		private IntPtr intptr_5;

		private Struct0 struct0_2;

		private IntPtr intptr_6;

		private Struct0 struct0_3;

		private IntPtr intptr_7;

		private Struct0 struct0_4;

		private IntPtr intptr_8;

		private Struct0 struct0_5;

		private IntPtr intptr_9;

		private Struct0 struct0_6;

		private IntPtr intptr_10;

		private Struct0 struct0_7;

		private IntPtr intptr_11;

		private Struct0 struct0_8;

		private IntPtr intptr_12;

		private Struct0 struct0_9;

		private IntPtr intptr_13;

		private Struct0 struct0_10;

		private IntPtr intptr_14;

		private Struct0 struct0_11;

		private bool bool_2 = false;

		internal bool bool_3 = false;

		internal Struct1 struct1_0 = default(Struct1);

		internal Struct1 struct1_1 = default(Struct1);

		public Class2(FileDialogControlBase fileDialogControlBase_1)
		{
			fileDialogControlBase_0 = fileDialogControlBase_1;
			Class5.smethod_39(this);
			bool_1 = true;
		}

		void IDisposable.Dispose()
		{
			if (fileDialogControlBase_0 != null && !fileDialogControlBase_0.IsDisposed)
			{
				if (fileDialogControlBase_0.MSDialog != null)
				{
					fileDialogControlBase_0.MSDialog.Disposed -= method_1;
					fileDialogControlBase_0.MSDialog.Dispose();
				}
				if (fileDialogControlBase_0 != null)
				{
					fileDialogControlBase_0.MSDialog = null;
					fileDialogControlBase_0.Dispose();
				}
				fileDialogControlBase_0 = null;
			}
			if (class1_0 != null)
			{
				class1_0.System_002EIDisposable_002EDispose();
				class1_0 = null;
			}
			if (intptr_2 != IntPtr.Zero)
			{
				Class5.DestroyWindow(intptr_2);
				DestroyHandle();
				intptr_2 = IntPtr.Zero;
			}
		}

		internal bool method_0(IntPtr intptr_15, int int_0)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			Class5.GetClassName(new HandleRef(this, intptr_15), stringBuilder, stringBuilder.Capacity);
			int dlgCtrlID = Class5.GetDlgCtrlID(intptr_15);
			Class5.GetWindowInfo(new HandleRef(this, intptr_15), out Struct0 @struct);
			if (!stringBuilder.ToString().StartsWith("#32770"))
			{
				switch ((Enum0)dlgCtrlID)
				{
				case Enum0.const_11:
					intptr_4 = intptr_15;
					struct0_1 = @struct;
					break;
				case Enum0.const_2:
					intptr_10 = intptr_15;
					struct0_7 = @struct;
					break;
				case Enum0.const_0:
					intptr_8 = intptr_15;
					struct0_5 = @struct;
					fileDialogControlBase_0.intptr_1 = intptr_15;
					break;
				case Enum0.const_1:
					intptr_9 = intptr_15;
					struct0_6 = @struct;
					break;
				case Enum0.const_12:
					intptr_14 = intptr_15;
					struct0_11 = @struct;
					break;
				case Enum0.const_5:
					intptr_12 = intptr_15;
					struct0_9 = @struct;
					break;
				case Enum0.const_7:
					fileDialogControlBase_0.intptr_2 = intptr_15;
					Class5.GetWindowInfo(new HandleRef(this, intptr_15), out struct0_0);
					Class5.smethod_74(fileDialogControlBase_0);
					break;
				case Enum0.const_10:
					intptr_7 = intptr_15;
					struct0_4 = @struct;
					break;
				case Enum0.const_9:
					if (stringBuilder.ToString().ToLower() == "comboboxex32")
					{
						intptr_6 = intptr_15;
						struct0_3 = @struct;
					}
					break;
				case Enum0.const_8:
					intptr_11 = intptr_15;
					struct0_8 = @struct;
					break;
				case Enum0.const_3:
					intptr_5 = intptr_15;
					struct0_2 = @struct;
					break;
				case Enum0.const_4:
					intptr_13 = intptr_15;
					struct0_10 = @struct;
					break;
				}
				return true;
			}
			class1_0 = new Class1(fileDialogControlBase_0);
			class1_0.AssignHandle(intptr_15);
			return true;
		}

		internal void method_1(object sender, EventArgs e)
		{
			System_002EIDisposable_002EDispose();
		}

		void NativeWindow.WndProc(ref Message m)
		{
			Struct1 @struct = default(Struct1);
			switch ((Enum1)m.Msg)
			{
			case Enum1.const_106:
				switch (Class5.GetDlgCtrlID(m.LParam))
				{
				}
				break;
			case Enum1.const_5:
				if (bool_1 && !bool_2)
				{
					bool_1 = false;
					intptr_3 = m.LParam;
					ReleaseHandle();
					AssignHandle(intptr_3);
					Class5.GetWindowRect(new HandleRef(this, intptr_3), ref fileDialogControlBase_0.struct1_0);
					fileDialogControlBase_0.intptr_0 = intptr_3;
				}
				break;
			case Enum1.const_4:
				Class5.GetClientRect(new HandleRef(this, intptr_3), ref @struct);
				switch (fileDialogControlBase_0.FileDlgStartLocation)
				{
				case AddonWindowLocation.Right:
					if (!bool_3 && Class5.smethod_2() == 0)
					{
						uint_0 = @struct.method_1();
					}
					if (@struct.method_1() != fileDialogControlBase_0.Height)
					{
						fileDialogControlBase_0.Height = (int)@struct.method_1();
					}
					break;
				case AddonWindowLocation.Bottom:
					if (!bool_3 && Class5.smethod_144() == 0)
					{
						uint_1 = @struct.method_0();
					}
					if (@struct.method_0() != fileDialogControlBase_0.Width)
					{
						fileDialogControlBase_0.Width = (int)@struct.method_0();
					}
					break;
				}
				break;
			case Enum1.const_21:
			{
				Class5.smethod_130(this);
				Class5.GetWindowRect(new HandleRef(this, intptr_3), ref @struct);
				int int_ = ((fileDialogControlBase_0.Parent != null) ? fileDialogControlBase_0.Parent.Top : @struct.int_1);
				int int_2 = ((fileDialogControlBase_0.Parent != null) ? fileDialogControlBase_0.Parent.Right : @struct.int_2);
				Struct1 struct2 = default(Struct1);
				Class5.GetClientRect(new HandleRef(this, intptr_3), ref struct2);
				int num = (int)(@struct.method_1() - struct2.method_1());
				int num2 = (int)(@struct.method_0() - struct2.method_0());
				int num3 = 0;
				int num4 = 0;
				switch (fileDialogControlBase_0.FileDlgStartLocation)
				{
				case AddonWindowLocation.Right:
					num3 = Math.Max(Class5.smethod_191(fileDialogControlBase_0).Height + num, (int)Class5.smethod_2());
					Class5.SetWindowPos(intptr_3, (IntPtr)1, int_2, int_, (int)@struct.method_0(), num3, Enum2.flag_1 | Enum2.flag_2);
					break;
				case AddonWindowLocation.Bottom:
					num4 = Math.Max(Class5.smethod_191(fileDialogControlBase_0).Width + num2, (int)Class5.smethod_144());
					Class5.SetWindowPos(intptr_3, (IntPtr)1, int_2, int_, num4, (int)@struct.method_1(), Enum2.flag_1 | Enum2.flag_2);
					break;
				}
				break;
			}
			case Enum1.const_53:
			{
				if (bool_2 || bool_3 || bool_0)
				{
					break;
				}
				Struct2 structure = (Struct2)Marshal.PtrToStructure(m.LParam, typeof(Struct2));
				if (structure.uint_0 == 0 || (structure.uint_0 & 1) == 1)
				{
					break;
				}
				switch (fileDialogControlBase_0.FileDlgStartLocation)
				{
				case AddonWindowLocation.Bottom:
					size_0 = new Size(structure.int_2, structure.int_3);
					structure.int_3 += fileDialogControlBase_0.Height;
					Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: true);
					@struct = default(Struct1);
					Class5.GetClientRect(new HandleRef(this, intptr_3), ref @struct);
					if (fileDialogControlBase_0.Width < (int)@struct.method_0())
					{
						fileDialogControlBase_0.Width = (int)@struct.method_0();
					}
					break;
				case AddonWindowLocation.Right:
					size_0 = new Size(structure.int_2, structure.int_3);
					structure.int_2 += fileDialogControlBase_0.Width;
					Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: true);
					@struct = default(Struct1);
					Class5.GetClientRect(new HandleRef(this, intptr_3), ref @struct);
					if (fileDialogControlBase_0.Height < (int)@struct.method_1())
					{
						fileDialogControlBase_0.Height = (int)@struct.method_1();
					}
					break;
				case AddonWindowLocation.BottomRight:
					size_0 = new Size(structure.int_2, structure.int_3);
					structure.int_3 += fileDialogControlBase_0.Height;
					structure.int_2 += fileDialogControlBase_0.Width;
					Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: true);
					break;
				}
				bool_0 = true;
				break;
			}
			case Enum1.const_146:
				Class5.GetClientRect(new HandleRef(this, intptr_3), ref @struct);
				switch (fileDialogControlBase_0.FileDlgStartLocation)
				{
				case AddonWindowLocation.Bottom:
					if (@struct.method_1() != fileDialogControlBase_0.Height)
					{
						Class5.SetWindowPos(fileDialogControlBase_0.Handle, (IntPtr)1, 0, 0, (int)@struct.method_0(), fileDialogControlBase_0.Height, Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
					}
					break;
				case AddonWindowLocation.Right:
					if (@struct.method_1() != fileDialogControlBase_0.Height)
					{
						Class5.SetWindowPos(fileDialogControlBase_0.Handle, (IntPtr)1, 0, 0, fileDialogControlBase_0.Width, (int)@struct.method_1(), Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
					}
					break;
				case AddonWindowLocation.BottomRight:
					if (@struct.method_0() != fileDialogControlBase_0.Width || @struct.method_1() != fileDialogControlBase_0.Height)
					{
						Class5.SetWindowPos(fileDialogControlBase_0.Handle, (IntPtr)1, (int)@struct.method_0(), (int)@struct.method_1(), (int)@struct.method_0(), (int)@struct.method_1(), Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
					}
					break;
				}
				break;
			case Enum1.const_166:
				if (m.WParam == (IntPtr)1)
				{
					bool_2 = true;
					Class5.SetWindowPos(intptr_3, IntPtr.Zero, 0, 0, 0, 0, Enum2.flag_0 | Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_7 | Enum2.flag_9);
					Class5.GetWindowRect(new HandleRef(this, intptr_3), ref struct1_0);
					Class5.SetWindowPos(intptr_3, IntPtr.Zero, struct1_0.int_0, struct1_0.int_1, size_0.Width, size_0.Height, Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9);
				}
				break;
			}
			base.WndProc(ref m);
		}
	}

	[CompilerGenerated]
	private PathChangedEventHandler pathChangedEventHandler_0;

	[CompilerGenerated]
	private PathChangedEventHandler pathChangedEventHandler_1;

	[CompilerGenerated]
	internal FilterChangedEventHandler filterChangedEventHandler_0;

	[CompilerGenerated]
	private CancelEventHandler cancelEventHandler_0;

	public static bool SubFolderSelected;

	internal FileDialog fileDialog_0;

	internal NativeWindow nativeWindow_0;

	private AddonWindowLocation addonWindowLocation_0 = AddonWindowLocation.Right;

	private FolderViewMode folderViewMode_0 = FolderViewMode.Default;

	internal IntPtr intptr_0 = IntPtr.Zero;

	private FileDialogType fileDialogType_0;

	internal string string_0 = string.Empty;

	internal string string_1 = "All files (*.*)|*.*";

	internal string string_2 = "jpg";

	internal string string_3 = string.Empty;

	private string string_4 = "Save";

	private bool bool_0 = false;

	private string string_5 = "&Open";

	internal int int_0 = 1;

	internal bool bool_1 = true;

	internal bool bool_2 = true;

	private bool bool_3 = true;

	internal bool bool_4 = true;

	internal bool bool_5;

	private Struct1 struct1_0 = default(Struct1);

	private IntPtr intptr_1 = IntPtr.Zero;

	internal bool bool_6;

	internal IntPtr intptr_2;

	internal static uint uint_0;

	internal static uint uint_1;

	public bool SubFileSelected = false;

	internal Size size_0;

	private IContainer icontainer_0 = null;

	[Browsable(false)]
	public string[] FileDlgFileNames => (!base.DesignMode) ? MSDialog.FileNames : null;

	[Browsable(false)]
	public FileDialog MSDialog
	{
		get
		{
			return fileDialog_0;
		}
		set
		{
			fileDialog_0 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(AddonWindowLocation.Right)]
	public AddonWindowLocation FileDlgStartLocation
	{
		get
		{
			return addonWindowLocation_0;
		}
		set
		{
			addonWindowLocation_0 = value;
			if (base.DesignMode)
			{
				Refresh();
			}
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(FolderViewMode.Default)]
	public FolderViewMode FileDlgDefaultViewMode
	{
		get
		{
			return folderViewMode_0;
		}
		set
		{
			folderViewMode_0 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(FileDialogType.OpenFileDlg)]
	public FileDialogType FileDlgType
	{
		get
		{
			return fileDialogType_0;
		}
		set
		{
			fileDialogType_0 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("")]
	public string FileDlgInitialDirectory
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.InitialDirectory : string_0;
		}
		set
		{
			string_0 = value;
			if (!base.DesignMode && MSDialog != null)
			{
				MSDialog.InitialDirectory = value;
			}
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("")]
	public string FileDlgFileName
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.FileName : string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("")]
	public string FileDlgCaption
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("&Open")]
	public string FileDlgOkCaption
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("jpg")]
	public string FileDlgDefaultExt
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.DefaultExt : string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue("All files (*.*)|*.*")]
	public string FileDlgFilter
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.Filter : string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(1)]
	public int FileDlgFilterIndex
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.FilterIndex : int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(true)]
	public bool FileDlgAddExtension
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.AddExtension : bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(true)]
	public bool FileDlgEnableOkBtn
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
			if (!base.DesignMode && MSDialog != null && intptr_1 != IntPtr.Zero)
			{
				Class5.EnableWindow(intptr_1, bool_3);
			}
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(true)]
	public bool FileDlgCheckFileExists
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.CheckFileExists : bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(false)]
	public bool FileDlgShowHelp
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.ShowHelp : bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	[Category("FileDialogExtenders")]
	[DefaultValue(true)]
	public bool FileDlgDereferenceLinks
	{
		get
		{
			return (!base.DesignMode) ? MSDialog.DereferenceLinks : bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	[Category("FileDialogExtenders")]
	public event PathChangedEventHandler EventFileNameChanged
	{
		[CompilerGenerated]
		add
		{
			PathChangedEventHandler pathChangedEventHandler = pathChangedEventHandler_0;
			PathChangedEventHandler pathChangedEventHandler2;
			do
			{
				pathChangedEventHandler2 = pathChangedEventHandler;
				PathChangedEventHandler value2 = (PathChangedEventHandler)Delegate.Combine(pathChangedEventHandler2, value);
				pathChangedEventHandler = Interlocked.CompareExchange(ref pathChangedEventHandler_0, value2, pathChangedEventHandler2);
			}
			while ((object)pathChangedEventHandler != pathChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathChangedEventHandler pathChangedEventHandler = pathChangedEventHandler_0;
			PathChangedEventHandler pathChangedEventHandler2;
			do
			{
				pathChangedEventHandler2 = pathChangedEventHandler;
				PathChangedEventHandler value2 = (PathChangedEventHandler)Delegate.Remove(pathChangedEventHandler2, value);
				pathChangedEventHandler = Interlocked.CompareExchange(ref pathChangedEventHandler_0, value2, pathChangedEventHandler2);
			}
			while ((object)pathChangedEventHandler != pathChangedEventHandler2);
		}
	}

	[Category("FileDialogExtenders")]
	public event PathChangedEventHandler EventFolderNameChanged
	{
		[CompilerGenerated]
		add
		{
			PathChangedEventHandler pathChangedEventHandler = pathChangedEventHandler_1;
			PathChangedEventHandler pathChangedEventHandler2;
			do
			{
				pathChangedEventHandler2 = pathChangedEventHandler;
				PathChangedEventHandler value2 = (PathChangedEventHandler)Delegate.Combine(pathChangedEventHandler2, value);
				pathChangedEventHandler = Interlocked.CompareExchange(ref pathChangedEventHandler_1, value2, pathChangedEventHandler2);
			}
			while ((object)pathChangedEventHandler != pathChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PathChangedEventHandler pathChangedEventHandler = pathChangedEventHandler_1;
			PathChangedEventHandler pathChangedEventHandler2;
			do
			{
				pathChangedEventHandler2 = pathChangedEventHandler;
				PathChangedEventHandler value2 = (PathChangedEventHandler)Delegate.Remove(pathChangedEventHandler2, value);
				pathChangedEventHandler = Interlocked.CompareExchange(ref pathChangedEventHandler_1, value2, pathChangedEventHandler2);
			}
			while ((object)pathChangedEventHandler != pathChangedEventHandler2);
		}
	}

	[Category("FileDialogExtenders")]
	public event FilterChangedEventHandler EventFilterChanged
	{
		[CompilerGenerated]
		add
		{
			FilterChangedEventHandler filterChangedEventHandler = filterChangedEventHandler_0;
			FilterChangedEventHandler filterChangedEventHandler2;
			do
			{
				filterChangedEventHandler2 = filterChangedEventHandler;
				FilterChangedEventHandler value2 = (FilterChangedEventHandler)Delegate.Combine(filterChangedEventHandler2, value);
				filterChangedEventHandler = Interlocked.CompareExchange(ref filterChangedEventHandler_0, value2, filterChangedEventHandler2);
			}
			while ((object)filterChangedEventHandler != filterChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			FilterChangedEventHandler filterChangedEventHandler = filterChangedEventHandler_0;
			FilterChangedEventHandler filterChangedEventHandler2;
			do
			{
				filterChangedEventHandler2 = filterChangedEventHandler;
				FilterChangedEventHandler value2 = (FilterChangedEventHandler)Delegate.Remove(filterChangedEventHandler2, value);
				filterChangedEventHandler = Interlocked.CompareExchange(ref filterChangedEventHandler_0, value2, filterChangedEventHandler2);
			}
			while ((object)filterChangedEventHandler != filterChangedEventHandler2);
		}
	}

	[Category("FileDialogExtenders")]
	public event CancelEventHandler EventClosingDialog
	{
		[CompilerGenerated]
		add
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelEventHandler cancelEventHandler = cancelEventHandler_0;
			CancelEventHandler cancelEventHandler2;
			do
			{
				cancelEventHandler2 = cancelEventHandler;
				CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
				cancelEventHandler = Interlocked.CompareExchange(ref cancelEventHandler_0, value2, cancelEventHandler2);
			}
			while ((object)cancelEventHandler != cancelEventHandler2);
		}
	}

	public FileDialogControlBase()
	{
		Class5.smethod_29(this);
	}

	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (!base.DesignMode && MSDialog != null)
		{
			MSDialog.FileOk += method_1;
			MSDialog.Disposed += method_0;
			MSDialog.HelpRequest += method_2;
			FileDlgEnableOkBtn = true;
			Class5.SetWindowText(new HandleRef(nativeWindow_0, nativeWindow_0.Handle), string_4);
			Class5.SetWindowText(new HandleRef(this, intptr_1), string_5);
		}
	}

	public void SortViewByColumn(int index)
	{
		try
		{
			IntPtr intPtr = Class5.FindWindowEx(nativeWindow_0.Handle, IntPtr.Zero, "SHELLDLL_DefView", "");
			if (intPtr != IntPtr.Zero)
			{
				Class5.SendMessage(new HandleRef(this, intPtr), 273u, (IntPtr)28716, IntPtr.Zero);
				IntPtr handle = Class5.FindWindowEx_1(intPtr, IntPtr.Zero, "SysListView32", IntPtr.Zero);
				IntPtr intPtr2 = Class5.FindWindowEx_1(handle, IntPtr.Zero, "SysHeader32", IntPtr.Zero);
				Struct4 structure = new Struct4
				{
					struct3_0 = 
					{
						intptr_0 = intPtr2,
						uint_0 = 4294966974u
					},
					int_0 = index,
					int_1 = 0
				};
				IntPtr intPtr3 = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
				try
				{
					Marshal.StructureToPtr(structure, intPtr3, fDeleteOld: false);
					Class5.SendMessage(new HandleRef(this, handle), 78u, IntPtr.Zero, intPtr3);
					Class5.SendMessage(new HandleRef(this, handle), 78u, IntPtr.Zero, intPtr3);
					return;
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr3);
				}
			}
		}
		catch
		{
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!base.IsDisposed)
		{
			if (MSDialog != null)
			{
				MSDialog.FileOk -= method_1;
				MSDialog.Disposed -= method_0;
				MSDialog.HelpRequest -= method_2;
				MSDialog.Dispose();
				MSDialog = null;
			}
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}
	}

	public virtual void OnFileNameChanged(IWin32Window sender, string fileName)
	{
		if (pathChangedEventHandler_0 != null)
		{
			pathChangedEventHandler_0(sender, fileName);
		}
	}

	public void OnFolderNameChanged(IWin32Window sender, string folderName)
	{
		if (pathChangedEventHandler_1 != null)
		{
			pathChangedEventHandler_1(sender, folderName);
		}
		Class5.smethod_74(this);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		if (base.DesignMode)
		{
			Graphics graphics = e.Graphics;
			HatchBrush hatchBrush = null;
			Pen pen = null;
			try
			{
				switch (FileDlgStartLocation)
				{
				case AddonWindowLocation.Bottom:
					hatchBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.Black, Color.Red);
					pen = new Pen(hatchBrush, 5f);
					graphics.DrawLine(pen, 0, 0, base.Width, 0);
					break;
				case AddonWindowLocation.Right:
					hatchBrush = new HatchBrush(HatchStyle.NarrowHorizontal, Color.Black, Color.Red);
					pen = new Pen(hatchBrush, 5f);
					graphics.DrawLine(pen, 0, 0, 0, base.Height);
					break;
				default:
					hatchBrush = new HatchBrush(HatchStyle.Sphere, Color.Black, Color.Red);
					pen = new Pen(hatchBrush, 5f);
					graphics.DrawLine(pen, 0, 0, 4, 4);
					break;
				}
			}
			finally
			{
				pen?.Dispose();
				hatchBrush?.Dispose();
			}
		}
		base.OnPaint(e);
	}

	public DialogResult ShowDialog()
	{
		return ShowDialog(null);
	}

	protected virtual void OnPrepareMSDialog()
	{
		Class5.smethod_212(this);
	}

	public DialogResult ShowDialog(IWin32Window owner)
	{
		DialogResult result = DialogResult.Cancel;
		if (!base.IsDisposed)
		{
			if (owner == null || owner.Handle == IntPtr.Zero)
			{
				WindowWrapper windowWrapper = new WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
				owner = windowWrapper;
			}
			size_0 = base.Size;
			fileDialog_0 = ((FileDlgType != FileDialogType.OpenFileDlg) ? ((FileDialog)new SaveFileDialog()) : ((FileDialog)new OpenFileDialog()));
			nativeWindow_0 = new Class2(this);
			OnPrepareMSDialog();
			if (!bool_6)
			{
				Class5.smethod_212(this);
			}
			try
			{
				PropertyInfo property = MSDialog.GetType().GetProperty("AutoUpgradeEnabled");
				if (property != null)
				{
					property.SetValue(MSDialog, false, null);
				}
				result = fileDialog_0.ShowDialog(owner);
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception ex2)
			{
				MessageBox.Show("unable to get the modal dialog handle", ex2.Message);
			}
			return result;
		}
		return result;
	}

	private void method_0(object sender, EventArgs e)
	{
		Dispose(disposing: true);
	}

	private void method_1(object sender, CancelEventArgs e)
	{
		if (cancelEventHandler_0 != null)
		{
			cancelEventHandler_0(this, e);
		}
	}

	private void method_2(object sender, EventArgs e)
	{
		OnHelpRequested(new HelpEventArgs(default(Point)));
	}
}
