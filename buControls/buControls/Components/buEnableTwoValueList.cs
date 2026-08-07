// Decompiled with JetBrains decompiler
// Type: buControls.Components.buEnableTwoValueList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns7;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace buControls.Components;

public class buEnableTwoValueList : UserControl
{
  public ValuesFormatType FormatType = ValuesFormatType.BoolDoubleDoubleDouble;
  public List<ValuesItem> ItemList = (List<ValuesItem>) null;
  public bool TextAsButton = true;
  public int SelectedItem = -1;
  public Color colorValueForeColor = Color.Black;
  public Color colorValueName = Color.LightGray;
  public Color colorValue1 = Color.WhiteSmoke;
  public Color colorValue2 = Color.WhiteSmoke;
  public Color colorValue3 = Color.WhiteSmoke;
  public Color colorValue4 = Color.WhiteSmoke;
  public Color colorValue5 = Color.WhiteSmoke;
  public Color colorValue6 = Color.WhiteSmoke;
  public Color colorValue7 = Color.WhiteSmoke;
  public Color colorValue8 = Color.WhiteSmoke;
  public Color colorBackEnable = Color.PaleGreen;
  public Color colorUnSelected = Color.Silver;
  public Color colorSelected = Color.LightSkyBlue;
  public Color colorHeader = Color.LightCyan;
  public Color colorHeaderForeColor = Color.Black;
  public Color colorHeaderName = Color.LightSteelBlue;
  public Color colorHeaderValue1 = Color.LightSteelBlue;
  public Color colorHeaderValue2 = Color.LightSteelBlue;
  public Color colorHeaderValue3 = Color.LightSteelBlue;
  public Color colorHeaderValue4 = Color.LightSteelBlue;
  public Color colorHeaderValue5 = Color.LightSteelBlue;
  public Color colorHeaderValue6 = Color.LightSteelBlue;
  public Color colorHeaderValue7 = Color.LightSteelBlue;
  public Color colorHeaderValue8 = Color.LightSteelBlue;
  public bool ShowHeader = true;
  public int ItemHeight = 30;
  public int DecimalPoint = 2;
  public int ValueArcDiameter = 8;
  public int Value1Width = 80 /*0x50*/;
  public int Value2Width = 80 /*0x50*/;
  public int Value3Width = 80 /*0x50*/;
  public int Value4Width = 80 /*0x50*/;
  public int Value5Width = 80 /*0x50*/;
  public int Value6Width = 80 /*0x50*/;
  public int Value7Width = 80 /*0x50*/;
  public int Value8Width = 80 /*0x50*/;
  public int ValueSpace = 4;
  public float ValueFontSize = 10f;
  public bool ValueBold = false;
  public string ValueFontName = "Microsoft Sans Serif";
  public int HeaderArcDiameter = 8;
  public int HeaderHeight = 40;
  public float HeaderFontSize = 10f;
  public bool HeaderBold = false;
  public string HeaderFontName = "Microsoft Sans Serif";
  public string textName = "Name";
  public string textValue1 = "Value 1";
  public string textValue2 = "Value 2";
  public string textValue3 = "Value 3";
  public string textValue4 = "Value 4";
  public string textValue5 = "Value 5";
  public string textValue6 = "Value 6";
  public string textValue7 = "Value 7";
  public string textValue8 = "Value 8";
  public string btnName = "";
  public string btnCommand1 = "";
  public string btnCommand2 = "";
  public string btnCommand3 = "";
  public string btnCommand4 = "";
  public string btnCommand5 = "";
  public string btnCommand6 = "";
  public string btnCommand7 = "";
  public string btnCommand8 = "";
  public buLabel LblName = (buLabel) null;
  public buButton BtnName = (buButton) null;
  public buSpin Spn1 = (buSpin) null;
  public buSpin Spn2 = (buSpin) null;
  public buSpin Spn3 = (buSpin) null;
  public buSpin Spn4 = (buSpin) null;
  public buCheckBox Chk1 = (buCheckBox) null;
  public buCheckBox Chk2 = (buCheckBox) null;
  public buCheckBox Chk3 = (buCheckBox) null;
  public buCheckBox Chk4 = (buCheckBox) null;
  public buPanel Pnl = (buPanel) null;
  public buLabel LblText = (buLabel) null;
  public buLabel Lbl1 = (buLabel) null;
  public buLabel Lbl2 = (buLabel) null;
  public buLabel Lbl3 = (buLabel) null;
  public buLabel Lbl4 = (buLabel) null;
  public buLabel Lbl5 = (buLabel) null;
  public buLabel Lbl6 = (buLabel) null;
  public buLabel Lbl7 = (buLabel) null;
  public buLabel Lbl8 = (buLabel) null;
  public buButton Btn1 = (buButton) null;
  public buButton Btn2 = (buButton) null;
  public bool Inited = false;
  private int int_0;
  private IContainer icontainer_0 = (IContainer) null;
  internal buLabel buLabel_0;
  internal buLabel buLabel_1;
  internal buPanel buPanel_0;

  public event buControlEvents.buListValueChangedEventHandler ItemValueChanged;

  public event buControlEvents.buListValueChangedEventHandler ItemValueChangedByEnter;

  public event buControlEvents.buListValueChangedEventHandler ItemClick;

  public event buControlEvents.buListEnableTwoValueChangedEventHandler ItemDoubleClick;

