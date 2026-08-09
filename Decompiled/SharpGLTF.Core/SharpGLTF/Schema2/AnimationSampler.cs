using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.Animations;
using SharpGLTF.Collections;
using SharpGLTF.IO;
using SharpGLTF.Memory;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
internal sealed class AnimationSampler : ExtraProperties, IChildOfList<Animation>, IAnimationSampler<float>, IAnimationSampler<Vector2>, IAnimationSampler<Vector3>, IAnimationSampler<Vector4>, IAnimationSampler<Quaternion>, IAnimationSampler<SparseWeight8>, IAnimationSampler<ArraySegment<float>>, IAnimationSampler<float[]>
{
	public new const string SCHEMANAME = "sampler";

	private int _input;

	private const AnimationInterpolationMode _interpolationDefault = AnimationInterpolationMode.LINEAR;

	private AnimationInterpolationMode? _interpolation = AnimationInterpolationMode.LINEAR;

	private int _output;

	public Animation LogicalParent { get; private set; }

	public int LogicalIndex { get; private set; } = -1;

	public AnimationInterpolationMode InterpolationMode
	{
		get
		{
			return _interpolation.AsValue(AnimationInterpolationMode.LINEAR);
		}
		set
		{
			_interpolation = value.AsNullable(AnimationInterpolationMode.LINEAR);
		}
	}

	public Accessor Input => LogicalParent.LogicalParent.LogicalAccessors[_input];

	public Accessor Output => LogicalParent.LogicalParent.LogicalAccessors[_output];

	public float Duration
	{
		get
		{
			IReadOnlyList<float> readOnlyList = Input.AsScalarArray();
			if (readOnlyList.Count != 0)
			{
				return readOnlyList[readOnlyList.Count - 1];
			}
			return 0f;
		}
	}

	protected override string GetSchemaName()
	{
		return "sampler";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "input";
		yield return "interpolation";
		yield return "output";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "input":
			value = FieldInfo.From("input", this, (AnimationSampler instance) => instance._input);
			return true;
		case "interpolation":
			value = FieldInfo.From("interpolation", this, (AnimationSampler instance) => instance._interpolation.GetValueOrDefault());
			return true;
		case "output":
			value = FieldInfo.From("output", this, (AnimationSampler instance) => instance._output);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "input", _input);
		JsonSerializable.SerializePropertyEnumSymbol(writer, "interpolation", _interpolation, AnimationInterpolationMode.LINEAR);
		JsonSerializable.SerializeProperty(writer, "output", _output);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "input":
			JsonSerializable.DeserializePropertyValue<AnimationSampler, int>(ref reader, this, out _input);
			break;
		case "interpolation":
			_interpolation = JsonSerializable.DeserializePropertyValue<AnimationInterpolationMode>(ref reader);
			break;
		case "output":
			JsonSerializable.DeserializePropertyValue<AnimationSampler, int>(ref reader, this, out _output);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal AnimationSampler()
	{
	}

	internal AnimationSampler(AnimationInterpolationMode interpolation)
	{
		_interpolation = interpolation.AsNullable(AnimationInterpolationMode.LINEAR);
	}

	void IChildOfList<Animation>.SetLogicalParent(Animation parent, int index)
	{
		LogicalParent = parent;
		LogicalIndex = index;
	}

	private Accessor _CreateInputAccessor(IReadOnlyList<float> input)
	{
		Guard.NotNull(input, "input");
		Guard.MustBeGreaterThan(input.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(input.Count * 4);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Input");
		accessor.SetData(buffer, 0, input.Count, AttributeFormat.Float1);
		input._CopyTo(accessor.AsScalarArray());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<float> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(output.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(output.Count * 4);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, output.Count, AttributeFormat.Float1);
		output._CopyTo(accessor.AsScalarArray());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<Vector2> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(output.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(output.Count * 4 * 2);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, output.Count, AttributeFormat.Float2);
		output._CopyTo(accessor.AsVector2Array());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<Vector3> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(output.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(output.Count * 4 * 3);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, output.Count, AttributeFormat.Float3);
		output._CopyTo(accessor.AsVector3Array());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<Vector4> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(output.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(output.Count * 4 * 4);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, output.Count, AttributeFormat.Float4);
		output._CopyTo(accessor.AsVector4Array());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<Quaternion> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(output.Count, 0, "Count");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(output.Count * 4 * 4);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, output.Count, AttributeFormat.Float4);
		output._CopyTo(accessor.AsQuaternionArray());
		accessor.UpdateBounds();
		return accessor;
	}

