namespace SharpGLTF.Animations;

public interface ICurveSampler<T>
{
	T GetPoint(float offset);
}
