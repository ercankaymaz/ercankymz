using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Serialization;

public class VectorViewSurrogate : ViewSurrogate
{
	public bool HiddenSegments;

	public bool IgnoreTransparency;

	public bool FillTexts;

	public double FontAccuracy;

	public bool FillRegions;

	public bool KeepEntityColor;

	public bool TreatWhiteAsBlack;

	public double CenterlinesExtensionAmount;

	public bool Shaded;

	internal Transformation originTranslation;

	internal double segmentsScaleFactor;

	public VectorViewSurrogate(VectorView vectorView)
		: base(vectorView)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (base.Content == contentType.Tessellation)
		{
			return _0023_003DzC3X1_iZp12rj();
		}
		VectorView vectorView = new VectorView(this);
		CopyDataToObject(vectorView);
		return vectorView;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		if (entity is VectorView vectorView)
		{
			vectorView.HiddenSegments = HiddenSegments;
			vectorView.IgnoreTransparency = IgnoreTransparency;
			vectorView.FillTexts = FillTexts;
			vectorView.FontAccuracy = FontAccuracy;
			vectorView.FillRegions = FillRegions;
			vectorView.KeepEntityColor = KeepEntityColor;
			vectorView.TreatWhiteAsBlack = TreatWhiteAsBlack;
			if (originTranslation != null)
			{
				vectorView.originTranslation = new Translation(originTranslation.GetTranslationVector());
			}
			vectorView.segmentsScaleFactor = segmentsScaleFactor;
			if (base.Version >= 7)
			{
				vectorView.CenterlinesExtensionAmount = CenterlinesExtensionAmount;
			}
			vectorView.Shaded = Shaded;
		}
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		VectorView vectorView = (VectorView)entity;
		HiddenSegments = vectorView.HiddenSegments;
		IgnoreTransparency = vectorView.IgnoreTransparency;
		FillTexts = vectorView.FillTexts;
		FontAccuracy = vectorView.FontAccuracy;
		FillRegions = vectorView.FillRegions;
		KeepEntityColor = vectorView.KeepEntityColor;
		TreatWhiteAsBlack = vectorView.TreatWhiteAsBlack;
		CenterlinesExtensionAmount = vectorView.CenterlinesExtensionAmount;
		originTranslation = vectorView.originTranslation;
		segmentsScaleFactor = vectorView.segmentsScaleFactor;
		Shaded = vectorView.Shaded;
		base.CopyDataFromObject(entity);
	}
}
