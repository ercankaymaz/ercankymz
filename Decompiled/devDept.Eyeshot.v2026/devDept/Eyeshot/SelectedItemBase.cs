using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public abstract class SelectedItemBase : IComparable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<BlockReference> _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISelectableItem _0023_003DzXQbq3rWVgLxZBLcIag_003D_003D;

	public Stack<BlockReference> Parents
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzVFEljva0ZbIneo8XbQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzVFEljva0ZbIneo8XbQ_003D_003D = value;
		}
	}

	public ISelectableItem Item
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzXQbq3rWVgLxZBLcIag_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzXQbq3rWVgLxZBLcIag_003D_003D = value;
		}
	}

	public SelectedItemBase(Stack<BlockReference> parents)
	{
		Init(parents, null);
	}

	public SelectedItemBase(ISelectableItem item)
	{
		Init(null, item);
	}

	public SelectedItemBase(Stack<BlockReference> parents, ISelectableItem item)
	{
		Init(parents, item);
	}

	public SelectedItemBase()
	{
	}

	public virtual void Init(Stack<BlockReference> parents, ISelectableItem item, int subItemIndex = -1, int shellIndex = -1, int nSubItems = -1, object[][] subItemsArray = null)
	{
		if (parents != null)
		{
			Parents = Utility.CloneStack(parents);
		}
		else
		{
			Parents = new Stack<BlockReference>();
		}
		Item = item;
	}

	public bool HasParents()
	{
		if (Parents != null)
		{
			return Parents.Count > 0;
		}
		return false;
	}

	public override bool Equals(object other)
	{
		if (!(other is SelectedItemBase))
		{
			return false;
		}
		SelectedItemBase selectedItemBase = (SelectedItemBase)other;
		if (Item != selectedItemBase.Item)
		{
			return false;
		}
		if ((HasParents() && !selectedItemBase.HasParents()) || (!HasParents() && selectedItemBase.HasParents()))
		{
			return false;
		}
		return AreEqualParents(selectedItemBase);
	}

	public virtual int CompareTo(object obj)
	{
		return -1;
	}

	public bool AreEqualParents(SelectedItemBase item2)
	{
		return _0023_003DzPglMnmnGOjfR(Parents, item2.Parents);
	}

	internal static bool _0023_003DzPglMnmnGOjfR(Stack<BlockReference> _0023_003DzUEXALWo_003D, Stack<BlockReference> _0023_003Dz7URySbs_003D)
	{
		return _0023_003DzUEXALWo_003D.SequenceEqual(_0023_003Dz7URySbs_003D);
	}

	internal static int _0023_003DzAdoyA7k_003D<T>(T _0023_003DzUBZd570_003D, List<T> _0023_003DzhrgkevI_003D) where T : SelectedItemBase
	{
		if (_0023_003DzhrgkevI_003D == null)
		{
			_0023_003DzhrgkevI_003D = new List<T>();
		}
		for (int i = 0; i < _0023_003DzhrgkevI_003D.Count; i++)
		{
			if (_0023_003DzUBZd570_003D.Equals(_0023_003DzhrgkevI_003D[i]))
			{
				return i;
			}
		}
		return -1;
	}

	protected static int FindEntityIndex(Entity ent, IList<Entity> entities)
	{
		for (int i = 0; i < entities.Count; i++)
		{
			if (ent == entities[i])
			{
				return i;
			}
		}
		return -1;
	}
}
