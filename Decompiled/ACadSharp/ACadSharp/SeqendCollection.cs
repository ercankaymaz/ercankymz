using System;
using System.Collections;
using System.Linq;
using ACadSharp.Entities;

namespace ACadSharp;

public class SeqendCollection<T> : CadObjectCollection<T>, ISeqendCollection, IEnumerable where T : CadObject
{
	private Seqend _seqend;

	public Seqend Seqend
	{
		get
		{
			if (_entries.Any())
			{
				return _seqend;
			}
			return null;
		}
		internal set
		{
			_seqend = value;
			_seqend.Owner = base.Owner;
		}
	}

	public event EventHandler<CollectionChangedEventArgs> OnSeqendAdded;

	public event EventHandler<CollectionChangedEventArgs> OnSeqendRemoved;

	public SeqendCollection(CadObject owner)
		: base(owner)
	{
		_seqend = new Seqend(owner);
	}

	public override void Add(T item)
	{
		bool flag = false;
		if (!_entries.Any())
		{
			flag = true;
		}
		base.Add(item);
		if (flag && _entries.Any())
		{
			this.OnSeqendAdded?.Invoke(this, new CollectionChangedEventArgs(_seqend));
		}
	}

	public override T Remove(T item)
	{
		T val = base.Remove(item);
		if (val != null)
		{
			EventHandler<CollectionChangedEventArgs> eventHandler = this.OnSeqendRemoved;
			if (eventHandler == null)
			{
				return val;
			}
			eventHandler(this, new CollectionChangedEventArgs(_seqend));
		}
		return val;
	}
}
