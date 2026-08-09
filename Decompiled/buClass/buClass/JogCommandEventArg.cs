namespace buClass;

public class JogCommandEventArg
{
	public JogCommandType Command = JogCommandType.None;

	public double IncrementalPosition = 0.0;

	public double Position = 0.0;

	public double Position1 = 0.0;

	public double Position2 = 0.0;

	public double Velocity = 0.0;

	public double VelocityMove = 0.0;

	public double VelocityJog = 0.0;

	public double Direction = 1.0;

	public int SelectedAxis = 0;

	public double WaitTime = 0.0;

	public override string ToString()
	{
		return "Cmd : " + Command.ToString() + " , Position: " + Position1 + " , Velocity: " + VelocityMove;
	}
}
