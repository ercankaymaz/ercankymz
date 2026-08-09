namespace Xbim.Common;

public class FlagSetter
{
	public static void SetActivationFlag(IPersistEntity entity, bool value)
	{
		if (entity is PersistEntity persistEntity)
		{
			persistEntity._activated = true;
		}
	}
}
