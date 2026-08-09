using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

public abstract class UserInterfaceSymbolBase : UserInterfaceBase, ICloneable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected int _0023_003DzgTjCWc4_003D;

	protected const int DefaultSize = 37;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzGIpKXu0_003D = true;

	protected internal bool Dragging;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal EyeshotDisposableCollection<Mesh> _0023_003Dz144AJpBY58Hz;

	protected internal Entity PickedEntity;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzJVnoiNWtZYWm;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzJ25ZVeMUUo9zC1ie9A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz_0024QioUdh1Gg_4_0024i6MshTutG0_003D;

	[Description("Size in pixels of the symbol.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int Size
	{
		get
		{
			return _0023_003DzgTjCWc4_003D;
		}
		set
		{
			if (value < 5)
			{
				value = 5;
			}
			_0023_003DzgTjCWc4_003D = value;
		}
	}

	[Description("Visibility status.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool Visible
	{
		get
		{
			return _0023_003DzGIpKXu0_003D;
		}
		set
		{
			_0023_003Dz2OORaIM_003D(this, value);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public EyeshotDisposableCollection<Mesh> Entities
	{
		get
		{
			return _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D();
		}
		set
		{
			_0023_003DzJ68739VSGtxjhT1AxA_003D_003D(value);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Transformation Transformation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJ25ZVeMUUo9zC1ie9A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJ25ZVeMUUo9zC1ie9A_003D_003D = value;
		}
	}

	public override void ScaleForDPI()
	{
		Size = UtilityEx._0023_003DzowV4NhAf418J(Size, UtilityEx.GetScalingLevel());
	}

	protected SizeF GetScalingLevel()
	{
		return ParentViewport?._0023_003Dz0TvaYNo_003D._0023_003DztnrgTmT5sBNd() ?? UtilityEx.GetScalingLevel();
	}

	private bool _0023_003DzPLlSnOGZ0u5W()
	{
		return Size != 37;
	}

	private void _0023_003Dzo_c5OjY_003D()
	{
		Size = 37;
	}

	internal static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	public abstract void Draw(RenderParams data);

	private static bool _0023_003Dz2OORaIM_003D(UserInterfaceSymbolBase _0023_003Dz3LVOudQ_003D, bool _0023_003DzsLHxXyo_003D)
	{
		if (_0023_003Dz3LVOudQ_003D._0023_003DzGIpKXu0_003D != _0023_003DzsLHxXyo_003D)
		{
			_0023_003Dz3LVOudQ_003D._0023_003DzGIpKXu0_003D = _0023_003DzsLHxXyo_003D;
			_0023_003Dz3LVOudQ_003D.PickedEntity = null;
			_0023_003Dz3LVOudQ_003D._0023_003DzJVnoiNWtZYWm = false;
			_0023_003Dz3LVOudQ_003D._0023_003DzOR76CViJWiUl(_0023_003DzsLHxXyo_003D: false);
			return true;
		}
		return false;
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	protected void SetupLights(Viewport viewport, RenderContextBase renderContext, float attenuation)
	{
		float num = 0.9f * attenuation;
		float[] ambient = new float[4] { 0.075f, 0.075f, 0.075f, 1f };
		float[] diffuse = new float[4] { attenuation, attenuation, attenuation, 1f };
		float[] specular = new float[4] { attenuation, attenuation, attenuation, 1f };
		float[] dir = new float[3] { -0.57735f, 0.57735f, 0.57735f };
		LightSettings lightSettings = new LightSettings();
		lightSettings.Active = true;
		renderContext.SetLightPosition(0, lightType.Directional, dir, null);
		renderContext.SetLightAttributes(0, diffuse, ambient, specular, lightSettings);
		LightSettings lightSettings2 = new LightSettings();
		lightSettings2.Active = true;
		float[] diffuse2 = new float[4] { num, num, num, 1f };
		float[] specular2 = new float[4] { 1f, 1f, 1f, 1f };
		float[] dir2 = new float[3] { 0.707107f, 0f, 0.707107f };
		renderContext.SetLightPosition(1, lightType.Directional, dir2, null);
		renderContext.SetLightAttributes(1, diffuse2, ambient, specular2, lightSettings2);
		renderContext.ActiveLights[0] = lightSettings;
		renderContext.ActiveLights[1] = lightSettings2;
		LightSettings lightSettings3 = new LightSettings();
		lightSettings3.Active = false;
		for (int i = 2; i < viewport._0023_003Dz0TvaYNo_003D._0023_003DzMuApP021PUyU.Length; i++)
		{
			renderContext.SetLightAttributes(i, diffuse, ambient, specular, lightSettings3);
		}
		renderContext.UpdateConstantBufferPerFrame(viewport._0023_003Dzms3vFmj75BNW());
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D() == null)
		{
			return;
		}
		foreach (Mesh item in _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D())
		{
			item.Dispose();
		}
	}

	internal EyeshotDisposableCollection<Mesh> _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()
	{
		return _0023_003Dz144AJpBY58Hz;
	}

	internal void _0023_003DzJ68739VSGtxjhT1AxA_003D_003D(EyeshotDisposableCollection<Mesh> _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz144AJpBY58Hz = _0023_003DzsLHxXyo_003D;
		if (_0023_003DzsLHxXyo_003D != null)
		{
			string defaultLayerName = GetDefaultLayerName();
			{
				foreach (Mesh item in _0023_003DzsLHxXyo_003D)
				{
					item.Visible = true;
					item.LayerName = defaultLayerName;
				}
				return;
			}
		}
		_0023_003Dz144AJpBY58Hz = new EyeshotDisposableCollection<Mesh>();
	}

	protected internal void CheckAndFixDefaultLayerName(Workspace workspace = null)
	{
		Workspace workspace2 = workspace ?? ParentViewport?._0023_003Dz0TvaYNo_003D;
		if (workspace2 == null || Entities == null)
		{
			return;
		}
		foreach (Mesh entity in Entities)
		{
			workspace2.Layers.CheckAndFixDefaultLayerName(entity);
		}
	}

	internal virtual bool _0023_003Dz5jYXZeY_003D(Entity _0023_003DzpWC0efg_003D)
	{
		if (_0023_003Dz_0024vZ0A_0024YRZA_H())
		{
			return false;
		}
		IList<Mesh> list = _0023_003DzE2brWRjSvZMG();
		if (list == null || _0023_003DzJVnoiNWtZYWm)
		{
			return false;
		}
		if (PickedEntity != _0023_003DzpWC0efg_003D)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Selected = false;
			}
			if (_0023_003DzpWC0efg_003D != null)
			{
				_0023_003DzpWC0efg_003D.Selected = true;
			}
			PickedEntity = _0023_003DzpWC0efg_003D;
			return true;
		}
		return false;
	}

	protected internal virtual bool OnMouseDown(MouseEventArgs e, Viewport viewport)
	{
		if (PickedEntity != null)
		{
			_0023_003DzJVnoiNWtZYWm = true;
			return true;
		}
		return false;
	}

	protected internal virtual bool OnMouseUp(MouseEventArgs e, Viewport viewport)
	{
		_0023_003DzJVnoiNWtZYWm = false;
		return true;
	}

	internal virtual IList<Mesh> _0023_003DzE2brWRjSvZMG()
	{
		return _0023_003Dz144AJpBY58Hz;
	}

	internal bool _0023_003Dz_0024vZ0A_0024YRZA_H()
	{
		return _0023_003Dz_0024QioUdh1Gg_4_0024i6MshTutG0_003D;
	}

	internal void _0023_003DzOR76CViJWiUl(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz_0024QioUdh1Gg_4_0024i6MshTutG0_003D = _0023_003DzsLHxXyo_003D;
	}

	internal bool _0023_003Dzh46LtHR_00243Trc(Workspace _0023_003Dz0TvaYNo_003D, Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzaKhuWjzYLRr8, Workspace._0023_003DzhFBmu_0024RpnRJ7 _0023_003DzbOk8RJDeO_0024TX, bool _0023_003DzEsQVjCtIj3aX)
	{
		if (!_0023_003Dz0TvaYNo_003D.hasFocus)
		{
			return false;
		}
		SelectedItem selectedItem;
		if (_0023_003DzEsQVjCtIj3aX)
		{
			selectedItem = null;
		}
		else
		{
			SelectedItem[] array = _0023_003Dz0TvaYNo_003D._0023_003DzqbHFKAkQdkNK4Y2H5A_003D_003D(_0023_003DzYzWi5Yw_003D, _0023_003DzaKhuWjzYLRr8, new List<Entity>(_0023_003DzE2brWRjSvZMG()), _0023_003DzbOk8RJDeO_0024TX, _0023_003Dz_bIfLEkNPFmB: true, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D: true, _0023_003DzCq_00248LrgCN_f9: false);
			selectedItem = ((array.Length != 0) ? array[0] : null);
			_0023_003DzYzWi5Yw_003D.Camera.ZBufferData.Dirty = true;
		}
		return _0023_003Dz5jYXZeY_003D((selectedItem != null) ? ((Entity)selectedItem.Item) : null);
	}

	public abstract object Clone();

	protected override void DrawForBitmap(object drawSceneParams)
	{
		if (Visible)
		{
			DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
			base.DrawForBitmap(drawSceneParams2);
			DrawInternal(drawSceneParams2);
		}
	}

	protected internal virtual void DrawInternal(DrawSceneParams data)
	{
	}

	protected internal virtual void DrawLabels(DrawSceneParams myParams)
	{
	}

	protected virtual double[] GetModelViewMatrix(Camera camera, double dist)
	{
		return new Transformation(camera.GetModelViewCsIcon(dist), byRow: false).MatrixAsVectorByColumn;
	}

	protected void PreDrawOnDepthBuffer(RenderContextBase context)
	{
		context.PushDepthStencilState();
		context.PushBlendState();
		context.SetState(blendStateType.ColorMaskOff);
		context.SetState(depthStencilStateType.DepthTestAlways);
	}

	protected void PostDrawOnDepthBuffer(RenderContextBase context)
	{
		context.PopDepthStencilState();
		context.PopBlendState();
	}
}
