using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Materials;
using ns71;

namespace buEyeBaseVer5.Forms.Foam;

public class F_FoamPattern : Form
{
	public FormProperties PropertiesForm = new FormProperties();

	public SizeObject FoamSize = new SizeObject();

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_0;

	[CompilerGenerated]
	private OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler_1;

	[CompilerGenerated]
	private CancelCommandEventHandler cancelCommandEventHandler_0;

	public bool ValueChanging = false;

	internal IContainer icontainer_0 = null;

	internal Button button_0;

	internal Button button_1;

	internal ImageList imageList_0;

	internal ImageList imageList_1;

	internal Button button_2;

	internal ImageList imageList_2;

	internal Button button_3;

	public NumericUpDown spn_blockvercount;

	public NumericUpDown spn_blockhorcount;

	public NumericUpDown spn_blocktotalwidth;

	internal Label label_0;

	public NumericUpDown spn_blocktotalheight;

	internal Label label_1;

	public NumericUpDown spn_blockwidthstartoffset;

	public NumericUpDown spn_blockwidthendoffset;

	public NumericUpDown spn_blockheightendoffset;

	public NumericUpDown spn_blockheightstartoffset;

	public Label label1;

	public Label label2;

	public Label label3;

	public Label label6;

	public Label label7;

	public NumericUpDown spn_patternheight;

	public NumericUpDown spn_patternwidth;

	internal Label label_2;

	internal Label label_3;

	internal Label label_4;

	public Label label12;

	public Label label13;

	public ListBox lst_idealwidth;

	public ListBox lst_idealheight;

	internal Label label_5;

	internal TextBox textBox_0;

	internal Panel panel_0;

	internal Label label_6;

	internal Panel panel_1;

	internal Label label_7;

	internal Panel panel_2;

	internal Label label_8;

	internal Panel panel_3;

	internal Button button_4;

	public NumericUpDown spn_patternspacehight;

	public Label label18;

	internal Label label_9;

	public Label label20;

	public NumericUpDown spn_patternspacewidth;

	internal Label label_10;

	public Label label21;

	public Label label22;

	public NumericUpDown spn_totalpart;

	public Label label23;

	internal Panel panel_4;

	public NumericUpDown spn_connectionvel;

	public Label label25;

	public NumericUpDown spn_leadoutvel;

	public Label label28;

	public NumericUpDown spn_leadinvel;

	public Label label24;

	public Label label26;

	public NumericUpDown spn_cutvel;

	internal Label label_11;

	internal Panel panel_5;

	public TextBox txt_info;

	internal Label label_12;

	public Label label29;

	public Panel pnl_controlspattern;

	internal CheckBox checkBox_0;

	internal CheckBox checkBox_1;

