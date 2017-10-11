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
using Android.Hardware;

namespace MotoDash
{
    [Activity(Label = "LeanAngleActivity")]
    public class LeanAngleActivity : Activity, ISensorEventListener
    {
        SensorManager sensorManager;
        Sensor rotationVector;

        TextView xReadout;
        TextView yReadout;
        TextView zReadout;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            throw new NotImplementedException();
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if(e.Sensor.Type == SensorType.GameRotationVector)
            {
                xReadout.Text = e.Values[0].ToString();
                yReadout.Text = e.Values[1].ToString();
                zReadout.Text = e.Values[2].ToString();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Create your application here
            SetContentView(Resource.Layout.LeanAngle);

            InitializeSensors();
            RegisterListeners();

            xReadout = FindViewById<TextView>(Resource.Id.xReadout);
            yReadout = FindViewById<TextView>(Resource.Id.yReadout);
            zReadout = FindViewById<TextView>(Resource.Id.zReadout);
        }

        private void InitializeSensors()
        {
            sensorManager = (SensorManager)GetSystemService(SensorService);
            rotationVector = sensorManager.GetDefaultSensor(SensorType.GameRotationVector);
            if(rotationVector == null)
            {
                throw new NotSupportedException("No Game Rotation Vector sensor");
            }
        }

        private void RegisterListeners()
        {
            sensorManager.RegisterListener(this, rotationVector, SensorDelay.Game);
        }
    }
}