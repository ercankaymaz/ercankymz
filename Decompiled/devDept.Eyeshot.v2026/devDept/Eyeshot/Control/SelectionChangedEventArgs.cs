using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace devDept.Eyeshot.Control;

public class SelectionChangedEventArgs : EventArgs
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<SelectedItem> _0023_003Dz_jZSRCyds2fDzthhTBo_E54_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<SelectedItem> _0023_003DzYRHjzVZpm5uVH2XvEkqrcJk_003D;

	public List<SelectedItem> AddedItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_jZSRCyds2fDzthhTBo_E54_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_jZSRCyds2fDzthhTBo_E54_003D = value;
		}
	}

	public List<SelectedItem> RemovedItems
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYRHjzVZpm5uVH2XvEkqrcJk_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYRHjzVZpm5uVH2XvEkqrcJk_003D = value;
		}
	}

	public SelectionChangedEventArgs()
	{
		AddedItems = new List<SelectedItem>();
		RemovedItems = new List<SelectedItem>();
	}

	public SelectionChangedEventArgs(int[] added, int[] removed, IWorkspace ws)
		: this(added, removed, ws.Document)
	{
	}

	public SelectionChangedEventArgs(int[] added, int[] removed, Document document)
		: this()
	{
		if (added != null)
		{
			for (int i = 0; i < added.Length; i++)
			{
				AddedItems.Add(new SelectedItem(document.Entities[added[i]]));
			}
		}
		if (removed != null)
		{
			for (int j = 0; j < removed.Length; j++)
			{
				RemovedItems.Add(new SelectedItem(document.Entities[removed[j]]));
			}
		}
	}

	public SelectionChangedEventArgs(IEnumerable<SelectedItem> added, IEnumerable<SelectedItem> removed)
		: this()
	{
		if (added != null)
		{
			AddedItems.AddRange(added);
		}
		if (removed != null)
		{
			RemovedItems.AddRange(removed);
		}
	}

	public void Clear()
	{
		AddedItems.Clear();
		RemovedItems.Clear();
	}

	internal void SetItems(IList<SelectedItem> _0023_003Dz1cDKNW8_003D, IList<SelectedItem> _0023_003Dz1AZlEC0_003D)
	{
		Clear();
		AddedItems.AddRange(_0023_003Dz1cDKNW8_003D);
		RemovedItems.AddRange(_0023_003Dz1AZlEC0_003D);
	}
}
