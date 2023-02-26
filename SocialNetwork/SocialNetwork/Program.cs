using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Sevices;

namespace SocialNetwork
{
    internal class Program
    {
        //нужно обратиться к слою бизнес логики и к userservices
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while(true)
            {
                Console.WriteLine("Введите имя пользователя:");
                string firstName = Console.ReadLine();

                Console.Write("Фамилия:");
                string lastName = Console.ReadLine();

                Console.Write("Пароль:");
                string password = Console.ReadLine();

                Console.Write("Почтовый адрес:");
                string email = Console.ReadLine();

                //создадим экземпляр UserRegistrationData, так как регистрация работает с ним
                //и передадим в него наши полученные значения из консоли
                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                userService.Register(userRegistrationData);

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация произошла успешно!");
                }

                catch (ArgumentNullException ae)
                {
                    Console.WriteLine(ae.Message);
                    Console.WriteLine("Введите корректное значение");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Произошла ошибка при регистрации");
                }
            }
        }
    }
}