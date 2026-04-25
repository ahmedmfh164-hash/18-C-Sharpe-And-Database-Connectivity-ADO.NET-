using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountriesDataAccessLayer;

namespace CountriesBusinessLayer
{
    public class clsCountries
    {
        private enum enMode { AddNew = 0, Update = 1 };

        private enMode Mode = enMode.AddNew;
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCode { get; set; }

        public clsCountries()
        {
            this.CountryID=-1;
            this.CountryName="";
            this.ContinentName="";
            this.CountryCode="";
            PhoneCode ="";
            Mode=enMode.AddNew;
        }

        private clsCountries(int countryID, string CountryName, string ContinentName, string CountryCode, string PhoneCode)
        {
            this.CountryID=countryID;
            this.CountryName=CountryName;
            this.ContinentName=ContinentName;
            this.CountryCode=CountryCode;
            this.PhoneCode=PhoneCode;
            Mode=enMode.Update;

        }


        private bool _AddNewCountry()
        {
            this.CountryID=clsCountriesDataAccess.AddNewCountry(this.CountryName, this.ContinentName, CountryCode, PhoneCode);

            return (this.CountryID!=-1);
        }

        private bool _UpdateCountry()
        {
            return clsCountriesDataAccess.UpdateCountry(this.CountryID, this.CountryName, this.ContinentName, this.CountryCode, this.PhoneCode);
        }

        public static clsCountries FindByID(int CountryID)
        {
            string CountryName = "", ContinentName = "", CountryCode = "", PhoneCode = "";

            if (clsCountriesDataAccess.GetCountriesInfoByID(CountryID, ref CountryName, ref ContinentName, ref CountryCode, ref PhoneCode))

                return new clsCountries(CountryID, CountryName, ContinentName, CountryCode, PhoneCode);

            else
                return null;

        }

        public static clsCountries FindByName(string CountryName)
        {
            int CountryID = -1;
            string ContinentName = "", CountryCode = "", PhoneCode = "";

            if (clsCountriesDataAccess.GetCountriesInfoByCountryName(ref CountryID, CountryName, ref ContinentName, ref CountryCode, ref PhoneCode))

                return new clsCountries(CountryID, CountryName, ContinentName, CountryCode, PhoneCode);

            else
                return null;


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateCountry();

            }
            return false;

        }

        public static bool isCountryExistByID(int CountryID)
        {
            return clsCountriesDataAccess.IsCountryExistByID(CountryID);
        }

        public static bool isCountryExistByCountryName(string CountryName)
        {
            return clsCountriesDataAccess.IsCountryExistByCountryName(CountryName);
        }


        public static bool DeleteCountry(int CountryID)
        {
            return clsCountriesDataAccess.DeleteCountry(CountryID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

    }
}
