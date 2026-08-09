namespace System.IO.Pipes;

public static class PipesAclExtensions
{
	public static PipeSecurity GetAccessControl(PipeStream stream)
	{
		return stream.GetAccessControl();
	}

	public static void SetAccessControl(PipeStream stream, PipeSecurity pipeSecurity)
	{
		stream.SetAccessControl(pipeSecurity);
	}
}
