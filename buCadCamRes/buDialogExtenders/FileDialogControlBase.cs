// Decompiled with JetBrains decompiler
// Type: buDialogExtenders.FileDialogControlBase
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns0;
using ns1;
using ns2;
using ns3;
using ns4;
using ns5;
using ns6;
using ns8;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Win32Types;

#nullable disable
namespace buDialogExtenders;

[ToolboxItem(false)]
public class FileDialogControlBase : UserControl
{
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
  private Struct1 struct1_0 = new Struct1();
  private IntPtr intptr_1 = IntPtr.Zero;
  internal bool bool_6;
  internal IntPtr intptr_2;
  internal static uint uint_0;
  internal static uint uint_1;
  public bool SubFileSelected = false;
  internal Size size_0;
  private IContainer icontainer_0 = (IContainer) null;

  [Category("FileDialogExtenders")]
  public event FileDialogControlBase.PathChangedEventHandler EventFileNameChanged;

  [Category("FileDialogExtenders")]
  public event FileDialogControlBase.PathChangedEventHandler EventFolderNameChanged;

  [Category("FileDialogExtenders")]
  public event FileDialogControlBase.FilterChangedEventHandler EventFilterChanged;

  [Category("FileDialogExtenders")]
  public event CancelEventHandler EventClosingDialog;

  public FileDialogControlBase() => Class5.smethod_29(this);

  [Browsable(false)]
  public string[] FileDlgFileNames => this.DesignMode ? (string[]) null : this.MSDialog.FileNames;

  [Browsable(false)]
  public FileDialog MSDialog
  {
    set => this.fileDialog_0 = value;
    get => this.fileDialog_0;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(AddonWindowLocation.Right)]
  public AddonWindowLocation FileDlgStartLocation
  {
    get => this.addonWindowLocation_0;
    set
    {
      this.addonWindowLocation_0 = value;
      if (!this.DesignMode)
        return;
      this.Refresh();
    }
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(FolderViewMode.Default)]
  public FolderViewMode FileDlgDefaultViewMode
  {
    get => this.folderViewMode_0;
    set => this.folderViewMode_0 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(FileDialogType.OpenFileDlg)]
  public FileDialogType FileDlgType
  {
    get => this.fileDialogType_0;
    set => this.fileDialogType_0 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("")]
  public string FileDlgInitialDirectory
  {
    get => this.DesignMode ? this.string_0 : this.MSDialog.InitialDirectory;
    set
    {
      this.string_0 = value;
      if ((this.DesignMode ? 0 : (this.MSDialog != null ? 1 : 0)) == 0)
        return;
      this.MSDialog.InitialDirectory = value;
    }
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("")]
  public string FileDlgFileName
  {
    get => this.DesignMode ? this.string_3 : this.MSDialog.FileName;
    set => this.string_3 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("")]
  public string FileDlgCaption
  {
    get => this.string_4;
    set => this.string_4 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("&Open")]
  public string FileDlgOkCaption
  {
    get => this.string_5;
    set => this.string_5 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("jpg")]
  public string FileDlgDefaultExt
  {
    get => this.DesignMode ? this.string_2 : this.MSDialog.DefaultExt;
    set => this.string_2 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue("All files (*.*)|*.*")]
  public string FileDlgFilter
  {
    get => this.DesignMode ? this.string_1 : this.MSDialog.Filter;
    set => this.string_1 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(1)]
  public int FileDlgFilterIndex
  {
    get => this.DesignMode ? this.int_0 : this.MSDialog.FilterIndex;
    set => this.int_0 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(true)]
  public bool FileDlgAddExtension
  {
    get => !this.DesignMode ? this.MSDialog.AddExtension : this.bool_1;
    set => this.bool_1 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(true)]
  public bool FileDlgEnableOkBtn
  {
    get => this.bool_3;
    set
    {
      this.bool_3 = value;
      if ((this.DesignMode || this.MSDialog == null ? 0 : (this.intptr_1 != IntPtr.Zero ? 1 : 0)) == 0)
        return;
      Class5.EnableWindow(this.intptr_1, this.bool_3);
    }
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(true)]
  public bool FileDlgCheckFileExists
  {
    get => !this.DesignMode ? this.MSDialog.CheckFileExists : this.bool_2;
    set => this.bool_2 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(false)]
  public bool FileDlgShowHelp
  {
    get => !this.DesignMode ? this.MSDialog.ShowHelp : this.bool_5;
    set => this.bool_5 = value;
  }

