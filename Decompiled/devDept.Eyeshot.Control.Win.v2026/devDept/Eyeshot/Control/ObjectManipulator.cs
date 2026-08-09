using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Eyeshot.Control.Labels;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[TypeConverter(typeof(ObjectManipulatorConverter))]
public class ObjectManipulator : CoordinateSystemBase, IObjectManipulator
{
	public class ObjectManipulatorEventArgs : EventArgs
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal Vector3D _0023_003DzZX83mf8_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private actionType _0023_003DzjGvm17_0024DzsnS;

		public actionType ActionMode => _0023_003DzjGvm17_0024DzsnS;

		public Vector3D Axis => _0023_003DzZX83mf8_003D;

		internal ObjectManipulatorEventArgs(actionType _0023_003DzfcUzrRi_0024u6FZ, Vector3D _0023_003DzfZZZs54_003D)
		{
			_0023_003DzjGvm17_0024DzsnS = _0023_003DzfcUzrRi_0024u6FZ;
			_0023_003DzZX83mf8_003D = _0023_003DzfZZZs54_003D;
		}
	}

	public delegate void ObjectManipulatorEventHandler(object sender, ObjectManipulatorEventArgs e);

	public enum actionType
	{
		None,
		TranslateOnView,
		TranslateOnAxis,
		Rotate,
		RotateOnView,
		Scale,
		UniformScale
	}

	public enum ballActionType
	{
		Translate,
		Rotate,
		Scale
	}

	public enum styleType
	{
		Standard,
		Rings,
		Large
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzPkzw1z5rqyYA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	private int _0023_003Dzo7sDYnjZFyS1 = 25;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzgKmhOzpIjgc2 = 25;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal TextOnly _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string _0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx = string.Empty;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private angularUnitsType _0023_003DzubHct5dMUgT2ht4L3LhDGw28lPL0EHIN8w_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzDp6FmKAkfieBsdgVTVwXq5k_003D = true;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true, the units are displayed next to the transformation label value.")]
	[Browsable(false)]
	public bool ShowTransformationLabelUnits = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzz88ws9_0024ulDWnMqv1nZuiCG4_003D = _0023_003Dzqf3DoNdmn51vDQXD2w_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz3W88KlTLIj39_0024ucn7yh45i0_003D = _0023_003DzEAqV1yPU_0024DxR1lwS_A_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Workspace _0023_003DzU0f5_qE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulatorPartProperties[] _0023_003DzsndQ1PQ_003D = new ObjectManipulatorPartProperties[10];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzB9dgHsvxJnKvwtZdEZRMfk4_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQH_bZoIQz92yO35PwUPGyhFeKdhp;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dza9D63iNEj_0024ocdn86JFpJeKI_003D = _0023_003Dz7P1pfE3vcDxtRZ5zaQ_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzY9cmPPcRA_VvJ_JV4tAzeyI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzw8KIRZgiGcbASbFAZHtSQ2s_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzITIdNiZF1MulGyn1kTRVe_0024w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Interval _0023_003DztLz9G4f2MbVf8jVqFgnf_0024ZU_003D = new Interval(double.MinValue, double.MaxValue);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private styleType _0023_003Dzp3jg0wwRHRrc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ballActionType _0023_003DzcFYy31myW_00242OMA4JlsKzBgU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulatorEventHandler _0023_003DzM133s9Ir1jmo;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulatorEventHandler _0023_003DzAiRqlf34N5UH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulatorEventHandler _0023_003DzEdy5_0024KyZ0bNx;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ObjectManipulatorEventHandler _0023_003Dzf_0024V9OVGSB1gu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Entity _0023_003Dz_d6LIGpNDz3J4WQS6My8luo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzQGuUDpnN5zj7dhytWA_003D_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzvwSfVtC_Wua_9AbsJA_003D_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzj4oERKFtAGPsz1BShQ_003D_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzfuQlipLErxf_0024VFRyLg_003D_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzTgpWXC1JaeOjNGrZHQ_003D_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz_0024qR2UYIkfFXv0oQG0g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz669_0024Pjn6EwHjjj_HxA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzgnoOChIwmV2J;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector2D _0023_003Dz7NYyz2il2OiE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Segment2D _0023_003DzIa2K1J3v8fYG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Circle _0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Plane _0023_003DzvAf97hdaih7oTb64mw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003Dz9SgiP7nQpD7o;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003DzvHflPJaLQdFs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzdnbIz3Zo4ds6fQ__Qvbctac_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private actionType _0023_003DzfcUzrRi_0024u6FZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D _0023_003Dz9Ou_LCIuLXrz;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzWehfaDZ7KlrO = new Identity();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzNo6p8zohxgTa = new Identity();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzVXxkxuBnkiRBonuzuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzzz8ZFe6_6GoPlVfHWDUrx4dIXH2a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ClippingPlaneBase _0023_003DzHtPJZtQL_PnTuWuzTk6L5Rip2xqhh3dPNA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ClippingPlaneBase _0023_003DzZ_0024hGGswT4bZiGeVKoQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzgwMhmLr71vvSEwxwRBGdQ1c_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzubU3aALCGlU7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzA_0024Oe3Hbz408q;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IList<Entity> _0023_003Dz2_rHji7pJUYf;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool[] _0023_003Dz6nR_0024uxcAmzwG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool[] _0023_003Dz4kpLOElXzSbg;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stack<BlockReference> _0023_003Dzbq3BJR0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D[] _0023_003DzQG9dygY_003D = new Point3D[252]
	{
		new Point3D(0.47352720333863, 0.136065220396476, 3.89984738160509),
		new Point3D(0.476789535232166, 0.0, 3.92671510198786),
		new Point3D(0.464236868115697, 0.251415744421884, 3.82333458732857),
		new Point3D(0.940149313762182, 0.136065220396476, 3.81433570624641),
		new Point3D(0.921704117323881, 0.251415744421884, 3.73950060255229),
		new Point3D(0.47352720333863, -0.136065220396477, 3.89984738160509),
		new Point3D(0.946626405404117, 0.0, 3.84061430004083),
		new Point3D(0.894098930040823, 0.328490500448458, 3.62750195511402),
		new Point3D(0.450332898883963, 0.328490500448458, 3.70882509849668),
		new Point3D(1.3930619301592, 0.136065220396476, 3.67320242715466),
		new Point3D(1.36573084500456, 0.251415744421884, 3.6011362783688),
		new Point3D(1.32482698546224, 0.328490500448458, 3.49328166480277),
		new Point3D(0.464236868115697, -0.251415744421884, 3.82333458732857),
		new Point3D(0.940149313762182, -0.136065220396477, 3.81433570624641),
		new Point3D(1.40265933096825, 0.0, 3.69850869328898),
		new Point3D(1.27657759335313, 0.355555555555556, 3.36605847366749),
		new Point3D(0.861536391435207, 0.355555555555556, 3.49539054273379),
		new Point3D(0.433932048919163, 0.355555555555556, 3.57375194675299),
		new Point3D(1.82566056671222, 0.136065220396476, 3.47850558534348),
		new Point3D(1.78984214160705, 0.251415744421884, 3.410259278194),
		new Point3D(1.73623608018505, 0.328490500448458, 3.30812146163345),
		new Point3D(1.67300341935757, 0.355555555555556, 3.18764169235156),
		new Point3D(2.22044604925031E-16, 0.355555555555556, 3.6),
		new Point3D(0.450332898883963, -0.328490500448457, 3.70882509849668),
		new Point3D(0.921704117323881, -0.251415744421884, 3.73950060255229),
		new Point3D(1.3930619301592, -0.136065220396477, 3.67320242715466),
		new Point3D(1.83823832497313, 0.0, 3.5024705014727),
		new Point3D(1.60977075853008, 0.328490500448458, 3.06716192306966),
		new Point3D(1.22832820124402, 0.328490500448458, 3.23883528253222),
		new Point3D(0.828973852829592, 0.328490500448458, 3.36327913035356),
		new Point3D(0.417531198954363, 0.328490500448458, 3.4386787950093),
		new Point3D(2.22044604925031E-16, -0.355555555555556, 3.6),
		new Point3D(2.231636961173, 0.136065220396476, 3.23308429918558),
		new Point3D(2.1878535094114, 0.251415744421884, 3.16965301850802),
		new Point3D(2.1223269431956, 0.328490500448458, 3.07472139831273),
		new Point3D(2.04503308823216, 0.355555555555556, 2.96274191721716),
		new Point3D(1.96773923326872, 0.328490500448458, 2.8507624361216),
		new Point3D(0.433932048919163, -0.355555555555556, 3.57375194675299),
		new Point3D(0.894098930040823, -0.328490500448457, 3.62750195511402),
		new Point3D(1.36573084500456, -0.251415744421884, 3.6011362783688),
		new Point3D(1.82566056671222, -0.136065220396477, 3.47850558534348),
		new Point3D(2.24701166484768, 0.0, 3.25535840286824),
		new Point3D(1.90221266705292, 0.251415744421884, 2.75583081592631),
		new Point3D(1.55616469710808, 0.251415744421884, 2.96502410650911),
		new Point3D(1.18742434170169, 0.251415744421884, 3.13098066896619),
		new Point3D(0.801368665546534, 0.251415744421884, 3.25128048291528),
		new Point3D(0.403627229722628, 0.251415744421884, 3.32416930617742),
		new Point3D(2.60507106353109, 0.136065220396476, 2.94051736367374),
		new Point3D(2.55396104643149, 0.251415744421884, 2.88282608037518),
		new Point3D(2.47746950031029, 0.328490500448458, 2.796484973335),
		new Point3D(2.38724156966686, 0.355555555555556, 2.69463869341597),
		new Point3D(2.29701363902343, 0.328490500448458, 2.59279241349693),
		new Point3D(2.22052209290223, 0.251415744421884, 2.50645130645675),
		new Point3D(0.417531198954363, -0.328490500448457, 3.4386787950093),
		new Point3D(0.861536391435207, -0.355555555555556, 3.49539054273379),
		new Point3D(1.32482698546224, -0.328490500448457, 3.49328166480277),
		new Point3D(1.78984214160705, -0.251415744421884, 3.410259278194),
		new Point3D(2.231636961173, -0.136065220396477, 3.23308429918558),
		new Point3D(2.62301851481914, 0.0, 2.96077584832125),
		new Point3D(2.16941207580263, 0.136065220396476, 2.44876002315819),
		new Point3D(1.85842921529132, 0.136065220396476, 2.69239953524875),
		new Point3D(1.52034627200291, 0.136065220396476, 2.89677779935963),
		new Point3D(1.16009325654706, 0.136065220396476, 3.05891452018033),
		new Point3D(0.782923469108233, 0.136065220396476, 3.17644537922117),
		new Point3D(0.394336894499696, 0.136065220396476, 3.2476565119009),
		new Point3D(2.94051736367374, 0.136065220396476, 2.60507106353109),
		new Point3D(2.88282608037518, 0.251415744421884, 2.55396104643149),
		new Point3D(2.796484973335, 0.328490500448458, 2.47746950031029),
		new Point3D(2.69463869341596, 0.355555555555556, 2.38724156966686),
		new Point3D(2.59279241349693, 0.328490500448458, 2.29701363902343),
		new Point3D(2.50645130645675, 0.251415744421884, 2.22052209290224),
		new Point3D(2.44876002315819, 0.136065220396476, 2.16941207580263),
		new Point3D(0.403627229722628, -0.251415744421884, 3.32416930617742),
		new Point3D(0.828973852829592, -0.328490500448457, 3.36327913035356),
		new Point3D(1.27657759335313, -0.355555555555556, 3.36605847366749),
		new Point3D(1.73623608018505, -0.328490500448457, 3.30812146163345),
		new Point3D(2.1878535094114, -0.251415744421884, 3.16965301850802),
		new Point3D(2.60507106353109, -0.136065220396477, 2.94051736367374),
		new Point3D(2.96077584832124, 0.0, 2.62301851481915),
		new Point3D(2.42850153851068, 4.35415592470179E-17, 2.15146462451458),
		new Point3D(2.15146462451458, 4.35415592470179E-17, 2.42850153851068),
		new Point3D(1.84305451161664, 4.35415592470179E-17, 2.67012543156609),
		new Point3D(1.507768513742, 4.35415592470179E-17, 2.87281288323041),
		new Point3D(1.150495855738, 4.35415592470179E-17, 3.03360825404601),
		new Point3D(0.776446377466298, 4.35415592470179E-17, 3.15016678542675),
		new Point3D(0.391074562606159, 4.35415592470179E-17, 3.22078879151813),
		new Point3D(3.23308429918558, 0.136065220396476, 2.23163696117301),
		new Point3D(3.16965301850802, 0.251415744421884, 2.1878535094114),
		new Point3D(3.07472139831273, 0.328490500448458, 2.12232694319561),
		new Point3D(2.96274191721716, 0.355555555555556, 2.04503308823216),
		new Point3D(2.8507624361216, 0.328490500448458, 1.96773923326872),
		new Point3D(2.75583081592631, 0.251415744421884, 1.90221266705292),
		new Point3D(2.69239953524875, 0.136065220396476, 1.85842921529132),
		new Point3D(2.67012543156608, 4.35415592470179E-17, 1.84305451161664),
		new Point3D(0.394336894499696, -0.136065220396476, 3.2476565119009),
		new Point3D(0.801368665546534, -0.251415744421884, 3.25128048291528),
		new Point3D(1.22832820124402, -0.328490500448457, 3.23883528253222),
		new Point3D(1.67300341935757, -0.355555555555556, 3.18764169235156),
		new Point3D(2.1223269431956, -0.328490500448457, 3.07472139831273),
		new Point3D(2.55396104643149, -0.251415744421884, 2.88282608037518),
		new Point3D(2.94051736367374, -0.136065220396477, 2.60507106353109),
		new Point3D(3.25535840286824, 0.0, 2.24701166484768),
		new Point3D(2.69239953524875, -0.136065220396476, 1.85842921529132),
		new Point3D(2.44876002315819, -0.136065220396476, 2.16941207580263),
		new Point3D(2.16941207580263, -0.136065220396476, 2.44876002315819),
		new Point3D(1.85842921529132, -0.136065220396476, 2.69239953524875),
		new Point3D(1.52034627200291, -0.136065220396476, 2.89677779935963),
		new Point3D(1.16009325654706, -0.136065220396476, 3.05891452018033),
		new Point3D(0.782923469108233, -0.136065220396476, 3.17644537922117),
		new Point3D(0.3363320646957, 0.0966430147762729, 3.91598772284587),
		new Point3D(0.328490500448458, 0.136065220396476, 3.90862048584967),
		new Point3D(0.355555555555556, 0.0, 3.93404840673413),
		new Point3D(0.281718319601187, 0.206064735784934, 3.86467750071729),
		new Point3D(0.348259523238418, -0.0366796314037709, 3.92719370306563),
		new Point3D(0.251415744421884, 0.251415744421884, 3.83620789364626),
		new Point3D(0.328490500448458, -0.136065220396477, 3.90862048584967),
		new Point3D(0.200148663413663, 0.285671312780055, 3.78804189972178),
		new Point3D(0.300293755628366, -0.178264631182633, 3.88212932986837),
		new Point3D(0.136065220396477, 0.328490500448457, 3.72783479086511),
		new Point3D(0.251415744421883, -0.251415744421884, 3.83620789364626),
		new Point3D(0.103584811808256, 0.334951255414199, 3.69731908503676),
		new Point3D(0.181051774729208, -0.29843144584973, 3.77010015998816),
		new Point3D(0.136065220396476, -0.328490500448458, 3.72783479086511),
		new Point3D(0.136065220396477, 0.328490500448458, 3.45570435007215),
		new Point3D(0.190510113668052, 0.292111585820595, 3.39796614748826),
		new Point3D(0.103584811808257, -0.334951255414199, 3.49014946142024),
		new Point3D(0.251415744421884, 0.251415744421884, 3.3333764048025),
		new Point3D(0.136065220396476, -0.328490500448458, 3.45570435007215),
		new Point3D(0.312493965907167, 0.160005726173649, 3.26860363156937),
		new Point3D(0.196992902322639, -0.287779924927455, 3.39109122236388),
		new Point3D(0.328490500448458, 0.136065220396476, 3.25163948495275),
		new Point3D(0.251415744421883, -0.251415744421884, 3.3333764048025),
		new Point3D(0.352914624856303, 0.0132768552003187, 3.2257379731992),
		new Point3D(0.275821017214158, -0.214890672521542, 3.30749488497718),
		new Point3D(0.355555555555556, 3.95869349943364E-17, 3.22293729562302),
		new Point3D(0.328490500448458, -0.136065220396477, 3.25163948495275),
		new Point3D(0.332719565561382, -0.114804274339499, 3.24715460852894),
		new Point3D(1.18742434170169, -0.251415744421884, 3.13098066896619),
		new Point3D(1.55616469710808, -0.251415744421884, 2.96502410650911),
		new Point3D(1.60977075853008, -0.328490500448457, 3.06716192306966),
		new Point3D(1.90221266705292, -0.251415744421884, 2.75583081592631),
		new Point3D(1.96773923326872, -0.328490500448457, 2.8507624361216),
		new Point3D(2.04503308823216, -0.355555555555556, 2.96274191721716),
		new Point3D(2.22052209290223, -0.251415744421884, 2.50645130645675),
		new Point3D(2.29701363902343, -0.328490500448457, 2.59279241349693),
		new Point3D(2.38724156966686, -0.355555555555556, 2.69463869341597),
		new Point3D(2.47746950031029, -0.328490500448457, 2.796484973335),
		new Point3D(2.50645130645675, -0.251415744421884, 2.22052209290224),
		new Point3D(2.59279241349693, -0.328490500448457, 2.29701363902343),
		new Point3D(2.69463869341596, -0.355555555555556, 2.38724156966686),
		new Point3D(2.796484973335, -0.328490500448457, 2.47746950031029),
		new Point3D(2.88282608037518, -0.251415744421884, 2.55396104643149),
		new Point3D(2.75583081592631, -0.251415744421884, 1.90221266705292),
		new Point3D(2.8507624361216, -0.328490500448457, 1.96773923326872),
		new Point3D(2.96274191721716, -0.355555555555556, 2.04503308823216),
		new Point3D(3.07472139831273, -0.328490500448457, 2.12232694319561),
		new Point3D(3.16965301850802, -0.251415744421884, 2.1878535094114),
		new Point3D(3.23308429918558, -0.136065220396477, 2.23163696117301),
		new Point3D(2.96502410650911, -0.251415744421884, 1.55616469710808),
		new Point3D(3.06716192306966, -0.328490500448457, 1.60977075853008),
		new Point3D(3.18764169235155, -0.355555555555556, 1.67300341935757),
		new Point3D(3.30812146163345, -0.328490500448457, 1.73623608018505),
		new Point3D(3.410259278194, -0.251415744421884, 1.78984214160705),
		new Point3D(3.47850558534348, -0.136065220396477, 1.82566056671222),
		new Point3D(3.5024705014727, 0.0, 1.83823832497313),
		new Point3D(2.89677779935963, -0.136065220396476, 1.52034627200292),
		new Point3D(3.47850558534348, 0.136065220396476, 1.82566056671222),
		new Point3D(3.13098066896619, -0.251415744421884, 1.18742434170169),
		new Point3D(3.23883528253222, -0.328490500448457, 1.22832820124402),
		new Point3D(3.36605847366749, -0.355555555555556, 1.27657759335313),
		new Point3D(3.49328166480277, -0.328490500448457, 1.32482698546224),
		new Point3D(3.6011362783688, -0.251415744421884, 1.36573084500457),
		new Point3D(3.67320242715466, -0.136065220396477, 1.3930619301592),
		new Point3D(3.69850869328897, 0.0, 1.40265933096825),
		new Point3D(3.67320242715466, 0.136065220396476, 1.3930619301592),
		new Point3D(2.87281288323041, 4.35415592470179E-17, 1.50776851374201),
		new Point3D(3.05891452018032, -0.136065220396476, 1.16009325654706),
		new Point3D(3.6011362783688, 0.251415744421884, 1.36573084500457),
		new Point3D(3.410259278194, 0.251415744421884, 1.78984214160705),
		new Point3D(3.25128048291528, -0.251415744421884, 0.801368665546535),
		new Point3D(3.36327913035356, -0.328490500448457, 0.828973852829593),
		new Point3D(3.49539054273379, -0.355555555555556, 0.861536391435209),
		new Point3D(3.62750195511402, -0.328490500448457, 0.894098930040825),
		new Point3D(3.73950060255229, -0.251415744421884, 0.921704117323883),
		new Point3D(3.81433570624641, -0.136065220396477, 0.940149313762184),
		new Point3D(3.84061430004083, 0.0, 0.946626405404119),
		new Point3D(3.81433570624641, 0.136065220396476, 0.940149313762184),
		new Point3D(3.73950060255229, 0.251415744421884, 0.921704117323883),
		new Point3D(2.89677779935963, 0.136065220396476, 1.52034627200292),
		new Point3D(3.03360825404601, 4.35415592470179E-17, 1.15049585573801),
		new Point3D(3.17644537922117, -0.136065220396476, 0.782923469108234),
		new Point3D(3.62750195511402, 0.328490500448458, 0.894098930040825),
		new Point3D(3.49328166480277, 0.328490500448458, 1.32482698546224),
		new Point3D(3.30812146163345, 0.328490500448458, 1.73623608018505),
		new Point3D(3.32416930617742, -0.251415744421884, 0.40362722972263),
		new Point3D(3.4386787950093, -0.328490500448457, 0.417531198954364),
		new Point3D(3.57375194675299, -0.355555555555556, 0.433932048919164),
		new Point3D(3.70882509849668, -0.328490500448457, 0.450332898883965),
		new Point3D(3.82333458732857, -0.251415744421884, 0.464236868115699),
		new Point3D(3.89984738160509, -0.136065220396477, 0.473527203338631),
		new Point3D(3.92671510198786, 0.0, 0.476789535232168),
		new Point3D(3.89984738160509, 0.136065220396476, 0.473527203338631),
		new Point3D(3.82333458732857, 0.251415744421884, 0.464236868115699),
		new Point3D(3.70882509849668, 0.328490500448458, 0.450332898883965),
		new Point3D(2.96502410650911, 0.251415744421884, 1.55616469710808),
		new Point3D(3.05891452018032, 0.136065220396476, 1.16009325654706),
		new Point3D(3.15016678542675, 4.35415592470179E-17, 0.7764463774663),
		new Point3D(3.2476565119009, -0.136065220396476, 0.394336894499697),
		new Point3D(3.57375194675299, 0.355555555555556, 0.433932048919164),
		new Point3D(3.49539054273379, 0.355555555555556, 0.861536391435209),
		new Point3D(3.36605847366749, 0.355555555555556, 1.27657759335313),
		new Point3D(3.18764169235155, 0.355555555555556, 1.67300341935757),
		new Point3D(3.6, -0.355555555555556, 1.33226762955019E-15),
		new Point3D(3.6, 0.355555555555556, 1.33226762955019E-15),
		new Point3D(3.06716192306966, 0.328490500448458, 1.60977075853008),
		new Point3D(3.13098066896619, 0.251415744421884, 1.18742434170169),
		new Point3D(3.17644537922117, 0.136065220396476, 0.782923469108234),
		new Point3D(3.22078879151813, 4.35415592470179E-17, 0.39107456260616),
		new Point3D(3.4386787950093, 0.328490500448458, 0.417531198954364),
		new Point3D(3.36327913035356, 0.328490500448458, 0.828973852829593),
		new Point3D(3.3333764048025, -0.251415744421884, 0.251415744421884),
		new Point3D(3.26860363156937, -0.160005726173649, 0.312493965907167),
		new Point3D(3.45570435007215, -0.328490500448458, 0.136065220396477),
		new Point3D(3.39796614748826, -0.292111585820596, 0.19051011366805),
		new Point3D(3.72783479086511, -0.328490500448457, 0.136065220396476),
		new Point3D(3.69731908503676, -0.334951255414199, 0.103584811808257),
		new Point3D(3.83620789364626, -0.251415744421884, 0.251415744421884),
		new Point3D(3.78804189972178, -0.285671312780055, 0.200148663413664),
		new Point3D(3.90862048584967, -0.136065220396477, 0.328490500448458),
		new Point3D(3.86467750071729, -0.206064735784934, 0.281718319601187),
		new Point3D(3.93404840673413, 0.0, 0.355555555555556),
		new Point3D(3.91598772284587, -0.0966430147762726, 0.3363320646957),
		new Point3D(3.90862048584967, 0.136065220396476, 0.328490500448457),
		new Point3D(3.92719370306563, 0.0366796314037714, 0.348259523238418),
		new Point3D(3.83620789364626, 0.251415744421884, 0.251415744421884),
		new Point3D(3.88212932986837, 0.178264631182634, 0.300293755628366),
		new Point3D(3.72783479086511, 0.328490500448458, 0.136065220396476),
		new Point3D(3.77010015998816, 0.29843144584973, 0.181051774729208),
		new Point3D(3.25163948495275, -0.136065220396477, 0.328490500448458),
		new Point3D(3.49014946142024, 0.334951255414199, 0.103584811808257),
		new Point3D(3.23883528253222, 0.328490500448458, 1.22832820124402),
		new Point3D(3.25128048291528, 0.251415744421884, 0.801368665546535),
		new Point3D(3.32416930617742, 0.251415744421884, 0.40362722972263),
		new Point3D(3.2476565119009, 0.136065220396476, 0.394336894499697),
		new Point3D(3.3333764048025, 0.251415744421884, 0.251415744421884),
		new Point3D(3.39109122236388, 0.287779924927455, 0.196992902322638),
		new Point3D(3.25163948495275, 0.136065220396476, 0.328490500448458),
		new Point3D(3.30749488497718, 0.214890672521542, 0.275821017214158),
		new Point3D(3.22293729562302, 4.35415592470179E-17, 0.355555555555556),
		new Point3D(3.24715460852894, 0.114804274339499, 0.332719565561382),
		new Point3D(3.45570435007215, 0.328490500448458, 0.136065220396477),
		new Point3D(3.2257379731992, -0.0132768552003191, 0.352914624856303)
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IndexTriangle[] _0023_003DzrCWv4TY_003D = new IndexTriangle[444]
	{
		new SmoothTriangle(110, 109, 0, 110, 109, 0),
		new SmoothTriangle(109, 111, 1, 109, 111, 1),
		new SmoothTriangle(109, 1, 0, 109, 1, 0),
		new SmoothTriangle(112, 110, 0, 112, 110, 0),
		new SmoothTriangle(112, 0, 2, 112, 0, 2),
		new SmoothTriangle(111, 113, 1, 111, 113, 1),
		new SmoothTriangle(0, 1, 3, 0, 1, 3),
		new SmoothTriangle(2, 0, 4, 2, 0, 4),
		new SmoothTriangle(114, 112, 2, 114, 112, 2),
		new SmoothTriangle(113, 115, 5, 113, 115, 5),
		new SmoothTriangle(113, 5, 1, 113, 5, 1),
		new SmoothTriangle(3, 1, 6, 3, 1, 6),
		new SmoothTriangle(0, 3, 4, 0, 3, 4),
		new SmoothTriangle(2, 4, 7, 2, 4, 7),
		new SmoothTriangle(116, 114, 2, 116, 114, 2),
		new SmoothTriangle(116, 2, 8, 116, 2, 8),
		new SmoothTriangle(115, 117, 5, 115, 117, 5),
		new SmoothTriangle(1, 5, 6, 1, 5, 6),
		new SmoothTriangle(3, 6, 9, 3, 6, 9),
		new SmoothTriangle(4, 3, 10, 4, 3, 10),
		new SmoothTriangle(7, 4, 11, 7, 4, 11),
		new SmoothTriangle(2, 7, 8, 2, 7, 8),
		new SmoothTriangle(118, 116, 8, 118, 116, 8),
		new SmoothTriangle(117, 119, 12, 117, 119, 12),
		new SmoothTriangle(117, 12, 5, 117, 12, 5),
		new SmoothTriangle(6, 5, 13, 6, 5, 13),
		new SmoothTriangle(9, 6, 14, 9, 6, 14),
		new SmoothTriangle(3, 9, 10, 3, 9, 10),
		new SmoothTriangle(4, 10, 11, 4, 10, 11),
		new SmoothTriangle(7, 11, 15, 7, 11, 15),
		new SmoothTriangle(8, 7, 16, 8, 7, 16),
		new SmoothTriangle(120, 118, 8, 120, 118, 8),
		new SmoothTriangle(120, 8, 17, 120, 8, 17),
		new SmoothTriangle(119, 121, 12, 119, 121, 12),
		new SmoothTriangle(5, 12, 13, 5, 12, 13),
		new SmoothTriangle(6, 13, 14, 6, 13, 14),
		new SmoothTriangle(9, 14, 18, 9, 14, 18),
		new SmoothTriangle(10, 9, 19, 10, 9, 19),
		new SmoothTriangle(11, 10, 20, 11, 10, 20),
		new SmoothTriangle(15, 11, 21, 15, 11, 21),
		new SmoothTriangle(7, 15, 16, 7, 15, 16),
		new SmoothTriangle(8, 16, 17, 8, 16, 17),
		new SmoothTriangle(22, 120, 17, 22, 120, 17),
		new SmoothTriangle(121, 122, 23, 121, 122, 23),
		new SmoothTriangle(121, 23, 12, 121, 23, 12),
		new SmoothTriangle(13, 12, 24, 13, 12, 24),
		new SmoothTriangle(14, 13, 25, 14, 13, 25),
		new SmoothTriangle(18, 14, 26, 18, 14, 26),
		new SmoothTriangle(9, 18, 19, 9, 18, 19),
		new SmoothTriangle(10, 19, 20, 10, 19, 20),
		new SmoothTriangle(11, 20, 21, 11, 20, 21),
		new SmoothTriangle(15, 21, 27, 15, 21, 27),
		new SmoothTriangle(16, 15, 28, 16, 15, 28),
		new SmoothTriangle(17, 16, 29, 17, 16, 29),
		new SmoothTriangle(22, 17, 30, 22, 17, 30),
		new SmoothTriangle(122, 31, 23, 122, 31, 23),
		new SmoothTriangle(12, 23, 24, 12, 23, 24),
		new SmoothTriangle(13, 24, 25, 13, 24, 25),
		new SmoothTriangle(14, 25, 26, 14, 25, 26),
		new SmoothTriangle(18, 26, 32, 18, 26, 32),
		new SmoothTriangle(19, 18, 33, 19, 18, 33),
		new SmoothTriangle(20, 19, 34, 20, 19, 34),
		new SmoothTriangle(21, 20, 35, 21, 20, 35),
		new SmoothTriangle(27, 21, 36, 27, 21, 36),
		new SmoothTriangle(15, 27, 28, 15, 27, 28),
		new SmoothTriangle(16, 28, 29, 16, 28, 29),
		new SmoothTriangle(17, 29, 30, 17, 29, 30),
		new SmoothTriangle(123, 22, 30, 123, 22, 30),
		new SmoothTriangle(23, 31, 37, 23, 31, 37),
		new SmoothTriangle(24, 23, 38, 24, 23, 38),
		new SmoothTriangle(25, 24, 39, 25, 24, 39),
		new SmoothTriangle(26, 25, 40, 26, 25, 40),
		new SmoothTriangle(32, 26, 41, 32, 26, 41),
		new SmoothTriangle(18, 32, 33, 18, 32, 33),
		new SmoothTriangle(19, 33, 34, 19, 33, 34),
		new SmoothTriangle(20, 34, 35, 20, 34, 35),
		new SmoothTriangle(21, 35, 36, 21, 35, 36),
		new SmoothTriangle(27, 36, 42, 27, 36, 42),
		new SmoothTriangle(28, 27, 43, 28, 27, 43),
		new SmoothTriangle(29, 28, 44, 29, 28, 44),
		new SmoothTriangle(30, 29, 45, 30, 29, 45),
		new SmoothTriangle(124, 123, 30, 124, 123, 30),
		new SmoothTriangle(124, 30, 46, 124, 30, 46),
		new SmoothTriangle(31, 125, 37, 31, 125, 37),
		new SmoothTriangle(23, 37, 38, 23, 37, 38),
		new SmoothTriangle(24, 38, 39, 24, 38, 39),
		new SmoothTriangle(25, 39, 40, 25, 39, 40),
		new SmoothTriangle(26, 40, 41, 26, 40, 41),
		new SmoothTriangle(32, 41, 47, 32, 41, 47),
		new SmoothTriangle(33, 32, 48, 33, 32, 48),
		new SmoothTriangle(34, 33, 49, 34, 33, 49),
		new SmoothTriangle(35, 34, 50, 35, 34, 50),
		new SmoothTriangle(36, 35, 51, 36, 35, 51),
		new SmoothTriangle(42, 36, 52, 42, 36, 52),
		new SmoothTriangle(27, 42, 43, 27, 42, 43),
		new SmoothTriangle(28, 43, 44, 28, 43, 44),
		new SmoothTriangle(29, 44, 45, 29, 44, 45),
		new SmoothTriangle(30, 45, 46, 30, 45, 46),
		new SmoothTriangle(126, 124, 46, 126, 124, 46),
		new SmoothTriangle(125, 127, 53, 125, 127, 53),
		new SmoothTriangle(125, 53, 37, 125, 53, 37),
		new SmoothTriangle(38, 37, 54, 38, 37, 54),
		new SmoothTriangle(39, 38, 55, 39, 38, 55),
		new SmoothTriangle(40, 39, 56, 40, 39, 56),
		new SmoothTriangle(41, 40, 57, 41, 40, 57),
		new SmoothTriangle(47, 41, 58, 47, 41, 58),
		new SmoothTriangle(32, 47, 48, 32, 47, 48),
		new SmoothTriangle(33, 48, 49, 33, 48, 49),
		new SmoothTriangle(34, 49, 50, 34, 49, 50),
		new SmoothTriangle(35, 50, 51, 35, 50, 51),
		new SmoothTriangle(36, 51, 52, 36, 51, 52),
		new SmoothTriangle(42, 52, 59, 42, 52, 59),
		new SmoothTriangle(43, 42, 60, 43, 42, 60),
		new SmoothTriangle(44, 43, 61, 44, 43, 61),
		new SmoothTriangle(45, 44, 62, 45, 44, 62),
		new SmoothTriangle(46, 45, 63, 46, 45, 63),
		new SmoothTriangle(128, 126, 46, 128, 126, 46),
		new SmoothTriangle(128, 46, 64, 128, 46, 64),
		new SmoothTriangle(127, 129, 53, 127, 129, 53),
		new SmoothTriangle(37, 53, 54, 37, 53, 54),
		new SmoothTriangle(38, 54, 55, 38, 54, 55),
		new SmoothTriangle(39, 55, 56, 39, 55, 56),
		new SmoothTriangle(40, 56, 57, 40, 56, 57),
		new SmoothTriangle(41, 57, 58, 41, 57, 58),
		new SmoothTriangle(47, 58, 65, 47, 58, 65),
		new SmoothTriangle(48, 47, 66, 48, 47, 66),
		new SmoothTriangle(49, 48, 67, 49, 48, 67),
		new SmoothTriangle(50, 49, 68, 50, 49, 68),
		new SmoothTriangle(51, 50, 69, 51, 50, 69),
		new SmoothTriangle(52, 51, 70, 52, 51, 70),
		new SmoothTriangle(59, 52, 71, 59, 52, 71),
		new SmoothTriangle(42, 59, 60, 42, 59, 60),
		new SmoothTriangle(43, 60, 61, 43, 60, 61),
		new SmoothTriangle(44, 61, 62, 44, 61, 62),
		new SmoothTriangle(45, 62, 63, 45, 62, 63),
		new SmoothTriangle(46, 63, 64, 46, 63, 64),
		new SmoothTriangle(130, 128, 64, 130, 128, 64),
		new SmoothTriangle(129, 131, 72, 129, 131, 72),
		new SmoothTriangle(129, 72, 53, 129, 72, 53),
		new SmoothTriangle(54, 53, 73, 54, 53, 73),
		new SmoothTriangle(55, 54, 74, 55, 54, 74),
		new SmoothTriangle(56, 55, 75, 56, 55, 75),
		new SmoothTriangle(57, 56, 76, 57, 56, 76),
		new SmoothTriangle(58, 57, 77, 58, 57, 77),
		new SmoothTriangle(65, 58, 78, 65, 58, 78),
		new SmoothTriangle(47, 65, 66, 47, 65, 66),
		new SmoothTriangle(48, 66, 67, 48, 66, 67),
		new SmoothTriangle(49, 67, 68, 49, 67, 68),
		new SmoothTriangle(50, 68, 69, 50, 68, 69),
		new SmoothTriangle(51, 69, 70, 51, 69, 70),
		new SmoothTriangle(52, 70, 71, 52, 70, 71),
		new SmoothTriangle(59, 71, 79, 59, 71, 79),
		new SmoothTriangle(60, 59, 80, 60, 59, 80),
		new SmoothTriangle(61, 60, 81, 61, 60, 81),
		new SmoothTriangle(62, 61, 82, 62, 61, 82),
		new SmoothTriangle(63, 62, 83, 63, 62, 83),
		new SmoothTriangle(64, 63, 84, 64, 63, 84),
		new SmoothTriangle(132, 130, 64, 132, 130, 64),
		new SmoothTriangle(132, 64, 85, 132, 64, 85),
		new SmoothTriangle(131, 133, 72, 131, 133, 72),
		new SmoothTriangle(53, 72, 73, 53, 72, 73),
		new SmoothTriangle(54, 73, 74, 54, 73, 74),
		new SmoothTriangle(55, 74, 75, 55, 74, 75),
		new SmoothTriangle(56, 75, 76, 56, 75, 76),
		new SmoothTriangle(57, 76, 77, 57, 76, 77),
		new SmoothTriangle(58, 77, 78, 58, 77, 78),
		new SmoothTriangle(65, 78, 86, 65, 78, 86),
		new SmoothTriangle(66, 65, 87, 66, 65, 87),
		new SmoothTriangle(67, 66, 88, 67, 66, 88),
		new SmoothTriangle(68, 67, 89, 68, 67, 89),
		new SmoothTriangle(69, 68, 90, 69, 68, 90),
		new SmoothTriangle(70, 69, 91, 70, 69, 91),
		new SmoothTriangle(71, 70, 92, 71, 70, 92),
		new SmoothTriangle(79, 71, 93, 79, 71, 93),
		new SmoothTriangle(59, 79, 80, 59, 79, 80),
		new SmoothTriangle(60, 80, 81, 60, 80, 81),
		new SmoothTriangle(61, 81, 82, 61, 81, 82),
		new SmoothTriangle(62, 82, 83, 62, 82, 83),
		new SmoothTriangle(63, 83, 84, 63, 83, 84),
		new SmoothTriangle(64, 84, 85, 64, 84, 85),
		new SmoothTriangle(134, 132, 85, 134, 132, 85),
		new SmoothTriangle(133, 135, 94, 133, 135, 94),
		new SmoothTriangle(133, 94, 72, 133, 94, 72),
		new SmoothTriangle(73, 72, 95, 73, 72, 95),
		new SmoothTriangle(74, 73, 96, 74, 73, 96),
		new SmoothTriangle(75, 74, 97, 75, 74, 97),
		new SmoothTriangle(76, 75, 98, 76, 75, 98),
		new SmoothTriangle(77, 76, 99, 77, 76, 99),
		new SmoothTriangle(78, 77, 100, 78, 77, 100),
		new SmoothTriangle(86, 78, 101, 86, 78, 101),
		new SmoothTriangle(65, 86, 87, 65, 86, 87),
		new SmoothTriangle(66, 87, 88, 66, 87, 88),
		new SmoothTriangle(67, 88, 89, 67, 88, 89),
		new SmoothTriangle(68, 89, 90, 68, 89, 90),
		new SmoothTriangle(69, 90, 91, 69, 90, 91),
		new SmoothTriangle(70, 91, 92, 70, 91, 92),
		new SmoothTriangle(71, 92, 93, 71, 92, 93),
		new SmoothTriangle(79, 93, 102, 79, 93, 102),
		new SmoothTriangle(80, 79, 103, 80, 79, 103),
		new SmoothTriangle(81, 80, 104, 81, 80, 104),
		new SmoothTriangle(82, 81, 105, 82, 81, 105),
		new SmoothTriangle(83, 82, 106, 83, 82, 106),
		new SmoothTriangle(84, 83, 107, 84, 83, 107),
		new SmoothTriangle(85, 84, 108, 85, 84, 108),
		new SmoothTriangle(136, 134, 85, 136, 134, 85),
		new SmoothTriangle(136, 85, 94, 136, 85, 94),
		new SmoothTriangle(135, 136, 94, 135, 136, 94),
		new SmoothTriangle(72, 94, 95, 72, 94, 95),
		new SmoothTriangle(73, 95, 96, 73, 95, 96),
		new SmoothTriangle(74, 96, 97, 74, 96, 97),
		new SmoothTriangle(75, 97, 98, 75, 97, 98),
		new SmoothTriangle(76, 98, 99, 76, 98, 99),
		new SmoothTriangle(85, 108, 94, 85, 108, 94),
		new SmoothTriangle(94, 108, 95, 94, 108, 95),
		new SmoothTriangle(95, 108, 137, 95, 108, 137),
		new SmoothTriangle(137, 108, 107, 137, 108, 107),
		new SmoothTriangle(95, 137, 96, 95, 137, 96),
		new SmoothTriangle(107, 108, 84, 107, 108, 84),
		new SmoothTriangle(137, 107, 138, 137, 107, 138),
		new SmoothTriangle(96, 137, 139, 96, 137, 139),
		new SmoothTriangle(138, 107, 106, 138, 107, 106),
		new SmoothTriangle(137, 138, 139, 137, 138, 139),
		new SmoothTriangle(96, 139, 97, 96, 139, 97),
		new SmoothTriangle(106, 107, 83, 106, 107, 83),
		new SmoothTriangle(138, 106, 140, 138, 106, 140),
		new SmoothTriangle(139, 138, 141, 139, 138, 141),
		new SmoothTriangle(97, 139, 142, 97, 139, 142),
		new SmoothTriangle(140, 106, 105, 140, 106, 105),
		new SmoothTriangle(138, 140, 141, 138, 140, 141),
		new SmoothTriangle(139, 141, 142, 139, 141, 142),
		new SmoothTriangle(97, 142, 98, 97, 142, 98),
		new SmoothTriangle(105, 106, 82, 105, 106, 82),
		new SmoothTriangle(140, 105, 143, 140, 105, 143),
		new SmoothTriangle(141, 140, 144, 141, 140, 144),
		new SmoothTriangle(142, 141, 145, 142, 141, 145),
		new SmoothTriangle(98, 142, 146, 98, 142, 146),
		new SmoothTriangle(143, 105, 104, 143, 105, 104),
		new SmoothTriangle(140, 143, 144, 140, 143, 144),
		new SmoothTriangle(141, 144, 145, 141, 144, 145),
		new SmoothTriangle(142, 145, 146, 142, 145, 146),
		new SmoothTriangle(98, 146, 99, 98, 146, 99),
		new SmoothTriangle(104, 105, 81, 104, 105, 81),
		new SmoothTriangle(143, 104, 147, 143, 104, 147),
		new SmoothTriangle(144, 143, 148, 144, 143, 148),
		new SmoothTriangle(145, 144, 149, 145, 144, 149),
		new SmoothTriangle(146, 145, 150, 146, 145, 150),
		new SmoothTriangle(99, 146, 151, 99, 146, 151),
		new SmoothTriangle(147, 104, 103, 147, 104, 103),
		new SmoothTriangle(143, 147, 148, 143, 147, 148),
		new SmoothTriangle(144, 148, 149, 144, 148, 149),
		new SmoothTriangle(145, 149, 150, 145, 149, 150),
		new SmoothTriangle(146, 150, 151, 146, 150, 151),
		new SmoothTriangle(99, 151, 100, 99, 151, 100),
		new SmoothTriangle(103, 104, 80, 103, 104, 80),
		new SmoothTriangle(147, 103, 152, 147, 103, 152),
		new SmoothTriangle(148, 147, 153, 148, 147, 153),
		new SmoothTriangle(149, 148, 154, 149, 148, 154),
		new SmoothTriangle(150, 149, 155, 150, 149, 155),
		new SmoothTriangle(151, 150, 156, 151, 150, 156),
		new SmoothTriangle(100, 151, 157, 100, 151, 157),
		new SmoothTriangle(99, 100, 77, 99, 100, 77),
		new SmoothTriangle(152, 103, 102, 152, 103, 102),
		new SmoothTriangle(147, 152, 153, 147, 152, 153),
		new SmoothTriangle(148, 153, 154, 148, 153, 154),
		new SmoothTriangle(149, 154, 155, 149, 154, 155),
		new SmoothTriangle(150, 155, 156, 150, 155, 156),
		new SmoothTriangle(151, 156, 157, 151, 156, 157),
		new SmoothTriangle(100, 157, 101, 100, 157, 101),
		new SmoothTriangle(102, 103, 79, 102, 103, 79),
		new SmoothTriangle(152, 102, 158, 152, 102, 158),
		new SmoothTriangle(153, 152, 159, 153, 152, 159),
		new SmoothTriangle(154, 153, 160, 154, 153, 160),
		new SmoothTriangle(155, 154, 161, 155, 154, 161),
		new SmoothTriangle(156, 155, 162, 156, 155, 162),
		new SmoothTriangle(157, 156, 163, 157, 156, 163),
		new SmoothTriangle(101, 157, 164, 101, 157, 164),
		new SmoothTriangle(100, 101, 78, 100, 101, 78),
		new SmoothTriangle(158, 102, 165, 158, 102, 165),
		new SmoothTriangle(152, 158, 159, 152, 158, 159),
		new SmoothTriangle(153, 159, 160, 153, 159, 160),
		new SmoothTriangle(154, 160, 161, 154, 160, 161),
		new SmoothTriangle(155, 161, 162, 155, 161, 162),
		new SmoothTriangle(156, 162, 163, 156, 162, 163),
		new SmoothTriangle(157, 163, 164, 157, 163, 164),
		new SmoothTriangle(101, 164, 166, 101, 164, 166),
		new SmoothTriangle(165, 102, 93, 165, 102, 93),
		new SmoothTriangle(158, 165, 167, 158, 165, 167),
		new SmoothTriangle(159, 158, 168, 159, 158, 168),
		new SmoothTriangle(160, 159, 169, 160, 159, 169),
		new SmoothTriangle(161, 160, 170, 161, 160, 170),
		new SmoothTriangle(162, 161, 171, 162, 161, 171),
		new SmoothTriangle(163, 162, 172, 163, 162, 172),
		new SmoothTriangle(164, 163, 173, 164, 163, 173),
		new SmoothTriangle(166, 164, 174, 166, 164, 174),
		new SmoothTriangle(101, 166, 86, 101, 166, 86),
		new SmoothTriangle(165, 93, 175, 165, 93, 175),
		new SmoothTriangle(167, 165, 176, 167, 165, 176),
		new SmoothTriangle(158, 167, 168, 158, 167, 168),
		new SmoothTriangle(159, 168, 169, 159, 168, 169),
		new SmoothTriangle(160, 169, 170, 160, 169, 170),
		new SmoothTriangle(161, 170, 171, 161, 170, 171),
		new SmoothTriangle(162, 171, 172, 162, 171, 172),
		new SmoothTriangle(163, 172, 173, 163, 172, 173),
		new SmoothTriangle(164, 173, 174, 164, 173, 174),
		new SmoothTriangle(166, 174, 177, 166, 174, 177),
		new SmoothTriangle(86, 166, 178, 86, 166, 178),
		new SmoothTriangle(175, 93, 92, 175, 93, 92),
		new SmoothTriangle(165, 175, 176, 165, 175, 176),
		new SmoothTriangle(167, 176, 179, 167, 176, 179),
		new SmoothTriangle(168, 167, 180, 168, 167, 180),
		new SmoothTriangle(169, 168, 181, 169, 168, 181),
		new SmoothTriangle(170, 169, 182, 170, 169, 182),
		new SmoothTriangle(171, 170, 183, 171, 170, 183),
		new SmoothTriangle(172, 171, 184, 172, 171, 184),
		new SmoothTriangle(173, 172, 185, 173, 172, 185),
		new SmoothTriangle(174, 173, 186, 174, 173, 186),
		new SmoothTriangle(177, 174, 187, 177, 174, 187),
		new SmoothTriangle(166, 177, 178, 166, 177, 178),
		new SmoothTriangle(86, 178, 87, 86, 178, 87),
		new SmoothTriangle(175, 92, 188, 175, 92, 188),
		new SmoothTriangle(176, 175, 189, 176, 175, 189),
		new SmoothTriangle(179, 176, 190, 179, 176, 190),
		new SmoothTriangle(167, 179, 180, 167, 179, 180),
		new SmoothTriangle(168, 180, 181, 168, 180, 181),
		new SmoothTriangle(169, 181, 182, 169, 181, 182),
		new SmoothTriangle(170, 182, 183, 170, 182, 183),
		new SmoothTriangle(171, 183, 184, 171, 183, 184),
		new SmoothTriangle(172, 184, 185, 172, 184, 185),
		new SmoothTriangle(173, 185, 186, 173, 185, 186),
		new SmoothTriangle(174, 186, 187, 174, 186, 187),
		new SmoothTriangle(177, 187, 191, 177, 187, 191),
		new SmoothTriangle(178, 177, 192, 178, 177, 192),
		new SmoothTriangle(87, 178, 193, 87, 178, 193),
		new SmoothTriangle(188, 92, 91, 188, 92, 91),
		new SmoothTriangle(175, 188, 189, 175, 188, 189),
		new SmoothTriangle(176, 189, 190, 176, 189, 190),
		new SmoothTriangle(179, 190, 194, 179, 190, 194),
		new SmoothTriangle(180, 179, 195, 180, 179, 195),
		new SmoothTriangle(181, 180, 196, 181, 180, 196),
		new SmoothTriangle(182, 181, 197, 182, 181, 197),
		new SmoothTriangle(183, 182, 198, 183, 182, 198),
		new SmoothTriangle(184, 183, 199, 184, 183, 199),
		new SmoothTriangle(185, 184, 200, 185, 184, 200),
		new SmoothTriangle(186, 185, 201, 186, 185, 201),
		new SmoothTriangle(187, 186, 202, 187, 186, 202),
		new SmoothTriangle(191, 187, 203, 191, 187, 203),
		new SmoothTriangle(177, 191, 192, 177, 191, 192),
		new SmoothTriangle(178, 192, 193, 178, 192, 193),
		new SmoothTriangle(87, 193, 88, 87, 193, 88),
		new SmoothTriangle(188, 91, 204, 188, 91, 204),
		new SmoothTriangle(189, 188, 205, 189, 188, 205),
		new SmoothTriangle(190, 189, 206, 190, 189, 206),
		new SmoothTriangle(194, 190, 207, 194, 190, 207),
		new SmoothTriangle(179, 194, 195, 179, 194, 195),
		new SmoothTriangle(180, 195, 196, 180, 195, 196),
		new SmoothTriangle(181, 196, 197, 181, 196, 197),
		new SmoothTriangle(182, 197, 198, 182, 197, 198),
		new SmoothTriangle(183, 198, 199, 183, 198, 199),
		new SmoothTriangle(184, 199, 200, 184, 199, 200),
		new SmoothTriangle(185, 200, 201, 185, 200, 201),
		new SmoothTriangle(186, 201, 202, 186, 201, 202),
		new SmoothTriangle(187, 202, 203, 187, 202, 203),
		new SmoothTriangle(191, 203, 208, 191, 203, 208),
		new SmoothTriangle(192, 191, 209, 192, 191, 209),
		new SmoothTriangle(193, 192, 210, 193, 192, 210),
		new SmoothTriangle(88, 193, 211, 88, 193, 211),
		new SmoothTriangle(204, 91, 90, 204, 91, 90),
		new SmoothTriangle(188, 204, 205, 188, 204, 205),
		new SmoothTriangle(189, 205, 206, 189, 205, 206),
		new SmoothTriangle(190, 206, 207, 190, 206, 207),
		new SmoothTriangle(221, 220, 194, 221, 220, 194),
		new SmoothTriangle(221, 194, 207, 221, 194, 207),
		new SmoothTriangle(223, 222, 195, 223, 222, 195),
		new SmoothTriangle(223, 195, 194, 223, 195, 194),
		new SmoothTriangle(196, 195, 212, 196, 195, 212),
		new SmoothTriangle(225, 224, 197, 225, 224, 197),
		new SmoothTriangle(225, 197, 196, 225, 197, 196),
		new SmoothTriangle(227, 226, 198, 227, 226, 198),
		new SmoothTriangle(227, 198, 197, 227, 198, 197),
		new SmoothTriangle(229, 228, 199, 229, 228, 199),
		new SmoothTriangle(229, 199, 198, 229, 199, 198),
		new SmoothTriangle(231, 230, 200, 231, 230, 200),
		new SmoothTriangle(231, 200, 199, 231, 200, 199),
		new SmoothTriangle(233, 232, 201, 233, 232, 201),
		new SmoothTriangle(233, 201, 200, 233, 201, 200),
		new SmoothTriangle(235, 234, 202, 235, 234, 202),
		new SmoothTriangle(235, 202, 201, 235, 202, 201),
		new SmoothTriangle(237, 236, 203, 237, 236, 203),
		new SmoothTriangle(237, 203, 202, 237, 203, 202),
		new SmoothTriangle(208, 203, 213, 208, 203, 213),
		new SmoothTriangle(191, 208, 209, 191, 208, 209),
		new SmoothTriangle(192, 209, 210, 192, 209, 210),
		new SmoothTriangle(193, 210, 211, 193, 210, 211),
		new SmoothTriangle(88, 211, 89, 88, 211, 89),
		new SmoothTriangle(204, 90, 214, 204, 90, 214),
		new SmoothTriangle(205, 204, 215, 205, 204, 215),
		new SmoothTriangle(206, 205, 216, 206, 205, 216),
		new SmoothTriangle(207, 206, 217, 207, 206, 217),
		new SmoothTriangle(238, 221, 207, 238, 221, 207),
		new SmoothTriangle(220, 223, 194, 220, 223, 194),
		new SmoothTriangle(222, 212, 195, 222, 212, 195),
		new SmoothTriangle(212, 225, 196, 212, 225, 196),
		new SmoothTriangle(224, 227, 197, 224, 227, 197),
		new SmoothTriangle(226, 229, 198, 226, 229, 198),
		new SmoothTriangle(228, 231, 199, 228, 231, 199),
		new SmoothTriangle(230, 233, 200, 230, 233, 200),
		new SmoothTriangle(232, 235, 201, 232, 235, 201),
		new SmoothTriangle(234, 237, 202, 234, 237, 202),
		new SmoothTriangle(236, 213, 203, 236, 213, 203),
		new SmoothTriangle(213, 239, 208, 213, 239, 208),
		new SmoothTriangle(209, 208, 218, 209, 208, 218),
		new SmoothTriangle(210, 209, 219, 210, 209, 219),
		new SmoothTriangle(89, 214, 90, 89, 214, 90),
		new SmoothTriangle(214, 89, 211, 214, 89, 211),
		new SmoothTriangle(214, 211, 240, 214, 211, 240),
		new SmoothTriangle(240, 211, 210, 240, 211, 210),
		new SmoothTriangle(214, 240, 215, 214, 240, 215),
		new SmoothTriangle(240, 210, 219, 240, 210, 219),
		new SmoothTriangle(215, 240, 241, 215, 240, 241),
		new SmoothTriangle(214, 215, 204, 214, 215, 204),
		new SmoothTriangle(240, 219, 241, 240, 219, 241),
		new SmoothTriangle(215, 241, 216, 215, 241, 216),
		new SmoothTriangle(241, 219, 242, 241, 219, 242),
		new SmoothTriangle(216, 241, 243, 216, 241, 243),
		new SmoothTriangle(215, 216, 205, 215, 216, 205),
		new SmoothTriangle(242, 219, 218, 242, 219, 218),
		new SmoothTriangle(241, 242, 243, 241, 242, 243),
		new SmoothTriangle(216, 243, 217, 216, 243, 217),
		new SmoothTriangle(218, 219, 209, 218, 219, 209),
		new SmoothTriangle(245, 244, 242, 245, 244, 242),
		new SmoothTriangle(245, 242, 218, 245, 242, 218),
		new SmoothTriangle(247, 246, 243, 247, 246, 243),
		new SmoothTriangle(247, 243, 242, 247, 243, 242),
		new SmoothTriangle(249, 248, 217, 249, 248, 217),
		new SmoothTriangle(249, 217, 243, 249, 217, 243),
		new SmoothTriangle(216, 217, 206, 216, 217, 206),
		new SmoothTriangle(250, 245, 218, 250, 245, 218),
		new SmoothTriangle(244, 247, 242, 244, 247, 242),
		new SmoothTriangle(246, 249, 243, 246, 249, 243),
		new SmoothTriangle(248, 251, 217, 248, 251, 217),
		new SmoothTriangle(239, 250, 218, 239, 250, 218),
		new SmoothTriangle(239, 218, 208, 239, 218, 208),
		new SmoothTriangle(251, 238, 207, 251, 238, 207),
		new SmoothTriangle(251, 207, 217, 251, 207, 217)
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Vector3D[] _0023_003Dzg_dccBg_003D = new Vector3D[252]
	{
		new Vector3D(0.101427690602753, 0.408800044364262, 0.906970201994955),
		new Vector3D(0.111909070607133, 0.0284035272509595, 0.99331243803526),
		new Vector3D(0.0755024948129435, 0.72693378504091, 0.682544244311765),
		new Vector3D(0.219608340142897, 0.38272833419934, 0.897380186509976),
		new Vector3D(0.166460580001342, 0.707153091222529, 0.687186569193577),
		new Vector3D(0.105350354106415, -0.356321942213488, 0.928405071284545),
		new Vector3D(0.239315664287557, -1.11033965330999E-15, 0.970941817426052),
		new Vector3D(0.087974814716521, 0.923892025163295, 0.372402950868086),
		new Vector3D(0.038083871173418, 0.934382698639424, 0.354229574202597),
		new Vector3D(0.326174376694613, 0.382728334199341, 0.864366414311013),
		new Vector3D(0.24807808272148, 0.707153091222529, 0.662111599692723),
		new Vector3D(0.132221594681148, 0.923892025163295, 0.359083521955044),
		new Vector3D(0.0827530960103604, -0.686777617627945, 0.722141557470545),
		new Vector3D(0.222579838740916, -0.382728334199341, 0.896647777885534),
		new Vector3D(0.354604887042535, -1.70567070146769E-15, 0.935016242685415),
		new Vector3D(-0.00375000256977584, 0.999991957398124, 0.0014221883823594),
		new Vector3D(-0.00389408669521428, 0.999991957398124, 0.000959806167097401),
		new Vector3D(-0.00398138626791684, 0.999991957398124, 0.000483427816624249),
		new Vector3D(0.427984056353391, 0.38272833419934, 0.81874823340774),
		new Vector3D(0.326078048372347, 0.707153091222529, 0.627381552122871),
		new Vector3D(0.174540286058222, 0.923892025163295, 0.340527846706225),
		new Vector3D(-0.00355123496259953, 0.999991957398124, 0.00186383188851717),
		new Vector3D(-0.00400184153020815, 0.99780111295218, -0.066158327183792),
		new Vector3D(0.0475604655741211, -0.912655128689696, 0.405953960678753),
		new Vector3D(0.171957998625597, -0.707153091222528, 0.685831577198879),
		new Vector3D(0.329035927618056, -0.382728334199341, 0.863281171193675),
		new Vector3D(0.464723172043769, -1.32768273438343E-15, 0.88545602565321),
		new Vector3D(-0.181098740332684, 0.923892025163296, -0.337085704368458),
		new Vector3D(-0.139147134850134, 0.923892025163295, -0.356457011016284),
		new Vector3D(-0.0951664508094081, 0.923892025163295, -0.370630371772208),
		new Vector3D(-0.0475604655741208, 0.912655128689697, -0.405953960678753),
		new Vector3D(0.00400184153020833, -0.99780111295218, 0.0661583271837909),
		new Vector3D(0.523552764734371, 0.382728334199341, 0.761190859600924),
		new Vector3D(0.399323061814126, 0.707153091222529, 0.583502868782848),
		new Vector3D(0.214313787034072, 0.923892025163295, 0.317006508650499),
		new Vector3D(-0.00330068235298401, 0.999991957398124, 0.00227829652875633),
		new Vector3D(-0.220409518382336, 0.923892025163296, -0.312798929100039),
		new Vector3D(0.00398138626791683, -0.999991957398124, -0.000483427816624423),
		new Vector3D(0.0951664508094081, -0.923892025163296, 0.370630371772207),
		new Vector3D(0.253372092737596, -0.707153091222529, 0.660103846524312),
		new Vector3D(0.430693931746142, -0.382728334199341, 0.817325981085911),
		new Vector3D(0.568064746731155, -9.63869316064842E-16, 0.822983865893657),
		new Vector3D(-0.403982750737421, 0.707153091222529, -0.580286517748817),
		new Vector3D(-0.331091451193217, 0.707153091222529, -0.624750315343011),
		new Vector3D(-0.253372092737596, 0.707153091222529, -0.660103846524312),
		new Vector3D(-0.171957998625596, 0.707153091222529, -0.685831577198878),
		new Vector3D(-0.0827530960103607, 0.686777617627946, -0.722141557470543),
		new Vector3D(0.611486894867372, 0.382728334199341, 0.692533609008586),
		new Vector3D(0.46674504581743, 0.707153091222529, 0.53111539968194),
		new Vector3D(0.250962110402345, 0.923892025163295, 0.288862501862159),
		new Vector3D(-0.00300199836217241, 0.999991957398124, 0.00265953847532941),
		new Vector3D(-0.256506229334962, 0.923892025163295, -0.283950841083495),
		new Vector3D(-0.470983072085944, 0.70715309122253, -0.527360836034406),
		new Vector3D(-0.0380838711734181, -0.934382698639425, -0.354229574202597),
		new Vector3D(0.00389408669521418, -0.999991957398124, -0.000959806167097868),
		new Vector3D(0.139147134850134, -0.923892025163296, 0.356457011016284),
		new Vector3D(0.331091451193217, -0.707153091222529, 0.624750315343011),
		new Vector3D(0.526071448511097, -0.382728334199341, 0.75945233771609),
		new Vector3D(0.663122658240795, -9.35520218533524E-16, 0.748510748171101),
		new Vector3D(-0.613777658947026, 0.38272833419934, -0.690504169124638),
		new Vector3D(-0.526071448511097, 0.382728334199341, -0.75945233771609),
		new Vector3D(-0.430693931746142, 0.382728334199341, -0.817325981085911),
		new Vector3D(-0.329035927618056, 0.382728334199341, -0.863281171193675),
		new Vector3D(-0.222579838740916, 0.382728334199341, -0.896647777885533),
		new Vector3D(-0.105350354106415, 0.356321942213487, -0.928405071284545),
		new Vector3D(0.690504169124637, 0.382728334199341, 0.613777658947027),
		new Vector3D(0.527360836034406, 0.707153091222529, 0.470983072085945),
		new Vector3D(0.283950841083495, 0.923892025163295, 0.256506229334962),
		new Vector3D(-0.00265953847532903, 0.999991957398124, 0.00300199836217267),
		new Vector3D(-0.288862501862159, 0.923892025163295, -0.250962110402346),
		new Vector3D(-0.531115399681939, 0.707153091222529, -0.46674504581743),
		new Vector3D(-0.692533609008585, 0.382728334199341, -0.611486894867373),
		new Vector3D(-0.0755024948129439, -0.72693378504091, -0.682544244311764),
		new Vector3D(-0.0879748147165211, -0.923892025163295, -0.372402950868087),
		new Vector3D(0.0037500025697758, -0.999991957398124, -0.00142218838235951),
		new Vector3D(0.181098740332684, -0.923892025163295, 0.337085704368458),
		new Vector3D(0.403982750737421, -0.707153091222529, 0.580286517748817),
		new Vector3D(0.613777658947026, -0.382728334199341, 0.690504169124638),
		new Vector3D(0.748510748171101, -3.21289772021614E-16, 0.663122658240796),
		new Vector3D(-0.748510748171101, -2.83490975313189E-17, -0.663122658240796),
		new Vector3D(-0.663122658240795, 6.8982803992876E-16, -0.748510748171101),
		new Vector3D(-0.568064746731155, 1.41745487656595E-16, -0.822983865893657),
		new Vector3D(-0.464723172043768, -4.86659507620974E-16, -0.88545602565321),
		new Vector3D(-0.354604887042535, 4.2051161338123E-16, -0.935016242685415),
		new Vector3D(-0.239315664287558, -1.55920036422254E-16, -0.970941817426052),
		new Vector3D(-0.111909070607135, -0.028403527250964, -0.993312438035259),
		new Vector3D(0.759452337716089, 0.382728334199341, 0.526071448511098),
		new Vector3D(0.580286517748816, 0.707153091222529, 0.403982750737422),
		new Vector3D(0.312798929100039, 0.923892025163295, 0.220409518382336),
		new Vector3D(-0.00227829652875632, 0.999991957398124, 0.00330068235298405),
		new Vector3D(-0.317006508650499, 0.923892025163295, -0.214313787034072),
		new Vector3D(-0.583502868782848, 0.707153091222529, -0.399323061814126),
		new Vector3D(-0.761190859600924, 0.382728334199341, -0.523552764734372),
		new Vector3D(-0.822983865893656, -1.13396390125276E-16, -0.568064746731156),
		new Vector3D(-0.101427690602751, -0.408800044364262, -0.906970201994955),
		new Vector3D(-0.166460580001342, -0.707153091222529, -0.687186569193576),
		new Vector3D(-0.132221594681148, -0.923892025163295, -0.359083521955044),
		new Vector3D(0.00355123496259968, -0.999991957398124, -0.00186383188851691),
		new Vector3D(0.220409518382336, -0.923892025163296, 0.312798929100039),
		new Vector3D(0.470983072085944, -0.707153091222529, 0.527360836034406),
		new Vector3D(0.692533609008585, -0.382728334199341, 0.611486894867373),
		new Vector3D(0.822983865893656, -1.7954428436502E-16, 0.568064746731156),
		new Vector3D(-0.75945233771609, -0.38272833419934, -0.526071448511098),
		new Vector3D(-0.690504169124637, -0.382728334199341, -0.613777658947026),
		new Vector3D(-0.611486894867372, -0.382728334199341, -0.692533609008586),
		new Vector3D(-0.523552764734372, -0.382728334199341, -0.761190859600924),
		new Vector3D(-0.42798405635339, -0.38272833419934, -0.818748233407741),
		new Vector3D(-0.326174376694613, -0.382728334199341, -0.864366414311013),
		new Vector3D(-0.219608340142897, -0.382728334199341, -0.897380186509976),
		new Vector3D(0.0592224502536195, 0.194747901501643, 0.979063816227862),
		new Vector3D(0.0557962234832677, 0.382132558711567, 0.922421535425944),
		new Vector3D(0.0603784974222875, -4.24460642100827E-15, 0.998175554223317),
		new Vector3D(0.050231154679175, 0.554868891572488, 0.830419980651186),
		new Vector3D(0.0592224502536177, -0.194747901501648, 0.979063816227861),
		new Vector3D(0.0427300444803821, 0.706510047297825, 0.706411846139297),
		new Vector3D(0.0557962234832647, -0.382132558711566, 0.922421535425945),
		new Vector3D(0.0335868475496427, 0.831000499372735, 0.555256781781135),
		new Vector3D(0.0502311546791745, -0.554868891572482, 0.830419980651189),
		new Vector3D(0.0231391362206489, 0.923650991237368, 0.382535523528455),
		new Vector3D(0.0427300444803834, -0.706510047297824, 0.706411846139298),
		new Vector3D(0.0117999688118978, 0.98071699611591, 0.195076739426884),
		new Vector3D(0.0335868475496438, -0.831000499372734, 0.555256781781136),
		new Vector3D(0.0231391362206511, -0.923650991237367, 0.382535523528457),
		new Vector3D(-0.0231391362206498, 0.923650991237369, -0.382535523528454),
		new Vector3D(-0.0335868475496438, 0.831000499372735, -0.555256781781134),
		new Vector3D(-0.0117999688118979, -0.98071699611591, -0.195076739426883),
		new Vector3D(-0.0427300444803851, 0.706510047297825, -0.706411846139297),
		new Vector3D(-0.0231391362206499, -0.923650991237369, -0.382535523528452),
		new Vector3D(-0.050231154679175, 0.554868891572485, -0.830419980651187),
		new Vector3D(-0.0335868475496434, -0.831000499372736, -0.555256781781133),
		new Vector3D(-0.0557962234832648, 0.382132558711566, -0.922421535425945),
		new Vector3D(-0.0427300444803844, -0.706510047297826, -0.706411846139296),
		new Vector3D(-0.0592224502536198, 0.194747901501636, -0.979063816227863),
		new Vector3D(-0.0502311546791742, -0.554868891572487, -0.830419980651186),
		new Vector3D(-0.0603784974222939, -8.98441692446747E-15, -0.998175554223317),
		new Vector3D(-0.0557962234832639, -0.382132558711567, -0.922421535425944),
		new Vector3D(-0.0592224502536191, -0.194747901501643, -0.979063816227862),
		new Vector3D(-0.24807808272148, -0.707153091222529, -0.662111599692722),
		new Vector3D(-0.326078048372346, -0.707153091222529, -0.627381552122871),
		new Vector3D(-0.174540286058222, -0.923892025163295, -0.340527846706225),
		new Vector3D(-0.399323061814125, -0.707153091222529, -0.583502868782848),
		new Vector3D(-0.214313787034072, -0.923892025163296, -0.317006508650499),
		new Vector3D(0.00330068235298423, -0.999991957398124, -0.00227829652875606),
		new Vector3D(-0.46674504581743, -0.707153091222529, -0.53111539968194),
		new Vector3D(-0.250962110402345, -0.923892025163296, -0.288862501862158),
		new Vector3D(0.00300199836217282, -0.999991957398124, -0.00265953847532893),
		new Vector3D(0.256506229334962, -0.923892025163296, 0.283950841083495),
		new Vector3D(-0.527360836034405, -0.707153091222529, -0.470983072085945),
		new Vector3D(-0.283950841083496, -0.923892025163295, -0.256506229334963),
		new Vector3D(0.00265953847532917, -0.999991957398124, -0.00300199836217256),
		new Vector3D(0.288862501862158, -0.923892025163296, 0.250962110402345),
		new Vector3D(0.531115399681939, -0.707153091222529, 0.466745045817431),
		new Vector3D(-0.580286517748816, -0.70715309122253, -0.403982750737421),
		new Vector3D(-0.312798929100039, -0.923892025163295, -0.220409518382337),
		new Vector3D(0.00227829652875632, -0.999991957398124, -0.00330068235298412),
		new Vector3D(0.317006508650499, -0.923892025163296, 0.214313787034072),
		new Vector3D(0.583502868782848, -0.707153091222529, 0.399323061814126),
		new Vector3D(0.761190859600923, -0.382728334199341, 0.523552764734372),
		new Vector3D(-0.624750315343011, -0.707153091222529, -0.331091451193216),
		new Vector3D(-0.337085704368458, -0.923892025163295, -0.181098740332684),
		new Vector3D(0.00186383188851695, -0.999991957398124, -0.00355123496259965),
		new Vector3D(0.340527846706225, -0.923892025163296, 0.174540286058222),
		new Vector3D(0.627381552122871, -0.70715309122253, 0.326078048372347),
		new Vector3D(0.81874823340774, -0.382728334199341, 0.427984056353391),
		new Vector3D(0.88545602565321, -2.64591576958976E-16, 0.464723172043769),
		new Vector3D(-0.817325981085911, -0.38272833419934, -0.430693931746143),
		new Vector3D(0.817325981085911, 0.382728334199342, 0.430693931746142),
		new Vector3D(-0.660103846524312, -0.707153091222529, -0.253372092737597),
		new Vector3D(-0.356457011016284, -0.923892025163295, -0.139147134850134),
		new Vector3D(0.00142218838235931, -0.999991957398124, -0.00375000256977586),
		new Vector3D(0.359083521955044, -0.923892025163296, 0.132221594681148),
		new Vector3D(0.662111599692722, -0.707153091222529, 0.24807808272148),
		new Vector3D(0.864366414311013, -0.382728334199341, 0.326174376694613),
		new Vector3D(0.935016242685415, -1.08671540536722E-16, 0.354604887042536),
		new Vector3D(0.863281171193675, 0.382728334199341, 0.329035927618057),
		new Vector3D(-0.88545602565321, -2.03168532307785E-16, -0.464723172043769),
		new Vector3D(-0.863281171193675, -0.38272833419934, -0.329035927618057),
		new Vector3D(0.660103846524312, 0.707153091222529, 0.253372092737596),
		new Vector3D(0.624750315343011, 0.707153091222529, 0.331091451193217),
		new Vector3D(-0.685831577198878, -0.707153091222529, -0.171957998625597),
		new Vector3D(-0.370630371772208, -0.923892025163295, -0.0951664508094085),
		new Vector3D(0.000959806167097439, -0.999991957398124, -0.00389408669521427),
		new Vector3D(0.372402950868086, -0.923892025163296, 0.0879748147165213),
		new Vector3D(0.687186569193576, -0.707153091222529, 0.166460580001343),
		new Vector3D(0.897380186509976, -0.38272833419934, 0.219608340142897),
		new Vector3D(0.970941817426052, -1.93718833130679E-16, 0.239315664287558),
		new Vector3D(0.896647777885534, 0.382728334199341, 0.222579838740917),
		new Vector3D(0.685831577198879, 0.707153091222529, 0.171957998625597),
		new Vector3D(-0.81874823340774, 0.382728334199341, -0.427984056353391),
		new Vector3D(-0.935016242685415, 2.12618231484892E-16, -0.354604887042536),
		new Vector3D(-0.896647777885534, -0.38272833419934, -0.222579838740917),
		new Vector3D(0.370630371772208, 0.923892025163295, 0.0951664508094085),
		new Vector3D(0.356457011016284, 0.923892025163295, 0.139147134850134),
		new Vector3D(0.337085704368458, 0.923892025163295, 0.181098740332684),
		new Vector3D(-0.722141557470543, -0.686777617627947, -0.0827530960103604),
		new Vector3D(-0.405953960678754, -0.912655128689696, -0.0475604655741207),
		new Vector3D(0.000483427816624286, -0.999991957398124, -0.0039813862679169),
		new Vector3D(0.354229574202597, -0.934382698639424, 0.0380838711734181),
		new Vector3D(0.682544244311764, -0.72693378504091, 0.0755024948129437),
		new Vector3D(0.906970201994955, -0.408800044364262, 0.101427690602753),
		new Vector3D(0.99331243803526, -0.0284035272509607, 0.111909070607133),
		new Vector3D(0.928405071284545, 0.356321942213488, 0.105350354106415),
		new Vector3D(0.722141557470544, 0.686777617627946, 0.0827530960103605),
		new Vector3D(0.405953960678753, 0.912655128689697, 0.0475604655741208),
		new Vector3D(-0.627381552122871, 0.707153091222529, -0.326078048372347),
		new Vector3D(-0.864366414311014, 0.38272833419934, -0.326174376694613),
		new Vector3D(-0.970941817426052, 2.92940674490295E-16, -0.239315664287558),
		new Vector3D(-0.928405071284545, -0.356321942213486, -0.105350354106415),
		new Vector3D(-0.000483427816624329, 0.999991957398124, 0.00398138626791689),
		new Vector3D(-0.000959806167097873, 0.999991957398124, 0.00389408669521416),
		new Vector3D(-0.00142218838235951, 0.999991957398124, 0.0037500025697758),
		new Vector3D(-0.00186383188851706, 0.999991957398124, 0.00355123496259962),
		new Vector3D(-0.0661583271837911, -0.99780111295218, -0.00400184153020779),
		new Vector3D(0.066158327183792, 0.99780111295218, 0.00400184153020808),
		new Vector3D(-0.340527846706225, 0.923892025163296, -0.174540286058222),
		new Vector3D(-0.662111599692723, 0.707153091222529, -0.24807808272148),
		new Vector3D(-0.897380186509976, 0.38272833419934, -0.219608340142898),
		new Vector3D(-0.993312438035259, 0.0284035272509647, -0.111909070607134),
		new Vector3D(-0.354229574202597, 0.934382698639424, -0.0380838711734182),
		new Vector3D(-0.372402950868086, 0.923892025163295, -0.0879748147165214),
		new Vector3D(-0.706411846139295, -0.706510047297827, -0.0427300444803823),
		new Vector3D(-0.830419980651189, -0.554868891572482, -0.0502311546791751),
		new Vector3D(-0.382535523528458, -0.923650991237367, -0.0231391362206484),
		new Vector3D(-0.555256781781134, -0.831000499372735, -0.0335868475496426),
		new Vector3D(0.382535523528455, -0.923650991237368, 0.0231391362206494),
		new Vector3D(0.195076739426883, -0.98071699611591, 0.0117999688118979),
		new Vector3D(0.706411846139298, -0.706510047297824, 0.042730044480383),
		new Vector3D(0.555256781781134, -0.831000499372735, 0.0335868475496427),
		new Vector3D(0.922421535425944, -0.382132558711567, 0.055796223483267),
		new Vector3D(0.830419980651187, -0.554868891572486, 0.0502311546791748),
		new Vector3D(0.998175554223317, 2.67410204523521E-15, 0.0603784974222866),
		new Vector3D(0.979063816227862, -0.194747901501643, 0.0592224502536185),
		new Vector3D(0.922421535425944, 0.382132558711568, 0.0557962234832668),
		new Vector3D(0.979063816227861, 0.194747901501645, 0.0592224502536179),
		new Vector3D(0.706411846139298, 0.706510047297824, 0.0427300444803833),
		new Vector3D(0.830419980651187, 0.554868891572487, 0.0502311546791749),
		new Vector3D(0.382535523528454, 0.923650991237369, 0.0231391362206494),
		new Vector3D(0.555256781781134, 0.831000499372735, 0.033586847549643),
		new Vector3D(-0.922421535425945, -0.382132558711564, -0.0557962234832686),
		new Vector3D(-0.195076739426883, 0.98071699611591, -0.0117999688118979),
		new Vector3D(-0.359083521955044, 0.923892025163295, -0.132221594681148),
		new Vector3D(-0.687186569193576, 0.707153091222529, -0.166460580001343),
		new Vector3D(-0.682544244311764, 0.72693378504091, -0.0755024948129445),
		new Vector3D(-0.906970201994954, 0.408800044364263, -0.101427690602753),
		new Vector3D(-0.706411846139296, 0.706510047297825, -0.0427300444803847),
		new Vector3D(-0.555256781781134, 0.831000499372735, -0.0335868475496436),
		new Vector3D(-0.922421535425942, 0.382132558711572, -0.0557962234832696),
		new Vector3D(-0.830419980651188, 0.554868891572484, -0.0502311546791766),
		new Vector3D(-0.998175554223317, 1.29036035198651E-14, -0.0603784974222916),
		new Vector3D(-0.97906381622786, 0.194747901501649, -0.0592224502536202),
		new Vector3D(-0.382535523528455, 0.923650991237368, -0.0231391362206497),
		new Vector3D(-0.979063816227863, -0.194747901501635, -0.0592224502536191)
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IndexLine[] _0023_003Dze7vsjYE_003D = new IndexLine[60]
	{
		new IndexLine(22, 120),
		new IndexLine(22, 123),
		new IndexLine(31, 122),
		new IndexLine(31, 125),
		new IndexLine(109, 110),
		new IndexLine(109, 111),
		new IndexLine(110, 112),
		new IndexLine(111, 113),
		new IndexLine(112, 114),
		new IndexLine(113, 115),
		new IndexLine(114, 116),
		new IndexLine(115, 117),
		new IndexLine(116, 118),
		new IndexLine(117, 119),
		new IndexLine(118, 120),
		new IndexLine(119, 121),
		new IndexLine(121, 122),
		new IndexLine(123, 124),
		new IndexLine(124, 126),
		new IndexLine(125, 127),
		new IndexLine(126, 128),
		new IndexLine(127, 129),
		new IndexLine(128, 130),
		new IndexLine(129, 131),
		new IndexLine(130, 132),
		new IndexLine(131, 133),
		new IndexLine(132, 134),
		new IndexLine(133, 135),
		new IndexLine(134, 136),
		new IndexLine(135, 136),
		new IndexLine(212, 222),
		new IndexLine(212, 225),
		new IndexLine(213, 236),
		new IndexLine(213, 239),
		new IndexLine(220, 221),
		new IndexLine(220, 223),
		new IndexLine(221, 238),
		new IndexLine(222, 223),
		new IndexLine(224, 225),
		new IndexLine(224, 227),
		new IndexLine(226, 227),
		new IndexLine(226, 229),
		new IndexLine(228, 229),
		new IndexLine(228, 231),
		new IndexLine(230, 231),
		new IndexLine(230, 233),
		new IndexLine(232, 233),
		new IndexLine(232, 235),
		new IndexLine(234, 235),
		new IndexLine(234, 237),
		new IndexLine(236, 237),
		new IndexLine(238, 251),
		new IndexLine(239, 250),
		new IndexLine(244, 245),
		new IndexLine(244, 247),
		new IndexLine(245, 250),
		new IndexLine(246, 247),
		new IndexLine(246, 249),
		new IndexLine(248, 249),
		new IndexLine(248, 251)
	};

	protected internal static Color DefaultArrowColorX => Color.Red;

	protected internal static Color DefaultArrowColorY => Color.Green;

	protected internal static Color DefaultArrowColorZ => Color.Blue;

	protected internal static Color DefaultBallColor => Color.DarkOrange;

	[Browsable(false)]
	public int TransformationLabelRadius
	{
		get
		{
			return _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.CornerRadius;
		}
		set
		{
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.CornerRadius = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Value's numeric format. Useful to change number format and decimal places.")]
	public string FormatString
	{
		get
		{
			return _0023_003DzPkzw1z5rqyYA;
		}
		set
		{
			if (_0023_003DzPkzw1z5rqyYA != value)
			{
				_0023_003DzPkzw1z5rqyYA = value;
			}
		}
	}

	public Vector3D TransformationLabelOffset
	{
		get
		{
			return new Vector3D(_0023_003Dzo7sDYnjZFyS1, _0023_003DzgKmhOzpIjgc2);
		}
		set
		{
			_0023_003Dzo7sDYnjZFyS1 = (int)value.X;
			_0023_003DzgKmhOzpIjgc2 = (int)value.Y;
		}
	}

	[Browsable(false)]
	public angularUnitsType TransformationLabelAngularUnitsType
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzubHct5dMUgT2ht4L3LhDGw28lPL0EHIN8w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzubHct5dMUgT2ht4L3LhDGw28lPL0EHIN8w_003D_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true, a label containing the information about the current transformation is shown.")]
	[Browsable(false)]
	public bool ShowTransformationLabel
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDp6FmKAkfieBsdgVTVwXq5k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDp6FmKAkfieBsdgVTVwXq5k_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TransformationLabelFillColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzz88ws9_0024ulDWnMqv1nZuiCG4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzz88ws9_0024ulDWnMqv1nZuiCG4_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Color TransformationLabelTextColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3W88KlTLIj39_0024ucn7yh45i0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3W88KlTLIj39_0024ucn7yh45i0_003D = value;
		}
	}

	[Browsable(false)]
	public override Color LabelColorName
	{
		get
		{
			return base.LabelColorName;
		}
		set
		{
			base.LabelColorName = value;
		}
	}

	[Browsable(false)]
	public override Color LabelColorX
	{
		get
		{
			return base.LabelColorX;
		}
		set
		{
			base.LabelColorX = value;
		}
	}

	[Browsable(false)]
	public override Color LabelColorY
	{
		get
		{
			return base.LabelColorY;
		}
		set
		{
			base.LabelColorY = value;
		}
	}

	[Browsable(false)]
	public override Color LabelColorZ
	{
		get
		{
			return base.LabelColorZ;
		}
		set
		{
			base.LabelColorZ = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Label font.")]
	public override Font LabelFont
	{
		get
		{
			return base.LabelFont;
		}
		set
		{
			if (value != _0023_003DzzmO0Pua6gdb0)
			{
				if (disposeFont)
				{
					_0023_003DzzmO0Pua6gdb0.Dispose();
					disposeFont = false;
				}
				_0023_003DzzmO0Pua6gdb0 = value;
				_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Font = value;
			}
		}
	}

	[Browsable(false)]
	public override Color ArrowColorX
	{
		get
		{
			return RenderContextUtility.ConvertColor(TranslateX.Color);
		}
		set
		{
			if (TranslateX != null)
			{
				TranslateX.Color = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Browsable(false)]
	public override Color ArrowColorY
	{
		get
		{
			return RenderContextUtility.ConvertColor(TranslateY.Color);
		}
		set
		{
			if (TranslateY != null)
			{
				TranslateY.Color = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Browsable(false)]
	public override Color ArrowColorZ
	{
		get
		{
			return RenderContextUtility.ConvertColor(TranslateZ.Color);
		}
		set
		{
			if (TranslateZ != null)
			{
				TranslateZ.Color = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Point3D Position
	{
		get
		{
			return center;
		}
		set
		{
			center = value;
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.AnchorPoint = center;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string LabelAxisX
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string LabelAxisY
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string LabelAxisZ
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string LabelOrigin
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true the preview is drawn inside the scene, otherwise it will be drawn on top of each other entity.")]
	public bool ShowPreviewOnTop
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzB9dgHsvxJnKvwtZdEZRMfk4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzB9dgHsvxJnKvwtZdEZRMfk4_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true, both the original and edited copies of the entities are shown during editing, else only the edited copies are shown.")]
	public bool ShowOriginalWhileEditing
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQH_bZoIQz92yO35PwUPGyhFeKdhp;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQH_bZoIQz92yO35PwUPGyhFeKdhp = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool ShowDraggedItemOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dza9D63iNEj_0024ocdn86JFpJeKI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dza9D63iNEj_0024ocdn86JFpJeKI_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the transformation sphere.")]
	public ObjectManipulatorPartProperties Ball
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[0];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[0] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arrow for the translation on X axis.")]
	public ObjectManipulatorPartProperties TranslateX
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[1];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[1] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arrow for the translation on Y axis.")]
	public ObjectManipulatorPartProperties TranslateY
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[2];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[2] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arrow for the translation on Z axis.")]
	public ObjectManipulatorPartProperties TranslateZ
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[3];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[3] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arc for the rotation around X axis.")]
	public ObjectManipulatorPartProperties RotateX
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[4];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[4] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arc for the rotation around Y axis.")]
	public ObjectManipulatorPartProperties RotateY
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[5];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[5] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the arc for the rotation around Z axis.")]
	public ObjectManipulatorPartProperties RotateZ
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[6];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[6] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the box for the scaling on Z axis.")]
	public ObjectManipulatorPartProperties ScaleZ
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[9];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[9] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the box for the scaling on Y axis.")]
	public ObjectManipulatorPartProperties ScaleY
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[8];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[8] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Properties of the box for the scaling on X axis.")]
	public ObjectManipulatorPartProperties ScaleX
	{
		get
		{
			return _0023_003DzsndQ1PQ_003D[7];
		}
		set
		{
			_0023_003DzsndQ1PQ_003D[7] = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Rotation step angle in radians.")]
	public double RotationStep
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzY9cmPPcRA_VvJ_JV4tAzeyI_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzY9cmPPcRA_VvJ_JV4tAzeyI_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Translation step distance.")]
	public double TranslationStep
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzw8KIRZgiGcbASbFAZHtSQ2s_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzw8KIRZgiGcbASbFAZHtSQ2s_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("Scaling step distance.")]
	public double ScalingStep
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzITIdNiZF1MulGyn1kTRVe_0024w_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzITIdNiZF1MulGyn1kTRVe_0024w_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Translation range.")]
	public Interval TranslationRange
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztLz9G4f2MbVf8jVqFgnf_0024ZU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DztLz9G4f2MbVf8jVqFgnf_0024ZU_003D = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("The style of the object manipulator.")]
	public styleType StyleMode
	{
		get
		{
			return _0023_003Dzp3jg0wwRHRrc;
		}
		set
		{
			_0023_003Dzp3jg0wwRHRrc = value;
			_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Description("The action mode applyed to the orgin sphere of the manipulator. ")]
	public ballActionType BallActionMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzcFYy31myW_00242OMA4JlsKzBgU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzcFYy31myW_00242OMA4JlsKzBgU_003D = value;
		}
	}

	protected override bool HasTextureCoords => false;

	[Browsable(false)]
	public override Transformation Transformation
	{
		get
		{
			return _0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D;
		}
		set
		{
			_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D = value;
			_0023_003Dz36GfUMHowvLS();
			if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
			{
				double[] matrixAsVectorByColumn = Transformation.MatrixAsVectorByColumn;
				_0023_003DzZWjOo62HF93770pqyezGoeo_003D().Plane = new Plane(new Point3D(matrixAsVectorByColumn[12], matrixAsVectorByColumn[13], matrixAsVectorByColumn[14]), new Vector3D(matrixAsVectorByColumn[0], matrixAsVectorByColumn[1], matrixAsVectorByColumn[2]), new Vector3D(matrixAsVectorByColumn[4], matrixAsVectorByColumn[5], matrixAsVectorByColumn[6]));
				((ClippingPlane)_0023_003DzZWjOo62HF93770pqyezGoeo_003D()).BuildClippingPlaneMesh(_0023_003DzgwMhmLr71vvSEwxwRBGdQ1c_003D);
				UpdateBoundingBox();
			}
		}
	}

	[Browsable(false)]
	public Transformation InitialTransformation
	{
		get
		{
			return _0023_003DzWehfaDZ7KlrO;
		}
		set
		{
			_0023_003DzWehfaDZ7KlrO = value ?? new Identity();
			_0023_003DzNo6p8zohxgTa = (Transformation)_0023_003DzWehfaDZ7KlrO.Clone();
			_0023_003DzNo6p8zohxgTa.Invert();
			Transformation = (Transformation)_0023_003DzWehfaDZ7KlrO.Clone();
		}
	}

	public event ObjectManipulatorEventHandler MouseDown
	{
		[CompilerGenerated]
		add
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzM133s9Ir1jmo;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Combine(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzM133s9Ir1jmo, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzM133s9Ir1jmo;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Remove(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzM133s9Ir1jmo, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
	}

	public event ObjectManipulatorEventHandler MouseUp
	{
		[CompilerGenerated]
		add
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzAiRqlf34N5UH;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Combine(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzAiRqlf34N5UH, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzAiRqlf34N5UH;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Remove(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzAiRqlf34N5UH, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
	}

	public event ObjectManipulatorEventHandler MouseOver
	{
		[CompilerGenerated]
		add
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzEdy5_0024KyZ0bNx;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Combine(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzEdy5_0024KyZ0bNx, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003DzEdy5_0024KyZ0bNx;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Remove(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003DzEdy5_0024KyZ0bNx, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
	}

	public event ObjectManipulatorEventHandler MouseDrag
	{
		[CompilerGenerated]
		add
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003Dzf_0024V9OVGSB1gu;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Combine(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003Dzf_0024V9OVGSB1gu, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ObjectManipulatorEventHandler objectManipulatorEventHandler = _0023_003Dzf_0024V9OVGSB1gu;
			ObjectManipulatorEventHandler objectManipulatorEventHandler2;
			do
			{
				objectManipulatorEventHandler2 = objectManipulatorEventHandler;
				ObjectManipulatorEventHandler value2 = (ObjectManipulatorEventHandler)Delegate.Remove(objectManipulatorEventHandler2, value);
				objectManipulatorEventHandler = Interlocked.CompareExchange(ref _0023_003Dzf_0024V9OVGSB1gu, value2, objectManipulatorEventHandler2);
			}
			while ((object)objectManipulatorEventHandler != objectManipulatorEventHandler2);
		}
	}

	public ObjectManipulator()
		: this(_0023_003DzmuZmjj_0024WEUbi(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DzPLZ_wzWVRFPk2THN_0024g_003D_003D(), _0023_003DzCp6SpVT8Q9QG(), _0023_003DzipNQapGTOSUQer2avg_003D_003D(), _0023_003DzGnW5VGS6k0W9(), _0023_003Dz865FUlRo9Ybb(), _0023_003DznGpZh_WdU5t_0024(), _0023_003DzZJLKi13kUrWn(), _0023_003Dz0SfXhbF7eXGH(), _0023_003DzMrF0pZj_0024c68H(), _0023_003DzZ_yXrQQx8Zwy(), _0023_003Dz6L45bgjomsqw(), _0023_003Dz7zroHPsUES_0024y(), _0023_003Dz2VvS96oHJro5(), _0023_003DzSUmnVLLl6Q_Y(), _0023_003DzwN0KXdWCh5DN(), _0023_003DzRFdvORg86iEi(), _0023_003Dzqf3DoNdmn51vDQXD2w_003D_003D(), _0023_003DzEAqV1yPU_0024DxR1lwS_A_003D_003D(), lighting: false)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public ObjectManipulator(int ballSize, bool visible, bool showOriginalWhileEditing, ObjectManipulatorPartProperties ball, ObjectManipulatorPartProperties translateX, ObjectManipulatorPartProperties translateY, ObjectManipulatorPartProperties translateZ, ObjectManipulatorPartProperties rotateX, ObjectManipulatorPartProperties rotateY, ObjectManipulatorPartProperties rotateZ)
		: this(ballSize, visible, showOriginalWhileEditing, ball, translateX, translateY, translateZ, rotateX, rotateY, rotateZ, 0.0, 0.0)
	{
	}

	public ObjectManipulator(int ballSize, bool visible, bool showOriginalWhileEditing, ObjectManipulatorPartProperties ball, ObjectManipulatorPartProperties translateX, ObjectManipulatorPartProperties translateY, ObjectManipulatorPartProperties translateZ, ObjectManipulatorPartProperties rotateX, ObjectManipulatorPartProperties rotateY, ObjectManipulatorPartProperties rotateZ, double rotationStep, double translationStep)
		: this(ballSize, visible, showOriginalWhileEditing, ball, translateX, translateY, translateZ, rotateX, rotateY, rotateZ, rotationStep, translationStep, lighting: false)
	{
	}

	public ObjectManipulator(int ballSize, bool visible, bool showOriginalWhileEditing, ObjectManipulatorPartProperties ball, ObjectManipulatorPartProperties translateX, ObjectManipulatorPartProperties translateY, ObjectManipulatorPartProperties translateZ, ObjectManipulatorPartProperties rotateX, ObjectManipulatorPartProperties rotateY, ObjectManipulatorPartProperties rotateZ, double rotationStep, double translationStep, bool lighting)
		: this(ballSize, visible, showOriginalWhileEditing, _0023_003DzCp6SpVT8Q9QG(), _0023_003DzipNQapGTOSUQer2avg_003D_003D(), ball, translateX, translateY, translateZ, rotateX, rotateY, rotateZ, _0023_003Dz6L45bgjomsqw(), _0023_003Dz7zroHPsUES_0024y(), _0023_003Dz2VvS96oHJro5(), rotationStep, translationStep, _0023_003DzRFdvORg86iEi(), _0023_003Dzqf3DoNdmn51vDQXD2w_003D_003D(), _0023_003DzEAqV1yPU_0024DxR1lwS_A_003D_003D(), lighting)
	{
	}

	private ObjectManipulator(ObjectManipulator _0023_003DzsmgIqeCnnRrL)
		: this(_0023_003DzsmgIqeCnnRrL._0023_003DzgTjCWc4_003D, _0023_003DzsmgIqeCnnRrL.Visible, _0023_003DzsmgIqeCnnRrL.ShowOriginalWhileEditing, _0023_003DzsmgIqeCnnRrL.StyleMode, _0023_003DzsmgIqeCnnRrL.BallActionMode, _0023_003DzsmgIqeCnnRrL.Ball, _0023_003DzsmgIqeCnnRrL.TranslateX, _0023_003DzsmgIqeCnnRrL.TranslateY, _0023_003DzsmgIqeCnnRrL.TranslateZ, _0023_003DzsmgIqeCnnRrL.RotateX, _0023_003DzsmgIqeCnnRrL.RotateY, _0023_003DzsmgIqeCnnRrL.RotateZ, _0023_003DzsmgIqeCnnRrL.ScaleX, _0023_003DzsmgIqeCnnRrL.ScaleY, _0023_003DzsmgIqeCnnRrL.ScaleZ, _0023_003DzsmgIqeCnnRrL.RotationStep, _0023_003DzsmgIqeCnnRrL.TranslationStep, _0023_003DzsmgIqeCnnRrL.ScalingStep, _0023_003DzsmgIqeCnnRrL.TransformationLabelFillColor, _0023_003DzsmgIqeCnnRrL.TransformationLabelTextColor, _0023_003DzsmgIqeCnnRrL.Lighting)
	{
	}

	public ObjectManipulator(int ballSize, bool visible, bool showOriginalWhileEditing, styleType styleMode, ballActionType ballActionMode, ObjectManipulatorPartProperties ball, ObjectManipulatorPartProperties translateX, ObjectManipulatorPartProperties translateY, ObjectManipulatorPartProperties translateZ, ObjectManipulatorPartProperties rotateX, ObjectManipulatorPartProperties rotateY, ObjectManipulatorPartProperties rotateZ, ObjectManipulatorPartProperties scaleX, ObjectManipulatorPartProperties scaleY, ObjectManipulatorPartProperties scaleZ, double rotationStep, double translationStep, double scalingStep, Color transformationLabelFill, Color transformationLabelTextColor, Font labelFont, bool lighting)
		: base(CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), CoordinateSystemBase._0023_003Dz3S5baIME1gm5(), translateX.Color, translateY.Color, translateZ.Color, null, null, null, null, visible, ballSize, null, lighting)
	{
		Ball = ball;
		TranslateX = translateX;
		TranslateY = translateY;
		TranslateZ = translateZ;
		RotateX = rotateX;
		RotateY = rotateY;
		RotateZ = rotateZ;
		ScaleX = scaleX;
		ScaleY = scaleY;
		ScaleZ = scaleZ;
		_0023_003Dzp3jg0wwRHRrc = styleMode;
		BallActionMode = ballActionMode;
		_0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D();
		_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D = new Identity();
		ShowOriginalWhileEditing = showOriginalWhileEditing;
		RotationStep = rotationStep;
		TranslationStep = translationStep;
		ScalingStep = scalingStep;
		_0023_003DzY78HOYOBdP1l(transformationLabelFill, transformationLabelTextColor, labelFont);
	}

	public ObjectManipulator(int ballSize, bool visible, bool showOriginalWhileEditing, styleType styleMode, ballActionType ballActionMode, ObjectManipulatorPartProperties ball, ObjectManipulatorPartProperties translateX, ObjectManipulatorPartProperties translateY, ObjectManipulatorPartProperties translateZ, ObjectManipulatorPartProperties rotateX, ObjectManipulatorPartProperties rotateY, ObjectManipulatorPartProperties rotateZ, ObjectManipulatorPartProperties scaleX, ObjectManipulatorPartProperties scaleY, ObjectManipulatorPartProperties scaleZ, double rotationStep, double translationStep, double scalingStep, Color transformationLabelFill, Color transformationLabelTextColor, bool lighting)
		: this(ballSize, visible, showOriginalWhileEditing, styleMode, ballActionMode, ball, translateX, translateY, translateZ, rotateX, rotateY, rotateZ, scaleX, scaleY, scaleZ, rotationStep, translationStep, scalingStep, transformationLabelFill, transformationLabelTextColor, CoordinateSystemBase._0023_003Dz0UloR3WvSVa2(), lighting)
	{
	}

	private void _0023_003DzQlLiYkSPe_HlAdaJQdoxyPpfXJfY_0024bNGSt2F_ixlLMT_0024zhJpmxkAmqg_003D(ClippingPlane _0023_003DzZWcyf2p3a_mrcR32EIL4AW0_003D, Color _0023_003Dzt6kJ_0024QY_003D, bool _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D)
	{
		_0023_003DzqEXfiU18n6I61BI5dg_003D_003D(_0023_003DzZWcyf2p3a_mrcR32EIL4AW0_003D, _0023_003Dzt6kJ_0024QY_003D, _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D);
	}

	void IObjectManipulator.EditClippingPlane(ClippingPlane _0023_003DzZWcyf2p3a_mrcR32EIL4AW0_003D, Color _0023_003Dzt6kJ_0024QY_003D, bool _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zQlLiYkSPe_HlAdaJQdoxyPpfXJfY$bNGSt2F_ixlLMT$zhJpmxkAmqg=
		this._0023_003DzQlLiYkSPe_HlAdaJQdoxyPpfXJfY_0024bNGSt2F_ixlLMT_0024zhJpmxkAmqg_003D(_0023_003DzZWcyf2p3a_mrcR32EIL4AW0_003D, _0023_003Dzt6kJ_0024QY_003D, _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D);
	}

	private bool _0023_003DzLqmzTZzgEEQiPss9_vQ_00242kk0qM7lu8F7BN3h24u0fwbNPjWqKtggYTsNr0f4()
	{
		return _0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D();
	}

	bool IObjectManipulator.get_editingClippingPlane()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zLqmzTZzgEEQiPss9_vQ$2kk0qM7lu8F7BN3h24u0fwbNPjWqKtggYTsNr0f4
		return this._0023_003DzLqmzTZzgEEQiPss9_vQ_00242kk0qM7lu8F7BN3h24u0fwbNPjWqKtggYTsNr0f4();
	}

	private ClippingPlaneBase _0023_003DzUXvewGj_vwgA62Y1I3AoJyiIrq4_0dhWYWsrSHtOJwQOppzD9TKaGTTTU0nT_A5qAg_003D_003D()
	{
		return _0023_003DzZWjOo62HF93770pqyezGoeo_003D();
	}

	ClippingPlaneBase IObjectManipulator.get_clippingPlane()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=zUXvewGj_vwgA62Y1I3AoJyiIrq4_0dhWYWsrSHtOJwQOppzD9TKaGTTTU0nT_A5qAg==
		return this._0023_003DzUXvewGj_vwgA62Y1I3AoJyiIrq4_0dhWYWsrSHtOJwQOppzD9TKaGTTTU0nT_A5qAg_003D_003D();
	}

	private static bool _0023_003DzPLZ_wzWVRFPk2THN_0024g_003D_003D()
	{
		return true;
	}

	private static bool _0023_003Dz7P1pfE3vcDxtRZ5zaQ_003D_003D()
	{
		return false;
	}

	private static int _0023_003DzmuZmjj_0024WEUbi()
	{
		return 8;
	}

	private static ObjectManipulatorPartProperties _0023_003DzGnW5VGS6k0W9()
	{
		return new ObjectManipulatorPartProperties(DefaultBallColor, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003Dz865FUlRo9Ybb()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorX, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003DznGpZh_WdU5t_0024()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorY, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003DzZJLKi13kUrWn()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorZ, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003Dz0SfXhbF7eXGH()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorX, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003DzMrF0pZj_0024c68H()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorY, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003DzZ_yXrQQx8Zwy()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorZ, visible: true, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003Dz6L45bgjomsqw()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorX, visible: false, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003Dz7zroHPsUES_0024y()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorY, visible: false, selectable: true);
	}

	private static ObjectManipulatorPartProperties _0023_003Dz2VvS96oHJro5()
	{
		return new ObjectManipulatorPartProperties(DefaultArrowColorZ, visible: false, selectable: true);
	}

	private static double _0023_003DzRFdvORg86iEi()
	{
		return 0.0;
	}

	private static double _0023_003DzSUmnVLLl6Q_Y()
	{
		return Math.PI / 12.0;
	}

	private static double _0023_003DzwN0KXdWCh5DN()
	{
		return 0.0;
	}

	private static Color _0023_003Dzqf3DoNdmn51vDQXD2w_003D_003D()
	{
		return Color.FromArgb(200, Color.WhiteSmoke);
	}

	private static Color _0023_003DzEAqV1yPU_0024DxR1lwS_A_003D_003D()
	{
		return Color.Black;
	}

	private static ballActionType _0023_003DzipNQapGTOSUQer2avg_003D_003D()
	{
		return ballActionType.Translate;
	}

	private static styleType _0023_003DzCp6SpVT8Q9QG()
	{
		return styleType.Standard;
	}

	private static string _0023_003DzWUgmeE8YqcXs()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587036);
	}

	public override object Clone()
	{
		return new ObjectManipulator(this);
	}

	private void _0023_003DzH2wzlkSxe_0024nyl_0024wEBg_003D_003D()
	{
		string defaultLayerName = GetDefaultLayerName();
		double _0023_003DzW_Mwciw_003D = ((StyleMode == styleType.Large) ? 1.0 : (2.0 / 9.0));
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1] = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, _0023_003DzW_Mwciw_003D, 0.0, Vector3D.AxisX, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)1);
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[2] = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, _0023_003DzW_Mwciw_003D, 90.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)2);
		_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[3] = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, _0023_003DzW_Mwciw_003D, -90.0, Vector3D.AxisY, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)3);
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count <= 4)
		{
			Mesh item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 90.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)4);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 0.0, Vector3D.AxisY, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)5);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, -90.0, Vector3D.AxisX, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)6);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 0.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)7);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 90.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)8);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, -90.0, Vector3D.AxisY, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)9);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 0.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)7);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, 90.0, Vector3D.AxisZ, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)8);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
			item = new _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D(defaultLayerName, Mesh.natureType.Smooth, 1.0, -90.0, Vector3D.AxisY, (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)9);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Add(item);
		}
	}

	private void _0023_003DzrsONG2I_003D()
	{
		for (int i = 0; i < _0023_003DzsndQ1PQ_003D.Length && i < _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count; i++)
		{
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].Visible = (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].visibleAndInFrustum = _0023_003DzsndQ1PQ_003D[i].Visible);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].Selectable = _0023_003DzsndQ1PQ_003D[i].Selectable;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].Color = _0023_003DzsndQ1PQ_003D[i].Color;
		}
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count == 13)
		{
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Visible = (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].visibleAndInFrustum = !_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Visible && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Visible);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Color = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Color;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Selectable = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Selectable;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].Visible = (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].visibleAndInFrustum = !_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[2].Visible && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].Visible);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].Color = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].Color;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].Selectable = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].Selectable;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].Visible = (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].visibleAndInFrustum = !_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[3].Visible && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].Visible);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].Color = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].Color;
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].Selectable = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].Selectable;
		}
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		if (_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs != null)
		{
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs._0023_003DzPY_0024ulDyKjEOA();
		}
	}

	protected internal virtual void DrawLabel(DrawSceneParams myParams)
	{
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.DrawWithOffset(myParams.RenderContext, _0023_003Dzo7sDYnjZFyS1, _0023_003DzgKmhOzpIjgc2, myParams.DrawScale);
	}

	protected virtual void AssignLabel(string value)
	{
		_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx = value;
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Text = value;
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D?.MakeCurrent();
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Regen(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, 1f);
	}

	internal void _0023_003DzqDGueC67yP8K(RenderContextBase _0023_003DzmNZD0Zs_003D, double[] _0023_003DzYgijFM_0024VNOEd, int[] _0023_003DzBppTnBIbeUl7)
	{
		Camera.ComputeScreenPosition(_0023_003DzmNZD0Zs_003D, _0023_003DzYgijFM_0024VNOEd, _0023_003DzBppTnBIbeUl7, _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.AnchorPoint, out _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.xPos, out _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.yPos, out _0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.zPos, _0023_003DzgDVcxV_0024JJ9hgETWqIg_003D_003D: true);
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs != null)
		{
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Dispose();
		}
	}

	private void _0023_003DzqTdmwY0P8xeh()
	{
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.FillColor = TransformationLabelFillColor;
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Color = TransformationLabelTextColor;
		UpdateLabelFont(this);
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Regen(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, 1f);
	}

	private void _0023_003DzY78HOYOBdP1l(Color _0023_003DzgUg07Uk_003D, Color _0023_003Dzlxpb_Og_003D, Font _0023_003Dz6FupbG0_003D)
	{
		if (_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs != null)
		{
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Dispose();
			_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs = null;
		}
		_0023_003DzPkzw1z5rqyYA = _0023_003DzWUgmeE8YqcXs();
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs = new TextOnly(center, string.Empty, _0023_003Dz6FupbG0_003D, _0023_003Dzlxpb_Og_003D);
		_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx = 0.ToString(_0023_003DzPkzw1z5rqyYA);
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.FillColor = _0023_003DzgUg07Uk_003D;
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.CornerRadius = 1;
		LabelFont = _0023_003Dz6FupbG0_003D;
		UpdateLabelFont(this);
	}

	internal new static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return false;
	}

	private bool _0023_003Dz4GHZ6q89cfp5D9vR6g_003D_003D()
	{
		return LabelFont != null;
	}

	private void _0023_003DzFiyIoy6yqiQC()
	{
		LabelFont = CoordinateSystemBase._0023_003Dz0UloR3WvSVa2();
	}

	protected override void UpdateLabelFont(CoordinateSystemBase csb)
	{
		base.UpdateLabelFont(csb);
		if (_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs != null && csb is ObjectManipulator objectManipulator)
		{
			objectManipulator._0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Font = objectManipulator.LabelFont;
			if (objectManipulator._0023_003DzU0f5_qE_003D != null)
			{
				objectManipulator._0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.Regen(objectManipulator._0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, 1f);
			}
		}
	}

	protected internal override void CreateLabels(Viewport viewport, RenderContextBase renderContext)
	{
	}

	internal override bool _0023_003Dz5jYXZeY_003D(Entity _0023_003DzpWC0efg_003D)
	{
		bool result = base._0023_003Dz5jYXZeY_003D(_0023_003DzpWC0efg_003D);
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count >= 13)
		{
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Selected);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].Selected);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].Selected);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Selected);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8].Selected);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].SetSelection(_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12].Selected || _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9].Selected);
		}
		if (_0023_003DzEdy5_0024KyZ0bNx != null)
		{
			if (_0023_003DzpWC0efg_003D != null)
			{
				Vector3D _0023_003DzfZZZs54_003D;
				actionType actionType2 = _0023_003DzMcdon_00249AaVqi(out _0023_003DzfZZZs54_003D);
				_0023_003DzEdy5_0024KyZ0bNx(this, new ObjectManipulatorEventArgs(actionType2, _0023_003DzfZZZs54_003D));
			}
			else if (_0023_003Dz_d6LIGpNDz3J4WQS6My8luo_003D != null)
			{
				_0023_003DzEdy5_0024KyZ0bNx(this, new ObjectManipulatorEventArgs(actionType.None, null));
			}
			_0023_003Dz_d6LIGpNDz3J4WQS6My8luo_003D = _0023_003DzpWC0efg_003D;
		}
		return result;
	}

	protected internal virtual bool OnDrag(ref System.Drawing.Point lastPoint, System.Drawing.Point curPoint, Viewport viewport)
	{
		if (!Dragging)
		{
			return false;
		}
		System.Drawing.Point[] array = new System.Drawing.Point[2] { lastPoint, curPoint };
		Transformation transformation = null;
		double num = 0.0;
		bool flag = false;
		switch (_0023_003DzfcUzrRi_0024u6FZ)
		{
		case actionType.TranslateOnView:
		{
			Point3D[] array2 = viewport.ScreenToPlane(new System.Drawing.Point[2]
			{
				new System.Drawing.Point(array[0].X, array[0].Y),
				new System.Drawing.Point(array[1].X, array[1].Y)
			}, _0023_003DzvAf97hdaih7oTb64mw_003D_003D);
			Vector3D vector3D2 = Vector3D.Subtract(array2[1], array2[0]);
			if (TranslationStep > 0.0)
			{
				if (vector3D2.Length > TranslationStep)
				{
					vector3D2.Length = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(vector3D2.Length, TranslationStep);
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				transformation = new Translation(vector3D2.X, vector3D2.Y, vector3D2.Z);
			}
			break;
		}
		case actionType.Rotate:
		{
			array[0].Offset(viewport.Location.X, viewport.Location.Y);
			array[1].Offset(viewport.Location.X, viewport.Location.Y);
			viewport.ScreenToPlane(array[0], _0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Plane, out var intPoint);
			viewport.ScreenToPlane(array[1], _0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Plane, out var intPoint2);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Project(intPoint, out var t);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Project(intPoint2, out var t2);
			num = t2 - t;
			if (RotationStep > 0.0)
			{
				if (Math.Abs(num) > RotationStep)
				{
					num = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num, RotationStep);
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				Point3D point3D = Transformation * center;
				transformation = new Translation(point3D.X, point3D.Y, point3D.Z) * new Rotation(num, _0023_003Dz9SgiP7nQpD7o) * new Translation(0.0 - point3D.X, 0.0 - point3D.Y, 0.0 - point3D.Z);
				if (_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D != null)
				{
					_0023_003Dz_0024nmiy764PDTf(_0023_003DzRBFnLoh6GpdX(num));
				}
			}
			break;
		}
		case actionType.TranslateOnAxis:
		{
			Point2D point2D = null;
			Point2D a = null;
			point2D = _0023_003DzIa2K1J3v8fYG.PointAt(_0023_003DzIa2K1J3v8fYG.Project(new Point2D(array[0].X + viewport.Location.X, viewport.Size.Height - array[0].Y)));
			a = _0023_003DzIa2K1J3v8fYG.PointAt(_0023_003DzIa2K1J3v8fYG.Project(new Point2D(array[1].X + viewport.Location.X, viewport.Size.Height - array[1].Y)));
			viewport.Camera.GetFrame(out var origin, out var _, out var _, out var camZ);
			Plane pe = new Plane(viewport.Camera.Location - viewport.Camera.Near * camZ, camZ);
			Point3D[] array2 = viewport.ScreenToPlane(new System.Drawing.Point[2]
			{
				new System.Drawing.Point((int)point2D.X, viewport.Size.Height - (int)point2D.Y),
				new System.Drawing.Point((int)a.X, viewport.Size.Height - (int)a.Y)
			}, pe);
			Point3D point3D3 = Transformation * center;
			double num5 = Vector3D.Dot(Vector3D.Subtract(point3D3, viewport.Camera.Location), -1.0 * viewport.Camera.ViewNormal);
			Vector3D vector3D2 = Vector3D.Subtract(array2[1], array2[0]);
			Vector3D u = (Vector3D)vector3D2.Clone();
			vector3D2.Normalize();
			double num6 = 1.0;
			Vector3D vector3D3;
			if (viewport.Camera.ProjectionMode == projectionType.Perspective)
			{
				vector3D3 = Vector3D.Subtract(point3D3, origin);
				vector3D3.Normalize();
				num6 = num5 / viewport.Camera.Near;
			}
			else
			{
				vector3D3 = camZ;
			}
			double num7 = Vector3D.Dot(u, vector3D2) * num6;
			double num8 = Math.Sign(Vector2D.Dot(Vector2D.Subtract(a, point2D), _0023_003Dz7NYyz2il2OiE));
			if (TranslationStep > 0.0)
			{
				if (num7 > TranslationStep)
				{
					num7 = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num7, TranslationStep);
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				double d = 0.0 - Vector3D.Dot(_0023_003Dz9SgiP7nQpD7o, vector3D3);
				double num9 = Math.Acos(d);
				d = Math.Cos(Math.PI / 2.0 - num9);
				if (Math.Abs(d) > 1E-05)
				{
					num7 /= d;
				}
			}
			Vector3D vector3D4 = num8 * num7 * _0023_003Dz9SgiP7nQpD7o;
			transformation = new Translation(vector3D4);
			point3D3 = transformation * point3D3;
			double num10 = Vector3D.Dot(Vector3D.Subtract(point3D3, center), _0023_003Dz9SgiP7nQpD7o);
			if (TranslationStep > 0.0)
			{
				num10 = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num10, TranslationStep);
			}
			if (!flag)
			{
				_0023_003Dz_0024nmiy764PDTf(_0023_003DzLEkOHrs85Eac(vector3D4));
				if (!TranslationRange.Includes(num10, testOpenInterval: false))
				{
					flag = true;
				}
			}
			break;
		}
		case actionType.RotateOnView:
		{
			array[0].Offset(viewport.Location.X, viewport.Location.Y);
			array[1].Offset(viewport.Location.X, viewport.Location.Y);
			viewport.ScreenToPlane(array[0], _0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Plane, out var intPoint3);
			viewport.ScreenToPlane(array[1], _0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Plane, out var intPoint4);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Project(intPoint3, out var t3);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D.Project(intPoint4, out var t4);
			num = t4 - t3;
			if (RotationStep > 0.0)
			{
				if (Math.Abs(num) > RotationStep)
				{
					num = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num, RotationStep);
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				Point3D point3D2 = Transformation * center;
				transformation = new Translation(point3D2.X, point3D2.Y, point3D2.Z) * new Rotation(num, _0023_003Dz9SgiP7nQpD7o) * new Translation(0.0 - point3D2.X, 0.0 - point3D2.Y, 0.0 - point3D2.Z);
				_0023_003Dz_0024nmiy764PDTf(_0023_003DzRBFnLoh6GpdX(num));
			}
			break;
		}
		case actionType.Scale:
		{
			Point2D a = _0023_003DzIa2K1J3v8fYG.PointAt(_0023_003DzIa2K1J3v8fYG.Project(new Point2D(array[1].X + viewport.Location.X, viewport.Size.Height - array[1].Y)));
			double num4 = Math.Abs(Point2D.Distance(a, _0023_003DzIa2K1J3v8fYG.P0)) / _0023_003DzTgpWXC1JaeOjNGrZHQ_003D_003D;
			if (ScalingStep > 0.0)
			{
				if (num4 > ScalingStep)
				{
					num4 = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num4, ScalingStep);
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				Vector3D vector3D = num4 * _0023_003Dz9Ou_LCIuLXrz;
				double sx = ((Math.Abs(vector3D.X) > 0.001) ? vector3D.X : 1.0);
				double sy = ((Math.Abs(vector3D.Y) > 0.001) ? vector3D.Y : 1.0);
				double sz = ((Math.Abs(vector3D.Z) > 0.001) ? vector3D.Z : 1.0);
				Transformation transformation3 = (Transformation)_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D.Clone();
				transformation3.Invert();
				transformation = _0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D * new Scaling(center, sx, sy, sz) * new Scaling(center, 1.0 / _0023_003DzvwSfVtC_Wua_9AbsJA_003D_003D, 1.0 / _0023_003Dzj4oERKFtAGPsz1BShQ_003D_003D, 1.0 / _0023_003DzfuQlipLErxf_0024VFRyLg_003D_003D) * transformation3;
				_0023_003DzvwSfVtC_Wua_9AbsJA_003D_003D = sx;
				_0023_003Dzj4oERKFtAGPsz1BShQ_003D_003D = sy;
				_0023_003DzfuQlipLErxf_0024VFRyLg_003D_003D = sz;
			}
			break;
		}
		case actionType.UniformScale:
		{
			double num2 = (double)(viewport.Size.Height - array[1].Y) - _0023_003DzIa2K1J3v8fYG.P0.Y;
			Math.Sign(num2);
			double num3 = num2 * _0023_003DzgnoOChIwmV2J / _0023_003Dz_0024qR2UYIkfFXv0oQG0g_003D_003D;
			if (ScalingStep > 0.0)
			{
				num3 = _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(num3, ScalingStep);
			}
			num3 = 1.0 + num3;
			if (num3 <= 0.0)
			{
				flag = true;
			}
			if (!flag)
			{
				Transformation transformation2 = (Transformation)_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D.Clone();
				transformation2.Invert();
				transformation = _0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D * new Scaling(center, num3, num3, num3) * new Scaling(center, 1.0 / _0023_003DzQGuUDpnN5zj7dhytWA_003D_003D, 1.0 / _0023_003DzQGuUDpnN5zj7dhytWA_003D_003D, 1.0 / _0023_003DzQGuUDpnN5zj7dhytWA_003D_003D) * transformation2;
				_0023_003DzQGuUDpnN5zj7dhytWA_003D_003D = num3;
			}
			break;
		}
		}
		if (!flag)
		{
			Transformation = transformation * _0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D;
			lastPoint = curPoint;
			if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
			{
				double[] matrixAsVectorByColumn = Transformation.MatrixAsVectorByColumn;
				_0023_003DzZWjOo62HF93770pqyezGoeo_003D().Plane = new Plane(new Point3D(matrixAsVectorByColumn[12], matrixAsVectorByColumn[13], matrixAsVectorByColumn[14]), new Vector3D(matrixAsVectorByColumn[0], matrixAsVectorByColumn[1], matrixAsVectorByColumn[2]), new Vector3D(matrixAsVectorByColumn[4], matrixAsVectorByColumn[5], matrixAsVectorByColumn[6]));
				((ClippingPlane)_0023_003DzZWjOo62HF93770pqyezGoeo_003D()).BuildClippingPlaneMesh(_0023_003DzgwMhmLr71vvSEwxwRBGdQ1c_003D);
				UpdateBoundingBox();
				if (!_0023_003DzU0f5_qE_003D._0023_003DzZ5L0bhmvC_0024K7)
				{
					_0023_003DzU0f5_qE_003D.Invalidate();
				}
			}
		}
		if (_0023_003Dzf_0024V9OVGSB1gu != null)
		{
			_0023_003Dzf_0024V9OVGSB1gu(this, new ObjectManipulatorEventArgs(_0023_003DzfcUzrRi_0024u6FZ, _0023_003Dz9Ou_LCIuLXrz));
		}
		return true;
	}

	private double _0023_003Dzef0hpOkS4Kw33YPxzw_003D_003D(double _0023_003DzsLHxXyo_003D, double _0023_003DztMUmTgk_003D)
	{
		return Math.Round(Math.Abs(_0023_003DzsLHxXyo_003D) / _0023_003DztMUmTgk_003D) * _0023_003DztMUmTgk_003D * (double)Math.Sign(_0023_003DzsLHxXyo_003D);
	}

	private void _0023_003DzYKcYML5sX3Pr(Viewport _0023_003DzYzWi5Yw_003D, Vector3D _0023_003DzfZZZs54_003D, System.Drawing.Point _0023_003DzTYCHRugcseEq, out Vector3D _0023_003Dz4x4oadsxmTcJ)
	{
		_0023_003Dz4x4oadsxmTcJ = _0023_003DzfZZZs54_003D;
		Point3D origin;
		switch (_0023_003DzfcUzrRi_0024u6FZ)
		{
		case actionType.TranslateOnView:
		{
			_0023_003DzYzWi5Yw_003D.Camera.GetFrame(out origin, out var _, out var _, out var camZ3);
			_0023_003DzvAf97hdaih7oTb64mw_003D_003D = new Plane(Transformation * center, camZ3);
			break;
		}
		case actionType.Rotate:
		{
			_0023_003DzYzWi5Yw_003D.Camera.GetFrame(out origin, out var camX2, out var camY2, out var camZ2);
			_0023_003DzvAf97hdaih7oTb64mw_003D_003D = new Plane(Transformation * center, camX2, camY2);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D = new Circle(_0023_003DzvAf97hdaih7oTb64mw_003D_003D, 1.0);
			_0023_003Dz4x4oadsxmTcJ = Transformation * new Vector3D(_0023_003DzfZZZs54_003D.ToArray());
			_0023_003Dz4x4oadsxmTcJ.Normalize();
			if (Vector3D.Dot(_0023_003Dz4x4oadsxmTcJ, camZ2) < 0.0)
			{
				_0023_003Dz4x4oadsxmTcJ.Negate();
			}
			break;
		}
		case actionType.RotateOnView:
		{
			_0023_003DzYzWi5Yw_003D.Camera.GetFrame(out origin, out var camX, out var camY, out var camZ);
			_0023_003DzvAf97hdaih7oTb64mw_003D_003D = new Plane(Transformation * center, camX, camY);
			_0023_003DzFdb0HcEFrnEfJYzdZQ_003D_003D = new Circle(_0023_003DzvAf97hdaih7oTb64mw_003D_003D, 1.0);
			_0023_003Dz4x4oadsxmTcJ = camZ;
			_0023_003Dz4x4oadsxmTcJ.Normalize();
			break;
		}
		case actionType.UniformScale:
		{
			_0023_003Dz_0024qR2UYIkfFXv0oQG0g_003D_003D = (double)_0023_003DzYzWi5Yw_003D.Size.Height / 2.0;
			_0023_003Dz669_0024Pjn6EwHjjj_HxA_003D_003D = _0023_003DzYzWi5Yw_003D.WorldToScreen(_0023_003DzA_0024Oe3Hbz408q).Y - _0023_003DzYzWi5Yw_003D.WorldToScreen(center).Y;
			_0023_003DzgnoOChIwmV2J = _0023_003Dz_0024qR2UYIkfFXv0oQG0g_003D_003D / _0023_003Dz669_0024Pjn6EwHjjj_HxA_003D_003D;
			Point3D[] array3 = new Point3D[2]
			{
				_0023_003DzYzWi5Yw_003D.WorldToScreen(Transformation * center),
				new Point3D(_0023_003DzTYCHRugcseEq.X, _0023_003DzYzWi5Yw_003D.Size.Height - _0023_003DzTYCHRugcseEq.Y)
			};
			_0023_003DzIa2K1J3v8fYG = new Segment2D(new Point2D(array3[0].X, array3[0].Y), new Point2D(array3[1].X, array3[1].Y));
			_0023_003DzTgpWXC1JaeOjNGrZHQ_003D_003D = (double)(_0023_003DzYzWi5Yw_003D.Size.Height - _0023_003DzTYCHRugcseEq.Y) - array3[0].Y;
			break;
		}
		case actionType.Scale:
		{
			Point3D[] array2 = new Point3D[2]
			{
				_0023_003DzYzWi5Yw_003D.WorldToScreen(Transformation * center),
				new Point3D(_0023_003DzTYCHRugcseEq.X, _0023_003DzYzWi5Yw_003D.Size.Height - _0023_003DzTYCHRugcseEq.Y)
			};
			_0023_003DzIa2K1J3v8fYG = new Segment2D(new Point2D(array2[0].X, array2[0].Y), new Point2D(array2[1].X, array2[1].Y));
			_0023_003DzTgpWXC1JaeOjNGrZHQ_003D_003D = _0023_003DzIa2K1J3v8fYG.Length;
			break;
		}
		default:
		{
			Point3D point3D = center + _0023_003DzI2dw8iBlKCH_0024() * _0023_003Dz4x4oadsxmTcJ;
			Point3D point3D2 = center;
			Point3D[] array = _0023_003DzYzWi5Yw_003D.WorldToScreen(new Point3D[2]
			{
				Transformation * point3D2,
				Transformation * point3D
			});
			_0023_003DzIa2K1J3v8fYG = new Segment2D(new Point2D(array[0].X, array[0].Y), new Point2D(array[1].X, array[1].Y));
			_0023_003Dz7NYyz2il2OiE = Vector2D.Subtract(_0023_003DzIa2K1J3v8fYG.P1, _0023_003DzIa2K1J3v8fYG.P0);
			_0023_003Dz7NYyz2il2OiE.Normalize();
			_0023_003Dz4x4oadsxmTcJ = Transformation * new Vector3D(_0023_003DzfZZZs54_003D.ToArray());
			_0023_003Dz4x4oadsxmTcJ.Normalize();
			break;
		}
		}
		if (_0023_003Dz4x4oadsxmTcJ != null && _0023_003DzvHflPJaLQdFs != _0023_003Dz4x4oadsxmTcJ)
		{
			_0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D = 0.0;
			_0023_003DzdnbIz3Zo4ds6fQ__Qvbctac_003D = 0.0;
			_0023_003DzvHflPJaLQdFs = (Vector3D)_0023_003Dz4x4oadsxmTcJ.Clone();
		}
	}

	private double _0023_003DzI2dw8iBlKCH_0024()
	{
		if (_0023_003DzA_0024Oe3Hbz408q == null)
		{
			return 1.0;
		}
		Size3D size3D = new Size3D(_0023_003DzubU3aALCGlU7, _0023_003DzA_0024Oe3Hbz408q);
		double[] array = new double[3] { size3D.X, size3D.Y, size3D.Z };
		Array.Sort(array);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] > 1E-09)
			{
				return array[i];
			}
		}
		return 0.0;
	}

	public override void Draw(RenderParams data)
	{
		ParentViewport = (Viewport)data.Viewport;
		data.RenderContext.SetState(depthStencilStateType.DepthTestAlways);
		base.Draw(data);
		data.RenderContext.SetState(depthStencilStateType.DepthTestLessEqual);
		base.Draw(data);
	}

	protected internal override bool OnMouseUp(MouseEventArgs e, Viewport viewport)
	{
		if (!_0023_003DzF3HKD2trntQC() || e.Button != MouseButtons.Left)
		{
			return false;
		}
		_0023_003DzxEpSi5o_003D();
		bool result = base.OnMouseUp(e, viewport);
		if (_0023_003DzAiRqlf34N5UH != null)
		{
			_0023_003DzAiRqlf34N5UH(this, new ObjectManipulatorEventArgs(_0023_003DzfcUzrRi_0024u6FZ, _0023_003Dz9Ou_LCIuLXrz));
		}
		_0023_003DzQGuUDpnN5zj7dhytWA_003D_003D = (_0023_003DzvwSfVtC_Wua_9AbsJA_003D_003D = (_0023_003Dzj4oERKFtAGPsz1BShQ_003D_003D = (_0023_003DzfuQlipLErxf_0024VFRyLg_003D_003D = 1.0)));
		if (ShowDraggedItemOnly)
		{
			_0023_003DzrsONG2I_003D();
		}
		return result;
	}

	private void _0023_003DzxEpSi5o_003D()
	{
		_0023_003Dz9SgiP7nQpD7o = null;
		_0023_003DzIa2K1J3v8fYG = null;
		Dragging = false;
		_0023_003DzJVnoiNWtZYWm = false;
		foreach (Mesh item in _0023_003DzE2brWRjSvZMG())
		{
			item.Selected = false;
		}
	}

	protected internal override bool OnMouseDown(MouseEventArgs e, Viewport viewport)
	{
		base.OnMouseDown(e, viewport);
		if (PickedEntity == null)
		{
			return false;
		}
		_0023_003DzfcUzrRi_0024u6FZ = _0023_003DzMcdon_00249AaVqi(out _0023_003Dz9Ou_LCIuLXrz);
		if (ShowDraggedItemOnly && _0023_003DzfcUzrRi_0024u6FZ != actionType.None)
		{
			for (int i = 1; i < _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count; i++)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i].Visible = false;
			}
			int num = (int)_0023_003DzYOMWa3_0024T_0024wxB(PickedEntity);
			_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[num].Visible = true;
			if (_0023_003DzfcUzrRi_0024u6FZ == actionType.Scale)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[num + 3].Visible = true;
			}
		}
		_0023_003DzYKcYML5sX3Pr(viewport, _0023_003Dz9Ou_LCIuLXrz, e.Location, out _0023_003Dz9SgiP7nQpD7o);
		Dragging = true;
		if (_0023_003DzM133s9Ir1jmo != null)
		{
			_0023_003DzM133s9Ir1jmo(this, new ObjectManipulatorEventArgs(_0023_003DzfcUzrRi_0024u6FZ, _0023_003Dz9Ou_LCIuLXrz));
		}
		return true;
	}

	private actionType _0023_003DzT43HYrlPuAvk()
	{
		return BallActionMode switch
		{
			ballActionType.Rotate => actionType.RotateOnView, 
			ballActionType.Scale => actionType.UniformScale, 
			_ => actionType.TranslateOnView, 
		};
	}

	private actionType _0023_003DzMcdon_00249AaVqi(out Vector3D _0023_003Dz9Ou_LCIuLXrz)
	{
		_0023_003Dz9Ou_LCIuLXrz = null;
		switch (_0023_003DzYOMWa3_0024T_0024wxB(PickedEntity))
		{
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)0:
			return _0023_003DzT43HYrlPuAvk();
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)1:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisX;
			return actionType.TranslateOnAxis;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)2:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisY;
			return actionType.TranslateOnAxis;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)3:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisZ;
			return actionType.TranslateOnAxis;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)4:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisX;
			return actionType.Rotate;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)5:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisY;
			return actionType.Rotate;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)6:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisZ;
			return actionType.Rotate;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)7:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisX;
			return actionType.Scale;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)8:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisY;
			return actionType.Scale;
		case (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)9:
			_0023_003Dz9Ou_LCIuLXrz = Vector3D.AxisZ;
			return actionType.Scale;
		default:
			return actionType.None;
		}
	}

	private _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D _0023_003DzYOMWa3_0024T_0024wxB(Entity _0023_003DztJCl_0024mM_003D)
	{
		if (_0023_003DztJCl_0024mM_003D is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
		{
			return ((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)PickedEntity)._0023_003DzGpFd0Ls_003D;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[0])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)0;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)1;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[2])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)2;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[3])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)3;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)4;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[5])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)5;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[6])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)6;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7] || PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)7;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8] || PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)8;
		}
		if (PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9] || PickedEntity == _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12])
		{
			return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)9;
		}
		return (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D._0023_003DzemvFlrg_003D)0;
	}

	internal override void _0023_003Dz8WTvZ9I_003D(Workspace _0023_003DzU0f5_qE_003D, TextureBase _0023_003DzrRiTzRDcSNK7)
	{
		base._0023_003Dz8WTvZ9I_003D(_0023_003DzU0f5_qE_003D, _0023_003DzrRiTzRDcSNK7);
		CompileParams compileParams = new CompileParams(_0023_003DzU0f5_qE_003D);
		bool flag = false;
		if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D().Count >= 10)
		{
			bool flag2 = TranslateX.Visible || TranslateY.Visible || TranslateZ.Visible;
			int num = ((TranslateX.Visible || ScaleX.Visible) ? 1 : 0);
			num += ((TranslateY.Visible || ScaleY.Visible) ? 1 : 0);
			num += ((TranslateZ.Visible || ScaleZ.Visible) ? 1 : 0);
			if (StyleMode == styleType.Large && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
			{
				Mesh mesh = OptimizedArrow(compileParams, 0.4, 7.0, 1.0, 4.0);
				mesh.Translate(1.0, 0.0);
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Vertices = mesh.Vertices;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Triangles = mesh.Triangles;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Normals = mesh.Normals;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Edges = mesh.Edges;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].Compile(compileParams);
				drawArrow = _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1].drawData;
				for (int i = 2; i < 4; i++)
				{
					if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
					{
						((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[i])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[1];
					}
				}
				mesh.Dispose();
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Dispose();
				if (StyleMode == styleType.Standard && num == 3)
				{
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Vertices = _0023_003DzQG9dygY_003D;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Triangles = _0023_003DzrCWv4TY_003D;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Normals = _0023_003Dzg_dccBg_003D;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Edges = _0023_003Dze7vsjYE_003D;
				}
				else
				{
					Mesh mesh2 = ((StyleMode == styleType.Large) ? Mesh.CreateTorus(6.0, 0.35, 13, 40) : Mesh.CreateTorus(3.6, 0.35, 13, 40));
					mesh2.Rotate(Math.PI / 2.0, Vector3D.AxisX);
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Vertices = mesh2.Vertices;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Triangles = mesh2.Triangles;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Normals = mesh2.Normals;
					_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].Edges = mesh2.Edges;
				}
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4]).Compile(compileParams);
				flag = true;
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[5] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[5])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4];
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[6] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[6])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4];
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Dispose();
				Mesh mesh3 = Mesh.CreateBox(1.6, 1.6, 1.6, Mesh.natureType.Smooth);
				if (flag2)
				{
					double dx = ((StyleMode != styleType.Large) ? 7.0 : 11.0);
					mesh3.Translate(dx, -0.8, -0.8);
				}
				else
				{
					double dx = ((StyleMode != styleType.Large) ? 4.0 : 8.0);
					mesh3.Translate(dx, -0.8, -0.8);
					Mesh mesh4 = new Circle(Plane.YZ, 0.25).ExtrudeAsMesh(dx, 0.001, Mesh.natureType.Smooth);
					mesh4.ComputeEdges();
					mesh4.UpdateNormals();
					mesh3.MergeWith(mesh4);
				}
				mesh3.Translate(1.0, 0.0);
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Vertices = mesh3.Vertices;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Triangles = mesh3.Triangles;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Normals = mesh3.Normals;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].Edges = mesh3.Edges;
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7]).Compile(compileParams);
				flag = true;
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[8])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7];
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[9])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7];
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)
			{
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Dispose();
				double amount = (flag2 ? ((StyleMode != styleType.Large) ? 7.0 : 11.0) : ((StyleMode != styleType.Large) ? 4.0 : 8.0));
				Mesh mesh5 = new Circle(Plane.YZ, 0.25).ExtrudeAsMesh(amount, 0.001, Mesh.natureType.Smooth);
				mesh5.ComputeEdges();
				mesh5.UpdateNormals();
				mesh5.Translate(1.0, 0.0);
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Vertices = mesh5.Vertices;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Triangles = mesh5.Triangles;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Normals = mesh5.Normals;
				_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10].Edges = mesh5.Edges;
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10]).Compile(compileParams);
				flag = true;
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[11])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10];
			}
			if (_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12] is _0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D && flag)
			{
				((_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[12])._0023_003DzcJIdS_jd32ls = (_0023_003Dz2BBosgG_3NbUjAojRgxRvNMgtHIsPQds_Q_003D_003D)_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[10];
			}
		}
		_0023_003DzrsONG2I_003D();
		_0023_003DzqTdmwY0P8xeh();
	}

	internal bool _0023_003DzL28lpFu5le27()
	{
		if (drawSphere != null && !drawSphere.NeedToCompile() && drawArrow != null && !drawArrow.NeedToCompile() && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].drawData != null && !_0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[4].drawData.NeedToCompile() && _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].drawData != null)
		{
			return _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D()[7].drawData.NeedToCompile();
		}
		return true;
	}

	internal void _0023_003Dz36GfUMHowvLS()
	{
		if (_0023_003DzU0f5_qE_003D != null && _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO != null)
		{
			BlockReference _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO = _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO;
			Transformation transformation = Transformation * _0023_003DzNo6p8zohxgTa;
			if (_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.AccumulatedParentsTransform != null)
			{
				_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation = transformation * _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.AccumulatedParentsTransform;
			}
			else
			{
				_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation = transformation;
			}
			_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.RegenMode = regenType.NotNeeded;
		}
	}

	private double _0023_003DzLEkOHrs85Eac(Vector3D _0023_003Dzm2D9EEv3PK2EZXe4Ag_003D_003D)
	{
		Vector3D vector3D = (Vector3D)_0023_003Dzm2D9EEv3PK2EZXe4Ag_003D_003D.Clone();
		vector3D.Normalize();
		if (Vector3D.AreOpposite(_0023_003Dz9SgiP7nQpD7o, vector3D))
		{
			_0023_003DzdnbIz3Zo4ds6fQ__Qvbctac_003D -= _0023_003Dzm2D9EEv3PK2EZXe4Ag_003D_003D.Length;
		}
		else
		{
			_0023_003DzdnbIz3Zo4ds6fQ__Qvbctac_003D += _0023_003Dzm2D9EEv3PK2EZXe4Ag_003D_003D.Length;
		}
		return _0023_003DzdnbIz3Zo4ds6fQ__Qvbctac_003D;
	}

	private double _0023_003DzRBFnLoh6GpdX(double _0023_003DzDDPdcHhoVRUkGA5Bdw_003D_003D)
	{
		Vector3D vector3D = null;
		if (_0023_003Dz9Ou_LCIuLXrz != null)
		{
			vector3D = (Vector3D)_0023_003Dz9Ou_LCIuLXrz.Clone();
			vector3D.TransformBy(GetFullTransformation());
		}
		else
		{
			Camera camera = ParentViewport.Camera;
			vector3D = (camera.Location - camera.Target).AsVector;
		}
		vector3D.Normalize();
		_0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D += _0023_003DzDDPdcHhoVRUkGA5Bdw_003D_003D;
		if (Math.Abs(_0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D) < 1E-12)
		{
			_0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D = 0.0;
		}
		double num = ((_0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D < 0.0) ? (Math.PI * 2.0 + _0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D) : _0023_003DzpgvOWzSFDFPu3bhZtA_003D_003D);
		if (Vector3D.AreOpposite(_0023_003Dz9SgiP7nQpD7o, vector3D))
		{
			num = Math.PI * 2.0 - num;
		}
		return num % (Math.PI * 2.0);
	}

	private void _0023_003Dz_0024nmiy764PDTf(double _0023_003DzsLHxXyo_003D)
	{
		if ((_0023_003DzfcUzrRi_0024u6FZ == actionType.Rotate || _0023_003DzfcUzrRi_0024u6FZ == actionType.RotateOnView) && TransformationLabelAngularUnitsType == angularUnitsType.Degrees)
		{
			_0023_003DzsLHxXyo_003D = Utility.RadToDeg(_0023_003DzsLHxXyo_003D);
		}
		_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx = _0023_003DzsLHxXyo_003D.ToString(_0023_003DzPkzw1z5rqyYA);
		if (ShowTransformationLabelUnits)
		{
			switch (_0023_003DzfcUzrRi_0024u6FZ)
			{
			case actionType.TranslateOnAxis:
				_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx = _0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338) + _0023_003DzU0f5_qE_003D.RootBlock.Units;
				break;
			case actionType.Rotate:
			case actionType.RotateOnView:
				_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx += ((TransformationLabelAngularUnitsType == angularUnitsType.Radians) ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587051) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587027));
				break;
			}
		}
		AssignLabel(_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx);
	}

	protected virtual string FormatTransformationLabelString(double value)
	{
		return value.ToString(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587040));
	}

	protected override Transformation GetInitialTransformation()
	{
		return InitialTransformation;
	}

	internal bool _0023_003DzF3HKD2trntQC()
	{
		return _0023_003DzVXxkxuBnkiRBonuzuQ_003D_003D;
	}

	internal void _0023_003DzlY_0024SHXjhU3aQ(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzVXxkxuBnkiRBonuzuQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal bool _0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D()
	{
		return _0023_003Dzzz8ZFe6_6GoPlVfHWDUrx4dIXH2a;
	}

	private void _0023_003DzQnD82jNZnTktpq_eSg_003D_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dzzz8ZFe6_6GoPlVfHWDUrx4dIXH2a = _0023_003DzsLHxXyo_003D;
	}

	internal ClippingPlaneBase _0023_003DzZWjOo62HF93770pqyezGoeo_003D()
	{
		return _0023_003DzHtPJZtQL_PnTuWuzTk6L5Rip2xqhh3dPNA_003D_003D;
	}

	private void _0023_003DzfsQxEU8D0Bp8pCmZwIt3w_c_003D(ClippingPlaneBase _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzHtPJZtQL_PnTuWuzTk6L5Rip2xqhh3dPNA_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003DzqEXfiU18n6I61BI5dg_003D_003D(ClippingPlaneBase _0023_003DzfBBXwzTnsxuU, Color _0023_003Dzhpb8QNg_003D, bool _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D)
	{
		if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587063));
		}
		if (_0023_003DzF3HKD2trntQC())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587134));
		}
		_0023_003DzgwMhmLr71vvSEwxwRBGdQ1c_003D = _0023_003Dzhpb8QNg_003D;
		((ClippingPlane)_0023_003DzfBBXwzTnsxuU).BuildClippingPlaneMesh(_0023_003DzgwMhmLr71vvSEwxwRBGdQ1c_003D);
		Entity clippingPlaneMesh = ((ClippingPlane)_0023_003DzfBBXwzTnsxuU).clippingPlaneMesh;
		_0023_003DzY_hj2g8iu2X5(new Identity(), _0023_003DzySssITO7DWIF: true, new Entity[1] { clippingPlaneMesh }, _0023_003Dzk7pNhlbdSzPJ: false, _0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D: true);
		clippingPlaneMesh.Visible = _0023_003Dzg_cGdK2xql7DRjSFBg_003D_003D;
		Transformation = new Transformation(_0023_003DzfBBXwzTnsxuU.Plane.Origin, _0023_003DzfBBXwzTnsxuU.Plane.AxisX, _0023_003DzfBBXwzTnsxuU.Plane.AxisY, _0023_003DzfBBXwzTnsxuU.Plane.AxisZ);
		_0023_003DzQnD82jNZnTktpq_eSg_003D_003D(_0023_003DzsLHxXyo_003D: true);
		_0023_003DzfsQxEU8D0Bp8pCmZwIt3w_c_003D(_0023_003DzfBBXwzTnsxuU);
		_0023_003DzZ_0024hGGswT4bZiGeVKoQ_003D_003D = new ClippingPlane(_0023_003DzfBBXwzTnsxuU.Plane, _0023_003DzfBBXwzTnsxuU.Active);
		_0023_003DzfBBXwzTnsxuU.Active = true;
	}

	public void Enable(Transformation initialTransform, bool centerOnEntities)
	{
		Position = Point3D.Origin;
		IList<Entity> entities = _0023_003DzU0f5_qE_003D.Entities;
		IList<Entity> list = new List<Entity>();
		for (int i = 0; i < entities.Count; i++)
		{
			Entity entity = entities[i];
			if (entity.Selected)
			{
				list.Add(entity);
			}
		}
		Enable(initialTransform, centerOnEntities, list);
	}

	public void Enable(Transformation initialTransform, bool centerOnEntities, IList<Entity> entities)
	{
		_0023_003DzY_hj2g8iu2X5(initialTransform, centerOnEntities, entities, _0023_003Dzk7pNhlbdSzPJ: true, _0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D: false);
	}

	internal void _0023_003DzY_hj2g8iu2X5(Transformation _0023_003Dz54oKZ5avL5qc, bool _0023_003DzySssITO7DWIF, IList<Entity> _0023_003DzHyqiRqo_003D, bool _0023_003Dzk7pNhlbdSzPJ, bool _0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D)
	{
		if (!base.Visible)
		{
			if (_0023_003DzU0f5_qE_003D._0023_003DzukN4kknF0ob8(_0023_003DzU0f5_qE_003D.ActionMode))
			{
				_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Push(_0023_003DzU0f5_qE_003D.ActionMode);
				_0023_003DzU0f5_qE_003D.ActionMode = devDept.Eyeshot.actionType.None;
			}
			else
			{
				_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Push(devDept.Eyeshot.actionType.None);
			}
		}
		Cancel();
		if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587444));
		}
		_0023_003Dz2_rHji7pJUYf = _0023_003DzHyqiRqo_003D;
		_0023_003Dz6nR_0024uxcAmzwG = new bool[_0023_003DzHyqiRqo_003D.Count];
		_0023_003Dz4kpLOElXzSbg = new bool[_0023_003DzHyqiRqo_003D.Count];
		_0023_003Dzbq3BJR0_003D = _0023_003DzU0f5_qE_003D.Parents;
		for (int i = 0; i < _0023_003DzHyqiRqo_003D.Count; i++)
		{
			_0023_003Dz6nR_0024uxcAmzwG[i] = !InstanceInfo.FindInstanceInfo(_0023_003Dzbq3BJR0_003D, _0023_003DzHyqiRqo_003D[i].instanceVisibilityInfo, out var _);
			_0023_003Dz4kpLOElXzSbg[i] = _0023_003DzHyqiRqo_003D[i].GetVisibility(_0023_003Dzbq3BJR0_003D);
		}
		Transformation = new Identity();
		InitialTransformation = _0023_003Dz54oKZ5avL5qc;
		bool flag = false;
		Transformation transformation = ((!_0023_003Dzk7pNhlbdSzPJ || !(_0023_003DzU0f5_qE_003D.CurrentTransformation != null)) ? new Identity() : _0023_003DzU0f5_qE_003D.CurrentTransformation);
		if (_0023_003DzHyqiRqo_003D.Count > 0)
		{
			_0023_003Dz__ogbSIFtpdK(_0023_003DzHyqiRqo_003D);
			if (_0023_003DzySssITO7DWIF)
			{
				Position = Point3D.MidPoint(_0023_003DzubU3aALCGlU7, _0023_003DzA_0024Oe3Hbz408q);
				_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D = transformation * new Translation(Position.X, Position.Y, Position.Z) * new Scaling(1.0 / transformation.ScaleFactorX, 1.0 / transformation.ScaleFactorY, 1.0 / transformation.ScaleFactorX) * InitialTransformation * new Translation(0.0 - Position.X, 0.0 - Position.Y, 0.0 - Position.Z);
				flag = true;
			}
			_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO = _0023_003Dz4IRhf_C10pC5(_0023_003DzHyqiRqo_003D, _0023_003Dzk7pNhlbdSzPJ ? _0023_003DzU0f5_qE_003D.CurrentTransformation : null, _0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D);
			if (!ShowOriginalWhileEditing)
			{
				for (int j = 0; j < _0023_003DzHyqiRqo_003D.Count; j++)
				{
					_0023_003DzHyqiRqo_003D[j].SetVisibility(status: false, _0023_003Dzbq3BJR0_003D);
				}
			}
		}
		if (!flag)
		{
			Position = Point3D.Origin;
			_0023_003Dz3SrJYHKlcY3XT_CvrgjSIn0_003D = transformation * InitialTransformation;
		}
		_0023_003DzNo6p8zohxgTa = (Transformation)Transformation.Clone();
		_0023_003DzNo6p8zohxgTa.Invert();
		_0023_003Dz36GfUMHowvLS();
		_0023_003DzY_hj2g8iu2X5();
		_0023_003DzitrHOBdzGGgz_0024dKOB738IeEVbGCs.AnchorPoint = center;
		AssignLabel(_0023_003DzpkxEPfDYjDtFQO1mIVg8smD2WZtx);
	}

	private void _0023_003DzY_hj2g8iu2X5()
	{
		base.Visible = true;
		_0023_003DzlY_0024SHXjhU3aQ(_0023_003DzsLHxXyo_003D: true);
		_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(_0023_003DzU0f5_qE_003D._0023_003DzSeMqxa6Bcvxs());
	}

	public void Apply()
	{
		BlockReference _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO = _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO;
		if (_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO != null)
		{
			for (int i = 0; i < _0023_003Dz2_rHji7pJUYf.Count; i++)
			{
				Transformation xform;
				if (_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.AccumulatedParentsTransform != null)
				{
					Transformation obj = (Transformation)_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.AccumulatedParentsTransform.Clone();
					obj.Invert();
					xform = obj * _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation;
				}
				else
				{
					xform = _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation;
				}
				_0023_003Dz2_rHji7pJUYf[i].TransformBy(xform);
				if (!_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
				{
					if (_0023_003Dz6nR_0024uxcAmzwG[i])
					{
						_0023_003Dz2_rHji7pJUYf[i].ClearVisibility(_0023_003Dzbq3BJR0_003D);
					}
					_0023_003Dz2_rHji7pJUYf[i].SetVisibility(_0023_003Dz4kpLOElXzSbg[i], _0023_003Dzbq3BJR0_003D);
				}
			}
		}
		if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			_0023_003DzZ_0024hGGswT4bZiGeVKoQ_003D_003D = new ClippingPlane(_0023_003DzZWjOo62HF93770pqyezGoeo_003D().Plane, _0023_003DzZWjOo62HF93770pqyezGoeo_003D().Active);
		}
		Cancel();
	}

	private void _0023_003DzzDqVH64_0024xJp27DgjXHZxREk_003D(string _0023_003DzYQvHPFc_003D, Dictionary<string, string> _0023_003DzehUwKyDIBWTg, BlockKeyedCollection _0023_003DzL0R_0024cON6cxFW)
	{
		_0023_003DzL0R_0024cON6cxFW[_0023_003DzYQvHPFc_003D].Entities[0].RegenMode = regenType.RegenAndCompile;
		_0023_003DzehUwKyDIBWTg.Add(_0023_003DzYQvHPFc_003D, _0023_003DzYQvHPFc_003D);
		for (int i = 0; i < _0023_003DzU0f5_qE_003D.Entities.Count; i++)
		{
			Entity entity = _0023_003DzU0f5_qE_003D.Entities[i];
			if (entity is BlockReference)
			{
				BlockReference blockReference = (BlockReference)entity;
				if (blockReference.BlockName == _0023_003DzYQvHPFc_003D)
				{
					blockReference.RegenMode = regenType.RegenAndCompile;
				}
			}
		}
		foreach (Block item in _0023_003DzL0R_0024cON6cxFW)
		{
			if (_0023_003DzehUwKyDIBWTg.ContainsKey(item.Name) || !(item.Name != _0023_003DzYQvHPFc_003D))
			{
				continue;
			}
			foreach (Entity entity2 in item.Entities)
			{
				if (!(entity2 is BlockReference))
				{
					continue;
				}
				BlockReference blockReference2 = (BlockReference)entity2;
				if (blockReference2.BlockName == _0023_003DzYQvHPFc_003D)
				{
					blockReference2.RegenMode = regenType.RegenAndCompile;
					if (!_0023_003DzehUwKyDIBWTg.ContainsKey(item.Name))
					{
						_0023_003DzzDqVH64_0024xJp27DgjXHZxREk_003D(item.Name, _0023_003DzehUwKyDIBWTg, _0023_003DzL0R_0024cON6cxFW);
					}
				}
			}
		}
	}

	public void Cancel()
	{
		if (_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO != null)
		{
			if (_0023_003DzU0f5_qE_003D._0023_003DznJLjYKflIJCP.Contains(_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.BlockName))
			{
				if (!_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
				{
					for (int i = 0; i < _0023_003Dz2_rHji7pJUYf.Count; i++)
					{
						if (_0023_003Dz6nR_0024uxcAmzwG[i])
						{
							_0023_003Dz2_rHji7pJUYf[i].ClearVisibility(_0023_003Dzbq3BJR0_003D);
						}
						_0023_003Dz2_rHji7pJUYf[i].SetVisibility(_0023_003Dz4kpLOElXzSbg[i], _0023_003Dzbq3BJR0_003D);
					}
				}
				Stack<BlockReference> parents = new Stack<BlockReference>(new BlockReference[1] { _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO });
				for (int j = 0; j < _0023_003Dz2_rHji7pJUYf.Count; j++)
				{
					_0023_003Dz2_rHji7pJUYf[j].SetSelection(status: false, parents);
				}
				_0023_003Dz2_rHji7pJUYf = null;
				_0023_003Dzbq3BJR0_003D = null;
				_0023_003DzU0f5_qE_003D._0023_003DznJLjYKflIJCP.Remove(_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.BlockName);
			}
			_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Dispose();
			_0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO = null;
		}
		if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			_0023_003DzQnD82jNZnTktpq_eSg_003D_003D(_0023_003DzsLHxXyo_003D: false);
			_0023_003DzZWjOo62HF93770pqyezGoeo_003D().Plane = _0023_003DzZ_0024hGGswT4bZiGeVKoQ_003D_003D.Plane;
			_0023_003DzZWjOo62HF93770pqyezGoeo_003D().Active = _0023_003DzZ_0024hGGswT4bZiGeVKoQ_003D_003D.Active;
		}
		if (_0023_003DzF3HKD2trntQC())
		{
			_0023_003DzlY_0024SHXjhU3aQ(_0023_003DzsLHxXyo_003D: false);
			base.Visible = false;
			_0023_003DzfcUzrRi_0024u6FZ = actionType.None;
			_0023_003DzxEpSi5o_003D();
			if (_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Count > 0)
			{
				devDept.Eyeshot.actionType actionMode = _0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Pop();
				if (_0023_003DzU0f5_qE_003D._0023_003DzMf9dmdyhF1ZW.Count == 0)
				{
					_0023_003DzU0f5_qE_003D.ActionMode = actionMode;
				}
			}
		}
		AssignLabel(0.ToString(_0023_003DzPkzw1z5rqyYA));
		_0023_003DzU0f5_qE_003D._0023_003DzFqaEE7IhVORj(_0023_003DzU0f5_qE_003D._0023_003DzSeMqxa6Bcvxs());
	}

	private BlockReference _0023_003Dz4IRhf_C10pC5(IList<Entity> _0023_003DzQDU9c0AE6yqQ, Transformation _0023_003DzyJ3I67I12H_0024L, bool _0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D)
	{
		string text = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587275);
		string text2 = text;
		int num = 0;
		BlockKeyedCollection blockKeyedCollection = _0023_003DzU0f5_qE_003D._0023_003DzoE3BE__0024RS_DJ();
		while (blockKeyedCollection.Contains(text2))
		{
			text2 = text + num++;
		}
		Block block = new Block(text2);
		if (_0023_003Dzb6T4WZxKRFxh3VcbHw_003D_003D)
		{
			block.Entities.AddRange(_0023_003DzQDU9c0AE6yqQ);
		}
		else
		{
			List<Entity> collection = _0023_003DzU0f5_qE_003D._0023_003Dzjf_0024BZto9_0024Rys_vlKUa_93O0_003D(_0023_003DzQDU9c0AE6yqQ, _0023_003DzU0f5_qE_003D._0023_003DzoE3BE__0024RS_DJ(), 1);
			block.Entities.AddRange(collection);
		}
		_0023_003DzU0f5_qE_003D._0023_003DznJLjYKflIJCP.Add(block);
		BlockReference blockReference = new BlockReference(0.0, 0.0, 0.0, text2, 1.0, 1.0, 1.0, 0.0);
		blockReference.LayerName = GetDefaultLayerName(_0023_003DzU0f5_qE_003D);
		blockReference.AccumulatedParentsTransform = _0023_003DzyJ3I67I12H_0024L;
		blockReference.visibleAndInFrustum = true;
		if (_0023_003DzU0f5_qE_003D.CurrentBlockReference != null)
		{
			blockReference.ColorMethod = colorMethodType.byEntity;
			blockReference.Color = _0023_003DzU0f5_qE_003D.CurrentBlockReference.AccumulatedParentsAttributes.GetColor();
		}
		Stack<BlockReference> parents = new Stack<BlockReference>(new BlockReference[1] { blockReference });
		for (int i = 0; i < _0023_003DzQDU9c0AE6yqQ.Count; i++)
		{
			if (_0023_003DzQDU9c0AE6yqQ[i].Selected)
			{
				_0023_003DzQDU9c0AE6yqQ[i].SetSelection(status: true, parents);
			}
		}
		return blockReference;
	}

	public void UpdateBoundingBox()
	{
		if (_0023_003DzF3HKD2trntQC())
		{
			BlockKeyedCollection blockKeyedCollection = _0023_003DzU0f5_qE_003D._0023_003DzoE3BE__0024RS_DJ();
			BlockReference _0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO = _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO;
			EntityList entities = blockKeyedCollection[_0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.BlockName].Entities;
			_0023_003Dz__ogbSIFtpdK(entities);
		}
	}

	private void _0023_003Dz__ogbSIFtpdK(IList<Entity> _0023_003DzQDU9c0AE6yqQ)
	{
		List<Point3D> list = new List<Point3D>(_0023_003DzQDU9c0AE6yqQ.Count * 2);
		for (int i = 0; i < _0023_003DzQDU9c0AE6yqQ.Count; i++)
		{
			if (_0023_003DzQDU9c0AE6yqQ[i].BoxMax.X >= _0023_003DzQDU9c0AE6yqQ[i].BoxMin.X)
			{
				list.Add(_0023_003DzQDU9c0AE6yqQ[i].BoxMin);
				list.Add(_0023_003DzQDU9c0AE6yqQ[i].BoxMax);
			}
		}
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		Utility.UpdateMinMax(null, list, list.Count, maxValue, minValue);
		_0023_003DzubU3aALCGlU7 = maxValue;
		_0023_003DzA_0024Oe3Hbz408q = minValue;
	}

	protected internal override float UpdateScreenToWorld(Viewport viewport, int[] layoutViewport)
	{
		return _0023_003DzoGvMfeZtKVwG = viewport._0023_003DzuPo9xTkqnag6(layoutViewport, (Transformation != null) ? (Transformation * center) : center);
	}

	internal void _0023_003DzqOMaE4ZfTqy4(DrawSceneParams _0023_003Dzt5jpbHs_003D)
	{
		Workspace workspace = (Workspace)_0023_003Dzt5jpbHs_003D.Workspace;
		if (workspace._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO != null)
		{
			Viewport viewport = (Viewport)_0023_003Dzt5jpbHs_003D.Viewport;
			bool[] array = new bool[workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length];
			for (int i = 0; i < workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; i++)
			{
				array[i] = workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[i].Active;
				workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[i].Active = false;
			}
			double near = viewport.Camera.Near;
			double far = viewport.Camera.Far;
			double[] array2 = null;
			_0023_003Dzt5jpbHs_003D.RenderContext.UpdateActiveLights(workspace._0023_003DzMuApP021PUyU);
			workspace._0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: true, _0023_003DzPHqp5dQ_003D: false);
			if (ShowPreviewOnTop && !_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
			{
				array2 = new double[16];
				Array.Copy(viewport.Camera.ProjectionMatrix, array2, 16);
				_0023_003DzTbFm48YmIfae(viewport, _0023_003Dzt5jpbHs_003D.ZoomRect, _0023_003Dzt5jpbHs_003D.CameraEyePos);
				_0023_003Dzt5jpbHs_003D.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			}
			bool accurateTransparency = workspace.AccurateTransparency;
			workspace.AccurateTransparency = false;
			_0023_003Dzt5jpbHs_003D.RenderContext.SetShader(shaderType.Standard);
			workspace._0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: false, _0023_003DzPHqp5dQ_003D: false);
			_0023_003Dzt5jpbHs_003D.RenderContext.ProcessLightAttributes(shadowPass: false, reflection: false);
			_0023_003Dzt5jpbHs_003D.RenderContext.UpdateConstantBufferPerFrame();
			_0023_003Dzt5jpbHs_003D.RenderContext.SetState(depthStencilStateType.DepthTestLess);
			if (ShowPreviewOnTop && !_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
			{
				_0023_003Dzt5jpbHs_003D.RenderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
			}
			if (_0023_003DzZWjOo62HF93770pqyezGoeo_003D() == null || ((ClippingPlane)_0023_003DzZWjOo62HF93770pqyezGoeo_003D()).ShowPlane)
			{
				workspace._0023_003DzRwMrM8lh4Uvo = true;
				DrawSceneParams drawSceneParams = new DrawSceneParams();
				drawSceneParams.Viewport = viewport;
				drawSceneParams.ZoomRect = _0023_003Dzt5jpbHs_003D.ZoomRect;
				drawSceneParams.DrawScale = _0023_003Dzt5jpbHs_003D.DrawScale;
				drawSceneParams.Simplify = false;
				drawSceneParams.PlanarReflections = false;
				drawSceneParams.Entities = new List<Entity>(new BlockReference[1] { workspace._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO });
				drawSceneParams.Blocks = _0023_003Dzt5jpbHs_003D.Blocks;
				drawSceneParams.RenderContext = _0023_003Dzt5jpbHs_003D.RenderContext;
				drawSceneParams.ShaderParams = _0023_003Dzt5jpbHs_003D.ShaderParams ?? _0023_003DzU0f5_qE_003D._0023_003DzdfzPZ4BvPfHu(_0023_003Dzt5jpbHs_003D);
				drawSceneParams.ObjectManipulatorDrawPreview = true;
				drawSceneParams.SkipSsao = true;
				DrawSceneParams _0023_003DzCBM7XJK4_5H_0024 = drawSceneParams;
				_0023_003DzU0f5_qE_003D._0023_003DztyHACw9KoliV(_0023_003DzCBM7XJK4_5H_0024, _0023_003DzyeguIwq0Zzv1: true);
				workspace._0023_003DzRwMrM8lh4Uvo = false;
			}
			workspace.AccurateTransparency = accurateTransparency;
			if (ShowPreviewOnTop && !_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
			{
				viewport.Camera.Near = near;
				viewport.Camera.Far = far;
				Array.Copy(array2, viewport.Camera.ProjectionMatrix, 16);
			}
			for (int j = 0; j < workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length; j++)
			{
				workspace._0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D[j].Active = array[j];
			}
		}
	}

	internal void _0023_003DzTbFm48YmIfae(Viewport _0023_003DzYzWi5Yw_003D, RectangleF _0023_003DzF7kGEgqMZE2_, CameraEyePosType _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D)
	{
		Camera camera = _0023_003DzYzWi5Yw_003D.Camera;
		Point3D point3D = (Point3D)_0023_003DzubU3aALCGlU7.Clone();
		Point3D point3D2 = (Point3D)_0023_003DzA_0024Oe3Hbz408q.Clone();
		double num = 0.001;
		bool num2 = !_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzzRoN5Ey7w2QrrEj19GQHBtc_003D.ShowPreviewOnTop || _0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D();
		Vector3D vector3D = Vector3D.Subtract(point3D2, point3D);
		double num3 = vector3D.Length * num;
		vector3D.Normalize();
		point3D -= num3 * vector3D;
		point3D2 += num3 * vector3D;
		Transformation transformation = _0023_003DzU0f5_qE_003D._0023_003Dzrehlspxe0V6kK8q4fb0aog9widVO.Transformation;
		if (num2)
		{
			point3D.TransformBy(transformation);
			point3D2.TransformBy(transformation);
			Block openBlock = _0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D.OpenBlock;
			Point3D boxMin = openBlock.Entities.BoxMin;
			Point3D boxMax = openBlock.Entities.BoxMax;
			if (boxMin.X < point3D.X)
			{
				point3D.X = boxMin.X;
			}
			if (boxMin.Y < point3D.Y)
			{
				point3D.Y = boxMin.Y;
			}
			if (boxMin.Z < point3D.Z)
			{
				point3D.Z = boxMin.Z;
			}
			if (point3D2.X < boxMax.X)
			{
				point3D2.X = boxMax.X;
			}
			if (point3D2.Y < boxMax.Y)
			{
				point3D2.Y = boxMax.Y;
			}
			if (point3D2.Z < boxMax.Z)
			{
				point3D2.Z = boxMax.Z;
			}
		}
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(point3D, point3D2);
		if (!num2)
		{
			for (int i = 0; i < boundingBoxCorners.Length; i++)
			{
				boundingBoxCorners[i] = transformation * boundingBoxCorners[i];
			}
		}
		UtilityEx._0023_003DzLlW7aSdsQyHy(camera, boundingBoxCorners, out var _0023_003Dz8SiEeqqjUObS, out var _0023_003DzVbNvU5kkJhqV);
		if (_0023_003DzjEG7KoKdcsMla_00243Q9w_003D_003D())
		{
			double num4 = (_0023_003DzVbNvU5kkJhqV - _0023_003Dz8SiEeqqjUObS) / 1000.0;
			_0023_003Dz8SiEeqqjUObS -= num4;
			_0023_003DzVbNvU5kkJhqV += num4;
		}
		if (camera.ProjectionMode == projectionType.Perspective && (_0023_003Dz8SiEeqqjUObS < 0.0 || _0023_003DzVbNvU5kkJhqV < 0.0))
		{
			return;
		}
		camera.Near = _0023_003Dz8SiEeqqjUObS - camera.GetOffsetForSelection();
		camera.Far = _0023_003DzVbNvU5kkJhqV;
		if (camera.ProjectionMode == projectionType.Perspective)
		{
			double minimumDepth = camera.GetMinimumDepth();
			if (camera.Near < minimumDepth)
			{
				camera.Near = minimumDepth;
			}
		}
		_0023_003DzYzWi5Yw_003D._0023_003Dz0TvaYNo_003D._0023_003DzmNZD0Zs_003D.SetMatrices(null, null);
		_0023_003DzU0f5_qE_003D._0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: true, _0023_003DzPHqp5dQ_003D: false);
		camera.SetupModelViewProjection(_0023_003DzF7kGEgqMZE2_, setGraphics: true, shadowPass: false, reflection: false, _0023_003DzuUy7SRpB3oSnOMNlsA_003D_003D, applySceneTransformation: false);
		_0023_003DzU0f5_qE_003D._0023_003DzizmWu9NqdXzq(_0023_003Dzj8Y3En1zLFs4: false, _0023_003DzPHqp5dQ_003D: false);
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs()
	{
		if (Size == _0023_003DzmuZmjj_0024WEUbi() && base.Visible == _0023_003DzndG2TcxO_tb_0024() && ShowOriginalWhileEditing == _0023_003DzPLZ_wzWVRFPk2THN_0024g_003D_003D() && BallActionMode.Equals(_0023_003DzipNQapGTOSUQer2avg_003D_003D()) && StyleMode.Equals(_0023_003DzCp6SpVT8Q9QG()) && Ball.Equals(_0023_003DzGnW5VGS6k0W9()) && TranslateX.Equals(_0023_003Dz865FUlRo9Ybb()) && TranslateY.Equals(_0023_003DznGpZh_WdU5t_0024()) && TranslateZ.Equals(_0023_003DzZJLKi13kUrWn()) && RotateX.Equals(_0023_003Dz0SfXhbF7eXGH()) && RotateY.Equals(_0023_003DzMrF0pZj_0024c68H()) && RotateZ.Equals(_0023_003DzZ_yXrQQx8Zwy()) && ScaleX.Equals(_0023_003Dz6L45bgjomsqw()) && ScaleY.Equals(_0023_003Dz7zroHPsUES_0024y()) && ScaleZ.Equals(_0023_003Dz2VvS96oHJro5()) && RotationStep == _0023_003DzSUmnVLLl6Q_Y() && TranslationStep == _0023_003DzwN0KXdWCh5DN() && ScalingStep == _0023_003DzRFdvORg86iEi() && !(TransformationLabelFillColor != _0023_003Dzqf3DoNdmn51vDQXD2w_003D_003D()) && !(TransformationLabelTextColor != _0023_003DzEAqV1yPU_0024DxR1lwS_A_003D_003D()) && LabelFont.Equals(System.Windows.Forms.Control.DefaultFont))
		{
			return base.Lighting;
		}
		return true;
	}

	internal bool _0023_003DzMhJnK2KPd8YE(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, System.Drawing.Point _0023_003DzaKhuWjzYLRr8, bool _0023_003DzEsQVjCtIj3aX)
	{
		return _0023_003Dzh46LtHR_00243Trc(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, _0023_003DzaKhuWjzYLRr8, (Workspace._0023_003DzhFBmu_0024RpnRJ7)32, _0023_003DzEsQVjCtIj3aX);
	}

	protected override void CreateLabels(RenderContextBase renderContext, Point3D posLabelAxisX, string textAxisX, Point3D posLabelAxisY, string textAxisY, Point3D posLabelAxisZ, string textAxisZ, Point3D posLabelOrigin, string textOrigin, Viewport viewport, ContentAlignment originNameAlignment)
	{
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		double factor = (float)Size * _0023_003DzoGvMfeZtKVwG;
		TraversalParams data = new TraversalParams(Transformation * InitialTransformation * new Translation(Position.X, Position.Y, Position.Z) * new Scaling(factor));
		Point3D point3D = null;
		Point3D point3D2 = null;
		foreach (Mesh item in _0023_003Dzf6JMq_X6Zs_0024jwTek_A_003D_003D())
		{
			((IEntityInternal)item).ComputeBoundingBox(data, out Point3D boxMin, out Point3D boxMax);
			if (point3D == null)
			{
				point3D = boxMin;
				point3D2 = boxMax;
			}
			else
			{
				Utility.UpdateMinMaxQuick(boxMin, point3D, point3D2);
				Utility.UpdateMinMaxQuick(boxMax, point3D, point3D2);
			}
		}
		Point2D point2D = viewport.WorldToScreen(point3D);
		Point2D maxCorner = viewport.WorldToScreen(point3D2);
		Size2D size2D = new Size2D(point2D, maxCorner);
		return new Rectangle((int)point2D.X, (int)((double)viewport._0023_003Dz0TvaYNo_003D._0023_003DzNwtRJ3cLTrAy() - point2D.Y - size2D.Y), (int)size2D.X, (int)size2D.Y);
	}
}
