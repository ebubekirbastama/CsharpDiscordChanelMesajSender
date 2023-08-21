     private string Dcmesajsender(string Mesaj, string Authorization, string channelsİD)
        {
            string url = "https://discord.com/api/v9/channels/" + channelsİD + "/messages";
            HttpClient httpClient = new HttpClient();

            var content = new StringContent("{\"content\":\"" + Mesaj + "\",\"nonce\":\"\",\"tts\":false,\"flags\":0}", Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Add("Authority", "discord.com");
            httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
            httpClient.DefaultRequestHeaders.Add("Authorization", Authorization);
            httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            // Diğer başlık bilgilerini buraya ekleyin...

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");



            var response = httpClient.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                return $"HTTP Error: {response.StatusCode}";
            }
        }


//Örnek Kullanımı
Dcmesajsender("Ebubekir Bastama Mesaj Komutu :)", "Authorization Girilecek", "Kanal İd değeri Girilecek")