  public buEnableTwoValueList()
  {
    Class39.smethod_320(this);
    this.ItemList = new List<ValuesItem>();
  }

  public void Add(ValuesItem Item, bool Draw = true)
  {
    this.ItemList.Add(Item);
    if (!Draw)
      return;
    Class39.smethod_38(this);
  }

  public void RemoveAll()
  {
    this.ItemList.Clear();
    Class39.smethod_38(this);
  }

  public void Remove(int index, bool Draw = true)
  {
    if (!(index >= 0 & index <= this.ItemList.Count - 1))
      return;
    this.ItemList.RemoveAt(index);
    if (!Draw)
      return;
    Class39.smethod_38(this);
  }

  public void DrawControls() => Class39.smethod_38(this);

  internal void method_0()
  {
    this.int_0 = this.Width - (this.Value1Width + this.Value2Width + this.Value3Width + this.Value4Width) - this.ValueSpace * 4 - 2;
    this.LblText = Class39.smethod_103("lbl_Nametext", 1, 6, this.Pnl.Height - 12, this.textName, this.int_0, 0, this);
    this.Pnl.Controls.Add((Control) this.LblText);
    string textValue1 = this.textValue1;
    int int_0_1 = this.LblText.Left + this.LblText.Width + this.ValueSpace;
    int value1Width1 = this.Value1Width;
    int int_2_1 = this.Pnl.Height - 12;
    this.Lbl1 = Class39.smethod_103("lbl_value1text", int_0_1, 6, int_2_1, textValue1, value1Width1, 1, this);
    this.Pnl.Controls.Add((Control) this.Lbl1);
    string textValue2 = this.textValue2;
    int int_0_2 = this.Lbl1.Left + this.Lbl1.Width + this.ValueSpace;
    int value2Width1 = this.Value2Width;
    int int_2_2 = this.Pnl.Height - 12;
    this.Lbl2 = Class39.smethod_103("lbl_value2text", int_0_2, 6, int_2_2, textValue2, value2Width1, 2, this);
    this.Pnl.Controls.Add((Control) this.Lbl2);
    string textValue3 = this.textValue3;
    int int_0_3 = this.Lbl2.Left + this.Lbl2.Width + this.ValueSpace;
    int value3Width1 = this.Value3Width;
    int int_2_3 = this.Pnl.Height - 12;
    this.Lbl3 = Class39.smethod_103("lbl_value3text", int_0_3, 6, int_2_3, textValue3, value3Width1, 3, this);
    this.Pnl.Controls.Add((Control) this.Lbl3);
    string textValue4 = this.textValue4;
    int int_0_4 = this.Lbl3.Left + this.Lbl3.Width + this.ValueSpace;
    int value4Width1 = this.Value4Width;
    int int_2_4 = this.Pnl.Height - 12;
    this.Lbl4 = Class39.smethod_103("lbl_value4text", int_0_4, 6, int_2_4, textValue4, value4Width1, 4, this);
    this.Pnl.Controls.Add((Control) this.Lbl4);
    int num1 = 0;
    for (int index = 0; index <= this.ItemList.Count - 1; ++index)
    {
      int num2 = this.Pnl.Height + (this.ItemHeight + 4) * index;
      int left;
      int width;
      if (!this.TextAsButton)
      {
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        this.LblName = Class39.smethod_484(1, this.ItemHeight, "LblName" + index.ToString(), -1, int0, this, name, num2);
        left = this.LblName.Left;
        width = this.LblName.Width;
        this.Controls.Add((Control) this.LblName);
      }
      else
      {
        string btnName = this.btnName;
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        int itemHeight = this.ItemHeight;
        string string_1 = "BtnName" + index.ToString();
        this.BtnName = Class39.smethod_674(itemHeight, num2, int0, -1, btnName, string_1, this, name, 1, index);
        left = this.BtnName.Left;
        width = this.BtnName.Width;
        this.Controls.Add((Control) this.BtnName);
      }
      double double_0_1 = this.ItemList[index].Value1;
      int int_5_1 = left + width + this.ValueSpace;
      int value1Width2 = this.Value1Width;
      int itemHeight1 = this.ItemHeight;
      string string_0_1 = "Spn1" + index.ToString();
      this.Spn1 = Class39.smethod_605(value1Width2, itemHeight1, index, num2, 0, double_0_1, int_5_1, this, string_0_1);
      this.Spn1.Tag = (object) num1;
      int num3 = num1 + 1;
      this.Controls.Add((Control) this.Spn1);
      bool bool1 = this.ItemList[index].Bool1;
      int int_2_5 = this.Spn1.Left + this.Spn1.Width + this.ValueSpace;
      int value2Width2 = this.Value2Width;
      int itemHeight2 = this.ItemHeight;
      this.Chk1 = Class39.smethod_360("Chk1" + index.ToString(), this, num2, 1, int_2_5, bool1, index, itemHeight2, value2Width2);
      this.Controls.Add((Control) this.Chk1);
      double double_0_2 = this.ItemList[index].Value2;
      int int_5_2 = this.Chk1.Left + this.Chk1.Width + this.ValueSpace;
      int value3Width2 = this.Value3Width;
      int itemHeight3 = this.ItemHeight;
      string string_0_2 = "Spn2" + index.ToString();
      this.Spn2 = Class39.smethod_605(value3Width2, itemHeight3, index, num2, 2, double_0_2, int_5_2, this, string_0_2);
      this.Spn2.Tag = (object) num3;
      int num4 = num3 + 1;
      this.Controls.Add((Control) this.Spn2);
      double double_0_3 = this.ItemList[index].Value3;
      int int_5_3 = this.Spn2.Left + this.Spn2.Width + this.ValueSpace;
      int value4Width2 = this.Value4Width;
      int itemHeight4 = this.ItemHeight;
      string string_0_3 = "Spn3" + index.ToString();
      this.Spn3 = Class39.smethod_605(value4Width2, itemHeight4, index, num2, 3, double_0_3, int_5_3, this, string_0_3);
      this.Spn3.Tag = (object) num4;
      num1 = num4 + 1;
      this.Controls.Add((Control) this.Spn3);
    }
    this.Inited = true;
  }

