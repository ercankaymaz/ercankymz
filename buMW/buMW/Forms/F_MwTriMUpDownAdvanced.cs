// Decompiled with JetBrains decompiler
// Type: buMW.Forms.F_MwTriMUpDownAdvanced
// Assembly: buMW, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B2D2CB56-8ED5-49EC-92C7-44A16E3DD18C
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMW.dll

using buClass;
using buMW.CamForms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace buMW.Forms;

public class F_MwTriMUpDownAdvanced : Form
{
  internal NumericUpDown \u0004;
  internal System.Windows.Forms.Label \u0004;
  internal System.Windows.Forms.Label \u0005;
  internal Panel \u0002;
  public static byte f0005F1;
  public FormProperties Properties = new FormProperties();
  public MachiningParams Par = new MachiningParams(Unit.Metric);
  private IContainer \u0001 = (IContainer) null;
  internal ImageList \u0001;
  public Button btn_ok;

  static void \u0001([In] F_TriMeshRough obj0)
  {
    string callMethod = "LoadLanguage";
    try
    {
      if (F_TriMeshRough.Captions.Count < 72)
        return;
      obj0.Text = F_TriMeshRough.Captions[8];
      obj0.\u008E.Text = F_TriMeshRough.Captions[0];
      obj0.\u008D.Text = F_TriMeshRough.Captions[1];
      obj0.\u0001.Text = F_TriMeshRough.Captions[2];
      obj0.\u000F.Text = F_TriMeshRough.Captions[3];
      obj0.\u008F.Text = F_TriMeshRough.Captions[3];
      obj0.\u0001.Text = F_TriMeshRough.Captions[4];
      obj0.\u0010.Text = F_TriMeshRough.Captions[5];
      obj0.\u008B.Text = F_TriMeshRough.Captions[6];
      obj0.\u0086.Text = F_TriMeshRough.Captions[7];
      obj0.\u000E.Text = F_TriMeshRough.Captions[9];
      obj0.\u0002.Text = F_TriMeshRough.Captions[10];
      obj0.\u0001.Text = F_TriMeshRough.Captions[11];
      obj0.\u0002.Text = F_TriMeshRough.Captions[12];
      obj0.\u0005.Text = F_TriMeshRough.Captions[13];
      obj0.\u0008.Text = F_TriMeshRough.Captions[14];
      obj0.\u000E.Text = F_TriMeshRough.Captions[15];
      obj0.\u0006.Text = F_TriMeshRough.Captions[16 /*0x10*/];
      obj0.\u0002.Text = F_TriMeshRough.Captions[17];
      obj0.\u0013.Text = F_TriMeshRough.Captions[18];
      obj0.\u0002.Text = F_TriMeshRough.Captions[19];
      obj0.\u0003.Text = F_TriMeshRough.Captions[20];
      obj0.\u0004.Text = F_TriMeshRough.Captions[21];
      obj0.\u0001.Text = F_TriMeshRough.Captions[22];
      obj0.\u0007.Text = F_TriMeshRough.Captions[23];
      obj0.\u0015.Text = F_TriMeshRough.Captions[24];
      obj0.\u0016.Text = F_TriMeshRough.Captions[25];
      obj0.\u0018.Text = F_TriMeshRough.Captions[26];
      obj0.\u0017.Text = F_TriMeshRough.Captions[27];
      obj0.\u0014.Text = F_TriMeshRough.Captions[29];
      obj0.\u0012.Text = F_TriMeshRough.Captions[30];
      obj0.\u0011.Text = F_TriMeshRough.Captions[31 /*0x1F*/];
      obj0.\u0004.Text = F_TriMeshRough.Captions[32 /*0x20*/];
      obj0.\u0003.Text = F_TriMeshRough.Captions[33];
      obj0.\u001F.Text = F_TriMeshRough.Captions[34];
      obj0.\u007F.Text = F_TriMeshRough.Captions[35];
      obj0.\u0003.Text = F_TriMeshRough.Captions[36];
      obj0.\u0019.Text = F_TriMeshRough.Captions[37];
      obj0.\u0003.Text = F_TriMeshRough.Captions[38];
      obj0.\u0004.Text = F_TriMeshRough.Captions[39];
      obj0.\u001C.Text = F_TriMeshRough.Captions[40];
      obj0.\u001B.Text = F_TriMeshRough.Captions[41];
      obj0.\u000F.Text = F_TriMeshRough.Captions[42];
      obj0.\u000F.Text = F_TriMeshRough.Captions[43];
      obj0.\u001A.Text = F_TriMeshRough.Captions[40];
      obj0.\u0004.Text = F_TriMeshRough.Captions[44];
      obj0.\u0001.Text = F_TriMeshRough.Captions[45];
      obj0.\u0003.Text = F_TriMeshRough.Captions[45];
      obj0.\u0089.Text = F_TriMeshRough.Captions[46];
      obj0.\u008A.Text = F_TriMeshRough.Captions[47];
      obj0.\u008C.Text = F_TriMeshRough.Captions[48 /*0x30*/];
      obj0.\u0090.Text = F_TriMeshRough.Captions[49];
      obj0.\u001D.Text = F_TriMeshRough.Captions[50];
      obj0.\u001E.Text = F_TriMeshRough.Captions[51];
      obj0.\u0080.Text = F_TriMeshRough.Captions[52];
      obj0.\u0005.Text = F_TriMeshRough.Captions[53];
      obj0.\u0010.Text = F_TriMeshRough.Captions[54];
      ((F_RoughLink) obj0).\u0093.Text = F_TriMeshRough.Captions[55];
      obj0.\u0012.Text = F_TriMeshRough.Captions[56];
      obj0.\u0008.Text = F_TriMeshRough.Captions[57];
      obj0.\u0011.Text = F_TriMeshRough.Captions[58];
      obj0.\u0080.Text = F_TriMeshRough.Captions[59];
      obj0.\u0010.Text = F_TriMeshRough.Captions[60];
      ((F_RoughLink) obj0).\u0092.Text = F_TriMeshRough.Captions[61];
      obj0.\u0014.Text = F_TriMeshRough.Captions[62];
      ((F_RoughLink) obj0).\u0015.Text = F_TriMeshRough.Captions[63 /*0x3F*/];
      obj0.\u0091.Text = F_TriMeshRough.Captions[64 /*0x40*/];
      obj0.\u0013.Text = F_TriMeshRough.Captions[65];
      obj0.\u0087.Text = F_TriMeshRough.Captions[66];
      obj0.\u0084.Text = F_TriMeshRough.Captions[67];
      obj0.\u0007.Text = F_TriMeshRough.Captions[68];
      obj0.btn_ok.Text = F_TriMeshRough.Captions[69];
      obj0.btn_cancel.Text = F_TriMeshRough.Captions[70];
      obj0.\u0002.Text = F_TriMeshRough.Captions[71];
    }
    catch (Exception ex)
    {
      string str = "";
      buLog.addLog(str, "Not Ok", callMethod);
      buException.throwException(ex, callMethod, true, str);
    }
  }

