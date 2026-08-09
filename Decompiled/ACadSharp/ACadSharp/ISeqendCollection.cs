using System;
using System.Collections;
using ACadSharp.Entities;

namespace ACadSharp;

public interface ISeqendCollection : IEnumerable
{
	Seqend Seqend { get; }

	event EventHandler<CollectionChangedEventArgs> OnSeqendAdded;

	event EventHandler<CollectionChangedEventArgs> OnSeqendRemoved;
}