  internal void method_1()
  {
    this.int_0 = this.Width - (this.Value1Width + this.Value2Width + this.Value3Width + this.Value4Width + this.Value5Width + this.Value6Width + this.Value7Width) - this.ValueSpace * 7 - 2;
    this.LblText = Class39.smethod_103("lbl_Nametext", 1, 6, this.Pnl.Height - 12, this.textName, this.int_0, 0, this);
    this.Pnl.Controls.Add((Control) this.LblText);
    string textValue1 = this.textValue1;
    int int_0_1 = this.LblText.Left + this.LblText.Width + this.ValueSpace;
    int value1Width1 = this.Value1Width;
    int int_2_1 = this.Pnl.Height - 12;
    this.Lbl1 = Class39.smethod_103("lbl_value1text", int_0_1, 6, int_2_1, textValue1, value1Width1, 1, this);
    this.Pnl.Controls.Add((Control) this.Lbl1);
    string textValue2 = this.textValue2;
    int int_0_2 = this.Lbl1.Left + this.Lbl1.Width + this.ValueSpace;
    int value2Width1 = this.Value2Width;
    int int_2_2 = this.Pnl.Height - 12;
    this.Lbl2 = Class39.smethod_103("lbl_value2text", int_0_2, 6, int_2_2, textValue2, value2Width1, 2, this);
    this.Pnl.Controls.Add((Control) this.Lbl2);
    string textValue3_1 = this.textValue3;
    int int_0_3 = this.Lbl2.Left + this.Lbl2.Width + this.ValueSpace;
    int value3Width1 = this.Value3Width;
    int int_2_3 = this.Pnl.Height - 12;
    this.Lbl3 = Class39.smethod_103("lbl_value3text", int_0_3, 6, int_2_3, textValue3_1, value3Width1, 3, this);
    this.Pnl.Controls.Add((Control) this.Lbl3);
    string textValue4 = this.textValue4;
    int int_0_4 = this.Lbl3.Left + this.Lbl3.Width + this.ValueSpace;
    int value4Width1 = this.Value4Width;
    int int_2_4 = this.Pnl.Height - 12;
    this.Lbl4 = Class39.smethod_103("lbl_value4text", int_0_4, 6, int_2_4, textValue4, value4Width1, 4, this);
    this.Pnl.Controls.Add((Control) this.Lbl4);
    string textValue5 = this.textValue5;
    int int_0_5 = this.Lbl4.Left + this.Lbl4.Width + this.ValueSpace;
    int value5Width1 = this.Value5Width;
    int int_2_5 = this.Pnl.Height - 12;
    this.Lbl5 = Class39.smethod_103("lbl_value5text", int_0_5, 6, int_2_5, textValue5, value5Width1, 5, this);
    this.Pnl.Controls.Add((Control) this.Lbl5);
    string textValue6 = this.textValue6;
    int int_0_6 = this.Lbl5.Left + this.Lbl5.Width + this.ValueSpace;
    int value6Width1 = this.Value6Width;
    int int_2_6 = this.Pnl.Height - 12;
    this.Lbl6 = Class39.smethod_103("lbl_value6text", int_0_6, 6, int_2_6, textValue6, value6Width1, 6, this);
    this.Pnl.Controls.Add((Control) this.Lbl6);
    string textValue7_1 = this.textValue7;
    int int_0_7 = this.Lbl6.Left + this.Lbl6.Width + this.ValueSpace;
    int value7Width1 = this.Value7Width;
    int int_2_7 = this.Pnl.Height - 12;
    this.Lbl7 = Class39.smethod_103("lbl_value7text", int_0_7, 6, int_2_7, textValue7_1, value7Width1, 7, this);
    this.Pnl.Controls.Add((Control) this.Lbl7);
    int num1 = 0;
    for (int index = 0; index <= this.ItemList.Count - 1; ++index)
    {
      int num2 = this.Pnl.Height + (this.ItemHeight + 4) * index;
      int left;
      int width;
      if (!this.TextAsButton)
      {
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        this.LblName = Class39.smethod_484(1, this.ItemHeight, "LblName" + index.ToString(), -1, int0, this, name, num2);
        left = this.LblName.Left;
        width = this.LblName.Width;
        this.Controls.Add((Control) this.LblName);
      }
      else
      {
        string btnName = this.btnName;
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        int itemHeight = this.ItemHeight;
        string string_1 = "BtnName" + index.ToString();
        this.BtnName = Class39.smethod_674(itemHeight, num2, int0, -1, btnName, string_1, this, name, 1, index);
        left = this.BtnName.Left;
        width = this.BtnName.Width;
        this.Controls.Add((Control) this.BtnName);
      }
      double double_0_1 = this.ItemList[index].Value1;
      int int_5_1 = left + width + this.ValueSpace;
      int value1Width2 = this.Value1Width;
      int itemHeight1 = this.ItemHeight;
      string string_0_1 = "Spn1" + index.ToString();
      this.Spn1 = Class39.smethod_605(value1Width2, itemHeight1, index, num2, 0, double_0_1, int_5_1, this, string_0_1);
      this.Spn1.Tag = (object) num1;
      int num3 = num1 + 1;
      this.Controls.Add((Control) this.Spn1);
      bool bool1 = this.ItemList[index].Bool1;
      int int_2_8 = this.Spn1.Left + this.Spn1.Width + this.ValueSpace;
      int value2Width2 = this.Value2Width;
      int itemHeight2 = this.ItemHeight;
      this.Chk1 = Class39.smethod_360("Chk1" + index.ToString(), this, num2, 1, int_2_8, bool1, index, itemHeight2, value2Width2);
      this.Controls.Add((Control) this.Chk1);
      string btnCommand1 = this.btnCommand1;
      string textValue3_2 = this.textValue3;
      int int_4_1 = this.Chk1.Left + this.Chk1.Width + this.ValueSpace;
      int value3Width2 = this.Value3Width;
      int itemHeight3 = this.ItemHeight;
      string string_1_1 = "Btn1" + index.ToString();
      this.Btn1 = Class39.smethod_674(itemHeight3, num2, value3Width2, 2, btnCommand1, string_1_1, this, textValue3_2, int_4_1, index);
      this.Controls.Add((Control) this.Btn1);
      bool bool2 = this.ItemList[index].Bool2;
      int int_2_9 = this.Btn1.Left + this.Btn1.Width + this.ValueSpace;
      int value4Width2 = this.Value4Width;
      int itemHeight4 = this.ItemHeight;
      this.Chk2 = Class39.smethod_360("Chk2" + index.ToString(), this, num2, 3, int_2_9, bool2, index, itemHeight4, value4Width2);
      this.Controls.Add((Control) this.Chk2);
      double double_0_2 = this.ItemList[index].Value2;
      int int_5_2 = this.Chk2.Left + this.Chk2.Width + this.ValueSpace;
      int value5Width2 = this.Value5Width;
      int itemHeight5 = this.ItemHeight;
      string string_0_2 = "Spn2" + index.ToString();
      this.Spn2 = Class39.smethod_605(value5Width2, itemHeight5, index, num2, 4, double_0_2, int_5_2, this, string_0_2);
      this.Spn2.Tag = (object) num3;
      int num4 = num3 + 1;
      this.Controls.Add((Control) this.Spn2);
      double double_0_3 = this.ItemList[index].Value3;
      int int_5_3 = this.Spn2.Left + this.Spn2.Width + this.ValueSpace;
      int value6Width2 = this.Value6Width;
      int itemHeight6 = this.ItemHeight;
      string string_0_3 = "Spn3" + index.ToString();
      this.Spn3 = Class39.smethod_605(value6Width2, itemHeight6, index, num2, 5, double_0_3, int_5_3, this, string_0_3);
      this.Spn3.Tag = (object) num4;
      num1 = num4 + 1;
      this.Controls.Add((Control) this.Spn3);
      string btnCommand2 = this.btnCommand2;
      string textValue7_2 = this.textValue7;
      int int_4_2 = this.Spn3.Left + this.Spn3.Width + this.ValueSpace;
      int value7Width2 = this.Value7Width;
      int itemHeight7 = this.ItemHeight;
      string string_1_2 = "Btn2" + index.ToString();
      this.Btn2 = Class39.smethod_674(itemHeight7, num2, value7Width2, 6, btnCommand2, string_1_2, this, textValue7_2, int_4_2, index);
      this.Controls.Add((Control) this.Btn2);
    }
    this.Inited = true;
  }

