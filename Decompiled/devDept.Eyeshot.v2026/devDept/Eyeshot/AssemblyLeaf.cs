using System;
using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class AssemblyLeaf
{
	public Entity Entity { get; set; }

	public Stack<BlockReference> Parents { get; set; }

	public AssemblyLeaf(Entity entity, Stack<BlockReference> parents)
	{
		Entity = entity;
		Parents = parents;
	}

	protected internal AssemblyLeaf(AssemblyLeafSurrogate surrogate)
	{
		Entity = surrogate.Entity;
		if (surrogate.Parents != null)
		{
			surrogate.Parents.Reverse();
			Parents = new Stack<BlockReference>(surrogate.Parents);
		}
		else
		{
			Parents = new Stack<BlockReference>();
		}
	}

	public override int GetHashCode()
	{
		int num = 0;
		num = (num * 397) ^ Entity.GetHashCode();
		foreach (BlockReference parent in Parents)
		{
			num = (num * 397) ^ parent.GetHashCode();
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		if (obj is AssemblyLeaf assemblyLeaf && assemblyLeaf.Parents.SequenceEqual(Parents))
		{
			return assemblyLeaf.Entity == Entity;
		}
		return false;
	}

	public virtual AssemblyLeafSurrogate ConvertToSurrogate()
	{
		return new AssemblyLeafSurrogate(this);
	}
}