  [Category("FileDialogExtenders")]
  [DefaultValue(true)]
  public bool FileDlgDereferenceLinks
  {
    get => !this.DesignMode ? this.MSDialog.DereferenceLinks : this.bool_4;
    set => this.bool_4 = value;
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    if (this.DesignMode || this.MSDialog == null)
      return;
    this.MSDialog.FileOk += new CancelEventHandler(this.method_1);
    this.MSDialog.Disposed += new EventHandler(this.method_0);
    this.MSDialog.HelpRequest += new EventHandler(this.method_2);
    this.FileDlgEnableOkBtn = true;
    Class5.SetWindowText(new HandleRef((object) this.nativeWindow_0, this.nativeWindow_0.Handle), this.string_4);
    Class5.SetWindowText(new HandleRef((object) this, this.intptr_1), this.string_5);
  }

  public void SortViewByColumn(int index)
  {
    try
    {
      IntPtr windowEx = Class5.FindWindowEx(this.nativeWindow_0.Handle, IntPtr.Zero, "SHELLDLL_DefView", "");
      if (!(windowEx != IntPtr.Zero))
        return;
      Class5.SendMessage(new HandleRef((object) this, windowEx), 273U, (IntPtr) 28716, IntPtr.Zero);
      IntPtr windowEx1_1 = Class5.FindWindowEx_1(windowEx, IntPtr.Zero, "SysListView32", IntPtr.Zero);
      IntPtr windowEx1_2 = Class5.FindWindowEx_1(windowEx1_1, IntPtr.Zero, "SysHeader32", IntPtr.Zero);
      Struct4 structure = new Struct4();
      structure.struct3_0.intptr_0 = windowEx1_2;
      structure.struct3_0.uint_0 = 4294966974U;
      structure.int_0 = index;
      structure.int_1 = 0;
      IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf<Struct4>(structure));
      try
      {
        Marshal.StructureToPtr<Struct4>(structure, num, false);
        Class5.SendMessage(new HandleRef((object) this, windowEx1_1), 78U, IntPtr.Zero, num);
        Class5.SendMessage(new HandleRef((object) this, windowEx1_1), 78U, IntPtr.Zero, num);
      }
      finally
      {
        Marshal.FreeHGlobal(num);
      }
    }
    catch
    {
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (this.IsDisposed)
      return;
    if (this.MSDialog != null)
    {
      this.MSDialog.FileOk -= new CancelEventHandler(this.method_1);
      this.MSDialog.Disposed -= new EventHandler(this.method_0);
      this.MSDialog.HelpRequest -= new EventHandler(this.method_2);
      this.MSDialog.Dispose();
      this.MSDialog = (FileDialog) null;
    }
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }

  public virtual void OnFileNameChanged(IWin32Window sender, string fileName)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.pathChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.pathChangedEventHandler_0(sender, fileName);
  }

  public void OnFolderNameChanged(IWin32Window sender, string folderName)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.pathChangedEventHandler_1 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.pathChangedEventHandler_1(sender, folderName);
    }
    Class5.smethod_74(this);
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    if (this.DesignMode)
    {
      Graphics graphics = e.Graphics;
      HatchBrush hatchBrush = (HatchBrush) null;
      Pen pen = (Pen) null;
      try
      {
        switch (this.FileDlgStartLocation)
        {
          case AddonWindowLocation.Right:
            hatchBrush = new HatchBrush(HatchStyle.NarrowHorizontal, Color.Black, Color.Red);
            pen = new Pen((Brush) hatchBrush, 5f);
            graphics.DrawLine(pen, 0, 0, 0, this.Height);
            break;
          case AddonWindowLocation.Bottom:
            hatchBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.Black, Color.Red);
            pen = new Pen((Brush) hatchBrush, 5f);
            graphics.DrawLine(pen, 0, 0, this.Width, 0);
            break;
          default:
            hatchBrush = new HatchBrush(HatchStyle.Sphere, Color.Black, Color.Red);
            pen = new Pen((Brush) hatchBrush, 5f);
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

  public DialogResult ShowDialog() => this.ShowDialog((IWin32Window) null);

  protected virtual void OnPrepareMSDialog() => Class5.smethod_212(this);

  public DialogResult ShowDialog(IWin32Window owner)
  {
    DialogResult dialogResult1 = DialogResult.Cancel;
    DialogResult dialogResult2;
    if (this.IsDisposed)
    {
      dialogResult2 = dialogResult1;
    }
    else
    {
      if ((owner == null ? 1 : (owner.Handle == IntPtr.Zero ? 1 : 0)) != 0)
        owner = (IWin32Window) new FileDialogControlBase.WindowWrapper(Process.GetCurrentProcess().MainWindowHandle);
      this.size_0 = this.Size;
      this.fileDialog_0 = this.FileDlgType == FileDialogType.OpenFileDlg ? (FileDialog) new OpenFileDialog() : (FileDialog) new SaveFileDialog();
      this.nativeWindow_0 = (NativeWindow) new FileDialogControlBase.Class2(this);
      this.OnPrepareMSDialog();
      if (!this.bool_6)
        Class5.smethod_212(this);
      try
      {
        PropertyInfo property = this.MSDialog.GetType().GetProperty("AutoUpgradeEnabled");
        if (property != (PropertyInfo) null)
          property.SetValue((object) this.MSDialog, (object) false, (object[]) null);
        dialogResult1 = this.fileDialog_0.ShowDialog(owner);
      }
      catch (ObjectDisposedException ex)
      {
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("unable to get the modal dialog handle", ex.Message);
      }
      dialogResult2 = dialogResult1;
    }
    return dialogResult2;
  }

  private void method_0(object sender, EventArgs e) => this.Dispose(true);

  private void method_1(object sender, CancelEventArgs e)
  {
    // ISSUE: reference to a compiler-generated field
    if (this.cancelEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.cancelEventHandler_0((object) this, e);
  }

  private void method_2(object sender, EventArgs e)
  {
    this.OnHelpRequested(new HelpEventArgs(new Point()));
  }

  public delegate void PathChangedEventHandler(IWin32Window sender, string filePath);

  public delegate void FilterChangedEventHandler(IWin32Window sender, int index);

  public class WindowWrapper : IWin32Window
  {
    private IntPtr handle;

    public WindowWrapper(IntPtr handle) => this.handle = handle;

    public IntPtr Handle => this.handle;
  }

  private class Class1 : NativeWindow, IDisposable
  {
    private int int_0;
    private FileDialogControlBase fileDialogControlBase_0;

    public Class1(FileDialogControlBase fileDialogControlBase_1)
    {
      this.fileDialogControlBase_0 = fileDialogControlBase_1;
      if (this.fileDialogControlBase_0 == null)
        return;
      fileDialogControlBase_1.MSDialog.Disposed += new EventHandler(this.method_0);
    }

    private void method_0(object sender, EventArgs e)
    {
      this.System\u002EIDisposable\u002EDispose();
    }

    void IDisposable.Dispose()
    {
      if (this.fileDialogControlBase_0 != null)
      {
        if (this.fileDialogControlBase_0.MSDialog != null)
        {
          this.fileDialogControlBase_0.MSDialog.Disposed -= new EventHandler(this.method_0);
          this.fileDialogControlBase_0.MSDialog.Dispose();
          if (this.fileDialogControlBase_0 != null)
            this.fileDialogControlBase_0.MSDialog = (FileDialog) null;
        }
        if (this.fileDialogControlBase_0 != null)
        {
          if (!this.fileDialogControlBase_0.IsDisposed)
            this.fileDialogControlBase_0.Dispose();
          this.fileDialogControlBase_0 = (FileDialogControlBase) null;
        }
      }
      this.DestroyHandle();
    }

    virtual void NativeWindow.WndProc(ref Message m)
    {
      try
      {
        switch ((Enum1) m.Msg)
        {
          case Enum1.const_58:
            Struct6 structure = (Struct6) Marshal.PtrToStructure(m.LParam, typeof (Struct6));
            switch (structure.struct3_0.uint_0)
            {
              case 4294966689:
                int int0 = ((Struct5) Marshal.PtrToStructure(structure.intptr_0, typeof (Struct5))).int_0;
                if ((this.fileDialogControlBase_0 == null ? 0 : (this.int_0 != int0 ? 1 : 0)) != 0)
                {
                  this.int_0 = int0;
                  Class5.smethod_184((IWin32Window) this, int0, this.fileDialogControlBase_0);
                  break;
                }
                break;
              case 4294966693:
                StringBuilder stringBuilder_0_1 = new StringBuilder(256 /*0x0100*/);
                Class5.SendMessage_2(new HandleRef((object) this, Class5.GetParent(this.Handle)), 1126U, (IntPtr) 256 /*0x0100*/, stringBuilder_0_1);
                if (this.fileDialogControlBase_0 != null)
                {
                  this.fileDialogControlBase_0.OnFolderNameChanged((IWin32Window) this, stringBuilder_0_1.ToString());
                  break;
                }
                break;
              case 4294966694:
                StringBuilder stringBuilder_0_2 = new StringBuilder(256 /*0x0100*/);
                Class5.SendMessage_2(new HandleRef((object) this, Class5.GetParent(this.Handle)), 1125U, (IntPtr) 256 /*0x0100*/, stringBuilder_0_2);
                if (this.fileDialogControlBase_0 != null)
                {
                  this.fileDialogControlBase_0.OnFileNameChanged((IWin32Window) this, stringBuilder_0_2.ToString());
                  break;
                }
                break;
            }
            break;
          case Enum1.const_106:
            switch (Class5.GetDlgCtrlID(m.LParam))
            {
            }
            break;
        }
        // ISSUE: explicit non-virtual call
        __nonvirtual (((NativeWindow) this).WndProc(ref m));
      }
      catch (Exception ex)
      {
      }
    }
  }

  internal class Class2 : NativeWindow, IDisposable
  {
    internal static readonly IntPtr intptr_0 = new IntPtr(-3);
    internal static readonly IntPtr intptr_1 = IntPtr.Zero;
    internal IntPtr intptr_2 = FileDialogControlBase.Class2.intptr_1;
    private bool bool_0;
    internal FileDialogControlBase fileDialogControlBase_0 = (FileDialogControlBase) null;
    private bool bool_1 = false;
    private Size size_0;
    internal IntPtr intptr_3;
    private Struct0 struct0_0;
    private FileDialogControlBase.Class1 class1_0;
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
    internal Struct1 struct1_0 = new Struct1();
    internal Struct1 struct1_1 = new Struct1();

    public Class2(FileDialogControlBase fileDialogControlBase_1)
    {
      this.fileDialogControlBase_0 = fileDialogControlBase_1;
      Class5.smethod_39(this);
      this.bool_1 = true;
    }

    void IDisposable.Dispose()
    {
      if (this.fileDialogControlBase_0 != null && !this.fileDialogControlBase_0.IsDisposed)
      {
        if (this.fileDialogControlBase_0.MSDialog != null)
        {
          this.fileDialogControlBase_0.MSDialog.Disposed -= new EventHandler(this.method_1);
          this.fileDialogControlBase_0.MSDialog.Dispose();
        }
        if (this.fileDialogControlBase_0 != null)
        {
          this.fileDialogControlBase_0.MSDialog = (FileDialog) null;
          this.fileDialogControlBase_0.Dispose();
        }
        this.fileDialogControlBase_0 = (FileDialogControlBase) null;
      }
      if (this.class1_0 != null)
      {
        this.class1_0.System\u002EIDisposable\u002EDispose();
        this.class1_0 = (FileDialogControlBase.Class1) null;
      }
      if (!(this.intptr_2 != IntPtr.Zero))
        return;
      Class5.DestroyWindow(this.intptr_2);
      this.DestroyHandle();
      this.intptr_2 = IntPtr.Zero;
    }

    internal bool method_0(IntPtr intptr_15, int int_0)
    {
      StringBuilder stringBuilder_0 = new StringBuilder(256 /*0x0100*/);
      Class5.GetClassName(new HandleRef((object) this, intptr_15), stringBuilder_0, stringBuilder_0.Capacity);
      int dlgCtrlId = Class5.GetDlgCtrlID(intptr_15);
      Struct0 struct0_0;
      Class5.GetWindowInfo(new HandleRef((object) this, intptr_15), out struct0_0);
      bool flag;
      if (stringBuilder_0.ToString().StartsWith("#32770"))
      {
        this.class1_0 = new FileDialogControlBase.Class1(this.fileDialogControlBase_0);
        this.class1_0.AssignHandle(intptr_15);
        flag = true;
      }
      else
      {
        switch ((Enum0) dlgCtrlId)
        {
          case Enum0.const_0:
            this.intptr_8 = intptr_15;
            this.struct0_5 = struct0_0;
            this.fileDialogControlBase_0.intptr_1 = intptr_15;
            break;
          case Enum0.const_1:
            this.intptr_9 = intptr_15;
            this.struct0_6 = struct0_0;
            break;
          case Enum0.const_2:
            this.intptr_10 = intptr_15;
            this.struct0_7 = struct0_0;
            break;
          case Enum0.const_12:
            this.intptr_14 = intptr_15;
            this.struct0_11 = struct0_0;
            break;
          case Enum0.const_3:
            this.intptr_5 = intptr_15;
            this.struct0_2 = struct0_0;
            break;
          case Enum0.const_4:
            this.intptr_13 = intptr_15;
            this.struct0_10 = struct0_0;
            break;
          case Enum0.const_5:
            this.intptr_12 = intptr_15;
            this.struct0_9 = struct0_0;
            break;
          case Enum0.const_7:
            this.fileDialogControlBase_0.intptr_2 = intptr_15;
            Class5.GetWindowInfo(new HandleRef((object) this, intptr_15), out this.struct0_0);
            Class5.smethod_74(this.fileDialogControlBase_0);
            break;
          case Enum0.const_10:
            this.intptr_7 = intptr_15;
            this.struct0_4 = struct0_0;
            break;
          case Enum0.const_11:
            this.intptr_4 = intptr_15;
            this.struct0_1 = struct0_0;
            break;
          case Enum0.const_9:
            if (stringBuilder_0.ToString().ToLower() == "comboboxex32")
            {
              this.intptr_6 = intptr_15;
              this.struct0_3 = struct0_0;
              break;
            }
            break;
          case Enum0.const_8:
            this.intptr_11 = intptr_15;
            this.struct0_8 = struct0_0;
            break;
        }
        flag = true;
      }
      return flag;
    }

    internal void method_1(object sender, EventArgs e)
    {
      this.System\u002EIDisposable\u002EDispose();
    }

    virtual void NativeWindow.WndProc(ref Message m)
    {
      Struct1 struct1_0_1 = new Struct1();
      switch ((Enum1) m.Msg)
      {
        case Enum1.const_4:
          Class5.GetClientRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_1);
          switch (this.fileDialogControlBase_0.FileDlgStartLocation)
          {
            case AddonWindowLocation.Right:
              if ((this.bool_3 ? 0 : (Class5.smethod_2() == 0U ? 1 : 0)) != 0)
                FileDialogControlBase.uint_0 = struct1_0_1.method_1();
              if ((long) struct1_0_1.method_1() != (long) this.fileDialogControlBase_0.Height)
              {
                this.fileDialogControlBase_0.Height = (int) struct1_0_1.method_1();
                break;
              }
              break;
            case AddonWindowLocation.Bottom:
              if ((this.bool_3 ? 0 : (Class5.smethod_144() == 0U ? 1 : 0)) != 0)
                FileDialogControlBase.uint_1 = struct1_0_1.method_0();
              if ((long) struct1_0_1.method_0() != (long) this.fileDialogControlBase_0.Width)
              {
                this.fileDialogControlBase_0.Width = (int) struct1_0_1.method_0();
                break;
              }
              break;
          }
          break;
        case Enum1.const_5:
          if ((!this.bool_1 ? 0 : (!this.bool_2 ? 1 : 0)) != 0)
          {
            this.bool_1 = false;
            this.intptr_3 = m.LParam;
            this.ReleaseHandle();
            this.AssignHandle(this.intptr_3);
            Class5.GetWindowRect(new HandleRef((object) this, this.intptr_3), ref this.fileDialogControlBase_0.struct1_0);
            this.fileDialogControlBase_0.intptr_0 = this.intptr_3;
            break;
          }
          break;
        case Enum1.const_21:
          Class5.smethod_130(this);
          Class5.GetWindowRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_1);
          int int_1 = this.fileDialogControlBase_0.Parent == null ? struct1_0_1.int_1 : this.fileDialogControlBase_0.Parent.Top;
          int int_0 = this.fileDialogControlBase_0.Parent == null ? struct1_0_1.int_2 : this.fileDialogControlBase_0.Parent.Right;
          Struct1 struct1_0_2 = new Struct1();
          Class5.GetClientRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_2);
          int num1 = (int) struct1_0_1.method_1() - (int) struct1_0_2.method_1();
          int num2 = (int) struct1_0_1.method_0() - (int) struct1_0_2.method_0();
          switch (this.fileDialogControlBase_0.FileDlgStartLocation)
          {
            case AddonWindowLocation.Right:
              int int_3 = Math.Max(Class5.smethod_191(this.fileDialogControlBase_0).Height + num1, (int) Class5.smethod_2());
              Class5.SetWindowPos(this.intptr_3, (IntPtr) 1, int_0, int_1, (int) struct1_0_1.method_0(), int_3, Enum2.flag_1 | Enum2.flag_2);
              break;
            case AddonWindowLocation.Bottom:
              int int_2 = Math.Max(Class5.smethod_191(this.fileDialogControlBase_0).Width + num2, (int) Class5.smethod_144());
              Class5.SetWindowPos(this.intptr_3, (IntPtr) 1, int_0, int_1, int_2, (int) struct1_0_1.method_1(), Enum2.flag_1 | Enum2.flag_2);
              break;
          }
          break;
        case Enum1.const_53:
          if (!this.bool_2 && (this.bool_3 ? 0 : (!this.bool_0 ? 1 : 0)) != 0)
          {
            Struct2 structure = (Struct2) Marshal.PtrToStructure(m.LParam, typeof (Struct2));
            if ((structure.uint_0 == 0U ? 0 : (((int) structure.uint_0 & 1) != 1 ? 1 : 0)) != 0)
            {
              switch (this.fileDialogControlBase_0.FileDlgStartLocation)
              {
                case AddonWindowLocation.BottomRight:
                  this.size_0 = new Size(structure.int_2, structure.int_3);
                  structure.int_3 += this.fileDialogControlBase_0.Height;
                  structure.int_2 += this.fileDialogControlBase_0.Width;
                  Marshal.StructureToPtr<Struct2>(structure, m.LParam, true);
                  break;
                case AddonWindowLocation.Right:
                  this.size_0 = new Size(structure.int_2, structure.int_3);
                  structure.int_2 += this.fileDialogControlBase_0.Width;
                  Marshal.StructureToPtr<Struct2>(structure, m.LParam, true);
                  Struct1 struct1_0_3 = new Struct1();
                  Class5.GetClientRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_3);
                  if (this.fileDialogControlBase_0.Height < (int) struct1_0_3.method_1())
                  {
                    this.fileDialogControlBase_0.Height = (int) struct1_0_3.method_1();
                    break;
                  }
                  break;
                case AddonWindowLocation.Bottom:
                  this.size_0 = new Size(structure.int_2, structure.int_3);
                  structure.int_3 += this.fileDialogControlBase_0.Height;
                  Marshal.StructureToPtr<Struct2>(structure, m.LParam, true);
                  Struct1 struct1_0_4 = new Struct1();
                  Class5.GetClientRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_4);
                  if (this.fileDialogControlBase_0.Width < (int) struct1_0_4.method_0())
                  {
                    this.fileDialogControlBase_0.Width = (int) struct1_0_4.method_0();
                    break;
                  }
                  break;
              }
              this.bool_0 = true;
              break;
            }
            break;
          }
          break;
        case Enum1.const_106:
          switch (Class5.GetDlgCtrlID(m.LParam))
          {
          }
          break;
        case Enum1.const_146:
          Class5.GetClientRect(new HandleRef((object) this, this.intptr_3), ref struct1_0_1);
          switch (this.fileDialogControlBase_0.FileDlgStartLocation)
          {
            case AddonWindowLocation.BottomRight:
              if (((long) struct1_0_1.method_0() != (long) this.fileDialogControlBase_0.Width ? 1 : ((long) struct1_0_1.method_1() != (long) this.fileDialogControlBase_0.Height ? 1 : 0)) != 0)
              {
                Class5.SetWindowPos(this.fileDialogControlBase_0.Handle, (IntPtr) 1, (int) struct1_0_1.method_0(), (int) struct1_0_1.method_1(), (int) struct1_0_1.method_0(), (int) struct1_0_1.method_1(), Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
                break;
              }
              break;
            case AddonWindowLocation.Right:
              if ((long) struct1_0_1.method_1() != (long) this.fileDialogControlBase_0.Height)
              {
                Class5.SetWindowPos(this.fileDialogControlBase_0.Handle, (IntPtr) 1, 0, 0, this.fileDialogControlBase_0.Width, (int) struct1_0_1.method_1(), Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
                break;
              }
              break;
            case AddonWindowLocation.Bottom:
              if ((long) struct1_0_1.method_1() != (long) this.fileDialogControlBase_0.Height)
              {
                Class5.SetWindowPos(this.fileDialogControlBase_0.Handle, (IntPtr) 1, 0, 0, (int) struct1_0_1.method_0(), this.fileDialogControlBase_0.Height, Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9 | Enum2.flag_13 | Enum2.flag_14);
                break;
              }
              break;
          }
          break;
        case Enum1.const_166:
          if (m.WParam == (IntPtr) 1)
          {
            this.bool_2 = true;
            Class5.SetWindowPos(this.intptr_3, IntPtr.Zero, 0, 0, 0, 0, Enum2.flag_0 | Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_7 | Enum2.flag_9);
            Class5.GetWindowRect(new HandleRef((object) this, this.intptr_3), ref this.struct1_0);
            Class5.SetWindowPos(this.intptr_3, IntPtr.Zero, this.struct1_0.int_0, this.struct1_0.int_1, this.size_0.Width, this.size_0.Height, Enum2.flag_1 | Enum2.flag_4 | Enum2.flag_9);
            break;
          }
          break;
      }
      // ISSUE: explicit non-virtual call
      __nonvirtual (((NativeWindow) this).WndProc(ref m));
    }
  }
}