  internal void method_2()
  {
    this.int_0 = this.Width - (this.Value1Width + this.Value2Width + this.Value3Width + this.Value4Width + this.Value5Width + this.Value6Width + this.Value7Width + this.Value8Width) - this.ValueSpace * 8 - 2;
    this.LblText = Class39.smethod_103("lbl_Nametext", 1, 6, this.Pnl.Height - 12, this.textName, this.int_0, 0, this);
    this.Pnl.Controls.Add((Control) this.LblText);
    string textValue1 = this.textValue1;
    int int_0_1 = this.LblText.Left + this.LblText.Width + this.ValueSpace;
    int value1Width1 = this.Value1Width;
    int int_2_1 = this.Pnl.Height - 12;
    this.Lbl1 = Class39.smethod_103("lbl_value1text", int_0_1, 6, int_2_1, textValue1, value1Width1, 1, this);
    this.Pnl.Controls.Add((Control) this.Lbl1);
    string textValue2 = this.textValue2;
    int int_0_2 = this.Lbl1.Left + this.Lbl1.Width + this.ValueSpace;
    int value2Width1 = this.Value2Width;
    int int_2_2 = this.Pnl.Height - 12;
    this.Lbl2 = Class39.smethod_103("lbl_value2text", int_0_2, 6, int_2_2, textValue2, value2Width1, 2, this);
    this.Pnl.Controls.Add((Control) this.Lbl2);
    string textValue3 = this.textValue3;
    int int_0_3 = this.Lbl2.Left + this.Lbl2.Width + this.ValueSpace;
    int value3Width1 = this.Value3Width;
    int int_2_3 = this.Pnl.Height - 12;
    this.Lbl3 = Class39.smethod_103("lbl_value3text", int_0_3, 6, int_2_3, textValue3, value3Width1, 3, this);
    this.Pnl.Controls.Add((Control) this.Lbl3);
    string textValue4_1 = this.textValue4;
    int int_0_4 = this.Lbl3.Left + this.Lbl3.Width + this.ValueSpace;
    int value4Width1 = this.Value4Width;
    int int_2_4 = this.Pnl.Height - 12;
    this.Lbl4 = Class39.smethod_103("lbl_value4text", int_0_4, 6, int_2_4, textValue4_1, value4Width1, 4, this);
    this.Pnl.Controls.Add((Control) this.Lbl4);
    string textValue5 = this.textValue5;
    int int_0_5 = this.Lbl4.Left + this.Lbl4.Width + this.ValueSpace;
    int value5Width1 = this.Value5Width;
    int int_2_5 = this.Pnl.Height - 12;
    this.Lbl5 = Class39.smethod_103("lbl_value5text", int_0_5, 6, int_2_5, textValue5, value5Width1, 5, this);
    this.Pnl.Controls.Add((Control) this.Lbl5);
    string textValue6 = this.textValue6;
    int int_0_6 = this.Lbl5.Left + this.Lbl5.Width + this.ValueSpace;
    int value6Width1 = this.Value6Width;
    int int_2_6 = this.Pnl.Height - 12;
    this.Lbl6 = Class39.smethod_103("lbl_value6text", int_0_6, 6, int_2_6, textValue6, value6Width1, 6, this);
    this.Pnl.Controls.Add((Control) this.Lbl6);
    string textValue7 = this.textValue7;
    int int_0_7 = this.Lbl6.Left + this.Lbl6.Width + this.ValueSpace;
    int value7Width1 = this.Value7Width;
    int int_2_7 = this.Pnl.Height - 12;
    this.Lbl7 = Class39.smethod_103("lbl_value7text", int_0_7, 6, int_2_7, textValue7, value7Width1, 7, this);
    this.Pnl.Controls.Add((Control) this.Lbl7);
    string textValue8_1 = this.textValue8;
    int int_0_8 = this.Lbl7.Left + this.Lbl7.Width + this.ValueSpace;
    int value8Width1 = this.Value8Width;
    int int_2_8 = this.Pnl.Height - 12;
    this.Lbl8 = Class39.smethod_103("lbl_value8text", int_0_8, 6, int_2_8, textValue8_1, value8Width1, 8, this);
    this.Pnl.Controls.Add((Control) this.Lbl8);
    int num1 = 0;
    for (int index = 0; index <= this.ItemList.Count - 1; ++index)
    {
      int num2 = this.Pnl.Height + (this.ItemHeight + 4) * index;
      int left;
      int width;
      if (!this.TextAsButton)
      {
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        this.LblName = Class39.smethod_484(1, this.ItemHeight, "LblName" + index.ToString(), -1, int0, this, name, num2);
        left = this.LblName.Left;
        width = this.LblName.Width;
        this.Controls.Add((Control) this.LblName);
      }
      else
      {
        string btnName = this.btnName;
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        int itemHeight = this.ItemHeight;
        string string_1 = "BtnName" + index.ToString();
        this.BtnName = Class39.smethod_674(itemHeight, num2, int0, -1, btnName, string_1, this, name, 1, index);
        left = this.BtnName.Left;
        width = this.BtnName.Width;
        this.Controls.Add((Control) this.BtnName);
      }
      double double_0_1 = this.ItemList[index].Value1;
      int int_5_1 = left + width + this.ValueSpace;
      int value1Width2 = this.Value1Width;
      int itemHeight1 = this.ItemHeight;
      string string_0_1 = "Spn1" + index.ToString();
      this.Spn1 = Class39.smethod_605(value1Width2, itemHeight1, index, num2, 0, double_0_1, int_5_1, this, string_0_1);
      this.Spn1.Tag = (object) num1;
      int num3 = num1 + 1;
      this.Controls.Add((Control) this.Spn1);
      bool bool1 = this.ItemList[index].Bool1;
      int int_2_9 = this.Spn1.Left + this.Spn1.Width + this.ValueSpace;
      int value2Width2 = this.Value2Width;
      int itemHeight2 = this.ItemHeight;
      this.Chk1 = Class39.smethod_360("Chk1" + index.ToString(), this, num2, 1, int_2_9, bool1, index, itemHeight2, value2Width2);
      this.Controls.Add((Control) this.Chk1);
      bool bool2 = this.ItemList[index].Bool2;
      int int_2_10 = this.Chk1.Left + this.Chk1.Width + this.ValueSpace;
      int value3Width2 = this.Value3Width;
      int itemHeight3 = this.ItemHeight;
      this.Chk2 = Class39.smethod_360("Chk2" + index.ToString(), this, num2, 2, int_2_10, bool2, index, itemHeight3, value3Width2);
      this.Controls.Add((Control) this.Chk2);
      string btnCommand1 = this.btnCommand1;
      string textValue4_2 = this.textValue4;
      int int_4_1 = this.Chk2.Left + this.Chk2.Width + this.ValueSpace;
      int value4Width2 = this.Value4Width;
      int itemHeight4 = this.ItemHeight;
      string string_1_1 = "Btn1" + index.ToString();
      this.Btn1 = Class39.smethod_674(itemHeight4, num2, value4Width2, 3, btnCommand1, string_1_1, this, textValue4_2, int_4_1, index);
      this.Controls.Add((Control) this.Btn1);
      bool bool3 = this.ItemList[index].Bool3;
      int int_2_11 = this.Btn1.Left + this.Btn1.Width + this.ValueSpace;
      int value5Width2 = this.Value5Width;
      int itemHeight5 = this.ItemHeight;
      this.Chk3 = Class39.smethod_360("Chk3" + index.ToString(), this, num2, 4, int_2_11, bool3, index, itemHeight5, value5Width2);
      this.Controls.Add((Control) this.Chk3);
      double double_0_2 = this.ItemList[index].Value3;
      int int_5_2 = this.Chk3.Left + this.Chk3.Width + this.ValueSpace;
      int value6Width2 = this.Value6Width;
      int itemHeight6 = this.ItemHeight;
      string string_0_2 = "Spn2" + index.ToString();
      this.Spn2 = Class39.smethod_605(value6Width2, itemHeight6, index, num2, 5, double_0_2, int_5_2, this, string_0_2);
      this.Spn2.Tag = (object) num3;
      int num4 = num3 + 1;
      this.Controls.Add((Control) this.Spn2);
      double double_0_3 = this.ItemList[index].Value3;
      int int_5_3 = this.Spn2.Left + this.Spn2.Width + this.ValueSpace;
      int value7Width2 = this.Value7Width;
      int itemHeight7 = this.ItemHeight;
      string string_0_3 = "Spn3" + index.ToString();
      this.Spn3 = Class39.smethod_605(value7Width2, itemHeight7, index, num2, 6, double_0_3, int_5_3, this, string_0_3);
      this.Spn3.Tag = (object) num4;
      num1 = num4 + 1;
      this.Controls.Add((Control) this.Spn3);
      string btnCommand2 = this.btnCommand2;
      string textValue8_2 = this.textValue8;
      int int_4_2 = this.Spn3.Left + this.Spn3.Width + this.ValueSpace;
      int value8Width2 = this.Value8Width;
      int itemHeight8 = this.ItemHeight;
      string string_1_2 = "Btn2" + index.ToString();
      this.Btn2 = Class39.smethod_674(itemHeight8, num2, value8Width2, 7, btnCommand2, string_1_2, this, textValue8_2, int_4_2, index);
      this.Controls.Add((Control) this.Btn2);
    }
    this.Inited = true;
  }

