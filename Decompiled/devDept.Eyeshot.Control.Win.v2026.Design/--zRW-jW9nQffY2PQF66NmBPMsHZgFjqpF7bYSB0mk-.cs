using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Designer;

internal sealed class _0023_003DzRW_0024jW9nQffY2PQF66NmBPMsHZgFjqpF7bYSB0mk_003D<_0023_003DzMP6kxrk_003D> : UIElementDesignerForm<_0023_003DzMP6kxrk_003D> where _0023_003DzMP6kxrk_003D : Viewport
{
	protected override Size ImageSize => viewport.Size;

	public _0023_003DzRW_0024jW9nQffY2PQF66NmBPMsHZgFjqpF7bYSB0mk_003D(_0023_003DzMP6kxrk_003D _0023_003Dz7Tv1nWI_003D, ISite _0023_003Dz9iWEovk_003D)
		: base((Viewport)_0023_003Dz7Tv1nWI_003D, _0023_003Dz7Tv1nWI_003D, _0023_003Dz9iWEovk_003D)
	{
		base.Icon = _0023_003Dz7cZkooqx14_TV6kCjyrvJyRLgYZv2GUZ4A_003D_003D._0023_003DzEq19E6zMfrOrPjwJIA_003D_003D();
		Viewport viewport = relatedElement;
		PictureBox pictureBox = new _0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D
		{
			BorderStyle = pictureBox1.BorderStyle,
			InitialImage = pictureBox1.InitialImage,
			Location = pictureBox1.Location,
			Margin = pictureBox1.Margin,
			Name = pictureBox1.Name,
			Size = pictureBox1.Size,
			SizeMode = pictureBox1.SizeMode,
			TabIndex = pictureBox1.TabIndex,
			TabStop = pictureBox1.TabStop
		};
		panel1.Controls.Remove(pictureBox1);
		pictureBox1 = pictureBox;
		panel1.Controls.Add(pictureBox1);
		((_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D)pictureBox1)._0023_003Dzdjd7G7o_003D(viewport, splitContainer1.Panel1, base.UpdatePicture, _0023_003Dz9iWEovk_003D);
		Point point = new Point(pictureBox1.Location.X + pictureBox1.Size.Width / 2, pictureBox1.Location.Y + pictureBox1.Size.Height / 2);
		pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
		pictureBox1.Size = viewport.Size;
		pictureBox1.Location = new Point(point.X - pictureBox1.Size.Width / 2, point.Y - pictureBox1.Size.Height / 2);
		pictureBox1.Paint += _0023_003DzHtml2H1ifWwUwG2t0Q_003D_003D;
		pictureBox1.MouseMove += _0023_003DzJhJsxiqWmxCHpr1tag_003D_003D;
		pictureBox1.MouseUp += ((_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D)pictureBox1)._0023_003Dzybt1vvbQ_0024v4i;
		checkBoxTransparentBackground.Checked = true;
	}

	private void _0023_003DzJhJsxiqWmxCHpr1tag_003D_003D(object _0023_003DzUNNLWvM_003D, MouseEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport _0023_003Dz7Tv1nWI_003D = _0023_003Dz8XjYxVRNAP4c.SelectedObject as Viewport;
		((_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D)pictureBox1)._0023_003Dz3ELtEkrJanRt(_0023_003Dz7Tv1nWI_003D, _0023_003Dz9I8ZVlc_003D);
	}

	private void _0023_003DzHtml2H1ifWwUwG2t0Q_003D_003D(object _0023_003DzUNNLWvM_003D, PaintEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		Viewport _0023_003Dz7Tv1nWI_003D = _0023_003Dz8XjYxVRNAP4c.SelectedObject as Viewport;
		((_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D)pictureBox1)._0023_003DzaFj_MrNl8OgL(_0023_003Dz7Tv1nWI_003D, _0023_003Dz9I8ZVlc_003D);
	}

	private void _0023_003DzZk4oIW2gdztcs4iuxA_003D_003D(object _0023_003DzUNNLWvM_003D, MouseEventArgs _0023_003Dz9I8ZVlc_003D)
	{
	}

	protected override void buttonOK_Click(object _0023_003DzUNNLWvM_003D, EventArgs _0023_003Dz9I8ZVlc_003D)
	{
		buttonOk = true;
		if (relatedElement != _0023_003Dz8XjYxVRNAP4c.SelectedObject)
		{
			relatedElement.Update((IUserInterfaceElement)_0023_003Dz8XjYxVRNAP4c.SelectedObject);
			((Viewport)_0023_003Dz8XjYxVRNAP4c.SelectedObject).Dispose();
		}
	}

	protected override void propertyGrid1_PropertyValueChanged(object _0023_003Dz8d5a5Pw_003D, PropertyValueChangedEventArgs _0023_003Dz9I8ZVlc_003D)
	{
		base.propertyGrid1_PropertyValueChanged(_0023_003Dz8d5a5Pw_003D, _0023_003Dz9I8ZVlc_003D);
		((_0023_003DzisWXpO8vO50RcQdswsH4ivEOd0ef696J_TQcFtA_003D)pictureBox1)._0023_003Dzwty0fR0_003D((Viewport)_0023_003Dz8XjYxVRNAP4c.SelectedObject);
	}
}
