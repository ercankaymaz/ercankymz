using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SharpGLTF.Transforms;

namespace SharpGLTF.Runtime;

public sealed class SceneInstance : IReadOnlyList<DrawableInstance>, IEnumerable<DrawableInstance>, IEnumerable, IReadOnlyCollection<DrawableInstance>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly ArmatureInstance _Armature;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly DrawableTemplate[] _DrawableReferences;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IGeometryTransform[] _DrawableTransforms;

	public ArmatureInstance Armature => _Armature;

	public int Count => _DrawableTransforms.Length;

	public DrawableInstance this[int index] => GetDrawableInstance(index);

	[Obsolete("Use .Count", true)]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int DrawableInstancesCount => Count;

	[Obsolete("use <this>", true)]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public IEnumerable<DrawableInstance> DrawableInstances
	{
		get
		{
			int i = 0;
			while (i < Count)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}
	}

	internal SceneInstance(ArmatureTemplate armature, DrawableTemplate[] drawables)
	{
		SharpGLTF.Guard.NotNull(armature, "armature");
		SharpGLTF.Guard.NotNull(drawables, "drawables");
		_Armature = new ArmatureInstance(armature);
		_DrawableReferences = drawables;
		_DrawableTransforms = new IGeometryTransform[_DrawableReferences.Length];
		for (int i = 0; i < _DrawableTransforms.Length; i++)
		{
			_DrawableTransforms[i] = _DrawableReferences[i].CreateGeometryTransform();
		}
	}

	public DrawableInstance GetDrawableInstance(int index)
	{
		DrawableTemplate drawableTemplate = _DrawableReferences[index];
		drawableTemplate.UpdateGeometryTransform(_DrawableTransforms[index], _Armature);
		return new DrawableInstance(drawableTemplate, _DrawableTransforms[index]);
	}

	public IEnumerator<DrawableInstance> GetEnumerator()
	{
		int i = 0;
		while (i < Count)
		{
			yield return this[i];
			int num = i + 1;
			i = num;
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		int i = 0;
		while (i < Count)
		{
			yield return this[i];
			int num = i + 1;
			i = num;
		}
	}
}
