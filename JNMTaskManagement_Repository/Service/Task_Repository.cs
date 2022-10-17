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
using JNMTaskManagement_Repository.Model;

namespace JNMTaskManagement_Repository.Service
{
    public class Task_Repository : ITask_Repository, IDisposable
    {
        private JNM_TaskManagementEntities context; 
        public Task_Repository(JNM_TaskManagementEntities _context)
        {
            context = _context;
        }
        public Task_Repository()
        {
            context = new JNM_TaskManagementEntities();
        }

        public void DeleteTask(long TaskId)
        {
            try
            {
                TaskDetail obj = context.TaskDetails.Find(TaskId);
                if (obj != null)
                {
                    obj.IsActive = false;
                    obj.DeletedDate = DateTime.Now;
                    //UpdatePaymentEntry(obj);
                }
            }
            catch (Exception ex)
            {
                ex.SetLog("DeletePaymentEntry,Repository");
                throw;
            }
        }

        public TaskDetail GetTaskByID(int TaskId)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[1]; 
                para[0] = new SqlParameter().CreateParameter("@TaskId", TaskId);
                return new dalc().GetDataTable_Text(@"SELECT T.*,P.PriorityName,F.FrequencyType,A.AlertDay,B.AlertDay1,C.AlertDay2 FROM 
dbo.TaskDetails AS T
LEFT JOIN dbo.PriorityMaster AS P ON T.PriorityId = P.PriorityId
LEFT JOIN dbo.FrequencyTypeMaster AS F ON T.FrequencyId = F.FrequencyId
LEFT JOIN dbo.AlertDayMaster AS A ON T.AlertId = A.AlertId  
LEFT JOIN dbo.AlertDay1Master AS B ON T.AlertId1 = B.AlertId1
LEFT JOIN dbo.AlertDay2Master AS C ON T.AlertId2 = C.AlertId2  
WHERE T.IsActive=1 AND T.TaskId=@TaskId", para).ConvertToList<TaskDetail>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.SetLog("GetTaskByID,Repository");
                throw;
            }
        }

        public void InsertTask(TaskDetail objTask)
        {
            try
            {
                objTask.IsActive = true;
                objTask.IsReportingField = false; 
                objTask.CreatedDate = DateTime.Now;
                context.TaskDetails.Add(objTask);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.SetLog("InsertPaymentEntry,Repository");
                throw;
            }
        }

        public void UpdateTask(TaskDetail objTask)
        {
            try
            {
                objTask.UpdatedDate = DateTime.Now;
                context.Entry(objTask).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ex.SetLog("UpdateTask,Repository");
                throw;
            }
        }

        public List<UserAssignModel> GetUserAssignList()
        {
            try
            {
                DataTable dt = new DataTable();
                List<UserAssignModel> user = new List<UserAssignModel>();
                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAllAssignUser", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    con.Close();
                }

                user = CommonFunctions.ConvertToList<UserAssignModel>(dt);
                return user;
            }
            catch (Exception ex)
            {
                ex.SetLog("GetUserAssignList,Repository");
                throw;
            }
        }

        public List<DepartmentModel> GetAllDepartmentList()
        {
            try
            {
                DataTable dt = new DataTable();
                List<DepartmentModel> dep = new List<DepartmentModel>();
                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetDepartmenList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; 
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    con.Close();
                }

                dep = CommonFunctions.ConvertToList<DepartmentModel>(dt);
                return dep;
            }
            catch (Exception ex)
            {
                ex.SetLog("GetAllDepartmentList,Repository");
                throw;
            }
        }

        public List<ClientModel> GetRemoteClient(string search)
        {
            try
            {
                List<ClientModel> client = new List<ClientModel>();
                //// Add parts to the list.
                //client.Add(new Select2Model() { id = 1, text = "MVP1" });
                //client.Add(new Select2Model() { id = 2, text = "MVP11" });
                //client.Add(new Select2Model() { id = 3, text = "ABC2" });
                //client.Add(new Select2Model() { id = 4, text = "ABC3" });
                //client.Add(new Select2Model() { id = 5, text = "XYZ3" });
                //client.Add(new Select2Model() { id = 6, text = "XYZ4" }); 

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetClientList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; 
                        cmd.Parameters.AddWithValue("@Search", search); 
                        con.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    con.Close();
                }

                client = CommonFunctions.ConvertToList<ClientModel>(dt);

                //if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
                //{
                //    client = client.Where(x => x.text.ToLower().StartsWith(search.ToLower())).ToList();
                //}
                return client;
            }
            catch (Exception ex)
            {
                ex.SetLog("GetRemoteClient,Repository");
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
