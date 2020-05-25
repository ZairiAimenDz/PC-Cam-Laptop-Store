using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using PCcamAdmin.Data;
using PCcamAdmin.Models;
using PCcamAdmin.Views;
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
        private FirebaseHelper helper = new FirebaseHelper();

        public Step4(Laptop lp,bool back = false)
        {
            InitializeComponent();
            this.lp = lp;
            file = new List<MediaFile>();
            this.back = back;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            activity.IsRunning = true;
            activity.IsVisible = true;

            lp.imgs = new List<Imgs>();
            string childof = "lp" + lp.Brand.Trim() + lp.Name.Trim();
            foreach (var media in file)
            {
                string filename = "image" + file.IndexOf(media) + ".jpeg";
                var stroageImage = await new FirebaseStorage("pccamdz.appspot.com")
                    .Child(childof)
                    .Child(filename)
                    .PutAsync(media.GetStream());
                string imgurl = stroageImage;
                lp.imgs.Add(new Imgs() { folder = childof, imgname = filename, imgurl = imgurl });
            }
            lp.date = DateTime.Now;
            lp.mainimg = lp.imgs.FirstOrDefault().imgurl;
            await helper.AddLaptop(lp);


                await PopupNavigation.Instance.RemovePageAsync(this);
                await PopupNavigation.Instance.PushAsync(new Step5(lp));
            /*}
            catch
            {
                await DisplayAlert("There Has Been An Error","Check Your Internet Connection","OK");
            }*/

            activity.IsRunning = false;
            activity.IsVisible = false;
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
                foreach (var media in files)
                    file.Add(media);
            }
            catch (Exception ex)
            {
                await DisplayAlert("There Was An Error", "Could You Please Try Again" + ex, "ok");
            }
        }
    }
}