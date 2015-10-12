using System;
using Xamarin.Forms;


namespace Rotation3dSample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			var mainLayout = new RelativeLayout();
			var contentLayout = new RelativeLayout();

			// center content layout inside main (full width, height according to 16:9 aspect ratio)
			mainLayout.Children.Add(contentLayout,
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) =>
				{
					return ((parent.Height / 2) - ((parent.Width * 0.5625) / 2));
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return parent.Width;
				}),
				Constraint.RelativeToParent((parent) =>
				{
					return (parent.Width * 0.5625);
				})
			);

			// add fullscreen background image to content layout
			var bgImageView = new Image();
			bgImageView.Source = ImageSource.FromUri(new Uri("https://client.exploodo.media/exploodo/fe407ce2-cdcc-4e1c-92f2-a3ce00d0ce5d/i/48D2CFC05787FB23raster_60px-01.png"));
			bgImageView.Aspect = Aspect.Fill;

			contentLayout.Children.Add(bgImageView,
				xConstraint: Constraint.Constant(0),
				yConstraint: Constraint.Constant(0),
				widthConstraint: Constraint.RelativeToParent(parent => parent.Width),
				heightConstraint: Constraint.RelativeToParent(parent => parent.Height)
			);

			// add rotated image to content layout (use custom view renderer here)
			// rotation is 45 degrees around Y with a camera distance of 200 pixels
			var rotatedImageView = new ImageView(0, 45, 0, 200);
			rotatedImageView.Source = ImageSource.FromUri(new Uri("https://client.exploodo.media/exploodo/fe407ce2-cdcc-4e1c-92f2-a3ce00d0ce5d/i/48D1C66D9599E8F2office_STILL_03.jpg"));
			rotatedImageView.Aspect = Aspect.Fill;

			// center it (size simply is 1/3 of parent)
			contentLayout.Children.Add(rotatedImageView,
				xConstraint: Constraint.RelativeToParent(parent => parent.Width / 2 - parent.Width / 6),
				yConstraint: Constraint.RelativeToParent(parent => parent.Height / 2 - parent.Height / 6),
				widthConstraint: Constraint.RelativeToParent(parent => parent.Width / 3),
				heightConstraint: Constraint.RelativeToParent(parent => parent.Height / 3)
			);

			MainPage = new ContentPage {
				Content = mainLayout
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
