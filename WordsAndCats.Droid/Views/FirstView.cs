using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using WordsAndCats.Core.ViewModels;
using Cirrious.CrossCore.WeakSubscription;
using Android.Webkit;

namespace WordsAndCats.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity<FirstViewModel>
    {
        MvxNamedNotifyPropertyChangedEventSubscription<string> subscription;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            var webView = FindViewById<WebView>(Resource.Id.webView);

            subscription = ViewModel.WeakSubscribe(() => ViewModel.CatImage, delegate {
                webView.LoadData(ViewModel.CatImage, "text/html", "utf-8");
            });
        }
    }
}