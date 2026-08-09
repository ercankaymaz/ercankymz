using System;
using System.Diagnostics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

[DebuggerDisplay("CameraContent => {_Camera}")]
internal class CameraContent : ICloneable, Schema2SceneBuilder.IOperator<Node>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CameraBuilder _Camera;

	public CameraBuilder Camera
	{
		get
		{
			return _Camera;
		}
		set
		{
			_Camera = value;
		}
	}

	public CameraContent(CameraBuilder camera)
	{
		_Camera = camera;
	}

	public object Clone()
	{
		return new CameraContent(this);
	}

	private CameraContent(CameraContent other)
	{
		_Camera = other._Camera?.Clone();
	}

	void Schema2SceneBuilder.IOperator<Node>.ApplyTo(Node dstNode, Schema2SceneBuilder context)
	{
		if (_Camera is CameraBuilder.Orthographic orthographic)
		{
			if (dstNode.Camera != null)
			{
				dstNode = dstNode.CreateNode();
			}
			dstNode.WithOrthographicCamera(orthographic.XMag, orthographic.YMag, orthographic.ZNear, orthographic.ZFar);
		}
		if (_Camera is CameraBuilder.Perspective perspective)
		{
			if (dstNode.Camera != null)
			{
				dstNode = dstNode.CreateNode();
			}
			dstNode.WithPerspectiveCamera(perspective.AspectRatio, perspective.VerticalFOV, perspective.ZNear, perspective.ZFar);
		}
	}
}
