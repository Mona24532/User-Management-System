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

        public async Task<string>adminlogin(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/Employee/admin-Post", model);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}
