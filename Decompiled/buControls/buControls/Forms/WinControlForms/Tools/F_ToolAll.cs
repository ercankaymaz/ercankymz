using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using buClass;
using buControls.DialogBox;
using buCore;
using ns27;

namespace buControls.Forms.WinControlForms.Tools;

public class F_ToolAll : Form
{
	public FormProperties Properties = new FormProperties();

	public static List<string> Captions = new List<string>();

	public ToolBase Tool = new ToolBase();

	public ToolAreaVisible ToolVarVisible = new ToolAreaVisible();

	public bool ShowHelps = true;

	public bool ShowNextButton = false;

	public bool ShowPreButton = false;

	public bool ReadOnly = false;

	internal IContainer icontainer_0 = null;

	internal PictureBox pictureBox_0;

	internal ImageList imageList_0;

	internal Label label_0;

	internal Label label_1;

	internal NumericUpDown numericUpDown_0;

	internal Label label_2;

	internal Panel panel_0;

	internal Label label_3;

	internal NumericUpDown numericUpDown_1;

	internal Label label_4;

	internal NumericUpDown numericUpDown_2;

	internal NumericUpDown numericUpDown_3;

	internal Label label_5;

	internal Label label_6;

	internal Panel panel_1;

	internal Label label_7;

	internal NumericUpDown numericUpDown_4;

	internal NumericUpDown numericUpDown_5;

	internal Label label_8;

	internal NumericUpDown numericUpDown_6;

	internal Panel panel_2;

	internal Label label_9;

	internal Panel panel_3;

	internal NumericUpDown numericUpDown_7;

	internal Label label_10;

	internal Label label_11;

	internal TabPage tabPage_0;

	internal Panel panel_4;

	internal CheckBox checkBox_0;

	internal Label label_12;

	internal Label label_13;

	internal Panel panel_5;

	internal ComboBox comboBox_0;

	internal Label label_14;

	internal Label label_15;

	internal Panel panel_6;

	internal TextBox textBox_0;

	internal Label label_16;

	internal Label label_17;

	internal Panel panel_7;

	internal Label label_18;

	internal NumericUpDown numericUpDown_8;

	internal Label label_19;

	internal Panel panel_8;

	internal Label label_20;

	internal NumericUpDown numericUpDown_9;

	internal Label label_21;

	internal Panel panel_9;

	internal Label label_22;

	internal NumericUpDown numericUpDown_10;

	internal Label label_23;

	internal Panel panel_10;

	internal TextBox textBox_1;

	internal Label label_24;

	internal Label label_25;

	internal Panel panel_11;

	public Button btn_next;

	internal ImageList imageList_1;

	internal TabPage tabPage_1;

	internal Panel panel_12;

	internal Label label_26;

	internal NumericUpDown numericUpDown_11;

	internal NumericUpDown numericUpDown_12;

	internal Label label_27;

	internal NumericUpDown numericUpDown_13;

	internal Panel panel_13;

	internal Label label_28;

	internal NumericUpDown numericUpDown_14;

	internal Label label_29;

	public Button btn_pre;

	public Button btn_cancel;

	public Button btn_ok;

	internal ImageList imageList_2;

	internal ImageList imageList_3;

	internal Label label_30;

	internal TextBox textBox_2;

	internal Label label_31;

	internal NumericUpDown numericUpDown_15;

	internal Label label_32;

	internal Panel panel_14;

	internal Label label_33;

	internal NumericUpDown numericUpDown_16;

	internal NumericUpDown numericUpDown_17;

	internal Panel panel_15;

	internal Label label_34;

	internal NumericUpDown numericUpDown_18;

	internal NumericUpDown numericUpDown_19;

	internal Label label_35;

	internal NumericUpDown numericUpDown_20;

	internal Panel panel_16;

	internal Panel panel_17;

	internal Label label_36;

	internal NumericUpDown numericUpDown_21;

	internal NumericUpDown numericUpDown_22;

	internal Label label_37;

	internal NumericUpDown numericUpDown_23;

	internal Panel panel_18;

	internal Label label_38;

	internal NumericUpDown numericUpDown_24;

	internal TabPage tabPage_2;

	internal TabControl tabControl_0;

	internal TabPage tabPage_3;

	internal TabPage tabPage_4;

	internal TabControl tabControl_1;

	internal TabPage tabPage_5;

	internal TabPage tabPage_6;

	internal TabPage tabPage_7;

	internal TabPage tabPage_8;

	internal PictureBox pictureBox_1;

	internal PictureBox pictureBox_2;

	internal PictureBox pictureBox_3;

	internal NumericUpDown numericUpDown_25;

	internal Label label_39;

	internal Label label_40;

	internal Label label_41;

	internal Label label_42;

	internal Label label_43;

	internal Label label_44;

	internal Label label_45;

	internal Label label_46;

	internal NumericUpDown numericUpDown_26;

	internal NumericUpDown numericUpDown_27;

	internal NumericUpDown numericUpDown_28;

	internal NumericUpDown numericUpDown_29;

	internal NumericUpDown numericUpDown_30;

	internal NumericUpDown numericUpDown_31;

	internal NumericUpDown numericUpDown_32;

	internal NumericUpDown numericUpDown_33;

	internal Label label_47;

	internal NumericUpDown numericUpDown_34;

	internal Label label_48;

	internal Label label_49;

	internal Label label_50;

	internal Label label_51;

	internal Label label_52;

	internal Label label_53;

	internal Label label_54;

	internal Label label_55;

	internal NumericUpDown numericUpDown_35;

	internal NumericUpDown numericUpDown_36;

	internal NumericUpDown numericUpDown_37;

	internal NumericUpDown numericUpDown_38;

	internal NumericUpDown numericUpDown_39;

	internal NumericUpDown numericUpDown_40;

	internal NumericUpDown numericUpDown_41;

	internal NumericUpDown numericUpDown_42;

	internal Label label_56;

	internal NumericUpDown numericUpDown_43;

	internal Label label_57;

	internal Label label_58;

	internal Label label_59;

	internal Label label_60;

	internal Label label_61;

	internal Label label_62;

	internal Label label_63;

	internal Label label_64;

	internal NumericUpDown numericUpDown_44;

	internal NumericUpDown numericUpDown_45;

