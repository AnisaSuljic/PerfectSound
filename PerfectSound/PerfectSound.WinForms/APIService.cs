using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using PerfectSound.Model;
using PerfectSound.WinForms.Properties;

namespace PerfectSound.WinForms
{
    public class APIService
    {
        public static string username;
        public static string password;
        public static int UserID;
        public string _resource;
        public string endpoint = $"{Resources.ApiUrl}";

        public APIService(string resource)
        {
            _resource = resource;
        }

        private static async Task ErrorHandle(FlurlHttpException ex)
        {
            var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

            var stringBuilder = new StringBuilder();
            foreach (var error in errors)
            {
                stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
            }

            MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public async Task<T> GetAll<T>(object searchRequest = null)
        {
            try
            {
                var query = "";
                if (searchRequest != null)
                {
                    query = await searchRequest?.ToQueryString();
                }

                return await $"{endpoint}{_resource}?{query}"
                    .WithBasicAuth(username, password)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                await ErrorHandle(ex);
                return default(T);
            }
        }       

        public async Task<T> Login<T>()
        {
            try
            {

                return await $"{endpoint}{_resource}/{"Login"}"
                    .WithBasicAuth(username, password)
                    .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.StatusCode == 401)
                    MessageBox.Show("Incorrect username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("An error has occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return default(T);
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                return await $"{endpoint}{_resource}/{id}"
                .WithBasicAuth(username, password)
                .GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                await ErrorHandle(ex);
                return default(T);
            }
        }

        public async Task<T> Insert<T>(object request)
        {
            try
            {
                return await $"{endpoint}{_resource}"
                    .WithBasicAuth(username, password)
                    .PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                await ErrorHandle(ex);
                return default(T);
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                return await $"{endpoint}{_resource}/{id}"
                    .WithBasicAuth(username, password)
                    .PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                await ErrorHandle(ex);
                return default(T);
            }

        }

        public async Task<T> Delete<T>(int id)
        {
            try
            {
                return await $"{endpoint}{_resource}/{id}"
                    .WithBasicAuth(username, password)
                    .DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                await ErrorHandle(ex);
                return default(T);
            }

        }



    }
}
