﻿using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
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
        //FirebaseStorage firebaseStorage = new FirebaseStorage("gs://pccamdz.appspot.com/");

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
                  storage = item.Object.storage
              }).ToList();

        }
        public async Task AddLaptop(Laptop laptop)
        {
            await firebase
              .Child("Laptops").PostAsync(laptop);
        }
    }
}
