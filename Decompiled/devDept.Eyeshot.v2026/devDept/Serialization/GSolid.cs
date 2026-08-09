using System;
using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

[Serializable]
internal class GSolid : GEntity
{
	[Serializable]
	internal class Portion : GMesh
	{
		public int Id;

		public Solid.EdgeData[] EdgeDatas;

		public Solid.Face[] Faces;

		public Solid.Cycle[] Cycles;

		public int VertexCount;

		public int EdgeCount;

		public int FaceCount;

		public int ContourCount;

		public int MaxNov;

		public int MaxNoe;

		public int MaxNof;

		public int MaxNoc;

		public int NovTemp;

		public List<IndexLine> IsoCurves;

		public override GEntitySurrogate ConvertToSurrogate()
		{
			return new GPortionSurrogate(this);
		}
	}

	public Solid.brepType BRepMode;

	public TextureMappingData TextureMapping;

	public List<Portion> Portions;

	public double SmoothingAngle;

	public override GEntitySurrogate ConvertToSurrogate()
	{
		return new GSolidSurrogate(this);
	}
}
