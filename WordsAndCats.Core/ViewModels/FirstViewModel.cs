using Cirrious.MvvmCross.ViewModels;
using WordsAndCats.Core.Services;
using Acr.MvvmCross.Plugins.UserDialogs;

namespace WordsAndCats.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        IDataService dataService;

        IUserDialogService userDialogService;

        public FirstViewModel(IDataService dataService, IUserDialogService userDialogService)
        {
            this.userDialogService = userDialogService;
            this.dataService = dataService;
        }

        
        public string RandomWords { get; set; }

        async void GetRandomWords()
        {
            var result = await userDialogService.PromptAsync("How many words would you like?");
            if (!result.Ok)
                return;

            int count;
            if (!int.TryParse(result.Text, out count)) {
                userDialogService.Toast("Please enter a number.");
                return;
            }

            using (userDialogService.Loading()) {
                var words = await dataService.GetRandomWordsAsync(count);

                RandomWords = string.Join(", ", words);
            }
        }

        public byte[] CatBytes { get; set; }

        public string CatBase64 => System.Convert.ToBase64String(CatBytes);

        public string CatImage => $"<img style='width: 100%' src='data:image/gif;base64,{CatBase64}' />";

        async void GetCat()
        {
            using (userDialogService.Loading("Chasing down a cat...")) {
                CatBytes = await dataService.GetCatAsync();
            }
        }

        public IMvxCommand GetRandomWordsCommand { get { return new MvxCommand(GetRandomWords); } }

        public IMvxCommand GetCatCommand { get { return new MvxCommand(GetCat); } }
    }
}