	private Accessor _CreateOutputAccessor(IReadOnlyList<SparseWeight8> output, int itemsStride)
	{
		return _CreateOutputAccessor(output.Count, itemsStride, (int y, int x) => output[y][x]);
	}

	private Accessor _CreateOutputAccessor<T>(IReadOnlyList<T> output, int itemsStride) where T : IReadOnlyList<float>
	{
		return _CreateOutputAccessor(output.Count, itemsStride, eval);
		float eval(int y, int x)
		{
			T val = output[y];
			if (x >= val.Count)
			{
				return 0f;
			}
			return val[x];
		}
	}

	private Accessor _CreateOutputAccessor(int itemCount, int itemsStride, Func<int, int, float> output)
	{
		Guard.NotNull(output, "output");
		Guard.MustBeGreaterThan(itemCount, 0, "itemCount");
		Guard.MustBeGreaterThan(itemsStride, 0, "itemsStride");
		ModelRoot logicalParent = LogicalParent.LogicalParent;
		BufferView buffer = logicalParent.CreateBufferView(itemCount * 4 * itemsStride);
		Accessor accessor = logicalParent.CreateAccessor("Animation.Output");
		accessor.SetData(buffer, 0, itemCount * itemsStride, AttributeFormat.Float1);
		IList<float> list = accessor.AsScalarArray();
		for (int i = 0; i < itemCount; i++)
		{
			for (int j = 0; j < itemsStride; j++)
			{
				list[i * itemsStride + j] = output(i, j);
			}
		}
		accessor.UpdateBounds();
		return accessor;
	}

	private static (float[] Keys, TValue[] Values) _Split<TValue>(IReadOnlyDictionary<float, TValue> keyframes)
	{
		Guard.NotNull(keyframes, "keyframes");
		List<KeyValuePair<float, TValue>> list = keyframes.OrderBy((KeyValuePair<float, TValue> item) => item.Key).ToList();
		float[] array = new float[list.Count];
		TValue[] array2 = new TValue[list.Count];
		for (int num = 0; num < array.Length; num++)
		{
			array[num] = list[num].Key;
			array2[num] = list[num].Value;
		}
		return (Keys: array, Values: array2);
	}

	private static (float[] Keys, TValue[] Values) _Split<TValue>(IReadOnlyDictionary<float, (TValue TangentIn, TValue Value, TValue TangentOut)> keyframes)
	{
		Guard.NotNull(keyframes, "keyframes");
		List<KeyValuePair<float, (TValue, TValue, TValue)>> list = keyframes.OrderBy((KeyValuePair<float, (TValue TangentIn, TValue Value, TValue TangentOut)> item) => item.Key).ToList();
		float[] array = new float[list.Count];
		TValue[] array2 = new TValue[list.Count * 3];
		for (int num = 0; num < array.Length; num++)
		{
			array[num] = list[num].Key;
			array2[num * 3] = list[num].Value.Item1;
			array2[num * 3 + 1] = list[num].Value.Item2;
			array2[num * 3 + 2] = list[num].Value.Item3;
		}
		return (Keys: array, Values: array2);
	}

	internal void SetKeys(IReadOnlyDictionary<float, float> keyframes)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, float[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		float[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2).LogicalIndex;
	}

	internal void SetKeys(IReadOnlyDictionary<float, Vector2> keyframes)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, Vector2[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		Vector2[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2).LogicalIndex;
	}

	internal void SetKeys(IReadOnlyDictionary<float, Vector3> keyframes)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, Vector3[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		Vector3[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2).LogicalIndex;
	}

	internal void SetKeys(IReadOnlyDictionary<float, Vector4> keyframes)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, Vector4[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		Vector4[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2).LogicalIndex;
	}

