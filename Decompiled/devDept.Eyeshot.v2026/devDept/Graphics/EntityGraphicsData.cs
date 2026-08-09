using System;

namespace devDept.Graphics;

public abstract class EntityGraphicsData : IDisposable
{
	public object Parent;

	public primitiveType PrimitiveType;

	protected EntityGraphicsData()
	{
	}

	protected EntityGraphicsData(object parent)
	{
		SetParent(parent);
	}

	public void SetParent(object parent)
	{
		Parent = parent;
	}

	public abstract void Dispose();

	public bool NeedToCompile()
	{
		return !IsValid();
	}

	public abstract bool IsValid();

	public abstract bool IsVbo();

	public virtual void DrawBuffer(RenderContextBase context, int part)
	{
	}

	public virtual void DrawBuffer(RenderContextBase context, bool nextPart)
	{
	}
}
