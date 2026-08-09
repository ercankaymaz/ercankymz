using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal abstract class SilhoWireAndTriangleData : SilhoWireData
{
	protected SilhoWireAndTriangleData(Entity entity, Stack<BlockReference> parents, bool fillTriangles)
		: base(entity, parents)
	{
		DataMode = ((!fillTriangles) ? silhoDataType.LineList : silhoDataType.TriangleList);
	}
}
