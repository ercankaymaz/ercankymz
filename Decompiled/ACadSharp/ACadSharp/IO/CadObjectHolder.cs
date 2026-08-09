using System.Collections.Generic;
using ACadSharp.Entities;

namespace ACadSharp.IO;

internal class CadObjectHolder
{
	public Queue<Entity> Entities { get; } = new Queue<Entity>();

	public Queue<CadObject> Objects { get; } = new Queue<CadObject>();
}
