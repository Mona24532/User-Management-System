namespace Frontend
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<string> login(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/Employee/login-Post", model);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }

        // C#
      /*  public async Task<string> adminlogin(LoginModel model)
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                var response = await _http.PostAsJsonAsync("api/Employee/admin-Post", model, cts.Token);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException tex)
            {
                Console.Error.WriteLine($"Request canceled: {tex.Message}");
                if (tex.InnerException != null)
                    Console.Error.WriteLine($"Inner: {tex.InnerException.GetType()}: {tex.InnerException.Message}");
                throw;
            }
        }*/


        public async Task<string>adminlogin(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/Employee/admin-Post", model);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }
        /*public async Task<string>adminLoginalt(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/Employee/admin-post-alt",model);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }*/
    }
}
