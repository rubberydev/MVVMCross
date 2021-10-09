using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using Serilog;
using System.Reflection;
using TipCalculator.Core.ViewModels;

namespace TipCalculator.Android.Views
{
    [Activity(Label = "@string/app_name")]
	public class TipView : MvxActivity<TipViewModel>
	{
		Spinner spinner;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.TipPage);
			Button button = FindViewById<Button>(Resource.Id.NavigateButton);
			button.Click += delegate
			{
				StartActivity(typeof(HistoricActivity));
				/*spinner = FindViewById<Spinner>(Resource.Id.spinner);
				spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
				var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.operations_items, Android.Resource.Layout.support_simple_spinner_dropdown_item);
				adapter.SetDropDownViewResource(Android.Resource.Layout.support_simple_spinner_dropdown_item);
				spinner.Adapter = adapter;*/
				this.Bootstraping();
			};
		}
		private void InitializeNLog()
		{
			Assembly assembly = this.GetType().Assembly;
			string assemblyName = assembly.GetName().Name;
			//new Helpers.LogService().Initialize(assembly, assemblyName);
		}

		private void Bootstraping()
		{
			var assembly = this.GetType().Assembly;
			var assemblyName = assembly.GetName().Name;
		}
		/*private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
			Spinner spinner = (Spinner)sender;
			var itemSelected = spinner.GetItemAtPosition(e.Position);
		}*/
	}
}