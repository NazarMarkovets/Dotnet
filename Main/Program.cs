using System;
using Lib.Interfaces;
using Lib.Models;
using Lib.Modules;

namespace Main
{
    internal static class Program
    {
        
        public static void Main()
        {
            var person = new PersonModule<DirectorModel>();

             #region CanBeUsed
                // DirectorModel directorModel = new DirectorModel();
                // directorModel.SetPersonalData();
                // directorModel.GetAge();
             #endregion
             
            person.InitializePerson(new DirectorModel());
            person.GetAllData();

        }
    }

}