using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System;
using Rotation3dSample;


[assembly: ExportRenderer(typeof(ImageView), typeof(Rotation3dSample.Droid.ImageViewRenderer))]
namespace Rotation3dSample.Droid
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

				// view has to be automatically adjusted to screen size
				_view.SizeChanged += imageView_SizeChanged;
			}
		}

		void imageView_SizeChanged(object sender, EventArgs e)
		{
			// go up parents and disable clipping
			(Control.Parent as Android.Views.ViewGroup).SetClipChildren(false);
			(Control.Parent.Parent as Android.Views.ViewGroup).SetClipChildren(false);

			// the reference frame is 960x540, so adjust perspective value here to scale consistently
			var scaleFactor = Resources.DisplayMetrics.WidthPixels / 960f;
			Control.SetCameraDistance(_view.Perspective * Resources.DisplayMetrics.Density * scaleFactor);

			Control.RotationX = _view.RotationX;
			Control.RotationY = _view.RotationY;
			Control.Rotation = _view.RotationZ;
		}
	}
}