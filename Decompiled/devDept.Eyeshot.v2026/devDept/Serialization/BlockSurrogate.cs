using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

namespace devDept.Serialization;

public class BlockSurrogate : Surrogate<Block>
{
	internal string xRefPath;

	public string Name;

	public Point3D BasePoint;

	public byte Units;

	public List<Entity> Entities;

	public string Description;

	public bool IsResolved;

	public byte MassUnits;

	public string FilePath;

	public ProtoObject CustomData;

	public string XRefName;

	public byte BlockSource;

	public byte ExportMode;

	public List<Mate> MatesList;

	public BlockSurrogate(Block block)
		: base(block)
	{
	}

	protected override Block ConvertToObject()
	{
		Block block = new Block(this);
		CopyDataToObject(block);
		return block;
	}

	protected override void CopyDataToObject(Block block)
	{
		block.Name = Name;
		block.Name = ((!string.IsNullOrEmpty(block.blockNameForExport)) ? block.blockNameForExport : block.Name);
		block.blockNameForExport = null;
		block.BasePoint = BasePoint;
		block.Units = (linearUnitsType)Units;
		block.MassUnits = (massUnitsType)MassUnits;
		block.Description = Description;
		block.IsResolved = IsResolved;
		block._filePath = FilePath;
		block._0023_003Dzp6_0024ma46EnjuJk7zPtQ_003D_003D(MatesList ?? new List<Mate>());
		block.matesGraph = ((block.MatesList.Count == 0) ? null : new _0023_003Dz8MfiwJHarI9u66omqzWP6QqoL2rzmT2nhA_003D_003D(block.MatesList));
		block.XRefName = XRefName;
		if (base.Version < 16 && string.IsNullOrEmpty(block._filePath))
		{
			block._filePath = xRefPath;
		}
		block.BlockSource = (autodeskSourceType)BlockSource;
		block._exportMode = (autodeskExportType)ExportMode;
		if (CustomData != null)
		{
			block.CustomData = CustomData.Object;
		}
		if (Entities != null)
		{
			block.Entities.baseList.AddRange(Entities);
		}
	}

	protected override void CopyDataFromObject(Block block)
	{
		Name = block.Name;
		BasePoint = block.BasePoint;
		Units = (byte)block.Units;
		MassUnits = (byte)block.MassUnits;
		Description = block.Description;
		IsResolved = block.IsResolved;
		FilePath = block.FilePath;
		MatesList = block.MatesList;
		XRefName = block.XRefName;
		BlockSource = (byte)block.BlockSource;
		ExportMode = (byte)block.ExportMode;
		if (block.CustomData != null)
		{
			CustomData = new ProtoObject(block.CustomData);
		}
		Entities = block.Entities.ToList();
	}

	public static implicit operator Block(BlockSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator BlockSurrogate(Block source)
	{
		return source?.ConvertToSurrogate();
	}
}
