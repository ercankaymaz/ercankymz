using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot;

internal class NestedEntity : Entity
{
	private delegate void _0023_003DzvLli_Xkat66RTBa23A_003D_003D<_0023_003DzWWgGxds_003D>(_0023_003DzWWgGxds_003D _0023_003DzELu0Pss_003D) where _0023_003DzWWgGxds_003D : DrawParams;

	private Transformation parentsTransform;

	private readonly bool _parentsTransformIsReversed;

	internal Entity entity;

	internal Stack<BlockReference> parents;

	private bool parentSelected;

	private bool isSelected;

	private double maxScaleFactor = 1.0;

	public bool ForceGray { get; }

	internal override bool UseMaterialTextureLength => entity.UseMaterialTextureLength;

	protected internal override haloType HaloMode => entity.HaloMode;

	public NestedEntity(Entity entity, GfxAttributes accumulatedParentsAttributes, Stack<BlockReference> parents, Transformation parentsTransform, double maxScaleFactor, bool parentSelected, bool isSelected, bool isClippable, bool forceGray)
	{
		this.entity = entity;
		this.parentSelected = parentSelected;
		this.isSelected = isSelected;
		Clippable = isClippable;
		ForceGray = forceGray;
		screenSize = entity.screenSize;
		base.entityNature = entity.entityNature;
		this.parents = Utility.CloneStack(parents);
		this.parentsTransform = parentsTransform;
		_parentsTransformIsReversed = parentsTransform != null && parentsTransform.HasReflection;
		_0023_003Dzz6CGSI8_003D(accumulatedParentsAttributes, entity.LayerName, entity.LineTypeScale);
		this.maxScaleFactor = maxScaleFactor;
		InitBoundingBox(parentsTransform);
	}

	public NestedEntity(SelectedItem item, LayerKeyedCollection layers, BlockKeyedCollection blocks, MaterialKeyedCollection materials, bool isSelected = true)
	{
		parentsTransform = new Identity();
		entity = (Entity)item.Item;
		this.isSelected = isSelected;
		base.entityNature = entity.entityNature;
		GfxAttributesRendered gfxAttributesRendered = new GfxAttributesRendered(layers);
		if (item.Parents.Count > 0)
		{
			parents = Utility.CloneStack(item.Parents);
			foreach (BlockReference parent in parents)
			{
				parentsTransform = parent.GetFullTransformation(blocks) * parentsTransform;
				gfxAttributesRendered.Propagate(parent, layers[parent.LayerName], materials);
			}
		}
		else
		{
			parents = new Stack<BlockReference>();
		}
		_parentsTransformIsReversed = parentsTransform.HasReflection;
		gfxAttributesRendered.Propagate(entity, layers[entity.LayerName], materials);
		_0023_003Dzz6CGSI8_003D(gfxAttributesRendered, entity.LayerName, entity.LineTypeScale);
		maxScaleFactor = parentsTransform.MaxAbsScaleFactor;
	}

	internal static bool IsGrayMinFr(Entity ent)
	{
		if (ent is NestedEntity nestedEntity)
		{
			return nestedEntity.ForceGray;
		}
		return false;
	}

	private void InitBoundingBox(Transformation tr)
	{
		if (tr != null && !tr.IsIdentity())
		{
			localMin = tr * entity.localMin;
			localMax = tr * entity.localMax;
			sphereCenter = tr * entity.sphereCenter;
			sphereRadius = entity.sphereRadius * maxScaleFactor;
		}
		else
		{
			localMin = entity.localMin;
			localMax = entity.localMax;
			sphereCenter = entity.sphereCenter;
			sphereRadius = entity.sphereRadius;
		}
		regenMode = regenType.NotNeeded;
	}

	internal override bool AvoidSmallSizeCulling()
	{
		return entity.AvoidSmallSizeCulling();
	}

