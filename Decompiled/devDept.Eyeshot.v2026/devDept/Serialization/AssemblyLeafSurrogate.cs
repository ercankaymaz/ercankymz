using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class AssemblyLeafSurrogate : Surrogate<AssemblyLeaf>
{
	public Entity Entity;

	public List<BlockReference> Parents;

	public AssemblyLeafSurrogate(AssemblyLeaf assemblyLeaf)
		: base(assemblyLeaf)
	{
	}

	protected override AssemblyLeaf ConvertToObject()
	{
		return new AssemblyLeaf(this);
	}

	protected override void CopyDataToObject(AssemblyLeaf obj)
	{
	}

	protected override void CopyDataFromObject(AssemblyLeaf assemblyLeaf)
	{
		Entity = assemblyLeaf.Entity;
		Parents = assemblyLeaf.Parents?.ToList();
	}

	public static implicit operator AssemblyLeaf(AssemblyLeafSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator AssemblyLeafSurrogate(AssemblyLeaf source)
	{
		return source?.ConvertToSurrogate();
	}
}
