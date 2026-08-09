using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;

namespace buCadCamResVer5.Editor;

public abstract class ProjectionInfo
{
	[CompilerGenerated]
	private static Color color_0 = Color.BlueViolet;

	public static Color ProjectedCurvesColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public static void SetAttributesProjectedCurve(Entity entity, float thickness)
	{
		entity.ColorMethod = colorMethodType.byEntity;
		entity.Color = ProjectedCurvesColor;
		entity.LineWeightMethod = colorMethodType.byEntity;
		entity.LineWeight = thickness;
	}
}