  internal void method_3()
  {
    this.int_0 = this.Width - (this.Value1Width + this.Value2Width + this.Value3Width) - this.ValueSpace * 3 - 2;
    this.LblText = Class39.smethod_103("lbl_Nametext", 1, 6, this.Pnl.Height - 12, this.textName, this.int_0, 0, this);
    this.Pnl.Controls.Add((Control) this.LblText);
    string textValue1 = this.textValue1;
    int int_0_1 = this.LblText.Left + this.LblText.Width + this.ValueSpace;
    int value1Width1 = this.Value1Width;
    int int_2_1 = this.Pnl.Height - 12;
    this.Lbl1 = Class39.smethod_103("lbl_value1text", int_0_1, 6, int_2_1, textValue1, value1Width1, 1, this);
    this.Pnl.Controls.Add((Control) this.Lbl1);
    string textValue2 = this.textValue2;
    int int_0_2 = this.Lbl1.Left + this.Lbl1.Width + this.ValueSpace;
    int value2Width1 = this.Value2Width;
    int int_2_2 = this.Pnl.Height - 12;
    this.Lbl2 = Class39.smethod_103("lbl_value2text", int_0_2, 6, int_2_2, textValue2, value2Width1, 2, this);
    this.Pnl.Controls.Add((Control) this.Lbl2);
    string textValue3 = this.textValue3;
    int int_0_3 = this.Lbl2.Left + this.Lbl2.Width + this.ValueSpace;
    int value3Width1 = this.Value3Width;
    int int_2_3 = this.Pnl.Height - 12;
    this.Lbl3 = Class39.smethod_103("lbl_value3text", int_0_3, 6, int_2_3, textValue3, value3Width1, 3, this);
    this.Pnl.Controls.Add((Control) this.Lbl3);
    int num1 = 0;
    for (int index = 0; index <= this.ItemList.Count - 1; ++index)
    {
      int num2 = this.Pnl.Height + (this.ItemHeight + 4) * index;
      int left;
      int width;
      if (!this.TextAsButton)
      {
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        this.LblName = Class39.smethod_484(1, this.ItemHeight, "LblName" + index.ToString(), -1, int0, this, name, num2);
        left = this.LblName.Left;
        width = this.LblName.Width;
        this.Controls.Add((Control) this.LblName);
      }
      else
      {
        string btnName = this.btnName;
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        int itemHeight = this.ItemHeight;
        string string_1 = "BtnName" + index.ToString();
        this.BtnName = Class39.smethod_674(itemHeight, num2, int0, -1, btnName, string_1, this, name, 1, index);
        left = this.BtnName.Left;
        width = this.BtnName.Width;
        this.Controls.Add((Control) this.BtnName);
      }
      bool bool1 = this.ItemList[index].Bool1;
      int int_2_4 = left + width + this.ValueSpace;
      int value1Width2 = this.Value1Width;
      int itemHeight1 = this.ItemHeight;
      this.Chk1 = Class39.smethod_360("Chk1" + index.ToString(), this, num2, 0, int_2_4, bool1, index, itemHeight1, value1Width2);
      this.Controls.Add((Control) this.Chk1);
      double double_0_1 = this.ItemList[index].Value1;
      int int_5_1 = this.Chk1.Left + this.Chk1.Width + this.ValueSpace;
      int value2Width2 = this.Value2Width;
      int itemHeight2 = this.ItemHeight;
      string string_0_1 = "Spn1" + index.ToString();
      this.Spn1 = Class39.smethod_605(value2Width2, itemHeight2, index, num2, 1, double_0_1, int_5_1, this, string_0_1);
      this.Spn1.Tag = (object) num1;
      int num3 = num1 + 1;
      this.Controls.Add((Control) this.Spn1);
      double double_0_2 = this.ItemList[index].Value2;
      int int_5_2 = this.Spn1.Left + this.Spn1.Width + this.ValueSpace;
      int value3Width2 = this.Value3Width;
      int itemHeight3 = this.ItemHeight;
      string string_0_2 = "Spn2" + index.ToString();
      this.Spn2 = Class39.smethod_605(value3Width2, itemHeight3, index, num2, 2, double_0_2, int_5_2, this, string_0_2);
      this.Spn2.Tag = (object) num3;
      num1 = num3 + 1;
      this.Controls.Add((Control) this.Spn2);
    }
    this.Inited = true;
  }

