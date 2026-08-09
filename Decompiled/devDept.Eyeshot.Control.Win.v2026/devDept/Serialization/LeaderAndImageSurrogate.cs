using devDept.Eyeshot.Control.Labels;
using devDept.Geometry;

namespace devDept.Serialization;

public class LeaderAndImageSurrogate : ImageOnlySurrogate
{
	public Vector2D Offset;

	public LeaderAndImageSurrogate(LeaderAndImage leaderAndImage)
		: base(leaderAndImage)
	{
	}

	protected override Label ConvertToObject()
	{
		LeaderAndImage leaderAndImage = new LeaderAndImage(AnchorPoint, Image, Color, HotSpot.X, HotSpot.Y, Offset);
		CopyDataToObject(leaderAndImage);
		return leaderAndImage;
	}

	protected override void CopyDataToObject(Label label)
	{
		((LeaderAndImage)label).Offset = Offset;
		base.CopyDataToObject(label);
	}

	protected override void CopyDataFromObject(Label label)
	{
		LeaderAndImage leaderAndImage = (LeaderAndImage)label;
		Offset = leaderAndImage.Offset;
		base.CopyDataFromObject(label);
	}
}
