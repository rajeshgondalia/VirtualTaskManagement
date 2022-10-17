using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JNMTaskManagement_Repository.Data;
using JNMTaskManagement_Repository.Model;

namespace JNMTaskManagement_Repository.ServiceContract
{
    public interface ITask_Repository : IDisposable
    {
        void InsertTask(TaskDetail objTask);
        void UpdateTask(TaskDetail objTask);
        void DeleteTask(long TaskId);
        TaskDetail GetTaskByID(int TaskId);
        List<ClientModel> GetRemoteClient(string search);
        List<DepartmentModel> GetAllDepartmentList();
        List<UserAssignModel> GetUserAssignList();
    }
}