  internal void method_4()
  {
    this.int_0 = this.Width - this.Value1Width - this.ValueSpace - 2;
    this.LblText = Class39.smethod_103("lbl_Nametext", 1, 6, this.Pnl.Height - 12, this.textName, this.int_0, 0, this);
    this.Pnl.Controls.Add((Control) this.LblText);
    string textValue1 = this.textValue1;
    int int_0 = this.LblText.Left + this.LblText.Width + this.ValueSpace;
    int value1Width1 = this.Value1Width;
    int int_2 = this.Pnl.Height - 12;
    this.Lbl1 = Class39.smethod_103("lbl_value1text", int_0, 6, int_2, textValue1, value1Width1, 1, this);
    this.Pnl.Controls.Add((Control) this.Lbl1);
    for (int index = 0; index <= this.ItemList.Count - 1; ++index)
    {
      int num = this.Pnl.Height + (this.ItemHeight + 4) * index;
      int left;
      int width;
      if (!this.TextAsButton)
      {
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        this.LblName = Class39.smethod_484(1, this.ItemHeight, "LblName" + index.ToString(), -1, int0, this, name, num);
        left = this.LblName.Left;
        width = this.LblName.Width;
        this.Controls.Add((Control) this.LblName);
      }
      else
      {
        string btnName = this.btnName;
        string name = this.ItemList[index].Name;
        int int0 = this.int_0;
        int itemHeight = this.ItemHeight;
        string string_1 = "BtnName" + index.ToString();
        this.BtnName = Class39.smethod_674(itemHeight, num, int0, -1, btnName, string_1, this, name, 1, index);
        left = this.BtnName.Left;
        width = this.BtnName.Width;
        this.Controls.Add((Control) this.BtnName);
      }
      double double_0 = this.ItemList[index].Value1;
      int int_5 = left + width + this.ValueSpace;
      int value1Width2 = this.Value1Width;
      int itemHeight1 = this.ItemHeight;
      string string_0 = "Spn1" + index.ToString();
      this.Spn1 = Class39.smethod_605(value1Width2, itemHeight1, index, num, 0, double_0, int_5, this, string_0);
      this.Spn1.Tag = (object) index;
      this.Controls.Add((Control) this.Spn1);
    }
    this.Inited = true;
  }

