using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Graphics;

namespace devDept.Eyeshot;

internal class PreProcessSilhouettesParams : GraphicsEnvironmentParams
{
	public IList<Entity> Entities;

	internal List<Tuple<Stack<BlockReference>, Entity>> EntitiesToHide;

	public FrustumParams FrustumParams;

	public Camera Camera;

	public double FontTolerance;

	public Document Document;

	public bool CheckFrustum;

	public GfxAttributesWire Attributes;

	public LineTypeKeyedCollection LineTypes;

	public LayerKeyedCollection Layers;

	public MaterialKeyedCollection Materials;

	public bool FillTexts;

	public bool FillRegions;

	public bool KeepHiddenSegments;

	internal bool CollectTextsOnly;

	internal float ViewScale = 1f;

	public BlockKeyedCollection Blocks { get; set; }

	public Stack<BlockReference> Parents { get; set; }

	public attributeReferenceVisibilityType AttributeReferenceVisibilityMode { get; set; } = attributeReferenceVisibilityType.Normal;
}
