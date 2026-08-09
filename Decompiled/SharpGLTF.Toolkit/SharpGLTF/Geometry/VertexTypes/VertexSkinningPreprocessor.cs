namespace SharpGLTF.Geometry.VertexTypes;

public delegate TvS? VertexSkinningPreprocessor<TvS>(TvS arg) where TvS : struct, IVertexSkinning;
