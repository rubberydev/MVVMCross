﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TipCalculator.Android.Helpers;
using TipCalculator.Android.Views;

namespace TipCalculator.Android
{
    [Activity(Label = "HistoricActivity")]
    public class HistoricActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HistoricPage);
            // Create your application here
          
            var button = FindViewById<Button>(Resource.Id.second);

            button.Click += delegate { StartActivity(typeof(TipView)); };

             
            var mainList = (ListView)FindViewById<ListView>(Resource.Id.historiclistview);
            mainList.Adapter = new ArrayAdapter(this, Android.Resource.Layout.support_simple_spinner_dropdown_item, ExecutionHistoricUtil.GetInstance().ExecutionHistorialInMemory.ToArray());
        }
    }
}