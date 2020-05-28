using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using Newtonsoft.Json.Converters;
using PCcamAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCcamAdmin.Data
{
    public class FirebaseHelper
    {
        readonly FirebaseClient firebase = new FirebaseClient("https://pccamdz.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("pccamdz.appspot.com");

        public async Task<List<Laptop>> Get_Items()
        {
            return (await firebase
              .Child("Laptops")
              .OnceAsync<Laptop>()).Select(item => new Laptop
              {
                  Name = item.Object.Name,
                  Brand = item.Object.Brand,
                  date = item.Object.date,
                  graphics = item.Object.graphics,
                  imgs = item.Object.imgs,
                  mainimg = item.Object.mainimg,
                  Os = item.Object.Os,
                  price = item.Object.price,
                  proc = item.Object.proc,
                  RAM = item.Object.RAM,
                  screen = item.Object.screen,
                  storage = item.Object.storage,
                  issold = item.Object.issold
              }).ToList();

        }
        public async Task AddLaptop(Laptop laptop)
        {
            await firebase
              .Child("Laptops").PostAsync(laptop);
        }
        public async Task UpdateState(DateTime date, string newprice,bool issold)
        {
            var toUpdatePerson = (await firebase
              .Child("Laptops")
              .OnceAsync<Laptop>()).Where(a => a.Object.date == date).FirstOrDefault();
            toUpdatePerson.Object.price = newprice;
            toUpdatePerson.Object.issold = issold;
            var newobj = toUpdatePerson.Object;
            await firebase
              .Child("Laptops")
              .Child(toUpdatePerson.Key)
              .PutAsync(newobj);

        }
        public async Task DeleteLaptop(DateTime date)
        {
            var toDeletePerson = (await firebase
              .Child("Laptops")
              .OnceAsync<Laptop>()).Where(a => a.Object.date == date).FirstOrDefault();
            foreach(var img in toDeletePerson.Object.imgs)
            {
                await firebaseStorage
                .Child(img.folder)
                .Child(img.imgname)
                .DeleteAsync();
            }
            await firebase.Child("Laptops").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
