using System.Collections.Generic;
using buClass;
using buEyeBaseVer5.Apps;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Cutter;

public class CutterPart
{
	public Entity Cut = null;

	public List<Entity> Drill = new List<Entity>();

	public List<Entity> RopeDirection = new List<Entity>();

	public List<Entity> InnerCut = new List<Entity>();

	public List<Entity> InnerNoCut = new List<Entity>();

	public List<Entity> Plotter1 = new List<Entity>();

	public List<Entity> Plotter2 = new List<Entity>();

	public List<Entity> textInfoEntities = new List<Entity>();

	public List<Entity> textPartInfoEntities = new List<Entity>();

	public List<Entity> NotchEntities = new List<Entity>();

	public Point3D pntMin = new Point3D();

	public Point3D pntMax = new Point3D();

	public List<CutterNotch> Notch = new List<CutterNotch>();

	public List<RulStrectPoints> StrectPntCut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntInnerCut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntDrillCut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntRopeDirCut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntInnerNoCut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntPloter1Cut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntPloter2Cut = new List<RulStrectPoints>();

	public List<RulStrectPoints> StrectPntNotch = new List<RulStrectPoints>();
}
