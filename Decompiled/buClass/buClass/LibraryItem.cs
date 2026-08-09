using System;
using System.Collections.Generic;
using System.Drawing;

namespace buClass;

[Serializable]
public class LibraryItem : buSerilization
{
	public WorkPlane Plane = new WorkPlane();

	public List<Pnt3D> Vertice = new List<Pnt3D>();

	public double Rotation = 0.0;

	public Color Color = Color.Black;

	public double Thickness = 1.0;

	public string Tag = "";

	public bool Visible = true;

	public LibraryItem()
	{
	}

	public LibraryItem(LibraryItem entity)
	{
		if (entity.GetType() == typeof(LibraryItemPoint))
		{
			entity = new LibraryItemPoint((LibraryItemPoint)entity);
		}
		if (entity.GetType() == typeof(LibraryItemLine))
		{
			entity = new LibraryItemLine((LibraryItemLine)entity);
		}
		if (entity.GetType() == typeof(LibraryItemRectangle))
		{
			entity = new LibraryItemRectangle((LibraryItemRectangle)entity);
		}
		if (entity.GetType() == typeof(LibraryItemCircle))
		{
			entity = new LibraryItemCircle((LibraryItemCircle)entity);
		}
		if (entity.GetType() == typeof(LibraryItemBarrel))
		{
			entity = new LibraryItemBarrel((LibraryItemBarrel)entity);
		}
		if (entity.GetType() == typeof(LibraryItemEllipse))
		{
			entity = new LibraryItemEllipse((LibraryItemEllipse)entity);
		}
		if (entity.GetType() == typeof(LibraryItemPolygon))
		{
			entity = new LibraryItemPolygon((LibraryItemPolygon)entity);
		}
		if (entity.GetType() == typeof(LibraryItemTriangleTwin))
		{
			entity = new LibraryItemTriangleTwin((LibraryItemTriangleTwin)entity);
		}
		if (entity.GetType() == typeof(LibraryItemText))
		{
			entity = new LibraryItemText((LibraryItemText)entity);
		}
		if (entity.GetType() == typeof(LibraryItemSlot))
		{
			entity = new LibraryItemSlot((LibraryItemSlot)entity);
		}
	}

	public static void Copy(List<LibraryItem> RefEntities, ref List<LibraryItem> CopiedEntities)
	{
		CopiedEntities.Clear();
		for (int i = 0; i <= RefEntities.Count - 1; i++)
		{
			LibraryItem CopiedTo = new LibraryItem();
			Copy(RefEntities[i], ref CopiedTo);
			CopiedEntities.Add(CopiedTo);
		}
	}

	public static void Copy(LibraryItem RefEntity, ref LibraryItem CopiedTo)
	{
		if (RefEntity.GetType() == typeof(LibraryItemPoint))
		{
			CopiedTo = new LibraryItemPoint((LibraryItemPoint)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemLine))
		{
			CopiedTo = new LibraryItemLine((LibraryItemLine)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemRectangle))
		{
			CopiedTo = new LibraryItemRectangle((LibraryItemRectangle)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemCircle))
		{
			CopiedTo = new LibraryItemCircle((LibraryItemCircle)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemEllipse))
		{
			CopiedTo = new LibraryItemEllipse((LibraryItemEllipse)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemBarrel))
		{
			CopiedTo = new LibraryItemBarrel((LibraryItemBarrel)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemPolygon))
		{
			CopiedTo = new LibraryItemPolygon((LibraryItemPolygon)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemTriangleTwin))
		{
			CopiedTo = new LibraryItemTriangleTwin((LibraryItemTriangleTwin)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemText))
		{
			CopiedTo = new LibraryItemText((LibraryItemText)RefEntity);
		}
		if (RefEntity.GetType() == typeof(LibraryItemSlot))
		{
			CopiedTo = new LibraryItemSlot((LibraryItemSlot)RefEntity);
		}
		CopiedTo.Rotation = RefEntity.Rotation;
		CopiedTo.Color = RefEntity.Color;
		CopiedTo.Thickness = RefEntity.Thickness;
		CopiedTo.Plane = new WorkPlane(RefEntity.Plane);
		CopiedTo.Tag = RefEntity.Tag;
		CopiedTo.Visible = RefEntity.Visible;
	}

	public static LibraryItem Copy(LibraryItem RefEntity)
	{
		LibraryItem CopiedTo = new LibraryItem();
		Copy(RefEntity, ref CopiedTo);
		return CopiedTo;
	}

	public override string ToString()
	{
		string result = "";
		if (GetType() == typeof(LibraryItemPoint))
		{
			result = ((LibraryItemPoint)this).ToString();
		}
		if (GetType() == typeof(LibraryItemLine))
		{
			result = ((LibraryItemLine)this).ToString();
		}
		if (GetType() == typeof(LibraryItemRectangle))
		{
			result = ((LibraryItemRectangle)this).ToString();
		}
		if (GetType() == typeof(LibraryItemCircle))
		{
			result = ((LibraryItemCircle)this).ToString();
		}
		if (GetType() == typeof(LibraryItemEllipse))
		{
			result = ((LibraryItemEllipse)this).ToString();
		}
		if (GetType() == typeof(LibraryItemPolygon))
		{
			result = ((LibraryItemPolygon)this).ToString();
		}
		if (GetType() == typeof(LibraryItemBarrel))
		{
			result = ((LibraryItemBarrel)this).ToString();
		}
		if (GetType() == typeof(LibraryItemTriangleTwin))
		{
			result = ((LibraryItemTriangleTwin)this).ToString();
		}
		if (GetType() == typeof(LibraryItemText))
		{
			result = ((LibraryItemText)this).ToString();
		}
		if (GetType() == typeof(LibraryItemSlot))
		{
			result = ((LibraryItemSlot)this).ToString();
		}
		return result;
	}
}
