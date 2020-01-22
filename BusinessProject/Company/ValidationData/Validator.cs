using System;
using System.Collections.Generic;
using System.Text;

namespace Company.ValidationData
{
   public static class Validator
    {
        public static bool isCorrectStringData(string value, int min_length_data)
        {
            if (value != null)
            {
                string data = value.Trim();
                if (data.Length >= min_length_data)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static bool isCorrectIntegerData(string value, int min_restriction, out int data)
        {
            if (value != null)
            {
                bool check = int.TryParse(value, out int numData);
                if (check && numData >= min_restriction)
                {
                    data = numData;
                    return true;
                }
                data = 0;
                return false;
            }
            data = 0;
            return false;
        }
        public static bool isCorrectIntegerData(string value, int min_restriction, int max_restriction, out int data)
        {
            if (value != null)
            {
                bool check = int.TryParse(value, out int numData);
                if (check && numData >= min_restriction && numData <= max_restriction)
                {
                    data = numData;
                    return true;
                }
                data = 0;
                return false;
            }
            data = 0;
            return false;
        }
        public static bool isCorrectDecimalData(string value, decimal min_restriction, out decimal data)
        {
            if (value != null)
            {
                bool check = decimal.TryParse(value, out decimal numData);
                if (check && numData >= min_restriction)
                {
                    data = numData;
                    return true;
                }
                data = 0;
                return false;
            }
            data = 0;
            return false;
        }
        public static bool isCorrectDecimalData(string value, decimal min_restriction, decimal max_restriction, out decimal data)
        {
            if (value != null)
            {
                bool check = decimal.TryParse(value, out decimal numData);
                if (check && numData >= min_restriction && numData <= max_restriction)
                {
                    data = numData;
                    return true;
                }
                data = 0;
                return false;
            }
            data = 0;
            return false;
        }
    }
}
