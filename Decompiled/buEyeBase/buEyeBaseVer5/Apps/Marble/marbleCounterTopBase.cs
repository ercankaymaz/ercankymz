using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleCounterTopBase : buSerilization5
{
	public MarbleCountertopTypes CountertopType = MarbleCountertopTypes.RectangleType1;

	public buEntitiesGroup EntitiesGroup = new buEntitiesGroup();

	public Entity SolidEntity = null;

	public marbleCountertopMainPars Main = new marbleCountertopMainPars();

	public List<marbleCounterTopItem> Items = new List<marbleCounterTopItem>();

	public List<marbleCountertopInsidePars> Sinks = new List<marbleCountertopInsidePars>();

	public List<marbleCountertopTapPars> Taps = new List<marbleCountertopTapPars>();

	public List<marbleCountertopCavityPars> Cavitys = new List<marbleCountertopCavityPars>();
}
