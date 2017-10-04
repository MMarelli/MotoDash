using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using System.Threading;

namespace MotoDash
{
    [Activity(Label = "Speedometer")]
    public class SpeedometerActivity : Activity
    {
        Location location;
        int refreshRate = 2;
        float speed;
        float accuracy;
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            TimerCallback timerDelegate = new TimerCallback(RefreshCallback);

            Timer refreshTimer = new Timer(timerDelegate, null, 0, 1000/refreshRate);

        }

        void RefreshCallback(Object o)
        {
            speed = location.Speed;
            accuracy = location.Accuracy;
        }
    }
}