  static void \u0001([In] F_MwGaugeCheck obj0)
  {
    obj0.\u0001 = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_MwGaugeCheck));
    obj0.\u0001 = new PictureBox();
    obj0.\u0002 = new PictureBox();
    obj0.\u0003 = new PictureBox();
    obj0.\u0004 = new PictureBox();
    obj0.\u0005 = new PictureBox();
    obj0.\u0006 = new PictureBox();
    obj0.\u0007 = new PictureBox();
    obj0.\u0008 = new PictureBox();
    obj0.\u000E = new PictureBox();
    obj0.\u000F = new PictureBox();
    obj0.\u0010 = new PictureBox();
    obj0.\u0011 = new PictureBox();
    obj0.\u0012 = new PictureBox();
    obj0.\u0013 = new PictureBox();
    obj0.\u0014 = new PictureBox();
    obj0.\u0015 = new PictureBox();
    obj0.\u0001 = new Panel();
    obj0.\u0002 = new Panel();
    obj0.\u0008 = new System.Windows.Forms.Label();
    obj0.\u0001 = new NumericUpDown();
    obj0.\u000E = new System.Windows.Forms.Label();
    obj0.\u0006 = new CheckBox();
    obj0.\u0002 = new NumericUpDown();
    obj0.\u0007 = new CheckBox();
    obj0.\u0018 = new PictureBox();
    obj0.\u0003 = new Panel();
    obj0.\u0005 = new CheckBox();
    obj0.\u0003 = new System.Windows.Forms.Label();
    obj0.\u0004 = new CheckBox();
    obj0.\u0004 = new System.Windows.Forms.Label();
    obj0.\u0003 = new CheckBox();
    obj0.\u0005 = new System.Windows.Forms.Label();
    obj0.\u0002 = new CheckBox();
    obj0.\u0006 = new System.Windows.Forms.Label();
    obj0.\u0004 = new Panel();
    obj0.\u0019 = new PictureBox();
    obj0.\u0001 = new Button();
    obj0.combo_action1 = new ComboBox();
    obj0.combo_move1 = new ComboBox();
    obj0.\u0016 = new PictureBox();
    obj0.\u0017 = new PictureBox();
    obj0.\u0001 = new System.Windows.Forms.Label();
    obj0.\u0001 = new CheckBox();
    obj0.\u0002 = new System.Windows.Forms.Label();
    obj0.\u0007 = new System.Windows.Forms.Label();
    obj0.\u000F = new System.Windows.Forms.Label();
    obj0.\u0010 = new System.Windows.Forms.Label();
    obj0.\u0011 = new System.Windows.Forms.Label();
    obj0.\u0005 = new Panel();
    obj0.\u0006 = new Panel();
    obj0.\u0012 = new System.Windows.Forms.Label();
    obj0.\u0003 = new NumericUpDown();
    obj0.\u0013 = new System.Windows.Forms.Label();
    obj0.\u0008 = new CheckBox();
    obj0.\u0004 = new NumericUpDown();
    obj0.\u000E = new CheckBox();
    obj0.\u001A = new PictureBox();
    obj0.\u0007 = new Panel();
    obj0.\u000F = new CheckBox();
    obj0.\u0014 = new System.Windows.Forms.Label();
    obj0.\u0010 = new CheckBox();
    obj0.\u0015 = new System.Windows.Forms.Label();
    obj0.\u0011 = new CheckBox();
    obj0.\u0016 = new System.Windows.Forms.Label();
    obj0.\u0012 = new CheckBox();
    obj0.\u0017 = new System.Windows.Forms.Label();
    obj0.\u0008 = new Panel();
    obj0.\u001B = new PictureBox();
    obj0.\u0002 = new Button();
    obj0.combo_action2 = new ComboBox();
    obj0.combo_move2 = new ComboBox();
    obj0.\u001C = new PictureBox();
    obj0.\u001D = new PictureBox();
    obj0.\u0018 = new System.Windows.Forms.Label();
    obj0.\u0013 = new CheckBox();
    obj0.\u0019 = new System.Windows.Forms.Label();
    obj0.\u000E = new Panel();
    obj0.\u000F = new Panel();
    obj0.\u001A = new System.Windows.Forms.Label();
    obj0.\u0005 = new NumericUpDown();
    obj0.\u001B = new System.Windows.Forms.Label();
    obj0.\u0014 = new CheckBox();
    obj0.\u0006 = new NumericUpDown();
    obj0.\u0015 = new CheckBox();
    obj0.\u001E = new PictureBox();
    obj0.\u0010 = new Panel();
    obj0.\u001F = new PictureBox();
    obj0.\u0016 = new CheckBox();
    obj0.\u007F = new PictureBox();
    obj0.\u001C = new System.Windows.Forms.Label();
    obj0.\u0080 = new PictureBox();
    obj0.\u0017 = new CheckBox();
    obj0.\u0081 = new PictureBox();
    obj0.\u0082 = new PictureBox();
    obj0.\u001D = new System.Windows.Forms.Label();
    obj0.\u0083 = new PictureBox();
    obj0.\u0018 = new CheckBox();
    obj0.\u0084 = new PictureBox();
    obj0.\u001E = new System.Windows.Forms.Label();
    obj0.\u0019 = new CheckBox();
    obj0.\u0086 = new PictureBox();
    obj0.\u001F = new System.Windows.Forms.Label();
    obj0.\u0011 = new Panel();
    obj0.\u0087 = new PictureBox();
    obj0.\u0003 = new Button();
    obj0.combo_action4 = new ComboBox();
    obj0.combo_move4 = new ComboBox();
    obj0.\u0088 = new PictureBox();
    obj0.\u0089 = new PictureBox();
    obj0.\u007F = new System.Windows.Forms.Label();
    obj0.\u001A = new CheckBox();
    obj0.\u0080 = new System.Windows.Forms.Label();
    obj0.\u0012 = new Panel();
    obj0.\u0013 = new Panel();
    obj0.\u0081 = new System.Windows.Forms.Label();
    obj0.\u0007 = new NumericUpDown();
    obj0.\u0082 = new System.Windows.Forms.Label();
    obj0.\u001B = new CheckBox();
    obj0.\u0008 = new NumericUpDown();
    obj0.\u001C = new CheckBox();
    obj0.\u008A = new PictureBox();
    obj0.\u0014 = new Panel();
    obj0.\u001D = new CheckBox();
    obj0.\u0083 = new System.Windows.Forms.Label();
    obj0.\u001E = new CheckBox();
    obj0.\u0084 = new System.Windows.Forms.Label();
    obj0.\u001F = new CheckBox();
    obj0.\u0086 = new System.Windows.Forms.Label();
    obj0.\u007F = new CheckBox();
    obj0.\u0087 = new System.Windows.Forms.Label();
    obj0.\u008B = new PictureBox();
    obj0.\u008C = new PictureBox();
    obj0.\u008D = new PictureBox();
    obj0.\u008E = new PictureBox();
    obj0.\u008F = new PictureBox();
    obj0.\u0090 = new PictureBox();
    obj0.\u0091 = new PictureBox();
    obj0.\u0092 = new PictureBox();
    obj0.\u0015 = new Panel();
    obj0.\u0093 = new PictureBox();
    obj0.\u0004 = new Button();
    obj0.combo_action3 = new ComboBox();
    obj0.combo_move3 = new ComboBox();
    obj0.\u0094 = new PictureBox();
    obj0.\u0095 = new PictureBox();
    obj0.\u0088 = new System.Windows.Forms.Label();
    obj0.\u0080 = new CheckBox();
    obj0.\u0089 = new System.Windows.Forms.Label();
    obj0.\u0005 = new Button();
    obj0.\u0006 = new Button();
    obj0.\u0007 = new Button();
    obj0.\u0001 = new ImageList(obj0.\u0001);
    obj0.btn_cancel = new Button();
    obj0.btn_ok = new Button();
    obj0.combo_relink1 = new ComboBox();
    obj0.combo_relink2 = new ComboBox();
    obj0.combo_relink3 = new ComboBox();
    obj0.combo_relink4 = new ComboBox();
    obj0.\u0008 = new Button();
    ((F_MwGaugeRemainCollsion) obj0).\u000E = new Button();
    ((F_MwGaugeRemainCollsion) obj0).\u0010 = new Button();
    ((F_MwGaugeRemainCollsion) obj0).\u000F = new Button();
    ((ISupportInitialize) obj0.\u0001).BeginInit();
    ((ISupportInitialize) obj0.\u0002).BeginInit();
    ((ISupportInitialize) obj0.\u0003).BeginInit();
    ((ISupportInitialize) obj0.\u0004).BeginInit();
    ((ISupportInitialize) obj0.\u0005).BeginInit();
    ((ISupportInitialize) obj0.\u0006).BeginInit();
    ((ISupportInitialize) obj0.\u0007).BeginInit();
    ((ISupportInitialize) obj0.\u0008).BeginInit();
    ((ISupportInitialize) obj0.\u000E).BeginInit();
    ((ISupportInitialize) obj0.\u000F).BeginInit();
    ((ISupportInitialize) obj0.\u0010).BeginInit();
    ((ISupportInitialize) obj0.\u0011).BeginInit();
    ((ISupportInitialize) obj0.\u0012).BeginInit();
    ((ISupportInitialize) obj0.\u0013).BeginInit();
    ((ISupportInitialize) obj0.\u0014).BeginInit();
    ((ISupportInitialize) obj0.\u0015).BeginInit();
    obj0.\u0001.SuspendLayout();
    obj0.\u0002.SuspendLayout();
    obj0.\u0001.BeginInit();
    obj0.\u0002.BeginInit();
    ((ISupportInitialize) obj0.\u0018).BeginInit();
    obj0.\u0003.SuspendLayout();
    obj0.\u0004.SuspendLayout();
    ((ISupportInitialize) obj0.\u0019).BeginInit();
    ((ISupportInitialize) obj0.\u0016).BeginInit();
    ((ISupportInitialize) obj0.\u0017).BeginInit();
    obj0.\u0005.SuspendLayout();
    obj0.\u0006.SuspendLayout();
    obj0.\u0003.BeginInit();
    obj0.\u0004.BeginInit();
    ((ISupportInitialize) obj0.\u001A).BeginInit();
    obj0.\u0007.SuspendLayout();
    obj0.\u0008.SuspendLayout();
    ((ISupportInitialize) obj0.\u001B).BeginInit();
    ((ISupportInitialize) obj0.\u001C).BeginInit();
    ((ISupportInitialize) obj0.\u001D).BeginInit();
    obj0.\u000E.SuspendLayout();
    obj0.\u000F.SuspendLayout();
    obj0.\u0005.BeginInit();
    obj0.\u0006.BeginInit();
    ((ISupportInitialize) obj0.\u001E).BeginInit();
    obj0.\u0010.SuspendLayout();
    ((ISupportInitialize) obj0.\u001F).BeginInit();
    ((ISupportInitialize) obj0.\u007F).BeginInit();
    ((ISupportInitialize) obj0.\u0080).BeginInit();
    ((ISupportInitialize) obj0.\u0081).BeginInit();
    ((ISupportInitialize) obj0.\u0082).BeginInit();
    ((ISupportInitialize) obj0.\u0083).BeginInit();
    ((ISupportInitialize) obj0.\u0084).BeginInit();
    ((ISupportInitialize) obj0.\u0086).BeginInit();
    obj0.\u0011.SuspendLayout();
    ((ISupportInitialize) obj0.\u0087).BeginInit();
    ((ISupportInitialize) obj0.\u0088).BeginInit();
    ((ISupportInitialize) obj0.\u0089).BeginInit();
    obj0.\u0012.SuspendLayout();
    obj0.\u0013.SuspendLayout();
    obj0.\u0007.BeginInit();
    obj0.\u0008.BeginInit();
    ((ISupportInitialize) obj0.\u008A).BeginInit();
    obj0.\u0014.SuspendLayout();
    ((ISupportInitialize) obj0.\u008B).BeginInit();
    ((ISupportInitialize) obj0.\u008C).BeginInit();
    ((ISupportInitialize) obj0.\u008D).BeginInit();
    ((ISupportInitialize) obj0.\u008E).BeginInit();
    ((ISupportInitialize) obj0.\u008F).BeginInit();
    ((ISupportInitialize) obj0.\u0090).BeginInit();
    ((ISupportInitialize) obj0.\u0091).BeginInit();
    ((ISupportInitialize) obj0.\u0092).BeginInit();
    obj0.\u0015.SuspendLayout();
    ((ISupportInitialize) obj0.\u0093).BeginInit();
    ((ISupportInitialize) obj0.\u0094).BeginInit();
    ((ISupportInitialize) obj0.\u0095).BeginInit();
    obj0.SuspendLayout();
    obj0.\u0001.Image = (Image) componentResourceManager.GetObject("pic_toolfluteOFF_1.Image");
    obj0.\u0001.Location = new Point(17, 51);
    obj0.\u0001.Name = "pic_toolfluteOFF_1";
    obj0.\u0001.Size = new Size(34, 68);
    obj0.\u0001.TabIndex = 0;
    obj0.\u0001.TabStop = false;
    obj0.\u0002.Image = (Image) componentResourceManager.GetObject("pic_toolfluteON_1.Image");
    obj0.\u0002.Location = new Point(18, 51);
    obj0.\u0002.Name = "pic_toolfluteON_1";
    obj0.\u0002.Size = new Size(34, 68);
    obj0.\u0002.TabIndex = 1;
    obj0.\u0002.TabStop = false;
    obj0.\u0003.Image = (Image) componentResourceManager.GetObject("pic_toolshoftOFF_1.Image");
    obj0.\u0003.Location = new Point(49, 51);
    obj0.\u0003.Name = "pic_toolshoftOFF_1";
    obj0.\u0003.Size = new Size(29, 68);
    obj0.\u0003.TabIndex = 2;
    obj0.\u0003.TabStop = false;
    obj0.\u0004.Image = (Image) componentResourceManager.GetObject("pic_toolholderOFF_1.Image");
    obj0.\u0004.Location = new Point(104, 51);
    obj0.\u0004.Name = "pic_toolholderOFF_1";
    obj0.\u0004.Size = new Size(82, 68);
    obj0.\u0004.TabIndex = 4;
    obj0.\u0004.TabStop = false;
    obj0.\u0005.Image = (Image) componentResourceManager.GetObject("pic_toolarborOFF_1.Image");
    obj0.\u0005.Location = new Point(77, 51);
    obj0.\u0005.Name = "pic_toolarborOFF_1";
    obj0.\u0005.Size = new Size(28, 68);
    obj0.\u0005.TabIndex = 3;
    obj0.\u0005.TabStop = false;
    obj0.\u0006.Image = (Image) componentResourceManager.GetObject("pic_toolholderON_1.Image");
    obj0.\u0006.Location = new Point(105, 51);
    obj0.\u0006.Name = "pic_toolholderON_1";
    obj0.\u0006.Size = new Size(82, 68);
    obj0.\u0006.TabIndex = 7;
    obj0.\u0006.TabStop = false;
    obj0.\u0007.Image = (Image) componentResourceManager.GetObject("pic_toolarborON_1.Image");
    obj0.\u0007.Location = new Point(78, 51);
    obj0.\u0007.Name = "pic_toolarborON_1";
    obj0.\u0007.Size = new Size(28, 68);
    obj0.\u0007.TabIndex = 6;
    obj0.\u0007.TabStop = false;
    obj0.\u0008.Image = (Image) componentResourceManager.GetObject("pic_toolshoftON_1.Image");
    obj0.\u0008.Location = new Point(50, 51);
    obj0.\u0008.Name = "pic_toolshoftON_1";
    obj0.\u0008.Size = new Size(29, 68);
    obj0.\u0008.TabIndex = 5;
    obj0.\u0008.TabStop = false;
    obj0.\u000E.Image = (Image) componentResourceManager.GetObject("pic_toolholderON_2.Image");
    obj0.\u000E.Location = new Point(105, 52);
    obj0.\u000E.Name = "pic_toolholderON_2";
    obj0.\u000E.Size = new Size(82, 68);
    obj0.\u000E.TabIndex = 144 /*0x90*/;
    obj0.\u000E.TabStop = false;
    obj0.\u000F.Image = (Image) componentResourceManager.GetObject("pic_toolarborON_2.Image");
    obj0.\u000F.Location = new Point(78, 52);
    obj0.\u000F.Name = "pic_toolarborON_2";
    obj0.\u000F.Size = new Size(28, 68);
    obj0.\u000F.TabIndex = 143;
    obj0.\u000F.TabStop = false;
    obj0.\u0010.Image = (Image) componentResourceManager.GetObject("pic_toolshoftON_2.Image");
    obj0.\u0010.Location = new Point(50, 52);
    obj0.\u0010.Name = "pic_toolshoftON_2";
    obj0.\u0010.Size = new Size(29, 68);
    obj0.\u0010.TabIndex = 142;
    obj0.\u0010.TabStop = false;
    obj0.\u0011.Image = (Image) componentResourceManager.GetObject("pic_toolholderOFF_2.Image");
    obj0.\u0011.Location = new Point(104, 51);
    obj0.\u0011.Name = "pic_toolholderOFF_2";
    obj0.\u0011.Size = new Size(82, 68);
    obj0.\u0011.TabIndex = 141;
    obj0.\u0011.TabStop = false;
    obj0.\u0012.Image = (Image) componentResourceManager.GetObject("pic_toolarborOFF_2.Image");
    obj0.\u0012.Location = new Point(77, 51);
    obj0.\u0012.Name = "pic_toolarborOFF_2";
    obj0.\u0012.Size = new Size(28, 68);
    obj0.\u0012.TabIndex = 140;
    obj0.\u0012.TabStop = false;
    obj0.\u0013.Image = (Image) componentResourceManager.GetObject("pic_toolshoftOFF_2.Image");
    obj0.\u0013.Location = new Point(49, 51);
    obj0.\u0013.Name = "pic_toolshoftOFF_2";
    obj0.\u0013.Size = new Size(29, 68);
    obj0.\u0013.TabIndex = 139;
    obj0.\u0013.TabStop = false;
    obj0.\u0014.Image = (Image) componentResourceManager.GetObject("pic_toolfluteON_2.Image");
    obj0.\u0014.Location = new Point(18, 52);
    obj0.\u0014.Name = "pic_toolfluteON_2";
    obj0.\u0014.Size = new Size(34, 68);
    obj0.\u0014.TabIndex = 138;
    obj0.\u0014.TabStop = false;
    obj0.\u0015.Image = (Image) componentResourceManager.GetObject("pic_toolfluteOFF_2.Image");
    obj0.\u0015.Location = new Point(17, 51);
    obj0.\u0015.Name = "pic_toolfluteOFF_2";
    obj0.\u0015.Size = new Size(34, 68);
    obj0.\u0015.TabIndex = 137;
    obj0.\u0015.TabStop = false;
    obj0.\u0001.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0001.Controls.Add((Control) obj0.\u0002);
    obj0.\u0001.Controls.Add((Control) obj0.\u0018);
    obj0.\u0001.Controls.Add((Control) obj0.\u0003);
    obj0.\u0001.Controls.Add((Control) obj0.\u0004);
    obj0.\u0001.Controls.Add((Control) obj0.\u0016);
    obj0.\u0001.Controls.Add((Control) obj0.\u0017);
    obj0.\u0001.Controls.Add((Control) obj0.\u0001);
    obj0.\u0001.Controls.Add((Control) obj0.\u0001);
    obj0.\u0001.Controls.Add((Control) obj0.\u0002);
    obj0.\u0001.Location = new Point(9, 35);
    obj0.\u0001.Name = "panel1";
    obj0.\u0001.Size = new Size(945, 130);
    obj0.\u0001.TabIndex = 161;
    obj0.\u0002.Controls.Add((Control) obj0.\u0008);
    obj0.\u0002.Controls.Add((Control) obj0.\u0008);
    obj0.\u0002.Controls.Add((Control) obj0.\u0001);
    obj0.\u0002.Controls.Add((Control) obj0.\u000E);
    obj0.\u0002.Controls.Add((Control) obj0.\u0006);
    obj0.\u0002.Controls.Add((Control) obj0.\u0002);
    obj0.\u0002.Controls.Add((Control) obj0.\u0007);
    obj0.\u0002.Location = new Point(740, 2);
    obj0.\u0002.Name = "pnl_geometry1";
    obj0.\u0002.Size = new Size(198, 124);
    obj0.\u0002.TabIndex = 162;
    obj0.\u0008.AutoSize = true;
    obj0.\u0008.Location = new Point(3, 88);
    obj0.\u0008.Name = "lbl_tolerance1";
    obj0.\u0008.Size = new Size(72, 17);
    obj0.\u0008.TabIndex = 166;
    obj0.\u0008.Text = "Tolerance";
    obj0.\u0001.DecimalPlaces = 2;
    obj0.\u0001.Location = new Point(111, 85);
    obj0.\u0001.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0001.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0001.Name = "spn_tolerance1";
    obj0.\u0001.Size = new Size(78, 22);
    obj0.\u0001.TabIndex = 165;
    obj0.\u000E.AutoSize = true;
    obj0.\u000E.Location = new Point(3, 60);
    obj0.\u000E.Name = "lbl_leavetostock1";
    obj0.\u000E.Size = new Size(102, 17);
    obj0.\u000E.TabIndex = 163;
    obj0.\u000E.Text = "Stock to Leave";
    obj0.\u0006.AutoSize = true;
    obj0.\u0006.Location = new Point(3, 33);
    obj0.\u0006.Name = "chk_checksurface1";
    obj0.\u0006.Size = new Size(122, 21);
    obj0.\u0006.TabIndex = 164;
    obj0.\u0006.Text = "Check Surface";
    obj0.\u0006.UseVisualStyleBackColor = true;
    obj0.\u0006.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0002.DecimalPlaces = 1;
    obj0.\u0002.Location = new Point(111, 57);
    obj0.\u0002.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0002.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0002.Name = "spn_leavetostock1";
    obj0.\u0002.Size = new Size(78, 22);
    obj0.\u0002.TabIndex = 162;
    obj0.\u0007.AutoSize = true;
    obj0.\u0007.Location = new Point(3, 6);
    obj0.\u0007.Name = "chk_machinesurface1";
    obj0.\u0007.Size = new Size(147, 21);
    obj0.\u0007.TabIndex = 163;
    obj0.\u0007.Text = "Machining Surface";
    obj0.\u0007.UseVisualStyleBackColor = true;
    obj0.\u0007.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0018.BackColor = Color.Black;
    obj0.\u0018.Location = new Point(731, -4);
    obj0.\u0018.Name = "pictureBox3";
    obj0.\u0018.Size = new Size(3, 136);
    obj0.\u0018.TabIndex = 175;
    obj0.\u0018.TabStop = false;
    obj0.\u0003.Controls.Add((Control) obj0.\u0001);
    obj0.\u0003.Controls.Add((Control) obj0.\u0006);
    obj0.\u0003.Controls.Add((Control) obj0.\u0007);
    obj0.\u0003.Controls.Add((Control) obj0.\u0008);
    obj0.\u0003.Controls.Add((Control) obj0.\u0005);
    obj0.\u0003.Controls.Add((Control) obj0.\u0003);
    obj0.\u0003.Controls.Add((Control) obj0.\u0002);
    obj0.\u0003.Controls.Add((Control) obj0.\u0004);
    obj0.\u0003.Controls.Add((Control) obj0.\u0005);
    obj0.\u0003.Controls.Add((Control) obj0.\u0003);
    obj0.\u0003.Controls.Add((Control) obj0.\u0004);
    obj0.\u0003.Controls.Add((Control) obj0.\u0004);
    obj0.\u0003.Controls.Add((Control) obj0.\u0003);
    obj0.\u0003.Controls.Add((Control) obj0.\u0005);
    obj0.\u0003.Controls.Add((Control) obj0.\u0002);
    obj0.\u0003.Controls.Add((Control) obj0.\u0006);
    obj0.\u0003.Location = new Point(63 /*0x3F*/, 2);
    obj0.\u0003.Name = "pnl_check1";
    obj0.\u0003.Size = new Size(192 /*0xC0*/, 124);
    obj0.\u0003.TabIndex = 162;
    obj0.\u0005.AutoSize = true;
    obj0.\u0005.Location = new Point(18, 27);
    obj0.\u0005.Name = "chk_flute1";
    obj0.\u0005.Size = new Size(18, 17);
    obj0.\u0005.TabIndex = 162;
    obj0.\u0005.UseVisualStyleBackColor = true;
    obj0.\u0005.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0003.AutoSize = true;
    obj0.\u0003.Location = new Point(123, 3);
    obj0.\u0003.Name = "lbl_holder1";
    obj0.\u0003.Size = new Size(50, 17);
    obj0.\u0003.TabIndex = 169;
    obj0.\u0003.Text = "Holder";
    obj0.\u0004.AutoSize = true;
    obj0.\u0004.Location = new Point(54, 27);
    obj0.\u0004.Name = "chk_shaft1";
    obj0.\u0004.Size = new Size(18, 17);
    obj0.\u0004.TabIndex = 163;
    obj0.\u0004.UseVisualStyleBackColor = true;
    obj0.\u0004.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0004.AutoSize = true;
    obj0.\u0004.Location = new Point(77, 3);
    obj0.\u0004.Name = "lbl_Arbor1";
    obj0.\u0004.Size = new Size(43, 17);
    obj0.\u0004.TabIndex = 168;
    obj0.\u0004.Text = "Arbor";
    obj0.\u0003.AutoSize = true;
    obj0.\u0003.Location = new Point(86, 27);
    obj0.\u0003.Name = "chk_arbor1";
    obj0.\u0003.Size = new Size(18, 17);
    obj0.\u0003.TabIndex = 164;
    obj0.\u0003.UseVisualStyleBackColor = true;
    obj0.\u0003.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0005.AutoSize = true;
    obj0.\u0005.Location = new Point(40, 3);
    obj0.\u0005.Name = "lbl_shaft1";
    obj0.\u0005.Size = new Size(41, 17);
    obj0.\u0005.TabIndex = 167;
    obj0.\u0005.Text = "Shaft";
    obj0.\u0002.AutoSize = true;
    obj0.\u0002.Location = new Point(136, 27);
    obj0.\u0002.Name = "chk_holder1";
    obj0.\u0002.Size = new Size(18, 17);
    obj0.\u0002.TabIndex = 165;
    obj0.\u0002.UseVisualStyleBackColor = true;
    obj0.\u0002.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0006.AutoSize = true;
    obj0.\u0006.Location = new Point(1, 3);
    obj0.\u0006.Name = "lbl_flute1";
    obj0.\u0006.Size = new Size(39, 17);
    obj0.\u0006.TabIndex = 166;
    obj0.\u0006.Text = "Flute";
    obj0.\u0004.Controls.Add((Control) obj0.combo_relink1);
    obj0.\u0004.Controls.Add((Control) obj0.\u0019);
    obj0.\u0004.Controls.Add((Control) obj0.\u0001);
    obj0.\u0004.Controls.Add((Control) obj0.combo_action1);
    obj0.\u0004.Controls.Add((Control) obj0.combo_move1);
    obj0.\u0004.Location = new Point(268, 2);
    obj0.\u0004.Name = "pnl_strategy1";
    obj0.\u0004.Size = new Size(457, 124);
    obj0.\u0004.TabIndex = 163;
    obj0.\u0019.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0019.Location = new Point(297, 6);
    obj0.\u0019.Name = "pic_preview1";
    obj0.\u0019.Size = new Size(159, 114);
    obj0.\u0019.TabIndex = 176 /*0xB0*/;
    obj0.\u0019.TabStop = false;
    obj0.\u0001.Location = new Point(8, 93);
    obj0.\u0001.Name = "btn_advanced1";
    obj0.\u0001.Size = new Size(204, 28);
    obj0.\u0001.TabIndex = 162;
    obj0.\u0001.Text = "Advanced";
    obj0.\u0001.UseVisualStyleBackColor = true;
    obj0.\u0001.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.combo_action1.FormattingEnabled = true;
    obj0.combo_action1.Items.AddRange(new object[4]
    {
      (object) "Retract Tool",
      (object) "Trim and Relink Toolpath",
      (object) "Stop Toolpath Calculation",
      (object) "Report Collision"
    });
    obj0.combo_action1.Location = new Point(8, 6);
    obj0.combo_action1.Name = "combo_action1";
    obj0.combo_action1.Size = new Size(280, 24);
    obj0.combo_action1.TabIndex = 162;
    obj0.combo_action1.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.combo_move1.FormattingEnabled = true;
    obj0.combo_move1.Items.AddRange(new object[19]
    {
      (object) "Along Toll Axis",
      (object) "Along +Z",
      (object) "Along XY Plane",
      (object) "Along XZ Plane",
      (object) "Along YZ Plane",
      (object) "Along -Z",
      (object) "Along +X",
      (object) "Along -X",
      (object) "Along +Y",
      (object) "Along -Y",
      (object) "Along Surface Normal",
      (object) "Away From Origine",
      (object) "Along to Cutter Center",
      (object) "Along Opt. in XY Plane",
      (object) "Along Opt. in XZ Plane",
      (object) "Along Opt. in YZ Plane",
      (object) "Along User Defined Direction",
      (object) "Along Tool Contact Line",
      (object) "Along Tool Plane"
    });
    obj0.combo_move1.Location = new Point(8, 34);
    obj0.combo_move1.Name = "combo_move1";
    obj0.combo_move1.Size = new Size(280, 24);
    obj0.combo_move1.TabIndex = 163;
    obj0.combo_move1.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.\u0016.BackColor = Color.Black;
    obj0.\u0016.Location = new Point(259, -1);
    obj0.\u0016.Name = "pictureBox2";
    obj0.\u0016.Size = new Size(3, 136);
    obj0.\u0016.TabIndex = 174;
    obj0.\u0016.TabStop = false;
    obj0.\u0017.BackColor = Color.Black;
    obj0.\u0017.Location = new Point(57, -1);
    obj0.\u0017.Name = "pictureBox1";
    obj0.\u0017.Size = new Size(3, 136);
    obj0.\u0017.TabIndex = 173;
    obj0.\u0017.TabStop = false;
    obj0.\u0001.AutoSize = true;
    obj0.\u0001.Location = new Point(5, 3);
    obj0.\u0001.Name = "lbl_enable1";
    obj0.\u0001.Size = new Size(52, 17);
    obj0.\u0001.TabIndex = 172;
    obj0.\u0001.Text = "Enable";
    obj0.\u0001.AutoSize = true;
    obj0.\u0001.Location = new Point(20, 28);
    obj0.\u0001.Name = "chk_enable1";
    obj0.\u0001.Size = new Size(18, 17);
    obj0.\u0001.TabIndex = 171;
    obj0.\u0001.UseVisualStyleBackColor = true;
    obj0.\u0001.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0002.AutoSize = true;
    obj0.\u0002.Font = new Font("Microsoft Sans Serif", 19.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0002.Location = new Point(13, 67);
    obj0.\u0002.Name = "lbl_number1";
    obj0.\u0002.Size = new Size(36, 38);
    obj0.\u0002.TabIndex = 170;
    obj0.\u0002.Text = "1";
    obj0.\u0007.AutoSize = true;
    obj0.\u0007.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0007.Location = new Point(364, 9);
    obj0.\u0007.Name = "label7";
    obj0.\u0007.Size = new Size(218, 20);
    obj0.\u0007.TabIndex = 175;
    obj0.\u0007.Text = "Strategy and Parameters";
    obj0.\u000F.AutoSize = true;
    obj0.\u000F.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u000F.Location = new Point(10, 9);
    obj0.\u000F.Name = "label9";
    obj0.\u000F.Size = new Size(63 /*0x3F*/, 20);
    obj0.\u000F.TabIndex = 177;
    obj0.\u000F.Text = "Status";
    obj0.\u0010.AutoSize = true;
    obj0.\u0010.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0010.Location = new Point(137, 9);
    obj0.\u0010.Name = "label10";
    obj0.\u0010.Size = new Size(61, 20);
    obj0.\u0010.TabIndex = 179;
    obj0.\u0010.Text = "Check";
    obj0.\u0011.AutoSize = true;
    obj0.\u0011.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0011.Location = new Point(796, 9);
    obj0.\u0011.Name = "label11";
    obj0.\u0011.Size = new Size(90, 20);
    obj0.\u0011.TabIndex = 180;
    obj0.\u0011.Text = "Geometry";
    obj0.\u0005.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0005.Controls.Add((Control) obj0.\u0006);
    obj0.\u0005.Controls.Add((Control) obj0.\u001A);
    obj0.\u0005.Controls.Add((Control) obj0.\u0007);
    obj0.\u0005.Controls.Add((Control) obj0.\u0008);
    obj0.\u0005.Controls.Add((Control) obj0.\u001C);
    obj0.\u0005.Controls.Add((Control) obj0.\u001D);
    obj0.\u0005.Controls.Add((Control) obj0.\u0018);
    obj0.\u0005.Controls.Add((Control) obj0.\u0013);
    obj0.\u0005.Controls.Add((Control) obj0.\u0019);
    obj0.\u0005.Location = new Point(9, 177);
    obj0.\u0005.Name = "panel5";
    obj0.\u0005.Size = new Size(945, 130);
    obj0.\u0005.TabIndex = 182;
    obj0.\u0006.Controls.Add((Control) ((F_MwGaugeRemainCollsion) obj0).\u000E);
    obj0.\u0006.Controls.Add((Control) obj0.\u0012);
    obj0.\u0006.Controls.Add((Control) obj0.\u0003);
    obj0.\u0006.Controls.Add((Control) obj0.\u0013);
    obj0.\u0006.Controls.Add((Control) obj0.\u0008);
    obj0.\u0006.Controls.Add((Control) obj0.\u0004);
    obj0.\u0006.Controls.Add((Control) obj0.\u000E);
    obj0.\u0006.Location = new Point(740, 2);
    obj0.\u0006.Name = "pnl_geometry2";
    obj0.\u0006.Size = new Size(198, 124);
    obj0.\u0006.TabIndex = 162;
    obj0.\u0012.AutoSize = true;
    obj0.\u0012.Location = new Point(3, 88);
    obj0.\u0012.Name = "lbl_tolerance2";
    obj0.\u0012.Size = new Size(72, 17);
    obj0.\u0012.TabIndex = 166;
    obj0.\u0012.Text = "Tolerance";
    obj0.\u0003.DecimalPlaces = 2;
    obj0.\u0003.Location = new Point(111, 85);
    obj0.\u0003.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0003.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0003.Name = "spn_tolerance2";
    obj0.\u0003.Size = new Size(78, 22);
    obj0.\u0003.TabIndex = 165;
    obj0.\u0013.AutoSize = true;
    obj0.\u0013.Location = new Point(3, 60);
    obj0.\u0013.Name = "lbl_leavetostock2";
    obj0.\u0013.Size = new Size(102, 17);
    obj0.\u0013.TabIndex = 163;
    obj0.\u0013.Text = "Stock to Leave";
    obj0.\u0008.AutoSize = true;
    obj0.\u0008.Location = new Point(3, 33);
    obj0.\u0008.Name = "chk_checksurface2";
    obj0.\u0008.Size = new Size(122, 21);
    obj0.\u0008.TabIndex = 164;
    obj0.\u0008.Text = "Check Surface";
    obj0.\u0008.UseVisualStyleBackColor = true;
    obj0.\u0008.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0004.DecimalPlaces = 1;
    obj0.\u0004.Location = new Point(111, 57);
    obj0.\u0004.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0004.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0004.Name = "spn_leavetostock2";
    obj0.\u0004.Size = new Size(78, 22);
    obj0.\u0004.TabIndex = 162;
    obj0.\u000E.AutoSize = true;
    obj0.\u000E.Location = new Point(3, 6);
    obj0.\u000E.Name = "chk_machinesurface2";
    obj0.\u000E.Size = new Size(147, 21);
    obj0.\u000E.TabIndex = 163;
    obj0.\u000E.Text = "Machining Surface";
    obj0.\u000E.UseVisualStyleBackColor = true;
    obj0.\u000E.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u001A.BackColor = Color.Black;
    obj0.\u001A.Location = new Point(731, -4);
    obj0.\u001A.Name = "pictureBox4";
    obj0.\u001A.Size = new Size(3, 136);
    obj0.\u001A.TabIndex = 175;
    obj0.\u001A.TabStop = false;
    obj0.\u0007.Controls.Add((Control) obj0.\u000F);
    obj0.\u0007.Controls.Add((Control) obj0.\u0014);
    obj0.\u0007.Controls.Add((Control) obj0.\u0010);
    obj0.\u0007.Controls.Add((Control) obj0.\u0015);
    obj0.\u0007.Controls.Add((Control) obj0.\u0011);
    obj0.\u0007.Controls.Add((Control) obj0.\u0016);
    obj0.\u0007.Controls.Add((Control) obj0.\u0012);
    obj0.\u0007.Controls.Add((Control) obj0.\u0017);
    obj0.\u0007.Controls.Add((Control) obj0.\u0015);
    obj0.\u0007.Controls.Add((Control) obj0.\u0013);
    obj0.\u0007.Controls.Add((Control) obj0.\u0012);
    obj0.\u0007.Controls.Add((Control) obj0.\u0011);
    obj0.\u0007.Controls.Add((Control) obj0.\u0014);
    obj0.\u0007.Controls.Add((Control) obj0.\u0010);
    obj0.\u0007.Controls.Add((Control) obj0.\u000F);
    obj0.\u0007.Controls.Add((Control) obj0.\u000E);
    obj0.\u0007.Location = new Point(63 /*0x3F*/, 2);
    obj0.\u0007.Name = "pnl_check2";
    obj0.\u0007.Size = new Size(192 /*0xC0*/, 124);
    obj0.\u0007.TabIndex = 162;
    obj0.\u000F.AutoSize = true;
    obj0.\u000F.Location = new Point(18, 27);
    obj0.\u000F.Name = "chk_flute2";
    obj0.\u000F.Size = new Size(18, 17);
    obj0.\u000F.TabIndex = 162;
    obj0.\u000F.UseVisualStyleBackColor = true;
    obj0.\u000F.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0014.AutoSize = true;
    obj0.\u0014.Location = new Point(123, 3);
    obj0.\u0014.Name = "lbl_holder2";
    obj0.\u0014.Size = new Size(50, 17);
    obj0.\u0014.TabIndex = 169;
    obj0.\u0014.Text = "Holder";
    obj0.\u0010.AutoSize = true;
    obj0.\u0010.Location = new Point(54, 27);
    obj0.\u0010.Name = "chk_shaft2";
    obj0.\u0010.Size = new Size(18, 17);
    obj0.\u0010.TabIndex = 163;
    obj0.\u0010.UseVisualStyleBackColor = true;
    obj0.\u0010.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0015.AutoSize = true;
    obj0.\u0015.Location = new Point(77, 3);
    obj0.\u0015.Name = "lbl_Arbor2";
    obj0.\u0015.Size = new Size(43, 17);
    obj0.\u0015.TabIndex = 168;
    obj0.\u0015.Text = "Arbor";
    obj0.\u0011.AutoSize = true;
    obj0.\u0011.Location = new Point(86, 27);
    obj0.\u0011.Name = "chk_arbor2";
    obj0.\u0011.Size = new Size(18, 17);
    obj0.\u0011.TabIndex = 164;
    obj0.\u0011.UseVisualStyleBackColor = true;
    obj0.\u0011.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0016.AutoSize = true;
    obj0.\u0016.Location = new Point(40, 3);
    obj0.\u0016.Name = "lbl_shaft2";
    obj0.\u0016.Size = new Size(41, 17);
    obj0.\u0016.TabIndex = 167;
    obj0.\u0016.Text = "Shaft";
    obj0.\u0012.AutoSize = true;
    obj0.\u0012.Location = new Point(136, 27);
    obj0.\u0012.Name = "chk_holder2";
    obj0.\u0012.Size = new Size(18, 17);
    obj0.\u0012.TabIndex = 165;
    obj0.\u0012.UseVisualStyleBackColor = true;
    obj0.\u0012.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0017.AutoSize = true;
    obj0.\u0017.Location = new Point(1, 3);
    obj0.\u0017.Name = "lbl_flute2";
    obj0.\u0017.Size = new Size(39, 17);
    obj0.\u0017.TabIndex = 166;
    obj0.\u0017.Text = "Flute";
    obj0.\u0008.Controls.Add((Control) obj0.combo_relink2);
    obj0.\u0008.Controls.Add((Control) obj0.\u001B);
    obj0.\u0008.Controls.Add((Control) obj0.\u0002);
    obj0.\u0008.Controls.Add((Control) obj0.combo_action2);
    obj0.\u0008.Controls.Add((Control) obj0.combo_move2);
    obj0.\u0008.Location = new Point(268, 2);
    obj0.\u0008.Name = "pnl_strategy2";
    obj0.\u0008.Size = new Size(457, 124);
    obj0.\u0008.TabIndex = 163;
    obj0.\u001B.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u001B.Location = new Point(297, 6);
    obj0.\u001B.Name = "pic_preview2";
    obj0.\u001B.Size = new Size(159, 114);
    obj0.\u001B.TabIndex = 176 /*0xB0*/;
    obj0.\u001B.TabStop = false;
    obj0.\u0002.Location = new Point(8, 93);
    obj0.\u0002.Name = "btn_advanced2";
    obj0.\u0002.Size = new Size(204, 28);
    obj0.\u0002.TabIndex = 162;
    obj0.\u0002.Text = "Advanced";
    obj0.\u0002.UseVisualStyleBackColor = true;
    obj0.\u0002.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.combo_action2.FormattingEnabled = true;
    obj0.combo_action2.Items.AddRange(new object[4]
    {
      (object) "Retract Tool",
      (object) "Trim and Relink Toolpath",
      (object) "Stop Toolpath Calculation",
      (object) "Report Collision"
    });
    obj0.combo_action2.Location = new Point(8, 6);
    obj0.combo_action2.Name = "combo_action2";
    obj0.combo_action2.Size = new Size(280, 24);
    obj0.combo_action2.TabIndex = 162;
    obj0.combo_action2.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.combo_move2.FormattingEnabled = true;
    obj0.combo_move2.Items.AddRange(new object[19]
    {
      (object) "Along Toll Axis",
      (object) "Along +Z",
      (object) "Along XY Plane",
      (object) "Along XZ Plane",
      (object) "Along YZ Plane",
      (object) "Along -Z",
      (object) "Along +X",
      (object) "Along -X",
      (object) "Along +Y",
      (object) "Along -Y",
      (object) "Along Surface Normal",
      (object) "Away From Origine",
      (object) "Along to Cutter Center",
      (object) "Along Opt. in XY Plane",
      (object) "Along Opt. in XZ Plane",
      (object) "Along Opt. in YZ Plane",
      (object) "Along User Defined Direction",
      (object) "Along Tool Contact Line",
      (object) "Along Tool Plane"
    });
    obj0.combo_move2.Location = new Point(8, 34);
    obj0.combo_move2.Name = "combo_move2";
    obj0.combo_move2.Size = new Size(280, 24);
    obj0.combo_move2.TabIndex = 163;
    obj0.combo_move2.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.\u001C.BackColor = Color.Black;
    obj0.\u001C.Location = new Point(259, -1);
    obj0.\u001C.Name = "pictureBox5";
    obj0.\u001C.Size = new Size(3, 136);
    obj0.\u001C.TabIndex = 174;
    obj0.\u001C.TabStop = false;
    obj0.\u001D.BackColor = Color.Black;
    obj0.\u001D.Location = new Point(57, -1);
    obj0.\u001D.Name = "pictureBox6";
    obj0.\u001D.Size = new Size(3, 136);
    obj0.\u001D.TabIndex = 173;
    obj0.\u001D.TabStop = false;
    obj0.\u0018.AutoSize = true;
    obj0.\u0018.Location = new Point(5, 3);
    obj0.\u0018.Name = "lbl_enable2";
    obj0.\u0018.Size = new Size(52, 17);
    obj0.\u0018.TabIndex = 172;
    obj0.\u0018.Text = "Enable";
    obj0.\u0013.AutoSize = true;
    obj0.\u0013.Location = new Point(20, 28);
    obj0.\u0013.Name = "chk_enable2";
    obj0.\u0013.Size = new Size(18, 17);
    obj0.\u0013.TabIndex = 171;
    obj0.\u0013.UseVisualStyleBackColor = true;
    obj0.\u0013.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0019.AutoSize = true;
    obj0.\u0019.Font = new Font("Microsoft Sans Serif", 19.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0019.Location = new Point(13, 67);
    obj0.\u0019.Name = "lbl_number2";
    obj0.\u0019.Size = new Size(36, 38);
    obj0.\u0019.TabIndex = 170;
    obj0.\u0019.Text = "2";
    obj0.\u000E.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u000E.Controls.Add((Control) obj0.\u000F);
    obj0.\u000E.Controls.Add((Control) obj0.\u001E);
    obj0.\u000E.Controls.Add((Control) obj0.\u0010);
    obj0.\u000E.Controls.Add((Control) obj0.\u0011);
    obj0.\u000E.Controls.Add((Control) obj0.\u0088);
    obj0.\u000E.Controls.Add((Control) obj0.\u0089);
    obj0.\u000E.Controls.Add((Control) obj0.\u007F);
    obj0.\u000E.Controls.Add((Control) obj0.\u001A);
    obj0.\u000E.Controls.Add((Control) obj0.\u0080);
    obj0.\u000E.Location = new Point(9, 461);
    obj0.\u000E.Name = "panel9";
    obj0.\u000E.Size = new Size(945, 130);
    obj0.\u000E.TabIndex = 190;
    obj0.\u000F.Controls.Add((Control) ((F_MwGaugeRemainCollsion) obj0).\u000F);
    obj0.\u000F.Controls.Add((Control) obj0.\u001A);
    obj0.\u000F.Controls.Add((Control) obj0.\u0005);
    obj0.\u000F.Controls.Add((Control) obj0.\u001B);
    obj0.\u000F.Controls.Add((Control) obj0.\u0014);
    obj0.\u000F.Controls.Add((Control) obj0.\u0006);
    obj0.\u000F.Controls.Add((Control) obj0.\u0015);
    obj0.\u000F.Location = new Point(740, 2);
    obj0.\u000F.Name = "pnl_geometry4";
    obj0.\u000F.Size = new Size(198, 124);
    obj0.\u000F.TabIndex = 162;
    obj0.\u001A.AutoSize = true;
    obj0.\u001A.Location = new Point(3, 88);
    obj0.\u001A.Name = "lbl_tolerance4";
    obj0.\u001A.Size = new Size(72, 17);
    obj0.\u001A.TabIndex = 166;
    obj0.\u001A.Text = "Tolerance";
    obj0.\u0005.DecimalPlaces = 2;
    obj0.\u0005.Location = new Point(111, 85);
    obj0.\u0005.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0005.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0005.Name = "spn_tolerance4";
    obj0.\u0005.Size = new Size(78, 22);
    obj0.\u0005.TabIndex = 165;
    obj0.\u001B.AutoSize = true;
    obj0.\u001B.Location = new Point(3, 60);
    obj0.\u001B.Name = "lbl_leavetostock4";
    obj0.\u001B.Size = new Size(102, 17);
    obj0.\u001B.TabIndex = 163;
    obj0.\u001B.Text = "Stock to Leave";
    obj0.\u0014.AutoSize = true;
    obj0.\u0014.Location = new Point(3, 33);
    obj0.\u0014.Name = "chk_checksurface4";
    obj0.\u0014.Size = new Size(122, 21);
    obj0.\u0014.TabIndex = 164;
    obj0.\u0014.Text = "Check Surface";
    obj0.\u0014.UseVisualStyleBackColor = true;
    obj0.\u0014.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0006.DecimalPlaces = 1;
    obj0.\u0006.Location = new Point(111, 57);
    obj0.\u0006.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0006.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0006.Name = "spn_leavetostock4";
    obj0.\u0006.Size = new Size(78, 22);
    obj0.\u0006.TabIndex = 162;
    obj0.\u0015.AutoSize = true;
    obj0.\u0015.Location = new Point(3, 6);
    obj0.\u0015.Name = "chk_machinesurface4";
    obj0.\u0015.Size = new Size(147, 21);
    obj0.\u0015.TabIndex = 163;
    obj0.\u0015.Text = "Machining Surface";
    obj0.\u0015.UseVisualStyleBackColor = true;
    obj0.\u0015.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u001E.BackColor = Color.Black;
    obj0.\u001E.Location = new Point(731, -4);
    obj0.\u001E.Name = "pictureBox7";
    obj0.\u001E.Size = new Size(3, 136);
    obj0.\u001E.TabIndex = 175;
    obj0.\u001E.TabStop = false;
    obj0.\u0010.Controls.Add((Control) obj0.\u001F);
    obj0.\u0010.Controls.Add((Control) obj0.\u0016);
    obj0.\u0010.Controls.Add((Control) obj0.\u007F);
    obj0.\u0010.Controls.Add((Control) obj0.\u001C);
    obj0.\u0010.Controls.Add((Control) obj0.\u0080);
    obj0.\u0010.Controls.Add((Control) obj0.\u0017);
    obj0.\u0010.Controls.Add((Control) obj0.\u0081);
    obj0.\u0010.Controls.Add((Control) obj0.\u0082);
    obj0.\u0010.Controls.Add((Control) obj0.\u001D);
    obj0.\u0010.Controls.Add((Control) obj0.\u0083);
    obj0.\u0010.Controls.Add((Control) obj0.\u0018);
    obj0.\u0010.Controls.Add((Control) obj0.\u0084);
    obj0.\u0010.Controls.Add((Control) obj0.\u001E);
    obj0.\u0010.Controls.Add((Control) obj0.\u0019);
    obj0.\u0010.Controls.Add((Control) obj0.\u0086);
    obj0.\u0010.Controls.Add((Control) obj0.\u001F);
    obj0.\u0010.Location = new Point(63 /*0x3F*/, 2);
    obj0.\u0010.Name = "pnl_check4";
    obj0.\u0010.Size = new Size(192 /*0xC0*/, 124);
    obj0.\u0010.TabIndex = 162;
    obj0.\u001F.Image = (Image) componentResourceManager.GetObject("pic_toolholderON_4.Image");
    obj0.\u001F.Location = new Point(105, 52);
    obj0.\u001F.Name = "pic_toolholderON_4";
    obj0.\u001F.Size = new Size(82, 68);
    obj0.\u001F.TabIndex = 204;
    obj0.\u001F.TabStop = false;
    obj0.\u0016.AutoSize = true;
    obj0.\u0016.Location = new Point(18, 27);
    obj0.\u0016.Name = "chk_flute4";
    obj0.\u0016.Size = new Size(18, 17);
    obj0.\u0016.TabIndex = 162;
    obj0.\u0016.UseVisualStyleBackColor = true;
    obj0.\u0016.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u007F.Image = (Image) componentResourceManager.GetObject("pic_toolarborON_4.Image");
    obj0.\u007F.Location = new Point(78, 52);
    obj0.\u007F.Name = "pic_toolarborON_4";
    obj0.\u007F.Size = new Size(28, 68);
    obj0.\u007F.TabIndex = 203;
    obj0.\u007F.TabStop = false;
    obj0.\u001C.AutoSize = true;
    obj0.\u001C.Location = new Point(123, 3);
    obj0.\u001C.Name = "lbl_holder4";
    obj0.\u001C.Size = new Size(50, 17);
    obj0.\u001C.TabIndex = 169;
    obj0.\u001C.Text = "Holder";
    obj0.\u0080.Image = (Image) componentResourceManager.GetObject("pic_toolshoftON_4.Image");
    obj0.\u0080.Location = new Point(50, 52);
    obj0.\u0080.Name = "pic_toolshoftON_4";
    obj0.\u0080.Size = new Size(29, 68);
    obj0.\u0080.TabIndex = 202;
    obj0.\u0080.TabStop = false;
    obj0.\u0017.AutoSize = true;
    obj0.\u0017.Location = new Point(54, 27);
    obj0.\u0017.Name = "chk_shaft4";
    obj0.\u0017.Size = new Size(18, 17);
    obj0.\u0017.TabIndex = 163;
    obj0.\u0017.UseVisualStyleBackColor = true;
    obj0.\u0017.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0081.Image = (Image) componentResourceManager.GetObject("pic_toolfluteON_4.Image");
    obj0.\u0081.Location = new Point(18, 52);
    obj0.\u0081.Name = "pic_toolfluteON_4";
    obj0.\u0081.Size = new Size(34, 68);
    obj0.\u0081.TabIndex = 198;
    obj0.\u0081.TabStop = false;
    obj0.\u0082.Image = (Image) componentResourceManager.GetObject("pic_toolholderOFF_4.Image");
    obj0.\u0082.Location = new Point(105, 51);
    obj0.\u0082.Name = "pic_toolholderOFF_4";
    obj0.\u0082.Size = new Size(82, 68);
    obj0.\u0082.TabIndex = 201;
    obj0.\u0082.TabStop = false;
    obj0.\u001D.AutoSize = true;
    obj0.\u001D.Location = new Point(77, 3);
    obj0.\u001D.Name = "lbl_Arbor4";
    obj0.\u001D.Size = new Size(43, 17);
    obj0.\u001D.TabIndex = 168;
    obj0.\u001D.Text = "Arbor";
    obj0.\u0083.Image = (Image) componentResourceManager.GetObject("pic_toolarborOFF_4.Image");
    obj0.\u0083.Location = new Point(78, 51);
    obj0.\u0083.Name = "pic_toolarborOFF_4";
    obj0.\u0083.Size = new Size(28, 68);
    obj0.\u0083.TabIndex = 200;
    obj0.\u0083.TabStop = false;
    obj0.\u0018.AutoSize = true;
    obj0.\u0018.Location = new Point(86, 27);
    obj0.\u0018.Name = "chk_arbor4";
    obj0.\u0018.Size = new Size(18, 17);
    obj0.\u0018.TabIndex = 164;
    obj0.\u0018.UseVisualStyleBackColor = true;
    obj0.\u0018.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0084.Image = (Image) componentResourceManager.GetObject("pic_toolshoftOFF_4.Image");
    obj0.\u0084.Location = new Point(50, 51);
    obj0.\u0084.Name = "pic_toolshoftOFF_4";
    obj0.\u0084.Size = new Size(29, 68);
    obj0.\u0084.TabIndex = 199;
    obj0.\u0084.TabStop = false;
    obj0.\u001E.AutoSize = true;
    obj0.\u001E.Location = new Point(40, 3);
    obj0.\u001E.Name = "lbl_shaft4";
    obj0.\u001E.Size = new Size(41, 17);
    obj0.\u001E.TabIndex = 167;
    obj0.\u001E.Text = "Shaft";
    obj0.\u0019.AutoSize = true;
    obj0.\u0019.Location = new Point(136, 27);
    obj0.\u0019.Name = "chk_holder4";
    obj0.\u0019.Size = new Size(18, 17);
    obj0.\u0019.TabIndex = 165;
    obj0.\u0019.UseVisualStyleBackColor = true;
    obj0.\u0019.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0086.Image = (Image) componentResourceManager.GetObject("pic_toolfluteOFF_4.Image");
    obj0.\u0086.Location = new Point(18, 51);
    obj0.\u0086.Name = "pic_toolfluteOFF_4";
    obj0.\u0086.Size = new Size(34, 68);
    obj0.\u0086.TabIndex = 197;
    obj0.\u0086.TabStop = false;
    obj0.\u001F.AutoSize = true;
    obj0.\u001F.Location = new Point(1, 3);
    obj0.\u001F.Name = "lbl_flute4";
    obj0.\u001F.Size = new Size(39, 17);
    obj0.\u001F.TabIndex = 166;
    obj0.\u001F.Text = "Flute";
    obj0.\u0011.Controls.Add((Control) obj0.combo_relink4);
    obj0.\u0011.Controls.Add((Control) obj0.\u0087);
    obj0.\u0011.Controls.Add((Control) obj0.\u0003);
    obj0.\u0011.Controls.Add((Control) obj0.combo_action4);
    obj0.\u0011.Controls.Add((Control) obj0.combo_move4);
    obj0.\u0011.Location = new Point(268, 2);
    obj0.\u0011.Name = "pnl_strategy4";
    obj0.\u0011.Size = new Size(457, 124);
    obj0.\u0011.TabIndex = 163;
    obj0.\u0087.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0087.Location = new Point(297, 6);
    obj0.\u0087.Name = "pic_preview4";
    obj0.\u0087.Size = new Size(159, 114);
    obj0.\u0087.TabIndex = 176 /*0xB0*/;
    obj0.\u0087.TabStop = false;
    obj0.\u0003.Location = new Point(8, 93);
    obj0.\u0003.Name = "btn_advanced4";
    obj0.\u0003.Size = new Size(204, 28);
    obj0.\u0003.TabIndex = 162;
    obj0.\u0003.Text = "Advanced";
    obj0.\u0003.UseVisualStyleBackColor = true;
    obj0.\u0003.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.combo_action4.FormattingEnabled = true;
    obj0.combo_action4.Items.AddRange(new object[4]
    {
      (object) "Retract Tool",
      (object) "Trim and Relink Toolpath",
      (object) "Stop Toolpath Calculation",
      (object) "Report Collision"
    });
    obj0.combo_action4.Location = new Point(8, 6);
    obj0.combo_action4.Name = "combo_action4";
    obj0.combo_action4.Size = new Size(280, 24);
    obj0.combo_action4.TabIndex = 162;
    obj0.combo_action4.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.combo_move4.FormattingEnabled = true;
    obj0.combo_move4.Items.AddRange(new object[19]
    {
      (object) "Along Toll Axis",
      (object) "Along +Z",
      (object) "Along XY Plane",
      (object) "Along XZ Plane",
      (object) "Along YZ Plane",
      (object) "Along -Z",
      (object) "Along +X",
      (object) "Along -X",
      (object) "Along +Y",
      (object) "Along -Y",
      (object) "Along Surface Normal",
      (object) "Away From Origine",
      (object) "Along to Cutter Center",
      (object) "Along Opt. in XY Plane",
      (object) "Along Opt. in XZ Plane",
      (object) "Along Opt. in YZ Plane",
      (object) "Along User Defined Direction",
      (object) "Along Tool Contact Line",
      (object) "Along Tool Plane"
    });
    obj0.combo_move4.Location = new Point(8, 34);
    obj0.combo_move4.Name = "combo_move4";
    obj0.combo_move4.Size = new Size(280, 24);
    obj0.combo_move4.TabIndex = 163;
    obj0.combo_move4.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.\u0088.BackColor = Color.Black;
    obj0.\u0088.Location = new Point(259, -1);
    obj0.\u0088.Name = "pictureBox8";
    obj0.\u0088.Size = new Size(3, 136);
    obj0.\u0088.TabIndex = 174;
    obj0.\u0088.TabStop = false;
    obj0.\u0089.BackColor = Color.Black;
    obj0.\u0089.Location = new Point(57, -1);
    obj0.\u0089.Name = "pictureBox9";
    obj0.\u0089.Size = new Size(3, 136);
    obj0.\u0089.TabIndex = 173;
    obj0.\u0089.TabStop = false;
    obj0.\u007F.AutoSize = true;
    obj0.\u007F.Location = new Point(5, 3);
    obj0.\u007F.Name = "lbl_enable4";
    obj0.\u007F.Size = new Size(52, 17);
    obj0.\u007F.TabIndex = 172;
    obj0.\u007F.Text = "Enable";
    obj0.\u001A.AutoSize = true;
    obj0.\u001A.Location = new Point(20, 28);
    obj0.\u001A.Name = "chk_enable4";
    obj0.\u001A.Size = new Size(18, 17);
    obj0.\u001A.TabIndex = 171;
    obj0.\u001A.UseVisualStyleBackColor = true;
    obj0.\u001A.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0080.AutoSize = true;
    obj0.\u0080.Font = new Font("Microsoft Sans Serif", 19.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0080.Location = new Point(13, 67);
    obj0.\u0080.Name = "lbl_number4";
    obj0.\u0080.Size = new Size(36, 38);
    obj0.\u0080.TabIndex = 170;
    obj0.\u0080.Text = "4";
    obj0.\u0012.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0012.Controls.Add((Control) obj0.\u0013);
    obj0.\u0012.Controls.Add((Control) obj0.\u008A);
    obj0.\u0012.Controls.Add((Control) obj0.\u0014);
    obj0.\u0012.Controls.Add((Control) obj0.\u0015);
    obj0.\u0012.Controls.Add((Control) obj0.\u0094);
    obj0.\u0012.Controls.Add((Control) obj0.\u0095);
    obj0.\u0012.Controls.Add((Control) obj0.\u0088);
    obj0.\u0012.Controls.Add((Control) obj0.\u0080);
    obj0.\u0012.Controls.Add((Control) obj0.\u0089);
    obj0.\u0012.Location = new Point(9, 319);
    obj0.\u0012.Name = "panel10";
    obj0.\u0012.Size = new Size(945, 130);
    obj0.\u0012.TabIndex = 189;
    obj0.\u0013.Controls.Add((Control) ((F_MwGaugeRemainCollsion) obj0).\u0010);
    obj0.\u0013.Controls.Add((Control) obj0.\u0081);
    obj0.\u0013.Controls.Add((Control) obj0.\u0007);
    obj0.\u0013.Controls.Add((Control) obj0.\u0082);
    obj0.\u0013.Controls.Add((Control) obj0.\u001B);
    obj0.\u0013.Controls.Add((Control) obj0.\u0008);
    obj0.\u0013.Controls.Add((Control) obj0.\u001C);
    obj0.\u0013.Location = new Point(740, 2);
    obj0.\u0013.Name = "pnl_geometry3";
    obj0.\u0013.Size = new Size(198, 124);
    obj0.\u0013.TabIndex = 162;
    obj0.\u0081.AutoSize = true;
    obj0.\u0081.Location = new Point(3, 88);
    obj0.\u0081.Name = "lbl_tolerance3";
    obj0.\u0081.Size = new Size(72, 17);
    obj0.\u0081.TabIndex = 166;
    obj0.\u0081.Text = "Tolerance";
    obj0.\u0007.DecimalPlaces = 2;
    obj0.\u0007.Location = new Point(111, 85);
    obj0.\u0007.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0007.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0007.Name = "spn_tolerance3";
    obj0.\u0007.Size = new Size(78, 22);
    obj0.\u0007.TabIndex = 165;
    obj0.\u0082.AutoSize = true;
    obj0.\u0082.Location = new Point(3, 60);
    obj0.\u0082.Name = "lbl_leavetostock3";
    obj0.\u0082.Size = new Size(102, 17);
    obj0.\u0082.TabIndex = 163;
    obj0.\u0082.Text = "Stock to Leave";
    obj0.\u001B.AutoSize = true;
    obj0.\u001B.Location = new Point(3, 33);
    obj0.\u001B.Name = "chk_checksurface3";
    obj0.\u001B.Size = new Size(122, 21);
    obj0.\u001B.TabIndex = 164;
    obj0.\u001B.Text = "Check Surface";
    obj0.\u001B.UseVisualStyleBackColor = true;
    obj0.\u001B.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0008.DecimalPlaces = 1;
    obj0.\u0008.Location = new Point(111, 57);
    obj0.\u0008.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    obj0.\u0008.Minimum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      int.MinValue
    });
    obj0.\u0008.Name = "spn_leavetostock3";
    obj0.\u0008.Size = new Size(78, 22);
    obj0.\u0008.TabIndex = 162;
    obj0.\u001C.AutoSize = true;
    obj0.\u001C.Location = new Point(3, 6);
    obj0.\u001C.Name = "chk_machinesurface3";
    obj0.\u001C.Size = new Size(147, 21);
    obj0.\u001C.TabIndex = 163;
    obj0.\u001C.Text = "Machining Surface";
    obj0.\u001C.UseVisualStyleBackColor = true;
    obj0.\u001C.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u008A.BackColor = Color.Black;
    obj0.\u008A.Location = new Point(731, -4);
    obj0.\u008A.Name = "pictureBox10";
    obj0.\u008A.Size = new Size(3, 136);
    obj0.\u008A.TabIndex = 175;
    obj0.\u008A.TabStop = false;
    obj0.\u0014.Controls.Add((Control) obj0.\u001D);
    obj0.\u0014.Controls.Add((Control) obj0.\u0083);
    obj0.\u0014.Controls.Add((Control) obj0.\u001E);
    obj0.\u0014.Controls.Add((Control) obj0.\u0084);
    obj0.\u0014.Controls.Add((Control) obj0.\u001F);
    obj0.\u0014.Controls.Add((Control) obj0.\u0086);
    obj0.\u0014.Controls.Add((Control) obj0.\u007F);
    obj0.\u0014.Controls.Add((Control) obj0.\u0087);
    obj0.\u0014.Controls.Add((Control) obj0.\u008B);
    obj0.\u0014.Controls.Add((Control) obj0.\u008C);
    obj0.\u0014.Controls.Add((Control) obj0.\u008D);
    obj0.\u0014.Controls.Add((Control) obj0.\u008E);
    obj0.\u0014.Controls.Add((Control) obj0.\u008F);
    obj0.\u0014.Controls.Add((Control) obj0.\u0090);
    obj0.\u0014.Controls.Add((Control) obj0.\u0091);
    obj0.\u0014.Controls.Add((Control) obj0.\u0092);
    obj0.\u0014.Location = new Point(63 /*0x3F*/, 2);
    obj0.\u0014.Name = "pnl_check3";
    obj0.\u0014.Size = new Size(192 /*0xC0*/, 124);
    obj0.\u0014.TabIndex = 162;
    obj0.\u001D.AutoSize = true;
    obj0.\u001D.Location = new Point(18, 27);
    obj0.\u001D.Name = "chk_flute3";
    obj0.\u001D.Size = new Size(18, 17);
    obj0.\u001D.TabIndex = 162;
    obj0.\u001D.UseVisualStyleBackColor = true;
    obj0.\u001D.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0083.AutoSize = true;
    obj0.\u0083.Location = new Point(123, 3);
    obj0.\u0083.Name = "lbl_holder3";
    obj0.\u0083.Size = new Size(50, 17);
    obj0.\u0083.TabIndex = 169;
    obj0.\u0083.Text = "Holder";
    obj0.\u001E.AutoSize = true;
    obj0.\u001E.Location = new Point(54, 27);
    obj0.\u001E.Name = "chk_shaft3";
    obj0.\u001E.Size = new Size(18, 17);
    obj0.\u001E.TabIndex = 163;
    obj0.\u001E.UseVisualStyleBackColor = true;
    obj0.\u001E.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0084.AutoSize = true;
    obj0.\u0084.Location = new Point(77, 3);
    obj0.\u0084.Name = "lbl_Arbor3";
    obj0.\u0084.Size = new Size(43, 17);
    obj0.\u0084.TabIndex = 168;
    obj0.\u0084.Text = "Arbor";
    obj0.\u001F.AutoSize = true;
    obj0.\u001F.Location = new Point(86, 27);
    obj0.\u001F.Name = "chk_arbor3";
    obj0.\u001F.Size = new Size(18, 17);
    obj0.\u001F.TabIndex = 164;
    obj0.\u001F.UseVisualStyleBackColor = true;
    obj0.\u001F.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0086.AutoSize = true;
    obj0.\u0086.Location = new Point(40, 3);
    obj0.\u0086.Name = "lbl_shaft3";
    obj0.\u0086.Size = new Size(41, 17);
    obj0.\u0086.TabIndex = 167;
    obj0.\u0086.Text = "Shaft";
    obj0.\u007F.AutoSize = true;
    obj0.\u007F.Location = new Point(136, 27);
    obj0.\u007F.Name = "chk_holder3";
    obj0.\u007F.Size = new Size(18, 17);
    obj0.\u007F.TabIndex = 165;
    obj0.\u007F.UseVisualStyleBackColor = true;
    obj0.\u007F.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0087.AutoSize = true;
    obj0.\u0087.Location = new Point(1, 3);
    obj0.\u0087.Name = "lbl_flute3";
    obj0.\u0087.Size = new Size(39, 17);
    obj0.\u0087.TabIndex = 166;
    obj0.\u0087.Text = "Flute";
    obj0.\u008B.Image = (Image) componentResourceManager.GetObject("pic_toolholderON_3.Image");
    obj0.\u008B.Location = new Point(105, 51);
    obj0.\u008B.Name = "pic_toolholderON_3";
    obj0.\u008B.Size = new Size(82, 68);
    obj0.\u008B.TabIndex = 196;
    obj0.\u008B.TabStop = false;
    obj0.\u008C.Image = (Image) componentResourceManager.GetObject("pic_toolfluteOFF_3.Image");
    obj0.\u008C.Location = new Point(18, 51);
    obj0.\u008C.Name = "pic_toolfluteOFF_3";
    obj0.\u008C.Size = new Size(34, 68);
    obj0.\u008C.TabIndex = 189;
    obj0.\u008C.TabStop = false;
    obj0.\u008D.Image = (Image) componentResourceManager.GetObject("pic_toolarborON_3.Image");
    obj0.\u008D.Location = new Point(78, 51);
    obj0.\u008D.Name = "pic_toolarborON_3";
    obj0.\u008D.Size = new Size(28, 68);
    obj0.\u008D.TabIndex = 195;
    obj0.\u008D.TabStop = false;
    obj0.\u008E.Image = (Image) componentResourceManager.GetObject("pic_toolshoftOFF_3.Image");
    obj0.\u008E.Location = new Point(50, 51);
    obj0.\u008E.Name = "pic_toolshoftOFF_3";
    obj0.\u008E.Size = new Size(29, 68);
    obj0.\u008E.TabIndex = 191;
    obj0.\u008E.TabStop = false;
    obj0.\u008F.Image = (Image) componentResourceManager.GetObject("pic_toolshoftON_3.Image");
    obj0.\u008F.Location = new Point(50, 51);
    obj0.\u008F.Name = "pic_toolshoftON_3";
    obj0.\u008F.Size = new Size(29, 68);
    obj0.\u008F.TabIndex = 194;
    obj0.\u008F.TabStop = false;
    obj0.\u0090.Image = (Image) componentResourceManager.GetObject("pic_toolarborOFF_3.Image");
    obj0.\u0090.Location = new Point(78, 51);
    obj0.\u0090.Name = "pic_toolarborOFF_3";
    obj0.\u0090.Size = new Size(28, 68);
    obj0.\u0090.TabIndex = 192 /*0xC0*/;
    obj0.\u0090.TabStop = false;
    obj0.\u0091.Image = (Image) componentResourceManager.GetObject("pic_toolfluteON_3.Image");
    obj0.\u0091.Location = new Point(18, 51);
    obj0.\u0091.Name = "pic_toolfluteON_3";
    obj0.\u0091.Size = new Size(34, 68);
    obj0.\u0091.TabIndex = 190;
    obj0.\u0091.TabStop = false;
    obj0.\u0092.Image = (Image) componentResourceManager.GetObject("pic_toolholderOFF_3.Image");
    obj0.\u0092.Location = new Point(105, 51);
    obj0.\u0092.Name = "pic_toolholderOFF_3";
    obj0.\u0092.Size = new Size(82, 68);
    obj0.\u0092.TabIndex = 193;
    obj0.\u0092.TabStop = false;
    obj0.\u0015.Controls.Add((Control) obj0.combo_relink3);
    obj0.\u0015.Controls.Add((Control) obj0.\u0093);
    obj0.\u0015.Controls.Add((Control) obj0.\u0004);
    obj0.\u0015.Controls.Add((Control) obj0.combo_action3);
    obj0.\u0015.Controls.Add((Control) obj0.combo_move3);
    obj0.\u0015.Location = new Point(268, 2);
    obj0.\u0015.Name = "pnl_strategy3";
    obj0.\u0015.Size = new Size(457, 124);
    obj0.\u0015.TabIndex = 163;
    obj0.\u0093.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0093.Location = new Point(297, 6);
    obj0.\u0093.Name = "pic_preview3";
    obj0.\u0093.Size = new Size(159, 114);
    obj0.\u0093.TabIndex = 176 /*0xB0*/;
    obj0.\u0093.TabStop = false;
    obj0.\u0004.Location = new Point(8, 93);
    obj0.\u0004.Name = "btn_advanced3";
    obj0.\u0004.Size = new Size(204, 28);
    obj0.\u0004.TabIndex = 162;
    obj0.\u0004.Text = "Advanced";
    obj0.\u0004.UseVisualStyleBackColor = true;
    obj0.\u0004.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.combo_action3.FormattingEnabled = true;
    obj0.combo_action3.Items.AddRange(new object[4]
    {
      (object) "Retract Tool",
      (object) "Trim and Relink Toolpath",
      (object) "Stop Toolpath Calculation",
      (object) "Report Collision"
    });
    obj0.combo_action3.Location = new Point(8, 6);
    obj0.combo_action3.Name = "combo_action3";
    obj0.combo_action3.Size = new Size(280, 24);
    obj0.combo_action3.TabIndex = 162;
    obj0.combo_action3.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.combo_move3.FormattingEnabled = true;
    obj0.combo_move3.Items.AddRange(new object[19]
    {
      (object) "Along Toll Axis",
      (object) "Along +Z",
      (object) "Along XY Plane",
      (object) "Along XZ Plane",
      (object) "Along YZ Plane",
      (object) "Along -Z",
      (object) "Along +X",
      (object) "Along -X",
      (object) "Along +Y",
      (object) "Along -Y",
      (object) "Along Surface Normal",
      (object) "Away From Origine",
      (object) "Along to Cutter Center",
      (object) "Along Opt. in XY Plane",
      (object) "Along Opt. in XZ Plane",
      (object) "Along Opt. in YZ Plane",
      (object) "Along User Defined Direction",
      (object) "Along Tool Contact Line",
      (object) "Along Tool Plane"
    });
    obj0.combo_move3.Location = new Point(8, 34);
    obj0.combo_move3.Name = "combo_move3";
    obj0.combo_move3.Size = new Size(280, 24);
    obj0.combo_move3.TabIndex = 163;
    obj0.combo_move3.SelectedIndexChanged += new EventHandler(obj0.\u0004);
    obj0.\u0094.BackColor = Color.Black;
    obj0.\u0094.Location = new Point(259, -1);
    obj0.\u0094.Name = "pictureBox11";
    obj0.\u0094.Size = new Size(3, 136);
    obj0.\u0094.TabIndex = 174;
    obj0.\u0094.TabStop = false;
    obj0.\u0095.BackColor = Color.Black;
    obj0.\u0095.Location = new Point(57, -1);
    obj0.\u0095.Name = "pictureBox12";
    obj0.\u0095.Size = new Size(3, 136);
    obj0.\u0095.TabIndex = 173;
    obj0.\u0095.TabStop = false;
    obj0.\u0088.AutoSize = true;
    obj0.\u0088.Location = new Point(5, 3);
    obj0.\u0088.Name = "lbl_enable3";
    obj0.\u0088.Size = new Size(52, 17);
    obj0.\u0088.TabIndex = 172;
    obj0.\u0088.Text = "Enable";
    obj0.\u0080.AutoSize = true;
    obj0.\u0080.Location = new Point(20, 28);
    obj0.\u0080.Name = "chk_enable3";
    obj0.\u0080.Size = new Size(18, 17);
    obj0.\u0080.TabIndex = 171;
    obj0.\u0080.UseVisualStyleBackColor = true;
    obj0.\u0080.CheckedChanged += new EventHandler(obj0.\u0003);
    obj0.\u0089.AutoSize = true;
    obj0.\u0089.Font = new Font("Microsoft Sans Serif", 19.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0089.Location = new Point(13, 67);
    obj0.\u0089.Name = "lbl_number3";
    obj0.\u0089.Size = new Size(36, 38);
    obj0.\u0089.TabIndex = 170;
    obj0.\u0089.Text = "3";
    obj0.\u0005.Location = new Point(9, 599);
    obj0.\u0005.Name = "btn_remaincollision";
    obj0.\u0005.Size = new Size(204, 39);
    obj0.\u0005.TabIndex = 191;
    obj0.\u0005.Text = "Remain Collision";
    obj0.\u0005.UseVisualStyleBackColor = true;
    obj0.\u0005.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.\u0006.Location = new Point(219, 599);
    obj0.\u0006.Name = "btn_clearancefortoolpath";
    obj0.\u0006.Size = new Size(204, 39);
    obj0.\u0006.TabIndex = 192 /*0xC0*/;
    obj0.\u0006.Text = "Clearance for Toolpath";
    obj0.\u0006.UseVisualStyleBackColor = true;
    obj0.\u0006.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.\u0007.Location = new Point(429, 599);
    obj0.\u0007.Name = "btn_advancedsettings";
    obj0.\u0007.Size = new Size(204, 39);
    obj0.\u0007.TabIndex = 193;
    obj0.\u0007.Text = "Advanced";
    obj0.\u0007.UseVisualStyleBackColor = true;
    obj0.\u0007.Click += new EventHandler(((F_MwGaugeRemainCollsion) obj0).\u0005);
    obj0.\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
    obj0.\u0001.TransparentColor = Color.Transparent;
    obj0.\u0001.Images.SetKeyName(0, "cancel.ico");
    obj0.\u0001.Images.SetKeyName(1, "ok.ico");
    obj0.btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    obj0.btn_cancel.DialogResult = DialogResult.Cancel;
    obj0.btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
    obj0.btn_cancel.ImageIndex = 0;
    obj0.btn_cancel.ImageList = obj0.\u0001;
    obj0.btn_cancel.Location = new Point(861, 599);
    obj0.btn_cancel.Margin = new Padding(4);
    obj0.btn_cancel.Name = "btn_cancel";
    obj0.btn_cancel.Size = new Size(98, 39);
    obj0.btn_cancel.TabIndex = 194;
    obj0.btn_cancel.Text = "Cancel";
    obj0.btn_cancel.TextAlign = ContentAlignment.MiddleRight;
    obj0.btn_cancel.Click += new EventHandler(obj0.\u0002);
    obj0.btn_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    obj0.btn_ok.ImageAlign = ContentAlignment.MiddleLeft;
    obj0.btn_ok.ImageIndex = 1;
    obj0.btn_ok.ImageList = obj0.\u0001;
    obj0.btn_ok.Location = new Point(755, 599);
    obj0.btn_ok.Margin = new Padding(4);
    obj0.btn_ok.Name = "btn_ok";
    obj0.btn_ok.Size = new Size(98, 39);
    obj0.btn_ok.TabIndex = 195;
    obj0.btn_ok.Text = "Ok";
    obj0.btn_ok.TextAlign = ContentAlignment.MiddleRight;
    obj0.btn_ok.Click += new EventHandler(obj0.\u0001);
    obj0.combo_relink1.FormattingEnabled = true;
    obj0.combo_relink1.Items.AddRange(new object[6]
    {
      (object) "Trim Collision Only",
      (object) "Trim Toolpath After First Collision",
      (object) "Trim Toolpath Before Last Collision",
      (object) "Trim Toolpath Betweel First and LAst Collision",
      (object) "Trim Toolpath Before First Collision",
      (object) "Trim Toolpath After Last Collision"
    });
    obj0.combo_relink1.Location = new Point(8, 62);
    obj0.combo_relink1.Name = "combo_relink1";
    obj0.combo_relink1.Size = new Size(280, 24);
    obj0.combo_relink1.TabIndex = 177;
    obj0.combo_relink2.FormattingEnabled = true;
    obj0.combo_relink2.Items.AddRange(new object[6]
    {
      (object) "Trim Collision Only",
      (object) "Trim Toolpath After First Collision",
      (object) "Trim Toolpath Before Last Collision",
      (object) "Trim Toolpath Betweel First and LAst Collision",
      (object) "Trim Toolpath Before First Collision",
      (object) "Trim Toolpath After Last Collision"
    });
    obj0.combo_relink2.Location = new Point(8, 62);
    obj0.combo_relink2.Name = "combo_relink2";
    obj0.combo_relink2.Size = new Size(280, 24);
    obj0.combo_relink2.TabIndex = 178;
    obj0.combo_relink3.FormattingEnabled = true;
    obj0.combo_relink3.Items.AddRange(new object[6]
    {
      (object) "Trim Collision Only",
      (object) "Trim Toolpath After First Collision",
      (object) "Trim Toolpath Before Last Collision",
      (object) "Trim Toolpath Betweel First and LAst Collision",
      (object) "Trim Toolpath Before First Collision",
      (object) "Trim Toolpath After Last Collision"
    });
    obj0.combo_relink3.Location = new Point(8, 62);
    obj0.combo_relink3.Name = "combo_relink3";
    obj0.combo_relink3.Size = new Size(280, 24);
    obj0.combo_relink3.TabIndex = 178;
    obj0.combo_relink4.FormattingEnabled = true;
    obj0.combo_relink4.Items.AddRange(new object[6]
    {
      (object) "Trim Collision Only",
      (object) "Trim Toolpath After First Collision",
      (object) "Trim Toolpath Before Last Collision",
      (object) "Trim Toolpath Betweel First and LAst Collision",
      (object) "Trim Toolpath Before First Collision",
      (object) "Trim Toolpath After Last Collision"
    });
    obj0.combo_relink4.Location = new Point(8, 62);
    obj0.combo_relink4.Name = "combo_relink4";
    obj0.combo_relink4.Size = new Size(280, 24);
    obj0.combo_relink4.TabIndex = 178;
    obj0.\u0008.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0008.Location = new Point(151, 32 /*0x20*/);
    obj0.\u0008.Name = "btn_Checksurf1";
    obj0.\u0008.Size = new Size(38, 23);
    obj0.\u0008.TabIndex = 178;
    obj0.\u0008.Text = "...";
    obj0.\u0008.UseVisualStyleBackColor = true;
    ((F_MwGaugeRemainCollsion) obj0).\u000E.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_MwGaugeRemainCollsion) obj0).\u000E.Location = new Point(151, 32 /*0x20*/);
    ((F_MwGaugeRemainCollsion) obj0).\u000E.Name = "btn_Checksurf2";
    ((F_MwGaugeRemainCollsion) obj0).\u000E.Size = new Size(38, 23);
    ((F_MwGaugeRemainCollsion) obj0).\u000E.TabIndex = 179;
    ((F_MwGaugeRemainCollsion) obj0).\u000E.Text = "...";
    ((F_MwGaugeRemainCollsion) obj0).\u000E.UseVisualStyleBackColor = true;
    ((F_MwGaugeRemainCollsion) obj0).\u0010.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_MwGaugeRemainCollsion) obj0).\u0010.Location = new Point(151, 32 /*0x20*/);
    ((F_MwGaugeRemainCollsion) obj0).\u0010.Name = "btn_Checksurf3";
    ((F_MwGaugeRemainCollsion) obj0).\u0010.Size = new Size(38, 23);
    ((F_MwGaugeRemainCollsion) obj0).\u0010.TabIndex = 179;
    ((F_MwGaugeRemainCollsion) obj0).\u0010.Text = "...";
    ((F_MwGaugeRemainCollsion) obj0).\u0010.UseVisualStyleBackColor = true;
    ((F_MwGaugeRemainCollsion) obj0).\u000F.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_MwGaugeRemainCollsion) obj0).\u000F.Location = new Point(151, 32 /*0x20*/);
    ((F_MwGaugeRemainCollsion) obj0).\u000F.Name = "btn_Checksurf4";
    ((F_MwGaugeRemainCollsion) obj0).\u000F.Size = new Size(38, 23);
    ((F_MwGaugeRemainCollsion) obj0).\u000F.TabIndex = 179;
    ((F_MwGaugeRemainCollsion) obj0).\u000F.Text = "...";
    ((F_MwGaugeRemainCollsion) obj0).\u000F.UseVisualStyleBackColor = true;
    obj0.AutoScaleDimensions = new SizeF(8f, 16f);
    obj0.AutoScaleMode = AutoScaleMode.Font;
    obj0.ClientSize = new Size(964, 644);
    obj0.Controls.Add((Control) obj0.btn_cancel);
    obj0.Controls.Add((Control) obj0.btn_ok);
    obj0.Controls.Add((Control) obj0.\u0007);
    obj0.Controls.Add((Control) obj0.\u0006);
    obj0.Controls.Add((Control) obj0.\u0005);
    obj0.Controls.Add((Control) obj0.\u000E);
    obj0.Controls.Add((Control) obj0.\u0012);
    obj0.Controls.Add((Control) obj0.\u0005);
    obj0.Controls.Add((Control) obj0.\u0011);
    obj0.Controls.Add((Control) obj0.\u0010);
    obj0.Controls.Add((Control) obj0.\u000F);
    obj0.Controls.Add((Control) obj0.\u0001);
    obj0.Controls.Add((Control) obj0.\u0007);
    obj0.MaximizeBox = false;
    obj0.MinimizeBox = false;
    obj0.Name = "F_MwGaugeCheck";
    obj0.Text = "Gauge Check";
    obj0.FormClosing += new FormClosingEventHandler(obj0.\u0001);
    ((ISupportInitialize) obj0.\u0001).EndInit();
    ((ISupportInitialize) obj0.\u0002).EndInit();
    ((ISupportInitialize) obj0.\u0003).EndInit();
    ((ISupportInitialize) obj0.\u0004).EndInit();
    ((ISupportInitialize) obj0.\u0005).EndInit();
    ((ISupportInitialize) obj0.\u0006).EndInit();
    ((ISupportInitialize) obj0.\u0007).EndInit();
    ((ISupportInitialize) obj0.\u0008).EndInit();
    ((ISupportInitialize) obj0.\u000E).EndInit();
    ((ISupportInitialize) obj0.\u000F).EndInit();
    ((ISupportInitialize) obj0.\u0010).EndInit();
    ((ISupportInitialize) obj0.\u0011).EndInit();
    ((ISupportInitialize) obj0.\u0012).EndInit();
    ((ISupportInitialize) obj0.\u0013).EndInit();
    ((ISupportInitialize) obj0.\u0014).EndInit();
    ((ISupportInitialize) obj0.\u0015).EndInit();
    obj0.\u0001.ResumeLayout(false);
    obj0.\u0001.PerformLayout();
    obj0.\u0002.ResumeLayout(false);
    obj0.\u0002.PerformLayout();
    obj0.\u0001.EndInit();
    obj0.\u0002.EndInit();
    ((ISupportInitialize) obj0.\u0018).EndInit();
    obj0.\u0003.ResumeLayout(false);
    obj0.\u0003.PerformLayout();
    obj0.\u0004.ResumeLayout(false);
    ((ISupportInitialize) obj0.\u0019).EndInit();
    ((ISupportInitialize) obj0.\u0016).EndInit();
    ((ISupportInitialize) obj0.\u0017).EndInit();
    obj0.\u0005.ResumeLayout(false);
    obj0.\u0005.PerformLayout();
    obj0.\u0006.ResumeLayout(false);
    obj0.\u0006.PerformLayout();
    obj0.\u0003.EndInit();
    obj0.\u0004.EndInit();
    ((ISupportInitialize) obj0.\u001A).EndInit();
    obj0.\u0007.ResumeLayout(false);
    obj0.\u0007.PerformLayout();
    obj0.\u0008.ResumeLayout(false);
    ((ISupportInitialize) obj0.\u001B).EndInit();
    ((ISupportInitialize) obj0.\u001C).EndInit();
    ((ISupportInitialize) obj0.\u001D).EndInit();
    obj0.\u000E.ResumeLayout(false);
    obj0.\u000E.PerformLayout();
    obj0.\u000F.ResumeLayout(false);
    obj0.\u000F.PerformLayout();
    obj0.\u0005.EndInit();
    obj0.\u0006.EndInit();
    ((ISupportInitialize) obj0.\u001E).EndInit();
    obj0.\u0010.ResumeLayout(false);
    obj0.\u0010.PerformLayout();
    ((ISupportInitialize) obj0.\u001F).EndInit();
    ((ISupportInitialize) obj0.\u007F).EndInit();
    ((ISupportInitialize) obj0.\u0080).EndInit();
    ((ISupportInitialize) obj0.\u0081).EndInit();
    ((ISupportInitialize) obj0.\u0082).EndInit();
    ((ISupportInitialize) obj0.\u0083).EndInit();
    ((ISupportInitialize) obj0.\u0084).EndInit();
    ((ISupportInitialize) obj0.\u0086).EndInit();
    obj0.\u0011.ResumeLayout(false);
    ((ISupportInitialize) obj0.\u0087).EndInit();
    ((ISupportInitialize) obj0.\u0088).EndInit();
    ((ISupportInitialize) obj0.\u0089).EndInit();
    obj0.\u0012.ResumeLayout(false);
    obj0.\u0012.PerformLayout();
    obj0.\u0013.ResumeLayout(false);
    obj0.\u0013.PerformLayout();
    obj0.\u0007.EndInit();
    obj0.\u0008.EndInit();
    ((ISupportInitialize) obj0.\u008A).EndInit();
    obj0.\u0014.ResumeLayout(false);
    obj0.\u0014.PerformLayout();
    ((ISupportInitialize) obj0.\u008B).EndInit();
    ((ISupportInitialize) obj0.\u008C).EndInit();
    ((ISupportInitialize) obj0.\u008D).EndInit();
    ((ISupportInitialize) obj0.\u008E).EndInit();
    ((ISupportInitialize) obj0.\u008F).EndInit();
    ((ISupportInitialize) obj0.\u0090).EndInit();
    ((ISupportInitialize) obj0.\u0091).EndInit();
    ((ISupportInitialize) obj0.\u0092).EndInit();
    obj0.\u0015.ResumeLayout(false);
    ((ISupportInitialize) obj0.\u0093).EndInit();
    ((ISupportInitialize) obj0.\u0094).EndInit();
    ((ISupportInitialize) obj0.\u0095).EndInit();
    obj0.ResumeLayout(false);
    obj0.PerformLayout();
  }

  static void \u0001([In] F_Fixtures obj0)
  {
    obj0.\u0001 = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_Fixtures));
    obj0.\u0001 = new System.Windows.Forms.Label();
    obj0.\u0001 = new Panel();
    obj0.\u0002 = new Panel();
    obj0.\u0001 = new RadioButton();
    obj0.\u0002 = new RadioButton();
    obj0.\u0001 = new ImageList(obj0.\u0001);
    obj0.\u0002 = new System.Windows.Forms.Label();
    obj0.\u0001 = new PictureBox();
    obj0.btn_ok = new Button();
    obj0.\u0002 = new ImageList(obj0.\u0001);
    ((F_Filtering) obj0).btn_cancel = new Button();
    ((F_Filtering) obj0).\u0001 = new CheckBox();
    ((F_Filtering) obj0).\u0001 = new NumericUpDown();
    ((F_Filtering) obj0).\u0003 = new System.Windows.Forms.Label();
    ((F_Filtering) obj0).\u0002 = new NumericUpDown();
    ((F_Filtering) obj0).\u0004 = new System.Windows.Forms.Label();
    obj0.\u0001.SuspendLayout();
    obj0.\u0002.SuspendLayout();
    ((ISupportInitialize) obj0.\u0001).BeginInit();
    ((F_Filtering) obj0).\u0001.BeginInit();
    ((F_Filtering) obj0).\u0002.BeginInit();
    obj0.SuspendLayout();
    obj0.\u0001.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    obj0.\u0001.BackColor = Color.Gainsboro;
    obj0.\u0001.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0001.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0001.Location = new Point(-1, -1);
    obj0.\u0001.Name = "lbl_toolcaption";
    obj0.\u0001.Padding = new Padding(5, 0, 0, 0);
    obj0.\u0001.Size = new Size(319, 32 /*0x20*/);
    obj0.\u0001.TabIndex = 0;
    obj0.\u0001.Text = "Tool Direction";
    obj0.\u0001.TextAlign = ContentAlignment.MiddleLeft;
    obj0.\u0001.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0001.Controls.Add((Control) obj0.\u0001);
    obj0.\u0001.Controls.Add((Control) obj0.\u0002);
    obj0.\u0001.Location = new Point(6, 98);
    obj0.\u0001.Name = "pnl_stock";
    obj0.\u0001.Size = new Size(319, 136);
    obj0.\u0001.TabIndex = 203;
    obj0.\u0002.Controls.Add((Control) obj0.\u0001);
    obj0.\u0002.Controls.Add((Control) obj0.\u0002);
    obj0.\u0002.Location = new Point(3, 37);
    obj0.\u0002.Name = "pnl_auto";
    obj0.\u0002.Size = new Size(306, 87);
    obj0.\u0002.TabIndex = 200;
    obj0.\u0001.AutoSize = true;
    obj0.\u0001.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0001.Location = new Point(15, 48 /*0x30*/);
    obj0.\u0001.Name = "radio_center";
    obj0.\u0001.Size = new Size(79, 22);
    obj0.\u0001.TabIndex = 133;
    obj0.\u0001.TabStop = true;
    obj0.\u0001.Text = "Center";
    obj0.\u0001.UseVisualStyleBackColor = true;
    obj0.\u0001.CheckedChanged += new EventHandler(((F_Filtering) obj0).\u0002);
    obj0.\u0001.Enter += new EventHandler(((F_Filtering) obj0).\u0003);
    obj0.\u0002.AutoSize = true;
    obj0.\u0002.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0002.Location = new Point(15, 10);
    obj0.\u0002.Name = "radio_outside";
    obj0.\u0002.Size = new Size(87, 22);
    obj0.\u0002.TabIndex = 132;
    obj0.\u0002.TabStop = true;
    obj0.\u0002.Text = "Outside";
    obj0.\u0002.UseVisualStyleBackColor = true;
    obj0.\u0002.CheckedChanged += new EventHandler(((F_Filtering) obj0).\u0002);
    obj0.\u0002.Enter += new EventHandler(((F_Filtering) obj0).\u0003);
    obj0.\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC256.ImageStream");
    obj0.\u0001.TransparentColor = Color.Transparent;
    obj0.\u0001.Images.SetKeyName(0, "steep_areas_slope_angle_start.png");
    obj0.\u0002.AutoSize = true;
    obj0.\u0002.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    obj0.\u0002.Location = new Point(331, 6);
    obj0.\u0002.Name = "label19";
    obj0.\u0002.Size = new Size(67, 18);
    obj0.\u0002.TabIndex = 195;
    obj0.\u0002.Text = "Preview";
    obj0.\u0001.BorderStyle = BorderStyle.FixedSingle;
    obj0.\u0001.Location = new Point(331, 28);
    obj0.\u0001.Name = "pic_preview";
    obj0.\u0001.Size = new Size(320, 320);
    obj0.\u0001.TabIndex = 194;
    obj0.\u0001.TabStop = false;
    obj0.btn_ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    obj0.btn_ok.ImageAlign = ContentAlignment.MiddleLeft;
    obj0.btn_ok.ImageIndex = 1;
    obj0.btn_ok.ImageList = obj0.\u0002;
    obj0.btn_ok.Location = new Point(446, 354);
    obj0.btn_ok.Margin = new Padding(4);
    obj0.btn_ok.Name = "btn_ok";
    obj0.btn_ok.Size = new Size(98, 39);
    obj0.btn_ok.TabIndex = 199;
    obj0.btn_ok.Text = "Ok";
    obj0.btn_ok.TextAlign = ContentAlignment.MiddleRight;
    obj0.btn_ok.Click += new EventHandler(obj0.\u0001);
    obj0.\u0002.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
    obj0.\u0002.TransparentColor = Color.Transparent;
    obj0.\u0002.Images.SetKeyName(0, "cancel.ico");
    obj0.\u0002.Images.SetKeyName(1, "ok.ico");
    ((F_Filtering) obj0).btn_cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ((F_Filtering) obj0).btn_cancel.DialogResult = DialogResult.Cancel;
    ((F_Filtering) obj0).btn_cancel.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_Filtering) obj0).btn_cancel.ImageIndex = 0;
    ((F_Filtering) obj0).btn_cancel.ImageList = obj0.\u0002;
    ((F_Filtering) obj0).btn_cancel.Location = new Point(552, 354);
    ((F_Filtering) obj0).btn_cancel.Margin = new Padding(4);
    ((F_Filtering) obj0).btn_cancel.Name = "btn_cancel";
    ((F_Filtering) obj0).btn_cancel.Size = new Size(98, 39);
    ((F_Filtering) obj0).btn_cancel.TabIndex = 197;
    ((F_Filtering) obj0).btn_cancel.Text = "Cancel";
    ((F_Filtering) obj0).btn_cancel.TextAlign = ContentAlignment.MiddleRight;
    ((F_Filtering) obj0).btn_cancel.Click += new EventHandler(obj0.\u0001);
    ((F_Filtering) obj0).\u0001.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    ((F_Filtering) obj0).\u0001.Location = new Point(331, 354);
    ((F_Filtering) obj0).\u0001.Name = "chk_showhelp";
    ((F_Filtering) obj0).\u0001.Size = new Size(75, 21);
    ((F_Filtering) obj0).\u0001.TabIndex = 204;
    ((F_Filtering) obj0).\u0001.Text = "Help";
    ((F_Filtering) obj0).\u0001.UseVisualStyleBackColor = true;
    ((F_Filtering) obj0).\u0001.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    ((F_Filtering) obj0).\u0001.DecimalPlaces = 3;
    ((F_Filtering) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_Filtering) obj0).\u0001.Location = new Point(218, 28);
    ((F_Filtering) obj0).\u0001.Margin = new Padding(3, 2, 3, 2);
    ((F_Filtering) obj0).\u0001.Maximum = new Decimal(new int[4]
    {
      100000000,
      0,
      0,
      0
    });
    ((F_Filtering) obj0).\u0001.Minimum = new Decimal(new int[4]
    {
      100000000,
      0,
      0,
      int.MinValue
    });
    ((F_Filtering) obj0).\u0001.Name = "spn_fixtureaddtionaloffset";
    ((F_Filtering) obj0).\u0001.Size = new Size(107, 24);
    ((F_Filtering) obj0).\u0001.TabIndex = 212;
    ((F_Filtering) obj0).\u0001.Tag = (object) "11";
    ((F_Filtering) obj0).\u0001.Enter += new EventHandler(((F_Filtering) obj0).\u0003);
    ((F_Filtering) obj0).\u0003.AutoSize = true;
    ((F_Filtering) obj0).\u0003.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_Filtering) obj0).\u0003.Location = new Point(6, 34);
    ((F_Filtering) obj0).\u0003.Name = "lbl_fixtureaddtionaloffset";
    ((F_Filtering) obj0).\u0003.Size = new Size(132, 18);
    ((F_Filtering) obj0).\u0003.TabIndex = 211;
    ((F_Filtering) obj0).\u0003.Text = "Additional Offset";
    ((F_Filtering) obj0).\u0002.DecimalPlaces = 3;
    ((F_Filtering) obj0).\u0002.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_Filtering) obj0).\u0002.Location = new Point(218, 56);
    ((F_Filtering) obj0).\u0002.Margin = new Padding(3, 2, 3, 2);
    ((F_Filtering) obj0).\u0002.Maximum = new Decimal(new int[4]
    {
      100000000,
      0,
      0,
      0
    });
    ((F_Filtering) obj0).\u0002.Minimum = new Decimal(new int[4]
    {
      100000000,
      0,
      0,
      int.MinValue
    });
    ((F_Filtering) obj0).\u0002.Name = "spn_fixturecurveheight";
    ((F_Filtering) obj0).\u0002.Size = new Size(107, 24);
    ((F_Filtering) obj0).\u0002.TabIndex = 210;
    ((F_Filtering) obj0).\u0002.Tag = (object) "6";
    ((F_Filtering) obj0).\u0002.Enter += new EventHandler(((F_Filtering) obj0).\u0003);
    ((F_Filtering) obj0).\u0004.AutoSize = true;
    ((F_Filtering) obj0).\u0004.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_Filtering) obj0).\u0004.Location = new Point(6, 62);
    ((F_Filtering) obj0).\u0004.Name = "lbl_fixturecurveheight";
    ((F_Filtering) obj0).\u0004.Size = new Size(105, 18);
    ((F_Filtering) obj0).\u0004.TabIndex = 209;
    ((F_Filtering) obj0).\u0004.Text = "Curve Height";
    obj0.AutoScaleDimensions = new SizeF(8f, 16f);
    obj0.AutoScaleMode = AutoScaleMode.Font;
    obj0.ClientSize = new Size(656, 398);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).\u0003);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).\u0004);
    obj0.Controls.Add((Control) obj0.\u0001);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).\u0002);
    obj0.Controls.Add((Control) obj0.\u0002);
    obj0.Controls.Add((Control) obj0.\u0001);
    obj0.Controls.Add((Control) obj0.btn_ok);
    obj0.Controls.Add((Control) ((F_Filtering) obj0).btn_cancel);
    obj0.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    obj0.MaximizeBox = false;
    obj0.MinimizeBox = false;
    obj0.Name = "F_Fixtures";
    obj0.Text = "Fixtures";
    obj0.FormClosing += new FormClosingEventHandler(obj0.\u0001);
    obj0.\u0001.ResumeLayout(false);
    obj0.\u0002.ResumeLayout(false);
    obj0.\u0002.PerformLayout();
    ((ISupportInitialize) obj0.\u0001).EndInit();
    ((F_Filtering) obj0).\u0001.EndInit();
    ((F_Filtering) obj0).\u0002.EndInit();
    obj0.ResumeLayout(false);
    obj0.PerformLayout();
  }

  public abstract void m000249();

  public F_MwTriMUpDownAdvanced() => \u0005.\u0002.\u0001(this);

  public void Init()
  {
    this.Properties.Inited = false;
    if (this.Properties.Height > 10)
      this.Height = this.Properties.Height;
    if (this.Properties.Width > 10)
      this.Width = this.Properties.Width;
    this.TopMost = this.Properties.TopMost;
    this.StartPosition = this.Properties.FormPosition;
    ((F_MwTriMUtility) this).\u0002.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinHeightChange;
    ((F_MwTriMUtility) this).\u0001.Value = (Decimal) this.Par.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.OverlapDistance;
    ((F_MwTriMUtility) this).UpdateControlFromType();
    this.Properties.Result = DialogResult.None;
    this.Properties.Inited = true;
  }

  internal void \u0001([In] object obj0, [In] FormClosingEventArgs obj1)
  {
    if (this.Properties.Result == DialogResult.OK)
      return;
    obj1.Cancel = true;
    this.Properties.Result = DialogResult.Cancel;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }

  internal void \u0001([In] object obj0, [In] EventArgs obj1)
  {
    ((F_MwTriMUtility) this).Apply();
    this.Properties.Result = DialogResult.OK;
    if (this.Properties.FormCloseMode == FormCloseModeType.Dispose)
      this.Dispose();
    if (this.Properties.FormCloseMode != FormCloseModeType.Invisible)
      return;
    this.Visible = false;
  }
}
