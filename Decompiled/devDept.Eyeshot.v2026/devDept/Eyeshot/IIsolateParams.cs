using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal interface IIsolateParams
{
	bool ParentIsolated { get; }

	Stack<BlockReference> Parents { get; }
}
