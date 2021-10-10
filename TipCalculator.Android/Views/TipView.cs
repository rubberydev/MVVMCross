using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Platforms.Android.Views;
using Serilog;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TipCalculator.Android.Helpers;
using TipCalculator.Core.ViewModels;

namespace TipCalculator.Android.Views
{
    [Activity(Label = "@string/app_name")]
	public class TipView : MvxActivity<TipViewModel>
	{
		Spinner spinner;
		protected  override  void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.TipPage);

			//Create Database  
			var db = new Database();
			db.createDatabase();
			Historial historicRegister = new Historial()
			{
				Register = $"Execution: {DateTime.Now.ToString()}"
			};

			db.insertIntoTable(historicRegister);

			//button to navigate Historic view
			Button button = FindViewById<Button>(Resource.Id.NavigateButton);
			button.Click += delegate
			{
				// i Keep one instance in order to build the list to show in historial execution list view
				var executionList = ExecutionHistoricUtil.GetInstance().ExecutionHistorialInMemory;

				var listOfExecutions = db.selectTable().Select(h=> h.Register);

                foreach (var item in listOfExecutions)
                {
					executionList.Add(item);
                }


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