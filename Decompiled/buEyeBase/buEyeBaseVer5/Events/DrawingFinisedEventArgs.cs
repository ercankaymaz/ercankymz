using System;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Events;

[Serializable]
public class DrawingFinisedEventArgs
{
	public int DrawingIndex = -1;

	public Entity FinshedEntity = null;
}
