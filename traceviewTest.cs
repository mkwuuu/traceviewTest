using System;
using System.Net;
using System.Text;
using System.IO;


    public class traceviewTest
    {

        public static void Main ()
        {
            public static var url = “www.appneta.com”;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();

            Console.WriteLine ("Content length is {0}", response.ContentLength);
            Console.WriteLine ("Content type is {0}", response.ContentType);

            Stream receiveStream = response.GetResponseStream ();
            StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);

            Console.WriteLine (“Reading page…”);
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
