using ParavarejoApp.Models.ParavarejoLucroReal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParavarejoApp.Services
{
    public class Services
    {
        private static Services _instance;

        internal LucroReal LucroRealModel { get; set; }

        public static Services GetInstance()
        {
            return _instance == null ? _instance = new Services() : _instance;
        }

        private Services()
        {

        }
    }
}
