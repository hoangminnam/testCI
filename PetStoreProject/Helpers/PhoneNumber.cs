﻿using PhoneNumbers;

namespace PetStoreProject.Helpers
{
    public static class PhoneNumber
    {
        public static bool isValid(string? phoneNumber)
        {
            var phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var numberParsed = phoneUtil.Parse(phoneNumber, "VN");
                var result = phoneUtil.IsValidNumber(numberParsed);
                return result;
            }
            catch (NumberParseException e)
            {
                return false;
            }
        }
    }
}
