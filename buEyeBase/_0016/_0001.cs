// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buEyeBaseVer5.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace \u0016;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
internal class \u0001 : Attribute
{
  static void \u0001([In] F_NestPartAdd obj0)
  {
    ((F_NestSheetPartList) obj0).\u0001 = (IContainer) new Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (F_NestPartAdd));
    ((F_NestSheetPartList) obj0).\u0001 = new Panel();
    ((F_NestSheetPartList) obj0).\u0001 = new Label();
    ((F_NestSheetPartList) obj0).txt_name = new TextBox();
    ((F_NestSheetPartList) obj0).\u0001 = new Button();
    ((F_NestSheetPartList) obj0).\u0001 = new ImageList(((F_NestSheetPartList) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0002 = new Panel();
    ((F_NestSheetPartList) obj0).\u0002 = new Label();
    ((F_NestSheetPartList) obj0).\u0001 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u0002 = new Button();
    ((F_NestSheetPartList) obj0).\u0003 = new Panel();
    ((F_NestSheetPartList) obj0).\u0001 = new ComboBox();
    ((F_NestSheetPartList) obj0).\u0003 = new Label();
    ((F_NestSheetPartList) obj0).\u0004 = new Label();
    ((F_NestSheetPartList) obj0).\u0002 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u0004 = new Panel();
    ((F_NestSheetPartList) obj0).\u0007 = new Label();
    ((F_NestSheetPartList) obj0).\u0005 = new Label();
    ((F_NestSheetPartList) obj0).\u0003 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u0005 = new Panel();
    ((F_NestSheetPartList) obj0).\u0006 = new Label();
    ((F_NestSheetPartList) obj0).\u0006 = new Panel();
    ((F_NestSheetPartList) obj0).\u0001 = new CheckBox();
    ((F_NestSheetPartList) obj0).\u0002 = new CheckBox();
    ((F_NestSheetPartList) obj0).\u0007 = new Panel();
    ((F_NestSheetPartList) obj0).\u0008 = new Label();
    ((F_NestSheetPartList) obj0).\u000E = new Label();
    ((F_NestSheetPartList) obj0).\u0001 = new RadioButton();
    ((F_NestSheetPartList) obj0).\u0002 = new RadioButton();
    ((F_NestSheetPartList) obj0).\u0004 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u000F = new Label();
    ((F_NestSheetPartList) obj0).\u0008 = new Panel();
    ((F_NestSheetPartList) obj0).\u0010 = new Label();
    ((F_NestSheetPartList) obj0).\u0011 = new Label();
    ((F_NestSheetPartList) obj0).\u0005 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u0003 = new CheckBox();
    ((F_NestSheetPartList) obj0).\u0006 = new NumericUpDown();
    ((F_NestSheetPartList) obj0).\u0012 = new Label();
    ((F_NestSheetPartList) obj0).\u0013 = new Label();
    ((F_NestSheetPartList) obj0).\u0001.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0002.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0001.BeginInit();
    ((F_NestSheetPartList) obj0).\u0003.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0002.BeginInit();
    ((F_NestSheetPartList) obj0).\u0004.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0003.BeginInit();
    ((F_NestSheetPartList) obj0).\u0005.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0007.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0004.BeginInit();
    ((F_NestSheetPartList) obj0).\u0008.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0005.BeginInit();
    ((F_NestSheetPartList) obj0).\u0006.BeginInit();
    obj0.SuspendLayout();
    ((F_NestSheetPartList) obj0).\u0001.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0001.Controls.Add((Control) ((F_NestSheetPartList) obj0).txt_name);
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(5, 6);
    ((F_NestSheetPartList) obj0).\u0001.Name = "pnl_name";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(332, 36);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 79;
    ((F_NestSheetPartList) obj0).\u0001.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(6, 9);
    ((F_NestSheetPartList) obj0).\u0001.Name = "lbl_partName";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(75, 17);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0001.Text = "Part Name";
    ((F_NestSheetPartList) obj0).txt_name.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).txt_name.Location = new Point(138, 4);
    ((F_NestSheetPartList) obj0).txt_name.Name = "txt_name";
    ((F_NestSheetPartList) obj0).txt_name.Size = new Size(176 /*0xB0*/, 27);
    ((F_NestSheetPartList) obj0).txt_name.TabIndex = 58;
    ((F_NestSheetPartList) obj0).\u0001.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ((F_NestSheetPartList) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0001.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestSheetPartList) obj0).\u0001.ImageIndex = 2;
    ((F_NestSheetPartList) obj0).\u0001.ImageList = ((F_NestSheetPartList) obj0).\u0001;
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(113, 638);
    ((F_NestSheetPartList) obj0).\u0001.Name = "btn_add";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(101, 42);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 78;
    ((F_NestSheetPartList) obj0).\u0001.Text = "Add";
    ((F_NestSheetPartList) obj0).\u0001.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestSheetPartList) obj0).\u0001.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0001.Click += new EventHandler(((F_SettingTreeView.DefaultClickEvent) obj0).\u0003);
    ((F_NestSheetPartList) obj0).\u0001.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("IC32.ImageStream");
    ((F_NestSheetPartList) obj0).\u0001.TransparentColor = Color.Transparent;
    ((F_NestSheetPartList) obj0).\u0001.Images.SetKeyName(0, "cancel.ico");
    ((F_NestSheetPartList) obj0).\u0001.Images.SetKeyName(1, "ok.ico");
    ((F_NestSheetPartList) obj0).\u0001.Images.SetKeyName(2, "addpart2.ico");
    ((F_NestSheetPartList) obj0).\u0002.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    ((F_NestSheetPartList) obj0).\u0002.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(5, 125);
    ((F_NestSheetPartList) obj0).\u0002.Name = "panel1";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(317, 36);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 85;
    ((F_NestSheetPartList) obj0).\u0002.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(6, 10);
    ((F_NestSheetPartList) obj0).\u0002.Name = "lbl_priority";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(52, 17);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0002.Text = "Priority";
    ((F_NestSheetPartList) obj0).\u0001.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(138, 5);
    ((F_NestSheetPartList) obj0).\u0001.Maximum = new Decimal(new int[4]
    {
      10,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0001.Minimum = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0001.Name = "spn_priority";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 60;
    ((F_NestSheetPartList) obj0).\u0001.Value = new Decimal(new int[4]
    {
      10,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0002.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    ((F_NestSheetPartList) obj0).\u0002.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0002.ImageAlign = ContentAlignment.MiddleLeft;
    ((F_NestSheetPartList) obj0).\u0002.ImageIndex = 0;
    ((F_NestSheetPartList) obj0).\u0002.ImageList = ((F_NestSheetPartList) obj0).\u0001;
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(220, 638);
    ((F_NestSheetPartList) obj0).\u0002.Name = "btn_close";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(101, 42);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 77;
    ((F_NestSheetPartList) obj0).\u0002.Text = "Close";
    ((F_NestSheetPartList) obj0).\u0002.TextAlign = ContentAlignment.MiddleRight;
    ((F_NestSheetPartList) obj0).\u0002.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0002.Click += new EventHandler(((F_SettingTreeView.DefaultClickEvent) obj0).\u0003);
    ((F_NestSheetPartList) obj0).\u0003.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0013);
    ((F_NestSheetPartList) obj0).\u0003.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0012);
    ((F_NestSheetPartList) obj0).\u0003.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0006);
    ((F_NestSheetPartList) obj0).\u0003.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0003.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0003);
    ((F_NestSheetPartList) obj0).\u0003.Location = new Point(5, 165);
    ((F_NestSheetPartList) obj0).\u0003.Name = "panel2";
    ((F_NestSheetPartList) obj0).\u0003.Size = new Size(317, 61);
    ((F_NestSheetPartList) obj0).\u0003.TabIndex = 86;
    ((F_NestSheetPartList) obj0).\u0001.FormattingEnabled = true;
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(138, 6);
    ((F_NestSheetPartList) obj0).\u0001.Name = "cmb_rotation";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(176 /*0xB0*/, 24);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 66;
    ((F_NestSheetPartList) obj0).\u0003.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0003.Location = new Point(6, 10);
    ((F_NestSheetPartList) obj0).\u0003.Name = "lbl_rotation";
    ((F_NestSheetPartList) obj0).\u0003.Size = new Size(61, 17);
    ((F_NestSheetPartList) obj0).\u0003.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0003.Text = "Rotation";
    ((F_NestSheetPartList) obj0).\u0004.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0004.Location = new Point(6, 10);
    ((F_NestSheetPartList) obj0).\u0004.Name = "lbl_quantity";
    ((F_NestSheetPartList) obj0).\u0004.Size = new Size(61, 17);
    ((F_NestSheetPartList) obj0).\u0004.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0004.Text = "Quantity";
    ((F_NestSheetPartList) obj0).\u0002.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(138, 5);
    ((F_NestSheetPartList) obj0).\u0002.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0002.Minimum = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0002.Name = "spn_quantity";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 60;
    ((F_NestSheetPartList) obj0).\u0002.Value = new Decimal(new int[4]
    {
      1,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0004.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0007);
    ((F_NestSheetPartList) obj0).\u0004.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0004);
    ((F_NestSheetPartList) obj0).\u0004.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    ((F_NestSheetPartList) obj0).\u0004.Location = new Point(5, 85);
    ((F_NestSheetPartList) obj0).\u0004.Name = "pnl_quantity";
    ((F_NestSheetPartList) obj0).\u0004.Size = new Size(317, 36);
    ((F_NestSheetPartList) obj0).\u0004.TabIndex = 83;
    ((F_NestSheetPartList) obj0).\u0007.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0007.Location = new Point(284, 10);
    ((F_NestSheetPartList) obj0).\u0007.Name = "lbl_unitquantitiy2";
    ((F_NestSheetPartList) obj0).\u0007.Size = new Size(30, 17);
    ((F_NestSheetPartList) obj0).\u0007.TabIndex = 66;
    ((F_NestSheetPartList) obj0).\u0007.Text = "Qty";
    ((F_NestSheetPartList) obj0).\u0005.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0005.Location = new Point(6, 9);
    ((F_NestSheetPartList) obj0).\u0005.Name = "lbl_thickness";
    ((F_NestSheetPartList) obj0).\u0005.Size = new Size(72, 17);
    ((F_NestSheetPartList) obj0).\u0005.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0005.Text = "Thickness";
    ((F_NestSheetPartList) obj0).\u0003.DecimalPlaces = 2;
    ((F_NestSheetPartList) obj0).\u0003.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0003.Location = new Point(138, 4);
    ((F_NestSheetPartList) obj0).\u0003.Maximum = new Decimal(new int[4]
    {
      1410065408,
      2,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0003.Name = "spn_thickness";
    ((F_NestSheetPartList) obj0).\u0003.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0003.TabIndex = 60;
    ((F_NestSheetPartList) obj0).\u0003.Value = new Decimal(new int[4]
    {
      10,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0005.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0006);
    ((F_NestSheetPartList) obj0).\u0005.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0005);
    ((F_NestSheetPartList) obj0).\u0005.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0003);
    ((F_NestSheetPartList) obj0).\u0005.Location = new Point(5, 46);
    ((F_NestSheetPartList) obj0).\u0005.Name = "pnl_thickness";
    ((F_NestSheetPartList) obj0).\u0005.Size = new Size(317, 36);
    ((F_NestSheetPartList) obj0).\u0005.TabIndex = 82;
    ((F_NestSheetPartList) obj0).\u0006.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0006.Location = new Point(284, 8);
    ((F_NestSheetPartList) obj0).\u0006.Name = "lbl_unitmetric";
    ((F_NestSheetPartList) obj0).\u0006.Size = new Size(30, 17);
    ((F_NestSheetPartList) obj0).\u0006.TabIndex = 63 /*0x3F*/;
    ((F_NestSheetPartList) obj0).\u0006.Text = "mm";
    ((F_NestSheetPartList) obj0).\u0006.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    ((F_NestSheetPartList) obj0).\u0006.Location = new Point(5, 423);
    ((F_NestSheetPartList) obj0).\u0006.Name = "pnl_view";
    ((F_NestSheetPartList) obj0).\u0006.Size = new Size(317, 207);
    ((F_NestSheetPartList) obj0).\u0006.TabIndex = 87;
    ((F_NestSheetPartList) obj0).\u0001.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(12, 342);
    ((F_NestSheetPartList) obj0).\u0001.Name = "chk_addauxentities";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(132, 21);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 88;
    ((F_NestSheetPartList) obj0).\u0001.Text = "Add Aux Entities";
    ((F_NestSheetPartList) obj0).\u0001.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0001.CheckedChanged += new EventHandler(((DataTableItem) obj0).\u0004);
    ((F_NestSheetPartList) obj0).\u0002.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(12, 369);
    ((F_NestSheetPartList) obj0).\u0002.Name = "chk_Deleteselectedentities";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(180, 21);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 89;
    ((F_NestSheetPartList) obj0).\u0002.Text = "Delete Selected Entities";
    ((F_NestSheetPartList) obj0).\u0002.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0008);
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u000E);
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0004);
    ((F_NestSheetPartList) obj0).\u0007.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u000F);
    ((F_NestSheetPartList) obj0).\u0007.Location = new Point(5, 231);
    ((F_NestSheetPartList) obj0).\u0007.Name = "panel3";
    ((F_NestSheetPartList) obj0).\u0007.Size = new Size(317, 61);
    ((F_NestSheetPartList) obj0).\u0007.TabIndex = 90;
    ((F_NestSheetPartList) obj0).\u0008.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0008.Location = new Point(284, 10);
    ((F_NestSheetPartList) obj0).\u0008.Name = "lbl_unitquantitiy";
    ((F_NestSheetPartList) obj0).\u0008.Size = new Size(30, 17);
    ((F_NestSheetPartList) obj0).\u0008.TabIndex = 70;
    ((F_NestSheetPartList) obj0).\u0008.Text = "Qty";
    ((F_NestSheetPartList) obj0).\u000E.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u000E.Location = new Point(7, 36);
    ((F_NestSheetPartList) obj0).\u000E.Name = "lbl_Mirroraxis";
    ((F_NestSheetPartList) obj0).\u000E.Size = new Size(74, 17);
    ((F_NestSheetPartList) obj0).\u000E.TabIndex = 69;
    ((F_NestSheetPartList) obj0).\u000E.Text = "Mirror Axis";
    ((F_NestSheetPartList) obj0).\u0001.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0001.Location = new Point(222, 36);
    ((F_NestSheetPartList) obj0).\u0001.Name = "radio_mirrorY";
    ((F_NestSheetPartList) obj0).\u0001.Size = new Size(67, 21);
    ((F_NestSheetPartList) obj0).\u0001.TabIndex = 68;
    ((F_NestSheetPartList) obj0).\u0001.TabStop = true;
    ((F_NestSheetPartList) obj0).\u0001.Text = "Y Axis";
    ((F_NestSheetPartList) obj0).\u0001.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0002.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0002.Location = new Point(138, 36);
    ((F_NestSheetPartList) obj0).\u0002.Name = "radio_mirrorX";
    ((F_NestSheetPartList) obj0).\u0002.Size = new Size(67, 21);
    ((F_NestSheetPartList) obj0).\u0002.TabIndex = 67;
    ((F_NestSheetPartList) obj0).\u0002.TabStop = true;
    ((F_NestSheetPartList) obj0).\u0002.Text = "X Axis";
    ((F_NestSheetPartList) obj0).\u0002.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0004.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0004.Location = new Point(138, 5);
    ((F_NestSheetPartList) obj0).\u0004.Maximum = new Decimal(new int[4]
    {
      1215752192,
      23,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0004.Name = "spn_mirrorcount";
    ((F_NestSheetPartList) obj0).\u0004.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0004.TabIndex = 66;
    ((F_NestSheetPartList) obj0).\u000F.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u000F.Location = new Point(6, 10);
    ((F_NestSheetPartList) obj0).\u000F.Name = "lbl_mirrorcount";
    ((F_NestSheetPartList) obj0).\u000F.Size = new Size(86, 17);
    ((F_NestSheetPartList) obj0).\u000F.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u000F.Text = "Mirror Count";
    ((F_NestSheetPartList) obj0).\u0008.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0010);
    ((F_NestSheetPartList) obj0).\u0008.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0011);
    ((F_NestSheetPartList) obj0).\u0008.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0005);
    ((F_NestSheetPartList) obj0).\u0008.Location = new Point(5, 298);
    ((F_NestSheetPartList) obj0).\u0008.Name = "panel4";
    ((F_NestSheetPartList) obj0).\u0008.Size = new Size(317, 36);
    ((F_NestSheetPartList) obj0).\u0008.TabIndex = 91;
    ((F_NestSheetPartList) obj0).\u0010.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0010.Location = new Point(284, 8);
    ((F_NestSheetPartList) obj0).\u0010.Name = "lbl_unitmetric2";
    ((F_NestSheetPartList) obj0).\u0010.Size = new Size(30, 17);
    ((F_NestSheetPartList) obj0).\u0010.TabIndex = 63 /*0x3F*/;
    ((F_NestSheetPartList) obj0).\u0010.Text = "mm";
    ((F_NestSheetPartList) obj0).\u0011.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0011.Location = new Point(6, 9);
    ((F_NestSheetPartList) obj0).\u0011.Name = "lbl_partdistance";
    ((F_NestSheetPartList) obj0).\u0011.Size = new Size(93, 17);
    ((F_NestSheetPartList) obj0).\u0011.TabIndex = 57;
    ((F_NestSheetPartList) obj0).\u0011.Text = "Part Distance";
    ((F_NestSheetPartList) obj0).\u0005.DecimalPlaces = 2;
    ((F_NestSheetPartList) obj0).\u0005.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0005.Location = new Point(138, 4);
    ((F_NestSheetPartList) obj0).\u0005.Maximum = new Decimal(new int[4]
    {
      1410065408,
      2,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0005.Name = "spn_partdistance";
    ((F_NestSheetPartList) obj0).\u0005.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0005.TabIndex = 60;
    ((F_NestSheetPartList) obj0).\u0003.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0003.Location = new Point(12, 396);
    ((F_NestSheetPartList) obj0).\u0003.Name = "chk_Deleteselectedauxentities";
    ((F_NestSheetPartList) obj0).\u0003.Size = new Size(207, 21);
    ((F_NestSheetPartList) obj0).\u0003.TabIndex = 92;
    ((F_NestSheetPartList) obj0).\u0003.Text = "Delete Selected Aux Entities";
    ((F_NestSheetPartList) obj0).\u0003.UseVisualStyleBackColor = true;
    ((F_NestSheetPartList) obj0).\u0006.DecimalPlaces = 1;
    ((F_NestSheetPartList) obj0).\u0006.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Regular, GraphicsUnit.Point, (byte) 162);
    ((F_NestSheetPartList) obj0).\u0006.Location = new Point(138, 33);
    ((F_NestSheetPartList) obj0).\u0006.Maximum = new Decimal(new int[4]
    {
      360,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0006.Name = "spn_addtionalrotation";
    ((F_NestSheetPartList) obj0).\u0006.Size = new Size(140, 27);
    ((F_NestSheetPartList) obj0).\u0006.TabIndex = 91;
    ((F_NestSheetPartList) obj0).\u0006.Value = new Decimal(new int[4]
    {
      10,
      0,
      0,
      0
    });
    ((F_NestSheetPartList) obj0).\u0012.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0012.Location = new Point(7, 38);
    ((F_NestSheetPartList) obj0).\u0012.Name = "lbl_Addtionalrotation";
    ((F_NestSheetPartList) obj0).\u0012.Size = new Size(124, 17);
    ((F_NestSheetPartList) obj0).\u0012.TabIndex = 92;
    ((F_NestSheetPartList) obj0).\u0012.Text = "Addtional Rotation";
    ((F_NestSheetPartList) obj0).\u0013.AutoSize = true;
    ((F_NestSheetPartList) obj0).\u0013.Location = new Point(284, 38);
    ((F_NestSheetPartList) obj0).\u0013.Name = "lbl_Degree";
    ((F_NestSheetPartList) obj0).\u0013.Size = new Size(14, 17);
    ((F_NestSheetPartList) obj0).\u0013.TabIndex = 93;
    ((F_NestSheetPartList) obj0).\u0013.Text = "°";
    obj0.AutoScaleMode = AutoScaleMode.None;
    obj0.ClientSize = new Size(328, 687);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0003);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0008);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0007);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0006);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0001);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0002);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0003);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0004);
    obj0.Controls.Add((Control) ((F_NestSheetPartList) obj0).\u0005);
    obj0.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    obj0.MaximizeBox = false;
    obj0.MinimizeBox = false;
    obj0.Name = "F_NestPartAdd";
    obj0.Text = "Part Add";
    obj0.FormClosing += new FormClosingEventHandler(((F_SettingTreeView.DefaultClickEvent) obj0).\u0001);
    obj0.Load += new EventHandler(((F_SettingTreeView.ApplyClickEvent) obj0).\u0001);
    ((F_NestSheetPartList) obj0).\u0001.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0001.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0002.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0002.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0001.EndInit();
    ((F_NestSheetPartList) obj0).\u0003.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0003.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0002.EndInit();
    ((F_NestSheetPartList) obj0).\u0004.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0004.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0003.EndInit();
    ((F_NestSheetPartList) obj0).\u0005.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0005.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0007.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0007.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0004.EndInit();
    ((F_NestSheetPartList) obj0).\u0008.ResumeLayout(false);
    ((F_NestSheetPartList) obj0).\u0008.PerformLayout();
    ((F_NestSheetPartList) obj0).\u0005.EndInit();
    ((F_NestSheetPartList) obj0).\u0006.EndInit();
    obj0.ResumeLayout(false);
    obj0.PerformLayout();
  }
}
