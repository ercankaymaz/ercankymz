using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(ExpandableObjectConverter))]
public abstract class Storage : GlobalId
{
	private NeedPaintHandler _needPaint;

	private NeedPaintHandler _needPaintDelegate;

	[Browsable(false)]
	public abstract bool IsDefault { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual NeedPaintHandler NeedPaint
	{
		get
		{
			return _needPaint;
		}
		set
		{
			_needPaint = value;
		}
	}

	protected NeedPaintHandler NeedPaintDelegate
	{
		get
		{
			if (_needPaintDelegate == null)
			{
				_needPaintDelegate = OnNeedPaint;
			}
			return _needPaintDelegate;
		}
	}

	public override string ToString()
	{
		if (!IsDefault)
		{
			return "Modified";
		}
		return string.Empty;
	}

	public void PerformNeedPaint()
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout: false));
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	protected virtual void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_needPaint != null)
		{
			_needPaint(this, e);
		}
	}
}
