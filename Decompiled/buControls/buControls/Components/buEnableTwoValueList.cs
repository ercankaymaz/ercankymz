using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Controls;
using buControls.Forms.buControlForms.KeyPad;
using buCore;
using ns27;

namespace buControls.Components;

public class buEnableTwoValueList : UserControl
{
	public ValuesFormatType FormatType = ValuesFormatType.BoolDoubleDoubleDouble;

	public List<ValuesItem> ItemList = null;

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

	public int Value1Width = 80;

	public int Value2Width = 80;

	public int Value3Width = 80;

	public int Value4Width = 80;

	public int Value5Width = 80;

	public int Value6Width = 80;

	public int Value7Width = 80;

	public int Value8Width = 80;

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

	public buLabel LblName = null;

	public buButton BtnName = null;

	public buSpin Spn1 = null;

	public buSpin Spn2 = null;

	public buSpin Spn3 = null;

	public buSpin Spn4 = null;

	public buCheckBox Chk1 = null;

	public buCheckBox Chk2 = null;

	public buCheckBox Chk3 = null;

	public buCheckBox Chk4 = null;

	public buPanel Pnl = null;

	public buLabel LblText = null;

	public buLabel Lbl1 = null;

	public buLabel Lbl2 = null;

	public buLabel Lbl3 = null;

	public buLabel Lbl4 = null;

	public buLabel Lbl5 = null;

	public buLabel Lbl6 = null;

	public buLabel Lbl7 = null;

	public buLabel Lbl8 = null;

	public buButton Btn1 = null;

	public buButton Btn2 = null;

	public bool Inited = false;

	private int int_0;

	[CompilerGenerated]
	private buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler_1;

	[CompilerGenerated]
	private buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler_2;

	[CompilerGenerated]
	private buControlEvents.buListEnableTwoValueChangedEventHandler buListEnableTwoValueChangedEventHandler_0;

	private IContainer icontainer_0 = null;

	internal buLabel buLabel_0;

	internal buLabel buLabel_1;

	internal buPanel buPanel_0;

	public event buControlEvents.buListValueChangedEventHandler ItemValueChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_0;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Combine(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_0, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_0;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Remove(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_0, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
	}

	public event buControlEvents.buListValueChangedEventHandler ItemValueChangedByEnter
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_1;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Combine(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_1, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_1;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Remove(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_1, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
	}

	public event buControlEvents.buListValueChangedEventHandler ItemClick
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_2;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Combine(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_2, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler = buListValueChangedEventHandler_2;
			buControlEvents.buListValueChangedEventHandler buListValueChangedEventHandler2;
			do
			{
				buListValueChangedEventHandler2 = buListValueChangedEventHandler;
				buControlEvents.buListValueChangedEventHandler value2 = (buControlEvents.buListValueChangedEventHandler)Delegate.Remove(buListValueChangedEventHandler2, value);
				buListValueChangedEventHandler = Interlocked.CompareExchange(ref buListValueChangedEventHandler_2, value2, buListValueChangedEventHandler2);
			}
			while ((object)buListValueChangedEventHandler != buListValueChangedEventHandler2);
		}
	}

	public event buControlEvents.buListEnableTwoValueChangedEventHandler ItemDoubleClick
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buListEnableTwoValueChangedEventHandler buListEnableTwoValueChangedEventHandler = buListEnableTwoValueChangedEventHandler_0;
			buControlEvents.buListEnableTwoValueChangedEventHandler buListEnableTwoValueChangedEventHandler2;
			do
			{
				buListEnableTwoValueChangedEventHandler2 = buListEnableTwoValueChangedEventHandler;
				buControlEvents.buListEnableTwoValueChangedEventHandler value2 = (buControlEvents.buListEnableTwoValueChangedEventHandler)Delegate.Combine(buListEnableTwoValueChangedEventHandler2, value);
				buListEnableTwoValueChangedEventHandler = Interlocked.CompareExchange(ref buListEnableTwoValueChangedEventHandler_0, value2, buListEnableTwoValueChangedEventHandler2);
			}
			while ((object)buListEnableTwoValueChangedEventHandler != buListEnableTwoValueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buListEnableTwoValueChangedEventHandler buListEnableTwoValueChangedEventHandler = buListEnableTwoValueChangedEventHandler_0;
			buControlEvents.buListEnableTwoValueChangedEventHandler buListEnableTwoValueChangedEventHandler2;
			do
			{
				buListEnableTwoValueChangedEventHandler2 = buListEnableTwoValueChangedEventHandler;
				buControlEvents.buListEnableTwoValueChangedEventHandler value2 = (buControlEvents.buListEnableTwoValueChangedEventHandler)Delegate.Remove(buListEnableTwoValueChangedEventHandler2, value);
				buListEnableTwoValueChangedEventHandler = Interlocked.CompareExchange(ref buListEnableTwoValueChangedEventHandler_0, value2, buListEnableTwoValueChangedEventHandler2);
			}
			while ((object)buListEnableTwoValueChangedEventHandler != buListEnableTwoValueChangedEventHandler2);
		}
	}