	public event OkCommandWithTwoDataEventHandler DataChanged
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_0;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_0, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event OkCommandWithTwoDataEventHandler ParameterChanged
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Combine(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler = okCommandWithTwoDataEventHandler_1;
			OkCommandWithTwoDataEventHandler okCommandWithTwoDataEventHandler2;
			do
			{
				okCommandWithTwoDataEventHandler2 = okCommandWithTwoDataEventHandler;
				OkCommandWithTwoDataEventHandler value2 = (OkCommandWithTwoDataEventHandler)Delegate.Remove(okCommandWithTwoDataEventHandler2, value);
				okCommandWithTwoDataEventHandler = Interlocked.CompareExchange(ref okCommandWithTwoDataEventHandler_1, value2, okCommandWithTwoDataEventHandler2);
			}
			while ((object)okCommandWithTwoDataEventHandler != okCommandWithTwoDataEventHandler2);
		}
	}

	public event CancelCommandEventHandler DataCancel
	{
		[CompilerGenerated]
		add
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Combine(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CancelCommandEventHandler cancelCommandEventHandler = cancelCommandEventHandler_0;
			CancelCommandEventHandler cancelCommandEventHandler2;
			do
			{
				cancelCommandEventHandler2 = cancelCommandEventHandler;
				CancelCommandEventHandler value2 = (CancelCommandEventHandler)Delegate.Remove(cancelCommandEventHandler2, value);
				cancelCommandEventHandler = Interlocked.CompareExchange(ref cancelCommandEventHandler_0, value2, cancelCommandEventHandler2);
			}
			while ((object)cancelCommandEventHandler != cancelCommandEventHandler2);
		}
	}

	public F_FoamPattern()
	{
		Class186.smethod_463(this);
	}

	public void Init()
	{
		PropertiesForm.Inited = false;
		textBox_0.Text = buFoamCalc.varFoamRunSettings.BlockName;
		spn_blockheightendoffset.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternHeightEndOffset;
		spn_blockheightstartoffset.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternHeightStartOffset;
		spn_blockwidthendoffset.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternWidthEndOffset;
		spn_blockwidthstartoffset.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternWidthStartOffset;
		spn_blocktotalwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockWidth;
		spn_blocktotalheight.Value = (decimal)buFoamCalc.varFoamRunSettings.BlockHeight;
		spn_patternwidth.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternWidth;
		spn_patternheight.Value = (decimal)buFoamCalc.varFoamRunSettings.PatternHeight;
		spn_patternspacewidth.Value = (decimal)buFoamCalc.varFoamSettings.PatternDistancesWidth;
		spn_patternspacehight.Value = (decimal)buFoamCalc.varFoamSettings.PatternDistancesHeight;
		spn_cutvel.Value = (decimal)buFoamCalc.varFoamSettings.CuttingFeed;
		spn_leadinvel.Value = (decimal)buFoamCalc.varFoamSettings.EntryFeed;
		spn_leadoutvel.Value = (decimal)buFoamCalc.varFoamSettings.LeaveFeed;
		spn_connectionvel.Value = (decimal)buFoamCalc.varFoamSettings.ConnectionFeed;
		checkBox_1.Checked = buFoamCalc.varFoamRunSettings.PatternMirrorX;
		checkBox_0.Checked = buFoamCalc.varFoamRunSettings.PatternMirrorY;
		button_3.BackColor = Color.Silver;
		button_2.BackColor = Color.Silver;
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.XZ)
		{
			button_3.BackColor = Color.Gold;
		}
		if (buFoamCalc.varFoamRunSettings.planeNames == FoamPlaneType.YZ)
		{
			button_2.BackColor = Color.Gold;
		}
		PropertiesForm.Inited = true;
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	public void Apply()
	{
		buFoamCalc.varFoamRunSettings.PatternHeightEndOffset = (double)spn_blockheightendoffset.Value;
		buFoamCalc.varFoamRunSettings.PatternHeightStartOffset = (double)spn_blockheightstartoffset.Value;
		buFoamCalc.varFoamRunSettings.PatternWidthEndOffset = (double)spn_blockwidthendoffset.Value;
		buFoamCalc.varFoamRunSettings.PatternWidthStartOffset = (double)spn_blockwidthstartoffset.Value;
		buFoamCalc.varFoamRunSettings.BlockWidth = (double)spn_blocktotalwidth.Value;
		buFoamCalc.varFoamRunSettings.BlockHeight = (double)spn_blocktotalheight.Value;
		buFoamCalc.varFoamRunSettings.PatternWidth = (double)spn_patternwidth.Value;
		buFoamCalc.varFoamRunSettings.PatternHeight = (double)spn_patternheight.Value;
		buFoamCalc.varFoamRunSettings.BlockName = textBox_0.Text;
		buFoamCalc.varFoamSettings.PatternDistancesWidth = (double)spn_patternspacewidth.Value;
		buFoamCalc.varFoamSettings.PatternDistancesHeight = (double)spn_patternspacehight.Value;
		buFoamCalc.varFoamSettings.CuttingFeed = (double)spn_cutvel.Value;
		buFoamCalc.varFoamSettings.EntryFeed = (double)spn_leadinvel.Value;
		buFoamCalc.varFoamSettings.LeaveFeed = (double)spn_leadoutvel.Value;
		buFoamCalc.varFoamSettings.ConnectionFeed = (double)spn_connectionvel.Value;
		buFoamCalc.varFoamRunSettings.PatternMirrorX = checkBox_1.Checked;
		buFoamCalc.varFoamRunSettings.PatternMirrorY = checkBox_0.Checked;
	}

	internal void method_1(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == button_1.Name)
		{
			PropertiesForm.Result = DialogResult.Cancel;
			if (cancelCommandEventHandler_0 != null)
			{
				cancelCommandEventHandler_0();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_0.Name)
		{
			PropertiesForm.Result = DialogResult.OK;
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
				foamUpdateArg.Finished = true;
				foamUpdateArg.PatternSpaceHeight = (double)spn_patternspacehight.Value;
				foamUpdateArg.PatternSpaceWidth = (double)spn_patternspacewidth.Value;
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamRunSettings, foamUpdateArg);
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
		if (control.Name == button_2.Name)
		{
			buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.YZ;
			button_3.BackColor = Color.Silver;
			button_2.BackColor = Color.Gold;
			Apply();
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg foamUpdateArg2 = new FoamUpdateArg();
				foamUpdateArg2.PatternSpaceHeight = (double)spn_patternspacehight.Value;
				foamUpdateArg2.PatternSpaceWidth = (double)spn_patternspacewidth.Value;
				foamUpdateArg2.Command = "PlaneYZ";
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamRunSettings, foamUpdateArg2);
			}
		}
		if (control.Name == button_3.Name)
		{
			buFoamCalc.varFoamRunSettings.planeNames = FoamPlaneType.XZ;
			button_3.BackColor = Color.Gold;
			button_2.BackColor = Color.Silver;
			Apply();
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg foamUpdateArg3 = new FoamUpdateArg();
				foamUpdateArg3.PatternSpaceHeight = (double)spn_patternspacehight.Value;
				foamUpdateArg3.PatternSpaceWidth = (double)spn_patternspacewidth.Value;
				foamUpdateArg3.Command = "PlaneXZ";
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamRunSettings, foamUpdateArg3);
			}
		}
		if (control.Name == button_4.Name)
		{
			F_Material3D f_Material3D = null;
			f_Material3D = new F_Material3D();
			CreateModelProperties createModelProperties = new CreateModelProperties();
			createModelProperties.CoordinateSystemIconVisible = false;
			createModelProperties.ViewCubeIconVisible = false;
			createModelProperties.OrigineCaptionVisible = false;
			createModelProperties.ToolBorVisible = false;
			f_Material3D.viewportLayout = buCall.buVector5_0.CreateModelControl("", createModelProperties);
			f_Material3D.TopMost = true;
			f_Material3D.pnl_model.Controls.Add(f_Material3D.viewportLayout);
			f_Material3D.viewportLayout.Entities.Clear();
			f_Material3D.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			f_Material3D.Material = new MaterialBase5();
			f_Material3D.Material.Size = new SizeObject(FoamSize);
			f_Material3D.Init(null);
			f_Material3D.StartPosition = FormStartPosition.CenterParent;
			f_Material3D.ShowDialog(this);
			if (f_Material3D.PropertiesForm.Result == DialogResult.OK && okCommandWithTwoDataEventHandler_1 != null)
			{
				FoamSize = new SizeObject(f_Material3D.Material.Size);
				okCommandWithTwoDataEventHandler_1("FoamSize", f_Material3D.Material.Size);
			}
		}
	}

	internal void method_2(object sender, FormClosingEventArgs e)
	{
		if (PropertiesForm.Result != DialogResult.OK)
		{
			e.Cancel = true;
			PropertiesForm.Result = DialogResult.Cancel;
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Dispose)
			{
				Dispose();
			}
			if (PropertiesForm.FormCloseMode == FormCloseModeType.Invisible)
			{
				base.Visible = false;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (PropertiesForm.Inited)
		{
			if (!(control.Name == spn_blockvercount.Name))
			{
			}
			ValueChanging = true;
			Apply();
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
				foamUpdateArg.PatternSpaceHeight = (double)spn_patternspacehight.Value;
				foamUpdateArg.PatternSpaceWidth = (double)spn_patternspacewidth.Value;
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamRunSettings, foamUpdateArg);
			}
			ValueChanging = false;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			ValueChanging = true;
			Apply();
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg foamUpdateArg = new FoamUpdateArg();
				foamUpdateArg.PatternSpaceHeight = (double)spn_patternspacehight.Value;
				foamUpdateArg.PatternSpaceWidth = (double)spn_patternspacewidth.Value;
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamRunSettings, foamUpdateArg);
			}
			ValueChanging = false;
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		if (PropertiesForm.Inited)
		{
			Apply();
			if (okCommandWithTwoDataEventHandler_0 != null)
			{
				FoamUpdateArg data = new FoamUpdateArg();
				okCommandWithTwoDataEventHandler_0(buFoamCalc.varFoamSettings, data);
			}
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (PropertiesForm.Inited && !ValueChanging && !AppBool.Calculation)
		{
			if (control.Name == spn_blockhorcount.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("HorizontalCount", (double)spn_blockhorcount.Value);
			}
			if (control.Name == spn_blockvercount.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("VerticalCount", (double)spn_blockvercount.Value);
			}
			if (control.Name == spn_cutvel.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("VelCut", (double)spn_cutvel.Value);
			}
			if (control.Name == spn_leadinvel.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("VelLeadIn", (double)spn_leadinvel.Value);
			}
			if (control.Name == spn_leadoutvel.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("VelLeadOut", (double)spn_leadoutvel.Value);
			}
			if (control.Name == spn_connectionvel.Name && okCommandWithTwoDataEventHandler_1 != null)
			{
				okCommandWithTwoDataEventHandler_1("VelConnection", (double)spn_connectionvel.Value);
			}
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		double result = 0.0;
		if (lst_idealwidth.SelectedIndex >= 0)
		{
			double.TryParse(lst_idealwidth.Items[lst_idealwidth.SelectedIndex].ToString(), out result);
			if (result > 0.0)
			{
				spn_blocktotalwidth.Value = (decimal)(result + 0.1);
			}
		}
	}

	internal void method_8(object sender, EventArgs e)
	{
		double result = 0.0;
		if (lst_idealheight.SelectedIndex >= 0)
		{
			double.TryParse(lst_idealheight.Items[lst_idealheight.SelectedIndex].ToString(), out result);
			if (result > 0.0)
			{
				spn_blocktotalheight.Value = (decimal)(result + 0.1);
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
