using System;
using System.Net;
using System.Text;
using System.IO;


    public class traceviewTest
    {

        public static void Main ()
        {
            const string url = "http://www.appneta.com";
            var request = (HttpWebRequest)WebRequest.Create (url);

            var response = (HttpWebResponse)request.GetResponse ();

            Console.WriteLine ("Content length is {0}", response.ContentLength);
            Console.WriteLine ("Content type is {0}", response.ContentType);

            var receiveStream = response.GetResponseStream ();
            var readStream = new StreamReader (receiveStream, Encoding.UTF8);

            Console.WriteLine ("Reading appneta HTML markup...");
            Console.WriteLine (readStream.ReadToEnd ());
            response.Close ();
            readStream.Close ();
        }
    }

/*
The output looks like:
Content length is 8070
Content type is text/plain; charset=utf-8
Reading page…
<!DOCTYPE html>
...
</html>
*/