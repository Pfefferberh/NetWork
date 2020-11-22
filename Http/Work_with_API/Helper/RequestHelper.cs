using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Work_with_API.Helper
{
    class RequestHelper
    {
        public const string url = "http://hp-api.herokuapp.com/api/characters/students";

        public static async Task<List<Student>> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            return students;
        }
        public static async Task<byte[]> GetPhoto(Student currentSelection)
        {
            HttpClient client = new HttpClient();
            return await client.GetByteArrayAsync(currentSelection.image);
        }
    }
}
