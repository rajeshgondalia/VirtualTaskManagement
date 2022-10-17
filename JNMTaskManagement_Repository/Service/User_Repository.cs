using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNMTaskManagement_Repository.ServiceContract;
using System.Data.Entity;
using JNMTaskManagement_Repository.Data;
using System.Data;
using System.Data.SqlClient;
using JNMTaskManagement_Repository.DataServices; 

namespace JNMTaskManagement_Repository.Service
{
    public class User_Repository 
        //: IUser_Repository, IDisposable
    {
//        private LNTPOCEntities context; 
//        public User_Repository(LNTPOCEntities _context)
//        {
//            context = _context;
//        }
//        public User_Repository()
//        {
//            context = new LNTPOCEntities();
//        }
//        public void InsertPaymentEntry(PaymentMaster objUser)
//        {
//            try
//            {
//                objUser.IsActive = true;
//                objUser.IsPending = true;
//                objUser.IsFail = false;
//                objUser.CreatedDate = DateTime.Now;
//                context.PaymentMasters.Add(objUser);
//                context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("InsertPaymentEntry,Repository");
//                throw;
//            }
//        }
//        public void UpdatePaymentEntry(PaymentMaster objUser)
//        {
//            try
//            {
//                objUser.UpdatedDate = DateTime.Now;
//                context.Entry(objUser).State = System.Data.Entity.EntityState.Modified;
//                context.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("UpdatePaymentEntry,Repository");
//                throw;
//            }
//        }
//        public void DeletePaymentEntry(int AccountEntryId)
//        {
//            try
//            {
//                PaymentMaster obj = GetPaymentEntryByID(AccountEntryId);
//                if (obj != null)
//                {
//                    obj.IsActive = false;
//                    obj.DeletedDate = DateTime.Now;
//                    UpdatePaymentEntry(obj);
//                }
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("DeletePaymentEntry,Repository");
//                throw;
//            }
//        }

//        public bool PaymentAmount(int AccountEntryId, string TechExcelURL)
//        {
//            Boolean isSuccess = false;
//            try
//            {
//                DataTable dt = new DataTable(); 
//                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("JNM_PaymentReceipt", con))
//                    {
//                        cmd.CommandType = CommandType.StoredProcedure;
//                        cmd.Parameters.AddWithValue("@AccountEntryId", AccountEntryId);
//                        cmd.Parameters.AddWithValue("@TechExcelURL", TechExcelURL);
//                        con.Open();
//                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
//                        {
//                            adapter.Fill(dt);
//                        }
//                    }
//                    con.Close();
//                    isSuccess = Convert.ToBoolean(dt.Rows[0][0].ToString());
//                } 
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("DeletePaymentEntry,Repository");
//                throw;
//            }
//            return isSuccess;
//        }

//        public string PendingAllPayment()
//        {
//            string Message = string.Empty;
//            try
//            {
//                DataTable dt = new DataTable();
//                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
//                {
//                    using (SqlCommand cmd = new SqlCommand("JNM_AllPaymentReceipt", con))
//                    {
//                        cmd.CommandType = CommandType.StoredProcedure; 
//                        con.Open();
//                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
//                        {
//                            adapter.Fill(dt);
//                        }
//                    }
//                    con.Close();
//                    Message = dt.Rows[0][0].ToString();
//                }
//            }
//            catch (Exception ex)
//            {
//                Message = ex.Message;
//                ex.SetLog("DeletePaymentEntry,Repository");
//                throw;
//            }
//            return Message;
//        }

//        public IQueryable<PaymentMaster> GetAllPaymentEntry()
//        {
//            try
//            {
//                return new dalc().selectbyquerydt("SELECT * FROM dbo.PaymentMaster with(nolock) WHERE  IsActive = 1").ConvertToList<PaymentMaster>().AsQueryable();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetAllPaymentEntry,Repository");
//                throw;
//            } 
//        }

//        public IQueryable<AccountCodeMaster> GetAllAccountCode()
//        {
//            try
//            {
//                return new dalc().selectbyquerydt("SELECT * FROM dbo.AccountCodeMaster with(nolock) WHERE  IsActive = 1").ConvertToList<AccountCodeMaster>().AsQueryable();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetAllAccountCode,Repository");
//                throw;
//            }
//        }

//        public IQueryable<CompanyCodeMaster> GetAllCompanyCode()
//        {
//            try
//            {
//                return new dalc().selectbyquerydt("SELECT * FROM dbo.CompanyCodeMaster with(nolock) WHERE  IsActive = 1").ConvertToList<CompanyCodeMaster>().AsQueryable();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetAllCompanyCode,Repository");
//                throw;
//            }
//        }

//        public AccountCodeMaster GetAccountCodeByID(int AccountId)
//        {
//            try
//            {
//                SqlParameter[] para = new SqlParameter[1];
//                para[0] = new SqlParameter().CreateParameter("@AccountId", AccountId);
//                return new dalc().GetDataTable_Text("SELECT * FROM dbo.AccountCodeMaster with(nolock) WHERE AccountId=@AccountId", para).ConvertToList<AccountCodeMaster>().FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetAccountCodeByID,Repository");
//                throw;
//            }
//        }

//        public CompanyCodeMaster GetCompanyCodeByID(int CompanyId)
//        {
//            try
//            {
//                SqlParameter[] para = new SqlParameter[1];
//                para[0] = new SqlParameter().CreateParameter("@CompanyId", CompanyId);
//                return new dalc().GetDataTable_Text("SELECT * FROM dbo.CompanyCodeMaster with(nolock) WHERE CompanyId=@CompanyId", para).ConvertToList<CompanyCodeMaster>().FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetCompanyCodeByID,Repository");
//                throw;
//            }
//        }

//        public PaymentReceiptCodeMaster GetPaymentReceiptCodeByID(int PRId)
//        {
//            try
//            {
//                SqlParameter[] para = new SqlParameter[1];
//                para[0] = new SqlParameter().CreateParameter("@PRId", PRId);
//                return new dalc().GetDataTable_Text("SELECT * FROM dbo.PaymentReceiptCodeMaster with(nolock) WHERE Id=@PRId", para).ConvertToList<PaymentReceiptCodeMaster>().FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetPaymentReceiptCodeByID,Repository");
//                throw;
//            }
//        }

//        public PaymentMaster GetPaymentEntryByID(int AccountEntryId)
//        {
//            try
//            {
//                SqlParameter[] para = new SqlParameter[1];
//                para[0] = new SqlParameter().CreateParameter("@AccountEntryId", AccountEntryId);
//                return new dalc().GetDataTable_Text(@"SELECT P.AccountEntryId,P.AccountId,A.AccountCode,P.CompanyId,C.CompanyCode,P.PaymentId,PM.PRCode AS PaymentCode,P.ReceiptId,PM.PRCode AS ReceiptCode,P.Amount,P.TransactionNo,P.CreatedDate,P.PaymentDate,P.IsPending,P.IsFail,P.Narration
//FROM dbo.PaymentMaster AS P
//INNER JOIN dbo.AccountCodeMaster AS A ON A.AccountId = P.AccountId
//INNER JOIN dbo.CompanyCodeMaster AS C ON C.CompanyId = P.CompanyId
//INNER JOIN dbo.PaymentReceiptCodeMaster AS PM ON PM.Id = P.PaymentId
//INNER JOIN dbo.PaymentReceiptCodeMaster AS R ON R.Id = P.ReceiptId
//WHERE P.IsActive=1
//AND P.AccountEntryId=@AccountEntryId", para).ConvertToList<PaymentMaster>().FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                ex.SetLog("GetPaymentEntryByID,Repository");
//                throw;
//            }
//        }
//        //public UserMaster LogInUsers(string UserName, string Password)
//        //{
//        //    try
//        //    {
//        //        SqlParameter[] para = new SqlParameter[2];
//        //        para[0] = new SqlParameter().CreateParameter("@UserName", UserName);
//        //        para[1] = new SqlParameter().CreateParameter("@Password", Password);
//        //        return new dalc().GetDataTable_Text("SELECT * FROM dbo.UserMaster with(nolock) WHERE UserName=@UserName and Password=@Password", para).ConvertToList<UserMaster>().FirstOrDefault();
//        //    }
//        //    catch(Exception ex)
//        //    {
//        //        ex.SetLog("LogIn error,Repository");
//        //        throw;
//        //    }
//        //} 

//        //public bool IsDuplicate(string UserName)
//        //{
//        //    try
//        //    {
//        //        SqlParameter[] para = new SqlParameter[1];
//        //        para[0] = new SqlParameter().CreateParameter("@UserName", UserName);
//        //        DataTable dt = new dalc().GetDataTable_Text("SELECT * FROM UserMaster with(nolock) WHERE UserName=@UserName and IsActive = 1", para);
//        //        return dt.Rows.Count > 0 ? true : false;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ex.SetLog("IsDuplicateUser,Repository");
//        //        throw;
//        //    }
//        //}
//        //public bool IsDuplicateEmail(string Email)
//        //{
//        //    try
//        //    {
//        //        SqlParameter[] para = new SqlParameter[1];
//        //        para[0] = new SqlParameter().CreateParameter("@Email", Email);
//        //        DataTable dt = new dalc().GetDataTable_Text("SELECT * FROM UserMaster with(nolock) WHERE Email=@Email and IsActive = 1", para);
//        //        return dt.Rows.Count > 0 ? true : false;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ex.SetLog("IsDuplicateEmail,Repository");
//        //        throw;
//        //    }
//        //}
//        //public bool IsDuplicateEdit(string UserName,int UserId)
//        //{
//        //    try
//        //    {
//        //        SqlParameter[] para = new SqlParameter[2];
//        //        para[0] = new SqlParameter().CreateParameter("@UserName", UserName);
//        //        para[1] = new SqlParameter().CreateParameter("@UserId", UserId);
//        //        DataTable dt = new dalc().GetDataTable_Text("SELECT * FROM UserMaster with(nolock) WHERE UserName=@UserName AND UserId<>@UserId and IsActive = 1", para);
//        //        return dt.Rows.Count > 0 ? true : false;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        ex.SetLog("IsDuplicate,Repository");
//        //        throw;
//        //    }
//        //}

        //#region IDisposable Support
        //private bool disposedValue = false; // To detect redundant calls

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }

        //        disposedValue = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //} 
        //#endregion
    }
}
