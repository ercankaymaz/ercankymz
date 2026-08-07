// Decompiled with JetBrains decompiler
// Type: buControls.Forms.WinControlForms.Tools.F_ToolAll
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.DialogBox;
using buCore;
using ns7;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
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
  internal IContainer icontainer_0 = (IContainer) null;
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

  public F_ToolAll() => Class39.smethod_568(this);

  public void Init()
  {
    this.Properties.Inited = false;
    int num1 = 0;
    ArrayList arrayList = new ArrayList();
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.btn_next.Visible = this.ShowNextButton;
    this.btn_pre.Visible = this.ShowPreButton;
    this.tabControl_1.SizeMode = TabSizeMode.Fixed;
    this.tabControl_1.ItemSize = new Size(0, 1);
    if (!this.ToolVarVisible.AuxTabVisible && this.tabControl_0.TabPages.Count >= 7)
      this.tabControl_0.TabPages.RemoveAt(6);
    if (!this.ToolVarVisible.ColorTabVisible && this.tabControl_0.TabPages.Count >= 6)
      this.tabControl_0.TabPages.RemoveAt(5);
    if (!this.ToolVarVisible.LimitTabVisible && this.tabControl_0.TabPages.Count >= 5)
      this.tabControl_0.TabPages.RemoveAt(4);
    if (!this.ToolVarVisible.PositionTabVisible && this.tabControl_0.TabPages.Count >= 4)
      this.tabControl_0.TabPages.RemoveAt(3);
    if (!this.ToolVarVisible.CamTabVisible && this.tabControl_0.TabPages.Count >= 3)
      this.tabControl_0.TabPages.RemoveAt(2);
    if (!this.ToolVarVisible.GeometryTabVisible && this.tabControl_0.TabPages.Count >= 2)
      this.tabControl_0.TabPages.RemoveAt(1);
    if (!this.ToolVarVisible.DataTabVisible && this.tabControl_0.TabPages.Count >= 1)
      this.tabControl_0.TabPages.RemoveAt(0);
    int num2 = 0;
    this.panel_10.Visible = this.ToolVarVisible.Name;
    if (this.ToolVarVisible.Name)
    {
      this.panel_10.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_9.Visible = this.ToolVarVisible.No;
    if (this.ToolVarVisible.No)
    {
      this.panel_9.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_8.Visible = this.ToolVarVisible.Sector;
    if (this.ToolVarVisible.Sector)
    {
      this.panel_8.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_7.Visible = this.ToolVarVisible.HeightOffsetIndex;
    if (this.ToolVarVisible.HeightOffsetIndex)
    {
      this.panel_7.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_6.Visible = this.ToolVarVisible.Tag;
    if (this.ToolVarVisible.Tag)
    {
      this.panel_6.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_5.Visible = this.ToolVarVisible.Purpose;
    if (this.ToolVarVisible.Purpose)
    {
      this.panel_5.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_4.Visible = this.ToolVarVisible.Clone;
    if (this.ToolVarVisible.Clone)
    {
      this.panel_4.Top = 6 + num2 * 32 /*0x20*/;
      ++num2;
    }
    this.panel_38.Visible = this.ToolVarVisible.Priority;
    if (this.ToolVarVisible.Priority)
    {
      this.panel_38.Top = 6 + num2 * 32 /*0x20*/;
      int num3 = num2 + 1;
    }
    int num4 = 0;
    this.panel_13.Visible = this.ToolVarVisible.MinLength;
    if (this.ToolVarVisible.MinLength)
    {
      this.panel_13.Top = 6 + num4 * 32 /*0x20*/;
      ++num4;
    }
    this.panel_12.Visible = this.ToolVarVisible.VectorDirection;
    if (this.ToolVarVisible.VectorDirection)
    {
      this.panel_12.Top = 6 + num4 * 32 /*0x20*/;
      ++num4;
    }
    this.panel_34.Visible = this.ToolVarVisible.ToolType;
    if (this.ToolVarVisible.ToolType)
    {
      this.panel_34.Top = 6 + num4 * 32 /*0x20*/;
      ++num4;
    }
    this.panel_42.Visible = this.ToolVarVisible.DistanceForOrientation;
    if (this.ToolVarVisible.DistanceForOrientation)
    {
      this.panel_42.Top = 6 + num4 * 32 /*0x20*/;
      num1 = this.panel_42.Top + this.panel_42.Height + 6;
      ++num4;
    }
    this.panel_43.Visible = this.ToolVarVisible.Size;
    if (this.ToolVarVisible.Size)
    {
      this.panel_43.Top = num1;
      num1 = this.panel_43.Top + this.panel_43.Height + 6;
      ++num4;
    }
    this.panel_44.Visible = this.ToolVarVisible.Size;
    if (this.ToolVarVisible.Size)
    {
      this.panel_44.Top = num1;
      int num5 = this.panel_44.Top + this.panel_44.Height + 6;
      int num6 = num4 + 1;
    }
    int num7 = 0;
    this.panel_26.Visible = this.ToolVarVisible.CutColor;
    if (this.ToolVarVisible.CutColor)
    {
      this.panel_26.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_23.Visible = this.ToolVarVisible.SolidColor;
    if (this.ToolVarVisible.SolidColor)
    {
      this.panel_23.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_22.Visible = this.ToolVarVisible.HolderColor;
    if (this.ToolVarVisible.HolderColor)
    {
      this.panel_22.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_27.Visible = this.ToolVarVisible.BodyColor;
    if (this.ToolVarVisible.BodyColor)
    {
      this.panel_27.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_24.Visible = this.ToolVarVisible.CamColor;
    if (this.ToolVarVisible.CamColor)
    {
      this.panel_24.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_25.Visible = this.ToolVarVisible.UpperCamColor;
    if (this.ToolVarVisible.UpperCamColor)
    {
      this.panel_25.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_32.Visible = this.ToolVarVisible.PlungeColor;
    if (this.ToolVarVisible.PlungeColor)
    {
      this.panel_32.Top = 6 + num7 * 32 /*0x20*/;
      ++num7;
    }
    this.panel_31.Visible = this.ToolVarVisible.LeaveColor;
    if (this.ToolVarVisible.LeaveColor)
    {
      this.panel_31.Top = 6 + num7 * 32 /*0x20*/;
      int num8 = num7 + 1;
    }
    int num9 = 0;
    this.panel_2.Visible = this.ToolVarVisible.Stepover;
    if (this.ToolVarVisible.Stepover)
    {
      this.panel_2.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_0.Visible = this.ToolVarVisible.OperationHeight;
    if (this.ToolVarVisible.OperationHeight)
    {
      this.panel_0.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_36.Visible = this.ToolVarVisible.Cutover;
    if (this.ToolVarVisible.Cutover)
    {
      this.panel_36.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_11.Visible = this.ToolVarVisible.FeedSpeed;
    if (this.ToolVarVisible.FeedSpeed)
    {
      this.panel_11.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_3.Visible = this.ToolVarVisible.PlungeSpeed;
    if (this.ToolVarVisible.PlungeSpeed)
    {
      this.panel_3.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_39.Visible = this.ToolVarVisible.FinishSpeed;
    if (this.ToolVarVisible.FinishSpeed)
    {
      this.panel_39.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_35.Visible = this.ToolVarVisible.AreaClearanceSpeed;
    if (this.ToolVarVisible.AreaClearanceSpeed)
    {
      this.panel_35.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_21.Visible = this.ToolVarVisible.SafeDistance;
    if (this.ToolVarVisible.SpindleDirection)
    {
      this.panel_21.Top = 6 + num9 * 32 /*0x20*/;
      ++num9;
    }
    this.panel_16.Visible = this.ToolVarVisible.OperationHeigthForSecond;
    if (this.ToolVarVisible.OperationHeigthForSecond)
    {
      this.panel_16.Top = 6 + num9 * 32 /*0x20*/;
      int num10 = num9 + 1;
    }
    this.panel_40.Visible = this.ToolVarVisible.SpindleSpeed;
    this.panel_41.Visible = this.ToolVarVisible.SpindleDirection;
    this.checkBox_10.Visible = this.ToolVarVisible.Air;
    this.textBox_5.Visible = this.ToolVarVisible.Air;
    this.checkBox_11.Visible = this.ToolVarVisible.Water;
    this.textBox_6.Visible = this.ToolVarVisible.Water;
    this.checkBox_9.Visible = this.ToolVarVisible.Oil;
    this.textBox_3.Visible = this.ToolVarVisible.Oil;
    this.checkBox_8.Visible = this.ToolVarVisible.InnerCooling;
    this.textBox_4.Visible = this.ToolVarVisible.InnerCooling;
    this.panel_33.Visible = this.ToolVarVisible.Outputs;
    int num11 = 0;
    this.panel_14.Visible = this.ToolVarVisible.AngularPosition;
    if (this.ToolVarVisible.AngularPosition)
    {
      this.panel_14.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_17.Visible = this.ToolVarVisible.SetPositionXYZ;
    if (this.ToolVarVisible.SetPositionXYZ)
    {
      this.panel_17.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_18.Visible = this.ToolVarVisible.SetPositionABC;
    if (this.ToolVarVisible.SetPositionABC)
    {
      this.panel_18.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_15.Visible = this.ToolVarVisible.OffsetXYZ;
    if (this.ToolVarVisible.OffsetXYZ)
    {
      this.panel_15.Top = 40 + num11 * 32 /*0x20*/;
      ++num11;
    }
    this.panel_1.Visible = this.ToolVarVisible.OffsetABC;
    if (this.ToolVarVisible.OffsetABC)
    {
      this.panel_1.Top = 40 + num11 * 32 /*0x20*/;
      int num12 = num11 + 1;
    }
    this.panel_20.Visible = this.ToolVarVisible.PlaneLimits;
    if (this.panel_20.Visible)
      this.panel_19.Top = this.panel_20.Top + this.panel_20.Height + 6;
    this.panel_29.Visible = this.ToolVarVisible.LimitAxisA;
    this.panel_30.Visible = this.ToolVarVisible.LimitAxisB;
    this.panel_28.Visible = this.ToolVarVisible.LimitAxisC;
    ArrayList EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Purpose, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Tool.Purpose), ref this.comboBox_0);
    this.numericUpDown_10.Value = (Decimal) this.Tool.Data.No;
    this.numericUpDown_9.Value = (Decimal) this.Tool.Data.Sector;
    this.numericUpDown_8.Value = (Decimal) this.Tool.Data.HeightOffsetIndex;
    this.numericUpDown_82.Value = (Decimal) this.Tool.Data.Priority;
    this.textBox_1.Text = this.Tool.Data.Name;
    this.textBox_0.Text = this.Tool.Data.Tag;
    this.checkBox_0.Checked = this.Tool.Data.Clone;
    EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Geometry.GeometryType, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Tool.Geometry.GeometryType), ref this.comboBox_1);
    EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.Geometry.FlatGeometry, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Tool.Geometry.FlatGeometry), ref this.comboBox_3);
    this.numericUpDown_14.Value = (Decimal) this.Tool.Geometry.MinLength;
    this.numericUpDown_13.Value = (Decimal) this.Tool.Geometry.PlaneDirection.X;
    this.numericUpDown_12.Value = (Decimal) this.Tool.Geometry.PlaneDirection.Y;
    this.numericUpDown_11.Value = (Decimal) this.Tool.Geometry.PlaneDirection.Z;
    this.numericUpDown_158.Value = (Decimal) this.Tool.Geometry.DistanceForOrientation.X;
    this.numericUpDown_157.Value = (Decimal) this.Tool.Geometry.DistanceForOrientation.Y;
    this.numericUpDown_156.Value = (Decimal) this.Tool.Geometry.DistanceForOrientation.Z;
    this.checkBox_34.Checked = this.Tool.Geometry.AddHalfOfToolThicknessToDistance;
    this.numericUpDown_161.Value = (Decimal) this.Tool.Geometry.SizeWidth;
    this.numericUpDown_160.Value = (Decimal) this.Tool.Geometry.SizeDepth;
    this.numericUpDown_159.Value = (Decimal) this.Tool.Geometry.SizeHeight;
    this.numericUpDown_162.Value = (Decimal) this.Tool.Geometry.PositionAngle;
    this.numericUpDown_25.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_33.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.numericUpDown_32.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_27.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_26.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_30.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_29.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_28.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_31.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_34.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_42.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.numericUpDown_41.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_36.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_35.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_39.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_38.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_37.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_40.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_43.Value = (Decimal) this.Tool.Geometry.BottomDiameter;
    this.numericUpDown_67.Value = (Decimal) this.Tool.Geometry.TopDiameter;
    this.numericUpDown_51.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.numericUpDown_50.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_45.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_44.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_48.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_47.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_46.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_49.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_52.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_60.Value = (Decimal) this.Tool.Geometry.Thickness;
    this.numericUpDown_59.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_54.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_53.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_57.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_56.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_55.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_58.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_71.Value = (Decimal) this.Tool.Geometry.LengthDiameter;
    this.numericUpDown_73.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_72.Value = (Decimal) this.Tool.Geometry.RoundRadius;
    this.numericUpDown_81.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.numericUpDown_80.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_75.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_74.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_78.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_77.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_76.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_79.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_85.Value = (Decimal) this.Tool.Geometry.Diameter;
    this.numericUpDown_92.Value = (Decimal) this.Tool.Geometry.CutLength;
    this.numericUpDown_91.Value = (Decimal) this.Tool.Geometry.Length;
    this.numericUpDown_147.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_86.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_89.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_88.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_87.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_90.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_83.Value = (Decimal) this.Tool.Geometry.LowerRadius;
    this.numericUpDown_84.Value = (Decimal) this.Tool.Geometry.TaperAngle;
    this.numericUpDown_174.Value = (Decimal) this.Tool.Geometry.DiameterLeft;
    this.numericUpDown_172.Value = (Decimal) this.Tool.Geometry.DiameterRight;
    this.numericUpDown_170.Value = (Decimal) this.Tool.Geometry.CutLengthLeft;
    this.numericUpDown_182.Value = (Decimal) this.Tool.Geometry.CutLengthRight;
    this.numericUpDown_169.Value = (Decimal) this.Tool.Geometry.LengthLeft;
    this.numericUpDown_171.Value = (Decimal) this.Tool.Geometry.LengthRigth;
    this.numericUpDown_176.Value = (Decimal) this.Tool.Geometry.HolderInDiameter;
    this.numericUpDown_175.Value = (Decimal) this.Tool.Geometry.HolderDiameter;
    this.numericUpDown_179.Value = (Decimal) this.Tool.Geometry.HolderLength;
    this.numericUpDown_178.Value = (Decimal) this.Tool.Geometry.ArborBottomDiameter;
    this.numericUpDown_177.Value = (Decimal) this.Tool.Geometry.ArborTopDiameter;
    this.numericUpDown_180.Value = (Decimal) this.Tool.Geometry.ArborLength;
    this.numericUpDown_181.Value = (Decimal) this.Tool.Geometry.AgregateVerticalLength;
    this.numericUpDown_173.Value = (Decimal) this.Tool.Geometry.AgregateToolCenterLength;
    this.checkBox_38.Checked = this.Tool.Geometry.AgregateLeftEnable;
    this.checkBox_37.Checked = this.Tool.Geometry.AgregateRightEnable;
    this.checkBox_39.Checked = this.Tool.Geometry.AgregateCircleBody;
    if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.None)
      this.radioButton_2.Checked = true;
    else if (this.Tool.Geometry.CornerRadiusType == ToolCornerRadiusType.Corner)
      this.radioButton_1.Checked = true;
    else
      this.radioButton_0.Checked = true;
    this.checkBox_20.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_21.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_19.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_17.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_18.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_16.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_29.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_30.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_28.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_23.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_24.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_22.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_32.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_33.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_31.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_26.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_27.Checked = this.Tool.Geometry.DrawHolder;
    this.checkBox_25.Checked = this.Tool.Geometry.DrawLength;
    this.checkBox_35.Checked = this.Tool.Geometry.DrawArbor;
    this.checkBox_36.Checked = this.Tool.Geometry.DrawHolder;
    Class39.smethod_217(this);
    EnumItems = new ArrayList();
    buGeneral.GetEnumTypeValues((object) this.Tool.CamData.SpindleDirection, ref EnumItems);
    buControlCommands.ComboboxAddItem(EnumItems, Convert.ToInt32((object) this.Tool.CamData.SpindleDirection), ref this.comboBox_2);
    this.numericUpDown_3.Value = (Decimal) this.Tool.CamData.Stepover;
    this.numericUpDown_70.Value = (Decimal) this.Tool.CamData.Cutover;
    this.numericUpDown_1.Value = (Decimal) this.Tool.CamData.OperationHeight;
    this.numericUpDown_0.Value = (Decimal) this.Tool.CamData.FeedSpeed;
    this.numericUpDown_69.Value = (Decimal) this.Tool.CamData.AreaClearanceSpeed;
    this.numericUpDown_154.Value = (Decimal) this.Tool.CamData.FinishSpeed;
    this.numericUpDown_2.Value = (Decimal) this.Tool.CamData.PlungeSpeed;
    this.numericUpDown_155.Value = (Decimal) this.Tool.CamData.SpindleSpeed;
    this.numericUpDown_68.Value = (Decimal) this.Tool.CamData.SafeDistance;
    this.numericUpDown_7.Value = (Decimal) this.Tool.CamData.OperationHeigthForSecond;
    this.checkBox_10.Checked = this.Tool.CamData.Air;
    this.checkBox_8.Checked = this.Tool.CamData.InnerCooling;
    this.checkBox_9.Checked = this.Tool.CamData.Oil;
    this.checkBox_11.Checked = this.Tool.CamData.Water;
    this.textBox_5.Text = buString.ArrayListToString(this.Tool.CamData.AirText, true);
    this.textBox_6.Text = buString.ArrayListToString(this.Tool.CamData.WaterText, true);
    this.textBox_4.Text = buString.ArrayListToString(this.Tool.CamData.InnerCoolText, true);
    this.textBox_3.Text = buString.ArrayListToString(this.Tool.CamData.OilText, true);
    this.label_89.BackColor = this.Tool.Display.ToolBodySolid.SkinColor;
    this.label_98.BackColor = this.Tool.Display.ToolCutSolid.SkinColor;
    this.label_86.BackColor = this.Tool.Display.HolderSolid.SkinColor;
    this.label_101.BackColor = this.Tool.Display.ArborSolid.SkinColor;
    this.label_92.BackColor = this.Tool.Display.CamColor;
    this.label_95.BackColor = this.Tool.Display.UpperCamColor;
    this.label_107.BackColor = this.Tool.Display.PlungeColor;
    this.label_104.BackColor = this.Tool.Display.LeaveColor;
    this.numericUpDown_15.Value = (Decimal) this.Tool.Positions.AngularPosition;
    this.numericUpDown_23.Value = (Decimal) this.Tool.Positions.Position.X;
    this.numericUpDown_22.Value = (Decimal) this.Tool.Positions.Position.Y;
    this.numericUpDown_21.Value = (Decimal) this.Tool.Positions.Position.Z;
    this.numericUpDown_24.Value = (Decimal) this.Tool.Positions.Position.A;
    this.numericUpDown_17.Value = (Decimal) this.Tool.Positions.Position.B;
    this.numericUpDown_16.Value = (Decimal) this.Tool.Positions.Position.C;
    this.numericUpDown_20.Value = (Decimal) this.Tool.Positions.Offset.X;
    this.numericUpDown_19.Value = (Decimal) this.Tool.Positions.Offset.Y;
    this.numericUpDown_18.Value = (Decimal) this.Tool.Positions.Offset.Z;
    this.numericUpDown_6.Value = (Decimal) this.Tool.Positions.Offset.A;
    this.numericUpDown_5.Value = (Decimal) this.Tool.Positions.Offset.B;
    this.numericUpDown_4.Value = (Decimal) this.Tool.Positions.Offset.C;
    this.numericUpDown_66.Value = (Decimal) this.Tool.Limits.AxesMinLimits.A;
    this.numericUpDown_64.Value = (Decimal) this.Tool.Limits.AxesMinLimits.B;
    this.numericUpDown_62.Value = (Decimal) this.Tool.Limits.AxesMinLimits.C;
    this.numericUpDown_65.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.A;
    this.numericUpDown_63.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.B;
    this.numericUpDown_61.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.C;
    this.numericUpDown_165.Value = (Decimal) this.Tool.Limits.AxesMinLimits.X;
    this.numericUpDown_167.Value = (Decimal) this.Tool.Limits.AxesMinLimits.Y;
    this.numericUpDown_164.Value = (Decimal) this.Tool.Limits.AxesMinLimits.Z;
    this.numericUpDown_166.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.X;
    this.numericUpDown_168.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.Y;
    this.numericUpDown_163.Value = (Decimal) this.Tool.Limits.AxesMaxLimits.Z;
    this.checkBox_7.Checked = this.Tool.Limits.PlaneTop;
    this.checkBox_6.Checked = this.Tool.Limits.PlaneBottom;
    this.checkBox_3.Checked = this.Tool.Limits.PlaneFront;
    this.checkBox_2.Checked = this.Tool.Limits.PlaneBack;
    this.checkBox_5.Checked = this.Tool.Limits.PlaneLeft;
    this.checkBox_4.Checked = this.Tool.Limits.PlaneRight;
    this.checkBox_1.Checked = this.Tool.Limits.PlaneAll;
    this.checkBox_12.Checked = this.Tool.Limits.PlaneSlope;
    this.checkBox_15.Checked = this.Tool.Limits.RotationA;
    this.checkBox_14.Checked = this.Tool.Limits.RotationB;
    this.checkBox_13.Checked = this.Tool.Limits.RotationC;
    this.textBox_2.Text = buString.ArrayListToString(this.Tool.Aux, true);
    if (this.Tool.Geometry.GeometryType == ToolType.Flat)
      this.tabControl_1.SelectedIndex = 0;
    if (this.Tool.Geometry.GeometryType == ToolType.Sphere)
      this.tabControl_1.SelectedIndex = 1;
    if (this.Tool.Geometry.GeometryType == ToolType.Saw)
      this.tabControl_1.SelectedIndex = 2;
    if (this.Tool.Geometry.GeometryType == ToolType.Bullnose)
      this.tabControl_1.SelectedIndex = 4;
    if (this.Tool.Geometry.GeometryType == ToolType.Taper)
      this.tabControl_1.SelectedIndex = 6;
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
    this.LoadLangueage();
  }

  public void LoadLangueage()
  {
    string callMethod = "ToolDetailed LoadLanguage";
    try
    {
      if (F_ToolAll.Captions.Count < 67)
        return;
      this.Text = F_ToolAll.Captions[0];
      this.tabPage_0.Text = F_ToolAll.Captions[1];
      this.label_24.Text = F_ToolAll.Captions[2];
      this.label_22.Text = F_ToolAll.Captions[3];
      this.label_20.Text = F_ToolAll.Captions[4];
      this.label_18.Text = F_ToolAll.Captions[5];
      this.label_16.Text = F_ToolAll.Captions[6];
      this.label_14.Text = F_ToolAll.Captions[7];
      this.label_12.Text = F_ToolAll.Captions[8];
      this.label_110.Text = F_ToolAll.Captions[9];
      this.label_25.Text = F_ToolAll.Captions[10];
      this.label_23.Text = F_ToolAll.Captions[11];
      this.label_21.Text = F_ToolAll.Captions[12];
      this.label_19.Text = F_ToolAll.Captions[13];
      this.label_17.Text = F_ToolAll.Captions[14];
      this.label_15.Text = F_ToolAll.Captions[15];
      this.label_13.Text = F_ToolAll.Captions[16 /*0x10*/];
      this.tabPage_1.Text = F_ToolAll.Captions[18];
      this.label_28.Text = F_ToolAll.Captions[22];
      this.label_27.Text = F_ToolAll.Captions[23];
      this.label_99.Text = F_ToolAll.Captions[24];
      this.label_93.Text = F_ToolAll.Captions[25];
      this.label_96.Text = F_ToolAll.Captions[26];
      this.label_29.Text = F_ToolAll.Captions[30];
      this.label_26.Text = F_ToolAll.Captions[31 /*0x1F*/];
      this.label_100.Text = F_ToolAll.Captions[32 /*0x20*/];
      this.label_94.Text = F_ToolAll.Captions[33];
      this.label_97.Text = F_ToolAll.Captions[34];
      this.tabPage_2.Text = F_ToolAll.Captions[35];
      this.label_5.Text = F_ToolAll.Captions[36];
      this.label_3.Text = F_ToolAll.Captions[37];
      this.label_0.Text = F_ToolAll.Captions[38];
      this.label_1.Text = F_ToolAll.Captions[39];
      this.label_205.Text = F_ToolAll.Captions[40];
      this.label_207.Text = F_ToolAll.Captions[41];
      this.label_10.Text = F_ToolAll.Captions[42];
      this.label_6.Text = F_ToolAll.Captions[43];
      this.label_4.Text = F_ToolAll.Captions[44];
      this.label_2.Text = F_ToolAll.Captions[45];
      this.label_9.Text = F_ToolAll.Captions[46];
      this.label_206.Text = F_ToolAll.Captions[47];
      this.label_208.Text = F_ToolAll.Captions[48 /*0x30*/];
      this.label_11.Text = F_ToolAll.Captions[49];
      this.tabPage_3.Text = F_ToolAll.Captions[50];
      this.label_31.Text = F_ToolAll.Captions[51];
      this.label_37.Text = F_ToolAll.Captions[52];
      this.label_38.Text = F_ToolAll.Captions[53];
      this.label_35.Text = F_ToolAll.Captions[54];
      this.label_8.Text = F_ToolAll.Captions[55];
      this.label_32.Text = F_ToolAll.Captions[56];
      this.label_36.Text = F_ToolAll.Captions[57];
      this.label_33.Text = F_ToolAll.Captions[58];
      this.label_34.Text = F_ToolAll.Captions[59];
      this.label_7.Text = F_ToolAll.Captions[60];
      this.textBox_2.Text = F_ToolAll.Captions[61];
      this.label_30.Text = F_ToolAll.Captions[62];
      this.btn_ok.Text = F_ToolAll.Captions[63 /*0x3F*/];
      this.btn_cancel.Text = F_ToolAll.Captions[64 /*0x40*/];
      this.btn_pre.Text = F_ToolAll.Captions[65];
      this.btn_next.Text = F_ToolAll.Captions[66];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  internal void method_0(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited)
      return;
    if (control2.Name == this.btn_ok.Name)
    {
      Class39.smethod_161(this);
      this.Properties.Result = DialogResult.OK;
      if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
        this.Dispose();
      if (this.Properties.FormCloseMode == FormCloseModeType.Invisible)
        this.Visible = false;
    }
    if (!(control2.Name == this.btn_cancel.Name))
      return;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_1(object sender, FormClosingEventArgs e)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    e.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void method_2(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (control2.Name == this.label_98.Name)
    {
      Color backColor = this.label_98.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_98.BackColor = backColor;
    }
    if (control2.Name == this.label_89.Name)
    {
      Color backColor = this.label_89.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_89.BackColor = backColor;
    }
    if (control2.Name == this.label_101.Name)
    {
      Color backColor = this.label_101.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_101.BackColor = backColor;
    }
    if (control2.Name == this.label_86.Name)
    {
      Color backColor = this.label_86.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_86.BackColor = backColor;
    }
    if (control2.Name == this.label_92.Name)
    {
      Color backColor = this.label_92.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_92.BackColor = backColor;
    }
    if (control2.Name == this.label_95.Name)
    {
      Color backColor = this.label_95.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_95.BackColor = backColor;
    }
    if (control2.Name == this.label_107.Name)
    {
      Color backColor = this.label_107.BackColor;
      if (ColorDialogBox.ShowDialog(ref backColor) == DialogResult.OK)
        this.label_107.BackColor = backColor;
    }
    if (!(control2.Name == this.label_104.Name))
      return;
    Color backColor1 = this.label_104.BackColor;
    if (ColorDialogBox.ShowDialog(ref backColor1) != DialogResult.OK)
      return;
    this.label_104.BackColor = backColor1;
  }

  internal void method_3(object sender, EventArgs e)
  {
    if (!this.Properties.Inited)
      return;
    this.tabControl_1.SelectedIndex = this.comboBox_1.SelectedIndex;
  }

  internal void method_4(object sender, EventArgs e)
  {
    Control control1 = new Control();
    Control control2 = (Control) sender;
    if (!this.Properties.Inited || !(control2.Name == this.radioButton_1.Name | control2.Name == this.radioButton_0.Name | control2.Name == this.radioButton_2.Name))
      return;
    if (this.radioButton_2.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.None;
    if (this.radioButton_1.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Corner;
    if (this.radioButton_0.Checked)
      this.Tool.Geometry.CornerRadiusType = ToolCornerRadiusType.Full;
    Class39.smethod_217(this);
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
