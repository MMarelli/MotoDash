using Android.App;
using Android.Widget;
using Android.OS;

namespace MotoDash
{
    [Activity(Label = "MotoDash", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button speedometerButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            speedometerButton = FindViewById<Button>(Resource.Id.SpeedometerButton);

            speedometerButton.Click += delegate
            {
                StartActivity(typeof(SpeedometerActivity));
            };
        }
    }
}