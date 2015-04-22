using System;
using System.Net;
using System.Text;
using System.IO;


    public class traceviewTest
    {
		public static void Main()
		{
			const string url = "http://www.google.com";
			const int maxHtmlMarkupCharToLookAt = 1000;
			var request = (HttpWebRequest)WebRequest.Create(url);

			var response = (HttpWebResponse)request.GetResponse();

			Console.WriteLine("Method is {0}",response.Method);
			Console.WriteLine("Status code is {0}", response.StatusCode);
			Console.WriteLine("Content type is {0}", response.ContentType);

			var receiveStream = response.GetResponseStream();
			if (receiveStream != null)
			{
				var readStream = new StreamReader(receiveStream, Encoding.UTF8);

				Console.WriteLine("Reading google HTML markup...");
				var htmlMarkup = readStream.ReadToEnd();
				if (htmlMarkup.Length > maxHtmlMarkupCharToLookAt)
					Console.WriteLine(htmlMarkup.Substring(0, maxHtmlMarkupCharToLookAt));
				else
					Console.WriteLine(htmlMarkup);
				Console.WriteLine("...");
				Console.ReadLine();
				response.Close();
				readStream.Close();
			}
		}
	}
}

/*

 * The output looks like:
 * Method is GET
 * Status code is OK
 * Content type is text/html; charset=ISO-8859-1
 * Reading page…
 * <!DOCTYPE html>
 * ...
 * </html>
*/
