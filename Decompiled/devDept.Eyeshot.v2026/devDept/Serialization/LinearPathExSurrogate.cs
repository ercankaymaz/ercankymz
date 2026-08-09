using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;

namespace devDept.Serialization;

public class LinearPathExSurrogate : LinearPathSurrogate
{
	public LinearPathExSurrogate(LinearPathEx linearPathEx)
		: base(linearPathEx)
	{
	}

	protected override Entity ConvertToObject()
	{
		if (!CheckSurrogateData(string.Empty))
		{
			Entity entity = base.ConvertToObject();
			if (!(entity is LinearPath))
			{
				return entity;
			}
		}
		LinearPathEx linearPathEx = new LinearPathEx(this);
		CopyDataToObject(linearPathEx);
		return linearPathEx;
	}
}
