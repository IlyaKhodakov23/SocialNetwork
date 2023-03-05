using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Sevices;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    internal class Program
    {
        static MessageService messageService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static AddingFriendView addingFriendView;
        public static UserFriendView userFriendView;

        //нужно обратиться к слою бизнес логики и к userservices
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            //Вызываем сервисы
            messageService = new MessageService();
            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            addingFriendView = new AddingFriendView(userService);
            userFriendView = new UserFriendView();

            while (true)
            {
                mainView.Show();
            }
        }
    }
}