	public buEnableTwoValueList()
	{
		Class76.smethod_320(this);
		ItemList = new List<ValuesItem>();
	}

	public void Add(ValuesItem Item, bool Draw = true)
	{
		ItemList.Add(Item);
		if (Draw)
		{
			Class76.smethod_38(this);
		}
	}

	public void RemoveAll()
	{
		ItemList.Clear();
		Class76.smethod_38(this);
	}

	public void Remove(int index, bool Draw = true)
	{
		if ((index >= 0) & (index <= ItemList.Count - 1))
		{
			ItemList.RemoveAt(index);
			if (Draw)
			{
				Class76.smethod_38(this);
			}
		}
	}

	public void DrawControls()
	{
		Class76.smethod_38(this);
	}

	internal void method_0()
	{
		int_0 = base.Width - (Value1Width + Value2Width + Value3Width + Value4Width) - ValueSpace * 4 - 2;
		string string_ = textName;
		int int_ = int_0;
		int int_2 = Pnl.Height - 12;
		string string_2 = "lbl_Nametext";
		LblText = Class76.smethod_103(string_2, 1, 6, int_2, string_, int_, 0, this);
		Pnl.Controls.Add(LblText);
		string_ = textValue1;
		int num = LblText.Left + LblText.Width + ValueSpace;
		int_ = Value1Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value1text";
		Lbl1 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 1, this);
		Pnl.Controls.Add(Lbl1);
		string_ = textValue2;
		num = Lbl1.Left + Lbl1.Width + ValueSpace;
		int_ = Value2Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value2text";
		Lbl2 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 2, this);
		Pnl.Controls.Add(Lbl2);
		string_ = textValue3;
		num = Lbl2.Left + Lbl2.Width + ValueSpace;
		int_ = Value3Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value3text";
		Lbl3 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 3, this);
		Pnl.Controls.Add(Lbl3);
		string_ = textValue4;
		num = Lbl3.Left + Lbl3.Width + ValueSpace;
		int_ = Value4Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value4text";
		Lbl4 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 4, this);
		Pnl.Controls.Add(Lbl4);
		int num2 = 0;
		for (int i = 0; i <= ItemList.Count - 1; i++)
		{
			int num3 = Pnl.Height + (ItemHeight + 4) * i;
			int num4 = 0;
			int num5 = 0;
			if (TextAsButton)
			{
				string string_3 = btnName;
				string name = ItemList[i].Name;
				int int_3 = int_0;
				int itemHeight = ItemHeight;
				string string_4 = "BtnName" + i;
				BtnName = Class76.smethod_674(itemHeight, num3, int_3, -1, string_3, string_4, this, name, 1, i);
				num4 = BtnName.Left;
				num5 = BtnName.Width;
				base.Controls.Add(BtnName);
			}
			else
			{
				string name2 = ItemList[i].Name;
				int int_4 = int_0;
				int itemHeight2 = ItemHeight;
				string string_5 = "LblName" + i;
				LblName = Class76.smethod_484(1, itemHeight2, string_5, -1, int_4, this, name2, num3);
				num4 = LblName.Left;
				num5 = LblName.Width;
				base.Controls.Add(LblName);
			}
			Spn1 = Class76.smethod_605(double_0: ItemList[i].Value1, int_5: num4 + num5 + ValueSpace, int_0: Value1Width, int_1: ItemHeight, string_0: "Spn1" + i, int_2: i, int_3: num3, int_4: 0, buEnableTwoValueList_0: this);
			Spn1.Tag = num2;
			num2++;
			base.Controls.Add(Spn1);
			bool @bool = ItemList[i].Bool1;
			int int_5 = Spn1.Left + Spn1.Width + ValueSpace;
			int value2Width = Value2Width;
			int itemHeight3 = ItemHeight;
			string string_6 = "Chk1" + i;
			Chk1 = Class76.smethod_360(string_6, this, num3, 1, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk1);
			Spn2 = Class76.smethod_605(double_0: ItemList[i].Value2, int_5: Chk1.Left + Chk1.Width + ValueSpace, int_0: Value3Width, int_1: ItemHeight, string_0: "Spn2" + i, int_2: i, int_3: num3, int_4: 2, buEnableTwoValueList_0: this);
			Spn2.Tag = num2;
			num2++;
			base.Controls.Add(Spn2);
			Spn3 = Class76.smethod_605(double_0: ItemList[i].Value3, int_5: Spn2.Left + Spn2.Width + ValueSpace, int_0: Value4Width, int_1: ItemHeight, string_0: "Spn3" + i, int_2: i, int_3: num3, int_4: 3, buEnableTwoValueList_0: this);
			Spn3.Tag = num2;
			num2++;
			base.Controls.Add(Spn3);
		}
		Inited = true;
	}

	internal void method_1()
	{
		int_0 = base.Width - (Value1Width + Value2Width + Value3Width + Value4Width + Value5Width + Value6Width + Value7Width) - ValueSpace * 7 - 2;
		string string_ = textName;
		int int_ = int_0;
		int int_2 = Pnl.Height - 12;
		string string_2 = "lbl_Nametext";
		LblText = Class76.smethod_103(string_2, 1, 6, int_2, string_, int_, 0, this);
		Pnl.Controls.Add(LblText);
		string_ = textValue1;
		int num = LblText.Left + LblText.Width + ValueSpace;
		int_ = Value1Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value1text";
		Lbl1 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 1, this);
		Pnl.Controls.Add(Lbl1);
		string_ = textValue2;
		num = Lbl1.Left + Lbl1.Width + ValueSpace;
		int_ = Value2Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value2text";
		Lbl2 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 2, this);
		Pnl.Controls.Add(Lbl2);
		string_ = textValue3;
		num = Lbl2.Left + Lbl2.Width + ValueSpace;
		int_ = Value3Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value3text";
		Lbl3 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 3, this);
		Pnl.Controls.Add(Lbl3);
		string_ = textValue4;
		num = Lbl3.Left + Lbl3.Width + ValueSpace;
		int_ = Value4Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value4text";
		Lbl4 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 4, this);
		Pnl.Controls.Add(Lbl4);
		string_ = textValue5;
		num = Lbl4.Left + Lbl4.Width + ValueSpace;
		int_ = Value5Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value5text";
		Lbl5 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 5, this);
		Pnl.Controls.Add(Lbl5);
		string_ = textValue6;
		num = Lbl5.Left + Lbl5.Width + ValueSpace;
		int_ = Value6Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value6text";
		Lbl6 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 6, this);
		Pnl.Controls.Add(Lbl6);
		string_ = textValue7;
		num = Lbl6.Left + Lbl6.Width + ValueSpace;
		int_ = Value7Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value7text";
		Lbl7 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 7, this);
		Pnl.Controls.Add(Lbl7);
		int num2 = 0;
		for (int i = 0; i <= ItemList.Count - 1; i++)
		{
			int num3 = Pnl.Height + (ItemHeight + 4) * i;
			int num4 = 0;
			int num5 = 0;
			string string_3;
			string name;
			int int_3;
			int itemHeight;
			string string_4;
			if (TextAsButton)
			{
				string_3 = btnName;
				name = ItemList[i].Name;
				int_3 = int_0;
				itemHeight = ItemHeight;
				string_4 = "BtnName" + i;
				BtnName = Class76.smethod_674(itemHeight, num3, int_3, -1, string_3, string_4, this, name, 1, i);
				num4 = BtnName.Left;
				num5 = BtnName.Width;
				base.Controls.Add(BtnName);
			}
			else
			{
				string name2 = ItemList[i].Name;
				int int_4 = int_0;
				int itemHeight2 = ItemHeight;
				string string_5 = "LblName" + i;
				LblName = Class76.smethod_484(1, itemHeight2, string_5, -1, int_4, this, name2, num3);
				num4 = LblName.Left;
				num5 = LblName.Width;
				base.Controls.Add(LblName);
			}
			Spn1 = Class76.smethod_605(double_0: ItemList[i].Value1, int_5: num4 + num5 + ValueSpace, int_0: Value1Width, int_1: ItemHeight, string_0: "Spn1" + i, int_2: i, int_3: num3, int_4: 0, buEnableTwoValueList_0: this);
			Spn1.Tag = num2;
			num2++;
			base.Controls.Add(Spn1);
			bool @bool = ItemList[i].Bool1;
			int int_5 = Spn1.Left + Spn1.Width + ValueSpace;
			int value2Width = Value2Width;
			int itemHeight3 = ItemHeight;
			string string_6 = "Chk1" + i;
			Chk1 = Class76.smethod_360(string_6, this, num3, 1, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk1);
			string_3 = btnCommand1;
			name = textValue3;
			int int_6 = Chk1.Left + Chk1.Width + ValueSpace;
			int_3 = Value3Width;
			itemHeight = ItemHeight;
			string_4 = "Btn1" + i;
			Btn1 = Class76.smethod_674(itemHeight, num3, int_3, 2, string_3, string_4, this, name, int_6, i);
			base.Controls.Add(Btn1);
			@bool = ItemList[i].Bool2;
			int_5 = Btn1.Left + Btn1.Width + ValueSpace;
			value2Width = Value4Width;
			itemHeight3 = ItemHeight;
			string_6 = "Chk2" + i;
			Chk2 = Class76.smethod_360(string_6, this, num3, 3, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk2);
			Spn2 = Class76.smethod_605(double_0: ItemList[i].Value2, int_5: Chk2.Left + Chk2.Width + ValueSpace, int_0: Value5Width, int_1: ItemHeight, string_0: "Spn2" + i, int_2: i, int_3: num3, int_4: 4, buEnableTwoValueList_0: this);
			Spn2.Tag = num2;
			num2++;
			base.Controls.Add(Spn2);
			Spn3 = Class76.smethod_605(double_0: ItemList[i].Value3, int_5: Spn2.Left + Spn2.Width + ValueSpace, int_0: Value6Width, int_1: ItemHeight, string_0: "Spn3" + i, int_2: i, int_3: num3, int_4: 5, buEnableTwoValueList_0: this);
			Spn3.Tag = num2;
			num2++;
			base.Controls.Add(Spn3);
			string_3 = btnCommand2;
			name = textValue7;
			int_6 = Spn3.Left + Spn3.Width + ValueSpace;
			int_3 = Value7Width;
			itemHeight = ItemHeight;
			string_4 = "Btn2" + i;
			Btn2 = Class76.smethod_674(itemHeight, num3, int_3, 6, string_3, string_4, this, name, int_6, i);
			base.Controls.Add(Btn2);
		}
		Inited = true;
	}

	internal void method_2()
	{
		int_0 = base.Width - (Value1Width + Value2Width + Value3Width + Value4Width + Value5Width + Value6Width + Value7Width + Value8Width) - ValueSpace * 8 - 2;
		string string_ = textName;
		int int_ = int_0;
		int int_2 = Pnl.Height - 12;
		string string_2 = "lbl_Nametext";
		LblText = Class76.smethod_103(string_2, 1, 6, int_2, string_, int_, 0, this);
		Pnl.Controls.Add(LblText);
		string_ = textValue1;
		int num = LblText.Left + LblText.Width + ValueSpace;
		int_ = Value1Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value1text";
		Lbl1 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 1, this);
		Pnl.Controls.Add(Lbl1);
		string_ = textValue2;
		num = Lbl1.Left + Lbl1.Width + ValueSpace;
		int_ = Value2Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value2text";
		Lbl2 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 2, this);
		Pnl.Controls.Add(Lbl2);
		string_ = textValue3;
		num = Lbl2.Left + Lbl2.Width + ValueSpace;
		int_ = Value3Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value3text";
		Lbl3 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 3, this);
		Pnl.Controls.Add(Lbl3);
		string_ = textValue4;
		num = Lbl3.Left + Lbl3.Width + ValueSpace;
		int_ = Value4Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value4text";
		Lbl4 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 4, this);
		Pnl.Controls.Add(Lbl4);
		string_ = textValue5;
		num = Lbl4.Left + Lbl4.Width + ValueSpace;
		int_ = Value5Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value5text";
		Lbl5 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 5, this);
		Pnl.Controls.Add(Lbl5);
		string_ = textValue6;
		num = Lbl5.Left + Lbl5.Width + ValueSpace;
		int_ = Value6Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value6text";
		Lbl6 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 6, this);
		Pnl.Controls.Add(Lbl6);
		string_ = textValue7;
		num = Lbl6.Left + Lbl6.Width + ValueSpace;
		int_ = Value7Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value7text";
		Lbl7 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 7, this);
		Pnl.Controls.Add(Lbl7);
		string_ = textValue8;
		num = Lbl7.Left + Lbl7.Width + ValueSpace;
		int_ = Value8Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value8text";
		Lbl8 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 8, this);
		Pnl.Controls.Add(Lbl8);
		int num2 = 0;
		for (int i = 0; i <= ItemList.Count - 1; i++)
		{
			int num3 = Pnl.Height + (ItemHeight + 4) * i;
			int num4 = 0;
			int num5 = 0;
			string string_3;
			string name;
			int int_3;
			int itemHeight;
			string string_4;
			if (TextAsButton)
			{
				string_3 = btnName;
				name = ItemList[i].Name;
				int_3 = int_0;
				itemHeight = ItemHeight;
				string_4 = "BtnName" + i;
				BtnName = Class76.smethod_674(itemHeight, num3, int_3, -1, string_3, string_4, this, name, 1, i);
				num4 = BtnName.Left;
				num5 = BtnName.Width;
				base.Controls.Add(BtnName);
			}
			else
			{
				string name2 = ItemList[i].Name;
				int int_4 = int_0;
				int itemHeight2 = ItemHeight;
				string string_5 = "LblName" + i;
				LblName = Class76.smethod_484(1, itemHeight2, string_5, -1, int_4, this, name2, num3);
				num4 = LblName.Left;
				num5 = LblName.Width;
				base.Controls.Add(LblName);
			}
			Spn1 = Class76.smethod_605(double_0: ItemList[i].Value1, int_5: num4 + num5 + ValueSpace, int_0: Value1Width, int_1: ItemHeight, string_0: "Spn1" + i, int_2: i, int_3: num3, int_4: 0, buEnableTwoValueList_0: this);
			Spn1.Tag = num2;
			num2++;
			base.Controls.Add(Spn1);
			bool @bool = ItemList[i].Bool1;
			int int_5 = Spn1.Left + Spn1.Width + ValueSpace;
			int value2Width = Value2Width;
			int itemHeight3 = ItemHeight;
			string string_6 = "Chk1" + i;
			Chk1 = Class76.smethod_360(string_6, this, num3, 1, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk1);
			@bool = ItemList[i].Bool2;
			int_5 = Chk1.Left + Chk1.Width + ValueSpace;
			value2Width = Value3Width;
			itemHeight3 = ItemHeight;
			string_6 = "Chk2" + i;
			Chk2 = Class76.smethod_360(string_6, this, num3, 2, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk2);
			string_3 = btnCommand1;
			name = textValue4;
			int int_6 = Chk2.Left + Chk2.Width + ValueSpace;
			int_3 = Value4Width;
			itemHeight = ItemHeight;
			string_4 = "Btn1" + i;
			Btn1 = Class76.smethod_674(itemHeight, num3, int_3, 3, string_3, string_4, this, name, int_6, i);
			base.Controls.Add(Btn1);
			@bool = ItemList[i].Bool3;
			int_5 = Btn1.Left + Btn1.Width + ValueSpace;
			value2Width = Value5Width;
			itemHeight3 = ItemHeight;
			string_6 = "Chk3" + i;
			Chk3 = Class76.smethod_360(string_6, this, num3, 4, int_5, @bool, i, itemHeight3, value2Width);
			base.Controls.Add(Chk3);
			Spn2 = Class76.smethod_605(double_0: ItemList[i].Value3, int_5: Chk3.Left + Chk3.Width + ValueSpace, int_0: Value6Width, int_1: ItemHeight, string_0: "Spn2" + i, int_2: i, int_3: num3, int_4: 5, buEnableTwoValueList_0: this);
			Spn2.Tag = num2;
			num2++;
			base.Controls.Add(Spn2);
			Spn3 = Class76.smethod_605(double_0: ItemList[i].Value3, int_5: Spn2.Left + Spn2.Width + ValueSpace, int_0: Value7Width, int_1: ItemHeight, string_0: "Spn3" + i, int_2: i, int_3: num3, int_4: 6, buEnableTwoValueList_0: this);
			Spn3.Tag = num2;
			num2++;
			base.Controls.Add(Spn3);
			string_3 = btnCommand2;
			name = textValue8;
			int_6 = Spn3.Left + Spn3.Width + ValueSpace;
			int_3 = Value8Width;
			itemHeight = ItemHeight;
			string_4 = "Btn2" + i;
			Btn2 = Class76.smethod_674(itemHeight, num3, int_3, 7, string_3, string_4, this, name, int_6, i);
			base.Controls.Add(Btn2);
		}
		Inited = true;
	}

	internal void method_3()
	{
		int_0 = base.Width - (Value1Width + Value2Width + Value3Width) - ValueSpace * 3 - 2;
		string string_ = textName;
		int int_ = int_0;
		int int_2 = Pnl.Height - 12;
		string string_2 = "lbl_Nametext";
		LblText = Class76.smethod_103(string_2, 1, 6, int_2, string_, int_, 0, this);
		Pnl.Controls.Add(LblText);
		string_ = textValue1;
		int num = LblText.Left + LblText.Width + ValueSpace;
		int_ = Value1Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value1text";
		Lbl1 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 1, this);
		Pnl.Controls.Add(Lbl1);
		string_ = textValue2;
		num = Lbl1.Left + Lbl1.Width + ValueSpace;
		int_ = Value2Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value2text";
		Lbl2 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 2, this);
		Pnl.Controls.Add(Lbl2);
		string_ = textValue3;
		num = Lbl2.Left + Lbl2.Width + ValueSpace;
		int_ = Value3Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value3text";
		Lbl3 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 3, this);
		Pnl.Controls.Add(Lbl3);
		int num2 = 0;
		for (int i = 0; i <= ItemList.Count - 1; i++)
		{
			int num3 = Pnl.Height + (ItemHeight + 4) * i;
			int num4 = 0;
			int num5 = 0;
			if (TextAsButton)
			{
				string string_3 = btnName;
				string name = ItemList[i].Name;
				int int_3 = int_0;
				int itemHeight = ItemHeight;
				string string_4 = "BtnName" + i;
				BtnName = Class76.smethod_674(itemHeight, num3, int_3, -1, string_3, string_4, this, name, 1, i);
				num4 = BtnName.Left;
				num5 = BtnName.Width;
				base.Controls.Add(BtnName);
			}
			else
			{
				string name2 = ItemList[i].Name;
				int int_4 = int_0;
				int itemHeight2 = ItemHeight;
				string string_5 = "LblName" + i;
				LblName = Class76.smethod_484(1, itemHeight2, string_5, -1, int_4, this, name2, num3);
				num4 = LblName.Left;
				num5 = LblName.Width;
				base.Controls.Add(LblName);
			}
			bool @bool = ItemList[i].Bool1;
			int int_5 = num4 + num5 + ValueSpace;
			int value1Width = Value1Width;
			int itemHeight3 = ItemHeight;
			string string_6 = "Chk1" + i;
			Chk1 = Class76.smethod_360(string_6, this, num3, 0, int_5, @bool, i, itemHeight3, value1Width);
			base.Controls.Add(Chk1);
			Spn1 = Class76.smethod_605(double_0: ItemList[i].Value1, int_5: Chk1.Left + Chk1.Width + ValueSpace, int_0: Value2Width, int_1: ItemHeight, string_0: "Spn1" + i, int_2: i, int_3: num3, int_4: 1, buEnableTwoValueList_0: this);
			Spn1.Tag = num2;
			num2++;
			base.Controls.Add(Spn1);
			Spn2 = Class76.smethod_605(double_0: ItemList[i].Value2, int_5: Spn1.Left + Spn1.Width + ValueSpace, int_0: Value3Width, int_1: ItemHeight, string_0: "Spn2" + i, int_2: i, int_3: num3, int_4: 2, buEnableTwoValueList_0: this);
			Spn2.Tag = num2;
			num2++;
			base.Controls.Add(Spn2);
		}
		Inited = true;
	}

	internal void method_4()
	{
		int_0 = base.Width - Value1Width - ValueSpace - 2;
		string string_ = textName;
		int int_ = int_0;
		int int_2 = Pnl.Height - 12;
		string string_2 = "lbl_Nametext";
		LblText = Class76.smethod_103(string_2, 1, 6, int_2, string_, int_, 0, this);
		Pnl.Controls.Add(LblText);
		string_ = textValue1;
		int num = LblText.Left + LblText.Width + ValueSpace;
		int_ = Value1Width;
		int_2 = Pnl.Height - 12;
		string_2 = "lbl_value1text";
		Lbl1 = Class76.smethod_103(string_2, num, 6, int_2, string_, int_, 1, this);
		Pnl.Controls.Add(Lbl1);
		for (int i = 0; i <= ItemList.Count - 1; i++)
		{
			int num2 = Pnl.Height + (ItemHeight + 4) * i;
			int num3 = 0;
			int num4 = 0;
			if (TextAsButton)
			{
				string string_3 = btnName;
				string name = ItemList[i].Name;
				int int_3 = int_0;
				int itemHeight = ItemHeight;
				string string_4 = "BtnName" + i;
				BtnName = Class76.smethod_674(itemHeight, num2, int_3, -1, string_3, string_4, this, name, 1, i);
				num3 = BtnName.Left;
				num4 = BtnName.Width;
				base.Controls.Add(BtnName);
			}
			else
			{
				string name2 = ItemList[i].Name;
				int int_4 = int_0;
				int itemHeight2 = ItemHeight;
				string string_5 = "LblName" + i;
				LblName = Class76.smethod_484(1, itemHeight2, string_5, -1, int_4, this, name2, num2);
				num3 = LblName.Left;
				num4 = LblName.Width;
				base.Controls.Add(LblName);
			}
			Spn1 = Class76.smethod_605(double_0: ItemList[i].Value1, int_5: num3 + num4 + ValueSpace, int_0: Value1Width, int_1: ItemHeight, string_0: "Spn1" + i, int_2: i, int_3: num2, int_4: 0, buEnableTwoValueList_0: this);
			Spn1.Tag = i;
			base.Controls.Add(Spn1);
		}
		Inited = true;
	}

	internal void method_5(object object_0, double double_0)
	{
		if (!Inited)
		{
			return;
		}
		buSpin buSpin2 = object_0 as buSpin;
		if (!((buSpin2.Aux.Index >= 0) & (buSpin2.Aux.Index <= ItemList.Count - 1)))
		{
			return;
		}
		if (FormatType == ValuesFormatType.Double && buSpin2.Aux.ValInt == 0)
		{
			ItemList[buSpin2.Aux.Index].Value1 = buSpin2.Value;
		}
		if (FormatType == ValuesFormatType.DoubleBoolDoubleDouble)
		{
			if (buSpin2.Aux.ValInt == 0)
			{
				ItemList[buSpin2.Aux.Index].Value1 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 2)
			{
				ItemList[buSpin2.Aux.Index].Value2 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 3)
			{
				ItemList[buSpin2.Aux.Index].Value3 = buSpin2.Value;
			}
		}
		if (FormatType == ValuesFormatType.DoubleBoolButtonBoolDoubleDoubleButton)
		{
			if (buSpin2.Aux.ValInt == 0)
			{
				ItemList[buSpin2.Aux.Index].Value1 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 4)
			{
				ItemList[buSpin2.Aux.Index].Value2 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 5)
			{
				ItemList[buSpin2.Aux.Index].Value3 = buSpin2.Value;
			}
		}
		if (FormatType == ValuesFormatType.DoubleBoolBoolButtonBoolDoubleDoubleButton)
		{
			if (buSpin2.Aux.ValInt == 0)
			{
				ItemList[buSpin2.Aux.Index].Value1 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 5)
			{
				ItemList[buSpin2.Aux.Index].Value2 = buSpin2.Value;
			}
			if (buSpin2.Aux.ValInt == 6)
			{
				ItemList[buSpin2.Aux.Index].Value3 = buSpin2.Value;
			}
		}
		if (buListValueChangedEventHandler_0 != null)
		{
			buListValueChangedEventArg e = new buListValueChangedEventArg(ItemList, ItemList[buSpin2.Aux.Index], buSpin2.Aux.Index, "");
			buListValueChangedEventHandler_0(this, e);
		}
	}

	internal void method_6(object sender, KeyEventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if ((e.KeyCode == Keys.Return) | (e.KeyCode == Keys.Tab))
		{
			int result = 0;
			int.TryParse(buSpin2.Tag.ToString(), out result);
			buControlCommands.FindNextControlByKey(base.Controls, result, e.Shift);
			if ((e.KeyCode == Keys.Return) & (buListValueChangedEventHandler_1 != null))
			{
				buListValueChangedEventArg e2 = new buListValueChangedEventArg(ItemList, ItemList[buSpin2.Aux.Index], buSpin2.Aux.Index, "");
				buListValueChangedEventHandler_1(this, e2);
			}
		}
	}

	internal void method_7(object sender, EventArgs e)
	{
		buSpin buSpin2 = sender as buSpin;
		if (AppBool.TouchPad)
		{
			F_KeyPadNumV1 f_KeyPadNumV = new F_KeyPadNumV1();
			f_KeyPadNumV.StartPosition = FormStartPosition.CenterParent;
			f_KeyPadNumV.Caption = buSpin2.Caption.Caption;
			f_KeyPadNumV.ShowDialog(buSpin2.Value.ToString());
			if (buNumeric.IsNumeric(f_KeyPadNumV.Value))
			{
				buSpin2.Value = double.Parse(f_KeyPadNumV.Value);
			}
		}
	}

	internal void method_8(object object_0, bool bool_0)
	{
		if (!Inited)
		{
			return;
		}
		buCheckBox buCheckBox2 = object_0 as buCheckBox;
		if (!((buCheckBox2.Aux.Index >= 0) & (buCheckBox2.Aux.Index <= ItemList.Count - 1)))
		{
			return;
		}
		if (FormatType == ValuesFormatType.DoubleBoolDoubleDouble && buCheckBox2.Aux.ValInt == 1)
		{
			ItemList[buCheckBox2.Aux.Index].Bool1 = buCheckBox2.Check;
		}
		if (FormatType == ValuesFormatType.DoubleBoolButtonBoolDoubleDoubleButton)
		{
			if (buCheckBox2.Aux.ValInt == 1)
			{
				ItemList[buCheckBox2.Aux.Index].Bool1 = buCheckBox2.Check;
			}
			if (buCheckBox2.Aux.ValInt == 3)
			{
				ItemList[buCheckBox2.Aux.Index].Bool2 = buCheckBox2.Check;
			}
		}
		if (FormatType == ValuesFormatType.DoubleBoolBoolButtonBoolDoubleDoubleButton)
		{
			if (buCheckBox2.Aux.ValInt == 1)
			{
				ItemList[buCheckBox2.Aux.Index].Bool1 = buCheckBox2.Check;
			}
			if (buCheckBox2.Aux.ValInt == 2)
			{
				ItemList[buCheckBox2.Aux.Index].Bool2 = buCheckBox2.Check;
			}
			if (buCheckBox2.Aux.ValInt == 4)
			{
				ItemList[buCheckBox2.Aux.Index].Bool3 = buCheckBox2.Check;
			}
		}
		if (buListValueChangedEventHandler_0 != null)
		{
			buListValueChangedEventArg e = new buListValueChangedEventArg(ItemList, ItemList[buCheckBox2.Aux.Index], buCheckBox2.Aux.Index, "");
			buListValueChangedEventHandler_0(this, e);
		}
		if (buListValueChangedEventHandler_1 != null)
		{
			buListValueChangedEventArg e2 = new buListValueChangedEventArg(ItemList, ItemList[buCheckBox2.Aux.Index], buCheckBox2.Aux.Index, "");
			buListValueChangedEventHandler_1(this, e2);
		}
	}

	internal void method_9(object sender, EventArgs e)
	{
		if (Inited)
		{
			buButton buButton2 = sender as buButton;
			if (buListValueChangedEventHandler_2 != null)
			{
				buListValueChangedEventArg e2 = new buListValueChangedEventArg(ItemList, ItemList[buButton2.Aux.Index], buButton2.Aux.Index, buButton2.Aux.AuxInfo);
				buListValueChangedEventHandler_2(this, e2);
			}
		}
	}

	internal void method_10(object sender, EventArgs e)
	{
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
