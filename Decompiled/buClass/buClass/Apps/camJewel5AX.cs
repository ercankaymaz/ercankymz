namespace buClass.Apps;

public class camJewel5AX : camBase
{
	public jewelCam Data = new jewelCam();

	public camJewel5AX()
	{
	}

	public camJewel5AX(camJewel5AX camm)
	{
	}

	public camJewel5AX(jewelCam data)
	{
		Data = new jewelCam(data);
	}

	public override string ToString()
	{
		return "( Jewel 5AX -> ";
	}
}
