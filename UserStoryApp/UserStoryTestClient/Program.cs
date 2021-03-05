using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserStoryStuff;

namespace UserStoryTestClient
{
    internal class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static UsersClient usersClient;
        private static DocumentsClient documentsClient;
        private static string jwtToken;

        private static async Task Main(string[] args)
        {
            usersClient = new UsersClient(httpClient);
            documentsClient = new DocumentsClient(httpClient);

            while (true)
            {
                Console.Write("Hello Dave? What do you want to do today?");
                Console.WriteLine("");
                Console.WriteLine("1 - Create a user");
                Console.WriteLine("2 - Login a user");
                Console.WriteLine("3 - Create user story");

                var menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        await CreateNewUser();
                        break;
                    case "2":
                        await LoginToSystem();
                        break;
                    case "3":
                        await CreateRandomUserStory();
                        break;

                    default:
                        Console.WriteLine("What?????????");
                        break;
                }
            }
        }

        private static async Task LoginToSystem()
        {
            var loginInfo = new UserDto
            {
                Username = "michael.p.rosario@gmail.com",
                Password = "password123"
            };
            var response = await usersClient.AuthenticateAsync(loginInfo);

            var responseString = JsonConvert.SerializeObject(response);
            jwtToken = response.Token;
        }

        private static async Task CreateRandomUserStory()
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var userStory = new UserStory
            {
                Complexity = 1,
                Priority = 2,
                DoneConditions = "done conditions " + DateTime.Now,
                Story = "As a user, I should do all the things."
            };

            var jsonString = JsonConvert.SerializeObject(userStory);
            var storeDocumentCommand = new StoreDocumentCommand
            {
                Document = new Doc
                {
                    CollectionName = "UserStory",
                    Id = Guid.NewGuid().ToString(),
                    JsonData = jsonString,
                    Name = "user story " + DateTime.Now
                }
            };

            var response = await documentsClient.StoreDocumentAsync(storeDocumentCommand);
            var responseString = JsonConvert.SerializeObject(response);
            Console.WriteLine(responseString);
        }

        private static async Task CreateNewUser()
        {
            var command = new RegisterUserCommand
            {
                FirstName = "Michael",
                LastName = "Rosario",
                Password = "password123",
                UserName = "michael.p.rosario@gmail.com"
            };
            var response = await usersClient.RegisterUserAsync(command);
            if (response.Code == ResponseCode.Success)
            {
                Console.WriteLine("User created!!");
            }
            else
            {
                var errorContent = JsonConvert.SerializeObject(response);
                Console.WriteLine(errorContent);
            }
        }
    }
}