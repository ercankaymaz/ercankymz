using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using buControls.Controls;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Components;

[DefaultProperty("Display")]
[DefaultEvent("Click")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
[ToolboxBitmap(typeof(Label))]
[DefaultBindingProperty("Display")]
public class buControlDisplaySet : UserControl
{
	[CompilerGenerated]
	private EventHandler eventHandler_0;

	private bool bool_0 = false;

	private buControlDisplay buControlDisplay_0 = null;

	private string string_0 = "";

	private IContainer icontainer_0 = null;

	internal buComboBox buComboBox_0;

	public buSpin spn_thickness;

	internal buLabel buLabel_0;

	internal Panel panel_0;

	public buButton btn_defvals;

	internal buLabel buLabel_1;

	public buButton btn_savefiles;

	public buButton btn_openfiles;

	internal buCheckBox buCheckBox_0;

	internal buLabel buLabel_2;

	internal buLabel buLabel_3;

	internal buLabel buLabel_4;

	public buButton btn_font;

	internal buLabel buLabel_5;

	internal buComboBox buComboBox_1;

	internal TabPage tabPage_0;

	internal buLabel buLabel_6;

	internal buLabel buLabel_7;

	internal buLabel buLabel_8;

	internal buLabel buLabel_9;

	internal buLabel buLabel_10;

	internal buLabel buLabel_11;

	internal buLabel buLabel_12;

	internal buLabel buLabel_13;

	internal TabPage tabPage_1;

	internal buLabel buLabel_14;

	internal buLabel buLabel_15;

	internal buLabel buLabel_16;

	internal buLabel buLabel_17;

	internal TabPage tabPage_2;

	public buSpin spn_lineardegree;

	internal buLabel buLabel_18;

	internal buLabel buLabel_19;

	internal buLabel buLabel_20;

	internal buLabel buLabel_21;

	internal TabPage tabPage_3;

	internal buLabel buLabel_22;

	internal buLabel buLabel_23;

	internal buTab buTab_0;

	internal buLabel buLabel_24;

	internal buLabel buLabel_25;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public string Caption
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			buLabel_0.Text = string_0;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
			Invalidate();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Browsable(true)]
	public buControlDisplay Display
	{
		get
		{
			return buControlDisplay_0;
		}
		set
		{
			buControlDisplay_0 = value;
			if (base.Parent != null)
			{
				base.Parent.Invalidate();
			}
		}
	}

	public event EventHandler Changed
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public buControlDisplaySet()
	{
		buControlDisplay_0 = new buControlDisplay();
		Display.Parent = this;
		Class76.smethod_845(this);
		buComboBox_1.Items.Clear();
		buComboBox_1.Items.AddRange(Enum.GetValues(typeof(ContentAlignment)).Cast<object>().ToArray());
		buControlDisplay_0.Changed += DisplayChanged;
		UpdateControl();
	}

	public void UpdateControl()
	{
		bool_0 = true;
		buLabel_23.Display.BackColor = Display.BackColor;
		buLabel_23.Text = buImage.GetColorKnownName(buLabel_23.Display.BackColor);
		if (!(Display.BackColor == Color.Black))
		{
			buLabel_23.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_23.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_21.Display.BackColor = Display.LineerGradient.FirstColor;
		buLabel_21.Text = buImage.GetColorKnownName(buLabel_21.Display.BackColor);
		if (!(Display.LineerGradient.FirstColor == Color.Black))
		{
			buLabel_21.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_21.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_19.Display.BackColor = Display.LineerGradient.SecondColor;
		buLabel_19.Text = buImage.GetColorKnownName(buLabel_19.Display.BackColor);
		if (!(Display.LineerGradient.SecondColor == Color.Black))
		{
			buLabel_19.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_19.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_17.Display.BackColor = Display.PathGradient.CenterColor;
		buLabel_17.Text = buImage.GetColorKnownName(buLabel_16.Display.BackColor);
		if (!(Display.PathGradient.CenterColor == Color.Black))
		{
			buLabel_17.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_17.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_15.Display.BackColor = Display.PathGradient.SurroundColor;
		buLabel_15.Text = buImage.GetColorKnownName(buLabel_15.Display.BackColor);
		if (!(Display.PathGradient.SurroundColor == Color.Black))
		{
			buLabel_15.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_15.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_13.Display.BackColor = Display.PathInterpolatedGradient.FirstColor;
		buLabel_13.Text = buImage.GetColorKnownName(buLabel_13.Display.BackColor);
		if (!(Display.PathInterpolatedGradient.FirstColor == Color.Black))
		{
			buLabel_13.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_13.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_11.Display.BackColor = Display.PathInterpolatedGradient.SecondColor;
		buLabel_11.Text = buImage.GetColorKnownName(buLabel_11.Display.BackColor);
		if (!(Display.PathInterpolatedGradient.SecondColor == Color.Black))
		{
			buLabel_11.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_11.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_9.Display.BackColor = Display.PathInterpolatedGradient.ThirdColor;
		buLabel_9.Text = buImage.GetColorKnownName(buLabel_9.Display.BackColor);
		if (!(Display.PathInterpolatedGradient.ThirdColor == Color.Black))
		{
			buLabel_9.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_9.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_7.Display.BackColor = Display.PathInterpolatedGradient.FourthColor;
		buLabel_7.Text = buImage.GetColorKnownName(buLabel_7.Display.BackColor);
		if (!(Display.PathInterpolatedGradient.FourthColor == Color.Black))
		{
			buLabel_7.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_7.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_3.Display.BackColor = Display.SelectionColor;
		buLabel_3.Text = buImage.GetColorKnownName(buLabel_3.Display.BackColor);
		if (!(Display.SelectionColor == Color.Black))
		{
			buLabel_3.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_3.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_25.Display.BackColor = Display.TitleForeColor;
		buLabel_25.Text = buImage.GetColorKnownName(buLabel_25.Display.BackColor);
		if (!(Display.TitleForeColor == Color.Black))
		{
			buLabel_25.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_25.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buCheckBox_0.Check = Display.Border.Visible;
		spn_thickness.Value = Display.Border.Thickness;
		buLabel_2.Display.BackColor = Display.Border.Color;
		buLabel_2.Text = buImage.GetColorKnownName(buLabel_2.Display.BackColor);
		if (!(Display.Border.Color == Color.Black))
		{
			buLabel_2.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_2.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		spn_lineardegree.Value = buControlDisplay_0.LineerGradient.GradientAngle;
		if (Display.GradientType != GradientMode.Solid)
		{
			if (Display.GradientType != GradientMode.Lineer)
			{
				if (Display.GradientType != GradientMode.Path)
				{
					buComboBox_0.SelectedIndex = 3;
					buTab_0.SelectedIndex = 3;
				}
				else
				{
					buComboBox_0.SelectedIndex = 2;
					buTab_0.SelectedIndex = 2;
				}
			}
			else
			{
				buComboBox_0.SelectedIndex = 1;
				buTab_0.SelectedIndex = 1;
			}
		}
		else
		{
			buComboBox_0.SelectedIndex = 0;
			buTab_0.SelectedIndex = 0;
		}
		btn_font.Text = Display.Fonts.Font.Name + " - " + Display.Fonts.Font.Size;
		btn_font.Display.BackColor = Display.Fonts.ForeColor;
		btn_font.ButtonDownDisplay.BackColor = Display.Fonts.ForeColor;
		btn_font.ButtonOverDisplay.BackColor = Display.Fonts.ForeColor;
		if (!(Display.Fonts.ForeColor == Color.Black))
		{
			btn_font.Display.Fonts.ForeColor = Color.Black;
			btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.Black;
			btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.Black;
		}
		else
		{
			btn_font.Display.Fonts.ForeColor = Color.WhiteSmoke;
			btn_font.ButtonDownDisplay.Fonts.ForeColor = Color.WhiteSmoke;
			btn_font.ButtonOverDisplay.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buLabel_5.Display.BackColor = Display.Fonts.ForeColor;
		buLabel_5.Text = buImage.GetColorKnownName(buLabel_5.Display.BackColor);
		if (!(Display.Fonts.ForeColor == Color.Black))
		{
			buLabel_5.Display.Fonts.ForeColor = Color.Black;
		}
		else
		{
			buLabel_5.Display.Fonts.ForeColor = Color.WhiteSmoke;
		}
		buComboBox_1.SelectedItem = Display.Fonts.Alignment;
		buLabel_0.Display.BackColor = Display.BackColor;
		buLabel_0.Display.SelectionColor = Display.SelectionColor;
		buLabel_0.Display.TitleForeColor = Display.TitleForeColor;
		buLabel_0.Display.GradientType = Display.GradientType;
		buLabel_0.Display.LineerGradient.FirstColor = Display.LineerGradient.FirstColor;
		buLabel_0.Display.LineerGradient.SecondColor = Display.LineerGradient.SecondColor;
		buLabel_0.Display.LineerGradient.GradientAngle = Display.LineerGradient.GradientAngle;
		buLabel_0.Display.PathGradient.CenterColor = Display.PathGradient.CenterColor;
		buLabel_0.Display.PathGradient.SurroundColor = Display.PathGradient.SurroundColor;
		buLabel_0.Display.PathInterpolatedGradient.FirstColor = Display.PathInterpolatedGradient.FirstColor;
		buLabel_0.Display.PathInterpolatedGradient.SecondColor = Display.PathInterpolatedGradient.SecondColor;
		buLabel_0.Display.PathInterpolatedGradient.ThirdColor = Display.PathInterpolatedGradient.ThirdColor;
		buLabel_0.Display.PathInterpolatedGradient.FourthColor = Display.PathInterpolatedGradient.FourthColor;
		buLabel_0.Display.Border.Visible = Display.Border.Visible;
		buLabel_0.Display.Border.Thickness = Display.Border.Thickness;
		buLabel_0.Display.Border.Color = Display.Border.Color;
		buLabel_0.Display.Fonts.ForeColor = Display.Fonts.ForeColor;
		buLabel_0.Display.Fonts.Alignment = Display.Fonts.Alignment;
		buLabel_0.Display.Fonts.Font = Display.Fonts.Font;
		bool_0 = false;
	}

	protected void DisplayChanged(object sender, EventArgs e)
	{
	}

	internal void method_0(object sender, EventArgs e)
	{
	}

	internal void method_1(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		Control control = sender as Control;
		if (control.Name == buComboBox_0.Name)
		{
			if (buComboBox_0.SelectedIndex != 0)
			{
				if (buComboBox_0.SelectedIndex != 1)
				{
					if (buComboBox_0.SelectedIndex != 2)
					{
						buTab_0.SelectedIndex = 3;
						Display.GradientType = GradientMode.InterpolatedPath;
					}
					else
					{
						buTab_0.SelectedIndex = 2;
						Display.GradientType = GradientMode.Path;
					}
				}
				else
				{
					buTab_0.SelectedIndex = 1;
					Display.GradientType = GradientMode.Lineer;
				}
			}
			else
			{
				buTab_0.SelectedIndex = 0;
				Display.GradientType = GradientMode.Solid;
			}
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
		if (control.Name == buComboBox_1.Name)
		{
			Enum.TryParse<ContentAlignment>(buComboBox_1.SelectedItem.ToString(), out var result);
			Display.Fonts.Alignment = result;
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
	}

	internal void method_2(object sender, EventArgs e)
	{
		buLabel buLabel2 = sender as buLabel;
		if (buLabel2.Name == buLabel_23.Name)
		{
			Color cColor = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor;
				buLabel2.Text = buImage.GetColorKnownName(cColor);
				Display.BackColor = cColor;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_21.Name)
		{
			Color cColor2 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor2;
				buLabel2.Text = buImage.GetColorKnownName(cColor2);
				Display.LineerGradient.FirstColor = cColor2;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_19.Name)
		{
			Color cColor3 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor3;
				buLabel2.Text = buImage.GetColorKnownName(cColor3);
				Display.LineerGradient.SecondColor = cColor3;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_17.Name)
		{
			Color cColor4 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor4) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor4;
				buLabel2.Text = buImage.GetColorKnownName(cColor4);
				Display.PathGradient.CenterColor = cColor4;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_15.Name)
		{
			Color cColor5 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor5) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor5;
				buLabel2.Text = buImage.GetColorKnownName(cColor5);
				Display.PathGradient.SurroundColor = cColor5;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_13.Name)
		{
			Color cColor6 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor6) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor6;
				buLabel2.Text = buImage.GetColorKnownName(cColor6);
				Display.PathInterpolatedGradient.FirstColor = cColor6;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_11.Name)
		{
			Color cColor7 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor7) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor7;
				buLabel2.Text = buImage.GetColorKnownName(cColor7);
				Display.PathInterpolatedGradient.SecondColor = cColor7;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_9.Name)
		{
			Color cColor8 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor8) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor8;
				buLabel2.Text = buImage.GetColorKnownName(cColor8);
				Display.PathInterpolatedGradient.ThirdColor = cColor8;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_7.Name)
		{
			Color cColor9 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor9) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor9;
				buLabel2.Text = buImage.GetColorKnownName(cColor9);
				Display.PathInterpolatedGradient.FourthColor = cColor9;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_3.Name)
		{
			Color cColor10 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor10) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor10;
				buLabel2.Text = buImage.GetColorKnownName(cColor10);
				Display.SelectionColor = cColor10;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_25.Name)
		{
			Color cColor11 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor11) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor11;
				buLabel2.Text = buImage.GetColorKnownName(cColor11);
				Display.TitleForeColor = cColor11;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (buLabel2.Name == buLabel_2.Name)
		{
			Color cColor12 = buLabel2.Display.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor12) == DialogResult.OK)
			{
				buLabel2.Display.BackColor = cColor12;
				buLabel2.Text = buImage.GetColorKnownName(cColor12);
				Display.Border.Color = cColor12;
				UpdateControl();
				if (eventHandler_0 != null)
				{
					eventHandler_0(this, new EventArgs());
				}
			}
		}
		if (!(buLabel2.Name == buLabel_5.Name))
		{
			return;
		}
		Color cColor13 = buLabel2.Display.BackColor;
		if (ColorDialogBox.ShowDialog(ref cColor13) == DialogResult.OK)
		{
			buLabel2.Display.BackColor = cColor13;
			buLabel2.Text = buImage.GetColorKnownName(cColor13);
			Display.Fonts.ForeColor = cColor13;
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
	}

	internal void method_3(object object_0, bool bool_1)
	{
		if (!bool_0)
		{
			Display.Border.Visible = buCheckBox_0.Check;
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
	}

	internal void method_4(object object_0, double double_0)
	{
		Control control = object_0 as Control;
		if (bool_0)
		{
			return;
		}
		if (control.Name == spn_thickness.Name)
		{
			Display.Border.Thickness = (float)spn_thickness.Value;
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
		if (control.Name == spn_lineardegree.Name)
		{
			Display.LineerGradient.GradientAngle = (float)spn_lineardegree.Value;
			UpdateControl();
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, new EventArgs());
			}
		}
	}

	internal void method_5(object sender, EventArgs e)
	{
		FontDialog fontDialog = new FontDialog();
		fontDialog.Font = Display.Fonts.Font;
		fontDialog.ShowDialog();
		Display.Fonts.Font = fontDialog.Font;
		UpdateControl();
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new EventArgs());
		}
	}

	internal void method_6(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buLabel_1.Name)
		{
			panel_0.Visible = false;
		}
		if (control.Name == btn_defvals.Name)
		{
			DialogResult dialogResult = MessageBox.Show("Do You Want to Call Deafult Values", "Default", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				Display = new buControlDisplay();
				UpdateControl();
			}
			panel_0.Visible = false;
		}
		if (control.Name == btn_openfiles.Name)
		{
			panel_0.Visible = false;
		}
		if (control.Name == btn_savefiles.Name)
		{
			panel_0.Visible = false;
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		if (panel_0.Visible)
		{
			panel_0.Visible = false;
			return;
		}
		panel_0.Height = 155;
		panel_0.Visible = true;
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
