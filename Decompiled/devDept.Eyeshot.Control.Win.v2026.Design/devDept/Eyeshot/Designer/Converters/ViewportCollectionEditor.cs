using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Geometry;

namespace devDept.Eyeshot.Designer.Converters;

public class ViewportCollectionEditor(Type type) : EyeshotCollectionEditor<Viewport>(type)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<ViewportList> _0023_003DzuT4OpGbzrUeEcSle6g_003D_003D = new Stack<ViewportList>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList _0023_003DzfD9dCFwbHCjesM_0024jDg_003D_003D;

	protected IList temporaryList
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfD9dCFwbHCjesM_0024jDg_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfD9dCFwbHCjesM_0024jDg_003D_003D = value;
		}
	}

	protected override void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
	{
		try
		{
			string label = e.ChangedItem.Parent.Label;
			if (!(label == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313465)))
			{
				if (label == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313432) || label == _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313433))
				{
					EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.CompileUserInterfaceElements();
				}
			}
			else
			{
				for (int i = 0; i < temporaryList.Count; i++)
				{
					((Viewport)temporaryList[i]).CompileBackground();
				}
			}
		}
		catch (Exception)
		{
		}
		base.propertyGrid_PropertyValueChanged(sender, e);
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		IList itemsList = GetItemsList();
		int num = listBox.SelectedIndex;
		if (num < 0)
		{
			num = 0;
		}
		if (itemsList.Count == 1 && (temporaryList == null || temporaryList.Count == 0))
		{
			((Viewport)itemsList[0]).Location = new Point(0, 0);
			((Viewport)itemsList[0]).Size = new Size(EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Width, EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Height);
		}
		UpdateDesignModeTemporaryList<Viewport>(num, itemsList);
	}

	protected override object CreateInstance(Type itemType)
	{
		Viewport obj = (Viewport)base.CreateInstance(itemType);
		obj.CompileBackground();
		return obj;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D = (Design)context.Instance;
		EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.SetViewportsForDesignTime(_0023_003Dz6TSTIePFr5zWCmLxveIOcgM_003D);
		EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.RestoreViewportsForDesignTime(_0023_003DzJPe4T0a1q_lyRT2i9YzSmFQ_003D);
		return base.EditValue(context, provider, value);
	}

	public void UpdateDesignModeTemporaryList<T>(int currIndex, IList newList) where T : Viewport
	{
		bool forceUpdate = false;
		if (typeof(T) == typeof(Viewport) && currIndex != EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.ActiveViewportIndex)
		{
			forceUpdate = true;
		}
		UpdateDesignModeTemporaryList(newList, forceUpdate);
	}

	private T[] _0023_003Dz7ZrS97jLiTGs<T>(IList _0023_003DzrYqZbfE_003D)
	{
		if (_0023_003DzrYqZbfE_003D == null)
		{
			return null;
		}
		T[] array = new T[_0023_003DzrYqZbfE_003D.Count];
		for (int i = 0; i < _0023_003DzrYqZbfE_003D.Count; i++)
		{
			array[i] = (T)_0023_003DzrYqZbfE_003D[i];
		}
		return array;
	}

	internal Viewport _0023_003DzJbglhUjV5SYV(int _0023_003Dzcp3dyG4_003D)
	{
		if (!EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.IsDesignMode())
		{
			return _0023_003DzJbglhUjV5SYV(EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports, _0023_003Dzcp3dyG4_003D);
		}
		if (temporaryList == null)
		{
			return _0023_003DzJbglhUjV5SYV(EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports, _0023_003Dzcp3dyG4_003D);
		}
		return _0023_003DzJbglhUjV5SYV(temporaryList, _0023_003Dzcp3dyG4_003D);
	}

	private static Viewport _0023_003DzJbglhUjV5SYV(IList _0023_003Dz_s4BR_0024Ebh3OI35iQVw_003D_003D, int _0023_003Dzcp3dyG4_003D)
	{
		Viewport result = null;
		if (_0023_003Dzcp3dyG4_003D < _0023_003Dz_s4BR_0024Ebh3OI35iQVw_003D_003D.Count)
		{
			result = (Viewport)_0023_003Dz_s4BR_0024Ebh3OI35iQVw_003D_003D[_0023_003Dzcp3dyG4_003D];
		}
		return result;
	}

	private void _0023_003DzJPe4T0a1q_lyRT2i9YzSmFQ_003D()
	{
		if (temporaryList != null)
		{
			EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports = _0023_003DzuT4OpGbzrUeEcSle6g_003D_003D.Pop();
		}
	}

	private void _0023_003Dz6TSTIePFr5zWCmLxveIOcgM_003D()
	{
		if (temporaryList != null)
		{
			_0023_003DzuT4OpGbzrUeEcSle6g_003D_003D.Push(EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports);
			EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports = new ViewportList(EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D);
			EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D.Viewports.AddRange(temporaryList);
		}
	}

	protected override void FormClosed(object sender, EventArgs e)
	{
		base.FormClosed(sender, e);
		UpdateDesignModeTemporaryList(null, forceUpdate: true);
	}

	public void UpdateDesignModeTemporaryList(IList newList, bool forceUpdate)
	{
		bool flag = forceUpdate;
		IList first = _0023_003DzsK0AXKSqWjrQ();
		if (!flag && newList != null)
		{
			flag = !Utility.AreEqual(first, newList);
		}
		_0023_003DzRtqi5X4tVCna(newList);
		if (flag)
		{
			((IWorkspaceInternal)EyeshotCollectionEditor<Viewport>._0023_003Dzf_0024fnpVEiO9xqE1nPDQ_003D_003D).UpdateWorkspace();
		}
	}

	private void _0023_003DzRtqi5X4tVCna(IList _0023_003DzarYwkyo_003D)
	{
		temporaryList = _0023_003DzarYwkyo_003D;
	}

	private IList _0023_003DzsK0AXKSqWjrQ()
	{
		return temporaryList;
	}
}
