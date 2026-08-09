using System;
using System.Collections.Generic;
using System.Numerics;
using SharpGLTF.Animations;
using SharpGLTF.Reflection;
using SharpGLTF.Schema2;

namespace SharpGLTF.Runtime;

internal class MaterialTemplate
{
	private readonly int _LogicalSourceIndex;

	private readonly string _PointerPrefix;

	private readonly Dictionary<string, AnimatableProperty<float>> _ScalarAnimatables;

	private readonly Dictionary<string, AnimatableProperty<Vector2>> _Vector2Animatables;

	private readonly Dictionary<string, AnimatableProperty<Vector3>> _Vector3Animatables;

	private readonly Dictionary<string, AnimatableProperty<Vector4>> _Vector4Animatables;

	private bool _IsAnimated;

	public bool IsAnimated => _IsAnimated;

	public string Name { get; set; }

	public object Extras { get; set; }

	public int LogicalNodeIndex => _LogicalSourceIndex;

	internal MaterialTemplate(Material srcMaterial, RuntimeOptions options)
	{
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		_LogicalSourceIndex = srcMaterial.LogicalIndex;
		Name = srcMaterial.Name;
		Extras = RuntimeOptions.ConvertExtras(srcMaterial, options);
		bool isolateMemory = options?.IsolateMemory ?? false;
		_PointerPrefix = $"/materials/{srcMaterial.LogicalIndex}/";
		_IsAnimated = false;
		foreach (MaterialChannel channel in srcMaterial.Channels)
		{
			foreach (Animation logicalAnimation in srcMaterial.LogicalParent.LogicalAnimations)
			{
				int logicalIndex = logicalAnimation.LogicalIndex;
				IEnumerable<AnimationChannel> enumerable = logicalAnimation.FindChannels(_PointerPrefix);
				foreach (AnimationChannel item in enumerable)
				{
					string targetPointerPath = item.TargetPointerPath;
					targetPointerPath = targetPointerPath.Substring(_PointerPrefix.Length - 1);
					FieldInfo fieldInfo = FieldInfo.From(srcMaterial, targetPointerPath);
					if (fieldInfo.IsEmpty)
					{
						continue;
					}
					if (fieldInfo.Value is float defaultSingle)
					{
						if (_ScalarAnimatables == null)
						{
							_ScalarAnimatables = new Dictionary<string, AnimatableProperty<float>>();
						}
						_AddAnimatableProperty(_ScalarAnimatables, logicalIndex, item, targetPointerPath, defaultSingle, isolateMemory);
					}
					if (fieldInfo.Value is Vector2 defaultSingle2)
					{
						if (_Vector2Animatables == null)
						{
							_Vector2Animatables = new Dictionary<string, AnimatableProperty<Vector2>>();
						}
						_AddAnimatableProperty<Vector2>(_Vector2Animatables, logicalIndex, item, targetPointerPath, defaultSingle2, isolateMemory);
					}
					if (fieldInfo.Value is Vector3 defaultSingle3)
					{
						if (_Vector3Animatables == null)
						{
							_Vector3Animatables = new Dictionary<string, AnimatableProperty<Vector3>>();
						}
						_AddAnimatableProperty<Vector3>(_Vector3Animatables, logicalIndex, item, targetPointerPath, defaultSingle3, isolateMemory);
					}
					if (fieldInfo.Value is Vector4 defaultSingle4)
					{
						if (_Vector4Animatables == null)
						{
							_Vector4Animatables = new Dictionary<string, AnimatableProperty<Vector4>>();
						}
						_AddAnimatableProperty<Vector4>(_Vector4Animatables, logicalIndex, item, targetPointerPath, defaultSingle4, isolateMemory);
					}
				}
			}
		}
	}

	private void _AddAnimatableProperty<T>(Dictionary<string, AnimatableProperty<T>> dict, int trackIdx, AnimationChannel channel, string pointerPath, T defaultSingle, bool isolateMemory) where T : struct
	{
		if (!dict.TryGetValue(pointerPath, out var value))
		{
			value = (dict[pointerPath] = new AnimatableProperty<T>(defaultSingle));
		}
		ICurveSampler<T> curveSampler = channel.GetSamplerOrNull<T>().CreateCurveSampler(isolateMemory);
		value.SetCurve(trackIdx, curveSampler);
		_IsAnimated = true;
	}

	public void UpdateRuntimeMaterial(int trackLogicalIndex, float time, Action<string, float> target)
	{
		foreach (KeyValuePair<string, AnimatableProperty<float>> scalarAnimatable in _ScalarAnimatables)
		{
			float valueAt = scalarAnimatable.Value.GetValueAt(trackLogicalIndex, time);
			target(scalarAnimatable.Key, valueAt);
		}
	}

	public void UpdateRuntimeMaterial(int trackLogicalIndex, float time, Action<string, Vector2> target)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, AnimatableProperty<Vector2>> vector2Animatable in _Vector2Animatables)
		{
			Vector2 valueAt = vector2Animatable.Value.GetValueAt(trackLogicalIndex, time);
			target(vector2Animatable.Key, valueAt);
		}
	}

	public void UpdateRuntimeMaterial(int trackLogicalIndex, float time, Action<string, Vector3> target)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, AnimatableProperty<Vector3>> vector3Animatable in _Vector3Animatables)
		{
			Vector3 valueAt = vector3Animatable.Value.GetValueAt(trackLogicalIndex, time);
			target(vector3Animatable.Key, valueAt);
		}
	}

	public void UpdateRuntimeMaterial(int trackLogicalIndex, float time, Action<string, Vector4> target)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		foreach (KeyValuePair<string, AnimatableProperty<Vector4>> vector4Animatable in _Vector4Animatables)
		{
			Vector4 valueAt = vector4Animatable.Value.GetValueAt(trackLogicalIndex, time);
			target(vector4Animatable.Key, valueAt);
		}
	}
}
