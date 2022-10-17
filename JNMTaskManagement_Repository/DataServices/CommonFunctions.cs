using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.IO;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace JNMTaskManagement_Repository.DataServices
{
    public static class CommonFunctions
    {
        //        public static object HttpContext { get; private set; }

        public static List<T> ConvertToList<T>(this DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name.ToLower() == column.ColumnName.ToLower())
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(dr[column.ColumnName])))
                            pro.SetValue(obj, dr[column.ColumnName]);
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
        public static string ToTimeAgo(this DateTime dt)
        {
            if (dt == DateTime.Now)
                return "about sometime from now";
            TimeSpan span = DateTime.Now - dt;

            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
            }

            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
            }

            if (span.Days > 0)
                return String.Format("about {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");

            if (span.Hours > 0)
                return String.Format("about {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");

            if (span.Minutes > 0)
                return String.Format("about {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

            if (span.Seconds > 5)
                return String.Format("about {0} seconds ago", span.Seconds);

            if (span.Seconds >= 5)
                return "just now";

            return string.Empty;
        }
        public static string getclass(string color)
        {
            if (color == "Green")
            {
                return "online-status-online";
            }
            else if (color == "Yellow")
            {
                return "online-status-recent";
            }
            else
            {
                return "online-status-offline";
            }

        }
        public static string Toonlineoffline(this DateTime dt)
        {
            if (dt == DateTime.Now)
                return "about sometime from now|Green";
            TimeSpan span = DateTime.Now - dt;

            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("about {0} {1} ago|Black", years, years == 1 ? "year" : "years");
            }

            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("about {0} {1} ago|Black", months, months == 1 ? "month" : "months");
            }

            if (span.Days > 0)
                return String.Format("about {0} {1} ago|Black", span.Days, span.Days == 1 ? "day" : "days");

            if (span.Hours > 0)
                return String.Format("about {0} {1} ago|Yellow", span.Hours, span.Hours == 1 ? "hour" : "hours");

            if (span.Minutes > 0)
                return String.Format("about {0} {1} ago|Green", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");

            if (span.Seconds > 5)
                return String.Format("about {0} seconds ago|Green", span.Seconds);

            else
                return "just now|Green";

            // return string.Empty;
        }
        public static void SetLog(this Exception ex, string msg, Boolean IsRedirect = false)
        {
            if (ex is System.Data.Entity.Validation.DbEntityValidationException)
            {
                foreach (var validationErrors in ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += ";" + string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                    }
                }
            }
            string FileName = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year;
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Logs")))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Logs"));
            if (!File.Exists(HttpContext.Current.Server.MapPath("~/Logs/" + FileName + ".txt")))
            {
                using (StreamWriter sw = File.CreateText(HttpContext.Current.Server.MapPath("~/Logs/" + FileName + ".txt")))
                {
                    // StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/" + FileName + ".txt"), true);
                    sw.WriteLine("Error on " + DateTime.Now + " ,Exception Message:" + ex.Message + ",Inner Message:" + ex.InnerException + ",Line:" + ex.StackTrace + ",Additional Msg:" + msg);
                    sw.Flush();
                    sw.Close();
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(HttpContext.Current.Server.MapPath("~/Logs/" + FileName + ".txt")))
                {
                    sw.WriteLine("Error on " + DateTime.Now + " ,Exception Message:" + ex.Message + ",Inner Message:" + ex.InnerException + ",Line:" + ex.StackTrace + ",Additional Msg: " + msg);
                    sw.Flush();
                    sw.Close();
                }
            }
            if (IsRedirect)
            {
                HttpContext.Current.Server.ClearError();
                HttpContext.Current.Response.Redirect("/Error/Index", true);
            }
        }
        public static void sendmail(string email, string strbody, string subject)
        {
            try
            {
                //strbody += "<br /><br />If You Dont want any email / Unsubscribe from pipcoin than click on ";
                //strbody = HttpContext.Current.Server.HtmlEncode(strbody);
                //var request = (HttpWebRequest)WebRequest.Create("http://trans.mailingservice.in/Email/API/SendEmailXml.aspx");


                //var postData = @"<apiinfo><api_user>7405249551</api_user><api_key>CBCDE</api_key><from>noreply@mypipcoins.com</from><fromname>My Pipcoins</fromname><replyto>noreply@mypipcoins.com</replyto><to>" + email + "</to><subject>" + subject + "</subject><body><html><body>" + strbody + "</body></html></body><spamlinkrequired>False</spamlinkrequired><unsubscribelinkrequired>False</unsubscribelinkrequired><scheduletime></scheduletime></apiinfo>";
                //var data = System.Text.Encoding.ASCII.GetBytes(postData);

                //request.Method = "POST";
                //request.ContentType = "text/xml; charset=utf-8";
                //request.ContentLength = data.Length;

                //using (var stream = request.GetRequestStream())
                //{
                //    stream.Write(data, 0, data.Length);
                //}

                //var response = (HttpWebResponse)request.GetResponse();

                //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                ////Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(email);
                //Configure the address we are sending the mail from
                MailAddress address = new MailAddress("cears.sunny@gmail.com");
                msg.From = address;
                msg.Subject = subject;
                msg.Body = strbody;
                msg.IsBodyHtml = true;
                //Configure an SmtpClient to send the mail.
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;
                client.Host = "68.168.100.184";
                client.Port = 25;

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential("cears.sunny@gmail.com", "sunny12345");
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);
                // lblmesg.Text = txtemail.Text + " Sent";
            }
            catch (Exception ex)
            {
                // lblmesg.Text = ex.ToString();
            }
        }
    }
}
