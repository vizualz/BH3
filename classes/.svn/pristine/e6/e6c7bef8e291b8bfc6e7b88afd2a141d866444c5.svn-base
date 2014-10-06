/**********************************************************************
 * AdSenseHelper Class
 * Version: 1.0
 * Release date: 19/09/2007
 * Copyright (c) 2007 by Alberto Falossi
 * 
 * Web & Blog: http://www.albertofalossi.com
 * 
 * This component is 100% free to use, also in commercial applications.
 * This software is provided "AS IS," without a warranty of any kind.
 ***********************************************************************************/

using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;

namespace BoardHunt.classes
{
    /// <summary>
    /// Helper class to build AdSense banners.
    /// </summary>
    public static class AdSenseHelper
    {
        /// <summary>
        /// Retrieves the markup for the AdSense banner.
        /// </summary>
        /// <param name="parameters">Advertisement parameters.</param>
        /// <returns>The raw markup to insert into the page.</returns>
        public static string GetAdMarkup(Dictionary<string, string> parameters)
        {
            // build the URL
            string url = BuildAdSenseQueryUrl(parameters);

            ErrorLog.ErrorRoutine(false, "URL: " + url);

            // get and return the response markup
            return GetUrl(url);
        }

        /// <summary>
        /// Builds a query URL for the AdSense Server, given the parameters for an advertisement.
        /// </summary>
        /// <param name="parameters">Advertisement parameters.</param>
        /// <returns>The URL to send to the AD Server.</returns>
        public static string BuildAdSenseQueryUrl(Dictionary<string, string> parameters)
        {
            HttpRequest request = HttpContext.Current.Request;

            const string URL_ADSERVER = "http://pagead2.googlesyndication.com/pagead/ads?&"; 

            // prepare some parameters
            long googleDt = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
            string googleScheme = request.IsSecureConnection ? "https://" : "http://";
            string googleHost = googleScheme + request.ServerVariables["HTTP_HOST"];

            StringBuilder url = new StringBuilder(URL_ADSERVER);

            // set "automatic" parameters
            AddDefaultParameter(parameters, "ad_type", "text_image");
            AddDefaultParameter(parameters, "dt", googleDt.ToString());
            AddDefaultParameter(parameters, "host", HttpUtility.UrlEncode(googleHost));
            AddDefaultParameter(parameters, "ip", request.UserHostAddress);
            AddDefaultParameter(parameters, "ref", request.UrlReferrer == null ? "" : HttpUtility.UrlEncode(request.UrlReferrer.ToString()));


            //AddDefaultParameter(parameters, "url", HttpUtility.UrlEncode(request.RawUrl));
            AddDefaultParameter(parameters, "url", HttpUtility.UrlEncode(googleHost) + HttpUtility.UrlEncode(request.ServerVariables["URL"]) ); //+ HttpUtility.UrlEncode(request.RawUrl));
            AddDefaultParameter(parameters, "useragent", HttpUtility.UrlEncode(request.UserAgent) + googleScreenRes());


            // add the parameters to the url
            foreach (System.Collections.Generic.KeyValuePair<string, string> pair in parameters)
            {
                string parameterName = pair.Key;
                string parameterValue = pair.Value;

                // encode the color values
                if (parameterName.Contains("color"))
                    parameterValue = GetGoogleColor(parameterValue, googleDt);

                // add the parameter
                url.AppendFormat("{0}={1}&", parameterName, parameterValue);
            }

            return url.ToString();
        }

        /// <summary>
        /// Add a parameter to the parameters dictionary only if the parameter isn't already present.
        /// </summary>
        /// <param name="parameters">Parameters dictionary.</param>
        /// <param name="parameterName">Parameter name.</param>
        /// <param name="parameterDefaultValue">Parameter value.</param>
        private static void AddDefaultParameter(Dictionary<string, string> parameters, string parameterName, string parameterDefaultValue)
        {
            // set the value only if the key is missing
            if (!parameters.ContainsKey(parameterName))
                parameters[parameterName] = parameterDefaultValue;
        }

        /// <summary>
        /// Get a color according to Google algorithm
        /// </summary>
        /// <param name="value"></param>
        /// <param name="random"></param>
        /// <returns></returns>
        private static string GetGoogleColor(string value, long random)
        {
            string[] colorArray = value.Split(',');
            return colorArray[(int)(random % colorArray.Length)];
        }

        /// <summary>
        /// Send a Web request and returns the server response markup.
        /// </summary>
        /// <param name="url">Request URL.</param>
        /// <returns>A string containing the server response markup. Empty string if an error occurred.</returns>
        private static string GetUrl(string url)
        {
            ErrorLog.ErrorRoutine(false, "GettingURL");

            Stream sream = null;
            StreamReader reader = null;

            try
            {
                // build the request
                System.Net.WebRequest request = WebRequest.Create(url);

                // get the response stream
                sream = request.GetResponse().GetResponseStream();

                // read the stream and copy it to a string; return the string
                reader = new StreamReader(sream);
                //ErrorLog.ErrorRoutine(false, "GetURL: txt: " + reader.ReadToEnd());
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                // generic error, return an empty string
                ErrorLog.ErrorRoutine(false, "GetURL: " + ex.Message);
                return "error";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (sream != null)
                    sream.Close();
            }
        }

        public static string googleColor(string value, double random)
        {
            string[] colorArray = value.Split(',');
            return colorArray[(int)random % colorArray.Length];
        }

        public static string googleScreenRes()
        {
            string screenRes = HttpContext.Current.Request.ServerVariables["HTTP_UA_PIXELS"];
            char delimiter = 'x';
            if (screenRes == null)
            {
                screenRes =
                HttpContext.Current.Request.ServerVariables["HTTP_X_UP_DEVCAP_SCREENPIXELS"];
                delimiter = ',';
            }
            if (screenRes != null)
            {
                string[] resArray = screenRes.Split(delimiter);
                if (resArray.GetUpperBound(0) + 1 == 2)
                {
                    return "&u_w=" + resArray[0] + "&u_h=" + resArray[1];
                }
            }
            return "";
        }

        public static double Timer()
        {
            return (DateTime.Now - DateTime.Now.Date).TotalSeconds;
        } 
    }
}