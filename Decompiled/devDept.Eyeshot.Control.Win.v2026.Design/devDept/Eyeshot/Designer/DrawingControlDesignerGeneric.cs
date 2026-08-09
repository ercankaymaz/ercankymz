#define WINFORMS
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public class DrawingControlDesignerGeneric<T> : WorkspaceControlDesignerGeneric<T> where T : Drawing
{
	protected internal Drawing Drawing;

	public override DesignerVerbCollection Verbs => new DesignerVerbCollection(new DesignerVerb[1]
	{
		new DesignerVerb(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313335), _0023_003DzH7DNClUywyQi)
	});

	public override DesignerActionListCollection ActionLists => new DesignerActionListCollection
	{
		new DrawingDesignerActionList<T>(this)
	};

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		try
		{
			Workspace = (T)Control;
			Drawing = (Drawing)Control;
		}
		catch (Exception ex)
		{
			throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313419) + ex.StackTrace, ex);
		}
		try
		{
			InitializeServices();
		}
		catch (Exception ex2)
		{
			throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313278) + ex2.StackTrace, ex2);
		}
	}

	public override void IntializeViewportAdorner()
	{
	}

	public override void InitializeNewComponent(IDictionary defaultValues)
	{
		Workspace.InitializeViewports();
		base.InitializeNewComponent(defaultValues);
		Workspace.UpdateDesignModeScene();
		Workspace.Invalidate();
	}

	private void _0023_003DzH7DNClUywyQi(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
	}
}
