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
        // xem cấu trúc trên api
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
        public class StudentData{
            public string Id{ get; set;}
            public string Fullname{get; set;}
            public DateTime Birthday{get;set;}

        }
        public class GetStudentResult
        {
            public int Code { get; set; }
            public string Message { get; set; }
           public StudentData Data {get;set;}
        }
        // login trả về kiểu loginresult
        public LoginResult Login(string username, string password)
        {
            using (var client = new WebClient())
            {
                var form = new NameValueCollection();
                // lấy thông tin từ api về
                form["Username"] = username;
                form["Password"] = password;
                // lấy tt từ api về trả lưu vô biến result kiểu byte[]
                var result = client.UploadValues("http://cntttest.vanlanguni.edu.vn:8080/CMU/SEPAPI/SEP21/Login", "POST", form);
                //ép kiểu đưa về mong muốn là string đưa vô thư viện
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
                // lấy khóa học nhân về
                var json = client.DownloadString(
                    "http://cntttest.vanlanguni.edu.vn:8080/CMU/SEPAPI/SEP21" + "/GetCourses?lecturerID=" + lecturerID);

                return JsonConvert.DeserializeObject<GetCourseResult>(json);

            }
        }
        public GetStudentResult GetStudent(string code)
        {
             using (var client = new WebClient())
            {
                // lấy khóa học nhân về
                var json = client.DownloadString(
                    "http://cntttest.vanlanguni.edu.vn:8080/CMU/SEPAPI/SEP21" + "/GetStudent?code=" + code);

                return JsonConvert.DeserializeObject<GetStudentResult>(json);

            }
        }

    }
}