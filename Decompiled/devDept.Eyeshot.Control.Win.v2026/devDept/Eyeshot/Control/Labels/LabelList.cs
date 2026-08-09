using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class LabelList : EyeshotCollection<Label>, ISelectable
{
	internal List<KeyValuePair<int, Label>> sortedLabels = new List<KeyValuePair<int, Label>>();

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Viewport _0023_003DzYzWi5Yw_003D;

	public override Label this[int index]
	{
		get
		{
			return baseList[index];
		}
		set
		{
			_0023_003DzMbc2_0024v8_003D(baseList[index]);
			baseList[index] = value;
		}
	}

	public LabelList()
	{
	}

	public LabelList(Viewport viewport)
	{
		_0023_003DzYzWi5Yw_003D = viewport;
	}

	private int _0023_003Dzbt3d4Ba2xyv8(KeyValuePair<int, Label> _0023_003DzkW_0024DzQk_003D, KeyValuePair<int, Label> _0023_003Dz8ecWqr4_003D)
	{
		Label value = _0023_003DzkW_0024DzQk_003D.Value;
		Label value2 = _0023_003Dz8ecWqr4_003D.Value;
		if (value.zPos < value2.zPos)
		{
			return 1;
		}
		if (value.zPos > value2.zPos)
		{
			return -1;
		}
		return 0;
	}

	internal void _0023_003DzL1xYB6XaQTqb()
	{
		if (sortedLabels.Count != base.Count)
		{
			sortedLabels = new List<KeyValuePair<int, Label>>(base.Count);
			for (int i = 0; i < base.Count; i++)
			{
				sortedLabels.Add(new KeyValuePair<int, Label>(i, baseList[i]));
			}
		}
		else
		{
			for (int j = 0; j < base.Count; j++)
			{
				sortedLabels[j] = new KeyValuePair<int, Label>(j, baseList[j]);
			}
		}
		sortedLabels.Sort(_0023_003Dzbt3d4Ba2xyv8);
	}

	private void _0023_003DzMbc2_0024v8_003D(Label _0023_003DzaO_0024_BNc_003D)
	{
		if (_0023_003DzYzWi5Yw_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			_0023_003DzaO_0024_BNc_003D.Dispose();
		}
	}

	public override bool Remove(Label item)
	{
		_0023_003DzMbc2_0024v8_003D(item);
		return baseList.Remove(item);
	}

	public override void RemoveAt(int index)
	{
		_0023_003DzMbc2_0024v8_003D(baseList[index]);
		baseList.RemoveAt(index);
	}

	public override void RemoveRange(int index, int count)
	{
		if (_0023_003DzYzWi5Yw_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			for (int i = index; i < count; i++)
			{
				baseList[index].Dispose();
			}
		}
		baseList.RemoveRange(index, count);
	}

	public override int RemoveAll(Predicate<Label> match)
	{
		if (_0023_003DzYzWi5Yw_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			foreach (Label item in FindAll(match))
			{
				item.Dispose();
			}
		}
		return baseList.RemoveAll(match);
	}

	public override void Clear()
	{
		if (_0023_003DzYzWi5Yw_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D != null)
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			foreach (Label @base in baseList)
			{
				@base.Dispose();
			}
		}
		baseList.Clear();
		sortedLabels.Clear();
	}

	public override void Add(Label item)
	{
		_0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(item);
		base.Add(item);
	}

	public override void AddRange(IEnumerable<Label> collection)
	{
		foreach (Label item in collection)
		{
			_0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(item);
		}
		base.AddRange(collection);
	}

	public override void Insert(int index, Label item)
	{
		_0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(item);
		base.Insert(index, item);
	}

	public override void InsertRange(int index, IEnumerable<Label> collection)
	{
		foreach (Label item in collection)
		{
			_0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(item);
		}
		base.InsertRange(index, collection);
	}

	public void Regen()
	{
		if (_0023_003DzYzWi5Yw_003D == null || _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D == null || _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D == null)
		{
			return;
		}
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
		foreach (Label @base in baseList)
		{
			if (@base.RegenMode != regenType.NotNeeded)
			{
				@base.Regen(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, 1f);
			}
		}
	}

	private void _0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(Label _0023_003DzaO_0024_BNc_003D)
	{
		if (_0023_003DzYzWi5Yw_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D != null && _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzXQRWQ3GhBR_Q())
		{
			_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.MakeCurrent();
			if (_0023_003DzaO_0024_BNc_003D.RegenMode != regenType.NotNeeded)
			{
				_0023_003DzaO_0024_BNc_003D.Regen(_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D, 1f);
			}
		}
	}

	public void ClearSelection()
	{
		SelectionChangedEventArgs e = EntityList.ClearSelectedItemInternal(this);
		if (e.AddedItems.Count > 0 || e.RemovedItems.Count > 0)
		{
			_0023_003DzYzWi5Yw_003D.FireLabelSelectionChanged(e);
		}
	}

	public void SelectAll()
	{
		List<SelectedItem> list = new List<SelectedItem>();
		for (int i = 0; i < baseList.Count; i++)
		{
			Label label = baseList[i];
			if (label.Selectable && (label.Visible & !label.Selected))
			{
				label.Selected = true;
				list.Add(new SelectedItem(label));
			}
		}
		if (list.Count > 0)
		{
			_0023_003DzYzWi5Yw_003D.FireLabelSelectionChanged(new SelectionChangedEventArgs(list, null));
		}
	}

	public void InvertSelection()
	{
		List<SelectedItem> list = new List<SelectedItem>(baseList.Count);
		List<SelectedItem> list2 = new List<SelectedItem>(baseList.Count);
		for (int i = 0; i < baseList.Count; i++)
		{
			Label label = baseList[i];
			if (label.Selected)
			{
				label.Selected = false;
				list2.Add(new SelectedItem(label));
			}
			else if (label.Selectable && label.Visible)
			{
				label.Selected = true;
				list.Add(new SelectedItem(label));
			}
		}
		if (list.Count > 0 || list2.Count > 0)
		{
			_0023_003DzYzWi5Yw_003D.FireLabelSelectionChanged(new SelectionChangedEventArgs(list, list2));
		}
	}

	public void DeleteSelected()
	{
		for (int num = base.Count - 1; num >= 0; num--)
		{
			Label label = baseList[num];
			if (label != null && label.Selected)
			{
				RemoveAt(num);
			}
		}
	}

	public void CopySelection()
	{
		_0023_003DzLitRyj3zsy9X(_0023_003DzUFCuHpQ_003D: false);
	}

	public void CutSelection()
	{
		_0023_003DzLitRyj3zsy9X(_0023_003DzUFCuHpQ_003D: true);
	}

	private void _0023_003DzLitRyj3zsy9X(bool _0023_003DzUFCuHpQ_003D)
	{
		List<Label> list = new List<Label>();
		for (int i = 0; i < baseList.Count; i++)
		{
			Label label = baseList[i];
			if (label.Selected)
			{
				list.Add(label);
				if (_0023_003DzUFCuHpQ_003D)
				{
					baseList.RemoveAt(i);
					i--;
				}
			}
		}
		if (list.Count > 0)
		{
			Clipboard.SetData(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586633), _0023_003DzpZu6f4I_003D(list));
		}
	}

	public virtual void Paste()
	{
		object data = Clipboard.GetData(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348586633));
		if (data != null)
		{
			List<Label> collection = _0023_003DzlpkxU34pSEqd((byte[])data);
			AddRange(collection);
		}
	}

	private protected byte[] _0023_003DzpZu6f4I_003D(List<Label> _0023_003Dz_0024GSTnvdQULEK)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			FileSerializerWithLabels fileSerializerWithLabels = new FileSerializerWithLabels();
			FileHeader _0023_003Dz8Vwa6Pc_003D = new FileHeader(contentType.GeometryAndTessellation, serializationType.WithLengthPrefix);
			try
			{
				fileSerializerWithLabels.WriteHeader(_0023_003Dz8Vwa6Pc_003D, memoryStream);
				foreach (Label item in _0023_003Dz_0024GSTnvdQULEK)
				{
					fileSerializerWithLabels.WriteSingleObject(memoryStream, item);
				}
			}
			finally
			{
				fileSerializerWithLabels.ResetCacheForLengthPrefix();
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private protected List<Label> _0023_003DzlpkxU34pSEqd(byte[] _0023_003DzM6mSidPww9Os)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzM6mSidPww9Os);
		try
		{
			List<Label> list = new List<Label>();
			FileSerializerWithLabels fileSerializerWithLabels = new FileSerializerWithLabels();
			try
			{
				fileSerializerWithLabels.ReadHeader(memoryStream);
				list.AddRange(fileSerializerWithLabels.ReadAllObjects<Label>(memoryStream));
			}
			finally
			{
				fileSerializerWithLabels.ResetCacheForLengthPrefix();
			}
			return list;
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	public void InitializeGraphicsResources()
	{
		foreach (Label @base in baseList)
		{
			_0023_003DzDDvr8XGIlsVd2xp7mQ_003D_003D(@base);
		}
	}
}