	internal NumericUpDown numericUpDown_46;

	internal NumericUpDown numericUpDown_47;

	internal NumericUpDown numericUpDown_48;

	internal NumericUpDown numericUpDown_49;

	internal NumericUpDown numericUpDown_50;

	internal NumericUpDown numericUpDown_51;

	internal Label label_65;

	internal NumericUpDown numericUpDown_52;

	internal Label label_66;

	internal Label label_67;

	internal Label label_68;

	internal Label label_69;

	internal Label label_70;

	internal Label label_71;

	internal Label label_72;

	internal Label label_73;

	internal NumericUpDown numericUpDown_53;

	internal NumericUpDown numericUpDown_54;

	internal NumericUpDown numericUpDown_55;

	internal NumericUpDown numericUpDown_56;

	internal NumericUpDown numericUpDown_57;

	internal NumericUpDown numericUpDown_58;

	internal NumericUpDown numericUpDown_59;

	internal NumericUpDown numericUpDown_60;

	internal Label label_74;

	internal TabPage tabPage_9;

	internal Panel panel_19;

	internal NumericUpDown numericUpDown_61;

	internal Label label_75;

	internal NumericUpDown numericUpDown_62;

	internal Label label_76;

	internal NumericUpDown numericUpDown_63;

	internal Label label_77;

	internal NumericUpDown numericUpDown_64;

	internal Label label_78;

	internal NumericUpDown numericUpDown_65;

	internal Label label_79;

	internal NumericUpDown numericUpDown_66;

	internal Label label_80;

	internal Label label_81;

	internal Panel panel_20;

	internal CheckBox checkBox_1;

	internal CheckBox checkBox_2;

	internal CheckBox checkBox_3;

	internal CheckBox checkBox_4;

	internal CheckBox checkBox_5;

	internal CheckBox checkBox_6;

	internal CheckBox checkBox_7;

	internal Label label_82;

	internal NumericUpDown numericUpDown_67;

	internal Label label_83;

	internal Panel panel_21;

	internal NumericUpDown numericUpDown_68;

	internal Label label_84;

	internal Label label_85;

	internal TabPage tabPage_10;

	internal Panel panel_22;

	internal Label label_86;

	internal Label label_87;

	internal Label label_88;

	internal Panel panel_23;

	internal Label label_89;

	internal Label label_90;

	internal Label label_91;

	internal Panel panel_24;

	internal Label label_92;

	internal Label label_93;

	internal Label label_94;

	internal Panel panel_25;

	internal Label label_95;

	internal Label label_96;

	internal Label label_97;

	internal Panel panel_26;

	internal Label label_98;

	internal Label label_99;

	internal Label label_100;

	internal Panel panel_27;

	internal Label label_101;

	internal Label label_102;

	internal Label label_103;

	internal Panel panel_28;

	internal Panel panel_29;

	internal Panel panel_30;

	internal Panel panel_31;

	internal Label label_104;

	internal Label label_105;

	internal Label label_106;

	internal Panel panel_32;

	internal Label label_107;

	internal Label label_108;

	internal Label label_109;

	internal Panel panel_33;

	internal CheckBox checkBox_8;

	internal CheckBox checkBox_9;

	internal CheckBox checkBox_10;

	internal CheckBox checkBox_11;

	internal Label label_110;

	internal Panel panel_34;

	internal ComboBox comboBox_1;

	internal Label label_111;

	internal Label label_112;

	internal Panel panel_35;

	internal Label label_113;

	internal NumericUpDown numericUpDown_69;

	internal Label label_114;

	internal Panel panel_36;

	internal NumericUpDown numericUpDown_70;

	internal Label label_115;

	internal Label label_116;

	internal Label label_117;

	internal NumericUpDown numericUpDown_71;

	internal TabPage tabPage_11;

	internal NumericUpDown numericUpDown_72;

	internal Label label_118;

	internal NumericUpDown numericUpDown_73;

	internal Label label_119;

	internal Label label_120;

	internal Label label_121;

	internal Label label_122;

	internal Label label_123;

	internal Label label_124;

	internal Label label_125;

	internal Label label_126;

	internal NumericUpDown numericUpDown_74;

	internal NumericUpDown numericUpDown_75;

	internal NumericUpDown numericUpDown_76;

	internal NumericUpDown numericUpDown_77;

	internal NumericUpDown numericUpDown_78;

	internal NumericUpDown numericUpDown_79;

	internal NumericUpDown numericUpDown_80;

	internal NumericUpDown numericUpDown_81;

	internal Label label_127;

	internal PictureBox pictureBox_4;

	internal CheckBox checkBox_12;

	internal Panel panel_37;

	internal CheckBox checkBox_13;

	internal CheckBox checkBox_14;

	internal CheckBox checkBox_15;

	internal Label label_128;

	internal Panel panel_38;

	internal NumericUpDown numericUpDown_82;

	internal Label label_129;

	internal Label label_130;

	internal TabPage tabPage_12;

	internal Label label_131;

	internal RadioButton radioButton_0;

	internal RadioButton radioButton_1;

	internal RadioButton radioButton_2;

	internal NumericUpDown numericUpDown_83;

	internal Label label_132;

	internal NumericUpDown numericUpDown_84;

	internal Label label_133;

	internal NumericUpDown numericUpDown_85;

	internal Label label_134;

	internal Label label_135;

	internal Label label_136;

	internal Label label_137;

	internal Label label_138;

	internal Label label_139;

	internal Label label_140;

	internal NumericUpDown numericUpDown_86;

	internal NumericUpDown numericUpDown_87;

	internal NumericUpDown numericUpDown_88;

	internal NumericUpDown numericUpDown_89;

	internal NumericUpDown numericUpDown_90;

	internal NumericUpDown numericUpDown_91;

	internal NumericUpDown numericUpDown_92;

	internal Label label_141;

	internal PictureBox pictureBox_5;

	internal PictureBox pictureBox_6;

	internal PictureBox pictureBox_7;

	internal TabPage tabPage_13;

	internal NumericUpDown numericUpDown_93;

	internal Label label_142;

	internal NumericUpDown numericUpDown_94;

	internal Label label_143;

	internal Label label_144;

	internal Label label_145;

