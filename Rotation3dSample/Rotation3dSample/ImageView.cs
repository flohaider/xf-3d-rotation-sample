using Xamarin.Forms;


namespace Rotation3dSample
{
    public class ImageView : Image
    {
		public int RotationX { get; set; }
		public int RotationY { get; set; }
		public int RotationZ { get; set; }
		public int Perspective { get; set; }

		public ImageView(int rotationX, int rotationY, int rotationZ, int perspective)
		{
			RotationX = rotationX;
			RotationY = rotationY;
			RotationZ = rotationZ;
			Perspective = perspective;
		}
    }
}
