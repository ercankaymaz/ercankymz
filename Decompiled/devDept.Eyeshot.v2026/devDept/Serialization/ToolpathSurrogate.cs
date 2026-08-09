using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class ToolpathSurrogate : EntitySurrogate
{
	public Point3D[] Vertices;

	public Point3D[] AllVertices;

	public int Tool;

	public List<Toolpath.Motion> MotionList;

	public Color RapidColor;

	public Color LeadColor;

	public Color RampColor;

	public Transformation Transformation;

	[CLSCompliant(false)]
	public ushort RapidPattern;

	public ToolpathSurrogate(Toolpath toolPath)
		: base(toolPath)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return CreateLinearPathOrGhostEntity(AllVertices, typeof(Toolpath));
		}
		Toolpath toolpath = new Toolpath(this);
		CopyDataToObject(toolpath);
		return toolpath;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is Toolpath toolpath)
		{
			toolpath.Vertices = Vertices;
			toolpath.allVertices = AllVertices;
			toolpath.RapidColor = RapidColor;
			toolpath.LeadColor = LeadColor;
			toolpath.RampColor = RampColor;
			toolpath.RapidPattern = RapidPattern;
			toolpath.Transformation = Transformation ?? new Identity();
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Toolpath toolpath = (Toolpath)entity;
		AllVertices = toolpath.allVertices;
		Tool = toolpath.Tool;
		MotionList = toolpath.MotionList;
		RapidColor = toolpath.RapidColor;
		LeadColor = toolpath.LeadColor;
		RampColor = toolpath.RampColor;
		RapidPattern = toolpath.RapidPattern;
		Vertices = toolpath.Vertices;
		Transformation = toolpath.Transformation;
		base.CopyDataFromObject(entity);
	}

	protected override bool CheckSurrogateData(string logMessage = null)
	{
		if ((base.Content != contentType.Geometry && AllVertices == null) || AllVertices.Length == 0)
		{
			WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302672520));
			return false;
		}
		if (base.Content != contentType.Tessellation && (MotionList == null || MotionList.Count == 0))
		{
			WriteLog((logMessage != null) ? logMessage : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673263));
			return false;
		}
		return true;
	}
}
