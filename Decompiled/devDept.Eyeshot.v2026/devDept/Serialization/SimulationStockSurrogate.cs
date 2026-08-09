using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Milling;
using devDept.Geometry;

namespace devDept.Serialization;

public class SimulationStockSurrogate : FastMeshSurrogate
{
	public int RowCount;

	public int ColumnCount;

	public FastMesh[] PlanarFaces;

	public Transformation Transformation;

	public double GridStep;

	public Point3D WorkMin;

	public Point3D WorkMax;

	public SimulationStockSurrogate(SimulationStock ss)
		: base(ss)
	{
	}

	protected override Entity ConvertToObject()
	{
		SimulationStock simulationStock = new SimulationStock(this);
		CopyDataToObject(simulationStock);
		return simulationStock;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		SimulationStock obj = (SimulationStock)entity;
		obj._0023_003DzcXgJLqmScQn6(RowCount);
		obj._0023_003DzbLGjtcnuU4JQ(ColumnCount);
		obj._0023_003DzjVAq6NRHT43AT0faX93DxDI_003D(PlanarFaces);
		obj.GridStep = GridStep;
		obj._0023_003DznTv6jJyUD3Pu(Transformation);
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		SimulationStock simulationStock = (SimulationStock)entity;
		RowCount = simulationStock.RowCount;
		ColumnCount = simulationStock.ColCount;
		PlanarFaces = simulationStock._0023_003Dz5j0tqfhMCbKvunROsGB6t_I_003D();
		Transformation = simulationStock._0023_003DzxdqexKR7jogJ();
		GridStep = simulationStock.GridStep;
		WorkMin = simulationStock.workMin;
		WorkMax = simulationStock.workMax;
		base.CopyDataFromObject(entity);
	}
}
