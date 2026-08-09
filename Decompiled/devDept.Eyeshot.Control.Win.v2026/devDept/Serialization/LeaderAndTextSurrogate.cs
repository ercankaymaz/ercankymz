using devDept.Eyeshot.Control.Labels;
using devDept.Geometry;

namespace devDept.Serialization;

public class LeaderAndTextSurrogate : TextOnlySurrogate
{
	public Vector2D Offset;

	public LeaderAndTextSurrogate(LeaderAndText leaderAndText)
		: base(leaderAndText)
	{
	}

	protected override Label ConvertToObject()
	{
		LeaderAndText leaderAndText = new LeaderAndText(AnchorPoint, Text, Font, Color, Offset);
		CopyDataToObject(leaderAndText);
		return leaderAndText;
	}

	protected override void CopyDataToObject(Label label)
	{
		((LeaderAndText)label).Offset = Offset;
		base.CopyDataToObject(label);
	}

	protected override void CopyDataFromObject(Label label)
	{
		LeaderAndText leaderAndText = (LeaderAndText)label;
		Offset = leaderAndText.Offset;
		base.CopyDataFromObject(label);
	}
}
