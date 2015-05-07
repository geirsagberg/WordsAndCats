using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WordsAndCats.Core.ViewModels;
using Cirrious.CrossCore.WeakSubscription;

namespace WordsAndCats.iOS.Views
{
    [MvxFromStoryboard]
    public partial class FirstView : MvxViewController<FirstViewModel>
    {
        public FirstView(System.IntPtr handle) : base(handle)
        {
        }

        MvxNamedNotifyPropertyChangedEventSubscription<string> catSubscription;        

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            catSubscription = ViewModel.WeakSubscribe(() => ViewModel.CatImage, delegate {
                
                WebView.LoadHtmlString(ViewModel.CatImage, new NSUrl("http://localhost"));
            });

            var getCatButton = new UIBarButtonItem {
                Title = "Get cat"
            };

            var getWordsButton = new UIBarButtonItem{
                Title = "Get words"
            };
            NavigationItem.LeftBarButtonItem = getCatButton;
            NavigationItem.RightBarButtonItem = getWordsButton;

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            set.Bind(WordsLabel).To(vm => vm.RandomWords);
            set.Bind(getCatButton).To(vm => vm.GetCatCommand);
            set.Bind(getWordsButton).To(vm => vm.GetRandomWordsCommand);
            set.Apply();
        }
    }
}