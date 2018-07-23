using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SEPApplication
{
    public class API
    {
        public class LoginData
        {
            public string Id { get; set; }
            public string Secret { get; set;}
        }
        public class LoginResult
        {
            
            public int Code { get; set; }
            public LoginData Data { get; set; }
            public string Messenger { get; set; }
        }
        public class CourseData
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Info { get; set; }

        }
        public class GetCourseResult
        {
            public int Code { get; set; }
            public CourseData[] Data { get; set; }
            public string Messenger { get; set; }
        }
        public LoginResult Login(string username, string password)
        {
            using (var client = new WebClient())
            {
                var form = new NameValueCollection();
                form["Username"] = username;
                form["Password"] = password;
                var result = client.UploadValues("http://cntttest.vanlanguni.edu.vn:8080/CMU/SEPAPI/SEP21/Login", "POST", form);

                var json = Encoding.UTF8.GetString(result);
                return JsonConvert.DeserializeObject<LoginResult>(json);
                
                //var reqparm = new System.Collections.Specialized.NameValueCollection();
                //reqparm.Add("param1", "<any> kinds & of = ? strings");
                //reqparm.Add("param2", "escaping is already handled");
                //byte[] responsebytes = client.UploadValues("http://localhost", "POST", reqparm);
                //string responsebody = Encoding.UTF8.GetString(responsebytes);
            }
        }
        public GetCourseResult GetCourse(string lecturerID)
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString(
                    "http://cntttest.vanlanguni.edu.vn:8080/CMU/SEPAPI/SEP21" + "/GetCourses?lecturerID=" + lecturerID);

                return JsonConvert.DeserializeObject<GetCourseResult>(json);

            }
        }
    }
}