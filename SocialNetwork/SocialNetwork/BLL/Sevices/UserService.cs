﻿using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Sevices
{
    public class UserService
    {
        //Определяем переменную интерфейса
        IUserRepository userRepository;

        //Конструктор юзер сервис
        public UserService()
        {
            //присваивание переменной
            userRepository = new UserRepository();
        }

        //Здесь будет добавлена регистрация и проверка на корректность введенных данных
        public void Register(UserRegistrationData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();
            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();
            //ищем в репозитории есть ли такая почта
            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentException();

            //UserRepository работает с сущостью UserEntity поэтому нужно создать экземпляр сущности,
            //чтобы отправить пользователя в репозиторий

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            //обратимся к методу создания репозитория и пробросим через него сущность. проверим, что ошибки нет
            // (так как имеет тип инт, то не должна быть равна 0)
            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }
    }
}
