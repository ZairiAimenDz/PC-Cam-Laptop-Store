using Firebase.Database;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace PCcamAdmin.Data
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://pccamdz.firebaseio.com/");
        FirebaseStorage firebaseStorage = new FirebaseStorage("gs://pccamdz.appspot.com/");

    }
}
