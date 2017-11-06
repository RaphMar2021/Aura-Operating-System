﻿using Aura_OS.System.Drawable;
using Aura_OS.System.Security;
using Aura_OS.System.Translation;
using Aura_OS.System.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aura_OS.System.Users
{
    class Login
    {

        public static void LoginForm()
        {
            string title = Title();
            string text = Menu.DispLoginForm(title);
            int middle = text.IndexOf("//////");
            string user = text.Remove(middle, text.Length - middle);
            string pass = text.Remove(0, middle + 6);
            string md5psw = MD5.hash(pass);
            string type;

            Settings.LoadUsers();

            if(Settings.GetUser("user:" + user).Contains(UserLevel.Administrator()))
            {
                type = UserLevel.Administrator();
            }
            else
            {
                type = UserLevel.StandardUser();
            }

            if (Settings.GetUser("user:" + user).Contains(md5psw))
            {
                Start(user);
            }
            else
            {
                WrongPasswordForm();
                LoginForm();
            }

        }

        private static string Title()
        {
            string title_fr = "Connexion à votre compte Aura.";
            string title_en = "Login to your Aura account.";

            switch (Kernel.langSelected)
            {
                case "en_US":
                    return title_en;
                case "fr_FR":
                    return title_fr;                    
            }

            return title_en; //default
        }

        private static void WrongPasswordForm()
        {
            string text_fr = "Mauvais mot de passe.";
            string text_en = "Wrong password.";

            if(Kernel.langSelected == "fr_FR")
            {
                Menu.DispErrorDialog(text_fr);
            }
            else
            {
                Menu.DispErrorDialog(text_en);
            }            
        }

        private static void Start(string username)
        {
            Console.Clear();

            Kernel.SystemExists = true;
            Kernel.userLogged = username;
            Kernel.JustInstalled = true;
            Kernel.running = true;

            Console.Clear();

            WelcomeMessage.Display();
            Text.Display("logged", username);

            Console.WriteLine();

            Kernel.Logged = true;
        }

    }
}
