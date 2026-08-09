using System.Collections.Generic;

namespace SharpGLTF.Geometry.VertexTypes;

public sealed class VertexPreprocessor<TvG, TvM, TvS> where TvG : struct, IVertexGeometry where TvM : struct, IVertexMaterial where TvS : struct, IVertexSkinning
{
	private readonly List<VertexGeometryPreprocessor<TvG>> _GeometryPreprocessor = new List<VertexGeometryPreprocessor<TvG>>();

	private readonly List<VertexMaterialPreprocessor<TvM>> _MaterialPreprocessor = new List<VertexMaterialPreprocessor<TvM>>();

	private readonly List<VertexSkinningPreprocessor<TvS>> _SkinningPreprocessor = new List<VertexSkinningPreprocessor<TvS>>();

	public void Clear()
	{
		_GeometryPreprocessor.Clear();
		_MaterialPreprocessor.Clear();
		_SkinningPreprocessor.Clear();
	}

	public void Append(VertexGeometryPreprocessor<TvG> func)
	{
		_GeometryPreprocessor.Add(func);
	}

	public void Append(VertexMaterialPreprocessor<TvM> func)
	{
		_MaterialPreprocessor.Add(func);
	}

	public void Append(VertexSkinningPreprocessor<TvS> func)
	{
		_SkinningPreprocessor.Add(func);
	}

	public void SetValidationPreprocessors()
	{
		Clear();
		Append((VertexGeometryPreprocessor<TvG>)VertexPreprocessorLambdas.ValidateVertexGeometry);
		Append((VertexMaterialPreprocessor<TvM>)VertexPreprocessorLambdas.ValidateVertexMaterial);
		Append((VertexSkinningPreprocessor<TvS>)VertexPreprocessorLambdas.ValidateVertexSkinning);
	}

	public void SetSanitizerPreprocessors()
	{
		Clear();
		Append((VertexGeometryPreprocessor<TvG>)VertexPreprocessorLambdas.SanitizeVertexGeometry);
		Append((VertexMaterialPreprocessor<TvM>)VertexPreprocessorLambdas.SanitizeVertexMaterial);
		Append((VertexSkinningPreprocessor<TvS>)VertexPreprocessorLambdas.SanitizeVertexSkinning);
	}

	public bool PreprocessVertex(ref VertexBuilder<TvG, TvM, TvS> vertex)
	{
		foreach (VertexGeometryPreprocessor<TvG> item in _GeometryPreprocessor)
		{
			TvG? val = item(vertex.Geometry);
			if (!val.HasValue)
			{
				return false;
			}
			vertex.Geometry = val.Value;
		}
		foreach (VertexMaterialPreprocessor<TvM> item2 in _MaterialPreprocessor)
		{
			TvM? val2 = item2(vertex.Material);
			if (!val2.HasValue)
			{
				return false;
			}
			vertex.Material = val2.Value;
		}
		foreach (VertexSkinningPreprocessor<TvS> item3 in _SkinningPreprocessor)
		{
			TvS? val3 = item3(vertex.Skinning);
			if (!val3.HasValue)
			{
				return false;
			}
			vertex.Skinning = val3.Value;
		}
		return true;
	}
}
