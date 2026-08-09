using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using ns27;

namespace buControls.Forms.WinControlForms.G54;

public class F_G54AxesXYZ : Form
{
	public FormProperties Properties = new FormProperties();

	[CompilerGenerated]
	private G54GetPosEventHandler g54GetPosEventHandler_0;

	[CompilerGenerated]
	private G54ChangedEventHandler g54ChangedEventHandler_0;

	[CompilerGenerated]
	private G54GetAllPosEventHandler g54GetAllPosEventHandler_0;

	[CompilerGenerated]
	private PageClosedEventHandler pageClosedEventHandler_0;

	public List<string> Captions = new List<string>();

	public List<Pnt9D> parG54List = new List<Pnt9D>();

	public Pnt9D Positions = new Pnt9D();

	public int parG54Index = 0;

	public int DecimalPoint = 2;

	public double IncrementStep = 0.1;

	public bool DisableSetAllButton = false;

	public AxesEnableWithUVW parG54OffsetAxisEnable = new AxesEnableWithUVW();

	public string[] parAxisString = new string[9] { "X", "Y", "Z", "A", "B", "C", "U", "V", "W" };

	internal IContainer icontainer_0 = null;

	internal Label label_0;

	internal Label label_1;

	internal Label label_2;

	internal Label label_3;

	internal ImageList imageList_0;

	public Button btn_cancel;

	public Button btn_ok;

	public NumericUpDown spn_x;

	public NumericUpDown spn_y;

	public NumericUpDown spn_z;

	public Label lbl_readz;

	public Label lbl_ready;

	public Label lbl_readx;

	public Button btn_x;

	public Button btn_y;

	public Button btn_z;

	public NumericUpDown spn_index;

