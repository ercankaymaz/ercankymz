using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buControls.Controls;
using ns27;

namespace buControls.Components;

public class buLayerList : UserControl
{
	public List<LayerData> LayerList = new List<LayerData>();

	public int SelectedLayer = -1;

	public Color colorUnSelected = Color.Silver;

	public Color colorSelected = Color.LightSkyBlue;

	public int LayetItemHeight = 25;

	[CompilerGenerated]
	private buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler_0;

	[CompilerGenerated]
	private buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler_0;

	private IContainer icontainer_0 = null;

	public event buControlEvents.buLayerChangedEventHandler LayerChanged
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler = buLayerChangedEventHandler_0;
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler2;
			do
			{
				buLayerChangedEventHandler2 = buLayerChangedEventHandler;
				buControlEvents.buLayerChangedEventHandler value2 = (buControlEvents.buLayerChangedEventHandler)Delegate.Combine(buLayerChangedEventHandler2, value);
				buLayerChangedEventHandler = Interlocked.CompareExchange(ref buLayerChangedEventHandler_0, value2, buLayerChangedEventHandler2);
			}
			while ((object)buLayerChangedEventHandler != buLayerChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler = buLayerChangedEventHandler_0;
			buControlEvents.buLayerChangedEventHandler buLayerChangedEventHandler2;
			do
			{
				buLayerChangedEventHandler2 = buLayerChangedEventHandler;
				buControlEvents.buLayerChangedEventHandler value2 = (buControlEvents.buLayerChangedEventHandler)Delegate.Remove(buLayerChangedEventHandler2, value);
				buLayerChangedEventHandler = Interlocked.CompareExchange(ref buLayerChangedEventHandler_0, value2, buLayerChangedEventHandler2);
			}
			while ((object)buLayerChangedEventHandler != buLayerChangedEventHandler2);
		}
	}

	public event buControlEvents.buLayerDoubleClickEventHandler LayerDoubleClick
	{
		[CompilerGenerated]
		add
		{
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler = buLayerDoubleClickEventHandler_0;
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler2;
			do
			{
				buLayerDoubleClickEventHandler2 = buLayerDoubleClickEventHandler;
				buControlEvents.buLayerDoubleClickEventHandler value2 = (buControlEvents.buLayerDoubleClickEventHandler)Delegate.Combine(buLayerDoubleClickEventHandler2, value);
				buLayerDoubleClickEventHandler = Interlocked.CompareExchange(ref buLayerDoubleClickEventHandler_0, value2, buLayerDoubleClickEventHandler2);
			}
			while ((object)buLayerDoubleClickEventHandler != buLayerDoubleClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler = buLayerDoubleClickEventHandler_0;
			buControlEvents.buLayerDoubleClickEventHandler buLayerDoubleClickEventHandler2;
			do
			{
				buLayerDoubleClickEventHandler2 = buLayerDoubleClickEventHandler;
				buControlEvents.buLayerDoubleClickEventHandler value2 = (buControlEvents.buLayerDoubleClickEventHandler)Delegate.Remove(buLayerDoubleClickEventHandler2, value);
				buLayerDoubleClickEventHandler = Interlocked.CompareExchange(ref buLayerDoubleClickEventHandler_0, value2, buLayerDoubleClickEventHandler2);
			}
			while ((object)buLayerDoubleClickEventHandler != buLayerDoubleClickEventHandler2);
		}
	}

	public buLayerList()
	{
		Class76.smethod_429(this);
	}

	public void Add(LayerData layer, bool Draw = true)
	{
		LayerList.Add(layer);
		if (Draw)
		{
			Class76.smethod_836(this);
		}
	}

	public void RemoveAll()
	{
		LayerList.Clear();
		Class76.smethod_836(this);
	}

	public void Remove(int index)
	{
		if ((index >= 0) & (index <= LayerList.Count - 1))
		{
			LayerList.RemoveAt(index);
			Class76.smethod_836(this);
		}
	}

	public void SetLayer(int Index)
	{
		if ((Index >= 0) & (Index <= LayerList.Count - 1))
		{
			SelectedLayer = Index;
			Class76.smethod_836(this);
		}
	}

	public void SetLayer(string Name)
	{
		int num = 0;
		while (true)
		{
			if (num <= LayerList.Count - 1)
			{
				if (Name == LayerList[num].Name)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		SelectedLayer = num;
		Class76.smethod_836(this);
	}

	public void DrawControls()
	{
		Class76.smethod_836(this);
	}

	internal void method_0(object object_0, Color color_0, bool bool_0, bool bool_1, string string_0, int int_0)
	{
		if (buLayerChangedEventHandler_0 == null)
		{
			return;
		}
		buLayerChangedEventHandler_0(object_0, color_0, bool_0, bool_1, string_0, int_0);
		SelectedLayer = int_0;
		for (int i = 0; i <= base.Controls.Count - 1; i++)
		{
			base.Controls[i].BackColor = colorUnSelected;
			if (i == SelectedLayer)
			{
				base.Controls[i].BackColor = colorSelected;
			}
		}
	}

	internal void method_1(object object_0, Color color_0, bool bool_0, bool bool_1, string string_0, int int_0)
	{
		if (buLayerDoubleClickEventHandler_0 != null)
		{
			buLayerDoubleClickEventHandler_0(object_0, color_0, bool_0, bool_1, string_0, int_0);
		}
	}

	internal void method_2(object sender, EventArgs e)
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