	internal Label label_146;

	internal Label label_147;

	internal Label label_148;

	internal Label label_149;

	internal NumericUpDown numericUpDown_95;

	internal NumericUpDown numericUpDown_96;

	internal NumericUpDown numericUpDown_97;

	internal NumericUpDown numericUpDown_98;

	internal NumericUpDown numericUpDown_99;

	internal NumericUpDown numericUpDown_100;

	internal NumericUpDown numericUpDown_101;

	internal Label label_150;

	internal PictureBox pictureBox_8;

	internal TabPage tabPage_14;

	internal NumericUpDown numericUpDown_102;

	internal Label label_151;

	internal NumericUpDown numericUpDown_103;

	internal Label label_152;

	internal Label label_153;

	internal Label label_154;

	internal Label label_155;

	internal Label label_156;

	internal Label label_157;

	internal Label label_158;

	internal NumericUpDown numericUpDown_104;

	internal NumericUpDown numericUpDown_105;

	internal NumericUpDown numericUpDown_106;

	internal NumericUpDown numericUpDown_107;

	internal NumericUpDown numericUpDown_108;

	internal NumericUpDown numericUpDown_109;

	internal NumericUpDown numericUpDown_110;

	internal Label label_159;

	internal PictureBox pictureBox_9;

	internal TabPage tabPage_15;

	internal NumericUpDown numericUpDown_111;

	internal Label label_160;

	internal NumericUpDown numericUpDown_112;

	internal Label label_161;

	internal Label label_162;

	internal Label label_163;

	internal Label label_164;

	internal Label label_165;

	internal Label label_166;

	internal Label label_167;

	internal NumericUpDown numericUpDown_113;

	internal NumericUpDown numericUpDown_114;

	internal NumericUpDown numericUpDown_115;

	internal NumericUpDown numericUpDown_116;

	internal NumericUpDown numericUpDown_117;

	internal NumericUpDown numericUpDown_118;

	internal NumericUpDown numericUpDown_119;

	internal Label label_168;

	internal PictureBox pictureBox_10;

	internal TabPage tabPage_16;

	internal NumericUpDown numericUpDown_120;

	internal Label label_169;

	internal NumericUpDown numericUpDown_121;

	internal Label label_170;

	internal Label label_171;

	internal Label label_172;

	internal Label label_173;

	internal Label label_174;

	internal Label label_175;

	internal Label label_176;

	internal NumericUpDown numericUpDown_122;

	internal NumericUpDown numericUpDown_123;

	internal NumericUpDown numericUpDown_124;

	internal NumericUpDown numericUpDown_125;

	internal NumericUpDown numericUpDown_126;

	internal NumericUpDown numericUpDown_127;

	internal NumericUpDown numericUpDown_128;

	internal Label label_177;

	internal PictureBox pictureBox_11;

	internal TabPage tabPage_17;

	internal NumericUpDown numericUpDown_129;

	internal Label label_178;

	internal NumericUpDown numericUpDown_130;

	internal Label label_179;

	internal Label label_180;

	internal Label label_181;

	internal Label label_182;

	internal Label label_183;

	internal Label label_184;

	internal Label label_185;

	internal NumericUpDown numericUpDown_131;

	internal NumericUpDown numericUpDown_132;

	internal NumericUpDown numericUpDown_133;

	internal NumericUpDown numericUpDown_134;

	internal NumericUpDown numericUpDown_135;

	internal NumericUpDown numericUpDown_136;

	internal NumericUpDown numericUpDown_137;

	internal Label label_186;

	internal PictureBox pictureBox_12;

	internal TabPage tabPage_18;

	internal NumericUpDown numericUpDown_138;

	internal Label label_187;

	internal NumericUpDown numericUpDown_139;

	internal Label label_188;

	internal Label label_189;

	internal Label label_190;

	internal Label label_191;

	internal Label label_192;

	internal Label label_193;

	internal Label label_194;

	internal NumericUpDown numericUpDown_140;

	internal NumericUpDown numericUpDown_141;

	internal NumericUpDown numericUpDown_142;

	internal NumericUpDown numericUpDown_143;

	internal NumericUpDown numericUpDown_144;

	internal NumericUpDown numericUpDown_145;

	internal NumericUpDown numericUpDown_146;

	internal Label label_195;

	internal PictureBox pictureBox_13;

	internal Label label_196;

	internal NumericUpDown numericUpDown_147;

	internal Label label_197;

	internal NumericUpDown numericUpDown_148;

	internal Label label_198;

	internal NumericUpDown numericUpDown_149;

	internal Label label_199;

	internal NumericUpDown numericUpDown_150;

	internal Label label_200;

	internal NumericUpDown numericUpDown_151;

	internal Label label_201;

	internal NumericUpDown numericUpDown_152;

	internal Label label_202;

	internal NumericUpDown numericUpDown_153;

	internal TabPage tabPage_19;

	internal CheckBox checkBox_16;

	internal CheckBox checkBox_17;

	internal CheckBox checkBox_18;

	internal CheckBox checkBox_19;

	internal CheckBox checkBox_20;

	internal CheckBox checkBox_21;

	internal CheckBox checkBox_22;

	internal CheckBox checkBox_23;

	internal CheckBox checkBox_24;

	internal CheckBox checkBox_25;

	internal CheckBox checkBox_26;

	internal CheckBox checkBox_27;

	internal CheckBox checkBox_28;

	internal CheckBox checkBox_29;

	internal CheckBox checkBox_30;

	internal CheckBox checkBox_31;

	internal CheckBox checkBox_32;

	internal CheckBox checkBox_33;

	internal TabControl tabControl_2;

	internal TabPage tabPage_20;

	internal Panel panel_39;

	internal Label label_203;

	internal NumericUpDown numericUpDown_154;

	internal Label label_204;

	internal TabPage tabPage_21;

	internal TabPage tabPage_22;

	internal Panel panel_40;

	internal Label label_205;

	internal NumericUpDown numericUpDown_155;

	internal Label label_206;

	internal Panel panel_41;

	internal ComboBox comboBox_2;

	internal Label label_207;

	internal Label label_208;

	internal TextBox textBox_3;

	internal TextBox textBox_4;

	internal TextBox textBox_5;

