using ModuleWorks;
using buEyeBaseVer5;

namespace buCadCamResVer5.Jewel;

public class JewelMode
{
	public string Name = "Mode";

	public string Prepared = "Noname";

	public GeoLib varMWCamMeshRoughPars = null;

	public camParameters5 varbuCamMeshRoughPars = null;

	public GeoLib varMWCamMeshParalelPars = null;

	public camParameters5 varbuCamMeshParallelPars = null;

	public GeoLib varMWCamMeshContantZPars = null;

	public camParameters5 varbuCamMeshConstantZPars = null;

	public GeoLib varMWCamWFPocketPars = null;

	public camParameters5 varbuCamWFPocketPars = null;

	public GeoLib varMWCamWFContourPars = null;

	public camParameters5 varbuCamWFContourPars = null;

	public GeoLib varMWCamWFContour4XPars = null;

	public camParameters5 varbuCamWFContour4XPars = null;

	public GeoLib varMWCamDrillPars = null;

	public camParameters5 varbuCamDrillPars = null;

	public JewelMode()
	{
	}

	public JewelMode(JewelMode data)
	{
		Name = data.Name;
		Prepared = data.Prepared;
		varbuCamDrillPars = new camParameters5(data.varbuCamDrillPars);
		varbuCamMeshConstantZPars = new camParameters5(data.varbuCamMeshConstantZPars);
		varbuCamMeshParallelPars = new camParameters5(data.varbuCamMeshParallelPars);
		varbuCamMeshRoughPars = new camParameters5(data.varbuCamMeshRoughPars);
		varbuCamWFContour4XPars = new camParameters5(data.varbuCamWFContour4XPars);
		varbuCamWFContourPars = new camParameters5(data.varbuCamWFContourPars);
		varbuCamWFPocketPars = new camParameters5(data.varbuCamWFPocketPars);
	}

	public JewelMode(camParameters5 buDrill, camParameters5 buWF3XContour, camParameters5 buWF4XContour, camParameters5 buWFRough, camParameters5 buTriMeshRough, camParameters5 buTriMeshParalel, camParameters5 buTriMeshConstantZ, GeoLib mwDrill, GeoLib mwWF3XContour, GeoLib mwWF4XContour, GeoLib mwWFRough, GeoLib mwTriMeshRough, GeoLib mwTriMeshParalel, GeoLib mwTriMeshConstantZ)
	{
		varbuCamDrillPars = new camParameters5(buDrill);
		varbuCamMeshConstantZPars = new camParameters5(buTriMeshConstantZ);
		varbuCamMeshParallelPars = new camParameters5(buTriMeshParalel);
		varbuCamMeshRoughPars = new camParameters5(buTriMeshRough);
		varbuCamWFContour4XPars = new camParameters5(buWF4XContour);
		varbuCamWFContourPars = new camParameters5(buWF3XContour);
		varbuCamWFPocketPars = new camParameters5(buWFRough);
	}
}
