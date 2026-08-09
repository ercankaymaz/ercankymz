using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDragDrop : Storage, IPaletteDragDrop
{
	private IPalette _inherit;

	private PaletteDragFeedback _feedback;

	private Color _solidBack;

	private Color _solidBorder;

	private float _solidOpacity;

	private Color _dropDockBack;

	private Color _dropDockBorder;

	private Color _dropDockActive;

	private Color _dropDockInactive;

	[Browsable(false)]
	public override bool IsDefault => Feedback == PaletteDragFeedback.Inherit && SolidBack == Color.Empty && SolidBorder == Color.Empty && SolidOpacity == -1f && DropDockBack == Color.Empty && DropDockBorder == Color.Empty && DropDockActive == Color.Empty && DropDockInactive == Color.Empty;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Feedback drawing method used.")]
	[DefaultValue(typeof(PaletteDragFeedback), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteDragFeedback Feedback
	{
		get
		{
			return _feedback;
		}
		set
		{
			if (_feedback != value)
			{
				_feedback = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background color for a solid drag drop area.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color SolidBack
	{
		get
		{
			return _solidBack;
		}
		set
		{
			if (_solidBack != value)
			{
				_solidBack = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border color for a solid drag drop area.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color SolidBorder
	{
		get
		{
			return _solidBorder;
		}
		set
		{
			if (_solidBorder != value)
			{
				_solidBorder = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Opacity for the solid drag drop area.")]
	[DefaultValue(-1f)]
	[RefreshProperties(RefreshProperties.All)]
	public float SolidOpacity
	{
		get
		{
			return _solidOpacity;
		}
		set
		{
			if (_solidOpacity != value)
			{
				_solidOpacity = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background color for the docking indicators area.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropDockBack
	{
		get
		{
			return _dropDockBack;
		}
		set
		{
			if (_dropDockBack != value)
			{
				_dropDockBack = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border color for the docking indicators area.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropDockBorder
	{
		get
		{
			return _dropDockBorder;
		}
		set
		{
			if (_dropDockBorder != value)
			{
				_dropDockBorder = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Sctive color for docking indicators..")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropDockActive
	{
		get
		{
			return _dropDockActive;
		}
		set
		{
			if (_dropDockActive != value)
			{
				_dropDockActive = value;
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Inactive color for docking indicators.")]
	[DefaultValue(typeof(Color), "")]
	[RefreshProperties(RefreshProperties.All)]
	public Color DropDockInactive
	{
		get
		{
			return _dropDockInactive;
		}
		set
		{
			if (_dropDockInactive != value)
			{
				_dropDockInactive = value;
				PerformNeedPaint();
			}
		}
	}

	public PaletteDragDrop(IPalette inherit, NeedPaintHandler needPaint)
	{
		_inherit = inherit;
		NeedPaint = needPaint;
		_feedback = PaletteDragFeedback.Inherit;
		_solidBack = Color.Empty;
		_solidBorder = Color.Empty;
		_solidOpacity = -1f;
		_dropDockBack = Color.Empty;
		_dropDockBorder = Color.Empty;
		_dropDockActive = Color.Empty;
		_dropDockInactive = Color.Empty;
	}

	public void SetInherit(IPalette inherit)
	{
		_inherit = inherit;
	}

	public void PopulateFromBase()
	{
		Feedback = GetDragDropFeedback();
		SolidBack = GetDragDropSolidBack();
		SolidBorder = GetDragDropSolidBorder();
		SolidOpacity = GetDragDropSolidOpacity();
		DropDockBack = GetDragDropDockBack();
		DropDockBorder = GetDragDropDockBorder();
		DropDockActive = GetDragDropDockBorder();
		DropDockInactive = GetDragDropDockInactive();
	}

	public void ResetFeedback()
	{
		Feedback = PaletteDragFeedback.Inherit;
	}

	public PaletteDragFeedback GetDragDropFeedback()
	{
		if (Feedback != PaletteDragFeedback.Inherit)
		{
			return Feedback;
		}
		return _inherit.GetDragDropFeedback();
	}

	public void ResetSolidBack()
	{
		SolidBack = Color.Empty;
	}

	public Color GetDragDropSolidBack()
	{
		if (SolidBack != Color.Empty)
		{
			return SolidBack;
		}
		return _inherit.GetDragDropSolidBack();
	}

	public void ResetSolidBorder()
	{
		SolidBorder = Color.Empty;
	}

	public Color GetDragDropSolidBorder()
	{
		if (SolidBorder != Color.Empty)
		{
			return SolidBorder;
		}
		return _inherit.GetDragDropSolidBorder();
	}

	public void ResetSolidOpacity()
	{
		SolidOpacity = -1f;
	}

	public virtual float GetDragDropSolidOpacity()
	{
		if (SolidOpacity >= 0f)
		{
			return SolidOpacity;
		}
		return _inherit.GetDragDropSolidOpacity();
	}

	public void ResetDropDockBack()
	{
		DropDockBack = Color.Empty;
	}

	public Color GetDragDropDockBack()
	{
		if (DropDockBack != Color.Empty)
		{
			return DropDockBack;
		}
		return _inherit.GetDragDropDockBack();
	}

	public void ResetDropDockBorder()
	{
		DropDockBorder = Color.Empty;
	}

	public Color GetDragDropDockBorder()
	{
		if (DropDockBorder != Color.Empty)
		{
			return DropDockBorder;
		}
		return _inherit.GetDragDropDockBorder();
	}

	public void ResetDropDockActive()
	{
		DropDockActive = Color.Empty;
	}

	public Color GetDragDropDockActive()
	{
		if (DropDockActive != Color.Empty)
		{
			return DropDockActive;
		}
		return _inherit.GetDragDropDockActive();
	}

	public void ResetDropDockInactive()
	{
		DropDockInactive = Color.Empty;
	}

	public Color GetDragDropDockInactive()
	{
		if (DropDockInactive != Color.Empty)
		{
			return DropDockInactive;
		}
		return _inherit.GetDragDropDockInactive();
	}
}
