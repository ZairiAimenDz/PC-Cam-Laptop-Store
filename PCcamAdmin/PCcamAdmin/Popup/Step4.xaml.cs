using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using PCcamAdmin.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCcamAdmin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Step4 : PopupPage  
    {
        private readonly Laptop lp;
        private readonly bool back;
        private List<MediaFile> file;

        public Step4(Laptop lp,bool back = false)
        {
            InitializeComponent();
            this.lp = lp;
            this.back = back;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            activity.IsRunning = true;
            activity.IsVisible = true;
            lp.imgs = new List<Imgs>();
            string childof = "lp" + lp.Brand.Trim() + lp.Name.Trim();
            foreach (var media in file) {
                string filename = "image" + file.IndexOf(media) + ".jpeg";
                var stroageImage = await new FirebaseStorage("pccamdz.appspot.com")
                    .Child(childof)
                    .Child(filename)
                    .PutAsync(media.GetStream());
                string imgurl = stroageImage;
                lp.imgs.Add(new Imgs() {folder=childof,imgname=filename,imgurl=imgurl});
            }

            await new FirebaseClient("https://pccamdz.firebaseio.com/")
              .Child("Laptops")
              .PostAsync(lp);


            await PopupNavigation.Instance.RemovePageAsync(this);
            await PopupNavigation.Instance.PushAsync(new Step5(lp));
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                var files = await Plugin.Media.CrossMedia.Current.PickPhotosAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (files == null)
                    return;                    
                
                foreach(var media in files)
                {
                    var imgChoosed = new Image() {
                        WidthRequest=128 ,
                        HeightRequest=128,
                        Source = ImageSource.FromStream(() =>
                        {
                            var imageStram = media.GetStream();
                            return imageStram;
                        })
                };
                    Photos.Children.Add(imgChoosed);
                }
                file.AddRange(files);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}