namespace CacheCalculator;
using System;
using System.Security.Cryptography;
using System.Text;

public class Calculator
{
    private string _requestParams;
    private string _secretKey;

    public string Calculate()
    {
        SortRequestParams();
        return GetMd5Hash(_requestParams + _secretKey);
    }

    public void SetParams(string inputRequestParams)
    {
        _requestParams = inputRequestParams;
    }
    
    public void SetKey(string inputSecretKey)
    {
        _secretKey = inputSecretKey;
    }

    private void SortRequestParams()
    {
        Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
        foreach (string parameter in _requestParams.Split('&'))
        {
            string[] splitedParameters = parameter.Split('=');
            parameterDictionary[splitedParameters[0]] = splitedParameters[1];
        }
        
        List<string> sortedKeys = parameterDictionary.Keys.ToList();
        sortedKeys.Sort();
        
        if (sortedKeys.Count < 2)
        {
            return;
        }

        string result = "";

        foreach (string key in sortedKeys)
        {
            result += key + "=" + parameterDictionary[key] + "&";
        }

        result = result.TrimEnd('&');
        
        _requestParams = result;
    }

    private string GetMd5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Converts to lowercase hex
            }
            return sb.ToString();
        }
    }
}