using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class GhostSurrogate : EntitySurrogate
{
	public string Description;

	public GhostSurrogate(Ghost ghost)
		: base(ghost)
	{
	}

	protected override Entity ConvertToObject()
	{
		Ghost ghost = new Ghost(this);
		CopyDataToObject(ghost);
		return ghost;
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Ghost ghost = entity as Ghost;
		Description = ghost.Description;
		base.CopyDataFromObject(entity);
	}
}
