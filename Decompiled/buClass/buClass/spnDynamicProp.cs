using System;
using System.Drawing;

namespace buClass;

[Serializable]
public class spnDynamicProp : buSerilization
{
	public Pnt3D pntMin = new Pnt3D();

	public Pnt3D pntMid = new Pnt3D();

	public Pnt3D pntMax = new Pnt3D();

	public string Caption = "";

	public ContentAlignment Alignment = ContentAlignment.MiddleCenter;

	public bool Focus = true;

	public bool SelectAll = true;

	public bool Visible = false;

	public bool PreVisible = false;
}
