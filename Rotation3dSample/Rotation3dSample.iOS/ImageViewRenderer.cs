using Rotation3dSample;
using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(ImageView), typeof(Rotation3dSample.iOS.ImageViewRenderer))]
namespace Rotation3dSample.iOS
{
	public class ImageViewRenderer : ImageRenderer
	{
		private ImageView _view;

		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				_view = (ImageView)e.NewElement;

				//ContentScaleFactor = UIScreen.MainScreen.Scale;

				// view has to be automatically adjusted to screen size
				_view.SizeChanged += imageView_SizeChanged;
			}
		}

		void imageView_SizeChanged(object sender, EventArgs e)
		{
			// the reference frame is 960x540, so adjust perspective value here to scale consistently
			var scaleFactor = UIScreen.MainScreen.Bounds.Width / new nfloat(960f);

			var transform = CoreAnimation.CATransform3D.Identity;
			transform.m34 = new nfloat(-1f) / (new nfloat(_view.Perspective * scaleFactor));

			transform = transform.Rotate(new nfloat(_view.RotationX * Math.PI / 180f), 1, 0, 0);
			transform = transform.Rotate(new nfloat(_view.RotationY * Math.PI / 180f), 0, 1, 0);
			transform = transform.Rotate(new nfloat(_view.RotationZ * Math.PI / 180f), 0, 0, 1);

			Control.Layer.Transform = transform;
		}
	}
}
