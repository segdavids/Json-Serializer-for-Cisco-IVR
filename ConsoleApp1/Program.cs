using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




namespace ConsoleProgram
{


    public class Class1
    {
        public class Account
        {
            public string Address { get; set; }
            public string AccountProductCode { get; set; }
            public string Sex { get; set; }
            public string CustomerID { get; set; }
            public string AccountType { get; set; }
            public string CustomerType { get; set; }
            public string EmailAddress { get; set; }
            public string AccountNumber { get; set; }
            public string AccountStatus { get; set; }
            public string AccountCurrency { get; set; }
            public string Phone { get; set; }
            public string AccountBalance { get; set; }
            public string FullName { get; set; }
            public string BVN { get; set; }
            public string AccountName { get; set; }
            public string BirthDate { get; set; }
        }
        

        static void Main()
        {
            HttpClient testcconsole = new HttpClient();
            testcconsole.BaseAddress = new Uri("http://154.113.16.142:8088/AppDevAPI/");
            testcconsole.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = testcconsole.GetAsync("api/GetCustomerInfoByAccountNumber/?AccountNumber=1700085845").Result;
            if (response.IsSuccessStatusCode)
            {



                var acctdet = response.Content.ReadAsStringAsync().Result;
               // var newer = acctdet.TrimEnd(']', '!', '<');
               // var newer1 = newer.TrimStart('[', '!', '<');

                // Console.WriteLine(acctdet);
                dynamic jsonRes = JsonConvert.SerializeObject(acctdet);
                var x = acctdet[10];
                //itemsArray = JObject.;
                //Newtonsoft.Json.Linq.JObject Jsonobject = Newtonsoft.Json.Linq.JObject.Parse(acctdet);
               // jsonRes = jsonRes.Trim("\"".ToCharArray());
                var test = JsonConvert.DeserializeObject<List<Account>>(jsonRes);
                Console.WriteLine(test[0].Phone);
               // Console.WriteLine(acctdet);


            }



            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                Console.WriteLine("done");
                Console.ReadLine();
            }
            }
        }
    } 
       