	internal TextBox textBox_6;

	internal Panel panel_42;

	internal Label label_209;

	internal Label label_210;

	internal Label label_211;

	internal NumericUpDown numericUpDown_156;

	internal NumericUpDown numericUpDown_157;

	internal NumericUpDown numericUpDown_158;

	internal Label label_212;

	internal CheckBox checkBox_34;

	internal Label label_213;

	internal Panel panel_43;

	internal Label label_214;

	internal Label label_215;

	internal Label label_216;

	internal NumericUpDown numericUpDown_159;

	internal NumericUpDown numericUpDown_160;

	internal Label label_217;

	internal NumericUpDown numericUpDown_161;

	internal Panel panel_44;

	internal Label label_218;

	internal NumericUpDown numericUpDown_162;

	internal Label label_219;

	internal Panel panel_45;

	internal ComboBox comboBox_3;

	internal Label label_220;

	internal Label label_221;

	internal Panel panel_46;

	internal Panel panel_47;

	internal NumericUpDown numericUpDown_163;

	internal Label label_222;

	internal NumericUpDown numericUpDown_164;

	internal Label label_223;

	internal Panel panel_48;

	internal Label label_224;

	internal NumericUpDown numericUpDown_165;

	internal Label label_225;

	internal NumericUpDown numericUpDown_166;

	internal Panel panel_49;

	internal Label label_226;

	internal NumericUpDown numericUpDown_167;

	internal Label label_227;

	internal NumericUpDown numericUpDown_168;

	internal Label label_228;

	internal Label label_229;

	internal NumericUpDown numericUpDown_169;

	internal NumericUpDown numericUpDown_170;

	internal Label label_230;

	internal Label label_231;

	internal NumericUpDown numericUpDown_171;

	internal NumericUpDown numericUpDown_172;

	internal Label label_232;

	internal Label label_233;

	internal NumericUpDown numericUpDown_173;

	internal CheckBox checkBox_35;

	internal CheckBox checkBox_36;

	internal NumericUpDown numericUpDown_174;

	internal Label label_234;

	internal Label label_235;

	internal Label label_236;

	internal Label label_237;

	internal Label label_238;

	internal Label label_239;

	internal Label label_240;

	internal Label label_241;

	internal NumericUpDown numericUpDown_175;

	internal NumericUpDown numericUpDown_176;

	internal NumericUpDown numericUpDown_177;

	internal NumericUpDown numericUpDown_178;

	internal NumericUpDown numericUpDown_179;

	internal NumericUpDown numericUpDown_180;

	internal NumericUpDown numericUpDown_181;

	internal NumericUpDown numericUpDown_182;

	internal Label label_242;

	internal PictureBox pictureBox_14;

	internal CheckBox checkBox_37;

	internal CheckBox checkBox_38;

	internal CheckBox checkBox_39;

	public F_ToolAll()
	{
		Class76.smethod_568(this);
	}