	internal void SetKeys(IReadOnlyDictionary<float, Quaternion> keyframes)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, Quaternion[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		Quaternion[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2).LogicalIndex;
	}

	internal void SetKeys<TWeights>(IReadOnlyDictionary<float, TWeights> keyframes, int itemsStride) where TWeights : IReadOnlyList<float>
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		GuardAll.MustBeEqualTo(keyframes.Values.Select((TWeights val) => val.Count), itemsStride, "keyframes");
		(float[] Keys, TWeights[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		TWeights[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2, itemsStride).LogicalIndex;
	}

	internal void SetKeys(IReadOnlyDictionary<float, SparseWeight8> keyframes, int itemsStride)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		(float[] Keys, SparseWeight8[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		SparseWeight8[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2, itemsStride).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (float TangentIn, float Value, float TangentOut)> keyframes)
	{
		Guard.NotNull(keyframes, "keyframes");
		Guard.MustBeGreaterThan(keyframes.Count, 0, "Count");
		var (input, array) = _Split(keyframes);
		array[0] = 0f;
		array[^1] = 0f;
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (Vector2 TangentIn, Vector2 Value, Vector2 TangentOut)> keyframes)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(keyframes, "keyframes");
		Guard.MustBeGreaterThan(keyframes.Count, 0, "Count");
		var (input, array) = _Split(keyframes);
		array[0] = Vector2.Zero;
		array[^1] = Vector2.Zero;
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (Vector3 TangentIn, Vector3 Value, Vector3 TangentOut)> keyframes)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(keyframes, "keyframes");
		Guard.MustBeGreaterThan(keyframes.Count, 0, "Count");
		var (input, array) = _Split(keyframes);
		array[0] = Vector3.Zero;
		array[^1] = Vector3.Zero;
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (Vector4 TangentIn, Vector4 Value, Vector4 TangentOut)> keyframes)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(keyframes, "keyframes");
		Guard.MustBeGreaterThan(keyframes.Count, 0, "Count");
		var (input, array) = _Split(keyframes);
		array[0] = Vector4.Zero;
		array[^1] = Vector4.Zero;
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (Quaternion TangentIn, Quaternion Value, Quaternion TangentOut)> keyframes)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		var (input, array) = _Split(keyframes);
		array[0] = default(Quaternion);
		array[^1] = default(Quaternion);
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array).LogicalIndex;
	}

	internal void SetCubicKeys<TWeights>(IReadOnlyDictionary<float, (TWeights TangentIn, TWeights Value, TWeights TangentOut)> keyframes, int expandedCount) where TWeights : IReadOnlyList<float>
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		Guard.MustBeGreaterThan(expandedCount, 0, "expandedCount");
		(float[] Keys, TWeights[] Values) tuple = _Split(keyframes);
		float[] item = tuple.Keys;
		TWeights[] item2 = tuple.Values;
		_input = _CreateInputAccessor(item).LogicalIndex;
		_output = _CreateOutputAccessor(item2, expandedCount).LogicalIndex;
	}

	internal void SetCubicKeys(IReadOnlyDictionary<float, (SparseWeight8 TangentIn, SparseWeight8 Value, SparseWeight8 TangentOut)> keyframes, int expandedCount)
	{
		Guard.NotNullOrEmpty(keyframes, "keyframes");
		Guard.MustBeGreaterThan(expandedCount, 0, "expandedCount");
		var (input, array) = _Split(keyframes);
		array[0] = default(SparseWeight8);
		array[^1] = default(SparseWeight8);
		_input = _CreateInputAccessor(input).LogicalIndex;
		_output = _CreateOutputAccessor(array, expandedCount).LogicalIndex;
	}

	IEnumerable<(float, float)> IAnimationSampler<float>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<float> second = Output.AsScalarArray();
		return first.Zip(second, (float key, float val) => (key: key, val: val));
	}

	IEnumerable<(float, Vector2)> IAnimationSampler<Vector2>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<Vector2> second = Output.AsVector2Array();
		return first.Zip(second, (float key, Vector2 val) => (key: key, val: val));
	}

	IEnumerable<(float, Vector3)> IAnimationSampler<Vector3>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<Vector3> second = Output.AsVector3Array();
		return first.Zip(second, (float key, Vector3 val) => (key: key, val: val));
	}

	IEnumerable<(float, Vector4)> IAnimationSampler<Vector4>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<Vector4> second = Output.AsVector4Array();
		return first.Zip(second, (float key, Vector4 val) => (key: key, val: val));
	}

	IEnumerable<(float, Quaternion)> IAnimationSampler<Quaternion>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<Quaternion> second = Output.AsQuaternionArray();
		return first.Zip(second, (float key, Quaternion val) => (key: key, val: val));
	}

	IEnumerable<(float, SparseWeight8)> IAnimationSampler<SparseWeight8>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / Input.Count;
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<float[]> second = Output.AsMultiArray(dimensions);
		return first.Zip(second, (float key, float[] val) => (key: key, SparseWeight8.Create(val)));
	}

	IEnumerable<(float, ArraySegment<float>)> IAnimationSampler<ArraySegment<float>>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / Input.Count;
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<float[]> second = Output.AsMultiArray(dimensions);
		return first.Zip(second, (float key, float[] val) => (key: key, new ArraySegment<float>(val)));
	}

	IEnumerable<(float, float[])> IAnimationSampler<float[]>.GetLinearKeys()
	{
		Guard.IsFalse(InterpolationMode == AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / Input.Count;
		IAccessorArray<float> first = Input.AsScalarArray();
		IAccessorArray<float[]> second = Output.AsMultiArray(dimensions);
		return first.Zip(second, (float key, float[] val) => (key: key, val: val));
	}

	IEnumerable<(float, (float, float, float))> IAnimationSampler<float>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(float, float, float)> second = _GroupByTangentValueTangent(Output.AsScalarArray());
		return first.Zip<float, (float, float, float), (float, (float, float, float))>(second, (float key, (float TangentIn, float Value, float TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (Vector2, Vector2, Vector2))> IAnimationSampler<Vector2>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(Vector2, Vector2, Vector2)> second = _GroupByTangentValueTangent(Output.AsVector2Array());
		return first.Zip<float, (Vector2, Vector2, Vector2), (float, (Vector2, Vector2, Vector2))>(second, (float key, (Vector2 TangentIn, Vector2 Value, Vector2 TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (Vector3, Vector3, Vector3))> IAnimationSampler<Vector3>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(Vector3, Vector3, Vector3)> second = _GroupByTangentValueTangent(Output.AsVector3Array());
		return first.Zip<float, (Vector3, Vector3, Vector3), (float, (Vector3, Vector3, Vector3))>(second, (float key, (Vector3 TangentIn, Vector3 Value, Vector3 TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (Vector4, Vector4, Vector4))> IAnimationSampler<Vector4>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(Vector4, Vector4, Vector4)> second = _GroupByTangentValueTangent(Output.AsVector4Array());
		return first.Zip<float, (Vector4, Vector4, Vector4), (float, (Vector4, Vector4, Vector4))>(second, (float key, (Vector4 TangentIn, Vector4 Value, Vector4 TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (Quaternion, Quaternion, Quaternion))> IAnimationSampler<Quaternion>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(Quaternion, Quaternion, Quaternion)> second = _GroupByTangentValueTangent(Output.AsQuaternionArray());
		return first.Zip<float, (Quaternion, Quaternion, Quaternion), (float, (Quaternion, Quaternion, Quaternion))>(second, (float key, (Quaternion TangentIn, Quaternion Value, Quaternion TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (float[], float[], float[]))> IAnimationSampler<float[]>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / (Input.Count * 3);
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(float[], float[], float[])> second = _GroupByTangentValueTangent(Output.AsMultiArray(dimensions));
		return first.Zip<float, (float[], float[], float[]), (float, (float[], float[], float[]))>(second, (float key, (float[] TangentIn, float[] Value, float[] TangentOut) val) => (key: key, val: val));
	}

	IEnumerable<(float, (ArraySegment<float>, ArraySegment<float>, ArraySegment<float>))> IAnimationSampler<ArraySegment<float>>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / (Input.Count * 3);
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(float[], float[], float[])> second = _GroupByTangentValueTangent(Output.AsMultiArray(dimensions));
		return first.Zip<float, (float[], float[], float[]), (float, (ArraySegment<float>, ArraySegment<float>, ArraySegment<float>))>(second, (float key, (float[] TangentIn, float[] Value, float[] TangentOut) val) => (key: key, (new ArraySegment<float>(val.TangentIn), new ArraySegment<float>(val.Value), new ArraySegment<float>(val.TangentOut))));
	}

	IEnumerable<(float, (SparseWeight8, SparseWeight8, SparseWeight8))> IAnimationSampler<SparseWeight8>.GetCubicKeys()
	{
		Guard.IsFalse(InterpolationMode != AnimationInterpolationMode.CUBICSPLINE, "InterpolationMode");
		int dimensions = Output.Count / (Input.Count * 3);
		IAccessorArray<float> first = Input.AsScalarArray();
		IEnumerable<(float[], float[], float[])> second = _GroupByTangentValueTangent(Output.AsMultiArray(dimensions));
		return first.Zip<float, (float[], float[], float[]), (float, (SparseWeight8, SparseWeight8, SparseWeight8))>(second, (float key, (float[] TangentIn, float[] Value, float[] TangentOut) val) => (key: key, SparseWeight8.AsTuple(val.TangentIn, val.Value, val.TangentOut)));
	}

	ICurveSampler<float> IAnimationSampler<float>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<float>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<float>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<float>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<Vector2> IAnimationSampler<Vector2>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<Vector2>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<Vector2>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<Vector2>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<Vector3> IAnimationSampler<Vector3>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<Vector3>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<Vector3>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<Vector3>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<Vector4> IAnimationSampler<Vector4>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<Vector4>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<Vector4>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<Vector4>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<Quaternion> IAnimationSampler<Quaternion>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<Quaternion>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<Quaternion>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<Quaternion>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<SparseWeight8> IAnimationSampler<SparseWeight8>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<SparseWeight8>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<SparseWeight8>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<SparseWeight8>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<float[]> IAnimationSampler<float[]>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<float[]>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<float[]>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<float[]>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	ICurveSampler<ArraySegment<float>> IAnimationSampler<ArraySegment<float>>.CreateCurveSampler(bool isolateMemory)
	{
		return InterpolationMode switch
		{
			AnimationInterpolationMode.STEP => ((IAnimationSampler<ArraySegment<float>>)this).GetLinearKeys().CreateSampler(isLinear: false, isolateMemory), 
			AnimationInterpolationMode.LINEAR => ((IAnimationSampler<ArraySegment<float>>)this).GetLinearKeys().CreateSampler(isLinear: true, isolateMemory), 
			AnimationInterpolationMode.CUBICSPLINE => ((IAnimationSampler<ArraySegment<float>>)this).GetCubicKeys().CreateSampler(isolateMemory), 
			_ => throw new NotImplementedException(), 
		};
	}

	private static IEnumerable<(T TangentIn, T Value, T TangentOut)> _GroupByTangentValueTangent<T>(IEnumerable<T> collection)
	{
		using IEnumerator<T> ptr = collection.GetEnumerator();
		while (ptr.MoveNext())
		{
			T current = ptr.Current;
			if (!ptr.MoveNext())
			{
				break;
			}
			T current2 = ptr.Current;
			if (!ptr.MoveNext())
			{
				break;
			}
			T current3 = ptr.Current;
			yield return (TangentIn: current, Value: current2, TangentOut: current3);
		}
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		base.OnValidateReferences(validate);
		validate.IsNullOrIndex("Input", _input, LogicalParent.LogicalParent.LogicalAccessors).IsNullOrIndex("Output", _output, LogicalParent.LogicalParent.LogicalAccessors);
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		base.OnValidateContent(validate);
		if (Output.Dimensions != DimensionType.SCALAR)
		{
			int num = ((InterpolationMode != AnimationInterpolationMode.CUBICSPLINE) ? 1 : 3);
			validate.AreEqual("Output", Output.Count, Input.Count * num);
		}
		Input.ValidateAnimationInput(validate);
		Output.ValidateAnimationOutput(validate);
	}
}
