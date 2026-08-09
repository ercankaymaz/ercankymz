using System;
using System.Diagnostics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("LightContent => {_Light}")]
internal class LightContent : ICloneable, Schema2SceneBuilder.IOperator<Node>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LightBuilder _Light;

	public LightBuilder Light
	{
		get
		{
			return _Light;
		}
		set
		{
			_Light = value;
		}
	}

	public LightContent(LightBuilder light)
	{
		_Light = light;
	}

	public object Clone()
	{
		return new LightContent(this);
	}

	private LightContent(LightContent other)
	{
		_Light = other._Light?.Clone();
	}

	void Schema2SceneBuilder.IOperator<Node>.ApplyTo(Node dstNode, Schema2SceneBuilder context)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		if (_Light is LightBuilder.Directional directional)
		{
			if (dstNode.Camera != null)
			{
				dstNode = dstNode.CreateNode();
			}
			dstNode.PunctualLight = dstNode.LogicalParent.CreatePunctualLight(PunctualLightType.Directional);
			dstNode.PunctualLight.Color = directional.Color;
			dstNode.PunctualLight.Intensity = directional.Intensity;
		}
		if (_Light is LightBuilder.Point point)
		{
			if (dstNode.Camera != null)
			{
				dstNode = dstNode.CreateNode();
			}
			dstNode.PunctualLight = dstNode.LogicalParent.CreatePunctualLight(PunctualLightType.Point);
			dstNode.PunctualLight.Color = point.Color;
			dstNode.PunctualLight.Intensity = point.Intensity;
			dstNode.PunctualLight.Range = point.Range;
		}
		if (_Light is LightBuilder.Spot spot)
		{
			if (dstNode.Camera != null)
			{
				dstNode = dstNode.CreateNode();
			}
			dstNode.PunctualLight = dstNode.LogicalParent.CreatePunctualLight(PunctualLightType.Spot);
			dstNode.PunctualLight.Color = spot.Color;
			dstNode.PunctualLight.Intensity = spot.Intensity;
			dstNode.PunctualLight.Range = spot.Range;
			dstNode.PunctualLight.SetSpotCone(spot.InnerConeAngle, spot.OuterConeAngle);
		}
	}
}
