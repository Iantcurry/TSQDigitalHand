using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TSQDigitalHand
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardMagnifier : ContentPage
	{
		public string ImagePath;

		public CardMagnifier (string imagepath)
		{
			InitializeComponent ();
			ImagePath = imagepath;
			img_CardImage.Source = ImageSource.FromFile(ImagePath);
		}

        private async void btn_Bigger_Clicked(object sender, EventArgs e)
        {
			await pz_ImageContainer.Content.RelScaleTo(1);

			pz_ImageContainer.Content.TranslationX = 0;
			pz_ImageContainer.Content.TranslationY = 0;
		}

        private async void btn_Smaller_Clicked(object sender, EventArgs e)
        {

			await pz_ImageContainer.Content.RelScaleTo(-1);

			System.Diagnostics.Debug.WriteLine(pz_ImageContainer.Content.Scale.ToString());

			if (pz_ImageContainer.Content.Scale < 1)
				pz_ImageContainer.Content.Scale = 1;

			pz_ImageContainer.Content.TranslationX = 0;
			pz_ImageContainer.Content.TranslationY = 0;
		}

        private async void btn_Close_Clicked(object sender, EventArgs e)
        {
			await Application.Current.MainPage.Navigation.PopModalAsync();
		}
    }
}