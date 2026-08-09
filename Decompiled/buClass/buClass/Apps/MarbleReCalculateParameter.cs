using System.Collections.Generic;

namespace buClass.Apps;

public class MarbleReCalculateParameter
{
	public camParameters CamPar = new camParameters();

	public marbleOperation Operation = new marbleOperation();

	public marbleCamParameters CamMarblePar = new marbleCamParameters();

	public List<List<eEntities>> ReCalcEntities = new List<List<eEntities>>();

	public List<List<eEntities>> ReCalcAfterEntities = new List<List<eEntities>>();

	public List<List<Pnt6D>> CalculatedPnt6D = new List<List<Pnt6D>>();

	public int CamIndex = -1;

	public bool Copy = false;
}
