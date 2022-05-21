using DevExpress.XtraSplashScreen;
using System.Drawing;
using System.Windows.Forms;

namespace Umoxi
{
    class OverlayFormShow
    {
        private static OverlayFormShow _defaultInstance;
        public static OverlayFormShow Instance
        {
            get
            {
                if (_defaultInstance == null)
                {
                    _defaultInstance = new OverlayFormShow();
                }
                return _defaultInstance;
            }
            set => _defaultInstance = value;
        }
        public IOverlaySplashScreenHandle handle = null;
        public OverlayFormShow()
        {

        }

        public void ShowFormOverlay(Control control)
        {
            Bitmap img = new Bitmap(1, 1);
            bool useFadeIn = false;
            bool useFadeOut = false;
            Color backColor = Color.Black;
            Color foreColor = Color.Black;
            double opacity = 0.5;
            Image waitImage = img;
            OverlayWindowOptions options = new OverlayWindowOptions(
                useFadeIn,
                useFadeOut,
                backColor,
                foreColor,
                opacity,
                waitImage);
            this.handle = ShowProgressPanel(control, options);
        }

        public IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions option)
        {
            return handle = SplashScreenManager.ShowOverlayForm(control, option);
        }
        public void CloseProgressPanel()
        {
            if (handle != null)
                SplashScreenManager.CloseOverlayForm(this.handle);
        }
        public void Dispose() {
            this.Dispose();
        }
    }
}
