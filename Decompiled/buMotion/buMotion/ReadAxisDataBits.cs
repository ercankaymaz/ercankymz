namespace buMotion;

public class ReadAxisDataBits
{
	public bool Position = false;

	public bool OffsetedPosition = false;

	public bool FollowingError = false;

	public bool Velocity = false;

	public bool Current = false;

	public bool Enabled = false;

	public bool HomingDone = false;

	public bool StandStill = false;

	public bool AxisError = false;

	public bool CommOk = false;

	public bool InputHoming = false;

	public bool InputNegLimit = false;

	public bool InputPosLimit = false;

	public bool InputCapture = false;

	public bool DistanceToGo = false;

	public ReadAxisDataBits()
	{
	}

	public ReadAxisDataBits(bool position, bool offsetedPosition)
	{
		Position = position;
		OffsetedPosition = offsetedPosition;
	}

	public ReadAxisDataBits(bool position, bool offsetedPosition, bool enabled, bool homingdone)
	{
		Position = position;
		OffsetedPosition = offsetedPosition;
		Enabled = enabled;
		HomingDone = homingdone;
	}

	public ReadAxisDataBits(bool position, bool vel, bool enabled, bool homingdone, bool axiserror)
	{
		Position = position;
		Velocity = vel;
		Enabled = enabled;
		HomingDone = homingdone;
		AxisError = axiserror;
	}

	public ReadAxisDataBits(bool position, bool offsetedposition, bool followerror, bool vel, bool current, bool enabled, bool homingdone, bool standstill, bool axiserror, bool commok, bool inphome, bool inpneglimit, bool inpposlimit, bool inpcapture)
	{
		Position = position;
		OffsetedPosition = offsetedposition;
		FollowingError = followerror;
		Velocity = vel;
		Current = current;
		Enabled = enabled;
		HomingDone = homingdone;
		StandStill = standstill;
		AxisError = axiserror;
		CommOk = commok;
		InputHoming = inphome;
		InputNegLimit = inpneglimit;
		InputPosLimit = inpposlimit;
		InputCapture = inpcapture;
	}
}
