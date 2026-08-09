using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class SectionViewSurrogate : VectorViewSurrogate
{
	public VectorView ParentView;

	public Segment2D SectionLine;

	public Plane SectionPlane;

	public SectionViewSurrogate(SectionView sectionView)
		: base(sectionView)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return _0023_003DzC3X1_iZp12rj();
		}
		SectionView sectionView = new SectionView(this);
		CopyDataToObject(sectionView);
		return sectionView;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		SectionView sectionView = (SectionView)entity;
		ParentView = sectionView.ParentView;
		SectionLine = sectionView.SectionLine;
		SectionPlane = sectionView.SectionPlane;
		base.CopyDataFromObject(entity);
	}
}
