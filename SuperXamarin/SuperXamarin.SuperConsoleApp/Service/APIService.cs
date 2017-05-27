using Newtonsoft.Json;
using SuperXamarin.PCL.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuperXamarin.PCL.Service
{
    public class APIService
    {
        private string apiKey;
        private string privateKey;
        private string baseURL = "https://gateway.marvel.com:443";

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public async Task<CharacterDataWrapper<Superhero>> GetCharacters(string character)
        {
            try
            {
                CharacterDataWrapper<Superhero> result = new CharacterDataWrapper<Superhero>();
                HttpClient client = new HttpClient()
                {
                    BaseAddress = new Uri(baseURL)
                };
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = "1";
                string hash;
                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, $"{ts}{privateKey}{apiKey}");
                }
                HttpResponseMessage response = await client.GetAsync($@"/v1/public/characters?name={character}&apikey={apiKey}&hash={hash}&ts={ts}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<CharacterDataWrapper<Superhero>>(content);
                }
                return result;
            } catch (Exception ex)
            {
                // return ex.Message;
                throw new Exception(ex.Message);
            }
        }
        public APIService(string apiKey, string privateKey)
        {
            this.apiKey = apiKey;
            this.privateKey = privateKey;
        }
    }
}