	internal override bool IsSelected(Stack<BlockReference> parents, selectionStatusType selectionStatus)
	{
		return isSelected;
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForFlat(DrawParams data)
	{
		return entity.GetPrimitiveTypeForFlat(data);
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForWireframe(DrawParams data)
	{
		return entity.GetPrimitiveTypeForWireframe(data);
	}

	internal override shaderPrimitiveType GetPrimitiveTypeForHiddenLines(DrawParams data)
	{
		return entity.GetPrimitiveTypeForHiddenLines(data);
	}

	private void DrawWithMatrix<T>(_0023_003DzvLli_Xkat66RTBa23A_003D_003D<T> myDrawFunc, T data) where T : DrawParams
	{
		Stack<BlockReference> stack = data.Parents;
		float screenToWorld = data.ScreenToWorld;
		Transformation transformation = data.Transformation;
		bool flag = data.ParentSelected;
		bool parentClippable = data.ParentClippable;
		bool forceGray = data.ForceGray;
		bool frontFaceCW = data.RenderContext.FrontFaceCW;
		if (parentsTransform != null)
		{
			if (!data.viewportInternal.parent.skipMoveTo)
			{
				data.RenderContext.PushModelView();
				data.RenderContext.MultMatrixModelView(parentsTransform);
			}
			data.Transformation = ((data.Transformation != null) ? (data.Transformation * parentsTransform) : parentsTransform);
		}
		data.Parents = parents;
		T val = data;
		float screenToWorld2 = val.ScreenToWorld / (float)maxScaleFactor;
		val.ScreenToWorld = screenToWorld2;
		data.ParentSelected = parentSelected;
		data.ForceGray = ForceGray;
		if (_parentsTransformIsReversed)
		{
			data.RenderContext.FrontFaceCW = true;
		}
		Transformation blockRefTransform = null;
		bool flag2 = false;
		if (data.ShaderParams != null && (data.ShaderParams.DoShadows || data.PlanarReflections) && data.ShaderParams.BlockRefTransform != null && data.Transformation != null)
		{
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			data.ShaderParams.BlockRefTransform = data.Transformation;
			flag2 = true;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
		if (data.viewportInternal.parent.Document is DrawingDocument)
		{
			data.Attributes.LineTypeName = string.Empty;
		}
		myDrawFunc(data);
		data.RenderContext.EndDrawBufferedLines();
		data.Parents = stack;
		data.ScreenToWorld = screenToWorld;
		data.Transformation = transformation;
		data.ParentSelected = flag;
		data.ParentClippable = parentClippable;
		data.ForceGray = forceGray;
		if (_parentsTransformIsReversed)
		{
			data.RenderContext.FrontFaceCW = frontFaceCW;
		}
		if (flag2)
		{
			data.ShaderParams.BlockRefTransform = blockRefTransform;
			data.RenderContext.SetBlockRefTransform(data.ShaderParams.BlockRefTansformMatrix);
		}
		if (parentsTransform != null && !data.viewportInternal.parent.skipMoveTo)
		{
			data.RenderContext.PopModelView();
		}
	}

	protected internal override bool SelectedInternal()
	{
		return entity.SelectedInternal();
	}

	protected internal override void Draw(DrawParams data)
	{
		DrawWithMatrix(entity.Draw, data);
	}

	protected internal override void DrawEdges(DrawParams data)
	{
		DrawWithMatrix(entity.DrawEdges, data);
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams data)
	{
		DrawWithMatrix(entity.DrawSilhouettes, data);
	}

	protected internal override void Render(RenderParams data)
	{
		DrawWithMatrix(entity.Render, data);
	}

	protected internal override void RenderFast(RenderParams data)
	{
		DrawWithMatrix(entity.RenderFast, data);
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		DrawWithMatrix(entity.DrawIsocurves, data);
	}

	protected internal override void DrawIsocurvesForFlat(DrawParams data)
	{
		DrawWithMatrix(entity.DrawIsocurvesForFlat, data);
	}

	protected internal override void DrawDirection(DrawParams data)
	{
		DrawWithMatrix(entity.DrawDirection, data);
	}

	protected internal override void DrawFast(DrawParams data)
	{
		DrawWithMatrix(entity.DrawFast, data);
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		DrawWithMatrix(entity.DrawForShadow, data);
	}

	protected internal override void DrawForDepthPass(DrawParams data)
	{
		DrawWithMatrix(entity.DrawForDepthPass, data);
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		DrawWithMatrix(entity.DrawNormals, data);
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		DrawWithMatrix(entity.DrawSelected, data);
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		DrawWithMatrix(entity.DrawHiddenLines, data);
	}

	protected internal override void DrawHiddenLinesFast(DrawParams data)
	{
		DrawWithMatrix(entity.DrawHiddenLinesFast, data);
	}

	protected internal override void DrawHiddenLinesMaterial(RenderParams data)
	{
		DrawWithMatrix(entity.DrawHiddenLinesMaterial, data);
	}

	protected internal override void DrawHiddenLinesMaterialFast(RenderParams data)
	{
		DrawWithMatrix(entity.DrawHiddenLinesMaterialFast, data);
	}

	protected internal override void DrawWireframe(DrawParams data)
	{
		DrawWithMatrix(entity.DrawWireframe, data);
	}

	protected internal override void DrawWireframeSelected(DrawParams data)
	{
		DrawWithMatrix(entity.DrawWireframeSelected, data);
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		DrawWithMatrix(entity.DrawFlat, data);
	}

	protected internal override void DrawFlatSelected(DrawParams drawParams)
	{
		DrawWithMatrix(entity.DrawFlatSelected, drawParams);
	}

	protected internal override void DrawFlatFast(DrawParams data)
	{
		DrawWithMatrix(entity.DrawFlatFast, data);
	}

	protected internal override void DrawForSelectionFaces(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionFaces, data);
	}

	protected internal override void DrawForSelectionEdges(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionEdges, data);
	}

	protected internal override void DrawForSelectionVertices(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionVertices, data);
	}

