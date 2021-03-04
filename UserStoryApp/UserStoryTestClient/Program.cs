using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserStoryStuff;

namespace UserStoryTestClient
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static UsersClient usersClient;
        static async Task Main(string[] args)
        {
            usersClient = new UsersClient(httpClient);

            while (true)
            {
                Console.Write("Hello Dave? What do you want to do today?");
                Console.WriteLine("");
                Console.WriteLine("1 - Create a user");
                Console.WriteLine("2 - Login a user");

                var menuSelection = Console.ReadLine();

                switch (menuSelection)
                {
                    case "1":
                        await CreateNewUser();
                        break;
                    case "2":
                        await LoginToSystem();
                        break;
                    default:
                        Console.WriteLine("What?????????");
                        break;
                }
            }

        }

        private static async Task LoginToSystem()
        {
            UserDto loginInfo = new UserDto();
            loginInfo.Username = "michael.p.rosario@gmail.com";
            loginInfo.Password = "password123";
            var response = await usersClient.AuthenticateAsync(loginInfo);


            var responseString = JsonConvert.SerializeObject(response);
            Console.WriteLine(responseString);
        }

        private static async Task CreateNewUser()
        {
            RegisterUserCommand command = new RegisterUserCommand
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
