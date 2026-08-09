#define WINFORMS
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public class DesignControlDesignerGeneric<T> : WorkspaceControlDesignerGeneric<T> where T : Design
{
	protected internal Design Design;

	public override DesignerVerbCollection Verbs => new DesignerVerbCollection(new DesignerVerb[1]
	{
		new DesignerVerb(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313335), _0023_003DzH7DNClUywyQi)
	});

	public override DesignerActionListCollection ActionLists => new DesignerActionListCollection
	{
		new DesignDesignerActionList<T>(this)
	};

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		try
		{
			Workspace = (T)Control;
			Design = (Design)Control;
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
		Adorner adorner = new Adorner();
		_0023_003DzvVRIqXnU6BzU.Adorners.Add(adorner);
		adorners.Add(InitializeUIElementAdorner(adorner));
	}

	public override void InitializeNewComponent(IDictionary defaultValues)
	{
		Design.InitializeViewports();
		Design.Tag = _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313235);
		base.InitializeNewComponent(defaultValues);
		if (!(Design is _0023_003Dz9yvIszad5kdpzWqoamfk8q5NGEfFxXmFXXZrywI_003D))
		{
			try
			{
				if (PresetManager.ShowWhenDropped)
				{
					PresetManager presetManager = new PresetManager(Design);
					presetManager.ShowDialog();
					presetManager.SetTheme(Design);
				}
			}
			catch
			{
			}
		}
		Design.UpdateDesignModeScene();
		Design.Invalidate();
	}

	private void _0023_003DzH7DNClUywyQi(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
	}

	internal void _0023_003DzhEmAtIyGka69()
	{
		PresetManager presetManager = new PresetManager(Design);
		PresetManager.AdjustScalingLevel(presetManager);
		if (presetManager.ShowDialog() == DialogResult.OK)
		{
			presetManager.SetTheme(Design);
			PropertyDescriptor member = TypeDescriptor.GetProperties(typeof(Workspace))[_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313322)];
			_0023_003DzwIQfEZg_003D.OnComponentChanging(Design, member);
			_0023_003DzwIQfEZg_003D.OnComponentChanged(Design, member, null, null);
			Design.UpdateDesignModeScene();
			Design.Invalidate();
		}
	}

	internal void _0023_003Dzi0rsks0_003D()
	{
		if (Design.Viewports.Count == 0)
		{
			Design.InitializeViewports();
		}
		VisualControlDesigner visualControlDesigner = new VisualControlDesigner(Design);
		if (visualControlDesigner.ShowDialog() == DialogResult.OK)
		{
			if (visualControlDesigner.Design.Viewports.Count == 0)
			{
				Design.Viewports.Clear();
			}
			else
			{
				VisualControlDesigner._0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(visualControlDesigner.Design, Design);
			}
			Design.UpdateDesignModeScene();
			PropertyDescriptor member = TypeDescriptor.GetProperties(typeof(Design))[_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313322)];
			_0023_003DzwIQfEZg_003D.OnComponentChanging(Design, member);
			_0023_003DzwIQfEZg_003D.OnComponentChanged(Design, member, null, null);
			Design.Invalidate();
		}
		visualControlDesigner.Dispose();
	}
}
