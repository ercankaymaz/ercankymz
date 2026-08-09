namespace SharpGLTF.Geometry.VertexTypes;

public delegate TvM? VertexMaterialPreprocessor<TvM>(TvM arg) where TvM : struct, IVertexMaterial;