	public void Init()
	{
		Properties.Inited = false;
		int top = 0;
		ArrayList arrayList = new ArrayList();
		if (Properties.Height > 10)
		{
			base.Height = Properties.Height;
		}
		if (Properties.Width > 10)
		{
			base.Width = Properties.Width;
		}
		base.TopMost = Properties.TopMost;
		btn_next.Visible = ShowNextButton;
		btn_pre.Visible = ShowPreButton;
		tabControl_1.SizeMode = TabSizeMode.Fixed;
		tabControl_1.ItemSize = new Size(0, 1);
		if (!ToolVarVisible.AuxTabVisible && tabControl_0.TabPages.Count >= 7)
		{
			tabControl_0.TabPages.RemoveAt(6);
		}
		if (!ToolVarVisible.ColorTabVisible && tabControl_0.TabPages.Count >= 6)
		{
			tabControl_0.TabPages.RemoveAt(5);
		}
		if (!ToolVarVisible.LimitTabVisible && tabControl_0.TabPages.Count >= 5)
		{
			tabControl_0.TabPages.RemoveAt(4);
		}
		if (!ToolVarVisible.PositionTabVisible && tabControl_0.TabPages.Count >= 4)
		{
			tabControl_0.TabPages.RemoveAt(3);
		}
		if (!ToolVarVisible.CamTabVisible && tabControl_0.TabPages.Count >= 3)
		{
			tabControl_0.TabPages.RemoveAt(2);
		}
		if (!ToolVarVisible.GeometryTabVisible && tabControl_0.TabPages.Count >= 2)
		{
			tabControl_0.TabPages.RemoveAt(1);
		}
		if (!ToolVarVisible.DataTabVisible && tabControl_0.TabPages.Count >= 1)
		{
			tabControl_0.TabPages.RemoveAt(0);
		}
		int num = 0;
		panel_10.Visible = ToolVarVisible.Name;
		if (ToolVarVisible.Name)
		{
			panel_10.Top = 6 + num * 32;
			num++;
		}
		panel_9.Visible = ToolVarVisible.No;
		if (ToolVarVisible.No)
		{
			panel_9.Top = 6 + num * 32;
			num++;
		}
		panel_8.Visible = ToolVarVisible.Sector;
		if (ToolVarVisible.Sector)
		{
			panel_8.Top = 6 + num * 32;
			num++;
		}
		panel_7.Visible = ToolVarVisible.HeightOffsetIndex;
		if (ToolVarVisible.HeightOffsetIndex)
		{
			panel_7.Top = 6 + num * 32;
			num++;
		}
		panel_6.Visible = ToolVarVisible.Tag;
		if (ToolVarVisible.Tag)
		{
			panel_6.Top = 6 + num * 32;
			num++;
		}
		panel_5.Visible = ToolVarVisible.Purpose;
		if (ToolVarVisible.Purpose)
		{
			panel_5.Top = 6 + num * 32;
			num++;
		}
		panel_4.Visible = ToolVarVisible.Clone;
		if (ToolVarVisible.Clone)
		{
			panel_4.Top = 6 + num * 32;
			num++;
		}
		panel_38.Visible = ToolVarVisible.Priority;
		if (ToolVarVisible.Priority)
		{
			panel_38.Top = 6 + num * 32;
			num++;
		}
		int num2 = 0;
		panel_13.Visible = ToolVarVisible.MinLength;
		if (ToolVarVisible.MinLength)
		{
			panel_13.Top = 6 + num2 * 32;
			num2++;
		}
		panel_12.Visible = ToolVarVisible.VectorDirection;
		if (ToolVarVisible.VectorDirection)
		{
			panel_12.Top = 6 + num2 * 32;
			num2++;
		}
		panel_34.Visible = ToolVarVisible.ToolType;
		if (ToolVarVisible.ToolType)
		{
			panel_34.Top = 6 + num2 * 32;
			num2++;
		}
		panel_42.Visible = ToolVarVisible.DistanceForOrientation;
		if (ToolVarVisible.DistanceForOrientation)
		{
			panel_42.Top = 6 + num2 * 32;
			top = panel_42.Top + panel_42.Height + 6;
			num2++;
		}
		panel_43.Visible = ToolVarVisible.Size;
		if (ToolVarVisible.Size)
		{
			panel_43.Top = top;
			top = panel_43.Top + panel_43.Height + 6;
			num2++;
		}
		panel_44.Visible = ToolVarVisible.Size;
		if (ToolVarVisible.Size)
		{
			panel_44.Top = top;
			top = panel_44.Top + panel_44.Height + 6;
			num2++;
		}
		int num3 = 0;
		panel_26.Visible = ToolVarVisible.CutColor;
		if (ToolVarVisible.CutColor)
		{
			panel_26.Top = 6 + num3 * 32;
			num3++;
		}
		panel_23.Visible = ToolVarVisible.SolidColor;
		if (ToolVarVisible.SolidColor)
		{
			panel_23.Top = 6 + num3 * 32;
			num3++;
		}
		panel_22.Visible = ToolVarVisible.HolderColor;
		if (ToolVarVisible.HolderColor)
		{
			panel_22.Top = 6 + num3 * 32;
			num3++;
		}
		panel_27.Visible = ToolVarVisible.BodyColor;
		if (ToolVarVisible.BodyColor)
		{
			panel_27.Top = 6 + num3 * 32;
			num3++;
		}
		panel_24.Visible = ToolVarVisible.CamColor;
		if (ToolVarVisible.CamColor)
		{
			panel_24.Top = 6 + num3 * 32;
			num3++;
		}
		panel_25.Visible = ToolVarVisible.UpperCamColor;
		if (ToolVarVisible.UpperCamColor)
		{
			panel_25.Top = 6 + num3 * 32;
			num3++;
		}
		panel_32.Visible = ToolVarVisible.PlungeColor;
		if (ToolVarVisible.PlungeColor)
		{
			panel_32.Top = 6 + num3 * 32;
			num3++;
		}
		panel_31.Visible = ToolVarVisible.LeaveColor;
		if (ToolVarVisible.LeaveColor)
		{
			panel_31.Top = 6 + num3 * 32;
			num3++;
		}
		int num4 = 0;
		panel_2.Visible = ToolVarVisible.Stepover;
		if (ToolVarVisible.Stepover)
		{
			panel_2.Top = 6 + num4 * 32;
			num4++;
		}
		panel_0.Visible = ToolVarVisible.OperationHeight;
		if (ToolVarVisible.OperationHeight)
		{
			panel_0.Top = 6 + num4 * 32;
			num4++;
		}
		panel_36.Visible = ToolVarVisible.Cutover;
		if (ToolVarVisible.Cutover)
		{
			panel_36.Top = 6 + num4 * 32;
			num4++;
		}
		panel_11.Visible = ToolVarVisible.FeedSpeed;
		if (ToolVarVisible.FeedSpeed)
		{
			panel_11.Top = 6 + num4 * 32;
			num4++;
		}
		panel_3.Visible = ToolVarVisible.PlungeSpeed;
		if (ToolVarVisible.PlungeSpeed)
		{
			panel_3.Top = 6 + num4 * 32;
			num4++;
		}
		panel_39.Visible = ToolVarVisible.FinishSpeed;
		if (ToolVarVisible.FinishSpeed)
		{
			panel_39.Top = 6 + num4 * 32;
			num4++;
		}
		panel_35.Visible = ToolVarVisible.AreaClearanceSpeed;
		if (ToolVarVisible.AreaClearanceSpeed)
		{
			panel_35.Top = 6 + num4 * 32;
			num4++;
		}
		panel_21.Visible = ToolVarVisible.SafeDistance;
		if (ToolVarVisible.SpindleDirection)
		{
			panel_21.Top = 6 + num4 * 32;
			num4++;
		}
		panel_16.Visible = ToolVarVisible.OperationHeigthForSecond;
		if (ToolVarVisible.OperationHeigthForSecond)
		{
			panel_16.Top = 6 + num4 * 32;
			num4++;
		}
		panel_40.Visible = ToolVarVisible.SpindleSpeed;
		panel_41.Visible = ToolVarVisible.SpindleDirection;
		checkBox_10.Visible = ToolVarVisible.Air;
		textBox_5.Visible = ToolVarVisible.Air;
		checkBox_11.Visible = ToolVarVisible.Water;
		textBox_6.Visible = ToolVarVisible.Water;
		checkBox_9.Visible = ToolVarVisible.Oil;
		textBox_3.Visible = ToolVarVisible.Oil;
		checkBox_8.Visible = ToolVarVisible.InnerCooling;
		textBox_4.Visible = ToolVarVisible.InnerCooling;
		panel_33.Visible = ToolVarVisible.Outputs;
		int num5 = 0;
		panel_14.Visible = ToolVarVisible.AngularPosition;
		if (ToolVarVisible.AngularPosition)
		{
			panel_14.Top = 40 + num5 * 32;
			num5++;
		}
		panel_17.Visible = ToolVarVisible.SetPositionXYZ;
		if (ToolVarVisible.SetPositionXYZ)
		{
			panel_17.Top = 40 + num5 * 32;
			num5++;
		}
		panel_18.Visible = ToolVarVisible.SetPositionABC;
		if (ToolVarVisible.SetPositionABC)
		{
			panel_18.Top = 40 + num5 * 32;
			num5++;
		}
		panel_15.Visible = ToolVarVisible.OffsetXYZ;
		if (ToolVarVisible.OffsetXYZ)
		{
			panel_15.Top = 40 + num5 * 32;
			num5++;
		}
		panel_1.Visible = ToolVarVisible.OffsetABC;
		if (ToolVarVisible.OffsetABC)
		{
			panel_1.Top = 40 + num5 * 32;
			num5++;
		}
		panel_20.Visible = ToolVarVisible.PlaneLimits;
		if (panel_20.Visible)
		{
			panel_19.Top = panel_20.Top + panel_20.Height + 6;
		}
		panel_29.Visible = ToolVarVisible.LimitAxisA;
		panel_30.Visible = ToolVarVisible.LimitAxisB;
		panel_28.Visible = ToolVarVisible.LimitAxisC;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Purpose, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Purpose), ref comboBox_0);
		numericUpDown_10.Value = Tool.Data.No;
		numericUpDown_9.Value = Tool.Data.Sector;
		numericUpDown_8.Value = Tool.Data.HeightOffsetIndex;
		numericUpDown_82.Value = Tool.Data.Priority;
		textBox_1.Text = Tool.Data.Name;
		textBox_0.Text = Tool.Data.Tag;
		checkBox_0.Checked = Tool.Data.Clone;
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Geometry.GeometryType, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Geometry.GeometryType), ref comboBox_1);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.Geometry.FlatGeometry, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.Geometry.FlatGeometry), ref comboBox_3);
		numericUpDown_14.Value = (decimal)Tool.Geometry.MinLength;
		numericUpDown_13.Value = (decimal)Tool.Geometry.PlaneDirection.X;
		numericUpDown_12.Value = (decimal)Tool.Geometry.PlaneDirection.Y;
		numericUpDown_11.Value = (decimal)Tool.Geometry.PlaneDirection.Z;
		numericUpDown_158.Value = (decimal)Tool.Geometry.DistanceForOrientation.X;
		numericUpDown_157.Value = (decimal)Tool.Geometry.DistanceForOrientation.Y;
		numericUpDown_156.Value = (decimal)Tool.Geometry.DistanceForOrientation.Z;
		checkBox_34.Checked = Tool.Geometry.AddHalfOfToolThicknessToDistance;
		numericUpDown_161.Value = (decimal)Tool.Geometry.SizeWidth;
		numericUpDown_160.Value = (decimal)Tool.Geometry.SizeDepth;
		numericUpDown_159.Value = (decimal)Tool.Geometry.SizeHeight;
		numericUpDown_162.Value = (decimal)Tool.Geometry.PositionAngle;
		numericUpDown_25.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_33.Value = (decimal)Tool.Geometry.CutLength;
		numericUpDown_32.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_27.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_26.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_30.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_29.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_28.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_31.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_34.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_42.Value = (decimal)Tool.Geometry.CutLength;
		numericUpDown_41.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_36.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_35.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_39.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_38.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_37.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_40.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_43.Value = (decimal)Tool.Geometry.BottomDiameter;
		numericUpDown_67.Value = (decimal)Tool.Geometry.TopDiameter;
		numericUpDown_51.Value = (decimal)Tool.Geometry.CutLength;
		numericUpDown_50.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_45.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_44.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_48.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_47.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_46.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_49.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_52.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_60.Value = (decimal)Tool.Geometry.Thickness;
		numericUpDown_59.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_54.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_53.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_57.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_56.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_55.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_58.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_71.Value = (decimal)Tool.Geometry.LengthDiameter;
		numericUpDown_73.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_72.Value = (decimal)Tool.Geometry.RoundRadius;
		numericUpDown_81.Value = (decimal)Tool.Geometry.CutLength;
		numericUpDown_80.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_75.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_74.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_78.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_77.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_76.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_79.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_85.Value = (decimal)Tool.Geometry.Diameter;
		numericUpDown_92.Value = (decimal)Tool.Geometry.CutLength;
		numericUpDown_91.Value = (decimal)Tool.Geometry.Length;
		numericUpDown_147.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_86.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_89.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_88.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_87.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_90.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_83.Value = (decimal)Tool.Geometry.LowerRadius;
		numericUpDown_84.Value = (decimal)Tool.Geometry.TaperAngle;
		numericUpDown_174.Value = (decimal)Tool.Geometry.DiameterLeft;
		numericUpDown_172.Value = (decimal)Tool.Geometry.DiameterRight;
		numericUpDown_170.Value = (decimal)Tool.Geometry.CutLengthLeft;
		numericUpDown_182.Value = (decimal)Tool.Geometry.CutLengthRight;
		numericUpDown_169.Value = (decimal)Tool.Geometry.LengthLeft;
		numericUpDown_171.Value = (decimal)Tool.Geometry.LengthRigth;
		numericUpDown_176.Value = (decimal)Tool.Geometry.HolderInDiameter;
		numericUpDown_175.Value = (decimal)Tool.Geometry.HolderDiameter;
		numericUpDown_179.Value = (decimal)Tool.Geometry.HolderLength;
		numericUpDown_178.Value = (decimal)Tool.Geometry.ArborBottomDiameter;
		numericUpDown_177.Value = (decimal)Tool.Geometry.ArborTopDiameter;
		numericUpDown_180.Value = (decimal)Tool.Geometry.ArborLength;
		numericUpDown_181.Value = (decimal)Tool.Geometry.AgregateVerticalLength;
		numericUpDown_173.Value = (decimal)Tool.Geometry.AgregateToolCenterLength;
		checkBox_38.Checked = Tool.Geometry.AgregateLeftEnable;
		checkBox_37.Checked = Tool.Geometry.AgregateRightEnable;
		checkBox_39.Checked = Tool.Geometry.AgregateCircleBody;
		if (Tool.Geometry.CornerRadiusType != ToolCornerRadiusType.None)
		{
			if (Tool.Geometry.CornerRadiusType != ToolCornerRadiusType.Corner)
			{
				radioButton_0.Checked = true;
			}
			else
			{
				radioButton_1.Checked = true;
			}
		}
		else
		{
			radioButton_2.Checked = true;
		}
		checkBox_20.Checked = Tool.Geometry.DrawArbor;
		checkBox_21.Checked = Tool.Geometry.DrawHolder;
		checkBox_19.Checked = Tool.Geometry.DrawLength;
		checkBox_17.Checked = Tool.Geometry.DrawArbor;
		checkBox_18.Checked = Tool.Geometry.DrawHolder;
		checkBox_16.Checked = Tool.Geometry.DrawLength;
		checkBox_29.Checked = Tool.Geometry.DrawArbor;
		checkBox_30.Checked = Tool.Geometry.DrawHolder;
		checkBox_28.Checked = Tool.Geometry.DrawLength;
		checkBox_23.Checked = Tool.Geometry.DrawArbor;
		checkBox_24.Checked = Tool.Geometry.DrawHolder;
		checkBox_22.Checked = Tool.Geometry.DrawLength;
		checkBox_32.Checked = Tool.Geometry.DrawArbor;
		checkBox_33.Checked = Tool.Geometry.DrawHolder;
		checkBox_31.Checked = Tool.Geometry.DrawLength;
		checkBox_26.Checked = Tool.Geometry.DrawArbor;
		checkBox_27.Checked = Tool.Geometry.DrawHolder;
		checkBox_25.Checked = Tool.Geometry.DrawLength;
		checkBox_35.Checked = Tool.Geometry.DrawArbor;
		checkBox_36.Checked = Tool.Geometry.DrawHolder;
		Class76.smethod_217(this);
		arrayList = new ArrayList();
		buGeneral.GetEnumTypeValues(Tool.CamData.SpindleDirection, ref arrayList);
		buControlCommands.ComboboxAddItem(arrayList, Convert.ToInt32(Tool.CamData.SpindleDirection), ref comboBox_2);
		numericUpDown_3.Value = (decimal)Tool.CamData.Stepover;
		numericUpDown_70.Value = (decimal)Tool.CamData.Cutover;
		numericUpDown_1.Value = (decimal)Tool.CamData.OperationHeight;
		numericUpDown_0.Value = (decimal)Tool.CamData.FeedSpeed;
		numericUpDown_69.Value = (decimal)Tool.CamData.AreaClearanceSpeed;
		numericUpDown_154.Value = (decimal)Tool.CamData.FinishSpeed;
		numericUpDown_2.Value = (decimal)Tool.CamData.PlungeSpeed;
		numericUpDown_155.Value = (decimal)Tool.CamData.SpindleSpeed;
		numericUpDown_68.Value = (decimal)Tool.CamData.SafeDistance;
		numericUpDown_7.Value = (decimal)Tool.CamData.OperationHeigthForSecond;
		checkBox_10.Checked = Tool.CamData.Air;
		checkBox_8.Checked = Tool.CamData.InnerCooling;
		checkBox_9.Checked = Tool.CamData.Oil;
		checkBox_11.Checked = Tool.CamData.Water;
		textBox_5.Text = buString.ArrayListToString(Tool.CamData.AirText, NewLineEnable: true);
		textBox_6.Text = buString.ArrayListToString(Tool.CamData.WaterText, NewLineEnable: true);
		textBox_4.Text = buString.ArrayListToString(Tool.CamData.InnerCoolText, NewLineEnable: true);
		textBox_3.Text = buString.ArrayListToString(Tool.CamData.OilText, NewLineEnable: true);
		label_89.BackColor = Tool.Display.ToolBodySolid.SkinColor;
		label_98.BackColor = Tool.Display.ToolCutSolid.SkinColor;
		label_86.BackColor = Tool.Display.HolderSolid.SkinColor;
		label_101.BackColor = Tool.Display.ArborSolid.SkinColor;
		label_92.BackColor = Tool.Display.CamColor;
		label_95.BackColor = Tool.Display.UpperCamColor;
		label_107.BackColor = Tool.Display.PlungeColor;
		label_104.BackColor = Tool.Display.LeaveColor;
		numericUpDown_15.Value = (decimal)Tool.Positions.AngularPosition;
		numericUpDown_23.Value = (decimal)Tool.Positions.Position.X;
		numericUpDown_22.Value = (decimal)Tool.Positions.Position.Y;
		numericUpDown_21.Value = (decimal)Tool.Positions.Position.Z;
		numericUpDown_24.Value = (decimal)Tool.Positions.Position.A;
		numericUpDown_17.Value = (decimal)Tool.Positions.Position.B;
		numericUpDown_16.Value = (decimal)Tool.Positions.Position.C;
		numericUpDown_20.Value = (decimal)Tool.Positions.Offset.X;
		numericUpDown_19.Value = (decimal)Tool.Positions.Offset.Y;
		numericUpDown_18.Value = (decimal)Tool.Positions.Offset.Z;
		numericUpDown_6.Value = (decimal)Tool.Positions.Offset.A;
		numericUpDown_5.Value = (decimal)Tool.Positions.Offset.B;
		numericUpDown_4.Value = (decimal)Tool.Positions.Offset.C;
		numericUpDown_66.Value = (decimal)Tool.Limits.AxesMinLimits.A;
		numericUpDown_64.Value = (decimal)Tool.Limits.AxesMinLimits.B;
		numericUpDown_62.Value = (decimal)Tool.Limits.AxesMinLimits.C;
		numericUpDown_65.Value = (decimal)Tool.Limits.AxesMaxLimits.A;
		numericUpDown_63.Value = (decimal)Tool.Limits.AxesMaxLimits.B;
		numericUpDown_61.Value = (decimal)Tool.Limits.AxesMaxLimits.C;
		numericUpDown_165.Value = (decimal)Tool.Limits.AxesMinLimits.X;
		numericUpDown_167.Value = (decimal)Tool.Limits.AxesMinLimits.Y;
		numericUpDown_164.Value = (decimal)Tool.Limits.AxesMinLimits.Z;
		numericUpDown_166.Value = (decimal)Tool.Limits.AxesMaxLimits.X;
		numericUpDown_168.Value = (decimal)Tool.Limits.AxesMaxLimits.Y;
		numericUpDown_163.Value = (decimal)Tool.Limits.AxesMaxLimits.Z;
		checkBox_7.Checked = Tool.Limits.PlaneTop;
		checkBox_6.Checked = Tool.Limits.PlaneBottom;
		checkBox_3.Checked = Tool.Limits.PlaneFront;
		checkBox_2.Checked = Tool.Limits.PlaneBack;
		checkBox_5.Checked = Tool.Limits.PlaneLeft;
		checkBox_4.Checked = Tool.Limits.PlaneRight;
		checkBox_1.Checked = Tool.Limits.PlaneAll;
		checkBox_12.Checked = Tool.Limits.PlaneSlope;
		checkBox_15.Checked = Tool.Limits.RotationA;
		checkBox_14.Checked = Tool.Limits.RotationB;
		checkBox_13.Checked = Tool.Limits.RotationC;
		textBox_2.Text = buString.ArrayListToString(Tool.Aux, NewLineEnable: true);
		if (Tool.Geometry.GeometryType == ToolType.Flat)
		{
			tabControl_1.SelectedIndex = 0;
		}
		if (Tool.Geometry.GeometryType == ToolType.Sphere)
		{
			tabControl_1.SelectedIndex = 1;
		}
		if (Tool.Geometry.GeometryType == ToolType.Saw)
		{
			tabControl_1.SelectedIndex = 2;
		}
		if (Tool.Geometry.GeometryType == ToolType.Bullnose)
		{
			tabControl_1.SelectedIndex = 4;
		}
		if (Tool.Geometry.GeometryType == ToolType.Taper)
		{
			tabControl_1.SelectedIndex = 6;
		}
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
		LoadLangueage();
	}

	public void LoadLangueage()
	{
		string callMethod = "ToolDetailed LoadLanguage";
		try
		{
			if (Captions.Count >= 67)
			{
				Text = Captions[0];
				tabPage_0.Text = Captions[1];
				label_24.Text = Captions[2];
				label_22.Text = Captions[3];
				label_20.Text = Captions[4];
				label_18.Text = Captions[5];
				label_16.Text = Captions[6];
				label_14.Text = Captions[7];
				label_12.Text = Captions[8];
				label_110.Text = Captions[9];
				label_25.Text = Captions[10];
				label_23.Text = Captions[11];
				label_21.Text = Captions[12];
				label_19.Text = Captions[13];
				label_17.Text = Captions[14];
				label_15.Text = Captions[15];
				label_13.Text = Captions[16];
				tabPage_1.Text = Captions[18];
				label_28.Text = Captions[22];
				label_27.Text = Captions[23];
				label_99.Text = Captions[24];
				label_93.Text = Captions[25];
				label_96.Text = Captions[26];
				label_29.Text = Captions[30];
				label_26.Text = Captions[31];
				label_100.Text = Captions[32];
				label_94.Text = Captions[33];
				label_97.Text = Captions[34];
				tabPage_2.Text = Captions[35];
				label_5.Text = Captions[36];
				label_3.Text = Captions[37];
				label_0.Text = Captions[38];
				label_1.Text = Captions[39];
				label_205.Text = Captions[40];
				label_207.Text = Captions[41];
				label_10.Text = Captions[42];
				label_6.Text = Captions[43];
				label_4.Text = Captions[44];
				label_2.Text = Captions[45];
				label_9.Text = Captions[46];
				label_206.Text = Captions[47];
				label_208.Text = Captions[48];
				label_11.Text = Captions[49];
				tabPage_3.Text = Captions[50];
				label_31.Text = Captions[51];
				label_37.Text = Captions[52];
				label_38.Text = Captions[53];
				label_35.Text = Captions[54];
				label_8.Text = Captions[55];
				label_32.Text = Captions[56];
				label_36.Text = Captions[57];
				label_33.Text = Captions[58];
				label_34.Text = Captions[59];
				label_7.Text = Captions[60];
				textBox_2.Text = Captions[61];
				label_30.Text = Captions[62];
				btn_ok.Text = Captions[63];
				btn_cancel.Text = Captions[64];
				btn_pre.Text = Captions[65];
				btn_next.Text = Captions[66];
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", callMethod);
			buException.throwException(mSException, callMethod, ShowMessageBox: true, text);
		}
	}

	internal void method_0(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (!Properties.Inited)
		{
			return;
		}
		if (control.Name == btn_ok.Name)
		{
			Class76.smethod_161(this);
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
	}

	internal void method_1(object sender, FormClosingEventArgs e)
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

	internal void method_2(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (control.Name == label_98.Name)
		{
			Color cColor = label_98.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor) == DialogResult.OK)
			{
				label_98.BackColor = cColor;
			}
		}
		if (control.Name == label_89.Name)
		{
			Color cColor2 = label_89.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor2) == DialogResult.OK)
			{
				label_89.BackColor = cColor2;
			}
		}
		if (control.Name == label_101.Name)
		{
			Color cColor3 = label_101.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor3) == DialogResult.OK)
			{
				label_101.BackColor = cColor3;
			}
		}
		if (control.Name == label_86.Name)
		{
			Color cColor4 = label_86.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor4) == DialogResult.OK)
			{
				label_86.BackColor = cColor4;
			}
		}
		if (control.Name == label_92.Name)
		{
			Color cColor5 = label_92.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor5) == DialogResult.OK)
			{
				label_92.BackColor = cColor5;
			}
		}
		if (control.Name == label_95.Name)
		{
			Color cColor6 = label_95.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor6) == DialogResult.OK)
			{
				label_95.BackColor = cColor6;
			}
		}
		if (control.Name == label_107.Name)
		{
			Color cColor7 = label_107.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor7) == DialogResult.OK)
			{
				label_107.BackColor = cColor7;
			}
		}
		if (control.Name == label_104.Name)
		{
			Color cColor8 = label_104.BackColor;
			if (ColorDialogBox.ShowDialog(ref cColor8) == DialogResult.OK)
			{
				label_104.BackColor = cColor8;
			}
		}
	}

	internal void method_3(object sender, EventArgs e)
	{
		if (Properties.Inited)
		{
			tabControl_1.SelectedIndex = comboBox_1.SelectedIndex;
		}
	}

	internal void method_4(object sender, EventArgs e)
	{
		Control control = new Control();
		control = (Control)sender;
		if (Properties.Inited && ((control.Name == radioButton_1.Name) | (control.Name == radioButton_0.Name) | (control.Name == radioButton_2.Name)))
		{
			if (radioButton_2.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
			}
			if (radioButton_1.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
			}
			if (radioButton_0.Checked)
			{
				Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
			}
			Class76.smethod_217(this);
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
