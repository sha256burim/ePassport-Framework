using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePassport_Framework
{
    class User_data
    {

        //Data 

        public class Data {
            public string Surname { get; set; }
            public string Name { get; set; }
            public string Date_of_Birth { get; set; }
            public string Sex { get; set; }
            public string issue_date { get; set; }
            public string expiry_date { get; set; }
            public string internal_ID_Number { get; set; }
            public string external_ID_number { get; set; }
            public string Authorized_by { get; set; }
        }

        //Should add public id for indexing in .json file, and a private ID that will be encrypted with the other data.
        //^^^ DONE:

        //Json Structure Class
        public void Serialize_json
            (
            string Surname,
            string Name,
            string Date_of_Birth,
            string Sex,
            string issue_date,
            string expiry_date ,
            string internal_ID_number,
            string external_ID_number,
            string Authorized_by
            )
        {
            Data New_data = new Data();

            New_data.Surname = Surname;
            New_data.Name = Name;
            New_data.Date_of_Birth = Date_of_Birth;
            New_data.Sex = Sex;
            New_data.issue_date = issue_date;
            New_data.expiry_date = expiry_date;
            New_data.internal_ID_Number = internal_ID_number;
            New_data.external_ID_number = external_ID_number;
            New_data.Authorized_by = Authorized_by; //probably also add an authorization key

            string json = JsonConvert.SerializeObject(New_data);

            //File.AppendAllText("User_data.json", "\n"+json); //old append with the unencrypted data only

            //send to encrypted thing to do the encryption
            Encryption something = new Encryption();



            byte[] key = something.KeyGenerator("hellodarknessmyoldfriend");
            byte[] IV = something.IVGenerator();
            string someOtherString = Encoding.ASCII.GetString(IV);

            byte[] EncryptedJsonData = something.Encrypt(json, key, IV);

            string SomeString = Encoding.ASCII.GetString(EncryptedJsonData);

            File.AppendAllText("User_data.json", "\n" + SomeString + "\n" + someOtherString);

            string DecryptedJson = something.Decrypt(EncryptedJsonData, key, IV);

            
            File.AppendAllText("User_data.json", "\n" + DecryptedJson + "\n" + someOtherString);


            // also make a log file (encrypted or unencrypted, maybe censored with * asterixes for id's and such)
            // that tells what opertions/changes have been made to the json databases
            //Also make it so the external ID number is written first to the .json file that's encrypted.
            //so searches can quickly identify the needed info and decrypt it for reading or editing. 


            //Note: Make .json database encrypted later and it decrypts everytime you acess it.
            //Add an export unencrypted data method

        }
       
    }
}