	public event G54GetPosEventHandler G54GetPos
	{
		[CompilerGenerated]
		add
		{
			G54GetPosEventHandler g54GetPosEventHandler = g54GetPosEventHandler_0;
			G54GetPosEventHandler g54GetPosEventHandler2;
			do
			{
				g54GetPosEventHandler2 = g54GetPosEventHandler;
				G54GetPosEventHandler value2 = (G54GetPosEventHandler)Delegate.Combine(g54GetPosEventHandler2, value);
				g54GetPosEventHandler = Interlocked.CompareExchange(ref g54GetPosEventHandler_0, value2, g54GetPosEventHandler2);
			}
			while ((object)g54GetPosEventHandler != g54GetPosEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54GetPosEventHandler g54GetPosEventHandler = g54GetPosEventHandler_0;
			G54GetPosEventHandler g54GetPosEventHandler2;
			do
			{
				g54GetPosEventHandler2 = g54GetPosEventHandler;
				G54GetPosEventHandler value2 = (G54GetPosEventHandler)Delegate.Remove(g54GetPosEventHandler2, value);
				g54GetPosEventHandler = Interlocked.CompareExchange(ref g54GetPosEventHandler_0, value2, g54GetPosEventHandler2);
			}
			while ((object)g54GetPosEventHandler != g54GetPosEventHandler2);
		}
	}

	public event G54ChangedEventHandler G54Changed
	{
		[CompilerGenerated]
		add
		{
			G54ChangedEventHandler g54ChangedEventHandler = g54ChangedEventHandler_0;
			G54ChangedEventHandler g54ChangedEventHandler2;
			do
			{
				g54ChangedEventHandler2 = g54ChangedEventHandler;
				G54ChangedEventHandler value2 = (G54ChangedEventHandler)Delegate.Combine(g54ChangedEventHandler2, value);
				g54ChangedEventHandler = Interlocked.CompareExchange(ref g54ChangedEventHandler_0, value2, g54ChangedEventHandler2);
			}
			while ((object)g54ChangedEventHandler != g54ChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54ChangedEventHandler g54ChangedEventHandler = g54ChangedEventHandler_0;
			G54ChangedEventHandler g54ChangedEventHandler2;
			do
			{
				g54ChangedEventHandler2 = g54ChangedEventHandler;
				G54ChangedEventHandler value2 = (G54ChangedEventHandler)Delegate.Remove(g54ChangedEventHandler2, value);
				g54ChangedEventHandler = Interlocked.CompareExchange(ref g54ChangedEventHandler_0, value2, g54ChangedEventHandler2);
			}
			while ((object)g54ChangedEventHandler != g54ChangedEventHandler2);
		}
	}

	public event G54GetAllPosEventHandler G54GetPosAll
	{
		[CompilerGenerated]
		add
		{
			G54GetAllPosEventHandler g54GetAllPosEventHandler = g54GetAllPosEventHandler_0;
			G54GetAllPosEventHandler g54GetAllPosEventHandler2;
			do
			{
				g54GetAllPosEventHandler2 = g54GetAllPosEventHandler;
				G54GetAllPosEventHandler value2 = (G54GetAllPosEventHandler)Delegate.Combine(g54GetAllPosEventHandler2, value);
				g54GetAllPosEventHandler = Interlocked.CompareExchange(ref g54GetAllPosEventHandler_0, value2, g54GetAllPosEventHandler2);
			}
			while ((object)g54GetAllPosEventHandler != g54GetAllPosEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			G54GetAllPosEventHandler g54GetAllPosEventHandler = g54GetAllPosEventHandler_0;
			G54GetAllPosEventHandler g54GetAllPosEventHandler2;
			do
			{
				g54GetAllPosEventHandler2 = g54GetAllPosEventHandler;
				G54GetAllPosEventHandler value2 = (G54GetAllPosEventHandler)Delegate.Remove(g54GetAllPosEventHandler2, value);
				g54GetAllPosEventHandler = Interlocked.CompareExchange(ref g54GetAllPosEventHandler_0, value2, g54GetAllPosEventHandler2);
			}
			while ((object)g54GetAllPosEventHandler != g54GetAllPosEventHandler2);
		}
	}

	public event PageClosedEventHandler G54PageClosed
	{
		[CompilerGenerated]
		add
		{
			PageClosedEventHandler pageClosedEventHandler = pageClosedEventHandler_0;
			PageClosedEventHandler pageClosedEventHandler2;
			do
			{
				pageClosedEventHandler2 = pageClosedEventHandler;
				PageClosedEventHandler value2 = (PageClosedEventHandler)Delegate.Combine(pageClosedEventHandler2, value);
				pageClosedEventHandler = Interlocked.CompareExchange(ref pageClosedEventHandler_0, value2, pageClosedEventHandler2);
			}
			while ((object)pageClosedEventHandler != pageClosedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PageClosedEventHandler pageClosedEventHandler = pageClosedEventHandler_0;
			PageClosedEventHandler pageClosedEventHandler2;
			do
			{
				pageClosedEventHandler2 = pageClosedEventHandler;
				PageClosedEventHandler value2 = (PageClosedEventHandler)Delegate.Remove(pageClosedEventHandler2, value);
				pageClosedEventHandler = Interlocked.CompareExchange(ref pageClosedEventHandler_0, value2, pageClosedEventHandler2);
			}
			while ((object)pageClosedEventHandler != pageClosedEventHandler2);
		}
	}

	public F_G54AxesXYZ()
	{
		Class76.smethod_582(this);
	}

	internal void method_0(object sender, FormClosingEventArgs e)
	{
		if (Properties.Result != DialogResult.OK)
		{
			e.Cancel = true;
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	public void Init()
	{
		Properties.Inited = false;
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		base.StartPosition = Properties.FormPosition;
		base.AutoScaleMode = Properties.ScaleFromMode;
		if (parG54List.Count > 0)
		{
			spn_x.Value = (decimal)parG54List[0].X;
			spn_y.Value = (decimal)parG54List[0].Y;
			spn_z.Value = (decimal)parG54List[0].Z;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == btn_ok.Name)
		{
			Class76.smethod_536(this);
			Properties.Result = DialogResult.OK;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_cancel.Name)
		{
			Properties.Result = DialogResult.Cancel;
			if (Properties.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (Properties.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == btn_x.Name)
		{
			spn_x.Value = (decimal)Positions.X;
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				Pnt9D pnt9D = new Pnt9D(parG54List[parG54Index]);
				pnt9D.X = (double)spn_x.Value;
				parG54List[parG54Index] = new Pnt9D(pnt9D);
			}
		}
		if (control.Name == btn_y.Name)
		{
			spn_y.Value = (decimal)Positions.Y;
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				Pnt9D pnt9D2 = new Pnt9D(parG54List[parG54Index]);
				pnt9D2.Y = (double)spn_y.Value;
				parG54List[parG54Index] = new Pnt9D(pnt9D2);
			}
		}
		if (control.Name == btn_z.Name)
		{
			spn_z.Value = (decimal)Positions.Z;
			if ((parG54Index >= 0) & (parG54Index <= parG54List.Count - 1))
			{
				Pnt9D pnt9D3 = new Pnt9D(parG54List[parG54Index]);
				pnt9D3.Z = (double)spn_z.Value;
				parG54List[parG54Index] = new Pnt9D(pnt9D3);
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		if (Properties.Inited && parG54List.Count > 0)
		{
			int num = Convert.ToInt32(spn_index.Value);
			if ((num >= 0) & (num <= parG54List.Count - 1))
			{
				parG54Index = num;
				spn_x.Value = (decimal)parG54List[num].X;
				spn_y.Value = (decimal)parG54List[num].Y;
				spn_z.Value = (decimal)parG54List[num].Z;
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}
}