	protected internal override void DrawForSelectionSubCurves(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionSubCurves, data);
	}

	protected internal override void DrawForSelectionSubContours(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionSubContours, data);
	}

	protected internal override void DrawForSelectionSketchCurves(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionSketchCurves, data);
	}

	protected internal override void DrawForSelectionSketchPoints(DrawForSelectionParams data)
	{
		DrawWithMatrix(entity.DrawForSelectionSketchPoints, data);
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		DrawWithMatrix(entity.DrawVertices, data);
	}

	protected internal override void DrawSelectedVertices(DrawParams data)
	{
		DrawWithMatrix(entity.DrawSelectedVertices, data);
	}

	public override void SetLineWeight(RenderContextBase renderContext, float lineWeight)
	{
		entity.SetLineWeight(renderContext, lineWeight);
	}

	protected internal override void SetLineWeightForSilhouettes(DrawSilhouettesParams data)
	{
		bool forceGray = data.ForceGray;
		data.ForceGray = ForceGray;
		entity.SetLineWeightForSilhouettes(data);
		data.ForceGray = forceGray;
	}

	protected internal override void SetLineWeightForEdges(DrawParams data)
	{
		bool forceGray = data.ForceGray;
		data.ForceGray = ForceGray;
		entity.SetLineWeightForEdges(data);
		data.ForceGray = forceGray;
	}

	protected internal override void SetShader(DrawParams data)
	{
		bool forceGray = data.ForceGray;
		data.ForceGray = ForceGray;
		entity.SetShader(data);
		data.ForceGray = forceGray;
	}

	public override Point3D[] EstimateBoundingBox(BlockKeyedCollection blocks, LayerKeyedCollection layers)
	{
		throw new NotImplementedException();
	}

	public override object Clone()
	{
		throw new NotImplementedException();
	}

	public override object CloneWithTessellation()
	{
		throw new NotImplementedException();
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		throw new NotImplementedException();
	}

	protected internal override bool IsVisibleAndInFrustum(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		return visibleAndInFrustum;
	}

	protected internal override bool IsVisible(Stack<BlockReference> parents, LayerKeyedCollection layers, attributeReferenceVisibilityType attributeReferenceMode)
	{
		return true;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		return entity.GetAllVertices(data, out verticesCoords);
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		data.PushTransformation(parentsTransform);
		bool result = entity.ComputeBoundingBox(data, out boxMin, out boxMax);
		data.PopTransformation();
		return result;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		data.PushTransformation(parentsTransform);
		entity.ComputeOffsetOnCameraAxes(data);
		data.PopTransformation();
	}
}