  internal void method_5(object object_0, double double_0)
  {
    if (!this.Inited)
      return;
    buSpin buSpin = object_0 as buSpin;
    if (!(buSpin.Aux.Index >= 0 & buSpin.Aux.Index <= this.ItemList.Count - 1))
      return;
    if (this.FormatType == ValuesFormatType.Double && buSpin.Aux.ValInt == 0)
      this.ItemList[buSpin.Aux.Index].Value1 = buSpin.Value;
    if (this.FormatType == ValuesFormatType.DoubleBoolDoubleDouble)
    {
      if (buSpin.Aux.ValInt == 0)
        this.ItemList[buSpin.Aux.Index].Value1 = buSpin.Value;
      if (buSpin.Aux.ValInt == 2)
        this.ItemList[buSpin.Aux.Index].Value2 = buSpin.Value;
      if (buSpin.Aux.ValInt == 3)
        this.ItemList[buSpin.Aux.Index].Value3 = buSpin.Value;
    }
    if (this.FormatType == ValuesFormatType.DoubleBoolButtonBoolDoubleDoubleButton)
    {
      if (buSpin.Aux.ValInt == 0)
        this.ItemList[buSpin.Aux.Index].Value1 = buSpin.Value;
      if (buSpin.Aux.ValInt == 4)
        this.ItemList[buSpin.Aux.Index].Value2 = buSpin.Value;
      if (buSpin.Aux.ValInt == 5)
        this.ItemList[buSpin.Aux.Index].Value3 = buSpin.Value;
    }
    if (this.FormatType == ValuesFormatType.DoubleBoolBoolButtonBoolDoubleDoubleButton)
    {
      if (buSpin.Aux.ValInt == 0)
        this.ItemList[buSpin.Aux.Index].Value1 = buSpin.Value;
      if (buSpin.Aux.ValInt == 5)
        this.ItemList[buSpin.Aux.Index].Value2 = buSpin.Value;
      if (buSpin.Aux.ValInt == 6)
        this.ItemList[buSpin.Aux.Index].Value3 = buSpin.Value;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buListValueChangedEventHandler_0 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buListValueChangedEventHandler_0((object) this, new buListValueChangedEventArg(this.ItemList, this.ItemList[buSpin.Aux.Index], buSpin.Aux.Index, ""));
  }

  internal void method_6(object sender, KeyEventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    if (!(e.KeyCode == Keys.Return | e.KeyCode == Keys.Tab))
      return;
    int result = 0;
    int.TryParse(buSpin.Tag.ToString(), out result);
    buControlCommands.FindNextControlByKey(this.Controls, result, e.Shift);
    // ISSUE: reference to a compiler-generated field
    if (!(e.KeyCode == Keys.Return & this.buListValueChangedEventHandler_1 != null))
      return;
    // ISSUE: reference to a compiler-generated field
    this.buListValueChangedEventHandler_1((object) this, new buListValueChangedEventArg(this.ItemList, this.ItemList[buSpin.Aux.Index], buSpin.Aux.Index, ""));
  }

  internal void method_7(object sender, EventArgs e)
  {
    buSpin buSpin = sender as buSpin;
    if (!AppBool.TouchPad)
      return;
    F_KeyPadNumV1 fKeyPadNumV1 = new F_KeyPadNumV1();
    fKeyPadNumV1.StartPosition = FormStartPosition.CenterParent;
    fKeyPadNumV1.Caption = buSpin.Caption.Caption;
    fKeyPadNumV1.ShowDialog(buSpin.Value.ToString());
    if (!buNumeric.IsNumeric(fKeyPadNumV1.Value))
      return;
    buSpin.Value = double.Parse(fKeyPadNumV1.Value);
  }

  internal void method_8(object object_0, bool bool_0)
  {
    if (!this.Inited)
      return;
    buCheckBox buCheckBox = object_0 as buCheckBox;
    if (!(buCheckBox.Aux.Index >= 0 & buCheckBox.Aux.Index <= this.ItemList.Count - 1))
      return;
    if (this.FormatType == ValuesFormatType.DoubleBoolDoubleDouble && buCheckBox.Aux.ValInt == 1)
      this.ItemList[buCheckBox.Aux.Index].Bool1 = buCheckBox.Check;
    if (this.FormatType == ValuesFormatType.DoubleBoolButtonBoolDoubleDoubleButton)
    {
      if (buCheckBox.Aux.ValInt == 1)
        this.ItemList[buCheckBox.Aux.Index].Bool1 = buCheckBox.Check;
      if (buCheckBox.Aux.ValInt == 3)
        this.ItemList[buCheckBox.Aux.Index].Bool2 = buCheckBox.Check;
    }
    if (this.FormatType == ValuesFormatType.DoubleBoolBoolButtonBoolDoubleDoubleButton)
    {
      if (buCheckBox.Aux.ValInt == 1)
        this.ItemList[buCheckBox.Aux.Index].Bool1 = buCheckBox.Check;
      if (buCheckBox.Aux.ValInt == 2)
        this.ItemList[buCheckBox.Aux.Index].Bool2 = buCheckBox.Check;
      if (buCheckBox.Aux.ValInt == 4)
        this.ItemList[buCheckBox.Aux.Index].Bool3 = buCheckBox.Check;
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buListValueChangedEventHandler_0 != null)
    {
      // ISSUE: reference to a compiler-generated field
      this.buListValueChangedEventHandler_0((object) this, new buListValueChangedEventArg(this.ItemList, this.ItemList[buCheckBox.Aux.Index], buCheckBox.Aux.Index, ""));
    }
    // ISSUE: reference to a compiler-generated field
    if (this.buListValueChangedEventHandler_1 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buListValueChangedEventHandler_1((object) this, new buListValueChangedEventArg(this.ItemList, this.ItemList[buCheckBox.Aux.Index], buCheckBox.Aux.Index, ""));
  }

  internal void method_9(object sender, EventArgs e)
  {
    if (!this.Inited)
      return;
    buButton buButton = sender as buButton;
    // ISSUE: reference to a compiler-generated field
    if (this.buListValueChangedEventHandler_2 == null)
      return;
    // ISSUE: reference to a compiler-generated field
    this.buListValueChangedEventHandler_2((object) this, new buListValueChangedEventArg(this.ItemList, this.ItemList[buButton.Aux.Index], buButton.Aux.Index, buButton.Aux.AuxInfo));
  }

  internal void method_10(object sender, EventArgs e)
  {
  }

  protected override void Dispose(bool disposing)
  {
    if ((!disposing ? 0 : (this.icontainer_0 != null ? 1 : 0)) != 0)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }
}
