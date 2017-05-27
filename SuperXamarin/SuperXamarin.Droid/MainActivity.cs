using Android.App;
using Android.Widget;
using Android.OS;
using System;
using SuperXamarin.PCL.Service;
using Android.Views;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;

namespace SuperXamarin.Droid
{
    [Activity(Label = "SuperXamarin.Droid", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/DemoTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button BtnGetCharacter;
        EditText TxtSearch;
        APIService client;
        // Toolbar toolbar;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            client = new APIService("", "");

            // Toolbar
            //toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //toolbar.Title = "";
            //SetSupportActionBar(toolbar);
            BtnGetCharacter = FindViewById<Button>(Resource.Id.BtnGetCharacter);
            BtnGetCharacter.Click += BtnGetCharacter_Click;

            TxtSearch = FindViewById<EditText>(Resource.Id.TxtSearch);
            // TxtSearch.SetImeActionLabel("Custom Text", Android.Views.InputMethods.ImeAction.Done);
            TxtSearch.KeyPress += TxtSearch_KeyPress;
        }

        private async void TxtSearch_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    var character = await client.GetCharacters(TxtSearch.Text);
                    Toast.MakeText(this, character.Data.Count.ToString(), ToastLength.Short);
                    e.Handled = true;
                }
            } catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }

        private async void BtnGetCharacter_Click(object sender, EventArgs e)
        {
            try
            {
                var character = await client.GetCharacters("Daredevil");
                Toast.MakeText(this, character.Data.Count.ToString(), ToastLength.Short);
            } catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }

        private void Fab_CLick(object sender, EventArgs e)
        {
            //Snackbar
            //    .Make(fab, "Hola!", Snackbar.LengthLong)
            //    .SetAction("Clic Aqui", (view) =>
            //    {
            //        var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
            //        builder.SetTitle("Alerta Importante")
            //            .SetMessage("Esto es una alerta de Material Design. Quieres acción?")
            //            .SetPositiveButton("Si", delegate
            //            {
            //                Toast.MakeText(this, "Acción realizada", ToastLength.Short).Show();
            //            })
            //            .SetNegativeButton("No", delegate { });
            //    }).Show();
        }
    }
}

