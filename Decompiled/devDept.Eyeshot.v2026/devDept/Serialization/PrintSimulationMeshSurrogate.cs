using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class PrintSimulationMeshSurrogate : MultiFastMeshSurrogate
{
	internal PrintSimulationMesh.MotionRange[] motionsByLevel;

	internal Dictionary<string, Color> styleColors;

	internal PrintSimulationMesh.MotionRangeStyle[] styleRanges;

	internal PrintSimulationMesh.MotionRangeStyle[] styleRangesToDraw;

	public PrintSimulationMeshSurrogate(PrintSimulationMesh psm)
		: base(psm)
	{
	}

	protected override Entity ConvertToObject()
	{
		PrintSimulationMesh printSimulationMesh = new PrintSimulationMesh(this);
		CopyDataToObject(printSimulationMesh);
		return printSimulationMesh;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		PrintSimulationMesh printSimulationMesh = (PrintSimulationMesh)entity;
		motionsByLevel = PrintSimulationMesh._0023_003Dzvv6hJ9KR6NHc(printSimulationMesh.MotionsByLayer).ToArray();
		styleColors = printSimulationMesh._0023_003Dz5uTfw_0024M6HLKSYSW8iw_003D_003D();
		styleRanges = PrintSimulationMesh._0023_003DzVwW60Dtlh1G8E_4Wi06KgZQ_003D(printSimulationMesh._0023_003DzIo59z2K4DQp5kDt43JpS3MDl6pOU()).ToArray();
		styleRangesToDraw = PrintSimulationMesh._0023_003DzVwW60Dtlh1G8E_4Wi06KgZQ_003D(printSimulationMesh._0023_003DzbUCR7FseKe01IU_0024huL_0mjaYYckaZbWYmw_003D_003D()).ToArray();
		base.CopyDataFromObject(entity);
	}
}
